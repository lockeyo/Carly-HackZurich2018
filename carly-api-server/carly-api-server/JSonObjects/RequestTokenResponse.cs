// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using JsonRequests;
//
//    var requestTokenResponse = RequestTokenResponse.FromJson(jsonString);

namespace nRequestTokenResponse
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class RequestTokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }

    public partial class RequestTokenResponse
    {
        public static RequestTokenResponse FromJson(string json) => JsonConvert.DeserializeObject<RequestTokenResponse>(json, nRequestTokenResponse.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this RequestTokenResponse self) => JsonConvert.SerializeObject(self, nRequestTokenResponse.Converter.Settings);
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
