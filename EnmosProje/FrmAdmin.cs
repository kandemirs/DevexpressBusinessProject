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
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


      

        //private void BtnGirisYap_Click(object sender, EventArgs e)
        //{
        //    SqlCommand komut = new SqlCommand("Select UserMail,UserPassword From Calisanlar where UserMail=@p1 and UserPassword=@p2", bgl.baglanti());
        //    komut.Parameters.AddWithValue("@p1", TxtKullaniciAdi.Text);
        //    komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
        //    SqlDataReader dr = komut.ExecuteReader();
        //    if (dr.Read()) {

        //        /veri tabanına kaydetme işelemi 
        //        SqlCommand komut2 = new SqlCommand("insert into Giris(Mail)values (@p3)", bgl.baglanti());
        //        komut2.Parameters.AddWithValue("@p3", TxtKullaniciAdi.Text);                             
        //        komut2.ExecuteNonQuery();


        //        FrmAnamodul fr = new FrmAnamodul();
        //        fr.Show();
        //        this.Hide();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Hatalı kullanıcı adı ya da şifre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        //    }
        //    bgl.baglanti().Close();
        //}


        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select UserMail,Password From LogIn where UserMail=@p1 and Password=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {

                ///veri tabanına kaydetme işelemi 
                SqlCommand komut2 = new SqlCommand("insert into Giris_db(Mail,Lastlogin)values (@p3,@p4)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p3", TxtKullaniciAdi.Text);
                komut2.Parameters.AddWithValue("@p4", DateTime.Now.ToString());
                komut2.ExecuteNonQuery();


                FrmHasModul fr = new FrmHasModul();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı ya da şifre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            bgl.baglanti().Close();
        }
    }
}
