using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.Models;


namespace TraversalCoreProje
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
            //Loglama i�lemi i�in eklenen kodlar
            services.AddLogging(x =>
            {
                x.ClearProviders();//sa�lay�c�lar� temizkledik
                x.SetMinimumLevel(LogLevel.Debug);//log i�lemi nerden itabaren ba�las�n
                x.AddDebug();//output �zerinde loglar� g�stericek

                //output uygulaman�n derlenme an�nda log tutucak ayr�ca bir klas�r olu�turup o klas�r icerisindeki text dosyas�nda log tutca��z
            });

            //�dentity icin eklenen kodlar
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<Context>();
            //kod sonu
            //manager tekrar newlemek yerine yap�lan config�rasyon kod

            services.ContainerDependencies();
            //kodsonu
            services.AddControllersWithViews();

            //Proje seviyesinde authorization
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            //loglamada dosyaya yazmak icin eklenen kodlar
            var path=Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log.txt");
            //kod sonu
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
            //404 sayfas�na y�nlendirme kodu
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
            //kod sonu
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //login i�lemi icin gerekli
            app.UseAuthentication();
            app.UseRouting();


            //�dentity icin eklenen kodlar
            app.UseAuthorization();
            //kod sonu
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            //Area i�lemi icin eklenen kod
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
