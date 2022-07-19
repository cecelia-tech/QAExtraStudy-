﻿namespace TestAutomationPractice;

[TestFixture]
[AllureNUnit]
public class WishlistTest : TestBaseClass
{
    //[Test, Order(1)]
    //public void TestUserLogIn()
    //{
    //    var logInPage = Page.Login.LoadPage();
    //    var userHomePage = logInPage.FillLogInDetails(DataFromFile.GetElementValue("email"), DataFromFile.GetElementValue("password"));
    //    Assert.IsTrue(userHomePage.IsPageLoaded(), "User homepage was not loaded");
    //}

    //[Test, Order(2)]
    //public void TestWishlistPageLoaded()
    //{
    //    var wishlists = Page.UserHome.ClickWishlist();
    //    Assert.IsTrue(wishlists.IsPageLoaded(), "wishlists page was not loaded");
    //}

    //[Test, Order(3)]
    //public void TestExistanceOfAutoGeneratedWishlist()
    //{
    //    var wishlists = Page.UserHome.ClickWishlist();
    //    Assert.IsFalse(wishlists.DoesAutoGeneratedWishListExist(), "There is no auto generated wishlist");
    //}

    //[Test, Order(4)]
    //public void TestProductPageLoaded()
    //{
    //    var productPage = Page.WishLists.ClickProduct();
    //    Assert.IsTrue(productPage.IsPageLoaded(), "Product page was not loaded");
    //}

    //[Test, Order(5)]
    //public void TestAddToWishList()
    //{
    //    var productPage = Page.ProductPage.AddToWishList();
    //    var wishlists = productPage.GoToUserHomePage().ClickWishlist();
    //    Assert.IsTrue(wishlists.CheckProductAddedToAutoWishList(), "Product was not added to the wishlist");
    //}

    [Test]
    public void TestAddToAutoCreatedWishlist()
    {
        Facade facade = new Facade();

        Assert.IsTrue(facade.AddToAutoCreatedWishlist(email, password), "Was not possible to add to the auto wishlist");
    }
}
