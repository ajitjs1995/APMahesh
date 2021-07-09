using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net.Mail;

public partial class Online_Complaint_Form : System.Web.UI.Page
{
    string ackid;
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    System.Data.DataSet ds = new System.Data.DataSet();
    System.Data.DataSet ds1 = new System.Data.DataSet();
    SqlDataReader dr;
    public SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["TMBCON"].ToString());
    private System.Random rand = new Random();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LblError.Text = ackid;
            BindBranch();
        }
    }

    public void BindBranch()
    {

        try
        {
            con.Open();
            cmd = new SqlCommand("USP_ManageBranch", con);
            cmd.Parameters.AddWithValue("@QueryType", "AllBranch");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                ddlBranch.Items.Clear();
                ddlBranch.DataSource = dt.DefaultView;
                ddlBranch.DataTextField = "BR_Name";
                ddlBranch.DataValueField = "BR_ID";
                ddlBranch.DataBind();
                ddlBranch.Items.Insert(0, " Select Branch Where You Have An Account");
                ddlBranch.SelectedIndex = 0;
            }
            else
            {
                ddlBranch.Items.Clear();
                ddlBranch.Items.Insert(0, " Select Branch Where You Have An Account ");
                ddlBranch.SelectedIndex = 0;
            }


        }
        catch { }
        finally
        {
            con.Close();
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
                    randgen();
                    SqlCommand cmd = new SqlCommand("USP_ComplaintProcedure", con);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
                    if (ddlBranch.SelectedIndex > 0)
                    {
                        cmd.Parameters.AddWithValue("@branch", ddlBranch.SelectedValue);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@branch", 0);
                    }
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
                    if (!string.IsNullOrEmpty(txtAddress.Text.Trim()))
                    {
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@address", "");
                    }

                    if (!string.IsNullOrEmpty(txtemail.Text.Trim()))
                    {
                        cmd.Parameters.AddWithValue("@email", txtemail.Text.Trim());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@email", "");
                    }
                    if (ddlsub.SelectedIndex > 0)
                    {
                        cmd.Parameters.AddWithValue("@subject", ddlsub.SelectedValue);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@subject", 0);
                    }

                    if (!string.IsNullOrEmpty(txtmsg.Text))
                    {
                        cmd.Parameters.AddWithValue("@msg", txtmsg.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@msg", "");
                    }


                    cmd.Parameters.AddWithValue("@refno", ackid);
                    cmd.Parameters["@mode"].Value = "InsertComplaint";
                    cmd.ExecuteNonQuery();

                    mail_appl();
                    if (!string.IsNullOrEmpty(txtemail.Text))
                    {
                        mail_Customer();
                    }
                    if (ddlBranch.SelectedIndex > 0)
                    {
                        mail_Branch();

                    }
                    con.Close();
                    Session["RefNo"] = ackid;
                    Session["Name"] = txtname.Text;
                    Response.Redirect("Online-Complaint-Form-Ack.aspx");
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




    protected void Btnreset_Click(object sender, EventArgs e)
    {
        LblError.Text = "";
        ddlBranch.SelectedIndex = 0;
        ddlsub.SelectedIndex = 0;
        txtname.Text = "";
        txtAddress.Text = "";
        txtphone.Text = "";
        txtemail.Text = "";
        txtmsg.Text = "";
        txtCaptcha.Text = "";
    }
    public string randgen()
    {

        StringBuilder sb = new StringBuilder();
        Random generator = new Random();
        int r =  rand.Next(1, 99999999);
        int r1 = rand.Next(1, 99999999);
        string digit1 = r.ToString("10000001");
        string digit2 = r1.ToString("10000001");
        int num = 0;
        int num2 = 0;
        string refnogen = null;

        con.Open();
        cmd = new SqlCommand("USP_ComplaintProcedure", con);
        cmd.Parameters.AddWithValue("@mode", "MaxNo");
        cmd.CommandType = CommandType.StoredProcedure;
        refnogen = cmd.ExecuteScalar().ToString();
        cmd.ExecuteNonQuery();
        con.Close();

        if (refnogen == "")
        { 
            num =  10000001;
            num2 = 10000001;
            ackid = num.ToString("D8") + "_" + num.ToString("D8");

        }
        else
        {
            string[] strdigit1 = null;
            string dd2 = refnogen;
            strdigit1 = dd2.Split('_');
            string digi = null;
           
            digi = strdigit1[0];
            digit2 = strdigit1[1];
            
            int number1 = Convert.ToInt32(digit2);
            num = number1 + 1;
            
            ackid = digit2 + "_" + num.ToString("D8");

        }
        if (string.IsNullOrEmpty(ackid))
        {
            randgen();
        }
        return sb.ToString();




        //return sb.ToString();

    }

    public bool checkdata()
    {
        //if (ddlBranch.SelectedIndex == 0)
        //{
        //    LblError.Text = "Please select branch !!";
        //    ddlBranch.Focus();
        //    return false;
        //}
        if (string.IsNullOrEmpty(txtname.Text.Trim()))
        {
            LblError.Text = "Please enter name !!";
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
        //else if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
        //{
        //    LblError.Text = "Please enter address !!";
        //    txtAddress.Focus();
        //    return false;
        //}
        else if (!string.IsNullOrEmpty(txtAddress.Text.Trim()) && !Regex.IsMatch(txtAddress.Text, "^[a-zA-Z0-9.\n-/,()#@ ]+$"))
        {
            LblError.Text = "Invalid address ,should contain alpha numeric and ( ) # @ - , / Character !!";
            txtAddress.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtAddress.Text.Trim()) && txtAddress.Text.Trim().Length < 8)
        {
            LblError.Text = "Address , should be geater than 8 characters !!";
            txtAddress.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtAddress.Text.Trim()) && txtAddress.Text.Trim().Length > 350)
        {
            LblError.Text = "Address , should be less than 350 characters !!";
            txtAddress.Focus();
            return false;
        }
        //else if (string.IsNullOrEmpty(txtphone.Text.Trim()))
        //{
        //    LblError.Text = "Mobile no should not be blank !!";
        //    txtphone.Focus();
        //    return false;
        //}
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
            LblError.Text = "Mobile number should  start with 7, 8 or 9  !! !!";
            txtphone.Focus();
            return false;
        }


        else if (string.IsNullOrEmpty(txtemail.Text.Trim()))
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
        //else if (ddlsub.SelectedIndex == 0)
        //{
        //    LblError.Text = "Please enter subject !!";
        //    ddlsub.Focus();
        //    return false;
        //}
        //else if (string.IsNullOrEmpty(txtmsg.Text.Trim()))
        //{
        //    LblError.Text = "Message should not be blank !!";
        //    txtmsg.Focus();
        //    return false;
        //}
        else if (!string.IsNullOrEmpty(txtmsg.Text.Trim()) && !Regex.IsMatch(txtmsg.Text.Trim(), "^[a-zA-Z0-9.\n-/,()#@ ]+$"))
        {
            LblError.Text = "Invalid message ,should contain alpha numeric and ( ) # @ - , / Character !!";
            txtmsg.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtmsg.Text.Trim()) && txtmsg.Text.Trim().Length < 8)
        {
            LblError.Text = "Message , should be geater than 8 characters !!";
            txtmsg.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtmsg.Text.Trim()) && txtmsg.Text.Trim().Length > 350)
        {
            LblError.Text = "Message , should be less than 350 characters !!";
            txtmsg.Focus();
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
            strbody3 = strbody3 + "<tr><td colspan='3' align=left valign=top><img src='https://www.tmb.in/images/tmb-logo.png'>";
            strbody3 = strbody3 + "</td></tr><br/>";



            strbody3 = strbody3 + "<tr><td colspan='3' align=center valign=middle style='width:68%; height:30px; font-family:Verdana; font-size:10pt; font-weight:bold; color:#ffffff;' bgcolor=#18388c> Complaint Acknowledgement</td></tr>";

            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";


            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Name :  " + " " + txtname.Text + ",";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Reference No. is:<strong> " + ackid + "<strong>";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Address : " + txtAddress.Text + ",";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Email : " + txtemail.Text + ",";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Mobile No : " + txtphone.Text + ",";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            if (ddlsub.SelectedIndex > 0)
            {
                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Subject : " + ddlsub.SelectedItem.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
            }
            else
            {
                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Subject : NA" + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
            }
            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Feedback : " + txtmsg.Text + ",";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            if (ddlBranch.SelectedIndex > 0)
            {
                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Branch Name : " + ddlBranch.SelectedItem.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
            }
            else
            {
                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Branch Name : NA" + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
            }

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
            //Mail_br1.CC.Add("dc_product@tmbank.in, bhupendra@chicinfotech.com");
            Mail_br1.Subject = "A new complaint is submitted in system";
            Mail_br1.IsBodyHtml = true;
            Mail_br1.Body = strbody3;

            SmtpClient smtpMailObj2 = new SmtpClient();            
			System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)3072;
            smtpMailObj2.UseDefaultCredentials = false;
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


    public void mail_Branch()
    {
        ///''''''''''----------------Mail Code To Customer Service-----------------------''''''''''''''
        string branchemail = string.Empty;
        try
        {
            con.Close();
            con.Open();

            SqlCommand cmd = new SqlCommand("USP_FeedbackProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 50));
            cmd.Parameters.AddWithValue("@branch", ddlBranch.SelectedValue);

            cmd.Parameters["@mode"].Value = "CheckMail";

            branchemail = cmd.ExecuteScalar().ToString();


            ///'''''''''''''''''''''''''''''' mail to Customer service

            MailAddress ma = new MailAddress(ConfigurationSettings.AppSettings["fromaddress"], "Webmaster");


            if (!string.IsNullOrEmpty(branchemail))
            {


                string strbody3 = "";
                //string imgurl = ConfigurationManager.AppSettings.Get("imgurl");

                strbody3 = "<html><head></head><body><table align=center border=0 cellpadding=0 cellspacing=0 style='width:68%; border:solid 1px; #18388c;' >";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
                strbody3 = strbody3 + "<tr><td colspan='3' align=left valign=top><img src='https://www.tmb.in/images/tmb-logo.png'>";
                strbody3 = strbody3 + "</td></tr><br/>";


                strbody3 = strbody3 + "<tr><td colspan='3' align=center valign=middle style='width:68%; height:30px; font-family:Verdana; font-size:10pt; font-weight:bold; color:#ffffff;' bgcolor=#18388c> Complaint Acknowledgement</td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";


                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Name :  " + " " + txtname.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
               

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Reference No. is:<strong> " + ackid + "<strong>";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Address : " + txtAddress.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Email : " + txtemail.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Mobile No : " + txtphone.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                if (ddlsub.SelectedIndex > 0)
                {
                    strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Subject : " + ddlsub.SelectedItem.Text + ",";
                    strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
                }
                else
                {
                    strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Subject : NA" + ",";
                    strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
                }
                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Feedback : " + txtmsg.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                if (ddlBranch.SelectedIndex > 0)
                {
                    strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Branch Name : " + ddlBranch.SelectedItem.Text + ",";
                    strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
                }
                else
                {
                    strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Branch Name : NA" + ",";
                    strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
                }

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
                Mail_br1.To.Add("branchemail");
                Mail_br1.Subject = "A new complaint is submitted in system";
                Mail_br1.IsBodyHtml = true;
                Mail_br1.Body = strbody3;

                SmtpClient smtpMailObj2 = new SmtpClient();                
				System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)3072;
                smtpMailObj2.UseDefaultCredentials = false;
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


    public void mail_Customer()
    {
        ///''''''''''----------------Mail Code To Customer-----------------------''''''''''''''
        try
        {
            con.Close();
            con.Open();




            ///'''''''''''''''''''''''''''''' mail to Customer 

            MailAddress ma = new MailAddress(ConfigurationSettings.AppSettings["fromaddress"], "Webmaster");


            if (!string.IsNullOrEmpty(txtemail.Text.Trim()))
            {


                string strbody3 = "";
                //string imgurl = ConfigurationManager.AppSettings.Get("imgurl");

                strbody3 = "<html><head></head><body><table align=center border=0 cellpadding=0 cellspacing=0 style='width:68%; border:solid 1px; #18388c;' >";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
                strbody3 = strbody3 + "<tr><td colspan='3' align=left valign=top><img src='https://www.tmb.in/images/tmb-logo.png'>";
                strbody3 = strbody3 + "</td></tr><br/>";


                strbody3 = strbody3 + "<tr><td colspan='3' align=center valign=middle style='width:68%; height:30px; font-family:Verdana; font-size:10pt; font-weight:bold; color:#ffffff;' bgcolor=#18388c> Complaint Acknowledgement</td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";


                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Dear " + " " + txtname.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr><br/>";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Greetings from Tamilnad Mercantile Bank Ltd!";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff> We acknowledge your Complaint and your reference number is <strong> " + ackid + " </strong> " + ".  We will take necessary action.";
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
                Mail_br1.To.Add(txtemail.Text);
                Mail_br1.Subject = "Complaint Acknowledgement";
                Mail_br1.IsBodyHtml = true;
                Mail_br1.Body = strbody3;

                SmtpClient smtpMailObj2 = new SmtpClient();                
				System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)3072;
                smtpMailObj2.UseDefaultCredentials = false;
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