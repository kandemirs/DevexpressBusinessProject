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
    public partial class FrmBusinessAnalysis : Form
    {
        public FrmBusinessAnalysis()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();


        private void FrmBusinessAnalysis_Load(object sender, EventArgs e)
        {

            SqlCommand da = new SqlCommand("Select g.GorevDurum,Count(g.Ad) From Gorevler g INNER JOIN Calisanlar c1 ON g.AtananCalisan = c1.UserId LEFT JOIN Calisanlar c2 ON g.AtananCalisan2 = c2.UserId group by g.GorevDurum ", bgl.baglanti());
            SqlDataReader dr = da.ExecuteReader();
            while (dr.Read())
            {

                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));

            }
            bgl.baglanti().Close();





            SqlCommand dh = new SqlCommand("Select g.Label,COUNT(g.Ad) From Gorevler g INNER JOIN Calisanlar c1 ON g.AtananCalisan = c1.UserId LEFT JOIN Calisanlar c2 ON g.AtananCalisan2 = c2.UserId group by g.Label ", bgl.baglanti());
            SqlDataReader dg = dh.ExecuteReader();


            while (dg.Read())
            {

                chartControl2.Series["Series 1"].Points.AddPoint(Convert.ToString(dg[0]), int.Parse(dg[1].ToString()));

            }

            bgl.baglanti().Close();





            SqlCommand dp = new SqlCommand("Select UserPosition,Count(UserAd) From Calisanlar group by UserPosition", bgl.baglanti());
            SqlDataReader dt = dp.ExecuteReader();
            while (dt.Read())
            {
                if (Convert.ToString(dt[0]) != "")
                {
                    chartControl3.Series["Series 1"].Points.AddPoint(Convert.ToString(dt[0]), int.Parse(dt[1].ToString()));
                }
            }
            bgl.baglanti().Close();





            SqlCommand dq = new SqlCommand("Select UserDepartman,Count(UserAd) From Calisanlar group by UserDepartman ", bgl.baglanti());
            SqlDataReader de = dq.ExecuteReader();
            while (de.Read())
            {
                if (Convert.ToString(de[0]) != "")
                {

                    chartControl4.Series["Series 1"].Points.AddPoint(Convert.ToString(de[0]), int.Parse(de[1].ToString()));
                }
            }
            bgl.baglanti().Close();

        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
