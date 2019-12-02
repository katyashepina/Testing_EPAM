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
    [TestFixture]
    public class Tests
    {
        private static int timeoutInSeconds = 30;
        private IWebDriver DriverPayWithoutCorrectData;
        private IWebDriver CallBackWithoutCorrectData;
        private string WebsiteURL;
        Random rand = new Random();


        [SetUp]
        public void SetupTest()
        {
            WebsiteURL = "https://www.avtomaxi.ru/";
        }

        [Test, Description("Test is not complete")]
        public void PayWithoutCorrectData()
        {
            DriverPayWithoutCorrectData = new ChromeDriver();
            DriverPayWithoutCorrectData.Navigate().GoToUrl(WebsiteURL);

            PayWithoutCorrectData payWithoutCorrectData = new PayWithoutCorrectData(DriverPayWithoutCorrectData);

            payWithoutCorrectData
                .PayOnlineButton()
                .NameTenantInput("Sasha")
                .NameClientInput("NameClientInput")
                .PhoneInput("+375292627647")
                .EmailInput("katya@list.ru")
                .PriseInput(123.123)
                .ContinuePayment();

            Assert.IsTrue(payWithoutCorrectData.CheckErrorLabel(), "Некорректные данные для оплаты.");

        }

        [Test, Description("Test is not complete")]
        public void CallBackWithoutCorrectData()
        {
            DriverCallBackWithoutCorrectData = new ChromeDriver();
            DriverCallBackWithoutCorrectData.Navigate().GoToUrl(WebsiteURL);

            CallBackWithoutCorrectData сallBackWithoutCorrectData = new CallBackWithoutCorrectData(DriverCallBackWithoutCorrectData);

            сallBackWithoutCorrectData
                .CallBackButton()
                .CallNameInput("Katya")
                .CallPhoneInput("+375292627647")
                .SendButton();

            Assert.IsTrue(сallBackWithoutCorrectData.CheckErrorLabel(), "Заявка успешно отправлена!");
        }

        [TearDown]
        public void TearDownTest()
        {
            if (DriverPayWithoutCorrectData != null)
                DriverPayWithoutCorrectData.Quit();
            if (DriverCallBackWithoutCorrectData != null)
                DriverCallBackWithoutCorrectData.Quit();
            
        }
    }
}
