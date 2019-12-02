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
using OpenQA.Selenium.Support.UI;
using PageObject;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{

    class PayWithoutCorrectData : Page
    {
        [FindsBy(How = How.CssSelector, Using = ".online-link")]
        private readonly IWebElement PayOnlineButton;

        [FindsBy(How = How.CssSelector, Using = ".tenant-name")]
        private readonly IWebElement NameTenantInput;

        [FindsBy(How = How.CssSelector, Using = ".name")]
        private readonly IWebElement NameClientInput;

        [FindsBy(How = How.CssSelector, Using = ".phone")]
        private readonly IWebElement PhoneInput;

        [FindsBy(How = How.CssSelector, Using = ".email")]
        private readonly IWebElement EmailInput;

        [FindsBy(How = How.CssSelector, Using = ".price")]
        private readonly IWebElement PriseInput;

        [FindsBy(How = How.CssSelector, Using = ".green-btn")]
        private readonly IWebElement ContinuePayment;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Некорректные данные для оплаты.')]")]
        private readonly IWebElement IncorrectPaymentData;

        [Obsolete]
        public PayWithoutCorrectData(IWebDriver driver) : base(driver) { }

        public PayWithoutCorrectData FillFieldNameTenant(string text)
        {
            NameTenantInput.SendKeys(text);
            return this;
        }

        public PayWithoutCorrectData FillFieldNAmeClient(string text)
        {
            NameClientInput.SendKeys(text);
            return this;
        }

        public PayWithoutCorrectData FillFieldPhone(string text)
        {
            PhoneInput.SendKeys(text);
            return this;
        }

        public PayWithoutCorrectData FillFieldEmail(string text)
        {
            EmailInput.SendKeys(text);
            return this;
        }

        public PayWithoutCorrectData FillFieldPrise(string text)
        {
            PriseInput.SendKeys(text);
            return this;
        }

        public BookingWithoutDestination SelectPayOnline()
        {
            PayOnlineButton.Click();
            return this;
        }

        public PayWithoutCorrectData Submit()
        {
            ContinuePayment.Click();
            return this;
        }

        public bool CheckErrorLabel()
        {
            return (IncorrectPaymentData != null);
        }
    }
}
