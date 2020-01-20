using NUnit.Framework;
using TestAutomation.Driver;
using TestAutomation.Pages;
using TestAutomation.Service;
using TestAutomation.Utils;
using log4net;

namespace TestAutomation
{
    [TestFixture]
    public class Tests: TestListener
    {
        public static ILog Log = LogManager.GetLogger("LOGGER");
        private const string ACCEPTABLE_MAXIMUM_NUMBER_OF_ADULTS = "9";
        private const string ACCEPTABLE_NUMBER_OF_ADULTS_WITH_ONE_INFLANT = "1";

        [Test]
        public void SearchWithoutCityOfArrivalTest()
        {
            MainPage mainPage = new MainPage(DriverSingleton.GetDriver())
                .OpenPage()
                .ChooseDepartureCity(RouteCreator.OnlyDepartureCity())
                .ClickSearchButton();
            Assert.AreEqual("Please enter destination city", mainPage.GetTextError());
        }

        [Test]
        public void SearchWithoutCityOfOriginTest()
        {
            MainPage mainPage = new MainPage(DriverSingleton.GetDriver())
                .OpenPage()
                .ChooseArrivalCity(RouteCreator.OnlyArrivalCity())
                .ClickSearchButton();
            Assert.AreEqual("Please enter origin city", mainPage.GetTextError());
        }

        [Test]
        public void SearchForIdenticalCitiesTest()
        {
            MainPage mainPage = new MainPage(DriverSingleton.GetDriver())
                .OpenPage()
                .ChooseIdenticalDepartureAndArrivalCity(RouteCreator.WithAllProperties())
                .ClickSearchButton();
            Assert.AreEqual("Source and Destination can not be same", mainPage.GetTextError());
        }

        [Test]
        public void EnterAcceptableMaxCountOfAdults()
        {
            MainPage mainPage = new MainPage(DriverSingleton.GetDriver())
                .OpenPage()
                .ChooseTravellersField()
                .AddAdultsToTravellers(9);
            Assert.AreEqual(ACCEPTABLE_MAXIMUM_NUMBER_OF_ADULTS, mainPage.GetCountOfAdults());
        }

        [Test]
        public void EnterNotAcceptableMaxCountOfAdults()
        {
            MainPage mainPage = new MainPage(DriverSingleton.GetDriver())
                 .OpenPage()
                 .ChooseTravellersField()
                 .AddAdultsToTravellers(9);
            Assert.AreEqual(ACCEPTABLE_MAXIMUM_NUMBER_OF_ADULTS, mainPage.GetCountOfAdults());
        }

        [Test]
        public void DateFieldIsClickableWhenYouChooseRoundTripTest()
        {
           MainPage mainPage = new MainPage(DriverSingleton.GetDriver())
                 .OpenPage()
                 .ClickRoundTripRadioButton();
            Assert.IsTrue(mainPage.ReturnDateFieldIsClickable());
        }

        [Test]
        public void DateFieldIsClickableWhenYouChooseRoundTripTestTWo()
        {
            MainPage mainPage = new MainPage(DriverSingleton.GetDriver())
                  .OpenPage()
                  .ClickRoundTripRadioButton();
            Assert.IsTrue(mainPage.ReturnDateFieldIsClickable());
        }
        
        [Test]
        public void EnterOneInfantsWithoutAdults()
        {
            MainPage mainPage = new MainPage(DriverSingleton.GetDriver())
                .OpenPage()
                .ChooseTravellersField()
                .AddInfantsToTravellers(1)
                .MinusAdultsToTravellers(1);
            Assert.AreEqual(ACCEPTABLE_NUMBER_OF_ADULTS_WITH_ONE_INFLANT, mainPage.GetCountOfAdults());
        }

        [Test]
        public void EnterOneInfantsWithoutAdultsTwo()
        {
            MainPage mainPage = new MainPage(DriverSingleton.GetDriver())
                .OpenPage()
                .ChooseTravellersField()
                .AddInfantsToTravellers(1)
                .MinusAdultsToTravellers(1);
            Assert.AreEqual(ACCEPTABLE_NUMBER_OF_ADULTS_WITH_ONE_INFLANT, mainPage.GetCountOfAdults());
        }

        [Test]
        public void BookTicketForCurrentDayMinusOneDayTest()
        {
            MainPage mainPage = new MainPage(DriverSingleton.GetDriver())
                    .OpenPage();
            Assert.IsFalse(mainPage.IsDateClickable());
        }

    }
}
