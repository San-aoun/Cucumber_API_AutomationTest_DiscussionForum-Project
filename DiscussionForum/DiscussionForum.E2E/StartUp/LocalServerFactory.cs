using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionForum.E2E.StartUp
{
    public class LocalServerFactory<TStartup> : WebApplicationFactory<IStartup> where TStartup : class
    {
        private IHost _host;
        public LocalServerFactory()
        {
            CreateHostServer(CreateHostBuilder());
        }
        protected void CreateHostServer(IHostBuilder builder)
        {
            _host = builder.Build();
            _host.Start();
        }
        protected override IHostBuilder CreateHostBuilder()
        {
            var builder = Host.CreateDefaultBuilder();

            builder.ConfigureWebHostDefaults(webBuilder =>
            {
                var envCur = Environment.CurrentDirectory.Replace(
                    "DiscussionForum\\bin\\Debug\\net5.0", "src\\DiscussionForum\\wwwroot");

                webBuilder.UseStartup<TStartup>();
                webBuilder.UseWebRoot(envCur);
            });

            builder.UseEnvironment("Development");
            return builder;
        }

        [ExcludeFromCodeCoverage]
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _host?.Dispose();
            }
        }
    }

}
