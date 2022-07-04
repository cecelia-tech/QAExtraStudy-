using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice.PageObjects;

public class HomePage : BaseClass, ILoad<HomePage>
{
    private const string URL = "http://automationpractice.com/index.php?id_category=8&controller=category";
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
        BrowserEnvironment.LoadApplication(URL);
        return Page.HomePage;
    }
}
