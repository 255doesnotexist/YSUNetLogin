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
        public static string HttpGet(string url, string[] headers)
        {
            HttpClient httpClient = new HttpClient();

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
            String result = response.Content.ReadAsStringAsync().Result;
            return result;
        }
    }
}
