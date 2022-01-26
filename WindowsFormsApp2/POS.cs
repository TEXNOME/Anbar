using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Text.Json;
using DevExpress.DataAccess.Native.Json;

namespace WindowsFormsApp2
{
    public partial class POS : DevExpress.XtraEditors.XtraForm
    {
        private const String CATEGORIES_TABLE = "Categories";
        // field name constants
        private const String CATEGORYID_FIELD = "CategoryID";

        private const string mal_alisi_details_id = "Mal_alisi_details_id";
        private const string barkod = "BARKOD";
        private const string mehsul_adi = "MƏHSUL ADI";
        private const string satis_qiymeti = "SATIŞ QİYMƏTİ";
        private const string say = "SAY";

        private DataTable dt;
        private SqlDataAdapter da;

        SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);


        public POS()
        {
            InitializeComponent();
        }

        private void POS_Load(object sender, EventArgs e)
        {
            gridControl1.TabStop = false;
            st.ins_def_calc();
            textEdit4.Text = DateTime.Now.ToString();
            ///LOAD FORM
            st.del_tr();
            get_emeliyyat_nomre();
          //  get_cem(textEdit11.Text.ToString());
            dt = new DataTable(CATEGORIES_TABLE);

            // add the identity column
            DataColumn col = dt.Columns.Add(CATEGORYID_FIELD, typeof(System.Int32));
            col.AllowDBNull = false;
            col.AutoIncrement = true;
            col.AutoIncrementSeed = 0;
            col.AutoIncrementStep = 1;
            // set the primary key
            dt.PrimaryKey = new DataColumn[] { col };

            // add the other columns
            dt.Columns.Add(mal_alisi_details_id, typeof(System.String));
            dt.Columns.Add(barkod, typeof(System.String));
            dt.Columns.Add(mehsul_adi, typeof(System.String));
            dt.Columns.Add(satis_qiymeti, typeof(System.String));
            dt.Columns.Add(say, typeof(System.String));
            DataView dv = dt.DefaultView;
            dv.Sort = "CategoryID DESC";

            //gridControl1.DataSource = dt.DefaultView;
            //gridControl1.DataSource = dv;

            //gridView1.Columns[0].Visible = true;

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }
        //public string ConString = "Data Source=.;Initial Catalog=NewInteko;Integrated Security=True";


        public void get_cem(string emeliyyat_n)
        {

            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);


                SqlConnection conn = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                conn.ConnectionString = Properties.Settings.Default.SqlCon;
                conn.Open();
                string query = " 	select sum(s) as cem " +
                    "from (	select satis_qiymeti*count(*) s " +
                    "from calculation  where  emeliyyat_nomre=@pricePoint 	group by satis_qiymeti	)t";// position column from position table
                cmd.Parameters.AddWithValue("@pricePoint", emeliyyat_n);
                cmd.Connection = conn;
                cmd.CommandText = query;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["cem"].ToString() == "0.000")
                    {
                        
                    }

                  else
                    {
                        textEdit2.Text = dr["cem"].ToString();
                    }



                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Xəta!\n" + e);
            }


        }

        public void get_emeliyyat_nomre()
        {
         
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);


                SqlConnection conn = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                conn.ConnectionString = Properties.Settings.Default.SqlCon;
                conn.Open();
                string query = "select 'P' +" +
                    "SUBSTRING(emeliyyat_nomre,1,2) +" +
                    " cast((cast(SUBSTRING(emeliyyat_nomre,3,len(emeliyyat_nomre))as int) +1) " +
                    "as nvarchar(20))  col1 from calculation WHERE tr=0";// position column from position table

                cmd.Connection = conn;
                cmd.CommandText = query;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    
                        textEdit11.Text = dr["col1"].ToString();
                  


                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Xəta!\n" + e);
            }


        }

        public void get(string paramValue)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);

                // Provide the query string with a parameter placeholder.
                //string queryString = "select mal_alisi_details_id,barkod,mehsul_adi,satis_qiymeti,count(*) as say" +
                //    ",satis_qiymeti*count(*) as mebleg " +
                //    "from (select  TOP 100 PERCENT * from calculation order by id desc) " +
                //    "  t  where  emeliyyat_nomre=@pricePoint group by mal_alisi_details_id,barkod,mehsul_adi,satis_qiymeti ";
               
                string queryString = "select m.mal_alisi_details_id,v.VAHIDLER_ID,vd.EDV_ID ,m.barkod,m.mehsul_adi,satis_qiymeti,count(*) as say" +
                   " , satis_qiymeti*count(*) as mebleg "+
                    "from(select  TOP 100 PERCENT * from calculation order by id desc) " +
                    "t left join MAL_ALISI_DETAILS m on t.mal_alisi_details_id = m.MAL_ALISI_DETAILS_ID "+
                    " left join VAHIDLER v on m.VAHID = v.VAHIDLER_ID " +
                    " left join VERGI_DERECESI vd on vd.EDV_ID = m.VERGI_DERECESI " +
                    " where emeliyyat_nomre = @pricePoint group by " +
                    " m.mal_alisi_details_id,m.BARKOD,m.MEHSUL_ADI,satis_qiymeti, " +
                    " v.VAHIDLER_ID,v.VAHIDLER_NAME ,vd.EDV_ID ";


                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@pricePoint", paramValue);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt1 = new DataTable();
                da.Fill(dt1);
                gridControl1.DataSource = dt1;

               
                //gridView1.Columns[0].Visible = false;
                //gridView1.Columns[6].Visible = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Xəta!\n" + e);
            }

        }
        public void getall(int A, string bark)
        {
            int paramValue = A;
            
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);


                SqlConnection conn = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                conn.ConnectionString = Properties.Settings.Default.SqlCon;
                conn.Open();
                string query = "SELECT * FROM  dbo.POS_SATIS(1,@pricePoint);";// position column from position table
                cmd.Parameters.AddWithValue("@pricePoint", bark);
                cmd.Connection = conn;
                cmd.CommandText = query;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                  
                    //DataRow row = dt.NewRow();
                    //row[mal_alisi_details_id] = dr["mal_details_id"].ToString();
                    //row[barkod] = dr["BARKOD"].ToString();
                    //row[mehsul_adi] = dr["MƏHSUL ADI"].ToString();
                    //row[satis_qiymeti] = dr["SATIŞ QİYMƏTİ"].ToString();
                    //row[say] = "1";
                    //dt.Rows.Add(row);

                    //if (string.IsNullOrEmpty(textEdit5.Text.ToString()))
                    //{
                    //    textEdit5.Text = dr["MƏHSUL ADI"].ToString();
                    //}
                    if (string.IsNullOrEmpty(textEdit1.Text.ToString()))
                    {
                        textEdit1.Text= dr["BARKOD"].ToString();

                    }                 ///grid load                              
                    textEdit5.Text = dr["MƏHSUL ADI"].ToString();

                  //  MessageBox.Show(dr["say"].ToString());
                    for (int i = 0; i < Convert.ToInt32(dr["say"]); i++)
                    {
                        st.insert_calculation_data(textEdit11.Text.ToString(), Convert.ToInt32(dr["mal_details_id"].ToString()), dr["BARKOD"].ToString(), dr["MƏHSUL ADI"].ToString(), Convert.ToDecimal(dr["SATIŞ QİYMƏTİ"].ToString()));

                    }



                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Xəta!\n" + e);
            }

        }
        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
          
           
           
        }

        private void textEdit5_TextChanged(object sender, EventArgs e)
        {
            //MEHSUL ADI

            //getall(1);
            //if (string.IsNullOrEmpty(textEdit1.Text.ToString()){

            //}
        }

        public void get_say_birmal(string barkod)
        {

            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);


                SqlConnection conn = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                conn.ConnectionString = Properties.Settings.Default.SqlCon;
                conn.Open();
                string query = "exec CALC_SAY_CALCULATION @barkod=@pricepoint";// position column from position table
                cmd.Parameters.AddWithValue("@pricepoint", barkod);
                cmd.Connection = conn;
                cmd.CommandText = query;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    textEdit6.Text = dr["SAY"].ToString();



                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Xəta!\n" + e);
            }


        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {

           

            if (e.KeyChar == (char)13)
            {
                //MessageBox.Show("ENTER has been pressed!");
                getall(1,textEdit1.Text.ToString());
                get(textEdit11.Text.ToString());
                get_say_birmal(textEdit1.Text.ToString());
                textEdit1.Text = string.Empty;
                get_cem(textEdit11.Text.ToString());
                //textEdit5.Text = string.Empty;
            }
                
       
            else if (e.KeyChar == (char)27)
            {
                this.Close();
            }


         

        }

        private void textEdit5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                getall(1,textEdit1.Text.ToString());
                get(textEdit11.Text.ToString());

            }
                //MessageBox.Show("ENTER has been pressed!");
              
          
            else if (e.KeyChar == (char)27)
            {
                this.Close();
            }
               

           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            POS_MEHSUL_AXTARIS PMA = new POS_MEHSUL_AXTARIS();
            PMA.Show();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit2.Text))
            {

            }
            else
            {
                decimal f = Convert.ToDecimal(textEdit2.Text);

                kart k = new kart(f,this);
                k.Show();
            }


         
        }

        private void simpleButton34_Click(object sender, EventArgs e)
        {

        }

        private  void simpleButton9_Click(object sender, EventArgs e)
        {
            //pos ac

            // record Person(string Name, string Occupation);

            var url = "http://192.168.137.217:5544";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Accept = "application/json";
            httpRequest.ContentType = "application/json";

            var data = @"{
                   ""operation"": ""openShift"",
                   ""cashierName"": ""Yeni Kassir"",
                   ""username"":""admin"",
                   ""password"": ""admin""
                          }";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                //MessageBox.Show(result.ToString());

                WeatherForecast weatherForecast =
                 System.Text.Json.JsonSerializer.Deserialize<WeatherForecast>(result);

                //MessageBox.Show($"{weatherForecast.message}");
               
                if ($"{weatherForecast.message}" == "Success operation")
                {
                    XtraMessageBox.Show("UĞURLA AÇILDI");
                }
                else
                {
                    XtraMessageBox.Show(weatherForecast.message);
                }
            }
         
            //MessageBox.Show(httpResponse.StatusCode.ToString());


        }

        public class WeatherForecast
        {
            public string  code { get; set; }
            public string message { get; set; }
            public string documentid { get; set; }
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            //pos bagla


            var url = "http://192.168.137.217:5544";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Accept = "application/json";
            httpRequest.ContentType = "application/json";

            var data = @"{
                   ""operation"": ""closeShift"",
                   ""cashierName"": ""Yeni Kassir"",
                   ""username"":""admin"",
                   ""password"": ""admin""
                          }";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                WeatherForecast weatherForecast =
                System.Text.Json.JsonSerializer.Deserialize<WeatherForecast>(result);

                if ($"{weatherForecast.message}"== "Success operation")
                {
                    XtraMessageBox.Show("GÜNLÜK Z HESABATI UĞURLA ÇIXARILDI");
                }
                
            }

           


        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            // X HESABAT

            var url = "http://192.168.137.217:5544";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Accept = "application/json";
            httpRequest.ContentType = "application/json";

            var data = @"{
                   ""operation"": ""getXReport"",
                   ""cashierName"": ""Yeni Kassir"",
                   ""username"":""admin"",
                   ""password"": ""admin""
                          }";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                WeatherForecast weatherForecast =
                System.Text.Json.JsonSerializer.Deserialize<WeatherForecast>(result);

                if ($"{weatherForecast.message}" == "Success operation")
                {
                    XtraMessageBox.Show("GÜNLÜK X HESABATI UĞURLA ÇIXARILDI");
                }

            }

        }
        satis_json st = new satis_json();

        public void gelen_data_negd_pos(decimal cash_,decimal card_)
        {
            st.update_calculation_tr();


            st.delete_item();

            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                //Convert.ToInt32(row["VAHIDLER_ID"])
                //Convert.ToInt32(row["EDV_ID"])
                DataRow row = gridView1.GetDataRow(i);
                //MessageBox.Show(row["say"].ToString());
                st.insert_item(row["mehsul_adi"].ToString(), "Code2", Convert.ToDecimal(row["say"]), Convert.ToDecimal(row["satis_qiymeti"]), 1, Convert.ToInt32(row["EDV_ID"]), Convert.ToInt32(row["VAHIDLER_ID"]),Convert.ToInt32(row["mal_alisi_details_id"]));
            }
       
            st.delete_hed();

            st.insert_head(cash_, card_, 0, "YENI MUSTERI");
            var url = "http://192.168.137.217:5544";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Accept = "application/json";
            httpRequest.ContentType = "application/json";         

            var data = st.returnjson();
          
            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (
                var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();          

                WeatherForecast weatherForecast =
                System.Text.Json.JsonSerializer.Deserialize<WeatherForecast>(result);
                st.insert_chec_pos_main(result);
                if ($"{weatherForecast.message}" == "Success operation")
                {
                    XtraMessageBox.Show("SATIŞ UĞURLA GETDİ");

                    string a = $"{weatherForecast.documentid}";
                    textEdit3.Text = a;
                }

            }
            

        }

        private void simpleButton32_Click(object sender, EventArgs e)
        {
            //SATIS


            //gelen_data_negd_pos();



        
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            //GAYTARMA 
            POS_GAYTARMA PSG = new POS_GAYTARMA();
            PSG.Show();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit2.Text))
            {

            }
            else
            {
                decimal f = Convert.ToDecimal(textEdit2.Text);

                bank n = new bank(f,this);

                n.Show();
            }
          
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit2.Text))
            {

            }
            else
            {
                decimal f = Convert.ToDecimal(textEdit2.Text);

                nagd_kart nk = new nagd_kart(f,this);
                nk.Show();
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            //umumi sil

            if (string.IsNullOrEmpty(textEdit11.Text))
            {

            }
            else
            {
                st.del_temp_all_data(textEdit11.Text);
             //   getall(1, textEdit1.Text.ToString());
                get(textEdit11.Text.ToString());
                //get_say_birmal("");
                textEdit6.Text = "0";
                textEdit5.Text = "";
                textEdit1.Text = string.Empty;
                get_cem(textEdit11.Text.ToString());
            }

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //grid update 
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
               
             int   paramValue = Convert.ToInt32(dr[0]);

                //textEdit6.Text = gridView1.GetDataRow(e.FocusedRowHandle)["satis_qiymeti"].ToString();
                textEdit6.Text = gridView1.GetDataRow(e.FocusedRowHandle)["say"].ToString();

                //XtraMessageBox.Show(paramValue.ToString());
                string queryString =
                    "exec CALC_SAY_CALCULATION @MAL_ALISI_DETAILS_ID=@pricePoint ";

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@pricePoint", paramValue);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            //            
                            //labelControl5.Text = reader[0].ToString();
                            //textEdit1.Text = reader[1].ToString();
                            //textEdit2.Text = reader[2].ToString();
                            //textEdit4.Text = reader[3].ToString();
                            textEdit6.Text = reader[0].ToString();

                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex.Message);
                    }

                }
                //MessageBox.Show(paramValue.ToString());
            }

        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void POS_FormClosing(object sender, FormClosingEventArgs e)
        {
            //form closing
            //DialogResult dialogResult = MessageBox.Show("SATIŞ BÖLÜMÜNÜ BAĞLAMAĞA ƏMİNSİNİZMİ?", "XƏBƏRDALIQ", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
            //    //do something
            //    this.Close();

            //}
            //else if (dialogResult == DialogResult.No)
            //{
            //    //do something else

            //}
            //st.del_tr();
        }

        private void POS_FormClosed(object sender, FormClosedEventArgs e)
        {
            //form closing

            //DialogResult dialogResult = MessageBox.Show("SATIŞ BÖLÜMÜNÜ BAĞLAMAĞA ƏMİNSİNİZMİ?", "XƏBƏRDALIQ", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
            //    //do something
            //    this.Close();

            //}
            //else if (dialogResult == DialogResult.No)
            //{
            //    //do something else



            //}
            //st.del_tr();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //ENDIRIM
        }
    }
}