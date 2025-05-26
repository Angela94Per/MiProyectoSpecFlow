using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

public class LoginPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void EnterUsername(string username)
    {
        var usernameInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Username")));
        usernameInput.Clear();
        usernameInput.SendKeys(username);
    }

    public void EnterPassword(string password)
    {
        var passwordField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Password")));
        passwordField.Clear();
        passwordField.SendKeys(password);
    }

    public void ClickLogin()
    {
        var loginButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[name='button'][value='login']")));
        loginButton.Click();
    }
    public bool IsLoginPageDisplayed()
{
    try
    {
        return wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Username"))).Displayed;
    }
    catch (WebDriverTimeoutException)
    {
        return false;
    }   
    }
   
}
