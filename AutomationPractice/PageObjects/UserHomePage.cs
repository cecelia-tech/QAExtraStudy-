using AutomationPractice.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice;

public class UserHomePage : BaseClass, ILoad<UserHomePage>
{
    [FindsBy(How = How.CssSelector, Using = "a[title='My wishlists']")]
    private IWebElement wishList;
    [FindsBy(How = How.CssSelector, Using = "#block_top_menu > ul > li:nth-child(2) a[title='Dresses']")]
    private IWebElement dresses;

    internal WishListsPage ClickWishlist()
    {
        ClickElement(wishList);
        return Page.WishLists;
    }

    public DressesPage ClickDressesOption()
    {
        ClickElement(dresses);
        return Page.DressesPage;
    }

    public bool IsPageLoaded()
    {
        try
        {
            return new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".header_user_info:first-of-type"))).Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public UserHomePage LoadPage()
    {
        BrowserEnvironment.LoadApplication(URLs.USER_HOME_PAGE);
        return Page.UserHome;
    }

    internal override bool AssertLocation()
    {
        return BrowserEnvironment.Driver.Url.Equals(URLs.USER_HOME_PAGE);
    }
}
