using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vet.WebSite.Utils
{
    public class Log
    {
        private static readonly Log _instance = new Log();
        protected ILog monitoringLogger;
        protected static ILog debugLogger;

        private Log()
        {
            monitoringLogger = LogManager.GetLogger("MonitoringLogger");
            debugLogger = LogManager.GetLogger("DebugLogger");
        }

        public static void Info(string message)
        {
            _instance.monitoringLogger.Info(message);
        }

        public static void Info(string message, Exception exception)
        {
            _instance.monitoringLogger.Info(message, exception);
        }

        public static void Error(string message)
        {
            _instance.monitoringLogger.Error(message);
        }
  
        public static void Error(string message, Exception exception)
        {
            _instance.monitoringLogger.Error(message, exception);
        }
    }
}