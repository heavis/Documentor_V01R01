using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.FrameworkBase.Utility.Log
{
    /// <summary>
    /// 日志接口
    /// </summary>
    public interface ILogger
    {
        /* Log a message object */
        void Debug(object message);
        void Info(object message);
        void Warn(object message);
        void Error(object message);
        void Fatal(object message);

        /* Log a message object and exception */
        void Debug(object message, System.Exception t);
        void Info(object message, System.Exception t);
        void Warn(object message, System.Exception t);
        void Error(object message, System.Exception t);
        void Fatal(object message, System.Exception t);
    }
}
