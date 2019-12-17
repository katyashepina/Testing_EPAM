using Framework.Model;
using Framework.Pages;
using Framework.Services;
using Framework.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Test
{
    [TestFixture]
    public class PayOnlineFormTest : CommonConditions
    {
        [Test]
        [Category("FormTest")]
        public void SendWithCorrectData()
        {
            Logger.Log.Info("Start SendWithCorrectData unit test.");

            string expectingMessage = ErrorCreater.CorrectNamePhoneEmail();

            User user = UserCreater.WithAllProperties();

            string errorMessage = (new PayOnlinePage(webDriver).OpenPage() as PayOnlinePage)
                                    .FillInFields(user)
                                    .SendPayOnline()
                                    .GetErrorMessageText();

            Assert.AreEqual(expectingMessage, errorMessage);
        }

        [Test]
        [Category("FormTest")]
        public void SendWithOutCorrectData()
        {
            Logger.Log.Info("Start SendWithOutCorrectData unit test.");

            string expectingMessage = ErrorCreater.SimilarStartDateAndEndDate();

            User user = UserCreater.UserWithSimilarStartDateAndEndDate();

            string errorMessage = (new PayOnlinePage(webDriver).OpenPage() as PayOnlinePage)
                                    .FillInFields(user)
                                    .SendPayOnline()
                                    .GetErrorMessageText();

            Assert.AreEqual(expectingMessage, errorMessage);
        }

        [Test]
        [Category("FormTest")]
        public void SendWithOutCorrectPrice()
        {
            Logger.Log.Info("Start SendWithOutCorrectPrice unit test.");

            string expectingMessage = ErrorCreater.FormWithInvalidPrice();

            User user = UserCreater.UserWithIncorrectPrice();

            string errorMessage = (new PayOnlinePage(webDriver).OpenPage() as PayOnlinePage)
                                    .FillInFields(user)
                                    .SendPayOnline()
                                    .GetErrorMessageText();

            Assert.AreEqual(expectingMessage, errorMessage);
        }
    }
}
