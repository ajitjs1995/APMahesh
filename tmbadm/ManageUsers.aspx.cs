using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.VisualBasic;

public partial class tmbadm_ManageUsers : System.Web.UI.Page
{
    public AdmChkClass chkclass = new AdmChkClass();
    public SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["TMBCON"]);
    public SqlCommand cmd = new SqlCommand();
    public SqlDataReader dr;
    public SqlDataReader dr1;
    public SqlDataAdapter da = new SqlDataAdapter();
    public DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (Session["usr_privilege"] != "")
        {
            if (Session["usr_privilege"] == "admin")
            {
                try
                {
                    con.Open();
                    int cnt;
                    // cmd = New SqlCommand("select count(*) from USerModAuthMaker a , tbl_AdmModules b where a .off_staff_no='" + Session("officer_staffNo").ToString() + "' and a.mod_id=b.mod_id and b.mod_nm='Adminstrator'", con)
                    cmd = new SqlCommand("Proc_User_Master", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 50));
                    cmd.Parameters.AddWithValue("@strStaffNum", Session["usr_id"].ToString());
                    cmd.Parameters.AddWithValue("@strAuthName", "Adminstrator");
                    cmd.Parameters["@Mode"].Value = "countmoduleusr";
                    cnt = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    if (cnt == 0)
                        Response.Redirect("TMBAdmin.aspx");
                }
                catch (Exception ex)
                {
                    ErrorLog.WriteError(ex.ToString(), ex.Message);
                }
                finally
                {
                }
            }
        }
        if (Session["log_name"] != "")
        {
            if (Page.IsPostBack == false)
            {
                
                bind_authority();
                clear_data();
                if (Session["usr_privilege"] == "Checker")
                {
                    lnkAddNew.Enabled = false;
                }
                bind_users();
                Tr_AddNew.Visible = false;
                Table1.Visible = true;
                lnkAddNew.Visible = true;
                Session["staff_num2"] = "";
            }
        }
    }
    protected void btnSrch_Click(object sender, System.EventArgs e)
    {
        if (txtNameSrch.Text == "" & txtEmailSrch.Text == "" & txtUnmSrch.Text == "" & txtStaffNum.Text == "" & chksrch1.Checked == false & chksrch2.Checked == false & chksrch3.Checked == false & rbtsrch1.Checked == false & rbtsrch2.Checked == false)
        {
            lblchk.Text = "Please select / enter any one field to search !!!";
        }
        else
        {
            bind_users();
            
        }
    }
    public void bind_authority()
    {
        try
        {
            con.Close();
            con.Open();
            cmd = new SqlCommand("Proc_BankAmdMods", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters["@Mode"].Value = "GetMods1";
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds, "tbl_modules");
            con.Close();
            if (ds.Tables["tbl_modules"].Rows.Count == 0)
            {
                dg_modules.DataSource = null;
                dg_modules.DataBind();
                dg_modules.Visible = false;
            }
            else
            {
                dg_modules.Visible = true;
                dg_modules.DataSource = ds.Tables["tbl_modules"];
                dg_modules.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
    public void bind_users()
    {
        try
        {
            string privilage = "";

            if (chksrch1.Checked == true)
                privilage = "Maker";
            else if (chksrch2.Checked == true)
                privilage = "Checker";
            else if (chksrch3.Checked == true)
                privilage = "Both";

            string active1 = "";
            if (rbtsrch1.Checked == true)
                active1 = "Y";
            else if (rbtsrch2.Checked == true)
                active1 = "N";

            int cnt1 = 0;
            con.Open();
            cmd = new SqlCommand("Proc_User_Master", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strStaffNum", txtStaffNum.Text);
            cmd.Parameters.AddWithValue("@strName", txtNameSrch.Text);
            cmd.Parameters.AddWithValue("@strEmail", txtEmailSrch.Text);
            cmd.Parameters.AddWithValue("@strPrivilage", privilage);
            cmd.Parameters.AddWithValue("@strOffStatus", active1);
            cmd.Parameters.AddWithValue("@strUserID", txtUnmSrch.Text);

            cmd.Parameters["@Mode"].Value = "view_count_m";

            cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            if (cnt1 > 0)
            {
                con.Open();
                cmd = new SqlCommand("Proc_User_Master", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strStaffNum", txtStaffNum.Text);
                cmd.Parameters.AddWithValue("@strName", txtNameSrch.Text);
                cmd.Parameters.AddWithValue("@strEmail", txtEmailSrch.Text);

                cmd.Parameters.AddWithValue("@strPrivilage", privilage);
                cmd.Parameters.AddWithValue("@strOffStatus", active1);
                cmd.Parameters.AddWithValue("@strUserID", txtUnmSrch.Text);
                cmd.Parameters.AddWithValue("@strUsrNm", Session["log_name"].ToString());
                cmd.Parameters["@Mode"].Value = "view_all_m";

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds, "officer_tbl");
                con.Close();
                if (ds.Tables["officer_tbl"].Rows.Count != 0)
                {
                    int x1 = ds.Tables["officer_tbl"].Rows.Count;

                    lblmsg.Text = x1 + " " + "Records found.";
                    dg_Usr.Visible = true;

                    try
                    {
                        dg_Usr.DataSource = ds.Tables["officer_tbl"].DefaultView;
                        dg_Usr.DataBind();
                    }
                    catch
                    {
                        try
                        {
                            this.dg_Usr.CurrentPageIndex = 0;
                            this.dg_Usr.DataBind();
                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex.ToString());
                        }
                    }
                }
                else
                {
                    dg_Usr.Visible = false;
                    lblmsg.Text = "No Records found !! ";
                }
            }
            else if (cnt1 == 0)
            {
                dg_Usr.Visible = false;
                lblmsg.Text = "No Records found !! ";
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
    public void clear_data()
    {
        txtName.Text = "";
        txtStaffNo.Text = "";
        txtEmail.Text = "";
        txtMobile.Text = "";
        txtUserID.Text = "";
        txtPwd.Text = "";
        txtConfPwd.Text = "";
        RBYes.Checked = false;
        RBNo.Checked = true;
        bind_authority();
    }
    public bool chk_dataedit()
    {
        if (txtName.Text == "")
        {
            lblchk.Text = "Name can not be blank";
            txtName.Focus();
            return false;
        }
        else if (!Regex.IsMatch(txtName.Text, "^[a-z.A-Z ]+$"))
        {
            lblchk.Text = "Enter valid name";
            txtName.Focus();
            return false;
        }
        //else if (txtMobile.Text == "")
        //{
        //    lblchk.Text = "Mobile no. can not be blank";
        //    txtMobile.Focus();
        //    return false;
        //}
        else if (!string.IsNullOrEmpty(txtMobile.Text.Trim()) & !Regex.IsMatch(txtMobile.Text.Trim(), "^[0-9]$") == false)
        {
            lblchk.Text = "Mobile no. can contain digits only.";
            txtMobile.Focus();
            return false;
        }
        else if (txtMobile.Text != "" & txtMobile.Text.Length < 10)
        {
            lblchk.Text = "Mobile no. can contain min 10 digits";
            txtMobile.Focus();
            return false;
        }
        else if (txtMobile.Text != "" & txtMobile.Text.Length > 10)
        {
            lblchk.Text = "Mobile no. can contain max 10 digits";
            txtMobile.Text = txtMobile.Text.Substring(0, 10);
            txtMobile.Focus();
            return false;
        }
        else if (txtEmail.Text == "")
        {
            lblchk.Text = "Email can not be blank";
            txtEmail.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtEmail.Text) && !Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
        {
            lblchk.Text = "Email address is not in correct format!!";
            txtEmail.Focus();
            return false;
        }
        else if (check_ModuleAlloted() == false)
            return false;
        else
        {
            lblchk.Text = "";
            return true;
        }
    }

    public bool chk_data()
    {
        if (txtName.Text.Trim() == "")
        {
            lblchk.Text = "Name can not be blank";
            txtName.Focus();
            return false;
        }
        else if (!Regex.IsMatch(txtName.Text, "^[a-z.A-Z ]+$"))
        {
            lblchk.Text = "Enter valid name";
            txtName.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtStaffNo.Text))
        {
            lblchk.Text = "Enter Staff no.";
            txtStaffNo.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtStaffNo.Text) && !Regex.IsMatch(txtStaffNo.Text.Trim(), "^[a-z.A-Z.0-9]+$"))
        {
            lblchk.Text = "Enter valid Staff no.";
            txtStaffNo.Focus();
            return false;
        }

        else if (txtMobile.Text != "" & txtMobile.Text.Length > 10)
        {
            lblchk.Text = "Mobile no. can contain max 10 digits";
            txtMobile.Text = txtMobile.Text.Substring(0, 10);
            txtMobile.Focus();
            return false;
        }
        else if (txtEmail.Text == "")
        {
            lblchk.Text = "Email can not be blank";
            txtEmail.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtEmail.Text) && !Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
        {
            lblchk.Text = "Email address is not in correct format!!";
            txtEmail.Focus();
            return false;
        }
        else if (chk_logdata() == false)
            return false;
        else if (check_ModuleAlloted() == false)
            return false;
        else
        {
            lblchk.Text = "";
            return true;
        }
    }
    public bool chk_logdata()
    {
        if (txtUserID.Text == "")
        {
            lblchk.Text = "Username can not be blank";
            txtUserID.Focus();
            return false;
        }
        else if (!Regex.IsMatch(txtUserID.Text, "^[a-z.A-Z0-9 ]+$"))
        {
            lblchk.Text = "Enter valid User name";
            txtUserID.Focus();
            return false;
        }
        else if (Regex.IsMatch(txtUserID.Text, "^[0-9 ]+$"))
        {
            lblchk.Text = "Enter valid User name";
            txtUserID.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtUserID.Text) && txtUserID.Text.Length < 6)
        {
            lblchk.Text = "Username must be minimum 6 characters";
            txtUserID.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtUserID.Text) && !Regex.IsMatch(txtUserID.Text, "a-z.0-9") == false)
        {
            txtUserID.Text = "";
            txtUserID.Focus();
            lblchk.Text = "Enter valid Username";
            return false;
        }
        else if (txtPwd.Text != txtConfPwd.Text)
        {
            lblchk.Text = "Password and confirm password must be same";
            txtConfPwd.Focus();
            return false;
        }
        else if (txtPwd.Text == "")
        {
            lblchk.Text = "Password can not be blank";
            txtPwd.Focus();
            return false;
        }
        else if ((!string.IsNullOrEmpty(txtPwd.Text)
                & !Regex.IsMatch(txtPwd.Text, @"^(?!.* )(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!#%^*?&])[A-Za-z\d$@$!%*?&#^]{8,20}")))
        {
            lblchk.Text = "Password should contain minimum 8 character, maximum 20 character and at least one alphabetic (A-Z an" + "d a - z), numeric (0-9) and special character. (!,@,#,$,%,^,&,*,?) ";

            txtPwd.Focus();

            return false;
        }
        else if (!string.IsNullOrEmpty(txtPwd.Text) && txtPwd.Text.Length < 8)
        {
            lblchk.Text = "Password must be minimum 8 characters";
            txtPwd.Focus();
            return false;
        }
        else if (txtConfPwd.Text == "" + txtConfPwd.Visible == true)
        {
            lblchk.Text = "Confirm password can not be blank";
            txtConfPwd.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtConfPwd.Text) && txtConfPwd.Text.Length < 8)
        {
            lblchk.Text = "Confirm password must be minimum 8 characters";
            txtConfPwd.Focus();
            return false;
        }
        //else if (!string.IsNullOrEmpty(txtConfPwd.Text) && chkCaps(txtConfPwd.Text) == false)
        //{
        //    txtConfPwd.Text = "";
        //    txtConfPwd.Focus();
        //    lblchk.Text = "Confirm password must contain atleast 1 capital letter";
        //    return false;
        //}
        //else if (!string.IsNullOrEmpty(txtConfPwd.Text) && chkSplChars(txtConfPwd.Text) == false)
        //{
        //    txtConfPwd.Text = "";
        //    txtConfPwd.Focus();
        //    lblchk.Text = "Confirm password must contain atleast 1 special character";
        //    return false;
        //}
        else if (txtUserID.Text == txtPwd.Text)
        {
            lblchk.Text = "Username and Password can not be same";
            txtPwd.Focus();
            return false;
        }
        else if (txtUserID.Text == txtConfPwd.Text)
        {
            lblchk.Text = "Username and Password can not be same";
            txtConfPwd.Focus();
            return false;
        }
        else if (txtPwd.Text != txtConfPwd.Text)
        {
            lblchk.Text = "Password and confirm password must be same";
            txtConfPwd.Focus();
            return false;
        }
        else
        {
            lblchk.Text = "";
            return true;
        }
    }
    public bool check_ModuleAlloted()
    {
        int i = 0;
        int j = 0;
        for (i = 0; i <= dg_modules.Items.Count - 1; i++)
        {
            if (((CheckBox)dg_modules.Items[i].Cells[1].FindControl("chkAllot")).Checked == true)
                j = j + 1;
        }

        if (j == 0)
        {
            lblchk.Text = "Allot atleast one module to new user !";
            return false;
        }
        else
        {
            lblchk.Text = "";
            return true;
        }
    }

    public void fill_UsrAuth(string lognm)
    {
        ///''''''''''''''''''' fill main modules
        int cnt1 = 0;
        con.Open();
        cmd = new SqlCommand("Proc_AmdMods", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 20));
        cmd.Parameters.AddWithValue("@strUsrNm", lognm.Replace("'", "''").Replace("<", ""));
        cmd.Parameters["@Mode"].Value = "CntUsrAuthMkr1";
        cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
        con.Close();

        int p = 0;
        for (p = 0; p <= dg_modules.Items.Count - 1; p++)
        {
            ((CheckBox)dg_modules.Items[p].Cells[1].FindControl("chkAllot")).Checked = false;
        }


        if (cnt1 > 0)
        {
            con.Open();
            cmd = new SqlCommand("Proc_AmdMods", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@strUsrNm", lognm.Replace("'", "''").Replace("<", ""));
            cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 20));
            cmd.Parameters["@Mode"].Value = "GetUsrAuthMkr1";
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds, "tbl_modAuth1");
            con.Close();


            if (!(ds.Tables["tbl_modAuth1"].Rows.Count == 0))
            {
                int i = 0;
                string authid1 = "";
                string authunm1 = "";
                string authmod1 = "";


                for (i = 0; i <= ds.Tables["tbl_modAuth1"].Rows.Count - 1; i++)
                {
                    if (Information.IsDBNull(ds.Tables["tbl_modAuth1"].Rows[i]["id1"]) == false)
                    {
                        authid1 = ds.Tables["tbl_modAuth1"].Rows[i]["id1"].ToString();
                    }
                    else
                    {
                        authid1 = "";
                    }

                    if (Information.IsDBNull(ds.Tables["tbl_modAuth1"].Rows[i]["offcr_id"]) == false)
                    {
                        authunm1 = ds.Tables["tbl_modAuth1"].Rows[i]["offcr_id"].ToString();
                    }
                    else
                    {
                        authunm1 = "";
                    }

                    if (Information.IsDBNull(ds.Tables["tbl_modAuth1"].Rows[i]["mod_id"]) == false)
                    {
                        authmod1 = ds.Tables["tbl_modAuth1"].Rows[i]["mod_id"].ToString();
                    }
                    else
                    {
                        authmod1 = "";
                    }

                    int j = 0;
                    int x1 = dg_modules.Items.Count;
                    for (j = 0; j <= dg_modules.Items.Count - 1; j++)
                    {
                        //Dim mod1 As String = ""
                        //mod1 = dg_Mod.Items(j).Cells(2).Text

                        string modid1 = "";
                        modid1 = dg_modules.Items[j].Cells[0].Text;

                        if (modid1 == authmod1)
                        {
                            ((CheckBox)dg_modules.Items[j].Cells[1].FindControl("chkAllot")).Checked = true;
                        }

                    }

                }

            }

        }

        // fill_UsrModuleAuth(lognm)


    }



    protected void btnAdd_Click(object sender, System.EventArgs e)
    {
        try
        {
            var password = txtPwd.Text;
            txtPwd.Attributes.Add("value", password);
            var conpassword = txtConfPwd.Text;
            txtConfPwd.Attributes.Add("value", conpassword);
            string pwd1 = "";
            pwd1 = Encryptn.GetMD5HashData(txtPwd.Text);

            int chkFlag = 0;


            if (lblAddMainHead.Text == "Edit User" | lblAddMainHead.Text == "Add New User")
            {
                if (chk_data() == true)
                    chkFlag = 1;
                else
                    chkFlag = 0;
            }
            else if (lblAddMainHead.Text == "Edit User's Login Details")
            {
                if (chk_logdata() == true)
                    chkFlag = 1;
                else
                    chkFlag = 0;
            }

            if (chkFlag > 0)
            {
                int cnt1 = 0;
                int cnt2 = 0;
                int cnt3 = 0;
                int cnt4 = 0;

                con.Open();
                cmd = new SqlCommand("Proc_User_Master", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // cmd.Parameters.AddWithValue("@strStaffNum", txtStaffNo.Text)
                cmd.Parameters.AddWithValue("@strUserID", txtUserID.Text);
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));

                cmd.Parameters["@Mode"].Value = "uid_ChkDup_m";

                cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

                if (cnt1 == 0)
                {
                    lblchk.Text = "";



                    lblchk.Text = "";

                    con.Open();
                    cmd = new SqlCommand("Proc_User_Master", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@strEmail", txtEmail.Text);
                    // cmd.Parameters.AddWithValue("@strStaffNum", txtStaffNo.Text)
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd.Parameters["@Mode"].Value = "email_chkDup_m";

                    cnt3 = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();

                    if (cnt3 == 0)
                    {

                        lblchk.Text = "";

                        string privilage = "";
                        if (RblPrivilege.SelectedIndex != -1)
                        {
                            privilage = RblPrivilege.SelectedValue;
                        }
                        string active1 = "";
                        if (RBYes.Checked == true)
                            active1 = "Y";
                        else if (RBNo.Checked == true)
                            active1 = "N";

                        con.Open();
                        cmd = new SqlCommand("Proc_User_Master", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@strName", txtName.Text);
                        cmd.Parameters.AddWithValue("@strStaffNum", txtStaffNo.Text);
                        cmd.Parameters.AddWithValue("@strEmail", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@strMobile", txtMobile.Text);
                        cmd.Parameters.AddWithValue("@strPrivilage", privilage);
                        cmd.Parameters.AddWithValue("@strUserID", txtUserID.Text);
                        cmd.Parameters.AddWithValue("@strPwd", pwd1);
                        cmd.Parameters.AddWithValue("@strConfPwd", pwd1);
                        cmd.Parameters.AddWithValue("@strOffStatus", active1);
                        cmd.Parameters.AddWithValue("@strLogedIn", 0);
                        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                        cmd.Parameters["@Mode"].Value = "Officer_add_m";
                        cmd.ExecuteNonQuery();
                        con.Close();

                        if (Session["usr_privilege"] == "Checker" | Session["usr_privilege"] == "Admin")
                        {
                            string off_id = "";
                            con.Open();
                            cmd = new SqlCommand("select officer_id from UserMasterMaker where officer_name='" + txtUserID.Text + "'", con);

                            off_id = cmd.ExecuteScalar().ToString();


                            if (off_id != "")
                            {
                                // cmd = New SqlCommand("delete from officer_master where officer_staffNo='" & txtStaffNo.Text & "'", con)
                                cmd = new SqlCommand("delete from UserMaster where officer_id='" + off_id + "'", con);
                                cmd.ExecuteNonQuery();
                            }
                            con.Close();

                            if (off_id != "")
                            {
                                con.Open();
                                cmd = new SqlCommand("Proc_User_Master", con);
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@strID", off_id);
                                cmd.Parameters.AddWithValue("@strName", txtName.Text);
                                cmd.Parameters.AddWithValue("@strStaffNum", txtStaffNo.Text);
                                cmd.Parameters.AddWithValue("@strEmail", txtEmail.Text);

                                cmd.Parameters.AddWithValue("@strMobile", txtMobile.Text);
                                cmd.Parameters.AddWithValue("@strPrivilage", privilage);
                                cmd.Parameters.AddWithValue("@strUserID", txtUserID.Text);
                                cmd.Parameters.AddWithValue("@strPwd", txtPwd.Text);
                                cmd.Parameters.AddWithValue("@strConfPwd", txtConfPwd.Text);
                                cmd.Parameters.AddWithValue("@strOffStatus", active1);
                                cmd.Parameters.AddWithValue("@strLogedIn", 0);
                                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                                cmd.Parameters["@Mode"].Value = "Officer_add_m";
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }

                        authority_submit();

                        // ''''''''''''''''''''''''  insert into auditrial   ''''''''''''''''''''''''

                        string officer_name = "User_name" + "" + "-" + "" + txtName.Text;
                        string officer_staffNo = "User_staffNo" + "" + "-" + "" + txtStaffNo.Text;
                        string officer_email = "User_email" + "" + "-" + "" + txtEmail.Text;
                        string officer_mobile = "User_mobile" + "" + "-" + "" + txtMobile.Text;
                        string officer_usr_privilege = "User_usr_privilege" + "" + "-" + "" + privilage;
                        string officer_uid = "User_uid" + " " + "-" + " " + txtUserID.Text;
                        string officer_pwd = "User_pwd" + "" + "-" + "" + txtPwd.Text;
                        string officer_conf_pwd = "User_conf_pwd" + "" + "-" + "" + txtConfPwd.Text;
                        string officer_active = "User_active" + "" + "-" + "" + active1;

                        string checked1 = "checked1" + "" + "-" + "" + "No";
                        string last_var = "";
                        last_var = officer_name + " " + "," + " " + officer_staffNo + " " + "," + " " + officer_email + " " + "," + " " + officer_mobile + " " + "," + " " + officer_usr_privilege + " " + "," + " " + officer_uid + " " + "," + " " + officer_pwd + " " + "," + " " + officer_conf_pwd + " " + "," + " " + officer_active + " " + "," + " " + checked1;

                        con.Open();
                        cmd = new SqlCommand("proc_audittrail", con);

                        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));


                        cmd.Parameters.AddWithValue("@strLogNm", Session["log_name"].ToString());
                        cmd.Parameters.AddWithValue("@strLogId", Convert.ToString(Session["usr_id"]));
                        cmd.Parameters.AddWithValue("@strTblNm", "User_master_maker");
                        cmd.Parameters.AddWithValue("@strFildNm", last_var);
                        cmd.Parameters.AddWithValue("@strPgNm", "ManageUser2.aspx");
                        cmd.Parameters.AddWithValue("@strModuleNm", "Manage User");
                        cmd.Parameters.AddWithValue("@strAuditDt", System.DateTime.Now);
                        cmd.Parameters.AddWithValue("@strRemark", "User is Added");
                        cmd.Parameters.AddWithValue("@strAddOn", System.DateTime.Now);
                        cmd.Parameters["@Mode"].Value = "AuditOnAdd";
                        cmd.ExecuteNonQuery();
                        con.Close();

                        // '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                        clear_data();
                        lblchk.Text = "User Details Added Successfully !!!";
                        Tr_AddNew.Visible = false;
                        tr_first.Visible = true;
                        Table1.Visible = true;
                        //bind_authority();
                        bind_users();

                    }
                    else if (cnt3 > 0)
                        lblchk.Text = "This email id already exists";
                }
                else if (cnt1 > 0)
                    lblchk.Text = "This user id is not available";
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
    public void authority_submit()
    {
        try
        {
            int i = 0;
            string off_id = "";
            con.Close();
            con.Open();
            if (Session["edit_lognm"] == "")
                txtUserID.Text = Session["edit_lognm"].ToString();

            cmd = new SqlCommand("select officer_id from UserMasterMaker where officer_uid='" + txtUserID.Text + "'", con);
            off_id = cmd.ExecuteScalar().ToString();
            con.Close();


            if (off_id != "")
            {
                int cnt2 = 0;
                for (i = 0; i <= dg_modules.Items.Count - 1; i++)
                {
                    string mod_id = "";
                    string status = "";
                    con.Open();
                    if (((CheckBox)dg_modules.Items[i].Cells[3].FindControl("chkAllot")).Checked == true)
                    {
                        mod_id = dg_modules.Items[i].Cells[0].Text;

                        cmd = new SqlCommand("select count(id1) from USerModAuthMaker where  mod_id='" + mod_id + "' and offcr_id='" + off_id + "'", con);
                        cnt2 = Convert.ToInt32(cmd.ExecuteScalar());

                        if (cnt2 == 0)
                        {
                            cmd = new SqlCommand("insert into USerModAuthMaker(offcr_id,mod_id,active) values('" + off_id + "','" + mod_id + "','Y')", con);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            cmd = new SqlCommand("select active from USerModAuthMaker where  mod_id='" + mod_id + "'", con);
                            status = Convert.ToString(cmd.ExecuteScalar());
                            if (status == "N")
                            {
                                cmd = new SqlCommand("update USerModAuthMaker set active ='Y' , checked1='N'  where  mod_id='" + mod_id + "' and offcr_id='" + off_id + "'", con);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    con.Close();
                }

                for (i = 0; i <= dg_modules.Items.Count - 1; i++)
                {
                    string mod_id1 = "";
                    int cnt22 = 0;
                    if (((CheckBox)dg_modules.Items[i].Cells[3].FindControl("chkAllot")).Checked == false)
                    {
                        mod_id1 = dg_modules.Items[i].Cells[0].Text;
                        con.Open();
                        cmd = new SqlCommand("select count(id1) from USerModAuthMaker where  mod_id='" + mod_id1 + "' and off_staff_no='" + txtStaffNo.Text + "'", con);
                        cnt22 = Convert.ToInt32(cmd.ExecuteScalar());

                        if (cnt22 > 0)
                        {
                            cmd = new SqlCommand("Update USerModAuthMaker set active='N',checked1='N' where mod_id='" + mod_id1 + "' and off_staff_no='" + txtStaffNo.Text + "'", con);
                            cmd.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    protected void RBYes_CheckedChanged(object sender, System.EventArgs e)
    {
        var password = txtPwd.Text;
        txtPwd.Attributes.Add("value", password);
        var conpassword = txtConfPwd.Text;
        txtConfPwd.Attributes.Add("value", conpassword);

        if (RBYes.Checked == true)
            RBNo.Checked = false;
        else if (RBYes.Checked == false)
            RBNo.Checked = true;
    }

    protected void RBNo_CheckedChanged(object sender, System.EventArgs e)
    {
        var password = txtPwd.Text;
        txtPwd.Attributes.Add("value", password);
        var conpassword = txtConfPwd.Text;
        txtConfPwd.Attributes.Add("value", conpassword);

        if (RBNo.Checked == true)
            RBYes.Checked = false;
        else if (RBNo.Checked == false)
            RBYes.Checked = true;
    }

    protected void dg_modules_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.SelectedItem | e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.EditItem)
            ((CheckBox)e.Item.Cells[3].FindControl("chkAllot")).Checked = false;
    }

    protected void btnCancel_Click(object sender, System.EventArgs e)
    {
        Tr_AddNew.Visible = false;
        Table1.Visible = true;
        lnkAddNew.Visible = true;
        txtName.Text = "";
        txtEmail.Text = "";
        txtMobile.Text = "";
        txtStaffNo.Text = "";
        txtPwd.Text = "";
        txtUserID.Text = "";
        RBNo.Checked = false;
        RBYes.Checked = true;
        lblchk.Text = "";
        bind_authority();
    }

    protected void lnkAddNew_Click(object sender, System.EventArgs e)
    {
        Table1.Visible = false;
        Tr_AddNew.Visible = true;
        lnkAddNew.Visible = false;
        btnAdd.Visible = true;
        btnupdate.Visible = false;
        txtName.Text = "";
        txtEmail.Text = "";
        txtMobile.Text = "";
        txtStaffNo.Text = "";
        txtPwd.Text = "";
        txtUserID.Text = "";
        RBNo.Checked = false;
        RBYes.Checked = true;
        lblAddMainHead.Text = "Add New User";
        Table4.Visible = true;
        tr_LogDtls.Visible = true;
        Table3.Visible = true;
        tr_PersDtls.Visible = true;
        txtUserID.Enabled = true;
        lblchk.Text = "";
        bind_authority();
    }

    public void fill_officer_data()
    {
        try
        {
            int cnt1 = 0;
            con.Open();
            cmd = new SqlCommand("Proc_User_Master", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strID", Session["UsrEdit"]);
            cmd.Parameters["@Mode"].Value = "view_count1_m";

            cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            if (cnt1 > 0)
            {
                con.Open();
                cmd = new SqlCommand("Proc_User_Master", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strID", Session["UsrEdit"]);
                cmd.Parameters["@Mode"].Value = "view_byId_m";
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds, "Officer_data");
                con.Close();
                if (ds.Tables["Officer_data"].Rows.Count != 0)
                {
                    string pwd1 = "";
                    string conf_pwd1 = "";
                    string off_level_id = "";
                    string off_dept_id = "";
                    string off_prev = "";
                    string off_active = "";
                    string off_level_name = "";
                    string br_zo = "";
                    string br_div = "";

                    if (Information.IsDBNull(ds.Tables["Officer_data"].Rows[0][1]) == false)
                        txtName.Text = ds.Tables["Officer_data"].Rows[0][1].ToString();
                    else
                        txtName.Text = "";

                    if (Information.IsDBNull(ds.Tables["Officer_data"].Rows[0][2]) == false)
                        txtStaffNo.Text = ds.Tables["Officer_data"].Rows[0][2].ToString();
                    else
                        txtStaffNo.Text = "";

                    if (Information.IsDBNull(ds.Tables["Officer_data"].Rows[0][3]) == false)
                        off_level_id = ds.Tables["Officer_data"].Rows[0][3].ToString();
                    else
                    {
                        off_level_id = "";
                        off_level_name = "";
                    }

                    if (Information.IsDBNull(ds.Tables["Officer_data"].Rows[0][4]) == false)
                        off_dept_id = ds.Tables["Officer_data"].Rows[0][4].ToString();
                    else
                        off_dept_id = "";

                    if (Information.IsDBNull(ds.Tables["Officer_data"].Rows[0][5]) == false)
                        txtEmail.Text = ds.Tables["Officer_data"].Rows[0][5].ToString();
                    else
                        txtEmail.Text = "";

                    if (Information.IsDBNull(ds.Tables["Officer_data"].Rows[0][5]) == false)
                        txtEmail.Text = ds.Tables["Officer_data"].Rows[0][5].ToString();
                    else
                        txtEmail.Text = "";



                    if (Information.IsDBNull(ds.Tables["Officer_data"].Rows[0][8]) == false)
                        txtMobile.Text = ds.Tables["Officer_data"].Rows[0][8].ToString();
                    else
                        txtMobile.Text = "";

                    if (Information.IsDBNull(ds.Tables["Officer_data"].Rows[0][8]) == false)
                        txtMobile.Text = ds.Tables["Officer_data"].Rows[0][8].ToString();
                    else
                        txtMobile.Text = "";

                    if (Information.IsDBNull(ds.Tables["Officer_data"].Rows[0][9]) == false)
                    {
                        off_prev = ds.Tables["Officer_data"].Rows[0][9].ToString();
                        if (off_prev != "")
                        {
                            RblPrivilege.SelectedValue = off_prev;
                        }
                    }
                    else
                    {
                        off_prev = "";
                    }

                    if (Information.IsDBNull(ds.Tables["Officer_data"].Rows[0][10]) == false)
                        txtUserID.Text = ds.Tables["Officer_data"].Rows[0][10].ToString();
                    else
                        txtUserID.Text = "";

                    if (Information.IsDBNull(ds.Tables["Officer_data"].Rows[0][11]) == false)
                    {
                        pwd1 = ds.Tables["Officer_data"].Rows[0][11].ToString();
                        txtPwd.Attributes.Add("value", pwd1);
                    }
                    else
                    {
                        pwd1 = "";
                        txtPwd.Text = "";
                    }

                    if (Information.IsDBNull(ds.Tables["Officer_data"].Rows[0][12]) == false)
                    {
                        conf_pwd1 = ds.Tables["Officer_data"].Rows[0][12].ToString();
                        txtConfPwd.Attributes.Add("value", conf_pwd1);
                    }
                    else
                    {
                        conf_pwd1 = "";
                        txtConfPwd.Text = "";
                    }

                    if (Information.IsDBNull(ds.Tables["Officer_data"].Rows[0][13]) == false)
                    {
                        off_active = ds.Tables["Officer_data"].Rows[0][13].ToString();

                        if (off_active == "Y")
                        {
                            RBYes.Checked = true;
                            RBNo.Checked = false;
                        }
                        else if (off_active == "N")
                        {
                            RBYes.Checked = false;
                            RBNo.Checked = true;
                        }
                    }
                    else
                    {
                        off_active = "";
                        RBYes.Checked = false;
                        RBNo.Checked = false;
                    }

                    if (off_level_id != "")
                    {
                        string levelnm;
                        string valact;
                        if (Information.IsDBNull(ds.Tables["Officer_data"].Rows[0]["level_name"]) == false)
                            levelnm = ds.Tables["Officer_data"].Rows[0]["level_name"].ToString();
                        else
                            levelnm = "";

                        con.Open();
                        if (levelnm == "Zonal Office")
                        {
                            cmd = new SqlCommand("Proc_User_Master", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                            cmd.Parameters.AddWithValue("@strDeptId", off_dept_id);
                            cmd.Parameters["@Mode"].Value = "cntzovalue";
                            valact = Convert.ToString(cmd.ExecuteScalar());
                        }
                        else if (levelnm == "Divisional Office")
                        {
                            cmd = new SqlCommand("Proc_User_Master", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                            cmd.Parameters.AddWithValue("@strDeptId", off_dept_id);
                            cmd.Parameters["@Mode"].Value = "cntdivvalue";
                            valact = Convert.ToString(cmd.ExecuteScalar());
                        }
                        else if (levelnm == "Branch")
                        {
                            cmd = new SqlCommand("Proc_User_Master", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                            cmd.Parameters.AddWithValue("@strDeptId", off_dept_id);
                            cmd.Parameters["@Mode"].Value = "cntbranchvalue";
                            valact = Convert.ToString(cmd.ExecuteScalar());
                        }
                        else if (levelnm == "CPC")
                        {
                            cmd = new SqlCommand("Proc_User_Master", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                            cmd.Parameters.AddWithValue("@strDeptId", off_dept_id);
                            cmd.Parameters["@Mode"].Value = "cntcpcvalue";
                            valact = Convert.ToString(cmd.ExecuteScalar());
                        }
                        else
                        {
                            cmd = new SqlCommand("Proc_User_Master", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                            cmd.Parameters.AddWithValue("@strDeptId", off_dept_id);
                            cmd.Parameters["@Mode"].Value = "cntdeptvalue";
                            valact = Convert.ToString(cmd.ExecuteScalar());
                        }

                        con.Close();
                    }
                    else
                        off_dept_id = "";
                }
                else if (ds.Tables["Officer_data"].Rows.Count == 0)
                    clear_data();
            }
            else if (cnt1 == 0)
                clear_data();
        }


        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }


    protected void dg_Usr_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        if ((e.CommandName != "Page"))
        {
            string log_id = e.Item.Cells[0].Text;
            string off_nm = e.Item.Cells[11].Text;
            string log_email = e.Item.Cells[12].Text;
            string log_unm = e.Item.Cells[14].Text;
            string log_prev = e.Item.Cells[15].Text;
            string log_act = e.Item.Cells[16].Text;
            string log_chk = e.Item.Cells[17].Text;
            string log_MainDeptId = e.Item.Cells[13].Text;
            string log_StaffNum = e.Item.Cells[3].Text;
            if (log_StaffNum == "&nbsp;")
            {
                log_StaffNum = "";
            }
            string zo_id = e.Item.Cells[21].Text;

            string div_id = e.Item.Cells[22].Text;
            string br_id = e.Item.Cells[24].Text;
            string cpc_id = e.Item.Cells[23].Text;

            string levelnm = e.Item.Cells[25].Text;

            Session["UsrEdit"] = "";
            Session["edit_lognm"] = "";
            // clear_Adddata()
            Tr_AddNew.Visible = false;
            tr_PersDtls.Visible = false;
            tr_LogDtls.Visible = false;
            //lnkAddNew.Visible = false;
            btnSrch.Focus();

            if (e.CommandName == "UsrLogEdit")
            {

                // clear_Adddata()
                Tr_AddNew.Visible = true;
                tr_PersDtls.Visible = false;
                lblModHead.Text = "";
                dg_modules.Visible = false;
                tr_LogDtls.Visible = true;
                // tr_LogDtls.Visible = False
                lnkAddNew.Visible = false;
                Table3.Visible = false;
                Table1.Visible = false;
                lblchk.Text = "";
                lblAddMainHead.Text = "Edit User's Login Details";
                btnAdd.Visible = false;
                btnupdate.Visible = true;
                Session["UsrEdit"] = log_id;
                chkall.Visible = false;
                txtUserID.Text = log_unm;
                txtUserID.Enabled = false;
                string blank1 = "";
                txtPwd.Attributes.Add("value", blank1);
                txtConfPwd.Attributes.Add("value", blank1);
                tr_Moduledetls.Visible = false;
            }
            else if (e.CommandName == "UsrEdit")
            {

                // clear_Adddata()
                Tr_AddNew.Visible = true;
                tr_PersDtls.Visible = true;
                lblModHead.Text = "Modules :";
                dg_modules.Visible = true;
                tr_LogDtls.Visible = false;
                // 'rdbUsrType.SelectedValue = log_prev
                btnAdd.Visible = false;
                Table1.Visible = false;
                Table3.Visible = true;
                txtStaffNo.Enabled = false;
                btnupdate.Visible = true;
                // ' lblErr.Text = ""
                Session["staff_num2"] = log_StaffNum;
                // ' fill_MainDeptAdd("Edit")
                lnkAddNew.Visible = false;
                lblAddMainHead.Text = "Edit User";
                // btnAdd.Text = "Update"

                Session["UsrEdit"] = log_id;
                Session["edit_lognm"] = log_unm;

                // txtName.Text = off_nm
                // txtStaffNo.Text = log_StaffNum
                // txtName.Text = off_nm
                // txtEmail.Text = log_email


                bind_authority();
                fill_UsrAuth(log_id);

                // Fill_AuthCheckerField()
                // dg_modules.Focus()
                tr_Moduledetls.Visible = true;
                fill_officer_data();
            }
            else if (e.CommandName == "UsrDelete")
            {
                con.Open();
                cmd = new SqlCommand("Proc_User_Master", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strId1", log_id);
                cmd.Parameters["@Mode"].Value = "DelUsrMkrById";
                cmd.ExecuteNonQuery();
                con.Close();

                string fields1 = "";

                if (off_nm != "")
                {
                    if (fields1 == "")
                        fields1 = "Name : " + off_nm;
                    else
                        fields1 = fields1 + ", Name : " + off_nm;
                }



                if (log_email != "")
                {
                    if (fields1 == "")
                        fields1 = "Email : " + log_email;
                    else
                        fields1 = fields1 + ", Email : " + log_email;
                }

                // If Not usr_tp = "" Then
                // If fields1 = "" Then
                // fields1 = "User Type : " & usr_tp
                // Else
                // fields1 = fields1 & ", User Type : " & usr_tp
                // End If
                // End If



                if (log_unm != "")
                {
                    if (fields1 == "")
                        fields1 = "Username : " + log_unm;
                    else
                        fields1 = fields1 + ", Username : " + log_unm;
                }

                fields1 = fields1 + ", Privilege : " + log_prev;

                fields1 = fields1 + ", Active : N";

                con.Close();
                con.Open();
                cmd = new SqlCommand("proc_audittrail", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strLogNm", Session["log_name"]);
                cmd.Parameters.AddWithValue("@strTblNm", "User_Master");
                cmd.Parameters.AddWithValue("@strFildNm", fields1);
                cmd.Parameters.AddWithValue("@strPgNm", "Manage_Users.aspx");
                cmd.Parameters.AddWithValue("@strModuleNm", "Manage Masters");
                cmd.Parameters.AddWithValue("@strAuditDt", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@strRemark", "User is deleted");
                cmd.Parameters.AddWithValue("@strDelOn", DateTime.Now.Date);
                cmd.Parameters["@Mode"].Value = "AuditOnDelete";
                cmd.ExecuteNonQuery();
                con.Close();

                Session["UsrEdit"] = "";

                bind_users();
                lblmsg.Text = "";
                lnkAddNew.Visible = true;
                dg_Usr.Focus();
            }
            else if (e.CommandName == "UsrCheck")
            {


                // '''''''''''''''''''''''''''' update checked field
                con.Open();
                cmd = new SqlCommand("Proc_User_Master", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strId1", log_id);
                cmd.Parameters.AddWithValue("@strStaffNum", log_StaffNum);
                cmd.Parameters["@Mode"].Value = "UserCheckMkr";
                cmd.ExecuteNonQuery();
                con.Close();


                // ''''''''''''''''''''''''''''' delete from checker
                // con.Open()
                // cmd = New SqlCommand("[Proc_AcbAmdLog]", con)
                // cmd.CommandType = Data.CommandType.StoredProcedure
                // cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                // cmd.Parameters.AddWithValue("@strLog_Id", log_id)
                // cmd.Parameters["@Mode"].Value = "DelUserChkrById2"
                // cmd.ExecuteNonQuery()
                // con.Close()


                // '''''''''''''''''''''''''''' insert in checker tbl

                // ''''''''''''''  get passwords
                // Dim pwd1 As String = ""
                // con.Open()
                // cmd = New SqlCommand("[Proc_AcbAmdLog]", con)
                // cmd.CommandType = Data.CommandType.StoredProcedure
                // cmd.Parameters.AddWithValue("@strLog_Id", log_id)
                // cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                // cmd.Parameters["@Mode"].Value = "GetLogPwdMkr"
                // If Information.IsDBNull(cmd.ExecuteScalar()) = False Then
                // pwd1 = cmd.ExecuteScalar()
                // Else
                // pwd1 = ""
                // End If
                // con.Close()

                // If Not pwd1 = "" Then

                // con.Open()
                // cmd = New SqlCommand("[Proc_AcbAmdLog]", con)
                // cmd.CommandType = Data.CommandType.StoredProcedure
                // cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                // cmd.Parameters.AddWithValue("@strLog_Id", log_id)
                // cmd.Parameters.AddWithValue("@strName", off_nm)
                // cmd.Parameters.AddWithValue("@strStaffNum", log_StaffNum)
                // ' cmd.Parameters.AddWithValue("@strDesig", log_desig)
                // cmd.Parameters.AddWithValue("@strEmail", log_email)
                // 'cmd.Parameters.AddWithValue("@strUsrType", usr_tp)
                // '  cmd.Parameters.AddWithValue("@strUsrSubDept", log_SubDeptId)
                // cmd.Parameters.AddWithValue("@strLogNm", log_unm)
                // cmd.Parameters.AddWithValue("@strPassword", pwd1)
                // cmd.Parameters.AddWithValue("@strCPassword", pwd1)
                // cmd.Parameters.AddWithValue("@strUsrPrev", log_prev)
                // cmd.Parameters.AddWithValue("@strActive", log_act)
                // cmd.Parameters.AddWithValue("@attemptlog", "0")
                // cmd.Parameters.AddWithValue("@chk_first_timelog", "Y")


                // cmd.Parameters["@Mode"].Value = "AddUserChkr1"
                // cmd.ExecuteNonQuery()
                // con.Close()


                // ''''''''''''   auditrial
                string fields1 = "";
                if (off_nm != "")
                {
                    if (fields1 == "")
                        fields1 = "Name : " + off_nm;
                    else
                        fields1 = fields1 + ", Name : " + off_nm;
                }

                // 

                if (log_email != "")
                {
                    if (fields1 == "")
                        fields1 = "Email : " + log_email;
                    else
                        fields1 = fields1 + ", Email : " + log_email;
                }



                if (log_unm != "")
                {
                    if (fields1 == "")
                        fields1 = "Username : " + log_unm;
                    else
                        fields1 = fields1 + ", Username : " + log_unm;
                }

                fields1 = fields1 + ", Privilege : " + log_prev;

                fields1 = fields1 + ", Active : " + log_act;


                // End If

                con.Close();
                con.Open();
                cmd = new SqlCommand("proc_audittrail", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strLogNm", Session["log_name"]);
                cmd.Parameters.AddWithValue("@strTblNm", "User_Master");
                cmd.Parameters.AddWithValue("@strFildNm", fields1);
                cmd.Parameters.AddWithValue("@strPgNm", "Manage_Users.aspx");
                cmd.Parameters.AddWithValue("@strModuleNm", "Manage Masters");
                cmd.Parameters.AddWithValue("@strAuditDt", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@strRemark", "User is checked by checker");
                cmd.Parameters.AddWithValue("@strChkOn", DateTime.Now.Date);
                cmd.Parameters["@Mode"].Value = "AuditOnCheck";

                cmd.ExecuteNonQuery();
                con.Close();

                bind_users();
                lblmsg.Text = "";
                lnkAddNew.Visible = true;
                dg_Usr.Focus();
            }
            else if (e.CommandName == "UsrAuthChk")
            {
                try
                {
                    con.Open();


                    // '''''''''''''''''''''''''''' update module checked field

                    cmd = new SqlCommand("Proc_User_Master", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd.Parameters.AddWithValue("@strID", log_id);
                    cmd.Parameters["@Mode"].Value = "UserModCheckMkr";
                    cmd.ExecuteNonQuery();


                    // '''''''''''''''''''''''''''' update module allotment checked field

                    cmd = new SqlCommand("Proc_User_Master", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd.Parameters.AddWithValue("@strStaffNum", log_StaffNum);
                    cmd.Parameters["@Mode"].Value = "CheckUsrMods1";
                    cmd.ExecuteNonQuery();


                    // '''''''''''''''''''''''''''' update module authority checked field

                    cmd = new SqlCommand("Proc_User_Master", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd.Parameters.AddWithValue("@strUsrNm", log_unm);
                    cmd.Parameters["@Mode"].Value = "CheckUsrModAuth1";
                    cmd.ExecuteNonQuery();


                    cmd = new SqlCommand("Proc_ManageMenus", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd.Parameters.AddWithValue("@strLogNm", log_unm);
                    cmd.Parameters["@Mode"].Value = "DelPgAuthForUsr_C";
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("Proc_ManageMenus", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd.Parameters.AddWithValue("@strLogNm", log_unm);
                    cmd.Parameters["@Mode"].Value = "getpageauth";
                    da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    ds = new DataSet();
                    da.Fill(ds, "tab_offMkrPgAuth");


                    int k = 0;
                    for (k = 0; k <= ds.Tables["tab_offMkrPgAuth"].Rows.Count - 1; k++)
                    {
                        string pgAuthId = "";
                        string PgParId = "";
                        string act = "";

                        if (Information.IsDBNull(ds.Tables["tab_offMkrPgAuth"].Rows[k]["PgAuthId1"]) == false)
                            pgAuthId = ds.Tables["tab_offMkrPgAuth"].Rows[k]["PgAuthId1"].ToString();
                        else
                            pgAuthId = "";

                        if (Information.IsDBNull(ds.Tables["tab_offMkrPgAuth"].Rows[k]["ParentId"]) == false)
                            PgParId = ds.Tables["tab_offMkrPgAuth"].Rows[k]["ParentId"].ToString();
                        else
                            PgParId = "";
                        if (Information.IsDBNull(ds.Tables["tab_offMkrPgAuth"].Rows[k]["active"]) == false)
                            act = ds.Tables["tab_offMkrPgAuth"].Rows[k]["active"].ToString();
                        else
                            act = "";

                        if (!string.IsNullOrEmpty(pgAuthId) && !string.IsNullOrEmpty(PgParId))
                        {
                            cmd = new SqlCommand("Proc_ManageMenus", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                            cmd.Parameters.AddWithValue("@PgAuthId", pgAuthId);
                            cmd.Parameters.AddWithValue("@strLogNm", log_unm);
                            cmd.Parameters.AddWithValue("@strPgAuthDt", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@strParentId1", PgParId);
                            cmd.Parameters.AddWithValue("@strAction", act);
                            cmd.Parameters["@Mode"].Value = "AddPgAuthChkr1";
                            cmd.ExecuteNonQuery();

                            cmd = new SqlCommand("Proc_ManageCmsPages", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                            cmd.Parameters.AddWithValue("@PgAuthId", pgAuthId);
                            cmd.Parameters["@Mode"].Value = "ChkPgAuthMkr1";
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    // fill_ModAuthChkr(log_unm)

                    bind_users();
                    lblmsg.Text = "";
                    lnkAddNew.Visible = true;
                    dg_Usr.Focus();
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    con.Close();
                }
            }
            else if (e.CommandName == "UsrAuth")
            {
                Session["UsrEdit"] = log_id;
                Session["edit_lognm"] = log_StaffNum;
                string x1 = Session["UsrEdit"].ToString();

                Response.Write("<script type='text/javascript'>detailedresults=window.open('Manage_UserModAuth.aspx','frmMensajeBox','height=575px,width=795px,top=0,left=0');</script>");
            }
            else if (e.CommandName == "UsrPgRight")
            {
                Session["UsrEdit"] = log_id;
                Session["edit_lognm"] = log_unm;
                Session["level_name"] = levelnm;

                string x1 = Session["UsrEdit"].ToString();
                Response.Redirect("Manage_PageRights.aspx");
            }
        }
    }
    protected void btnupdate_Click(object sender, System.EventArgs e)
    {
        try
        {
            con.Open();
            Session["offcer_id"] = Session["UsrEdit"];
            // Dim password = txtPwd.Text
            // txtPwd.Attributes.Add("value", password)
            // Dim conpassword = txtConfPwd.Text
            // txtConfPwd.Attributes.Add("value", conpassword)
            int cnt1 = 0;
            string privilage = "";
            if (RblPrivilege.SelectedIndex != -1)
            {
                privilage = RblPrivilege.SelectedValue;
            }
            string active1 = "";
            if (RBYes.Checked == true)
                active1 = "Y";
            else if (RBNo.Checked == true)
                active1 = "N";

            string officer_name = "officer_name" + "" + "-" + "" + txtName.Text;
            string officer_staffNo = "officer_staffNo" + "" + "-" + "" + txtStaffNo.Text;
            string officer_email = "officer_email" + "" + "-" + "" + txtEmail.Text;
            // Dim officer_std As String = "officer_std" & "" & "-" & "" & txtStd.Text
            // Dim officer_phone As String = "officer_phone" & "" & "-" & "" & txtPhone.Text
            string officer_mobile = "officer_mobile" + "" + "-" + "" + txtMobile.Text;
            string officer_privilege = "officer_privilege" + "" + "-" + "" + privilage;
            string officer_uid = "officer_uid" + " " + "-" + " " + txtUserID.Text;
            string officer_pwd = "officer_pwd" + "" + "-" + "" + txtPwd.Text;
            string officer_conf_pwd = "officer_conf_pwd" + "" + "-" + "" + txtConfPwd.Text;
            string officer_active = "officer_active" + "" + "-" + "" + active1;

            string checked1 = "checked1" + "" + "-" + "" + "N";
            string last_var = "";
            last_var = officer_name + " " + "," + " " + officer_staffNo + " " + "," + " " + officer_email + " " + "," + " " + officer_mobile + " " + "," + " " + officer_privilege + " " + "," + " " + officer_uid + " " + "," + " " + officer_pwd + " " + "," + " " + officer_conf_pwd + " " + "," + " " + officer_active + " " + "," + " " + checked1;


            if (lblAddMainHead.Text == "Edit User's Login Details")
            {
                string pwd1 = "";
                pwd1 = Encryptn.GetMD5HashData(txtPwd.Text);
                // con.Open()
                if (chk_logdata() == true)
                {
                    cmd = new SqlCommand("Proc_User_Master", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@strID", Session["offcer_id"]);
                    cmd.Parameters.AddWithValue("@strUserID", txtUserID.Text);
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                    cmd.Parameters["@Mode"].Value = "uid_ChkDup1_m";
                    cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
                    // con.Close()
                    if (cnt1 == 0)
                    {
                        cmd = new SqlCommand("Proc_User_Master", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                        cmd.Parameters.AddWithValue("@strID", Session["offcer_id"]);
                        cmd.Parameters.AddWithValue("@strUserID", txtUserID.Text);
                        cmd.Parameters.AddWithValue("@strPwd", pwd1);
                        cmd.Parameters.AddWithValue("@strConfPwd", pwd1);
                        cmd.Parameters["@Mode"].Value = "updatelogdetails";
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("proc_audittrail", con);
                        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                        cmd.Parameters.AddWithValue("@strLogNm", Session["log_name"].ToString());
                        cmd.Parameters.AddWithValue("@strLogId", Convert.ToString(Session["usr_id"]));
                        cmd.Parameters.AddWithValue("@strTblNm", "User_master_maker");
                        cmd.Parameters.AddWithValue("@strFildNm", last_var);
                        cmd.Parameters.AddWithValue("@strPgNm", "ManageUser2.aspx");
                        cmd.Parameters.AddWithValue("@strModuleNm", "Manage User");
                        cmd.Parameters.AddWithValue("@strAuditDt", DateAndTime.Now);
                        cmd.Parameters.AddWithValue("@strRemark", "User Login Detail's is Updated");
                        cmd.Parameters.AddWithValue("@strEditOn", DateAndTime.Now);
                        cmd.Parameters["@Mode"].Value = "AuditOnEdit";
                        cmd.ExecuteNonQuery();
                        // con.Close()

                        // '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        clear_data();
                        lblchk.Text = "Login Detail's Updated succesfully !!!";
                        Tr_AddNew.Visible = false;
                        Table1.Visible = true;
                    }
                }
            }
            else if (chk_dataedit() == true)
            {
                int cnt2 = 0;
                int cnt3 = 0;
                int cnt4 = 0;



                // If cnt1 = 0 Then

                // con.Open()
                cmd = new SqlCommand("Proc_User_Master", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@strID", Session["offcer_id"]);
                cmd.Parameters.AddWithValue("@strEmail", txtEmail.Text);
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters["@Mode"].Value = "email_chkDup1_m";
                cnt3 = Convert.ToInt32(cmd.ExecuteScalar());
                // con.Close()

                if (cnt3 == 0)
                {
                    lblchk.Text = "";

                    // con.Open()
                    // cmd = New SqlCommand("Proc_User_Master", con)
                    // cmd.CommandType = Data.CommandType.StoredProcedure
                    // cmd.Parameters.AddWithValue("@strID", Session("offcer_id"))
                    // cmd.Parameters.AddWithValue("@strStaffNum", txtStaffNo.Text)
                    // cmd.Parameters.Add(New SqlParameter("@Mode", Data.SqlDbType.VarChar, 20))
                    // cmd.Parameters["@Mode"].Value = "StaffNo_chkDup1_m"
                    // cnt4 = cmd.ExecuteScalar()
                    // con.Close()

                    // If cnt4 = 0 Then
                    lblchk.Text = "";

                    // If chkBoth.Checked = True Then
                    // privilage = "Both"
                    // ElseIf chkMaker.Checked = True Then
                    // privilage = "Maker"
                    // ElseIf chkCheker.Checked = True Then
                    // privilage = "Checker"
                    // End If


                    // con.Open()
                    cmd = new SqlCommand("Proc_User_Master", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@strID", Session["offcer_id"]);
                    cmd.Parameters.AddWithValue("@strName", txtName.Text);
                    cmd.Parameters.AddWithValue("@strEmail", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@strMobile", txtMobile.Text);
                    cmd.Parameters.AddWithValue("@strPrivilage", privilage);
                    cmd.Parameters.AddWithValue("@strOffStatus", active1);
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                    cmd.Parameters["@Mode"].Value = "Officer_edit_m";
                    cmd.ExecuteNonQuery();
                    // con.Close()

                    authority_submit();

                    // ''''''''''''''''''''''''  insert into auditrial   ''''''''''''''''''''''''

                    con.Open();
                    cmd = new SqlCommand("proc_audittrail", con);
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                    cmd.Parameters.AddWithValue("@strLogNm", Session["log_name"].ToString());
                    cmd.Parameters.AddWithValue("@strLogId", Convert.ToString(Session["usr_id"]));
                    cmd.Parameters.AddWithValue("@strTblNm", "User_master_maker");
                    cmd.Parameters.AddWithValue("@strFildNm", last_var);
                    cmd.Parameters.AddWithValue("@strPgNm", "ManageUser2.aspx");
                    cmd.Parameters.AddWithValue("@strModuleNm", "Manage User");
                    cmd.Parameters.AddWithValue("@strAuditDt", DateAndTime.Now);
                    cmd.Parameters.AddWithValue("@strRemark", "User is Updated");
                    cmd.Parameters.AddWithValue("@strEditOn", DateAndTime.Now);
                    cmd.Parameters["@Mode"].Value = "AuditOnEdit";
                    cmd.ExecuteNonQuery();
                    // con.Close()

                    // '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    clear_data();
                    lblchk.Text = "Updated succesfully !!!";
                    Tr_AddNew.Visible = false;
                    Table1.Visible = true;
                }
                else if (cnt3 > 0)
                    lblchk.Text = "This email id already exists";
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
        bind_users();
    }

    protected void dg_Usr_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.SelectedItem | e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.EditItem)
        {
            string name1 = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "officer_name")) == false)
                name1 = DataBinder.Eval(e.Item.DataItem, "officer_name").ToString();
            else
                name1 = "--";

            string email1 = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "officer_email")) == false)
                email1 = DataBinder.Eval(e.Item.DataItem, "officer_email").ToString();
            else
                email1 = "--";

            string staffnum = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "officer_staffNo")) == false)
            {
                staffnum = DataBinder.Eval(e.Item.DataItem, "officer_staffNo").ToString();
                e.Item.Cells[19].Text = staffnum;
            }
            else
            {
                e.Item.Cells[19].Text = "";
                staffnum = "--";
            }
            e.Item.Cells[2].Text = "Name : " + name1 + "<br>" + "Email : " + email1 + "<br>";


            string deptid = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "officer_Dept")) == false)
            {
                deptid = DataBinder.Eval(e.Item.DataItem, "officer_Dept").ToString();
            }
            else
            {
                deptid = "--";
            }

            string usr_type = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "officer_privilege")) == false)
                usr_type = DataBinder.Eval(e.Item.DataItem, "officer_privilege").ToString();
            else
                usr_type = "";

            string log_name = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "officer_uid")) == false)
                log_name = DataBinder.Eval(e.Item.DataItem, "officer_uid").ToString();
            else
                log_name = "--";

            string usr_privilege = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "officer_privilege")) == false)
                usr_privilege = DataBinder.Eval(e.Item.DataItem, "officer_privilege").ToString();
            else
                usr_privilege = "--";

            string check = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "checked1")) == false)
                check = DataBinder.Eval(e.Item.DataItem, "checked1").ToString();
            else
                check = "--";


            if (usr_type != "")
                ((Label)e.Item.Cells[4].FindControl("lblUsrLogDtls")).Text = "Username : " + log_name + "<br>" + "Privilege : " + usr_privilege;
            else
                ((Label)e.Item.Cells[4].FindControl("lblUsrLogDtls")).Text = "Username : " + log_name + "<br>" + "Privilege : " + usr_privilege;

            string urs_active = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "officer_active")) == false)
                urs_active = DataBinder.Eval(e.Item.DataItem, "officer_active").ToString();
            else
                urs_active = "N";

            string mod_chk1 = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "mod_chk1")) == false)
                mod_chk1 = DataBinder.Eval(e.Item.DataItem, "mod_chk1").ToString();
            else
                mod_chk1 = "N";

            if (log_name != "--")
            {

                // '''''''''''' check for alloted modules
                int cnt1 = 0;
                con.Open();
                cmd = new SqlCommand("Proc_User_Master", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters["@Mode"].Value = "CntMods1";
                cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

                if (cnt1 > 0)
                {
                    int cnt2 = 0;
                    con.Open();
                    cmd = new SqlCommand("Proc_User_Master", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@strUsrNm", Strings.Replace(Strings.Replace(log_name, "'", "''"), "<", ""));
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd.Parameters["@Mode"].Value = "CntUsrAuthMkr1";
                    cnt2 = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();

                    if (cnt2 > 0)
                    {
                        ((LinkButton)e.Item.Cells[5].FindControl("lnkAuth")).Text = "View";
                        ((LinkButton)e.Item.Cells[5].FindControl("lnkAuth")).Enabled = true;

                        if (Session["usr_privilege"] == "Maker")
                        {
                            ((LinkButton)e.Item.Cells[5].FindControl("lnkAuthChk")).Enabled = false;
                            if (mod_chk1 == "Y")
                                ((LinkButton)e.Item.Cells[5].FindControl("lnkAuthChk")).Text = "Auth Checked";
                            else
                                ((LinkButton)e.Item.Cells[5].FindControl("lnkAuthChk")).Text = "Auth Not Checked";
                        }
                        else if (mod_chk1 == "Y")
                        {
                            ((LinkButton)e.Item.Cells[5].FindControl("lnkAuthChk")).Text = "Auth Checked";
                            ((LinkButton)e.Item.Cells[5].FindControl("lnkAuthChk")).Enabled = false;
                        }
                        else
                        {
                            ((LinkButton)e.Item.Cells[5].FindControl("lnkAuthChk")).Text = "Check Auth";
                            if (Session["usr_privilege"] == "admin")
                                ((LinkButton)e.Item.Cells[5].FindControl("lnkAuthChk")).Enabled = false;
                            else if (Session["auth_check"] == "Y")
                                ((LinkButton)e.Item.Cells[5].FindControl("lnkAuthChk")).Enabled = false;
                            else
                                ((LinkButton)e.Item.Cells[5].FindControl("lnkAuthChk")).Enabled = false;
                        }

                        // ''''''''''''''''''''''''''''   page rights link
                        int cntCms = 0;
                        con.Open();
                        cmd = new SqlCommand("Proc_User_Master", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@strUsrNm", log_name);
                        cmd.Parameters.AddWithValue("@strModName", "CMS");
                        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                        cmd.Parameters["@Mode"].Value = "CntAuthByNmUnm_m";
                        cntCms = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                        if (cntCms > 0)
                        {
                            if (chkclass.Chk_ModAuth(Session["log_name"].ToString(), "Content Management", "Manage Page Rights", Session["usr_privilege"].ToString()) == true)
                            {
                                if (Session["usr_privilege"] == "admin" | Session["usr_privilege"] == "Maker")
                                    ((LinkButton)e.Item.Cells[5].FindControl("lnkPageRights")).Enabled = true;
                                else if (Session["auth_view"] == "Y")
                                    ((LinkButton)e.Item.Cells[5].FindControl("lnkPageRights")).Enabled = true;
                                else
                                    ((LinkButton)e.Item.Cells[5].FindControl("lnkPageRights")).Enabled = true;
                            }
                            else
                                ((LinkButton)e.Item.Cells[5].FindControl("lnkPageRights")).Enabled = true;
                        }
                        else
                            ((LinkButton)e.Item.Cells[5].FindControl("lnkPageRights")).Enabled = false;
                    }
                    else
                    {
                        ((LinkButton)e.Item.Cells[5].FindControl("lnkAuth")).Text = "No";
                        ((LinkButton)e.Item.Cells[5].FindControl("lnkAuth")).Enabled = false;

                        ((LinkButton)e.Item.Cells[5].FindControl("lnkAuthChk")).Text = "";
                        ((LinkButton)e.Item.Cells[5].FindControl("lnkAuthChk")).Enabled = false;

                        ((LinkButton)e.Item.Cells[5].FindControl("lnkPageRights")).Enabled = false;

                        ((LinkButton)e.Item.Cells[5].FindControl("lnkPageRights")).Enabled = false;
                    }
                }
                else
                {
                    ((LinkButton)e.Item.Cells[5].FindControl("lnkAuth")).Text = "No";
                    ((LinkButton)e.Item.Cells[5].FindControl("lnkAuth")).Enabled = false;

                    ((LinkButton)e.Item.Cells[5].FindControl("lnkAuthChk")).Text = "";
                    ((LinkButton)e.Item.Cells[5].FindControl("lnkAuthChk")).Enabled = false;

                    ((LinkButton)e.Item.Cells[5].FindControl("lnkPageRights")).Enabled = false;
                }
            }
            else
            {
                ((LinkButton)e.Item.Cells[5].FindControl("lnkAuth")).Text = "No";
                ((LinkButton)e.Item.Cells[5].FindControl("lnkAuth")).Enabled = false;

                ((LinkButton)e.Item.Cells[5].FindControl("lnkAuthChk")).Text = "";
                ((LinkButton)e.Item.Cells[5].FindControl("lnkAuthChk")).Enabled = false;

                ((LinkButton)e.Item.Cells[5].FindControl("lnkPageRights")).Enabled = false;
            }

            if (check == "N")
            {
                ((LinkButton)e.Item.Cells[6].FindControl("lnkCheck")).Enabled = true;
                ((LinkButton)e.Item.Cells[6].FindControl("lnkCheck")).ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                ((LinkButton)e.Item.Cells[6].FindControl("lnkCheck")).Enabled = false;
                ((LinkButton)e.Item.Cells[6].FindControl("lnkCheck")).ForeColor = System.Drawing.Color.Green;
                ((LinkButton)e.Item.Cells[6].FindControl("lnkCheck")).Text = "Checked";
            }
            if (Session["usr_privilege"] == "Maker" & check == "N")
            {
                ((LinkButton)e.Item.Cells[6].FindControl("lnkCheck")).Enabled = false;
                ((LinkButton)e.Item.Cells[6].FindControl("lnkCheck")).ForeColor = System.Drawing.Color.Gray;
            }
            else if (Session["usr_privilege"] == "Maker" & check == "Y")
            {
                ((LinkButton)e.Item.Cells[6].FindControl("lnkCheck")).Enabled = false;
                ((LinkButton)e.Item.Cells[6].FindControl("lnkCheck")).ForeColor = System.Drawing.Color.Green;
                ((LinkButton)e.Item.Cells[6].FindControl("lnkCheck")).Text = "Checked";
            }


            if (urs_active == "N")
            {
                // e.Item.DefaultCellStyle.ForeColor = System.Drawing.Color.Gray
                ((LinkButton)e.Item.Cells[6].FindControl("lnkDelete")).Enabled = false;
                ((LinkButton)e.Item.Cells[6].FindControl("lnkDelete")).ForeColor = System.Drawing.Color.Gray;
                e.Item.Cells[1].ForeColor = System.Drawing.Color.Gray;
                e.Item.Cells[2].ForeColor = System.Drawing.Color.Gray;
                e.Item.Cells[3].ForeColor = System.Drawing.Color.Gray;
                e.Item.Cells[4].ForeColor = System.Drawing.Color.Gray;
                e.Item.Cells[8].ForeColor = System.Drawing.Color.Gray;
            }

            if (Session["usr_privilege"] == "Checker")
            {
                ((LinkButton)e.Item.Cells[6].FindControl("lnkDelete")).Enabled = false;
                ((LinkButton)e.Item.Cells[6].FindControl("lnkEdit")).Enabled = false;
                ((LinkButton)e.Item.Cells[5].FindControl("lnkUsrLogEdit")).Enabled = false;
            }

            // ''''''''''''''confirmation before deletion
            ((LinkButton)e.Item.Cells[6].FindControl("lnkDelete")).Attributes.Add("onclick", "javascript: return confirm('Are you sure you want to delete this user?')");
        }
    }
    protected void chksrch2_CheckedChanged(object sender, System.EventArgs e)
    {
        chksrch2.Checked = true;
        chksrch3.Checked = false;
        chksrch1.Checked = false;
    }

    protected void chksrch3_CheckedChanged(object sender, System.EventArgs e)
    {
        chksrch2.Checked = false;
        chksrch3.Checked = true;
        chksrch1.Checked = false;
    }

    protected void btnReset_Click(object sender, System.EventArgs e)
    {
        txtNameSrch.Text = "";
        txtUnmSrch.Text = "";
        txtEmailSrch.Text = "";
        txtStaffNum.Text = "";
        lblchk.Text = "";
        chksrch1.Checked = false;
        chksrch2.Checked = false;
        chksrch3.Checked = false;
        rbtsrch1.Checked = false;
        rbtsrch2.Checked = false;
        lblSrchErr.Text = "";
        bind_authority();
        bind_users();
    }


    protected void chksrch1_CheckedChanged(object sender, System.EventArgs e)
    {
        chksrch2.Checked = false;
        chksrch3.Checked = false;
        chksrch1.Checked = true;
    }

    protected void chkall_CheckedChanged(object sender, System.EventArgs e)
    {
        if (chkall.Checked == true)
        {
            int p = 0;
            for (p = 0; p <= dg_modules.Items.Count - 1; p++)
                ((CheckBox)dg_modules.Items[p].Cells[1].FindControl("chkAllot")).Checked = true;
        }
        else
        {
            int p = 0;
            for (p = 0; p <= dg_modules.Items.Count - 1; p++)
            {
                ((CheckBox)dg_modules.Items[p].Cells[1].FindControl("chkAllot")).Checked = false;
            }
        }
    }



    protected void RblPrivilege_SelectedIndexChanged(object sender, EventArgs e)
    {
        var password = txtPwd.Text;
        txtPwd.Attributes.Add("value", password);
        var conpassword = txtConfPwd.Text;
        txtConfPwd.Attributes.Add("value", conpassword);
    }
   
}