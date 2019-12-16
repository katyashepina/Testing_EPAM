using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Framework;
using Framework.Test;
using Framework.Services;
using Framework.Pages;
using Framework.Model;

namespace Framework.Test
{
    [TestFixture]
    public class OrderTest : CommonConditions
    {
        [Test]
        [Category("CalendarTest")]
        public void StartDateLeaseEndDate()
        {
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
