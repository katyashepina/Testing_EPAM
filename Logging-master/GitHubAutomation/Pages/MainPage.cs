using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using TestAutomation.Models;
using OpenQA.Selenium.Support.UI;
using System;
using TestAutomation.Service;

namespace TestAutomation.Pages
{
    public class MainPage
    {
        private const string BASE_URL = "https://paytm.com/flights/";

        [FindsBy(How = How.XPath, Using = "//input[@data-reactid='168']")]
        private IWebElement DepartureCityField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@data-reactid='180']")]
        private IWebElement ArrivalCityField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@data-reactid='195']")]
        private IWebElement CalendarField { get; set; }

        [FindsBy(How = How.ClassName, Using = "_1WIP")]
        private IWebElement CityListClass { get; set; }

        [FindsBy(How = How.ClassName, Using = "_3LRd")]
        private IWebElement SearchButtonClass { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='_3cB6']")]
        private IWebElement TextError { get; set; }

        [FindsBy(How = How.ClassName, Using = "_1jns")]
        private IWebElement TravellersField { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".olTz._3wE8")]
        private IWebElement PlusOneAdultButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".olTz._3wE8")]
        private IWebElement PlusOneInfantButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "._1THk._3wE8")]
        private IWebElement MinusOneAdultButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "qj2b")]
        private IWebElement FieldValuesForAdults { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[@data-reactid='164']")]
        private IWebElement RoundTripRadioButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@data-reactid='209']")]
        private IWebElement ReturnDateField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@data-reactid='195']")]
        private IWebElement DepartureDateField { get; set; }

        [FindsBy(How = How.ClassName, Using = "Ccmi")]
        private IWebElement BookButtonClass { get; set; }

        [FindsBy(How = How.ClassName, Using = "_2JMZ")]
        private IWebElement PastDayClass { get; set; }

        [FindsBy(How = How.ClassName, Using = "_2JMZ")]
        private IWebElement CurrentDateMinusOneDayClass { get; set; }

        private IWebDriver driver;
        
        public MainPage(IWebDriver driver)
        {
            Logger.InitLogger();
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public MainPage OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Logger.Log.Info("Go to url https://paytm.com/flights/");
            return this;
        }

        public MainPage ChooseArrivalCity(Route route)
        {
            ArrivalCityField.Click();
            ArrivalCityField.SendKeys(route.ArrivalCity);
            WaitCityList();
            CityListClass.Click();
            Logger.Log.Info("Choose arrival city");
            return this;
        }
        public MainPage ChooseDepartureCity(Route route)
        {
            DepartureCityField.Click();
            DepartureCityField.SendKeys(route.DepartureCity);
            WaitCityList();
            CityListClass.Click();
            Logger.Log.Info("Choose departure city");
            return this;
        } 

        public MainPage ChooseIdenticalDepartureAndArrivalCity(Route route)
        {
            DepartureCityField.Click();
            DepartureCityField.SendKeys(route.DepartureCity);
            WaitCityList();
            CityListClass.Click();
            ArrivalCityField.SendKeys(route.DepartureCity);
            WaitCityList();
            CityListClass.Click();
            Logger.Log.Info("Choose identical departure and arrival city");
            return this;
        }

        public MainPage ClickCalendar()
        {
            CalendarField.Click();
            Logger.Log.Info("Open calendar");
            return this;
        }

        public MainPage ClickSearchButton()
        {
            SearchButtonClass.Click();
            Logger.Log.Info("Click SearchButton");
            return this;
        }
        public string GetTextError()
        {
            Logger.Log.Info("Get text error");
            return TextError.Text;
        }
        public MainPage ChooseTravellersField()
        {
            TravellersField.Click();
            Logger.Log.Info("Choose travellers field");
            return this;
        }

        public MainPage AddAdultsToTravellers(int countAdults)
        {
            for (int i = 1; i <= countAdults; i++)
                PlusOneAdultButton.Click();
            Logger.Log.Info("Add" + countAdults + "adults to traveller");
            return this;
        }

        public MainPage MinusAdultsToTravellers(int countAdults)
        {
            for (int i = 0; i < countAdults; i++)
                MinusOneAdultButton.Click();
            Logger.Log.Info("Minus" + countAdults + "Adults ToTraveller");
            return this;
        }

        public MainPage AddInfantsToTravellers(int countInfants)
        {
            for (int i = 0; i < countInfants; i++)
                PlusOneInfantButton.Click();
            Logger.Log.Info("Add" + countInfants + "Infants ToTraveller");
            return this;
        }

        public string GetCountOfAdults()
        {
            Logger.Log.Info("Get Count Of Adults");
            return FieldValuesForAdults.Text;
        }

        public MainPage ClickRoundTripRadioButton()
        {
            RoundTripRadioButton.Click();
            Logger.Log.Info("Click Round Trip Radio Button");
            return this;
        }
        public bool ReturnDateFieldIsClickable()
        {
            try
            {
                ReturnDateField.Click();
                Logger.Log.Info("ReturnDate Field Is Clickable");
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsDateClickable()
        {
            DepartureDateField.Click();
            Logger.Log.Info("Click Departure DateField");
            return CurrentDateMinusOneDayClass.Selected;
        }

        public TiketsListPage ClickBookButton(Route route)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("Ccmi")));
            BookButtonClass.Click();
            Logger.Log.Info("Click Book Button");
            return new TiketsListPage(driver);
        }

        private void WaitCityList()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.ClassName("_1WIP")));
        }
    }
}
