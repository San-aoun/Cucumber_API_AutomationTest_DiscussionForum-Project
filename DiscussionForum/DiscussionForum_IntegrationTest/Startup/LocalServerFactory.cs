using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionForum_IntegrationTest.Startup
{
    public class LocalServerFactory<TStartup> : WebApplicationFactory where TStartup : class
    {
        private IHost _host;
    }
}
