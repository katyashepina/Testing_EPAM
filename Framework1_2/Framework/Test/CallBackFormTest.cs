using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Framework;
using Framework.Test;
using Framework.Services;
using Framework.Model;
using Framework.Utils;
using log4net;

namespace Framework.Test
{
    [TestFixture]
    public class CallBackFormTest : CommonConditions
    {
        const string ErrorTextForCallBackWithIncorrectData =
            "Start SendCallBackWithCorrectData unit test.";

        const string ErrorTextForSendIncorrectEmail =
            "Start SendIncorrectEMailAddr unit test.";

        static private ILog Log = LogManager.GetLogger(typeof(CallBackFormTest));

        [Test,Description("TestForFormWithCallBackWithCorrectData")]
        public void SendCallBackWithCorrectData()
        {
            string expectingMessage = ErrorCreater.CorrectNamePhoneEmail();

            User user = UserCreater.WithAllProperties();

            string errorMessage = new StartPage()
                                                .ClickCallBackButton()
                                                .FillINameField(user)
                                                .FillIPhoneField(user)
                                                .SendCall()
                                                .GetMessageText();

            Log.Info(ErrorTextForCallBackWithIncorrectData);

            Assert.AreEqual(expectingMessage, errorMessage, "Data entered is correct for collback");
        }

        [Test, Description("TestForFormWithCallBackWithIncorrectData")]
        public void SendEMailIncorrectEMailAddr()
        {
            string expectingMessage = ErrorCreater.FormWithInvalidEMail();

            User user = UserCreater.UserWithIncorrectEmail();

            string errorMessage = new StartPage()
                                                .ClickCallBackButton()
                                                .FillIPhoneField(user)
                                                .FillINameField(user)
                                                .SendCall()
                                                .GetMessageText();

            Logger.Log.Info(ErrorTextForSendIncorrectEmail);

            Assert.AreEqual(expectingMessage, errorMessage, "Email entered incorrectly for callback");
        }

    }
}