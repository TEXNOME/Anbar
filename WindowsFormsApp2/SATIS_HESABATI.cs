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
    public partial class SATIS_HESABATI : DevExpress.XtraEditors.XtraForm
    {
        public SATIS_HESABATI()
        {
            InitializeComponent();
        }

        private void SATIS_HESABATI_Load(object sender, EventArgs e)
        {
            searchlookupedit();
            gridControl1.TabStop = false;
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

        private void searchLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            searchLookUpEdit1.Properties.View.Columns["TECHIZATCI_ID"].Visible = false;
            searchLookUpEdit1.Properties.View.Columns["MAL_ALISI_DETAILS_ID"].Visible = false;
        }
    }
}