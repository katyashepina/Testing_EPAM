using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using Framework.Pages;
using Framework.Model;
using Framework.Utils;

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
            Logger.Log.Info("Fill Fields on page Call Back");

            nameField.SendKeys(user.Name);
            phoneField.SendKeys(user.PNumber);

            return this;
        }

        public CallBackPage SendCall()
        {
            Logger.Log.Info("Send call");

            sendButton.Click();

            return this;
        }        

        public override BasePage OpenPage()
        {
            Logger.Log.Info("Open Call Back page");

            webDriver.Navigate().GoToUrl("https://www.avtomaxi.ru/");

            return this;
        }
        public string GetMessageText()
        {
            Logger.Log.Info("Get error message text: " + errorMessageAlert.Text);

            return errorMessageAlert.Text;
        }
        public CallBackPage(IWebDriver webDriver) : base(webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }
    }
}
