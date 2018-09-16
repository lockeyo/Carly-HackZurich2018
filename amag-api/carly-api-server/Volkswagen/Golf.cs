using nCarBaseInfo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace carlyapiserver.Volkswagen
{
    public class Golf
    {
        public static string generateBaseInfo()
        {
            CarBaseInfo baseInfo = new CarBaseInfo();

            baseInfo.ModelName = "Der Golf";
            baseInfo.ModelVersion = 7;

            baseInfo.Editions = new Edition[]
            {
                new Edition{Name = "Trendline", BasePrice = 18075, PriceType = "EUR"},
                new Edition{Name = "Comfortline", BasePrice = 20175, PriceType = "EUR"},
                new Edition{Name = "\"JOIN\"", BasePrice = 22075, PriceType = "EUR"},
                new Edition{Name = "Highline", BasePrice = 25800, PriceType = "EUR"},
                new Edition{Name = "GTD", BasePrice = 33550, PriceType = "EUR"},
                new Edition{Name = "GTI \"Performance\"", BasePrice = 32950, PriceType = "EUR"}
            };

            return JsonConvert.SerializeObject(baseInfo);
        }

    }
}
