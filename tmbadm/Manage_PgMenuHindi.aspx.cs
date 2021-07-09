using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Microsoft.VisualBasic;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;


public partial class Admin_Manage_PgMenuHindi : System.Web.UI.Page
{
    private AdmChkClass chkclass = new AdmChkClass();
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["TMBCON"]);
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    System.Data.DataSet ds = new System.Data.DataSet();
    System.Data.DataSet ds1 = new System.Data.DataSet();
    string PgLang = "";
    string fields1 = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usr_privilege"] != null)
        {

            if (Session["usr_privilege"].ToString() != "admin")
            {
                try
                {
                    con.Open();
                    int cnt;
                    //cmd = new SqlCommand("select count(*) from USerModAuthMaker a , tbl_AdmModules b where a .off_staff_no='" + Session["officer_staffNo"].ToString() + "' and a.mod_id=b.mod_id and b.mod_nm='CMS'", con);
                    cmd = new SqlCommand("Proc_User_Master", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 50));
                    cmd.Parameters.AddWithValue("@strStaffNum", Session["officer_staffNo"].ToString());
                    cmd.Parameters.AddWithValue("@strAuthName", "CMS");
                    cmd.Parameters["@Mode"].Value = "countmoduleusr";
                    cnt = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    if (cnt == 0)
                    {
                        Response.Redirect("admlogin.aspx");
                    }


                }
                catch
                {

                }
                finally
                {
                    con.Close();
                }
            }
        }

        string aaa = cmbWebPage.SelectedValue;
        if (!Page.IsPostBack)
        {
            if (chkclass.Chk_ModAuth(Convert.ToString(Session["log_name"]), "Content Management", "Manage PgMenus", Convert.ToString(Session["utype"])) == true)
            {

                Session["LinkId"] = "";
                clear_AddData();
                tr_menu.Visible = false;
                lbllnkid.Text = "0";
                Label1.Text = "0";
                lblparentid.Text = "0";
                btnEditIndex.Visible = false;
                btneditleft.Visible = false;
                btnchildIndex.Visible = false;
                //lblmsg.Text = "";
                if (RadioButtonList1.SelectedValue == "Left")
                {
                    bind_gridleftmenu();
                  
                }
                else
                {
                    bind_grid();
                   
                }
                PgLang = Convert.ToString(Session["PgLanguage"]);
                //lblmsg.Text = "";
                lblMainMsg.Text = "";
                fill_PageNames();
                getPagedetails(Session["PgId1"].ToString());
            }
            else
            {
                Response.Redirect("AdmMainPage.aspx");
            }
        }
    }
    public void getPagedetails(string LnkId)
    {
        try
        {
            string LnkID = LnkId;

            con.Open();
            cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strLnkId", LnkID);

            cmd.Parameters["@Mode"].Value = "GetPageDetailsHindi";

            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds, "Tbl_PageDetails");
            con.Close();
            if (!(ds.Tables["Tbl_PageDetails"].Rows.Count == 0))
            {
                string PageName = "";
                if (Information.IsDBNull(ds.Tables["Tbl_PageDetails"].Rows[0]["PageName"]) == false)
                {
                    PageName = ds.Tables["Tbl_PageDetails"].Rows[0]["PageName"].ToString();
                    Session["PageName"] = PageName;
                }
                else
                {
                    PageName = "";
                }

                string PageType = null;
                if (Information.IsDBNull(ds.Tables["Tbl_PageDetails"].Rows[0]["MainPageName"]) == false)
                {
                    PageType = ds.Tables["Tbl_PageDetails"].Rows[0]["MainPageName"].ToString();
                    Session["PageType"] = PageType;
                }
                else
                {
                    PageType = "";
                }

                string MainParent = null;
                if (Information.IsDBNull(ds.Tables["Tbl_PageDetails"].Rows[0]["MainParentName"]) == false)
                {
                    MainParent = ds.Tables["Tbl_PageDetails"].Rows[0]["MainParentName"].ToString();
                    Session["MainParent"] = MainParent;
                }
                else
                {
                    MainParent = "";
                }

            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    void Audit_Trail()
    {
        if (Session["PageName"] != "")
        {
            fields1 = "Page Name : " + Session["PageName"].ToString();
        }
        if (Session["MainParent"] != "")
        {
            if (fields1 == "")
            {
                fields1 = "Parent : " + Session["MainParent"].ToString();
            }
            else
            {
                fields1 = fields1 + ", Parent : " + Session["MainParent"].ToString();
            }
        }
        if (Session["PageType"] != "")
        {
            if (fields1 == "")
            {
                fields1 = "Page Type : " + Session["PageType"].ToString();
            }
            else
            {
                fields1 = fields1 + ", Page Type : " + Session["PageType"].ToString();
            }
        }
        if (txtManuName.Text.Trim() != "")
        {
            if (fields1 == "")
            {
                fields1 = "Menu Name : " + txtManuName.Text.Trim();
            }
            else
            {
                fields1 = fields1 + " , Menu Name : " + txtManuName.Text.Trim();
            }

        }
        if (!string.IsNullOrEmpty(cmbWebPage.SelectedItem.Text) & cmbWebPage.SelectedIndex != 0)
        {
            if (fields1 == "")
            {
                fields1 = "Menu Page : " + cmbWebPage.SelectedItem.Text;
            }
            else
            {
                fields1 = fields1 + ", Menu Page : " + cmbWebPage.SelectedItem.Text;
            }
        }

        else if (!string.IsNullOrEmpty(FileMenuDoc.FileName) & cmbWebPage.SelectedIndex == 0 & string.IsNullOrEmpty(txturl.Text))
        {
            if (fields1 == "")
            {
                fields1 = "File Name : " + FileMenuDoc.FileName;
            }
            else
            {
                fields1 = fields1 + ", File Name : " + FileMenuDoc.FileName;
            }
        }

        else if (!string.IsNullOrEmpty(lnkMenuFile.Text) & cmbWebPage.SelectedIndex == 0 & string.IsNullOrEmpty(txturl.Text))
        {
            if (fields1 == "")
            {
                fields1 = "File Name : " + lnkMenuFile.Text;
            }
            else
            {
                fields1 = fields1 + ", File Name : " + lnkMenuFile.Text;
            }
        }

        else if (!string.IsNullOrEmpty(txturl.Text) & cmbWebPage.SelectedIndex == 0 & string.IsNullOrEmpty(lnkMenuFile.Text))
        {
            if (fields1 == "")
            {
                fields1 = "URL : " + txturl.Text;
            }
            else
            {
                fields1 = fields1 + ", URL : " + txturl.Text;
            }
        }

        if (!string.IsNullOrEmpty(rdbAct.SelectedValue))
        {
            if (fields1 == "")
            {
                fields1 = "Active : " + rdbAct.SelectedValue;
            }
            else
            {
                fields1 = fields1 + ", Active : " + rdbAct.SelectedValue;
            }
        }
        string LogNm = Session["log_name"].ToString();
        string FieldNm = fields1;
        string LogId = Convert.ToString(Session["log_name"]);
        string TblNm = "PageMenuLinks_Tbl";
        string PageNm = "Manage_PgMenuHindi.aspx";
        string ModuleNm = "Content Management";
        //string Content = Session["Content"].ToString();
        if (btnAdd.Text == "Update")
        {
            string Remark = "Menu is Updated";
            con.Open();
            cmd = new SqlCommand("proc_AuditTrail", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strLogNm", LogNm);
            //cmd.Parameters.AddWithValue("@strLogId", LogId);
            cmd.Parameters.AddWithValue("@strTblNm", TblNm);
            cmd.Parameters.AddWithValue("@strFildNm", FieldNm);
            cmd.Parameters.AddWithValue("@strPgNm", PageNm);
            cmd.Parameters.AddWithValue("@strModuleNm", ModuleNm);
            //cmd.Parameters.AddWithValue("@strUpdatedContent", Content);
            cmd.Parameters.AddWithValue("@strAuditDt", DateTime.Now);
            cmd.Parameters.AddWithValue("@strRemark", Remark);
            cmd.Parameters.AddWithValue("@strEditOn", DateTime.Now);
            cmd.Parameters["@mode"].Value = "AuditOnEdit";
            cmd.ExecuteNonQuery();
            con.Close();
        }
        else if (btnAdd.Text == "Add")
        {
            string Remark = "Menu is Added";
            con.Open();
            cmd = new SqlCommand("proc_AuditTrail", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strLogNm", LogNm);
            //cmd.Parameters.AddWithValue("@strLogId", LogId);
            cmd.Parameters.AddWithValue("@strTblNm", TblNm);
            cmd.Parameters.AddWithValue("@strFildNm", FieldNm);
            cmd.Parameters.AddWithValue("@strPgNm", PageNm);
            cmd.Parameters.AddWithValue("@strModuleNm", ModuleNm);
            //cmd.Parameters.AddWithValue("@strUpdatedContent", Content);
            cmd.Parameters.AddWithValue("@strAuditDt", DateTime.Now);
            cmd.Parameters.AddWithValue("@strRemark", Remark);
            cmd.Parameters.AddWithValue("@strAddOn", DateTime.Now);
            cmd.Parameters["@mode"].Value = "AuditOnAdd";
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    public void fill_PageNames()
    {
        try
        {
            int cnt1 = 0;
            PgLang = Convert.ToString(Session["PgLanguage"]);
            con.Open();
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strPageId", Session["PgId1"]);
            if (PgLang == "Hindi")
            {
                cmd.Parameters["@Mode"].Value = "cntHndPg1";
            }
            else
            {
                cmd.Parameters["@Mode"].Value = "cntPgMaker2";
            }
            cnt1 = (int)cmd.ExecuteScalar();
            con.Close();

            if (cnt1 > 0)
            {
                con.Open();
                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                PgLang = Convert.ToString(Session["PgLanguage"]);
                cmd.Parameters.AddWithValue("@strPageId", Session["PgId1"]);
                if (PgLang == "Hindi")
                {
                    cmd.Parameters["@Mode"].Value = "shHndPg1";
                }
                else
                {
                    cmd.Parameters["@Mode"].Value = "shPgMaker2";
                }
            }
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "tbl_Main2");
            con.Close();
            if (!(ds.Tables["tbl_Main2"].Rows.Count == 0))
            {
                cmbWebPage.Items.Clear();
                cmbWebPage.DataSource = ds.Tables["tbl_Main2"];
                cmbWebPage.DataTextField = "PageName";
                cmbWebPage.DataValueField = "PageID";
                cmbWebPage.DataBind();
                cmbWebPage.Items.Insert(0, "Select Web Page");
                cmbWebPage.SelectedIndex = 0;
                Session["pageID"] = ds.Tables["tbl_Main2"].Rows[0]["PageID"].ToString();
            }
            else
            {
                cmbWebPage.Items.Clear();
                cmbWebPage.Items.Insert(0, "Select Web Page");
                cmbWebPage.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            string ma1 = "";
            ma1 = ex.ToString();

            if (!ma1.Contains("Thread was being aborted"))
            {
                try
                {
                    Response.Write(ex.Message);
                }
                catch
                {
                }
            }
        }
    }
    public void clear_AddData()
    {
        Session["CityEdit"] = "";
        txtManuName.Text = "";
        cmbWebPage.SelectedIndex = 0;
        txtTempFilenm.Text = "";

        lblAddMainHead.Text = "Add New Menu";
        btnAdd.Text = "Add";
        lblMainMsg.Text = "";
        lnkMenuFile.Text = "";
        rdbAct.SelectedIndex = 0;
        rbtmenulocation.SelectedIndex = 0;
        txturl.Text = "";
    }
    public void bind_grid()
    {
        try
        {
            btnEditIndex.Visible = false;
            lblmsg.Text = "";
            int cnt1 = 0;
            int cnt2 = 0;
            int pgid = int.Parse(Session["PgId1"].ToString());
            string GetPgID = pgid.ToString();

            PgLang = Convert.ToString(Session["PgLanguage"]);
            con.Open();
            cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strPageId", GetPgID);
          
            cmd.Parameters["@Mode"].Value = "CntMenuItemHMkr1";
            
            cnt1 = (int)cmd.ExecuteScalar();
            con.Close();

            con.Open();
            cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strPageId", GetPgID);
           
                cmd.Parameters["@Mode"].Value = "CntMenuItemHMkr2";
           
            cnt2 = (int)cmd.ExecuteScalar();
            con.Close();
            int cnt3 = cnt1 + cnt2;

            if (cnt3 > 0)
            {
                if (cnt1 > 0)
                {
                    GetPgID = pgid.ToString();
                    con.Open();
                    cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd.Parameters.AddWithValue("@strPageId", GetPgID);
                   
                        cmd.Parameters["@Mode"].Value = "ShMenuItemHMkr1";
                   
                    da = new SqlDataAdapter();
                    da.SelectCommand = cmd;

                    da.Fill(ds, "tbl_MenuDtls1");
                    con.Close();
                }
                if (cnt2 > 0)
                {
                    con.Open();
                    cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd.Parameters.AddWithValue("@strPageId", GetPgID);
                  
                        cmd.Parameters["@Mode"].Value = "ShMenuItemHMkr2";
                   
                    da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds1 = new DataSet();

                    da.Fill(ds1, "tbl_MenuDtls1");
                    con.Close();
                }

                int flag1 = 0;
                if (cnt1 > 0 & cnt2 > 0)
                {
                    ds.Merge(ds1);
                    flag1 = 1;
                }
                else if (cnt1 > 0 & cnt2 == 0)
                {
                    flag1 = 1;
                }
                else if (cnt1 == 0 & cnt2 > 0)
                {
                    flag1 = 2;
                }

                //'********************   bind grid

                if (flag1 == 1)
                {

                    if (!(ds.Tables["tbl_MenuDtls1"].Rows.Count == 0))
                    {
                        if (Convert.IsDBNull(ds.Tables["tbl_MenuDtls1"].Rows[0]["PageName"]) == false)
                        {
                            lblParentPage.Text = "You Are Here >> " + ds.Tables["tbl_MenuDtls1"].Rows[0]["PageName"].ToString();

                        }

                        if (string.IsNullOrEmpty(lblmsg.Text))
                        {
                            lblmsg.Text = ds.Tables["tbl_MenuDtls1"].Rows.Count + " Records found !!";
                        }

                        dg_Menu.Visible = true;
                        if (Session["utype"].ToString() == "Maker" || Session["utype"].ToString() == "admin" || Session["utype"].ToString() == "Both")
                        {
                            btnEditIndex.Visible = true;
                        }
                        else
                        {
                            btnEditIndex.Visible = true;
                            btnEditIndex.Enabled = false;
                        }
                       // btnEditIndex.Visible = true;
                        try
                        {
                            dg_Menu.DataSource = ds.Tables["tbl_MenuDtls1"].DefaultView;
                            dg_Menu.DataBind();
                        }
                        catch
                        {
                            try
                            {
                                this.dg_Menu.CurrentPageIndex = 0;
                                this.dg_Menu.DataBind();
                            }
                            catch (Exception ex)
                            {
                                Response.Write(ex.ToString());
                            }
                        }
                    }
                    else
                    {
                        btnEditIndex.Visible = false;
                        dg_Menu.DataSource = null;
                        dg_Menu.DataBind();
                        dg_Menu.Visible = false;
                        lblmsg.Text = "No records found";
                    }
                }
                else if (flag1 == 2)
                {

                    if (!(ds1.Tables["tbl_MenuDtls1"].Rows.Count == 0))
                    {
                        if (Convert.IsDBNull(ds1.Tables["tbl_MenuDtls1"].Rows[0]["PageName"]) == false)
                        {
                            lblParentPage.Text = "You Are Here >> " + ds1.Tables["tbl_MenuDtls1"].Rows[0]["PageName"].ToString();
                        }

                        if (string.IsNullOrEmpty(lblmsg.Text))
                        {
                            lblmsg.Text = ds1.Tables["tbl_MenuDtls1"].Rows.Count + " Records found !!";
                        }

                        dg_Menu.Visible = true;
                        if (Session["utype"].ToString() == "Maker" || Session["utype"].ToString() == "admin" || Session["utype"].ToString() == "Both")
                        {
                            btnEditIndex.Visible = true;
                        }
                        else
                        {
                            btnEditIndex.Visible = true;
                            btnEditIndex.Enabled = false;
                        }
                        try
                        {
                            dg_Menu.DataSource = ds1.Tables["tbl_MenuDtls1"].DefaultView;
                            dg_Menu.DataBind();
                        }
                        catch
                        {
                            try
                            {
                                this.dg_Menu.CurrentPageIndex = 0;
                                this.dg_Menu.DataBind();
                            }
                            catch (Exception ex)
                            {
                                Response.Write(ex.ToString());
                            }
                        }
                    }
                    else
                    {
                        btnEditIndex.Visible = false;
                        dg_Menu.DataSource = null;
                        dg_Menu.DataBind();
                        dg_Menu.Visible = false;
                        lblmsg.Text = "No records found";
                    }
                }
                else
                {
                    btnEditIndex.Visible = false;
                    dg_Menu.DataSource = null;
                    dg_Menu.DataBind();
                    dg_Menu.Visible = false;
                    lblmsg.Text = "No records found";
                }
                //'**********************************************************************
            }
            else
            {
                dg_Menu.DataSource = null;
                dg_Menu.DataBind();
                dg_Menu.Visible = false;
                lblmsg.Text = "No records found";
                btnEditIndex.Visible = false;
            }
            if (string.IsNullOrEmpty(lblParentPage.Text))
            {
                lnkHome.Visible = false;
                lnkBack.Visible = false;
            }
            else
            {
                lnkHome.Visible = true;
                lnkBack.Visible = true;
            }

        }
        catch (Exception ex)
        {
            string ma1 = "";
            ma1 = ex.ToString();

            if (!ma1.Contains("Thread was being aborted"))
            {
                try
                {
                    Response.Write(ex.Message);
                }
                catch
                {
                }
            }
        }
    }

    public void bind_gridleftmenu()
    {
        try
        {
            btnEditIndex.Visible = false;
            lblmsg.Text = "";
            int cnt1 = 0;
            int cnt2 = 0;
            int pgid = int.Parse(Session["PgId1"].ToString());
            string GetPgID = pgid.ToString();

            PgLang = Convert.ToString(Session["PgLanguage"]);
            con.Open();
            cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strPageId", GetPgID);

            cmd.Parameters["@Mode"].Value = "CntMenuItemHLeft";
          
            cnt1 = (int)cmd.ExecuteScalar();
            con.Close();

            con.Open();
            cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strPageId", GetPgID);
            cmd.Parameters["@Mode"].Value = "CntMenuItemHLeft";
           
            cnt2 = (int)cmd.ExecuteScalar();
            con.Close();
            int cnt3 = cnt1 + cnt2;

            if (cnt3 > 0)
            {
                if (cnt1 > 0)
                {
                    GetPgID = pgid.ToString();
                    con.Open();
                    cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd.Parameters.AddWithValue("@strPageId", GetPgID);
                    //if (PgLang == "Hindi")
                    //{
                    cmd.Parameters["@Mode"].Value = "ShMenuItemHLeft";
                   
                    da = new SqlDataAdapter();
                    da.SelectCommand = cmd;

                    da.Fill(ds, "tbl_MenuDtls1");
                    con.Close();
                }
                if (cnt2 > 0)
                {
                    con.Open();
                    cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd.Parameters.AddWithValue("@strPageId", GetPgID);
                   
                    cmd.Parameters["@Mode"].Value = "ShMenuItemHLeft";
                    da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds1 = new DataSet();

                    da.Fill(ds1, "tbl_MenuDtls1");
                    con.Close();
                }

                int flag1 = 0;
                if (cnt1 > 0 & cnt2 > 0)
                {
                    ds.Merge(ds1);
                    flag1 = 1;
                }
                else if (cnt1 > 0 & cnt2 == 0)
                {
                    flag1 = 1;
                }
                else if (cnt1 == 0 & cnt2 > 0)
                {
                    flag1 = 2;
                }

                //'********************   bind grid

                if (flag1 == 1)
                {

                    if (!(ds.Tables["tbl_MenuDtls1"].Rows.Count == 0))
                    {
                        if (Convert.IsDBNull(ds.Tables["tbl_MenuDtls1"].Rows[0]["PageName"]) == false)
                        {
                            lblParentPage.Text = "You Are Here >> " + ds.Tables["tbl_MenuDtls1"].Rows[0]["PageName"].ToString();

                        }

                        if (string.IsNullOrEmpty(lblmsg.Text))
                        {
                            lblmsg.Text = ds.Tables["tbl_MenuDtls1"].Rows.Count + " Records found !!";
                        }

                        dgleft_menu.Visible = true;
                        if (Session["utype"].ToString() == "Maker" || Session["utype"].ToString() == "admin" || Session["utype"].ToString() == "Both")
                        {
                            btneditleft.Visible = true;
                        }
                        else
                        {
                            btneditleft.Visible = true;
                            btneditleft.Enabled = false;
                        }
                       // btneditleft.Visible = true;
                        try
                        {
                            dgleft_menu.DataSource = ds.Tables["tbl_MenuDtls1"].DefaultView;
                            dgleft_menu.DataBind();
                        }
                        catch
                        {
                            try
                            {
                                this.dgleft_menu.CurrentPageIndex = 0;
                                this.dgleft_menu.DataBind();
                            }
                            catch (Exception ex)
                            {
                                Response.Write(ex.ToString());
                            }
                        }
                    }
                    else
                    {
                        btnEditIndex.Visible = false;
                        dgleft_menu.DataSource = null;
                        dgleft_menu.DataBind();
                        dgleft_menu.Visible = false;
                        lblmsg.Text = "No records found";
                    }
                }
                else if (flag1 == 2)
                {

                    if (!(ds1.Tables["tbl_MenuDtls1"].Rows.Count == 0))
                    {
                        if (Convert.IsDBNull(ds1.Tables["tbl_MenuDtls1"].Rows[0]["PageName"]) == false)
                        {
                            lblParentPage.Text = "You Are Here >> " + ds1.Tables["tbl_MenuDtls1"].Rows[0]["PageName"].ToString();
                        }

                        if (string.IsNullOrEmpty(lblmsg.Text))
                        {
                            lblmsg.Text = ds1.Tables["tbl_MenuDtls1"].Rows.Count + " Records found !!";
                        }

                        dgleft_menu.Visible = true;
                        if (Session["utype"].ToString() == "Maker" || Session["utype"].ToString() == "admin" || Session["utype"].ToString() == "Both")
                        {
                            btneditleft.Visible = true;
                        }
                        else
                        {
                            btneditleft.Visible = true;
                            btneditleft.Enabled = false;
                        }
                        try
                        {
                            dgleft_menu.DataSource = ds1.Tables["tbl_MenuDtls1"].DefaultView;
                            dgleft_menu.DataBind();
                        }
                        catch
                        {
                            try
                            {
                                this.dgleft_menu.CurrentPageIndex = 0;
                                this.dgleft_menu.DataBind();
                            }
                            catch (Exception ex)
                            {
                                Response.Write(ex.ToString());
                            }
                        }
                    }
                    else
                    {
                        btnEditIndex.Visible = false;
                        dgleft_menu.DataSource = null;
                        dgleft_menu.DataBind();
                        dgleft_menu.Visible = false;
                        lblmsg.Text = "No records found";
                    }
                }
                else
                {
                    btnEditIndex.Visible = false;
                    dgleft_menu.DataSource = null;
                    dgleft_menu.DataBind();
                    dgleft_menu.Visible = false;
                    lblmsg.Text = "No records found";
                }
                //'**********************************************************************
            }
            else
            {
                dgleft_menu.DataSource = null;
                dgleft_menu.DataBind();
                dgleft_menu.Visible = false;
                lblmsg.Text = "No records found";
                btnEditIndex.Visible = false;
            }
            if (string.IsNullOrEmpty(lblParentPage.Text))
            {
                lnkHome.Visible = false;
                lnkBack.Visible = false;
            }
            else
            {
                lnkHome.Visible = true;
                lnkBack.Visible = true;
            }

        }
        catch (Exception ex)
        {
            string ma1 = "";
            ma1 = ex.ToString();

            if (!ma1.Contains("Thread was being aborted"))
            {
                try
                {
                    Response.Write(ex.Message);
                }
                catch
                {
                }
            }
        }
    }
    public void fill_MenuDtls(string lnkFileNm, string LnkId)
    {
        try
        {
            string LnkID = LnkId;
            string filenm = lnkFileNm;

            con.Open();
            cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strLnkId", LnkID);


            if (filenm.Contains("#") | filenm.Contains(".com") | filenm.Contains(".in") | filenm.Contains(".org") | filenm.Contains(".nic"))
            {
                cmd.Parameters["@Mode"].Value = "ShLnkByIdHnd";
            }
            else if (filenm.Contains(".aspx"))
            {
                cmd.Parameters["@Mode"].Value = "ShLnkByIdM1Hindi";
            }
            else if (filenm.Contains(".doc") | filenm.Contains(".pdf") | filenm.Contains(".zip") | filenm.Contains(".xlx") | filenm.Contains(".xlsx") | filenm.Contains(".docx"))
            {
                cmd.Parameters["@Mode"].Value = "ShLnkByIdHnd";
            }
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds, "tbl_LnkDtls");
            con.Close();
            if (!(ds.Tables["tbl_LnkDtls"].Rows.Count == 0))
            {
                if (Information.IsDBNull(ds.Tables["tbl_LnkDtls"].Rows[0]["LnkName"]) == false)
                {
                    txtManuName.Text = ds.Tables["tbl_LnkDtls"].Rows[0]["LnkName"].ToString();
                }
                else
                {
                    txtManuName.Text = "";
                }
                if (Information.IsDBNull(ds.Tables["tbl_LnkDtls"].Rows[0]["menulocation"]) == false)
                {
                    rbtmenulocation.SelectedValue = ds.Tables["tbl_LnkDtls"].Rows[0]["menulocation"].ToString();
                }
                string lnkact = null;
                if (Information.IsDBNull(ds.Tables["tbl_LnkDtls"].Rows[0]["lnkact"]) == false)
                {
                    lnkact = ds.Tables["tbl_LnkDtls"].Rows[0]["lnkact"].ToString();
                }
                else
                {
                    lnkact = "";
                }
                if (lnkact == "N")
                {
                    rdbAct.SelectedIndex = 1;
                }
                else
                {
                    rdbAct.SelectedIndex = 0;
                }

                if (lnkFileNm.Contains("#") | lnkFileNm.Contains(".com") | lnkFileNm.Contains(".in") | lnkFileNm.Contains(".org") | lnkFileNm.Contains(".nic"))
                {
                    txturl.Text = ds.Tables["tbl_LnkDtls"].Rows[0]["LnkHLink"].ToString();
                    txtTempFilenm.Text = "";
                    lnkMenuFile.Text = "";
                }

                else if (lnkFileNm.Contains(".aspx"))
                {
                    if (Information.IsDBNull(ds.Tables["tbl_LnkDtls"].Rows[0]["lnkhypgid"]) == false)
                    {
                        cmbWebPage.SelectedValue = ds.Tables["tbl_LnkDtls"].Rows[0]["lnkhypgid"].ToString();
                    }
                    else
                    {
                        cmbWebPage.SelectedIndex = 0;
                    }
                    txtTempFilenm.Text = "";
                    lnkMenuFile.Text = "";
                    txturl.Text = "";
                }
                else if (lnkFileNm.Contains(".doc") | lnkFileNm.Contains(".pdf") | lnkFileNm.Contains(".zip") | lnkFileNm.Contains(".xlx") | lnkFileNm.Contains(".xlsx") | lnkFileNm.Contains(".docx"))
                {
                   
                    cmbWebPage.SelectedIndex = 0;
                    if (Information.IsDBNull(ds.Tables["tbl_LnkDtls"].Rows[0]["LnkHLink"]) == false)
                    {
                        txtTempFilenm.Text = "";
                        lnkMenuFile.Text = ds.Tables["tbl_LnkDtls"].Rows[0]["LnkHLink"].ToString();
                    }
                    else
                    {
                        txtTempFilenm.Text = "";
                        lnkMenuFile.Text = "";
                        txturl.Text = "";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    public void bindchild(int pgid)
    {
        try
        {
            SqlDataAdapter da = new SqlDataAdapter();
            string GetPgID = pgid.ToString();
            PgLang = "English";

            con.Open();
            cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@strLnkId", GetPgID);
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters["@Mode"].Value = "GetChildLnkHnd1";
           

            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            da.Fill(ds, "childpgTbl");
            con.Close();

            if (ds.Tables["childpgTbl"].Rows.Count == 0)
            {
                dgchild.DataSource = null;
                dgchild.DataBind();
                dgchild.Visible = false;
                btnEditIndex.Visible = false;
                dgleft_menu.Visible = false;
                btneditleft.Visible = false;
            }
            else
            {
                dgchild.Visible = true;
                btnchildIndex.Visible = true;
                if (Session["utype"].ToString() == "Maker" || Session["utype"].ToString() == "admin" || Session["utype"].ToString() == "Both")
                {
                    btnchildIndex.Visible = true;
                }
                else
                {
                    btnchildIndex.Visible = true;
                    btnchildIndex.Enabled = false;
                }
                //RadioButtonList1.Visible = false;
                try
                {
                    dgchild.DataSource = ds.Tables["childpgTbl"].DefaultView;
                    dgchild.DataBind();
                }
                catch
                {
                    try
                    {
                        this.dgchild.CurrentPageIndex = 0;
                        this.dgchild.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.ToString());
                    }
                }
            }
            clear_AddData();
            lblmsg.Text = "";
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
    public static bool HasMzSignature(string fileName)
    {
        try
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    double mzSignature = reader.ReadInt16();
                    if (mzSignature == 0x5a4d)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        catch
        {
        }
        return false;
    }

    public bool checkRealFile(FileUpload passfile)
    {
        if (passfile.HasFile)
        {
            if (passfile.PostedFile.ContentType == "application/doc" | passfile.PostedFile.ContentType == "application/zip" | passfile.PostedFile.ContentType == "application/vnd.ms-excel" | passfile.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" | passfile.PostedFile.ContentType == "application/docx" | passfile.PostedFile.ContentType == "application/msword" | passfile.PostedFile.ContentType == "application/pdf" | passfile.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
            {
                passfile.PostedFile.SaveAs(Server.MapPath("..\\PageMenuDocs") + "\\" + passfile.FileName);
                if (HasMzSignature(Server.MapPath("..\\PageMenuDocs\\" + passfile.FileName)))
                {
                    FileInfo fd = new FileInfo(Server.MapPath("..\\PageMenuDocs\\" + passfile.FileName));
                    fd.Delete();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
        System.GC.Collect();
    }
    public bool chk_data()
    {
        if (txtManuName.Text.Trim() == "")
        {
            lblMainMsg.Text = "Please enter menu text !!";
            txtManuName.Focus();
            return false;
        }

        else
        if (string.IsNullOrEmpty(txtManuName.Text))
        {
            lblMainMsg.Text = "Please enter menu text !!";
            txtManuName.Focus();
            return false;
        }
        else if (txtManuName.Text.Length < 5)
        {
            lblMainMsg.Text = "Enter minimum 5 characters in Menu Text";
            txtManuName.Focus();
            return false;
        }
        else if (txtManuName.Text.Length > 100)
        {
            lblMainMsg.Text = "Maximum limit exceeded for menu text";
            txtManuName.Focus();
            return false;
        }
        //else if (!string.IsNullOrEmpty(txtManuName.Text) & !Regex.IsMatch(txtManuName.Text, "^[a-z.A-Z.0-9-_%@,():./'& ]+$"))
        //{
        //    lblMainMsg.Text = "Enter valid menu text !!";
        //    txtManuName.Focus();
        //    return false;
        //}
        else if (!(btnAdd.Text.Equals("Update")) & cmbWebPage.SelectedIndex == 0 & string.IsNullOrEmpty(Path.GetFileName(FileMenuDoc.PostedFile.FileName)) & txturl.Text == "")
        {
            lblMainMsg.Text = "Please select page or attach file or external URL to menu !!";
            cmbWebPage.Focus();
            return false;

        }
        else if (!(cmbWebPage.SelectedIndex == 0) & Information.IsNumeric(cmbWebPage.SelectedValue) == false)
        {
            lblMainMsg.Text = "Select valid page !!";
            cmbWebPage.SelectedIndex = 0;
            cmbWebPage.Focus();
            return false;
        }
        else if (!(cmbWebPage.SelectedIndex == 0) & !string.IsNullOrEmpty(Path.GetFileName(FileMenuDoc.PostedFile.FileName)))
        {
            lblMainMsg.Text = "Please select either page or attach file to menu !!";
            cmbWebPage.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(Path.GetFileName(FileMenuDoc.PostedFile.FileName)) & !Regex.IsMatch(Path.GetFileName(FileMenuDoc.PostedFile.FileName), "^[a-z.A-Z.0-9-_(). ]+$"))
        {
            lblMainMsg.Text = "Enter valid file name !";
            FileMenuDoc.Focus();
            return false;
        }
        //else if (!string.IsNullOrEmpty(Path.GetFileName(FileMenuDoc.PostedFile.FileName)) & !Path.GetFileName(FileMenuDoc.PostedFile.FileName).Contains(".doc") & !Path.GetFileName(FileMenuDoc.PostedFile.FileName).Contains(".pdf"))
        //{
        //    lblMainMsg.Text = "Only word and pdf documents are allowed to upload";
        //    FileMenuDoc.Focus();
        //    return false;
        //}
        else if (!string.IsNullOrEmpty(Path.GetFileName(FileMenuDoc.PostedFile.FileName)) & Path.GetFileName(FileMenuDoc.PostedFile.FileName).Contains(".docx") & Path.GetFileName(FileMenuDoc.PostedFile.FileName).Contains(".xlsx") & Path.GetFileName(FileMenuDoc.PostedFile.FileName).Contains(".doc") & Path.GetFileName(FileMenuDoc.PostedFile.FileName).Contains(".pdf") & Path.GetFileName(FileMenuDoc.PostedFile.FileName).Contains(".zip"))
        {
            lblMainMsg.Text = "Only doc,docx,xls,xlxs,pdf,zip documents are allowed to upload !!";
            FileMenuDoc.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(Path.GetFileName(FileMenuDoc.PostedFile.FileName)) & checkRealFile(FileMenuDoc) == false)
        {
            lblMainMsg.Text = "Only  doc,docx,xls,xlxs,pdf,zip documents are allowed to upload !!";
            FileMenuDoc.Focus();
            return false;
        }
        //else if (!string.IsNullOrEmpty(txturl.Text) & !Regex.IsMatch(txturl.Text, "^[a-z.A-Z.0- 9-_*#/.:%& ]+$"))
        //{
        //    lblMainMsg.Text = "Enter valid url";
        //    txturl.Focus();
        //    return false;
        //}
        else if ((txturl.Text == "") & (cmbWebPage.SelectedIndex == 0) & (String.IsNullOrEmpty(Path.GetFileName(FileMenuDoc.PostedFile.FileName))) & (lnkMenuFile.Text == ""))
        {
            lblMainMsg.Text = "External URL / Page Name / Upload File either one of the Options needs to be selected/uploaded/entered !!";
            rdbAct.Focus();
            return false;
        }
        else if (!(rdbAct.SelectedValue == "Y") & !(rdbAct.SelectedValue == "N"))
        {
            lblMainMsg.Text = "Select whether menu is active !!";
            rdbAct.Focus();
            return false;
        }
        else if (!(rbtmenulocation.SelectedValue == "Left") & !(rbtmenulocation.SelectedValue == "Right") & !(rbtmenulocation.SelectedValue == "Both") & !(rbtmenulocation.SelectedValue == "NotBoth"))
        {
            lblMainMsg.Text = "Select menu location !!";
            rdbAct.Focus();
            return false;
        }
        else
        {
            lblMainMsg.Text = "";
            return true;
        }
    }
    public void recurchild(int id1)
    {
        con.Open();
        cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
        cmd.Parameters.AddWithValue("@strParentLnkId", id1);
        cmd.Parameters["@Mode"].Value = "GetHLnkMkrDel2";
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataSet ds = new DataSet();
        da.Fill(ds, "tbl_LnkDtls2");
        con.Close();
        if (!(ds.Tables["tbl_LnkDtls2"].Rows.Count == 0))
        {
            int i = 0;

            for (i = 0; i <= ds.Tables["tbl_LnkDtls2"].Rows.Count - 1; i++)
            {
                int lid = 0;
                string lnm = "";
                int pgcnt = 0;

                pgcnt = (int)ds.Tables["tbl_LnkDtls2"].Rows[i]["countpage"];

                lnm = ds.Tables["tbl_LnkDtls2"].Rows[i]["lnkname"].ToString();

                lid = (int)ds.Tables["tbl_LnkDtls2"].Rows[i]["lnkid"];

                if (pgcnt != 0)
                {
                    recurchild(lid);
                }
                string LnkID = lid.ToString();
                con.Open();
                cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strLnkId", LnkID);
                if (PgLang == "Hindi")
                {
                    cmd.Parameters["@Mode"].Value = "DelHndLnMkr1";
                }
                else
                {
                    cmd.Parameters["@Mode"].Value = "DelLnMkr1";
                }
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
    protected void dg_Menu_ItemCommand1(object source, DataGridCommandEventArgs e)
    {
        string linkid1 = e.Item.Cells[0].Text;
        string linknm1 = e.Item.Cells[2].Text;
        string linkdoc1 = e.Item.Cells[4].Text;
        string lnkindex1 = ((TextBox)e.Item.Cells[5].FindControl("txtMenuIndex")).Text;
        string linkPgId1 = e.Item.Cells[8].Text;
        string linkParId1 = e.Item.Cells[9].Text;
        string linkParLnkId1 = e.Item.Cells[10].Text;
        string linkact1 = e.Item.Cells[11].Text;
        string LnkID = linkid1;
        string LnkName = linknm1;
        string LnkDoc = linkdoc1;
        string LnkIndex = lnkindex1;
        string LnkAct = linkact1;
        string LnkParid = linkParLnkId1;
        string GetPrntID = linkParId1;
        string GetPgID = linkPgId1;

        if (e.CommandName == "AddChild")
        {
            lnkHome.Visible = true;
            lnkBack.Visible = true;

            Label5.Visible = false;
            rbtmenulocation.Visible = false;

            dgleft_menu.Visible = false;
            btneditleft.Visible = false;
            btnEditIndex.Visible = false;
            dg_Menu.Visible = false;
           // RadioButtonList1.Visible = false;
            lblparentid.Text = Label1.Text;
            int a = int.Parse(lbllnkid.Text);
            lbllnkid.Text = (a + 1).ToString();
            Label1.Text = linkid1;
            int linkid2 = int.Parse(linkid1);
            bindchild(linkid2);
            clear_AddData();
            tr_menu.Visible = true;
            lblAddMainHead.Text = "Add New Menu";
            btnAdd.Text = "Add";

            lblParentPage.Text = lblParentPage.Text + ">>" + e.Item.Cells[2].Text;
        }
        else if (e.CommandName == "MenuEdit")
        {
            Session["LnkId"] = linkid1;
            clear_AddData();
            tr_menu.Visible = true;
            Table1.Visible = true;
            lblAddMainHead.Text = "Update Menu";
            btnAdd.Text = "Update";
            tval.Text = linkid1;
            fill_MenuDtls(linkdoc1, Session["LnkId"].ToString());
        }
        else if (e.CommandName == "MenuCheck")
        {
            try
            {
                // string LnkID = "";
                // string LnkName = "";
                string LnkHLink = "";
                string PageID = "";
                string Parentid = "";
                // string LnkIndex = "";
                string menulocation = "";
                string parentlinkid = "";
                string lnkAct = "";
                con.Open();
                cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 50));
                cmd.Parameters.AddWithValue("@strLnkId", linkid1);
                cmd.Parameters["@Mode"].Value = "updatemenustatusHnd";
                cmd.ExecuteScalar();

                cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 50));
                cmd.Parameters.AddWithValue("@strLnkId", linkid1);
                cmd.Parameters["@Mode"].Value = "getmenuHnd";
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                ds = new DataSet();
                adp.Fill(ds, "tbl_cont");
                if (ds.Tables["tbl_cont"].Rows.Count > 0)
                {
                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["LnkID"]) == false)
                    {
                        LnkID = ds.Tables["tbl_cont"].Rows[0]["LnkID"].ToString();

                    }
                    else
                    {
                        LnkID = "";
                    }
                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["LnkName"]) == false)
                    {
                        LnkName = ds.Tables["tbl_cont"].Rows[0]["LnkName"].ToString();

                    }
                    else
                    {
                        LnkName = "";
                    }
                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["LnkHLink"]) == false)
                    {
                        LnkHLink = ds.Tables["tbl_cont"].Rows[0]["LnkHLink"].ToString();

                    }
                    else
                    {
                        LnkHLink = "";
                    }
                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["PageID"]) == false)
                    {
                        PageID = ds.Tables["tbl_cont"].Rows[0]["PageID"].ToString();

                    }
                    else
                    {
                        PageID = "";
                    }
                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["Parentid"]) == false)
                    {
                        Parentid = ds.Tables["tbl_cont"].Rows[0]["Parentid"].ToString();

                    }
                    else
                    {
                        Parentid = "";
                    }
                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["LnkIndex"]) == false)
                    {
                        LnkIndex = ds.Tables["tbl_cont"].Rows[0]["LnkIndex"].ToString();

                    }
                    else
                    {
                        LnkIndex = "";
                    }
                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["parentlinkid"]) == false)
                    {
                        parentlinkid = ds.Tables["tbl_cont"].Rows[0]["parentlinkid"].ToString();

                    }
                    else
                    {
                        parentlinkid = "";
                    }

                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["lnkAct"]) == false)
                    {
                        lnkAct = ds.Tables["tbl_cont"].Rows[0]["lnkAct"].ToString();

                    }
                    else
                    {
                        lnkAct = "";
                    }
                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["menulocation"]) == false)
                    {
                        menulocation = ds.Tables["tbl_cont"].Rows[0]["menulocation"].ToString();

                    }
                    else
                    {
                        menulocation = "";
                    }

                    cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                    cmd.Parameters.AddWithValue("@strLnkId", linkid1);
                    cmd.Parameters["@Mode"].Value = "deletemenuHnd";
                    cmd.ExecuteNonQuery();


                    cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd.Parameters.AddWithValue("@strLnkId", LnkID);
                    cmd.Parameters.AddWithValue("@strLnkNm", LnkName);
                    cmd.Parameters.AddWithValue("@strLnkHLink", LnkHLink);
                    cmd.Parameters.AddWithValue("@strPageId", PageID);
                    cmd.Parameters.AddWithValue("@strParentId1", Parentid);
                    cmd.Parameters.AddWithValue("@strLnkIndex", LnkIndex);
                    cmd.Parameters.AddWithValue("@strParentLnkId", parentlinkid);
                    cmd.Parameters.AddWithValue("@strlnkact", lnkAct);
                    cmd.Parameters.AddWithValue("@strmenulocation", menulocation);
                    cmd.Parameters["@Mode"].Value = "AddLnkHindi";
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                    cmd.Parameters.AddWithValue("@strLnkId", linkid1);
                    cmd.Parameters["@Mode"].Value = "updatemenuchkHnd";
                    cmd.ExecuteNonQuery();

                }


            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
            bind_grid();
          
        }

        else if (e.CommandName == "MenuDelete")
        {
            Session["LnkId"] = linkid1;
            con.Open();
            cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strLnkId", linkid1);
            
                cmd.Parameters["@Mode"].Value = "GetHndLnkMkrDel";
           
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            da.Fill(ds, "tbl_LnkDtls1");
            con.Close();

            if (!(ds.Tables["tbl_LnkDtls1"].Rows.Count == 0))
            {
                int pgcnt = 0;
                int parentLnkid = 0;
                int ID1 = 0;

                pgcnt = (int)ds.Tables["tbl_LnkDtls1"].Rows[0]["countpage"];

                parentLnkid = (int)ds.Tables["tbl_LnkDtls1"].Rows[0]["parentlinkid"];

                ID1 = (int)ds.Tables["tbl_LnkDtls1"].Rows[0]["lnkid"];

                //if (pgcnt != 0)
                //{
                //    recurchild(ID1);
                //}
                con.Open();
                cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strLnkId", Convert.ToString(Session["LnkId"]));
                cmd.Parameters["@Mode"].Value = "DelHndLnMkr1";
               
                cmd.ExecuteNonQuery();
                con.Close();


                if (lbllnkid.Text == "0")
                {
                   // bind_grid();
                }
                else
                {
                    int i = parentLnkid;
                    bindchild(parentLnkid);
                }
            }
            string mnm1 = linknm1;

            string fields1 = "";
            if (!string.IsNullOrEmpty(mnm1))
            {
                if (string.IsNullOrEmpty(fields1))
                {
                    fields1 = "Menu : " + mnm1 + " is deleted";
                }
                else
                {
                    fields1 = fields1 + ", Menu : " + mnm1 + " is deleted";
                }
            }
            ///''''''''''''''''''''''''''''''''''''''''''''''''''''''''call Audit Trail Function
            ///
            con.Open();
            cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strLnkId", linkid1);
            cmd.Parameters["@Mode"].Value = "deletemenuHndchk";
            cmd.ExecuteNonQuery();
            con.Close();
             bind_grid();
        }
     //   btnEditIndex.Visible = true;
       // btneditleft.Visible = false;
    }
    protected void lnkHome_Click(object sender, EventArgs e)
    {
        bind_gridleftmenu();
        dg_Menu.Visible = false;
        RadioButtonList1.Visible = true;
        RadioButtonList1.SelectedValue = "Left";
        dgchild.Visible = false;
        btnchildIndex.Visible = false;
        lbllnkid.Text = "0";
        lblparentid.Text = "0";
        Label1.Text = "0";
        clear_AddData();
        tr_menu.Visible = false;
    }
    protected void lnkBack_Click(object sender, EventArgs e)
    {
        if (lbllnkid.Text != "0")
        {
            int pnm1 = lblParentPage.Text.Length;
            string pnm;
            // 
            pnm1 = lblParentPage.Text.LastIndexOf(">>", pnm1 - 1);
            pnm = lblParentPage.Text.Substring(0, pnm1);
            lblParentPage.Text = pnm.ToString();

            int tempid = 0;

            if (lblparentid.Text == "0")
            {
               //bind_grid();
                bind_gridleftmenu();
                dg_Menu.Visible = false;
                RadioButtonList1.Visible = true;
                RadioButtonList1.SelectedValue = "Left";
                dgchild.Visible = false;
                btnchildIndex.Visible = false;
            }
            else
            {
                tempid = int.Parse(lblparentid.Text);
                bindchild(tempid);
            }
            string pid = "0";

            lblparentid.Text = pid;
            int a = int.Parse(lbllnkid.Text);
            lbllnkid.Text = (a - 1).ToString();
        }
        Label1.Text = "0";
        clear_AddData();
        tr_menu.Visible = false;
    }
    protected void btnEditIndex_Click(object sender, EventArgs e)
    {
        try
        {
            int i = 0;
            int j = 0;
            if (!(dg_Menu.Items.Count == 0))
            {
                for (i = 0; i <= dg_Menu.Items.Count - 1; i++)
                {
                    if (j == i)
                    {
                        if (string.IsNullOrEmpty(((TextBox)dg_Menu.Items[i].Cells[4].FindControl("txtMenuIndex")).Text))
                        {
                            lblmsg.Text = "Menu Index can not be blank !!";
                        }
                        else if (Information.IsNumeric(((TextBox)dg_Menu.Items[i].Cells[4].FindControl("txtMenuIndex")).Text) == false)
                        {
                            lblmsg.Text = "Menu Index no. can contain digits only !!";
                        }
                        else if (((TextBox)dg_Menu.Items[i].Cells[4].FindControl("txtMenuIndex")).Text.Length > 2)
                        {
                            lblmsg.Text = "Enter valid Menu index !!";
                        }
                        else
                        {
                            lblmsg.Text = "";
                            j = j + 1;
                        }
                    }
                }
                if (j == dg_Menu.Items.Count)
                {
                    lblmsg.Text = "";
                    int n = 0;
                    int flag2 = 0;
                    for (n = 0; n <= dg_Menu.Items.Count - 1; n++)
                    {
                        if (flag2 == n)
                        {
                            //'**********************
                            string text1 = ((TextBox)dg_Menu.Items[n].Cells[4].FindControl("txtMenuIndex")).Text;
                            int x1 = 0;

                            int y = 0;
                            for (y = 0; y <= dg_Menu.Items.Count - 1; y++)
                            {
                                if (x1 < 2)
                                {
                                    //x1 = 0
                                    if (((TextBox)dg_Menu.Items[y].Cells[4].FindControl("txtMenuIndex")).Text == text1)
                                    {
                                        x1 = x1 + 1;
                                    }
                                }
                                else
                                {
                                    lblmsg.Text = "Menu Index sequence must be unique !!";
                                }
                            }
                            if (x1 < 2)
                            {
                                lblmsg.Text = "";
                                flag2 = flag2 + 1;
                            }
                            else if (x1 > 1)
                            {
                                lblmsg.Text = "Menu Index sequence must be unique !!";
                            }
                            //'************************
                        }
                    }
                    if (flag2 == dg_Menu.Items.Count)
                    {
                        int p = 0;

                        for (p = 0; p <= dg_Menu.Items.Count - 1; p++)
                        {
                            int MenuId = int.Parse(dg_Menu.Items[p].Cells[0].Text);
                            string MenuIndex = ((TextBox)dg_Menu.Items[p].Cells[4].FindControl("txtMenuIndex")).Text;
                            string LnkID = MenuId.ToString();
                            string LnkIndex = MenuIndex;
                            con.Open();
                            cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                            cmd.Parameters.AddWithValue("@strLnkId", LnkID);
                            cmd.Parameters.AddWithValue("@strLnkIndex", LnkIndex);
                          
                                cmd.Parameters["@Mode"].Value = "EditIndexHnd1";
                           
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        lblmsg.Text = "Menu index updated successfully !!";

                        bind_grid();
                        btneditleft.Visible = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
    protected void lnkBackMain_Click(object sender, EventArgs e)
    {
        Session["LnkId"] = "";
        Session["PgId1"] = "";

        if (Session["MenuPg"].ToString() == "InnerPgMain")
        {
            Session["MenuPg"] = "";
            Response.Redirect("Manage_InnerPage.aspx");
        }
        else if (Session["MenuPg"].ToString() == "InnerPgEdit")
        {
            Session["MenuPg"] = "";
            Response.Redirect("Manage_InnerPageEdit.aspx");
        }
    }
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        clear_AddData();
        tr_menu.Visible = true;
        lblAddMainHead.Text = "Add New Menu";
        btnAdd.Text = "Add";

        if (RadioButtonList1.SelectedValue == "Left")
        {
            rbtmenulocation.SelectedValue = "Left";
        }
        else
        {
            rbtmenulocation.SelectedValue = "Right";
        }
        Table1.Visible = true;
        clear_AddData();
        //cmbWebPage.SelectedValue = Session["pageID"].ToString();
        //cmbWebPage.Enabled = false;
        //Session["pageID"] = ds.Tables["tbl_Main2"].Rows[0]["PageID"].ToString();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            int length = 0;
            length = FileMenuDoc.PostedFile.ContentLength;
            if (!string.IsNullOrEmpty(Path.GetFileName(FileMenuDoc.PostedFile.FileName)) & Path.GetFileName(FileMenuDoc.PostedFile.FileName).Contains(".docx") & Path.GetFileName(FileMenuDoc.PostedFile.FileName).Contains(".xlsx") & Path.GetFileName(FileMenuDoc.PostedFile.FileName).Contains(".doc") & Path.GetFileName(FileMenuDoc.PostedFile.FileName).Contains(".pdf") & Path.GetFileName(FileMenuDoc.PostedFile.FileName).Contains(".zip"))
            {
                lblMainMsg.Text = "Only doc,docx,xls,xlxs,pdf,zip documents are allowed to upload !!";
            }
            else if (length >= 5242880)
            {
                lblMainMsg.Text = "Your file size shold be less than 5MB";
                FileMenuDoc.Focus();

            }
            else if (chk_data() == true)
            {
                lblMainMsg.Text = "";

                int flag1 = 0;
                int flag2 = 0;

                if (cmbWebPage.SelectedIndex == 0)
                {
                    if (string.IsNullOrEmpty(Path.GetFileName(FileMenuDoc.PostedFile.FileName)) & txturl.Text == "" & lnkMenuFile.Text == "")
                    {
                        flag1 = 0;
                        lblMainMsg.Text = "Either select page or upload file or URL for menu";
                    }
                    else if (!string.IsNullOrEmpty(Path.GetFileName(FileMenuDoc.PostedFile.FileName)))
                    {
                        txtTempFilenm.Text = Path.GetFileName(FileMenuDoc.PostedFile.FileName);

                        int len1 = 0;
                        len1 = FileMenuDoc.PostedFile.ContentLength;
                        if (!Path.GetFileName(FileMenuDoc.PostedFile.FileName).Contains(".doc") & !Path.GetFileName(FileMenuDoc.PostedFile.FileName).Contains(".pdf"))
                        {
                            lblMainMsg.Text = "Only word and pdf documents are allowed to upload";
                            FileMenuDoc.Focus();
                            flag1 = 0;
                        }
                        if (!Regex.IsMatch(Path.GetFileName(FileMenuDoc.PostedFile.FileName), "^[a-z.A-Z.0-9-_(). ]+$"))
                        {
                            lblMainMsg.Text = "Enter valid file name !";
                            FileMenuDoc.Focus();
                            flag1 = 0;
                        }
                        else
                        {
                            lblMainMsg.Text = "";
                            flag1 = flag1 + 1;
                        }
                    }
                    else if (txturl.Text != "")
                    {
                        lblMainMsg.Text = "";
                        flag1 = flag1 + 1;
                    }
                    else
                    {
                        flag1 = flag1 + 1;
                    }
                }
                else
                {
                    flag1 = flag1 + 1;
                }
                if (flag1 > 0)
                {
                    ///''''''''''''''''''   add data
                    if (btnAdd.Text == "Add")
                    {
                        int cnt1 = 0;
                        string LnkID = Session["PgId1"].ToString();
                        string LnkName = Strings.Trim(txtManuName.Text);
                        string LnkParid = Label1.Text;
                        //cnt1 = ui.ChkDupLnkM1(cms);
                        con.Open();
                        cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                        cmd.Parameters.AddWithValue("@strLnkNm", LnkName);
                        cmd.Parameters.AddWithValue("@strPageId", LnkID);
                        cmd.Parameters.AddWithValue("@strParentLnkId", LnkParid);
                        cmd.Parameters["@Mode"].Value = "ChkDupLnkHindi";
                        cnt1 = (int)cmd.ExecuteScalar();
                        con.Close();
                        if (cnt1 == 0)
                        {
                            lblMainMsg.Text = "";

                            string strHLink = "";
                            string strParentID = "";
                            string strLinkIndex = "";

                            if (!(cmbWebPage.SelectedIndex == 0))
                            {
                                string Pagename = cmbWebPage.SelectedValue;

                                DataSet ds = new DataSet();
                                int cntPg1 = 0;
                                con.Open();
                                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                                cmd.Parameters.AddWithValue("@strPageId", Pagename);
                              
                                    cmd.Parameters["@Mode"].Value = "CntHndPgMkrById";
                               
                                cntPg1 = (int)cmd.ExecuteScalar();
                                con.Close();

                                if (cntPg1 > 0)
                                {
                                    con.Open();
                                    cmd = new SqlCommand("Proc_ManageCmsPages", con);
                                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                                    cmd.Parameters.AddWithValue("@strPageId", Pagename);
                                  
                                        cmd.Parameters["@Mode"].Value = "GetHndPgMkrById";
                                    
                                    da = new SqlDataAdapter();
                                    da.SelectCommand = cmd;
                                }
                                da.Fill(ds, "tbl_PgDtls");
                                con.Close();

                                if ((ds != null))
                                {
                                    if (!(ds.Tables["tbl_PgDtls"].Rows.Count == 0))
                                    {
                                        if (Information.IsDBNull(ds.Tables["tbl_PgDtls"].Rows[0]["PageFileName"]) == false)
                                        {
                                            strHLink = ds.Tables["tbl_PgDtls"].Rows[0]["PageFileName"].ToString();
                                        }
                                        else
                                        {
                                            strHLink = "";
                                        }

                                        if (Information.IsDBNull(ds.Tables["tbl_PgDtls"].Rows[0]["ParentID"]) == false)
                                        {
                                            strParentID = ds.Tables["tbl_PgDtls"].Rows[0]["ParentID"].ToString();
                                        }
                                        else
                                        {
                                            strParentID = "";
                                        }
                                    }
                                }
                                else if (!string.IsNullOrEmpty(Path.GetFileName(FileMenuDoc.PostedFile.FileName)))
                                {
                                    strHLink = txtTempFilenm.Text;
                                    strParentID = "0";
                                }
                                else if (txturl.Text != "")
                                {
                                    strHLink = txturl.Text;
                                    strParentID = "0";
                                }
                                else
                                {
                                    strHLink = lnkMenuFile.Text;
                                    strParentID = "0";
                                }
                            }
                            else if (!string.IsNullOrEmpty(Path.GetFileName(FileMenuDoc.PostedFile.FileName)))
                            {
                                strHLink = txtTempFilenm.Text;
                                strParentID = "0";
                            }
                            else if (txturl.Text != "")
                            {
                                strHLink = txturl.Text;
                                strParentID = "0";
                            }
                            else
                            {
                                strHLink = lnkMenuFile.Text;
                                strParentID = "0";
                            }

                            string test = Session["PgId1"].ToString();
                            string test1 = lblparentid.Text;
                            string test2 = lbllnkid.Text;
                            string test3 = Label1.Text;

                            string GetPgID = Session["PgId1"].ToString();
                            LnkParid = Label1.Text;

                            con.Open();
                            cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                            cmd.Parameters.AddWithValue("@strPageId", GetPgID);
                            cmd.Parameters.AddWithValue("@strParentLnkId", LnkParid);
                            //if (rbtmenulocation.SelectedValue == "Left")
                            //{
                            //    cmd.Parameters["@Mode"].Value = "GetMaxIndHnd1L";
                            //}
                            //else
                            //{
                            //    cmd.Parameters["@Mode"].Value = "GetMaxIndHnd1";
                            //}
                            cmd.Parameters["@Mode"].Value = "GetMaxIndHnd1";
                            if (Convert.IsDBNull(cmd.ExecuteScalar()) == false)
                            {
                                strLinkIndex = (Convert.ToInt32(cmd.ExecuteScalar()) + 1).ToString();
                            }
                            else
                            {
                                strLinkIndex = "1";
                            }
                            con.Close();

                            LnkName = txtManuName.Text;
                            string LnkActHin = strHLink;

                            string GetPrntID = strParentID;
                            string LnkIndex = strLinkIndex;
                            string LnkAct = rdbAct.SelectedValue;
                            string PgnmGuj = Label1.Text;
                            string menulocation = RadioButtonList1.SelectedValue;

                            con.Open();
                            cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                            cmd.Parameters.AddWithValue("@strLnkNm", LnkName);
                            cmd.Parameters.AddWithValue("@strLnkHLink", LnkActHin);
                            cmd.Parameters.AddWithValue("@strPageId", GetPgID);
                            cmd.Parameters.AddWithValue("@strParentId1", GetPrntID);
                            cmd.Parameters.AddWithValue("@strLnkIndex", LnkIndex);
                            cmd.Parameters.AddWithValue("@strParentLnkId", LnkParid);
                            cmd.Parameters.AddWithValue("@strLnkAct", LnkAct);
                            cmd.Parameters.AddWithValue("@strmenulocation", menulocation);
                            cmd.Parameters.AddWithValue("@checked", "N");
                            //if (PgLang == "Hindi")
                            //{
                                cmd.Parameters["@Mode"].Value = "AddHLnkMkr1";
                            //}
                            //else if (PgLang == "Marathi")
                            //{
                            //    cmd.Parameters["@Mode"].Value = "AddMarLnkMkr1";
                            //}
                            //else
                            //{
                            //    cmd.Parameters["@Mode"].Value = "AddLnkMkr1";
                            //}
                            cmd.ExecuteNonQuery();
                            con.Close();

                            if (cmbWebPage.SelectedIndex == 0 & !string.IsNullOrEmpty(Path.GetFileName(FileMenuDoc.PostedFile.FileName)))
                            {
                                string strFileName = "";
                                strFileName = Path.GetFileName(FileMenuDoc.PostedFile.FileName);
                                FileMenuDoc.PostedFile.SaveAs(Server.MapPath("..\\PageMenuDocs") + "\\" + strFileName);
                            }
                            lblmsg.Text = "New menu added successfully !!";
                            mail_appl(lblmsg.Text);
                            Audit_Trail();
                            clear_AddData();
                            tr_menu.Visible = false;
                            lblmsg.Text = "New menu added successfully !!";
                            if (lbllnkid.Text == "0")
                            {
                                if (RadioButtonList1.SelectedValue == "Left")
                                {
                                    bind_gridleftmenu();
                                }
                                else if (RadioButtonList1.SelectedValue == "Right")
                                {
                                    bind_grid();
                                }
                               // bind_grid();
                            }
                            else
                            {
                                int i = int.Parse(Label1.Text);
                                bindchild(i);
                            }
                        }
                        else
                        {
                            lblmsg.Text = "This menu text already exists !!";
                        }
                    }
                    else if (btnAdd.Text == "Update")
                    {
                        string LnkID = Session["LnkId"].ToString();
                        string LnkName = Strings.Trim(txtManuName.Text);
                        string LnkParid = Label1.Text;
                        string GetPgID = Session["PgId1"].ToString();
                        int cnt2 = 0;
                        con.Open();

                        cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                        cmd.Parameters.AddWithValue("@strLnkId", LnkID);
                        cmd.Parameters.AddWithValue("@strPageId", GetPgID);
                        cmd.Parameters.AddWithValue("@strLnkNm", LnkName);
                        cmd.Parameters.AddWithValue("@strParentLnkId", LnkParid);
                        //if (PgLang == "Hindi")
                        //{
                            cmd.Parameters["@Mode"].Value = "ChkHDupLnkM3";
                        //}
                        //else if (PgLang == "Marathi")
                        //{
                        //    cmd.Parameters["@Mode"].Value = "ChkMarDupLnkM3";
                        //}
                        //else
                        //{
                        //    cmd.Parameters["@Mode"].Value = "ChkDupLnkM2";
                        //}

                        cnt2 = (int)cmd.ExecuteScalar();
                        con.Close();
                        if (cnt2 == 0)
                        {
                            lblmsg.Text = "";

                            string strHLink1 = "";
                            string strParentID1 = "";

                            if (!(cmbWebPage.SelectedIndex == 0))
                            {
                                string Pagename = cmbWebPage.SelectedValue;

                                DataSet ds1 = new DataSet();
                                int cntPg1 = 0;
                                con.Open();
                                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                                cmd.Parameters.AddWithValue("@strPageId", Pagename);
                                //if (PgLang == "Hindi")
                                //{
                                    cmd.Parameters["@Mode"].Value = "CntHndPgMkrById";
                                //}
                                //else if (PgLang == "Marathi")
                                //{
                                //    cmd.Parameters["@Mode"].Value = "CntHndPgMkrByIdMar";
                                //}
                                //else
                                //{
                                //    cmd.Parameters["@Mode"].Value = "CntPgMkrById";
                                //}

                                cntPg1 = (int)cmd.ExecuteScalar();
                                con.Close();

                                if (cntPg1 > 0)
                                {
                                    con.Open();
                                    cmd = new SqlCommand("Proc_ManageCmsPages", con);
                                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                                    cmd.Parameters.AddWithValue("@strPageId", Pagename);
                                    //if (PgLang == "Hindi")
                                    //{
                                        cmd.Parameters["@Mode"].Value = "GetHndPgMkrById";
                                    //}
                                    //else if (PgLang == "Marathi")
                                    //{
                                    //    cmd.Parameters["@Mode"].Value = "GetMarPgMkrById";
                                    //}
                                    //else
                                    //{
                                    //    cmd.Parameters["@Mode"].Value = "GetPgMkrById";
                                    //}
                                    da = new SqlDataAdapter();
                                    da.SelectCommand = cmd;

                                }
                                da.Fill(ds1, "tbl_PgDtls");
                                con.Close();
                                if ((ds1 != null))
                                {

                                    if (!(ds1.Tables["tbl_PgDtls"].Rows.Count == 0))
                                    {
                                        if (Information.IsDBNull(ds1.Tables["tbl_PgDtls"].Rows[0]["PageFileName"]) == false)
                                        {
                                            strHLink1 = ds1.Tables["tbl_PgDtls"].Rows[0]["PageFileName"].ToString();
                                        }
                                        else
                                        {
                                            strHLink1 = "";
                                        }

                                        if (Information.IsDBNull(ds1.Tables["tbl_PgDtls"].Rows[0]["ParentID"]) == false)
                                        {
                                            strParentID1 = ds1.Tables["tbl_PgDtls"].Rows[0]["ParentID"].ToString();
                                        }
                                        else
                                        {
                                            strParentID1 = "";
                                        }
                                    }
                                }
                                else if (!string.IsNullOrEmpty(Path.GetFileName(FileMenuDoc.PostedFile.FileName)))
                                {
                                    strHLink1 = txtTempFilenm.Text;
                                    strParentID1 = "0";
                                }

                                else if (txturl.Text != "")
                                {
                                    strHLink1 = txturl.Text;
                                    strParentID1 = "0";
                                }
                                else
                                {
                                    strHLink1 = "";
                                    strParentID1 = "0";
                                }
                            }
                            else if (!string.IsNullOrEmpty(Path.GetFileName(FileMenuDoc.PostedFile.FileName)))
                            {
                                strHLink1 = txtTempFilenm.Text;
                                strParentID1 = "0";
                            }
                            else if (txturl.Text != "")
                            {
                                strHLink1 = txturl.Text;
                                strParentID1 = "0";
                            }
                            else
                            {
                                strHLink1 = lnkMenuFile.Text;
                                strParentID1 = "0";
                            }
                            string n1 = lbllnkid.Text;
                            string n2 = Label1.Text;

                            LnkID = Session["PgId1"].ToString();
                            LnkParid = Label1.Text;

                            string strLinkIndex;
                            //strLinkIndex =ui.GetMaxIndex1(cms);

                            con.Open();
                            cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                            cmd.Parameters.AddWithValue("@strPageId", GetPgID);
                            cmd.Parameters.AddWithValue("@strParentLnkId", LnkParid);
                            //if (PgLang == "Hindi")
                            //{
                            if (rbtmenulocation.SelectedValue == "Left")
                            {
                                cmd.Parameters["@Mode"].Value = "GetMaxIndHnd1L";
                            }
                            else
                            {
                                cmd.Parameters["@Mode"].Value = "GetMaxIndHnd1";
                            }

                               // cmd.Parameters["@Mode"].Value = "GetMaxIndHnd1";

                            //}
                            //else if (PgLang == "Marathi")
                            //{
                            //    cmd.Parameters["@Mode"].Value = "GetMaxIndMar";
                            //}
                            //else
                            //{
                            //    cmd.Parameters["@Mode"].Value = "GetMaxIndex1";
                            //}
                            if (Convert.IsDBNull(cmd.ExecuteScalar()) == false)
                            {
                                strLinkIndex = (Convert.ToInt32(cmd.ExecuteScalar()) + 1).ToString();
                            }
                            else
                            {
                                strLinkIndex = "1";
                            }
                            con.Close();

                            LnkName = txtManuName.Text;
                            string LnkActHin = strHLink1;
                            GetPgID = Session["PgId1"].ToString();
                            LnkID = tval.Text;
                            string LnkAct = rdbAct.SelectedValue;
                            string PgnmGuj = Label1.Text;
                            string menulocation = rbtmenulocation.SelectedValue;
                            con.Open();
                            cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                            cmd.Parameters.AddWithValue("@strLnkNm", LnkName);
                            cmd.Parameters.AddWithValue("@strLnkHLink", LnkActHin);
                            cmd.Parameters.AddWithValue("@strPageId", GetPgID);
                            cmd.Parameters.AddWithValue("@strParentLnkId", LnkParid);
                            cmd.Parameters.AddWithValue("@strLnkId", LnkID);
                            cmd.Parameters.AddWithValue("@strLnkAct", LnkAct);
                            cmd.Parameters.AddWithValue("@strmenulocation", menulocation);
                            //if (PgLang == "Hindi")
                            //{
                                cmd.Parameters["@Mode"].Value = "EditHLnkM1";
                            //}
                            //else if (PgLang == "Marathi")
                            //{
                            //    cmd.Parameters["@Mode"].Value = "EditMLnkM1";
                            //}
                            //else
                            //{
                            //    cmd.Parameters["@Mode"].Value = "EditLnkM1";
                            //}
                            cmd.ExecuteNonQuery();
                            con.Close();

                            if (cmbWebPage.SelectedIndex == 0 & !string.IsNullOrEmpty(Path.GetFileName(FileMenuDoc.PostedFile.FileName)))
                            {
                                string strFileName = "";
                                strFileName = Path.GetFileName(FileMenuDoc.PostedFile.FileName);
                                FileMenuDoc.PostedFile.SaveAs(Server.MapPath("..\\PageMenuDocs") + "\\" + strFileName);
                            }
                            con.Open();
                            cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                            cmd.Parameters.AddWithValue("@strLnkId", LnkID);
                            cmd.Parameters["@Mode"].Value = "deletemenuHndchk";
                            cmd.ExecuteNonQuery();
                            con.Close();

                            lblmsg.Text = "Menu updated successfully !!";
                            mail_appl(lblmsg.Text);
                            Audit_Trail();
                            clear_AddData();
                            tr_menu.Visible = false;
                            lblmsg.Text = "Menu updated successfully !!";

                            if (lbllnkid.Text == "0")
                            {
                               // bind_grid();
                                if (RadioButtonList1.SelectedValue == "Left")
                                {
                                    bind_gridleftmenu();
                                }
                                else if (RadioButtonList1.SelectedValue == "Right")
                                {
                                    bind_grid();
                                }
                            }
                            else
                            {
                                int i = int.Parse(Label1.Text);
                                bindchild(i);
                            }
                        }
                        else
                        {
                            lblMainMsg.Text = "This menu text already exists !!";
                        }
                        //bind_gridleftmenu();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
      //  bind_grid();
    }

    public void mail_appl(string msg)
    {
        try
        {
            string mailid = null;
            string FROM = "";
            string HOST = "";
            string PORT = "";
            string USRNM = "";
            string pswd = "";
            string ImgUrl = ConfigurationManager.AppSettings.Get("imgurl");



            int x = 0;
            //bool(MR = False)
            string blank1 = "";
            string strbody1 = "";
            //string ImgUrl = "../Images/logo.PNG";

            string message = "";

            if (msg == "New menu added successfully !!")
            {
                message = "Menu has been Added in Page .Please check this Menus.";
            }
            else if (msg == "Menu updated successfully !!")
            {
                message = "Menu has been Updated in Page .Please check this Menus.";
            }

            string mail = "komalkosbatwar@gmail.com";

            if (!string.IsNullOrEmpty(mail))
            {


                //.................
                strbody1 = "<html><head></head><body> <table cellpadding='8' cellspacing='0' width='' border='0' >";

                strbody1 = strbody1 + "<tr><td><table cellpadding='8' cellspacing='0' width='' border='0' bgcolor='#fff'>";
                strbody1 = strbody1 + "<tr><td><table cellpadding='5' cellspacing='0' width='' border='0' bgcolor='#DA251C'>";
                strbody1 = strbody1 + "<tr><td align='left' class='GridHead'></td></tr>";


                strbody1 = strbody1 + " <tr><td><table cellpadding='5' cellspacing='0' border='0' width='100%' bgcolor='#DA251C'>";


                strbody1 = strbody1 + "<tr><td style='color: #DA251C;'><img src=" + ImgUrl + " ></td></tr>";

                strbody1 = strbody1 + "<tr><td align='center'  style='color:black;background-color:white;'>";

                strbody1 = strbody1 + "<strong>LV Bank : Content Management System Update</strong> </td>";

                strbody1 = strbody1 + "</tr><tr><td width='675px'>&nbsp;</td></tr>";

                strbody1 = strbody1 + "<tr><td class='style1' style='font-size: 14px; color:black; background-color:white;'>";


                strbody1 = strbody1 + "Dear <strong> Sir /Mam ,</strong><br />";


                strbody1 = strbody1 + "<br /> " + message + " </span> <br /><br/>";

                strbody1 = strbody1 + "Page Name :<strong> " + lblParentPage.Text + ".aspx </strong> <br /><br />";

                strbody1 = strbody1 + "Menu Added in Page By :<strong> " + Session["log_name"] + " </strong> <br /><br />";

                strbody1 = strbody1 + "<br /><br /><strong>Regards,</strong><br /><br />Webmaster <br /><br />LV Bank<br /><br /><br /></td>";

                strbody1 = strbody1 + "</tr></table></td>";

                strbody1 = strbody1 + " </tr></table></td></tr></table></td></tr></table></body></html>";

                //'''''''''''''''''


                MailAddress ma = new MailAddress("lvbank@donotreply.com");
                ///''''''''''''''''''''''' mail to user
                MailMessage Mail_br1 = new MailMessage();
                Mail_br1.From = ma;
                Mail_br1.CC.Add("ajitshinde133@gmail.com");
                Mail_br1.To.Add(mail);
                Mail_br1.Subject = "LV Bank : Menu Added in Page";
                Mail_br1.IsBodyHtml = true;
                Mail_br1.Body = strbody1;


                SmtpClient smtpMailObj1 = new SmtpClient();
                smtpMailObj1.Host = "127.0.0.1";
                smtpMailObj1.Port = 25;
                smtpMailObj1.Send(Mail_br1);



            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }

    }


    protected void dg_Menu_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.SelectedItem | e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.EditItem)
        {
            string LnkIndex = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "LnkIndex")) == false)
            {
                LnkIndex = DataBinder.Eval(e.Item.DataItem, "LnkIndex").ToString();
                ((TextBox)e.Item.Cells[5].FindControl("txtMenuIndex")).Text = LnkIndex;
            }
            else
            {
                LnkIndex = "";
                ((TextBox)e.Item.Cells[5].FindControl("txtMenuIndex")).Text = LnkIndex;
            }

            string lnkAct = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "lnkAct")) == false)
            {
                lnkAct = DataBinder.Eval(e.Item.DataItem, "lnkAct").ToString();
            }
            else
            {
                lnkAct = "";
            }

            string chek = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Checked")) == false)
            {
                chek = DataBinder.Eval(e.Item.DataItem, "Checked").ToString();
            }
            else
            {
                chek = "";
            }



            if (lnkAct == "Y")
            {
                e.Item.ForeColor = System.Drawing.Color.Black;
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuDelete")).Attributes.Add("onclick", "javascript: return confirm('Are you sure you want to delete this link?')");
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuDelete")).Enabled = true;
            }
            else if (lnkAct == "N")
            {
                e.Item.ForeColor = System.Drawing.Color.Gray;
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuDelete")).ForeColor = System.Drawing.Color.Gray;
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuDelete")).Enabled = false;
                ((LinkButton)e.Item.Cells[7].FindControl("lnkAddChild")).ForeColor = System.Drawing.Color.Gray;
                ((LinkButton)e.Item.Cells[7].FindControl("lnkAddChild")).Enabled = false;
            }
            if (Session["usr_privilege"].ToString() == "Checker")
            {
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuCheck")).Enabled = true;
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuDelete")).Enabled = false;
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuEdit")).Enabled = false;
                ((LinkButton)e.Item.Cells[6].FindControl("lnkAddChild")).Enabled = false;
                lnkAddNew.Enabled = false;
            }
            else if (Session["usr_privilege"].ToString() == "admin" || Session["usr_privilege"].ToString() == "Both")
            {
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuCheck")).Enabled = true;
            }
            else
            {
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuCheck")).Enabled = false;
            }

            if (chek == "y" || chek == "Y")
            {
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuCheck")).Enabled = false;
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuCheck")).ForeColor = System.Drawing.Color.Black;
            }

           
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
       // clear_AddData();
        Table1.Visible = false;
    }
    protected void btneditleft_Click(object sender, EventArgs e)
    {
        try
        {
            int i = 0;
            int j = 0;
            if (!(dgleft_menu.Items.Count == 0))
            {
                for (i = 0; i <= dgleft_menu.Items.Count - 1; i++)
                {
                    if (j == i)
                    {
                        if (string.IsNullOrEmpty(((TextBox)dgleft_menu.Items[i].Cells[4].FindControl("txtMenuIndexleft")).Text))
                        {
                            lblmsg.Text = "Menu Index can not be blank !!";
                        }
                        else if (Information.IsNumeric(((TextBox)dgleft_menu.Items[i].Cells[4].FindControl("txtMenuIndexleft")).Text) == false)
                        {
                            lblmsg.Text = "Menu Index no. can contain digits only !!";
                        }
                        else if (((TextBox)dgleft_menu.Items[i].Cells[4].FindControl("txtMenuIndexleft")).Text.Length > 2)
                        {
                            lblmsg.Text = "Enter valid Menu index !!";
                        }
                        else
                        {
                            lblmsg.Text = "";
                            j = j + 1;
                        }
                    }
                }
                if (j == dgleft_menu.Items.Count)
                {
                    lblmsg.Text = "";
                    int n = 0;
                    int flag2 = 0;
                    for (n = 0; n <= dgleft_menu.Items.Count - 1; n++)
                    {
                        if (flag2 == n)
                        {
                            //'**********************
                            string text1 = ((TextBox)dgleft_menu.Items[n].Cells[4].FindControl("txtMenuIndexleft")).Text;
                            int x1 = 0;

                            int y = 0;
                            for (y = 0; y <= dgleft_menu.Items.Count - 1; y++)
                            {
                                if (x1 < 2)
                                {
                                    //x1 = 0
                                    if (((TextBox)dgleft_menu.Items[y].Cells[4].FindControl("txtMenuIndexleft")).Text == text1)
                                    {
                                        x1 = x1 + 1;
                                    }
                                }
                                else
                                {
                                    lblmsg.Text = "Menu Index sequence must be unique !!";
                                }
                            }
                            if (x1 < 2)
                            {
                                lblmsg.Text = "";
                                flag2 = flag2 + 1;
                            }
                            else if (x1 > 1)
                            {
                                lblmsg.Text = "Menu Index sequence must be unique !!";
                            }
                            //'************************
                        }
                    }
                    if (flag2 == dgleft_menu.Items.Count)
                    {
                        int p = 0;

                        for (p = 0; p <= dgleft_menu.Items.Count - 1; p++)
                        {
                            int MenuId = int.Parse(dgleft_menu.Items[p].Cells[0].Text);
                            string MenuIndex = ((TextBox)dgleft_menu.Items[p].Cells[4].FindControl("txtMenuIndexleft")).Text;
                            string LnkID = MenuId.ToString();
                            string LnkIndex = MenuIndex;
                            con.Open();
                            cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                            cmd.Parameters.AddWithValue("@strLnkId", LnkID);
                            cmd.Parameters.AddWithValue("@strLnkIndex", LnkIndex);
                          
                                cmd.Parameters["@Mode"].Value = "EditIndexHnd1";
                           
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        lblmsg.Text = "Menu index updated successfully !!";

                        bind_gridleftmenu();
                        btnEditIndex.Visible = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
    protected void dgleft_menu_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        string linkid1 = e.Item.Cells[0].Text;
        string linknm1 = e.Item.Cells[2].Text;
        string linkdoc1 = e.Item.Cells[4].Text;
        string lnkindex1 = ((TextBox)e.Item.Cells[5].FindControl("txtMenuIndexleft")).Text;
        string linkPgId1 = e.Item.Cells[8].Text;
        string linkParId1 = e.Item.Cells[9].Text;
        string linkParLnkId1 = e.Item.Cells[10].Text;
        string linkact1 = e.Item.Cells[11].Text;
        string LnkID = linkid1;
        string LnkName = linknm1;
        string LnkDoc = linkdoc1;
        string LnkIndex = lnkindex1;
        string LnkAct = linkact1;
        string LnkParid = linkParLnkId1;
        string GetPrntID = linkParId1;
        string GetPgID = linkPgId1;

        if (e.CommandName == "AddChildleft")
        {
            lnkHome.Visible = true;
            lnkBack.Visible = true;

            Label5.Visible = false;
            rbtmenulocation.Visible = false;

            dgleft_menu.Visible = false;
            btneditleft.Visible = false;
          //  RadioButtonList1.Visible = false;

            lblparentid.Text = Label1.Text;
            int a = int.Parse(lbllnkid.Text);
            lbllnkid.Text = (a + 1).ToString();
            Label1.Text = linkid1;
            int linkid2 = int.Parse(linkid1);
            bindchild(linkid2);
            clear_AddData();
            tr_menu.Visible = true;
            lblAddMainHead.Text = "Add New Menu";
            btnAdd.Text = "Add";

            lblParentPage.Text = lblParentPage.Text + ">>" + e.Item.Cells[2].Text;
        }
        else if (e.CommandName == "MenuEditleft")
        {
            Session["LnkId"] = linkid1;
            clear_AddData();
            tr_menu.Visible = true;
            Table1.Visible = true;
            lblAddMainHead.Text = "Update Menu";
            btnAdd.Text = "Update";
            tval.Text = linkid1;
            fill_MenuDtls(linkdoc1, Session["LnkId"].ToString());
        }
        else if (e.CommandName == "MenuCheckleft")
        {
            try
            {
                // string LnkID = "";
                // string LnkName = "";
                string LnkHLink = "";
                string PageID = "";
                string Parentid = "";
                // string LnkIndex = "";
                string menulocation = "";
                string parentlinkid = "";
                string lnkAct = "";
                con.Open();
                cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 50));
                cmd.Parameters.AddWithValue("@strLnkId", linkid1);
                cmd.Parameters["@Mode"].Value = "updatemenustatusHnd";
                cmd.ExecuteScalar();

                cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 50));
                cmd.Parameters.AddWithValue("@strLnkId", linkid1);
                cmd.Parameters["@Mode"].Value = "getmenuHnd";
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                ds = new DataSet();
                adp.Fill(ds, "tbl_cont");
                if (ds.Tables["tbl_cont"].Rows.Count > 0)
                {
                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["LnkID"]) == false)
                    {
                        LnkID = ds.Tables["tbl_cont"].Rows[0]["LnkID"].ToString();

                    }
                    else
                    {
                        LnkID = "";
                    }
                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["LnkName"]) == false)
                    {
                        LnkName = ds.Tables["tbl_cont"].Rows[0]["LnkName"].ToString();

                    }
                    else
                    {
                        LnkName = "";
                    }
                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["LnkHLink"]) == false)
                    {
                        LnkHLink = ds.Tables["tbl_cont"].Rows[0]["LnkHLink"].ToString();

                    }
                    else
                    {
                        LnkHLink = "";
                    }
                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["PageID"]) == false)
                    {
                        PageID = ds.Tables["tbl_cont"].Rows[0]["PageID"].ToString();

                    }
                    else
                    {
                        PageID = "";
                    }
                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["Parentid"]) == false)
                    {
                        Parentid = ds.Tables["tbl_cont"].Rows[0]["Parentid"].ToString();

                    }
                    else
                    {
                        Parentid = "";
                    }
                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["LnkIndex"]) == false)
                    {
                        LnkIndex = ds.Tables["tbl_cont"].Rows[0]["LnkIndex"].ToString();

                    }
                    else
                    {
                        LnkIndex = "";
                    }
                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["parentlinkid"]) == false)
                    {
                        parentlinkid = ds.Tables["tbl_cont"].Rows[0]["parentlinkid"].ToString();

                    }
                    else
                    {
                        parentlinkid = "";
                    }

                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["lnkAct"]) == false)
                    {
                        lnkAct = ds.Tables["tbl_cont"].Rows[0]["lnkAct"].ToString();

                    }
                    else
                    {
                        lnkAct = "";
                    }
                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["menulocation"]) == false)
                    {
                        menulocation = ds.Tables["tbl_cont"].Rows[0]["menulocation"].ToString();

                    }
                    else
                    {
                        menulocation = "";
                    }

                    cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                    cmd.Parameters.AddWithValue("@strLnkId", linkid1);
                    cmd.Parameters["@Mode"].Value = "deletemenuHnd";
                    cmd.ExecuteNonQuery();


                    cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd.Parameters.AddWithValue("@strLnkId", LnkID);
                    cmd.Parameters.AddWithValue("@strLnkNm", LnkName);
                    cmd.Parameters.AddWithValue("@strLnkHLink", LnkHLink);
                    cmd.Parameters.AddWithValue("@strPageId", PageID);
                    cmd.Parameters.AddWithValue("@strParentId1", Parentid);
                    cmd.Parameters.AddWithValue("@strLnkIndex", LnkIndex);
                    cmd.Parameters.AddWithValue("@strParentLnkId", parentlinkid);
                    cmd.Parameters.AddWithValue("@strlnkact", lnkAct);
                    cmd.Parameters.AddWithValue("@strmenulocation", menulocation);
                    cmd.Parameters["@Mode"].Value = "AddLnkHindi";
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                    cmd.Parameters.AddWithValue("@strLnkId", linkid1);
                    cmd.Parameters["@Mode"].Value = "updatemenuchkHnd";
                    cmd.ExecuteNonQuery();

                }


            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
            bind_gridleftmenu();
        }

        else if (e.CommandName == "MenuDeleteleft")
        {
            Session["LnkId"] = linkid1;
            con.Open();
            cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strLnkId", linkid1);
           
                cmd.Parameters["@Mode"].Value = "GetHndLnkMkrDel";
            
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            da.Fill(ds, "tbl_LnkDtls1");
            con.Close();

            if (!(ds.Tables["tbl_LnkDtls1"].Rows.Count == 0))
            {
                int pgcnt = 0;
                int parentLnkid = 0;
                int ID1 = 0;

                pgcnt = (int)ds.Tables["tbl_LnkDtls1"].Rows[0]["countpage"];

                parentLnkid = (int)ds.Tables["tbl_LnkDtls1"].Rows[0]["parentlinkid"];

                ID1 = (int)ds.Tables["tbl_LnkDtls1"].Rows[0]["lnkid"];

                //if (pgcnt != 0)
                //{
                //    recurchild(ID1);
                //}
                con.Open();
                cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strLnkId", Convert.ToString(Session["LnkId"]));
              
                    cmd.Parameters["@Mode"].Value = "DelHndLnMkr1";
                
                cmd.ExecuteNonQuery();
                con.Close();


                if (lbllnkid.Text == "0")
                {
                   // bind_gridleftmenu();
                }
                else
                {
                    int i = parentLnkid;
                    bindchild(parentLnkid);
                }
            }
            string mnm1 = linknm1;

            string fields1 = "";
            if (!string.IsNullOrEmpty(mnm1))
            {
                if (string.IsNullOrEmpty(fields1))
                {
                    fields1 = "Menu : " + mnm1 + " is deleted";
                }
                else
                {
                    fields1 = fields1 + ", Menu : " + mnm1 + " is deleted";
                }
            }
            ///''''''''''''''''''''''''''''''''''''''''''''''''''''''''call Audit Trail Function
            ///
            con.Open();
            cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strLnkId", linkid1);
            cmd.Parameters["@Mode"].Value = "deletemenuHndchk";
            cmd.ExecuteNonQuery();
            con.Close();
            bind_gridleftmenu();
          //  bind_gridleftmenu();
        }
     //   btnEditIndex.Visible = false;
       // btneditleft.Visible = true;
    }
    protected void dgleft_menu_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.SelectedItem | e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.EditItem)
        {
            string LnkIndex = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "LnkIndex")) == false)
            {
                LnkIndex = DataBinder.Eval(e.Item.DataItem, "LnkIndex").ToString();
                ((TextBox)e.Item.Cells[5].FindControl("txtMenuIndexleft")).Text = LnkIndex;
            }
            else
            {
                LnkIndex = "";
                ((TextBox)e.Item.Cells[5].FindControl("txtMenuIndexleft")).Text = LnkIndex;
            }

            string lnkAct = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "lnkAct")) == false)
            {
                lnkAct = DataBinder.Eval(e.Item.DataItem, "lnkAct").ToString();
            }
            else
            {
                lnkAct = "";
            }

            string chek = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Checked")) == false)
            {
                chek = DataBinder.Eval(e.Item.DataItem, "Checked").ToString();
            }
            else
            {
                chek = "";
            }



            if (lnkAct == "Y")
            {
                e.Item.ForeColor = System.Drawing.Color.Black;
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuDeleteleft")).Attributes.Add("onclick", "javascript: return confirm('Are you sure you want to delete this link?')");
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuDeleteleft")).Enabled = true;
            }
            else if (lnkAct == "N")
            {
                e.Item.ForeColor = System.Drawing.Color.Gray;
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuDeleteleft")).ForeColor = System.Drawing.Color.Gray;
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuDeleteleft")).Enabled = false;
                ((LinkButton)e.Item.Cells[7].FindControl("lnkAddChildleft")).ForeColor = System.Drawing.Color.Gray;
                ((LinkButton)e.Item.Cells[7].FindControl("lnkAddChildleft")).Enabled = false;
            }
            if (Session["usr_privilege"].ToString() == "Checker")
            {
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuCheckleft")).Enabled = true;
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuDeleteleft")).Enabled = false;
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuEditleft")).Enabled = false;
                ((LinkButton)e.Item.Cells[6].FindControl("lnkAddChildleft")).Enabled = false;
                lnkAddNew.Enabled = false;
            }
            else if (Session["usr_privilege"].ToString() == "admin" || Session["usr_privilege"].ToString() == "Both")
            {
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuCheckleft")).Enabled = true;
            }
            else
            {
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuCheckleft")).Enabled = false;
            }

            if (chek == "y" || chek == "Y")
            {
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuCheckleft")).Enabled = false;
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuCheckleft")).ForeColor = System.Drawing.Color.Black;
            }


        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "Left")
        {
            bind_gridleftmenu();
           // btneditleft.Visible = true;
            btnEditIndex.Visible = false;
            dg_Menu.Visible = false;
            rbtmenulocation.SelectedValue = "Left";
            dgchild.Visible = false;
            btnchildIndex.Visible = false;
            Table1.Visible = false;
            clear_AddData();
        }
        else
        {
            dgleft_menu.Visible = false;
            bind_grid();
            btneditleft.Visible = false;
          //  btnEditIndex.Visible = true;
            rbtmenulocation.SelectedValue = "Right";
            dgchild.Visible = false;
            btnchildIndex.Visible = false;
            Table1.Visible = false;
            clear_AddData();
        }
    }
    protected void rbtmenulocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtmenulocation.SelectedValue == "Left")
        {
            RadioButtonList1.SelectedValue = "Left";
            bind_gridleftmenu();
            dg_Menu.Visible = false;
            btnEditIndex.Visible = false;
        }
        else
        {
            RadioButtonList1.SelectedValue = "Right";
            bind_grid();
            dgleft_menu.Visible = false;
            btneditleft.Visible = false;
        }
    }
    protected void btnchildIndex_Click(object sender, EventArgs e)
    {
        try
        {
            int i = 0;
            int j = 0;
            if (!(dgchild.Items.Count == 0))
            {
                for (i = 0; i <= dgchild.Items.Count - 1; i++)
                {
                    if (j == i)
                    {
                        if (string.IsNullOrEmpty(((TextBox)dgchild.Items[i].Cells[4].FindControl("txtMenuIndex1")).Text))
                        {
                            lblmsg.Text = "Menu Index can not be blank !!";
                        }
                        else if (Information.IsNumeric(((TextBox)dgchild.Items[i].Cells[4].FindControl("txtMenuIndex1")).Text) == false)
                        {
                            lblmsg.Text = "Menu Index no. can contain digits only !!";
                        }
                        else if (((TextBox)dgchild.Items[i].Cells[4].FindControl("txtMenuIndex1")).Text.Length > 2)
                        {
                            lblmsg.Text = "Enter valid Menu index !!";
                        }
                        else
                        {
                            lblmsg.Text = "";
                            j = j + 1;
                        }
                    }
                }
                if (j == dgchild.Items.Count)
                {
                    lblmsg.Text = "";
                    int n = 0;
                    int flag2 = 0;
                    for (n = 0; n <= dgchild.Items.Count - 1; n++)
                    {
                        if (flag2 == n)
                        {
                            //'**********************
                            string text1 = ((TextBox)dgchild.Items[n].Cells[4].FindControl("txtMenuIndex1")).Text;
                            int x1 = 0;

                            int y = 0;
                            for (y = 0; y <= dgchild.Items.Count - 1; y++)
                            {
                                if (x1 < 2)
                                {
                                    //x1 = 0
                                    if (((TextBox)dgchild.Items[y].Cells[4].FindControl("txtMenuIndex1")).Text == text1)
                                    {
                                        x1 = x1 + 1;
                                    }
                                }
                                else
                                {
                                    lblmsg.Text = "Menu Index sequence must be unique !!";
                                }
                            }
                            if (x1 < 2)
                            {
                                lblmsg.Text = "";
                                flag2 = flag2 + 1;
                            }
                            else if (x1 > 1)
                            {
                                lblmsg.Text = "Menu Index sequence must be unique !!";
                            }
                            //'************************
                        }
                    }
                    if (flag2 == dgchild.Items.Count)
                    {
                        int p = 0;
                        string lnk = "";
                        for (p = 0; p <= dgchild.Items.Count - 1; p++)
                        {
                            int MenuId = int.Parse(dgchild.Items[p].Cells[0].Text);
                            string MenuIndex = ((TextBox)dgchild.Items[p].Cells[4].FindControl("txtMenuIndex1")).Text;
                            string LnkID = MenuId.ToString();
                            lnk = LnkID;
                            string LnkIndex = MenuIndex;
                            con.Open();
                            cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                            cmd.Parameters.AddWithValue("@strLnkId", LnkID);
                            cmd.Parameters.AddWithValue("@strLnkIndex", LnkIndex);

                            cmd.Parameters["@Mode"].Value = "EditIndexHnd1";

                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        lblmsg.Text = "Menu index updated successfully !!";
                        con.Open();
                        cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                        cmd.Parameters.AddWithValue("@strLnkId", lnk);
                        cmd.Parameters["@Mode"].Value = "getparentidHnd";
                        int linkid2 = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                        bindchild(linkid2);
                       
                        btneditleft.Visible = false;
                        btnEditIndex.Visible = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
    protected void dgchild_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        string linkid1 = e.Item.Cells[0].Text;
        string linknm1 = e.Item.Cells[2].Text;
        string linkdoc1 = e.Item.Cells[4].Text;
        string lnkindex1 = ((TextBox)e.Item.Cells[5].FindControl("txtMenuIndex1")).Text;
        string linkPgId1 = e.Item.Cells[8].Text;
        string linkParId1 = e.Item.Cells[9].Text;
        string linkParLnkId1 = e.Item.Cells[10].Text;
        string linkact1 = e.Item.Cells[11].Text;
        string LnkID = linkid1;
        string LnkName = linknm1;
        string LnkDoc = linkdoc1;
        string LnkIndex = lnkindex1;
        string LnkAct = linkact1;
        string LnkParid = linkParLnkId1;
        Session["parentid"] = LnkParid;
        string GetPrntID = linkParId1;
        string GetPgID = linkPgId1;

        if (e.CommandName == "AddChild1")
        {
            lnkHome.Visible = true;
            lnkBack.Visible = true;

            Label5.Visible = false;
            rbtmenulocation.Visible = false;

            dgleft_menu.Visible = false;
            btneditleft.Visible = false;
            dg_Menu.Visible = false;
            btnEditIndex.Visible = false;
            lblparentid.Text = Label1.Text;
            int a = int.Parse(lbllnkid.Text);
            lbllnkid.Text = (a + 1).ToString();
            Label1.Text = linkid1;
            int linkid2 = int.Parse(linkid1);
            bindchild(linkid2);
            clear_AddData();
            tr_menu.Visible = true;
            lblAddMainHead.Text = "Add New Menu";
            btnAdd.Text = "Add";

            lblParentPage.Text = lblParentPage.Text + ">>" + e.Item.Cells[2].Text;
        }
        else if (e.CommandName == "MenuEdit1")
        {
            Session["LnkId"] = linkid1;
            clear_AddData();
            tr_menu.Visible = true;
            Table1.Visible = true;
            lblAddMainHead.Text = "Update Menu";
            btnAdd.Text = "Update";
            tval.Text = linkid1;
            fill_MenuDtls(linkdoc1, Session["LnkId"].ToString());
        }
        else if (e.CommandName == "MenuCheck1")
        {
            try
            {
                // string LnkID = "";
                // string LnkName = "";
                string LnkHLink = "";
                string PageID = "";
                string Parentid = "";
                // string LnkIndex = "";
                string menulocation = "";
                string parentlinkid = "";
                string lnkAct = "";
                con.Open();
                cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 50));
                cmd.Parameters.AddWithValue("@strLnkId", linkid1);
                cmd.Parameters["@Mode"].Value = "updatemenustatusHnd";
                cmd.ExecuteScalar();

                cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 50));
                cmd.Parameters.AddWithValue("@strLnkId", linkid1);
                cmd.Parameters["@Mode"].Value = "getmenuHnd";
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                ds = new DataSet();
                adp.Fill(ds, "tbl_cont");
                if (ds.Tables["tbl_cont"].Rows.Count > 0)
                {
                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["LnkID"]) == false)
                    {
                        LnkID = ds.Tables["tbl_cont"].Rows[0]["LnkID"].ToString();

                    }
                    else
                    {
                        LnkID = "";
                    }
                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["LnkName"]) == false)
                    {
                        LnkName = ds.Tables["tbl_cont"].Rows[0]["LnkName"].ToString();

                    }
                    else
                    {
                        LnkName = "";
                    }
                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["LnkHLink"]) == false)
                    {
                        LnkHLink = ds.Tables["tbl_cont"].Rows[0]["LnkHLink"].ToString();

                    }
                    else
                    {
                        LnkHLink = "";
                    }
                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["PageID"]) == false)
                    {
                        PageID = ds.Tables["tbl_cont"].Rows[0]["PageID"].ToString();

                    }
                    else
                    {
                        PageID = "";
                    }
                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["Parentid"]) == false)
                    {
                        Parentid = ds.Tables["tbl_cont"].Rows[0]["Parentid"].ToString();

                    }
                    else
                    {
                        Parentid = "";
                    }
                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["LnkIndex"]) == false)
                    {
                        LnkIndex = ds.Tables["tbl_cont"].Rows[0]["LnkIndex"].ToString();

                    }
                    else
                    {
                        LnkIndex = "";
                    }
                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["parentlinkid"]) == false)
                    {
                        parentlinkid = ds.Tables["tbl_cont"].Rows[0]["parentlinkid"].ToString();

                    }
                    else
                    {
                        parentlinkid = "";
                    }

                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["lnkAct"]) == false)
                    {
                        lnkAct = ds.Tables["tbl_cont"].Rows[0]["lnkAct"].ToString();

                    }
                    else
                    {
                        lnkAct = "";
                    }
                    if (Convert.IsDBNull(ds.Tables["tbl_cont"].Rows[0]["menulocation"]) == false)
                    {
                        menulocation = ds.Tables["tbl_cont"].Rows[0]["menulocation"].ToString();

                    }
                    else
                    {
                        menulocation = "";
                    }

                    cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                    cmd.Parameters.AddWithValue("@strLnkId", linkid1);
                    cmd.Parameters["@Mode"].Value = "deletemenuHnd";
                    cmd.ExecuteNonQuery();


                    cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd.Parameters.AddWithValue("@strLnkId", LnkID);
                    cmd.Parameters.AddWithValue("@strLnkNm", LnkName);
                    cmd.Parameters.AddWithValue("@strLnkHLink", LnkHLink);
                    cmd.Parameters.AddWithValue("@strPageId", PageID);
                    cmd.Parameters.AddWithValue("@strParentId1", Parentid);
                    cmd.Parameters.AddWithValue("@strLnkIndex", LnkIndex);
                    cmd.Parameters.AddWithValue("@strParentLnkId", parentlinkid);
                    cmd.Parameters.AddWithValue("@strlnkact", lnkAct);
                    cmd.Parameters.AddWithValue("@strmenulocation", menulocation);
                    cmd.Parameters["@Mode"].Value = "AddLnkHindi";
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                    cmd.Parameters.AddWithValue("@strLnkId", linkid1);
                    cmd.Parameters["@Mode"].Value = "updatemenuchkHnd";
                    cmd.ExecuteNonQuery();

                }


            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
            int linkid2 = int.Parse(Session["parentid"].ToString());
            bindchild(linkid2);

        }

        else if (e.CommandName == "MenuDelete1")
        {
            Session["LnkId"] = linkid1;
            con.Open();
            cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strLnkId", linkid1);
           
            cmd.Parameters["@Mode"].Value = "GetHndLnkMkrDel";
           
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            da.Fill(ds, "tbl_LnkDtls1");
            con.Close();

            if (!(ds.Tables["tbl_LnkDtls1"].Rows.Count == 0))
            {
                int pgcnt = 0;
                int parentLnkid = 0;
                int ID1 = 0;

                pgcnt = (int)ds.Tables["tbl_LnkDtls1"].Rows[0]["countpage"];

                parentLnkid = (int)ds.Tables["tbl_LnkDtls1"].Rows[0]["parentlinkid"];

                ID1 = (int)ds.Tables["tbl_LnkDtls1"].Rows[0]["lnkid"];

                if (pgcnt != 0)
                {
                    recurchild(ID1);
                }
                con.Open();
                cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strLnkId", Convert.ToString(Session["LnkId"]));
               
                                    cmd.Parameters["@Mode"].Value = "DelHndLnMkr1";
               
                cmd.ExecuteNonQuery();
                con.Close();
                if (lbllnkid.Text == "0")
                {
                    bind_grid();
                }
                else
                {
                    int i = parentLnkid;
                    bindchild(parentLnkid);
                }
            }
            string mnm1 = linknm1;

            string fields1 = "";
            if (!string.IsNullOrEmpty(mnm1))
            {
                if (string.IsNullOrEmpty(fields1))
                {
                    fields1 = "Menu : " + mnm1 + " is deleted";
                }
                else
                {
                    fields1 = fields1 + ", Menu : " + mnm1 + " is deleted";
                }
            }
            ///''''''''''''''''''''''''''''''''''''''''''''''''''''''''call Audit Trail Function
            ///
            con.Open();
            cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strLnkId", linkid1);
            cmd.Parameters["@Mode"].Value = "deletemenuHndchk";
            cmd.ExecuteNonQuery();
            con.Close();
            // bind_grid();
            int linkid2 = int.Parse(Session["parentid"].ToString());
            bindchild(linkid2);
        }
    }
    protected void dgchild_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.SelectedItem | e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.EditItem)
        {
            string LnkIndex = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "LnkIndex")) == false)
            {
                LnkIndex = DataBinder.Eval(e.Item.DataItem, "LnkIndex").ToString();
                ((TextBox)e.Item.Cells[5].FindControl("txtMenuIndex1")).Text = LnkIndex;
            }
            else
            {
                LnkIndex = "";
                ((TextBox)e.Item.Cells[5].FindControl("txtMenuIndex1")).Text = LnkIndex;
            }

            string lnkAct = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "lnkAct")) == false)
            {
                lnkAct = DataBinder.Eval(e.Item.DataItem, "lnkAct").ToString();
            }
            else
            {
                lnkAct = "";
            }

            string chek = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Checked")) == false)
            {
                chek = DataBinder.Eval(e.Item.DataItem, "Checked").ToString();
            }
            else
            {
                chek = "";
            }



            if (lnkAct == "Y")
            {
                e.Item.ForeColor = System.Drawing.Color.Black;
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuDelete1")).Attributes.Add("onclick", "javascript: return confirm('Are you sure you want to delete this link?')");
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuDelete1")).Enabled = true;
            }
            else if (lnkAct == "N")
            {
                e.Item.ForeColor = System.Drawing.Color.Gray;
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuDelete1")).ForeColor = System.Drawing.Color.Gray;
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuDelete1")).Enabled = false;
                ((LinkButton)e.Item.Cells[7].FindControl("lnkAddChild1")).ForeColor = System.Drawing.Color.Gray;
                ((LinkButton)e.Item.Cells[7].FindControl("lnkAddChild1")).Enabled = false;
            }
            if (Session["usr_privilege"].ToString() == "Checker")
            {
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuCheck1")).Enabled = true;
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuDelete1")).Enabled = false;
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuEdit1")).Enabled = false;
                ((LinkButton)e.Item.Cells[6].FindControl("lnkAddChild1")).Enabled = false;
                lnkAddNew.Enabled = false;
            }
            else if (Session["usr_privilege"].ToString() == "admin" || Session["usr_privilege"].ToString() == "Both")
            {
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuCheck1")).Enabled = true;
            }
            else
            {
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuCheck1")).Enabled = false;
            }

            if (chek == "y" || chek == "Y")
            {
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuCheck1")).Enabled = false;
                ((LinkButton)e.Item.Cells[7].FindControl("lnkMenuCheck1")).ForeColor = System.Drawing.Color.Black;
            }
        }
    }
}