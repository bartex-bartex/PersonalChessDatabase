using PersonalChessdatabaseLibrary.DataAccess;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PersonalChessdatabaseLibrary
{
    public static class GlobalConfig
    {
        public static IDataConnection Connection { get; private set; }

        public static void InitializeConnections(DataSourceType dataSource)
        {
            if (dataSource == DataSourceType.Sql)
            {
                SqlConnector sql = new SqlConnector();
                Connection = sql;
            }
        }

        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
