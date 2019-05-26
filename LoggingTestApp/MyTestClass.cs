using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;


namespace LoggingTestApp
{
    public class MyTestClass
    {
        private readonly ILogger _logger;

        public MyTestClass(ILogger<MyTestClass> logger)
        {
            _logger = logger;
        }


        public void SomeMethod()
        {
            _logger.LogInformation("Hello 1");
            _logger.LogError("Hello 2");
            _logger.LogWarning("Hello 3");

        }
    }
}
