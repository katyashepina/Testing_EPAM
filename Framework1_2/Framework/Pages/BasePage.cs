using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.Pages
{
    public abstract class BasePage
    {
        public abstract BasePage OpenPage();

        protected IWebDriver webDriver;

        protected BasePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public string GetUrlPage()
        {
            return this.webDriver.Url;
        }
    }
}
