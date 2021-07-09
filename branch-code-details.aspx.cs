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

public partial class branch_code_detailed : System.Web.UI.Page
{
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    System.Data.DataSet ds = new System.Data.DataSet();
    System.Data.DataSet ds1 = new System.Data.DataSet();
    SqlDataReader dr;
    public SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["TMBCON"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        string ID = Request.QueryString["id"];
        string chk = Session["id"].ToString();

        if (ID == Session["id"].ToString() && SecureQueryString(ID) == true)
        {
            filldetails(ID);
        }
        else
        {
            Response.Redirect("browser.htm");
        }
    }

    public bool SecureQueryString(string TexttoValidate)
    {
        string TextVal;
        int flag1 = 0;
        TextVal = TexttoValidate;
        // Build an array of characters that need to be filter.
        string[] strDirtyQueryString = new[] { "xp_", ";", "--", "<", ">", "script", "iframe", "delete", "drop table", "exec", "join", "select", "union", "../Web.config", "Web.config", "web.config", "web.Config", "../", "..", "where", "*", "]", "[", "--", "=", "create", "rename", "modify", "cast", "alter", "/script", "insert into", "delete from", "exec(", "declare", "cast(", "varchar", "sp_", "xp_", "@@", "update <ANY TABLE NAME YOU HAVE IN YOUR DATABASE>", "b.js" };
        // Loop through all items in the array 
        foreach (string item in strDirtyQueryString)
        {
            if (TextVal.IndexOf(item) != -1)
            {
                flag1 = 1;
                // HttpContext.Current.Response.Redirect("browser.htm")
                // PageRedirect(1);//Redirect to page not found.
                break;
            }
        }
        if (flag1 == 0)
            return true;
        else
            return false;
    }
    public void filldetails(string id)
    {
        int cnt1 = 0;
        con.Open();
        cmd = new SqlCommand("USP_BranchMaster", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@Query", SqlDbType.VarChar, 20));
        cmd.Parameters.AddWithValue("@Br_ID", id);
        cmd.Parameters["@Query"].Value = "CntBranch";
        cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
        con.Close();
        if (cnt1 > 0)
        {
            con.Open();
            cmd.Parameters["@Query"].Value = "BranchDetails";
            con.Close();
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds1 = new DataSet();
            da.Fill(ds1, "tbl_data5");
            if (!(ds1.Tables["tbl_data5"].Rows.Count == 0))
            {
                if (Information.IsDBNull(ds1.Tables["tbl_Data5"].Rows[0]["Br_Code"].ToString()) == false)
                {
                    lblBCode.Text = ds1.Tables["tbl_Data5"].Rows[0]["Br_Code"].ToString();
                }
                else
                {
                    lblBCode.Text = "";
                }

                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Br_Type"].ToString()) == false)
                {
                    lblBType.Text = ds1.Tables["tbl_data5"].Rows[0]["Br_Type"].ToString();
                }
                else
                {
                    lblBType.Text = "";
                }

                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Br_Name"].ToString()) == false)
                {
                    lblBName.Text = ds1.Tables["tbl_data5"].Rows[0]["Br_Name"].ToString();
                    Label2.Text = lblBName.Text;
                }
                else
                {
                    lblBName.Text = "";
                }


                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Address"].ToString()) == false)
                {
                    lblAdd.Text = ds1.Tables["tbl_data5"].Rows[0]["Address"].ToString();
                }
                else
                {
                    lblAdd.Text = "";
                }

                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Area"].ToString()) == true || ds1.Tables["tbl_data5"].Rows[0]["Area"].ToString() == "")
                {
                    area.Visible = false;
                    lblArea.Text = "";

                }
                else
                {
                    lblArea.Text = ds1.Tables["tbl_data5"].Rows[0]["Area"].ToString();
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["City"].ToString()) == false)
                {
                    lblCity.Text = ds1.Tables["tbl_data5"].Rows[0]["City"].ToString();
                }
                else
                {
                    lblCity.Text = "";
                }


                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Pin_Code"]) == false)
                {
                    lblpin.Text = ds1.Tables["tbl_data5"].Rows[0]["Pin_Code"].ToString();
                }
                else
                {
                    lblpin.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["District"]) == false)
                {
                    lblDistrict.Text = ds1.Tables["tbl_data5"].Rows[0]["District"].ToString();
                }
                else
                {
                    lblDistrict.Text = "";
                }

                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["State"]) == false)
                {
                    lblstate.Text = ds1.Tables["tbl_data5"].Rows[0]["State"].ToString();
                }
                else
                {
                    lblstate.Text = "";
                }

                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Country"].ToString()) == false)
                {
                    lblcountry.Text = ds1.Tables["tbl_data5"].Rows[0]["Country"].ToString();
                }
                else
                {
                    lblcountry.Text = "";
                }

                //Services / Facilities / Products Offered


                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Forex_Services"]) == false)
                {
                    lblForexService.Text = ds1.Tables["tbl_data5"].Rows[0]["Forex_Services"].ToString();
                }
                else
                {
                    //forex service row
                    ForexService.Visible = false;
                    lblForexService.Text = "";
                }

                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["NRI_Services"]) == false)
                {
                    lblNRI.Text = ds1.Tables["tbl_data5"].Rows[0]["NRI_Services"].ToString();
                }
                else
                {
                    NRI.Visible = false;
                    lblNRI.Text = "";
                }

                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["MICR_Code"]) == false)
                {
                    lblMICR.Text = ds1.Tables["tbl_data5"].Rows[0]["MICR_Code"].ToString();
                }
                else
                {
                    micr.Visible = false;
                    lblMICR.Text = "";
                }

                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["RTGS_IFSC_Code"]) == false)
                {
                    lblRTGS.Text = ds1.Tables["tbl_data5"].Rows[0]["RTGS_IFSC_Code"].ToString();
                }
                else
                {
                    rtgs.Visible = false;
                    lblRTGS.Text = "";
                }


                //ATM / eLobby Center

                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["ATM_Facility"]) == false)
                {
                    lblatmfac.Text = ds1.Tables["tbl_data5"].Rows[0]["ATM_Facility"].ToString();
                }
                else
                {
                    ATMFac.Visible = false;
                    lblatmfac.Text = "";
                }

                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Locker_Facility"]) == false)
                {
                    lblLocker.Text = ds1.Tables["tbl_data5"].Rows[0]["Locker_Facility"].ToString();
                }
                else
                {
                    lckrfac.Visible = false;
                    lblLocker.Text = "";
                }

                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["ASBA_Services"]) == false)
                {
                    lblASBA.Text = ds1.Tables["tbl_data5"].Rows[0]["ASBA_Services"].ToString();
                }
                else
                {
                    asba.Visible = false;
                    lblASBA.Text = "";
                }


                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Demat_Services"]) == false)
                {
                    lblDemat.Text = ds1.Tables["tbl_data5"].Rows[0]["Demat_Services"].ToString();
                }
                else
                {
                    demat.Visible = false;
                    lblDemat.Text = "";
                }

                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Mutual_Fund_Services"]) == false)
                {
                    lblMutual.Text = ds1.Tables["tbl_data5"].Rows[0]["Mutual_Fund_Services"].ToString();
                }
                else
                {
                    mutual.Visible = false;
                    lblMutual.Text = "";
                }

                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Anywhere_Banking"]) == false)
                {
                    lblAny.Text = ds1.Tables["tbl_data5"].Rows[0]["Anywhere_Banking"].ToString();
                }
                else
                {
                    any.Visible = false;
                    lblAny.Text = "";
                }

                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["ECS_Services"]) == false)
                {
                    lblECS.Text = ds1.Tables["tbl_data5"].Rows[0]["ECS_Services"].ToString();
                }
                else
                {
                    ecs.Visible = false;
                    lblECS.Text = "";
                }


                string CountryCode = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Country_Code"].ToString()) == false)
                {
                    CountryCode = ds1.Tables["tbl_data5"].Rows[0]["Country_Code"].ToString();
                }
                else
                {
                    CountryCode = "";
                }
                string StdCode = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Std_Code"].ToString()) == false)
                {
                    StdCode = ds1.Tables["tbl_data5"].Rows[0]["Std_Code"].ToString();
                }
                else
                {
                    StdCode = "";
                }
                if (StdCode.Equals(null))
                {
                    lblCode.Text = "+" + CountryCode + "(Country Code)";
                }
                else
                {

                    lblCode.Text = "+" + CountryCode + "(Country Code)" + " " + StdCode + "(Std Code)";
                }

                //Contact Info (Phone)
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Bill_Section"]) == false)
                {
                    lblBill.Text = ds1.Tables["tbl_data5"].Rows[0]["Bill_Section"].ToString();
                }
                else
                {
                    bill.Visible = false;
                    lblBill.Text = "";
                }

                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Board"]) == false)
                {
                    lblBoard.Text = ds1.Tables["tbl_data5"].Rows[0]["Board"].ToString();
                }
                else
                {
                    Board.Visible = false;
                    lblBoard.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Board1"]) == false)
                {
                    lblBoard1.Text = ds1.Tables["tbl_data5"].Rows[0]["Board1"].ToString();
                }
                else
                {
                    Board1.Visible = false;
                    lblBoard1.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Board2"]) == false)
                {
                    lblBoard2.Text = ds1.Tables["tbl_data5"].Rows[0]["Board2"].ToString();
                }
                else
                {
                    Board2.Visible = false;
                    lblBoard2.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Cash_Section"]) == false)
                {
                    lblCashSec.Text = ds1.Tables["tbl_data5"].Rows[0]["Cash_Section"].ToString();
                }
                else
                {
                    cash.Visible = false;
                    lblCashSec.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Clearing"]) == false)
                {
                    lblClear.Text = ds1.Tables["tbl_data5"].Rows[0]["Clearing"].ToString();
                }
                else
                {
                    clear.Visible = false;
                    lblClear.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["CTS_Clearing"]) == false)
                {
                    lblCTS.Text = ds1.Tables["tbl_data5"].Rows[0]["CTS_Clearing"].ToString();
                }
                else
                {
                    CTS.Visible = false;
                    lblCTS.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Current_AC"]) == false)
                {
                    lblcrntAC.Text = ds1.Tables["tbl_data5"].Rows[0]["Current_AC"].ToString();
                }
                else
                {
                    crntAC.Visible = false;
                    lblcrntAC.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Deposits"]) == false)
                {
                    lblDeposit.Text = ds1.Tables["tbl_data5"].Rows[0]["Deposits"].ToString();
                }
                else
                {
                    Deposit.Visible = false;
                    lblDeposit.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Direct"]) == false)
                {
                    lblDirect.Text = ds1.Tables["tbl_data5"].Rows[0]["Direct"].ToString();
                }
                else
                {
                    Direct.Visible = false;
                    lblDirect.Text = "";
                }

                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Forex"]) == false)
                {
                    lblFor.Text = ds1.Tables["tbl_data5"].Rows[0]["Forex"].ToString();
                }
                else
                {
                    For.Visible = false;
                    lblFor.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Landline"]) == false)
                {
                    lblLL.Text = ds1.Tables["tbl_data5"].Rows[0]["Landline"].ToString();
                }
                else
                {
                    LL.Visible = false;
                    lblLL.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Loan_Section"]) == false)
                {
                    lblLoan.Text = ds1.Tables["tbl_data5"].Rows[0]["Loan_Section"].ToString();
                }
                else
                {
                    Loan.Visible = false;
                    lblLoan.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Manager"]) == false)
                {
                    lblManager.Text = ds1.Tables["tbl_data5"].Rows[0]["Manager"].ToString();
                }
                else
                {
                    Manager.Visible = false;
                    lblManager.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Mobile"]) == false)
                {
                    lblMobile.Text = ds1.Tables["tbl_data5"].Rows[0]["Mobile"].ToString();
                }
                else
                {
                    Mobile.Visible = false;
                    lblMobile.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Residence"]) == false)
                {
                    lblRes.Text = ds1.Tables["tbl_data5"].Rows[0]["Residence"].ToString();
                }
                else
                {
                    res.Visible = false;
                    lblRes.Text = "";
                }

                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Savings_AC"]) == false)
                {
                    lblSaving.Text = ds1.Tables["tbl_data5"].Rows[0]["Savings_AC"].ToString();
                }
                else
                {
                    Sav.Visible = false;
                    lblSaving.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Spic_Nagar"]) == false)
                {
                    lblSpic.Text = ds1.Tables["tbl_data5"].Rows[0]["Spic_Nagar"].ToString();
                }
                else
                {
                    Spic.Visible = false;
                    lblSpic.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Sub_Manager"]) == false)
                {
                    lblSubM.Text = ds1.Tables["tbl_data5"].Rows[0]["Sub_Manager"].ToString();
                }
                else
                {
                    SUbM.Visible = false;
                    lblSubM.Text = "";
                }




                //string Mob = "";
                //if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Mobile"].ToString()) == false)
                //{

                //    Mob = ds1.Tables["tbl_data5"].Rows[0]["Mobile"].ToString();
                //    if (Mob == "")
                //    {
                //        Mob = "";

                //    }
                //    else
                //    {
                //        lblContact.Text = "Mobile : " + "( +" + CountryCode + " )" + Mob + "<br/>";
                //    }

                //}
                //else
                //{
                //    Mob = " ";
                //}


                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Fax_No"]) == false)
                {
                    lblfaxno.Text = ds1.Tables["tbl_data5"].Rows[0]["Fax_No"].ToString();
                }
                else
                {
                    Tr3.Visible = false;
                    CTFax1.Visible = false;
                    lblfaxno.Text = "";
                }

                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Email_ID"]) == false)
                {
                    lblEid.Text = ds1.Tables["tbl_data5"].Rows[0]["Email_ID"].ToString();
                }
                else
                {
                    ContactEid.Visible = false;
                    Eid.Visible = false;
                    lblEid.Text = "";
                }


            }
        }
    }
}