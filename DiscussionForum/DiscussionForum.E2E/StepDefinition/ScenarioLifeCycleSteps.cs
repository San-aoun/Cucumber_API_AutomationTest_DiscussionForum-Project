using DiscussionForum.E2E.StartUp;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace DiscussionForum.E2E.StepDefinition
{
    [Binding]
    public sealed class ScenarioLifeCycleSteps : BaseStepDefinition
    {
        public ScenarioLifeCycleSteps(FeatureContext featureContext, LocalServerFactory<Startup> localServerFactory)
            : base(featureContext, localServerFactory)
        {
        }
        [BeforeFeature(Order = 0)]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            if (!featureContext.FeatureContainer.IsRegistered<RemoteWebDriver>())
                featureContext.FeatureContainer.RegisterInstanceAs(GetChrome());
        }
        private static ChromeDriver GetChrome()
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
