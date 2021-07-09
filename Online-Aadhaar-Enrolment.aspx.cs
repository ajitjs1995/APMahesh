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

public partial class Online_Aadhaar_Enrolment : System.Web.UI.Page
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
            lblerror.Text = ackid;
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
                ddlBranch.Items.Insert(0, " Select Branch");
                ddlBranch.SelectedIndex = 0;
            }
            else
            {
                ddlBranch.Items.Clear();
                ddlBranch.Items.Insert(0, " Select Branch");
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
                string capcha = Txtcaptch.Text;
                ccJoin.ValidateCaptcha(capcha);
                randgen();
                if (ccJoin.UserValidated == false)
                {
                    lblerror.Text = "The text you typed as shown in image is incorrect !!";
                }
                else
                {

                    SqlCommand cmd = new SqlCommand("USP_AadharEnrolmentProcedure", con);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 50));

                    if (ddlBranch.SelectedIndex == 0)
                    {
                        cmd.Parameters.AddWithValue("@branch", 0);
                       
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@branch", Convert.ToInt32(ddlBranch.SelectedValue));
                        
                    }
                    if (string.IsNullOrEmpty(txtName.Text.Trim()))
                    {
                        cmd.Parameters.AddWithValue("@name", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@name", Regex.Replace(txtName.Text.Trim(), @"\s+", " "));
                    }
                    if (string.IsNullOrEmpty(txtaddress.Text.Trim()))
                    {
                        cmd.Parameters.AddWithValue("@address", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@address", Regex.Replace(txtaddress.Text.Trim(), @"\s+", " "));
                    }
                    if (string.IsNullOrEmpty(Txtmob.Text.Trim()))
                    {
                        cmd.Parameters.AddWithValue("@phone", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@phone", Regex.Replace(Txtmob.Text.Trim(), @"\s+", " "));
                    }
                    if (string.IsNullOrEmpty(Txtemail.Text.Trim()))
                    {
                        cmd.Parameters.AddWithValue("@email", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@email", Regex.Replace(Txtemail.Text.Trim(), @"\s+", " ") );
                    }
                    if (Ddlsub.SelectedValue == "")
                    {
                        cmd.Parameters.AddWithValue("@subject", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@subject", Regex.Replace(Ddlsub.SelectedItem.Text.Trim(), @"\s+", " "));
                    }
                    if (string.IsNullOrEmpty(txtMessage.Text.Trim()))
                    {
                        cmd.Parameters.AddWithValue("@Message", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Message", Regex.Replace(txtMessage.Text.Trim(), @"\s+", " "));
                    }
                   
                  
                    cmd.Parameters.AddWithValue("@refno", ackid);
                    cmd.Parameters["@mode"].Value = "Insert";
                    cmd.ExecuteNonQuery();
                   
                    if (ddlBranch.SelectedIndex > 0)
                    {
                        mail_branch();
                    }
                    if (!string.IsNullOrEmpty(Txtemail.Text.Trim()))
                    {
                        mail_Customer();
                    }
					mail_KYCTMB();
                    con.Close();

                    Session["ACK"] = ackid;
                    Session["Name"] = txtName.Text.ToString().Trim();
                    Response.Redirect("Online-Aadhar-Enrolment-Ack.aspx");
                }
            }
            else
            {
                lblerror.Text = lblerror.Text;
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

    public string randgen()
    {

        StringBuilder sb = new StringBuilder();
        Random generator = new Random();
        String r = generator.Next(0, 999999).ToString("10");
        String r1 = generator.Next(0, 999999).ToString("08");


        ackid = r + "_" + r1;
        int cnt = 0;
        con.Open();
        SqlCommand cmd = new SqlCommand("USP_FeedbackProcedure", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
        if (ackid != "")
        {
            cmd.Parameters.AddWithValue("@refno", ackid);
        }
        cmd.Parameters["@mode"].Value = "CheckRefNo";
        cnt = Convert.ToInt32(cmd.ExecuteScalar());
        con.Close();



        if (string.IsNullOrEmpty(ackid))
        {
            randgen();
        }
        return sb.ToString();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
       
        txtaddress.Text = "";
        Txtcaptch.Text = "";
        Txtemail.Text = "";
        txtMessage.Text = "";
        Txtmob.Text = "";
        txtName.Text = "";
        ddlBranch.SelectedIndex = 0;
        Ddlsub.SelectedIndex = 0;
        lblerror.Text = "";
    }

    public bool checkdata()
    {
        if (ddlBranch.SelectedIndex == 0)
        {
            lblerror.Text = "Please select branch !!";
            ddlBranch.Focus();
            return false;
        }       
       
        if (string.IsNullOrEmpty(txtName.Text.Trim()) )
        {
            lblerror.Text ="Please enter your name !!";
            txtName.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtName.Text.Trim()) && !Regex.IsMatch(txtName.Text.Trim(), "^[a-zA-Z ]+$"))
        {
            lblerror.Text = "Invalid Name, should contains the alphabets and space !!";
            txtName.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtName.Text.Trim()) && txtName.Text.Trim().Length < 2)
        {
            lblerror.Text = "Name should be greater than the 2 charactors !!";
            txtName.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtName.Text.Trim()) && txtName.Text.Trim().Length > 100)
        {
            lblerror.Text = "Name should be less than the 100 charactors !!";
            txtName.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtaddress.Text.Trim()) && txtaddress.Text.Trim().Length < 8)
        {
            lblerror.Text = "Address , should be geater than 8 characters !!";
            txtaddress.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtaddress.Text.Trim()) && txtaddress.Text.Trim().Length > 350)
        {
            lblerror.Text = "Address, should be  lesser than 350 characters !!";
            txtaddress.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtaddress.Text.Trim()) && !Regex.IsMatch(txtaddress.Text, "^[a-zA-Z0-9.\n-/,()#@ ]+$"))
        {
            lblerror.Text = "Invalid Address, Should contain alpha numeric and ( ) # @ - , / Character";
            txtaddress.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(Txtmob.Text) && !Regex.IsMatch(Txtmob.Text, "^[0-9]+$"))
        {
            lblerror.Text = "Invalid Mobile no, should be digits !!";
            Txtmob.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(Txtmob.Text) && Txtmob.Text.Trim().Trim().Length < 10)
        {
            lblerror.Text = "Mobile number should contain 10 digits !!";
            Txtmob.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(Txtmob.Text) && Txtmob.Text.Trim().Length > 10)
        {
            lblerror.Text = "Mobile number should contain 10 digits !!";
            Txtmob.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(Txtmob.Text) && !Regex.IsMatch(Txtmob.Text, "^[7-9]{1}[0-9]{9}"))
        {
            lblerror.Text = "Invalid Mobile no, should start with 7, 8 or 9 !!";
            Txtmob.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(Txtemail.Text.Trim()))
        {
            lblerror.Text = "Email-Id should not be blank !!";
            Txtemail.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(Txtemail.Text.Trim()) && !Regex.IsMatch(Txtemail.Text.Trim(), "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$"))
        {
            lblerror.Text = "Your email-Id is not in correct format !!";
            Txtemail.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(Txtemail.Text.Trim()) && Txtemail.Text.Trim().Length < 8)
        {
            lblerror.Text = "Please enter email Id is above 8 characters !!";
            Txtemail.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(Txtemail.Text.Trim()) && Txtemail.Text.Trim().Length > 75)
        {
            lblerror.Text = "Please enter email Id is below 75 characters !!";
            Txtemail.Focus();
            return false;
        }
        else if (Ddlsub.SelectedIndex == 0)
        {
            lblerror.Text = "Please select appropriate subject !!";
            Ddlsub.Focus();
            return false;
        }
        else if (Ddlsub.SelectedIndex > 0 && Ddlsub.SelectedItem.Text != "Online Request for an Appointment" && Ddlsub.SelectedItem.Text != "Ask Questions for Aadhar Enrolment")
        {
            lblerror.Text = "Please select appropriate subject from list only !!";
            Ddlsub.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtMessage.Text.Trim()) && txtMessage.Text.Trim().Length < 8)
        {
            lblerror.Text = "Message , should be geater than 8 characters !!";
            txtMessage.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtMessage.Text.Trim()) && txtMessage.Text.Trim().Length > 350)
        {
            lblerror.Text = "Message, should be  lesser than 350 characters !!";
            txtMessage.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtMessage.Text.Trim()) && !Regex.IsMatch(txtMessage.Text, "^[a-zA-Z0-9.\n-/,()#@ ]+$"))
        {
            lblerror.Text = "Invalid Message, Should contain alpha numeric and ( ) # @ - , / Character";
            txtMessage.Focus();
            return false;
        }

        else if (String.IsNullOrEmpty(Txtcaptch.Text.Trim()) && !Regex.IsMatch(Txtcaptch.Text, "^[0-9]+$"))
        {
            lblerror.Text = "Verification Code , should not be blank !!";
            Txtcaptch.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(Txtcaptch.Text.Trim()) && Txtcaptch.Text.Trim().Length != 6)
        {
            lblerror.Text = "The text you typed as shown in image is incorrect !!";
            Txtcaptch.Focus();
            return false;
        }
        else
        {
            lblerror.Text = "";
            return true;
        }
    }


    //--------------------------------------Mail to Customer------------------------------------------//
    public void mail_Customer()
    {
        ///''''''''''----------------Mail Code-----------------------''''''''''''''

        try
        {
            con.Close();
            con.Open();



            ///'''''''''''''''''''''''''''''' mail to user

            MailAddress ma = new MailAddress(ConfigurationSettings.AppSettings["fromaddress"], "Webmaster");


            if (!string.IsNullOrEmpty(Txtemail.Text.Trim()))
            {
                string strbody3 = "";
                //string imgurl = ConfigurationManager.AppSettings.Get("imgurl");

                strbody3 = "<html><head></head><body><table align=center border=0 cellpadding=0 cellspacing=0 style='width:68%; border:solid 1px; #18388c;' >";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
                strbody3 = strbody3 + "<tr><td colspan='3' align=left valign=top><img src='http://tmb2.cdn18.com/i/tmb_head_04.png'>";
                strbody3 = strbody3 + "</td></tr><br/>";


                strbody3 = strbody3 + "<tr><td colspan='3' align=center valign=middle style='width:68%; height:30px; font-family:Verdana; font-size:10pt; font-weight:bold; color:#ffffff;' bgcolor=#18388c>Aadhar Enrolment Acknowledgement</td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";


                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Dear " + " " + txtName.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr><br/>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Greetings from Tamilnad Mercantile Bank Ltd!";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>We acknowledge receipt of your Online Request for Aadhaar Enrolment (as below) and your tracking reference number is "+  ackid +" We will review your request and take necessary action as soon as possible.";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";


                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Your patience till then is appreciated. Thank you.";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Branch Name : " + ddlBranch.SelectedItem.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";


                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Name : " + txtName.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

                

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Email-Id : " + Txtemail.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";


                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Mobile : " + Txtmob.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Address : " + txtaddress.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";



                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Subject : " + Ddlsub.SelectedItem.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";



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
                Mail_br1.To.Add(Txtemail.Text.Trim());
                Mail_br1.Subject = "Aadhar Enrolment Request Acknowledgment";
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
    

   
    //--------------------------------------Mail To Branch For Existing Cutomer------------------------------------------//
    public void mail_branch()
    {

        string branchemail = string.Empty;

        try
        {
            MailAddress ma = new MailAddress(ConfigurationManager.AppSettings["fromaddress"], "Webmaster");
                                 
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("USP_FeedbackProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 50));
            cmd.Parameters.AddWithValue("@branch", ddlBranch.SelectedValue);
            
            cmd.Parameters["@mode"].Value = "CheckMail";

            branchemail = cmd.ExecuteScalar().ToString();

            con.Close();
            if (!string.IsNullOrEmpty(branchemail.Trim()))
            {
                string strbody3 = "";
                //string imgurl = ConfigurationManager.AppSettings.Get("imgurl");


                strbody3 = strbody3 + "<tr><td colspan='3' align=center valign=middle style='width:68%; height:30px; font-family:Verdana; font-size:10pt; font-weight:bold; color:#ffffff;' bgcolor=#18388c>Aadhar Enrolment Acknowledgement</td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";


                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Dear " + " " + txtName.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr><br/>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Greetings from Tamilnad Mercantile Bank Ltd!";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>We acknowledge receipt of your Online Request for Aadhaar Enrolment (as below) and your tracking reference number is " + ackid + " We will review your request and take necessary action as soon as possible.";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";


                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Your patience till then is appreciated. Thank you.";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Branch Name : " + ddlBranch.SelectedItem.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";


                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Name : " + txtName.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";



                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Email-Id : " + Txtemail.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";


                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Mobile : " + Txtmob.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Address : " + txtaddress.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";



                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Subject : " + Ddlsub.SelectedItem.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";



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
                Mail_br1.To.Add(branchemail);
                Mail_br1.Subject = "A new Aadhar Enrolment Request Submitted";
                Mail_br1.CC.Add("");

                Mail_br1.IsBodyHtml = true;
                Mail_br1.Body = strbody3;

                SmtpClient smtpMailObj2 = new SmtpClient();
                smtpMailObj2.UseDefaultCredentials = false;
                smtpMailObj2.EnableSsl = true;
                smtpMailObj2.Host = ConfigurationSettings.AppSettings["smtphost"];
                smtpMailObj2.Port = Convert.ToInt32(ConfigurationSettings.AppSettings["smtpport"]);
                smtpMailObj2.Credentials = new System.Net.NetworkCredential(ConfigurationSettings.AppSettings["smtpuser"], ConfigurationSettings.AppSettings["smtppassword"]);
                smtpMailObj2.Send(Mail_br1);


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
   public void mail_KYCTMB()
    {

        string kycmail = string.Empty;
        kycmail = "kyc@tmbank.in";
        try
        {
            MailAddress ma = new MailAddress(ConfigurationManager.AppSettings["fromaddress"], "Webmaster");

            con.Close();
            con.Open();
            
            if (!string.IsNullOrEmpty(kycmail.Trim()))
            {
                string strbody3 = "";
                //string imgurl = ConfigurationManager.AppSettings.Get("imgurl");


                strbody3 = strbody3 + "<tr><td colspan='3' align=center valign=middle style='width:68%; height:30px; font-family:Verdana; font-size:10pt; font-weight:bold; color:#ffffff;' bgcolor=#18388c>Aadhar Enrolment Acknowledgement</td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";


                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Dear " + " " + txtName.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr><br/>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Greetings from Tamilnad Mercantile Bank Ltd!";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>We acknowledge receipt of your Online Request for Aadhaar Enrolment (as below) and your tracking reference number is " + ackid + " We will review your request and take necessary action as soon as possible.";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";


                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Your patience till then is appreciated. Thank you.";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Branch Name : " + ddlBranch.SelectedItem.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";


                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Name : " + txtName.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";



                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Email-Id : " + Txtemail.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";


                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Mobile : " + Txtmob.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Address : " + txtaddress.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";



                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Subject : " + Ddlsub.SelectedItem.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";



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
                Mail_br1.To.Add(kycmail);
                Mail_br1.Subject = "A new Aadhar Enrolment Request Submitted";
                Mail_br1.CC.Add("");

                Mail_br1.IsBodyHtml = true;
                Mail_br1.Body = strbody3;

                SmtpClient smtpMailObj2 = new SmtpClient();
                smtpMailObj2.UseDefaultCredentials = false;
                smtpMailObj2.EnableSsl = true;
                smtpMailObj2.Host = ConfigurationSettings.AppSettings["smtphost"];
                smtpMailObj2.Port = Convert.ToInt32(ConfigurationSettings.AppSettings["smtpport"]);
                smtpMailObj2.Credentials = new System.Net.NetworkCredential(ConfigurationSettings.AppSettings["smtpuser"], ConfigurationSettings.AppSettings["smtppassword"]);
                smtpMailObj2.Send(Mail_br1);


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