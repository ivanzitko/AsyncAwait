using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging;
using System;
//using AzureBackup.Services;
//using Serilog;
//using Microsoft.WindowsAzure.Storage;



namespace LoggingTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new SerilogTestClass();
            test.LogAction();

            Console.WriteLine("Hello World!");
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();



            var myClass = serviceProvider.GetService<MyTestClass>();

            myClass.SomeMethod();

        }


        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole());   
            services.AddLogging(configure => configure.AddDebug());
            services.AddTransient<MyTestClass>();
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;

//namespace LoggingTestApp
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var services = new ServiceCollection();
//            ConfigureServices(services);
//            var serviceProvider = services.BuildServiceProvider();

//            var ac = serviceProvider.GetService<MyTestClass>();
//            ac.SomeMethod();

//            Console.WriteLine("CallMethod is called in another thread! It can be seen on console...");
//            Console.ReadKey();
//        }

//        private static void ConfigureServices(IServiceCollection services)
//        {
//            services.AddLogging(configure => configure.AddConsole());
//            services.AddLogging(configure => configure.AddDebug());
//            services.AddTransient<MyTestClass>();
//        }


//    }
//}
