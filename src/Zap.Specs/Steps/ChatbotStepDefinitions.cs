using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using Xunit;

using Zap.Specs.Drivers;
using Zap.Specs.PageObjects;

namespace Zap.Specs.Steps;

[Binding]
public class ChatbotStepDefinitions
{
    private readonly IWebDriver _webDriver;
    private ChatbotPageObject? _pageObject;

    public ChatbotStepDefinitions()
    {
        _webDriver = BrowserDriver.CurrentDriver.CreateWebDriver();
    }

    [Given("the default test user is logged in")]
    public void GivenTheDefaultTestUserIsLoggedIn()
    {
        _webDriver.Url = "https://localhost:5001/Account/LogOut";
        WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
        wait.UntilAllElementsAppear("homepage");
        
        _webDriver.Url = "https://localhost:5001/Account/SignIn";
        wait.UntilAllElementsAppear("emailEntry", "passwordEntry", "submit");

        var element = _webDriver.FindElement(By.Id("emailEntry"));
        element.Clear();
        element.SendKeys("testuser@example.com");

        element = _webDriver.FindElement(By.Id("passwordEntry"));
        element.Clear();
        element.SendKeys("testuser");

        element = _webDriver.FindElement(By.Id("submit"));
        element.Click();
        
        wait.UntilAllElementsAppear("login-friendly");
    }

    [When("the chatbot is loaded")]
    public void WhenTheChatbotIsLoaded()
    {
        _pageObject = new ChatbotPageObject(_webDriver);
        _pageObject.Initialize();
 
        WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
        wait.UntilAllElementsAppear("chatbot");
    }

    [When("action \"(.+)\" is selected")]
    public void WhenActionIsSelected(string identifier)
    {
        var element = _webDriver.FindElement(By.Id("action-" + identifier));
        element.Click();

        WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
        wait.UntilAllElementsAppear("chatbot");
    }

    [Then("the prompt text should be \"(.+)\"")]
    public void ThenThePromptTextShouldBe(string text)
    {
        ArgumentNullException.ThrowIfNull(_pageObject);
        Assert.Equal(text, _pageObject.PromptText);
    }

    [Then("the external link \"(.+)\" exists")]
    public void ThenTheExternalLinkExists(string text)
    {
        ArgumentNullException.ThrowIfNull(_pageObject);
        Assert.Contains(text, _pageObject.ActionButtonTitles);
    }
}
