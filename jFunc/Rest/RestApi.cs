﻿using jFunc.Akamai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace jFunc.Rest
{
    public class RestApi
    {
        public Dictionary<string, string> Headers { get; } = new Dictionary<string, string>();
        HttpClient client = new HttpClient();

        public RestApi()
        {
        }

        void AddHeaders(HttpRequestMessage request)
        {
            foreach (var header in Headers) request.Headers.Add(header.Key, header.Value);
        }

        public RestResponse Get(string url)
        {
            var uri = new Uri(url);
            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                AddHeaders(request);
                var response = client.SendAsync(request).Result;
                return new RestResponse(response);
            }
        }
        public RestResponse Post(string url, string data)
        {
            var uri = new Uri(url);
            ServicePointManager.Expect100Continue = false;
            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                AddHeaders(request);
                var response = client.SendAsync(request).Result;
                return new RestResponse(response);
            }
        }
    }
}
