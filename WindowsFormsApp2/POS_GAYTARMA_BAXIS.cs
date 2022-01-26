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
    public partial class POS_GAYTARMA_BAXIS : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public POS_GAYTARMA_BAXIS()
        {
            InitializeComponent();
        }
       // public string ConString = "Data Source=.;Initial Catalog=NewInteko;Integrated Security=True";
        public void getal(string t1,string t2)
        {

            try
            {

                //qaytarilma tablosundan sonra




                //SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);

                //// Provide the query string with a parameter placeholder.
                //string queryString = " sselect * from [dbo].[fn_POS_GAYTARMA] ()  WHERE CAST([TARİX] AS smalldatetime) BETWEEN  @pricePoint and @pricePoint1";
                //SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@pricePoint", Convert.ToDateTime(t1));
                //command.Parameters.AddWithValue("@pricePoint1", Convert.ToDateTime(t2));
                //SqlDataAdapter da = new SqlDataAdapter(command);
                //DataTable dt = new DataTable();
                //da.Fill(dt);
                //gridControl1.DataSource = dt;
                //gridView1.Columns[0].Visible = false;
                //gridView1.OptionsSelection.MultiSelect = true;
                //gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            }
            catch (Exception e)
            {
                Console.WriteLine("Xəta!\n" + e);
            }

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //load
            if (string.IsNullOrEmpty(dateEdit1.Text) || string.IsNullOrEmpty(dateEdit4.Text))
            {

            }
            else
            {
                getal(dateEdit1.Text.ToString(), dateEdit4.Text.ToString());
            }
         
        }

        private void POS_GAYTARMA_BAXIS_Load(object sender, EventArgs e)
        {
            gridControl1.TabStop = false;
        }
    }
}