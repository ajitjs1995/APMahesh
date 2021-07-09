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

public partial class Online_Feedback_Form : System.Web.UI.Page
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
                string capcha = Txtcaptch.Text;
                ccJoin.ValidateCaptcha(capcha);
               
                if (ccJoin.UserValidated == false)
                {
                    lblerror.Text = "The text you typed as shown in image is incorrect !!";
                }
                else
                {
                    randgen();
                    SqlCommand cmd = new SqlCommand("USP_FeedbackProcedure", con);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 50));
                    if (string.IsNullOrEmpty(Txtname.Text.Trim()))
                    {
                        cmd.Parameters.AddWithValue("@name", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@name", Txtname.Text.Trim());
                    }
                    if (string.IsNullOrEmpty(txtaddress.Text.Trim()))
                    {
                        cmd.Parameters.AddWithValue("@address", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@address", txtaddress.Text.Trim());
                    }
                    if (string.IsNullOrEmpty(Txtmob.Text.Trim()))
                    {
                        cmd.Parameters.AddWithValue("@phone", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@phone", Txtmob.Text.Trim());
                    }
                    if (string.IsNullOrEmpty(Txtemail.Text.Trim()))
                    {
                        cmd.Parameters.AddWithValue("@email", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@email", Txtemail.Text.Trim());
                    }
                    if (Ddlsub.SelectedValue == "")
                    {
                        cmd.Parameters.AddWithValue("@subject", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@subject", Convert.ToInt32(Ddlsub.SelectedValue));
                    }
                    if (string.IsNullOrEmpty(Txtfeedback.Text.Trim()))
                    {
                        cmd.Parameters.AddWithValue("@feedback", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@feedback", Txtfeedback.Text.Trim());
                    }
                    if (ddlBranch.SelectedIndex == 0)
                    {
                        cmd.Parameters.AddWithValue("@branch", 0);
                        cmd.Parameters.AddWithValue("@accountno", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@branch", Convert.ToInt32(ddlBranch.SelectedValue));
                        cmd.Parameters.AddWithValue("@accountno", txtacc.Text);
                    }

                    cmd.Parameters.AddWithValue("@copyemail", rdbcopy.SelectedValue);
                    cmd.Parameters.AddWithValue("@refno", ackid);
                    cmd.Parameters["@mode"].Value = "InsertFeedbackDetails";
                    cmd.ExecuteNonQuery();
                    mail_appl();
                    if (ddlBranch.SelectedIndex > 0)
                    {
                        mail_branch();
                    }
                    if (!string.IsNullOrEmpty(Txtemail.Text.Trim()))
                    {
                        mail_Customer();
                    }
                    con.Close();

                    Session["ACK"] = ackid;
                    Session["Name"] = Txtname.Text.ToString().Trim();
                    Response.Redirect("Feedback-Ack.aspx");
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
        int r = rand.Next(1, 99999999);
        int r1 = rand.Next(1, 99999999);
        string digit1 = r.ToString("10000001");
        string digit2 = r1.ToString("10000001");
        int num = 0;
        int num2 = 0;
        string refnogen = null;

        con.Open();
        cmd = new SqlCommand("USP_FeedbackProcedure", con);
        cmd.Parameters.AddWithValue("@mode", "MaxNo");
        cmd.CommandType = CommandType.StoredProcedure;
        refnogen = cmd.ExecuteScalar().ToString();
        cmd.ExecuteNonQuery();
        con.Close();
        if (refnogen == "")
        {
            num  = 10000001;
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





    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        txtacc.Text = "";
        txtaddress.Text = "";
        Txtcaptch.Text = "";
        Txtemail.Text = "";
        Txtfeedback.Text = "";
        Txtmob.Text = "";
        Txtname.Text = "";
        ddlBranch.SelectedIndex = 0;
        Ddlsub.SelectedIndex = 0;
        lblerror.Text = "";
    }

    public bool checkdata()
    {
        if (string.IsNullOrEmpty(Txtname.Text.Trim()))
        {
            lblerror.Text = "Please enter your name !!";
            Txtname.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(Txtname.Text.Trim()) && !Regex.IsMatch(Txtname.Text.Trim(), "^[a-zA-Z ]+$"))
        {
            lblerror.Text = "Name should contain only aplhabates !!";
            Txtname.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(Txtname.Text.Trim()) && Txtname.Text.Trim().Length < 2)
        {
            lblerror.Text = "Name should be greater than the 2 charactors !!";
            Txtname.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(Txtname.Text.Trim()) && Txtname.Text.Trim().Length > 100)
        {
            lblerror.Text = "Name should be less than the 100 charactors !!";
            Txtname.Focus();
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
        else if (string.IsNullOrEmpty(Txtemail.Text))
        {
            lblerror.Text = "Email-Id should not be blank !!";
            Txtemail.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(Txtemail.Text) && !Regex.IsMatch(Txtemail.Text, "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$"))
        {
            lblerror.Text = "Your email-Id is not in correct format !!";
            Txtemail.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(Txtemail.Text) && Txtemail.Text.Trim().Length < 8)
        {
            lblerror.Text = "Please enter email Id is above 8 characters !!";
            Txtemail.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(Txtemail.Text) && Txtemail.Text.Trim().Length > 75)
        {
            lblerror.Text = "Please enter email Id is below 75 characters !!";
            Txtemail.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(Txtfeedback.Text.Trim()) && Txtfeedback.Text.Trim().Length < 8)
        {
            lblerror.Text = "Feedback , should be geater than 8 characters !!";
            Txtfeedback.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(Txtfeedback.Text.Trim()) && Txtfeedback.Text.Trim().Length > 350)
        {
            lblerror.Text = "Feedback, should be  lesser than 350 characters !!";
            Txtfeedback.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(Txtfeedback.Text.Trim()) && !Regex.IsMatch(Txtfeedback.Text, "^[a-zA-Z0-9.\n-/,()#@ ]+$"))
        {
            lblerror.Text = "Invalid Feedback, Should contain alpha numeric and ( ) # @ - , / Character";
            Txtfeedback.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtacc.Text) && !Regex.IsMatch(txtacc.Text, "^[0-9]{15}$"))
        {
            lblerror.Text = "Invalid account no, should be 15 digits !!";
            txtacc.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtacc.Text) && txtacc.Text.Trim().Length < 15)
        {
            lblerror.Text = "account number should contain 15 digits !!";
            txtacc.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtacc.Text) && txtacc.Text.Trim().Length > 15)
        {
            lblerror.Text = "account number should contain 15 digits !!";
            txtacc.Focus();
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
                strbody3 = strbody3 + "<tr><td colspan='3' align=left valign=top><img src='https://www.tmb.in/images/tmb-logo.png'>";
                strbody3 = strbody3 + "</td></tr><br/>";


                strbody3 = strbody3 + "<tr><td colspan='3' align=center valign=middle style='width:68%; height:30px; font-family:Verdana; font-size:10pt; font-weight:bold; color:#ffffff;' bgcolor=#18388c> Feedback Acknowledgement</td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";


                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Dear " + " " + Txtname.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr><br/>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Greetings from Tamilnad Mercantile Bank Ltd!";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff> We acknowledge your Feedback and your reference number is <strong> " + ackid + " </strong> " + ".  We will take necessary action.";
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
                Mail_br1.To.Add(Txtemail.Text.Trim());
                Mail_br1.Subject = "Feedback Acknowledgment";
                Mail_br1.IsBodyHtml = true;
                Mail_br1.Body = strbody3;

                SmtpClient smtpMailObj2 = new SmtpClient();
                System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)3072;
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
    //-----------End------------------------------//

    //--------------------------------------Mail to Customer Service------------------------------------------//
    public void mail_appl()
    {


        try
        {
            con.Close();
            con.Open();




            MailAddress ma = new MailAddress(ConfigurationSettings.AppSettings["fromaddress"], "Webmaster");



            string strbody3 = "";
            //string imgurl = ConfigurationManager.AppSettings.Get("imgurl");

            strbody3 = "<html><head></head><body><table align=center border=0 cellpadding=0 cellspacing=0 style='width:68%; border:solid 1px; #18388c;' >";
            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
            strbody3 = strbody3 + "<tr><td colspan='3' align=left valign=top><img src='<img src='https://www.tmb.in/images/tmb-logo.png'>";
            strbody3 = strbody3 + "</td></tr><br/>";


            strbody3 = strbody3 + "<tr><td colspan='3' align=center valign=middle style='width:68%; height:30px; font-family:Verdana; font-size:10pt; font-weight:bold; color:#ffffff;' bgcolor=#18388c> Feedback Acknowledgement</td></tr>";

            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";


            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Name : " + " " + Txtname.Text + ",";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Reference No. is:<strong> " + ackid + "<strong>";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Address : " + txtaddress.Text + ",";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Email : " + Txtemail.Text + ",";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Mobile No : " + Txtmob.Text + ",";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            if (Ddlsub.SelectedIndex > 0)
            {
                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Subject : " + Ddlsub.SelectedItem.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
            }
            else
            {
                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Subject : NA" + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
            }
            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Feedback : " + Txtfeedback.Text + ",";
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
            if (txtacc.Text.Trim() == "")
            {
                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Account No : NA ,";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
            }
            else
            {
                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Account No : " + txtacc.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
            }
            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Email Copy Sent to Branch : " + rdbcopy.SelectedItem.Text + ",";
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
            Mail_br1.Subject = "A new feedback is submitted in system";
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
    //----------------------End----------------------------------//


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
            cmd.Parameters.AddWithValue("@copyemail", rdbcopy.SelectedValue);
            cmd.Parameters["@mode"].Value = "CheckMail";

            branchemail = cmd.ExecuteScalar().ToString();

            con.Close();
            if (!string.IsNullOrEmpty(branchemail.Trim()))
            {
                string strbody3 = "";
                //string imgurl = ConfigurationManager.AppSettings.Get("imgurl");

                strbody3 = "<html><head></head><body><table align=center border=0 cellpadding=0 cellspacing=0 style='width:68%; border:solid 1px; #18388c;' >";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
                strbody3 = strbody3 + "<tr><td colspan='3' align=left valign=top><img src='https://www.tmb.in/images/tmb-logo.png'>";
                strbody3 = strbody3 + "</td></tr><br/>";


                strbody3 = strbody3 + "<tr><td colspan='3' align=center valign=middle style='width:68%; height:30px; font-family:Verdana; font-size:10pt; font-weight:bold; color:#ffffff;' bgcolor=#18388c>A new Grievance Submitted</td></tr>";

                strbody3 = strbody3 + " <tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:bold; color:#000000;' bgcolor=#ffffff>A new feedback has submitted, customer details are as follows :";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Reference No : " + ackid + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";


                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Name : " + Txtname.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                if (txtaddress.Text.Trim() == "")
                {
                    strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Address : -- ,";
                    strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
                }
                else
                {
                    strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Address : " + txtaddress.Text + ",";
                    strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
                }

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Email : " + Txtemail.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Mobile No : " + Txtmob.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + " <tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";


                if (Ddlsub.SelectedIndex > 0)
                {
                    strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Subject : " + Ddlsub.SelectedItem.Text + ",";
                    strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
                }
                else
                {
                    strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Subject : NA" + ",";
                    strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
                }
                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Feedback : " + Txtfeedback.Text + ",";
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
                if (txtacc.Text.Trim() == "")
                {
                    strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Account No : NA ,";
                    strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
                }
                else
                {
                    strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Account No : " + txtacc.Text + ",";
                    strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
                }
                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Email Copy Sent to Branch : " + rdbcopy.SelectedItem.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";


                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";


                strbody3 = strbody3 + " </table></body></html>";






                MailMessage Mail_br1 = new MailMessage();                
                Mail_br1.From = ma;
                Mail_br1.To.Add(branchemail);
                Mail_br1.Subject = "A new Feedback Submitted";
                Mail_br1.CC.Add("");

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


    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBranch.SelectedIndex != 0)
        {
            txtacc.Enabled = true;
           
        }
        else
        {
            txtacc.Text = "";
            txtacc.Enabled = false;
            
        }
    }
}