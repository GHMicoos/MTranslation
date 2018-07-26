using System;
using System.Collections.Generic;
using System.Text;

namespace Translation.Abstract
{
    /// <summary>
    /// 语言对象
    /// </summary>
    public interface ILanguage
    {
        /// <summary>
        /// 语言名称
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 语言代码
        /// </summary>
        string Code { get; set; }
    }
}
