using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice.PageObjects;

public class HomePage : BaseClass, ILoad<HomePage>
{
    private By signInButton = By.ClassName("login");

    public bool IsPageLoaded()
    {
        try
        {
            return new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementIsVisible(signInButton)).Displayed;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public HomePage LoadPage()
    {
        BrowserEnvironment.LoadApplication(URLs.HOME_PAGE);
        return Page.HomePage;
    }

    internal override bool AssertLocation()
    {
        return BrowserEnvironment.Driver.Equals(URLs.HOME_PAGE);
    }
}
