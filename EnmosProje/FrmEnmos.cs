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
    public partial class FrmEnmos : Form
    {
        public FrmEnmos()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select UserId,UserAd,UserSoyad,UserMaas,UserMail,UserYil,UserAdres,UserTelefon,Department,UserPositionId From Calisanlar", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }

        void Temizle()
        {
            TxtId.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            CmbDepartment.Text = "";
            CmbPosition.Text = "";
            TxtMaas.Text = "";
            TxtMail.Text = "";
            MskYil.Text = "";
            RchAdres.Text = "";
            MskTel.Text = "";
            TxtAd.Focus();

        }

        void departmentlist()
        {
            SqlCommand komut = new SqlCommand("Select Name From Department", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbDepartment.Items.Add(dr[0]);

            }
            bgl.baglanti().Close();
        }

        private void FrmEnmos_Load(object sender, EventArgs e)
        {
            listele();

            departmentlist();

            Temizle();

        }




        private void TxtId_TextChanged(object sender, EventArgs e)
        {
           // TxtId.ReadOnly = true;
        }

        private void BtnKaydet_Click_1(object sender, EventArgs e)
        {
            //Verileri Kaydetme
            SqlCommand komut = new SqlCommand("insert into Calisanlar(UserAd,UserSoyad,Department,UserMaas,UserMail,UserYil,UserAdres,UserTelefon,UserPositionId)values (@p1, @p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", getDepartmentId(CmbDepartment.Text));
            komut.Parameters.AddWithValue("@p9", getPositionId(CmbPosition.Text));
            komut.Parameters.AddWithValue("@p4", TxtMaas.Text);
            komut.Parameters.AddWithValue("@p5", TxtMail.Text);
            komut.Parameters.AddWithValue("@p6", MskYil.Text);
            komut.Parameters.AddWithValue("@p7", RchAdres.Text);
            komut.Parameters.AddWithValue("@p8", MskTel.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("New employee is saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

            Temizle();
        }
        public string getPositionId(string name)
        {
            string PositionId = null;
            using (SqlCommand komut = new SqlCommand("SELECT Id FROM Position WHERE Name=@p1", bgl.baglanti()))
            {
                komut.Parameters.AddWithValue("@p1", name);
                PositionId = komut.ExecuteScalar().ToString();
            }
            return PositionId;
        }
        public string getDepartmentId(string name)
        {
            string DepartmentId = null;
            using (SqlCommand komut = new SqlCommand("SELECT Id FROM Department WHERE Name=@p1", bgl.baglanti()))
            {
                komut.Parameters.AddWithValue("@p1", name);
                DepartmentId = komut.ExecuteScalar().ToString();
            }
            return DepartmentId;
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
       

        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtId.Text = dr["UserId"].ToString();
                TxtAd.Text = dr["UserAd"].ToString();
                TxtSoyad.Text = dr["UserSoyad"].ToString();
                CmbPosition.Text = getPositionName(dr["UserPositionId"].ToString());
                CmbDepartment.Text = getDepartmentName(dr["Department"].ToString());
                TxtMaas.Text = dr["UserMaas"].ToString();
                TxtMail.Text = dr["UserMail"].ToString();
                MskYil.Text = dr["UserYil"].ToString();
                RchAdres.Text = dr["UserAdres"].ToString();
                MskTel.Text = dr["UserTelefon"].ToString();
            }

        }

        private void BtnSil_Click_1(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From Calisanlar where UserId=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", TxtId.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Employee is deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            listele();
            Temizle();
        }

        private void BtnGuncelle_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Calisanlar set UserAd=@p1, UserSoyad=@p2, Department=@p3,UserMaas=@p4,UserMail=@p5,UserYil=@p6,UserAdres=@p7,UserTelefon=@p8,UserPositionId=@p10 where UserId=@p9", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", getDepartmentId(CmbDepartment.Text));
            komut.Parameters.AddWithValue("@p10", getPositionId(CmbPosition.Text));
            komut.Parameters.AddWithValue("@p4", TxtMaas.Text);
            komut.Parameters.AddWithValue("@p5", TxtMail.Text);
            komut.Parameters.AddWithValue("@p6", MskYil.Text);
            komut.Parameters.AddWithValue("@p7", RchAdres.Text);
            komut.Parameters.AddWithValue("@p8", MskTel.Text);
            komut.Parameters.Add("@p9", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Employee is updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            Temizle();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            Temizle();
        }

        private void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

            CmbPosition.Items.Clear();

            SqlCommand komut = new SqlCommand("Select Name From Position where DepartmentId = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbDepartment.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbPosition.Items.Add(dr[0]);

            }
            bgl.baglanti().Close();
        }
    }
}
