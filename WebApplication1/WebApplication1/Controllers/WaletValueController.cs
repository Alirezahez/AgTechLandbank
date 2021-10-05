using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaletValueController : ControllerBase
    {
        private readonly ILogger<WaletValueController> _logger;

        public WaletValueController(ILogger<WaletValueController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get([FromQuery(Name = "startdate")] int startdate,
            [FromQuery(Name = "enddate")] int enddate)
        {
            Random rnd = new Random();
            // create randomness in this already chaotic world!
            Dictionary<int, WaletValue> dataPoints = new Dictionary<int, WaletValue>();

            int maxNum = rnd.Next(10, 30);
            for (int i = 0; i < maxNum; i++)
            {

                WaletValue stock = new WaletValue();
                stock.stock = rnd.Next(300, 1000);
                List<DateTime> dateTimes = new List<DateTime>();
                dateTimes.Add(RandomDay());
                stock.WaletDate = dateTimes;
                stock.walet = rnd.Next(1, 1000);

                dataPoints.Add(i, stock);
            }

            return JsonConvert.SerializeObject(dataPoints, Formatting.Indented); ;
        }

        DateTime RandomDay()
        {
           Random gen = new Random();
          DateTime start = new DateTime(2021, 1, 1,10,43,32);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}