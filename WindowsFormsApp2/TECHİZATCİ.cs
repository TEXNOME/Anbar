using DevExpress.XtraBars;
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
    public partial class TECHİZATCİ : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        CrudTechizatci ct = new CrudTechizatci();
        public int grup_edit_value = 0;
        public TECHİZATCİ()
        {
            InitializeComponent();
            buttonEdit1.Visible = false;
            labelControl17.Visible = false;

        }
        //string CONN = "Data Source =.; Initial Catalog = NewInteko; Integrated Security = True";
       private string qeryString2 = "select TECHIZATCI_NOMRE=case when (TECHIZATCI_NOMRE is null or TECHIZATCI_NOMRE='' ) " +
            "then 'T-1' else 'T-'+ RTRIM( LTRIM(CAST(MAX(CAST(REPLACE(TECHIZATCI_NOMRE,'T-','')  AS INT)+1) AS NCHAR(10)))) end " +
            "from COMPANY.TECHIZATCI group by TECHIZATCI_NOMRE";

        private string qeryString = "   EXEC dbo.TECHIZATCI_NOMRE";
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
                      
                        textEdit14.Text = reader[0].ToString();

                        
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
        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }


        public void CLEAR()
        {
            dateEdit1.Text = "";
            textEdit15.Text = "";
            textEdit14.Text = "";
            buttonEdit1.Text = "";
            textEdit1.Text = "";
            textEdit13.Text = "";
            textEdit2.Text = "";
            textEdit3.Text = "";
            textEdit17.Text = "";
            textEdit4.Text = "";
            textEdit2.Text = "";
            memoEdit1.Text = "";
            textEdit5.Text = "";
            textEdit6.Text = "";
            textEdit7.Text = "";
            textEdit8.Text = "";
            textEdit9.Text = "";
            textEdit10.Text = "";
            textEdit11.Text = "";
            textEdit12.Text = "";
            GETKOD();
        }
        private void labelControl12_Click(object sender, EventArgs e)
        {

        }

        private void textEdit15_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void TECHİZATCİ_Load(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            dateEdit1.Text = dateTime.ToString("dd/MM/yyyy");
            GETKOD();
            lookupedittextxhange_main();
            label1.Text = "0";

            textEdit14.Enabled = false;
            //textEdit14.TabIndex = 1;
            textEdit15.TabIndex = 1;
            buttonEdit1.TabIndex = 2;
            textEdit1.TabIndex = 3;
            textEdit13.TabIndex = 4;
            textEdit2.TabIndex = 5;
            textEdit3.TabIndex = 6;
            //textEdit16.TabIndex = 7;
            textEdit17.TabIndex = 8;
            textEdit4.TabIndex = 9;
            lookUpEdit1.TabIndex = 10;
            textEdit12.TabIndex = 11;
            memoEdit1.TabIndex = 12;
            textEdit5.TabIndex = 13;
            textEdit6.TabIndex = 14;
            textEdit7.TabIndex = 15;
            textEdit8.TabIndex = 16;
            textEdit9.TabIndex = 17;
            textEdit10.TabIndex = 18;
            textEdit11.TabIndex = 19;



        }
        private void lookupedittextxhange_main()
        {
            //int id = Convert.ToInt32(lookUpEdit1.EditValue.ToString());

            //if (id > 0)
            //{



                string strQuery = "select * from BORC_TEYINATI";

                SqlCommand cmd = new SqlCommand(strQuery);

               

                DataTable dt = GetData(cmd);


            

                lookUpEdit1.Properties.DisplayMember = "BORC_TEYINATI";
                lookUpEdit1.Properties.ValueMember = "BORC_TEYINATI_ID";
                lookUpEdit1.Properties.DataSource = dt;
                lookUpEdit1.Properties.NullText = "BORC TƏYİNATINI SEÇİN";
                lookUpEdit1.Properties.PopulateColumns();
                lookUpEdit1.Properties.Columns[0].Visible = false;


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

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (
    string.IsNullOrEmpty(dateEdit1.Text)
   || string.IsNullOrEmpty(textEdit1.Text) ||
    string.IsNullOrEmpty(textEdit3.Text) //|| string.IsNullOrEmpty(textEdit12.Text)  

    )
            {
                XtraMessageBox.Show("MƏLUMATLAR TAM OLARAQ DOLDURULMALIDIR");
            }
            else
            {
                if (Convert.ToInt32(label1.Text) > 0)
                {
                    //update();
                }
                else
                {
                    Insert();
                }
            }
        }

        private void Insert()
        {
            string TECHIZATCI_NOMRE = textEdit14.Text.ToString();
            string MUGAVİLE_NOM = textEdit15.Text.ToString();
            string SIRKET_ADI = textEdit1.Text.ToString();
            string TECHIZATCI_VOEN = textEdit13.Text.ToString();
            string UNVAN = textEdit2.Text.ToString();
            string ELAGE_NOMRE = textEdit3.Text.ToString();
            string ELEKTRON_POCT= textEdit4.Text.ToString();
            decimal ILKIN_BORC;
            int SAHIBKAR_TECHIZATCI;
           
            string HESAB_AD = textEdit5.Text.ToString();
            string BANK_ADI = textEdit6.Text.ToString();
            string BANK_VOEN = textEdit7.Text.ToString();
            string KOD = textEdit8.Text.ToString();
            string MH = textEdit9.Text.ToString();
            string SWIFT = textEdit10.Text.ToString();
            string MESUL_SEXS = textEdit11.Text.ToString();

            string DESCRIPTION = memoEdit1.Text.ToString();

           string ELAGE_NOM3 = "";  //textEdit16.Text.ToString();
            string ELAGE_NOM2 = textEdit17.Text.ToString();
            int aa = 0;
            if (string.IsNullOrEmpty(textEdit12.Text))
            {
                ILKIN_BORC = 0;
            }
            else
            {
                 ILKIN_BORC = Convert.ToDecimal(textEdit12.Text.ToString());
            }

           
            if (lookUpEdit1.Text== "BORC TƏYİNATINI SEÇİN")
            {
                SAHIBKAR_TECHIZATCI = 0;
            }
            else
            {
                SAHIBKAR_TECHIZATCI = Convert.ToInt32(lookUpEdit1.EditValue.ToString());
            }
            int a = ct.InsertTechizatci(TECHIZATCI_NOMRE, MUGAVİLE_NOM, SIRKET_ADI, UNVAN, ELAGE_NOMRE, ELEKTRON_POCT, ILKIN_BORC, SAHIBKAR_TECHIZATCI,
                TECHIZATCI_VOEN, HESAB_AD, BANK_ADI, BANK_VOEN, KOD, MH, SWIFT, MESUL_SEXS, DESCRIPTION, ELAGE_NOM2, ELAGE_NOM3);
            if (a == 0)
            {
                XtraMessageBox.Show("ƏLAVƏ ETMƏK İSTƏDİYNİZ TƏCHİZATÇI ADI ARTIQ MÖVCUDDUR");


                //clear();

            }
            if (a == 1)
            {
                XtraMessageBox.Show("MƏLUMATLARINIZ UĞURLA ƏLAVƏ EDİLDİ");

                //clear();
                CLEAR();
            }
            else
            {
              //   XtraMessageBox.Show("Ugrusuz");
            }

        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            SearchTechizatci fr = new SearchTechizatci();
            //fr.MdiParent = this;
            fr.Show();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
   

   
}
