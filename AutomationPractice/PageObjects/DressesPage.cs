using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice.PageObjects;

public class DressesPage : BaseClass, ILoad<DressesPage>
{
    [FindsBy(How = How.CssSelector, Using = ".product_list > li:nth-of-type(1) > div")]
    private IWebElement firstDress;
    [FindsBy(How = How.CssSelector, Using = ".product_list > li:nth-of-type(1) a[title='Add to cart']")]
    private IWebElement firstDressAddToCartLink;
    [FindsBy(How = How.CssSelector, Using = ".product_list > li:nth-of-type(2) > div")]
    private IWebElement secondDress;
    [FindsBy(How = How.CssSelector, Using = ".product_list > li:nth-of-type(2) a[title='Add to cart']")]
    private IWebElement secondDressAddToCartLink;
    [FindsBy(How = How.CssSelector, Using = ".product_list > li:nth-of-type(3) > div")]
    private IWebElement thirdDress;
    [FindsBy(How = How.CssSelector, Using = ".product_list > li:nth-of-type(3) a[title='Add to cart']")]
    private IWebElement thirdDressAddToCartLink;
    [FindsBy(How = How.ClassName, Using = "continue")]
    private IWebElement continueShoppingButton;
    [FindsBy(How = How.CssSelector, Using = "a[title='View my shopping cart']")]
    private IWebElement cartButton;

    public DressesPage AddThreeDressesToTheCart()
    {
        MoveMouse(firstDress);
        ClickElement(firstDressAddToCartLink);
        ClickElement(continueShoppingButton);
        MoveMouse(secondDress);
        ClickElement(secondDressAddToCartLink);
        ClickElement(continueShoppingButton);
        MoveMouse(thirdDress);
        ClickElement(thirdDressAddToCartLink);
        ClickElement(continueShoppingButton);

        return Page.DressesPage;
    }

    public CartPage GoToCart()
    {
        ClickElement(cartButton);
        return Page.CartPage;
    }

    public bool IsPageLoaded()
    {
        try
        {
            return new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementIsVisible(By.XPath("//h2[contains(.,'Dresses')]"))).Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public DressesPage LoadPage()
    {
        BrowserEnvironment.LoadApplication(URLs.DRESSES_PAGE);
        return Page.DressesPage;
    }

    internal override bool AssertLocation()
    {
        return BrowserEnvironment.Driver.Url.Equals(URLs.DRESSES_PAGE);
    }
}
