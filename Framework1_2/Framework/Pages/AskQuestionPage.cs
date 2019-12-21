using Framework.driver;
using Framework.Model;
using Framework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Pages
{
    public class AskQuestionPage : BasePage
    {
        private const string PageUrl = "https://www.avtomaxi.ru/faq/";

        [FindsBy(How = How.Name, Using = "name")]
        private IWebElement nameField;

        [FindsBy(How = How.Name, Using = "phone")]
        private IWebElement phoneField;

        [FindsBy(How = How.Name, Using = "blue-btn")]
        private IWebElement sendButton;

        [FindsBy(How = How.Name, Using = "send-faq")]
        private IWebElement askQuestionButton;

        [FindsBy(How = How.ClassName, Using = "success_message")]
        private IWebElement errorMessageAlert;

        public AskQuestionPage() : base() { }
        
        public override BasePage OpenPage()
        {
            DriverSingleton.GetInstance().Navigate().GoToUrl(PageUrl);

            return this;
        }
        public AskQuestionPage FillNameField(User user)
        {
            nameField.SendKeys(user.Name);

            return this;
        }
        public AskQuestionPage FillPhoneField(User user)
        {
            phoneField.SendKeys(user.PNumber);

            return this;
        }

        public AskQuestionPage Submit()
        {
            sendButton.Click();

            return this;
        }

        public AskQuestionPage AskQuestionButton()
        {
            askQuestionButton.Click();

            return this;
        }                

        public string GetErrorMessageText()
        {
            return errorMessageAlert.Text;
        }
       
    }
}
