using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Framework.driver
{
    public class DriverSingleton
    {
        private DriverSingleton() { }

        private static IWebDriver webDriver;        
        public static IWebDriver GetInstance()
        {
            if(webDriver==null)
            {
                Logger.Log.Info("Inizializing driver.");
                switch (TestContext.Parameters.Get("browser"))
                {                    
                    case "edge":
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        webDriver = new EdgeDriver();
                        Logger.Log.Info("Start driver.");
                        break;
                    case "firefox":
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        webDriver = new FirefoxDriver();
                        Logger.Log.Info("Start driver.");
                        break;
                    default:
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        webDriver = new ChromeDriver();
                        Logger.Log.Info("Start driver.");
                        break;
                }
                webDriver.Manage().Window.Maximize();
                webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            }

            return webDriver;
        }

        public static void CloseDriver()
        {
            webDriver.Quit();
            webDriver = null;
            Logger.Log.Info("Closed driver.");
        }
    }
}
