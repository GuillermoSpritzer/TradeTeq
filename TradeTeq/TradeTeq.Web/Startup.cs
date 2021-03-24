using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TradeTeq.Domain;
using TradeTeq.Repository;
using TradeTeq.Repository.Config;

namespace TradeTeq.Web
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
            services.AddControllers();

            services.ConfigureDataService();

            var provider = services.BuildServiceProvider();

            ApiContext apiContext = (ApiContext)provider.GetRequiredService(typeof(ApiContext));

            AddTestData(apiContext);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }


        private static void AddTestData(ApiContext context)
        {
            var testpost1 = new Insight
            {
                Id = 0,
                Title = "TradeTeq secures 200m new series A round funding",
                Type = (InsightType) 1,
                DatePublished = DateTime.Now,
                Author = "Megan Chudley",
                ActiveFlag = true,
                Content = "asdasdasdasd",
                ImageSource = "www.nondosandaosd.com",
            };
            var testpost2 = new Insight
            {
                Id = 0,
                Title = "TradeTeq Hires top developer Guillermo Spritzer",
                Type = (InsightType) 2,
                DatePublished = DateTime.Now.AddDays(5),
                Author = "Jeff Bezos",
                ActiveFlag = false,
                Content = "null",
                ImageSource = null,
            };
            var testpost3 = new Insight
            {
                Id = 0,
                Title = "TradeTeq Moves offices to the Moon",
                Type = (InsightType) 4,
                DatePublished = DateTime.Now.AddDays(-55),
                Author = "Elon Musk",
                ActiveFlag = true,
                Content = "asdasdasdasdasd",
                ImageSource = null,
            };
            var testpost4 = new Insight
            {
                Id = 0,
                Title = "TradeTeq sets 4 day work week in surprise move",
                Type = (InsightType) 3,
                DatePublished = DateTime.Now.AddDays(1),
                Author = "Mason Mount",
                ActiveFlag = false,
                Content = "This content",
                ImageSource = null,
            };

            context.Insights.Add(testpost1);
            context.Insights.Add(testpost2);
            context.Insights.Add(testpost3);
            context.Insights.Add(testpost4);
            context.SaveChanges();
        }
    }
}
