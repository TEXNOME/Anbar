using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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



namespace WindowsFormsApp2
    {
    public partial class GAIME_SATISI_LAYOUT : DevExpress.XtraEditors.XtraForm
    {
        public static string radio = "";
        public static string mal_alisi_details_id = "0";
        AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
        private const String CATEGORIES_TABLE = "Categories";
        // field name constants
        private const String CATEGORYID_FIELD = "CategoryID";
        private const string TARİX = "TARIX";
        private const string bank_nagd = "ÖDƏMƏ TİPİ";
        private const string GAIME_NOM = "QAİMƏ №";
        private const string ODENILEN_MEBLEG = "ÖDƏNİLƏN MƏBLƏĞ";
        private const string EMELIYYAT_NOMRESI = "EMELIYYAT NOMRESI";
        private const string techicatci_adi = "TƏCHİZATÇI ADI";
        private const String MEHSUL_ADI = "MƏHSUL ADI";
        private const String MEHSUL_KODU = "MƏHSUL KODU";
        private const string musteri_adi = "MÜŞTƏRİ ADI";
        private const string ANBAR = "ANBAR";
        private const string GEYD = "GEYD";

        private const string VERGI_DERECESI = "VEGRI DƏRƏCƏSİ";
        private const string MIGDAR = "MIGDAR";
        private const string VAHID = "VAHID";

        private const string SATIS_GIYMETI = "SATIŞ QİYMƏTİ";
        private const string ENDIRIM_FAIZ = "ENDIRIM FAIZ";
        private const string ENDIRIM_AZN = "ENDIRIM_AZN";
        private const string ENDIRIM_MEBLEGI = "ENDIRIM MƏBLƏĞİ";
        private const string YEKUN_MEBLEG = "YEKUN MƏBLƏĞ";

        private DataTable dt;
        private SqlDataAdapter da;

        SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);

        public GAIME_SATISI_LAYOUT()
        {
            InitializeComponent();
        }

        public void MUSTERI(string ID, string MUSTERI_AD)
        {
            labelControl9.Text = ID;
            textEdit3.Text = MUSTERI_AD;
        }
        private string qeryString = "EXEC   dbo.GAIME_SATISI_EMELIYYAT_NOMRE";


        public void GETKOD()
        {

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon))
            {

                SqlCommand command = new SqlCommand(qeryString, connection);


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        //XtraMessageBox.Show(reader[0].ToString());

                        textEdit5.Text = reader[0].ToString();


                    }
                    reader.Close();


                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                    XtraMessageBox.Show(ex.Message);
                }
            }

        }
        private void GAIME_SATISI_LAYOUT_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            DateTime dateTime = DateTime.UtcNow.Date;
            dateEdit1.Text = dateTime.ToString();
            gridControl1.TabStop = false;
            textEdit5.Enabled = false;
            GETKOD();

            lookUpEdit8GEtData_yeni();
            //ANBAR_LOAD();
            searchlookupedit();
            dt = new DataTable(CATEGORIES_TABLE);


        }


        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            radio = radioButton1.Text.ToString();
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            radio = radioButton3.Text.ToString();
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        public void searchlookupedit()
        {

            DataTable dt = null;

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon))

            {
                con.Open();
                string strCmd = "SELECT * FROM GAIME_SATIS_SEARCH()";
                using (SqlCommand cmd = new SqlCommand(strCmd, con))
                {

                    SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
                    dt = new DataTable("TName");
                    da.Fill(dt);

                }
            }
            searchLookUpEdit1.Properties.DisplayMember = "TƏCHİZATÇI";
            searchLookUpEdit1.Properties.ValueMember = "TECHIZATCI_ID";
            searchLookUpEdit1.Properties.DataSource = dt;
            searchLookUpEdit1.Properties.NullText = "--Seçin--";


        }
        public static string mehsul_kod;


        private void searchLookUpEdit1_TextChanged_1(object sender, EventArgs e)
        {

            string marketId = this.searchLookUpEdit1.Properties.View.GetFocusedRowCellValue("MƏHSUL ADI").ToString();
            string mehsukod = this.searchLookUpEdit1.Properties.View.GetFocusedRowCellValue("MƏHSUL KODU").ToString();
            mal_alisi_details_id = this.searchLookUpEdit1.Properties.View.GetFocusedRowCellValue("MAL_ALISI_DETAILS_ID").ToString();
            textEdit9.Text = marketId; //mehsul adi
            mehsul_kod = mehsukod;
            lookUpEdit8GEtData_yeni(Convert.ToInt32(mal_alisi_details_id));

        }




        private void lookUpEdit8GEtData_yeni(int id)
        {
            //int id = Convert.ToInt32(lookUpEdit7.EditValue.ToString());

            if (id > 0)
            {


                string strQuery = "select * from  [dbo].[GAIME_SATIS_magaza_load] (@IDD)";
                //string strQuery = "select GRUPLAR_ID No,GRUP as N'Qrup' " +
                //   " From GRUPLAR  where IXTISAS_ID=@IDD";

                SqlCommand cmd = new SqlCommand(strQuery);

                cmd.Parameters.AddWithValue("@IDD", id);

                DataTable dt = GetData(cmd);




                lookUpEdit1.Properties.DisplayMember = "MAĞAZA";
                lookUpEdit1.Properties.ValueMember = "STOREID";
                lookUpEdit1.Properties.DataSource = dt;
                lookUpEdit1.Properties.NullText = "--Seçin--";
                lookUpEdit1.Properties.PopulateColumns();
                lookUpEdit1.Properties.Columns[0].Visible = false;
                //lookUpEdit1.Properties.Columns[2].Visible = false;

            }


        }


        //public string ConString = "Data Source=.;Initial Catalog=NewInteko;Integrated Security=True";




        private DataTable GetData(SqlCommand cmd)

        {

            DataTable dt = new DataTable();


            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);

            SqlDataAdapter sda = new SqlDataAdapter();

            cmd.CommandType = CommandType.Text;

            cmd.Connection = con;

            try

            {

                con.Open();

                sda.SelectCommand = cmd;

                sda.Fill(dt);

                return dt;

            }

            catch (Exception ex)

            {



                return null;

            }

            finally

            {

                con.Close();

                sda.Dispose();

                con.Dispose();

            }

        }
        private void searchLookUpEdit1_QueryProcessKey(object sender, DevExpress.XtraEditors.Controls.QueryProcessKeyEventArgs e)
        {

        }

        private void searchLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {


            searchLookUpEdit1.Properties.View.Columns["TECHIZATCI_ID"].Visible = false;
            searchLookUpEdit1.Properties.View.Columns["MAL_ALISI_DETAILS_ID"].Visible = false;

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        public void getmebleg(string paramValue, string paramValue1, string paramValue2, string paramValue3)
        {
            //YEKUN_MEBLEG 

            string queryString = " exec yekun_mebleg_calc @migdar =@pricePoint,@alis_giymet =@pricePoint1,@endirim_faiz =@pricePoint2,@endirim_azn =@pricePoint3";
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand();
            SqlCommand command = new SqlCommand(queryString, connection);

            command.Parameters.AddWithValue("@pricePoint", paramValue);
            command.Parameters.AddWithValue("@pricePoint1", paramValue1);
            command.Parameters.AddWithValue("@pricePoint2", paramValue2);
            command.Parameters.AddWithValue("@pricePoint3", paramValue3);
            connection.Open();
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {

                textEdit10.Text = dr["endirim_meblegi"].ToString();
                textEdit4.Text = dr["yekun_mebleg"].ToString();
            }
            connection.Close();
        }

        private void textEdit7_TextChanged_1(object sender, EventArgs e)
        {
            textEdit13.Text = "0.00";
            getmebleg(textEdit8.Text, textEdit6.Text, textEdit7.Text, textEdit13.Text);
        }

        private void textEdit13_TextChanged_1(object sender, EventArgs e)
        {
            textEdit7.Text = "0.00";
            getmebleg(textEdit8.Text, textEdit6.Text, textEdit7.Text, textEdit13.Text);
        }

        private void textEdit8_TextChanged_1(object sender, EventArgs e)
        {
            getmebleg(textEdit8.Text, textEdit6.Text, textEdit7.Text, textEdit13.Text);
        }

        private void textEdit6_TextChanged_1(object sender, EventArgs e)
        {
            getmebleg(textEdit8.Text, textEdit6.Text, textEdit7.Text, textEdit13.Text);
        }
        CRUD_GAIME_SATISI cgs = new CRUD_GAIME_SATISI();
        int b;





        private void gridView1_FocusedRowChanged_2(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {


                int paramValue = Convert.ToInt32(dr[0]);
                


                //XtraMessageBox.Show(paramValue.ToString());
                string queryString =
                   " select  D.GAIME_SATISI_DETAILS_ID, CT.SIRKET_ADI,m.MUSTERI,MD.MEHSUL_ADI,MD.MEHSUL_KODU,d.MIGDARI" +
                   ",d.SATIS_GIYMETI, " +
                   " CAST(replace(D.MIGDARI,',','.') " +
                   "AS DECIMAL(9,2))*CAST(replace(D.SATIS_GIYMETI,',','.') AS DECIMAL(9,2)) " +
                   " AS YEKUN_MEBLEG,d.ENDIRIM_AZN,d.ENDIRIM_FAIZ,d.ENDIRIM_MEBLEGI,d.GEYD,cs.STORE_NAME " + " from GAIME_SATISI_MAIN m inner join GAIME_SATISI_DETAILS d " +
                   " on m.GAIME_SATISI_MAIN_ID = d.GAIME_SATISI_MAIN_ID " + " inner JOIN MAL_ALISI_DETAILS MD ON MD.MAL_ALISI_DETAILS_ID=D.MAL_DETAILS_ID " +
                   " INNER JOIN MAL_ALISI_MAIN MM ON MM.MAL_ALISI_MAIN_ID=MD.MAL_ALISI_MAIN_ID " + 
                   " INNER JOIN COMPANY.TECHIZATCI CT ON CT.TECHIZATCI_ID=MM.TECHIZATCI_ID " +
                   " inner join COMPANY.STORE cs on cs.STOREID=d.MAGAZA " +
                " WHERE D.GAIME_SATISI_DETAILS_ID=@pricepoint " ;


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
                            label1.Text = dr[0].ToString();
                            textEdit3.Text = reader[2].ToString();
                            textEdit9.Text = reader[3].ToString();
                            mehsul_kod = reader[4].ToString();
                            textEdit8.Text = reader[5].ToString();
                            textEdit6.Text = reader[6].ToString();
                            textEdit4.Text = reader[7].ToString();
                            textEdit13.Text = reader[8].ToString();
                            textEdit7.Text = reader[9].ToString();
                            textEdit10.Text = reader[10].ToString();
                            memoEdit1.Text = reader[11].ToString();
                            lookUpEdit1.Text = reader[12].ToString();
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex.Message);
                    }
                }
            }

        }





        private void searchLookUpEdit1_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {

        }

        private void lookUpEdit8GEtData_yeni()
        {
            //int id = Convert.ToInt32(lookUpEdit7.EditValue.ToString());



            string strQuery = "select WAREHOUSE_ID,WAREHOUSE_NAME as 'Anbar' from COMPANY.WAREHOUSE";
            //string strQuery = "select GRUPLAR_ID No,GRUP as N'Qrup' " +
            //   " From GRUPLAR  where IXTISAS_ID=@IDD";

            SqlCommand cmd = new SqlCommand(strQuery);

            //cmd.Parameters.AddWithValue("@IDD", a);

            DataTable dt = GetData(cmd);




            //lookUpEdit7.Properties.DisplayMember = "Anbar";
            //lookUpEdit7.Properties.ValueMember = "WAREHOUSE_ID";
            //lookUpEdit7.Properties.DataSource = dt;
            //lookUpEdit7.Properties.NullText = "--Seçin--";
            //lookUpEdit7.Properties.PopulateColumns();
            //lookUpEdit7.Properties.Columns[0].Visible = false;



        }



        private void magazaLoad(string a)
        {
            //int id = Convert.ToInt32(lookUpEdit7.EditValue.ToString());




            string strQuery = "SELECT distinct( STOREID), OBYEKT FROM[dbo].[fn_MAGAZA_ANBAR_LOAD]('') where ANBAR = @IDD";
            //string strQuery = "select GRUPLAR_ID No,GRUP as N'Qrup' " +
            //   " From GRUPLAR  where IXTISAS_ID=@IDD";

            SqlCommand cmd = new SqlCommand(strQuery);

            cmd.Parameters.AddWithValue("@IDD", a);

            DataTable dt = GetData(cmd);




            lookUpEdit1.Properties.DisplayMember = "OBYEKT";
            lookUpEdit1.Properties.ValueMember = "STOREID";
            lookUpEdit1.Properties.DataSource = dt;
            lookUpEdit1.Properties.NullText = "--Seçin--";
            lookUpEdit1.Properties.PopulateColumns();
            lookUpEdit1.Properties.Columns[0].Visible = false;



        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            clear();
        }

        private void gridclear() 
        {
            gridControl1.DataSource = null;
        }
        private void clear()
        {
            textEdit5.Text = "";
            textEdit9.Text = "";
            textEdit8.Text = "";
            textEdit6.Text = "";
            textEdit7.Text = "";
            textEdit13.Text = "";
            textEdit10.Text = "";
            textEdit17.Text = "";
            textEdit1.Text = "";
            memoEdit1.Text = "";

        }



        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {

            gridView1.ShowPrintPreview();

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            MUSTERI_AXTAR M = new MUSTERI_AXTAR(this);
            M.Show();
        }






        private void simpleButton2_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            gridView1.MoveFirst();


            ///
            try
            {
                int ret = cgs.GAIME_SATISI_MAIN(
             textEdit5.Text.ToString(), textEdit17.Text.ToString(),
             Convert.ToDecimal(textEdit1.Text), Convert.ToDateTime(dateEdit1.Text), radio.Trim(), textEdit3.Text.ToString());

                if (ret > 0)
                {

                    int xx = cgs.GAIME_SATISI_DETAILS(ret,
                        Convert.ToDateTime(dateEdit1.Text),
                        textEdit5.Text.ToString(),
                        radio,
                        textEdit17.Text.ToString()
                        , Convert.ToDecimal(textEdit1.Text), Convert.ToInt32(mal_alisi_details_id), Convert.ToInt32(lookUpEdit1.EditValue.ToString())
                        , 0, textEdit8.Text.ToString(), textEdit6.Text.ToString(), textEdit7.Text.ToString(), textEdit13.Text.ToString(), textEdit10.Text.ToString(),
                        textEdit4.Text.ToString(), memoEdit1.Text.ToString()

                         );

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
            GetallData(textEdit5.Text.ToString());

            gridView1.MoveFirst();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int value = cgs.GAIME_SATISI_udapte_(
               Convert.ToInt32(label1.Text.ToString()),
               textEdit17.Text.ToString(),
               Convert.ToDecimal(textEdit1.Text.ToString()),
               Convert.ToInt32(mal_alisi_details_id)
               , Convert.ToInt32(lookUpEdit1.EditValue.ToString()),
               textEdit8.Text.ToString(),
               textEdit6.Text.ToString(),
               textEdit7.Text.ToString(),
               textEdit13.Text.ToString(),
               textEdit10.Text.ToString(),
               textEdit4.Text.ToString(),
               memoEdit1.Text.ToString());

                if (value == 1)
                {
                    MessageBox.Show("Əməliyyat uğurla yerinə yetirildi");
                }
                else
                {
                    MessageBox.Show("Uğursuz əməliyyat :(", "XƏTA");
                }
                GetallData(textEdit5.Text.ToString());
                //clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Uğursuz əməliyyat :(","XƏTA");

            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            //SILME

            //if (Convert.ToInt32(label1.Text.ToString()) == 1)
            //{

            //}
            //else
            //{
            //    int num = dt.Rows.Count;
            //    if (num > 1)
            //    {


            //        if (Convert.ToInt32(label1.Text.ToString()) > 1)
            //        {


            //            DataRow[] row1 = dt.Select("CategoryID =" + Convert.ToInt32(label1.Text.ToString()));

            //            foreach (var rows in row1)
            //            {
            //                rows.Delete();
            //                dt.AcceptChanges();
            //            }


            //        }
            //        else
            //        {
            //            XtraMessageBox.Show("SİLMƏK ÜÇÜN MÜVAFİQ XANA SEÇİLMƏYİB");
            //        }

            //    }
            //    else
            //    {
            //        dt.Clear();
            //    dt.AcceptChanges();
            //}
            //}
            //label1.Text = "1";



            foreach (int i in gridView1.GetSelectedRows())
            {
                DataRow row = gridView1.GetDataRow(i);

                int B = Convert.ToInt32(row[0].ToString());
                if (B > 0)
                {
                    int x = cgs.GAIME_SATISI_DELETE(B);
                }


            }
            GetallData(textEdit5.Text.ToString());
            clear();

        }

        public void GetallData(string emeliyyat_nomre)
        {

            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);
                string queryString = "SELECT * FROM dbo.fn_GAIME_SATISI_LOAD(@pricepoint) ";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@pricepoint", emeliyyat_nomre);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
                gridView1.Columns[0].Visible = false;
                gridView1.OptionsSelection.MultiSelect = true;
                gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            }
            catch (Exception e)
            {
                Console.WriteLine("Xəta!\n" + e);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {

            gridclear();
            clear();
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            clear();
        }



        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            MUSTERI_AXTAR M = new MUSTERI_AXTAR(this);
            M.Show();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            GAIME_SATIS_DETAILS gs = new GAIME_SATIS_DETAILS();
            gs.Show();
        }

        private void lookUpEdit7_TextChanged_1(object sender, EventArgs e)
        {
            //magazaLoad(lookUpEdit7.Text.ToString());
        }

        private void textEdit10_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            radio = radioButton1.Text.ToString();
        }

        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //update focus row 
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {


                int paramValue = Convert.ToInt32(dr[0]);
                label1.Text = paramValue.ToString();

                //update_mal_details_id = Convert.ToInt32(dr[0]);
                //XtraMessageBox.Show(paramValue.ToString());
                string queryString =
                    " select  md.MEHSUL_ADI,gd.MAL_DETAILS_ID,GAIME_NOM,gd.MIGDARI,gd.SATIS_GIYMETI,gd.ENDIRIM_FAIZ,gd.ENDIRIM_AZN,"+
                     " gd.ENDIRIM_MEBLEGI,gd.YEKUN_MEBLEG,gd.GEYD,cs.STORE_NAME,gm.MUSTERI " +
                   " from GAIME_SATISI_DETAILS gd " +
                  " inner join MAL_ALISI_DETAILS md on md.MAL_ALISI_DETAILS_ID = gd.MAL_DETAILS_ID " +
                    " inner join COMPANY.STORE cs on cs.STOREID = gd.MAGAZA " +
                  " inner join GAIME_SATISI_MAIN gm on gm.GAIME_SATISI_MAIN_ID = gd.GAIME_SATISI_MAIN_ID " +
                  " where gd.GAIME_SATISI_DETAILS_ID = @pricePoint ";

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
                            //textBox1.Text = reader[1].ToString();
                            textEdit9.Text = reader[0].ToString();
                            mal_alisi_details_id = reader[1].ToString();
                            textEdit17.Text = reader[2].ToString();
                            textEdit8.Text = reader[3].ToString();
                            textEdit6.Text = reader[4].ToString();
                            textEdit7.Text = reader[5].ToString();
                            textEdit13.Text = reader[6].ToString();
                            textEdit10.Text = reader[7].ToString();
                            textEdit4.Text = reader[8].ToString();
                            memoEdit1.Text = reader[9].ToString();
                           lookUpEdit1.Text = reader[10].ToString();
                            textEdit3.Text = reader[11].ToString();


                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex.Message);
                    }

                }

            }
        }

   
    }

}

