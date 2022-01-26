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
    public partial class nagd_kart : DevExpress.XtraEditors.XtraForm
    {
        private readonly POS frm1;
        public decimal h { get; set; }
        public nagd_kart( decimal a, POS frm)
        {
            InitializeComponent();
            h = a;
            frm1 = frm;
        }

        private void nagd_kart_Load(object sender, EventArgs e)
        {
            textEdit1.Text = h.ToString();
            textEdit1.Enabled = false;
        }

        private void textEdit4_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit4.Text))
            {
                textEdit4.Text = "0";


            }
            else
            {
               
                getmebleg(textEdit1.Text.ToString(), textEdit4.Text.ToString(), textEdit3.Text.ToString());
            }
        }

        private void textEdit4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit4.Text))
            {
                textEdit4.Text = "0";

            }
            else
            {
                getmebleg(textEdit1.Text.ToString(), textEdit4.Text.ToString(), textEdit3.Text.ToString());
            }
        }

        private void textEdit3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit3.Text))
            {
                textEdit3.Text = "0";

            }
            else
            {
                getmebleg(textEdit1.Text.ToString(), textEdit4.Text.ToString(), textEdit3.Text.ToString());
            }
        }

        private void textEdit3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit3.Text))
            {
                textEdit3.Text = "0";

            }
            else
            {
                getmebleg(textEdit1.Text.ToString(), textEdit4.Text.ToString(), textEdit3.Text.ToString());
            }
          
        }
        //public string ConString = "Data Source=.;Initial Catalog=NewInteko;Integrated Security=True";
        public void getmebleg(string paramValue, string paramValue1,string paramValue2)
        {


            string queryString = " exec  [dbo].[yekun_mebleg_nagd_kat]  @param1 =@pricePoint, @param2=@pricePoint1 ";
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand();
            SqlCommand command = new SqlCommand(queryString, connection);

            command.Parameters.AddWithValue("@pricePoint", paramValue);
            command.Parameters.AddWithValue("@pricePoint1", paramValue1);
        
            connection.Open();
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {

                textEdit2.Text = dr["galig"].ToString();
                textEdit3.Text = dr["kart"].ToString();

            }
            connection.Close();
        }

        private void nagd_kart_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit4.Text) || string.IsNullOrEmpty(textEdit3.Text))
            {

            }
            else
            {
                //frm1.gelen_data_negd_pos( Convert.ToDecimal(0.00), Convert.ToDecimal(textEdit4.Text));
                frm1.gelen_data_negd_pos(Convert.ToDecimal(textEdit4.Text), Convert.ToDecimal(textEdit3.Text));
            }
        }
    }
}