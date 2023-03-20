using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;

namespace MySelfieApp.Config
{
    //https://learn.microsoft.com/en-us/azure/azure-monitor/app/ilogger
    public static class ApplicationInsightConfig
    {

        public static void AddApplicationInsightConfig(this IServiceCollection services)
        {
            using var channel = new InMemoryChannel();

            services.Configure<TelemetryConfiguration>(config => config.TelemetryChannel = channel);
            services.AddLogging(builder =>
            {
                // Only Application Insights is registered as a logger provider
                builder.AddApplicationInsights(
                    configureTelemetryConfiguration: (config) => config.ConnectionString = "<YourConnectionString>",
                    configureApplicationInsightsLoggerOptions: (options) => { }
                );
            });

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ILogger<Program> logger = serviceProvider.GetRequiredService<ILogger<Program>>();

            logger.LogInformation("Logger is working...");

            //TODO: Flush channel when application ends
        }
    }
}
