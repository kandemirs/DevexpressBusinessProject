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

    
    public partial class FrmChangePassword : Form
    {
        public FrmChangePassword()
        {
            InitializeComponent();
        }
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

        private void button1_Click(object sender, EventArgs e)
        {
            string mail = getmailadress();
            SqlCommand komut = new SqlCommand("Select UserMail,Password From LogIn where UserMail=@p1 and Password=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mail);
            komut.Parameters.AddWithValue("@p2", TxtCurrentPassword.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {

                if(TxtNew.Text == TxtNewAgain.Text)
                {
                //veri tabanına kaydetme işelemi 
                    SqlCommand komut2 = new SqlCommand("update LogIn set Password=@p1 where UserMail=@p9", bgl.baglanti());
                    komut2.Parameters.AddWithValue("@p1", TxtNew.Text);
                    komut2.Parameters.Add("@p9", mail);
                    komut2.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Password Changed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    MessageBox.Show("Passwords don't match.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                
            }
            else
            {
                MessageBox.Show("Current Password WRONG.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            bgl.baglanti().Close();
        }

     
    }
}
