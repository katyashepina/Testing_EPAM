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
using log4net;

namespace Framework.Test
{
    [TestFixture]
    public class OrderTest : CommonConditions
    {
        const string ErrorTextForStartDateLeaseEndDate =
            "Start StartDateLeaseEndDate unit test.";

        const string ErrorTextForSimilarStartDateAndEdDate =
            "Start SimilarStartDateAndEndDate unit test.";

        const string ErrorTextForSendOrderPositiveTest =
            "Start SendOrderPositiveTest unit test.";

        const string ErrorTextForSendAsqQuestionWithInvalidData =
            "Start SendAskQuestionWithInvalidEmail unit test.";

        const string ErrorTextForDendAsqQuestionWithCorrectData =
            "Start SendAskQuestionWithCorrectData unit test.";

        const string ErrorTextForAsqQuestionWithIncorrectPhone =
            "Start SendAskQuestionWithIncorrectPhone unit test.";

        static private ILog Log = LogManager.GetLogger(typeof(OrderTest));

        [Test]
        [Category("CalendarTest")]
        public void StartDateLeaseEndDate()
        {
            string expectingMessage = ErrorCreater.StartDateLeaseEndDate();

            User user = UserCreater.UserWithDateLeaseEndDate();

            string errorMessage = new StartPage(webDriver)
                                            .FillRentalDateEnd(user)
                                            .FillRentalDateStartFields(user)
                                            .ClickSubmitButton()
                                            .GetErrorMessageText();

            Log.Info(ErrorTextForStartDateLeaseEndDate);
            
            Assert.AreEqual(expectingMessage, errorMessage);
        }

        [Test]
        [Category("CalendarTest")]
        public void SimilarStartDateAndEndDate()
        {
            string expectingMessage = ErrorCreater.SimilarStartDateAndEndDate();

            User user = UserCreater.UserWithSimilarStartDateAndEndDate();

            string errorMessage = new StartPage(webDriver)
                                            .FillRentalDateEnd(user)
                                            .FillRentalDateStartFields(user)
                                            .ClickSubmitButton()
                                            .GetErrorMessageText();

            Log.Info(ErrorTextForSimilarStartDateAndEdDate);

            Assert.AreEqual(expectingMessage, errorMessage);
        }

        [Test]
        [Category("PositiveTest")]
        public void SendOrderPositiveTest()
        {
            string expectingMessage = ErrorCreater.CorrectNamePhoneEmail();

            User user = UserCreater.WithAllProperties();

            string errorMessage = new StartPage(webDriver)
                                            .ClickContactsButton()
                                            .WriteButton()
                                            .FillNameField(user)
                                            .FillPhoneField(user)
                                            .FillEmailField(user)
                                            .SendButton()
                                            .GetErrorMessageText();

            Log.Info(ErrorTextForSendOrderPositiveTest);

            Assert.AreEqual(expectingMessage, errorMessage);
        }

        [Test]
        [Category("AskQuestionsTest")]
        public void SendAskQuestionWithInvalidEmail()
        {
            string expectingMessage = ErrorCreater.FormWithInvalidEMail();

            User user = UserCreater.UserWithIncorrectEmail();

            string errorMessage = new StartPage(webDriver)
                                            .ClickAskQuestionButtonToNextPage()
                                            .AskQuestionButton()
                                            .FillNameField(user)
                                            .FillPhoneField(user)
                                            .Submit()
                                            .GetErrorMessageText();

            Log.Info(ErrorTextForSendAsqQuestionWithInvalidData);

            Assert.AreEqual(expectingMessage, errorMessage);
        }

        [Test]
        [Category("PositiveTest")]
        public void SendAskQuestionWithCorrectData()
        {
            string expectingMessage = ErrorCreater.CorrectNamePhoneEmail();

            User user = UserCreater.WithAllProperties();

            string errorMessage = new StartPage(webDriver)
                                            .ClickAskQuestionButtonToNextPage()
                                            .AskQuestionButton()
                                            .FillNameField(user)
                                            .FillPhoneField(user)
                                            .Submit()
                                            .GetErrorMessageText();

            Log.Info(ErrorTextForDendAsqQuestionWithCorrectData);

            Assert.AreEqual(expectingMessage, errorMessage);
        }

        [Test]
        [Category("AskQuestionsTest")]
        public void SendAskQuestionWithIncorrectPhone()
        {
            string expectingMessage = ErrorCreater.FormWithInvalidPhone();

            User user = UserCreater.UserWithIncorrectPhone();

            string errorMessage = new StartPage(webDriver)
                                            .ClickAskQuestionButtonToNextPage()
                                            .AskQuestionButton()
                                            .FillNameField(user)
                                            .FillPhoneField(user)
                                            .Submit()
                                            .GetErrorMessageText();

            Log.Info(ErrorTextForAsqQuestionWithIncorrectPhone);

            Assert.AreEqual(expectingMessage, errorMessage);
        }
    }
}
