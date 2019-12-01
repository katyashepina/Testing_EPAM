using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebDriver
{
    [TestClass]
    public class AutoMaxiTest
    {
        IWebDriver driver= new ChromeDriver();
        [TestMethod]
        public void СallBackTheWrongNameAndPhone()
        {
            driver.Navigate().GoToUrl(@"https://www.avtomaxi.ru/");
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.avtomaxi.ru/");
            driver.FindElement(By.XPath("//span[@class='callback open-popup-link']")).Click();
            driver.FindElement(By.XPath("//input[@name = 'name']")).SendKeys("111");
            driver.FindElement(By.XPath("//input[@name = 'phone']")).SendKeys("123");
            driver.FindElement(By.XPath("//input[@class='blue-btn']")).Click();
            IWebElement error = GetElement(driver, "//div[@class='success_message']");
            Assert.AreEqual("Данные указаны неверно.", error.Text);
            driver.Quit();
        }
        [TestMethod]
        public void PaymentOnlineIncorrectDetails()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.avtomaxi.ru/");
            driver.FindElement(By.XPath("//span[@class='callback open-popup-link']")).Click();
            driver.FindElement(By.XPath("//input[@name = 'tenant-name']")).SendKeys("artem");
            driver.FindElement(By.XPath("//input[@name = 'name']")).SendKeys("katya");
            driver.FindElement(By.XPath("//input[@name = 'phone']")).SendKeys("katya");
            driver.FindElement(By.XPath("//input[@name = 'email']")).SendKeys("katya@mail.ru");
            driver.FindElement(By.XPath("//input[@name = 'price']")).SendKeys("123");
            driver.FindElement(By.XPath("//input[@name = 'message']")).SendKeys("123");
            driver.FindElement(By.XPath("//input[@class='green-btn']")).Click();
            IWebElement error = GetElement(driver, "//h1[@class='title_page']");
            Assert.AreEqual("Оплата отменена.", error.Text);
            driver.Quit();
        }
        IWebElement GetElement(IWebDriver driver, string xPath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until<IWebElement>((d) =>
            {
                IWebElement webElement = d.FindElement(By.XPath(xPath));
                if (webElement.Displayed)
                    return webElement;
                return null;
            });
            return element;
        }
    }
}
