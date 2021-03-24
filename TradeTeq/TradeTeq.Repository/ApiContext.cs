using Microsoft.EntityFrameworkCore;
using TradeTeq.Domain;

namespace TradeTeq.Repository
{
    public class ApiContext : DbContext
        {
        public ApiContext()
        {
        }

        public ApiContext(DbContextOptions<ApiContext> options)
                : base(options)
            {

            }

            public DbSet<Insight> Insights { get; set; }


        }
    
}