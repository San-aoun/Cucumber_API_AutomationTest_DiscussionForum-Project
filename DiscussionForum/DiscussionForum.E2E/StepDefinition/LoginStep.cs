using DiscussionForum.E2E.Domains;
using OpenQA.Selenium;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DiscussionForum.E2E.StartUp.StepDefinition
{
    [Binding]
    public class LoginStep : BaseStepDefinition
    {
        public LoginStep(FeatureContext featureContext, LocalServerFactory<Startup> factory)
            : base(featureContext, factory) { }

        [Given(@"navigate the registeration website")]
        public async Task GivenNavigateTheRegisterationWebsite()
        {
            WebDriver.Navigate().GoToUrl("localhost:44360");
        }

    }
}
