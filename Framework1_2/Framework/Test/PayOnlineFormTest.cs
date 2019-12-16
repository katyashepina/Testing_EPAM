using Framework.Model;
using Framework.Pages;
using Framework.Services;
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
            string expectingMessage = ErrorCreater.MessageWithEmptyFields();

            User user = UserCreater.UserWithIncorrectEmailPhoneName();

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
