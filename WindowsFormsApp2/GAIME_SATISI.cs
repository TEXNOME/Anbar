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
    public partial class GAIME_SATISI : DevExpress.XtraBars.Ribbon.RibbonForm
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
        public GAIME_SATISI()
        {
            InitializeComponent();
        }

        public void MUSTERI(string ID,string MUSTERI_AD)
        {
            labelControl9.Text = ID;
            textEdit3.Text = MUSTERI_AD;
        }

        private void GAIME_SATISI_Load(object sender, EventArgs e)
        {
            gridControl1.TabStop = false;

            //gridView1.OptionsSelection.MultiSelect = true;
            //gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            lookUpEdit8GEtData_yeni();
            //ANBAR_LOAD();
            searchlookupedit();
            dt = new DataTable(CATEGORIES_TABLE);

            // add the identity column
            DataColumn col = dt.Columns.Add(CATEGORYID_FIELD, typeof(System.Int32));
            col.AllowDBNull = false;
            col.AutoIncrement = true;
            col.AutoIncrementSeed = 1;
            col.AutoIncrementStep = 1;
            // set the primary key
            dt.PrimaryKey = new DataColumn[] { col };

            // add the other columns
            dt.Columns.Add(TARİX, typeof(System.String));
            dt.Columns.Add(bank_nagd, typeof(System.String));
            dt.Columns.Add(GAIME_NOM, typeof(System.String));
            dt.Columns.Add(ODENILEN_MEBLEG, typeof(System.String));
            dt.Columns.Add(EMELIYYAT_NOMRESI, typeof(System.String));
            dt.Columns.Add(techicatci_adi, typeof(System.String));
            col = dt.Columns.Add(MEHSUL_ADI, typeof(System.String));
            //col.AllowDBNull = false;
            col.MaxLength = 50;
            dt.Columns.Add(MEHSUL_KODU, typeof(System.String));
            dt.Columns.Add(musteri_adi, typeof(System.String));
            dt.Columns.Add(ANBAR, typeof(System.String));
            dt.Columns.Add(GEYD, typeof(System.String));
            dt.Columns.Add(VERGI_DERECESI, typeof(System.String));
            dt.Columns.Add(MIGDAR, typeof(System.String));
            //dt.Columns.Add(VAHID, typeof(System.String));
            dt.Columns.Add(SATIS_GIYMETI, typeof(System.String));
            dt.Columns.Add(ENDIRIM_FAIZ, typeof(System.String));
            dt.Columns.Add(ENDIRIM_AZN, typeof(System.String));
            dt.Columns.Add(ENDIRIM_MEBLEGI, typeof(System.String));
            dt.Columns.Add(YEKUN_MEBLEG, typeof(System.String));

            lookUpEdit3.Visible = false;
            lookUpEdit5.Visible = false;
            labelControl1.Visible = false;
            labelControl16.Visible = false;





            // fill the table with data
            //da.Fill(dt);

            //BOS DATA DAXIL EDILIR

            DataRow row = dt.NewRow();
            row[TARİX] = "";
            row[bank_nagd] = "";
            row[GAIME_NOM] = "";
            row[ODENILEN_MEBLEG] = "";
            row[EMELIYYAT_NOMRESI] = "";
            row[techicatci_adi] = "";
            row[MEHSUL_ADI] = "";
            row[MEHSUL_KODU] = "";
            row[musteri_adi] = "";
            row[ANBAR] = "";
            row[GEYD] = "";
            row[VERGI_DERECESI] = "";
            row[MIGDAR] = "";
            //row[VAHID] = "";
            row[SATIS_GIYMETI] = "";
            row[ENDIRIM_FAIZ] = "";
            row[ENDIRIM_AZN] = "";
            row[ENDIRIM_MEBLEGI] = "";
            row[YEKUN_MEBLEG] = "";
            dt.Rows.Add(row);



            DataView dv1 = dt.DefaultView;
            dv1.Sort = "CategoryID DESC";
            
            gridControl1.DataSource = dv1;

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            //DAXIL ET
            DataRow row = dt.NewRow();
            row[TARİX] = dateEdit1.Text.ToString();
            row[bank_nagd] = radio.ToString();
            row[GAIME_NOM] = textEdit17.Text.ToString();
            row[ODENILEN_MEBLEG] = textEdit5.Text.ToString();
            row[EMELIYYAT_NOMRESI] = textEdit5.Text.ToString();
            row[MEHSUL_ADI] = textEdit9.Text.ToString();
            row[MEHSUL_KODU] = mehsul_kod;
            row[musteri_adi] = lookUpEdit3.Text.ToString();
            row[ANBAR] = lookUpEdit7.Text.ToString();
            row[GEYD] = memoEdit1.Text.ToString();
            row[MIGDAR] = textEdit8.Text.ToString();
            //row[VAHID] = lookUpEdit5.Text.ToString();
            row[SATIS_GIYMETI] = textEdit6.Text.ToString();
            row[ENDIRIM_FAIZ] = textEdit7.Text.ToString();
            row[ENDIRIM_AZN] = textEdit13.Text.ToString();
            row[ENDIRIM_MEBLEGI] = textEdit10.Text.ToString();
            row[YEKUN_MEBLEG] = textEdit4.Text.ToString();
            row[techicatci_adi] = searchLookUpEdit1.Text.ToString();
            //row[POS_EKRANDA_GOSTER] = spinEdit2.Text.ToString();
            dt.Rows.Add(row);
            clear();
        }

        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radio = radioButton1.Text.ToString();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
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
        private void searchLookUpEdit1_TextChanged(object sender, EventArgs e)
        {

            string marketId = this.searchLookUpEdit1.Properties.View.GetFocusedRowCellValue("MƏHSUL ADI").ToString();
            string mehsukod = this.searchLookUpEdit1.Properties.View.GetFocusedRowCellValue("MƏHSUL KODU").ToString();
            mal_alisi_details_id = this.searchLookUpEdit1.Properties.View.GetFocusedRowCellValue("MAL_ALISI_DETAILS_ID").ToString();
            textEdit9.Text = marketId; //mehsul adi
            mehsul_kod = mehsukod;
            lookUpEdit8GEtData_yeni(1, marketId);

        }

        private void lookUpEdit8GEtData_yeni(int id, string a)
        {
            //int id = Convert.ToInt32(lookUpEdit7.EditValue.ToString());

            if (id > 0)
            {


                string strQuery = "SELECT WAREHOUSE_ID,WAREHOUSE_NAME as 'ANBAR'  from dbo.fn_anbardan_anbara_anbaraxtar (@IDD)";
                //string strQuery = "select GRUPLAR_ID No,GRUP as N'Qrup' " +
                //   " From GRUPLAR  where IXTISAS_ID=@IDD";

                SqlCommand cmd = new SqlCommand(strQuery);

                cmd.Parameters.AddWithValue("@IDD", a);

                DataTable dt = GetData(cmd);




                lookUpEdit7.Properties.DisplayMember = "ANBAR";
                lookUpEdit7.Properties.ValueMember = "ANBAR";
                lookUpEdit7.Properties.DataSource = dt;
                lookUpEdit7.Properties.NullText = "--Seçin--";
                lookUpEdit7.Properties.PopulateColumns();
                lookUpEdit7.Properties.Columns[0].Visible = false;
                lookUpEdit7.Properties.Columns[2].Visible = false;

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

        private void textEdit7_TextChanged(object sender, EventArgs e)
        {
            textEdit13.Text = "0.00";
            getmebleg(textEdit8.Text, textEdit6.Text, textEdit7.Text, textEdit13.Text);
        }

        private void textEdit13_TextChanged(object sender, EventArgs e)
        {
            textEdit7.Text = "0.00";
            getmebleg(textEdit8.Text, textEdit6.Text, textEdit7.Text, textEdit13.Text);
        }

        private void textEdit8_TextChanged(object sender, EventArgs e)
        {
            getmebleg(textEdit8.Text, textEdit6.Text, textEdit7.Text, textEdit13.Text);
        }

        private void textEdit6_TextChanged(object sender, EventArgs e)
        {
            getmebleg(textEdit8.Text, textEdit6.Text, textEdit7.Text, textEdit13.Text);
        }
        CRUD_GAIME_SATISI cgs = new CRUD_GAIME_SATISI();
        int b;



        private void simpleButton6_Click(object sender, EventArgs e)
        {





            gridView1.MoveFirst();

            //gridView1.ResetCursor();
            ///database e yolla
            ///
            try
            {
                int ret = cgs.GAIME_SATISI_MAIN(
             textEdit5.Text.ToString(), textEdit17.Text.ToString(),
             Convert.ToDecimal(textEdit1.Text), Convert.ToDateTime(dateEdit1.Text), radio.Trim(),textEdit3.Text.ToString());

                if (ret > 0)
                {
                    MessageBox.Show("ƏMƏLİYYAT UĞURLA TAMAMLANDI");

                    foreach (DataRow row in dt.Rows)
                    {
                        if (string.IsNullOrEmpty(row["TARIX"].ToString()))
                        {

                        }
                        else
                        {
                            //cgs.GAIME_SATISI_DETAILS(ret, Convert.ToDateTime(row["TARIX"]), row["EMELIYYAT NOMRESI"].ToString(), row["ÖDƏMƏ TİPİ"].ToString(), row["QAİMƏ №"].ToString(),
                            //                        Convert.ToDecimal(row["ÖDƏNİLƏN MƏBLƏĞ"]), Convert.ToInt32(mal_alisi_details_id),Convert.ToInt32(lookUpEdit1.EditValue.ToString()) , row["ANBAR"].ToString(), row["MIGDAR"].ToString(),
                            //                        row["SATIŞ QİYMƏTİ"].ToString(), row["ENDIRIM FAIZ"].ToString(), row["ENDIRIM_AZN"].ToString(), row["ENDIRIM MƏBLƏĞİ"].ToString(), row["YEKUN MƏBLƏĞ"].ToString(), row["GEYD"].ToString());

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
            dt.Clear();
            gridControl1.DataSource = null;

            gridView1.MoveFirst();


            /// empty row
            DataRow row2 = dt.NewRow();
            row2[TARİX] = "";
            row2[bank_nagd] = "";
            row2[GAIME_NOM] = "";
            row2[ODENILEN_MEBLEG] = "";
            row2[EMELIYYAT_NOMRESI] = "";
            row2[techicatci_adi] = "";
            row2[MEHSUL_ADI] = "";
            row2[MEHSUL_KODU] = "";
            row2[musteri_adi] = "";
            row2[ANBAR] = "";
            row2[GEYD] = "";
            row2[VERGI_DERECESI] = "";
            row2[MIGDAR] = "";
            //r2ow[VAHID] = "";
            row2[SATIS_GIYMETI] = "";
            row2[ENDIRIM_FAIZ] = "";
            row2[ENDIRIM_AZN] = "";
            row2[ENDIRIM_MEBLEGI] = "";
            row2[YEKUN_MEBLEG] = "";
            dt.Rows.Add(row2);



            DataView dv1 = dt.DefaultView;
            dv1.Sort = "CategoryID DESC";

            gridControl1.DataSource = dv1;

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //

            try
            {
                int num = dt.Rows.Count;
                if (num > 1)
                {
                    label1.Text = gridView1.GetDataRow(e.FocusedRowHandle)["CategoryID"].ToString();
                    dateEdit1.Text = gridView1.GetDataRow(e.FocusedRowHandle)["TARIX"].ToString();

                    textEdit17.Text = gridView1.GetDataRow(e.FocusedRowHandle)["QAİMƏ №"].ToString();
                    textEdit1.Text = gridView1.GetDataRow(e.FocusedRowHandle)["ÖDƏNİLƏN MƏBLƏĞ"].ToString();
                    textEdit5.Text = gridView1.GetDataRow(e.FocusedRowHandle)["EMELIYYAT NOMRESI"].ToString();
                    textEdit9.Text = gridView1.GetDataRow(e.FocusedRowHandle)["MƏHSUL ADI"].ToString();
                    //searchLookUpEdit1.CustomDisplayText = gridView1.GetDataRow(e.FocusedRowHandle)["TƏCHİZATÇI ADI"].ToString();
                    //searchLookUpEdit1.Properties.ValueMember = gridView1.GetDataRow(e.FocusedRowHandle)["TƏCHİZATÇI ADI"].ToString(); 
                    //searchLookUpEdit1.EditValue = gridView1.GetDataRow(e.FocusedRowHandle)["TƏCHİZATÇI ADI"].ToString(); 
                    lookUpEdit7.Text = gridView1.GetDataRow(e.FocusedRowHandle)["ANBAR"].ToString();
                    memoEdit1.Text = gridView1.GetDataRow(e.FocusedRowHandle)["GEYD"].ToString();
                    textEdit8.Text = gridView1.GetDataRow(e.FocusedRowHandle)["MIGDAR"].ToString();
                    textEdit6.Text = gridView1.GetDataRow(e.FocusedRowHandle)["SATIŞ QİYMƏTİ"].ToString();
                    textEdit7.Text = gridView1.GetDataRow(e.FocusedRowHandle)["ENDIRIM FAIZ"].ToString();
                    textEdit13.Text = gridView1.GetDataRow(e.FocusedRowHandle)["ENDIRIM_AZN"].ToString();

                    string caseSwitch = gridView1.GetDataRow(e.FocusedRowHandle)["ÖDƏMƏ TİPİ"].ToString();

                    switch (caseSwitch)
                    {

                        case "BANK":
                            radioButton1.Checked = true;
                            break;
                        case "NİSYƏ":
                            radioButton3.Checked = true;
                            break;
                        default:
                            radioButton1.Checked = true;
                            break;
                    }
                }
            }
            catch (Exception esx)
            {

                MessageBox.Show(esx.Message.ToString());
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //silme 


            if (Convert.ToInt32(label1.Text.ToString()) == 1)
            {

            }
            else
            {
                int num = dt.Rows.Count;
                if (num > 1)
                {


                    if (Convert.ToInt32(label1.Text.ToString()) > 1)
                    {


                        DataRow[] row1 = dt.Select("CategoryID =" + Convert.ToInt32(label1.Text.ToString()));

                        foreach (var rows in row1)
                        {
                            rows.Delete();
                            dt.AcceptChanges();
                        }


                    }
                    else
                    {
                        XtraMessageBox.Show("SİLMƏK ÜÇÜN MÜVAFİQ XANA SEÇİLMƏYİB");
                    }

                }
                else
                {
                    dt.Clear();
                    dt.AcceptChanges();
                }
            }
            label1.Text = "1";
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            //update 
            var rowsToUpdate =
                  dt.AsEnumerable().Where(r => r.Field<int>("CategoryID") == Convert.ToInt32(label1.Text.ToString()));

            foreach (var row in rowsToUpdate)
            {
                //label1.Text = gridView1.GetDataRow(e.FocusedRowHandle)["CategoryID"].ToString();
                //dateEdit1.Text = gridView1.GetDataRow(e.FocusedRowHandle)["TARIX"].ToString();

                //textEdit17.Text = gridView1.GetDataRow(e.FocusedRowHandle)["QAİMƏ №"].ToString();
                //textEdit1.Text = gridView1.GetDataRow(e.FocusedRowHandle)["ÖDƏNİLƏN MƏBLƏĞ"].ToString();
                //textEdit5.Text = gridView1.GetDataRow(e.FocusedRowHandle)["EMELIYYAT NOMRESI"].ToString();
                //textEdit9.Text = gridView1.GetDataRow(e.FocusedRowHandle)["MƏHSUL ADI"].ToString();
                ////searchLookUpEdit1.CustomDisplayText = gridView1.GetDataRow(e.FocusedRowHandle)["TƏCHİZATÇI ADI"].ToString();
                ////searchLookUpEdit1.Properties.ValueMember = gridView1.GetDataRow(e.FocusedRowHandle)["TƏCHİZATÇI ADI"].ToString(); 
                ////searchLookUpEdit1.EditValue = gridView1.GetDataRow(e.FocusedRowHandle)["TƏCHİZATÇI ADI"].ToString(); 
                //lookUpEdit7.Text = gridView1.GetDataRow(e.FocusedRowHandle)["ANBAR"].ToString();
                //memoEdit1.Text = gridView1.GetDataRow(e.FocusedRowHandle)["GEYD"].ToString();
                //textEdit8.Text = gridView1.GetDataRow(e.FocusedRowHandle)["MIGDAR"].ToString();
                //textEdit6.Text = gridView1.GetDataRow(e.FocusedRowHandle)["SATIŞ QİYMƏTİ"].ToString();
                //textEdit7.Text = gridView1.GetDataRow(e.FocusedRowHandle)["ENDIRIM FAIZ"].ToString();
                //textEdit13.Text = gridView1.GetDataRow(e.FocusedRowHandle)["ENDIRIM_AZN"].ToString();

                row.SetField("TARIX", dateEdit1.Text);
                row.SetField("QAİMƏ №", textEdit17.Text);

                row.SetField("ÖDƏMƏ TİPİ", radio);


            }
            dt.AcceptChanges();
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




            lookUpEdit7.Properties.DisplayMember = "Anbar";
            lookUpEdit7.Properties.ValueMember = "WAREHOUSE_ID";
            lookUpEdit7.Properties.DataSource = dt;
            lookUpEdit7.Properties.NullText = "--Seçin--";
            lookUpEdit7.Properties.PopulateColumns();
            lookUpEdit7.Properties.Columns[0].Visible = false;



        }

        private void lookUpEdit7_TextChanged(object sender, EventArgs e)
        {



            magazaLoad(lookUpEdit7.Text.ToString());
            //
            // 
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

       private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            GAIME_SATIS_DETAILS gs = new GAIME_SATIS_DETAILS();
            gs.Show();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
           
                gridView1.ShowPrintPreview();
            
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
           // MUSTERI_AXTAR M = new MUSTERI_AXTAR(this);
          //  M.Show();
        }
    }
}