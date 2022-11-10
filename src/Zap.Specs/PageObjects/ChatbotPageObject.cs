using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Zap.Specs.PageObjects;

public class ChatbotPageObject
{
    private const string PageUrl = "https://localhost:5001/Home/Chatbot";

    private IWebDriver _webDriver;

    public ChatbotPageObject(IWebDriver driver)
    {
        _webDriver = driver;
    }

    public void Initialize()
    {
        if (_webDriver.Url != PageUrl)
            _webDriver.Url = PageUrl;
    }

    public string PromptText
    {
        get
        {
            var element = _webDriver.FindElement(By.Id("prompt-text-p"));
            return element.Text;
        }
    }

    public IEnumerable<string> ActionButtonTitles
    {
        get
        {
            var elements = _webDriver.FindElements(By.CssSelector(".external-link"));
            return elements.Select(e => e.Text);
        }
    }

    public void ClickActionButton(string identifier)
    {
        var element = _webDriver.FindElement(By.Id("action-" + identifier));
        element.Click();

        WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
        wait.UntilAllElementsAppear("prompt-text-p");
    }
}