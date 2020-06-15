using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StackTeck_File_Transfer
{
    public partial class InputForm : Form
    {

        public string htmlLocation = "D:\\Github\\StackTeck File Transfer\\index.html";

        public InputForm()
        {
            InitializeComponent();
        }

        private void InputForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            if (string.IsNullOrEmpty(txtBoxLink.Text.Trim()) || string.IsNullOrEmpty(txtBoxFileName.Text.Trim()) || string.IsNullOrEmpty(txtBoxFromEmail.Text.Trim()) || string.IsNullOrEmpty(txtBoxRecipients.Text.Trim()))
            {
                MessageBox.Show("Fields cannot be empty!");
                return;
            }

            SendEmail();
            Cursor = Cursors.Default;
            Application.DoEvents();
            this.Dispose();

        }


        private void btnSend_Mouse(object sender, EventArgs e)
        {
            Program.SwitchBtnColors(btnSend);
        }

        private string getHtml()
        {
            string htmlBody = File.ReadAllText(htmlLocation);

            return htmlBody;
        }

        private void SendEmail()
        {
            MailMessage myMail = new MailMessage();
            SmtpClient mySmtp = new SmtpClient();            

            string mailTo = txtBoxRecipients.Text.Trim();
            string mailFrom = txtBoxFromEmail.Text.Trim();
            string emailSrv = "192.168.0.47";

            myMail.From = new MailAddress(mailFrom);
            myMail.To.Add(mailTo);

            myMail.IsBodyHtml = true;
            myMail.BodyEncoding = Encoding.UTF8;

            string mailBody = (getHtml()).Replace("**mylink**", txtBoxLink.Text.Trim());
            mailBody = mailBody.Replace("**filename**", txtBoxFileName.Text.Trim());
            mailBody = mailBody.Replace("**useremail**", txtBoxFromEmail.Text.Trim());

            myMail.Body = mailBody;


            myMail.Subject = mailFrom + " has sent you a CAD file";            

            mySmtp.Host = emailSrv;

            try
            {
                mySmtp.Send(myMail);
            }
            catch (System.Exception ex)
            {

                MessageBox.Show("File not sent!" + Environment.NewLine + ex.ToString(), "Email send error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
