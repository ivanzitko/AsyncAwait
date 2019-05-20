using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;   // TODO: Ova referenca se dobija instalacijom Serilog.AspNetCore nugeta. Dodavanjem Serilog nugeta se nista ne menja... U nekim tutorijalima se koristi jedan, u neki drugi nuget paket...


namespace MsExampleAsyncCall
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")  // Ovo je dodato uz instalaciju    Microsoft.Extensions.Configuration.Json     nuget paketa
                .AddEnvironmentVariables()
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration) // Dodato uz instalaciju   Serilog.Settings.Configuration   nuget paketa.
                //.WriteTo.File("consoleapp.log") 
                //.WriteTo.Console()
                .CreateLogger();


            var services = new ServiceCollection();
            ConfigureServices(services, configuration);
            var serviceProvider = services.BuildServiceProvider();
            
            var ac = serviceProvider.GetService<AsyncCalls>();
            ac.callMethod();

            Console.WriteLine("CallMethod is called in another thread! It can be seen on console...");
            Console.ReadKey();
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging(configure => configure.AddConsole());   // TODO: Ovo je logovanje u konzolu preko MS Logging-a.
            services.AddLogging(configure => configure.AddDebug());     // TODO: Ovo je logovanje u konzolu preko MS Logging-a.
            services.AddLogging(configure => configure.AddSerilog());   // TODO: Sta se desava ako imamo dva definisana logera u istom programu? Kako to DI resava?
            services.AddTransient<AsyncCalls>();

            /* OVO NICEMU NE SLUZI POSTO NE POSTOJI LOG_LEVEL PROMENLJIVA U Enviroment varijablama
             * 
            if (configuration["LOG_LEVEL"] == "true")
            {
                services.Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Trace);
            }
            else
            {
                services.Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Information);
            }
            */

        }




        //public static async void callMethod()
        //{
        //    Coffee cup = PourCoffee();
        //    Console.WriteLine("-------------------------- Coffee is SERVED");
        //    var eggsTask = FryEggsAsync(5);
        //    var baconTask = FryBaconAsync(2);
        //    var toastTask = makeToastWithButterAndJamAsync(2);

        //    var allTasks = new List<Task> { eggsTask, baconTask, toastTask };
        //    while (allTasks.Any())
        //    {
        //        Task finished = await Task.WhenAny(allTasks);
        //        if (finished == eggsTask)
        //        {
        //            allTasks.Remove(eggsTask);
        //            if (eggsTask.Status == TaskStatus.Faulted)
        //            {
        //                Console.WriteLine("-------------------------- Eggs are NOT SERVED. Error:" + eggsTask.Exception.Message);
        //            }
        //            else
        //            {
        //                await eggsTask;
        //                Console.WriteLine("-------------------------- Eggs are SERVED");
        //            }
        //        }
        //        else if (finished == baconTask)
        //        {
        //            Console.WriteLine("-------------------------- Bacon is SERVED");
        //            allTasks.Remove(baconTask);
        //            await baconTask;
        //        }
        //        else if (finished == toastTask)
        //        {
        //            Console.WriteLine("-------------------------- Toast is SERVED");
        //            allTasks.Remove(toastTask);
        //            var toast = await toastTask;
        //        }
        //        else
        //            allTasks.Remove(finished);
        //    }
        //    Console.WriteLine("");
        //    Console.WriteLine("------------ Breakfast is SERVED! --------------");

        //    async Task<Toast> makeToastWithButterAndJamAsync(int number)
        //    {
        //        var plainToast = await ToastBreadAsync(number);
        //        ApplyButter(plainToast);
        //        ApplyJam(plainToast);
        //        return plainToast;
        //    }
        //}
        //private static Coffee PourCoffee()
        //{
        //    Console.WriteLine("Coffe is poured!");
        //    return new Coffee();
        //}

        //private static Toast ApplyButter(Toast plainToast)
        //{
        //    Console.WriteLine("Butter is applied to toast!");
        //    return plainToast;
        //}

        //private static Toast ApplyJam(Toast plainToast)
        //{
        //    Console.WriteLine("Jam is applied to toast!");
        //    return plainToast;
        //}

        //private static async Task<Toast> ToastBreadAsync(int number)
        //{
        //    //await Task.Run(() =>
        //    //{
        //        for (int i = 1; i <= number; i++)
        //        {
        //            await Task.Delay(1000);
        //            Console.WriteLine("Toasts finished:" + i + "/" + number);
        //        }
        //    //});
        //    Console.WriteLine("Toast is toasted!");
        //    return new Toast();
        //}

        //private static async Task FryEggsAsync(int number)
        //{
        //    //await Task.Run(() =>
        //    //{
        //        for (int i = 1; i <= number; i++)
        //        {
        //            await Task.Delay(1000);
        //            Console.WriteLine("Eggs finished:" + i + "/" + number);
        //            throw new Exception("Jaje se razbilo!");
        //        }
        //    //});
        //    Console.WriteLine("Eggs are fried!");
        //}

        //private static async Task FryBaconAsync(int number)
        //{
        //    //await Task.Run(() =>
        //    //{
        //        for (int i = 1; i <= number; i++)
        //        {
        //            await Task.Delay(1000);
        //            Console.WriteLine("Bacons finished:" + i + "/" + number);
        //        }
        //    //});
        //    Console.WriteLine("Bacon is fried!");
        //}

        //private class Toast
        //{
        //}

        //private class Coffee
        //{
        //}
    }
}
