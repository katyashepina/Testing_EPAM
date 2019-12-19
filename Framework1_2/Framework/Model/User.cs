using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Model
{
    public class User
    {
        public string Renter { get; set; }
        public string Name { get; set; }
        public string PNumber { get; set; }
        public string EMail { get; set; }
        public string FutureDate { get; set; }
        public string PastDate { get; set; }
        public string Price { get; set; }
        public User(string renter, string name, string pNumber, string email,string futureDate, string pastDate, string price)
        {
            this.Renter = renter;
            this.Name = name;
            this.PNumber = pNumber;
            this.EMail = email;
            this.FutureDate = futureDate;
            this.PastDate = pastDate;
            this.Price = price;
        }       

    }
}
