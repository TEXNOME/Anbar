using DevExpress.XtraBars;
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

namespace WindowsFormsApp2
{
    public partial class GAIME_SATIS_GAYTARMA : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private const String CATEGORIES_TABLE = "Categories";
        // field name constants
        private const String CATEGORYID_FIELD = "CategoryID";
        private const string TARİX = "TARIX";
        private const string emeliyat_nomre = "ƏMILİYYAT NÖMRƏ";
        private const string GAIME_NOM = "QAİMƏ №";
    
        private const string GAIME_SATIS_DETAILS_ID = "GAIME_SATIS_DETAILS_ID";
        private const string MIGDAR = "MIGDAR";
        private const string G_MIGDAR = "G_MIGDAR";
        private const String MEHSUL_ADI = "MƏHSUL ADI";
        private const String MEHSUL_KODU = "MƏHSUL KODU";
        private const String GEYD = "GEYD";
        private DataTable dt;
        private SqlDataAdapter da;

        public GAIME_SATIS_GAYTARMA()
        {
            InitializeComponent();
        }

        private void GAIME_SATIS_GAYTARMA_Load(object sender, EventArgs e)
        {
            gridControl1.TabStop = false;
            searchlookupedit();
            textEdit7.Enabled = false;

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
            dt.Columns.Add(emeliyat_nomre, typeof(System.String));
            dt.Columns.Add(GAIME_NOM, typeof(System.String));
            dt.Columns.Add(GAIME_SATIS_DETAILS_ID, typeof(System.String));
            dt.Columns.Add(MIGDAR, typeof(System.String));
            dt.Columns.Add(G_MIGDAR, typeof(System.String));
            col = dt.Columns.Add(MEHSUL_ADI, typeof(System.String));
            //col.AllowDBNull = false;
            col.MaxLength = 50;
            col = dt.Columns.Add(MEHSUL_KODU, typeof(System.String));
            dt.Columns.Add(GEYD, typeof(System.String));
            //col.AllowDBNull = false;
            col.MaxLength = 50;

            DataRow row = dt.NewRow();
            row[TARİX] = "";
            row[emeliyat_nomre] = "";
            row[GAIME_NOM] = "";
            row[GAIME_SATIS_DETAILS_ID] = "";
            row[MIGDAR] = "";
            row[G_MIGDAR] = "";
            row[MEHSUL_ADI] = "";
            row[MEHSUL_KODU] = "";
            row[GEYD] = "";


            dt.Rows.Add(row);



            DataView dv1 = dt.DefaultView;
            dv1.Sort = "CategoryID DESC";

            gridControl1.DataSource = dv1;
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {

        }

        public void searchlookupedit()
        {

            DataTable dt = null;

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon))

            {
                con.Open();
                string strCmd = "select * from dbo.gaime_gaytarma()";
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
        private void searchLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {


            searchLookUpEdit1.Properties.View.Columns["TECHIZATCI_ID"].Visible = false;
            searchLookUpEdit1.Properties.View.Columns["MAL_ALISI_DETAILS_ID"].Visible = false;
            searchLookUpEdit1.Properties.View.Columns["GAIME_SATISI_DETAILS_ID"].Visible = false;
        }
        public static string gaime_satis_details_id;
        private void searchLookUpEdit1_TextChanged(object sender, EventArgs e)
        {
            textEdit4.Text = this.searchLookUpEdit1.Properties.View.GetFocusedRowCellValue("MƏHSUL ADI").ToString();
            textEdit1.Text = this.searchLookUpEdit1.Properties.View.GetFocusedRowCellValue("MƏHSUL KODU").ToString();
            textEdit7.Text = this.searchLookUpEdit1.Properties.View.GetFocusedRowCellValue("migdar").ToString();
            gaime_satis_details_id = this.searchLookUpEdit1.Properties.View.GetFocusedRowCellValue("GAIME_SATISI_DETAILS_ID").ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(textEdit7.Text.ToString()) <= 0 || Convert.ToDecimal(textEdit7.Text.ToString()) < Convert.ToDecimal(textEdit8.Text.ToString()))
            {
                MessageBox.Show("Migdar çıxılacaq migdardan azdır");
                goto SON;
            }
            //DAXIL ET
            DataRow row = dt.NewRow();
            row[TARİX] = dateEdit4.Text.ToString();
            row[emeliyat_nomre] = textEdit6.Text.ToString();
            row[GAIME_NOM] = textEdit5.Text.ToString();
            row[GAIME_SATIS_DETAILS_ID] = gaime_satis_details_id;
            row[MIGDAR] = textEdit7.Text.ToString();
            row[G_MIGDAR] = textEdit8.Text.ToString();
            row[MEHSUL_ADI] = textEdit4.Text.ToString();
            row[MEHSUL_KODU] = textEdit1.Text.ToString();
            row[GEYD] = memoEdit1.Text.ToString();
            //row[POS_EKRANDA_GOSTER] = spinEdit2.Text.ToString();
            dt.Rows.Add(row);
             clear();

            SON:;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                int num = dt.Rows.Count;
                if (num > 1)
                {
                    label1.Text = gridView1.GetDataRow(e.FocusedRowHandle)["CategoryID"].ToString();
                    dateEdit4.Text = gridView1.GetDataRow(e.FocusedRowHandle)["TARIX"].ToString();
                    textEdit5.Text = gridView1.GetDataRow(e.FocusedRowHandle)["QAİMƏ №"].ToString();
                    textEdit6.Text = gridView1.GetDataRow(e.FocusedRowHandle)["ƏMILİYYAT NÖMRƏ"].ToString();
                    textEdit4.Text = gridView1.GetDataRow(e.FocusedRowHandle)["MƏHSUL ADI"].ToString();
                    memoEdit1.Text = gridView1.GetDataRow(e.FocusedRowHandle)["GEYD"].ToString();
                    textEdit7.Text = gridView1.GetDataRow(e.FocusedRowHandle)["MIGDAR"].ToString();
                    textEdit8.Text = gridView1.GetDataRow(e.FocusedRowHandle)["G_MIGDAR"].ToString();
                    

                   
                }
            }
            catch (Exception esx)
            {

                MessageBox.Show(esx.Message.ToString());
            }

        }

        CRUD_GAIME_SATISI CG = new CRUD_GAIME_SATISI();
        private void simpleButton6_Click_1(object sender, EventArgs e)
        {
            //
            try
            {
                int ret = CG.GAIME_SATISI_GAYTARMA_MAIN(textEdit6.Text.ToString(), textEdit5.Text.ToString(), Convert.ToDateTime(dateEdit4.Text), memoEdit1.Text.ToString());

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
                            int a = CG.GAIME_SATISI_GAYTARMA_DETAILS(ret, Convert.ToInt32(gaime_satis_details_id), Convert.ToDecimal(textEdit8.Text.ToString()));

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
            row2[emeliyat_nomre] = "";
            row2[GAIME_NOM] = "";
            row2[GAIME_SATIS_DETAILS_ID] = "";
            row2[MIGDAR] = "";
            row2[G_MIGDAR] = "";
            row2[MEHSUL_ADI] = "";
            row2[MEHSUL_KODU] = "";
            row2[GEYD] = "";


            dt.Rows.Add(row2);




            DataView dv1 = dt.DefaultView;
            dv1.Sort = "CategoryID DESC";

            gridControl1.DataSource = dv1;

        }
        private void clear()
        {
            textEdit5.Text = "";
           
            textEdit8.Text = "";
            textEdit6.Text = "";
            textEdit7.Text = "";
          
            textEdit1.Text = "";
            memoEdit1.Text = "";

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            clear();
        }
    }
}