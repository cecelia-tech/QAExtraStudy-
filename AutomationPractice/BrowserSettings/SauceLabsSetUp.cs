using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace AutomationPractice;

internal class SauceLabsSetUp
{
    private DriverOptions? DriverOptions { get; set; }

    internal RemoteWebDriver SetSauceLabsBrowser(string browserName)
    {
        var browserOptions = SetDriverOptions(browserName ?? throw new ArgumentNullException(nameof(browserName)));

        var sauceOptions = new Dictionary<string, object>();
        sauceOptions.Add("username", "oauth-vitagriciute-33166");
        sauceOptions.Add("accessKey", "c88e383d-b09e-4efa-bc5f-b165eb6ccba1");
        browserOptions.AddAdditionalOption("sauce:options", sauceOptions);

        var uri = new Uri("https://ondemand.eu-central-1.saucelabs.com:443/wd/hub");
        return new RemoteWebDriver(uri, browserOptions);
    }

    private DriverOptions SetDriverOptions(string browserName)
    {
        if (browserName.ToLower().Equals("firefox"))
        {
            DriverOptions = new FirefoxOptions();
        }
        else if (browserName.ToLower().Equals("chrome"))
        {
            DriverOptions = new ChromeOptions();
        }
        else
        {
            throw new ArgumentException("Browser name provided is unavailable");
        }

        DriverOptions.PlatformName = "Windows 10";
        DriverOptions.BrowserVersion = "latest";

        return DriverOptions;
    }
}
