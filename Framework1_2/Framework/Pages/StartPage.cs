using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using Framework.Pages;
using Framework.Utils;
using Framework.Model;
using System.Threading;

namespace Framework
{
    public class StartPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "some_class date_start")]
        private IWebElement rentalDateStart;

        [FindsBy(How = How.Id, Using = "some_class date_end")]
        private IWebElement rentalDateEnd;

        [FindsBy(How = How.Id, Using = "catalog-car")]
        private IWebElement submitButton;

        [FindsBy(How = How.Id, Using = "call-back")]
        private IWebElement callBackButton;

        [FindsBy(How = How.Id, Using = "online-link")]
        private IWebElement payOnlineButton;

        [FindsBy(How = How.Id, Using = "collback_modal")]
        private IWebElement askQuestionButton;

        [FindsBy(How = How.Id, Using = "root-item")]
        private IWebElement contactsButton;

        [FindsBy(How = How.XPath, Using = "success_message")]
        private IWebElement errorMessageAlert;

        public StartPage FillInFields(User user)
        {
            Logger.Log.Info("Fill fields with date on start page");

            rentalDateStart.SendKeys(user.PastDate);
            rentalDateEnd.SendKeys(user.FutureDate);

            return this;
        }
        public StartPage ClickSubmitButton()
        {
            Logger.Log.Info("Send submit");

            submitButton.Click();

            return this;
        }

        public CallBackPage ClickCallBackButton()
        {
            Logger.Log.Info("Send call back button");

            callBackButton.Click();

            return new CallBackPage(this.webDriver);
        }

        public PayOnlinePage ClickPayOnlineButton()
        {
            Logger.Log.Info("Open pay online page");

            payOnlineButton.Click();

            return new PayOnlinePage(this.webDriver);
        }

        public AskQuestionPage ClickAskQuestionButton()
        {
            Logger.Log.Info("Open asq question page");

            askQuestionButton.Click();

            return new AskQuestionPage(this.webDriver);
        }

        public ContactsPage ClickContactsButton()
        {
            Logger.Log.Info("Send contasts button");

            contactsButton.Click();

            return new ContactsPage(this.webDriver);
        }        
        public override BasePage OpenPage()
        {
            Logger.Log.Info("Open start page");

            webDriver.Navigate().GoToUrl("https://www.avtomaxi.ru/");

            return this;
        }
        public StartPage(IWebDriver webDriver) : base(webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }
        public string GetErrorMessageText()
        {
            Logger.Log.Info("Get error message text: " + errorMessageAlert.Text);

            return errorMessageAlert.Text;
        }

    }
}
