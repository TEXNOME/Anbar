using DevExpress.XtraBars;
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

namespace WindowsFormsApp2
{
    public partial class RibbonForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonForm1()
        {
            InitializeComponent();
            ButtDisable();

            avtorizasiya av = new avtorizasiya();
            av.Owner = this;
            av.Show();

        }

        public void UserLogin()
        {
            barButtonItem1.Enabled = true;
            barButtonItem2.Enabled = true;
            barButtonItem3.Enabled = true;
            barButtonItem4.Enabled = true;
            barButtonItem14.Enabled = true;
            barButtonItem23.Enabled = true;
            barButtonItem24.Enabled = true;

            barSubItem1.Enabled = true;
            barSubItem2.Enabled = true;
            barSubItem3.Enabled = true;
            barSubItem4.Enabled = true;
            barSubItem5.Enabled = true;
            barSubItem6.Enabled = true;
            barSubItem7.Enabled = true;

            if (admin_control.check)
            {
                barButtonItem44.Enabled = true;
            }


        }

        public void ButtDisable()
        {
           
            barButtonItem1.Enabled = false;
            barButtonItem2.Enabled = false;
            barButtonItem3.Enabled = false;
            barButtonItem4.Enabled = false;
            barButtonItem14.Enabled =false;
            barButtonItem23.Enabled =false;
            barButtonItem24.Enabled =false;
            barButtonItem44.Enabled =false;
            barSubItem1.Enabled = false;
            barSubItem2.Enabled = false;
            barSubItem4.Enabled = false;
            barSubItem5.Enabled = false;
            barSubItem6.Enabled = false;
            barSubItem7.Enabled = false;
        }


       RibbonForm2 fr;
        private void barButtonItem1_ItemClick(object sender, EventArgs e)
        {
            //    this.Hide();


            if (Application.OpenForms["RibbonForm2"] != null)
            {
                var Main = Application.OpenForms["RibbonForm2"] as RibbonForm2;
                if (Main != null)
                {

                }
                   // Main.Close();
            }
            else
            {
                fr = new RibbonForm2();
                fr.Show();
            }




        }

        Magaza m;
        private void barButtonItem2_ItemClick(object sender, EventArgs e)
        {

            if (Application.OpenForms["Magaza"] != null)
            {
                var Main = Application.OpenForms["Magaza"] as Magaza;
                if (Main != null)
                {

                }
                // Main.Close();
            }
            else
            {
                m = new Magaza();
                m.Show();
            }

        }

        Anbar a;
        private void barButtonItem3_ItemClick(object sender, EventArgs e)
        {
            if (Application.OpenForms["Anbar"] != null)
            {
                var Main = Application.OpenForms["Anbar"] as Anbar;
                if (Main != null)
                {

                }
                //    Main.Close();
            }
            else
            {
                a = new Anbar();
                a.Show();
            }
        }

        TECHİZATCİ frt;
        private void barButtonItem4_ItemClick(object sender, EventArgs e)
        {
            if (Application.OpenForms["TECHİZATCİ"] != null)
            {
                var Main = Application.OpenForms["TECHİZATCİ"] as TECHİZATCİ;
                if (Main != null)
                {

                }
                  //  Main.Close();
            }
            else
            {
                frt = new TECHİZATCİ();
                frt.Show();
            }

        }

        

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        MEHSUL_ALISI_LAYOUT MA;
        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Application.OpenForms["MEHSUL_ALISI_LAYOUT"] != null)
            {
                var Main = Application.OpenForms["MEHSUL_ALISI_LAYOUT"] as MEHSUL_ALİSİ;
                if (Main != null)
                {
                    //
                }
                   // Main.Close();
            }
            else
            {
                MA = new MEHSUL_ALISI_LAYOUT();
                MA.Show();
            }
        }
       MEHSUL_GAYTARMA MG;
        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Application.OpenForms["MEHSUL_GAYTARMA"] != null)
            {
                var Main = Application.OpenForms["MEHSUL_GAYTARMA"] as MEHSUL_GAYTARMA;
                if (Main != null)
                {

                }
                  //  Main.Close();
            }
            else
            {
                MG = new MEHSUL_GAYTARMA();
                MG.Show();

            }
        }

        GAIME_SATISI_LAYOUT GS;
        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Application.OpenForms["GAIME_SATISI_LAYOUT"] != null)
            {
                var Main = Application.OpenForms["GAIME_SATISI_LAYOUT"] as GAIME_SATISI;
                if (Main != null)
                {

                }
                 //   Main.Close();
            }
            else
            {
                GS = new GAIME_SATISI_LAYOUT();
                GS.Show();

            }

        }

         GAIME_SATIS_GAYTARMA GST;
        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Application.OpenForms["GAIME_SATIS_GAYTARMA"] != null)
            {
                var Main = Application.OpenForms["GAIME_SATIS_GAYTARMA"] as GAIME_SATIS_GAYTARMA;
                if (Main != null)
                {

                }
                  //  Main.Close();
            }
            else
            {
                GST = new GAIME_SATIS_GAYTARMA();
                GST.Show();

            }


        }

        MÜŞTƏRİLƏR MS;
        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Application.OpenForms["MUSTERILER"] != null)
            {
                var Main = Application.OpenForms["MUSTERILER"] as MÜŞTƏRİLƏR;
                if (Main != null)
                {

                }
                // Main.Close();
            }
            else
            {
                MS = new MÜŞTƏRİLƏR();
                MS.Show();
            }
        }

       ANBARDAN_ANBARA AB;
        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Application.OpenForms["ANBARDAN_ANBARA"] != null)
            {
                var Main = Application.OpenForms["ANBARDAN_ANBARA"] as ANBARDAN_ANBARA;
                if (Main != null)
                {

                }
                  //  Main.Close();
            }
            else
            {
                AB = new ANBARDAN_ANBARA();
                AB.Show();

            }

        }

        private void barButtonItem22_ItemClick(object sender, ItemClickEventArgs e)
        {
            //TECHIZATCI_ODENISI TO = new TECHIZATCI_ODENISI();
            //TO.Show();
        }

         ANBARDAN_OBYEKTE AO;
        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Application.OpenForms["ANBARDAN_OBYEKTE"] != null)
            {
                var Main = Application.OpenForms["ANBARDAN_OBYEKTE"] as ANBARDAN_OBYEKTE;
                if (Main != null)
                {

                }
                 //   Main.Close();
            }
            else
            {
                AO = new ANBARDAN_OBYEKTE();
                AO.Show();

            }

        }

       OBYEKTDEN_ANBARA OAT;
        private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Application.OpenForms["OBYEKTDEN_ANBARA"] != null)
            {
                var Main = Application.OpenForms["OBYEKTDEN_ANBARA"] as OBYEKTDEN_ANBARA;
                if (Main != null)
                {

                }
                   // Main.Close();
            }
            else
            {
                OAT = new OBYEKTDEN_ANBARA();
                OAT.Show();

            }
        }
       POS p;
        private void barButtonItem23_ItemClick(object sender, EventArgs e)
        {
            if (Application.OpenForms["POS"] != null)
            {
                var Main = Application.OpenForms["POS"] as POS;
                if (Main != null)
                {

                }
                //    Main.Close();
            }
            else
            {
                p = new POS();
                p.Show();

            }
        }

        TENZIMLEME T;
        private void barButtonItem24_ItemClick(object sender, EventArgs e)
        {
            if (Application.OpenForms["TENZIMLEME"] != null)
            {
                var Main = Application.OpenForms["TENZIMLEME"] as TENZIMLEME;
                if (Main != null)
                {

                }
                  //  Main.Close();
            }
            else
            {
                T = new TENZIMLEME();
                T.Show();

            }

        }

       TECHIZATCI_ODENISI TO;
        private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Application.OpenForms["TECHIZATCI_ODENISI"] != null)
            {
                var Main = Application.OpenForms["TECHIZATCI_ODENISI"] as TECHIZATCI_ODENISI;
                if (Main != null)
                {

                }
                   // Main.Close();
            }
            else
            {
                TO = new TECHIZATCI_ODENISI();
                TO.Show();

            }
        }

        private void barButtonItem26_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraMessageBox.Show("Sistemdə bankla inteqrasiya mövcud deyildir.(Servis xidmətinə müraciət edin)");
            //BANK_ODENİS n = new BANK_ODENİS();
            //n.Show();
        }

        private void barButtonItem27_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem31_ItemClick(object sender, ItemClickEventArgs e)
        {
            SATIS_HESABATI S = new SATIS_HESABATI();
            S.Show();
        }

        
    }
}