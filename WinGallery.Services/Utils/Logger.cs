namespace WinGallery.Services.Utils
{
    using log4net;
    using System.Reflection;

    public static class AppLogger
    {
        // From log4net documentation:
        // var logger = LogManager.GetLogger(typeof(Class));
        // logger.Info("your log message");
        // logger.Error("your log message", new Exception("your exception message"));

        public static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    }
}
