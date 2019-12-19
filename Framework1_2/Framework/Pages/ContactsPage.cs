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
        private const string PageUrl = "https://www.avtomaxi.ru/kontakti/";

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

        public ContactsPage(IWebDriver webDriver) : base(webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }
        public override BasePage OpenPage()
        {
            webDriver.Navigate().GoToUrl(PageUrl);

            return this;
        }
        public ContactsPage FillNameField(User user)
        {
            nameField.SendKeys(user.Name);

            return this;
        }

        public ContactsPage FillPhoneField(User user)
        {
            phoneField.SendKeys(user.PNumber);

            return this;
        }
        public ContactsPage FillEmailField(User user)
        {
            emailField.SendKeys(user.EMail);

            return this;
        }
        public ContactsPage SendButton()
        {
            sendButton.Click();

            return this;
        }
        public ContactsPage WriteButton()
        {
            writeButton.Click();

            return this;
        }
               
        public string GetErrorMessageText()
        {
            return errorMessageAlert.Text;
        }
        
    }
}
