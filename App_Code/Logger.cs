using System;
using log4net;
using log4net.Config;
using log4net.Appender;
using log4net.Core;

namespace Log4Net.Logger
{
    public class Log
    {
        public static void Info(string message)
        {
            SetLog4NetCustomProperties();
            LogManager.GetLogger(string.Empty).Info(message);
        }

        public static void Debug(string message)
        {
            SetLog4NetCustomProperties();
            LogManager.GetLogger(string.Empty).Debug(message);
        }

        public static void Warn(string message)
        {
            SetLog4NetCustomProperties();
            LogManager.GetLogger(string.Empty).Warn(message);
        }

        /// <summary>
        /// Logs the error without a specific type. Mostly unknown errors.
        /// Sends out an accompanying email
        /// </summary>
        /// <param name="ex">the exception thrown</param>
        public static void Error(Exception ex)
        {
            SetLog4NetCustomProperties();
            LogManager.GetLogger(string.Empty).Error(string.Empty, ex);
        }

        /// <summary>
        /// Logs user-defined application errors.
        /// Sends out an accompanying email
        /// </summary>
        /// <param name="errorMessage">the error message</param>
        public static void Error(string errorMessage)
        {
            SetLog4NetCustomProperties();
            LogManager.GetLogger(string.Empty).Error(errorMessage);
        }

        /// <summary>
        /// Logs the error with a specific type.  Useful for tracing classes.
        /// Sends out an accompanying email
        /// </summary>
        /// <param name="obj">the object to log</param>
        /// <param name="ex">the exception thrown</param>
        public static void Error(object obj, Exception ex)
        {
            SetLog4NetCustomProperties();
            LogManager.GetLogger(obj.GetType()).Error(obj.ToString(), ex);
        }

        public static void Fatal(object obj, Exception ex)
        {
            SetLog4NetCustomProperties();

            if (obj == null)
            {
                LogManager.GetLogger(string.Empty).Fatal(string.Empty, ex);
            }
            else
            {
                LogManager.GetLogger(obj.GetType()).Fatal(obj.ToString(), ex);
            }
        }

        /// <summary>
        /// Sets the Employee Id property of the log since static constructors
        /// are only called once.  This ensures that the property is always updated
        /// </summary>
        private static void SetLog4NetCustomProperties()
        {
            XmlConfigurator.Configure();

            log4net.GlobalContext.Properties["URL"] = HttpContext.Current.Request.Url.ToString();

            System.Web.HttpBrowserCapabilities browswer = HttpContext.Current.Request.Browser;

            log4net.GlobalContext.Properties["BrowserPlatform"] = browswer.Platform;
            log4net.GlobalContext.Properties["BrowserName"] = browswer.Browser;
            log4net.GlobalContext.Properties["BrowserVersion"] = browswer.Version;
            log4net.GlobalContext.Properties["ApplicationName"] = "WIN.Website v1";

            //log4net.GlobalContext.Properties["UserId"] = [USER_ID_HERE];
        }
    }
}
