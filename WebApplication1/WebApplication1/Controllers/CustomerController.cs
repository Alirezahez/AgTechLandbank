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
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get([FromQuery(Name = "startdate")] int startdate,
            [FromQuery(Name = "enddate")] int enddate)
        {
            Random rnd = new Random();
            // create randomness in this already chaotic world!
            Dictionary<int, Customer> dataPoints = new Dictionary<int, Customer>();

            int maxNum = rnd.Next(10, 30);
            for (int i = 0; i < maxNum; i++)
            {

                Customer customer = new Customer();
                
                customer.Date = RandomDay();
                customer.NumberOfCustomers = rnd.Next(1, 1000);

                dataPoints.Add(i, customer);
            }

            return JsonConvert.SerializeObject(dataPoints, Formatting.Indented); ;
        }

        DateTime RandomDay()
        {
            Random gen = new Random();
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}