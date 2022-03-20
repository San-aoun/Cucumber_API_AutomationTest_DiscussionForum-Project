using DiscussionForum_IntegrationTest.Startup;
using DiscussionForum_IntegrationTest.StepDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace StepDefinitions.StepDefinition
{
    public class LogStep : BaseStepDefinition
    {
        public LogStep(FeatureContext featureContext, 
            LocalServerFactory<DiscussionForum.Startup> factory)
            : base(featureContext, factory) { }

        [Given(@"test")]
        public void GivenTest()
        {
            //throw new PendingStepException();
        }

    }
}
