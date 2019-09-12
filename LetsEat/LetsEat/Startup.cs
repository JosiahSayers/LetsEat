using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsEat.DAL;
using LetsEat.DAL.SQL;
using LetsEat.Providers.Auth;
using LetsEat.Providers.Email;
using LetsEat.Providers.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LetsEat
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //session info
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                // Sets session expiration to 20 minuates
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
            });

            //Dependency injections
            string connectionString = Configuration.GetConnectionString("Prod");
            string emailProviderPassword = Configuration.GetSection("Email")["Pass"];
            string googleJsonCredential = Configuration.GetSection("Google")["json"];
            services.AddTransient<IUsersDAL>(m => new UserSqlDAL(connectionString));
            services.AddTransient<IFamilyDAL, FamilySqlDAL>(c => new FamilySqlDAL(connectionString));
            services.AddTransient<IImageDAL, ImageSqlDAL>(c => new ImageSqlDAL(connectionString));
            services.AddTransient<IIngredientDAL, IngredientSqlDAL>(c => new IngredientSqlDAL(connectionString));
            services.AddTransient<IRecipeDAL, RecipeSqlDAL>(c => new RecipeSqlDAL(connectionString));
            services.AddTransient<IStepDAL, StepSqlDAL>(c => new StepSqlDAL(connectionString));
            services.AddTransient<IWebsiteRequestDAL, WebsiteRequestSqlDAL>(c => new WebsiteRequestSqlDAL(connectionString));
            services.AddTransient<GoogleCloudStorage>(c => new GoogleCloudStorage(googleJsonCredential));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IAuthProvider, SessionAuthProvider>();

            services.AddTransient<EmailProvider>(c => new EmailProvider(emailProviderPassword, connectionString));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
