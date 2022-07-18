namespace TestAutomationPractice;

[AllureNUnit]
[TestFixture]
internal class CreateAccountTest : TestBaseClass
{
    //[Test]
    //public void TestCreateAcount()
    //{
    //    var loginPage = Page.Login.LoadPage();
    //    var signupPage = loginPage.SubmitEmailForm(DataFromFile.GetElementValue("email"));
    //    Assert.IsTrue(signupPage.IsPageLoaded(), "SignUp page was not loaded");
    //}

    //[Test, TestCaseSource(typeof(DataFromFile), nameof(DataFromFile.RegisterFormData))]
    //public void TestSignUp(string firstName, string lastName, string email, string password,
    //    string address, string city, string state, string zipCode, string country, string mobile_phone, string alias)
    //{
    //    var userHomePage = Page.SignUp.FillRegistrationForm(firstName, lastName, email, password,
    //    address, city, state, zipCode, country, mobile_phone, alias);
    //    Assert.IsTrue(userHomePage.IsPageLoaded(), "User homepage was not loaded");
    //}

    [Test, TestCaseSource(typeof(DataFromFile), nameof(DataFromFile.RegisterFormData))]
    public void TestSignUp2(string firstName, string lastName, string email, string password,
        string address, string city, string state, string zipCode, string country, string mobile_phone, string alias)
    {
        var facade = new Facade();
        
        Assert.IsTrue(facade.CreateAnAccount(firstName, lastName, email, password,
        address, city, state, zipCode, country, mobile_phone, alias), "User homepage was not loaded");
    }
}
