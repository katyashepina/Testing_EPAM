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
            rentalDateStart.SendKeys(user.PastDate);
            rentalDateEnd.SendKeys(user.FutureDate);

            return this;
        }

        public StartPage(IWebDriver webDriver):base(webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        public StartPage ClickSubmitButton()
        {
            submitButton.Click();

            return this;
        }

        public CallBackPage ClickCallBackButton()
        {
            callBackButton.Click();

            return new CallBackPage(this.webDriver);
        }

        public PayOnlinePage ClickPayOnlineButton()
        {
            payOnlineButton.Click();

            return new PayOnlinePage(this.webDriver);
        }

        public AskQuestionPage ClickAskQuestionButton()
        {
            askQuestionButton.Click();

            return new AskQuestionPage(this.webDriver);
        }

        public ContactsPage ClickContactsButton()
        {
            contactsButton.Click();

            return new ContactsPage(this.webDriver);
        }
        public string GetErrorMessageText()
        {
            return errorMessageAlert.Text;
        }
        
        public override BasePage OpenPage()
        {
            webDriver.Navigate().GoToUrl("https://www.avtomaxi.ru/");
            return this;
        }
    }
}
