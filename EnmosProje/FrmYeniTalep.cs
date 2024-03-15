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
    public partial class FrmYeniTalep : Form
    {
        public FrmYeniTalep()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void Assigneelist()
        {
            CmbAssignee.Items.Add("null"); //ComboBoxa null seçneği eklenir
            CmbAssignee2.Items.Add("null");   
            SqlCommand komut = new SqlCommand("Select CONCAT(UserAd, ' ', UserSoyad) AS AdSoyad From Calisanlar", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbAssignee.Items.Add(dr[0]);
                CmbAssignee2.Items.Add(dr[0]);
            }

            CmbAssignee.SelectedIndex = 0;  //ComboBox ın başlangıç değerini belirleme
            CmbAssignee2.SelectedIndex = 0; 

        }

        public int getidfromgorev(string name)
        {
        
                int UserId = -1;
                using (SqlCommand getname = new SqlCommand("SELECT UserId FROM Calisanlar WHERE CONCAT(UserAd, ' ', UserSoyad)=@namedb ", bgl.baglanti()))
                {

                    getname.Parameters.AddWithValue("@namedb", name);
                    UserId = (int)getname.ExecuteScalar();
                }
                return UserId;
         
          
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

        public string getRequestername()
        {
            string namesurname;
            using (SqlCommand komut = new SqlCommand("SELECT CONCAT(UserAd, ' ',UserSoyad) As AdSoyad FROM Calisanlar WHERE UserMail=@p6 ", bgl.baglanti()))
            {

                komut.Parameters.AddWithValue("@p6", getmailadress());
                //Giriş yapılan mail adresinin veri tabanından çekilmesi
                namesurname = (string)komut.ExecuteScalar();
            }

            return namesurname;

        }

        private void buttonsettings()
        {
            string LastLogin = getmailadress();

            if (LastLogin != "admin")
            {
                button1.Text = "Send to Request";
            }
        }



        private void FrmYeniTalep_Load(object sender, EventArgs e)
        {
            Assigneelist();

            buttonsettings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string LastLogin = getmailadress();

            if (LastLogin != "admin")
            {

                SqlCommand komut = new SqlCommand("insert into Requests(Name,Description,TaskStatus,Priority,Assignee,Assignee2,Label,Deadline,Requester,ApproveOrReject)values (@p1, @p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtTask.Text);
                komut.Parameters.AddWithValue("@p2", RchDescription.Text);
                komut.Parameters.AddWithValue("@p3", "Waiting");
                komut.Parameters.AddWithValue("@p4", TxtPriority.Text);

                if (CmbAssignee.Text != "null")
                {
                    komut.Parameters.AddWithValue("@p5", getidfromgorev(CmbAssignee.Text));
                }
                else
                {
                    komut.Parameters.AddWithValue("@p5", "");
                }

                if (CmbAssignee2.Text != "null")
                {
                    komut.Parameters.AddWithValue("@p6", getidfromgorev(CmbAssignee2.Text));
                }
                else
                {
                    komut.Parameters.AddWithValue("@p6", "");
                }
                komut.Parameters.AddWithValue("@p7", CmbLabel.Text);
                komut.Parameters.AddWithValue("@p8", DtpDeadline.Text);

                komut.Parameters.AddWithValue("@p9", getRequestername());
                komut.Parameters.AddWithValue("@p10", "0");

                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Your job request has been created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else
            {

                SqlCommand komut = new SqlCommand("insert into Gorevler(Ad,Aciklama,GorevDurum,Onem,AtananCalisan,AtananCalisan2,Label,Deadline)values (@p1, @p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtTask.Text);
                komut.Parameters.AddWithValue("@p2", RchDescription.Text);
                komut.Parameters.AddWithValue("@p3", "Waiting");
                komut.Parameters.AddWithValue("@p4", TxtPriority.Text);

                if (CmbAssignee.Text != "null")
                {                  
                    komut.Parameters.AddWithValue("@p5", getidfromgorev(CmbAssignee.Text));
                }
                else
                {
                    komut.Parameters.AddWithValue("@p5", "");
                }

                if (CmbAssignee2.Text != "null")
                {
                    komut.Parameters.AddWithValue("@p6", getidfromgorev(CmbAssignee2.Text));
                }
                else
                {
                    komut.Parameters.AddWithValue("@p6", "");
                }
                komut.Parameters.AddWithValue("@p7", CmbLabel.Text);
                komut.Parameters.AddWithValue("@p8", DtpDeadline.Text);

                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("New task has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
            }

        }

    
    }
}
