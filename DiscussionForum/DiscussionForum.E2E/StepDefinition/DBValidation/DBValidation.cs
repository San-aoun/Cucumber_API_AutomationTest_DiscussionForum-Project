using DiscussionForum.E2E.Domains;
using DiscussionForum.E2E.StartUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DiscussionForum.E2E.StepDefinition.DBValidation
{
    public class DBValidation : BaseStepDefinition
    {
        public DBValidation(FeatureContext featureContext, LocalServerFactory<Startup> factory)
            : base(featureContext, factory) { }

        [Then(@"database create with infomation")]
        public void ThenDatabaseCreateWithInfomation(Table table)
        {
            throw new PendingStepException();
        }

    }
}
