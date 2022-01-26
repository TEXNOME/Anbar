using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
   public  class satis_json
    {

       // string connectionString = "Data Source=.;Initial Catalog=NewInteko;Integrated Security=True";

        string procedure = "satis_json";
        string Item = "INSERT_Item";
        string del_tiem = "delete_item";
        string ins_header = "INSERT_header";
        string del_header = "delete_header";
        string update_tr_calculation = "update_calc_tr";
        string insert_calculation_ = "insert_calculation";
        string del_ = "dele_temp_data";
        string ins_def = "ins_default_calculation";
        string dele_all_temp_data_ = "dele_all_temp_data";
        string insert_pos_satis_check_json = "json_to_check_pos";
        string insert_pos_gaytarma_manual_ = "insert_pos_gaytarma_manual";
        string return_gaytarma_ = "return_gaytarma";


        public string returnjson_gaytarma( string emeliyyat_nomre_)
        {
            // Create ADO.NET objects.
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(return_gaytarma_, con);
            // Configure command and add input parameters.
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            //param = cmd.Parameters.Add("@WAREHOUSE_NAME", SqlDbType.NVarChar, 500);
            //param.Value = WAREHOUSE_NAME;
            //param = cmd.Parameters.Add("@ADDRESS", SqlDbType.NVarChar, 500);
            //param.Value = ADDRESS;
            param = cmd.Parameters.Add("@emeliyyat_nomre", SqlDbType.NVarChar, 500);
            param.Value = emeliyyat_nomre_;
            // Add the output parameter.
            param = cmd.Parameters.Add("@ret", SqlDbType.NVarChar, int.MaxValue);
            param.Direction = ParameterDirection.Output;
            // Execute the command.
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return param.Value.ToString();
        }


        public void insert_pos_gaytarma_manual_proc(string emeliyyat_nomre ,int pos_satis_check_main_id  ,int pos_satis_check_details ,
        int say)
        {
            // Create ADO.NET objects.
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(insert_pos_gaytarma_manual_, con);
            // Configure command and add input parameters.
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@emeliyyat_nomre", SqlDbType.NVarChar,100);
            param.Value = emeliyyat_nomre;
            param = cmd.Parameters.Add("@pos_satis_check_main_id", SqlDbType.Int);
            param.Value = pos_satis_check_main_id;
            param = cmd.Parameters.Add("@pos_satis_check_details", SqlDbType.Int);
            param.Value = pos_satis_check_details;
            param = cmd.Parameters.Add("@say", SqlDbType.Int);
            param.Value = say;




            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void insert_chec_pos_main (string json_data_)
        {
            // Create ADO.NET objects.
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(insert_pos_satis_check_json, con);
            // Configure command and add input parameters.
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@t", SqlDbType.NVarChar, int.MaxValue);
            param.Value = json_data_;


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void del_temp_all_data(string emeliyyat_nomre)
        {
            // Create ADO.NET objects.
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(dele_all_temp_data_, con);
            // Configure command and add input parameters.
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@emeliyyat_nomre", SqlDbType.NVarChar, 20);
            param.Value = emeliyyat_nomre;      


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }


        public void ins_def_calc()
        {
            // Create ADO.NET objects.
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(ins_def, con);
            // Configure command and add input parameters.
            cmd.CommandType = CommandType.StoredProcedure;


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void del_tr()
        {
            // Create ADO.NET objects.
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(del_, con);
            // Configure command and add input parameters.
            cmd.CommandType = CommandType.StoredProcedure;


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void update_calculation_tr()
        {
            // Create ADO.NET objects.
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(update_tr_calculation, con);
            // Configure command and add input parameters.
            cmd.CommandType = CommandType.StoredProcedure;
           
          
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void insert_calculation_data(string emeliyyat_nomre,int mal_alisi_details_id, string barkod ,string mehsul_adi,decimal satis_qiymeti )
        {
            // Create ADO.NET objects.
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(insert_calculation_, con);
            // Configure command and add input parameters.
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@emeliyyat_nomre", SqlDbType.NVarChar, 20);
            param.Value = emeliyyat_nomre;
            param = cmd.Parameters.Add("@mal_alisi_details_id", SqlDbType.Int);
            param.Value = mal_alisi_details_id;
            param = cmd.Parameters.Add("@barkod", SqlDbType.NVarChar,100);
            param.Value = barkod;
            param = cmd.Parameters.Add("@mehsul_adi", SqlDbType.NVarChar,250);
            param.Value = mehsul_adi;
            param = cmd.Parameters.Add("@satis_qiymeti", SqlDbType.Decimal);
            param.Value = satis_qiymeti;
          



            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void delete_hed()
        {
            // Create ADO.NET objects.
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(del_header, con);

            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void insert_head(decimal _cashPayment,decimal _cardPayment,decimal _bonusPayment ,string _clientName )
        {
            // Create ADO.NET objects.
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(ins_header, con);
            // Configure command and add input parameters.
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@cashPayment", SqlDbType.Decimal);
            param.Value = _cashPayment;
            param = cmd.Parameters.Add("@cardPayment", SqlDbType.Decimal);
            param.Value = _cardPayment;
            param = cmd.Parameters.Add("@bonusPayment", SqlDbType.Decimal);
            param.Value = _bonusPayment;
            param = cmd.Parameters.Add("@clientName", SqlDbType.NVarChar,100);
            param.Value = _clientName;
      

            
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
          
        }

        public void delete_item()
        {
            // Create ADO.NET objects.
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(del_tiem, con);
           
            cmd.CommandType = CommandType.StoredProcedure;
           
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
           
        }

        public  void  insert_item(string _name ,string  _code,decimal	_quantity,decimal   _salePrice,decimal  _purchasePrice,
          int _vatType,int  _quantityType ,int mal_alisi_details_id_)
        {
            // Create ADO.NET objects.
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(Item, con);
            // Configure command and add input parameters.
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100);
            param.Value = _name;
            param = cmd.Parameters.Add("@code", SqlDbType.NVarChar, 100);
            param.Value = _code;
            param = cmd.Parameters.Add("@quantity", SqlDbType.Decimal);
            param.Value = _quantity;
            param = cmd.Parameters.Add("@salePrice", SqlDbType.Decimal);
            param.Value = _salePrice;
            param = cmd.Parameters.Add("@purchasePrice", SqlDbType.Decimal);
            param.Value = _purchasePrice;
            param = cmd.Parameters.Add("@vatType", SqlDbType.Int);
            param.Value = _vatType;
            param = cmd.Parameters.Add("@quantityType", SqlDbType.Int);
            param.Value = _quantityType;
            param = cmd.Parameters.Add("@mal_alisi_details_id", SqlDbType.Int);
            param.Value = mal_alisi_details_id_;

            // Add the output parameter.
            //param = cmd.Parameters.Add("@ret", SqlDbType.int);
            //param.Direction = ParameterDirection.Output;
            // Execute the command.
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            //return param.Value.ToString();
        }

        public string returnjson()
        {
            // Create ADO.NET objects.
            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand(procedure, con);
            // Configure command and add input parameters.
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            //param = cmd.Parameters.Add("@WAREHOUSE_NAME", SqlDbType.NVarChar, 500);
            //param.Value = WAREHOUSE_NAME;
            //param = cmd.Parameters.Add("@ADDRESS", SqlDbType.NVarChar, 500);
            //param.Value = ADDRESS;
            //param = cmd.Parameters.Add("@TELEFON", SqlDbType.NVarChar, 500);
            //param.Value = TELEFON;
            // Add the output parameter.
            param = cmd.Parameters.Add("@ret", SqlDbType.NVarChar,int.MaxValue);
            param.Direction = ParameterDirection.Output;
            // Execute the command.
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return param.Value.ToString();
        }
    }
}
