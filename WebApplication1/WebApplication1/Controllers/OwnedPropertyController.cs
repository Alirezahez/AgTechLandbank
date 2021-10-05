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
    public class OwnedPropertyController : ControllerBase
    {
        private readonly ILogger<OwnedPropertyController> _logger;

        public OwnedPropertyController(ILogger<OwnedPropertyController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get([FromQuery(Name = "startdate")] int startdate,
            [FromQuery(Name = "enddate")] int enddate)
        {
            Random rnd = new Random();
            // create randomness in this already chaotic world!
            Dictionary<int, OwnedProperty> dataPoints = new Dictionary<int, OwnedProperty>();

            int maxNum = rnd.Next(10, 30);
            for (int i = 0; i < maxNum; i++)
            {

                OwnedProperty customer = new OwnedProperty();

                customer.currentPrice = rnd.Next(1,10000);
                customer.investmentReturn = rnd.Next(1, 1000);
                customer.stock = rnd.Next(1, 30);
                customer.totalWorth = rnd.Next(3000, 50000);
                customer.landAddress = "23 avenue east X9X 9X9";
                customer.imgURL = null;
                dataPoints.Add(i, customer);
            }

            return JsonConvert.SerializeObject(dataPoints, Formatting.Indented); ;
        }

        //DateTime RandomDay()
        //{
        //    Random gen = new Random();
        //    DateTime start = new DateTime(1995, 1, 1);
        //    int range = (DateTime.Today - start).Days;
        //    return start.AddDays(gen.Next(range));
        //}
    }
}