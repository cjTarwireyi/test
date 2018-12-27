using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Leads.IDP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            IdentityServerSetup(services);
            AngularCoreSetup(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(builder =>
            {
                builder.WithOrigins("https://localhost:44336")
                .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            });

            app.UseCors("CorsPolicy");

            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            //app.UseHttpsRedirection();
            //app.UseMvc();
        }

        private void IdentityServerSetup(IServiceCollection services)
        {
            services.AddIdentityServer()                                        // To register the IdentityServer on Asp.Net core build in depedency injection
                .AddDeveloperSigningCredential()                                // This is use for signing Tokens. Using a developr Certificate: TODO: For production it requires a real certificate
                .AddTestUsers(Config.GetUsers())                                // This will be the authenticated users
                .AddInMemoryIdentityResources(Config.GetIdentityResources())    // This is the scopes that is registered in memory                    
                .AddInMemoryClients(Config.GetClients());                       // Registering the Client applications
        }

        private void AngularCoreSetup(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowCredentials();
            }));
        }
    }
}
