using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using log4net;
using TestAutomation.Service;

namespace TestAutomation.Pages
{
    public class TiketsListPage
    {
        [FindsBy(How = How.ClassName, Using = "_1YAy")]
        private IWebElement ContinueButtonClass { get; set; }

        IWebDriver driver;

        public  TiketsListPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }
        public BookPage ClickContunue()
        {
           new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("_1JXX")));
            ContinueButtonClass.Click();
            Logger.Log.Info("Click ContunueButton");
            return new BookPage(driver);
        }
    }

}
