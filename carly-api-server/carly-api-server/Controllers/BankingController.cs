using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace carlyapiserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankingController : ControllerBase
    {
        [HttpGet("generateChart/{carPrice}")]
        public ActionResult GenerateChart(int carPrice)
        {
            Rectangle size = new Rectangle(0, 0, 250 , 250);
            var result = ChartGen.DrawPieChart(size, new[] { ChartGen.SliceBrushes[0], ChartGen.SliceBrushes[1] }, new[] { ChartGen.SlicePens[0] }, new[] { 0.2f, 0.8f });

            return base.File(result, "image/jpeg"); ;
        }
    }
}