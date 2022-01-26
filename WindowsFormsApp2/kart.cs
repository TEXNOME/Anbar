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
    public partial class kart : DevExpress.XtraEditors.XtraForm
    {
        private readonly POS frm1;
        public decimal h { get; set; }
        public kart(decimal a, POS frm)
        {
            InitializeComponent();
            h = a;
            frm1 = frm;
        }
        //public string ConString = "Data Source=.;Initial Catalog=NewInteko;Integrated Security=True";
        public void getmebleg(string paramValue, string paramValue1)
        {


            string queryString = " exec  [dbo].[yekun_mebleg_nagd]  @param1 =@pricePoint, @param2=@pricePoint1";
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand();
            SqlCommand command = new SqlCommand(queryString, connection);

            command.Parameters.AddWithValue("@pricePoint", paramValue);
            command.Parameters.AddWithValue("@pricePoint1", paramValue1);

            connection.Open();
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {

                textEdit3.Text = dr["col"].ToString();

            }
            connection.Close();
        }
        private void kart_Load(object sender, EventArgs e)
        {
            textEdit2.Text = h.ToString();
            textEdit2.Enabled = false;
        }

        private void textEdit4_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit4.Text))
            {
                textEdit4.Text = "0";

            }
            else
            {
                getmebleg(textEdit2.Text.ToString(), textEdit4.Text.ToString());
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
                getmebleg(textEdit2.Text.ToString(), textEdit4.Text.ToString());
            }


        }

        private void kart_FormClosing(object sender, FormClosingEventArgs e)
        {
            //
            if (string.IsNullOrEmpty(textEdit4.Text))
            {

            }
            else
            {
                //frm1.gelen_data_negd_pos( Convert.ToDecimal(0.00), Convert.ToDecimal(textEdit4.Text));
                frm1.gelen_data_negd_pos(Convert.ToDecimal(0.00), Convert.ToDecimal(3.00));
            }
        }
    }
}