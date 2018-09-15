using nRequestCarUpdateResponse;
using nRequestTokenResponse;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmagAPIServer
{
    public class AmagManager
    {
        private static bool bIsIntilized = false;
        private static readonly object syncLock = new object();
        private static RestClient accessClient = new RestClient("https://identity.vwgroup.io");
        private static RestClient restClient = new RestClient("https://api.productdata.vwgroup.com/");

        private static RequestTokenResponse sessionInfo;
        private static RequestCarUpdateResponse carInfo;

        public static void init()
        {
            try
            {
                Console.WriteLine("Logging in...");
                AmagManager.performLogin();
                Console.WriteLine("Performing update");
                AmagManager.performUpdateModelsRequerst();
                Console.WriteLine("Init done =)");

                bIsIntilized = true;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static RequestCarUpdateResponse getCarList()
        {
            lock(syncLock)
            {
                if (!bIsIntilized)
                    return null;
                return carInfo;
            }
        }

        public static void performLogin()
        {
            lock (syncLock)
            {
                var request = new RestRequest("oidc/v1/token", Method.POST);
                request.AddParameter("grant_type", "client_credentials");
                request.AddParameter("client_id", "b0781e40-2821-4a2d-baed-9b33dbb4167c@apps_vw-dilab_com");
                request.AddParameter("client_secret", "9bc2116f0bce1f43ff47632d2b497928a175d3886ad1e5cfc603c6728bb2f36e");

                // execute the request
                IRestResponse response = accessClient.Execute(request);
                var content = response.Content;

                sessionInfo = RequestTokenResponse.FromJson(content);
            }
        }

        public static void performUpdateModelsRequerst()
        {
            lock (syncLock)
            {
                var request = new RestRequest("v2/catalog/CH/brands/V/models", Method.GET);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Authorization", sessionInfo.TokenType + " " + sessionInfo.AccessToken);

                IRestResponse response = restClient.Execute(request);
                var content = response.Content;

                carInfo = RequestCarUpdateResponse.FromJson(content);
            }
        }
    }
}
