using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Leads.Data.Models;

namespace Leads
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            HttpContextAccessorSetup(services);
            AuthenticationSetup(services);
            SpaStaticFilesSetup(services);
            DependencyInjection(services);
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        private void HttpContextAccessorSetup(IServiceCollection services)
        {
            // Register an IHttpContextAccessor so we can access the current HttpContext in Services by injecting it
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        private void SpaStaticFilesSetup(IServiceCollection services)
        {
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        private void AuthenticationSetup(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            }).AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options =>
            {
                options.SignInScheme = "Cookies";
                options.Authority = "https://localhost:44362";
                options.ClientId = "leadsclientid";
                options.ResponseType = "code id_token";
                // options.CallbackPath = new PahtString("...")             //If you want to change default redirect URI. You specify it here
                options.Scope.Add("openId");
                options.Scope.Add("profile");
                options.SaveTokens = true;
                options.ClientSecret = "secret";
                //options.GetClaimsFromUserInfoEndpoint = true;
            });
        }

        private void DependencyInjection(IServiceCollection services)
        {
            services.AddScoped<LeadsDemo_v1Context, LeadsDemo_v1Context>();
        }
    }
}
