using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using TestAutomation.Service;

namespace TestAutomation.Pages
{
    public class BookPage
    {
        IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "_1JXX")]
        private IWebElement ProccedToPayButtonClass { get; set; }

        [FindsBy(How = How.ClassName, Using = "_3gOW")]
        private IWebElement ErrorTextClass { get; set; }

        [FindsBy(How = How.ClassName, Using = "kyhT")]
        private IWebElement NoticeTextClass { get; set; }

        [FindsBy(How = How.ClassName, Using = "_3Vek")]
        private IWebElement SkipButton { get; set; }

        public BookPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }
        public BookPage ClickProccedToPayButton()
        {
            ProccedToPayButtonClass.Click();
            Logger.Log.Info("Click ProccedPayButton");
            return this;
        }
        public BookPage ClickSkipButton()
        {
            SkipButton.Click();
            Logger.Log.Info("Click SkipButton");
            return this;
        }
        public string GetError()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementToBeClickable(By.ClassName("_3gOW")));
            Logger.Log.Info("Get error");
            return ErrorTextClass.Text;
        }
        public string GetNotice()
        {
            Logger.Log.Info("Get notice");
            return NoticeTextClass.Text;
        }
    }
}