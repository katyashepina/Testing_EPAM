using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.Pages
{
    public abstract class BasePage
    {
        public abstract BasePage OpenPage();

        protected IWebDriver webDriver;

        protected BasePage()
        {
            this.webDriver = DriverSingleton.GetInstance();
        }
        public string GetUrlPage()
        {
            return this.webDriver.Url;
        }
    }
}
