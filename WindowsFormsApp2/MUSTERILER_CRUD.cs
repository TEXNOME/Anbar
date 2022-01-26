using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class MUSTERILER_CRUD
    {

        //string connectionString = "Data Source=.;Initial Catalog=NewInteko;Integrated Security=True";
        string procedure = "MUSTERILER_insert";
        string procedure_insert = "INSERT_MUSTERI";
        string procedure_delete = "delete_muster";



        public int delete_(int m_id)
        {
            // Create ADO.NET objects.
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(procedure_delete, con);
            // Configure command and add input parameters.
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;        

            param = cmd.Parameters.Add("@id", SqlDbType.Int);
            param.Value = m_id;
            // Add the output parameter.
            param = cmd.Parameters.Add("@emp_count", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            // Execute the command.
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return Convert.ToInt32(param.Value);
        }




        public int INSERT_MUSTERI_b(DateTime TARIX ,string SVNO,string FINKOD,
	string DOGULDUGU_YER,string UNVAN ,DateTime DOGUM_TARIX ,
   DateTime SV_VERILME_TARIX ,DateTime SV_BITME_TARIX ,string FAKTIKI_YASAYIS_YERI ,
	string AD ,string SOYAD ,string ATAADI ,string CINSI ,string VETENDASLIG ,
	string MOBIL ,string EV ,string GEYD ,string musteri_nomre )
        {
            // Create ADO.NET objects.
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(procedure_insert, con);
            // Configure command and add input parameters.
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;          
          
            param = cmd.Parameters.Add("@TARIX", SqlDbType.Date);
            param.Value = TARIX;
            param = cmd.Parameters.Add("@SVNO", SqlDbType.NVarChar,250);
            param.Value = SVNO;
            param = cmd.Parameters.Add("@FINKOD", SqlDbType.NVarChar,250);
            param.Value = FINKOD;
            param = cmd.Parameters.Add("@DOGULDUGU_YER", SqlDbType.NVarChar,250);
            param.Value = DOGULDUGU_YER;

            param = cmd.Parameters.Add("@UNVAN", SqlDbType.NVarChar,250);
            param.Value = UNVAN;
            param = cmd.Parameters.Add("@DOGUM_TARIX", SqlDbType.Date);
            param.Value = DOGUM_TARIX;
            param = cmd.Parameters.Add("@SV_VERILME_TARIX", SqlDbType.Date);
            param.Value = SV_VERILME_TARIX;
            param = cmd.Parameters.Add("@SV_BITME_TARIX", SqlDbType.Date);
            param.Value = SV_BITME_TARIX;
            param = cmd.Parameters.Add("@FAKTIKI_YASAYIS_YERI", SqlDbType.NVarChar, 250);
            param.Value = FAKTIKI_YASAYIS_YERI;
            param = cmd.Parameters.Add("@AD", SqlDbType.NVarChar, 250);
            param.Value = AD;
            param = cmd.Parameters.Add("@SOYAD", SqlDbType.NVarChar, 250);
            param.Value = SOYAD;
            param = cmd.Parameters.Add("@ATAADI", SqlDbType.NVarChar, 250);
            param.Value = ATAADI;
            param = cmd.Parameters.Add("@CINSI", SqlDbType.NVarChar,20);
            param.Value = CINSI;
            param = cmd.Parameters.Add("@VETENDASLIG", SqlDbType.NVarChar,250);
            param.Value = VETENDASLIG;

            param = cmd.Parameters.Add("@musteri_nomre", SqlDbType.NVarChar, 250);
            param.Value = musteri_nomre;
            // Add the output parameter.
            param = cmd.Parameters.Add("@emp_count", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            // Execute the command.
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return Convert.ToInt32(param.Value);
        }


   







        public int INSERT_MUSTERI( // int MUSTERI_NO ,DateTime TARIX ,
            string  SVNO,string FINKOD ,string  DOGULDUGU_YER,
	string  UNVAN ,DateTime DOGUM_TARIX,DateTime SV_VERILME_TARIX,DateTime SV_BITME_TARIX ,string  FAKTIKI_YASAYIS_YERI,string AD ,
	string  SOYAD ,string ATAADI ,string  CINSI,string  VETENDASLIG,string UNVAN_ ,string  MOBIL ,string  EV ,string GEYD ,
	byte[] SEKIL ,byte[] SENED1 ,byte[] SENED2 ,byte[] SENED3)
        {
            // Create ADO.NET objects.
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(procedure, con);
            // Configure command and add input parameters.
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            //param = cmd.Parameters.Add("@MUSTERI_NO", SqlDbType.Int);
            //param.Value = MUSTERI_NO;
            //param = cmd.Parameters.Add("@TARIX", SqlDbType.Date);
            //param.Value = TARIX;
            param = cmd.Parameters.Add("@SVNO", SqlDbType.NVarChar);
            param.Value = SVNO;
            param = cmd.Parameters.Add("@FINKOD", SqlDbType.NVarChar);
            param.Value = FINKOD;
            param = cmd.Parameters.Add("@DOGULDUGU_YER", SqlDbType.NVarChar);
            param.Value = DOGULDUGU_YER;
            param = cmd.Parameters.Add("@UNVAN", SqlDbType.NVarChar);
            param.Value = UNVAN;
            param = cmd.Parameters.Add("@DOGUM_TARIX", SqlDbType.Date);
            param.Value = DOGUM_TARIX;
            param = cmd.Parameters.Add("@SV_VERILME_TARIX", SqlDbType.Date);
            param.Value = SV_VERILME_TARIX;
            param = cmd.Parameters.Add("@SV_BITME_TARIX", SqlDbType.Date);
            param.Value = SV_BITME_TARIX;
            param = cmd.Parameters.Add("@FAKTIKI_YASAYIS_YERI", SqlDbType.NVarChar);
            param.Value = FAKTIKI_YASAYIS_YERI;
            param = cmd.Parameters.Add("@AD", SqlDbType.NVarChar);
            param.Value = AD;

            param = cmd.Parameters.Add("@SOYAD", SqlDbType.NVarChar);
            param.Value = SOYAD;
            param = cmd.Parameters.Add("@ATAADI", SqlDbType.NVarChar);
            param.Value = ATAADI;
            param = cmd.Parameters.Add("@CINSI", SqlDbType.NVarChar);
            param.Value = CINSI;

            param = cmd.Parameters.Add("@VETENDASLIG", SqlDbType.NVarChar);
            param.Value = VETENDASLIG;
            param = cmd.Parameters.Add("@UNVAN_", SqlDbType.NVarChar);
            param.Value = UNVAN_;
            param = cmd.Parameters.Add("@MOBIL", SqlDbType.NVarChar);
            param.Value = MOBIL;



            param = cmd.Parameters.Add("@EV", SqlDbType.NVarChar);
            param.Value = EV;
            param = cmd.Parameters.Add("@GEYD", SqlDbType.NVarChar);
            param.Value = GEYD;
            param = cmd.Parameters.Add("@SEKIL", SqlDbType.VarBinary);
            param.Value = SEKIL;


            param = cmd.Parameters.Add("@SENED1", SqlDbType.VarBinary);
            param.Value = SENED1;
            param = cmd.Parameters.Add("@SENED2", SqlDbType.VarBinary);
            param.Value = SENED2;
            param = cmd.Parameters.Add("@SENED3", SqlDbType.VarBinary);
            param.Value = SENED3;
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
