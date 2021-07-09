using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Mail;


public partial class Tab_Banking_Services : System.Web.UI.Page
{

    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    System.Data.DataSet ds = new System.Data.DataSet();
    System.Data.DataSet ds1 = new System.Data.DataSet();
    SqlDataReader dr;
    public SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["TMBCON"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public bool checkdata()
    {
        if (string.IsNullOrEmpty(txtname.Text.Trim()))
        {
            LblError.Text = "Please enter  name !!";
            txtname.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtname.Text.Trim()) && !Regex.IsMatch(txtname.Text, "^[a-zA-Z ]+$"))
        {
            LblError.Text = "Name should contain only aplhabates !!";
            txtname.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtname.Text.Trim()) && txtname.Text.Trim().Length < 2)
        {
            LblError.Text = "Name should be greater then 2 character !!";
            txtname.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtname.Text.Trim()) && txtname.Text.Trim().Length > 100)
        {
            LblError.Text = "Name should be less than 100 character !!";
            txtname.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtLocation.Text.Trim()) && !Regex.IsMatch(txtLocation.Text, "^[a-zA-Z0-9.\n-/,()#@ ]+$"))
        {
            LblError.Text = "Invalid address ,should contain alpha numeric and ( ) # @ - , / Character !!";
            txtLocation.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtphone.Text.Trim()) && txtphone.Text.Trim().Length < 10)
        {
            LblError.Text = "Mobile number should contain 10 digits !!";
            txtphone.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtphone.Text.Trim()) && txtphone.Text.Trim().Length > 10)
        {
            LblError.Text = "Mobile number should contain 10 digits !!";
            txtphone.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtphone.Text.Trim()) && !Regex.IsMatch(txtphone.Text.Trim(), "^[7-9]{1}[0-9]{9}"))
        {
            LblError.Text = "Invalid Mobile no, should start with 7, 8 or 9 !! !!";
            txtphone.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtphone.Text.Trim()) && !Regex.IsMatch(txtphone.Text.Trim(), "^[7-9]{1}[0-9]{9}"))
        {
            LblError.Text = "Invalid Mobile no, should start with 7, 8 or 9 !!";
            txtphone.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtemail.Text))
        {
            LblError.Text = "Email-Id should not be blank !!";
            txtemail.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtemail.Text.Trim()) && !Regex.IsMatch(txtemail.Text.Trim(), "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$"))
        {
            LblError.Text = "Your email-Id is not in correct format !!";
            txtemail.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtemail.Text.Trim()) && txtemail.Text.Trim().Length < 8)
        {
            LblError.Text = "Please enter email Id is above 8 characters !!";
            txtemail.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtemail.Text.Trim()) && txtemail.Text.Trim().Length > 75)
        {
            LblError.Text = "Please enter email Id is below 75 characters !!";
            txtemail.Focus();
            return false;
        }


        else if (String.IsNullOrEmpty(txtCaptcha.Text.Trim()))
        {
            LblError.Text = "Verification Code , should not be blank !!";
            txtCaptcha.Focus();
            return false;
        }
        else if (String.IsNullOrEmpty(txtCaptcha.Text.Trim()) && !Regex.IsMatch(txtCaptcha.Text, "^[0-9]+$"))
        {
            LblError.Text = "Verification Code , should not be blank !!";
            txtCaptcha.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtCaptcha.Text.Trim()) && txtCaptcha.Text.Trim().Length != 6)
        {
            LblError.Text = "The text you typed as shown in image is incorrect !!";
            txtCaptcha.Focus();
            return false;
        }
        else
        {
            LblError.Text = "";
            return true;
        }
    }

    protected void Btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            if (checkdata() == true)
            {
                string capcha = txtCaptcha.Text;
                ccJoin.ValidateCaptcha(capcha);

                if (ccJoin.UserValidated == false)
                {
                    LblError.Text = "The text you typed as shown in image is incorrect !!";
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("USP_TabBanking", con);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));

                    if (!string.IsNullOrEmpty(txtname.Text.Trim()))
                    {
                        cmd.Parameters.AddWithValue("@name", txtname.Text.Trim());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@name", "");
                    }
                    if (!string.IsNullOrEmpty(txtphone.Text.Trim()))
                    {
                        cmd.Parameters.AddWithValue("@phone", txtphone.Text.Trim());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@phone", "");
                    }
                    if (!string.IsNullOrEmpty(txtLocation.Text.Trim()))
                    {
                        cmd.Parameters.AddWithValue("@Location", txtLocation.Text.Trim());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Location", "");
                    }

                    if (!string.IsNullOrEmpty(txtemail.Text.Trim()))
                    {
                        cmd.Parameters.AddWithValue("@email", txtemail.Text.Trim());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@email", "");
                    }


                    cmd.Parameters["@mode"].Value = "InsertCustomer";
                    cmd.ExecuteNonQuery();

                    mail_appl();
                    mail_BD();
                    con.Close();

                    Session["Name"] = txtname.Text;
                    Response.Redirect("Tab-Banking-Services-Ack.aspx");
                }
            }

            else
            {
                LblError.Text = LblError.Text;
            }

        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
        finally
        {
            con.Close();
        }
    }
    protected void BtnReset_Click(object sender, EventArgs e)
 {
    txtname.Text = "";
    txtLocation.Text = "";
    txtemail.Text = "";
    txtphone.Text = "";
    txtCaptcha.Text = "";
}

public void mail_appl()
{
    ///''''''''''----------------Mail Code To Customer Service-----------------------''''''''''''''

    try
    {
        con.Close();
        con.Open();

        ///'''''''''''''''''''''''''''''' mail to Customer service

        MailAddress ma = new MailAddress(ConfigurationSettings.AppSettings["fromaddress"], "Webmaster");





        string strbody3 = "";
        //string imgurl = ConfigurationManager.AppSettings.Get("imgurl");

        strbody3 = "<html><head></head><body><table align=center border=0 cellpadding=0 cellspacing=0 style='width:68%; border:solid 1px; #18388c;' >";
        strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
        strbody3 = strbody3 + "<tr><td colspan='3' align=left valign=top><img src='http://new.tmb.in/images/tmb-logo.png'>";
        strbody3 = strbody3 + "</td></tr><br/>";



        strbody3 = strbody3 + "<tr><td colspan='3' align=center valign=middle style='width:68%; height:30px; font-family:Verdana; font-size:10pt; font-weight:bold; color:#ffffff;' bgcolor=#18388c> Tab Banking Services Acknowledgement</td></tr>";

        strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
        strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";


        strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Name :  " + " " + txtname.Text + ",";
        strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

        strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";



        strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Email : " + txtemail.Text + ",";
        strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

        strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Mobile No : " + txtphone.Text + ",";
        strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

        strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Feedback : " + txtLocation.Text + ",";
        strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";




        strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";





        strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

        strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Thanking You,";
        strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

        strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

        strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

        strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Webmaster";
        strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

        strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

        strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

        strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Tamilnad Mercantile Bank Ltd.";
        strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

        strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

        strbody3 = strbody3 + "</table></body></html>";






        MailMessage Mail_br1 = new MailMessage();
        Mail_br1.From = ma;
        Mail_br1.To.Add("customerservice@tmbank.in");
        Mail_br1.Subject = "A Tab banking Services Enquiry is submitted in system";
        Mail_br1.IsBodyHtml = true;
        Mail_br1.Body = strbody3;

        SmtpClient smtpMailObj2 = new SmtpClient();
        smtpMailObj2.EnableSsl = true;
        smtpMailObj2.Host = ConfigurationSettings.AppSettings["smtphost"];
        smtpMailObj2.Port = Convert.ToInt32(ConfigurationSettings.AppSettings["smtpport"]);
        smtpMailObj2.Credentials = new System.Net.NetworkCredential(ConfigurationSettings.AppSettings["smtpuser"], ConfigurationSettings.AppSettings["smtppassword"]);
        smtpMailObj2.Send(Mail_br1);


        //SmtpClient smtpMailObj2 = new SmtpClient();
        //smtpMailObj2.Host = "127.0.0.1";
        //smtpMailObj2.Port = 25;
        //smtpMailObj2.Send(Mail_br1);









    }
    catch (Exception ex)
    {
        Response.Write(ex.ToString());

    }
    finally
    {
        con.Close();

    }

}




public void mail_BD()
{
    ///''''''''''----------------Mail Code To BD-----------------------''''''''''''''

    try
    {
        con.Close();
        con.Open();

        ///'''''''''''''''''''''''''''''' mail to BD

        MailAddress ma = new MailAddress(ConfigurationSettings.AppSettings["fromaddress"], "Webmaster");





        string strbody3 = "";
        //string imgurl = ConfigurationManager.AppSettings.Get("imgurl");

        strbody3 = "<html><head></head><body><table align=center border=0 cellpadding=0 cellspacing=0 style='width:68%; border:solid 1px; #18388c;' >";
        strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
        strbody3 = strbody3 + "<tr><td colspan='3' align=left valign=top><img src='http://new.tmb.in/images/tmb-logo.png'>";
        strbody3 = strbody3 + "</td></tr><br/>";



        strbody3 = strbody3 + "<tr><td colspan='3' align=center valign=middle style='width:68%; height:30px; font-family:Verdana; font-size:10pt; font-weight:bold; color:#ffffff;' bgcolor=#18388c> Tab Banking Services Acknowledgement</td></tr>";

        strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
        strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";


        strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Name :  " + " " + txtname.Text + ",";
        strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

        strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";




        strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Email : " + txtemail.Text + ",";
        strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

        strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Mobile No : " + txtphone.Text + ",";
        strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

        strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Feedback : " + txtLocation.Text + ",";
        strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";




        strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";





        strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

        strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Thanking You,";
        strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

        strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

        strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

        strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Webmaster";
        strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

        strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

        strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

        strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Tamilnad Mercantile Bank Ltd.";
        strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

        strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

        strbody3 = strbody3 + "</table></body></html>";






        MailMessage Mail_br1 = new MailMessage();
        Mail_br1.From = ma;
        Mail_br1.To.Add("bd@tmbank.in");
        Mail_br1.Subject = "A Tab banking Services Enquiry is submitted in system";
        Mail_br1.IsBodyHtml = true;
        Mail_br1.Body = strbody3;

        SmtpClient smtpMailObj2 = new SmtpClient();
        smtpMailObj2.EnableSsl = true;
        smtpMailObj2.Host = ConfigurationSettings.AppSettings["smtphost"];
        smtpMailObj2.Port = Convert.ToInt32(ConfigurationSettings.AppSettings["smtpport"]);
        smtpMailObj2.Credentials = new System.Net.NetworkCredential(ConfigurationSettings.AppSettings["smtpuser"], ConfigurationSettings.AppSettings["smtppassword"]);
        smtpMailObj2.Send(Mail_br1);


        //SmtpClient smtpMailObj2 = new SmtpClient();
        //smtpMailObj2.Host = "127.0.0.1";
        //smtpMailObj2.Port = 25;
        //smtpMailObj2.Send(Mail_br1);









    }
    catch (Exception ex)
    {
        Response.Write(ex.ToString());

    }
    finally
    {
        con.Close();

    }

}

}