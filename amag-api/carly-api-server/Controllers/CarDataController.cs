using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using carlyapiserver.Volkswagen;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace carlyapiserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDataController : ControllerBase
    {
        [HttpGet("getCarInfo/{model}")]
        public ActionResult<IEnumerable<string>> Get(string model)
        {
            if (model == null)
                return new string[] { "wrong parameter" };

            if(model.Equals("Der Golf"))
                return new string[] { Golf.generateBaseInfo() };

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

        [HttpGet("getWheelList/")]
        public ActionResult<IEnumerable<string>> GetWheelList()
        {
            return new string[] { Wheels.generateBaseInfo() };
        }
    }
}