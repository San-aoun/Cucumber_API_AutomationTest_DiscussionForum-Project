using DiscussionForum_IntegrationTest.Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DiscussionForum_IntegrationTest.StepDefinitions
{
    public class BaseStepDefinition : IClassFixture<LocalServerFactory<Startup>>
    {
        protected readonly LocalServerFactory<Startup> _localServerFactory;

        public BaseStepDefinition(FeatureContext featureContext, LocalServerFactory<Startup> localServerFactory)
        {
            _localServerFactory = localServerFactory;
            _featureContext = featureContext;
            _remoteWebDriver = _featureContext.FeatureContainer.Resolve<RemoteWebDriver>();
        }

        protected static RemoteWebDriver WebDriver => _remoteWebDriver;
    }
}
