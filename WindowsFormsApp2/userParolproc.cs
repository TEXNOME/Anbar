using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class userParolproc
    {
        //string ConString = "Data Source=DESKTOP-UB3DILS;Initial Catalog=NewInteko;Integrated Security=True";
        string insertUser = "userParol_insert";
        string updateUser = "userParol_update";
        string deleteUser = "userParol_delete";

        public void INSERT_user(string login, string parol, int admin)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(insertUser, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@login", SqlDbType.VarChar);
            param.Value = login;
            param = cmd.Parameters.Add("@parol", SqlDbType.VarChar);
            param.Value = parol;
            param = cmd.Parameters.Add("@admin", SqlDbType.Int);
            param.Value = admin;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UPDATE_user(int id,string login, string parol, int admin)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(updateUser, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@id", SqlDbType.Int);
            param.Value = id;
            param = cmd.Parameters.Add("@login", SqlDbType.VarChar);
            param.Value = login;
            param = cmd.Parameters.Add("@parol", SqlDbType.VarChar);
            param.Value = parol;
            param = cmd.Parameters.Add("@admin", SqlDbType.Int);
            param.Value = admin;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public void DELETE_user(string login)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(deleteUser, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@login", SqlDbType.VarChar);
            param.Value = login;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
