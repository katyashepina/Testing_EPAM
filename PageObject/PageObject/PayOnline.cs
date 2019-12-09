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

    public class PayOnline : Page
    {
        [FindsBy(How = How.CssSelector, Using = ".online-link")]
        private IWebElement PayOnlineButton;

        [FindsBy(How = How.CssSelector, Using = ".tenant-name")]
        private IWebElement NameTenantInput;

        [FindsBy(How = How.CssSelector, Using = ".name")]
        private IWebElement NameClientInput;

        [FindsBy(How = How.CssSelector, Using = ".phone")]
        private IWebElement PhoneInput;

        [FindsBy(How = How.CssSelector, Using = ".email")]
        private IWebElement EmailInput;

        [FindsBy(How = How.CssSelector, Using = ".price")]
        private IWebElement PriseInput;

        [FindsBy(How = How.CssSelector, Using = ".green-btn")]
        private IWebElement ContinuePayment;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Некорректные данные для оплаты.')]")]
        private IWebElement IncorrectPaymentData;

        
        public PayOnline (IWebDriver driver) : base(driver) { }

        public PayOnline FillFieldNameTenant(string text)
        {
            NameTenantInput.SendKeys(text);
            return this;
        }

        public PayOnline FillFieldNAmeClient(string text)
        {
            NameClientInput.SendKeys(text);
            return this;
        }

        public PayOnline FillFieldPhone(string text)
        {
            PhoneInput.SendKeys(text);
            return this;
        }

        public PayOnline FillFieldEmail(string text)
        {
            EmailInput.SendKeys(text);
            return this;
        }

        public PayOnline FillFieldPrise(string text)
        {
            PriseInput.SendKeys(text);
            return this;
        }

        public PayOnline SelectPayOnline()
        {
            PayOnlineButton.Click();
            return this;
        }

        public PayOnline Submit()
        {
            ContinuePayment.Click();
            return this;
        }

        public string CheckErrorLabel()
        {
            return IncorrectPaymentData.Text;
        }
    }
}
