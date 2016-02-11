using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.FrameworkBase.Core.ExpcetionEx
{
    /// <summary>
    /// 启动异常
    /// </summary>
    public class StartupException : Exception
    {
        public StartupException() : base()
        {
        }

        public StartupException(string message) : base(message)
        {
        }

        public StartupException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
