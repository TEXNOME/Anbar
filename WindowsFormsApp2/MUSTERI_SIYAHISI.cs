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
    public partial class MUSTERI_SIYAHISI : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MUSTERI_SIYAHISI()
        {
            InitializeComponent();
        }

        private void MUSTERI_SIYAHISI_Load(object sender, EventArgs e)
        {
            GetallData();
        }

        public void GetallData()
        {

            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);
                string queryString = "SELECT* FROM dbo.fn_MUSTERI() ";

                SqlCommand command = new SqlCommand(queryString, connection);
                
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
        MUSTERILER_CRUD mc = new MUSTERILER_CRUD();
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //try
            //{
                //XtraMessageBox.Show("ugurlu");
                    foreach (int i in gridView1.GetSelectedRows())        
                {
                        DataRow row = gridView1.GetDataRow(i);
                        //    MessageBox.Show(i.ToString());
                        int a = Convert.ToInt32(row[0].ToString());
                    int u = mc.delete_(a);  
                     
                    }
                GetallData();
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("SƏHV");
            //}
        }
    }
}