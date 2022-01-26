using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
 public    class techizatci_odenis
    {
       // string connectionString = "Data Source=.;Initial Catalog=NewInteko;Integrated Security=True";
        string procedure = "INSERT_TECHIZATCI_ODENIS";
        string proce1 = "techizatci_odenis_emeliyyat_nomre";
        string delete_odenis = "DELETE_TECHIZATCI_ODENISI";
        string update_techizatc = "update_techizatci";
        string UPDATE_KATEGORIYA = "kategory_update";

        public int update_kategoriya(int kategoriya_id, string kategoriya)
        {
            // Create ADO.NET objects.
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(UPDATE_KATEGORIYA, con);
            // Configure command and add input parameters.
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@KATEGORIYA_ID", SqlDbType.Int);
            param.Value = kategoriya_id;

            param = cmd.Parameters.Add("@KATEGORIYA", SqlDbType.NVarChar, 500);
            param.Value = kategoriya;

         
            // Add the output parameter.
            param = cmd.Parameters.Add("@EMCPOUNT", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            // Execute the command.
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return Convert.ToInt32(param.Value);
        }

        public int update_techizatci(int techizatci_id,string unvan,string mugavile_nom,string tel1,string tel2)
        {
            // Create ADO.NET objects.
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(update_techizatc, con);
            // Configure command and add input parameters.
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@TECHIZATCI_ID", SqlDbType.Int);
            param.Value = techizatci_id;

            param = cmd.Parameters.Add("@UNVAN", SqlDbType.NVarChar,500);
            param.Value = unvan;

            param = cmd.Parameters.Add("@MUVAGILE_NOM", SqlDbType.NVarChar, 500);
            param.Value = mugavile_nom;
            param = cmd.Parameters.Add("@TELEFON1", SqlDbType.NVarChar, 500);
            param.Value = tel1;
            param = cmd.Parameters.Add("@TELEFON2", SqlDbType.NVarChar, 500);
            param.Value = tel2;
            // Add the output parameter.
            param = cmd.Parameters.Add("@EMPCOUNT", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            // Execute the command.
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return Convert.ToInt32(param.Value);
        }
        public int DELETE_ODENIS(int TECHIZATCI_ODENIS_ID)
        {
            // Create ADO.NET objects.
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(delete_odenis, con);
            // Configure command and add input parameters.
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@TECHIZATCI_ODENISI_ID", SqlDbType.Int);
            param.Value = TECHIZATCI_ODENIS_ID;
          

            // Add the output parameter.
            param = cmd.Parameters.Add("@EMPCOUNT", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            // Execute the command.
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return Convert.ToInt32(param.Value);
        }
        public string emeliyyat_nomre()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(proce1, con);
            // Configure command and add input parameters.
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

          
            // Add the output parameter.
            param = cmd.Parameters.Add("@r", SqlDbType.NVarChar,100);
            param.Direction = ParameterDirection.Output;
            // Execute the command.
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return Convert.ToString(param.Value);
        }
        public int INSERT_ODENIS(int MAL_ALISI_MAIN_ID , decimal ODENIS,string  ODENIS_TIPI ,string gaime_n,string geyd,DateTime tarix,string emeliyyat_nomre,string faktura_nom)
        {
            // Create ADO.NET objects.
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(procedure, con);
            // Configure command and add input parameters.
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
         
            param = cmd.Parameters.Add("@MAL_ALISI_MAIN_ID", SqlDbType.Int);
            param.Value = MAL_ALISI_MAIN_ID;
            param = cmd.Parameters.Add("@ODENIS", SqlDbType.Decimal);
            param.Value = ODENIS;
            param = cmd.Parameters.Add("@ODENIS_TIPI", SqlDbType.NVarChar);
            param.Value = ODENIS_TIPI;

            param = cmd.Parameters.Add("@GAIME_N", SqlDbType.NVarChar);
            param.Value = gaime_n;
            param = cmd.Parameters.Add("@GEYD", SqlDbType.NVarChar);
            param.Value = geyd;
            param = cmd.Parameters.Add("@TARIX", SqlDbType.Date);
            param.Value = tarix;
            param = cmd.Parameters.Add("@EMELIYYAT_NOMRE", SqlDbType.NVarChar,250);
            param.Value = emeliyyat_nomre;

            param = cmd.Parameters.Add("@FAKTURA_NOMRE", SqlDbType.NVarChar, 50);
            param.Value = faktura_nom;

            // Add the output parameter.
            param = cmd.Parameters.Add("@EMPCOUNT", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            // Execute the command.
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return Convert.ToInt32(param.Value);
        }


       

    }
}
