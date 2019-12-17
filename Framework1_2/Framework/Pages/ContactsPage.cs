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
    public class ContactsPage:BasePage
    {
        [FindsBy(How = How.Name, Using = "name")]
        private IWebElement nameField;

        [FindsBy(How = How.Name, Using = "phone")]
        private IWebElement phoneField;

        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement emailField;

        [FindsBy(How = How.Name, Using = "blue-btn")]
        private IWebElement sendButton;

        [FindsBy(How = How.Name, Using = "open-popul-link")]
        private IWebElement writeButton;

        [FindsBy(How = How.Id, Using = "success-message")]
        private IWebElement errorMessageAlert;

        public ContactsPage FillInFields(User user)
        {
            Logger.Log.Info("Fill fields on Contacts page");

            nameField.SendKeys(user.Name);
            phoneField.SendKeys(user.PNumber);
            emailField.SendKeys(user.EMail);

            return this;
        }
        
        public ContactsPage SendButton()
        {
            Logger.Log.Info("Send button");

            sendButton.Click();

            return this;
        }
        public ContactsPage WriteButton()
        {
            Logger.Log.Info("Send write button");

            writeButton.Click();

            return this;
        }
        
        public override BasePage OpenPage()
        {
            Logger.Log.Info("Open Contacts page");

            webDriver.Navigate().GoToUrl("https://www.avtomaxi.ru/kontakti/");

            return this;
        }
        public string GetErrorMessageText()
        {
            Logger.Log.Info("Get error message text: " + errorMessageAlert.Text);

            return errorMessageAlert.Text;
        }
        public ContactsPage(IWebDriver webDriver) : base(webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }
    }
}
