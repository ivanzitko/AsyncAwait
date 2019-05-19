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
            _logger.LogDebug("Hello");
            
        }
    }
}
