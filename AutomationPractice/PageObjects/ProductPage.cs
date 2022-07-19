using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice.PageObjects;

public class ProductPage : BaseClass, ILoad<ProductPage>
{
    [FindsBy(How = How.Id, Using = "wishlist_button")]
    private IWebElement wishListLink;

    public bool IsPageLoaded()
    {
        try
        {
            return new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementIsVisible(By.Id("bigpic"))).Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public ProductPage LoadPage()
    {
        BrowserEnvironment.LoadApplication(URLs.PRODUCT_PAGE);
        return Page.ProductPage;
    }

    public ProductPage AddToWishList()
    {
        ClickElement(wishListLink);

        new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
            .Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[title='Close']"))).Click();

        return Page.ProductPage;
    }

    internal override bool AssertLocation()
    {
        return BrowserEnvironment.Driver.Url.Equals(URLs.PRODUCT_PAGE);
    }
}
