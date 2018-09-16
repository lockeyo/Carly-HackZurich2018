using Newtonsoft.Json;
using nWheelBaseInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace carlyapiserver.Volkswagen
{
    public class Wheels
    {
        public static string generateBaseInfo()
        {
            WheelBaseInfo baseInfo = new WheelBaseInfo();

            baseInfo.Wheels = new Wheel[]
            {
                    new Wheel{Id = 1, Name = "15 Zoll Stahl Felgen", Material = "steel", Size = 15, SizeType = "zoll",
                        PricePw = 149, PriceType = "EUR", Keywords = new []{ "steel", "15 zoll", "cheap wheels" } },
                    new Wheel{Id = 2, Name = "16 Zoll Alu Felgen", Material = "alu", Size = 15, SizeType = "zoll",
                        PricePw = 249, PriceType = "EUR", Keywords = new []{ "alu", "16 zoll", "nice wheels" } },
                    new Wheel{Id = 3, Name = "17 Zoll Alu Felgen", Material = "alu", Size = 15, SizeType = "zoll",
                        PricePw = 349, PriceType = "EUR", Keywords = new []{ "alu", "17 zoll", "big wheels" } },
            };

            return JsonConvert.SerializeObject(baseInfo);
        }
    }
}
