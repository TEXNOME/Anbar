using DevExpress.XtraBars;
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
    public partial class GAIME_SATIS_DETAILS : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        CRUD_GAIME_SATISI cgs = new CRUD_GAIME_SATISI();
        public GAIME_SATIS_DETAILS()
        {
            InitializeComponent();
        }

        private void GAIME_SATIS_DETAILS_Load(object sender, EventArgs e)
        {
            getall();

            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            gridControl1.TabStop = false;
        }

        private void getall() 
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);
            string queryString = "SELECT * FROM GAIME_SATISI_DETAILS  ";
            SqlCommand command = new SqlCommand(queryString, connection);


            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gridControl1.DataSource = dt;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                foreach (var i in gridView1.GetSelectedRows())
                {
                    DataRow row = gridView1.GetDataRow(i);

                    cgs.GAIME_SATISI_MAIN_DEATAILS_UPDATE(Convert.ToInt32(row["GAIME_SATISI_DETAILS_ID"].ToString()), Convert.ToDateTime(row["TARIX"]), row["EMMELIYYAT_NOMRE"].ToString(), row["ODEME_TIPI"].ToString(), row["GAIME_NOM"].ToString(),
                        Convert.ToDecimal(row["ODENILEN_MEBLEG"]), Convert.ToInt32(row["MAL_DETAILS_ID"].ToString()), row["MAGAZA"].ToString(), row["ANBAR"].ToString(), row["MIGDARI"].ToString(),
                        row["SATIS_GIYMETI"].ToString(), row["ENDIRIM_FAIZ"].ToString(), row["ENDIRIM_AZN"].ToString(), row["ENDIRIM_MEBLEGI"].ToString(), row["YEKUN_MEBLEG"].ToString(), row["GEYD"].ToString());
                }
                getall();
            }
            catch (Exception)
            {

                MessageBox.Show("Dəyişiləsi məhsulu seçin");
            }
           
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                foreach (var i in gridView1.GetSelectedRows())
                {
                    DataRow row = gridView1.GetDataRow(i);
                    cgs.GAIME_SATISI_MAIN_DEATAILS_DELETE(Convert.ToInt32(row["GAIME_SATISI_MAIN_ID"].ToString()));
                }
                getall();
            }
            catch (Exception)
            {

                MessageBox.Show("Silinəsi məhsulu seçin");
            }
           
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }
    }
}