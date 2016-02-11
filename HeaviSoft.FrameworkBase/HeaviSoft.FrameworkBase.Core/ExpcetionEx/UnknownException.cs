using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.FrameworkBase.Core.ExpcetionEx
{
    /// <summary>
    /// 系统未知错误
    /// </summary>
    public class UnknownException : Exception
    {
        public UnknownException() : base()
        {
        }

        public UnknownException(string message) : base(message)
        {
        }

        public UnknownException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
