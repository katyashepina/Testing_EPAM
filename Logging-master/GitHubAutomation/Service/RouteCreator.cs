using TestAutomation.Models;

namespace TestAutomation.Service
{
    class RouteCreator
    {
        public static Route WithAllProperties()
        {
            return new Route(TestDataReader.GetData("DepartureCity"), TestDataReader.GetData("ArrivalCity"), 
                            TestDataReader.GetData("Email"), TestDataReader.GetData("PhoneNumber"));
        }
        public static Route OnlyArrivalCity()
        {
            return new Route("", TestDataReader.GetData("ArrivalCity"), "", "");
        }
        public static Route OnlyDepartureCity()
        {
            return new Route(TestDataReader.GetData("DepartureCity"), "", "", "");
        }
        public static Route OnlyEmail()
        {
            return new Route("", "", TestDataReader.GetData("Email"),  "");
        }
        public static Route Empty()
        {
            return new Route("", "", "", "");
        }
    }
}
