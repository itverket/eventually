using Microsoft.Extensions.Logging;

namespace MessageEndpoint
{
    public class ApplicationLogging
    {
        private static ILoggerFactory _Factory = null;

        public static void ConfigureLogger(ILoggerFactory factory)
        {
            factory.AddConsole();
            factory.AddDebug();
            factory.AddAzureWebAppDiagnostics();
        }

        public static ILoggerFactory LoggerFactory
        {
            get
            {
                if (_Factory == null)
                {
                    _Factory = new LoggerFactory();
                    ConfigureLogger(_Factory);
                }
                return _Factory;
            }
            set { _Factory = value; }
        }
        public static ILogger CreateLogger() => LoggerFactory.CreateLogger("FeedbackService");
    }
}