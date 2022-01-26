using DevExpress.XtraBars;
using DevExpress.XtraEditors;
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
    public partial class MEHSUL_GAYTARMA : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MEHSUL_GAYTARMA()
        {
            InitializeComponent();
            

        }
        private string qeryString = "EXEC  dbo.MAL_GAYTARMA_KOD";
        public void GETKOD()
        {

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon))
            {

                SqlCommand command = new SqlCommand(qeryString, connection);


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        //XtraMessageBox.Show(reader[0].ToString());

                        textEdit6.Text = reader[0].ToString();


                    }
                    reader.Close();


                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                    XtraMessageBox.Show(ex.Message);
                }
            }

        }
        private void MEHSUL_GAYTARMA_Load(object sender, EventArgs e)
        {
            GETKOD();
            textEdit6.Enabled = false;
            DateTime dateTime = DateTime.UtcNow.Date;
            dateEdit4.Text = dateTime.ToString();
          
            
            gridControl1.TabStop = false;
          
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
          
            lookupedittextxhange_main();
            //simpleButton4.Visible = false;
            //simpleButton5.Visible = false;
            //simpleButton2.Visible = false;
          //  gridView1.MoveFirst();
        }
        public void getsum(int A)
        {
            int paramValue = A;


            string queryString = "SELECT Y.BORC - X.GAYTARMA_MEBLEG AS BORC FROM( " +
        " select 1 AS ID, cast(sum(isnull(BORC, 0.00)) as decimal(9, 2)) as BORC " +
                  " from(SELECT f.MAL_ALISI_MAIN_ID, f.[FAKTURA NÖMRƏ], " +
                   "   f.TARIX, f.QİYMƏT - isnull(t.odenis, 0.00) BORC, " +
                    "  0 AS 'ÖDƏNİŞ'FROM dbo.fn_TECHIZATCI_BORC(@pricePoint) f " +
                          "  left join(select  MAL_ALISI_MAIN_ID, " +
                       " sum(ODENIS) odenis from TECHIZATCI_ODENIS " +
                       " group by MAL_ALISI_MAIN_ID)t  on f.MAL_ALISI_MAIN_ID = t.MAL_ALISI_MAIN_ID)o " +
                       " )Y " +
                       " LEFT JOIN( " +
                       " SELECT 1 AS ID, ISNULL(CAST(SUM(MD.ALIS_GIYMETI * D.MIGDARI) AS decimal(9, 2)), 0.00) " +
                       " AS GAYTARMA_MEBLEG FROM MAL_GEYTARMA_MAIN M " +
                       " INNER JOIN  MAL_GEYTARMA_DETAILS D ON " +
                       " M.MAL_GEYTARMA_MAIN_ID = D.MAL_GEYTARMA_MAIN_ID " +
                       " INNER JOIN MAL_ALISI_DETAILS MD ON MD.MAL_ALISI_DETAILS_ID = D.MAL_ALISI_DETAILS_ID " +
                       " INNER JOIN MAL_ALISI_MAIN MM ON MM.MAL_ALISI_MAIN_ID = MD.MAL_ALISI_MAIN_ID " +
                       " WHERE MM.TECHIZATCI_ID = @pricePoint " +
                       "  )X ON X.ID = Y.ID ";

            SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);
            SqlCommand cmd = new SqlCommand();
            SqlCommand command = new SqlCommand(queryString, connection);

            command.Parameters.AddWithValue("@pricePoint", paramValue);

            connection.Open();
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {

                textEdit14.Text = dr["BORC"].ToString();

            }
            connection.Close();


        }
        public void getall_null_value ()
        {
            //string paramValue = a;
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);

                // Provide the query string with a parameter placeholder.
                string queryString = " select 0,''[TARIX],''[TƏCHİZATÇI ADI],''[FAKTURA NÖMRƏSİ],''[MƏHSUL ADI], "+

                    " ''[MƏHSUL KODU],''[VAHİD],0.00[MİQDARI],0.00[BİR VAHİDİN QİYMƏTİ]," +
                    " ''[YERLƏŞDİYİ ANBAR],null[QAYTARILMALI MİQDAR] ";
                SqlCommand command = new SqlCommand(queryString, connection);
               // command.Parameters.AddWithValue("@pricePoint", paramValue);
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

            lookupedittextxhange_main();
        }

        public void getall1(string a)
        {
            string paramValue = a;
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);

                // Provide the query string with a parameter placeholder.
                string queryString = " select [MAL_ALISI_DETAILS_ID]"+
                                     ",[TARIX],[TƏCHİZATÇI ADI],[FAKTURA NÖMRƏSİ]"+
                                     ",[MƏHSUL ADI],[MƏHSUL KODU],[VAHİD]"+
                                     ",[MİQDARI],[BİR VAHİDİN QİYMƏTİ]"+
                                     ",[YERLƏŞDİYİ ANBAR],[QAYTARILMALI MİQDAR]"+
                                     "from[dbo].[gaytarilacag_mallar] where[TƏCHİZATÇI ADI] = @pricePoint " +
                                     " and[MİQDARI] > 0.00   union all "+
                    " select 0,'','','','','','',0.00,0.00,'',null ";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@pricePoint", paramValue);
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

            lookupedittextxhange_main();
        }
        public void getall()
        {
            //string paramValue = a;
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon);

                // Provide the query string with a parameter placeholder.
                string queryString = " select * from [dbo].[gaytarilacag_mallar] where [MİQDARI]>0.00";
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@pricePoint", paramValue);
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

            lookupedittextxhange_main();
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {



        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (gridView1.Columns[8].OptionsColumn.AllowEdit == false)
            {
                gridView1.Columns[8].OptionsColumn.AllowEdit = true;

            }
            else
            {
                //gridView1.Columns[8].OptionsColumn.AllowEdit = false;
            }
        }
        MAL_GAYTARMA mg = new MAL_GAYTARMA();
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            try
            {
                int ret = mg.InsertMalGaytarma(textEdit6.Text.ToString(), Convert.ToDateTime(dateEdit4.Text));
                if (ret > 0)
                {
                    //XtraMessageBox.Show("ugurlu");
                    foreach (int i in gridView1.GetSelectedRows())
                    {
                        DataRow row = gridView1.GetDataRow(i);
                        //    MessageBox.Show(i.ToString());
                        decimal a = Convert.ToDecimal(row[7].ToString());
                        decimal b = Convert.ToDecimal(row[10].ToString());
                        if (a >= b)
                        {
                            int u= mg.InsertMalGaytarmaDetails(ret.ToString(), row[0].ToString(), row[10].ToString());
                        }
                     //  MessageBox.Show(row[7].ToString() +" / " +row[10].ToString());
                    //    MessageBox.Show(ret.ToString()+" " + row[0].ToString() + " " + row[1].ToString());
                


                    }
                    XtraMessageBox.Show("ƏMƏLİYYAT UĞURLA TAMAMLANDI");
                }
                getall1(lookUpEdit2.Text.ToString());
                clear();
                getsum(Convert.ToInt32(lookUpEdit2.EditValue));

                textEdit14.Text = "";
                GETKOD();
                textEdit5.Text = "";
                lookUpEdit2.EditValue = null;
                dateEdit1.Text = "";
                getall_null_value();
            }
            catch (Exception)
            {

                MessageBox.Show("SƏHV");
            }
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            GAYTARMA_AXTARİS GA = new GAYTARMA_AXTARİS(this);
            GA.Show();
        }

        private void lookupedittextxhange_main()
        {
            //int id = Convert.ToInt32(lookUpEdit1.EditValue.ToString());

            //if (id > 0)
            //{
            string strQuery = "select TECHIZATCI_ID,SIRKET_ADI from COMPANY.TECHIZATCI";
            SqlCommand cmd = new SqlCommand(strQuery);
            DataTable dt = GetData(cmd);
            lookUpEdit2.Properties.DisplayMember = "SIRKET_ADI";
            lookUpEdit2.Properties.ValueMember = "TECHIZATCI_ID";
            lookUpEdit2.Properties.DataSource = dt;
            lookUpEdit2.Properties.NullText = "TƏCHİZATÇINI SEÇİN";
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

        private void lookUpEdit2_TextChanged(object sender, EventArgs e)
        {
            ///

            if (lookUpEdit2.EditValue != null)
            {
                getsum(Convert.ToInt32(lookUpEdit2.EditValue));
                getall1(lookUpEdit2.Text.ToString());
            }
           
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            clear();
        }

        private void clear()
        {
            textEdit5.Text = "";
           // textEdit6.Text = "";
           // textEdit3.Text = "";
           // textEdit1.Text = "";
            memoEdit1.Text = "";
        }

        //private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    foreach (var i in gridView1.GetSelectedRows())
        //    {
        //        DataRow row = gridView1.GetDataRow(i);
        //        if (row != null)
        //        {
        //            /// delete
        //        }
        //    }
        //    getall();
        //}
    }
}