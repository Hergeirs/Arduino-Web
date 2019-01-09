using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace E.Gardener
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseKestrel(options =>
                {
                    // Configure the Url and ports to bind to
                    // This overrides calls to UseUrls and the ASPNETCORE_URLS environment variable, but will be 
                    // overridden if you call UseIisIntegration() and host behind IIS/IIS Express
                    options.Listen(IPAddress.Loopback, 5001);
                    options.Listen(IPAddress.Loopback, 5000, listenOptions =>
                    {
                        listenOptions.UseHttps("localhost.crt", "Password0");
                    });
                })
//                .UseDefaultServiceProvider(options =>options.ValidateScopes = false)
                .UseStartup<Startup>();
        
    }    
}
