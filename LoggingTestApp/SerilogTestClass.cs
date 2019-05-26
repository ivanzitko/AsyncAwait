using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace LoggingTestApp
{
    public class SerilogTestClass
    {
        public SerilogTestClass()
        {
            //Log.Logger = new LoggerConfiguration()
            //        .MinimumLevel.Debug()
            //        .WriteTo.LiterateConsole()
            //        .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == Serilog.Events.LogEventLevel.Information).WriteTo.RollingFile(@"Logs\Info-{Date}.log"))
            //        .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == Serilog.Events.LogEventLevel.Debug).WriteTo.RollingFile(@"Logs\Debug-{Date}.log"))
            //        .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == Serilog.Events.LogEventLevel.Warning).WriteTo.RollingFile(@"Logs\Warning-{Date}.log"))
            //        .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == Serilog.Events.LogEventLevel.Error).WriteTo.RollingFile(@"Logs\Error-{Date}.log"))
            //        .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == Serilog.Events.LogEventLevel.Fatal).WriteTo.RollingFile(@"Logs\Fatal-{Date}.log"))
            //        .WriteTo.RollingFile(@"Logs\Verbose-{Date}.log")
            //        .CreateLogger();

            Log.Logger = new LoggerConfiguration()
            .ReadFrom.AppSettings()
            .CreateLogger();
        }

        public void LogAction()
        {
            Log.Information("test test");
            Log.Fatal("test test");
        }

    }
}
