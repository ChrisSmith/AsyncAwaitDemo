using Microsoft.AspNet.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Logging;

namespace FrontEnd
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
#if !DNXCORE50
            System.Net.ServicePointManager.DefaultConnectionLimit = int.MaxValue;
#endif
            loggerFactory.AddConsole();
            
            // Add the platform handler to the request pipeline.
            app.UseIISPlatformHandler();
            
            app.UseDeveloperExceptionPage();

            app.UseMvcWithDefaultRoute();
        }
    }
}
