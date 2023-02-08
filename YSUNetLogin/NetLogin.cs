using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;

namespace YSUNetLogin
{
    internal class NetLogin
    {
        private string[] serviceStrings = new string[]
        {
            "%e6%a0%a1%e5%9b%ad%e7%bd%91",
            "%E4%B8%AD%E5%9B%BD%E7%A7%BB%E5%8A%A8",
            "%e4%b8%ad%e5%9b%bd%e8%81%94%e9%80%9a",
            "%e4%b8%ad%e5%9b%bd%e7%94%b5%e4%bf%a1"
        }; // 0.校园网 1.中国移动 2.中国联通 3.中国电信

        private string[] headerStrings = new string[]
        {
            "User-Agent",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.140 Safari/537.36 Edge/17.17134",
            "Accept-Encoding",
            "identify"
        };

        private const string url = "http://auth.ysu.edu.cn/eportal/InterFace.do?method=";
        private bool isLogined = false;
        private JObject alldata = null;
        public string userIndex = "";
        private string info = null;

        public bool IsNetAuthorized()
        {
            bool res = CommonUtils.HttpGet("http://auth.ysu.edu.cn", headerStrings).IndexOf("您已成功连接") != -1;
            if(res)
            {
                isLogined = true;
            }
            else
            {
                isLogined = false;
            }
            return isLogined;
        }

        public async Task<bool> IsNetAuthorizedAsync()
        {
            return await Task.FromResult(IsNetAuthorized());
        }

        public JObject GetUserData()
        {
            string[] dataStrings = new[]
            {
                "userIndex", userIndex
            };

            string res = CommonUtils.HttpPost("http://auth.ysu.edu.cn/eportal/InterFace.do?method=getOnlineUserInfo",
                headerStrings, dataStrings);
            try
            { // userId: 账号、userName: 姓名、password: 密码
                alldata = JObject.Parse(res);

                userIndex = alldata.SelectToken("userIndex").ToObject<string>();

                return alldata;
            }
            catch (Exception ex)
            {
                throw new Exception("连接失败。\n" + ex.ToString());
            }
        }
        public async Task<JObject> GetUserDataAsync()
        {
            return await Task.FromResult(GetUserData());
        }
        public string GetBallInfo()
        {
            if (alldata == null) alldata = GetUserData();
            return alldata.SelectToken("ballInfo").ToObject<string>();
        }

        public async Task<string> GetBallInfoAsync()
        {
            return await Task.FromResult(GetBallInfo());
        }
        public string GetUserId()
        {
            if (alldata == null) alldata = GetUserData();
            return alldata.SelectToken("userId").ToObject<string>();
        }

        public async Task<string> GetUserIdAsync()
        {
            return await Task.FromResult(GetUserId());
        }
        public string GetUsername()
        {
            if (alldata == null) GetUserData();
            return alldata.SelectToken("userName").ToObject<string>();
        }
        public async Task<string> GetUsernameAsync()
        {
            return await Task.FromResult(GetUsername());
        }

        public string GetPassword()
        {
            if (alldata == null) GetUserData();
            return CommonUtils.ParseQueryString(alldata.SelectToken("selfUrl").ToObject<string>())["password"];
        }
        public async Task<string> GetPasswordAsync()
        {
            return await Task.FromResult(GetPassword());
        }

        public string GetUserIp()
        {
            if (alldata == null) GetUserData();
            return alldata.SelectToken("userIp").ToObject<string>();
        }
        public async Task<string> GetUserIpAsync()
        {
            return await Task.FromResult(GetUserIp());
        }
        public string GetUserMac()
        {
            if (alldata == null) GetUserData();
            return alldata.SelectToken("userMac").ToObject<string>();
        }
        public async Task<string> GetUserMacAsync()
        {
            return await Task.FromResult(GetUserMac());
        }
        public string GetUserIndex()
        {
            if (alldata == null) GetUserData();
            return alldata.SelectToken("userIndex").ToObject<string>();
        }
        public async Task<string> GetUserIndexAsync()
        {
            return await Task.FromResult(GetUserIndex());
        }

        public ValueTuple<bool, string> Login(string user, string password, int type)
        {
            if (!IsNetAuthorized())
            {
                if (user == "" || password == "") return (false, "username or password is empty");
                string res = CommonUtils.HttpGet("http://auth.ysu.edu.cn", headerStrings);
                string queryString = Regex.Matches(res, "href='https://auth.ysu.edu.cn:8443/eportal/index.jsp?.*?\\?(.*?)'", RegexOptions.IgnoreCase)[0].Value;

                queryString = queryString.Substring(queryString.IndexOf("wlanacname"));

                string[] dataStrings = new[]
                {
                    "userId", user,
                    "password", password,
                    "service", serviceStrings[type],
                    "operatorPwd", "",
                    "operatorUserId", "",
                    "validcode", "", // 验证码 未实现
                    "passwordEncrypt", "false",
                    "queryString", URLEncode.UrlEncode(queryString, Encoding.UTF8)
                };

                res = CommonUtils.HttpPost(url + "login", headerStrings, dataStrings);
                JObject jb = JObject.Parse(res);
                
                userIndex = jb.SelectToken("userIndex").ToObject<string>();
                info = jb.SelectToken("message").ToObject<string>();
                if (jb.SelectToken("result").ToObject<string>() == "success")
                {
                    return (true, "authorization succeed");
                }
                else
                {
                    return (false, info);
                }
            }
            else
            {
                return (true, "already online");
            }
        }

        public async Task<ValueTuple<bool, string>> LoginAsync(string user, string password, int type)
        {
            return await Task.FromResult(Login(user, password, type));
        }

        public ValueTuple<bool, string> Logout()
        {
            if (alldata == null)
            {
                GetUserData();
            }

            string res = CommonUtils.HttpGet(url + "logout", headerStrings);
            JObject jb = JObject.Parse(res);
            info = jb.SelectToken("message").ToObject<string>();

            if (jb.SelectToken("result").ToObject<string>() == "success")
            {
                return (true, "logout succeed");
            }
            else
            {
                return (false, info);
            }
        }
        public async Task<ValueTuple<bool, string>> LogoutAsync()
        {
            return await Task.FromResult(Logout());
        }
    }
}
