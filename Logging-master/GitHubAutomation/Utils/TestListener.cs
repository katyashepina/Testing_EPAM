using System;
using System.IO;
using TestAutomation.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using NUnit.Framework.Interfaces;
using TestAutomation.Service;

namespace TestAutomation.Utils
{
    public class TestListener
    {
        protected IWebDriver Driver { get; set; }

        [SetUp]
        public void Setter()
        {
            Driver = DriverSingleton.GetDriver();
            Logger.Log.Info("Create driver");
        }

        [TearDown]
        public void ClearDriver()

        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                string screenFolder = AppDomain.CurrentDomain.BaseDirectory + @"\screens";
                Directory.CreateDirectory(screenFolder);
                var screen = Driver.TakeScreenshot();
                screen.SaveAsFile(screenFolder + @"\screen" + DateTime.Now.ToString("yy-MM-dd_hh-mm-ss") + ".png",
                    ScreenshotImageFormat.Png);
            }

            DriverSingleton.CloseDriver();
            Logger.Log.Info("Close driver");
        }
    }
}
