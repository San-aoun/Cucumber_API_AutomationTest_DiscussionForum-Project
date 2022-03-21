using DiscussionForum.E2E.StartUp;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace DiscussionForum.E2E.Domains
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

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            Console.WriteLine("BeforeScenario");
            //RollbackDataBase();
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

        private static void RegisterFeatureContainer(FeatureContext featurecontext)
        {
            var sqlConnectionString = System.Configuration.ConfigurationManager.
                ConnectionStrings["discussionForumDB"].ConnectionString;

            featurecontext.FeatureContainer.RegisterInstanceAs(sqlConnectionString);
        }

        //private void RollbackDataBase()
        //{
        //    var DbContext = _featurecontext.FeatureContainer.Resolve<discussionForumDBContext>();

        //    //DbContext.Database.ExecuteSqlCommand(File.ReadAllText(@"./SQL/ClearDataTableDB.sql"));
        //    DbContext.SaveChanges();
        //}
    }
}
