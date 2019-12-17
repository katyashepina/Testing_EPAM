using Framework.Model;
using Framework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Pages
{
    public class PayOnlinePage : BasePage
    {
        [FindsBy(How = How.Name, Using = "renter-name")]
        private IWebElement nameRenterField;

        [FindsBy(How = How.Name, Using = "name")]
        private IWebElement namePayerField;

        [FindsBy(How = How.Name, Using = "phone")]
        private IWebElement phoneField;

        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement emailField;

        [FindsBy(How = How.Name, Using = "price")]
        private IWebElement priceField;

        [FindsBy(How = How.Name, Using = "green-btn")]
        private IWebElement sendPayOnlineButton;
        
        [FindsBy(How = How.ClassName, Using = "continue_pay")]
        private IWebElement errorMessageAlert;

        public PayOnlinePage FillInFields(User user)
        {
            Logger.Log.Info("Fill fields on pay online page");

            nameRenterField.SendKeys(user.Renter);
            namePayerField.SendKeys(user.Name);
            phoneField.SendKeys(user.PNumber);
            emailField.SendKeys(user.EMail);
            priceField.SendKeys(user.Price);

            return this;
        }

        public override BasePage OpenPage()
        {
            Logger.Log.Info("Send button pay online");

            webDriver.Navigate().GoToUrl("https://www.avtomaxi.ru/online-payment/");

            return this;
        }

        public PayOnlinePage SendPayOnline()
        {
            Logger.Log.Info("Send button pay online");

            sendPayOnlineButton.Click();

            return this;
        }
        public string GetErrorMessageText()
        {
            Logger.Log.Info("Get error message text: " + errorMessageAlert.Text);

            return errorMessageAlert.Text;
        }
        public PayOnlinePage(IWebDriver webDriver) : base(webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }
    }
}
