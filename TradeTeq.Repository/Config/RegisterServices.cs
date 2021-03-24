using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TradeTeq.Domain;

namespace TradeTeq.Repository.Config
{
    public static class RegisterServices
    {
        public static IServiceCollection ConfigureDataService(this IServiceCollection services)
        {
            services.AddDbContext<ApiContext>(opt =>
            {
                opt.UseInMemoryDatabase("Tradeteq-Insights");
            });

            services.AddTransient<IInsightRepository, InsightRepository>();
            return services;
        }
    }
}
