using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApp2
{


    public partial class avtorizasiya : DevExpress.XtraEditors.XtraForm
    {

        bool mouseDown;
        private Point offset;

        SqlConnection Con = new SqlConnection(Properties.Settings.Default.SqlCon);

        public avtorizasiya()
        {
            InitializeComponent();


        }


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            bool check = false;
            try
            {
                SqlCommand com = new SqlCommand("proc_passGet", Con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@login", textEdit1.Text);
                com.Parameters.AddWithValue("@parol", textEdit2.Text);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr[2].ToString() == "True")
                    {

                        admin_control.check = true;
                        check = true;
                        (this.Owner as RibbonForm1).UserLogin();
                        this.Hide();

                    }
                    else
                    {

                        admin_control.check = false;
                        check = true;
                        (this.Owner as RibbonForm1).UserLogin();
                        this.Hide();
                    }
                    break;

                }
                if (!check)
                {
                    MessageBox.Show("Login və ya parol səfdir", "XƏTA");
                    check = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void avtorizasiya_Load(object sender, EventArgs e)
        {
            this.Hide();
        }



        private void textEdit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton2.PerformClick();

                e.SuppressKeyPress = true;
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Up)
            {
                textEdit1.Select();
            }
        }

        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton2.PerformClick();

                e.SuppressKeyPress = true;
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                textEdit2.Select();
            }
        }




    }
}