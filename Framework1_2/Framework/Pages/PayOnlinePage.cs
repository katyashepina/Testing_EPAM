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
        private const string PageUrl = "https://www.avtomaxi.ru/online-payment/";

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

        public PayOnlinePage(IWebDriver webDriver) : base(webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }        
        public override BasePage OpenPage()
        {
            webDriver.Navigate().GoToUrl(PageUrl);

            return this;
        }
        public PayOnlinePage FillNameRenterField(User user)
        {
            nameRenterField.SendKeys(user.Renter);

            return this;
        }
        public PayOnlinePage FillNamePayerField(User user)
        {
            namePayerField.SendKeys(user.Name);

            return this;
        }
        public PayOnlinePage FillPhoneField(User user)
        {
            phoneField.SendKeys(user.PNumber);

            return this;
        }
        public PayOnlinePage FillEmailField(User user)
        {
            emailField.SendKeys(user.EMail);

            return this;
        }
        public PayOnlinePage FillPriceField(User user)
        {
            priceField.SendKeys(user.Price);

            return this;
        }

        public PayOnlinePage SendPayOnline()
        {
            sendPayOnlineButton.Click();

            return this;
        }
        public string GetErrorMessageText()
        {
            return errorMessageAlert.Text;
        }
        
    }
}
