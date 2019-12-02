using System;
using System.IO;
using Framework.Driver;
using Framework.Pages;
using Framework.Services;
using GitHubAutomation.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace Framework.Tests
{
    class AutoTests:TestConfig
    {
        [Test]
        [Category("CallTest")]
        public void CallBackWithoutData()
        {
            MakeScreenshotWhenFail(() =>
            {
                Driver.Navigate().GoToUrl("https://www.avtomaxi.ru/");
                CallBackPage callBackPage = new CallBackPage(Driver)
                         .ClickCallBack(DataCreator.WithAllProperties());
                Assert.AreEqual("Заявка успешно отправлена!", callBackPage.MessageSuccess.Text);

            });           
        }
        [Test]
        [Category("PayTest")]
        public void PayWithoutDate()
        {
            Driver.Navigate().GoToUrl("https://www.avtomaxi.ru/");
            MakeScreenshotWhenFail(() =>
            {
                PayOnlinePage payOnlinePage = new PayOnlinePage(DriverSingleton.GetDriver())
                 .PayWithoutData(DataCreator.WithAllProperties());
                Assert.AreNotEqual("Некорректные данные для оплаты.", payOnlinePage.MessagePayError.Text);
            });        
        }
    }
}
