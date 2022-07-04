using AutomationPractice.PageObjects;
using SeleniumExtras.PageObjects;

namespace AutomationPractice;

public static class Page
{
    private static T GetPage<T>() where T : new()
    {
        var page = new T();
        PageFactory.InitElements(BrowserEnvironment.Driver, page);
        return page;
    }

    public static UserHomePage UserHome
    {
        get { return GetPage<UserHomePage>(); }
    }

    public static LoginPage Login
    {
        get { return GetPage<LoginPage>(); }
    }

    public static SignUpPage SignUp
    {
        get { return GetPage<SignUpPage>(); }
    }

    public static UserHomePage UserHomePage
    {
        get { return GetPage<UserHomePage>(); }
    }

    public static WishListsPage WishLists
    {
        get { return GetPage<WishListsPage>(); }
    }

    public static ProductPage ProductPage
    {
        get { return GetPage<ProductPage>(); }
    }

    public static DressesPage DressesPage
    {
        get { return GetPage<DressesPage>(); }
    }

    public static CartPage CartPage
    {
        get { return GetPage<CartPage>(); }
    }

    public static HomePage HomePage
    {
        get { return GetPage<HomePage>(); }
    }
}
