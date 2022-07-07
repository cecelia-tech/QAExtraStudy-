namespace TestAutomationPractice;

[AllureNUnit]
[TestFixture]
public class AddToCartTest : TestBaseClass
{
    [Test, Order(1)]
    public void TestUserLogIn()
    {
        var logInPage = Page.Login.LoadPage();
        var userHomePage = logInPage.FillLogInDetails(DataFromFile.GetElementValue("email"), DataFromFile.GetElementValue("password"));
        Assert.IsTrue(userHomePage.IsPageLoaded(), "User homepage was not loaded");
    }

    [Test, Order(2)]
    public void TestDressesPageLoad()
    {
        var dressesPage = Page.UserHome.ClickDressesOption();
        Assert.IsTrue(dressesPage.IsPageLoaded(), "Dresses page was not loaded");
    }

    [Test, Order(3)]
    public void TestDressesAddedToTheCart()
    {
        var expectedNumberOfItemsInTheCart = 3;
        var dressesPage = Page.DressesPage.AddThreeDressesToTheCart();
        var cartPage = dressesPage.GoToCart();
        Assert.AreEqual(cartPage.CountProductsInTheCart(), expectedNumberOfItemsInTheCart, "Cart page was not loaded");
    }

    [Test, Order(4)]
    public void TestTotalOfTheCart()
    {
        var expectedCartTotal = 107.97;
        Assert.AreEqual(expectedCartTotal, Page.CartPage.GetCartTotal(), "Cart total doesn't match");
    }
}
