using megev.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace megev.Endpoints
{
    public static class UsuarioEndpoints
    {
        public static void RegistrarEndpointsUsuarios(this IEndpointRouteBuilder rotas)
        {
            var rotaUsuarios = rotas.MapGroup("/usuarios");

            rotaUsuarios.MapPost("/registrar-usuario", async (MegevDbContext dbContext, UsuarioDTO usuarioDto) =>
            {
                var usuario = new Usuario
                {
                    Nome = usuarioDto.Nome,
                    Sobrenome = usuarioDto.Sobrenome,
                    Email = usuarioDto.Email,
                    Senha = BCrypt.Net.BCrypt.HashPassword(usuarioDto.Senha),
                    SaldoConta = usuarioDto.SaldoConta,
                    UserImage = usuarioDto.UserImage
                };

                dbContext.Usuario.Add(usuario);
                await dbContext.SaveChangesAsync();

                return Results.Created($"/usuarios/{usuario.Id}", usuario);
            });

            rotaUsuarios.MapPost("/login", async (MegevDbContext dbContext, UsuarioLoginDTO loginDto, IConfiguration config) =>
            {
                var usuario = await dbContext.Usuario.SingleOrDefaultAsync(u => u.Email == loginDto.Email);

                if (usuario == null || !BCrypt.Net.BCrypt.Verify(loginDto.Senha, usuario.Senha))
                {
                    return Results.Unauthorized();
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Email),
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())
                };

                var jwtSettings = config.GetSection("JwtSettings");
                var secretKey = jwtSettings["SecretKey"];

                if (string.IsNullOrEmpty(secretKey))
                {
                    return Results.Problem("Chave secreta do JWT não configurada corretamente.", statusCode: 500);
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: jwtSettings["Issuer"],
                    audience: jwtSettings["Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["ExpirationInMinutes"])),
                    signingCredentials: creds
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Results.Ok(new
                {
                    Mensagem = "Login bem-sucedido.",
                    UsuarioId = usuario.Id,
                    Token = tokenString
                });
            });

            rotaUsuarios.MapPut("/editar-usuario/{id:int}", async (int id, MegevDbContext dbContext, UsuarioDTO usuarioDto) =>
            {
                var usuario = await dbContext.Usuario.FindAsync(id);

                if (usuario == null)
                {
                    return Results.NotFound("Usuário não encontrado.");
                }

                usuario.Nome = usuarioDto.Nome;
                usuario.Sobrenome = usuarioDto.Sobrenome;
                usuario.Email = usuarioDto.Email;
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuarioDto.Senha);
                usuario.SaldoConta = usuarioDto.SaldoConta;
                usuario.UserImage = usuarioDto.UserImage;

                dbContext.Usuario.Update(usuario);
                await dbContext.SaveChangesAsync();

                return Results.Ok("Usuário atualizado com sucesso.");
            });

            rotaUsuarios.MapDelete("/excluir-usuario/{id:int}", async (int id, MegevDbContext dbContext) =>
            {
                var usuario = await dbContext.Usuario.FindAsync(id);

                if (usuario == null)
                {
                    return Results.NotFound("Usuário não encontrado.");
                }

                dbContext.Usuario.Remove(usuario);
                await dbContext.SaveChangesAsync();

                return Results.Ok("Usuário excluído com sucesso.");
            });

            rotaUsuarios.MapGet("/{id:int}", async (int id, MegevDbContext dbContext) =>
            {
                var usuario = await dbContext.Usuario.SingleOrDefaultAsync(u => u.Id == id);

                if (usuario == null)
                {
                    return Results.NotFound("Usuário não encontrado.");
                }

                var usuarioDto = new UsuarioOutputDto
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Sobrenome = usuario.Sobrenome,
                    Email = usuario.Email,
                    SaldoConta = usuario.SaldoConta,
                    UserImage = usuario.UserImage
                };

                return TypedResults.Ok(usuarioDto);
            });

            rotaUsuarios.MapGet("/", async (MegevDbContext dbContext) =>
            {
                var usuarios = await dbContext.Usuario
                    .Select(u => new UsuarioOutputDto
                    {
                        Id = u.Id,
                        Nome = u.Nome,
                        Sobrenome = u.Sobrenome,
                        Email = u.Email,
                        SaldoConta = u.SaldoConta,
                        UserImage = u.UserImage
                    })
                    .ToListAsync();

                return TypedResults.Ok(usuarios);
            });
        }
    }
}
