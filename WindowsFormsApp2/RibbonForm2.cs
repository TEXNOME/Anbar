using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;
using DevExpress.XtraEditors;
using System.Runtime.Remoting.Messaging;
using System.Runtime.InteropServices.WindowsRuntime;
using DevExpress.XtraLayout.Filtering.Templates;
using DevExpress.XtraSplashScreen;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;


namespace WindowsFormsApp2
{
    public partial class RibbonForm2 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static byte[] picture_edit_value = null;

        CrudSirket cs = new CrudSirket();
        public RibbonForm2()
        {
            InitializeComponent();
            buttonEdit1.Visible = false;
        }

        private void RibbonForm2_Load(object sender, EventArgs e)
        {
            //gridControl1.DisplayLayout.GroupByBox.Prompt = "Custom text";
            GetAll();
            int a = countsirket();
            if (a > 0)
            {
                ribbonPageGroup1.Visible = false;
                groupControl1.Enabled = false;
                groupControl2.Enabled = false;
                buttonEdit1.Enabled = false;
            }
            else
            {
                ribbonPageGroup1.Visible = true;
                groupControl1.Enabled = true;
                groupControl2.Enabled = true;
                buttonEdit1.Enabled = true;
            }
            textEdit1.TabIndex = 1;
            textEdit12.TabIndex = 2;
            textEdit13.TabIndex = 3;
            textEdit2.TabIndex = 4;
            textEdit3.TabIndex = 5;
            textEdit14.TabIndex = 6;
            textEdit4.TabIndex = 7;
            textEdit11.TabIndex = 8;
            textEdit5.TabIndex = 9;
            textEdit6.TabIndex = 10;
            textEdit7.TabIndex = 11;
            textEdit8.TabIndex = 12;
            textEdit9.TabIndex = 13;
            textEdit10.TabIndex = 14;
            dateEdit1.TabIndex = 15;
          

        }


        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty( buttonEdit1.Text))
            {

            }
            else
            {
             //   MemoryStream stream = new MemoryStream();
             //pictureEdit1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
             //   byte[] pic = stream.ToArray();
             //   picture_edit_value = pic;
            }
        }
        int cnt;
        string qa = "select count(*) from COMPANY.COMPANY";
        private int countsirket()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon))
            {

                SqlCommand command = new SqlCommand(qa, connection);


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        cnt = Convert.ToInt32(reader[0]);
                       

                    }
                    reader.Close();

                   
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                    XtraMessageBox.Show(ex.Message);
                }
            }
            return cnt;
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //string t = textEdit9.Text.Trim();
            //XtraMessageBox.Show(t);

            if (
    //  pictureEdit1.Image == null ||
      string.IsNullOrEmpty(textEdit1.Text) ||
       //string.IsNullOrEmpty(textEdit12.Text) || string.IsNullOrEmpty(textEdit13.Text) ||
          string.IsNullOrEmpty(textEdit2.Text) || string.IsNullOrEmpty(textEdit3.Text) ||
          string.IsNullOrEmpty(textEdit4.Text) ||
           string.IsNullOrEmpty(dateEdit1.Text)
      )
            {
                XtraMessageBox.Show("Məlumatlar Tam Olaraq Doldurulmalıdır !");
            }

            else
            {

                //    MemoryStream stream = new MemoryStream();
                //pictureEdit1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                //byte[] pic = "";//stream.ToArray();
                string COMPANY_NAME = textEdit1.Text.ToString();
                string adres = textEdit2.Text.ToString();
                string telefon = textEdit3.Text.ToString();
                string emaill = textEdit4.Text.ToString();
                string hesabnom = textEdit5.Text.ToString();
                string bankadi = textEdit6.Text.ToString();
                string voen = textEdit7.Text.ToString();
                string kod = textEdit8.Text.ToString();
                string c = textEdit9.Text.Trim();
                string f = textEdit10.Text.ToString();
                string mesulsexs = textEdit11.Text.ToString();
                DateTime start_date = Convert.ToDateTime(dateEdit1.Text.ToString());

                string sirket_voen = textEdit12.Text.ToString();
                string sirket_kod = textEdit13.Text.ToString();
                string web_sayt = textEdit14.Text.ToString();


                try
                {
                    int a =
                     cs.InsertCompany
                     (COMPANY_NAME, adres, telefon, emaill, hesabnom, bankadi, voen, kod, c, f, mesulsexs,start_date,sirket_voen,sirket_kod,web_sayt);
                    if (a == 0)
                    {
                        XtraMessageBox.Show("MƏLUMATLAR PROQRAMDA ARTIQ MÖVCUDDUR");

                      
                        //clear();

                    }
                    if (a > 0)
                    {
                        XtraMessageBox.Show("Məlumatlarınız uğurla daxil edildi");

                        //clear();
                        ribbonPageGroup1.Visible = false;
                        groupControl1.Enabled = false;
                        groupControl2.Enabled = false;
                        buttonEdit1.Enabled = false;
                    }
                    else
                    {
                        XtraMessageBox.Show("Ugrusuz");
                    }
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("sehv");
                }
                //Console.ReadKey();
            }
        }

        private void labelControl12_Click(object sender, EventArgs e)
        {

        }

        private void labelControl11_Click(object sender, EventArgs e)
        {

        }

        private void labelControl10_Click(object sender, EventArgs e)
        {

        }


        public static byte[] ConvertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        string queryString =
                "select * from dbo.fn_company()";
       // string co = "Data Source=.;Initial Catalog=NewInteko;Integrated Security=True";
        string countsir = "select count (*) from COMPANY.COMPANY";
        private void GetAll()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SqlCon))
            {

                SqlCommand command = new SqlCommand(queryString, connection);


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {


                        textEdit1.Text = reader[1].ToString();
                        textEdit2.Text = reader[2].ToString();
                        textEdit3.Text = reader[3].ToString();
                        textEdit4.Text = reader[4].ToString();
                        textEdit5.Text = reader[5].ToString();
                        textEdit6.Text = reader[6].ToString();
                        textEdit7.Text = reader[7].ToString();
                        textEdit8.Text = reader[8].ToString();
                        textEdit9.Text = reader[9].ToString();
                        textEdit10.Text = reader[10].ToString();
                        textEdit11.Text = reader[11].ToString();
                        dateEdit1.Text = reader[13].ToString();
                        textEdit12.Text = reader[14].ToString();
                        textEdit13.Text = reader[15].ToString();
                        textEdit14.Text = reader[16].ToString();//VOEN 

                        //byte[] ima = (byte[])reader[12];          //sekil
                        //MemoryStream ms = new MemoryStream(ima);
                        //pictureEdit1.Image = Image.FromStream(ms);
                        //picture_edit_value = ima;

                        //ms.Close();

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

        private void textEdit1_Validated(object sender, EventArgs e)
        {
            
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ribbonStatusBar_Click(object sender, EventArgs e)
        {

        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit12_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}



    












    
