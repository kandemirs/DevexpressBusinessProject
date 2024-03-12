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
using System.Globalization;


namespace EnmosProje
{
    public partial class FrmGorevlerim : Form
    {
        public FrmGorevlerim()
        {
            InitializeComponent();
        }


        

        sqlbaglantisi bgl = new sqlbaglantisi();


        void SetLabelColor(DataRow df)
        {
            if (df["Label"].ToString() == "Enhancement")
            {
                TxtLabel.ForeColor = Color.Red;
            }
            else if (df["Label"].ToString() == "Bug")
            {
                TxtLabel.ForeColor = Color.Blue;
            }
            else if (df["Label"].ToString() == "Duty")
            {
                TxtLabel.ForeColor = Color.Green;
            }
            else if (df["Label"].ToString() == "New Feature")
            {
                TxtLabel.ForeColor = Color.Pink;
            }
            else if (df["Label"].ToString() == "Support")
            {
                TxtLabel.ForeColor = Color.DarkGray;
            }
            else
            {
                TxtLabel.ForeColor = Color.Orange;
            }

        }

        void buttonProperty()
        {

            if (getmailadress() != "admin")
            {
            CmbAssignee.Enabled = false;
            CmbAssignee2.Enabled = false;
           // DtpDeadline.Enabled = false;
            MskDeadline.ReadOnly = true;
            TxtIs.ReadOnly = true;
            BtnGuncelle.Text = "Update Job Status";
            }
            else
            {

            CmbAssignee.Enabled = true;
            CmbAssignee2.Enabled = true;
            MskDeadline.ReadOnly = false;
            //DtpDeadline.Enabled = false;
            TxtIs.ReadOnly = false;
            BtnGuncelle.Text = "Update";
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

        void Assigneelist()
        {
            SqlCommand komut = new SqlCommand("Select CONCAT(UserAd, ' ', UserSoyad) AS AdSoyad From Calisanlar", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbAssignee.Items.Add(dr[0]);
                CmbAssignee2.Items.Add(dr[0]);
            }

        }


        void graphic_deign()
        {
            //chartcontrol1.series["series 1"].points.addpoint("istanbul", 4);
            //chartcontrol1.series["series 1"].points.addpoint("izmit", 5);

            string LastLoginMail = getmailadress();

            if(LastLoginMail != "admin")
            {

                SqlCommand da = new SqlCommand("Select g.GorevDurum,Count(g.Ad) From Gorevler g INNER JOIN Calisanlar c1 ON g.AtananCalisan = c1.UserId LEFT JOIN Calisanlar c2 ON g.AtananCalisan2 = c2.UserId WHERE (c2.UserMail = @Maile OR c1.UserMail = @Maile) group by g.GorevDurum ", bgl.baglanti());
                da.Parameters.AddWithValue("@Maile", LastLoginMail);
                SqlDataReader dr = da.ExecuteReader();
                chartControl1.Series["Series 1"].Points.Clear();
                while (dr.Read())
                {

                    chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));

                }
                bgl.baglanti().Close();





                SqlCommand dh = new SqlCommand("Select g.Label,COUNT(g.Ad) From Gorevler g INNER JOIN Calisanlar c1 ON g.AtananCalisan = c1.UserId LEFT JOIN Calisanlar c2 ON g.AtananCalisan2 = c2.UserId WHERE (c2.UserMail = @Maile OR c1.UserMail = @Maile) group by g.Label ", bgl.baglanti());
                dh.Parameters.AddWithValue("@Maile", LastLoginMail);
                SqlDataReader dg = dh.ExecuteReader();
                chartControl2.Series["Series 1"].Points.Clear();

                while (dg.Read())
                {

                    chartControl2.Series["Series 1"].Points.AddPoint(Convert.ToString(dg[0]), int.Parse(dg[1].ToString()));

                }

                bgl.baglanti().Close();





                SqlCommand dp = new SqlCommand("Select g.Completed,Count(g.Ad) From Gorevler g INNER JOIN Calisanlar c1 ON g.AtananCalisan = c1.UserId LEFT JOIN Calisanlar c2 ON g.AtananCalisan2 = c2.UserId WHERE (c2.UserMail = @Maile OR c1.UserMail = @Maile) group by g.Completed ", bgl.baglanti());
                dp.Parameters.AddWithValue("@Maile", LastLoginMail);
                SqlDataReader dt = dp.ExecuteReader();
                chartControl3.Series["Series 1"].Points.Clear();
                while (dt.Read())
                {

                    chartControl3.Series["Series 1"].Points.AddPoint(Convert.ToString(dt[0]), int.Parse(dt[1].ToString()));

                }
                bgl.baglanti().Close();





                SqlCommand dq = new SqlCommand("Select g.Completed,Count(g.Ad) From Gorevler g INNER JOIN Calisanlar c1 ON g.AtananCalisan = c1.UserId LEFT JOIN Calisanlar c2 ON g.AtananCalisan2 = c2.UserId WHERE (c2.UserMail = @Maile OR c1.UserMail = @Maile) group by g.Completed ", bgl.baglanti());
                dq.Parameters.AddWithValue("@Maile", LastLoginMail);
                SqlDataReader de = dq.ExecuteReader();
                chartControl4.Series["Series 1"].Points.Clear();
                while (de.Read())
                {

                    chartControl4.Series["Series 1"].Points.AddPoint(Convert.ToString(de[0]), int.Parse(de[1].ToString()));

                }
                bgl.baglanti().Close();

            }
            else
            {
                SqlCommand da = new SqlCommand("Select g.GorevDurum,Count(g.Ad) From Gorevler g INNER JOIN Calisanlar c1 ON g.AtananCalisan = c1.UserId LEFT JOIN Calisanlar c2 ON g.AtananCalisan2 = c2.UserId group by g.GorevDurum ", bgl.baglanti());
                SqlDataReader dr = da.ExecuteReader();
                chartControl1.Series["Series 1"].Points.Clear();
                while (dr.Read())
                {

                    chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));

                }
                bgl.baglanti().Close();





                SqlCommand dh = new SqlCommand("Select g.Label,COUNT(g.Ad) From Gorevler g INNER JOIN Calisanlar c1 ON g.AtananCalisan = c1.UserId LEFT JOIN Calisanlar c2 ON g.AtananCalisan2 = c2.UserId group by g.Label ", bgl.baglanti());
                SqlDataReader dg = dh.ExecuteReader();

                chartControl2.Series["Series 1"].Points.Clear();
                while (dg.Read())
                {

                    chartControl2.Series["Series 1"].Points.AddPoint(Convert.ToString(dg[0]), int.Parse(dg[1].ToString()));

                }

                bgl.baglanti().Close();





                SqlCommand dp = new SqlCommand("Select g.Completed,Count(g.Ad) From Gorevler g INNER JOIN Calisanlar c1 ON g.AtananCalisan = c1.UserId LEFT JOIN Calisanlar c2 ON g.AtananCalisan2 = c2.UserId group by g.Completed ", bgl.baglanti());
                SqlDataReader dt = dp.ExecuteReader();
                chartControl3.Series["Series 1"].Points.Clear();
                while (dt.Read())
                {

                    chartControl3.Series["Series 1"].Points.AddPoint(Convert.ToString(dt[0]), int.Parse(dt[1].ToString()));

                }
                bgl.baglanti().Close();





                SqlCommand dq = new SqlCommand("Select g.Completed,Count(g.Ad) From Gorevler g INNER JOIN Calisanlar c1 ON g.AtananCalisan = c1.UserId LEFT JOIN Calisanlar c2 ON g.AtananCalisan2 = c2.UserId group by g.Completed ", bgl.baglanti());
                SqlDataReader de = dq.ExecuteReader();
                chartControl4.Series["Series 1"].Points.Clear();
                while (de.Read())
                {

                    chartControl4.Series["Series 1"].Points.AddPoint(Convert.ToString(de[0]), int.Parse(de[1].ToString()));

                }
                bgl.baglanti().Close();
            }
        }
        void listele()
        {
            
            string LastLoginMail = getmailadress();

            
            if (LastLoginMail != "admin")
            {

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select CONCAT(c1.UserAd, ' ', c1.UserSoyad) AS AdSoyad1,CONCAT(c2.UserAd, ' ', c2.UserSoyad) AS AdSoyad2,g.Ad,g.Aciklama,g.GorevDurum,g.Deadline,g.Label From Gorevler g INNER JOIN Calisanlar c1 ON g.AtananCalisan = c1.UserId LEFT JOIN Calisanlar c2 ON g.AtananCalisan2 = c2.UserId WHERE (c2.UserMail = @Maile OR c1.UserMail = @Maile) AND g.GorevDurum=@gorev ", bgl.baglanti());
                da.SelectCommand.Parameters.AddWithValue("@Maile", LastLoginMail);
                da.SelectCommand.Parameters.AddWithValue("@gorev", "Waiting");
                da.Fill(dt);
                gridControl1.DataSource = dt;
 


                DataTable dp = new DataTable();
                SqlDataAdapter dl = new SqlDataAdapter("Select CONCAT(c1.UserAd, ' ', c1.UserSoyad) AS AdSoyad1,CONCAT(c2.UserAd, ' ', c2.UserSoyad) AS AdSoyad2,g.Ad,g.Aciklama,g.GorevDurum,g.Deadline,g.Label From Gorevler g INNER JOIN Calisanlar c1 ON g.AtananCalisan = c1.UserId LEFT JOIN Calisanlar c2 ON g.AtananCalisan2 = c2.UserId WHERE ((c2.UserMail IS NOT NULL AND c2.UserMail = @Maile) OR (c1.UserMail IS NOT NULL AND c1.UserMail = @Maile)) AND g.GorevDurum=@gorev", bgl.baglanti());
                dl.SelectCommand.Parameters.AddWithValue("@Maile", LastLoginMail);
                dl.SelectCommand.Parameters.AddWithValue("@gorev", "To Be Tested");
                dl.Fill(dp);
                gridControl2.DataSource = dp;

                DataTable dk = new DataTable();
                SqlDataAdapter du = new SqlDataAdapter("Select CONCAT(c1.UserAd, ' ', c1.UserSoyad) AS AdSoyad1,CONCAT(c2.UserAd, ' ', c2.UserSoyad) AS AdSoyad2,g.Ad,g.Aciklama,g.GorevDurum,g.Deadline,g.Label From Gorevler g INNER JOIN Calisanlar c1 ON g.AtananCalisan = c1.UserId LEFT JOIN Calisanlar c2 ON g.AtananCalisan2 = c2.UserId WHERE ((c2.UserMail IS NOT NULL AND c2.UserMail = @Maile) OR (c1.UserMail IS NOT NULL AND c1.UserMail = @Maile)) AND g.GorevDurum=@gorev", bgl.baglanti());
                du.SelectCommand.Parameters.AddWithValue("@Maile", LastLoginMail);
                du.SelectCommand.Parameters.AddWithValue("@gorev", "Finished");
                du.Fill(dk);
                gridControl3.DataSource = dk;


                graphic_deign();

            }
            else
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select CONCAT(c1.UserAd, ' ', c1.UserSoyad) AS AdSoyad1,CONCAT(c2.UserAd, ' ', c2.UserSoyad) AS AdSoyad2,g.Ad,g.Aciklama,g.GorevDurum,g.Deadline,g.Label From Gorevler g INNER JOIN Calisanlar c1 ON g.AtananCalisan = c1.UserId LEFT JOIN Calisanlar c2 ON g.AtananCalisan2 = c2.UserId WHERE g.GorevDurum=@gorev", bgl.baglanti());
                da.SelectCommand.Parameters.AddWithValue("@gorev", "Waiting");
                da.Fill(dt);
                gridControl1.DataSource = dt;
      


                DataTable dp = new DataTable();
                SqlDataAdapter dl = new SqlDataAdapter("Select CONCAT(c1.UserAd, ' ', c1.UserSoyad) AS AdSoyad1,CONCAT(c2.UserAd, ' ', c2.UserSoyad) AS AdSoyad2,g.Ad,g.Aciklama,g.GorevDurum,g.Deadline,g.Label From Gorevler g INNER JOIN Calisanlar c1 ON g.AtananCalisan = c1.UserId LEFT JOIN Calisanlar c2 ON g.AtananCalisan2 = c2.UserId WHERE g.GorevDurum=@gorev", bgl.baglanti());
                dl.SelectCommand.Parameters.AddWithValue("@gorev", "To Be Tested");
                dl.Fill(dp);
                gridControl2.DataSource = dp;
   

                DataTable dk = new DataTable();
                SqlDataAdapter du = new SqlDataAdapter("Select CONCAT(c1.UserAd, ' ', c1.UserSoyad) AS AdSoyad1,CONCAT(c2.UserAd, ' ', c2.UserSoyad) AS AdSoyad2,g.Ad,g.Aciklama,g.GorevDurum,g.Deadline,g.Label From Gorevler g INNER JOIN Calisanlar c1 ON g.AtananCalisan = c1.UserId LEFT JOIN Calisanlar c2 ON g.AtananCalisan2 = c2.UserId WHERE g.GorevDurum=@gorev", bgl.baglanti());
                du.SelectCommand.Parameters.AddWithValue("@gorev", "Finished");
                du.Fill(dk);
                gridControl3.DataSource = dk;


                graphic_deign();

            }

        }
        private void FrmGorevlerim_Load(object sender, EventArgs e)
        {

            buttonProperty();

            listele();

            Assigneelist();
         

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

      

  
  

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                // dq null değilse, veriler kontrol edilir ve belirli kontrol değerlerine yüklenir.
                TxtIs.Text = dr["Ad"].ToString();  // "Ad" sütunundaki veriyi bir TextBox'a yükler
                RchAciklama.Text = dr["Aciklama"].ToString();  // "Aciklama" sütunundaki veriyi bir RichTextBox'a yükler
                CmbDurum.Text = dr["GorevDurum"].ToString();  // "GorevDurum" sütunundaki veriyi bir ComboBox'a yükler
                MskDeadline.Text = dr["Deadline"].ToString();
                CmbAssignee.Text = dr["AdSoyad1"].ToString();
                CmbAssignee2.Text = dr["AdSoyad2"].ToString();
                TxtLabel.Text = dr["Label"].ToString();//Veri tabanından etiket değerini al
                SetLabelColor(dr);

            }
            else
            {
                // dq null ise, tüm kontrol değerleri temizlenir.
                TxtIs.Text = "";
                RchAciklama.Text = "";
                CmbDurum.Text = "";
                MskDeadline.Text = "";
                //DtpDeadline.Text = "";
                CmbAssignee.Text = "";
                CmbAssignee2.Text = "";
                TxtLabel.Text = "";

            }
        }

        private void gridView2_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dq = gridView2.GetDataRow(gridView2.FocusedRowHandle);



            if (dq != null)
            {
                // dq null değilse, veriler kontrol edilir ve belirli kontrol değerlerine yüklenir.
                TxtIs.Text = dq["Ad"].ToString();  // "Ad" sütunundaki veriyi bir TextBox'a yükler
                RchAciklama.Text = dq["Aciklama"].ToString();  // "Aciklama" sütunundaki veriyi bir RichTextBox'a yükler
                CmbDurum.Text = dq["GorevDurum"].ToString();  // "GorevDurum" sütunundaki veriyi bir ComboBox'a yükler
                MskDeadline.Text = dq["Deadline"].ToString();
                //DtpDeadline.Text = dq["Deadline"].ToString();
                CmbAssignee.Text = dq["AdSoyad1"].ToString();
                CmbAssignee2.Text = dq["AdSoyad2"].ToString();
                TxtLabel.Text = dq["Label"].ToString();//Veri tabanından etiket değerini al
                SetLabelColor(dq);
            }
            else
            {
                // dq null ise, tüm kontrol değerleri temizlenir.
                TxtIs.Text = "";
                RchAciklama.Text = "";
                CmbDurum.Text = "";
                MskDeadline.Text = "";
                //DtpDeadline.Text = "";
                CmbAssignee.Text = "";
                CmbAssignee2.Text = "";
                TxtLabel.Text = "";
            }
        }

        private void gridView3_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dc = gridView3.GetDataRow(gridView3.FocusedRowHandle);



            if (dc != null)
            {
                // dq null değilse, veriler kontrol edilir ve belirli kontrol değerlerine yüklenir.
                TxtIs.Text = dc["Ad"].ToString();  // "Ad" sütunundaki veriyi bir TextBox'a yükler
                RchAciklama.Text = dc["Aciklama"].ToString();  // "Aciklama" sütunundaki veriyi bir RichTextBox'a yükler
                CmbDurum.Text = dc["GorevDurum"].ToString();  // "GorevDurum" sütunundaki veriyi bir ComboBox'a yükler
                MskDeadline.Text = dc["Deadline"].ToString();
                //DtpDeadline.Text = dc["Deadline"].ToString();
                CmbAssignee.Text = dc["AdSoyad1"].ToString();
                CmbAssignee2.Text = dc["AdSoyad2"].ToString();
                TxtLabel.Text = dc["Label"].ToString();//Veri tabanından etiket değerini al
                SetLabelColor(dc);

            }
            else
            {
                // dq null ise, tüm kontrol değerleri temizlenir.
                TxtIs.Text = "";
                RchAciklama.Text = "";
                CmbDurum.Text = "";
                MskDeadline.Text = ""; 
                //DtpDeadline.Text = "";
                CmbAssignee.Text = "";
                CmbAssignee2.Text = "";
                TxtLabel.Text = "";
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            string LastLogin = getmailadress();

            if (LastLogin != "admin")
            {


                SqlCommand komut = new SqlCommand("update Gorevler set Aciklama=@p4,GorevDurum=@p5,Completed=@p6 where Ad=@p9", bgl.baglanti());
                komut.Parameters.AddWithValue("@p4", RchAciklama.Text);
                komut.Parameters.AddWithValue("@p5", CmbDurum.Text);
                komut.Parameters.Add("@p9", TxtIs.Text);
                string isCompleted = null;
                if (CmbDurum.Text != "Finished")
                {
                    isCompleted = "0";
                }
                else
                {
                    isCompleted = "1";
                }
                komut.Parameters.AddWithValue("@p6", isCompleted);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Job Status is updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listele();

            }

            else
            {

                SqlCommand komut = new SqlCommand("update Gorevler set Aciklama=@p4,GorevDurum=@p5,Deadline=@p2,AtananCalisan=@p3,AtananCalisan2=@p6,Completed=@p8 where Ad=@p9", bgl.baglanti());
                komut.Parameters.AddWithValue("@p4", RchAciklama.Text);
                komut.Parameters.AddWithValue("@p5", CmbDurum.Text);
                //komut.Parameters.AddWithValue("@p2", DtpDeadline.Text);
                komut.Parameters.AddWithValue("@p2", MskDeadline.Text);
                komut.Parameters.AddWithValue("@p3", getnamefromgorev(CmbAssignee.Text));
                komut.Parameters.AddWithValue("@p6", getnamefromgorev(CmbAssignee2.Text));
                string isCompleted = null;
                if (CmbDurum.Text != "Finished")
                {
                    isCompleted = "0";
                }
                else
                {
                    isCompleted = "1";
                }
                komut.Parameters.AddWithValue("@p8", isCompleted);
                komut.Parameters.Add("@p9", TxtIs.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Job Status is updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listele();
            }
        }
    }
}
