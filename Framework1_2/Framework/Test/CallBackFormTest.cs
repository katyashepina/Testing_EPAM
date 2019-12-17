using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Framework;
using Framework.Test;
using Framework.Services;
using Framework.Model;
using Framework.Utils;

namespace Framework.Test
{
    [TestFixture]
    public class CallBackFormTest : CommonConditions
    {
        [Test]
        [Category("FormTest")]
        public void SendCallBackWithCorrectData()
        {
            Logger.Log.Info("Start SendCallBackWithCorrectData unit test.");

            string expectingMessage = ErrorCreater.CorrectNamePhoneEmail();

            User user = UserCreater.WithAllProperties();

            string errorMessage = (new StartPage(webDriver).OpenPage() as StartPage)
                                                .ClickCallBackButton()
                                                .FillInFields(user)
                                                .SendCall()
                                                .GetMessageText();

            Assert.AreEqual(expectingMessage, errorMessage);
        }

        [Test]
        [Category("FormTest")]
        public void SendEMailIncorrectEMailAddr()
        {
            Logger.Log.Info("Start SendEMailIncorrectEMailAddr unit test.");

            string expectingMessage = ErrorCreater.FormWithInvalidEMail();

            User user = UserCreater.UserWithIncorrectEmail();

            string errorMessage = (new StartPage(webDriver).OpenPage() as StartPage)
                                                .ClickCallBackButton()
                                                .FillInFields(user)
                                                .SendCall()
                                                .GetMessageText();

            Assert.AreEqual(expectingMessage, errorMessage);
        }

    }
}