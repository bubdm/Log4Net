using System;
using log4net;
using log4net.Config;
using log4net.Appender;
using log4net.Core;

namespace Log4Net.Logger
{
    public class Log
    {
        private Log()
        {
        }

        static Log()
        {
            XmlConfigurator.Configure();
        }

        public static void Info(string message)
        {
            LogManager.GetLogger(string.Empty).Info(message);         
        }

        public static void Debug(string message)
        {
            LogManager.GetLogger(string.Empty).Debug(message);
        }

        public static void Warn(string message)
        {
            LogManager.GetLogger(string.Empty).Warn(message);
        }

        public static void Error(object obj, Exception ex)
        {
            LogManager.GetLogger(obj.GetType()).Error(obj.ToString(), ex);
        }

        public static void Fatal(object obj, Exception ex)
        {
            LogManager.GetLogger(obj.GetType()).Fatal(obj.ToString(), ex);
        }
    }
}
