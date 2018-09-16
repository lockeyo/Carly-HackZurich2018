// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using nCarBaseInfo;
//
//    var carBaseInfo = CarBaseInfo.FromJson(jsonString);

namespace nCarBaseInfo
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CarBaseInfo
    {
        [JsonProperty("modelName")]
        public string ModelName { get; set; }

        [JsonProperty("modelVersion")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ModelVersion { get; set; }

        [JsonProperty("editions")]
        public Edition[] Editions { get; set; }
    }

    public partial class Edition
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("basePrice")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long BasePrice { get; set; }

        [JsonProperty("priceType")]
        public string PriceType { get; set; }
    }

    public partial class CarBaseInfo
    {
        public static CarBaseInfo FromJson(string json) => JsonConvert.DeserializeObject<CarBaseInfo>(json, nCarBaseInfo.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this CarBaseInfo self) => JsonConvert.SerializeObject(self, nCarBaseInfo.Converter.Settings);
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
