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

    protected bool IsElementVisible(By element)
    {
        try
        {
            return new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
            .Until(ExpectedConditions.ElementIsVisible(element)).Displayed;

        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    protected bool IsElementClickable(IWebElement element)
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

    protected bool HasElementTextChanged(IWebElement element)
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

    internal void SwitchToFrame(IWebElement frame)
    {
        BrowserEnvironment.Driver.SwitchTo().Frame(frame);
    }

    internal void ExitFrame()
    {
        BrowserEnvironment.Driver.SwitchTo().DefaultContent(); ;
    }

    protected bool ValidateDropdownOptions(IWebElement dropdownElement, IEnumerable<string> expectedOptions)
    {
        SelectElement dropdown = new SelectElement(dropdownElement);

        return expectedOptions.Count() == dropdown.Options.Count ? dropdown.Options.Select(option => option.Text).Except(expectedOptions).Any() : false;

        //if (expectedOptions.Count() != dropdown.Options.Count)
        //{
        //    return false;
        //}

        //var actualOptions = dropdown.Options.Select(option => option.Text);

        //return actualOptions.Except(expectedOptions).Any();
    }
}
