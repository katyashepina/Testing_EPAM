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
        private const string PageUrl = "https://www.avtomaxi.ru/";

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

        public StartPage() : base()
        {
            PageFactory.InitElements(webDriver, this);

            OpenPage();
        }
        public override BasePage OpenPage()
        {
            webDriver.Navigate().GoToUrl(PageUrl);

            return this;
        }
        public StartPage FillRentalDateStartFields(User user)
        {
            rentalDateStart.SendKeys(user.PastDate);

            return this;
        }
        public StartPage FillRentalDateEnd(User user)
        {
            rentalDateEnd.SendKeys(user.FutureDate);

            return this;
        }
        public StartPage ClickSubmitButton()
        {
            submitButton.Click();

            return this;
        }

        public CallBackPage ClickCallBackButton()
        {
            callBackButton.Click();

            return new CallBackPage();
        }

        public PayOnlinePage ClickPayOnlineButton()
        {
            payOnlineButton.Click();

            return new PayOnlinePage();
        }

        public AskQuestionPage ClickAskQuestionButtonToNextPage()
        {
            askQuestionButton.Click();

            return new AskQuestionPage();
        }

        public ContactsPage ClickContactsButton()
        {
            contactsButton.Click();

            return new ContactsPage();
        } 
        
        public string GetErrorMessageText()
        {
            return errorMessageAlert.Text;
        }

    }
}
