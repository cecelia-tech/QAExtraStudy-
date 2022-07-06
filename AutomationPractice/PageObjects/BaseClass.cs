using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice;

public abstract class BaseClass 
{
    [FindsBy(How = How.ClassName, Using = "account")]
    private IWebElement userHomePage;
    [FindsBy(How = How.ClassName, Using = "logout")]
    private IWebElement logout;
    
    protected void SetInputValue(IWebElement element, string? value)
    {
        element.Clear();
        element.SendKeys(value ?? throw new ArgumentNullException(nameof(value)));
    }

    protected void ClickElement(IWebElement element)
    {
        new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
            .Until(ExpectedConditions.ElementToBeClickable(element)).Click();
    }

    protected void MoveMouse(IWebElement element)
    {
        Actions action = new Actions(BrowserEnvironment.Driver);
        action.MoveToElement(element).Perform();
    }

    protected void SelectDropdownElementByText(IWebElement element, string? value)
    {
        SelectElement selectElement = new SelectElement(element);
        selectElement.SelectByText(value ?? throw new ArgumentNullException(nameof(value)));
    }

    public UserHomePage GoToUserHomePage()
    {
        ClickElement(userHomePage);
        return Page.UserHomePage;
    }

    public void Logout() => ClickElement(logout);

    protected bool IsElementVisible(By by)
    {
        try
        {
            return BrowserEnvironment.Driver.FindElement(by).Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
        catch (StaleElementReferenceException)
        {
            return false;
        }
    }

    protected bool IsElementClickable(By by)
    {
        try
        {
            return BrowserEnvironment.Driver.FindElement(by).Enabled;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
        catch (StaleElementReferenceException)
        {
            return false;
        }
    }

    protected bool HasElementTextChanged(By by, string text)
    {
        try
        {
            return BrowserEnvironment.Driver.FindElement(by).Text == text;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
        catch (StaleElementReferenceException)
        {
            return false;
        }
    }

    protected bool WaitForElementToBeVisible(By by)
    {
        try
        {
            return new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
                .Until((condition) =>
                {
                    ExpectedConditions.ElementIsVisible(by);

                    return true;
                });
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    protected bool WaitForElementToBeClickable(IWebElement element)
    {
        try
        {
            new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(element));

            return true;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    protected bool WaitForElementTextToChange(IWebElement element, string text)
    {
        try
        {
            return new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.TextToBePresentInElement(element, text));
        }
        catch (WebDriverTimeoutException) 
        {
            return false;
        }
    }

    protected bool WaitForElementToBeNotVisible(By by)
    {
        try
        {
            return new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
                .Until((condition) =>
                {
                    ExpectedConditions.InvisibilityOfElementLocated(by);

                    return true;
                });
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
 
    protected bool WaitForElementToBeNotClickable(By by)
    {
        try
        {
            return new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
                .Until((IWebDriver driver) =>
                {
                    if (!driver.FindElement(by).Enabled)
                    {
                        return true;
                    } 
                    return false;
                });
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    internal void SwitchToFrame(IWebElement frame)
    {
        BrowserEnvironment.Driver.SwitchTo().Frame(frame);
    }

    internal void ExitFrame()
    {
        BrowserEnvironment.Driver.SwitchTo().DefaultContent(); ;
    }

    internal bool ValidateDropdownOptions(IWebElement dropdownElement, IEnumerable<string> expectedOptions)
    {
        SelectElement dropdown = new SelectElement(dropdownElement);

        return expectedOptions.Count() == dropdown.Options.Count ? dropdown.Options.Select(option => option.Text).Except(expectedOptions).Any() : false;
    }
}
