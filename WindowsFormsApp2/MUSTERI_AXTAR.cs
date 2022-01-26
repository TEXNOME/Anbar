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
    public partial class MUSTERI_AXTAR : DevExpress.XtraEditors.XtraForm
    {
        private readonly GAIME_SATISI_LAYOUT frm1;
        public MUSTERI_AXTAR(GAIME_SATISI_LAYOUT frm)
        {
            InitializeComponent();
            frm1 = frm;
        }

        private void MUSTERI_AXTAR_Load(object sender, EventArgs e)
        {
            getall();
        }
        public void getall()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);


                // Provide the query string with a parameter placeholder.
                string queryString =
                  "SELECT  MUSTERILER_ID, AD +' ' " +
                   " +SOYAD + ' ' + ATAADI + ' ' +( CASE WHEN CINSI=N'KİŞİ' " +
                    " THEN N'O' ELSE N'Q' END) AS [AD SOYAD ATA ADI], " +
                    " SVNO AS N'ŞV-№',FINKOD AS N'FİN',MOBIL AS N'ƏLAQƏ' " +
                    " FROM MUSTERILER "; 
                    


                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@pricePoint", paramValue);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
                gridView1.Columns[0].Visible = false;

                //gridView1.OptionsSelection.MultiSelect = true;
                //gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;


            }
            catch (Exception e)
            {
                Console.WriteLine("Xəta!\n" + e);
            }
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            frm1.MUSTERI(ID, aD);
            this.Close();
        }
        public static string aD;
        public static string ID;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                string id = dr[0].ToString();

                //  XtraMessageBox.Show(id.ToString());
                ID = dr[0].ToString();
                aD = dr[1].ToString();
            }
        }
    }
}