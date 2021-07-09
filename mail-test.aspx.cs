using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Configuration;
using System.Globalization;
using System.Net.Mail;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Configuration;

public partial class mail_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("mailSettings");
            
            SmtpClient Smtp_Server = new SmtpClient();
            MailMessage e_mail = new MailMessage();

            e_mail = new MailMessage();
            e_mail.From = new MailAddress("donotreply@tmbank.in");
            e_mail.To.Add(txtemail.Text);
            e_mail.Subject = "Email Sending";
            e_mail.IsBodyHtml = false;
            e_mail.Body = "Testing email functionality!!";
            
            

            if (smtpSection.Network != null)
            {
                Smtp_Server.Host = smtpSection.Network.Host;
                Smtp_Server.Port = smtpSection.Network.Port;
                Smtp_Server.Credentials = new NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password, smtpSection.Network.ClientDomain);
            }
            Smtp_Server.DeliveryMethod = smtpSection.DeliveryMethod;
            Smtp_Server.Send(e_mail);
            Response.Write("Mail Sent");
        }
        catch (Exception error_t)
        {
            Response.Write(error_t.ToString());
        }
    }
}
