
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace bmonsterman.security.service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
            .ConfigureAppConfiguration((context,builder)=>{
                if(context.HostingEnvironment.IsDevelopment())                
                    builder.AddUserSecrets<Program>();
            })
            .Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();                    
                });
    }
}
