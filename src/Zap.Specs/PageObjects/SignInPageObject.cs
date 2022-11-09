using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace Zap.Specs.PageObjects;

public class SignInPageObject
{
    private const string PageUrl = "https://localhost:5001/Account/SignIn";

    private IWebDriver _webDriver;

    public SignInPageObject(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    private IWebElement EmailElement => _webDriver.FindElement(By.Id("emailEntry"));
    private IWebElement PasswordElement => _webDriver.FindElement(By.Id("passwordEntry"));
    private IWebElement SubmitButtonElement => _webDriver.FindElement(By.Id("submit"));

    public void EnterEmailAddress(string address)
    {
        EmailElement.Clear();
        EmailElement.SendKeys(address);
    }

    public void EnterPassword(string password)
    {
        PasswordElement.Clear();
        PasswordElement.SendKeys(password);
    }

    public void Submit()
    {
        SubmitButtonElement.Click();

        var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
        wait.UntilAnyElementsAppear("login-friendly", "login-error-box");
    }

    public void Initialize()
    {
        if (_webDriver.Url != PageUrl) _webDriver.Url = PageUrl;
    }
}