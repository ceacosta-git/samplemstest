using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SampleTest;

[TestClass]
public class AlternativeLoginTest : BaseChromeTest
{
    //
    // Summary:
    //     
    //     Navigate to the login page:  https://www.saucedemo.com/
    //     Enter valid credentials into textboxes with css ID’s “user-name” and “password”.
    //     Credentials:
    //         Username: standar_user
    //         Password: secret_sauce
    //     Click the “Login” button.
    //     Verify unsuccessful login (e.g., check for a locked message).
    //         css data-test: error – Message contains “locked”
    //
    
    
    [TestMethod]
    public void LoginErrorsWhenAccountIsLocked()
    {
        driver.Url = "https://www.saucedemo.com/";
        IWebElement usernameInput = driver.FindElement(By.CssSelector("#user-name"));
        IWebElement passwordInput = driver.FindElement(By.CssSelector("#password"));
        IWebElement loginBtn = driver.FindElement(By.Id("login-button"));

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
        wait.Until(d => usernameInput.Displayed);
        usernameInput.SendKeys("locked_out_user");

        wait.Until(d => passwordInput.Displayed);
        passwordInput.SendKeys("secret_sauce");

        wait.Until(d => loginBtn.Displayed);
        loginBtn.Click();

        IWebElement errorBanner = driver.FindElement(By.CssSelector("h3[data-test='error']"));
        wait.Until(d => errorBanner.Displayed);
        Assert.IsTrue(errorBanner.Text.Contains("locked"));

    }
}
