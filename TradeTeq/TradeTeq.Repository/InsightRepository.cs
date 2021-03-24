using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TradeTeq.Domain;

namespace TradeTeq.Repository
{
    public class InsightRepository:IInsightRepository
    {
        private readonly ApiContext _dbContext;


        public InsightRepository(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Insight> GetInsights()
        {
            using (_dbContext)
            {
                return _dbContext.Insights.OrderBy(a => a.DatePublished).ToList();
            } 
        }

        public PagedResult<Insight> GetPagedInsightOrderByDateDescending(int pageSize, int pageNumber, bool desc)
        {
            PagedResult<Insight> pagedInsights = new PagedResult<Insight>();
            pagedInsights.PageSize = pageSize;
            pagedInsights.PageNumber = pageNumber;

            using (_dbContext)
            {
                pagedInsights.TotalRecords = _dbContext.Insights.Count();
                pagedInsights.TotalPages = (pagedInsights.TotalRecords + pageSize - 1)/pageSize;
                if (desc)
                {
                    pagedInsights.Data = _dbContext.Insights.OrderByDescending(a => a.DatePublished)
                        .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                }
                else
                {
                    pagedInsights.Data = _dbContext.Insights.OrderBy(a => a.DatePublished)
                        .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                }
            }

            return pagedInsights;
        }

        public int CreateInsight(string title, DateTime datePublished)
        {
            Insight insight = new Insight() {Title = title, DatePublished = datePublished};
            using (var db = new ApiContext())
            {
                var returnInsight =  db.Insights.Add(insight);
                db.SaveChanges();
                return returnInsight.Entity.Id;
            }
        }
    }
}