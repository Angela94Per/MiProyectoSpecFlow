// -----------------------------------------------------------------------------
// Archivo      : LoginSteps.cs
// Descripción  : [El archivo implementa pruebas de comportamiento (BDD) para verificar el login en una aplicación web, con estos pasos:
//                  [BeforeScenario] Setup(): Inicia el navegador Chrome y configura la página de login antes de cada escenario.
//                  [AfterScenario] TearDown(): Cierra el navegador después del escenario.
//                  Given I navigate to the login page: Navega a la URL del login y verifica que se haya cargado correctamente.
//                  When I enter valid credentials: Ingresa el usuario y la contraseña válidos.
//                  When I click the login button: Hace clic en el botón de login.
//                  Then I should see the main layout loaded: Verifica que la página principal del sistema se haya cargado correctamente (buscando un elemento con id page-top y luego wrapper).]
// Autor        : [Nombre del autor original]
// Fecha creación: [26/05/2025]
// 
// Historial de cambios:
// Fecha        | Autor             | Descripción
// -------------|------------------|--------------------------------------------
// 10/04/2024   | Juan Pérez        | Creación del archivo y lógica principal
// 15/05/2024   | Ana Gómez         | Corrección de bugs en el método X
// 28/05/2025   | Carlos Méndez     | Mejora de rendimiento y refactorización
// -----------------------------------------------------------------------------

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace MiProyectoSpecFlow.Steps
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver driver = null!;
        private LoginPage loginPage = null!;

        [BeforeScenario]
        public void Setup()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
        }

        [AfterScenario]
        public void TearDown()
        {
            driver.Quit();
        }

        [Given(@"I navigate to the login page")]
        public void GivenINavigateToTheLoginPage()
        {
            driver.Navigate().GoToUrl("https://advancedqa.calibrify.app:8443/Account/Login?...");

            Assert.IsTrue(loginPage.IsLoginPageDisplayed(), "La página de login no se cargó correctamente.");

        }

        [When(@"I enter valid credentials")]
        public void WhenIEnterValidCredentials()
        {
            loginPage.EnterUsername("alice");
            loginPage.EnterPassword("Pass123$");
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            loginPage.ClickLogin();
        }

        [Then(@"I should see the main layout loaded")]
        public void ThenIShouldSeeTheMainLayoutLoaded()
        
        {
            Console.WriteLine(">> Verificando carga de layout principal...");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            // Esperar que el elemento con id "wrapper" esté presente y visible
            var wrapper = wait.Until(d =>
            {
                try
                {
                    var element = d.FindElement(By.Id("page-top"));
                    return element.Displayed ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
            
            var pageTop = driver.FindElement(By.Id("wrapper"));

            Assert.IsTrue(pageTop.Displayed, "El 'body' con id 'page-top' no se encuentra.");

    }
   } 
}
