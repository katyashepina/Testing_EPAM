using Framework.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Framework.Pages
{
    class CallBackPage
    {
        IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//span[@class='callback open-popup-link']")]                                 
        IWebElement CallBackButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='name")]
        public IWebElement NameData { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='phone")]
        public IWebElement PhoneData { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='blue-btn")]
        public IWebElement SendButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='success_message']")]
        public IWebElement MessageSuccess { get; set; }
        public CallBackPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        public CallBackPage ClickCallBack(Data data)
        {
            CallBackButton.Click();
            NameData.SendKeys(data.ClientName);           
            PhoneData.SendKeys(data.Phone);
            SendButton.Click();
            return this;
        }
    }
}
