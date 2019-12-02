using Framework.Models;
using GitHubAutomation.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Services
{
    class DataCreator
    {
        public static Data WithAllProperties()
        {
            return new Data(
                TestDataReader.GetData("TenantName"),
                TestDataReader.GetData("ClientName"),
                TestDataReader.GetData("Phone"),
                TestDataReader.GetData("Email"),
                TestDataReader.GetData("Price")
                );
        }
    }
}
