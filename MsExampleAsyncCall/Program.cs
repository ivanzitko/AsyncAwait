using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MsExampleAsyncCall
{
    class Program
    {
        static void Main(string[] args)
        {
            callMethod();

            Console.ReadKey();
        }

        public static async void callMethod()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("-------------------------- Coffee is SERVED");
            var eggsTask = FryEggsAsync(5);
            var baconTask = FryBaconAsync(2);
            var toastTask = makeToastWithButterAndJamAsync(2);

            var allTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (allTasks.Any())
            {
                Task finished = await Task.WhenAny(allTasks);
                if (finished == eggsTask)
                {
                    Console.WriteLine("-------------------------- Eggs are SERVED");
                    allTasks.Remove(eggsTask);
                    await eggsTask;
                }
                else if (finished == baconTask)
                {
                    Console.WriteLine("-------------------------- Bacon is SERVED");
                    allTasks.Remove(baconTask);
                    await baconTask;
                }
                else if (finished == toastTask)
                {
                    Console.WriteLine("-------------------------- Toast is SERVED");
                    allTasks.Remove(toastTask);
                    var toast = await toastTask;
                }
                else
                    allTasks.Remove(finished);
            }
            Console.WriteLine("");
            Console.WriteLine("------------ Breakfast is SERVED! --------------");

            async Task<Toast> makeToastWithButterAndJamAsync(int number)
            {
                var plainToast = await ToastBreadAsync(number);
                ApplyButter(plainToast);
                ApplyJam(plainToast);
                return plainToast;
            }
        }
        private static Coffee PourCoffee()
        {
            Console.WriteLine("Coffe is poured!");
            return new Coffee();
        }

        private static Toast ApplyButter(Toast plainToast)
        {
            Console.WriteLine("Butter is applied to toast!");
            return plainToast;
        }

        private static Toast ApplyJam(Toast plainToast)
        {
            Console.WriteLine("Jam is applied to toast!");
            return plainToast;
        }

        private static async Task<Toast> ToastBreadAsync(int number)
        {
            //await Task.Run(() =>
            //{
                for (int i = 1; i <= number; i++)
                {
                    await Task.Delay(1000);
                    Console.WriteLine("Toasts finished:" + i + "/" + number);
                }
            //});
            Console.WriteLine("Toast is toasted!");
            return new Toast();
        }

        private static async Task FryEggsAsync(int number)
        {
            //await Task.Run(() =>
            //{
                for (int i = 1; i <= number; i++)
                {
                    await Task.Delay(1000);
                    Console.WriteLine("Eggs finished:" + i + "/" + number);
                }
            //});
            Console.WriteLine("Eggs are fried!");
        }

        private static async Task FryBaconAsync(int number)
        {
            //await Task.Run(() =>
            //{
                for (int i = 1; i <= number; i++)
                {
                    await Task.Delay(1000);
                    Console.WriteLine("Bacons finished:" + i + "/" + number);
                }
            //});
            Console.WriteLine("Bacon is fried!");
        }

        private class Toast
        {
        }

        private class Coffee
        {
        }
    }
}
