using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
   public class CrudSirket
    {

       // string connectionString = "Data Source=.;Initial Catalog=NewInteko;Integrated Security=True";

        string procedure = "INSERT_COMPANY";

        public int InsertCompany(string COMPANY_NAME, string ADRESS, string PHONE,
          string EMAILL, string HN, string BANK_ADI, string VOEN, string KOD,
         string MH, string SWIFT, string MESUL_SEXS, DateTime START_DATE, string sirket_voen ,string sirket_kod,string web_sayt
            )
        {
            // Create ADO.NET objects.
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(procedure, con);
            // Configure command and add input parameters.
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@COMPANY_NAME", SqlDbType.NVarChar, 500);
            param.Value = COMPANY_NAME;
            param = cmd.Parameters.Add("@ADRESS", SqlDbType.NVarChar, 500);
            param.Value = ADRESS;
            param = cmd.Parameters.Add("@PHONE", SqlDbType.NVarChar, 500);
            param.Value = PHONE;

            param = cmd.Parameters.Add("@EMAILL", SqlDbType.NVarChar, 500);
            param.Value = EMAILL;
            param = cmd.Parameters.Add("@HN", SqlDbType.NVarChar, 500);
            param.Value = HN;
            param = cmd.Parameters.Add("@BANK_ADI", SqlDbType.NVarChar, 500);
            param.Value = BANK_ADI;

            param = cmd.Parameters.Add("@VOEN", SqlDbType.NVarChar, 500);
            param.Value = VOEN;
            param = cmd.Parameters.Add("@KOD", SqlDbType.NVarChar, 500);
            param.Value = KOD;
            param = cmd.Parameters.Add("@MH", SqlDbType.NVarChar, 500);
            param.Value = MH;

            param = cmd.Parameters.Add("@SWIFT", SqlDbType.NVarChar, 500);
            param.Value = SWIFT;
            param = cmd.Parameters.Add("@MESUL_SEXS", SqlDbType.NVarChar, 500);
            param.Value = MESUL_SEXS;

            //param = cmd.Parameters.Add("@LOGO", SqlDbType.Binary,int.MaxValue);

            //param.Value = pictr;
            param = cmd.Parameters.Add("@START_DATE", SqlDbType.Date);
            param.Value = START_DATE;


            //param.Value = pictr;
            param = cmd.Parameters.Add("@SIRKET_VOEN", SqlDbType.NVarChar,250);
            param.Value = sirket_voen;

            //param.Value = pictr;
            param = cmd.Parameters.Add("@OBYEKT_KODU", SqlDbType.NVarChar,250);
            param.Value = sirket_kod;

            //param.Value = pictr;
            param = cmd.Parameters.Add("@WEB_SAYTI", SqlDbType.NVarChar,250);
            param.Value = web_sayt;

            // Add the output parameter.
            param = cmd.Parameters.Add("@emp_count", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            // Execute the command.
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return Convert.ToInt32(param.Value);
        }
    }
}
