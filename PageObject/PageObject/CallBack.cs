using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using Docker.DotNet.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace PageObject
{
     public class CallBack : Page
    {
        [FindsBy(How = How.CssSelector, Using = ".callback open-popup-link")]
        private IWebElement CallBackButton;

        [FindsBy(How = How.CssSelector, Using = ".name")]
        private IWebElement CallNameInput;

        [FindsBy(How = How.CssSelector, Using = ".phone")]
        private IWebElement CallPhoneInput;

        [FindsBy(How = How.CssSelector, Using = ".blue-btn")]
        private IWebElement SendButton;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Заявка успешно отправлена!')]")]
        private IWebElement RequestSentSuccess;

        public CallBack(IWebDriver driver) : base(driver) { }
        
        public CallBack FillFieldName(string text)
        {
            CallNameInput.SendKeys(text);
            return this;
        }

        public CallBack FillFieldPhone(string text)
        {
            CallPhoneInput.SendKeys(text);
            return this;
        }

        public CallBack SelectButtonCallMe()
        {
            CallBackButton.Click();
            return this;
        }

        public CallBack ButtonSendData()
        {
            SendButton.Click();
            return this;
        }

        public string CheckErrorLabel()
        {
            return RequestSentSuccess.Text;
        }
    }

}
