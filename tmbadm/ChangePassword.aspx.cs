﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;

public partial class tmbadm_ChangePassword : System.Web.UI.Page
{
    private Audit_trail audtclass = new Audit_trail();
    public AdmPrpty adm = new AdmPrpty();
    Label lblpath1 = default(Label);
    public SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["TMBCON"].ToString());
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    SqlDataReader dr = default(SqlDataReader);
    protected void Page_Load(object sender, EventArgs e)
    {

        lblpath1 = (Label)this.Form.Parent.FindControl("lblSmeModNm");

        string specChar1 = "!@#$%^&*()_[]{};,\"./?-\\|=+";
        btnChngPwd.Attributes.Add("onclick", "javascript: return validate2('" + specChar1 + "','" + txtOldpassword.ClientID + "','" + txtNewpassword.ClientID + "','" + txtConfpassword.ClientID + "');");

        if (!Page.IsPostBack)
        {
            txtcaptcha.Attributes.Add("autocomplete", "off");
            Session["CaptchaImageText"] = GenerateRandomCode().ToString();
            Session["usr_id"] = Session["usr_id"];
            Session["log_name"] = Session["log_name"];

            if (!string.IsNullOrEmpty(Convert.ToString(Session["log_name"])))
            {

                lblmsg.Text = "";
                txtlogin.Text = Convert.ToString(Session["log_name"]);
            }
            else
            {

                Session["usr_id"] = "";
                Session["log_name"] = "";
                Session["usr_dept"] = "";
                Session["usrtype"] = "";
                Session["current_mod"] = "";
                Session.Clear();
                Response.Redirect("TMBAdmin.aspx");
            }
            //lblpath1.Text = "Change Password";
        } 

    }

    private string GenerateRandomCode()
    {
        Random random1 = new Random();
        string s = "";
        for (int i = 0; i <= 5; i++)
        {
            s = s + random1.Next(10).ToString();
        }
        Session["CaptchaImageText"] = s;
        return s;
    }
    public void clear_data()
    {
        lblmsg.Text = "";
        //txtlogin.Text = "";
        string blank1 = "";
        txtOldpassword.Attributes.Add("value", blank1);
        txtNewpassword.Attributes.Add("value", blank1);
        txtConfpassword.Attributes.Add("value", blank1);
    }
    public bool chk_LoginData()
    {
        if (string.IsNullOrEmpty(txtOldpassword.Text))
        {
            lblmsg.Text = "Old Password cannot be blank !!";
            txtOldpassword.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtOldpassword.Text) && !(Regex.IsMatch(txtOldpassword.Text.Trim(), "^(?=.*[A-Za-z])(?=.*\\d)(?=.*[$~^@$!%*#&])[A-Za-z\\d$@$~^!%*#&]{8,20}$")))
        {
            lblmsg.Text = "Password should contain minimum 8 character, maximum 20 character and at least one alphabetic (A-Z and a - z), numeric (0-9) and special character. (~,!,@,#,$,%,^,&,*) ";
            txtOldpassword.Focus();
            return false;
        }
        else if (txtOldpassword.Text.Length < 8)
        {
            lblmsg.Text = "Password should be minimum 8 characters. !!";
            txtOldpassword.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtOldpassword.Text) & txtOldpassword.Text.Length > 20)
        {
            txtOldpassword.Text = txtOldpassword.Text.Substring(0, 20);
            lblmsg.Text = "Password can contain max 20 characters. !!";
            txtOldpassword.Focus();
            return false;
        }
        else if (txtlogin.Text == txtOldpassword.Text)
        {
            lblmsg.Text = "Username and password can not be same !!";
            txtlogin.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtNewpassword.Text))
        {
            lblmsg.Text = "New Password cannot be blank !!";
            txtOldpassword.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtNewpassword.Text) && !(Regex.IsMatch(txtNewpassword.Text.Trim(), "^(?=.*[A-Za-z])(?=.*\\d)(?=.*[$~^@$!%*#&])[A-Za-z\\d$@$~^!%*#&]{8,20}$")))
        {
            lblmsg.Text = "Password should contain minimum 8 character, maximum 20 character and at least one alphabetic (A-Z and a - z), numeric (0-9) and special character. (~,!,@,#,$,%,^,&,*) ";
            txtNewpassword.Focus();
            return false;
        }
        else if (txtNewpassword.Text.Length < 8)
        {
            lblmsg.Text = "Password should be minimum 8 characters. !!";
            txtNewpassword.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtNewpassword.Text) & txtNewpassword.Text.Length > 20)
        {
            txtNewpassword.Text = txtNewpassword.Text.Substring(0, 20);
            lblmsg.Text = "Password can contain max 20 characters. !!";
            txtNewpassword.Focus();
            return false;
        }
        else if (txtlogin.Text == txtNewpassword.Text)
        {
            lblmsg.Text = "Username and New password can not be same !!";
            txtlogin.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtConfpassword.Text))
        {
            lblmsg.Text = "Confirm password cannot be blank !!";
            txtConfpassword.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtConfpassword.Text) && !(Regex.IsMatch(txtConfpassword.Text.Trim(), "^(?=.*[A-Za-z])(?=.*\\d)(?=.*[$~^@$!%*#&])[A-Za-z\\d$@$~^!%*#&]{8,20}$")))
        {
            lblmsg.Text = "Confirm password should contain minimum 8 character, maximum 20 character and at least one alphabetic (A-Z and a - z), numeric (0-9) and special character. (~,!,@,#,$,%,^,&,*) ";
            txtConfpassword.Focus();
            return false;
        }
        else if (txtConfpassword.Text.Length < 8)
        {
            lblmsg.Text = "Confirm password should be minimum 8 characters. !!";
            txtConfpassword.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtConfpassword.Text) & txtConfpassword.Text.Length > 20)
        {
            txtConfpassword.Text = txtConfpassword.Text.Substring(0, 20);
            lblmsg.Text = "Confirm password can contain max 20 characters. !!";
            txtConfpassword.Focus();
            return false;
        }
        else if (!(txtNewpassword.Text == txtConfpassword.Text))
        {
            lblmsg.Text = "New Password and Confirm password must be same !!";
            txtConfpassword.Focus();
            return false;
        }
        else
        {
            lblmsg.Text = "";
            return true;
        }
    }
    protected void btnChngPwd_Click(object sender, EventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            if (chk_LoginData() == true)
            {
                string capcha = txtcaptcha.Text;
                ccJoin.ValidateCaptcha(capcha);

                if (ccJoin.UserValidated == false)
                {
                    lblmsg.Text = "The text you typed as shown in the below image is incorrect !!";
                }
                else
                {
                    lblmsg.Text = "";
                    string encrypPwd = Encryptn.GetMD5HashData(txtOldpassword.Text.Trim());
                    int cnt1 = 0;
                    con.Open();
                    cmd = new SqlCommand("Proc_AmdLog", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@strLogNm", txtlogin.Text.Replace("'", "''").Replace("<", ""));
                    cmd.Parameters.AddWithValue("@strPassword", encrypPwd.Replace("'", "''").Replace("<", ""));
                    cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 20));
                    cmd.Parameters["@Mode"].Value = "LogCnt";
                    cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();

                    if (cnt1 > 0)
                    {
                        int cnt11 = 0;
                        lblmsg.Text = "";
                        con.Close();
                        con.Open();
                        cmd = new SqlCommand("Proc_AmdLog", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        string pwd11 = Encryptn.GetMD5HashData(txtNewpassword.Text);
                        SqlCommand cmd1 = new SqlCommand("Proc_AmdLog", con);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
                        cmd1.Parameters.AddWithValue("@strlog_id", Convert.ToString(Session["usr_id"]));
                        cmd1.Parameters.AddWithValue("@strPassword", pwd11);
                        cmd1.Parameters["@mode"].Value = "CntDupPass1";
                        cnt11 = Convert.ToInt32(cmd1.ExecuteScalar());
                        con.Close();
                        if (cnt11 > 0)
                        {
                            lblmsg.Text = "New password should be different from last 5 password !!";
                            txtNewpassword.Text = "";
                            txtNewpassword.Focus();
                        }
                        else
                        {
                            lblmsg.Text = "";
                            con.Close();
                            con.Open();
                            cmd = new SqlCommand("Proc_AmdLog", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 20));
                            if (!string.IsNullOrEmpty(txtNewpassword.Text))
                            {
                                con.Close();
                                con.Open();
                                SqlCommand cmd11 = new SqlCommand("Proc_AmdLog", con);
                                cmd11.CommandType = CommandType.StoredProcedure;
                                cmd11.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
                                cmd11.Parameters.AddWithValue("@strlog_id", Convert.ToString(Session["usr_id"]));
                                cmd11.Parameters["@mode"].Value = "getpassword";
                                SqlDataAdapter da1 = new SqlDataAdapter();
                                DataSet ds11 = new DataSet();
                                da.SelectCommand = cmd11;
                                da.Fill(ds11, "data1");
                                string pass = ds11.Tables["data1"].Rows[0]["officer_pwd"].ToString();
                                //string pass1 = ds11.Tables["data1"].Rows[0]["Pass_1"].ToString();
                                //string pass2 = ds11.Tables["data1"].Rows[0]["Pass_2"].ToString();
                                //string pass3 = ds11.Tables["data1"].Rows[0]["Pass_3"].ToString();
                                if (!string.IsNullOrEmpty(pwd11))
                                {
                                    //cmd.Parameters.AddWithValue("@Pass1", pass.Replace("'", "''").Replace("<", ""));
                                    //cmd.Parameters.AddWithValue("@Pass2", pass1.Replace("'", "''").Replace("<", ""));
                                    //cmd.Parameters.AddWithValue("@Pass3", pass2.Replace("'", "''").Replace("<", ""));
                                    //cmd.Parameters.AddWithValue("@Pass4", pass3.Replace("'", "''").Replace("<", ""));
                                    cmd.Parameters.AddWithValue("@strPassword", pwd11.Replace("'", "''").Replace("<", ""));
                                    cmd.Parameters.AddWithValue("@strlog_id", Convert.ToString(Session["usr_id"]));
                                    cmd.Parameters["@Mode"].Value = "EditUserLogMkr1";
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    audit_trail_changePass();
                                    clear_data();
                                    Session["usr_id"] = "";
                                    Session["log_name"] = "";
                                    Session["usr_dept"] = "";
                                    Session["password"] = "";
                                    Session["usr_type"] = "";
                                    Session["usr_desig"] = "";
                                    Session.Clear();
                                    Response.Redirect("TMBAdmin.aspx");
                                }
                            }
                        }
                    }
                    else
                    {
                        lblmsg.Text = "Enter valid old password !!";
                        txtOldpassword.Text = "";
                        txtOldpassword.Focus();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
    public void audit_trail_changePass()
    {
        try
        {
            string fields1 = "";
            if (!string.IsNullOrEmpty(txtlogin.Text))
            {
                if (string.IsNullOrEmpty(fields1))
                {
                    fields1 = txtlogin.Text + " change their password. ";
                }
                else
                {
                    fields1 = fields1 + " " + txtlogin.Text + " change their password. ";
                }
            }
            adm.LogNm = Session["log_name"].ToString();
            adm.FieldNm = fields1;
            adm.TblNm = "tbl_LogCBI";
            adm.PageNm = "ChangePassword.aspx";
            adm.ModuleNm = "Change Password";

            adm.Remark = "Reset the password";
            audtclass.AditOnAdd(adm, "Edit");
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        txtcaptcha.Text = "";
    }
}