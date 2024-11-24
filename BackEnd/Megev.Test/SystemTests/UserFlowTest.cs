using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using megev.Models;
using megev;
using Microsoft.Extensions.Configuration;
using System.Threading;

namespace Megev.Test.SystemTests
{
    public class UserFlowTest : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly MegevDbContext _dbContext;

        public UserFlowTest()
        {
            _driver = new ChromeDriver();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MegevDbContext>();
            optionsBuilder.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                                    ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")));

            _dbContext = new MegevDbContext(optionsBuilder.Options);
        }

        [Fact]
        public void TestUserFlow()
        {
            _driver.Navigate().GoToUrl("http://localhost:5116/static/formulario_crud_usuarios_db.html");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(150));

            try
            {
                IWebElement nomeField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("nome")));
                nomeField.SendKeys("FluxoNomeEditado");

                IWebElement sobrenomeField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("sobrenome")));
                sobrenomeField.SendKeys("FluxoSobrenome");

                IWebElement emailField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("email")));
                emailField.SendKeys("fluxo@teste.com");

                IWebElement senhaField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("senha")));
                senhaField.SendKeys("123456");

                IWebElement salvarButton = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnSalvar")));
                salvarButton.Click();

                wait.Until(ExpectedConditions.AlertIsPresent());
                _driver.SwitchTo().Alert().Accept();

                IWebElement tabelaUsuarios = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("tabelaUsuarios")));
                Assert.Contains("FluxoNomeEditado", tabelaUsuarios.Text);

                var usuarioAtualizado = _dbContext.Usuario.FirstOrDefault(u => u.Email == "fluxo@teste.com");
                Assert.NotNull(usuarioAtualizado);
                Assert.Equal("FluxoNomeEditado", usuarioAtualizado.Nome);
                Assert.Equal("FluxoSobrenome", usuarioAtualizado.Sobrenome);

                Console.WriteLine("Teste concluído com sucesso.");
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Elemento não encontrado: {ex.Message}");
                Assert.Fail("O elemento esperado não foi encontrado.");
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine($"Tempo de espera excedido: {ex.Message}");
                Assert.Fail("O elemento esperado demorou muito para ser carregado.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                Assert.Fail("Erro inesperado durante o teste.");
            }
            finally
            {
                Thread.Sleep(30000);

                Dispose();
            }
        }

        public void Dispose()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }

            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
    }
}
