using DiscussionForum.E2E.Domains;
using DiscussionForum.E2E.StartUp;
using TechTalk.SpecFlow;
using Xunit;

namespace DiscussionForum.E2E
{
    [Binding]
    public class CreateNewUserStep : BaseStepDefinition
    {
        public CreateNewUserStep(FeatureContext featureContext, LocalServerFactory<Startup> factory)
            : base(featureContext, factory) { }

        [When(@"user creates with new account with data details:")]
        public void WhenUserCreatesWithNewAccountWithDataDetails(Table table)
        {
            for (var i = 0; i < table.RowCount; i++)
            {
                WebDriver.FindElementById("Email").SendKeys(table.Rows[i]["Company name"]);
                WebDriver.FindElementById("Password").SendKeys(table.Rows[i]["First name"]);
                WebDriver.FindElementById("PasswordAgain").SendKeys(table.Rows[i]["Last name"]);
            }
            WebDriver.FindElementByXPath("/html/body/div/main/form/div[2]/div/div[4]/button[1]").Click();
        }

        [Then(@"User can create data and go to page User detail with the message ""([^""]*)""")]
        public void ThenUserCanCreateDataAndGoToPageUserDetailWithTheMessage(string expectation)
        {
            var results = WebDriver.ExecuteScript("return $('.text.header > label').text()").ToString();
            Assert.Equal(expectation, results);
        }

        [Then(@"database create with infomation")]
        public void ThenDatabaseCreateWithInfomation(Table table)
        {
            throw new PendingStepException();
        }
    }
}
