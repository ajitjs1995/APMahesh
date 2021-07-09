using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.VisualBasic;

public partial class tmbadm_Include_AdmMenu : System.Web.UI.UserControl
{
    DataSet ds = new DataSet();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["TMBCON"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        AllMenuDisable();
        AllTblHide(); ;

        if (string.IsNullOrEmpty(Convert.ToString(Session["log_name"])))
        {
            Session["usr_id"] = "";
            Session["log_name"] = "";
            Session["usr_dept"] = "";
            Session["usr_type"] = "";
            Session["usr_privilege"] = "";
            Session["current_mod"] = "";
            Session.Clear();
            Response.Redirect("TMBAdmin.aspx");

        }

        else
        {
            if (Convert.ToString(Session["usr_type"]) == "admin")
            {
                ///'''''''''''''''' if admin
                AllMenuEnable();
                GetCurrentMenu();
                lnkManageForexRates.Enabled = false;
                tblForex.Visible = false;
            }
           //else if (Convert.ToString(Session["usr_type"]) == "IBDAdmin")
           // {
                                
           //     lnkManageForexRates.Enabled = true;
           //     GetCurrentMenu();


           // }
            else
            {
                ///''''''''''''''''' if not admin

                Session["usr_id"] = Convert.ToString(Session["usr_id"]);
                Session["log_name"] = Convert.ToString(Session["log_name"]);
                Session["usr_dept"] = Convert.ToString(Session["usr_dept"]);

                if (Convert.ToString(Session["usr_type"]) == "Dept")
                {
                    //lnkInqNature.Visible = false;
                }
                else if (Convert.ToString(Session["usr_type"]) == "Branch")
                {
                    //lnkInqNature.Visible = false;
                }
               


                int cnt2 = 0;
                con.Open();
                cmd = new SqlCommand("Proc_AmdMods", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@strUsrNm", Convert.ToString(Session["log_name"]).Replace("'", "''").Replace("<", ""));
                cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 20));
                cmd.Parameters["@Mode"].Value = "CntUsrAuthChkr1";
                cnt2 = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

                if (cnt2 > 0)
                {
                    con.Open();
                    cmd = new SqlCommand("Proc_AmdMods", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@strUsrNm", Convert.ToString(Session["log_name"]).Replace("'", "''").Replace("<", ""));
                    cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 20));
                    cmd.Parameters["@Mode"].Value = "GetUsrAuthChkr1";
                    da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    ds = new DataSet();
                    da.Fill(ds, "tbl_auth");
                    con.Close();


                    if (!(ds.Tables["tbl_auth"].Rows.Count == 0))
                    {
                        int i = 0;

                        for (i = 0; i <= ds.Tables["tbl_auth"].Rows.Count - 1; i++)
                        {
                            string modnm = "";
                            if (Information.IsDBNull(ds.Tables["tbl_auth"].Rows[i]["mod_nm"]) == false)
                            {
                                modnm = ds.Tables["tbl_auth"].Rows[i]["mod_nm"].ToString();
                            }
                            else
                            {
                                modnm = "";
                            }
                            if (modnm == "Forex Rates")
                            {
                                lnkManageForexRates.Enabled = true;
                            }


                            if (modnm == "Administrator")
                            {
                                lnkManageadministration.Enabled = true;
                            }

                            if (modnm == "Download Library")
                            {
                            }

                            if (modnm == "CMS")
                            {
                                lnkManageCMS.Enabled = true;
                            }

                            if (modnm == "Master")
                            {
                                lnkManageMasters.Enabled = true;
                            }

                           

                            if (modnm == "Audit Trial")
                            {
                                lnkManageAudit.Enabled = true;
                            }
                        }
                        GetCurrentMenu();
                    }
                }
            }
        }
    }

    public void GetCurrentMenu()
    {

        if (Convert.ToString(Session["current_mod"]) == "Administrator")
        {
           tbl_administration.Visible = true;
        }
        else if (Convert.ToString(Session["current_mod"]) == "CMS")
        {
            tblCMS.Visible = true;
        }
        else if (Convert.ToString(Session["current_mod"]) == "Master")
        {
            TblMaster.Visible = true;
        }
        else if (Convert.ToString(Session["current_mod"]) == "Forex Rates")
        {
            tblForex.Visible=true;
        }
     
    }

    public void AllMenuEnable()
    {
        lnkManageadministration.Enabled = true;
        lnkManageCMS.Enabled = true;
        lnkManageMasters.Enabled = true;
        lnkManageForexRates.Enabled = true;
        
    }
   

    public void AllMenuDisable()
    {
        lnkManageadministration.Enabled = false;
        lnkManageCMS.Enabled = false;
        lnkManageMasters.Enabled = false;
        lnkManageForexRates.Enabled = false;


    }


    public void AllTblHide()
    {
        tbl_administration.Visible = false;
        tblCMS.Visible = false;
        TblMaster.Visible = false;
        tblForex.Visible = false;
        
    }
    protected void lnkManageadministration_Click(object sender, EventArgs e)
    {
        AllTblHide();
        Session["current_mod"] = "Administrator";
        tbl_administration.Visible = true;
        Response.Redirect("AdmMainPage.aspx");
    }
    protected void lnkManageCMS_Click(object sender, EventArgs e)
    {
        AllTblHide();
        Session["current_mod"] = "CMS";
        tblCMS.Visible = true;
        Response.Redirect("AdmMainPage.aspx");
    }
    protected void lnkManageInnerPg_Click(object sender, EventArgs e)
    {
        Session["current_mod"] = "CMS";
        Response.Redirect("Manage_InnerPage.aspx");
    }
    protected void lnkManageMasters_Click(object sender, EventArgs e)
    {
        AllTblHide();
        Session["current_mod"] = "Master";
        TblMaster.Visible = true;
        Response.Redirect("AdmMainPage.aspx");
    }
    protected void lnkManageForexRates_Click(object sender, EventArgs e)
    {
        AllTblHide();
        Session["current_mod"] = "Forex Rates";
        tblForex.Visible = true;
        Response.Redirect("AdmMainPage.aspx");
    }
    protected void lnkManageAudit_Click(object sender, EventArgs e)
    {
        AllTblHide();
        Session["current_mod"] = "Audit Trial";
        Response.Redirect("ManageAuditTrail.aspx");
    }
    protected void lnkinnerpagebanner_Click(object sender, EventArgs e)
    {
        Session["current_mod"] = "CMS";
        Response.Redirect("Manage_Banner.aspx");
    }
    protected void lnkpress_Click(object sender, EventArgs e)
    {
        AllTblHide();
        Session["current_mod"] = "Master";

        Response.Redirect("ManagePressRelease.aspx");
    }
    protected void lnksale_Click(object sender, EventArgs e)
    {
        AllTblHide();
        Session["current_mod"] = "Master";

        Response.Redirect("ManageSaleNotice.aspx");
    }


    protected void lnkMngLiveRates_Click(object sender, EventArgs e)
    {
        
        Session["current_mod"] = "Forex Rates";
        Response.Redirect("Manage_ForexRates.aspx");
    }

    protected void lnkMngTrendIndicators_Click(object sender, EventArgs e)
    {
        
        Session["current_mod"] = "Forex Rates";
        Response.Redirect("ManageTrendIndicatorsINR.aspx");
    }

    protected void lnkMngIFCR_Click(object sender, EventArgs e)
    {
        
        Session["current_mod"] = "Forex Rates";
        Response.Redirect("Manage_IFCRates.aspx");
    }

    protected void lnkMngCardRates_Click(object sender, EventArgs e)
    {
       
        Session["current_mod"] = "Forex Rates";
        Response.Redirect("Manage_CardRates.aspx");
    }
    protected void Lnkmangeruser_Click(object sender, EventArgs e)
    {
        Session["current_mod"] = "Administrator";
        Response.Redirect("ManageUsers.aspx");
    }
}