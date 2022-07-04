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
}
