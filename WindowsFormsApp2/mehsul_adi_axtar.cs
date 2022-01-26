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
    public partial class mehsul_adi_axtar : DevExpress.XtraEditors.XtraForm
    {
        private readonly MEHSUL_ALISI_LAYOUT frm1;
        public static int x;
        public mehsul_adi_axtar(int a, MEHSUL_ALISI_LAYOUT frm)
        {
            InitializeComponent();
            frm1 = frm;
            x = a;
        }

        private void mehsul_adi_axtar_Load(object sender, EventArgs e)
        {
            // MessageBox.Show(x.ToString());
            getall(x);
        }

        public void getall(int Y)
        {
            int paramValue =Y;
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);                               
                string queryString = "select D.MEHSUL_ADI as N'MƏHSUL ADI',D.MEHSUL_KODU as N'MƏHSUL KODU',D.ALIS_GIYMETI as N'SON ALIŞ QİYMƏTİ' from  " +
                                 " MAL_ALISI_MAIN M INNER JOIN MAL_ALISI_DETAILS D " +
                                 " ON M.MAL_ALISI_MAIN_ID = D.MAL_ALISI_MAIN_ID " +
                                 " WHERE M.TECHIZATCI_ID = @pricePoint ";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@pricePoint", paramValue);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
              //  gridView1.Columns[0].Visible = false;
                gridView1.OptionsSelection.MultiSelect = true;
                //gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            }
            catch (Exception e)
            {
                Console.WriteLine("Xəta!\n" + e);
            }

        }
        public static string m_ad;
        public static string m_kod;
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            frm1.mehsul_kod_axtar(m_ad, m_kod);
            this.Close();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                m_ad = dr[0].ToString();

                //  XtraMessageBox.Show(id.ToString());
                m_kod = dr[1].ToString();

            }
        }
    }
}