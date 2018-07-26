using System;
using System.Collections.Generic;
using System.Text;
using Translation.Abstract;

namespace TranslationAPI.Baidu
{
    public class BaiduLanguage : ILanguage
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
