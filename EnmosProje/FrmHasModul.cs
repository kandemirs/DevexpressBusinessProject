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
using System.Diagnostics;
using System.IO;

namespace EnmosProje
{
    public partial class FrmHasModul : Form
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

        public DateTime getLastLoginMail()
        {
            DateTime LastloginTime = DateTime.MinValue;
            using (SqlCommand komut = new SqlCommand("SELECT TOP 1 LastLoginTime FROM Giris_db WHERE Id IN(SELECT TOP 2 Id FROM Giris_db WHERE Mail IS NOT NULL ORDER BY ID DESC) order by Id ASC", bgl.baglanti()))
            {
                LastloginTime = (DateTime)komut.ExecuteScalar();

            }
            return LastloginTime;
        }

        public FrmHasModul()
        {
            InitializeComponent();
        }


        FrmGorevlerim fr7;
        private void BtnAssignments_Click(object sender, EventArgs e)
        {
            if (fr7 == null || fr7.IsDisposed)
            {
                fr7 = new FrmGorevlerim();
                fr7.Show();
            }
        }

        FrmYeniTalep fr10;
        private void BtnNewJob_Click(object sender, EventArgs e)
        {
            if (fr10 == null || fr10.IsDisposed)
            {

                fr10 = new FrmYeniTalep();
                fr10.Show();
            }
        }

        FrmEnmos fr2;
        private void BtnEnmosEmployees_Click(object sender, EventArgs e)
        {

            if (fr2 == null || fr2.IsDisposed)
            {
                fr2 = new FrmEnmos();
                fr2.Show();
            }
        }

        FrmBusinessAnalysis fr8;
        private void BtnBusinessAnalysis_Click(object sender, EventArgs e)
        {
            if (fr8 == null || fr8.IsDisposed)
            {
                fr8 = new FrmBusinessAnalysis();
                fr8.Show();
            }
        }

        FrmRehber fr5;
        private void BtnMail_Click(object sender, EventArgs e)
        {

            if (fr5 == null || fr5.IsDisposed)
            {
                fr5 = new FrmRehber();
                fr5.Show();
            }
        }
        
        FrmRequests fr11;
        private void BtnRequests_Click_1(object sender, EventArgs e)
        {
            if (fr11 == null || fr11.IsDisposed)
            {

                fr11 = new FrmRequests();
                fr11.Show();
            }
        }
        FrmAyarlar fr6;
        private void BtnAddEmployee_Click_1(object sender, EventArgs e)
        {
            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new FrmAyarlar();
                fr6.Show();
            }
        }
        void usersettings()
        {
            if (getmailadress() != "admin")
            {
                //BtnRequests.enabled = false;
                BtnRequests.Visible = false;
                BtnAddEmployee.Visible = false;
                BtnAddIdentity.Visible = false;
                BtnExit.Visible = true;
                BtnChangePassword.Visible = true;


            }
            else
            {
                //BtnRequests.enabled = true;
                BtnRequests.Visible = true;
                BtnAddEmployee.Visible = true;
                BtnAddIdentity.Visible = true;
                BtnExit.Visible = false;
                BtnChangePassword.Visible = false;

            }
        }

        private void FrmHasModul_Load(object sender, EventArgs e)
        {
            usersettings();
            informations();
        }
        void informations()
        {
            string Lastlogin = getmailadress(); 
            string timeasastring = getLastLoginMail().ToString("yyyy-MM-dd HH:mm:ss");  //Bir önceki giriş tarihi 
            LblLastLogin.Text = timeasastring;


            if (Lastlogin != "admin")
            {
                SqlCommand da = new SqlCommand("Select UserAd,Picture From Calisanlar WHERE (UserMail = @Maile)", bgl.baglanti());
                da.Parameters.AddWithValue("@Maile", Lastlogin);

                SqlDataReader reader = da.ExecuteReader();
                if (reader.Read())
                {

                    string name = reader.GetString(0); // veya reader["UserAd"].ToString();
                    LblHello.Text = "Hello " + name + " (::";

                    if (!reader.IsDBNull(1)) // Veri null değilse
                    {
                        byte[] MyImg = (byte[])reader["Picture"];
                        MemoryStream ms = new MemoryStream(MyImg);
                        ms.Position = 0;
                        Image img = Image.FromStream(ms);
                        pictureBox2.Image = img;
                    }
                    else
                    {
                        // Picture alanı null olduğunda buraya gelebilirsiniz
                        // Örneğin bir varsayılan resim kullanabilirsiniz.
                        pictureBox2.Image = null;
                    }

                }
                else
                {
                    LblHello.Text = "Hello User";
                }

                reader.Close();
                bgl.baglanti().Close();


            }

        }

        FrmExchange frEx;
        private void BtnPerformance_Click(object sender, EventArgs e)


        {
            if (frEx == null || frEx.IsDisposed)
            {
                frEx = new FrmExchange();
                frEx.Show();
            }
        }
      
        int sayac = 0;
        private void Timer1_Tick_1(object sender, EventArgs e)
        {
            string Lastlogin = getmailadress();

            LblTime.Text = DateTime.Now.ToString();
            LabelDay.Text = DateTime.Now.DayOfWeek.ToString();


            //if (Lastlogin != "admin")
            //{
            //    sayac++;
            //    if (sayac > 0 && sayac <= 5)
            //    {

            //        SqlCommand dal = new SqlCommand("Select UserPosition From Calisanlar WHERE (UserMail = @Maile)", bgl.baglanti());
            //        dal.Parameters.AddWithValue("@Maile", Lastlogin);

            //        string Na = (string)dal.ExecuteScalar();
            //        LblDepOrPos.Text = "-" + Na;

            //        bgl.baglanti().Close();
            //    }
            //    if (sayac > 4 && sayac <= 10)
            //    {

            //        SqlCommand dal = new SqlCommand("Select UserDepartman From Calisanlar WHERE (UserMail = @Maile)", bgl.baglanti());
            //        dal.Parameters.AddWithValue("@Maile", Lastlogin);

            //        string Na = (string)dal.ExecuteScalar();
            //        LblDepOrPos.Text = "-" + Na;

            //        bgl.baglanti().Close();
            //    }

            //    if (sayac == 11)
            //    {
            //        sayac = 0;
            //    }
            //}
        }
        FrmAddIdentity frIdentity;
        private void BtnAddIdentity_Click(object sender, EventArgs e)
        {
            if (frIdentity == null || frIdentity.IsDisposed)
            {
                frIdentity = new FrmAddIdentity();
                frIdentity.Show();
            }
        }
        FrmProfile frProfile;
        private void BtnExit_Click(object sender, EventArgs e)
        {
            if (frProfile == null || frProfile.IsDisposed)
            {
                frProfile = new FrmProfile();
                frProfile.Show();
            }
        }
        FrmAdmin frr;
        private void BtnProfile_Click(object sender, EventArgs e)
        {
            if (frProfile != null && !frProfile.IsDisposed)
            {
                frProfile.Close();
            }

            if (frIdentity != null && !frIdentity.IsDisposed)
            {
                frIdentity.Close();
            }
            if (frEx != null && !frEx.IsDisposed)
            {
                frEx.Close();
            }
            if (fr6 != null && !fr6.IsDisposed)
            {
                fr6.Close();
            }

            if (fr11 != null && !fr11.IsDisposed)
            {
                fr11.Close();

            }
            if (fr8 != null && !fr8.IsDisposed)
            {
                fr8.Close();
            }
            if (fr5 != null && !fr5.IsDisposed)
            {
                fr5.Close();
            }
            if (fr2 != null && !fr2.IsDisposed)
            {
                fr2.Close();
            }
            if (fr10 != null && !fr10.IsDisposed)
            {
                fr10.Close();
            }
            if (fr7 != null && !fr7.IsDisposed)
            {
                fr7.Close();
            }
            if (frPassword != null && !frPassword.IsDisposed)
            {
                frPassword.Close();
            }


            if (frr == null || frr.IsDisposed)
            {
                frr = new FrmAdmin();
                frr.Show();
            }
            this.Hide();

        }


        private void BtnCalculator_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }
        FrmChangePassword frPassword;
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (frPassword == null || frPassword.IsDisposed)
            {
                frPassword = new FrmChangePassword();
                frPassword.Show();
            }
        }

        FrmMail frmai;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (frmai == null || frmai.IsDisposed)
            {
                frmai = new FrmMail();
                frmai.Show();
            }
        }

        
    }
}
