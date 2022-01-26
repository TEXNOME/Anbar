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
    public partial class bank : DevExpress.XtraEditors.XtraForm
    {
        private readonly POS frm1;

       // public string ConString = "Data Source=.;Initial Catalog=NewInteko;Integrated Security=True";
        public decimal g { get; set; }
        public bank(decimal A, POS frm)
        {
            InitializeComponent();
            g = A;
            frm1 = frm;
        }

        private void nagd_Load(object sender, EventArgs e)
        {
           // MessageBox.Show(g.ToString());
            textEdit2.Text = g.ToString();
            textEdit2.Enabled = false;
        }
        public void getmebleg(string paramValue, string paramValue1)
        {


            string queryString = " exec  yekun_mebleg_nagd  @param1 =@pricePoint, @param2=@pricePoint1";
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand();
            SqlCommand command = new SqlCommand(queryString, connection);

            command.Parameters.AddWithValue("@pricePoint", paramValue);
            command.Parameters.AddWithValue("@pricePoint1", paramValue1);
           
            connection.Open();
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {

                textEdit3.Text = dr["galig"].ToString();
               
            }
            connection.Close();
        }
        private void textEdit4_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit4.Text))
            {
                textEdit4.Text = "0.0";

            }
            else
            {
                getmebleg(textEdit2.Text.ToString(), textEdit4.Text.ToString());
            }


            //decimal a = Convert.ToDecimal(textEdit2.Text);
            ////decimal f = Convert.ToDecimal(textEdit4.Text);
            //if (string.IsNullOrEmpty(textEdit4.Text))
            //{
            //    textEdit4.Text = "0";

            //}
            //else
            //{
            //    decimal f = Convert.ToDecimal(textEdit4.Text.ToString());
            //    if (f >= a)
            //    {
            //        decimal x = f - a;
            //        textEdit3.Text = x.ToString();
            //    }
            //    else
            //    {
            //        textEdit4.Text = "0";

            //    }
            //}


        }

        private void textEdit4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit4.Text))
            {
                textEdit4.Text = "0";

            }
            else
            {
                getmebleg(textEdit2.Text.ToString(), textEdit4.Text.ToString());
            }
            //decimal a = Convert.ToDecimal(textEdit2.Text.ToString());

            ////MessageBox.Show(textEdit4.Text.ToString());
            //if (string.IsNullOrEmpty(textEdit4.Text))
            //{

            //    textEdit4.Text = "0";
            //}
            //else
            //{
            //    decimal f = Convert.ToDecimal(textEdit4.Text.ToString());
            //    if (f >= a)
            //    {
            //        decimal x = f - a;
            //        textEdit3.Text = x.ToString();
            //    }
            //    else
            //    {
            //        textEdit4.Text = "0";
            //    }
            //}

        }

        private void nagd_FormClosing(object sender, FormClosingEventArgs e)
        {
            ///
            if (string.IsNullOrEmpty(textEdit4.Text))
                {

            }
            else
            {
                frm1.gelen_data_negd_pos(Convert.ToDecimal( textEdit4.Text),Convert.ToDecimal( 0.00));
            }
       
        }
    }
}