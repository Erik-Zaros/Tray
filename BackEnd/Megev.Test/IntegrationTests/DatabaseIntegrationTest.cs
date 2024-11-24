using megev;
using megev.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class DatabaseIntegrationTest
{
    private DbContextOptions<MegevDbContext> _options;

    public DatabaseIntegrationTest()
    {
        _options = new DbContextOptionsBuilder<MegevDbContext>()
            .UseInMemoryDatabase("megev_tray")
            .Options;
    }

    [Fact]
    public async void ShouldSaveUsuarioToDatabase()
    {
        using var context = new MegevDbContext(_options);
        var usuario = new Usuario("Teste", "Sobrenome", "teste@email.com", "senha", 100, "default-image.png");

        context.Usuario.Add(usuario);
        await context.SaveChangesAsync();

        var savedUsuario = await context.Usuario.FirstOrDefaultAsync(u => u.Email == "teste@email.com");
        Assert.NotNull(savedUsuario);
        Assert.Equal("Teste", savedUsuario.Nome);
        Assert.Equal("default-image.png", savedUsuario.UserImage);
    }

    [Fact]
    public async void ShouldUpdateUsuarioInDatabase()
    {
        using var context = new MegevDbContext(_options);
        var usuario = new Usuario("Teste", "Sobrenome", "teste@email.com", "senha", 100, "default-image.png");
    
        context.Usuario.Add(usuario);
        await context.SaveChangesAsync();
    
        var savedUsuario = await context.Usuario.FirstOrDefaultAsync(u => u.Email == "teste@email.com");
        if (savedUsuario == null)
        {
            throw new InvalidOperationException("Usuário não encontrado no banco de dados.");
        }
    
        savedUsuario.Nome = "Nome Atualizado";
        await context.SaveChangesAsync();
    
        var updatedUsuario = await context.Usuario.FirstOrDefaultAsync(u => u.Email == "teste@email.com");
        Assert.NotNull(updatedUsuario);
        Assert.Equal("Nome Atualizado", updatedUsuario!.Nome);
    }


    [Fact]
    public async void ShouldDeleteUsuarioFromDatabase()
    {
        using var context = new MegevDbContext(_options);
        var usuario = new Usuario("Teste", "Sobrenome", "teste@email.com", "senha", 100, "default-image.png");

        context.Usuario.Add(usuario);
        await context.SaveChangesAsync();

        context.Usuario.Remove(usuario);
        await context.SaveChangesAsync();

        var deletedUsuario = await context.Usuario.FirstOrDefaultAsync(u => u.Email == "teste@email.com");
        Assert.Null(deletedUsuario);
    }
}
