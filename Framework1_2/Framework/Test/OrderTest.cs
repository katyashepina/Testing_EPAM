using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Framework;
using Framework.Test;
using Framework.Services;
using Framework.Pages;
using Framework.Model;
using Framework.Utils;

namespace Framework.Test
{
    [TestFixture]
    public class OrderTest : CommonConditions
    {
        [Test]
        [Category("CalendarTest")]
        public void StartDateLeaseEndDate()
        {
            Logger.Log.Info("Start StartDateLeaseEndDate unit test.");

            string expectingMessage = ErrorCreater.StartDateLeaseEndDate();

            User user = UserCreater.UserWithDateLeaseEndDate();

            string errorMessage = (new StartPage(webDriver).OpenPage() as StartPage)
                                            .FillInFields(user)
                                            .ClickSubmitButton()
                                            .GetErrorMessageText();

            Assert.AreEqual(expectingMessage, errorMessage);
        }

        [Test]
        [Category("CalendarTest")]
        public void SimilarStartDateAndEndDate()
        {
            Logger.Log.Info("Start SimilarStartDateAndEndDate unit test.");

            string expectingMessage = ErrorCreater.SimilarStartDateAndEndDate();

            User user = UserCreater.UserWithSimilarStartDateAndEndDate();

            string errorMessage = (new StartPage(webDriver).OpenPage() as StartPage)
                                            .FillInFields(user)
                                            .ClickSubmitButton()
                                            .GetErrorMessageText();

            Assert.AreEqual(expectingMessage, errorMessage);
        }

        [Test]
        [Category("ContactsTest")]
        public void SendOrderPositiveTest()
        {
            Logger.Log.Info("Start SendOrderPositiveTest unit test.");

            string expectingMessage = ErrorCreater.CorrectNamePhoneEmail();

            User user = UserCreater.WithAllProperties();

            string errorMessage = (new StartPage(webDriver).OpenPage() as StartPage)
                                            .ClickContactsButton()
                                            .WriteButton()
                                            .FillInFields(user)
                                            .SendButton()
                                            .GetErrorMessageText();

            Assert.AreEqual(expectingMessage, errorMessage);
        }

        [Test]
        [Category("AskQuestionsTest")]
        public void SendAskQuestionWithInvalidEmail()
        {
            Logger.Log.Info("Start SendAskQuestionWithInvalidEmail unit test.");

            string expectingMessage = ErrorCreater.FormWithInvalidEMail();

            User user = UserCreater.UserWithIncorrectEmail();

            string errorMessage = (new StartPage(webDriver).OpenPage() as StartPage)
                                            .ClickAskQuestionButton()
                                            .AskQuestionButton()
                                            .FillInFields(user)
                                            .Submit()
                                            .GetErrorMessageText();

            Assert.AreEqual(expectingMessage, errorMessage);
        }

        [Test]
        [Category("AskQuestionsTest")]
        public void SendAskQuestionWithCorrectData()
        {
            Logger.Log.Info("Start SendAskQuestionWithCorrectData unit test.");

            string expectingMessage = ErrorCreater.CorrectNamePhoneEmail();

            User user = UserCreater.WithAllProperties();

            string errorMessage = (new StartPage(webDriver).OpenPage() as StartPage)
                                            .ClickAskQuestionButton()
                                            .AskQuestionButton()
                                            .FillInFields(user)
                                            .Submit()
                                            .GetErrorMessageText();

            Assert.AreEqual(expectingMessage, errorMessage);
        }

        [Test]
        [Category("AskQuestionsTest")]
        public void SendAskQuestionWithIncorrectPhone()
        {
            Logger.Log.Info("Start SendAskQuestionWithIncorrectPhone unit test.");

            string expectingMessage = ErrorCreater.FormWithInvalidPhone();

            User user = UserCreater.UserWithIncorrectPhone();

            string errorMessage = (new StartPage(webDriver).OpenPage() as StartPage)
                                            .ClickAskQuestionButton()
                                            .AskQuestionButton()
                                            .FillInFields(user)
                                            .Submit()
                                            .GetErrorMessageText();

            Assert.AreEqual(expectingMessage, errorMessage);
        }
    }
}
