using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Models
{
    class Data
    {
        public string TenantName { get; set; }

        public string ClientName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Price { get; set; }

        public Data(string tenantName,string clientName,string phone,string email, string price)
        {
            TenantName = tenantName;
            ClientName = clientName;
            Phone = phone;
            Email = email;
            Price = price;
        }
    }
}
