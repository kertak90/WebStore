using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebStore.Infrastructure;
using WebStore.Infrastructure.Implementations;
using WebStore.Infrastructure.Interfaces;
using WebStore.DAL;

namespace WebStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();
            services.AddMvc(options =>
            {
                options.Filters.Add(new SimpleActionFilter());      //Таким образом мы повесили фильтр на все методы нашего приложения
            });

            services.AddSingleton<IEmployeesData, InMemoryEmployeeData>();  //Этот объект будет жить в течении жизни нашего приложения

            //services.AddSingleton<IProductService, InMemoryProductService>();  //Этот объект будет жить в течении жизни нашего приложения
            services.AddScoped<IProductService, SqlProductService>();  //Этот объект будет жить в течении жизни нашего приложения

            services.AddDbContext<WebStoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWelcomePage("/welcome");

            //app.Map("/index", CustomIndexHandler);

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hi From Use Method");
            //    await next.Invoke();
            //});

            //app.UseMiddleware<TokenMiddleware>();


            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template:"{controller=Home}/{action=Index}/{id?}");
            });

            var hello = Configuration["CustomHello"];

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync(hello);
            //});
        }

        private void CustomIndexHandler(IApplicationBuilder obj)
        {
            obj.Run(async context =>
            {
                await context.Response.WriteAsync("Custom Index Handler");
            });
        }
    }
}
