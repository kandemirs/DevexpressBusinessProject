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
    public partial class FrmRehber : Form
    {
        public FrmRehber()
        {
            InitializeComponent();
        }


        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmRehber_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select UserId,Ad,Soyad,Tel,Mail,TC,Il, Ilce From Musteriler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;


            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select UserId,Ad,YetkiliStatu,YetkiliAd,Mail,YetkiliTc,Il, Ilce,Telefon,Sektor,Fax From Firmalar", bgl.baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;


            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("Select UserId,UserAd,UserSoyad,UserMail,UserTelefon From Calisanlar", bgl.baglanti());
            da3.Fill(dt3);
            gridControl3.DataSource = dt3;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frm = new FrmMail();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if(dr != null)
            {
                frm.mail = dr["Mail"].ToString();


            }
            frm.Show();

        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frm = new FrmMail();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);

            if (dr != null)
            {
                frm.mail = dr["Mail"].ToString();


            }
            frm.Show();

        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frm = new FrmMail();
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);

            if (dr != null)
            {
                frm.mail = dr["UserMail"].ToString();


            }
            frm.Show();

        }
    }

    
}
