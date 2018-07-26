using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Translation.Abstract;

namespace TranslationAPI.Baidu
{
    public class BaiduTranslationAPI : ITranslationAPI
    {
        private IList<ILanguage> _LanguageList = new List<ILanguage>()
        {
            new BaiduLanguage(){Name="自动检测",Code="auto" },
             new BaiduLanguage(){Name="中文",Code="zh" },
              new BaiduLanguage(){Name="英语",Code="en" },
               new BaiduLanguage(){Name="粤语",Code="yue" },
                new BaiduLanguage(){Name="文言文",Code="wyw" },
                 new BaiduLanguage(){Name="日语",Code="jp" },
                  new BaiduLanguage(){Name="韩语",Code="kor" },
                   new BaiduLanguage(){Name="法语",Code="fra" },
                    new BaiduLanguage(){Name="西班牙语",Code="spa" },
                     new BaiduLanguage(){Name="泰语",Code="th" },
                      new BaiduLanguage(){Name="阿拉伯语",Code="ara" },
                       new BaiduLanguage(){Name="俄语",Code="ru" },
                        new BaiduLanguage(){Name="葡萄牙语",Code="pt" },
                         new BaiduLanguage(){Name="德语",Code="de" },
                          new BaiduLanguage(){Name="意大利语",Code="it" },
                           new BaiduLanguage(){Name="希腊语",Code="el" },
                            new BaiduLanguage(){Name="荷兰语",Code="nl" },
                             new BaiduLanguage(){Name="波兰语",Code="pl" },
                              new BaiduLanguage(){Name="保加利亚语",Code="bul" },
                               new BaiduLanguage(){Name="爱沙尼亚语",Code="est" },
                                new BaiduLanguage(){Name="丹麦语",Code="dan" },
                                 new BaiduLanguage(){Name="芬兰语",Code="fin" },
                                  new BaiduLanguage(){Name="捷克语",Code="cs" },
                                   new BaiduLanguage(){Name="罗马尼亚语",Code="rom" },
                                    new BaiduLanguage(){Name="斯洛文尼亚语",Code="slo" },
                                     new BaiduLanguage(){Name="瑞典语",Code="swe" },
                                      new BaiduLanguage(){Name="匈牙利语",Code="hu" },
                                       new BaiduLanguage(){Name="繁体中文",Code="cht" },
                                        new BaiduLanguage(){Name="越南语",Code="vie" },
        };

        public IList<ILanguage> SourceLanguage { get=>_LanguageList; set=>throw new NotImplementedException(); }

        public IList<ILanguage> TargetLanguage { get => _LanguageList; set => throw new NotImplementedException(); }

        private const string _baseUrl = "http://api.fanyi.baidu.com";

        private const string _resourceUrl = "/api/trans/vip/translate";

        private const long _appid = 201608120000266540;

        private const string _key = "Sh4rQbdUMJJJZdoAkXwV";

        public ITranslationResult Translate(ITranslateParam param)
        {
            string baseUrl = _baseUrl;
            var client = new RestClient(baseUrl);
            var request = new RestRequest(_resourceUrl, Method.GET);
            var q = param.SourceText;
            var from = param.From;
            var to = param.To;
            var salt = new Random(DateTime.Now.Millisecond).Next(100000);
            var sign = _appid + q + salt + _key;

            var bytes = Encoding.UTF8.GetBytes(sign);//求Byte[]数组
            var Md5 = new MD5CryptoServiceProvider().ComputeHash(bytes);//求哈希值
            sign = BitConverter.ToString(Md5).Replace("-", "").ToLower();


            request.AddParameter("q", q);
            request.AddParameter("from", from);
            request.AddParameter("to", to);
            request.AddParameter("appid", _appid);
            request.AddParameter("salt", salt);
            request.AddParameter("sign", sign);

            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string
            var transResult= JsonConvert.DeserializeObject<BaiduTranslationResult>(content);
            
            return null;
        }

        /// <summary>
        /// 百度翻译返回结果
        /// </summary>
        class BaiduTranslationResult
        {
            public string error_code { get; set; }

            public string error_msg { get; set; }

            public string from { get; set; }

            public string to { get; set; }

            public IList<trans_result> trans_result { get; set; }
        }

        class trans_result
        {
            public string src { get; set; }

            public string dst { get; set; }
        }
    }
}
