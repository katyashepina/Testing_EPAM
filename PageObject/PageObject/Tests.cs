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

namespace PageObject
{
    [TestClass]
    public class Tests
    {
        private IWebDriver browser;
        private static string HomePage = "https://www.carrentals.com/";
               
        [TestMethod]
        public void PayWithoutCorrectData()
        {
            browser = new ChromeDriver();
            browser.Navigate().GoToUrl(HomePage);

            PayOnline payOnline = new PayOnline(browser);

            payOnline
                .PayOnlineButton()
                .NameTenantInput("Sasha")
                .NameClientInput("Katya")
                .PhoneInput("+375292627647")
                .EmailInput("katya@list.ru")
                .PriseInput(123.123)
                .ContinuePayment();

            Assert.AreEqual("Некорректные данные для оплаты.", payOnline.CheckErrorLabel());

        }

        [TestMethod]
        public void CallBackWithoutCorrectData()
        {
            browser = new ChromeDriver();
            browser.Navigate().GoToUrl(HomePage);

            CallBack callBack = new CallBack(browser);

            callBack
                .CallBackButton()
                .CallNameInput("Katya")
                .CallPhoneInput("+375292627647")
                .SendButton();

            Assert.AreEqual("Заявка успешно отправлена!", callBack.CheckErrorLabel());
        }

      
    }
}
