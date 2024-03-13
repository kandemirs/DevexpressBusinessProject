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
    public partial class FrmRequests : Form
    {
        public FrmRequests()
        {
            InitializeComponent();
        }


        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Name,Description,TaskStatus,Priority,Assignee,Assignee2,Label,Deadline,StartDate,Requester From Requests WHERE ApproveOrReject=@P1", bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@p1", "0");
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        public void stampjob()
        {
            SqlCommand komu = new SqlCommand("update Requests set ApproveOrReject=@p1 where Name=@p2 AND Description=@p3 AND Requester=@p4", bgl.baglanti());
            komu.Parameters.AddWithValue("@p1", "1");
            komu.Parameters.Add("@p2", Nm);
            komu.Parameters.Add("@p3", Dscrptn);
            komu.Parameters.Add("@p4", Rqstr);
            komu.ExecuteNonQuery();

        }


        private void FrmRequests_Load(object sender, EventArgs e)
        {
            listele();
        }



        string Nm, Dscrptn, Tsk, Prrty, Assgn, Assgn2, Lbl, Ddln, Rqstr;

        private void BtnReject_Click_1(object sender, EventArgs e)
        {
            /*SqlCommand komutsil = new SqlCommand("Delete From Requests where Name=@p1 AND Description=@p2 AND Requester=@p3", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", Nm);
            komutsil.Parameters.AddWithValue("@p2", Dscrptn);
            komutsil.Parameters.AddWithValue("@p3", Rqstr);
            komutsil.ExecuteNonQuery();*/
            stampjob();
            bgl.baglanti().Close();
            MessageBox.Show("Request Deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            listele();
        }

        private void BtnOnayla_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Gorevler(Ad,Aciklama,GorevDurum,Onem,AtananCalisan,AtananCalisan2,Label,Deadline)values (@p1, @p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Nm);
            komut.Parameters.AddWithValue("@p2", Dscrptn);
            komut.Parameters.AddWithValue("@p3", Tsk);
            komut.Parameters.AddWithValue("@p4", Prrty);
            komut.Parameters.AddWithValue("@p5", Assgn);
            komut.Parameters.AddWithValue("@p6", Assgn2);
            komut.Parameters.AddWithValue("@p7", Lbl);
            komut.Parameters.AddWithValue("@p8", Ddln);
            komut.ExecuteNonQuery();
            stampjob();
            bgl.baglanti().Close();
            MessageBox.Show("The Job request has been approved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Nm = dr["Name"].ToString();
                Dscrptn = dr["Description"].ToString();
                Tsk = dr["TaskStatus"].ToString();
                Prrty = dr["Priority"].ToString();
                Assgn = dr["Assignee"].ToString();
                Assgn2 = dr["Assignee2"].ToString();
                Ddln = dr["Deadline"].ToString();
                Lbl = dr["Label"].ToString();
                Rqstr = dr["Requester"].ToString();

                LblName.Text = dr["Name"].ToString();
                LblDescription.Text = dr["Description"].ToString();
                LblAssignee.Text = dr["Assignee"].ToString();
                LblAssignee2.Text = dr["Assignee2"].ToString();
                LblLabel.Text = dr["Label"].ToString();
                LblRequester.Text = dr["Requester"].ToString();
            }

        }

       
    }
}
