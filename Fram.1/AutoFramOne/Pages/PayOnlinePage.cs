using Framework.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Framework.Pages
{
    class PayOnlinePage
    {
        IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//span[@class='online-link']")]
        IWebElement PayOnlineButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='tenant-name")]
        public IWebElement TenantName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='name")]
        public IWebElement ClientName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='phone")]
        public IWebElement Phone { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='email")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='price")]
        public IWebElement Price { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='green-btn']")]
        IWebElement ContinuePayment { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='left-content']")]
        public IWebElement MessagePayError { get; set; }

        public PayOnlinePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;            
        }

        public PayOnlinePage PayWithoutData(Data data)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='data_block']/div[@class='buy_button']")));
            ContinuePayment.Click();
            TenantName.SendKeys(data.TenantName);
            ClientName.SendKeys(data.ClientName);
            Phone.SendKeys(data.Phone);
            Email.SendKeys(data.Email);
            Price.SendKeys(data.Price);
            return new PayOnlinePage(driver);
        }
    }
}
