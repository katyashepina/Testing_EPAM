using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using Framework.Pages;
using Framework.Model;

namespace Framework
{
    public class CallBackPage :BasePage
    {
        [FindsBy(How = How.Name, Using = "name")]
        private IWebElement nameField;

        [FindsBy(How = How.Name, Using = "phone")]
        private IWebElement phoneField;
        
        [FindsBy(How = How.Name, Using = "blue-btn")]
        private IWebElement sendButton;

        [FindsBy(How = How.ClassName, Using = "success_message")]
        private IWebElement errorMessageAlert;

        public CallBackPage FillInFields(User user)
        {
            nameField.SendKeys(user.Name);
            phoneField.SendKeys(user.PNumber);

            return this;
        }

        public CallBackPage SendCall()
        {
            sendButton.Click();

            return this;
        }

        public string GetMessageText()
        {
            return errorMessageAlert.Text;
        }

        public override BasePage OpenPage()
        {
            webDriver.Navigate().GoToUrl("https://www.avtomaxi.ru/");
            return this;
        }

        public CallBackPage(IWebDriver webDriver) : base(webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }
    }
}
