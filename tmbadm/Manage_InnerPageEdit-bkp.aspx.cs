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
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;

public partial class Admin_Manage_InnerPageEdit : System.Web.UI.Page
{
    private AdmChkClass chkclass = new AdmChkClass();
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["TMBCON"]);
    SqlCommand cmd = new SqlCommand();
    //Audit_trail audtclass = new Audit_trail();
    SqlDataAdapter da = new SqlDataAdapter();
    System.Data.DataSet ds = new System.Data.DataSet();
    System.Data.DataSet ds1 = new System.Data.DataSet();
    Label lblpath1 = new Label();
    string GetPgID = "";
    string Usrtype = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblpath1 = (Label)this.Form.Parent.FindControl("lblSmeModNm");

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
                            Response.Redirect("TMBAdmin.aspx");
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
            if (!Page.IsPostBack)
            {
                // lblpath1.Text = "Content Management : Edit Inner Page";

                if (chkclass.Chk_ModAuth(Convert.ToString(Session["log_name"]), "Content Management", "Manage Inner Page Edit", Convert.ToString(Session["utype"])) == true)
                {
                    fill_day();
                    fill_year();

                    fill_MainParents();
                    //fill_ParentPage()
                    clear_data();
                    if (Session["Add Page"] == "Y")
                    {
                        Session["PgId1"] = "";
                        Session["PgLanguage"] = "Eng";
                        txtPgName.ReadOnly = false;
                        txtPgName.Enabled = true;

                        cmbMainType.AutoPostBack = true;
                        btnAdd1.Visible = true;
                        btnUpdate.Visible = false;

                        editor1.Text = "<table border='0' cellspacing='0' cellpadding='0' width='100%'><tbody><tr><td><img alt='banner' src='../images/samplebanner.jpg' /></td></tr><tr><td>&nbsp;</td></tr><tr><td class='header1bg'>Heading</td></tr><tr><td>&nbsp;</td></tr><tr><td><table border='0' cellspacing='0' cellpadding='10' width='100%' align='center'><tbody><tr><td><p align='center'><strong>Page under construction</strong></p></td></tr></tbody></table></td></tr><tr><td>&nbsp;</td></tr><tr><td>&nbsp;</td></tr></tbody></table>";

                    }
                    if ((Session["Add Page"] == "N") || (Session["Add Page"] == null))
                    {
                        btnAdd1.Visible = false;
                        btnUpdate.Visible = true;
                        fill_data();
                        cmbMainType.AutoPostBack = false;
                        cmbMainType.Enabled = false;
                        cmbPgType.Enabled = false;
                        if (!string.IsNullOrEmpty(Convert.ToString(Session["PgId1"])))
                        {
                            GetPgID = Convert.ToString(Session["PgId1"]);
                            Session["ContPgId"] = GetPgID;
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(Session["utype"])))
                        {
                            Usrtype = Convert.ToString(Session["utype"]);
                        }
                        string Usrnm = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(Session["log_name"])))
                        {
                            Usrnm = Convert.ToString(Session["log_name"]);
                        }
                        if (chk_thisPgAuth(Usrnm, Usrtype, GetPgID) == false)
                        {
                            Session["PgId1"] = "";
                            Response.Redirect("Manage_InnerPage.aspx");
                        }
                    }
                }
                else
                {
                    Response.Redirect("AdmMainPage.aspx");
                }
            }
        }
        catch
        {
        }

    }

    public bool chk_thisPgAuth(string Usrnm, string Usrtype, string GetPgId)
    {
        if (Usrtype == "admin")
        {
            return true;
        }
        else
        {
            int cnt1 = 0;

            con.Open();
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strLogNm", Usrnm);
            cmd.Parameters.AddWithValue("@strPageId", GetPgID);
            cmd.Parameters["@Mode"].Value = "cntUsrPgByPgId";
            cnt1 = (int)cmd.ExecuteScalar();
            con.Close();

            if (cnt1 > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public void clear_data()
    {
        cmbMainType.SelectedIndex = 0;

        cmbPgType.Items.Clear();
        cmbPgType.Items.Insert(0, "Select Page Type");
        cmbPgType.SelectedIndex = 0;

        txtPgName.Text = "";
        txtTitle.Text = "";
        rdbMainAct.SelectedIndex = 0;
        editor1.Text = "";
        rdbcontent.SelectedIndex = 0;
        //txtContentEdit.Text = ""
    }
    public void fill_day()
    {
        int day = 0;
        for (day = 1; day <= 31; day++)
        {
            cmbDD1.Items.Add(day.ToString());

        }
        cmbDD1.Items.Insert(0, "DD");
    }
    public void fill_year()
    {
        int y1 = (DateAndTime.Now.Year) + 1;

        int y2 = 0;
        for (y2 = 2010; y2 <= y1; y2++)
        {
            cmbYY1.Items.Add(y2.ToString());
        }
        cmbYY1.Items.Insert(0, "YYYY");
    }
    public void fill_content()
    {
        string contentt;
        string contentt1;
        string contentt2;
        GetPgID = Session["PgId1"].ToString();
        string PgLang = Session["PgLanguage"].ToString();
        SqlDataAdapter da = new SqlDataAdapter();
        string chk_cont = "";
        int cnt1 = 0;

        con.Open();
        cmd = new SqlCommand("Proc_ManageCmsPages", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
        cmd.Parameters.AddWithValue("@strPageId", GetPgID);
        if (PgLang == "Eng" || PgLang=="English")
        {
            cmd.Parameters["@Mode"].Value = "CntContMkr1";
        }
        else if (PgLang == "Hindi")
        {
            cmd.Parameters["@Mode"].Value = "CntContHnd1";
        }
        else if (PgLang == "Marathi")
        {
            cmd.Parameters["@Mode"].Value = "CntContMar1";
        }
        cnt1 = (int)cmd.ExecuteScalar();
        con.Close();

        if (cnt1 > 0)
        {
            con.Open();
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strPageId", GetPgID);
            if (PgLang == "Eng" ||PgLang=="English")
            {
                cmd.Parameters["@Mode"].Value = "ShContMkr1";
            }
            else if (PgLang == "Hindi")
            {
                cmd.Parameters["@Mode"].Value = "ShContHnd1";
            }
            else if (PgLang == "Marathi")
            {
                cmd.Parameters["@Mode"].Value = "ShContMar1";
            }
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "tbl_PgContent");
            con.Close();
            if (!(ds.Tables["tbl_PgContent"].Rows.Count == 0))
            {
                if (Convert.IsDBNull(ds.Tables["tbl_PgContent"].Rows[0]["ContDescription2"]) == false)
                {
                    contentt2 = ds.Tables["tbl_PgContent"].Rows[0]["ContDescription2"].ToString();
                }
                else
                {
                    contentt2 = "";
                }

                if (Convert.IsDBNull(ds.Tables["tbl_PgContent"].Rows[0]["ContDescription1"]) == false)
                {
                    contentt1 = ds.Tables["tbl_PgContent"].Rows[0]["ContDescription1"].ToString();
                }
                else
                {
                    contentt1 = "";
                }

                if (Convert.IsDBNull(ds.Tables["tbl_PgContent"].Rows[0]["ContDescription"]) == false)
                {
                    contentt = ds.Tables["tbl_PgContent"].Rows[0]["ContDescription"].ToString();
                }
                else
                {
                    contentt = "";
                }

                if (Convert.IsDBNull(ds.Tables["tbl_PgContent"].Rows[0]["ContID"]) == false)
                {
                    Session["ContId1"] = ds.Tables["tbl_PgContent"].Rows[0]["ContID"].ToString();
                }
                else
                {
                    Session["ContId1"] = "";
                }
                if (!(contentt == ""))
                {
                      if (!(contentt == ""))
                    {
                        editor1.Text = contentt;
                    }
                     else if (!(contentt2 == ""))
                    {
                        editor1.Text = contentt2;

                    }
                    else if (!(contentt1 == ""))
                    {
                        editor1.Text = contentt1;
                    }
                   
                }
            }
        }
    }
    public void fill_Parent()
    {
        try
        {
            string GetMainPrntID = cmbMainType.SelectedValue;
            string GetMainPrntNm = cmbMainType.SelectedItem.Text;

            Usrtype = Session["utype"].ToString();
            int cnt1 = 0;

            con.Open();
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strMainParId1", GetMainPrntID);
            cmd.Parameters["@Mode"].Value = "CntMainPg1";
            cnt1 = (int)cmd.ExecuteScalar();
            con.Close();

            if (cnt1 > 0)
            {
                con.Open();
                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strMainParId1", GetMainPrntID);
                cmd.Parameters["@Mode"].Value = "ShMainPg1";
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "tbl_SubPg");
                con.Close();

                if ((ds != null))
                {
                    if (!(ds.Tables["tbl_SubPg"].Rows.Count == 0))
                    {
                        cmbPgType.Items.Clear();
                        cmbPgType.DataSource = ds.Tables["tbl_SubPg"];
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
    void Audit_Trail()
    {
        string fields1 = "";
        if (txtPgName.Text != "")
        {
            fields1 = "Page Name : " + txtPgName.Text;
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
            if (fields1 == "")
            {
                fields1 = ", Page Type : " + cmbPgType.SelectedItem.Text;
            }
            else
            {
                fields1 = fields1 + ", Page Type : " + cmbPgType.SelectedItem.Text;
            }
        }
        string LogNm = Session["log_name"].ToString();
        string FieldNm = fields1;
        string LogId = Convert.ToString(Session["usr_id"]);
        string TblNm = "Page_Master_Tbl";
        string PageNm = "Manage_InnerPageEdit.aspx";
        string ModuleNm = "Content Management";
        string Content = Session["Content"].ToString();
        if (btnUpdate.Text == "Update")
        {
            string Remark = "Content is Updated";
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
            cmd.Parameters.AddWithValue("@strUpdatedContent", Content);
            cmd.Parameters.AddWithValue("@strAuditDt", DateTime.Now);
            cmd.Parameters.AddWithValue("@strRemark", Remark);
            cmd.Parameters.AddWithValue("@strEditOn", DateTime.Now);
            cmd.Parameters["@mode"].Value = "AuditOnEdit";
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    public void Content_History()
    {
        string ContPgIdEng = Session["ContPgId"].ToString();
        string ContPgIdHnd = Session["ContPgId"].ToString();
        string ContPgIdMar = Session["ContPgId"].ToString();
        string ContPgNmEng = txtPgName.Text + ".aspx";
        string ContPgNmHnd = txtPgName.Text + ".aspx";
        string ContPgNmMar = txtPgName.Text + ".aspx";
        string MainParent = cmbMainType.SelectedItem.Text;
        string Content = Session["Content"].ToString();
        string UpdatedBy = Session["log_name"].ToString();
        //string UpdatedOn = DateTime.Now.ToString();
        string Action = "";
        string lang = Session["PgLanguage"].ToString();
        if (btnUpdate.Text == "Update")
        {
            Action = "Content Updated";
            con.Close();
            //.........................Update English Content History
            if (lang == "Eng")
            {
                con.Open();
                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strContent", Content);
                cmd.Parameters.AddWithValue("@strContPgId", ContPgIdEng);
                cmd.Parameters.AddWithValue("@strContPgNmEng", ContPgNmEng);
                cmd.Parameters.AddWithValue("@strMainParent", MainParent);
                cmd.Parameters.AddWithValue("@strAddedOn", DateTime.Now);
                cmd.Parameters.AddWithValue("@strAddedBy", UpdatedBy);
                cmd.Parameters.AddWithValue("@strAction", Action);
                cmd.Parameters["@mode"].Value = "ContEngUpdate";
                cmd.ExecuteNonQuery();
                con.Close();
            }
            //.........................Update Hindi Content History
            else if (lang == "Hindi")
            {
                con.Open();
                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strContent", Content);
                cmd.Parameters.AddWithValue("@strContPgId", ContPgIdHnd);
                cmd.Parameters.AddWithValue("@strContPgNmHnd", ContPgNmHnd);
                cmd.Parameters.AddWithValue("@strMainParent", MainParent);
                cmd.Parameters.AddWithValue("@strUpdatedOn", DateTime.Now);
                cmd.Parameters.AddWithValue("@strUpdatedBy", UpdatedBy);
                cmd.Parameters.AddWithValue("@strAction", Action);
                cmd.Parameters["@mode"].Value = "ContHndUpdate";
                cmd.ExecuteNonQuery();
                con.Close();
            }
            //.........................Update Marathi Content History
            else if (lang == "Marathi")
            {
                con.Open();
                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strContent", Content);
                cmd.Parameters.AddWithValue("@strContPgId", ContPgIdMar);
                cmd.Parameters.AddWithValue("@strContPgNmHnd", ContPgNmMar);
                cmd.Parameters.AddWithValue("@strMainParent", MainParent);
                cmd.Parameters.AddWithValue("@strUpdatedOn", DateTime.Now);
                cmd.Parameters.AddWithValue("@strUpdatedBy", UpdatedBy);
                cmd.Parameters.AddWithValue("@strAction", Action);
                cmd.Parameters["@mode"].Value = "ContMarUpdate";
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
    public void fill_data()
    {
        try
        {
            GetPgID = Convert.ToString(Session["PgId1"]);
            string PgType1 = "";
            string PgLang = Session["PgLanguage"].ToString();
            SqlDataAdapter da1 = new SqlDataAdapter();
            string pgType1 = "";
            con.Close();
            con.Open();
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strPageId", GetPgID);
            if (PgLang == "Eng" || PgLang == "English")
            {
                cmd.Parameters["@Mode"].Value = "GetPgMkrById";
            }
            else if (PgLang == "Hindi")
            {
                cmd.Parameters["@Mode"].Value = "GetHndPgMkrById";
            }
            else if (PgLang == "Marathi")
            {
                cmd.Parameters["@Mode"].Value = "GetPgMkrByIdMarathi";
            }
            da1 = new SqlDataAdapter();
            da1.SelectCommand = cmd;
            da1.Fill(ds, "tbl_PgDtls");
            con.Close();
            if (!(ds.Tables["tbl_PgDtls"].Rows.Count == 0))
            {
                if (Convert.IsDBNull(ds.Tables["tbl_PgDtls"].Rows[0]["MainParent"]) == false)
                {
                    cmbMainType.SelectedValue = ds.Tables["tbl_PgDtls"].Rows[0]["MainParent"].ToString();
                    fill_Parent();
                }
                else
                {
                    cmbMainType.SelectedIndex = 0;
                }

                if (Convert.IsDBNull(ds.Tables["tbl_PgDtls"].Rows[0]["ParentID"]) == false)
                {
                    PgType1 = ds.Tables["tbl_PgDtls"].Rows[0]["ParentID"].ToString();
                }
                else
                {
                    PgType1 = "";
                }

                if (Convert.IsDBNull(ds.Tables["tbl_PgDtls"].Rows[0]["PageTitle"]) == false)
                {
                    txtTitle.Text = ds.Tables["tbl_PgDtls"].Rows[0]["PageTitle"].ToString();
                }
                else
                {
                    txtTitle.Text = "";
                }

                if (Convert.IsDBNull(ds.Tables["tbl_PgDtls"].Rows[0]["PageName"]) == false)
                {
                    txtPgName.Text = ds.Tables["tbl_PgDtls"].Rows[0]["PageName"].ToString();
                }
                else
                {
                    txtPgName.Text = "";
                }

                if (Convert.IsDBNull(ds.Tables["tbl_PgDtls"].Rows[0]["PageAct"]) == false)
                {
                    rdbMainAct.SelectedValue = ds.Tables["tbl_PgDtls"].Rows[0]["PageAct"].ToString();
                }
                else
                {
                    rdbMainAct.SelectedValue = "N";
                }

                fill_Parent();
                cmbPgType.SelectedValue = PgType1;
                fill_content();
            }
        }
        catch (Exception ex)
        {
            string ma1 = "";
            ma1 = ex.ToString();

            if (!ma1.Contains("Thread was being aborted"))
            {
                Response.Write(ex.Message);
            }
        }
        finally
        {
            con.Close();
        }
    }
    public void fill_MainParents()
    {
        try
        {
            int cnt1 = 0;
            con.Open();
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters["@Mode"].Value = "CntMainParent1";
            cnt1 = (int)cmd.ExecuteScalar();
            con.Close();

            if (cnt1 > 0)
            {
                con.Open();
                // cmd = New SqlCommand("select distinct * from Main_PageParents order by 1", con)
                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters["@Mode"].Value = "ShMainParent1";
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "tbl_MainParent");

                if (!(ds.Tables["tbl_MainParent"].Rows.Count == 0))
                {
                    cmbMainType.Items.Clear();
                    cmbMainType.DataSource = ds.Tables["tbl_MainParent"];
                    cmbMainType.DataTextField = "MainParentName";
                    cmbMainType.DataValueField = "MainParentId";
                    cmbMainType.DataBind();
                    cmbMainType.Items.Insert(0, "Select Main Type");
                    cmbMainType.SelectedIndex = 0;
                }
                else
                {
                    cmbMainType.Items.Clear();
                    cmbMainType.Items.Insert(0, "Select Main Type");
                    cmbMainType.SelectedIndex = 0;
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
    public void fill_ParentPage()
    {
        try
        {
            int cnt1 = 0;
            con.Open();
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters["@Mode"].Value = "CntMainPg1";
            cnt1 = (int)cmd.ExecuteScalar();
            con.Close();

            if (cnt1 > 0)
            {
                con.Open();
                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters["@Mode"].Value = "ShMainPg1";
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "tbl_MainPg");
                con.Close();

                if (!(ds.Tables["tbl_MainPg"].Rows.Count == 0))
                {
                    cmbPgType.Items.Clear();
                    cmbPgType.DataSource = ds.Tables["tbl_MainPg"];
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
    public bool checkMainPgType()
    {
        string GetMainPrntID = cmbMainType.SelectedValue;
        string GetMainPrntNm = cmbMainType.SelectedItem.Text;
        int compcnt = 0;
        con.Open();
        cmd = new SqlCommand("Proc_ManageCmsPages", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@strMainParId1", GetMainPrntID);
        cmd.Parameters.AddWithValue("@strPageNm", GetMainPrntNm);
        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
        cmd.Parameters["@Mode"].Value = "chkMainParent";
        if (Convert.IsDBNull(cmd.ExecuteScalar()) == false)
        {
            compcnt = (int)cmd.ExecuteScalar();
        }
        else
        {
            compcnt = 0;
        }
        con.Close();
        if (compcnt > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool ChkPgType()
    {
        GetPgID = cmbPgType.SelectedValue;
        string Pagename = cmbPgType.SelectedItem.Text;
        int compcnt = 0;

        con.Open();
        cmd = new SqlCommand("Proc_ManageCmsPages", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@strPageId", GetPgID);
        cmd.Parameters.AddWithValue("@strPageNm", Pagename);
        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
        cmd.Parameters["@Mode"].Value = "chkMainPages";
        if (Convert.IsDBNull(cmd.ExecuteScalar()) == false)
        {
            compcnt = (int)cmd.ExecuteScalar();
        }
        else
        {
            compcnt = 0;
        }
        con.Close();
        if (compcnt > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool chkDatesSrch()
    {
        if (!(cmbDD1.SelectedIndex == 0) & !(cmbMM1.SelectedIndex == 0) & !(cmbYY1.SelectedIndex == 0))
        {
            if (Information.IsNumeric(cmbDD1.SelectedValue) == false)
            {
                lblMainMsg.Text = "Please select valid day for from date";
                cmbDD1.Focus();
                return false;
            }
            else if (int.Parse(cmbDD1.SelectedValue) > 31 || int.Parse(cmbDD1.SelectedValue) < 0)
            {
                lblMainMsg.Text = "Please select valid day for from date";
                cmbDD1.Focus();
                cmbDD1.SelectedIndex = 0;
                return false;
            }
            else if (Information.IsNumeric(cmbMM1.SelectedValue) == false)
            {
                lblMainMsg.Text = "Please select valid month for from date";
                cmbMM1.Focus();
                return false;
            }
            else if (int.Parse(cmbMM1.SelectedValue) > 12 | int.Parse(cmbMM1.SelectedValue) < 0)
            {
                lblMainMsg.Text = "Please select valid month for from date";
                cmbMM1.Focus();
                cmbMM1.SelectedIndex = 0;
                return false;
            }
            else if (Information.IsNumeric(cmbYY1.SelectedValue) == false)
            {
                lblMainMsg.Text = "Please select valid year for from date";
                cmbYY1.Focus();
                return false;
            }
            else if (int.Parse(cmbYY1.SelectedValue) > (DateAndTime.Now.Year + 1) | int.Parse(cmbYY1.SelectedValue) < 2010)
            {
                lblMainMsg.Text = "Please select valid year for from date";
                cmbYY1.Focus();
                cmbYY1.SelectedIndex = 0;
                return false;
            }

            else
            {
                lblMainMsg.Text = "";
                return true;
            }
        }
        else
        {
            if (string.IsNullOrEmpty(lblMainMsg.Text))
            {
                lblMainMsg.Text = "Please select proper date";
            }
            else
            {
                lblMainMsg.Text = lblMainMsg.Text;
            }
            return false;
        }
    }
    public bool check_datesSrch()
    {
        lblMainMsg.Text = "";
        int flag1 = 0;

        if (int.Parse(cmbMM1.SelectedValue) == 4 || int.Parse(cmbMM1.SelectedValue) == 6 || int.Parse(cmbMM1.SelectedValue) == 9 || int.Parse(cmbMM1.SelectedValue) == 11)
        {
            if (cmbDD1.SelectedValue == "31")
            {
                lblMainMsg.Text = cmbMM1.SelectedItem.Text + " " + "can't have" + " " + cmbDD1.SelectedValue + " " + "days";
                flag1 = 0;
            }
            else
            {
                flag1 = flag1 + 1;
                lblMainMsg.Text = "";
            }
        }
        else
        {
            flag1 = flag1 + 1;
            lblMainMsg.Text = "";
        }

        if (flag1 >= 1)
        {
            if (int.Parse(cmbMM1.SelectedValue) == 2 & (System.DateTime.IsLeapYear(int.Parse(cmbYY1.SelectedValue))))
            {
                if (int.Parse(cmbDD1.SelectedValue) > 29)
                {
                    lblMainMsg.Text = "February" + " " + cmbYY1.SelectedValue + " " + "dosen't have" + " " + cmbDD1.SelectedValue + " " + "days";
                    flag1 = 0;
                }
                else
                {
                    flag1 = flag1 + 1;
                    lblMainMsg.Text = "";
                }
            }
            else
            {
                flag1 = flag1 + 1;
                lblMainMsg.Text = "";
            }
        }

        if (flag1 >= 2)
        {
            if (int.Parse(cmbMM1.SelectedValue) == 2 & !(System.DateTime.IsLeapYear(int.Parse(cmbYY1.SelectedValue))))
            {
                if (int.Parse(cmbDD1.SelectedValue) > 28)
                {
                    lblMainMsg.Text = "February" + " " + cmbYY1.SelectedValue + " " + "dosen't have" + " " + cmbDD1.SelectedValue + " " + "days";
                    flag1 = 0;
                }
                else
                {
                    flag1 = flag1 + 1;
                    lblMainMsg.Text = "";
                }
            }
            else
            {
                flag1 = flag1 + 1;
                lblMainMsg.Text = "";
            }
        }

        if (flag1 == 0)
        {
            if (string.IsNullOrEmpty(lblMainMsg.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (flag1 >= 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string nowdt = DateTime.Now.ToShortDateString();

            string validdate1 = cmbMM1.SelectedValue + "/" + cmbDD1.SelectedValue + "/" + cmbYY1.SelectedValue;
            string PageTitle = txtTitle.Text;
            string Pagename = txtPgName.Text;
            string LnkAct = rdbMainAct.SelectedValue;
            string StrAlpha = editor1.Text;

            if (cmbMainType.SelectedIndex == 0)
            {
                lblMainMsg.Text = "Select main type  !!";
                cmbMainType.SelectedIndex = 0;
                cmbMainType.Focus();

            }
            else if (!(cmbMainType.SelectedIndex == 0) & Information.IsNumeric(cmbMainType.SelectedValue) == false)
            {
                lblMainMsg.Text = "Select valid main type !!";
                cmbMainType.SelectedIndex = 0;
                cmbMainType.Focus();

            }
            else if (!(cmbMainType.SelectedIndex == 0) & checkMainPgType() == false)
            {
                lblMainMsg.Text = "Select valid main type !!";
                cmbMainType.SelectedIndex = 0;
                cmbMainType.Focus();

            }
            else if (cmbPgType.SelectedIndex == 0)
            {
                lblMainMsg.Text = "Select page type !!";
                cmbPgType.SelectedIndex = 0;
                cmbPgType.Focus();

            }
            else if (!(cmbPgType.SelectedIndex == 0) & Information.IsNumeric(cmbPgType.SelectedValue) == false)
            {
                lblMainMsg.Text = "Select valid page type !!";
                cmbPgType.SelectedIndex = 0;
                cmbPgType.Focus();

            }
            else if (!(cmbPgType.SelectedIndex == 0) & ChkPgType() == false)
            {
                lblMainMsg.Text = "Select valid page type !!";
                cmbPgType.SelectedIndex = 0;
                cmbPgType.Focus();

            }
            else if (string.IsNullOrEmpty(txtPgName.Text))
            {
                lblMainMsg.Text = "Please enter page name !!";
                txtPgName.Focus();

            }
            else if (string.IsNullOrEmpty(txtTitle.Text))
            {
                lblMainMsg.Text = "Please enter page title !!";
                txtTitle.Focus();

            }
            else if (!(rdbMainAct.SelectedValue == "Y") & !(rdbMainAct.SelectedValue == "N"))
            {
                lblMainMsg.Text = "Select whether the page is active !!";
                rdbMainAct.Focus();

            }
            else if (string.IsNullOrEmpty(editor1.Text))
            {
                lblMainMsg.Text = "Enter page content !!";
            }
            else if ((cmbDD1.SelectedIndex == 0) || (cmbMM1.SelectedIndex == 0) || (cmbYY1.SelectedIndex == 0))
            {
                lblMainMsg.Text = "Please Select Date";
                cmbDD1.Focus();

            }
            else if (chkDatesSrch() == false)
            {
                lblMainMsg.Text = lblmsg.Text;
                cmbDD1.Focus();
            }
            else if (check_datesSrch() == false)
            {
                lblMainMsg.Text = "Please enter valid date";
                cmbDD1.Focus();
            }
            //else if (DateTime.Compare(DateTime.Parse(nowdt), Convert.ToDateTime(DateTime.Parse(validdate1))) > 0)
            //{
            //    lblMainMsg.Text = "Please select date greater than current date";
            //    cmbDD1.Focus();
            //}

            else
            {
                string validdate = cmbMM1.SelectedValue + "/" + cmbDD1.SelectedValue + "/" + cmbYY1.SelectedValue;
                //DateTime timee = DateTime.Now.TimeOfDay;
                lblmsg.Text = "";
                ///''''''' Update Title and Contents
                GetPgID = Session["PgId1"].ToString();
                string PgLang = Session["PgLanguage"].ToString();
                string GetEditorContent = editor1.Text;
                string GetMainPrntID = validdate;

                con.Open();
                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strPageId", GetPgID);
                cmd.Parameters.AddWithValue("@strPageTitle", PageTitle);
                cmd.Parameters.AddWithValue("@PgAct", LnkAct);
                if (PgLang == "Eng")
                {
                    cmd.Parameters["@Mode"].Value = "EditPgTitleMkr";
                }
                else if (PgLang == "Hindi")
                {
                    cmd.Parameters["@Mode"].Value = "EdtPgTtlHndMkr";
                }
                else if (PgLang == "Marathi")
                {
                    cmd.Parameters["@Mode"].Value = "EditPgTtlMarMkr";
                }
                cmd.ExecuteNonQuery();
                con.Close();

                if (txtPgName.Text.Contains("Hindi"))
                {
                    PgLang = "Hindi";
                }
                else if (txtPgName.Text.Contains("Marathi"))
                {
                    PgLang = "Marathi";
                }
                else
                {
                    PgLang = "Eng";
                }
                SqlDataAdapter da = new SqlDataAdapter();

                string chk_cont = "";
                int cnt1 = 0;

                con.Open();
                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strPageId", GetPgID);
                if (PgLang == "Eng")
                {
                    cmd.Parameters["@Mode"].Value = "CntContMkr1";
                }
                else if (PgLang == "Hindi")
                {
                    cmd.Parameters["@Mode"].Value = "CntContHnd1";
                }
                else if (PgLang == "Marathi")
                {
                    cmd.Parameters["@Mode"].Value = "CntContMar1";
                }
                cnt1 = (int)cmd.ExecuteScalar();
                con.Close();

                if (cnt1 > 0)
                {
                    con.Open();
                    cmd = new SqlCommand("Proc_ManageCmsPages", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd.Parameters.AddWithValue("@strPageId", GetPgID);
                    if (PgLang == "Eng")
                    {
                        cmd.Parameters["@Mode"].Value = "ShContMkr1";
                    }
                    else if (PgLang == "Hindi")
                    {
                        cmd.Parameters["@Mode"].Value = "ShContHnd1";
                    }
                    else if (PgLang == "Marathi")
                    {
                        cmd.Parameters["@Mode"].Value = "ShContMar1";
                    }
                    da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                }

                DataSet ds = new DataSet();
                da.Fill(ds, "tbl_content");
                con.Close();
                string content;
                string content1;
                string content2;
                if (Convert.IsDBNull(ds.Tables["tbl_content"].Rows[0]["ContDescription"]) == false)
                {
                    content = ds.Tables["tbl_content"].Rows[0]["ContDescription"].ToString();
                }
                else
                {
                    content = "";
                }

                if (Convert.IsDBNull(ds.Tables["tbl_content"].Rows[0]["ContDescription1"]) == false)
                {
                    content1 = ds.Tables["tbl_content"].Rows[0]["ContDescription1"].ToString();
                }
                else
                {
                    content1 = "";
                }
                if (Convert.IsDBNull(ds.Tables["tbl_content"].Rows[0]["ContDescription2"]) == false)
                {
                    content2 = ds.Tables["tbl_content"].Rows[0]["ContDescription2"].ToString();
                }
                else
                {
                    content2 = "";
                }
                string GetEditorContent1 = "";
                string GetEditorContent2 = "";
                if ((content == "") & (content1 == "") & (content2 == ""))
                {
                    GetEditorContent = editor1.Text;
                    GetEditorContent1 = "";
                    GetEditorContent2 = "";
                    LnkAct = "Edit";
                }
                else if ((content == ""))
                {
                    GetEditorContent = editor1.Text;
                    GetEditorContent1 = "";
                    GetEditorContent2 = "";
                    LnkAct = "Edit";
                    Session["content"] = GetEditorContent;
                }
                else if ((!(content == "")) & (content1 == ""))
                {
                    GetEditorContent = editor1.Text;
                    GetEditorContent1 = content;
                    GetEditorContent2 = "";
                    LnkAct = "Edit";
                    Session["content"] = GetEditorContent1;
                }
                else if ((!(content == "")) & (!(content1 == "")) & (content2 == ""))
                {
                    GetEditorContent = editor1.Text;
                    GetEditorContent1 = content;
                    GetEditorContent2 = content1;
                    LnkAct = "Edit";
                    Session["content"] = GetEditorContent2;
                }
                else if ((!(content == "")) & (!(content1 == "")) & (!(content2 == "")))
                {
                    GetEditorContent = editor1.Text;
                    GetEditorContent1 = content;
                    GetEditorContent2 = content1;
                   // GetEditorContent2 = editor1.Text;
                    LnkAct = "Edit";
                    Session["content"] = GetEditorContent2;
                }
                // ui.Eng_Update_content(cms);
                con.Open();

                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strPageId", GetPgID);
                cmd.Parameters.AddWithValue("@strContDesc", GetEditorContent);
                cmd.Parameters.AddWithValue("@strContDesc1", GetEditorContent1);
                cmd.Parameters.AddWithValue("@strContDesc2", GetEditorContent2);
                cmd.Parameters.AddWithValue("@strDtUpload", DateTime.Now);
                cmd.Parameters.AddWithValue("@strDtDisplay", GetMainPrntID);
                cmd.Parameters.AddWithValue("@checked1", "Y");
                if (PgLang == "Eng")
                {
                    if (LnkAct == "Edit")
                    {
                        cmd.Parameters["@Mode"].Value = "EditContMkr";
                    }
                    else if (LnkAct == "Add")
                    {
                        cmd.Parameters.AddWithValue("@strContArch", "N");
                        cmd.Parameters["@Mode"].Value = "AddContMkr";
                    }
                }
                else if (PgLang == "Hindi")
                {
                    if (LnkAct == "Edit")
                    {
                        cmd.Parameters["@Mode"].Value = "EditContHndMkr";
                    }
                    else if (LnkAct == "Add")
                    {
                        cmd.Parameters.AddWithValue("@strContArch", "N");
                        cmd.Parameters["@Mode"].Value = "AddHndContMkr";
                    }
                }
                else if (PgLang == "Marathi")
                {
                    if (LnkAct == "Edit")
                    {
                        cmd.Parameters["@Mode"].Value = "EditContMarMkr";
                    }
                    else if (LnkAct == "Add")
                    {
                        cmd.Parameters.AddWithValue("@strContArch", "N");
                        cmd.Parameters["@Mode"].Value = "AddMarContMkr";
                    }
                }
                cmd.ExecuteNonQuery();
                con.Close();
                mail_appl();
                int aa = int.Parse(GetPgID);
                Content_History();
                Audit_Trail();
                lblmsg.Text = "Page contents updated successfully !!";
            }
        }
        catch (Exception ex)
        {
            string ma1 = "";
            ma1 = ex.ToString();

            if (!ma1.Contains("Thread was being aborted"))
            {
                Response.Write(ex.Message);
            }
            con.Close();
        }
    }

    public void mail_appl()
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


                strbody1 = strbody1 + "Dear <strong> Sir / Mam,</strong><br />";


                strbody1 = strbody1 + "<br /> Page Content has been updated.Kindly check. </span> <br /><br/>";

                strbody1 = strbody1 + "Page Name :<strong> " + txtPgName.Text + ".aspx </strong> <br /><br />";

                strbody1 = strbody1 + "Page Content Updated by :<strong> " + Session["log_name"] + " </strong> <br /><br />";

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
                Mail_br1.Subject = "LV Bank : Page Content Updated";
                Mail_br1.IsBodyHtml = true;
                Mail_br1.Body = strbody1;


                SmtpClient smtpMailObj1 = new SmtpClient();
                smtpMailObj1.Host = "smtp.gmail.com";
                smtpMailObj1.EnableSsl = true;
                smtpMailObj1.Credentials = new System.Net.NetworkCredential("ajitshinde625@gmail.com", "9930253216");
                smtpMailObj1.Port = 587;
              //  smtpMailObj1.Send(Mail_br1);



            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }

    }
    public void clear_AddEditTbl()
    {
        lblAddMainHead.Text = "Add New Page";
        cmbMainType.SelectedIndex = 0;

        cmbPgType.Items.Clear();
        cmbPgType.Items.Insert(0, "Select Page Type");
        cmbPgType.SelectedIndex = 0;
        txtPgName.Text = "";
        txtTitle.Text = "";
        rdbMainAct.SelectedIndex = 0;
        //btnAdd1.Text = "Add";
        lblMainMsg.Text = "";
    }
    public bool chk_data1()
    {
        string nowdt = DateTime.Now.ToShortDateString();
        string validdate1 = cmbMM1.SelectedValue + "/" + cmbDD1.SelectedValue + "/" + cmbYY1.SelectedValue;
        if (cmbMainType.SelectedIndex == 0)
        {
            lblMainMsg.Text = "Please select main type !!";
            cmbMainType.Focus();
            return false;
        }
        else if (!(cmbMainType.SelectedIndex == 0) & Information.IsNumeric(cmbMainType.SelectedValue) == false)
        {
            lblMainMsg.Text = "Select valid main type !!";
            cmbMainType.SelectedIndex = 0;
            cmbMainType.Focus();
            return false;
        }

        else if (cmbPgType.SelectedIndex == 0)
        {
            lblMainMsg.Text = "Please select page type !!";
            cmbPgType.Focus();
            return false;
        }
        else if (!(cmbPgType.SelectedIndex == 0) & Information.IsNumeric(cmbPgType.SelectedValue) == false)
        {
            lblMainMsg.Text = "Select valid page type !!";
            cmbPgType.SelectedIndex = 0;
            cmbPgType.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtPgName.Text))
        {
            lblMainMsg.Text = "Please enter page name !!";
            txtPgName.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtPgName.Text) & !Regex.IsMatch(txtPgName.Text, "^[A-Z.a-z.0-9.-]+$"))
        {
            lblMainMsg.Text = "Please enter valid page name !!";
            txtPgName.Focus();
            return false;
        }
        else if (Information.IsNumeric(txtPgName.Text) == true)
        {
            lblMainMsg.Text = "Page name must start with characters!!";
            txtPgName.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtPgName.Text) & txtPgName.Text.Length > 100)
        {
            lblMainMsg.Text = "Page name should contain maximum 100 characters!!";
            txtPgName.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtTitle.Text) & !Regex.IsMatch(txtPgName.Text, "^[A-Z.a-z.0-9-_& ]+$"))
        {
            lblMainMsg.Text = "Enter valid page title !!";
            txtTitle.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtTitle.Text) & txtTitle.Text.Length > 100)
        {
            lblMainMsg.Text = "Page title should contain maximum 100 characters!!";
            txtTitle.Focus();
            return false;
        }
        else if ((cmbDD1.SelectedIndex == 0) || (cmbMM1.SelectedIndex == 0) || (cmbYY1.SelectedIndex == 0))
        {
            lblMainMsg.Text = "Please Select Date";
            cmbDD1.Focus();
            return false;
        }
        else if (chkDatesSrch() == false)
        {
            lblMainMsg.Text = lblmsg.Text;
            cmbDD1.Focus();
            return false;
        }
        else if (check_datesSrch() == false)
        {
            lblMainMsg.Text = "Please enter valid date";
            cmbDD1.Focus();
            return false;
        }
        else if (DateTime.Compare(DateTime.Parse(nowdt), DateTime.Parse(validdate1)) > 0)
        {
            lblMainMsg.Text = "Please select date greater than current date";
            cmbDD1.Focus();
            return false;
        }
        else
        {
            lblMainMsg.Text = "";
            return true;
        }
    }
    public void CreateFile(string strName, int k, int MainId1)
    {
        ///''''''''''''''''''''''''  for Retail
        if (MainId1 == 1)
        {

            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicDeposite.aspx", Server.MapPath("../English/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicDeposite.aspx", Server.MapPath("../English/") + "\\" + strName + ".aspx");
            }

            ///''''''''''''''''''''''''  for Corporate
        }
        else if (MainId1 == 2)
        {

            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicCorp.aspx", Server.MapPath("../English/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicCorp.aspx", Server.MapPath("../English/") + "\\" + strName + ".aspx");
            }


            ///''''''''''''''''''''''''  for NRI
        }
        else if (MainId1 == 3)
        {

            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicNRI.aspx", Server.MapPath("../English/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicNRI.aspx", Server.MapPath("../English/") + "\\" + strName + ".aspx");
            }


            ///''''''''''''''''''''''''  for Rural
        }
        else if (MainId1 == 4)
        {
            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicRural.aspx", Server.MapPath("../English/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicRural.aspx", Server.MapPath("../English/") + "\\" + strName + ".aspx");
            }

            ///''''''''''''''''''''''''  for MSME
        }
        else if (MainId1 == 5)
        {
            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicMSME.aspx", Server.MapPath("../English/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicMSME.aspx", Server.MapPath("../English/") + "\\" + strName + ".aspx");
            }

            ///''''''''''''''''''''''''  for DynamicStandardForms
        }
        else if (MainId1 == 6)
        {
            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicServCharge.aspx", Server.MapPath("../English/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicServCharge.aspx", Server.MapPath("../English/") + "\\" + strName + ".aspx");
            }

            ///''''''''''''''''''''''''  for DynamicTender
        }
        else if (MainId1 == 7)
        {
            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicInterestRate.aspx", Server.MapPath("../English/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicInterestRate.aspx", Server.MapPath("../English/") + "\\" + strName + ".aspx");
            }

        }
        else if (MainId1 == 8)
        {
            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicCustCorner.aspx", Server.MapPath("../English/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicCustCorner.aspx", Server.MapPath("../English/") + "\\" + strName + ".aspx");
            }

        }
        else if (MainId1 == 9)
        {
            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicAbout.aspx", Server.MapPath("../English/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicAbout.aspx", Server.MapPath("../English/") + "\\" + strName + ".aspx");
            }

        }
        else if (MainId1 == 11)
        {
            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicCards.aspx", Server.MapPath("../English/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicCards.aspx", Server.MapPath("../English/") + "\\" + strName + ".aspx");
            }

        }
        else if (MainId1 == 12)
        {
            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicHome.aspx", Server.MapPath("../English/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicHome.aspx", Server.MapPath("../English/") + "\\" + strName + ".aspx");
            }

            ///''''''''''''''''''''''''  for DynamicStandardForms
        }
        else if (MainId1 == 13)
        {
            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicAucillary.aspx", Server.MapPath("../English/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicAucillary.aspx", Server.MapPath("../English/") + "\\" + strName + ".aspx");
            }

            ///''''''''''''''''''''''''  for DynamicStandardForms
        }
        else if (MainId1 == 14)
        {
            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicInvestor.aspx", Server.MapPath("../English/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicInvestor.aspx", Server.MapPath("../English/") + "\\" + strName + ".aspx");
            }

            ///''''''''''''''''''''''''  for DynamicStandardForms
        }
        else if (MainId1 == 15)
        {
            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicGeneral.aspx", Server.MapPath("../English/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../English/") + "\\DynamicGeneral.aspx", Server.MapPath("../English/") + "\\" + strName + ".aspx");
            }

            ///''''''''''''''''''''''''  for DynamicStandardForms
        }
    }
    public void CreateFileHindi(string strName, int k, int MainId1)
    {
        ///''''''''''''''''''''''''  for Retail
        if (MainId1 == 1)
        {

            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicDepositeHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicDepositeHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName + ".aspx");
            }

            ///''''''''''''''''''''''''  for Corporate
        }
        else if (MainId1 == 2)
        {

            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicCorpHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicCorpHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName + ".aspx");
            }


            ///''''''''''''''''''''''''  for NRI
        }
        else if (MainId1 == 3)
        {

            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicNRIHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicNRIHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName + ".aspx");
            }


            ///''''''''''''''''''''''''  for Rural
        }
        else if (MainId1 == 4)
        {
            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicRuralHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicRuralHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName + ".aspx");
            }

            ///''''''''''''''''''''''''  for MSME
        }
        else if (MainId1 == 5)
        {
            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicMSMEHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicMSMEHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName + ".aspx");
            }

            ///''''''''''''''''''''''''  for RTI
        }
        else if (MainId1 == 6)
        {
            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicServChargeHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicServChargeHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName + ".aspx");
            }

            ///''''''''''''''''''''''''  for DynamicStandardForms
        }
        else if (MainId1 == 7)
        {
            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicInterestHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicInterestHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName + ".aspx");
            }

            ///''''''''''''''''''''''''  for DynamicTender
        }
        else if (MainId1 == 8)
        {
            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicCustCornerHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicCustCornerHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName + ".aspx");
            }

        }
        else if (MainId1 == 9)
        {
            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicAboutHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicAboutHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName + ".aspx");
            }

        }
        else if (MainId1 == 11)
        {
            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicCardsHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicCardsHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName + ".aspx");
            }

        }
        else if (MainId1 == 12)
        {

            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicHomeHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicHomeHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName + ".aspx");
            }


            ///''''''''''''''''''''''''  for NRI
        }
        else if (MainId1 == 13)
        {

            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicAucillaryHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicAucillaryHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName + ".aspx");
            }


            ///''''''''''''''''''''''''  for NRI
        }
        else if (MainId1 == 14)
        {

            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicInvestorHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicInvestorHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName + ".aspx");
            }


            ///''''''''''''''''''''''''  for NRI
        }
        else if (MainId1 == 15)
        {

            int J = 0;
            J = strName.IndexOf(".aspx");
            if (J != -1)
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicGeneralHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName);
            }
            else
            {
                File.Copy(Server.MapPath("../Hindi/") + "\\DynamicGeneralHindi.aspx", Server.MapPath("../Hindi/") + "\\" + strName + ".aspx");
            }


            ///''''''''''''''''''''''''  for NRI
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Session["PgId1"] = "";
        Session["MenuPg"] = "";
        Session["PgLanguage"] = "";

        Session["Add Page"] = Convert.ToString(Session["Add Page"]);

        Session["SrchTxt"] = Convert.ToString(Session["SrchTxt"]);
        Session["MainType"] = "";
        Session["PgTypename"] = Convert.ToString(txtPgName.Text);

        Response.Redirect("Manage_InnerPage.aspx");
    }
    protected void rdbcontent_SelectedIndexChanged(object sender, EventArgs e)
    {
        string PgLang = "";
        if (txtPgName.Text.Contains("Hindi"))
        {
            PgLang = "Hindi";
        }
        else if (txtPgName.Text.Contains("Marathi"))
        {
            PgLang = "Marathi";
        }
        else
        {
            PgLang = "Eng";
        }

        if (rdbcontent.SelectedValue == "Previous1")
        {
            GetPgID = Session["PgId1"].ToString();

            con.Open();

            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strPageId", GetPgID);

            if (PgLang == "Eng")
            {
                cmd = new SqlCommand("select ContDescription1 from dbo.PageContents_Tbl_Maker where PageID='" + GetPgID + "'", con);
                //cmd.Parameters["@Mode"].Value = "Contteng1";
            }
            else if (PgLang == "Hindi")
            {
                cmd.Parameters["@Mode"].Value = "ConttHind1";
            }
            else if (PgLang == "Marathi")
            {
                cmd.Parameters["@Mode"].Value = "ConttMar1";
            }
            editor1.Text = cmd.ExecuteScalar().ToString();
            con.Close();

            btnUpdate.Enabled = true;
        }
        else if (rdbcontent.SelectedValue == "Previous2")
        {
            GetPgID = Session["PgId1"].ToString();

            con.Open();

            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strPageId", GetPgID);

            if (PgLang == "Eng")
            {
                cmd = new SqlCommand("select ContDescription2 from dbo.PageContents_Tbl_Maker where PageID='" + GetPgID + "'", con);
                //cmd.Parameters["@Mode"].Value = "Contteng2";
            }
            else if (PgLang == "Hindi")
            {
                cmd.Parameters["@Mode"].Value = "ConttHind2";
            }
            else if (PgLang == "Marathi")
            {
                cmd.Parameters["@Mode"].Value = "ConttMar2";
            }
            editor1.Text = cmd.ExecuteScalar().ToString();
            con.Close();

            btnUpdate.Enabled = true;
        }
        else if (rdbcontent.SelectedValue == "Latest")
        {
            fill_content();
            btnUpdate.Enabled = true;
        }
    }
    int getlang(string pgnm)
    {
        if (pgnm.Contains("Hindi"))
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }
    protected void cmbMainType_SelectedIndexChanged(object sender, EventArgs e)
    {
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
    protected void btnAdd1_Click(object sender, EventArgs e)
    {

    }
}