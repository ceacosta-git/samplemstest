using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SampleTest;

[TestClass]
public class LoginTest : BaseChromeTest
{
    //
    // Summary:
    //     Write a Selenium test script in C# that performs the following steps:
    //     Open the web browser (e.g., Chrome).
    //     Navigate to the login page:  www.sampletest.com/login
    //     Enter valid credentials into textboxes with css ID’s “username” and “password”.
    //     Credentials:
    //         Username: user
    //         Password: testpassword
    //     Click the “Login” button.
    //     Verify successful login (e.g., check for a welcome message).
    //         css ID: successBanner – Message contains “Success”
    //
    // Note: Test fails because www.sampletest.com/login UI does not have the elements described in Summary.
    // Please run LoginErrorsWhenAccountIsLocked which has a similar intent.

    [TestMethod]
    public void CanLoginToSampleTest()
    {
        driver.Url = "www.sampletest.com/login";

        //ToDo: create Page Object Model for LoginPage
        IWebElement usernameInput = driver.FindElement(By.CssSelector("#username"));
        IWebElement passwordInput = driver.FindElement(By.CssSelector("#password"));
        //ToDo: confirm how the button is implemented. Assumes button with text "Login".
        IWebElement loginBtn = driver.FindElement(By.XPath("//button[contains(text(),\"Login\")]"));

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
        wait.Until(d => usernameInput.Displayed);
        usernameInput.SendKeys("user");

        wait.Until(d => passwordInput.Displayed);
        // ToDo: look into getting the password from a secure source (e.g., secrets, env, config) instead of hardcoding
        passwordInput.SendKeys("testpassword");

        wait.Until(d => loginBtn.Displayed);
        loginBtn.Click();

        IWebElement successBanner = driver.FindElement(By.CssSelector("#successBanner"));
        wait.Until(d => successBanner.Displayed);
        Assert.IsTrue(successBanner.Text.Contains("Success"));
    }

    [TestMethod]
    public void LoginErrorsWhenCredentialsAreInvalid()
    {
        driver.Url = "www.sampletest.com/login";

        //ToDo: create Page Object Model for LoginPage
        IWebElement usernameInput = driver.FindElement(By.CssSelector("#username"));
        IWebElement passwordInput = driver.FindElement(By.CssSelector("#password"));
        //ToDo: confirm how the button is implemented. Assumes button with text "Login".
        IWebElement loginBtn = driver.FindElement(By.XPath("//button[contains(text(),\"Login\")]"));

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
        wait.Until(d => usernameInput.Displayed);
        usernameInput.SendKeys("user");

        wait.Until(d => passwordInput.Displayed);
        // ToDo: look into getting the password from a secure source (e.g., secrets, env, config) instead of hardcoding
        passwordInput.SendKeys("wrongpassword");

        wait.Until(d => loginBtn.Displayed);
        loginBtn.Click();

        IWebElement errorBanner = driver.FindElement(By.CssSelector("#errorBanner"));
        wait.Until(d => errorBanner.Displayed);
        Assert.IsTrue(errorBanner.Text.Contains("Error"));
    }   
}
