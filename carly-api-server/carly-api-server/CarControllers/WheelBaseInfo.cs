// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using nWheelBaseInfo;
//
//    var wheelBaseInfo = WheelBaseInfo.FromJson(jsonString);

namespace nWheelBaseInfo
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class WheelBaseInfo
    {
        [JsonProperty("wheels")]
        public Wheel[] Wheels { get; set; }
    }

    public partial class Wheel
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("material")]
        public string Material { get; set; }

        [JsonProperty("size")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Size { get; set; }

        [JsonProperty("sizeType")]
        public string SizeType { get; set; }

        [JsonProperty("pricePW")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long PricePw { get; set; }

        [JsonProperty("priceType")]
        public string PriceType { get; set; }

        [JsonProperty("keywords")]
        public string[] Keywords { get; set; }
    }

    public partial class WheelBaseInfo
    {
        public static WheelBaseInfo FromJson(string json) => JsonConvert.DeserializeObject<WheelBaseInfo>(json, nWheelBaseInfo.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this WheelBaseInfo self) => JsonConvert.SerializeObject(self, nWheelBaseInfo.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
