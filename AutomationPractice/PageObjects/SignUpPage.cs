using AutomationPractice.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice;

public class SignUpPage : BaseClass, ILoad<SignUpPage>
{
    private const string URL = "http://automationpractice.com/index.php?controller=authentication&back=my-account#account-creation";
    private By signUpForm = By.Id("account-creation_form");
    [FindsBy(How = How.Id, Using = "customer_firstname")]
    private IWebElement personalInfoFirstNameInputLocator;
    [FindsBy(How = How.Id, Using = "customer_lastname")]
    private IWebElement personalInfoLastNameInputLocator;
    [FindsBy(How = How.Id, Using = "passwd")]
    private IWebElement passwordInputLocator;
    [FindsBy(How = How.CssSelector, Using = "input[id='firstname']")]
    private IWebElement addressFirstNameInputLocator;
    [FindsBy(How = How.CssSelector, Using = "input[id='lastname']")]
    private IWebElement addressLastNameInputLocator;
    [FindsBy(How = How.Id, Using = "address1")]
    private IWebElement addressInputLocator;
    [FindsBy(How = How.Id, Using = "city")]
    private IWebElement cityInputLocator;
    [FindsBy(How = How.Id, Using = "id_state")]
    private IWebElement state;
    [FindsBy(How = How.Id, Using = "id_country")]
    private IWebElement country;
    [FindsBy(How = How.Id, Using = "postcode")]
    private IWebElement zipCode;
    [FindsBy(How = How.Id, Using = "phone_mobile")]
    private IWebElement mobileNumber;
    [FindsBy(How = How.Id, Using = "alias")]
    private IWebElement alias;
    [FindsBy(How = How.Id, Using = "submitAccount")]
    private IWebElement registerButton;

    internal UserHomePage FillRegistrationForm(string firstName, string lastName, string email, string password,
        string address, string city, string state, string zipCode, string country, string mobile_phone, string alias)
    {
        SetInputValue(personalInfoFirstNameInputLocator, firstName);
        SetInputValue(personalInfoLastNameInputLocator, lastName);
        SetInputValue(passwordInputLocator, password);
        SetInputValue(addressFirstNameInputLocator, firstName);
        SetInputValue(addressLastNameInputLocator, lastName);
        SetInputValue(addressInputLocator, address);
        SetInputValue(cityInputLocator, city);
        SelectDropdownElementByText(this.state, state);
        SetInputValue(this.zipCode, zipCode);
        SelectDropdownElementByText(this.country, country);
        SetInputValue(mobileNumber, mobile_phone);
        SetInputValue(this.alias, alias);
        ClickElement(registerButton);

        return Page.UserHomePage;
    }

    public SignUpPage LoadPage()
    {
        BrowserEnvironment.LoadApplication(URL);
        return Page.SignUp;
    }

    public bool IsPageLoaded()
    {
        try
        {
            return new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementIsVisible(signUpForm)).Displayed;
        }
        catch (TimeoutException)
        {
            return false;
        }
    }
}
