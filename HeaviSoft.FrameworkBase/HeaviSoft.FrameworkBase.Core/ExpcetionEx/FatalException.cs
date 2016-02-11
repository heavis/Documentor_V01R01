using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.FrameworkBase.Core.ExpcetionEx
{
    /// <summary>
    ///系统中断错误
    /// </summary>
    public class FatalException : Exception
    {
        public FatalException() : base()
        {
        }

        public FatalException(string message) : base(message)
        {
        }

        public FatalException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
