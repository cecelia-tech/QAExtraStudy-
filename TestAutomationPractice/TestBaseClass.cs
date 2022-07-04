using Allure.Commons;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System.IO;

namespace TestAutomationPractice;

public class TestBaseClass
{
    private const string LOCAL_PLATFORM = "local";
    private const string SELENOID_PLATFORM = "selenoid";
    private const string SAUCE_LABS_PLATDORM = "saucelabs";
    private const string CHROME_BROWSER = "chrome";
    private const string FIREFOX_BROWSER = "firefox";

    [OneTimeSetUp]
    public void Setup()
    {
        BrowserEnvironment.SetEnvironment(LOCAL_PLATFORM, CHROME_BROWSER);
    }

    [TearDown]
    public void TakeScreenShot()
    {
        if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
        {
            var screenshot = ((ITakesScreenshot)BrowserEnvironment.Driver).GetScreenshot();
            var folderName = "allure-results";
            var filename = TestContext.CurrentContext.Test.MethodName + "_screenshot_" + DateTime.Now.Ticks + ".png";
            var path = Path.Combine(Environment.CurrentDirectory, folderName, filename);
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(path);
            AllureLifecycle.Instance.AddAttachment(filename, "image/png", path);
        }
    }

    [OneTimeTearDown]
    public void CleanUp()
    {
        BrowserEnvironment.CloseDriver();
    }
}
