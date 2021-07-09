using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Configuration;
using Microsoft.VisualBasic;

public partial class Admin_ManageAuditTrail : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["TMBCON"]);
    SqlCommand cmd = new SqlCommand();
    private AdmChkClass chkclass = new AdmChkClass();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    SqlDataReader dr;
    Label lblpath1;

    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetCacheability(HttpCacheability.NoCache);



        if (!Page.IsPostBack)
        {
          //  lblpath1.Text = "Audit Trail";
            fill_day();
            fill_year();
            fill_User();
            fill_PageNames();
            clear_data();
            bind_AuditGrid();
            // Allbind_AuditGrid();

            if (cmbTimeProd.SelectedValue == "Date Wise")
            {
                true_data();
            }
            else
            {
                false_data();
            }
        }
    }
    public void true_data()
    {
        cmbDD1.Enabled = true;
        cmbMM1.Enabled = true;
        cmbYY1.Enabled = true;
        cmbDD2.Enabled = true;
        cmbMM2.Enabled = true;
        cmbYY2.Enabled = true;
    }
    public void false_data()
    {
        cmbDD1.Enabled = false;
        cmbMM1.Enabled = false;
        cmbYY1.Enabled = false;
        cmbDD2.Enabled = false;
        cmbMM2.Enabled = false;
        cmbYY2.Enabled = false;
    }
    public void clear_data()
    {
        lblMainMsg.Text = "";
        lblmsg.Text = "";

        cmbView.SelectedIndex = 0;
        cmbTimeProd.SelectedIndex = 0;
        cmbDD1.SelectedIndex = 0;
        cmbMM1.SelectedIndex = 0;
        cmbYY1.SelectedIndex = 0;
        cmbDD2.SelectedIndex = 0;
        cmbMM2.SelectedIndex = 0;
        cmbYY2.SelectedIndex = 0;
        ddluser.SelectedIndex = 0;
        ddlpage.SelectedIndex = 0;
        txtPageSize.Text = "10";
        txtPageIndex.Text = "1";
        dg_audit.DataSource = null;
        dg_audit.DataBind();
        dg_audit.Visible = false;
        false_data();
    }
    public string LPadZero(string strNumber, Int32 nWidth)
    {
        string LPadZero1;
        strNumber = strNumber.Trim();
        if (strNumber.Length > nWidth)
        {
            LPadZero1 = strNumber;
        }
        else
        {
            LPadZero1 = new string('0', nWidth - strNumber.Length) + strNumber;
        }
        return LPadZero1;
    }
    public void fill_User()
    {
        try
        {
            string Usrtype = Session["usr_type"].ToString();

            SqlDataAdapter da = new SqlDataAdapter();
            //da = ui.fill_MainPrnt_Srch(cms);
            int cnt1 = 0;

            con.Open();
            //cmd = New SqlCommand("select count(distinct MainParentId) from Main_PageParents", con)
            cmd = new SqlCommand("Proc_AmdLog", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            if (Usrtype == "admin")
            {
                cmd.Parameters["@Mode"].Value = "CntLogNm";
            }
            //else
            //{
            //    cmd.Parameters.AddWithValue("@strLogNm", Session["log_name"].ToString());
            //    cmd.Parameters["@Mode"].Value = "cntUsrMainParentsM3";
            //}
            cnt1 = (int)cmd.ExecuteScalar();
            con.Close();
            if (cnt1 > 0)
            {


                con.Open();
                cmd = new SqlCommand("Proc_AmdLog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 20));
                if (Usrtype == "admin")
                {
                    cmd.Parameters["@Mode"].Value = "GetLogNm";
                }
                //else
                //{
                //    cmd.Parameters.AddWithValue("@strLogNm", Session["log_name"].ToString());
                //    cmd.Parameters["@Mode"].Value = "getUsrMainParentsM3";
                //}
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                con.Close();
            }

            da.Fill(ds, "tbl_LogMaster");

            if ((ds != null))
            {
                if (!(ds.Tables["tbl_LogMaster"].Rows.Count == 0))
                {
                    ddluser.Items.Clear();
                    ddluser.DataSource = ds.Tables["tbl_LogMaster"];
                    ddluser.DataTextField = "officer_uid";
                    ddluser.DataValueField = "officer_id";
                    ddluser.DataBind();
                    ddluser.Items.Insert(0, "All");
                    ddluser.SelectedIndex = 0;
                }
                else
                {
                    ddluser.Items.Clear();
                    ddluser.Items.Insert(0, "Select Main Type");
                    ddluser.SelectedIndex = 0;
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
        finally {
            con.Close();
        }
    }
    public void fill_day()
    {
        int day = 0;
        for (day = 1; day <= 31; day++)
        {
            cmbDD1.Items.Add(LPadZero(day.ToString(), 2));
            cmbDD2.Items.Add(LPadZero(day.ToString(), 2));
        }
        cmbDD1.Items.Insert(0, "DD");
        cmbDD2.Items.Insert(0, "DD");
    }

    public void fill_year()
    {
        int y1 = (DateAndTime.Now.Year) + 1;

        int y2 = 0;
        for (y2 = 2010; y2 <= y1; y2++)
        {
            cmbYY1.Items.Add(y2.ToString());
            cmbYY2.Items.Add(y2.ToString());
        }
        cmbYY1.Items.Insert(0, "YYYY");
        cmbYY2.Items.Insert(0, "YYYY");
    }
    public void fill_PageNames()
    {
        try
        {
            int cnt1 = 0;
            con.Open();
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));

            cmd.Parameters["@Mode"].Value = "cntPgMaker2";

            cnt1 = (int)cmd.ExecuteScalar();
            con.Close();

            if (cnt1 > 0)
            {
                con.Open();
                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));

                cmd.Parameters["@Mode"].Value = "shPgMaker2";

            }
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "tbl_Main2");
            con.Close();
            if (!(ds.Tables["tbl_Main2"].Rows.Count == 0))
            {
                ddlpage.Items.Clear();
                ddlpage.DataSource = ds.Tables["tbl_Main2"];
                ddlpage.DataTextField = "PageName";
                ddlpage.DataValueField = "PageName";
                ddlpage.DataBind();
                ddlpage.Items.Insert(0, "Select Web Page");
                ddlpage.SelectedIndex = 0;
            }
            else
            {
                ddlpage.Items.Clear();
                ddlpage.Items.Insert(0, "Select Web Page");
                ddlpage.SelectedIndex = 0;
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
    public bool chkDates()
    {
        if (!(cmbDD1.SelectedIndex == 0) & !(cmbMM1.SelectedIndex == 0) & !(cmbYY1.SelectedIndex == 0) & !(cmbDD2.SelectedIndex == 0) & !(cmbMM2.SelectedIndex == 0) & !(cmbYY2.SelectedIndex == 0))
        {
            if (Information.IsNumeric(cmbDD1.SelectedValue) == false)
            {
                lblMainMsg.Text = "Please select valid day for from display date";
                cmbDD1.Focus();
                return false;
            }
            else if (int.Parse(cmbDD1.SelectedValue) > 31 | int.Parse(cmbDD1.SelectedValue) < 0)
            {
                lblMainMsg.Text = "Please select valid day for from display date";
                cmbDD1.Focus();
                cmbDD1.SelectedIndex = 0;
                return false;
            }
            else if (Information.IsNumeric(cmbMM1.SelectedValue) == false)
            {
                lblMainMsg.Text = "Please select valid month for from display date";
                cmbMM1.Focus();
                return false;
            }
            else if (int.Parse(cmbMM1.SelectedValue) > 12 | int.Parse(cmbMM1.SelectedValue) < 0)
            {
                lblMainMsg.Text = "Please select valid month for from display date";
                cmbMM1.Focus();
                cmbMM1.SelectedIndex = 0;
                return false;
            }
            else if (Information.IsNumeric(cmbYY1.SelectedValue) == false)
            {
                lblMainMsg.Text = "Please select valid year for from display date";
                cmbYY1.Focus();
                return false;
            }
            else if (int.Parse(cmbYY1.SelectedValue) > (DateAndTime.Now.Year + 1) | int.Parse(cmbYY1.SelectedValue) < 2010)
            {
                lblMainMsg.Text = "Please select valid year for from display date";
                cmbYY1.Focus();
                cmbYY1.SelectedIndex = 0;
                return false;
            }
            else if (Information.IsNumeric(cmbDD2.SelectedValue) == false)
            {
                lblMainMsg.Text = "Please select valid day for to display date";
                cmbDD2.Focus();
                return false;
            }
            else if (int.Parse(cmbDD2.SelectedValue) > 31 | int.Parse(cmbDD2.SelectedValue) < 0)
            {
                lblMainMsg.Text = "Please select valid day for to display date";
                cmbDD2.Focus();
                cmbDD2.SelectedIndex = 0;
                return false;
            }
            else if (Information.IsNumeric(cmbMM2.SelectedValue) == false)
            {
                lblMainMsg.Text = "Please select valid month for to display date";
                cmbMM2.Focus();
                return false;
            }
            else if (int.Parse(cmbMM2.SelectedValue) > 12 | int.Parse(cmbMM2.SelectedValue) < 0)
            {
                lblMainMsg.Text = "Please select valid month to from display date";
                cmbMM2.Focus();
                cmbMM2.SelectedIndex = 0;
                return false;
            }
            else if (Information.IsNumeric(cmbYY2.SelectedValue) == false)
            {
                lblMainMsg.Text = "Please select valid year for to display date";
                cmbYY2.Focus();
                return false;
            }
            else if (int.Parse(cmbYY2.SelectedValue) > (DateAndTime.Now.Year + 1) | int.Parse(cmbYY2.SelectedValue) < 2010)
            {
                lblMainMsg.Text = "Please select valid year for to display date";
                cmbYY2.Focus();
                cmbYY2.SelectedIndex = 0;
                return false;
            }
            else if (check_dates() == false)
            {
                lblMainMsg.Text = lblmsg.Text;
                cmbYY2.Focus();
                return false;
            }
            else if (compare_dates() == false)
            {
                lblMainMsg.Text = lblMainMsg.Text;
                cmbYY2.Focus();
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
            if (string.IsNullOrEmpty(lblmsg.Text))
            {
                lblMainMsg.Text = "Please select from and to display dates";
            }
            else
            {
                lblMainMsg.Text = lblMainMsg.Text;
            }
            return false;
        }
    }

    public bool check_dates()
    {

        lblmsg.Text = "";
        int flag1 = 0;

        if (int.Parse(cmbMM1.SelectedValue) == 4 | int.Parse(cmbMM1.SelectedValue) == 6 | int.Parse(cmbMM1.SelectedValue) == 9 | int.Parse(cmbMM1.SelectedValue) == 11)
        {
            if (int.Parse(cmbDD1.SelectedValue) == 31)
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
            if (int.Parse(cmbMM1.SelectedValue) == 2 & (System.DateTime.IsLeapYear(int.Parse(cmbYY1.SelectedValue))) & int.Parse(cmbDD1.SelectedValue) > 29)
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


        if (flag1 >= 2)
        {
            if (int.Parse(cmbMM1.SelectedValue) == 2 & !(System.DateTime.IsLeapYear(int.Parse(cmbYY1.SelectedValue))) & int.Parse(cmbDD1.SelectedValue) > 28)
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


        if (flag1 >= 3)
        {
            if (int.Parse(cmbMM2.SelectedValue) == 4 | int.Parse(cmbMM2.SelectedValue) == 6 | int.Parse(cmbMM2.SelectedValue) == 9 | int.Parse(cmbMM2.SelectedValue) == 11)
            {
                if (int.Parse(cmbDD2.SelectedValue) == 31)
                {
                    lblMainMsg.Text = cmbMM2.SelectedItem.Text + " " + "can't have" + " " + cmbDD2.SelectedValue + " " + "days";
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


        if (flag1 >= 4)
        {
            if (int.Parse(cmbMM2.SelectedValue) == 2 & (System.DateTime.IsLeapYear(int.Parse(cmbYY2.SelectedValue))) & int.Parse(cmbDD2.SelectedValue) > 29)
            {
                lblMainMsg.Text = "February" + " " + cmbYY2.SelectedValue + " " + "dosen't have" + " " + cmbDD2.SelectedValue + " " + "days";
                flag1 = 0;
            }
            else
            {
                flag1 = flag1 + 1;
                lblMainMsg.Text = "";
            }
        }


        if (flag1 >= 5)
        {
            if (int.Parse(cmbMM2.SelectedValue) == 2 & !(System.DateTime.IsLeapYear(int.Parse(cmbYY2.SelectedValue))) & int.Parse(cmbDD2.SelectedValue) > 28)
            {
                lblMainMsg.Text = "February" + " " + cmbYY2.SelectedValue + " " + "dosen't have" + " " + cmbDD2.SelectedValue + " " + "days";
                flag1 = 0;
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
        else if (flag1 >= 6)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool compare_dates()
    {
        string frmDt = "";
        string toDt = "";

        DateTime frmDt1 = default(DateTime);
        DateTime toDt1 = default(DateTime);

        frmDt = cmbMM1.SelectedValue + "/" + cmbDD1.SelectedValue + "/" + cmbYY1.SelectedValue;
        toDt = cmbMM2.SelectedValue + "/" + cmbDD2.SelectedValue + "/" + cmbYY2.SelectedValue;

        frmDt1 = Convert.ToDateTime(frmDt);
        toDt1 = Convert.ToDateTime(toDt);

        if (frmDt1 > toDt1)
        {
            lblMainMsg.Text = "From date must be less than To date !!";
            return false;
        }
        else
        {
            lblMainMsg.Text = "";
            return true;
        }
    }

    public void bind_data()
    {
        try
        {
            int flag1 = 0;
            if (cmbTimeProd.SelectedValue == "Date Wise")
            {
                if (cmbDD1.SelectedIndex == 0 & cmbMM1.SelectedIndex == 0 & cmbYY1.SelectedIndex == 0 & cmbDD2.SelectedIndex == 0 & cmbMM2.SelectedIndex == 0 & cmbYY2.SelectedIndex == 0)
                {
                    flag1 = 0;
                    lblMainMsg.Text = "Select Dates !!";
                }
                else if (!(cmbDD1.SelectedIndex == 0) & !(cmbMM1.SelectedIndex == 0) & !(cmbYY1.SelectedIndex == 0) & !(cmbDD2.SelectedIndex == 0) & !(cmbMM2.SelectedIndex == 0) & !(cmbYY2.SelectedIndex == 0))
                {

                    if (chk_validDates() == true)
                    {

                        if (check_dates() == true)
                        {

                            if (compare_dates() == true)
                            {
                                lblMainMsg.Text = "";
                                flag1 = flag1 + 1;
                            }
                            else
                            {
                                flag1 = 0;
                                lblMainMsg.Text = lblMainMsg.Text;
                            }
                        }
                        else
                        {
                            flag1 = 0;
                            lblMainMsg.Text = lblMainMsg.Text;
                        }
                    }
                    else
                    {
                        flag1 = 0;
                        lblMainMsg.Text = lblMainMsg.Text;
                    }
                }
                else if (cmbDD1.SelectedIndex == 0)
                {
                    flag1 = 0;
                    lblMainMsg.Text = "Select day for From Date !!";
                    cmbDD1.Focus();
                }
                else if (cmbMM1.SelectedIndex == 0)
                {
                    flag1 = 0;
                    lblMainMsg.Text = "Select month for From Date !!";
                    cmbMM1.Focus();
                }
                else if (cmbYY1.SelectedIndex == 0)
                {
                    flag1 = 0;
                    lblMainMsg.Text = "Select year for From Date !!";
                    cmbYY1.Focus();
                }
                else if (cmbDD2.SelectedIndex == 0)
                {
                    flag1 = 0;
                    lblMainMsg.Text = "Select day for To Date !!";
                    cmbDD2.Focus();
                }
                else if (cmbMM2.SelectedIndex == 0)
                {
                    flag1 = 0;
                    lblMainMsg.Text = "Select month for To Date !!";
                    cmbMM2.Focus();
                }
                else if (cmbYY2.SelectedIndex == 0)
                {
                    flag1 = 0;
                    lblMainMsg.Text = "Select year for To Date !!";
                    cmbYY2.Focus();
                }
            }
            else
            {
                flag1 = flag1 + 1;
                lblMainMsg.Text = "";
            }

            if (flag1 > 0 & string.IsNullOrEmpty(lblMainMsg.Text))
            {
                bind_AuditGrid();
            }
            else
            {
                dg_audit.DataSource = null;
                dg_audit.DataBind();
                dg_audit.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    public bool chk_validDates()
    {

        if (cmbDD1.SelectedIndex == 0)
        {
            lblMainMsg.Text = "Select day for From date !!";
            cmbDD1.Focus();
            return false;
        }
        else if (Information.IsNumeric(cmbDD1.SelectedValue) == false)
        {
            cmbDD1.SelectedIndex = 0;
            lblMainMsg.Text = "Select valid day for From date !!";
            cmbDD1.Focus();
            return false;
        }
        else if (cmbMM1.SelectedIndex == 0)
        {
            lblMainMsg.Text = "Select month for From date !!";
            cmbMM1.Focus();
            return false;
        }
        else if (Information.IsNumeric(cmbMM1.SelectedValue) == false)
        {
            cmbMM1.SelectedIndex = 0;
            lblMainMsg.Text = "Select valid month for From date !!";
            cmbMM1.Focus();
            return false;
        }
        else if (cmbYY1.SelectedIndex == 0)
        {
            lblMainMsg.Text = "Select year for From date !!";
            cmbYY1.Focus();
            return false;
        }
        else if (Information.IsNumeric(cmbYY1.SelectedValue) == false)
        {
            cmbYY1.SelectedIndex = 0;
            lblMainMsg.Text = "Select valid year for From date !!";
            cmbYY1.Focus();
            return false;
        }
        else if (cmbDD2.SelectedIndex == 0)
        {
            lblMainMsg.Text = "Select day for To Date !!";
            cmbDD2.Focus();
            return false;
        }
        else if (Information.IsNumeric(cmbDD2.SelectedValue) == false)
        {
            cmbDD2.SelectedIndex = 0;
            lblMainMsg.Text = "Select valid day for To Date !!";
            cmbDD2.Focus();
            return false;
        }
        else if (cmbMM2.SelectedIndex == 0)
        {
            lblMainMsg.Text = "Select month for To Date !!";
            cmbMM2.Focus();
            return false;
        }
        else if (Information.IsNumeric(cmbMM2.SelectedValue) == false)
        {
            cmbMM2.SelectedIndex = 0;
            lblMainMsg.Text = "Select valid month for To Date !!";
            cmbMM2.Focus();
            return false;
        }
        else if (cmbYY2.SelectedIndex == 0)
        {
            lblMainMsg.Text = "Select year for To Date !!";
            cmbYY2.Focus();
            return false;
        }
        else if (Information.IsNumeric(cmbYY2.SelectedValue) == false)
        {
            cmbYY2.SelectedIndex = 0;
            lblMainMsg.Text = "Select valid year for To Date !!";
            cmbYY2.Focus();
            return false;
        }
        else
        {
            lblMainMsg.Text = "";
            return true;
        }
    }

    public void bind_AuditGrid()
    {
        try
        {
            string M1;
            string M2;
            if (cmbMM1.SelectedValue.Length < 2)
            {
                M1 = (00 + cmbMM1.SelectedValue);
            }
            else
            {
                M1 = cmbMM1.SelectedValue;
            }
            if (cmbMM2.SelectedValue.Length < 2)
            {
                M2 = (00 + cmbMM1.SelectedValue);
            }
            else
            {
                M2 = cmbMM2.SelectedValue;
            }

            string frmdt = M1 + "/" + cmbDD1.SelectedValue + "/" + cmbYY1.SelectedValue;
            //(00+cmbMM1.SelectedValue) + "/" + cmbDD1.SelectedValue + "/" + cmbYY1.SelectedValue;
            string todt = M2 + "/" + cmbDD2.SelectedValue + "/" + cmbYY2.SelectedValue;
            //(00+cmbMM2.SelectedValue) + "/" + cmbDD2.SelectedValue + "/" + cmbYY2.SelectedValue;

            int cnt1 = 0;
            con.Close();
            con.Open();
            cmd = new SqlCommand("proc_AuditTrail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strViewMode", cmbView.SelectedValue);
            cmd.Parameters.AddWithValue("@strTimeProd", cmbTimeProd.SelectedValue);
            if (ddluser.SelectedIndex > 0)
            {
            cmd.Parameters.AddWithValue("@id1", ddluser.SelectedIndex);
            }
            if(ddlpage.SelectedValue!="Select Web Page")
            {
            cmd.Parameters.AddWithValue("@Page", ddlpage.SelectedValue);
            }
            if (cmbTimeProd.SelectedValue == "Date Wise")
            {
                if (chk_validDates() == true)
                {
                    if (check_dates() == true)
                    {
                        if (compare_dates() == true)
                        {
                            cmd.Parameters.AddWithValue("@strFrmDt", frmdt);
                            cmd.Parameters.AddWithValue("@strToDt", todt);
                            cmd.Parameters.AddWithValue("@strToday", "");
                            cmd.Parameters["@Mode"].Value = "CntAudit";
                            cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
                            con.Close();
                            lblMainMsg.Text = "";
                        }
                        else
                        {
                            lblMainMsg.Text = lblMainMsg.Text;
                            dg_audit.Visible = false;
                        }
                    }
                    else
                    {
                        lblMainMsg.Text = lblMainMsg.Text;
                        dg_audit.Visible = false;
                    }
                }
                else
                {
                    lblMainMsg.Text = lblMainMsg.Text;
                    dg_audit.Visible = false;
                }
            }
            else if (cmbTimeProd.SelectedValue == "Today")
            {
                cmd.Parameters.AddWithValue("@strFrmDt", "");
                cmd.Parameters.AddWithValue("@strToDt", "");
                cmd.Parameters.AddWithValue("@strToday", DateAndTime.Now.Date.ToString("MM/dd/yyyy"));
                cmd.Parameters["@Mode"].Value = "CntAudit";
                cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

            }
            else if (cmbTimeProd.SelectedValue == "All")
            {
                cmd.Parameters.AddWithValue("@strFrmDt", "");
                cmd.Parameters.AddWithValue("@strToDt", "");
                cmd.Parameters.AddWithValue("@strToday", "");
                cmd.Parameters["@Mode"].Value = "CntAudit";
                cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

            }

            if (cnt1 > 0)
            {
                con.Open();
                cmd = new SqlCommand("proc_AuditTrail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strViewMode", cmbView.SelectedValue);
                cmd.Parameters.AddWithValue("@strTimeProd", cmbTimeProd.SelectedValue);
                if (ddluser.SelectedIndex > 0)
                {
                    cmd.Parameters.AddWithValue("@id1", ddluser.SelectedIndex);
                }
                if (ddlpage.SelectedValue != "Select Web Page")
                {
                    cmd.Parameters.AddWithValue("@Page", ddlpage.SelectedValue);
                }
                if (cmbTimeProd.SelectedValue == "Date Wise")
                {
                    if (chk_validDates() == true)
                    {
                        if (check_dates() == true)
                        {
                            if (compare_dates() == true)
                            {
                                cmd.Parameters.AddWithValue("@strFrmDt", frmdt);
                                cmd.Parameters.AddWithValue("@strToDt", todt);
                                cmd.Parameters.AddWithValue("@strToday", "");
                                lblMainMsg.Text = "";
                            }
                            else
                            {
                                lblMainMsg.Text = lblMainMsg.Text;
                                dg_audit.Visible = false;
                            }
                        }
                        else
                        {
                            lblMainMsg.Text = lblMainMsg.Text;
                            dg_audit.Visible = false;
                        }
                    }
                    else
                    {
                        lblMainMsg.Text = lblMainMsg.Text;
                        dg_audit.Visible = false;
                    }
                }
                else if (cmbTimeProd.SelectedValue == "Today")
                {
                    cmd.Parameters.AddWithValue("@strFrmDt", "");
                    cmd.Parameters.AddWithValue("@strToDt", "");
                    cmd.Parameters.AddWithValue("@strToday", DateAndTime.Now.Date.ToString("MM/dd/yyyy"));

                }
                else if (cmbTimeProd.SelectedValue == "All")
                {
                    cmd.Parameters.AddWithValue("@strFrmDt", "");
                    cmd.Parameters.AddWithValue("@strToDt", "");
                    cmd.Parameters.AddWithValue("@strToday", "");
                }
                cmd.Parameters["@Mode"].Value = "ShowAudit";
                cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds, "tbl_Audit");
                con.Close();

                if (!(ds.Tables["tbl_Audit"].Rows.Count == 0))
                {
                    lblmsg.Text = ds.Tables["tbl_Audit"].Rows.Count + " Records found !!";
                    //lblmsg.Text = ""
                    dg_audit.Visible = true;

                    try
                    {
                        dg_audit.DataSource = ds.Tables["tbl_Audit"].DefaultView;
                        dg_audit.DataBind();
                    }
                    catch
                    {
                        try
                        {
                            this.dg_audit.CurrentPageIndex = 0;
                            this.dg_audit.DataBind();
                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex.ToString());
                        }
                    }
                }
                else
                {
                    dg_audit.DataSource = null;
                    dg_audit.DataBind();
                    dg_audit.Visible = false;
                    lblmsg.Text = "No Records Found !";
                }
            }
            else
            {
                dg_audit.DataSource = null;
                dg_audit.DataBind();
                dg_audit.Visible = false;
                lblmsg.Text = "No Records Found !";
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
    protected void btnSrch_Click(object sender, EventArgs e)
    {
        bind_AuditGrid();
    }
    protected void dg_audit_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.SelectedItem | e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.EditItem)
        {
            string name1 = "";
            //name1
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "lg_nm")) == false)
            {
                name1 = DataBinder.Eval(e.Item.DataItem, "lg_nm").ToString();
            }
            else
            {
                name1 = "--";
            }

            System.DateTime AuditDt = default(System.DateTime);
            string AuditDt1 = null;
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "AuditDt")) == false)
            {
                AuditDt = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "AuditDt"));
                AuditDt1 = AuditDt.ToString("dd/MM/yyyy h:mm:ss tt");
            }
            else
            {
                AuditDt1 = "--";
            }

            string remarks = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "remarks")) == false)
            {
                remarks = DataBinder.Eval(e.Item.DataItem, "remarks").ToString();
            }
            else
            {
                remarks = "--";
            }

            string ActDtls = "";
            ActDtls = "<strong>Action taken by :-</strong>" + "<br>" + name1 + "<br>" + "<strong>Action :-</strong>" + "<br>" + remarks;
            e.Item.Cells[2].Text = ActDtls;


            string module_name = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "module_name")) == false)
            {
                module_name = DataBinder.Eval(e.Item.DataItem, "module_name").ToString();
            }
            else
            {
                module_name = "--";
            }

            string page_name = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "page_name")) == false)
            {
                page_name = DataBinder.Eval(e.Item.DataItem, "page_name").ToString();
            }
            else
            {
                page_name = "--";
            }

            string table_name = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "table_name")) == false)
            {
                table_name = DataBinder.Eval(e.Item.DataItem, "table_name").ToString();
            }
            else
            {
                table_name = "--";
            }

            string ModDtls = "";
            ModDtls = "<strong>Module :-</strong>" + "<br>" + module_name + "<br>" + "<strong>Page :-</strong>" + "<br>" + page_name + "<br>" + "<strong>Table Name :-</strong>" + "<br>" + table_name;
            e.Item.Cells[3].Text = ModDtls;

            string PageDetails = "";
            string PageName = "";
            string PageType = "";
            string Parent = "";
            string Menu = "";
            string Menu1 = "";
            string Menu2 = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "field_names")) == false)
            {
                PageDetails = DataBinder.Eval(e.Item.DataItem, "field_names").ToString();
                string strPagename = PageDetails;
                string[] strPage = null;
                string sPageName = null;
                char[] splitchar = { ',' };
                strPage = strPagename.Split(splitchar);
                if (strPage.Length.Equals(3))
                {
                    strPage = strPagename.Split(splitchar);
                    sPageName = strPage[strPage.Length - 1];
                    PageType = "<br>" + sPageName;

                    strPage = strPagename.Split(splitchar);
                    sPageName = strPage[strPage.Length - 2];
                    Parent = "<br>" + sPageName;

                    strPage = strPagename.Split(splitchar);
                    sPageName = strPage[strPage.Length - 3];
                    PageName = sPageName;
                }
                else
                {

                    if (strPage.Length > 6)
                    {
                        strPage = strPagename.Split(splitchar);
                        sPageName = strPage[strPage.Length - 6];
                        PageName = sPageName;

                        strPage = strPagename.Split(splitchar);
                        sPageName = strPage[strPage.Length - 7];
                        PageName = sPageName + "<br>" + PageName;
                    }
                    else if (strPage.Length.Equals(6))
                    {
                        strPage = strPagename.Split(splitchar);
                        sPageName = strPage[strPage.Length - 2];
                        Menu1 = "<br>" + sPageName;

                        strPage = strPagename.Split(splitchar);
                        sPageName = strPage[strPage.Length - 3];
                        Menu = "<br>" + sPageName;

                        strPage = strPagename.Split(splitchar);
                        sPageName = strPage[strPage.Length - 4];
                        PageType = "<br>" + sPageName;

                        strPage = strPagename.Split(splitchar);
                        sPageName = strPage[strPage.Length - 5];
                        Parent = "<br>" + sPageName;

                        strPage = strPagename.Split(splitchar);
                        sPageName = strPage[strPage.Length - 6];
                        PageName = sPageName;
                    }
                    else if (strPage.Length.Equals(5))
                    {
                        strPage = strPagename.Split(splitchar);
                        sPageName = strPage[strPage.Length - 2];
                        Menu1 = "<br>" + sPageName;

                        strPage = strPagename.Split(splitchar);
                        sPageName = strPage[strPage.Length - 3];
                        Menu = "<br>" + sPageName;

                        strPage = strPagename.Split(splitchar);
                        sPageName = strPage[strPage.Length - 4];
                        PageType = "<br>" + sPageName;

                        strPage = strPagename.Split(splitchar);
                        sPageName = strPage[strPage.Length - 5];
                        Parent = sPageName;
                    }
                    else if (strPage.Length.Equals(4))
                    {
                        strPage = strPagename.Split(splitchar);
                        sPageName = strPage[strPage.Length - 2];
                        Menu1 = "<br>" + sPageName;

                        strPage = strPagename.Split(splitchar);
                        sPageName = strPage[strPage.Length - 3];
                        Menu = "<br>" + sPageName;

                        strPage = strPagename.Split(splitchar);
                        sPageName = strPage[strPage.Length - 4];
                        PageType = sPageName;
                    }
                    else if (strPage.Length.Equals(3))
                    {
                        strPage = strPagename.Split(splitchar);
                        sPageName = strPage[strPage.Length - 2];
                        Menu1 = "<br>" + sPageName;

                        strPage = strPagename.Split(splitchar);
                        sPageName = strPage[strPage.Length - 3];
                        Menu = sPageName;
                    }
                    else if (strPage.Length.Equals(2))
                    {
                        strPage = strPagename.Split(splitchar);
                        sPageName = strPage[strPage.Length - 2];
                        Menu1 = sPageName;
                    }
                    strPage = strPagename.Split(splitchar);
                    sPageName = strPage[strPage.Length - 1];
                    Menu2 = "<br>" + sPageName;
                }
            }
            else
            {
                PageDetails = "--";
            }
            e.Item.Cells[4].Text = PageName + Parent + PageType + Menu + Menu1 + Menu2;

            string ChangesDetails = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "UpdatedContent")) == false)
            {
                ChangesDetails = DataBinder.Eval(e.Item.DataItem, "UpdatedContent").ToString();
                ((Label)e.Item.Cells[5].FindControl("lblChangesDetails")).Text = ChangesDetails;
            }
            else
            {
                ((Label)e.Item.Cells[5].FindControl("lblChangesDetails")).Text = "--";
                ChangesDetails = "Changes details are not available!!!";
            }

            System.DateTime added_on = default(System.DateTime);
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "added_on")) == false)
            {
                added_on = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "added_on"));
                e.Item.Cells[6].Text = added_on.ToString("dd/MM/yyyy h:mm:ss tt");
            }
            else
            {
                e.Item.Cells[6].Text = "--";
            }

            System.DateTime updated_on = default(System.DateTime);
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "updated_on")) == false)
            {
                updated_on = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "updated_on"));
                e.Item.Cells[7].Text = updated_on.ToString("dd/MM/yyyy h:mm:ss tt");
            }
            else
            {
                e.Item.Cells[7].Text = "--";
            }

            System.DateTime checked_on = default(System.DateTime);
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "checked_on")) == false)
            {
                checked_on = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "checked_on"));
                e.Item.Cells[8].Text = checked_on.ToString("dd/MM/yyyy h:mm:ss tt");
            }
            else
            {
                e.Item.Cells[8].Text = "--";
            }
            System.DateTime deleted_on = default(System.DateTime);
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "deleted_on")) == false)
            {
                deleted_on = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "deleted_on"));
                e.Item.Cells[9].Text = deleted_on.ToString("dd/MM/yyyy h:mm:ss tt");
            }
            else
            {
                e.Item.Cells[9].Text = "--";
            }

            //System.DateTime archived_on = default(System.DateTime);
            //if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "archived_on")) == false)
            //{
            //    archived_on = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "archived_on"));
            //    e.Item.Cells[9].Text = archived_on.ToString("dd/MM/yyyy");
            //}
            //else
            //{
            //    e.Item.Cells[9].Text = "--";
            //}

            System.DateTime replied_on = default(System.DateTime);
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "replied_on")) == false)
            {
                replied_on = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "replied_on"));
                e.Item.Cells[10].Text = replied_on.ToString("dd/MM/yyyy h:mm:ss tt");
            }
            else
            {
                e.Item.Cells[10].Text = "--";
            }

            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "UpdatedContent")) == false)
            {
                ((LinkButton)e.Item.Cells[5].FindControl("lnkChangesMade")).Visible = true;
            }
            else
            {
                ((LinkButton)e.Item.Cells[5].FindControl("lnkChangesMade")).Visible = false;
            }
            //System.DateTime closed_on = default(System.DateTime);
            //if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "closed_on")) == false)
            //{
            //    closed_on = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "closed_on"));
            //    e.Item.Cells[11].Text = closed_on.ToString("dd/MM/yyyy");
            //}
            //else
            //{
            //    e.Item.Cells[11].Text = "--";
            //}
        }

    }
    public void Allbind_AuditGrid()
    {
        try
        {
            con.Close();
            con.Open();
            cmd = new SqlCommand("proc_AuditTrail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 20));
            cmd.Parameters["@Mode"].Value = "descview";

            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds, "tbl_Audit1");
            con.Close();

            if (!(ds.Tables["tbl_Audit1"].Rows.Count == 0))
            {
                lblmsg.Text = ds.Tables["tbl_Audit1"].Rows.Count + " Records found !!";
                //lblmsg.Text = ""
                dg_audit.Visible = true;

                try
                {
                    dg_audit.DataSource = ds.Tables["tbl_Audit1"].DefaultView;
                    dg_audit.DataBind();
                }
                catch
                {
                    try
                    {
                        this.dg_audit.CurrentPageIndex = 0;
                        this.dg_audit.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.ToString());
                    }
                }
            }
            else
            {
                dg_audit.DataSource = null;
                dg_audit.DataBind();
                dg_audit.Visible = false;
                lblmsg.Text = "No Records Found !";
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        clear_data();
        bind_AuditGrid();
        //Allbind_AuditGrid();
    }
    protected void cmbTimeProd_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbTimeProd.SelectedValue == "Today")
        {
            cmbDD1.Enabled = false;
            cmbMM1.Enabled = false;
            cmbYY1.Enabled = false;
            cmbDD2.Enabled = false;
            cmbMM2.Enabled = false;
            cmbYY2.Enabled = false;

            cmbDD1.SelectedIndex = 0;
            cmbMM1.SelectedIndex = 0;
            cmbYY1.SelectedIndex = 0;
            cmbDD2.SelectedIndex = 0;
            cmbMM2.SelectedIndex = 0;
            cmbYY2.SelectedIndex = 0;
        }
        else if (cmbTimeProd.SelectedValue == "All")
        {
            cmbDD1.Enabled = false;
            cmbMM1.Enabled = false;
            cmbYY1.Enabled = false;
            cmbDD2.Enabled = false;
            cmbMM2.Enabled = false;
            cmbYY2.Enabled = false;

            cmbDD1.SelectedIndex = 0;
            cmbMM1.SelectedIndex = 0;
            cmbYY1.SelectedIndex = 0;
            cmbDD2.SelectedIndex = 0;
            cmbMM2.SelectedIndex = 0;
            cmbYY2.SelectedIndex = 0;
        }
        else
        {
            cmbDD1.Enabled = true;
            cmbMM1.Enabled = true;
            cmbYY1.Enabled = true;
            cmbDD2.Enabled = true;
            cmbMM2.Enabled = true;
            cmbYY2.Enabled = true;
        }
    }
    protected void btnPageSize_Click(object sender, EventArgs e)
    {
        if (txtPageSize.Text != "" && !Regex.IsMatch(txtPageSize.Text.Trim(), "^[0-9]+$"))
        {
            lblmsg.Text = "Page size contains digits only.";
            txtPageSize.Focus();
        }
        else if (txtPageSize.Text != "" && txtPageSize.Text.Length > 3)
        {
            lblmsg.Text = "Page size contains maximum 3 digits.";
            txtPageSize.Focus();
        }
        else
        {

            if (string.IsNullOrEmpty(txtPageSize.Text))
            {
                txtPageSize.Text = "10";
            }
            else if (!string.IsNullOrEmpty(txtPageSize.Text) & Information.IsNumeric(txtPageSize.Text) == true)
            {
                if (txtPageSize.Text.Length > 0)
                {
                    dg_audit_indexSize();
                }
                else
                {
                    txtPageSize.Text = "";
                }
            }
        }
    }
    protected void btnPageIndex_Click(object sender, EventArgs e)
    {
        if (txtPageIndex.Text != "" && !Regex.IsMatch(txtPageIndex.Text.Trim(), "^[0-9]+$"))
        {
            lblmsg.Text = "Page index contains digits only.";
            txtPageIndex.Focus();
        }
        else if (txtPageIndex.Text != "" && txtPageIndex.Text.Length > 3)
        {
            lblmsg.Text = "Page index contains maximum 3 digits.";
            txtPageIndex.Focus();
        }
        else
        {
            if (string.IsNullOrEmpty(txtPageIndex.Text))
            {
                txtPageIndex.Text = "1";
            }
            else if (!string.IsNullOrEmpty(txtPageIndex.Text) & Information.IsNumeric(txtPageIndex.Text) == true)
            {
                if (txtPageIndex.Text.Length > 0)
                {
                    dg_audit_indexSize();
                }
                else
                {
                    txtPageIndex.Text = "";
                }
            }
        }
    }
    public void dg_audit_indexSize()
    {
        if (!string.IsNullOrEmpty(txtPageSize.Text))
        {
            if (!string.IsNullOrEmpty(txtPageSize.Text) & Information.IsNumeric(txtPageSize.Text) == true)
            {
                dg_audit.PageSize = Convert.ToInt32(txtPageSize.Text);
            }
        }

        int pg_index = 0;
        if (!string.IsNullOrEmpty(txtPageIndex.Text))
        {
            if (!string.IsNullOrEmpty(txtPageIndex.Text) & Information.IsNumeric(txtPageIndex.Text) == true)
            {
                pg_index = Convert.ToInt32(txtPageIndex.Text) - 1;
                dg_audit.CurrentPageIndex = pg_index;
            }
        }

        //bind_inward()
        bind_AuditGrid();

        string x1 = dg_audit.CurrentPageIndex.ToString();
        int currPage = Convert.ToInt32(x1) + 1;
        string x2 = dg_audit.PageCount.ToString();

        txtPageIndex.Text = currPage.ToString();
        lblPageIndex.Text = "Page" + " " + currPage + " " + "of" + " " + x2 + " " + ". Skip to page";

        if (string.IsNullOrEmpty(txtPageSize.Text))
        {
            int n = dg_audit.Items.Count;
            txtPageSize.Text = n.ToString();
        }
    }
    protected void dg_audit_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(txtPageSize.Text))
            {
                if (!string.IsNullOrEmpty(txtPageSize.Text) & Information.IsNumeric(txtPageSize.Text) == true)
                {
                    dg_audit.PageSize = Convert.ToInt32(txtPageSize.Text);
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

            dg_audit.CurrentPageIndex = e.NewPageIndex;
            //bind_inward()
            bind_AuditGrid();

            string x1 = dg_audit.CurrentPageIndex.ToString();
            int currPage = Convert.ToInt32(x1) + 1;
            string x2 = dg_audit.PageCount.ToString();

            txtPageIndex.Text = currPage.ToString();
            lblPageIndex.Text = "Page" + " " + currPage + " " + "of" + " " + x2 + " " + ". Skip to page";
            if (string.IsNullOrEmpty(txtPageSize.Text))
            {
                int n = dg_audit.Items.Count;
                txtPageSize.Text = n.ToString();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void dg_audit_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (!(e.CommandName == "Page"))
        {
            string pg_id_1 = e.Item.Cells[0].Text;

            if (e.CommandName == "PgChanges")
            {
                Session["PgId1"] = pg_id_1;
                Session["PgLanguage"] = "English";
                Response.Write("<script type='text/javascript'>detailedresults=window.open('PreviewChangesDetails.aspx','frmMensajeBox','scrollbars=yes, height=490px,width=800px,top=25,left=250');</script>");
            }
        }
    }
    protected void cmbView_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbView.SelectedIndex == 4)
        {
            ddlpage.Enabled = false;
        }
        else
        {
            ddlpage.Enabled = true;
        }
    }
    protected void dg_audit_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddluser_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}