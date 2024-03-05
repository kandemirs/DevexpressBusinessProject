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
    public partial class FrmHomePage : Form
    {
        public FrmHomePage()
        {
            InitializeComponent();
        }


        sqlbaglantisi bgl = new sqlbaglantisi();

        void informations()
        {
            string Lastlogin =  getmailadress();

            if (Lastlogin != "admin")
            {
                SqlCommand da = new SqlCommand("Select UserAd From Calisanlar WHERE (UserMail = @Maile)", bgl.baglanti());
                da.Parameters.AddWithValue("@Maile", Lastlogin);

                string Name = (string)da.ExecuteScalar();
                LblHello.Text = "Hello " + Name + " (::";

                bgl.baglanti().Close();
            }

        }

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
        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {

            string Lastlogin = getmailadress();

            LblTime.Text = DateTime.Now.ToString();


            if (Lastlogin != "admin")
            {
                sayac++;
                if (sayac > 0 && sayac <= 5)
                {

                    SqlCommand dal = new SqlCommand("Select UserPosition From Calisanlar WHERE (UserMail = @Maile)", bgl.baglanti());
                    dal.Parameters.AddWithValue("@Maile", Lastlogin);

                    string Na = (string)dal.ExecuteScalar();
                    LblDepOrPos.Text = "-" + Na;

                    bgl.baglanti().Close();
                }
                if (sayac > 4 && sayac <= 10)
                {

                    SqlCommand dal = new SqlCommand("Select UserDepartman From Calisanlar WHERE (UserMail = @Maile)", bgl.baglanti());
                    dal.Parameters.AddWithValue("@Maile", Lastlogin);

                    string Na = (string)dal.ExecuteScalar();
                    LblDepOrPos.Text = "-" + Na;

                    bgl.baglanti().Close();
                }

                if (sayac == 11)
                {
                    sayac = 0;
                }
            }
        }

        private void FrmHomePage_Load(object sender, EventArgs e)
        {
            informations();

            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");

        }
    }
}
