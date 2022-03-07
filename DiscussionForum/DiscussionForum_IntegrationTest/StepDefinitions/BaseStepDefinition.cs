using DiscussionForum_IntegrationTest.Startup;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;
using Xunit;

namespace DiscussionForum_IntegrationTest.StepDefinitions
{
    public class BaseStepDefinition : IClassFixture<LocalServerFactory<DiscussionForum.Startup>>
    {
        private readonly LocalServerFactory<DiscussionForum.Startup> _localServerFactory;
        private readonly FeatureContext _featureContext;
        private static RemoteWebDriver _remoteWebDriver;

        public BaseStepDefinition(FeatureContext featureContext, LocalServerFactory<DiscussionForum.Startup> localServerFactory)
        {
            _localServerFactory = localServerFactory;
            _featureContext = featureContext;
            _remoteWebDriver = _featureContext.FeatureContainer.Resolve<RemoteWebDriver>();
        }

        protected static RemoteWebDriver WebDriver => _remoteWebDriver;
    }
}
