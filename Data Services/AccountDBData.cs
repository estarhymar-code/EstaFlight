using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Data_Services
{
    public class AccountDBData
    {
        private string connectionString
        = "Data Source =localhost\\SQLEXPRESS; Initial Catalog = EstaFlight; Integrated Security = True; TrustServerCertificate=True;";

        private SqlConnection sqlConnection;
        public AccountDBData()
        {
            
        }

    }
}
