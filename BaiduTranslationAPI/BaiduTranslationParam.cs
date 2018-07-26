using System;
using System.Collections.Generic;
using System.Text;
using Translation.Abstract;

namespace TranslationAPI.Baidu
{
    public class BaiduTranslationParam : ITranslateParam
    {
        public string From { get; set; }
        public string To { get; set; }
        public string SourceText { get; set; }
    }
}
