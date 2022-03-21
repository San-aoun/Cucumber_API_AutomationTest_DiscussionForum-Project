using DiscussionForum.E2E.Domains;
using DiscussionForum.E2E.StartUp;
using TechTalk.SpecFlow;

namespace DiscussionForum.E2E.StepDefinition.DBValidation
{
    [Binding]
    public class DBValidation : BaseStepDefinition
    {
        public DBValidation(FeatureContext featureContext, LocalServerFactory<Startup> factory)
            : base(featureContext, factory) { }

        [Then(@"display error message ""([^""]*)""")]
        public void ThenDisplayErrorMessage(string p0)
        {
            throw new PendingStepException();
        }



    }
}
