using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaviSoft.FrameworkBase.Utility.Log
{
    public class Logger
    {
        private static ILogger _logger = new LoggerWriter();

        private static ILogger GetInstance()
        {
            //以后直接可以使用反射
            return _logger;
        }

        public static void Debug(object message)
        {
            GetInstance().Debug(message);
        }

        public static void Debug(object message, Exception t)
        {
            GetInstance().Debug(message, t);
        }

        public static void Error(object message)
        {
            GetInstance().Error(message);
        }

        public static void Error(object message, Exception t)
        {
            GetInstance().Error(message, t);
        }

        public static void Fatal(object message)
        {
            GetInstance().Fatal(message);
        }

        public static void Fatal(object message, Exception t)
        {
            GetInstance().Fatal(message, t);
        }

        public static void Info(object message)
        {
            GetInstance().Info(message);
        }

        public static void Info(object message, Exception t)
        {
            GetInstance().Info(message, t);
        }

        public static void Warn(object message)
        {
            GetInstance().Warn(message);
        }

        public static void Warn(object message, Exception t)
        {
            GetInstance().Warn(message, t);
        }
    }
}
