using DiscussionForum.E2E.Domains;
using DiscussionForum.E2E.StartUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DiscussionForum.E2E.StepDefinition
{
    public class AccountStep : BaseStepDefinition
    {
        public AccountStep(FeatureContext featureContext, LocalServerFactory<Startup> factory)
    : base(featureContext, factory) { }

        [When(@"user creates with new account with data details:")]
        public async Task WhenUserCreatesWithNewAccountWithDataDetails(Table table)
        {
            throw new PendingStepException();
        }

        [Then(@"User can create data and go to page User detail")]
        public void ThenUserCanCreateDataAndGoToPageUserDetail()
        {
            throw new PendingStepException();
        }


    }
}
