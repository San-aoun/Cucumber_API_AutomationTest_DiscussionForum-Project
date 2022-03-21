using DiscussionForum.E2E.StartUp;
using OpenQA.Selenium.Remote;
using System.Net.Http;
using TechTalk.SpecFlow;
using Xunit;

namespace DiscussionForum.E2E.Domains
{
    public class BaseStepDefinition : IClassFixture<LocalServerFactory<Startup>>
    {
        private readonly LocalServerFactory<Startup> _localServerFactory;
        public HttpClient _client;
        private readonly FeatureContext _featureContext;
        private static RemoteWebDriver _remoteWebDriver;

        public BaseStepDefinition(FeatureContext featureContext, LocalServerFactory<Startup> localServerFactory)
        {
            _localServerFactory = localServerFactory;
            _featureContext = featureContext;
            _remoteWebDriver = _featureContext.FeatureContainer.Resolve<RemoteWebDriver>();

        }

        protected static RemoteWebDriver WebDriver => _remoteWebDriver;
    }
}
