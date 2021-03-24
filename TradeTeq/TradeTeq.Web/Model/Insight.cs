using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TradeTeq.Web.Model
{
    public class Insight
    {
        [Key]
        public int Id;

        public string Title;

        public DateTime DatePublished;
    }
}
