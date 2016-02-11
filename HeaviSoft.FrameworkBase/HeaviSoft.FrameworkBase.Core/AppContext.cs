using HeaviSoft.FrameworkBase.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.FrameworkBase.Core
{
    /// <summary>
    /// 应用上下文
    /// </summary>
    public class AppContext
    {
        public IPrincipal User { get; set; }

        public string CurrentTheme { get; set; }

        public string CurrentLanguage { get; set; }
    }
}
