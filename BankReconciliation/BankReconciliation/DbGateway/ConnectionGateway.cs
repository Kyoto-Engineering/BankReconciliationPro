using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankReconciliation
{
   public class ConnectionGateway
    {
        
       protected SqlConnection connection;

         public ConnectionGateway()
        {

           // string connectionString = @"Data Source=DESKTOP-TQ74LPH\SQLSERVER2018;Initial Catalog=BankReconciliationDBProNovember;User=sa;Password=SystemAdministrator;Persist Security Info=True;";
            string connectionString = @"Data Source=LAPTOP-19NF5E9;Initial Catalog=BankReconciliationDBProNovember;User=sa;Password=SystemAdministrator;Persist Security Info=True;";
         //  string connectionString = @"Data Source=LAPTOP-19NF5E9;Initial Catalog=BankReconciliationDBProNovember;User=sa;Password=SystemAdministrator;Persist Security Info=True;";
          
            connection = new SqlConnection(connectionString);
        }
    }
}
