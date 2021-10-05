using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get([FromQuery(Name = "startdate")] int startdate,
            [FromQuery(Name = "enddate")] int enddate,
            [FromQuery(Name = "query")] string query)
        {
            Random rnd = new Random();
            // create randomness in this already chaotic world!
            List<string> dataPoints = new List<string>();
         
            int maxNum = rnd.Next(10, 30);
            for (int i = 0; i < maxNum; i++)
            {
                
                dataPoints.Add(rnd.Next(1, 1000).ToString());
            }

            return JsonConvert.SerializeObject(dataPoints, Formatting.Indented); ;
        }
    }
}
