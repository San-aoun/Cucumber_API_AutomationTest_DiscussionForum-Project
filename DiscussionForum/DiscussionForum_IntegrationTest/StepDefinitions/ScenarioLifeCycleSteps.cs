using System;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using DiscussionForum_IntegrationTest.Startup;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace DiscussionForum_IntegrationTest.StepDefinitions
{
    [Binding]
    public sealed class ScenarioLifeCycleSteps : BaseStepDefinition
    {
        public ScenarioLifeCycleSteps(FeatureContext featureContext, LocalServerFactory<Startup> factory)
    : base(featureContext, factory) { }

        [BeforeFeature(Order = 0)]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            if (!featureContext.FeatureContainer.IsRegistered<RemoteWebDriver>())
                featureContext.FeatureContainer.RegisterInstanceAs(GetChrome());
        }

        [AfterTestRun]
        public static void CloseWebDriver()
        {
            WebDriver.Close();
            WebDriver.Quit();
        }

        private static RemoteWebDriver GetChrome()
        {
            var envChromeWebDriver = Environment.GetEnvironmentVariable("ChromeWebDriver");
            if (!string.IsNullOrEmpty(envChromeWebDriver) && File.Exists(Path.Combine(envChromeWebDriver, "chromedriver.exe")))
            {
                return new ChromeDriver(ChromeDriverService.CreateDefaultService(envChromeWebDriver));
            }
            else
            {
                new DriverManager().SetUpDriver(new ChromeConfig());
                return new ChromeDriver(ChromeDriverService.CreateDefaultService());
            }
        }
    }
}
