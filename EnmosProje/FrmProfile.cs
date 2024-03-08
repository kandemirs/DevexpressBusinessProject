using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace EnmosProje
{

   
    public partial class FrmProfile : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public FrmProfile()
        {
            InitializeComponent();
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

        public string getPositionName(string id)
        {
            string PositionName = null;
            using (SqlCommand komut = new SqlCommand("SELECT Name FROM Position WHERE Id=@p1", bgl.baglanti()))
            {
                komut.Parameters.AddWithValue("@p1", id);
                PositionName = (string)komut.ExecuteScalar();
            }
            return PositionName;
        }

        public string getDepartmentName(string id)
        {
            string DepartmentName = null;
            using (SqlCommand komut = new SqlCommand("SELECT Name FROM Department WHERE Id=@p1", bgl.baglanti()))
            {
                komut.Parameters.AddWithValue("@p1", id);
                DepartmentName = (string)komut.ExecuteScalar();
            }
            return DepartmentName;
        }
        private void FrmProfile_Load(object sender, EventArgs e)
        {
            informations();
        }


        void informations()
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("Select UserId,Picture,UserAd,UserSoyad,UserPositionId,UserMail,UserTelefon,UserYil,UserAdres,UserDepartmentId,UserMaas From Calisanlar WHERE UserMail=@p1", bgl.baglanti()))
            {
                cmd.Parameters.AddWithValue("@p1", getmailadress().ToString());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            
            DataRow Row;
            Row = dt.Rows[0];
            byte[] MyImg = (byte[])Row[1];
            // label1.Text = (string)Row[0];
            MemoryStream ms = new MemoryStream(MyImg);
            ms.Position = 0;
            Image img = Image.FromStream(ms);
            pictureBox1.Image = img;

            LblName.Text = dt.Rows[0]["UserAd"].ToString() + " " + dt.Rows[0]["UserSoyad"].ToString();

            LblMail.Text = dt.Rows[0]["UserMail"].ToString();
            LblTel.Text = dt.Rows[0]["UserTelefon"].ToString();
            LblAdress.Text = dt.Rows[0]["UserAdres"].ToString();

            LblDepartment.Text = getDepartmentName(dt.Rows[0]["UserDepartmentId"].ToString());
            LblPosition.Text = getPositionName(dt.Rows[0]["UserPositionId"].ToString());
            LblSalary.Text = dt.Rows[0]["UserMaas"].ToString();

            bgl.baglanti().Close();

        }

      



        //private void Bas_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog opf = new OpenFileDialog();

        //    if (opf.ShowDialog() == DialogResult.OK)
        //    {
        //        Image img = Image.FromFile(opf.FileName);
        //        byte[] imageData;

        //        using (MemoryStream tmpStream = new MemoryStream())
        //        {
        //            img.Save(tmpStream, System.Drawing.Imaging.ImageFormat.Png); // Formatı değiştirebilirsiniz
        //            imageData = tmpStream.ToArray();
        //        }

        //        SqlCommand komut = new SqlCommand("insert into ResimDeneme (Pic)values (@p1)", bgl.baglanti());
        //        komut.Parameters.Add("@p1", SqlDbType.VarBinary, -1).Value = imageData;
        //        komut.ExecuteNonQuery();
        //        bgl.baglanti().Close();

        //        //MemoryStream ms = new MemoryStream(imageData);
        //        //ms.Position = 0;
        //        //Image imgi = Image.FromStream(ms);
        //        //pictureBox1.Image = imgi;

        //    }


        //}

        //private void Yükle_Click(object sender, EventArgs e)
        //{
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter("Select Id,Pic From ResimDeneme WHERE Id=9", bgl.baglanti());
        //    da.Fill(dt);
        //    DataRow Row;
        //    Row = dt.Rows[0];
        //    byte[] MyImg = (byte[])Row[1];
        //    // label1.Text = (string)Row[0];
        //    MemoryStream ms = new MemoryStream(MyImg);
        //    ms.Position = 0;
        //    Image img = Image.FromStream(ms);
        //    pictureBox1.Image = img;
        //    bgl.baglanti().Close();

        //}
    }
}
