﻿using Newtonsoft.Json;
using NuGet.Configuration;
using System.Net;

namespace IkostSipayAPI.SipayClasses
{
    public class SipayPaymentService
    {

        private static readonly HttpClient _httpClient;
        static SipayPaymentService()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            _httpClient = new HttpClient();
        }

        public static SipayTokenResponse CreateToken(Settings settings)
        {
            SipayTokenRequest tokenRequest = new SipayTokenRequest();
            tokenRequest.AppID = settings.AppID;
            tokenRequest.AppSecret = settings.AppSecret;

            SipayTokenResponse response = PostDataAsync<SipayTokenResponse, SipayTokenRequest>(settings.BaseUrl + "/api/token", tokenRequest);
            return response;
        }

        public static SipayGetPosResponse GetPos(SipayGetPosRequest request, Settings settings, string token)
        {

            request.MerchantKey = settings.MerchantKey;

            var header = new Dictionary<string, string>();
            header.Add("Authorization", "Bearer " + token);

            SipayGetPosResponse response = PostDataAsync<SipayGetPosResponse, SipayGetPosRequest>(settings.BaseUrl + "/api/getpos", request, header);

            return response;
        }

        public static Response PostDataAsync<Response, Request>(string endPoint, Request dto, Dictionary<string, string> headers = null)
        {

            HttpRequestMessage requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(endPoint),
                Content = JsonBuilder.ToJsonString<Request>(dto)
            };

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    requestMessage.Headers.Add(header.Key, header.Value);
                }
            }

            var httpResponse = _httpClient.SendAsync(requestMessage).Result;

            // GEÇİCİ
            var t = httpResponse.Content.ReadAsStringAsync().Result;

            if (!httpResponse.IsSuccessStatusCode)
            {
                return default;
            }


            return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ReadAsStringAsync().Result);
        }




    }
}
