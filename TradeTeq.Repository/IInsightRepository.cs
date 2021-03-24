using System;
using System.Collections.Generic;
using TradeTeq.Domain;

namespace TradeTeq.Repository
{
    public interface IInsightRepository
    {
        public List<Insight> GetInsights();

        int CreateInsight(string title, DateTime datePublished);

        public PagedResult<Insight> GetPagedInsightOrderByDateDescending(int pageSize, int pageNumber, bool desc);


    }
}