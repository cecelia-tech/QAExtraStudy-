using AutomationPractice.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice;

public class LoginPage : BaseClass, ILoad<LoginPage>
{
    [FindsBy(How = How.Id, Using = "email_create")]
    private IWebElement createAccountEmailInput;
    [FindsBy(How = How.Id, Using = "SubmitCreate")]
    private IWebElement crteateAccountButton;
    [FindsBy(How = How.Id, Using = "email")]
    private IWebElement logInEmailInput;
    [FindsBy(How = How.Id, Using = "passwd")]
    private IWebElement logInPasswordInput;
    [FindsBy(How = How.Id, Using = "SubmitLogin")]
    private IWebElement logInButton;
    private By errorMessage = By.Id("create_account_error");

    internal SignUpPage SubmitEmailForm(string email)
    {
        SetEmail(email);
        ClickCreateAccountButton();

        if (IsEmailIncorrect())
        {
            throw new ArgumentException("Wrong email format or this email already exists");
        }

        return Page.SignUp;
    }

    private void SetEmail(string email)
    {
        createAccountEmailInput?.Clear();
        createAccountEmailInput?.SendKeys(email);
    }

    private void ClickCreateAccountButton()
    {
        crteateAccountButton?.Click();
    }

    private bool IsEmailIncorrect()
    {
        try
        {
            return new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementIsVisible(By.Id("create_account_error"))).Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public UserHomePage FillLogInDetails(string email, string password)
    {
        SetInputValue(logInEmailInput, email);
        SetInputValue(logInPasswordInput, password);
        ClickElement(logInButton);

        return Page.UserHomePage;
    }

    public LoginPage LoadPage()
    {
        BrowserEnvironment.LoadApplication(URLs.LOGIN_PAGE);
        return Page.Login;
    }

    public bool IsPageLoaded()
    {
        try
        {
            return new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.TitleContains("Login"));
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    internal override bool AssertLocation()
    {
        return BrowserEnvironment.Driver.Url.Equals(URLs.LOGIN_PAGE);
    }
}
