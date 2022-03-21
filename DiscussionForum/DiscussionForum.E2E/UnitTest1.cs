using DiscussionForum.E2E.StartUp;
using OpenQA.Selenium;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DiscussionForum.E2E
{
    public class UnitTest1 :  IClassFixture<LocalServerFactory<Startup>>
    {
        private LocalServerFactory<Startup> _localServerFactory;
        public HttpClient Client;
        public IWebDriver Browser;

        public UnitTest1(LocalServerFactory<Startup> localServerFactory)
        {
            _localServerFactory = localServerFactory;
            Client = _localServerFactory.CreateClient();

        }

        [Fact]
        public async Task Test1()
        {
            var response = await Client.GetAsync("/");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
