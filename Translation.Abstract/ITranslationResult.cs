using System;
using System.Collections.Generic;
using System.Text;

namespace Translation.Abstract
{
    public interface ITranslationResult
    {
        bool Success { get; set; }

        string TargetText { get; set; }

        Exception Exception { get; set; }
    }
}
