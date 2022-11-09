using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Zap.Specs;

public static class Utilities
{
    public static void UntilAnyElementsAppear(this WebDriverWait wait, params string[] elementIds)
    {
        wait.Until(driver =>
        {
            foreach (string elementId in elementIds)
            {
                IWebElement? element;

                try
                {
                    element = driver.FindElement(By.Id(elementId));
                }
                catch (NoSuchElementException)
                {
                    element = null;
                }

                if (element != null) return true;
            }

            return false;
        });
    }

    public static void UntilAllElementsAppear(this WebDriverWait wait, params string[] elementIds)
    {
        wait.Until(driver =>
        {
            bool success = true;

            foreach (string elementId in elementIds)
            {
                IWebElement? element;

                try
                {
                    element = driver.FindElement(By.Id(elementId));
                }
                catch (NoSuchElementException)
                {
                    element = null;
                }

                if (element == null)
                {
                    success = false;
                    break;
                }
            }

            return success;
        });
    }
}
