Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mail.MailAddress
Imports System.Net.Mail.SmtpClient
Partial Class checksmtp
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("donotreply", "CHi@m1N%3")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.tmbank.in"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress("donotreply@tmbank.in")
            e_mail.To.Add(txtemail.Text)
            e_mail.Subject = "SMTP Relay mail functionlaity is working absolutely fine using TLS1.2!!"
            e_mail.IsBodyHtml = False
            e_mail.Body = "Testing email SMTP Relay functionality using TLS1.2!!"
            Smtp_Server.Send(e_mail)
            Label1.text = "Mail Sent!!"

        Catch error_t As Exception
            Response.Write(error_t.ToString())
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtemail.Text = ""
            Label1.Text = ""
        End If
    End Sub
End Class
