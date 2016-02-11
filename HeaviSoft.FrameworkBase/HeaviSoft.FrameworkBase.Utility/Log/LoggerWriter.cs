using log4net;
using System;

namespace HeaviSoft.FrameworkBase.Utility.Log
{
    internal class LoggerWriter : ILogger
    {
        private ILog _logger;

        public LoggerWriter()
        {
            _logger = LogManager.GetLogger("default");
        }

        public LoggerWriter(string defaultName)
        {
            _logger = LogManager.GetLogger(defaultName);
        }

        public virtual void Debug(object message)
        {
            _logger.Debug(message);
        }

        public virtual void Debug(object message, Exception t)
        {
            _logger.Debug(message, t);
        }

        public virtual void Error(object message)
        {
            _logger.Error(message);
        }

        public virtual void Error(object message, Exception t)
        {
            _logger.Error(message, t);
        }

        public virtual void Fatal(object message)
        {
            _logger.Fatal(message);
        }

        public virtual void Fatal(object message, Exception t)
        {
            _logger.Fatal(message, t);
        }

        public virtual void Info(object message)
        {
            _logger.Info(message);
        }

        public virtual void Info(object message, Exception t)
        {
            _logger.Info(message, t);
        }

        public virtual void Warn(object message)
        {
            _logger.Warn(message);
        }

        public virtual void Warn(object message, Exception t)
        {
            _logger.Warn(message, t);
        }
    }
}
