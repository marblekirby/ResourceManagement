using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fritz.ResourceManagement.Web.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Fritz.ResourceManagement.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
					var host = CreateHostBuilder(args).Build();

					using (var scope = host.Services.CreateScope())
					{
						var services = scope.ServiceProvider;

						new SeedData()
								.SeedAsync(services)
								.Wait();
					}

					host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
