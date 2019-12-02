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
    class CallBackWithoutCorrectData : Page
    {
        [FindsBy(How = How.CssSelector, Using = ".callback open-popup-link")]
        private readonly IWebElement CallBackButton;

        [FindsBy(How = How.CssSelector, Using = ".name")]
        private readonly IWebElement CallNameInput;

        [FindsBy(How = How.CssSelector, Using = ".phone")]
        private readonly IWebElement CallPhoneInput;

        [FindsBy(How = How.CssSelector, Using = ".blue-btn")]
        private readonly IWebElement SendButton;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Заявка успешно отправлена!')]")]
        private readonly IWebElement RequestSentSuccess;

        public CallBackWithoutCorrectData(IWebDriver driver) : base(driver) { }
        
        public CallBackWithoutCorrectData FillFieldName(string text)
        {
            CallNameInput.SendKeys(text);
            return this;
        }

        public CallBackWithoutCorrectData FillFieldPhone(string text)
        {
            CallPhoneInput.SendKeys(text);
            return this;
        }

        public CallBackWithoutCorrectData SelectButtonCallMe()
        {
            CallBackButton.Click();
            return this;
        }

        public CallBackWithoutCorrectData SelectButtonSendData()
        {
            SendButton.Click();
            return this;
        }

        public bool CheckErrorLabel()
        {
            return (RequestSentSuccess != null);
        }
    }

}
