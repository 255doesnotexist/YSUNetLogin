using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace YSUNetLogin
{
    internal class BallInfo
    {
        public double DataPackage = Double.PositiveInfinity;
        public double Money = 0;
        public int OnlineDeviceCount = 0;
        public string ISP = "";
        public BallInfo(string str)
        {
            str.Replace("\\\"", "\"");
            var obj = JArray.Parse(str);

            foreach(var x in obj)
            {
                if (x.SelectToken("displayName").ToObject<String>() == "剩余流量")
                {
                    DataPackage = x.SelectToken("value").ToObject<double>();
                }
                if (x.SelectToken("displayName").ToObject<String>() == "套餐&余额")
                {
                    Money = x.SelectToken("value").ToObject<double>();
                }
                if (x.SelectToken("displayName").ToObject<String>() == "在线设备")
                {
                    OnlineDeviceCount = x.SelectToken("value").ToObject<int>();
                }
                if (x.SelectToken("displayName").ToObject<String>() == "我的运营商")
                {
                    ISP = x.SelectToken("value").ToObject<string>();
                }
            }
        }
    }
}
