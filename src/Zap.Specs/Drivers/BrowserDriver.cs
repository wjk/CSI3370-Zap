using System;
using System.Reflection;

using OpenQA.Selenium;
using AlexanderOnTest.NetCoreWebDriverFactory;
using AlexanderOnTest.NetCoreWebDriverFactory.DependencyInjection;
using AlexanderOnTest.NetCoreWebDriverFactory.WebDriverFactory;

using Microsoft.Extensions.DependencyInjection;

namespace Zap.Specs.Drivers
{
    public class BrowserDriver
    {
        private readonly IWebDriverFactory _driverFactory;
        
        public BrowserDriver()
        {
            var serviceProvider = ServiceCollectionFactory
                .GetDefaultServiceCollection(new DriverPath("/usr/bin")).BuildServiceProvider();
            _driverFactory = serviceProvider.GetRequiredService<IWebDriverFactory>();
        }
        
        public IWebDriver CreateWebDriver()
        {
            return _driverFactory.GetWebDriver(Browser.Safari);
        }
    }
}