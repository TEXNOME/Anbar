using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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
    public partial class kategoriyalar : DevExpress.XtraEditors.XtraForm
    {
        private readonly MEHSUL_ALISI_LAYOUT frm1;
      

        public kategoriyalar(MEHSUL_ALISI_LAYOUT frm)
        {
            InitializeComponent();
            frm1 = frm;
        }

        private void kategoriyalar_Load(object sender, EventArgs e)
        {
            getall();
            labelControl2.Visible = false;
        }

        public void getall()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);


                // Provide the query string with a parameter placeholder.
                string queryString =
                  "select * from KATEGORIYA";


                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@pricePoint", paramValue);
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
          //  XtraMessageBox.Show("a");
            this.Close();
          //  throw new DevExpress.Utils.HideException();
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //this.Close();
            frm1.kategoriya(a);
        }
        public static string a;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
               string  id = dr[1].ToString();

                //  XtraMessageBox.Show(id.ToString());
                a = id;
                textEdit1.Text = dr[1].ToString();
                labelControl2.Text = dr[0].ToString();
            }
        }
        techizatci_odenis to = new techizatci_odenis();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textEdit1.Text) && string.IsNullOrEmpty(labelControl2.Text.ToString()))
                {

                }
                else
                {
                    int x = to.update_kategoriya(Convert.ToInt32(labelControl2.Text.ToString()), textEdit1.Text.ToString());
                    if (x > 0)
                    {
                        XtraMessageBox.Show("MƏLUMATLAR UĞURLA DƏYİŞDİRİLDİ");
                    }
                }
            }
           
            catch(Exception EX)
            {
                XtraMessageBox.Show(EX.Message.ToString());
            }

            getall();
        }
    }
}