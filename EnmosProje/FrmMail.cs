using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace EnmosProje
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }

        public string mail;
        private void FrmMail_Load(object sender, EventArgs e)
        {
            TxtMail.Text = mail;
        }


        private void BtnGonder_Click(object sender, EventArgs e)
        {
            string userName = "ennane77@outlook.com";
            string password = "Enmosbilgisayar123";
            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(TxtMail.Text));
            msg.From = new MailAddress(userName);
            msg.Subject = TxtKonu.Text;
            msg.Body = RchMesaj.Text;
            msg.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Host = "smtp.office365.com";
            client.Credentials = new System.Net.NetworkCredential(userName, password);
            client.Port = 587;
            client.EnableSsl = true;
            client.Send(msg);
        }
    }
}
