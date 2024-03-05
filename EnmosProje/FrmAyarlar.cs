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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select UserMail,Password From LogIn", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            listele();

        }

     

        private void BtnUpdate_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into LogIn (UserMail,Password) values (@p1,@p2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtUserName.Text);
            komut.Parameters.AddWithValue("@p2", TxtPassword.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();

            SqlCommand komut2 = new SqlCommand("insert into Calisanlar (UserMail) values (@p3)", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p3", TxtUserName.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Yeni çalışan sisteme kayıt edildi.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();


        }
    }
}
