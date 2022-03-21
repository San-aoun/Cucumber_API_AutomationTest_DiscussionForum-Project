using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics.CodeAnalysis;

namespace DiscussionForum.E2E.StartUp
{
    public class LocalServerFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        private IHost _host;
        public LocalServerFactory()
        {
            CreateHostServer(CreateHostBuilder());
        }
        public void CreateHostServer(IHostBuilder builder)
        {
            _host = builder.Build();
            _host.Start();
        }
        protected override IHostBuilder CreateHostBuilder()
        {
            var builder = Host.CreateDefaultBuilder();

            builder.ConfigureWebHostDefaults(webBuilder =>
            {
                //var envCur = Environment.CurrentDirectory.Replace(
                //    "DiscussionForum\\bin\\Debug\\net5.0", "DiscussionForum\\wwwroot\\images");
                webBuilder.UseStartup<TStartup>();
                webBuilder.UseWebRoot(
                    "E:\\DiscussionForum372022\\DiscussionForum\\DiscussionForum.E2E\\bin\\Debug\\net5.0\\wwwroot\\images");
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
