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

public partial class Admin_Office_Details : System.Web.UI.Page
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
        string QueryId = Request.QueryString["id"];

        if (!IsPostBack)
        {
            if (QueryId != "")
            {
                QueryId = (Request.QueryString["id"]).ToString();
            }

            if (SecureQueryString(QueryId) == false)
            {

                Response.Redirect("admin-offices.aspx");
            }
            else
            {

                if (Convert.ToString(Session["id"]) != null || Convert.ToString(Session["id"]) != "")
                {
                    string id = null;
                    id = Convert.ToString(Session["id"]);
                    filldetails(id);
                }
            }
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
        cmd = new SqlCommand("USP_RegionalMaster", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@Query", SqlDbType.VarChar, 20));
        cmd.Parameters.AddWithValue("@RO_ID", id);
        cmd.Parameters["@Query"].Value = "CntRegionDtls";
        cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
        con.Close();
        if (cnt1 > 0)
        {
            con.Open();
            cmd.Parameters["@Query"].Value = "GetRegionDtls";
            con.Close();
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds1 = new DataSet();
            da.Fill(ds1, "tbl_data5");
            if (!(ds1.Tables["tbl_data5"].Rows.Count == 0))
            {
                if (Information.IsDBNull(ds1.Tables["tbl_Data5"].Rows[0]["No"].ToString()) == false)
                {
                    lblNo.Text = ds1.Tables["tbl_Data5"].Rows[0]["No"].ToString();
                }
                else
                {
                    lblNo.Text = "";
                }

                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Name"].ToString()) == false)
                {
                    lblName.Text = ds1.Tables["tbl_data5"].Rows[0]["Name"].ToString();
                }
                else
                {
                    lblName.Text = "";
                }


                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Address"].ToString()) == false)
                {
                    lblAdd.Text = ds1.Tables["tbl_data5"].Rows[0]["Address"].ToString();
                }
                else
                {
                    lblAdd.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["City"].ToString()) == false)
                {
                    lblCity.Text = ds1.Tables["tbl_data5"].Rows[0]["City"].ToString();
                }
                else
                {
                    lblCity.Text = "";
                }


                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["PinZipCode"]) == false)
                {
                    lblpin.Text = ds1.Tables["tbl_data5"].Rows[0]["PinZipCode"].ToString();
                }
                else
                {
                    lblpin.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["District "]) == false)
                {
                    lblstate.Text = ds1.Tables["tbl_data5"].Rows[0]["District "].ToString();
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
                string CountryCode = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["CountryCode"].ToString()) == false)
                {
                    CountryCode = ds1.Tables["tbl_data5"].Rows[0]["CountryCode"].ToString();
                }
                else
                {
                    CountryCode = "";
                }
                string StdCode = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["StdCode"].ToString()) == false)
                {
                    StdCode = ds1.Tables["tbl_data5"].Rows[0]["StdCode"].ToString();
                }
                else
                {
                    StdCode = "";
                }
                lblCode.Text = "+" + CountryCode + "(Country Code)" + " " + StdCode + "(Std Code)";

                string Mob = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Mobile"].ToString()) == false)
                {

                    Mob = ds1.Tables["tbl_data5"].Rows[0]["Mobile"].ToString();
                    if (Mob == "")
                    {
                        Mob = "";

                    }
                    else
                    {
                        lblContact.Text = "Mobile : " + "( +" + CountryCode + " )" + Mob + "<br/>";
                    }

                }
                else
                {
                    Mob = " ";
                }

                string RegionalManager = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["RegionalManager"].ToString()) == false)
                {

                    RegionalManager = ds1.Tables["tbl_data5"].Rows[0]["RegionalManager"].ToString();
                    if (RegionalManager == "")
                    {
                        RegionalManager = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "Regional Manager : " + "( +" + CountryCode + " " + StdCode + " )" + " " + RegionalManager + "<br/>";
                    }
                }
                else
                {
                    RegionalManager = "";
                }
                string ChiefManager = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["ChiefManager"].ToString()) == false)
                {

                    ChiefManager = ds1.Tables["tbl_data5"].Rows[0]["ChiefManager"].ToString();
                    if (ChiefManager == "")
                    {
                        ChiefManager = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "Chief Office : " + "( +" + CountryCode + " " + StdCode + " )" + " " + ChiefManager + "<br/>";
                    }
                }
                else
                {
                    ChiefManager = "";
                }
                string ChiefManager1 = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["ChiefManager1"].ToString()) == false)
                {

                    ChiefManager1 = ds1.Tables["tbl_data5"].Rows[0]["ChiefManager1"].ToString();
                    if (ChiefManager1 == "")
                    {
                        ChiefManager1 = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "Chief Manager : " + "( +" + CountryCode + " " + StdCode + " )" + " " + ChiefManager1 + "<br/>";
                    }
                }
                else
                {
                    ChiefManager1 = "";
                }
                string Board_Extn = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Board_Extn"].ToString()) == false)
                {

                    Board_Extn = ds1.Tables["tbl_data5"].Rows[0]["Board_Extn"].ToString();
                    if (Board_Extn == "")
                    {
                        Board_Extn = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "Board Extn : " + "( +" + CountryCode + " " + StdCode + " )" + " " + Board_Extn + "<br/>";
                    }
                }
                else
                {
                    Board_Extn = "";
                }

                string Principal = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Principal"].ToString()) == false)
                {

                    Principal = ds1.Tables["tbl_data5"].Rows[0]["Principal"].ToString();
                    if (Principal == "")
                    {
                        Principal = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "Principal : " + "( +" + CountryCode + " " + StdCode + " )" + " " + Principal + "<br/>";
                    }
                }
                else
                {
                    Principal = "";
                }

                string Board = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Board"].ToString()) == false)
                {

                    Board = ds1.Tables["tbl_data5"].Rows[0]["Board"].ToString();
                    if (Board == "")
                    {
                        Board = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "Board : " + "( +" + CountryCode + " " + StdCode + " )" + " " + Board + "<br/>";
                    }
                }
                else
                {
                    Board = "";
                }

                string Board_Mobile = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Board_Mobile"].ToString()) == false)
                {

                    Board_Mobile = ds1.Tables["tbl_data5"].Rows[0]["Board_Mobile"].ToString();
                    if (Board_Mobile == "")
                    {
                        Board_Mobile = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "Board : " + "( +" + CountryCode + " )" + " " + Board_Mobile + "<br/>";
                    }
                }
                else
                {
                    Board_Mobile = "";
                }

                string Board_01 = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Board_01"].ToString()) == false)
                {

                    Board_01 = ds1.Tables["tbl_data5"].Rows[0]["Board_01"].ToString();
                    if (Board_01 == "")
                    {
                        Board_01 = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "Board_01 : " + "( +" + CountryCode + " " + StdCode + " )" + " " + Board_01 + "<br/>";
                    }
                }
                else
                {
                    Board_01 = "";
                }

                string Board_02 = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Board_02"].ToString()) == false)
                {

                    Board_02 = ds1.Tables["tbl_data5"].Rows[0]["Board_02"].ToString();
                    if (Board_02 == "")
                    {
                        Board_02 = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "Board_02 : " + "( +" + CountryCode + " " + StdCode + " )" + " " + Board_02 + "<br/>";
                    }
                }
                else
                {
                    Board_02 = "";
                }

                string Board_03 = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Board_03"].ToString()) == false)
                {

                    Board_03 = ds1.Tables["tbl_data5"].Rows[0]["Board_03"].ToString();
                    if (Board_03 == "")
                    {
                        Board_03 = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "Board_03 : " + "( +" + CountryCode + " " + StdCode + " )" + " " + Board_03 + "<br/>";
                    }
                }
                else
                {
                    Board_03 = "";
                }

                string Board_04 = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Board_04"].ToString()) == false)
                {

                    Board_04 = ds1.Tables["tbl_data5"].Rows[0]["Board_04"].ToString();
                    if (Board_04 == "")
                    {
                        Board_04 = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "Board_04 : " + "( +" + CountryCode + " " + StdCode + " )" + " " + Board_04 + "<br/>";
                    }
                }
                else
                {
                    Board_04 = "";
                }

                string Board_05 = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Board_05"].ToString()) == false)
                {

                    Board_05 = ds1.Tables["tbl_data5"].Rows[0]["Board_05"].ToString();
                    if (Board_05 == "")
                    {
                        Board_05 = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "Board_05 : " + "( +" + CountryCode + " " + StdCode + " )" + " " + Board_05 + "<br/>";
                    }
                }
                else
                {
                    Board_05 = "";
                }

                string AdministrativeOfficer = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["AdministrativeOfficer"].ToString()) == false)
                {

                    AdministrativeOfficer = ds1.Tables["tbl_data5"].Rows[0]["AdministrativeOfficer"].ToString();
                    if (AdministrativeOfficer == "")
                    {
                        AdministrativeOfficer = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "Administrative Officer : " + "( +" + CountryCode + " " + StdCode + " )" + " " + AdministrativeOfficer + "<br/>";
                    }
                }
                else
                {
                    AdministrativeOfficer = "";
                }

                string Manager = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0][" Manager"].ToString()) == false)
                {

                    Manager = ds1.Tables["tbl_data5"].Rows[0][" Manager"].ToString();
                    if (Manager == "")
                    {
                        Manager = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "Manager : " + "( +" + CountryCode + " " + StdCode + " )" + " " + Manager + "<br/>";
                    }
                }
                else
                {
                    Manager = "";
                }

                string Residence = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Residence"].ToString()) == false)
                {

                    Residence = ds1.Tables["tbl_data5"].Rows[0]["Residence"].ToString();
                    if (Residence == "")
                    {
                        Residence = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "Residence : " + "( +" + CountryCode + " " + StdCode + " )" + " " + Residence + "<br/>";
                    }
                }
                else
                {
                    Residence = "";
                }

                string Residence1 = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Residence1"].ToString()) == false)
                {

                    Residence1 = ds1.Tables["tbl_data5"].Rows[0]["Residence1"].ToString();
                    if (Residence1 == "")
                    {
                        Residence1 = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "Residence : " + "( +" + CountryCode + " " + StdCode + " )" + " " + Residence1 + "<br/>";
                    }
                }
                else
                {
                    Residence1 = "";
                }

                string ETaxCustomDuty = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["ETaxCustomDuty"].ToString()) == false)
                {

                    ETaxCustomDuty = ds1.Tables["tbl_data5"].Rows[0]["ETaxCustomDuty"].ToString();
                    if (ETaxCustomDuty == "")
                    {
                        ETaxCustomDuty = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "ETax Custom Duty : " + "( +" + CountryCode + " " + StdCode + " )" + " " + ETaxCustomDuty + "<br/>";
                    }
                }
                else
                {
                    ETaxCustomDuty = "";
                }

                string ATMCell = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["ATMCell"].ToString()) == false)
                {

                    ATMCell = ds1.Tables["tbl_data5"].Rows[0]["ATMCell"].ToString();
                    if (ATMCell == "")
                    {
                        ATMCell = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "ATM Cell : " + "( +" + CountryCode + " " + StdCode + " )" + " " + ATMCell + "<br/>";
                    }
                }
                else
                {
                    ATMCell = "";
                }

                string AsstGeneralManager = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["AsstGeneralManager"].ToString()) == false)
                {

                    AsstGeneralManager = ds1.Tables["tbl_data5"].Rows[0]["AsstGeneralManager"].ToString();
                    if (AsstGeneralManager == "")
                    {
                        AsstGeneralManager = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "Asst General Manager : " + "( +" + CountryCode + " " + StdCode + " )" + " " + AsstGeneralManager + "<br/>";
                    }
                }
                else
                {
                    AsstGeneralManager = "";
                }

                //string DGM = "";
                //if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["DGM"].ToString()) == false)
                //{

                //    DGM = ds1.Tables["tbl_data5"].Rows[0]["DGM"].ToString();
                //    if (DGM == "")
                //    {
                //        DGM = "";
                //    }
                //    else
                //    {
                //        lblContact.Text = lblContact.Text + "DGM : " + "( +" + CountryCode + " " + StdCode + " )" + " " + DGM + "<br/>";
                //    }
                //}
                //else
                //{
                //    DGM = "";
                //}

                //string DGM_2 = "";
                //if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["DGM_2"].ToString()) == false)
                //{

                //    DGM_2 = ds1.Tables["tbl_data5"].Rows[0]["DGM_2"].ToString();
                //    if (DGM_2 == "")
                //    {
                //        DGM_2 = "";
                //    }
                //    else
                //    {
                //        lblContact.Text = lblContact.Text + "DGM_2 : " + "( +" + CountryCode + " " + StdCode + " )" + " " + DGM_2 + "<br/>";
                //    }
                //}
                //else
                //{
                //    DGM_2 = "";
                //}

                string AGM = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["AGM"].ToString()) == false)
                {

                    AGM = ds1.Tables["tbl_data5"].Rows[0]["AGM"].ToString();
                    if (AGM == "")
                    {
                        AGM = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "AGM : " + "( +" + CountryCode + " " + StdCode + " )" + " " + AGM + "<br/>";
                    }
                }
                else
                {
                    AGM = "";
                }

                string BackOffice = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["BackOffice"].ToString()) == false)
                {

                    BackOffice = ds1.Tables["tbl_data5"].Rows[0]["BackOffice"].ToString();
                    if (BackOffice == "")
                    {
                        BackOffice = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "Back Office : " + "( +" + CountryCode + " " + StdCode + " )" + " " + BackOffice + "<br/>";
                    }
                }
                else
                {
                    BackOffice = "";
                }
                string DealingRoom = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["DealingRoom"].ToString()) == false)
                {

                    DealingRoom = ds1.Tables["tbl_data5"].Rows[0]["DealingRoom"].ToString();
                    if (DealingRoom == "")
                    {
                        DealingRoom = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "Dealing Room : " + "( +" + CountryCode + " " + StdCode + " )" + " " + DealingRoom + "<br/>";
                    }
                }
                else
                {
                    DealingRoom = "";
                }

                string DeputyGeneralManager = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["DGM"].ToString()) == false)
                {

                    DeputyGeneralManager = ds1.Tables["tbl_data5"].Rows[0]["DGM"].ToString();
                    if (DeputyGeneralManager == "")
                    {
                        DeputyGeneralManager = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "Deputy General Manager : " + "( +" + CountryCode + " " + StdCode + " )" + " " + DeputyGeneralManager + "<br/>";
                    }
                }
                else
                {
                    DeputyGeneralManager = "";
                }

                string Swift = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Swift"].ToString()) == false)
                {

                    Swift = ds1.Tables["tbl_data5"].Rows[0]["Swift"].ToString();
                    if (Swift == "")
                    {
                        Swift = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "Swift : " + "( +" + CountryCode + " " + StdCode + " )" + " " + Swift + "<br/>";
                    }
                }
                else
                {
                    Swift = "";
                }

                string Credit = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["Credit"].ToString()) == false)
                {

                    Credit = ds1.Tables["tbl_data5"].Rows[0]["Credit"].ToString();
                    if (Credit == "")
                    {
                        Credit = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "Credit : " + "( +" + CountryCode + " " + StdCode + " )" + " " + Credit + "<br/>";
                    }
                }
                else
                {
                    Credit = "";
                }

                string CM = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["CM"].ToString()) == false)
                {

                    CM = ds1.Tables["tbl_data5"].Rows[0]["CM"].ToString();
                    if (CM == "")
                    {
                        CM = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "CM : " + "( +" + CountryCode + " " + StdCode + " )" + " " + CM + "<br/>";
                    }
                }
                else
                {
                    CM = "";
                }

                string AO = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["AO"].ToString()) == false)
                {

                    AO = ds1.Tables["tbl_data5"].Rows[0]["AO"].ToString();
                    if (AO == "")
                    {
                        AO = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "AO : " + "( +" + CountryCode + " " + StdCode + " )" + " " + AO + "<br/>";
                    }
                }
                else
                {
                    AO = "";
                }

                string RM = "";
                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["RM"].ToString()) == false)
                {

                    RM = ds1.Tables["tbl_data5"].Rows[0]["RM"].ToString();
                    if (RM == "")
                    {
                        RM = "";
                    }
                    else
                    {
                        lblContact.Text = lblContact.Text + "RM : " + "( +" + CountryCode + " " + StdCode + " )" + " " + RM + "<br/>";
                    }
                }
                else
                {
                    RM = "";
                }

                if (Information.IsDBNull(ds1.Tables["tbl_data5"].Rows[0]["FaxNo"]) == false)
                {
                    lblfaxno.Text = "( +" + CountryCode + " " + StdCode + " )" + " " + ds1.Tables["tbl_data5"].Rows[0]["FaxNo"].ToString();
                }
                else
                {
                    lblfaxno.Text = "";
                    CTFax.Visible = false;
                    CTFax1.Visible = false;
                }
            }
        }
    }
}