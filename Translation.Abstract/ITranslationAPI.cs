using System;
using System.Collections.Generic;
using System.Text;

namespace Translation.Abstract
{
    public interface ITranslationAPI
    {
        /// <summary>
        /// 源语言 列表
        /// </summary>
        IList<ILanguage> SourceLanguage { get; set; }

        /// <summary>
        /// 目标语言 列表
        /// </summary>
        IList<ILanguage> TargetLanguage { get; set; }

        /// <summary>
        /// 翻译
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ITranslationResult Translate(ITranslateParam param);
    }
}
