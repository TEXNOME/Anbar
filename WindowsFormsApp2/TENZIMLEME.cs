using DevExpress.XtraBars;
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
    public partial class TENZIMLEME : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public TENZIMLEME()
        {
            InitializeComponent();
        }

        private void TENZIMLEME_Load(object sender, EventArgs e)
        {
            firma_main();
            magaza_main();
            gridControl1.TabStop = false;
        }

        private void firma_main()
        {
            //int id = Convert.ToInt32(lookUpEdit1.EditValue.ToString());

            //if (id > 0)
            //{
            string strQuery = "SELECT KASSA_FIRMALAR_ID ,KASSA_FIRMALAR AS N'FİRMALAR' FROM KASSA_FIRMALAR";
            SqlCommand cmd = new SqlCommand(strQuery);
            DataTable dt = GetData(cmd);
            lookUpEdit1.Properties.DisplayMember = "FİRMALAR";
            lookUpEdit1.Properties.ValueMember = "KASSA_FIRMALAR_ID";
            lookUpEdit1.Properties.DataSource = dt;
            lookUpEdit1.Properties.NullText = "--Seçin--";
            lookUpEdit1.Properties.PopulateColumns();
            lookUpEdit1.Properties.Columns[0].Visible = false;
            //}
        }
        private void magaza_main()
        {
            //int id = Convert.ToInt32(lookUpEdit1.EditValue.ToString());

            //if (id > 0)
            //{
            string strQuery = "select STOREID,STORE_NAME  as N'OBYEKT' from COMPANY.STORE";
            SqlCommand cmd = new SqlCommand(strQuery);
            DataTable dt = GetData(cmd);
            lookUpEdit2.Properties.DisplayMember = "OBYEKT";
            lookUpEdit2.Properties.ValueMember = "STOREID";
            lookUpEdit2.Properties.DataSource = dt;
            lookUpEdit2.Properties.NullText = "--Seçin--";
            lookUpEdit2.Properties.PopulateColumns();
            lookUpEdit2.Properties.Columns[0].Visible = false;
            //}
        }

        private DataTable GetData(SqlCommand cmd)

        {

            DataTable dt = new DataTable();


            SqlConnection con = new SqlConnection(Properties.Settings.Default.SqlCon);

            SqlDataAdapter sda = new SqlDataAdapter();

            cmd.CommandType = CommandType.Text;

            cmd.Connection = con;

            try

            {

                con.Open();

                sda.SelectCommand = cmd;

                sda.Fill(dt);

                return dt;

            }

            catch (Exception ex)

            {



                return null;

            }

            finally

            {

                con.Close();

                sda.Dispose();

                con.Dispose();

            }

        }

    }
}