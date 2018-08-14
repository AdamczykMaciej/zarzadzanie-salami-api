using ClassroomManagementApi;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ClassroomManagementApi
{
    public class Program
    {
        //private static IContainer Container { get; set; }

        public static void Main(string[] args)
        {
            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json");
            //var conString = builder.Build().GetConnectionString("DefaultConnection");

         //   var host = new WebHostBuilder()
         //.UseKestrel()
         //.ConfigureServices(services => services.AddAutofac())
         //.UseContentRoot(Directory.GetCurrentDirectory())
         //.UseIISIntegration()
         //.UseStartup<Startup>()
         //.Build();

            //host.Run();
            CreateWebHostBuilder(args).Build().Run();      
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
