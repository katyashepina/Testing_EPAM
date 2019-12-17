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

        public AskQuestionPage FillInFields(User user)
        {
            Logger.Log.Info("FillInFields on AskQuestionPage");

            nameField.SendKeys(user.Name);
            phoneField.SendKeys(user.PNumber);

            return this;
        }

        public AskQuestionPage Submit()
        {
            Logger.Log.Info("Submit send ask");

            sendButton.Click();

            return this;
        }

        public AskQuestionPage AskQuestionButton()
        {
            Logger.Log.Info("Submit askQuestion");

            askQuestionButton.Click();

            return this;
        }
        public override BasePage OpenPage()
        {
            Logger.Log.Info("Open page Ask Question");

            webDriver.Navigate().GoToUrl("https://www.avtomaxi.ru/faq/");

            return this;
        }        

        public string GetErrorMessageText()
        {
            Logger.Log.Info("Get error message text: " + errorMessageAlert.Text);

            return errorMessageAlert.Text;
        }
        public AskQuestionPage(IWebDriver webDriver) : base(webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }
    }
}
