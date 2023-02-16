using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace YSUNetLogin
{
    internal static class CommonUtils
    {
        public static TimeSpan HttpClientTimeout;
        public static string HttpGet(string url, string[] headers)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Timeout = HttpClientTimeout;

            for (int i = 0; i < headers.Length; i += 2)
            {
                httpClient.DefaultRequestHeaders.Add(headers[i], headers[i + 1]);
            }

            HttpResponseMessage response = httpClient.GetAsync(new Uri(url)).Result;
            String result = response.Content.ReadAsStringAsync().Result;
            return result;
        }
        public static string HttpPost(string url, string[] headers, string[] data)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Timeout = HttpClientTimeout;

            for (int i = 0; i < headers.Length; i += 2)
            {
                httpClient.DefaultRequestHeaders.Add(headers[i], headers[i + 1]);
            }

            List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<String, String>>();
            for (int i = 0; i < data.Length; i += 2)
            {
                paramList.Add(new KeyValuePair<string, string>(data[i], data[i + 1]));
            }

            HttpResponseMessage response = httpClient.PostAsync(new Uri(url), new FormUrlEncodedContent(paramList)).Result;
            String result =response.Content.ReadAsStringAsync().Result;
            return result;
        }

        public static Dictionary<string, string> ParseQueryString(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("url");
            }
            var uri = new Uri(url);
            if (string.IsNullOrWhiteSpace(uri.Query))
            {
                return new Dictionary<string, string>();
            }
            //1.去除第一个前导?字符
            var dic = uri.Query.Substring(1)
                //2.通过&划分各个参数
                .Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries)
                //3.通过=划分参数key和value,且保证只分割第一个=字符
                .Select(param => param.Split(new char[] { '=' }, 2, StringSplitOptions.RemoveEmptyEntries))
                //4.通过相同的参数key进行分组
                .GroupBy(part => part[0], part => part.Length > 1 ? part[1] : string.Empty)
                //5.将相同key的value以,拼接
                .ToDictionary(group => group.Key, group => string.Join(",", group));

            return dic;
        }
    }
}
