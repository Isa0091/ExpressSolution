using ExpressSolution.Stores.Data;
using ExpressSolution.Stores.Data.Repos;
using Isa0091.Domain.Context.ServicesBusSenders;
using Isa0091.Domain.ContextInjection;
using ManagerFileEasyAzure.Injection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin
{
    public class Startup
    {
        private readonly IConfiguration _conf;

        public Startup(IConfiguration conf)
        {
            _conf = conf;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            string connection = _conf["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(connection);

            });


            //Repo
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IStoreRepo, StoreRepo>();

            //MEDIATR
            services.AddMediatR(new Assembly[] { typeof(ExpressSolution.Stores.Handlers.DummyMarker).Assembly });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddManegerFileEasyAzure(_conf["AzureStorage:Connection"], _conf["AzureStorage:container"]);

            //Integration events
            IntegrationEventTopicConfiguration eventConfig = _conf
               .GetSection(nameof(IntegrationEventTopicConfiguration)).Get<IntegrationEventTopicConfiguration>();
            services.AddServiceBusIntegrationEventSender(eventConfig, typeof(ExpressSolution.DynamicDataVo).Assembly);

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
