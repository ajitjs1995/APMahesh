using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class TestPage : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["TMBCON"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Btn_Click(object sender, EventArgs e)
    {
        try
        {
            //con.Close();
            //con.Open();
            //MailAddress ma = new MailAddress(ConfigurationSettings.AppSettings["fromaddress"], "Webmaster");
            //MailMessage Mail_br1 = new MailMessage();
            //Mail_br1.From = ma;
            //Mail_br1.To.Add(txtEmail.Text);
            //Mail_br1.Subject = "Acknowledgement";
            //Mail_br1.IsBodyHtml = true;
            //Mail_br1.Body = "Thanking You, <br/>Tamilnad mercantile bank ltd ";

            //SmtpClient smtpMailObj2 = new SmtpClient();
            //smtpMailObj2.EnableSsl = true;
            //smtpMailObj2.Host = "smtp.tmbank.in";
            //smtpMailObj2.Port = 465;
            //smtpMailObj2.Credentials = new System.Net.NetworkCredential(ConfigurationSettings.AppSettings["smtpuser"], ConfigurationSettings.AppSettings["smtppassword"]);
            //smtpMailObj2.Send(Mail_br1);

            //Label1.Text = "Mail Send Suceesully !!";

            MailAddress ma = new MailAddress("donotreply@tmbank.in", "Webmaster");
            MailMessage mm = new MailMessage();
            mm.From = ma;
            mm.To.Add(txtEmail.Text);
            mm.Subject = "Acknowledgement";
            mm.Body = "Thanking You, <br/>Tamilnad mercantile bank ltd";
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential();
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            NetworkCred.UserName = "donotreply@tmbank.in";
            NetworkCred.Password = "CHi@m1N%3";
            smtp.Host = "smtp.tmbank.in";
            smtp.Port = 465;
            smtp.Send(mm);
           // Label1.Text = "Mail Send Suceesully !!";
           
        }
        catch (Exception ex)
        {
            Label1.Text = "Something Bad happenedr!!!!";
           // Response.Write(ex.ToString());

        }
        finally
        {
            con.Close();

        }

    }
}