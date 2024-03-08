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
using System.IO;

namespace EnmosProje
{
    public partial class FrmAddIdentity : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public FrmAddIdentity()
        {
            InitializeComponent();
        }

        private void FrmAddIdentity_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select UserAd,UserSoyad From Calisanlar", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbNames.Items.Add(dr[0] + " " + dr[1]);
            }
            bgl.baglanti().Close();
        }
        public int getnamefromgorev(string name)
        {

            int UserId = -1;
            using (SqlCommand getname = new SqlCommand("SELECT UserId FROM Calisanlar WHERE CONCAT(UserAd, ' ', UserSoyad)=@namedb ", bgl.baglanti()))
            {

                getname.Parameters.AddWithValue("@namedb", name);
                UserId = (int)getname.ExecuteScalar();
            }
            return UserId;

        }
        private void GetId_Click(object sender, EventArgs e)
        {

            if (CmbNames.Text == "")
            {
                MessageBox.Show("Please select the personel.","Add Personel Picture",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                
            }
            else
            {
                byte[] imageData;
          
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // Resmi PNG formatında kaydetmek istiyorsanız
                    imageData = ms.ToArray();
                }

                SqlCommand komut = new SqlCommand("UPDATE Calisanlar SET Picture = @p1 WHERE UserId = @p2", bgl.baglanti());
                komut.Parameters.Add("@p1", SqlDbType.VarBinary, -1).Value = imageData;
                komut.Parameters.AddWithValue("@p2", getnamefromgorev(CmbNames.Text).ToString());
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Profile Picture Succesfully Saved");

            }
          
        }

        private void BtnPickPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();

            if (opf.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(opf.FileName);
                byte[] imageData;

                using (MemoryStream tmpStream = new MemoryStream())
                {
                    img.Save(tmpStream, System.Drawing.Imaging.ImageFormat.Png); // Formatı değiştirebilirsiniz
                    imageData = tmpStream.ToArray();
                }

                MemoryStream ms = new MemoryStream(imageData);
                ms.Position = 0;
                Image imgi = Image.FromStream(ms);
                pictureBox1.Image = imgi;

            }
        }
    }
}
