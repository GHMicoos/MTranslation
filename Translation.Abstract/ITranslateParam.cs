using System;
using System.Collections.Generic;
using System.Text;

namespace Translation.Abstract
{
    public interface ITranslateParam
    {
        string From { get; set; }

        string To { get; set; }

        string SourceText { get; set; }
    }
}
