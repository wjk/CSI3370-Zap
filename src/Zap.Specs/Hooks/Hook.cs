using System;

using TechTalk.SpecFlow;

using Zap.Specs.Drivers;

namespace Zap.Specs.Hooks
{
    [Binding]
    public class Hooks
    {
        [AfterTestRun]
        public static void ReleaseSession()
        {
            BrowserDriver.CurrentDriver.DisposeDriverFactory();
        }
    }
}