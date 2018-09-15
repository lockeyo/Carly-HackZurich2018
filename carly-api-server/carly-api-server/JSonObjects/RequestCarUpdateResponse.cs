// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using JsonRequests;
//
//    var requestCarUpdateResponse = RequestCarUpdateResponse.FromJson(jsonString);

namespace nRequestCarUpdateResponse
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class RequestCarUpdateResponse
    {
        [JsonProperty("data")]
        public Datum[] Data { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }

    public partial class Datum
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Meta
    {
        [JsonProperty("count")]
        public long Count { get; set; }
    }

    public partial class RequestCarUpdateResponse
    {
        public static RequestCarUpdateResponse FromJson(string json) => JsonConvert.DeserializeObject<RequestCarUpdateResponse>(json, nRequestTokenResponse.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this RequestCarUpdateResponse self) => JsonConvert.SerializeObject(self, nRequestTokenResponse.Converter.Settings);
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
}
