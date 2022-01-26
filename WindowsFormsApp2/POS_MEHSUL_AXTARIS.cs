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
    public partial class POS_MEHSUL_AXTARIS : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dt;
        private SqlDataAdapter da;
        AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
        SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);
        private const String CATEGORIES_TABLE = "Categories";
        private const string barkod = "BARKOD";
        public POS_MEHSUL_AXTARIS()
        {
            InitializeComponent();
        }

        private void POS_MEHSUL_AXTARIS_Load(object sender, EventArgs e)
        {

            gridControl1.TabStop = false;
            //getall();
            Auto();

            dt = new DataTable(CATEGORIES_TABLE);

            // add the identity column
        

            // add the other columns
     
            dt.Columns.Add(barkod, typeof(System.String));
            

            DataView dv = dt.DefaultView;
           
        }
       //string ConString= "Data Source =.; Initial Catalog = NewInteko; Integrated Security = True";
        
        public void getall(string a)
        {
            string paramValue = a;
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);


                string queryString = "select mal_details_id,BARKOD,[MƏHSUL ADI],[MigDAR] AS N'Miqdar',SATIS_GIYMETI AS N'SATIŞ QİYMƏTİ' " +
                    "  from dbo.fn_pos_axtaris_load('a') where [MƏHSUL ADI]=@pricePoint";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@pricePoint", paramValue);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
                gridView1.Columns[0].Visible = false;



                foreach (DataRow row in dt.Rows)
                {
                    //MessageBox.Show(row["BARKOD"].ToString());
                    textBox2.Text = row["BARKOD"].ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Xəta!\n" + e);
            }

        }


        public void Auto()

        {

            da = new SqlDataAdapter("select [MƏHSUL ADI]  from dbo.fn_pos_axtaris_load('a')", Properties.Settings.Default.SqlCon);

            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count > 0)

            {

                for (int i = 0; i < dt.Rows.Count; i++)

                {

                    coll.Add(dt.Rows[i]["MƏHSUL ADI"].ToString());

                }

            }
            else

            {

                //MessageBox.Show("Name not found");

            }

            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;

            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

            textBox1.AutoCompleteCustomSource = coll;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (string.IsNullOrEmpty(textBox1.Text.ToString()))
            //    {

            //}
            //else
            //{
            //    if (e.KeyChar == (char)13)
            //        //MessageBox.Show("ENTER has been pressed!");
            //        getall();
            //    else if (e.KeyChar == (char)27)
            //        this.Close();
            //}
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.ToString()))
            {
            }
            else
            {
                getall(textBox1.Text.ToString());
            }
               
        }
    }
}