using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using NUnit.Framework;
using MiProyectoSpecFlow.Pages;
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

    }
   } 
}
