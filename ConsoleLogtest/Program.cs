using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using System;
using System.Data;
using System.Data.SqlClient;
using ConsoleLogtest.Query;

namespace ConsoleLogtest
{
    internal class Program
    {
        private readonly QueryDemoHandler _handler;
        private static void Main(string[] args)
        {
            var servicesProvider = BuildDi();
            var runner = servicesProvider.GetRequiredService<Runner>();

            runner.DoAction("Action1");

            var work = servicesProvider.GetRequiredService<WorkService>();
            work.Work().ForEach(x => {
                Console.WriteLine($"{x.Id} {x.DateOf} {x.Value}");
                }
            );

            Console.WriteLine("Press ANY key to exit");
            Console.ReadLine();

            // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
            LogManager.Shutdown();
        }

        private static IServiceProvider BuildDi()
        {
            var services = new ServiceCollection();

            //Runner is the custom class
            services.AddTransient<Runner>();

            services.AddSingleton<ILoggerFactory, LoggerFactory>();
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            services.AddLogging((builder) => builder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace));
            services.AddScoped<IDbConnection>(x => new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()));
            services.AddSingleton(typeof(IQueryDemoHandler), typeof(QueryDemoHandler));
            services.AddScoped<WorkService>();

            var serviceProvider = services.BuildServiceProvider();
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            
            //configure NLog
            loggerFactory.AddNLog(new NLogProviderOptions { CaptureMessageTemplates = true, CaptureMessageProperties = true });
            LogManager.LoadConfiguration("nlog.config");

            return serviceProvider;
        }
    }
}
