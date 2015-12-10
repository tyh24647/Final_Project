using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.DependencyInjection;
using Final_Project.Services;
using Final_Project.Filters;
using Final_Project.Models;

namespace Final_Project {
    public class Startup {

        public Startup(IHostingEnvironment env) { }
        
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
            /*
            services.AddMvc(options => {
                options.Filters.Add(new ExceptionHandlerFilter());
            });
            */
            services.AddSingleton<IPlayersDatabase, PlayersDatabase>();
            services.AddSingleton<ISecurityProvider, SecurityProvider>();

            // TEST
            services.AddSingleton<UsersModel>();
            ///////
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
