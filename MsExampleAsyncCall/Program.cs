using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MsExampleAsyncCall
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            
            var ac = serviceProvider.GetService<AsyncCalls>();
            ac.callMethod();

            Console.WriteLine("CallMethod is called in another thread! It can be seen on console...");
            Console.ReadKey();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole());
            services.AddLogging(configure => configure.AddDebug());
            services.AddTransient<AsyncCalls>();
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
