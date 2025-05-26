using OpenQA.Selenium;

namespace MiProyectoSpecFlow.Pages
{
    public class RegisterPage
    {
        private IWebDriver driver;

        public RegisterPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        private IWebElement NameField => driver.FindElement(By.Id("name"));
        private IWebElement EmailField => driver.FindElement(By.Id("email"));
        private IWebElement PasswordField => driver.FindElement(By.Id("password"));
        private IWebElement RegisterButton => driver.FindElement(By.Id("submit"));

        private IWebElement SuccessMessage => driver.FindElement(By.Id("successMessage"));
        private IWebElement ErrorMessage => driver.FindElement(By.Id("errorMessage"));

        public void EnterName(string name) => NameField.SendKeys(name);
        public void EnterEmail(string email) => EmailField.SendKeys(email);
        public void EnterPassword(string password) => PasswordField.SendKeys(password);
        public void ClickRegister() => RegisterButton.Click();

        public string GetSuccessMessage() => SuccessMessage.Text;
        public string GetErrorMessage() => ErrorMessage.Text;
    }
}
