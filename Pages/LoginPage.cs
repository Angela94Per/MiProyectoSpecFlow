// -----------------------------------------------------------------------------
// Archivo      : LoginPage.cs
// Descripción  : [La clase LoginPage automatiza el proceso de inicio de sesión en una página web. Permite:
//                  Ingresar un nombre de usuario (EnterUsername).
//                  Ingresar una contraseña (EnterPassword).
//                  Hacer clic en el botón de inicio de sesión (ClickLogin).
//                  Verificar si la página de inicio de sesión está visible (IsLoginPageDisplayed).
//                  Utiliza esperas explícitas (WebDriverWait) para asegurar que los elementos estén presentes y listos antes de interactuar con ellos.]
// Autor        : [Nombre del autor original]
// Fecha creación: [26/05/2025]
// 
// Historial de cambios:
// Fecha        | Autor             | Descripción
// -------------|------------------|--------------------------------------------
// ------------ | Juan Pérez        | Creación del archivo y lógica principal
// ------------ | Ana Gómez         | Corrección de bugs en el método X
// 28/05/2025   | Carlos Méndez     | Mejora de rendimiento y refactorización
// -----------------------------------------------------------------------------

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
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(35));
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
            var waitShort = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return waitShort.Until(ExpectedConditions.ElementIsVisible(By.Id("Username"))).Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            Console.WriteLine("La página de login no se mostró dentro del tiempo esperado.");
            return false;
        }
    }
      public bool ValidateOnLoginPage(int timeoutInSeconds = 15)
{
    try
    {
        var waitShort = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

        // Esperar que la URL contenga "/Account/Login" o similar
        waitShort.Until(drv => drv.Url.Contains("/Account/Login", StringComparison.OrdinalIgnoreCase));

        // Opcional: validar visibilidad del campo de usuario
        var usernameField = waitShort.Until(ExpectedConditions.ElementIsVisible(By.Id("Username")));
        return usernameField.Displayed;
    }
    catch (WebDriverTimeoutException)
    {
        Console.WriteLine("No se está en la página de login.");
        return false;
    }
}
}
