using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Configuration;
//using Azure.Identity;

namespace Contoso.Apps.SportsLeague.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder//.ConfigureAppConfiguration((hostingContext, config) =>
                    //{
                    //    var settings = config.Build();

                    //    config.AddAzureAppConfiguration(options =>
                    //    {
                    //        options.Connect(settings["ConnectionStrings:AppConfig"])
                    //                .ConfigureKeyVault(kv =>
                    //                {
                    //                    kv.SetCredential(new DefaultAzureCredential());
                    //                });
                    //    });
                    //})
                    .UseStartup<Startup>();
                });
    }
}
