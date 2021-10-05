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
    public class SalesController : ControllerBase
    {
        private readonly ILogger<SalesController> _logger;

        public SalesController(ILogger<SalesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get([FromQuery(Name = "startdate")] int startdate,
            [FromQuery(Name = "enddate")] int enddate)

        {
            Random rnd = new Random();
            // create randomness in this already chaotic world!
            Dictionary<int, int> dataPoints = new Dictionary<int, int>();
            

            int maxNum = rnd.Next(10, 30);
            for (int i = 0; i < maxNum; i++)
            {
                dataPoints.Add(i, rnd.Next(1, 1000));
            }

            return JsonConvert.SerializeObject(dataPoints, Formatting.Indented); ;
        }
    }
}
