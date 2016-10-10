using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;


namespace NinjaGold
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSession();
            
        }
        public void Configure(IApplicationBuilder App)
        {
    
            App.UseStaticFiles();
            App.UseSession();
            App.UseMvc();
            
  
        }
    }
}