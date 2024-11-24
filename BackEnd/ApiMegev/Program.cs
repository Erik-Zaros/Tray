using megev.Endpoints;
using megev;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });

        builder.Services.AddDbContext<MegevDbContext>(options =>
        {
            options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                             ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")));
        });

        var jwtSettings = builder.Configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["SecretKey"];

        if (string.IsNullOrEmpty(secretKey))
        {
            throw new InvalidOperationException("Chave secreta do JWT não está configurada.");
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = key,
                    ClockSkew = TimeSpan.Zero
                };
            });

        builder.Services.AddAuthorization();
        builder.Services.AddControllers();  

        var app = builder.Build();

        var staticFileOptions = new StaticFileOptions
        {
            FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
                Path.Combine(app.Environment.ContentRootPath, "Static")
            ),
            RequestPath = "/static"
        };
        app.UseStaticFiles(staticFileOptions);

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseCors();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        app.RegistrarEndpointsUsuarios();
        app.RegistrarEndpointsProdutos();
        app.RegistrarEndpointsMetodoPagamento();
        app.RegistrarEndpointsMetodosEntrega();
        app.RegistrarEndpointsObjetivoLoja();
        app.RegistrarEndpointsLoja();
        app.RegistrarEndpointsCategoriaProduto();

        app.Run();
    }
}
