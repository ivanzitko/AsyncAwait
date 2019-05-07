using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsExampleAsyncCall
{
    class AsyncCalls
    {
        private readonly ILogger _logger;

        public AsyncCalls(ILogger<AsyncCalls> logger)
        {
            _logger = logger;
        }

        public async void callMethod()
        {
            _logger.LogInformation("callMethod started");

            Coffee cup = PourCoffee();
            _logger.LogInformation("-------------------------- Coffee is SERVED");
            var eggsTask = FryEggsAsync(5);
            var baconTask = FryBaconAsync(2);
            var toastTask = makeToastWithButterAndJamAsync(2);

            var allTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (allTasks.Any())
            {
                Task finished = await Task.WhenAny(allTasks);
                if (finished == eggsTask)
                {
                    allTasks.Remove(eggsTask);
                    if (eggsTask.Status == TaskStatus.Faulted)
                    {
                        _logger.LogError("-------------------------- Eggs are NOT SERVED. Error:" + eggsTask.Exception.Message);
                    }
                    else
                    {
                        await eggsTask;
                        _logger.LogInformation("-------------------------- Eggs are SERVED");
                    }
                }
                else if (finished == baconTask)
                {
                    _logger.LogInformation("-------------------------- Bacon is SERVED");
                    allTasks.Remove(baconTask);
                    await baconTask;
                }
                else if (finished == toastTask)
                {
                    _logger.LogInformation("-------------------------- Toast is SERVED");
                    allTasks.Remove(toastTask);
                    var toast = await toastTask;
                }
                else
                    allTasks.Remove(finished);
            }
            //Console.WriteLine("");
            _logger.LogInformation("------------ Breakfast is SERVED! --------------");

            async Task<Toast> makeToastWithButterAndJamAsync(int number)
            {
                var plainToast = await ToastBreadAsync(number);
                ApplyButter(plainToast);
                ApplyJam(plainToast);
                return plainToast;
            }
        }
        private Coffee PourCoffee()
        {
            _logger.LogInformation("Coffe is poured!");
            return new Coffee();
        }

        private Toast ApplyButter(Toast plainToast)
        {
            _logger.LogInformation("Butter is applied to toast!");
            return plainToast;
        }

        private Toast ApplyJam(Toast plainToast)
        {
            _logger.LogInformation("Jam is applied to toast!");
            return plainToast;
        }

        private async Task<Toast> ToastBreadAsync(int number)
        {
            //await Task.Run(() =>
            //{
            for (int i = 1; i <= number; i++)
            {
                await Task.Delay(1000);
                _logger.LogInformation("Toasts finished:" + i + "/" + number);
            }
            //});
            _logger.LogInformation("Toast is toasted!");
            return new Toast();
        }

        private async Task FryEggsAsync(int number)
        {
            //await Task.Run(() =>
            //{
            for (int i = 1; i <= number; i++)
            {
                await Task.Delay(1000);
                _logger.LogInformation("Eggs finished:" + i + "/" + number);
                throw new Exception("Jaje se razbilo!");
            }
            //});
            Console.WriteLine("Eggs are fried!");
        }

        private async Task FryBaconAsync(int number)
        {
            //await Task.Run(() =>
            //{
            for (int i = 1; i <= number; i++)
            {
                await Task.Delay(1000);
                _logger.LogInformation("Bacons finished:" + i + "/" + number);
            }
            //});
            _logger.LogInformation("Bacon is fried!");
        }

        private class Toast
        {
        }

        private class Coffee
        {
        }


    }



}
