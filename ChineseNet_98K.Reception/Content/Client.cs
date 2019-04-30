using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChineseNet_98K.Reception.Content
{
    /// <summary>
    /// Copyright (C) 2015-2018 LiChen
    /// HttpClient调用类
    /// QQ 594281739
    /// Email 594281739@qq.com
    /// </summary>
    public class Client
    {
        //加载appsetting.json
        static IConfiguration configuration = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
         .AddJsonFile("appsettings.json").Build();

        /// <summary>
        /// 获取地址
        /// </summary>
        private static readonly string esApiUrl = configuration["ESAPI:ESAPIURL"];

        /// <summary>
        /// ApiHelper
        /// </summary>
        /// <param name="methods">请求方式</param>
        /// <param name="uri">路径</param>
        /// <param name="obj">参数</param>
        /// <returns></returns>
        public static string GetApi(string methods, string uri, Object obj = null)
        {
            string json = string.Empty;
            Task<HttpResponseMessage> task = null;
            HttpResponseMessage respose = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(esApiUrl);
                switch (methods.ToLower())
                {
                    case "get":
                        task = client.GetAsync(uri);
                        break;
                    case "post":
                        task = client.PostAsJsonAsync(uri, obj);
                        break;
                    case "put":
                        task = client.PutAsJsonAsync(uri, obj);
                        break;
                    case "delete":
                        task = client.DeleteAsync(uri);
                        break;
                }
                respose = task.Result;
                if (respose.IsSuccessStatusCode)
                {
                    var res = respose.Content.ReadAsStringAsync();
                    json = res.Result;
                }
            }
            return json;
        }
    }
}
