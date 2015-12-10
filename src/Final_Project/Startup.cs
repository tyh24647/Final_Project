using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Final_Project.Services;
using Final_Project.Filters;
using Final_Project.Models;

namespace Final_Project {
    public class Startup {

        public Startup(IHostingEnvironment env) { }

        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc(options => {
                options.Filters.Add(new ExceptionHandlerFilter());
            });

            services.AddSingleton<IPlayersDatabase, PlayersDatabase>();
            services.AddSingleton<ISecurityProvider, SecurityProvider>();
            services.AddSingleton<UsersModel>();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseCors(policy => policy
                .AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins("*")
                .WithExposedHeaders(new string[] { "ETag" })
            );

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
