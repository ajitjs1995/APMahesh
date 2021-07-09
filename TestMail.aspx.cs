using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

public partial class TestMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        mail1();
    }

    public static void mail()
    {
        var client = new SmtpClient("smtp.tmbank.in", 465)
        {
            Credentials = new NetworkCredential("donotreply@tmbank.in", "CHi@m1N%3"),
            EnableSsl = true

        };
        client.Send("donotreply@tmbank.in", "thakurpooja9511@gmail.com", "test", "testbody");
    }

    public static void mail1()
    {
        var fromaddress = new MailAddress("donotreply@tmbank.in", "From Name");
        var toaddress = new MailAddress("thakurpooja9511@gmail.com", "To Name");
        const string frompassword = "CHi@m1N%3";
        const string subject = "Subject";
        const string body = "Body";
        var smtp = new SmtpClient
        {
            Host = "smtp.tmbank.in",
            Port = 465,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential (fromaddress.Address,frompassword)
        };
        using (var message = new MailMessage(fromaddress, toaddress)
        {
            Subject = subject,
            Body = body
        }) { smtp.Send(message); }
    }
}