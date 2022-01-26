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
    public partial class UserQeydiyyat : DevExpress.XtraEditors.XtraForm
    {
        userParolproc up = new userParolproc();
        public UserQeydiyyat()
        {
            InitializeComponent();
            getall();
        }
       // string ConString = "Data Source=DESKTOP-UB3DILS;Initial Catalog=NewInteko;Integrated Security=True";

        public void getall()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);
                string queryString = "SELECT * FROM userParol ";
                SqlCommand command = new SqlCommand(queryString, connection);


                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gridControl1.DataSource = dt;

                //for (int i = 0; i < 2; i++)
                //{
                //    gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                //}

                ////gridView1.Columns[3].OptionsColumn.ReadOnly = true;
                //for (int i = 2; i < 8; i++)
                //{
                //    gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                //}

            }
            catch (Exception e)
            {
                Console.WriteLine("Xəta!\n" + e);
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var val = checkBox1.Checked ? 1 : 0;
            up.INSERT_user(textEdit1.Text, textEdit2.Text,val);
            getall();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                int var = Convert.ToInt32(dr[3]);
                up.UPDATE_user(Convert.ToInt32(dr[0].ToString()),dr[1].ToString(), dr[2].ToString(), var);
                getall();
            }
           
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                up.DELETE_user(dr[1].ToString());
                getall();
            }
        }



            private void UserQeydiyyat_Load(object sender, EventArgs e)
        {
            gridView1.Columns[0].Visible = false;
            gridControl1.TabStop = false;
        }

       
    }
}

