using Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Services
{
    public class UserCreater
    {
        public static User WithAllProperties()
        {
            return new User(
                            TestDataReader.GetData("User.Renter"),
                            TestDataReader.GetData("User.Name"), 
                            TestDataReader.GetData("User.PNumber"),
                            TestDataReader.GetData("User.EMail"), 
                            TestDataReader.GetData("User.FutureDate"),
                            TestDataReader.GetData("User.PastDate"), 
                            TestDataReader.GetData("User.Price")
                            );
        }

        public static User UserWithIncorrectEmail()
        {
            return new User(
                            TestDataReader.GetData("User.Renter"), 
                            TestDataReader.GetData("User.Name"),
                            TestDataReader.GetData("User.PNumber"),
                            TestDataReader.GetData("User.EMail.Incorrect"),
                            TestDataReader.GetData("User.FutureDate"),
                            TestDataReader.GetData("User.PastDate"), 
                            TestDataReader.GetData("User.Price")
                            );
        }

        public static User UserWithIncorrectPrice()
        {
            return new User(
                            TestDataReader.GetData("User.Renter"),
                            TestDataReader.GetData("User.Name.Incorrect"),
                            TestDataReader.GetData("User.PNumber.Incorrect"),
                            TestDataReader.GetData("User.EMail.Incorrect"),
                            TestDataReader.GetData("User.FutureDate"),
                            TestDataReader.GetData("User.PastDate"),
                            TestDataReader.GetData("User.Price.Incorrect")
                            );
        }
        public static User UserWithIncorrectEmailPhoneName()
        {
            return new User(
                            TestDataReader.GetData("User.Renter"), 
                            TestDataReader.GetData("User.Name.Incorrect"),
                            TestDataReader.GetData("User.PNumber.Incorrect"),
                            TestDataReader.GetData("User.EMail.Incorrect"),
                            TestDataReader.GetData("User.FutureDate"),
                            TestDataReader.GetData("User.PastDate"), 
                            TestDataReader.GetData("User.Price")
                            );
        }
       
        public static User UserWithIncorrectPhone()
        {
            return new User(
                            TestDataReader.GetData("User.Renter"), 
                            TestDataReader.GetData("User.Name"), 
                            TestDataReader.GetData("User.PNumber.Incorrect"),
                            TestDataReader.GetData("User.EMail"), 
                            TestDataReader.GetData("User.FutureDate"),
                            TestDataReader.GetData("User.PastDate"), 
                            TestDataReader.GetData("User.Price")
                            );
        }
        public static User UserWithDateLeaseEndDate()
        {
            return new User(
                            TestDataReader.GetData("User.Renter"),
                            TestDataReader.GetData("User.Name.Incorrect"), 
                            TestDataReader.GetData("User.PNumber.Incorrect"),
                            TestDataReader.GetData("User.EMail.Incorrect"),
                            TestDataReader.GetData("User.FutureDate"),
                            TestDataReader.GetData("User.PastDate.Incorrect"), 
                            TestDataReader.GetData("User.Price.Incorrect")
                            );
        }
        public static User UserWithSimilarStartDateAndEndDate()
        {
            return new User(
                            TestDataReader.GetData("User.Renter"),
                            TestDataReader.GetData("User.Name.Incorrect"),
                            TestDataReader.GetData("User.PNumber.Incorrect"),
                            TestDataReader.GetData("User.EMail.Incorrect"), 
                            TestDataReader.GetData("User.FutureDate"),
                            TestDataReader.GetData("User.FutureDate"), 
                            TestDataReader.GetData("User.Price.Incorrect")
                            );
        }
    }
}
