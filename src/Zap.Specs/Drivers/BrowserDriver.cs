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
        public static readonly BrowserDriver CurrentDriver = new BrowserDriver();    
        
        private IWebDriverFactory? _driverFactory;
        private IWebDriver? _driver;
        
        public BrowserDriver()
        {
            var serviceProvider = ServiceCollectionFactory
                .GetDefaultServiceCollection(new DriverPath("/usr/bin")).BuildServiceProvider();
            _driverFactory = serviceProvider.GetRequiredService<IWebDriverFactory>();
        }

        public IWebDriver CreateWebDriver()
        {
            if (_driverFactory == null)
                throw new InvalidOperationException("Driver factory was disposed");
            
            if (_driver == null)
                _driver = _driverFactory.GetWebDriver(Browser.Safari);

            return _driver;
        }

        public void DisposeDriverFactory()
        {
            _driver?.Dispose();
            _driverFactory?.Dispose();
        }
    }
}