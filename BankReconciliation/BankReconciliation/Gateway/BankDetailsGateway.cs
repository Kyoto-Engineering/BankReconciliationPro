using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankReconciliation.DAO;

namespace BankReconciliation.Gateway
{
  public   class BankDetailsGateway:ConnectionGateway
    {


        public int  SaveBankdetails(BankAccounts aBankDetails)
        {
            connection.Open();
            string insertquery = "insert into BankAccounts(AccountNo,BankName,ShortName,BranchName,TypeOfAccount,AccountTitle,Balance,AvailableBalance, OD, InitialBalance, InitialBalanceDate,LimitSet) values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12) " + "SELECT CONVERT(int, SCOPE_IDENTITY())";
            SqlCommand cmd = new SqlCommand(insertquery, connection);
            cmd.Parameters.AddWithValue("@d1", aBankDetails.AccountNumber);
            cmd.Parameters.AddWithValue("@d2", aBankDetails.BankName);
            cmd.Parameters.AddWithValue("@d3", aBankDetails.BankShortName);
            cmd.Parameters.AddWithValue("@d4", aBankDetails.BranchName);
            cmd.Parameters.AddWithValue("@d5", aBankDetails.TypeOfAccount);
            cmd.Parameters.AddWithValue("@d6", aBankDetails.AccountTitle);
            cmd.Parameters.AddWithValue("@d7", aBankDetails.Balance);
            cmd.Parameters.AddWithValue("@d8", aBankDetails.Balance);
            cmd.Parameters.AddWithValue("@d9", "NON-OD");
            cmd.Parameters.AddWithValue("@d10", aBankDetails.Balance);
            cmd.Parameters.AddWithValue("@d11", DateTime.UtcNow.ToLocalTime());
            cmd.Parameters.AddWithValue("@d12", "Not-set");

            int affectedrows = cmd.ExecuteNonQuery();
            connection.Close();
            return affectedrows;
        }
    }
}
//values('" + aBankDetails.AccountNumber + "','" + aBankDetails.BankName + "','" + aBankDetails.BankShortName + "','" + aBankDetails.BranchName + "','" + aBankDetails.TypeOfAccount + "','" + aBankDetails.AccountTitle + "','" + aBankDetails.Balance + "')