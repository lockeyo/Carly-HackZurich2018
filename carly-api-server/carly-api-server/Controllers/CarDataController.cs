using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AmagAPIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDataController : ControllerBase
    {
        [HttpGet("{model}")]
        public ActionResult<IEnumerable<string>> Get(string model)
        {
            if (model == null)
                return new string[] { "wrong parameter" };

            if(model.Equals("Golf6"))
                return new string[] { "Colors: Green, Red, Yellow" };

            return new string[] { "unknown model" };
        }

        [HttpGet("getCarList/")]
        public ActionResult<IEnumerable<string>> GetCarList()
        {
            var carDetails = AmagManager.getCarList();
            if(carDetails == null)
                return new string[] { "Api is not initilized" };

            return new string[] { JsonConvert.SerializeObject(carDetails) };
        }
    }
}