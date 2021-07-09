using System;
using System.Net;
using System.Net.Mail;

partial class mail_demo : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            errormsg.Text = "";
            errormsg.Visible = false;
        }
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
         try
        {
            SmtpClient Smtp_Server = new SmtpClient();
            MailMessage e_mail = new MailMessage();
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            Smtp_Server.UseDefaultCredentials = false;
            Smtp_Server.Credentials = new System.Net.NetworkCredential("donotreply", "CHi@m1N%3");
            Smtp_Server.Port = 587;
            Smtp_Server.EnableSsl = true;
            Smtp_Server.Host = "smtp.tmbank.in";

            e_mail = new MailMessage();
            e_mail.From = new MailAddress("donotreply@tmbank.in");
            e_mail.To.Add(txtemail.Text);
            e_mail.Subject = "SMTP Relay mail functionlaity is working absolutely fine using TLS1.2!!";
            e_mail.IsBodyHtml = false;
            e_mail.Body = "Testing email SMTP Relay functionality using TLS1.2!!";
            Smtp_Server.Send(e_mail);
            errormsg.Text  = "Mail Sent!!";
            errormsg.Visible = true;
        }
         catch (Exception ex)
         {
             Response.Write(ex);
         }
    }
}
