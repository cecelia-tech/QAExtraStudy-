using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace AutomationPractice;

internal static class BrowserEnvironment
{
    private static string Browser { get; set; }
    private static string Platform { get; set; }

    private static IWebDriver driver;

    internal static IWebDriver Driver
    {
        get
        {
            return driver;
        }
        private set
        {
            driver = value;
        }
    }

    internal static void SetEnvironment(string platform, string browser)
    {
        Platform = platform?.ToLower() ?? throw new ArgumentNullException(nameof(platform));
        Browser = browser?.ToLower() ?? throw new ArgumentNullException(nameof(browser));

        if (Platform.Equals("local"))
        {
            switch (Browser)
            {
                case "firefox":
                    driver = new FirefoxDriver();
                    break;

                case "chrome":
                    driver = new ChromeDriver();
                    break;

                default: throw new ArgumentException("No such browser");
            }
        } else if (Platform.Equals("selenoid"))
        {
            switch (Browser)
            {
                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), firefoxOptions);
                    break;

                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chromeOptions);
                    break;

                default: throw new ArgumentException("No such browser");
            }
        }
        else if (Platform.Equals("saucelabs"))
        {
            switch (Browser)
            {
                case "firefox":
                    driver = new SauceLabsSetUp().SetSauceLabsBrowser("firefox");

                    break;

                case "chrome":
                    driver = new SauceLabsSetUp().SetSauceLabsBrowser("chrome");

                    break;

                default: throw new ArgumentException("No such browser");
            }
        }
        else
        {
            throw new ArgumentException("Environment provided is unavailable");
        }
    }

    internal static void LoadApplication(string url)
    {
        Driver.Url = url;
    }

    internal static void CloseDriver()
    {
        driver?.Quit();
    }
}
