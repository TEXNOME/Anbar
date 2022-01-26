using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class POS_GAYTARMA : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public POS_GAYTARMA()
        {
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        //public string ConString = "Data Source =.; Initial Catalog = NewInteko; Integrated Security = True";
        //public void getall()
        //{
        //    //string paramValue = A;
        //    try
        //    {
        //        SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);


        //        string queryString = " select *from [dbo].[fn_POS_GAYTARMA] ()";

        //        SqlCommand command = new SqlCommand(queryString, connection);

        //        SqlDataAdapter da = new SqlDataAdapter(command);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        gridControl1.DataSource = dt;
        //        //gridView1.Columns[0].Visible = false;
        //        gridView1.OptionsSelection.MultiSelect = false;
        //        gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Xəta!\n" + e);
        //    }

        //}

        private void POS_GAYTARMA_Load(object sender, EventArgs e)
        {
            //getall();
            gridControl1.TabStop = false;
            radioButton1.Checked = true;
        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (gridView1.OptionsSelection.MultiSelect == true)
            {
                gridView1.OptionsSelection.MultiSelect = false;
            }
          
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (gridView1.OptionsSelection.MultiSelect == false)
            {
                gridView1.OptionsSelection.MultiSelect = true;
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            //pos gaytarma load
            POS_GAYTARMA_BAXIS PGB =new POS_GAYTARMA_BAXIS();
            PGB.Show();
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

                string queryString = " select pd.pos_satis_check_main_id, pd.pos_satis_check_details_id,pm.pos_nomre, " +
                    " pm.fiscal_id,md.MEHSUL_ADI,pd.count_-isnull(pd.gaytarilan_say,0) as say ,isnull(pd.satis_giymet,0.00) as satis_giymet," +
                    "(pd.count_-isnull(pd.gaytarilan_say,0))*isnull(pd.satis_giymet,0.00) as mebleg ,0.00 as gaytarilacaq_migdar" +
                    " from pos_satis_check_main pm inner join pos_satis_check_details pd on " +
                    " pm.pos_satis_check_main_id=pd.pos_satis_check_main_id inner join " +
                    " MAL_ALISI_DETAILS md on md.MAL_ALISI_DETAILS_ID = pd.mal_alisi_details_id "+
                       " where pos_nomre= @pricePoint ";


                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@pricePoint", paramValue);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt1 = new DataTable();
                da.Fill(dt1);
                gridControl1.DataSource = dt1;


                gridView1.OptionsSelection.MultiSelect = true;
                gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
              //  gridView1.Columns[0].Visible = false;
              
            }
            catch (Exception e)
            {
                Console.WriteLine("Xəta!\n" + e);
            }

        }
        private void textEdit6_KeyPress(object sender, KeyPressEventArgs e)
        {
            //axtar

            if (e.KeyChar == (char)13)
            {
                
                //MessageBox.Show("ENTER has been pressed!");
                get(textEdit6.Text.ToString());
                //textEdit5.Text = string.Empty;
                textEdit6.Text = string.Empty;
            }


            else if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }
        satis_json s = new satis_json();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //gaytar

            if (string.IsNullOrEmpty(textEdit1.Text))
            {
                MessageBox.Show("Emeliyyat Nomre bosdur");

            }
            else
            {
                foreach (int i in gridView1.GetSelectedRows())
                {
                    DataRow row = gridView1.GetDataRow(i);
                    //MessageBox.Show(i.ToString());

                    //int a = mg.updateMehsulgaytarma(Convert.ToInt32(row[0]), Convert.ToDecimal(row[8]));
                    //      MessageBox.Show(row[8].ToString());
                    s.insert_pos_gaytarma_manual_proc(textEdit1.Text.ToString(), Convert.ToInt32(row[0]), Convert.ToInt32(row[1]), Convert.ToInt32(row[8]));
                }



                var url = "http://192.168.137.217:5544";

                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Method = "POST";

                httpRequest.Accept = "application/json";
                httpRequest.ContentType = "application/json";

                var data = s.returnjson_gaytarma(textEdit1.Text);

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
                    //st.insert_chec_pos_main(result);
                    if ($"{weatherForecast.message}" == "Success operation")
                    {
                        XtraMessageBox.Show("QAYTARMA UĞURLA GETDİ");

                        //string a = $"{weatherForecast.documentid}";
                        //textEdit3.Text = a;
                    }

                }
            }
         
        }

        public class WeatherForecast
        {
            public string code { get; set; }
            public string message { get; set; }
            public string documentid { get; set; }
        }

    }
}