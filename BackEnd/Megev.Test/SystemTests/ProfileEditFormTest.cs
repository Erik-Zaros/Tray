using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using Xunit;

namespace Megev.Test.SystemTests
{
    public class ProfileEditFormTest : IDisposable
    {
        private readonly IWebDriver _driver;

        public ProfileEditFormTest()
        {
            _driver = new ChromeDriver();
        }

        [Fact]
        public void TestCrudUserProfile()
        {
            _driver.Navigate().GoToUrl("http://localhost:5116/static/formulario_crud_usuarios.html");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(150)); 

            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("nome")));

                IWebElement nomeField = _driver.FindElement(By.Id("nome"));
                nomeField.SendKeys("TesteNome");

                IWebElement sobrenomeField = _driver.FindElement(By.Id("sobrenome"));
                sobrenomeField.SendKeys("TesteSobrenome");

                IWebElement emailField = _driver.FindElement(By.Id("email"));
                emailField.SendKeys("teste@teste.com");

                IWebElement senhaField = _driver.FindElement(By.Id("senha"));
                senhaField.SendKeys("123456");

                IWebElement salvarButton = _driver.FindElement(By.Id("btnSalvar"));
                salvarButton.Click();

                wait.Until(ExpectedConditions.AlertIsPresent());
                _driver.SwitchTo().Alert().Accept();

                IWebElement tabelaUsuarios = _driver.FindElement(By.Id("tabelaUsuarios"));
                Assert.Contains("TesteNome", tabelaUsuarios.Text);

                IWebElement editarButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()='Editar']")));
                editarButton.Click();

                nomeField = _driver.FindElement(By.Id("nome"));
                nomeField.Clear();
                nomeField.SendKeys("NomeEditado");

                salvarButton = _driver.FindElement(By.Id("btnSalvar"));
                salvarButton.Click();

                wait.Until(ExpectedConditions.AlertIsPresent());
                _driver.SwitchTo().Alert().Accept();

                tabelaUsuarios = _driver.FindElement(By.Id("tabelaUsuarios"));
                Assert.Contains("NomeEditado", tabelaUsuarios.Text);

                IWebElement excluirButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()='Excluir']")));
                excluirButton.Click();

                wait.Until(ExpectedConditions.AlertIsPresent());
                _driver.SwitchTo().Alert().Accept();

                tabelaUsuarios = _driver.FindElement(By.Id("tabelaUsuarios"));
                Assert.DoesNotContain("NomeEditado", tabelaUsuarios.Text);
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
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
