using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TradeTeq.Domain;
using TradeTeq.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TradeTeq.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsightController : ControllerBase
    {
        private readonly IInsightRepository _insightRepository;

        public InsightController(IInsightRepository insightRepository)
        {
            _insightRepository = insightRepository;
        }

      
        [HttpGet]
        public ActionResult<PagedResult<Insight>> Get([FromQuery] int? pageSize, [FromQuery] int? pageNumber, [FromQuery] bool? desc)
        {
            try
            {
                int pageIndex = pageNumber.HasValue ? Convert.ToInt32(pageNumber) : 1;

                if (pageNumber != null && (pageSize < 1 || pageNumber < 1))
                    return BadRequest();

                return Ok(_insightRepository.GetPagedInsightOrderByDateDescending(pageSize ?? 10, pageIndex,
                    desc ?? true));
            }
            catch (Exception e)
            {
                return new ObjectResult(HttpStatusCode.InternalServerError);
            }
        }

   
        // POST api/<InsightController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }


      
    }
}
