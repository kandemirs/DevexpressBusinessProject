using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EnmosProje
{
    public partial class FrmAnamodul : Form
    {

        sqlbaglantisi bgl = new sqlbaglantisi();

        public string getmailadress()
        {
            string LastLogin = null;
            using (SqlCommand komut = new SqlCommand("SELECT TOP 1 Mail FROM Giris_db WHERE Mail IS NOT NULL ORDER BY ID DESC ", bgl.baglanti()))
            {
                //Giriş yapılan mail adresinin veri tabanından çekilmesi
                LastLogin = (string)komut.ExecuteScalar();
            }

            return LastLogin;

        }

        public FrmAnamodul()
        {
            InitializeComponent();
        }


        FrmEnmos fr2;
        private void BtnEnmos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null || fr2.IsDisposed)
            {
                fr2 = new FrmEnmos();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }
        FrmRehber fr5;
        private void BtnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr5 == null || fr5.IsDisposed)
            {
                fr5 = new FrmRehber();
                fr5.MdiParent = this;
                fr5.Show();
            }
        }
        FrmAyarlar fr6;
        private void BtnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new FrmAyarlar();
                fr6.MdiParent = this;
                fr6.Show();
            }
        }
        FrmGorevlerim fr7;
        private void BtnGeziler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7 == null || fr7.IsDisposed)
            {
                fr7 = new FrmGorevlerim();
                fr7.MdiParent = this;
                fr7.Show();
            }

        }


        FrmBusinessAnalysis fr8;

     
    private void BtnMuzikler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr8 == null || fr8.IsDisposed)
            {
                fr8 = new FrmBusinessAnalysis();
                fr8.MdiParent = this;
                fr8.Show();
            }

        }


        FrmYeniTalep fr10;
        private void BtnKemal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr10 == null || fr10.IsDisposed)
            {
                fr10 = new FrmYeniTalep();
                fr10.MdiParent = this;
                fr10.Show();
            }
        }


        FrmRequests fr11;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr11 == null || fr11.IsDisposed)
            {
                fr11 = new FrmRequests();
                fr11.MdiParent = this;
                fr11.Show();
            }
        }

        void UserSettings()
        {
            if (getmailadress() != "admin")
            {
                //BtnRequests.Enabled = false;
                BtnRequests.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                BtnAyarlar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


            }
            else
            {
                //BtnRequests.Enabled = true;
                BtnRequests.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                BtnAyarlar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }
        
        private void FrmAnamodul_Load(object sender, EventArgs e)
        {

            UserSettings();
           
        }


        FrmHomePage fr12;
        private void BtnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr12 == null || fr12.IsDisposed)
            {
                fr12 = new FrmHomePage();
                fr12.MdiParent = this;
                fr12.Show();
            }
        }
    }
}
