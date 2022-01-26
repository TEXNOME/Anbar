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
    public partial class ALINAN_MEHSULLAR : DevExpress.XtraEditors.XtraForm
    {
        //public string ConString = "Data Source=.;Initial Catalog=NewInteko;Integrated Security=True";
        public ALINAN_MEHSULLAR()
        {
            InitializeComponent();
        }

        private void ALINAN_MEHSULLAR_Load(object sender, EventArgs e)
        {
            
          
        }

        private void LOAD(DateTime d1,DateTime d2)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);

                // Provide the query string with a parameter placeholder.
                string queryString = "SELECT * FROM dbo.ALINAN_MEHSUL(@pricePoint,@pricePoint1) ";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@pricePoint", d1);
                command.Parameters.AddWithValue("@pricePoint1", d2);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
                gridView1.Columns[0].Visible = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Xəta!\n" + e);
            }

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dateEdit2.Text) || string.IsNullOrEmpty(dateEdit1.Text))
            {
                XtraMessageBox.Show("TARİX ARALIĞI SEÇİLMƏYİB");
            }
            else
            {
                LOAD(Convert.ToDateTime(dateEdit2.Text.ToString()), Convert.ToDateTime(dateEdit1.Text));
            }
        }
    }
}