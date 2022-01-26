using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
  public  class MAL_GAYTARMA
    {
        //string connectionString = "Data Source=.;Initial Catalog=NewInteko;Integrated Security=True";
        string procedure = "INSERT_MAL_GAYTARMA_MAIN";
        string procedure1 = "INSERT_MAL_GAYTARMA_DETAILS";

        public int InsertMalGaytarma(string EMELIYYAT_NOMRE, DateTime TARIX)
        {
            // Create ADO.NET objects.
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(procedure, con);
            // Configure command and add input parameters.
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@EMELIYYAT_NOMRE", SqlDbType.NVarChar, 100);
            param.Value = EMELIYYAT_NOMRE;
            param = cmd.Parameters.Add("@TARIX", SqlDbType.Date);
            param.Value = TARIX;
           
            // Add the output parameter.
            param = cmd.Parameters.Add("@emp_count", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            // Execute the command.
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return Convert.ToInt32(param.Value);
        }
        public int InsertMalGaytarmaDetails(string MAL_GEYTARMA_MAIN_ID, string MAL_ALISI_DETAILS_ID,string MIGDARI)
        {
            // Create ADO.NET objects.
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(procedure1, con);
            // Configure command and add input parameters.
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@MAL_GEYTARMA_MAIN_ID", SqlDbType.NVarChar, 100);
            param.Value = MAL_GEYTARMA_MAIN_ID;
            param = cmd.Parameters.Add("@MAL_ALISI_DETAILS_ID", SqlDbType.NVarChar, 100);
            param.Value = MAL_ALISI_DETAILS_ID;
            param = cmd.Parameters.Add("@MIGDARI", SqlDbType.NVarChar,100);
            param.Value = MIGDARI;

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
