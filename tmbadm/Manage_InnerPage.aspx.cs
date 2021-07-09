using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.VisualBasic;
using System.Data;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

public partial class Admin_Manage_InnerPage : System.Web.UI.Page
{
    public Label lblpath1 = new Label();
    private AdmChkClass chkclass = new AdmChkClass();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    System.Data.DataSet ds = new System.Data.DataSet();
    System.Data.DataSet ds1 = new System.Data.DataSet();
    SqlDataReader dr;
     SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["TMBCON"].ToString());
    string strAlpha;
    string fields1 = "";
    string msg = "";

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
                    cmd.Parameters.AddWithValue("@strStaffNum", Session["usr_id"].ToString());
                    cmd.Parameters.AddWithValue("@strAuthName", "CMS");
                    cmd.Parameters["@Mode"].Value = "countmoduleusr";
                    cnt = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    if (cnt == 0)
                    {
                        Response.Redirect("TMBadmin.aspx");
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

        Session["SrchTxt"] = "";
        Session["MainType"] = "";
        Session["PgType"] = Session["PgType"];
        lblPage.Text = string.Empty;
        int x = 0;

        for (x = 65; x <= 65 + 25; x++)
        {
            lblPage.Text = lblPage.Text + "<a href=\"Manage_InnerPage.aspx?alpha=" + Chr(x) + Chr(34) + " class=\"LinkClass\">" + Chr(x) + "</a> | ";
        }

        lblpath1 = (Label)this.Form.Parent.FindControl("lblSmeModNm");

        if (!Page.IsPostBack)
        {
            if (chkclass.Chk_ModAuth(Convert.ToString(Session["log_name"]), "CMS", "Manage Inner Pages", Convert.ToString(Session["usr_privilege"])) == true)
            {

                txtPageIndex.Text = "1";
                txtPageSize.Text = "10";
                btn_go();
                fill_MainParentSrch();

                cmbPgTypeSrch.Items.Clear();
                cmbPgTypeSrch.Items.Insert(0, "Select Page Type");
                cmbPgTypeSrch.SelectedIndex = 0;

                tr_pg.Visible = false;
                clear_AddEditTbl();

                if (!string.IsNullOrEmpty(Session["SrchTxt"].ToString()))
                {
                    txtSrchPg.Text = Session["SrchTxt"].ToString();
                }
                else
                {
                    txtSrchPg.Text = "";
                }

                if (!string.IsNullOrEmpty(Session["MainType"].ToString()))
                {
                    cmbMainParentSrch.SelectedValue = Session["MainType"].ToString();
                    if (!string.IsNullOrEmpty(Session["PgType"].ToString()))
                    {
                        cmbPgTypeSrch.SelectedValue = Session["PgType"].ToString();
                    }
                    else
                    {
                        cmbPgTypeSrch.SelectedIndex = 0;
                    }
                }
                else
                {
                    cmbMainParentSrch.SelectedIndex = 0;
                }

                if (!string.IsNullOrEmpty(Request.QueryString["alpha"]))
                {
                    strAlpha = Request.QueryString["alpha"];
                }
                else
                {
                    strAlpha = "";
                }

                bind_grid();

            }
            else
            {
                Response.Redirect("AdmMainPage.aspx");
            }

        }
    }

    public void clear_AddEditTbl()
    {
        lblAddEditHead.Text = "Add New Page";
        cmbMainType.SelectedIndex = 0;

        cmbPgType.Items.Clear();
        cmbPgType.Items.Insert(0, "Select Page Type");
        cmbPgType.SelectedIndex = 0;
        PgSubType.Visible = false;
        cmbPgSubType.Items.Clear();
        cmbPgSubType.Items.Insert(0, "Select Sub Page Type");
        cmbPgSubType.SelectedIndex = 0;
        txtSrchPg.Text = "";
        //cmbPgType.Enabled = True
        txtPgName.Text = "";
        //txtPgName.Enabled = True
        txtTitle.Text = "";
        txtPageIndex.Text = "1";
        txtPageSize.Text = "10";
        rdbMainAct.SelectedIndex = 0;
        btnAdd.Text = "Add";
        lblAddMsg.Text = "";

    }
    public void bind_grid()
    {
        try
        {

            if (Session["PgTypename"] != "" && Session["PgTypename"] !=null)
            {
                if (txtSrchPg.Text.Trim() == Session["PgTypename"].ToString() || txtSrchPg.Text.Trim() == "")
                {
                    txtSrchPg.Text = Session["PgTypename"].ToString();
                }
                else
                {
                    Session["PgTypename"] = txtSrchPg.Text;
                }
            }
            string GetPgID = "";
            string GetMainPrntID = "";
            string Pagename = "";
            if (!(cmbPgTypeSrch.SelectedIndex == 0) & !(cmbPgTypeSrch.SelectedIndex == -1))
            {
                GetPgID = cmbPgTypeSrch.SelectedValue;
            }
            else
            {
                GetPgID = "";
            }
            if (!(cmbMainParentSrch.SelectedIndex == 0) & !(cmbMainParentSrch.SelectedIndex == -1))
            {
                GetMainPrntID = cmbMainParentSrch.SelectedValue;
            }
            else
            {
                GetMainPrntID = "";
            }
            string editcontent = txtSrchPg.Text;
            if (txtSrchPg.Text.Contains("Hindi"))
            {
                Pagename = editcontent.Remove(editcontent.IndexOf("Hindi"));
            }
            else
            {
                Pagename = txtSrchPg.Text;
            }

            string UsrNm = Session["log_name"].ToString();
            strAlpha = Request.QueryString["alpha"];
            string Usrtype = Session["usr_type"].ToString();
            string StrAlpha = strAlpha;
            //da = ui.Bind_CMSGrid(cms);

            da = new SqlDataAdapter();
            int cnt1 = 0;

            con.Open();
            cmd = new SqlCommand("Proc_ManageMenus", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            if (!string.IsNullOrEmpty(GetMainPrntID))
            {
                cmd.Parameters.AddWithValue("@strParentId1", GetPgID);

            }
            if (!string.IsNullOrEmpty(GetMainPrntID))
            {
                cmd.Parameters.AddWithValue("@strMainParId1", GetMainPrntID);
            }
          
            if (Usrtype == "admin")
            {
                if (!string.IsNullOrEmpty(StrAlpha))
                {
                    cmd.Parameters.AddWithValue("@strPgFileNm", StrAlpha);
                    cmd.Parameters["@Mode"].Value = "CntPgMkr1";
                }
                else
                {
                    cmd.Parameters.AddWithValue("@strPgFileNm", Pagename);
                    cmd.Parameters["@Mode"].Value = "CntPgMkr2";
                }
            }
            else
            {
                string lognm1 = UsrNm;
                cmd.Parameters.AddWithValue("@strLogNm", lognm1);
                if (!string.IsNullOrEmpty(StrAlpha))
                {
                    cmd.Parameters.AddWithValue("@strPgFileNm", StrAlpha);
                    cmd.Parameters["@Mode"].Value = "CntPg_usrMkr1";
                }
                else
                {
                    cmd.Parameters.AddWithValue("@strPgFileNm", Pagename);
                    cmd.Parameters["@Mode"].Value = "CntPg_usrM2";
                }


                //if (!string.IsNullOrEmpty(StrAlpha))
                //{
                //    cmd.Parameters.AddWithValue("@strPgFileNm", StrAlpha);
                //    cmd.Parameters["@Mode"].Value = "CntPgMkr1";
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("@strPgFileNm", Pagename);
                //    cmd.Parameters["@Mode"].Value = "CntPgMkr2";
                //}

            }
            cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            if (cnt1 > 0)
            {
                con.Open();

                cmd = new SqlCommand("Proc_ManageMenus", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                if (!string.IsNullOrEmpty(GetMainPrntID))
                {
                    cmd.Parameters.AddWithValue("@strParentId1", GetPgID);

                }
                if (!string.IsNullOrEmpty(GetMainPrntID))
                {
                    cmd.Parameters.AddWithValue("@strMainParId1", GetMainPrntID);
                }
                //cmd.Parameters.AddWithValue("@strParentId1", cms.GetPageMParentsId)
                //cmd.Parameters.AddWithValue("@strMainParId1", cms.GetPageGParentsId)


                if (Usrtype == "admin")
                {
                    if (!string.IsNullOrEmpty(StrAlpha))
                    {
                        cmd.Parameters.AddWithValue("@strPgFileNm", StrAlpha);
                        cmd.Parameters["@Mode"].Value = "ShowPgMkr1";
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@strPgFileNm", Pagename);
                       // cmd.Parameters.AddWithValue("@strLogNm", Session["log_name"].ToString());
                        cmd.Parameters["@Mode"].Value = "ShowPgMkr2";
                    }
                }
                else
                {
                    string lognm1 = UsrNm;
                    cmd.Parameters.AddWithValue("@strLogNm", lognm1);
                    if (!string.IsNullOrEmpty(StrAlpha))
                    {
                        cmd.Parameters.AddWithValue("@strPgFileNm", StrAlpha);
                        cmd.Parameters["@Mode"].Value = "ShowPg_usrMkr1";
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@strPgFileNm", Pagename);
                        //cmd.Parameters.AddWithValue("@strLogNm", Session["log_name"].ToString());

                        cmd.Parameters["@Mode"].Value = "ShowPg_usrM2";
                    }

                    //if (!string.IsNullOrEmpty(StrAlpha))
                    //{
                    //    cmd.Parameters.AddWithValue("@strPgFileNm", StrAlpha);
                    //    cmd.Parameters["@Mode"].Value = "ShowPgMkr1";
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@strPgFileNm", Pagename);
                    //    //cmd.Parameters["@Mode"].Value = "ShowPgMkr2";
                    //    cmd.Parameters["@Mode"].Value = "ShowPgMkr1";
                    //}
                }

                da.SelectCommand = cmd;
                DataSet ds1 = new DataSet();
                da.Fill(ds1, "tbl_Pages1");
                con.Close();
                if ((ds1 != null))
                {
                    if (!(ds1.Tables["tbl_Pages1"].Rows.Count == 0))
                    {
                        lblmsg.Text = ds1.Tables["tbl_Pages1"].Rows.Count + " Records found !!";

                        dg_Pg.Visible = true;
                        try
                        {
                            dg_Pg.DataSource = ds1.Tables["tbl_Pages1"].DefaultView;
                            dg_Pg.DataBind();
                        }
                        catch
                        {
                            try
                            {
                                this.dg_Pg.CurrentPageIndex = 0;
                                this.dg_Pg.DataBind();
                            }
                            catch (Exception ex)
                            {
                                //Response.Write(ex.ToString())
                                string ma1 = "";
                                ma1 = ex.ToString();

                                if (!ma1.Contains("Thread was being aborted"))
                                {

                                    try
                                    {
                                        string ErrorPath = System.Configuration.ConfigurationManager.AppSettings["ErrorLogPath"];
                                        StreamWriter sw = new StreamWriter(ErrorPath + "ErrorLog" + DateAndTime.Now.ToString("yyyyddmm") + ".txt", true);
                                        sw.WriteLine(ex.Message);
                                        sw.Write(ex.StackTrace);
                                        sw.Close();
                                        //Response.Write(ex.Message);
                                    }
                                    catch
                                    {
                                        // Response.Write(ex.Message);
                                    }
                                }
                            }
                        }
                        tr_pg.Visible = true;
                    }
                    else
                    {
                        dg_Pg.DataSource = null;
                        dg_Pg.DataBind();
                        dg_Pg.Visible = false;
                        tr_pg.Visible = false;
                        lblmsg.Text = "No record found !!";
                    }
                }
            }
            else
            {
                dg_Pg.DataSource = null;
                dg_Pg.DataBind();
                dg_Pg.Visible = false;
                tr_pg.Visible = false;
                lblmsg.Text = "No record found !!";
            }

        }
        catch (Exception ex)
        {
            //Response.Write(ex.ToString())
            string ma1 = "";
            ma1 = ex.ToString();

            if (!ma1.Contains("Thread was being aborted"))
            {

                try
                {
                    //string ErrorPath = System.Configuration.ConfigurationManager.AppSettings("ErrorLogPath");
                    //StreamWriter sw = new StreamWriter(ErrorPath + "ErrorLog" + DateAndTime.Now.ToString("yyyyddmm") + ".txt", true);
                    //sw.WriteLine(ex.Message);
                    //sw.Write(ex.StackTrace);
                    //sw.Close();
                    //Response.Write(ex.Message);

                }
                catch
                {
                }
            }
        }
    }
    char Chr(int n)
    {
        return (char)n;
    }
    public void fill_MainParentSrch()
    {
        try
        {

            string Usrtype = Session["usr_type"].ToString();

            SqlDataAdapter da = new SqlDataAdapter();
            //da = ui.fill_MainPrnt_Srch(cms);
            int cnt1 = 0;

            con.Open();
            //cmd = New SqlCommand("select count(distinct MainParentId) from Main_PageParents", con)
            cmd = new SqlCommand("Proc_ManageMenus", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
            if (Usrtype == "admin")
            {
                cmd.Parameters["@Mode"].Value = "CntMainParent3";
            }
            else
            {
                //cmd = new SqlCommand("Proc_ManageMenus", con);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));                
                cmd.Parameters.AddWithValue("@strLogNm", Session["log_name"].ToString());
                cmd.Parameters["@Mode"].Value = "cntUsrMainParentsM3";
                //cmd.Parameters["@Mode"].Value = "CntMainParent3";
            }
            cnt1 = (int)cmd.ExecuteScalar();
            con.Close();
            if (cnt1 > 0)
            {


                con.Open();
                cmd = new SqlCommand("Proc_ManageMenus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 50));
                if (Usrtype == "admin")
                {
                    cmd.Parameters["@Mode"].Value = "ShMainParent3";
                }
                else
                {
                    cmd = new SqlCommand("Proc_ManageMenus", con);
                     cmd.CommandType = System.Data.CommandType.StoredProcedure;
                     cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20)); 
                    cmd.Parameters.AddWithValue("@strLogNm", Session["log_name"].ToString());
                    cmd.Parameters["@Mode"].Value = "getUsrMainParentsM3";
                   // cmd.Parameters["@Mode"].Value = "ShMainParent3";
                }
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                con.Close();

                da.Fill(ds, "tbl_MainParentSrc");

                if ((ds != null))
                {
                    if (!(ds.Tables["tbl_MainParentSrc"].Rows.Count == 0))
                    {
                        cmbMainParentSrch.Items.Clear();
                        cmbMainParentSrch.DataSource = ds.Tables["tbl_MainParentSrc"];
                        cmbMainParentSrch.DataTextField = "MainParentName";
                        cmbMainParentSrch.DataValueField = "MainParentId";
                        cmbMainParentSrch.DataBind();
                        cmbMainParentSrch.Items.Insert(0, "Select Main Type");
                        cmbMainParentSrch.SelectedIndex = 0;

                        cmbMainType.Items.Clear();
                        cmbMainType.DataSource = ds.Tables["tbl_MainParentSrc"];
                        cmbMainType.DataTextField = "MainParentName";
                        cmbMainType.DataValueField = "MainParentId";
                        cmbMainType.DataBind();
                        cmbMainType.Items.Insert(0, "Select Main Type");
                        cmbMainType.SelectedIndex = 0;

                    }
                    else
                    {
                        cmbMainParentSrch.Items.Clear();
                        cmbMainParentSrch.Items.Insert(0, "Select Main Type");
                        cmbMainParentSrch.SelectedIndex = 0;

                        cmbMainType.Items.Clear();
                        cmbMainType.Items.Insert(0, "Select Main Type");
                        cmbMainType.SelectedIndex = 0;
                    }
                }
                else
                {
                    cmbMainParentSrch.Items.Clear();
                    cmbMainParentSrch.Items.Insert(0, "Select Main Type");
                    cmbMainParentSrch.SelectedIndex = 0;

                    cmbMainType.Items.Clear();
                    cmbMainType.Items.Insert(0, "Select Main Type");
                    cmbMainType.SelectedIndex = 0;
                }
            }
            else
            {
                cmbMainParentSrch.Items.Clear();
                cmbMainParentSrch.Items.Insert(0, "Select Main Type");
                cmbMainParentSrch.SelectedIndex = 0;

                cmbMainType.Items.Clear();
                cmbMainType.Items.Insert(0, "Select Main Type");
                cmbMainType.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            //Response.Write(ex.ToString())
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
    public void btn_go()
    {
        if (!string.IsNullOrEmpty(txtPageSize.Text))
        {
            if (!string.IsNullOrEmpty(txtPageSize.Text) && Information.IsNumeric(txtPageSize.Text) == true)
            {
                dg_Pg.PageSize = Convert.ToInt32(txtPageSize.Text);
            }
        }

        int pg_index = 0;
        if (!string.IsNullOrEmpty(txtPageIndex.Text))
        {
            if (!string.IsNullOrEmpty(txtPageIndex.Text) && Information.IsNumeric(txtPageIndex.Text) == true)
            {
                pg_index = Convert.ToInt32(txtPageIndex.Text) - 1;
                dg_Pg.CurrentPageIndex = pg_index;
            }
        }

        // bind_grid(cms);

        string x1 = "";
        x1 = dg_Pg.CurrentPageIndex.ToString();

        int currPage = Convert.ToInt32(x1) + 1;

        string x2 = "";
        x2 = dg_Pg.PageCount.ToString();

        txtPageIndex.Text = currPage.ToString();
        lblPageIndex.Text = "Page" + " " + currPage + " " + "of" + " " + x2 + " " + ". Skip to page";
    }
    protected void btnSrch_Click(object sender, EventArgs e)
    {
        if (cmbMainParentSrch.SelectedIndex == 0 && cmbPgTypeSrch.SelectedIndex == 0 && txtSrchPg.Text == "")
        {
            lblMainMsg.Text = "Please Select or enter field to search !!!";
        }
        else
        {
            int flag = 0;

            if (!(cmbMainParentSrch.SelectedIndex == 0))
            {
                if (Information.IsNumeric(cmbMainParentSrch.SelectedValue) == false)
                {
                    lblMainMsg.Text = "Select valid main type for search!!";
                    cmbMainParentSrch.SelectedIndex = 0;
                    cmbMainParentSrch.Focus();
                    flag = 1;
                }
            }
            else if (!(cmbPgTypeSrch.SelectedIndex == 0))
            {
                if (cmbPgTypeSrch.SelectedIndex == 0 & Information.IsNumeric(cmbPgTypeSrch.SelectedValue) == false)
                {
                    lblMainMsg.Text = "Select valid page type for search!!";
                    cmbPgTypeSrch.SelectedIndex = 0;
                    cmbPgTypeSrch.Focus();
                    flag = 2;
                }
            }
            if (!(flag > 0))
            {
                //if (!string.IsNullOrEmpty(txtSrchPg.Text) & chkPgNm1(txtSrchPg.Text) == false)
                if (!string.IsNullOrEmpty(txtSrchPg.Text) & !Regex.IsMatch(txtSrchPg.Text, "^[a-zA-Z0-9_-]+$"))
                {
                    lblMainMsg.Text = "Enter valid page name to be searched!!";
                    txtSrchPg.Focus();
                }
                else if (!string.IsNullOrEmpty(txtSrchPg.Text) & txtSrchPg.Text.Length > 100)
                {
                    lblMainMsg.Text = "Page name to be searched should contain maximum 100 characters!!";
                    txtSrchPg.Focus();
                }
                else if (flag == 0)
                {
                    lblMainMsg.Text = "";
                    bind_grid();
                }
            }
        }
    }
    protected void cmbMainParentSrch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!(cmbMainParentSrch.SelectedIndex == 0))
        {
            cmbPgTypeSrch.Items.Clear();
            cmbPgTypeSrch.Items.Insert(0, "Select Page Type");
            cmbPgTypeSrch.SelectedIndex = 0;
            fill_ParentSrch();
        }
        else
        {
            cmbPgTypeSrch.Items.Clear();
            cmbPgTypeSrch.Items.Insert(0, "Select Page Type");
            cmbPgTypeSrch.SelectedIndex = 0;
        }
    }

    public void fill_Parent()
    {
        try
        {
            string GetMainPrntID = "";
            if (!(cmbMainType.SelectedIndex == 0))
            {
                GetMainPrntID = cmbMainType.SelectedValue;
            }
            string UsrNm = Session["log_name"].ToString();
            string Usrtype = Session["usr_type"].ToString();
            //da = ui.Fill_Parent(cms);
            da = new SqlDataAdapter();
            int cnt1 = 0;

            con.Open();
            cmd = new SqlCommand("Proc_ManageMenus", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strMainParId1", GetMainPrntID);
            if (Usrtype == "admin")
            {
                cmd.Parameters["@Mode"].Value = "CntMainPg2";
            }
            else
            {
                cmd.Parameters.AddWithValue("@strLogNm", UsrNm);
                cmd.Parameters["@Mode"].Value = "cntUsrPg2";

               // cmd.Parameters["@Mode"].Value = "CntMainPg2";
            }
            cnt1 = (int)cmd.ExecuteScalar();
            con.Close();

            if (cnt1 > 0)
            {
                con.Open();

                cmd = new SqlCommand("Proc_ManageMenus", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strMainParId1", GetMainPrntID);
                if (Usrtype == "admin")
                {
                    cmd.Parameters["@Mode"].Value = "ShMainPg2";
                }
                else
                {
                    cmd.Parameters.AddWithValue("@strLogNm", UsrNm);
                    cmd.Parameters["@Mode"].Value = "shtUsrPg2";
                    //cmd.Parameters["@Mode"].Value = "ShMainPg2";
                }

                da.SelectCommand = cmd;
                con.Close();
            }
            da.Fill(ds, "tbl_MainPg2");
            if ((ds != null))
            {
                if (!(ds.Tables["tbl_MainPg2"].Rows.Count == 0))
                {
                    cmbPgType.Items.Clear();
                    cmbPgType.DataSource = ds.Tables["tbl_MainPg2"];
                    cmbPgType.DataTextField = "MainPageName";
                    cmbPgType.DataValueField = "parentid";
                    cmbPgType.DataBind();
                    cmbPgType.Items.Insert(0, "Select Page Type");
                    cmbPgType.SelectedIndex = 0;
                }
                else
                {
                    cmbPgType.Items.Clear();
                    cmbPgType.Items.Insert(0, "Select Page Type");
                    cmbPgType.SelectedIndex = 0;
                }
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
    public void fill_ParentSrch()
    {
        try
        {
            string GetPrntID = "";
            if (!(cmbMainParentSrch.SelectedIndex == 0))
            {

                GetPrntID = cmbMainParentSrch.SelectedValue;
            }
            string UsrNm = Session["log_name"].ToString();
            string Usrtype = Session["usr_type"].ToString();
            //da = ui.Fill_ParentSrch(cms);
            da = new SqlDataAdapter();
            int cnt1 = 0;

            con.Open();
            cmd = new SqlCommand("Proc_ManageMenus", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
            cmd.Parameters.AddWithValue("@strMainParId1", GetPrntID);
            if (Usrtype == "admin")
            {
                cmd.Parameters["@Mode"].Value = "CntMainPg2";
            }
            else
            {
                cmd.Parameters.AddWithValue("@strLogNm", UsrNm);
                cmd.Parameters["@Mode"].Value = "cntUsrPg2";
               // cmd.Parameters["@Mode"].Value = "CntMainPg2";
            }
            cnt1 = (int)cmd.ExecuteScalar();
            con.Close();

            if (cnt1 > 0)
            {
                con.Open();

                cmd = new SqlCommand("Proc_ManageMenus", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                cmd.Parameters.AddWithValue("@strMainParId1", GetPrntID);
                if (Usrtype == "admin")
                {
                    cmd.Parameters["@Mode"].Value = "ShMainPg2";
                }
                else
                {
                    cmd.Parameters.AddWithValue("@strLogNm", UsrNm);
                   cmd.Parameters["@Mode"].Value = "shtUsrPg2";
                   // cmd.Parameters["@Mode"].Value = "ShMainPg2";
                }

                da.SelectCommand = cmd;
                con.Close();

            }

            da.Fill(ds, "tbl_MainPg");
            if ((ds != null))
            {
                if (!(ds.Tables["tbl_MainPg"].Rows.Count == 0))
                {
                    cmbPgTypeSrch.Items.Clear();
                    cmbPgTypeSrch.DataSource = ds.Tables["tbl_MainPg"];
                    cmbPgTypeSrch.DataTextField = "MainPageName";
                    cmbPgTypeSrch.DataValueField = "parentid";
                    cmbPgTypeSrch.DataBind();
                    cmbPgTypeSrch.Items.Insert(0, "Select Page Type");
                    cmbPgTypeSrch.SelectedIndex = 0;
                }
                else
                {
                    cmbPgTypeSrch.Items.Clear();
                    cmbPgTypeSrch.Items.Insert(0, "Select Page Type");
                    cmbPgTypeSrch.SelectedIndex = 0;
                }
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
                    //string ErrorPath = System.Configuration.ConfigurationManager.AppSettings("ErrorLogPath");
                    //StreamWriter sw = new StreamWriter(ErrorPath + "ErrorLog" + DateAndTime.Now.ToString("yyyyddmm") + ".txt", true);
                    //sw.WriteLine(ex.Message);
                    //sw.Write(ex.StackTrace);
                    //sw.Close();
                    Response.Write(ex.Message);

                }
                catch
                {
                }
            }
        }
    }
    protected void cmbMainType_SelectedIndexChanged(object sender, EventArgs e)
    {
        PgSubType.Visible = false;
        if (!(cmbMainType.SelectedIndex == 0))
        {
            fill_Parent();
        }
        else
        {
            cmbPgType.Items.Clear();
            cmbPgType.Items.Insert(0, "Select Page Type");
            cmbPgType.SelectedIndex = 0;
        }
    }
    public bool chk_data()
    {

        if (cmbMainType.SelectedIndex == 0)
        {
            lblAddMsg.Text = "Please select main type !!";
            cmbMainType.Focus();
            return false;

        }
        else if (!(cmbMainType.SelectedIndex == 0) & Information.IsNumeric(cmbMainType.SelectedValue) == false)
        {
            lblAddMsg.Text = "Select valid main type !!";
            cmbMainType.SelectedIndex = 0;
            cmbMainType.Focus();
            return false;

        }
        //else if (checkMainPgType(cmbMainType.SelectedValue, cmbMainType.SelectedItem.Text, "add") == false)
        //{
        //    lblAddMsg.Text = "Select valid main type !!";
        //    cmbMainType.SelectedIndex = 0;
        //    cmbMainType.Focus();
        //    return false;

        //}
        else if (cmbPgType.SelectedIndex == 0)
        {
            lblAddMsg.Text = "Please select page type !!";
            cmbPgType.Focus();
            return false;

        }
        else if (!(cmbPgType.SelectedIndex == 0) & Information.IsNumeric(cmbPgType.SelectedValue) == false)
        {
            lblAddMsg.Text = "Select valid page type !!";
            cmbPgType.SelectedIndex = 0;
            cmbPgType.Focus();
            return false;
        }
        else if (txtTitle.Text.Trim() == "")
        {
            lblAddMsg.Text = "Please enter page title !!";
            txtTitle.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtTitle.Text))
        {
            lblAddMsg.Text = "Please enter page title !!";
            txtTitle.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtTitle.Text) & !Regex.IsMatch(txtTitle.Text, "^[a-zA-Z0-9-_& ]+$"))
        //else if (!string.IsNullOrEmpty(txtTitle.Text) & chkPgTitle(txtTitle.Text) == false)
        {
            lblAddMsg.Text = "Enter valid page title !!";
            txtTitle.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtTitle.Text) & txtTitle.Text.Length > 100)
        {
            lblAddMsg.Text = "Page title should contain maximum 100 characters!!";
            txtTitle.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtPgName.Text))
        {
            lblAddMsg.Text = "Please enter page name !!";
            txtPgName.Focus();
            return false;
        }
        //else if (chkPgNm1(txtPgName.Text) == false)
        else if (!Regex.IsMatch(txtPgName.Text, "^[a-zA-Z0-9-]+$"))
        {
            lblAddMsg.Text = "Please enter valid page name !!";
            txtPgName.Focus();
            return false;
        }
        else if (Information.IsNumeric(txtPgName.Text) == true)
        {
            lblAddMsg.Text = "Page name must start with characters!!";
            txtPgName.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtPgName.Text) & txtPgName.Text.Length > 100)
        {
            lblAddMsg.Text = "Page name should contain maximum 100 characters!!";
            txtPgName.Focus();
            return false;
        }
       
        else
        {
            lblAddMsg.Text = "";
            return true;
        }

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtTitle.Text))
        {
            if (!string.IsNullOrEmpty(txtPgName.Text))
            {
                txtTitle.Text = txtPgName.Text;
            }
            else
            {
                txtTitle.Text = "";
            }
        }
        if (!chk_data() == false)
        {
            if (btnAdd.Text == "Add")
            {
                string strFilename = "";
                string strFilenameHindi = "";
                string strFilenametamil = "";


                strFilename = txtPgName.Text;
                strFilenameHindi = strFilename + "Hindi";
                strFilenametamil = strFilename + "Tamil";
                int cnt1, cnt2, cnt3;
                string Pagename = strFilename;
                string PagenameHindi = strFilenameHindi;
                string Pagenametamil = strFilenametamil;
                Session["ContPgNmEng"] = strFilename;
                Session["ContPgNmHnd"] = strFilenameHindi;
                Session["ContPgNmTam"] = strFilenametamil;

                con.Open();
                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strPageNm", Pagename);
                cmd.Parameters["@Mode"].Value = "PgDupNm1";
                cnt1 = (int)cmd.ExecuteScalar();
                con.Close();

                con.Open();
                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strPageNm", PagenameHindi);
                cmd.Parameters["@Mode"].Value = "PgHndDupNm1";
                cnt2 = (int)cmd.ExecuteScalar();
                con.Close();

                con.Open();
                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strPageNm", Pagenametamil);
                cmd.Parameters["@Mode"].Value = "PgMarDupNm1";
                cnt3 = (int)cmd.ExecuteScalar();
                con.Close();

                if (cnt1 == 0 && cnt2 == 0 && cnt3 == 0)
                {


                    con.Open();
                    cmd = new SqlCommand("Proc_Sections", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd.Parameters.AddWithValue("@Name", int.Parse(cmbMainType.SelectedValue));
                    cmd.Parameters["@Mode"].Value = "CntDtlsByPrnt";
                    cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();

                    if (cnt1 > 0)
                    {

                        lblmsg.Text = "";
                        ///''''''''''''''''''' add English page
                        int j = 0;
                        j = strFilename.IndexOf(".aspx");
                        string LnkName = "";
                        if (j == -1)
                        {
                            strFilename = strFilename + ".aspx";
                            LnkName = strFilename;
                        }
                        else
                        {
                            LnkName = strFilename;
                        }
                        string GetMainPrntID = string.Empty;
                        if (cmbPgSubType.Visible == true && cmbPgSubType.SelectedIndex != 0)
                        {
                            GetMainPrntID = cmbPgSubType.SelectedValue;
                        }
                        else if (cmbPgSubType.Visible == false)
                        {
                            GetMainPrntID = cmbPgType.SelectedValue;
                        }
                        string PageTitle = txtTitle.Text;
                        Pagename = txtPgName.Text;
                        string LnkAct = rdbMainAct.SelectedValue;
                        //ui.AddPage(cms);
                        con.Open();
                        cmd = new SqlCommand("Proc_ManageCmsPages", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                        cmd.Parameters.AddWithValue("@strPageTitle", PageTitle);
                        cmd.Parameters.AddWithValue("@strPageNm", Pagename);
                        cmd.Parameters.AddWithValue("@strPgFileNm", LnkName);

                        cmd.Parameters.AddWithValue("@strParentId1", GetMainPrntID);
                        cmd.Parameters.AddWithValue("@PgAct", LnkAct);

                        cmd.Parameters["@Mode"].Value = "AddPgMaker1";
                        cmd.ExecuteNonQuery();
                        con.Close();

                        ///''''''''''''''''''' add Hindi Page

                        j = strFilenameHindi.IndexOf(".aspx");
                        if (j == -1)
                        {
                            strFilenameHindi = strFilenameHindi + ".aspx";
                            LnkName = strFilenameHindi;
                        }
                        else
                        {
                            LnkName = strFilenameHindi;
                        }

                        int HindiFlag = 0;
                        //HindiFlag = ui.AddPageHindi(cms);
                        string pgid1 = "";
                        int cnt11 = 0;

                        con.Open();
                        cmd = new SqlCommand("Proc_ManageCmsPages", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                        cmd.Parameters.AddWithValue("@strPgFileNm", Pagename + ".aspx");
                        cmd.Parameters["@Mode"].Value = "GetPageIDMkr";
                        cnt11=Convert.ToInt32(cmd.ExecuteScalar());
                        if (Convert.IsDBNull(cmd.ExecuteScalar()) == false)
                        {
                            pgid1 = cnt11.ToString();
                            Session["ContPgIdEng"] = pgid1;
                        }
                        else
                        {
                            pgid1 = "";
                        }
                        con.Close();

                        if (!string.IsNullOrEmpty(pgid1))
                        {
                            ///'''''''''''''''''''' Hindi page
                            HindiFlag = 0;

                            con.Open();
                            cmd = new SqlCommand("Proc_ManageCmsPages", con);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                            cmd.Parameters.AddWithValue("@strPageId", pgid1);
                            cmd.Parameters.AddWithValue("@strPageTitle", PageTitle + "Hindi");
                            cmd.Parameters.AddWithValue("@strPageNm", Pagename + "Hindi");

                            cmd.Parameters.AddWithValue("@strPgFileNm", LnkName);

                            cmd.Parameters.AddWithValue("@strParentId1", GetMainPrntID);

                            cmd.Parameters.AddWithValue("@PgAct", "Y");

                            cmd.Parameters["@Mode"].Value = "AddPgHndMaker1";
                            cmd.ExecuteNonQuery();
                            HindiFlag = 1;
                            con.Close();

                        }


                        pgid1 = "0";

                        con.Open();
                        cmd = new SqlCommand("Proc_ManageCmsPages", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                        cmd.Parameters.AddWithValue("@strPgFileNm", strFilename);
                        cmd.Parameters["@Mode"].Value = "GetPageIDMkr";
                        cnt11 = Convert.ToInt32(cmd.ExecuteScalar());
                        if (Convert.IsDBNull(cmd.ExecuteScalar()) == false)
                        {
                           // pgid1 = Convert.ToString(cmd.ExecuteScalar());
                            pgid1 = cnt11.ToString();
                            Session["ContPgIdHnd"] = pgid1;
                        }
                        else
                        {
                            pgid1 = "0";
                        }
                        con.Close();

                        //ui.AddContent(pgid1);
                        j = strFilenametamil.IndexOf(".aspx");
                        if (j == -1)
                        {
                            strFilenametamil = strFilenametamil + ".aspx";
                            LnkName = strFilenametamil;
                        }
                        else
                        {
                            LnkName = strFilenametamil;
                        }
                        int MarFlag = 0;
                        if (!string.IsNullOrEmpty(pgid1))
                        {
                            ///'''''''''''''''''''' Tamil page
                            MarFlag = 0;

                            con.Open();
                            cmd = new SqlCommand("Proc_ManageCmsPages", con);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                            cmd.Parameters.AddWithValue("@strPageId", pgid1);
                            cmd.Parameters.AddWithValue("@strPageTitle", PageTitle + "Tamil");
                            cmd.Parameters.AddWithValue("@strPageNm", Pagename + "Tamil");
                            cmd.Parameters.AddWithValue("@strPgFileNm", LnkName);

                            cmd.Parameters.AddWithValue("@strParentId1", GetMainPrntID);

                            cmd.Parameters.AddWithValue("@PgAct", "Y");

                            cmd.Parameters["@Mode"].Value = "AddPgMarMaker1";
                            cmd.ExecuteNonQuery();
                            MarFlag = 1;
                            con.Close();

                        }


                        ///''''''''''''

                        //pgid1 = ui.GetPageId(strFilename);
                        pgid1 = "0";

                        con.Open();
                        cmd = new SqlCommand("Proc_ManageCmsPages", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                        cmd.Parameters.AddWithValue("@strPgFileNm", strFilename);
                        //cmd.Parameters["@Mode"].Value = "GetPageIDMkr";
                        cmd = new SqlCommand("SELECT distinct PageID FROM Page_Master_Tbl_Maker where PageFileName='" + strFilename + "' ", con);
                        if (Convert.IsDBNull(cmd.ExecuteScalar()) == false)
                        {
                            pgid1 = Convert.ToString(cmd.ExecuteScalar());
                        }
                        else
                        {
                            pgid1 = "0";
                        }
                        con.Close();

                        string content1 = "";

                        con.Open();
                        //SqlCommand cmd22 = new SqlCommand("Proc_ManageCmsPages", con);
                        //cmd22.CommandType = System.Data.CommandType.StoredProcedure;
                        //cmd22.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 30));
                        //cmd22.Parameters["@Mode"].Value = "GetDefaultCont";

                        SqlCommand cmd3 = new SqlCommand("select distinct pgcont from PageContents_default",con);
                        SqlDataAdapter ad2 = new SqlDataAdapter();
                        ad2.SelectCommand = cmd3;
                        DataSet ds2 = new DataSet();
                        ad2.Fill(ds2, "tblaa");
                        if (ds2.Tables["tblaa"].Rows.Count > 0)
                        {
                            content1 = ds2.Tables["tblaa"].Rows[0]["pgcont"].ToString();
                            Session["Content"] = content1;
                        }
                        //string cont =Convert.ToString(cmd.ExecuteScalar());
                    
                        //if (Convert.IsDBNull(cmd.ExecuteScalar()) == false)
                      
                        //{
                        //    content1 = cont.ToString();
                        //    Session["Content"] = content1;
                        //}
                        //else
                        //{
                        //    content1 = "";
                        //}
                        con.Close();
                        ///''get English content

                        con.Open();
                        cmd = new SqlCommand("Proc_ManageCmsPages", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                        cmd.Parameters.AddWithValue("@strPageId", pgid1);
                        cmd.Parameters.AddWithValue("@strContDesc", content1);
                        cmd.Parameters.AddWithValue("@strDtUpload", DateTime.Now);
                        cmd.Parameters.AddWithValue("@strContArch", "N");
                        cmd.Parameters.AddWithValue("@checked1", "N");
                        cmd.Parameters["@Mode"].Value = "AddContMkr";
                        cmd.ExecuteNonQuery();
                        con.Close();

                        ///'''''''''''''''''' add content for Hindi page

                        con.Open();
                        cmd = new SqlCommand("Proc_ManageCmsPages", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                        cmd.Parameters.AddWithValue("@strPageId", pgid1);
                        cmd.Parameters.AddWithValue("@strContDesc", content1);
                        cmd.Parameters.AddWithValue("@strDtUpload", DateTime.Now);
                        cmd.Parameters.AddWithValue("@strContArch", "N");
                        cmd.Parameters["@Mode"].Value = "AddHndContMkr";
                        cmd.ExecuteNonQuery();
                        con.Close();

                        ///'''''''''''''''''' add content for Tamil page

                        con.Open();
                        cmd = new SqlCommand("Proc_ManageCmsPages", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                        cmd.Parameters.AddWithValue("@strPageId", pgid1);
                        cmd.Parameters.AddWithValue("@strContDesc", content1);
                        cmd.Parameters.AddWithValue("@strDtUpload", DateTime.Now);
                        cmd.Parameters.AddWithValue("@strContArch", "N");
                        cmd.Parameters["@Mode"].Value = "AddMarContMkr";
                        cmd.ExecuteNonQuery();
                        con.Close();


                        int pgtp = int.Parse(cmbPgType.SelectedValue);
                        int maintp = int.Parse(cmbMainType.SelectedValue);

                        CreateFile(strFilename, pgtp, maintp, strFilenameHindi, strFilenametamil);
                        Content_History();
                        Audit_Trail();
                        clear_AddEditTbl();
                      
                        lblAddMsg.Text = "Page added successfully !!";
                        bind_grid();
                    }
                    else
                    {
                        lblAddMsg.Text = "Layout for this selection does not exist !!";
                    }
                }

                else
                {
                    lblAddMsg.Text = "!! Page Already Exists !!";
                }
            }

        }
    }
    public void Content_History()
    {
        string ContPgIdEng = Session["ContPgIdEng"].ToString();
        string ContPgIdHnd = Session["ContPgIdHnd"].ToString();
        string ContPgNmEng = Session["ContPgNmEng"].ToString();
        string ContPgNmHnd = Session["ContPgNmHnd"].ToString();
        string MainParent = cmbMainType.SelectedItem.Text;
        string Content = Session["Content"].ToString();
        string AddedBy = Session["log_name"].ToString();
        string AddedOn = DateTime.Now.ToString();
        string Action = "";
        if (btnAdd.Text == "Add")
        {
            Action = "Content Added";
            con.Close();
            //.........................Adding English Content History
            con.Open();
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strContent", Content);
            cmd.Parameters.AddWithValue("@strContPgId", ContPgIdEng);
            cmd.Parameters.AddWithValue("@strContPgNmEng", ContPgNmEng);
            cmd.Parameters.AddWithValue("@strMainParent", MainParent);
            cmd.Parameters.AddWithValue("@strAddedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("@strAddedBy", AddedBy);
            cmd.Parameters.AddWithValue("@strAction", Action);
            cmd.Parameters["@mode"].Value = "ContEngAdd";
            cmd.ExecuteNonQuery();
            con.Close();
            //.........................Adding Hindi Content History
            con.Open();
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strContent", Content);
            cmd.Parameters.AddWithValue("@strContPgId", ContPgIdHnd);
            cmd.Parameters.AddWithValue("@strContPgNmHnd", ContPgNmHnd);
            cmd.Parameters.AddWithValue("@strMainParent", MainParent);
            cmd.Parameters.AddWithValue("@strAddedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("@strAddedBy", AddedBy);
            cmd.Parameters.AddWithValue("@strAction", Action);
            cmd.Parameters["@mode"].Value = "ContHndAdd";
            cmd.ExecuteNonQuery();
            con.Close();

            //.........................Adding Tamil Content History
            con.Open();
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strContent", Content);
            cmd.Parameters.AddWithValue("@strContPgId", ContPgIdHnd);
            cmd.Parameters.AddWithValue("@strContPgNmHnd", ContPgNmHnd);
            cmd.Parameters.AddWithValue("@strMainParent", MainParent);
            cmd.Parameters.AddWithValue("@strAddedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("@strAddedBy", AddedBy);
            cmd.Parameters.AddWithValue("@strAction", Action);
            cmd.Parameters["@mode"].Value = "ConttamilAdd";
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    void Audit_Trail()
    {
        string Remark = "";
        if (txtPgName.Text != "")
        {
            fields1 = "Page Name : " + txtPgName.Text;
        }
        else
        {
            fields1 = "Page Name : " + fields1;
        }
        if (cmbMainType.SelectedIndex != 0)
        {
            if (fields1 == "")
            {
                fields1 = ", Parent : " + cmbMainType.SelectedItem.Text;
            }
            else
            {
                fields1 = fields1 + ", Parent : " + cmbMainType.SelectedItem.Text;
            }
        }
        if (cmbPgType.SelectedIndex != 0)
        {
            if (cmbPgSubType.Visible == true && cmbPgSubType.SelectedIndex != 0)
            {
                if (fields1 == "")
                {
                    fields1 = ", Page Type : " + cmbPgSubType.SelectedItem.Text;
                }
                else
                {
                    fields1 = fields1 + ", Page Type : " + cmbPgSubType.SelectedItem.Text;
                }
            }
            else
            {
                if (fields1 == "")
                {
                    fields1 = ", Page Type : " + cmbPgType.SelectedItem.Text;
                }
                else
                {
                    fields1 = fields1 + ", Page Type : " + cmbPgType.SelectedItem.Text;
                }
            }
        }

        string LogNm = Session["log_name"].ToString();
        string LogId = Convert.ToString(Session["usr_id"]);
        string FieldNm = fields1;
        string TblNm = "Page_Master_Tbl";
        string PageNm = "Manage_InnerPage.aspx";
        string ModuleNm = "Content Management";

        if (btnAdd.Text == "Add" && msg == "")
        {
            Remark = "Page is Added";
            //audtclass.AditOnAdd(adm, "Add");
            con.Close();
            con.Open();
            cmd = new SqlCommand("proc_AuditTrail", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strLogNm", LogNm);
            cmd.Parameters.AddWithValue("@strLogId", LogId);
            cmd.Parameters.AddWithValue("@strTblNm", TblNm);
            cmd.Parameters.AddWithValue("@strFildNm", FieldNm);
            cmd.Parameters.AddWithValue("@strPgNm", PageNm);
            cmd.Parameters.AddWithValue("@strModuleNm", ModuleNm);
            cmd.Parameters.AddWithValue("@strAuditDt", DateAndTime.Now);
            cmd.Parameters.AddWithValue("@strRemark", Remark);
            cmd.Parameters.AddWithValue("@strAddOn", DateAndTime.Now);
            cmd.Parameters["@mode"].Value = "AuditOnAdd";
            cmd.ExecuteNonQuery();
            con.Close();
        }
        else if (msg.Contains("Checked"))
        {
            if (msg.Contains("CheckedEdit"))
            {
                Remark = "Page Content is Checked";
            }
            else if (msg.Contains("CheckedMenu"))
            {
                Remark = "Page Menu is Checked";
            }
            //audtclass.AditOnAdd(adm, "Add");
            con.Close();
            con.Open();
            cmd = new SqlCommand("proc_AuditTrail", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strLogNm", LogNm);
            cmd.Parameters.AddWithValue("@strLogId", LogId);
            cmd.Parameters.AddWithValue("@strTblNm", TblNm);
            cmd.Parameters.AddWithValue("@strFildNm", FieldNm);
            cmd.Parameters.AddWithValue("@strPgNm", PageNm);
            cmd.Parameters.AddWithValue("@strModuleNm", ModuleNm);
            cmd.Parameters.AddWithValue("@strRemark", Remark);
            cmd.Parameters["@mode"].Value = "AuditOnChecked";
            cmd.ExecuteNonQuery();
            con.Close();

        }
        else if (msg.Contains("Delete"))
        {
            Remark = "Page is Deleted";
            //audtclass.AditOnAdd(adm, "Add");
            con.Close();
            con.Open();
            cmd = new SqlCommand("proc_AuditTrail", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strLogNm", LogNm);
            cmd.Parameters.AddWithValue("@strLogId", LogId);
            cmd.Parameters.AddWithValue("@strTblNm", TblNm);
            cmd.Parameters.AddWithValue("@strFildNm", FieldNm);
            cmd.Parameters.AddWithValue("@strPgNm", PageNm);
            cmd.Parameters.AddWithValue("@strModuleNm", ModuleNm);
            cmd.Parameters.AddWithValue("@strAuditDt", DateAndTime.Now);
            cmd.Parameters.AddWithValue("@strRemark", Remark);
            cmd.Parameters.AddWithValue("@strDelOn", DateAndTime.Now);
            cmd.Parameters["@mode"].Value = "AuditOnDelete";
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
    void CreateFile(string strName, int k, int MainId1, string strnameother, string strnametamil)
    {


        string path = Server.MapPath(@"..");
        con.Close();
        con.Open();
        cmd = new SqlCommand("Proc_Sections", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
        cmd.Parameters.AddWithValue("@Name", MainId1.ToString());
        cmd.Parameters["@Mode"].Value = "GetDtlsByPrnt";
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds, "tbl_layouts");
        con.Close();

        string dynaminpg = ds.Tables["tbl_layouts"].Rows[0]["DynamicPgName"].ToString();
        int J = 0;
        J = strName.IndexOf(".aspx");
        if (J != -1)
        {
            File.Copy(path + "\\" + dynaminpg + "", path + "\\" + strName);
        }
        else
        {
            File.Copy(path + "\\" + dynaminpg + "", path + "\\" + strName + ".aspx");
        }

        ///''''''''''''''''''''''''  for Hindi
        string dynaminpg2 = ds.Tables["tbl_layouts"].Rows[1]["DynamicPgName"].ToString();
        //dynaminpg2 = dynaminpg2 + ".aspx";
        J = strnameother.IndexOf(".aspx");
        if (J != -1)
        {
            File.Copy(path + "\\Hindi" + "\\" + dynaminpg2 + "", path + "\\Hindi" + "\\" + strnameother);
        }
        else
        {
            File.Copy(path + "\\Hindi" + "\\" + dynaminpg2 + "", path + "\\Hindi" + "\\" + strnameother + ".aspx");
        }

        ///''''''''''''''''''''''''  for Tamil
        string dynaminpg3 = ds.Tables["tbl_layouts"].Rows[2]["DynamicPgName"].ToString();
        J = strnameother.IndexOf(".aspx");
        if (J != -1)
        {
            File.Copy(path + "\\Tamil" + "\\" + dynaminpg3 + "", path + "\\Tamil" + "\\" + strnametamil);
        }
        else
        {
            File.Copy(path + "\\Tamil" + "\\" + dynaminpg3 + "", path + "\\Tamil" + "\\" + strnametamil + ".aspx");
        }

    }
    protected void dg_Pg_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        {
            if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.SelectedItem | e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.EditItem)
            {
                string PageID = "";
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "PageID")) == false)
                {
                    PageID = DataBinder.Eval(e.Item.DataItem, "PageID").ToString();
                }
                else
                {
                    PageID = "";
                }

                string MainPageName = "";
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "MainPageName")) == false)
                {
                    MainPageName = DataBinder.Eval(e.Item.DataItem, "MainPageName").ToString();
                }
                else
                {
                    MainPageName = "--";
                }

                string MainParentName = "";
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "MainParentName")) == false)
                {
                    MainParentName = DataBinder.Eval(e.Item.DataItem, "MainParentName").ToString();
                }
                else
                {
                    MainParentName = "--";
                }

                e.Item.Cells[2].Text = MainParentName + " - " + MainPageName;


                string PageTitle = "";
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "PageTitle")) == false)
                {
                    PageTitle = DataBinder.Eval(e.Item.DataItem, "PageTitle").ToString();
                }
                else
                {
                    PageTitle = "--";
                }

                string TitleHnd = "";
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "TitleHnd")) == false)
                {
                    TitleHnd = DataBinder.Eval(e.Item.DataItem, "TitleHnd").ToString();
                }
                else
                {
                    TitleHnd = "--";
                }

                string TitleTam = "";
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "TitleTam")) == false)
                {
                    TitleTam = DataBinder.Eval(e.Item.DataItem, "TitleTam").ToString();
                }
                else
                {
                    TitleTam = "--";
                }

                e.Item.Cells[3].Text = PageTitle + "<br>" + TitleHnd + "<br>" + TitleTam;

                string PageName = "";
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "PageName")) == false)
                {
                    PageName = DataBinder.Eval(e.Item.DataItem, "PageName").ToString();
                }
                else
                {
                    PageName = "--";
                }

                string PgNmHnd = "";
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "PgNmHnd")) == false)
                {
                    PgNmHnd = DataBinder.Eval(e.Item.DataItem, "PgNmHnd").ToString();
                }
                else
                {
                    PgNmHnd = "--";
                }

                string PgNmTam = "";
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "PgNmTam")) == false)
                {
                    PgNmTam = DataBinder.Eval(e.Item.DataItem, "PgNmTam").ToString();
                }
                else
                {
                    PgNmTam = "--";
                }

                e.Item.Cells[4].Text = PageName + "<br>" + PgNmHnd + "<br>" + PgNmTam;


                string PageFileName = "";
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "PageFileName")) == false)
                {
                    PageFileName = DataBinder.Eval(e.Item.DataItem, "PageFileName").ToString();
                    ((LinkButton)e.Item.Cells[5].FindControl("lnkEngPgCont")).Text = PageFileName;
                }
                else
                {
                    ((LinkButton)e.Item.Cells[5].FindControl("lnkEngPgCont")).Text = "--";
                    PageFileName = "--";
                }

                string PgFileHnd = "";
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "PgFileHnd")) == false)
                {
                    PgFileHnd = DataBinder.Eval(e.Item.DataItem, "PgFileHnd").ToString();
                    ((LinkButton)e.Item.Cells[5].FindControl("lnkHndPgCont")).Text = PgFileHnd;
                }
                else
                {
                    ((LinkButton)e.Item.Cells[5].FindControl("lnkHndPgCont")).Text = "--";
                    PgFileHnd = "--";
                }

                string PgFileMar = "";
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "PgFileTam")) == false)
                {
                    PgFileMar = DataBinder.Eval(e.Item.DataItem, "PgFileTam").ToString();
                    ((LinkButton)e.Item.Cells[5].FindControl("lnkTamilPgCont")).Text = PgFileMar;
                }
                else
                {
                    ((LinkButton)e.Item.Cells[5].FindControl("lnkTamilPgCont")).Text = "--";
                    PgFileMar = "--";
                }


                string PageAct = "";
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "PageAct")) == false)
                {
                    PageAct = DataBinder.Eval(e.Item.DataItem, "PageAct").ToString();
                }
                else
                {
                    PageAct = "N";
                }

                string PageActHnd = "";
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "PageActHnd")) == false)
                {
                    PageActHnd = DataBinder.Eval(e.Item.DataItem, "PageActHnd").ToString();
                }
                else
                {
                    PageActHnd = "N";
                }

                string PageActTam = "";
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "PageActTam")) == false)
                {
                    PageActTam = DataBinder.Eval(e.Item.DataItem, "PageActTam").ToString();
                }
                else
                {
                    PageActTam = "N";
                }

               

                if (PageAct == "N")
                {
                    ((LinkButton)e.Item.Cells[20].FindControl("lnkDeleteEng")).Enabled = false;
                    ((LinkButton)e.Item.Cells[20].FindControl("lnkDeleteEng")).ForeColor = System.Drawing.Color.Gray;
                    ((LinkButton)e.Item.Cells[6].FindControl("lnkEngPgCont")).ForeColor = System.Drawing.Color.Gray;
                }
                else
                {
                    ((LinkButton)e.Item.Cells[20].FindControl("lnkDeleteEng")).Attributes.Add("onclick", "javascript: return confirm('Are you sure you want to delete this page?')");
                    ((LinkButton)e.Item.Cells[20].FindControl("lnkDeleteEng")).Enabled = true;

                }

                if (PageActHnd == "N")
                {
                    ((LinkButton)e.Item.Cells[20].FindControl("lnkDeleteHnd")).Enabled = false;
                    ((LinkButton)e.Item.Cells[20].FindControl("lnkDeleteHnd")).ForeColor = System.Drawing.Color.Gray;
                    ((LinkButton)e.Item.Cells[6].FindControl("lnkHndPgCont")).ForeColor = System.Drawing.Color.Gray;
                }
                else
                {
                    ((LinkButton)e.Item.Cells[20].FindControl("lnkDeleteHnd")).Attributes.Add("onclick", "javascript: return confirm('Are you sure you want to delete this page?')");
                    ((LinkButton)e.Item.Cells[20].FindControl("lnkDeleteHnd")).Enabled = true;
                }

                if (PageActTam == "N")
                {
                    ((LinkButton)e.Item.Cells[20].FindControl("lnkDeleteTam")).Enabled = false;
                    ((LinkButton)e.Item.Cells[20].FindControl("lnkDeleteTam")).ForeColor = System.Drawing.Color.Gray;
                    ((LinkButton)e.Item.Cells[6].FindControl("lnkTamilPgCont")).ForeColor = System.Drawing.Color.Gray;
                }
                else
                {
                    ((LinkButton)e.Item.Cells[20].FindControl("lnkDeleteTam")).Attributes.Add("onclick", "javascript: return confirm('Are you sure you want to delete this page?')");
                    ((LinkButton)e.Item.Cells[20].FindControl("lnkDeleteTam")).Enabled = true;
                }
                //checker
                if (Session["usr_privilege"].ToString() == "Checker")
                {
                    ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuEng")).Enabled = true;
                    ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuHnd")).Enabled = true;
                    ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuTam")).Enabled = true;

                    ((LinkButton)e.Item.Cells[22].FindControl("lnkcheckEditEng")).Enabled = true;
                    ((LinkButton)e.Item.Cells[22].FindControl("lnkcheckEditHnd")).Enabled = true;
                    ((LinkButton)e.Item.Cells[22].FindControl("lnkcheckEditTam")).Enabled = true;

                    ((LinkButton)e.Item.Cells[20].FindControl("lnkDeleteEng")).Enabled = false;
                    ((LinkButton)e.Item.Cells[20].FindControl("lnkDeleteHnd")).Enabled = false;
                    ((LinkButton)e.Item.Cells[20].FindControl("lnkDeleteTam")).Enabled = false;

                    ((LinkButton)e.Item.Cells[19].FindControl("lnkEditEng")).Enabled = false;
                    ((LinkButton)e.Item.Cells[19].FindControl("lnkEditHnd")).Enabled = false;
                    ((LinkButton)e.Item.Cells[19].FindControl("lnkEditTam")).Enabled = false;

                    ((LinkButton)e.Item.Cells[8].FindControl("lnkMenuEng")).Enabled = false;
                    ((LinkButton)e.Item.Cells[8].FindControl("lnkMenuHnd")).Enabled = false;
                    ((LinkButton)e.Item.Cells[8].FindControl("lnkMenuTam")).Enabled = false;
                }
                else
                {
                    ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuEng")).Enabled = false;
                    ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuHnd")).Enabled = false;
                    ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuTam")).Enabled = false;

                    ((LinkButton)e.Item.Cells[22].FindControl("lnkcheckEditEng")).Enabled = false;
                    ((LinkButton)e.Item.Cells[22].FindControl("lnkcheckEditHnd")).Enabled = false;
                    ((LinkButton)e.Item.Cells[22].FindControl("lnkcheckEditTam")).Enabled = false;

                    ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDelEng")).Enabled = false;
                    ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDeltHnd")).Enabled = false;
                    ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDelTam")).Enabled = false;

                   
                }

                if (Session["usr_privilege"].ToString() == "Maker")
                {
                    ((LinkButton)e.Item.Cells[22].FindControl("lnkcheckEditEng")).ForeColor = System.Drawing.Color.Gray;
                    ((LinkButton)e.Item.Cells[22].FindControl("lnkcheckEditHnd")).ForeColor = System.Drawing.Color.Gray;
                    ((LinkButton)e.Item.Cells[22].FindControl("lnkcheckEditTam")).ForeColor = System.Drawing.Color.Gray;

                    ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDelEng")).ForeColor = System.Drawing.Color.Gray;
                    ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDeltHnd")).ForeColor = System.Drawing.Color.Gray;
                    ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDelTam")).ForeColor = System.Drawing.Color.Gray;
                }

                if (Session["usr_privilege"].ToString() == "admin" || Session["usr_privilege"].ToString() == "Both")
                {
                     ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuEng")).Enabled = true;
                    ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuHnd")).Enabled = true;
                    ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuTam")).Enabled = true;

                    ((LinkButton)e.Item.Cells[22].FindControl("lnkcheckEditEng")).Enabled = true;
                    ((LinkButton)e.Item.Cells[22].FindControl("lnkcheckEditHnd")).Enabled = true;
                    ((LinkButton)e.Item.Cells[22].FindControl("lnkcheckEditTam")).Enabled = true;

                    ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDelEng")).Enabled = true;
                    ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDeltHnd")).Enabled = true;
                    ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDelTam")).Enabled = true;
                }


                //if (Session["usr_privilege"].ToString() != "Checker")
                //{
                //    btnAdd.Enabled = false;
                //}
                //else
                //{
                //    btnAdd.Enabled = true;
                //}

                string ENGstatus = string.Empty;
                string HNDstatus = string.Empty;
                string Mrtstatus = string.Empty;

                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "ContEng")) == false)
                {
                    ENGstatus = DataBinder.Eval(e.Item.DataItem, "ContEng").ToString();
                }
                else
                {
                    ENGstatus = "";
                }
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "ContHnd")) == false)
                {
                    HNDstatus = DataBinder.Eval(e.Item.DataItem, "ContHnd").ToString();
                }
                else
                {
                    HNDstatus = "";
                }
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "ContTam")) == false)
                {
                    Mrtstatus = DataBinder.Eval(e.Item.DataItem, "ContTam").ToString();
                }
                else
                {
                    Mrtstatus = "";
                }
                if (ENGstatus == "Y")
                {
                    ((LinkButton)e.Item.Cells[22].FindControl("lnkcheckEditEng")).Enabled = false;
                    ((LinkButton)e.Item.Cells[22].FindControl("lnkcheckEditEng")).ForeColor = System.Drawing.Color.Gray;
                }
                else
                {
                    if (Session["usr_privilege"].ToString() == "Checker")
                    {
                        ((LinkButton)e.Item.Cells[22].FindControl("lnkcheckEditEng")).Enabled = true;
                    }
                    else if (Session["usr_privilege"].ToString() == "admin" || Session["usr_privilege"].ToString() == "Both")
                    {
                        ((LinkButton)e.Item.Cells[22].FindControl("lnkcheckEditEng")).Enabled = true;
                    }
                }

                if (HNDstatus == "Y")
                {
                    ((LinkButton)e.Item.Cells[22].FindControl("lnkcheckEditHnd")).Enabled = false;
                    ((LinkButton)e.Item.Cells[22].FindControl("lnkcheckEditHnd")).ForeColor = System.Drawing.Color.Gray;
                }
                else
                {
                    if (Session["usr_privilege"].ToString() == "Checker")
                    {
                        ((LinkButton)e.Item.Cells[22].FindControl("lnkcheckEditHnd")).Enabled = true;
                    }
                    else if (Session["usr_privilege"].ToString() == "admin" || Session["usr_privilege"].ToString() == "Both")
                    {
                        ((LinkButton)e.Item.Cells[22].FindControl("lnkcheckEditHnd")).Enabled = true;
                    }
                }

                if (Mrtstatus == "Y")
                {
                    ((LinkButton)e.Item.Cells[22].FindControl("lnkcheckEditTam")).Enabled = false;
                    ((LinkButton)e.Item.Cells[22].FindControl("lnkcheckEditTam")).ForeColor = System.Drawing.Color.Gray;
                }
                else
                {
                    if (Session["usr_privilege"].ToString() == "Checker")
                    {
                        ((LinkButton)e.Item.Cells[22].FindControl("lnkcheckEditTam")).Enabled = true;
                    }
                    else if (Session["usr_privilege"].ToString() == "admin" || Session["usr_privilege"].ToString() == "Both")
                    {
                        ((LinkButton)e.Item.Cells[22].FindControl("lnkcheckEditTam")).Enabled = true;
                    }
                }


                ////--------------------------------menu status-----------------------------

                string ENGmenustatus = string.Empty;
                string HNDmenustatus = string.Empty;
                string Mrtmenustatus = string.Empty;

                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "MenuEng")) == false)
                {
                    ENGmenustatus = DataBinder.Eval(e.Item.DataItem, "MenuEng").ToString();
                }
                else
                {
                    ENGmenustatus = "";
                }
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "MenuHnd")) == false)
                {
                    HNDmenustatus = DataBinder.Eval(e.Item.DataItem, "MenuHnd").ToString();
                }
                else
                {
                    HNDmenustatus = "";
                }
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "MenuTam")) == false)
                {
                    Mrtmenustatus = DataBinder.Eval(e.Item.DataItem, "MenuTam").ToString();
                }
                else
                {
                    Mrtmenustatus = "";
                }
                if (ENGmenustatus == "Y")
                {
                    ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuEng")).Enabled = false;
                    ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuEng")).ForeColor = System.Drawing.Color.Gray;
                }
                else
                {
                    if (Session["usr_privilege"].ToString() == "Checker")
                    {
                        ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuEng")).Enabled = true;
                    }
                    else if (Session["usr_privilege"].ToString() == "admin" || Session["usr_privilege"].ToString() == "Both")
                    {
                        ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuEng")).Enabled = true;
                    }
                }

                if (HNDmenustatus == "Y")
                {
                    ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuHnd")).Enabled = false;
                    ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuHnd")).ForeColor = System.Drawing.Color.Gray;
                }
                else
                {
                    if (Session["usr_privilege"].ToString() == "Checker")
                    {
                        ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuHnd")).Enabled = true;
                    }
                    else if (Session["usr_privilege"].ToString() == "admin" || Session["usr_privilege"].ToString() == "Both")
                    {
                        ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuHnd")).Enabled = true;
                    }
                }

                if (Mrtmenustatus == "Y")
                {
                    ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuTam")).Enabled = false;
                    ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuTam")).ForeColor = System.Drawing.Color.Gray;
                }
                else
                {
                    if (Session["usr_privilege"].ToString() == "Checker")
                    {
                        ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuTam")).Enabled = true;
                    }
                    else if (Session["usr_privilege"].ToString() == "admin" || Session["usr_privilege"].ToString() == "Both")
                    {
                        ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuTam")).Enabled = true;
                    }
                }

                if (ENGmenustatus == "")
                {
                    ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuEng")).Enabled = false;
                    ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuEng")).ForeColor = System.Drawing.Color.Gray;
                }
                if (HNDmenustatus == "")
                {
                    ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuHnd")).Enabled = false;
                    ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuHnd")).ForeColor = System.Drawing.Color.Gray;
                }
                if (Mrtmenustatus == "")
                {
                    ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuTam")).Enabled = false;
                    ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuTam")).ForeColor = System.Drawing.Color.Gray;
                }
                
                int ENGmenustatusN = 0;
                int HNDmenustatusN = 0;
                int MrtmenustatusN = 0;


                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "MenuCntEng")) == false)
                {
                    ENGmenustatusN = Convert.ToInt16(DataBinder.Eval(e.Item.DataItem, "MenuCntEng").ToString());
                }
                else
                {
                    ENGmenustatusN = 0;
                }
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "MenuCntHnd")) == false)
                {
                    HNDmenustatusN = Convert.ToInt16(DataBinder.Eval(e.Item.DataItem, "MenuCntHnd").ToString());
                }
                else
                {
                    HNDmenustatusN = 0;
                }
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "MenuCntTam")) == false)
                {
                    MrtmenustatusN = Convert.ToInt16(DataBinder.Eval(e.Item.DataItem, "MenuCntTam").ToString());
                }
                else
                {
                    MrtmenustatusN = 0;
                }

                if (ENGmenustatusN > 0)
                {
                    ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuEng")).ForeColor = System.Drawing.Color.Blue;
                
                    if (Session["usr_privilege"].ToString() == "Checker")
                    {
                        ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuEng")).Enabled = true;
                    }
                    else if (Session["usr_privilege"].ToString() == "admin" || Session["usr_privilege"].ToString() == "Both")
                    {
                        ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuEng")).Enabled = true;
                    }
                }

                if (HNDmenustatusN > 0)
                {
                    ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuHnd")).ForeColor = System.Drawing.Color.Blue;

                    if (Session["usr_privilege"].ToString() == "Checker")
                    {
                        ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuHnd")).Enabled = true;
                    }
                    else if (Session["usr_privilege"].ToString() == "admin" || Session["usr_privilege"].ToString() == "Both")
                    {
                        ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuHnd")).Enabled = true;
                    }
                }

                if (MrtmenustatusN > 0)
                {
                    ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuTam")).ForeColor = System.Drawing.Color.Blue;

                    if (Session["usr_privilege"].ToString() == "Checker")
                    {
                        ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuTam")).Enabled = true;
                    }
                    else if (Session["usr_privilege"].ToString() == "admin" || Session["usr_privilege"].ToString() == "Both")
                    {
                        ((LinkButton)e.Item.Cells[21].FindControl("lnkcheckMenuTam")).Enabled = true;
                    }
                }
                                
                string ENGPgtatuschk = string.Empty;
                string ENGPgtatusact = string.Empty;
                string HNDPgstatuschk = string.Empty;
                string HNDPgstatusact = string.Empty;
                string MrtPgstatuschk = string.Empty;
                string MrtPgstatusact = string.Empty;


                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Checked")) == false)
                {
                    ENGPgtatuschk = DataBinder.Eval(e.Item.DataItem, "Checked").ToString();
                }
                else
                {
                    ENGPgtatuschk = "";
                }
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "PageAct")) == false)
                {
                    ENGPgtatusact = DataBinder.Eval(e.Item.DataItem, "PageAct").ToString();
                }
                else
                {
                    ENGPgtatusact = "";
                }
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "CheckedHnd")) == false)
                {
                    HNDPgstatuschk = DataBinder.Eval(e.Item.DataItem, "CheckedHnd").ToString();
                }
                else
                {
                    HNDPgstatuschk = "";
                }
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "PageActHnd")) == false)
                {
                    HNDPgstatusact = DataBinder.Eval(e.Item.DataItem, "PageActHnd").ToString();
                }
                else
                {
                    HNDPgstatusact = "";
                }
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "CheckedTam")) == false)
                {
                    MrtPgstatuschk = DataBinder.Eval(e.Item.DataItem, "CheckedTam").ToString();
                }
                else
                {
                    MrtPgstatuschk = "";
                }
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "PageActTam")) == false)
                {
                    MrtPgstatusact = DataBinder.Eval(e.Item.DataItem, "PageActTam").ToString();
                }
                else
                {
                    MrtPgstatusact = "";
                }

                if (ENGPgtatuschk == "N" && ENGPgtatusact=="N")
                {
                    ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDelEng")).ForeColor = System.Drawing.Color.Blue;
                    if (Session["usr_privilege"].ToString() == "Checker")
                    {
                        ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDelEng")).Enabled = true;
                    }
                    else if (Session["usr_privilege"].ToString() == "admin" || Session["usr_privilege"].ToString() == "Both")
                    {
                        ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDelEng")).Enabled = true;
                    }
                }
                else
                {

                    ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDelEng")).Enabled = false;
                    ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDelEng")).ForeColor = System.Drawing.Color.Gray;
                }

                if (HNDPgstatuschk == "N" && HNDPgstatusact=="N")
                {
                    ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDeltHnd")).ForeColor = System.Drawing.Color.Blue;
                    if (Session["usr_privilege"].ToString() == "Checker")
                    {
                        ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDeltHnd")).Enabled = true;
                    }
                    else if (Session["usr_privilege"].ToString() == "admin" || Session["usr_privilege"].ToString() == "Both")
                    {
                        ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDeltHnd")).Enabled = true;
                    }

                }
                else
                {

                    ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDeltHnd")).Enabled = false;
                    ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDeltHnd")).ForeColor = System.Drawing.Color.Gray;
                }

                if (MrtPgstatusact == "N" && MrtPgstatuschk=="N")
                {

                    ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDelTam")).ForeColor = System.Drawing.Color.Blue;
                    if (Session["usr_privilege"].ToString() == "Checker")
                    {
                        ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDelTam")).Enabled = true;
                    }
                    else if (Session["usr_privilege"].ToString() == "admin" || Session["usr_privilege"].ToString() == "Both")
                    {
                        ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDelTam")).Enabled = true;
                    }
                }
                else
                {
                    ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDelTam")).Enabled = false;
                    ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDelTam")).ForeColor = System.Drawing.Color.Gray;
                }

                if (Session["usr_privilege"].ToString() == "Maker")
                {
                     ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDelEng")).ForeColor = System.Drawing.Color.Gray;
                    ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDeltHnd")).ForeColor = System.Drawing.Color.Gray;
                    ((LinkButton)e.Item.Cells[26].FindControl("lnkcheckDelTam")).ForeColor = System.Drawing.Color.Gray;
                }
            }
        }
    }

    public void fill_checker()
    {
        try
        {
            SqlDataAdapter ad;
            DataSet ds = new DataSet();
            con.Open();
            string PageTitle = "";
            string Pagename = "";
            string LnkName = "";
            string GetMainPrntID = "";
            string LnkAct = "";
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strMainParId1", Session["PgId1"]);
            cmd.Parameters["@Mode"].Value = "getEngPage";
            ad = new SqlDataAdapter();
            ad.SelectCommand = cmd;
            ad.Fill(ds, "tbl");

            if (ds.Tables["tbl"].Rows.Count > 0)
            {
                if (Convert.IsDBNull(ds.Tables["tbl"].Rows[0]["PageTitle"]) == false)
                {
                    PageTitle = ds.Tables["tbl"].Rows[0]["PageTitle"].ToString();
                   
                }
                else
                {
                    PageTitle = "";
                }

                if (Convert.IsDBNull(ds.Tables["tbl"].Rows[0]["PageName"]) == false)
                {
                    Pagename = ds.Tables["tbl"].Rows[0]["PageName"].ToString();

                }
                else
                {
                    Pagename = "";
                }

                if (Convert.IsDBNull(ds.Tables["tbl"].Rows[0]["PageFileName"]) == false)
                {
                    LnkName = ds.Tables["tbl"].Rows[0]["PageFileName"].ToString();

                }
                else
                {
                    LnkName = "";
                }

                if (Convert.IsDBNull(ds.Tables["tbl"].Rows[0]["ParentID"]) == false)
                {
                    GetMainPrntID = ds.Tables["tbl"].Rows[0]["ParentID"].ToString();

                }
                else
                {
                    GetMainPrntID = "";
                }

                if (Convert.IsDBNull(ds.Tables["tbl"].Rows[0]["PageAct"]) == false)
                {
                    LnkAct = ds.Tables["tbl"].Rows[0]["PageAct"].ToString();

                }
                else
                {
                    LnkAct = "";
                }
            }


            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            
            cmd.Parameters.AddWithValue("@strPageId", Session["PgId1"]);
            
            cmd.Parameters["@Mode"].Value = "delchecker";
            cmd.ExecuteNonQuery();

            
                  //  con.Open();
                    cmd = new SqlCommand("Proc_ManageCmsPages", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd.Parameters.AddWithValue("@strPageTitle", PageTitle);
                    cmd.Parameters.AddWithValue("@strPageNm", Pagename);
                    cmd.Parameters.AddWithValue("@strPgFileNm", LnkName);
                    cmd.Parameters.AddWithValue("@strPageId", Session["PgId1"]);
                    cmd.Parameters.AddWithValue("@strParentId1", GetMainPrntID);
                    cmd.Parameters.AddWithValue("@PgAct", LnkAct);
                    cmd.Parameters["@Mode"].Value = "AddPgChecker1";
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("Proc_ManageCmsPages", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd.Parameters.AddWithValue("@strPageId", Session["PgId1"]);
                    cmd.Parameters["@Mode"].Value = "updatemakerchk";
                    cmd.ExecuteNonQuery();
                    //con.Close();

                    string ContID = "";
                    string ContDescription = "";
                    string PageID = "";
                    DateTime dt_upload;
                    string archieve = "";
                    DateTime dt_display;
                    string ContDescription1 = "";
                    string ContDescription2 = "";
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strMainParId1", Session["PgId1"]);
            //cmd.Parameters["@Mode"].Value = "getpageid";

           SqlCommand cmd1 = new SqlCommand("select * from PageContents_Tbl_Maker where PageID='" + Session["PgId1"].ToString() + "'", con);
           SqlDataAdapter ad2 = new SqlDataAdapter();
           DataSet ds3 = new DataSet();
            ad2.SelectCommand = cmd1;
            ad2.Fill(ds3, "tbl_cont");

            if (ds3.Tables["tbl_cont"].Rows.Count > 0)
            {
                if (Convert.IsDBNull(ds3.Tables["tbl_cont"].Rows[0]["ContID"]) == false)
                {
                    ContID = ds3.Tables["tbl_cont"].Rows[0]["ContID"].ToString();

                }
                else
                {
                    ContID = "";
                }
                if (Convert.IsDBNull(ds3.Tables["tbl_cont"].Rows[0]["ContDescription"]) == false)
                {
                    ContDescription = ds3.Tables["tbl_cont"].Rows[0]["ContDescription"].ToString();

                }
                else
                {
                    ContDescription = "";
                }
                if (Convert.IsDBNull(ds3.Tables["tbl_cont"].Rows[0]["PageID"]) == false)
                {
                    PageID = ds3.Tables["tbl_cont"].Rows[0]["PageID"].ToString();

                }
                else
                {
                    PageID = "";
                }
                if (Convert.IsDBNull(ds3.Tables["tbl_cont"].Rows[0]["dt_upload"]) == false)
                {
                    dt_upload =Convert.ToDateTime(ds3.Tables["tbl_cont"].Rows[0]["dt_upload"].ToString());

                }
                else
                {
                    dt_upload = DateTime.Now;
                }
                if (Convert.IsDBNull(ds3.Tables["tbl_cont"].Rows[0]["archieve"]) == false)
                {
                    archieve = ds3.Tables["tbl_cont"].Rows[0]["archieve"].ToString();

                }
                else
                {
                    archieve = "";
                }
                if (Convert.IsDBNull(ds3.Tables["tbl_cont"].Rows[0]["ContDescription1"]) == false)
                {
                    ContDescription1 = ds3.Tables["tbl_cont"].Rows[0]["ContDescription1"].ToString();

                }
                else
                {
                    ContDescription1 = "";
                }
                if (Convert.IsDBNull(ds3.Tables["tbl_cont"].Rows[0]["ContDescription2"]) == false)
                {
                    ContDescription2 = ds3.Tables["tbl_cont"].Rows[0]["ContDescription2"].ToString();

                }
                else
                {
                    ContDescription2 = "";
                }
                if (Convert.IsDBNull(ds3.Tables["tbl_cont"].Rows[0]["dt_display"]) == false)
                {
                    dt_display =Convert.ToDateTime(ds3.Tables["tbl_cont"].Rows[0]["dt_display"].ToString());

                }
                else
                {
                    dt_display = DateTime.Now;
                }

                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                cmd.Parameters.AddWithValue("@strContID", ContID);
                cmd.Parameters["@Mode"].Value = "deleteEngchecker";
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                cmd.Parameters.AddWithValue("@strContID", ContID);
                cmd.Parameters.AddWithValue("@strContDesc", ContDescription);
                cmd.Parameters.AddWithValue("@strPageId", PageID);
                cmd.Parameters.AddWithValue("@strDtUpload", dt_upload);
                cmd.Parameters.AddWithValue("@strDtDisplay", dt_display);
                cmd.Parameters.AddWithValue("@strContArch", LnkAct);
                cmd.Parameters.AddWithValue("@strContDesc1", ContDescription1);
                cmd.Parameters.AddWithValue("@strContDesc2", ContDescription2);              
                cmd.Parameters["@Mode"].Value = "addcontchecker";
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strContID", ContID);
                cmd.Parameters["@Mode"].Value = "updatecontEng";
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
        //mail_applchecked();
    }

    public void fill_checkerHindi()
    {
        try
        {
            SqlDataAdapter ad;
            DataSet ds = new DataSet();
            con.Open();
            string PageTitle = "";
            string Pagename = "";
            string LnkName = "";
            string GetMainPrntID = "";
            string LnkAct = "";
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strMainParId1", Session["PgId1"]);
            cmd.Parameters["@Mode"].Value = "getHindiPage";
            ad = new SqlDataAdapter();
            ad.SelectCommand = cmd;
            ad.Fill(ds, "tbl");

            if (ds.Tables["tbl"].Rows.Count > 0)
            {
                if (Convert.IsDBNull(ds.Tables["tbl"].Rows[0]["PageTitle"]) == false)
                {
                    PageTitle = ds.Tables["tbl"].Rows[0]["PageTitle"].ToString();

                }
                else
                {
                    PageTitle = "";
                }

                if (Convert.IsDBNull(ds.Tables["tbl"].Rows[0]["PageName"]) == false)
                {
                    Pagename = ds.Tables["tbl"].Rows[0]["PageName"].ToString();

                }
                else
                {
                    Pagename = "";
                }

                if (Convert.IsDBNull(ds.Tables["tbl"].Rows[0]["PageFileName"]) == false)
                {
                    LnkName = ds.Tables["tbl"].Rows[0]["PageFileName"].ToString();

                }
                else
                {
                    LnkName = "";
                }

                if (Convert.IsDBNull(ds.Tables["tbl"].Rows[0]["ParentID"]) == false)
                {
                    GetMainPrntID = ds.Tables["tbl"].Rows[0]["ParentID"].ToString();

                }
                else
                {
                    GetMainPrntID = "";
                }

                if (Convert.IsDBNull(ds.Tables["tbl"].Rows[0]["PageAct"]) == false)
                {
                    LnkAct = ds.Tables["tbl"].Rows[0]["PageAct"].ToString();

                }
                else
                {
                    LnkAct = "";
                }
            }


            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));

            cmd.Parameters.AddWithValue("@strPageId", Session["PgId1"]);

            cmd.Parameters["@Mode"].Value = "delcheckerHindi";
            cmd.ExecuteNonQuery();



            //  con.Open();
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strPageTitle", PageTitle);
            cmd.Parameters.AddWithValue("@strPageNm", Pagename);
            cmd.Parameters.AddWithValue("@strPgFileNm", LnkName);
            cmd.Parameters.AddWithValue("@strPageId", Session["PgId1"]);
            cmd.Parameters.AddWithValue("@strParentId1", GetMainPrntID);
            cmd.Parameters.AddWithValue("@PgAct", LnkAct);
            cmd.Parameters["@Mode"].Value = "AddPgCheckerHindi";
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strPageId", Session["PgId1"]);
            cmd.Parameters["@Mode"].Value = "updatemakerHndchk";
            cmd.ExecuteNonQuery();
            //con.Close();

            string ContID = "";
            string ContDescription = "";
            string PageID = "";
            DateTime dt_upload;
            string archieve = "";
            DateTime dt_display;
            string ContDescription1 = "";
            string ContDescription2 = "";
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strMainParId1", Session["PgId1"]);
            //cmd.Parameters["@Mode"].Value = "getpageid";

            SqlCommand cmd1 = new SqlCommand("select * from PageContentsHindi_Tbl_Maker where PageID='" + Session["PgId1"].ToString() + "'", con);
            SqlDataAdapter ad2 = new SqlDataAdapter();
            DataSet ds3 = new DataSet();
            ad2.SelectCommand = cmd1;
            ad2.Fill(ds3, "tbl_cont");

            if (ds3.Tables["tbl_cont"].Rows.Count > 0)
            {
                if (Convert.IsDBNull(ds3.Tables["tbl_cont"].Rows[0]["ContID"]) == false)
                {
                    ContID = ds3.Tables["tbl_cont"].Rows[0]["ContID"].ToString();

                }
                else
                {
                    ContID = "";
                }
                if (Convert.IsDBNull(ds3.Tables["tbl_cont"].Rows[0]["ContDescription"]) == false)
                {
                    ContDescription = ds3.Tables["tbl_cont"].Rows[0]["ContDescription"].ToString();

                }
                else
                {
                    ContDescription = "";
                }
                if (Convert.IsDBNull(ds3.Tables["tbl_cont"].Rows[0]["PageID"]) == false)
                {
                    PageID = ds3.Tables["tbl_cont"].Rows[0]["PageID"].ToString();

                }
                else
                {
                    PageID = "";
                }
                if (Convert.IsDBNull(ds3.Tables["tbl_cont"].Rows[0]["dt_upload"]) == false)
                {
                    dt_upload = Convert.ToDateTime(ds3.Tables["tbl_cont"].Rows[0]["dt_upload"].ToString());

                }
                else
                {
                    dt_upload = DateTime.Now;
                }
                if (Convert.IsDBNull(ds3.Tables["tbl_cont"].Rows[0]["archieve"]) == false)
                {
                    archieve = ds3.Tables["tbl_cont"].Rows[0]["archieve"].ToString();

                }
                else
                {
                    archieve = "";
                }
                if (Convert.IsDBNull(ds3.Tables["tbl_cont"].Rows[0]["ContDescription1"]) == false)
                {
                    ContDescription1 = ds3.Tables["tbl_cont"].Rows[0]["ContDescription1"].ToString();

                }
                else
                {
                    ContDescription1 = "";
                }
                if (Convert.IsDBNull(ds3.Tables["tbl_cont"].Rows[0]["ContDescription2"]) == false)
                {
                    ContDescription2 = ds3.Tables["tbl_cont"].Rows[0]["ContDescription2"].ToString();

                }
                else
                {
                    ContDescription2 = "";
                }
                if (Convert.IsDBNull(ds3.Tables["tbl_cont"].Rows[0]["dt_display"]) == false)
                {
                    dt_display = Convert.ToDateTime(ds3.Tables["tbl_cont"].Rows[0]["dt_display"].ToString());

                }
                else
                {
                    dt_display = DateTime.Now;
                }

                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                cmd.Parameters.AddWithValue("@strContID", ContID);
                cmd.Parameters["@Mode"].Value = "deleteHndchecker";
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                cmd.Parameters.AddWithValue("@strContID", ContID);
                cmd.Parameters.AddWithValue("@strContDesc", ContDescription);
                cmd.Parameters.AddWithValue("@strPageId", PageID);
                cmd.Parameters.AddWithValue("@strDtUpload", dt_upload);
                cmd.Parameters.AddWithValue("@strDtDisplay", dt_display);
                cmd.Parameters.AddWithValue("@strContArch", LnkAct);
                cmd.Parameters.AddWithValue("@strContDesc1", ContDescription1);
                cmd.Parameters.AddWithValue("@strContDesc2", ContDescription2);
                cmd.Parameters["@Mode"].Value = "addcontHndchecker";
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strContID", ContID);
                cmd.Parameters["@Mode"].Value = "updatecontHnd";
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

    public void fill_checkertamil()
    {
        try
        {
            SqlDataAdapter ad;
            DataSet ds = new DataSet();
            con.Open();
            string PageTitle = "";
            string Pagename = "";
            string LnkName = "";
            string GetMainPrntID = "";
            string LnkAct = "";
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strMainParId1", Session["PgId1"]);
            cmd.Parameters["@Mode"].Value = "gettamilPage";
            ad = new SqlDataAdapter();
            ad.SelectCommand = cmd;
            ad.Fill(ds, "tbl");

            if (ds.Tables["tbl"].Rows.Count > 0)
            {
                if (Convert.IsDBNull(ds.Tables["tbl"].Rows[0]["PageTitle"]) == false)
                {
                    PageTitle = ds.Tables["tbl"].Rows[0]["PageTitle"].ToString();

                }
                else
                {
                    PageTitle = "";
                }

                if (Convert.IsDBNull(ds.Tables["tbl"].Rows[0]["PageName"]) == false)
                {
                    Pagename = ds.Tables["tbl"].Rows[0]["PageName"].ToString();

                }
                else
                {
                    Pagename = "";
                }

                if (Convert.IsDBNull(ds.Tables["tbl"].Rows[0]["PageFileName"]) == false)
                {
                    LnkName = ds.Tables["tbl"].Rows[0]["PageFileName"].ToString();

                }
                else
                {
                    LnkName = "";
                }

                if (Convert.IsDBNull(ds.Tables["tbl"].Rows[0]["ParentID"]) == false)
                {
                    GetMainPrntID = ds.Tables["tbl"].Rows[0]["ParentID"].ToString();

                }
                else
                {
                    GetMainPrntID = "";
                }

                if (Convert.IsDBNull(ds.Tables["tbl"].Rows[0]["PageAct"]) == false)
                {
                    LnkAct = ds.Tables["tbl"].Rows[0]["PageAct"].ToString();

                }
                else
                {
                    LnkAct = "";
                }
            }

            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strPageId", Session["PgId1"]);
            cmd.Parameters["@Mode"].Value = "delcheckerTamil";
            cmd.ExecuteNonQuery();




            //  con.Open();
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strPageTitle", PageTitle);
            cmd.Parameters.AddWithValue("@strPageNm", Pagename);
            cmd.Parameters.AddWithValue("@strPgFileNm", LnkName);
            cmd.Parameters.AddWithValue("@strPageId", Session["PgId1"]);
            cmd.Parameters.AddWithValue("@strParentId1", GetMainPrntID);
            cmd.Parameters.AddWithValue("@PgAct", LnkAct);
            cmd.Parameters["@Mode"].Value = "AddPgCheckerTamil";
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strPageId", Session["PgId1"]);
            cmd.Parameters["@Mode"].Value = "updatemakerTamilchk";
            cmd.ExecuteNonQuery();
            //con.Close();

            string ContID = "";
            string ContDescription = "";
            string PageID = "";
            DateTime dt_upload;
            string archieve = "";
            DateTime dt_display;
            string ContDescription1 = "";
            string ContDescription2 = "";
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strMainParId1", Session["PgId1"]);
            //cmd.Parameters["@Mode"].Value = "getpageid";

            SqlCommand cmd1 = new SqlCommand("select * from PageContentsTamil_Tbl_Maker where PageID='" + Session["PgId1"].ToString() + "'", con);
            SqlDataAdapter ad2 = new SqlDataAdapter();
            DataSet ds3 = new DataSet();
            ad2.SelectCommand = cmd1;
            ad2.Fill(ds3, "tbl_cont");

            if (ds3.Tables["tbl_cont"].Rows.Count > 0)
            {
                if (Convert.IsDBNull(ds3.Tables["tbl_cont"].Rows[0]["ContID"]) == false)
                {
                    ContID = ds3.Tables["tbl_cont"].Rows[0]["ContID"].ToString();

                }
                else
                {
                    ContID = "";
                }
                if (Convert.IsDBNull(ds3.Tables["tbl_cont"].Rows[0]["ContDescription"]) == false)
                {
                    ContDescription = ds3.Tables["tbl_cont"].Rows[0]["ContDescription"].ToString();

                }
                else
                {
                    ContDescription = "";
                }
                if (Convert.IsDBNull(ds3.Tables["tbl_cont"].Rows[0]["PageID"]) == false)
                {
                    PageID = ds3.Tables["tbl_cont"].Rows[0]["PageID"].ToString();

                }
                else
                {
                    PageID = "";
                }
                if (Convert.IsDBNull(ds3.Tables["tbl_cont"].Rows[0]["dt_upload"]) == false)
                {
                    dt_upload = Convert.ToDateTime(ds3.Tables["tbl_cont"].Rows[0]["dt_upload"].ToString());

                }
                else
                {
                    dt_upload = DateTime.Now;
                }
                if (Convert.IsDBNull(ds3.Tables["tbl_cont"].Rows[0]["archieve"]) == false)
                {
                    archieve = ds3.Tables["tbl_cont"].Rows[0]["archieve"].ToString();

                }
                else
                {
                    archieve = "";
                }
                if (Convert.IsDBNull(ds3.Tables["tbl_cont"].Rows[0]["ContDescription1"]) == false)
                {
                    ContDescription1 = ds3.Tables["tbl_cont"].Rows[0]["ContDescription1"].ToString();

                }
                else
                {
                    ContDescription1 = "";
                }
                if (Convert.IsDBNull(ds3.Tables["tbl_cont"].Rows[0]["ContDescription2"]) == false)
                {
                    ContDescription2 = ds3.Tables["tbl_cont"].Rows[0]["ContDescription2"].ToString();

                }
                else
                {
                    ContDescription2 = "";
                }
                if (Convert.IsDBNull(ds3.Tables["tbl_cont"].Rows[0]["dt_display"]) == false)
                {
                    dt_display = Convert.ToDateTime(ds3.Tables["tbl_cont"].Rows[0]["dt_display"].ToString());

                }
                else
                {
                    dt_display = DateTime.Now;
                }

                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                cmd.Parameters.AddWithValue("@strContID", ContID);
                cmd.Parameters["@Mode"].Value = "deleteTamchecker";
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                cmd.Parameters.AddWithValue("@strContID", ContID);
                cmd.Parameters.AddWithValue("@strContDesc", ContDescription);
                cmd.Parameters.AddWithValue("@strPageId", PageID);
                cmd.Parameters.AddWithValue("@strDtUpload", dt_upload);
                cmd.Parameters.AddWithValue("@strDtDisplay", dt_display);
                cmd.Parameters.AddWithValue("@strContArch", LnkAct);
                cmd.Parameters.AddWithValue("@strContDesc1", ContDescription1);
                cmd.Parameters.AddWithValue("@strContDesc2", ContDescription2);
                cmd.Parameters["@Mode"].Value = "addcontTamchecker";
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strContID", ContID);
                cmd.Parameters["@Mode"].Value = "updatecontTam";
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
    public void fill_menucheck()
    {
        try
        {
            string LnkID = "";
            string LnkName = "";
            string LnkHLink = "";
            string PageID = "";
            string Parentid = "";
            string LnkIndex = "";
            string parentlinkid = "";
            con.Open();
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strMainParId1", Session["PgId1"]);
            cmd.Parameters["@Mode"].Value = "getmenuEnglish";
            SqlDataAdapter ad = new SqlDataAdapter();
            ad = new SqlDataAdapter();
            ad.SelectCommand = cmd;
            ad.Fill(ds, "tbl_menu");
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


                cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strPageId", PageID);
                cmd.Parameters["@Mode"].Value = "deletemenu";
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
                cmd.Parameters["@Mode"].Value = "AddLnkEnglish";
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strPageId", PageID);
                cmd.Parameters["@Mode"].Value = "updatemenuchk";
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
    }
    protected void dg_Pg_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (!(e.CommandName == "Page"))
        {
            Session["SrchTxt"] = txtSrchPg.Text;
            Session["PgType"] = cmbPgTypeSrch.SelectedValue;
            Session["MainType"] = cmbMainParentSrch.SelectedValue;

            clear_AddEditTbl();
            Session["MenuPg"] = "";
            Session["PgLanguage"] = "";
            Session["PgId1"] = "";

            string pg_title = "";
            string Hpg_title = "";

            string pg_nm = "";
            string Hpg_nm = "";

            string pg_file = "";
            string Hpg_file = "";

            string par_id = "";
            string pg_act = "";
            string Hpg_act = "";

            string Marnam = "";
            //string Mar_act = "";
            string TitleTam = "";
            string pg_id_1 = e.Item.Cells[0].Text;
            pg_title = e.Item.Cells[11].Text;
            Hpg_title = e.Item.Cells[12].Text;
            pg_nm = e.Item.Cells[13].Text;
            Hpg_nm = e.Item.Cells[14].Text;
            pg_file = e.Item.Cells[15].Text;
            Hpg_file = e.Item.Cells[16].Text;
            par_id = e.Item.Cells[9].Text;
            pg_act = e.Item.Cells[17].Text;
            Hpg_act = e.Item.Cells[18].Text;

            Marnam = e.Item.Cells[24].Text;
            TitleTam = e.Item.Cells[25].Text;
          

            string Usrtype = Session["usr_type"].ToString();
            string UsrNm = Session["log_name"].ToString();
            string GetPgID = pg_id_1;
            //bool i = ui.chk_thisPgAuth(cms);
            bool i;
            if (Usrtype == "admin")
            {
                i = true;
            }
            else
            {
                int cnt1 = 0;
                con.Open();
                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strLogNm", UsrNm);
                cmd.Parameters.AddWithValue("@strPageId", GetPgID);
                cmd.Parameters["@Mode"].Value = "cntUsrPgByPgId";
                cnt1 = (int)cmd.ExecuteScalar();
                con.Close();

                if (cnt1 > 0)
                {
                    i = true;
                }
                else
                {
                  //  after remove Create user master
                   // i = false;

                    i = true;
                }
            }

            if (i == true)
            {
                if (e.CommandName == "PgEngCont")
                {
                    Session["PgId1"] = pg_id_1;
                    Session["pgid22"] = pg_id_1;
                    Session["PgLanguage"] = "English";
                    Response.Write("<script type='text/javascript'>detailedresults=window.open('PreviewContents.aspx','frmMensajeBox','scrollbars=yes, height=650px,width=644px,top=25,left=250');</script>");
                }
                else if (e.CommandName == "PgHndCont")
                {
                    Session["PgId1"] = pg_id_1;
                    Session["PgLanguage"] = "Hindi";
                    Response.Write("<script type='text/javascript'>detailedresults=window.open('PreviewContents.aspx','frmMensajeBox','height=550px,width=644px,top=50,left=50');</script>");
                }
                else if (e.CommandName == "PgTamilCont")
                {
                    Session["PgId1"] = pg_id_1;
                    Session["PgLanguage"] = "Tamil";
                    Session["utype"] = Usrtype;
                    Response.Write("<script type='text/javascript'>detailedresults=window.open('PreviewContents.aspx','frmMensajeBox','height=550px,width=644px,top=50,left=50');</script>");
                }
                else if (e.CommandName == "PgEditEng")
                {
                    Session["Add Page"] = "N";
                    Session["PgId1"] = pg_id_1;
                    Session["PgLanguage"] = "Eng";
                    Session["utype"] = Usrtype;
                    Response.Redirect("Manage_InnerPageEdit.aspx");
                }
                else if (e.CommandName == "PgEditHnd")
                {
                    Session["Add Page"] = "N";
                    Session["PgId1"] = pg_id_1;
                    Session["utype"] = Usrtype;
                    Session["PgLanguage"] = "Hindi";
                    Response.Redirect("Manage_InnerPageEdit.aspx");
                }
                else if (e.CommandName == "PgEditTam")
                {
                    Session["Add Page"] = "N";
                    Session["PgId1"] = pg_id_1;
                    Session["PgLanguage"] = "Tamil";
                    Session["utype"] = Usrtype;
                    Response.Redirect("Manage_InnerPageEdit.aspx");
                }
                //=---- Check Edit
                else if (e.CommandName == "PgEditcheckEng")
                {
                    Session["PgId1"] = pg_id_1;
                    fill_checker(); 
                    if (!string.IsNullOrEmpty(pg_file))
                    {
                        if (string.IsNullOrEmpty(fields1))
                        {
                            fields1 = pg_file;
                        }
                        else
                        {
                            fields1 = fields1 + ", Page Name : " + pg_file;
                        }
                    }
                    msg = "checkedEdit";
                    Audit_Trail();
                        
                }
                else if (e.CommandName == "PgEditcheckHnd")
                {
                    Session["Add Page"] = "N";
                    Session["PgId1"] = pg_id_1;
                    fill_checkerHindi();
                    if (!string.IsNullOrEmpty(pg_file))
                    {
                        if (string.IsNullOrEmpty(fields1))
                        {
                            fields1 = pg_file;
                        }
                        else
                        {
                            fields1 = fields1 + ", Page Name : " + pg_file;
                        }
                    }
                    msg = "checkedEdit";
                    Audit_Trail();
                   
                }
                else if (e.CommandName == "PgEditcheckTam")
                {
                    Session["Add Page"] = "N";
                    Session["PgId1"] = pg_id_1;

                    fill_checkertamil();
                    if (!string.IsNullOrEmpty(pg_file))
                    {
                        if (string.IsNullOrEmpty(fields1))
                        {
                            fields1 = pg_file;
                        }
                        else
                        {
                            fields1 = fields1 + ", Page Name : " + pg_file;
                        }
                    }
                    msg = "checkedEdit";
                    Audit_Trail();
                }
                else if (e.CommandName == "PgMenucheckEng")
                {
                    Session["PgId1"] = pg_id_1;
                    Session["PgLanguage"] = "Eng";
                    Session["MenuPg"] = "InnerPgMain";
                    Session["utype"] = Usrtype;
                    Response.Redirect("Manage_PgMenuEnglish.aspx");
                    if (!string.IsNullOrEmpty(pg_file))
                    {
                        if (string.IsNullOrEmpty(fields1))
                        {
                            fields1 = pg_file;
                        }
                        else
                        {
                            fields1 = fields1 + ", Page Name : " + pg_file;
                        }
                    }
                    msg = "checkedMenus";
                    Audit_Trail();
                }
                else if (e.CommandName == "PgMenucheckHnd")
                {
                    Session["PgId1"] = pg_id_1;
                    Session["PgLanguage"] = "Hindi";
                    Session["MenuPg"] = "InnerPgMain";
                    Session["utype"] = Usrtype;
                    Response.Redirect("Manage_PgMenuHindi.aspx");
                    if (!string.IsNullOrEmpty(pg_file))
                    {
                        if (string.IsNullOrEmpty(fields1))
                        {
                            fields1 = pg_file;
                        }
                        else
                        {
                            fields1 = fields1 + ", Page Name : " + pg_file;
                        }
                    }
                    msg = "checkedMenus";
                    Audit_Trail();
                }
                else if (e.CommandName == "PgMenucheckTam")
                {
                    Session["PgId1"] = pg_id_1;
                    Session["PgLanguage"] = "Tamil";
                    Session["MenuPg"] = "InnerPgMain";
                    Session["utype"] = Usrtype;
                    Response.Redirect("Manage_PgMenuTamil.aspx");
                    if (!string.IsNullOrEmpty(pg_file))
                    {
                        if (string.IsNullOrEmpty(fields1))
                        {
                            fields1 = pg_file;
                        }
                        else
                        {
                            fields1 = fields1 + ", Page Name : " + pg_file;
                        }
                    }
                    msg = "checkedMenus";
                    Audit_Trail();
                   
                }
                else if (e.CommandName == "PgDelcheckEng")
                {
                    con.Open();
                    cmd = new SqlCommand("Proc_ManageCmsPages", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                    cmd.Parameters.AddWithValue("@strPageId", GetPgID);
                    cmd.Parameters["@Mode"].Value = "DelPgchkrById";
                    cmd.ExecuteScalar();
                    cmd.Parameters["@Mode"].Value = "DelPgchkrByUpdE";
                    cmd.ExecuteScalar();
                    con.Close();
                    if (!string.IsNullOrEmpty(pg_file))
                    {
                        if (string.IsNullOrEmpty(fields1))
                        {
                            fields1 = pg_file;
                        }
                        else
                        {
                            fields1 = fields1 + ", Page Name : " + pg_file;
                        }
                    }
                    msg = "checkedDel";
                    Audit_Trail();
                    bind_grid();
                }
                else if (e.CommandName == "PgDelcheckHnd")
                {
                    con.Open();
                    cmd = new SqlCommand("Proc_ManageCmsPages", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                    cmd.Parameters.AddWithValue("@strPageId", GetPgID);
                    cmd.Parameters["@Mode"].Value = "DelPgchkrHnd";
                    cmd.ExecuteScalar();
                    cmd.Parameters["@Mode"].Value = "DelPgchkrByUpdH";
                    cmd.ExecuteScalar();
                    con.Close();
                    if (!string.IsNullOrEmpty(pg_file))
                    {
                        if (string.IsNullOrEmpty(fields1))
                        {
                            fields1 = pg_file;
                        }
                        else
                        {
                            fields1 = fields1 + ", Page Name : " + pg_file;
                        }
                    }
                    msg = "checkedDel";
                    Audit_Trail();
                    bind_grid();
                }
                else if (e.CommandName == "PgDelcheckTam")
                {
                    con.Open();
                    cmd = new SqlCommand("Proc_ManageCmsPages", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                    cmd.Parameters.AddWithValue("@strPageId", GetPgID);
                    cmd.Parameters["@Mode"].Value = "DelPgchkrMrt";
                    cmd.ExecuteScalar();
                    cmd.Parameters["@Mode"].Value = "DelPgchkrByUpdM";
                    cmd.ExecuteScalar();
                    con.Close();
                    if (!string.IsNullOrEmpty(pg_file))
                    {
                        if (string.IsNullOrEmpty(fields1))
                        {
                            fields1 = pg_file;
                        }
                        else
                        {
                            fields1 = fields1 + ", Page Name : " + pg_file;
                        }
                    }
                    msg = "checkedDel";
                    Audit_Trail();
                    bind_grid();
                }
                else if (e.CommandName == "PgDeleteEng")
                {
                    string Pagename = pg_file;
                    string PagenameHindi = Hpg_file;

                    if (!(pg_file == "HomePage.aspx"))
                    {
                        //ui.DeleteEngPage(cms);
                        con.Open();
                        cmd = new SqlCommand("Proc_ManageCmsPages", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                        cmd.Parameters.AddWithValue("@strPageId", GetPgID);
                        cmd.Parameters["@Mode"].Value = "DelPgMkrById";
                        cmd.ExecuteNonQuery();
                        //cmd.Parameters["@Mode"].Value = "updatedelpageEng";
                        //cmd.ExecuteNonQuery();
                        con.Close();
                        lblmsg.Text = "English page successfully deleted";

                        //string fields1 = "";

                        if (!string.IsNullOrEmpty(pg_file))
                        {
                            if (string.IsNullOrEmpty(fields1))
                            {
                                fields1 = pg_file;
                            }
                            else
                            {
                                fields1 = fields1 + ", Page Name : " + pg_file;
                            }
                        }
                        msg = "Deleted";
                        Audit_Trail();
                        
                        strAlpha = Request.QueryString["alpha"];
                        bind_grid();
                    }
                }
                else if (e.CommandName == "PgDeleteHnd")
                {
                    if (!(pg_file == "home.aspx"))
                    {
                        string Pagename = pg_file;
                        string PagenameHindi = Hpg_file;
                        //ui.DeleteHndPage(cms);
                        con.Open();
                        cmd = new SqlCommand("Proc_ManageCmsPages", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                        cmd.Parameters.AddWithValue("@strPageId", GetPgID);
                        cmd.Parameters["@Mode"].Value = "DelHindiPgMkr";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        lblmsg.Text = "Hindi page successfully deleted";

                        //string fields1 = "";

                        if (!string.IsNullOrEmpty(pg_file))
                        {
                            if (string.IsNullOrEmpty(fields1))
                            {
                                fields1 = Hpg_file;
                            }
                            else
                            {
                                fields1 = fields1 + ", Page Name : " + Hpg_file;
                            }
                        }
                        msg = "Deleted";
                        Audit_Trail();
                        strAlpha = Request.QueryString["alpha"];
                        bind_grid();
                    }
                }
                else if (e.CommandName == "PgDeleteTam")
                {
                    if (!(pg_file == "home.aspx"))
                    {
                        //ui.DeleteMarPage(cms);
                        con.Open();
                        cmd = new SqlCommand("Proc_ManageCmsPages", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                        cmd.Parameters.AddWithValue("@strPageId", GetPgID);
                        cmd.Parameters["@Mode"].Value = "DelMarPgMkr";
                        cmd.ExecuteNonQuery();
                        con.Close();

                        lblmsg.Text = "Tamil page successfully deleted";

                        string fields1 = "";

                        if (!string.IsNullOrEmpty(pg_file))
                        {
                            if (string.IsNullOrEmpty(fields1))
                            {
                                fields1 = "Page Name : " + Hpg_file + " is deleted";
                            }
                            else
                            {
                                fields1 = fields1 + ", Page Name : " + Hpg_file + " is deleted";
                            }
                        }
                        msg = "Deleted";
                        Audit_Trail();
                        strAlpha = Request.QueryString["alpha"];
                        bind_grid();
                    }
                }

                else if (e.CommandName == "PgMenuEng")
                {
                    Session["PgId1"] = pg_id_1;
                    Session["PgLanguage"] = "Eng";
                    Session["utype"] = Usrtype;
                    Session["MenuPg"] = "InnerPgMain";
                    Response.Redirect("Manage_PgMenuEnglish.aspx");
                }
                else if (e.CommandName == "PgMenuHnd")
                {
                    Session["PgId1"] = pg_id_1;
                    Session["PgLanguage"] = "Hindi";
                    Session["utype"] = Usrtype;
                    Session["MenuPg"] = "InnerPgMain";
                    Response.Redirect("Manage_PgMenuHindi.aspx");
                }
                else if (e.CommandName == "PgMenuTamil")
                {
                    Session["PgId1"] = pg_id_1;
                    Session["PgLanguage"] = "Tamil";
                    Session["MenuPg"] = "InnerPgMain";
                    Session["utype"] = Usrtype;
                    Response.Redirect("Manage_PgMenuTamil.aspx");
                }
                else if (e.CommandName == "PgmetadataEng")
                {
                    Session["PgId1"] = pg_id_1;
                    Session["MenuPg"] = "InnerPgMain";
                    Session["utype"] = Usrtype;
                    Response.Redirect("ManageMetaData.aspx");
                }
            }
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        clear_AddEditTbl();
        lblAddMsg.Text = "";
        txtSrchPg.Text = "";
        Session["PgTypename"] = "";
        cmbMainParentSrch.SelectedIndex = 0;
        cmbPgTypeSrch.Items.Clear();
        cmbPgTypeSrch.Items.Insert(0, "Select Page Type");
        cmbPgTypeSrch.SelectedIndex = 0;
        txtPageSize.Text = "50";
        txtPageIndex.Text = "1";
        btn_go();
        lblMainMsg.Text = "";
        strAlpha = Request.QueryString["alpha"];
        strAlpha = "";
        bind_grid();
        Response.Redirect("Manage_InnerPage.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Session["MenuPg"] = "";
        Session["PgId1"] = "";
        Session["PgTypename"] = "";
        clear_AddEditTbl();

        txtSrchPg.Text = "";
        cmbPgTypeSrch.SelectedIndex = 0;
        cmbPgTypeSrch.SelectedIndex = 0;

        lblMainMsg.Text = "";
        strAlpha = "";
      

        bind_grid();
    }

    protected void dg_Pg_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(txtPageSize.Text))
        {
            if (!string.IsNullOrEmpty(txtPageSize.Text) & Information.IsNumeric(txtPageSize.Text) == true)
            {
                dg_Pg.PageSize = Convert.ToInt32(txtPageSize.Text);
            }
        }

        int pg_index = 0;
        if (!string.IsNullOrEmpty(txtPageIndex.Text))
        {
            if (!string.IsNullOrEmpty(txtPageIndex.Text) & Information.IsNumeric(txtPageIndex.Text) == true)
            {
                pg_index = Convert.ToInt32(txtPageIndex.Text) - 1;
            }
        }

        dg_Pg.CurrentPageIndex = e.NewPageIndex;
        strAlpha = Request.QueryString["alpha"];
        bind_grid();

        string x1 = dg_Pg.CurrentPageIndex.ToString();
        int currPage = Convert.ToInt32(x1) + 1;
        string x2 = dg_Pg.PageCount.ToString();

        txtPageIndex.Text = currPage.ToString();
        lblPageIndex.Text = "Page" + " " + currPage + " " + "of" + " " + x2 + " " + ". Skip to page";
    }
    protected void btnPageSize_Click(object sender, EventArgs e)
    {
        if (txtPageSize.Text != "" && !Regex.IsMatch(txtPageSize.Text, "^[0-9]+$"))
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Enter only digits";
            txtPageSize.Text = "";
            txtPageSize.Focus();
        }
        else if (txtPageSize.Text != "" && !(Convert.ToInt32(txtPageSize.Text) < 0) & Convert.ToInt32(txtPageSize.Text) > 0)
        {
            lblmsg.Visible = false;
            dg_page_indexSize();
        }
        else
        {
            txtPageSize.Text = "";
        }
    }
    public void dg_page_indexSize()
    {
        if (!string.IsNullOrEmpty(txtPageSize.Text))
        {
            if (!string.IsNullOrEmpty(txtPageSize.Text) & Information.IsNumeric(txtPageSize.Text) == true)
            {
                dg_Pg.PageSize = Convert.ToInt32(txtPageSize.Text);
            }
        }

        int pg_index = 0;
        if (!string.IsNullOrEmpty(txtPageIndex.Text))
        {
            if (!string.IsNullOrEmpty(txtPageIndex.Text) & Information.IsNumeric(txtPageIndex.Text) == true)
            {
                if (Convert.ToInt32(txtPageIndex.Text) != 0)
                {
                    pg_index = Convert.ToInt32(txtPageIndex.Text) - 1;
                    dg_Pg.CurrentPageIndex = pg_index;
                }
            }
        }

        bind_grid();


        string x1 = dg_Pg.CurrentPageIndex.ToString();
        int currPage = Convert.ToInt32(x1) + 1;
        string x2 = dg_Pg.PageCount.ToString();

        txtPageIndex.Text = currPage.ToString();
        lblPageIndex.Text = "Page" + " " + currPage + " " + "of" + " " + x2 + " " + ". Skip to page";

        if (string.IsNullOrEmpty(txtPageSize.Text))
        {
            int n = dg_Pg.Items.Count;
            txtPageSize.Text = n.ToString();
        }

    }
    protected void btnPageIndex_Click(object sender, EventArgs e)
    {
        if (txtPageIndex.Text != "" && !Regex.IsMatch(txtPageIndex.Text, "^[0-9]+$"))
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Enter only digits";
            txtPageIndex.Text = "";
            txtPageIndex.Focus();
        }
        else if (txtPageIndex.Text != "" && !(Convert.ToInt32(txtPageIndex.Text) < 0))
        {
            lblmsg.Visible = false;
            dg_page_indexSize();

        }
        else
        {
            txtPageIndex.Text = "";
        }
    }
    protected void lnkAllPg_Click(object sender, EventArgs e)
    {
        strAlpha = Request.QueryString["alpha"];
        strAlpha = "";
        cmbMainParentSrch.SelectedIndex = 0;
        cmbPgTypeSrch.Items.Clear();
        cmbPgTypeSrch.Items.Insert(0, "Select Page Type");
        cmbPgTypeSrch.SelectedIndex = 0;
        bind_grid();
        Response.Redirect("Manage_InnerPage.aspx");
    }
    protected void cmbPgType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!(cmbPgType.SelectedIndex == 0))
        {
            PgSubType.Visible = true;
            try
            {
                string UsrNm = Session["log_name"].ToString();
                string Usrtype = Session["usr_type"].ToString();
                //da = ui.Fill_Parent(cms);
                da = new SqlDataAdapter();
                int cnt1 = 0;

                con.Open();
                SqlCommand cmd1 = new SqlCommand("Proc_ManageMenus", con);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                cmd1.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd1.Parameters.AddWithValue("@strMainParId1", cmbMainType.SelectedValue);
                cmd1.Parameters.AddWithValue("@strParentId1", cmbPgType.SelectedValue);
                if (Usrtype == "admin")
                {
                    cmd1.Parameters["@Mode"].Value = "CntSubPg3";
                }
                else
                {
                    cmd1.Parameters.AddWithValue("@strLogNm", UsrNm);
                    cmd1.Parameters["@Mode"].Value = "cntUsrPg3";
                    //cmd1.Parameters["@Mode"].Value = "CntSubPg3";
                }
                cnt1 = (int)cmd1.ExecuteScalar();
                con.Close();

                if (cnt1 > 0)
                {
                    con.Open();

                    SqlCommand cmd2 = new SqlCommand("Proc_ManageMenus", con);
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd2.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd2.Parameters.AddWithValue("@strMainParId1", cmbMainType.SelectedValue);
                    cmd2.Parameters.AddWithValue("@strParentId1", cmbPgType.SelectedValue);
                    if (Usrtype == "admin")
                    {
                        cmd2.Parameters["@Mode"].Value = "ShSubPg3";
                    }
                    else
                    {
                        cmd2.Parameters.AddWithValue("@strLogNm", UsrNm);
                        cmd2.Parameters["@Mode"].Value = "shtUsrPg3";
                       // cmd2.Parameters["@Mode"].Value = "ShSubPg3";
                    }

                    da.SelectCommand = cmd2;
                    da.Fill(ds, "tbl_MainPg3");
                    con.Close();
                    if ((ds != null))
                    {
                        if (!(ds.Tables["tbl_MainPg3"].Rows.Count == 0))
                        {
                            cmbPgSubType.Items.Clear();
                            cmbPgSubType.DataSource = ds.Tables["tbl_MainPg3"];
                            cmbPgSubType.DataTextField = "MainPageName";
                            cmbPgSubType.DataValueField = "parentid";
                            cmbPgSubType.DataBind();
                            cmbPgSubType.Items.Insert(0, "Select Sub Page Type");
                            cmbPgSubType.SelectedIndex = 0;
                        }
                        else
                        {
                            PgSubType.Visible = false;
                            cmbPgSubType.Items.Clear();
                            cmbPgSubType.Items.Insert(0, "Select Sub Page Type");
                            cmbPgSubType.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        PgSubType.Visible = false;
                        cmbPgSubType.Items.Clear();
                        cmbPgSubType.Items.Insert(0, "Select Sub Page Type");
                        cmbPgSubType.SelectedIndex = 0;
                    }
                }
                else
                {
                    PgSubType.Visible = false;
                    cmbPgSubType.Items.Clear();
                    cmbPgSubType.Items.Insert(0, "Select Sub Page Type");
                    cmbPgSubType.SelectedIndex = 0;
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
        else
        {
            PgSubType.Visible = false;
            cmbPgSubType.Items.Clear();
            cmbPgSubType.Items.Insert(0, "Select Sub Page Type");
            cmbPgSubType.SelectedIndex = 0;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["MenuPg"] = "";
        Session["PgId1"] = "";

        clear_AddEditTbl();

        txtSrchPg.Text = "";
        cmbPgTypeSrch.SelectedIndex = 0;
        cmbPgTypeSrch.SelectedIndex = 0;

        lblMainMsg.Text = "";
        strAlpha = "";
          }
    protected void lblallview_Click(object sender, EventArgs e)
    {
        bind_grid();
    }
    protected void cmbPgTypeSrch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!(cmbPgTypeSrch.SelectedIndex == 0))
        {
           // PgSubType.Visible = true;
            try
            {
                string UsrNm = Session["log_name"].ToString();
                string Usrtype = Session["usr_type"].ToString();
                //da = ui.Fill_Parent(cms);
                da = new SqlDataAdapter();
                int cnt1 = 0;

                con.Open();
                SqlCommand cmd1 = new SqlCommand("Proc_ManageMenus", con);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                cmd1.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd1.Parameters.AddWithValue("@strMainParId1", cmbMainParentSrch.SelectedValue);
                cmd1.Parameters.AddWithValue("@strParentId1", cmbPgTypeSrch.SelectedValue);
                if (Usrtype == "admin")
                {
                    cmd1.Parameters["@Mode"].Value = "CntSubPg3";
                }
                else
                {
                    cmd1.Parameters.AddWithValue("@strLogNm", UsrNm);
                    cmd1.Parameters["@Mode"].Value = "cntUsrPg3";
                }
                cnt1 = (int)cmd1.ExecuteScalar();
                con.Close();

                if (cnt1 > 0)
                {
                    con.Open();

                    SqlCommand cmd2 = new SqlCommand("Proc_ManageMenus", con);
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd2.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd2.Parameters.AddWithValue("@strMainParId1", cmbMainParentSrch.SelectedValue);
                    cmd2.Parameters.AddWithValue("@strParentId1", cmbPgTypeSrch.SelectedValue);
                    if (Usrtype == "admin")
                    {
                        cmd2.Parameters["@Mode"].Value = "ShSubPg3";
                    }
                    else
                    {
                        cmd2.Parameters.AddWithValue("@strLogNm", UsrNm);
                        cmd2.Parameters["@Mode"].Value = "shtUsrPg3";
                    }

                    da.SelectCommand = cmd2;
                    da.Fill(ds, "tbl_MainPg3");
                    con.Close();
                    if ((ds != null))
                    {
                        if (!(ds.Tables["tbl_MainPg3"].Rows.Count == 0))
                        {
                            Tr1.Visible = true;
                            ddlsrchsubtype.Items.Clear();
                            ddlsrchsubtype.DataSource = ds.Tables["tbl_MainPg3"];
                            ddlsrchsubtype.DataTextField = "MainPageName";
                            ddlsrchsubtype.DataValueField = "parentid";
                            ddlsrchsubtype.DataBind();
                            ddlsrchsubtype.Items.Insert(0, "Select Sub Page Type");
                            ddlsrchsubtype.SelectedIndex = 0;
                        }
                        else
                        {
                            Tr1.Visible = false;
                            ddlsrchsubtype.Items.Clear();
                            ddlsrchsubtype.Items.Insert(0, "Select Sub Page Type");
                            ddlsrchsubtype.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        Tr1.Visible = false;
                        ddlsrchsubtype.Items.Clear();
                        ddlsrchsubtype.Items.Insert(0, "Select Sub Page Type");
                        ddlsrchsubtype.SelectedIndex = 0;
                    }
                }
                else
                {
                    Tr1.Visible = false;
                    ddlsrchsubtype.Items.Clear();
                    ddlsrchsubtype.Items.Insert(0, "Select Sub Page Type");
                    ddlsrchsubtype.SelectedIndex = 0;
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
        else
        {
            PgSubType.Visible = false;
            ddlsrchsubtype.Items.Clear();
            ddlsrchsubtype.Items.Insert(0, "Select Sub Page Type");
            ddlsrchsubtype.SelectedIndex = 0;
        }
    }
   
}