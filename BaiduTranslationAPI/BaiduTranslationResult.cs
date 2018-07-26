using System;
using System.Collections.Generic;
using System.Text;
using Translation.Abstract;

namespace TranslationAPI.Baidu
{
    public class BaiduTranslationResult : ITranslationResult
    {
        public bool Success { get; set; }
        public string TargetText { get; set; }
        public Exception Exception { get; set; }
    }
}
