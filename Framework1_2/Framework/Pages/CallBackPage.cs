using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using Framework.Pages;
using Framework.Model;
using Framework.Utils;
using Framework.driver;

namespace Framework
{
    public class CallBackPage :BasePage
    {
        private const string PageUrl = "https://www.avtomaxi.ru/";

        [FindsBy(How = How.Name, Using = "name")]
        private IWebElement nameField;

        [FindsBy(How = How.Name, Using = "phone")]
        private IWebElement phoneField;
        
        [FindsBy(How = How.Name, Using = "blue-btn")]
        private IWebElement sendButton;

        [FindsBy(How = How.ClassName, Using = "success_message")]
        private IWebElement errorMessageAlert;

        public CallBackPage() : base() { }
        
        public override BasePage OpenPage()
        {
            DriverSingleton.GetInstance().Navigate().GoToUrl(PageUrl);

            return this;
        }
        public CallBackPage FillINameField(User user)
        {
            nameField.SendKeys(user.Name);

            return this;
        }
        public CallBackPage FillIPhoneField(User user)
        {
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
       
    }
}
