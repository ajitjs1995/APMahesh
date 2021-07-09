using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Globalization;
using Microsoft.VisualBasic;

public partial class archieve_forex_rates_new : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["TMBCON"]);
    SqlCommand cmd = new SqlCommand();

    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    DataTable dt = new DataTable();
    DataTable dtdate = new DataTable();
    private IEnumerable<DataRow> duplicateList;
    private object hTable;
    DataTable dTable = new DataTable();
    DataTable dTable1 = new DataTable();
    int cnt = 0;
    int id;
    string strMessage = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            BindGrid();
            BindGridData();
            fill_Content();
            BindCardRates();
        }
    }

    public void BindGrid()
    {
        try
        {

            con.Open();
            cmd = new SqlCommand("USP_UpdateIndFwdCrossRates", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@QueryType", "Show");
            DataTable dtShow = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dtShow);
            if (dtShow.Rows.Count > 0)
            {
                tblGrid.Visible = true;
                if (Information.IsDBNull(dtShow.Rows[0]["USIREx"]) == false)
                {
                    lblUSIREx.Text = dtShow.Rows[0]["USIREx"].ToString();
                }
                else
                {
                    lblUSIREx.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["USIRIm"]) == false)
                {
                    lblUSIRIm.Text = dtShow.Rows[0]["USIRIm"].ToString();
                }
                else
                {
                    lblUSIRIm.Text = "0.0000";
                }

                if (Information.IsDBNull(dtShow.Rows[0]["USICREx"]) == false)
                {
                    lblUSICREx.Text = dtShow.Rows[0]["USICREx"].ToString();
                }
                else
                {
                    lblUSICREx.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["USIFREx"]) == false)
                {
                    lblUSIFREx.Text = dtShow.Rows[0]["USIFREx"].ToString();
                }
                else
                {
                    lblUSIFREx.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["USIFRIm"]) == false)
                {
                    lblUSIFRIm.Text = dtShow.Rows[0]["USIFRIm"].ToString();
                }
                else
                {
                    lblUSIFRIm.Text = "0.0000";
                }

                if (Information.IsDBNull(dtShow.Rows[0]["USICRIm"]) == false)
                {
                    lblUSICRIm.Text = dtShow.Rows[0]["USICRIm"].ToString();
                }
                else
                {
                    lblUSICRIm.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["MonthUS"]) == false)
                {
                    lblUSMonth.Text = dtShow.Rows[0]["MonthUS"].ToString();
                }
                else
                {
                    lblUSMonth.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["GBIREx"]) == false)
                {
                    lblGBIREx.Text = dtShow.Rows[0]["GBIREx"].ToString();
                }
                else
                {
                    lblGBIREx.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["GBIRIm"]) == false)
                {
                    lblGBIRIm.Text = dtShow.Rows[0]["GBIRIm"].ToString();
                }
                else
                {
                    lblGBIRIm.Text = "0.0000";
                }

                if (Information.IsDBNull(dtShow.Rows[0]["GBICREx"]) == false)
                {
                    lblGBICREx.Text = dtShow.Rows[0]["GBICREx"].ToString();
                }
                else
                {
                    lblGBICREx.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["GBIFREx"]) == false)
                {
                    lblGBIFREx.Text = dtShow.Rows[0]["GBIFREx"].ToString();
                }
                else
                {
                    lblGBIFREx.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["GBIFRIm"]) == false)
                {
                    lblGBIFRIm.Text = dtShow.Rows[0]["GBIFRIm"].ToString();
                }
                else
                {
                    lblGBIFRIm.Text = "0.0000";
                }

                if (Information.IsDBNull(dtShow.Rows[0]["GBICRIm"]) == false)
                {
                    lblGBICRIm.Text = dtShow.Rows[0]["GBICRIm"].ToString();
                }
                else
                {
                    lblGBICRIm.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["GBMonth"]) == false)
                {
                    lblGBMonth.Text = dtShow.Rows[0]["GBMonth"].ToString();
                }
                else
                {
                    lblGBMonth.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["EuroIREx"]) == false)
                {
                    lblEuroIREx.Text = dtShow.Rows[0]["EuroIREx"].ToString();
                }
                else
                {
                    lblEuroIREx.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["EuroIRIm"]) == false)
                {
                    lblEuroIRIm.Text = dtShow.Rows[0]["EuroIRIm"].ToString();
                }
                else
                {
                    lblEuroIRIm.Text = "0.0000";
                }

                if (Information.IsDBNull(dtShow.Rows[0]["EuroICREx"]) == false)
                {
                    lblEuroICREx.Text = dtShow.Rows[0]["EuroICREx"].ToString();
                }
                else
                {
                    lblEuroICREx.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["EuroIFREx"]) == false)
                {
                    lblEuroIFREx.Text = dtShow.Rows[0]["EuroIFREx"].ToString();
                }
                else
                {
                    lblEuroIFREx.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["EuroIFRIm"]) == false)
                {
                    lblEuroIFRIm.Text = dtShow.Rows[0]["EuroIFRIm"].ToString();
                }
                else
                {
                    lblEuroIFRIm.Text = "0.0000";
                }

                if (Information.IsDBNull(dtShow.Rows[0]["EuroICRIm"]) == false)
                {
                    lblEuroICRIm.Text = dtShow.Rows[0]["EuroICRIm"].ToString();
                }
                else
                {
                    lblEuroICRIm.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["EuroMonth"]) == false)
                {
                    lblEuroMonth.Text = dtShow.Rows[0]["EuroMonth"].ToString();
                }
                else
                {
                    lblEuroMonth.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["JPYIREx"]) == false)
                {
                    lblJPYIREx.Text = dtShow.Rows[0]["JPYIREx"].ToString();
                }
                else
                {
                    lblJPYIREx.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["JPYIRIm"]) == false)
                {
                    lblJPYIRIm.Text = dtShow.Rows[0]["JPYIRIm"].ToString();
                }
                else
                {
                    lblJPYIRIm.Text = "0.0000";
                }

                if (Information.IsDBNull(dtShow.Rows[0]["JPYICREx"]) == false)
                {
                    lblJPYICREx.Text = dtShow.Rows[0]["JPYICREx"].ToString();
                }
                else
                {
                    lblJPYICREx.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["JPYIFREx"]) == false)
                {
                    lblJPYIFREx.Text = dtShow.Rows[0]["JPYIFREx"].ToString();
                }
                else
                {
                    lblJPYIFREx.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["JPYIFRIm"]) == false)
                {
                    lblJPYIFRIm.Text = dtShow.Rows[0]["JPYIFRIm"].ToString();
                }
                else
                {
                    lblJPYIFRIm.Text = "0.0000";
                }

                if (Information.IsDBNull(dtShow.Rows[0]["JPYICRIm"]) == false)
                {
                    lblJPYICRIm.Text = dtShow.Rows[0]["JPYICRIm"].ToString();
                }
                else
                {
                    lblJPYICRIm.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["JPYMonth"]) == false)
                {
                    lblJPYMonth.Text = dtShow.Rows[0]["JPYMonth"].ToString();
                }
                else
                {
                    lblJPYMonth.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["CHFIREx"]) == false)
                {
                    lblCHFIREx.Text = dtShow.Rows[0]["CHFIREx"].ToString();
                }
                else
                {
                    lblCHFIREx.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["CHFIRIm"]) == false)
                {
                    lblCHFIRIM.Text = dtShow.Rows[0]["CHFIRIm"].ToString();
                }
                else
                {
                    lblCHFIRIM.Text = "0.0000";
                }

                if (Information.IsDBNull(dtShow.Rows[0]["CHFICREx"]) == false)
                {
                    lblCHFICREx.Text = dtShow.Rows[0]["CHFICREx"].ToString();
                }
                else
                {
                    lblCHFICREx.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["CHFIFREx"]) == false)
                {
                    lblCHFIFREx.Text = dtShow.Rows[0]["CHFIFREx"].ToString();
                }
                else
                {
                    lblCHFIFREx.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["CHFIFRIm"]) == false)
                {
                    lblCHFIFRIm.Text = dtShow.Rows[0]["CHFIFRIm"].ToString();
                }
                else
                {
                    lblCHFIFRIm.Text = "0.0000";
                }

                if (Information.IsDBNull(dtShow.Rows[0]["CHFICRIm"]) == false)
                {
                    lblCHFICRIm.Text = dtShow.Rows[0]["CHFICRIm"].ToString();
                }
                else
                {
                    lblCHFICRIm.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["CHFMonth"]) == false)
                {
                    lblCHFMonth.Text = dtShow.Rows[0]["CHFMonth"].ToString();
                }
                else
                {
                    lblCHFMonth.Text = "0.0000";
                }
            }
            else
            {
                tblGrid.Visible = false;
            }
            con.Close();
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
    public void BindGridData()
    {
        try
        {

            con.Open();
            cmd = new SqlCommand("USP_UpdateTrendRates", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@QueryType", "Show");
            DataTable dtShow = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dtShow);
            if (dtShow.Rows.Count > 0)
            {
                tblGrid.Visible = true;
                if (Information.IsDBNull(dtShow.Rows[0]["PrevDayUS"]) == false)
                {
                    lblPreUS.Text = dtShow.Rows[0]["PrevDayUS"].ToString();
                }
                else
                {
                    lblPreUS.Text = " ---- ";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["PrevDayEuro"]) == false)
                {
                    lblPreEURO.Text = dtShow.Rows[0]["PrevDayEuro"].ToString();
                }
                else
                {
                    lblPreEURO.Text = " ---- ";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["PrevDayGB"]) == false)
                {
                    lblPreGB.Text = dtShow.Rows[0]["PrevDayGB"].ToString();
                }
                else
                {
                    lblPreGB.Text = " ---- ";
                }

                if (Information.IsDBNull(dtShow.Rows[0]["TodayUS"]) == false)
                {
                    lblTodUS.Text = dtShow.Rows[0]["TodayUS"].ToString();
                }
                else
                {
                    lblTodUS.Text = " ---- ";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["TodayEuro"]) == false)
                {
                    lblTodEURO.Text = dtShow.Rows[0]["TodayEuro"].ToString();
                }
                else
                {
                    lblTodEURO.Text = " ---- ";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["TodayGB"]) == false)
                {
                    lblTodGB.Text = dtShow.Rows[0]["TodayGB"].ToString();
                }
                else
                {
                    lblTodGB.Text = " ---- ";
                }


                if (Information.IsDBNull(dtShow.Rows[0]["TRUS"]) == false)
                {
                    lblRanUS.Text = dtShow.Rows[0]["TRUS"].ToString();
                }
                else
                {
                    lblRanUS.Text = " ---- ";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["TREuro"]) == false)
                {
                    lblRanEURO.Text = dtShow.Rows[0]["TREuro"].ToString();
                }
                else
                {
                    lblRanEURO.Text = " ---- ";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["TRGB"]) == false)
                {
                    lblRanGB.Text = dtShow.Rows[0]["TRGB"].ToString();
                }
                else
                {
                    lblRanGB.Text = " ---- ";
                }


                if (Information.IsDBNull(dtShow.Rows[0]["CMUS"]) == false)
                {
                    lblCurrUS.Text = dtShow.Rows[0]["CMUS"].ToString();
                }
                else
                {
                    lblCurrUS.Text = " ---- ";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["CMEuro"]) == false)
                {
                    lblCurrEURO.Text = dtShow.Rows[0]["CMEuro"].ToString();
                }
                else
                {
                    lblCurrEURO.Text = " ---- ";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["CMGB"]) == false)
                {
                    lblCurrGB.Text = dtShow.Rows[0]["CMGB"].ToString();
                }
                else
                {
                    lblCurrGB.Text = " ---- ";
                }
            }
            else
            {
                tblGrid.Visible = false;
            }
            con.Close();
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
    public void fill_Content()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand("Proc_TrendIndicator", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 50));

            cmd.Parameters["@Mode"].Value = "GetTrendCont";
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds1 = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds1, "tbl_data");
            if (ds1.Tables["tbl_data"].Rows.Count > 0)
            {

                if (Information.IsDBNull(ds1.Tables["tbl_data"].Rows[0]["id"]) == false)
                {
                    id = Convert.ToInt32(ds1.Tables["tbl_data"].Rows[0]["id"]);
                }


                if (Information.IsDBNull(ds1.Tables["tbl_data"].Rows[0]["Heading"]) == false)
                {
                    lblheading.Text = ds1.Tables["tbl_data"].Rows[0]["Heading"].ToString();
                }
                else
                {
                    lblheading.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data"].Rows[0]["Spot"]) == false)
                {
                    lblspot.Text = ds1.Tables["tbl_data"].Rows[0]["Spot"].ToString();
                }
                else
                {
                    lblspot.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data"].Rows[0]["Forword"]) == false)
                {
                    lblforpre.Text = ds1.Tables["tbl_data"].Rows[0]["Forword"].ToString();
                }
                else
                {
                    lblforpre.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data"].Rows[0]["Global"]) == false)
                {
                    lblglobal.Text = ds1.Tables["tbl_data"].Rows[0]["Global"].ToString();
                }
                else
                {
                    lblglobal.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data"].Rows[0]["Positive"]) == false)
                {
                    lblpostive.Text = ds1.Tables["tbl_data"].Rows[0]["Positive"].ToString();
                }
                else
                {
                    lblpostive.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data"].Rows[0]["Factor"]) == false)
                {
                    lblfactor.Text = ds1.Tables["tbl_data"].Rows[0]["Factor"].ToString();
                }
                else
                {
                    lblfactor.Text = "";
                }
            }
        }
        catch
        { }
        finally
        {
            con.Close();
        }
    }

    public void BindCardRates()
    {
        try
        {

            con.Open();
            cmd = new SqlCommand("USP_UpdateCardRates", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@QueryType", "show");
            DataTable dtshow = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dtshow);
            if (dtshow.Rows.Count > 0)
            {
               
                if (Information.IsDBNull(dtshow.Rows[0]["Header"]) == false)
                {

                    lblHeader.Text = dtshow.Rows[0]["Header"].ToString();
                }
                else
                {
                    lblHeader.Text = "";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["USBTT"]) == false)
                {
                    lblUSBTT.Text = dtshow.Rows[0]["USBTT"].ToString();

                }
                else
                {
                    lblUSBTT.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["USBBills"]) == false)
                {
                    lblUSBBill.Text = dtshow.Rows[0]["USBBills"].ToString();

                }
                else
                {
                    lblUSBBill.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["USBChq"]) == false)
                {
                    lblUSBChq.Text = dtshow.Rows[0]["USBChq"].ToString();

                }
                else
                {
                    lblUSBChq.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["USSBills"]) == false)
                {
                    lblUSSBill.Text = dtshow.Rows[0]["USSBills"].ToString();

                }
                else
                {
                    lblUSSBill.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["USSTT"]) == false)
                {
                    lblUSSTT.Text = dtshow.Rows[0]["USSTT"].ToString();

                }
                else
                {
                    lblUSSTT.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["GBBTT"]) == false)
                {
                    lblGBPBTT.Text = dtshow.Rows[0]["GBBTT"].ToString();

                }
                else
                {
                    lblGBPBTT.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["GBBBills"]) == false)
                {
                    lblGBPBBill.Text = dtshow.Rows[0]["GBBBills"].ToString();

                }
                else
                {
                    lblGBPBBill.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["GBBChq"]) == false)
                {
                    lblGBPBChq.Text = dtshow.Rows[0]["GBBChq"].ToString();

                }
                else
                {
                    lblGBPBChq.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["GBSBills"]) == false)
                {
                    lblGBPSBill.Text = dtshow.Rows[0]["GBSBills"].ToString();

                }
                else
                {
                    lblGBPSBill.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["GBSTT"]) == false)
                {
                    lblGBPSTT.Text = dtshow.Rows[0]["GBSTT"].ToString();

                }
                else
                {
                    lblGBPSTT.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["EURBTT"]) == false)
                {
                    lblEURBTT.Text = dtshow.Rows[0]["EURBTT"].ToString();

                }
                else
                {
                    lblEURBTT.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["EURBBills"]) == false)
                {
                    lblEURBBill.Text = dtshow.Rows[0]["EURBBills"].ToString();

                }
                else
                {
                    lblEURBBill.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["EURBChq"]) == false)
                {
                    lblEURBChq.Text = dtshow.Rows[0]["EURBChq"].ToString();

                }
                else
                {
                    lblEURBChq.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["EURSBills"]) == false)
                {
                    lblEURSBill.Text = dtshow.Rows[0]["EURSBills"].ToString();

                }
                else
                {
                    lblEURSBill.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["EURSTT"]) == false)
                {
                    lblEURSTT.Text = dtshow.Rows[0]["EURSTT"].ToString();

                }
                else
                {
                    lblEURSTT.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["JPYBTT"]) == false)
                {
                    lblJPYBTT.Text = dtshow.Rows[0]["JPYBTT"].ToString();

                }
                else
                {
                    lblJPYBTT.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["JPYBBills"]) == false)
                {
                    lblJPYBBill.Text = dtshow.Rows[0]["JPYBBills"].ToString();

                }
                else
                {
                    lblJPYBBill.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["JPYBChq"]) == false)
                {
                    lblJPYBChq.Text = dtshow.Rows[0]["JPYBChq"].ToString();

                }
                else
                {
                    lblJPYBChq.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["JPYSBills"]) == false)
                {
                    lblJPYSBill.Text = dtshow.Rows[0]["JPYSBills"].ToString();

                }
                else
                {
                    lblJPYSBill.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["JPYSTT"]) == false)
                {
                    lblJPYSTT.Text = dtshow.Rows[0]["JPYSTT"].ToString();

                }
                else
                {
                    lblJPYSTT.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["AUDBTT"]) == false)
                {
                    lblAUDBTT.Text = dtshow.Rows[0]["AUDBTT"].ToString();

                }
                else
                {
                    lblAUDBTT.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["AUDBBills"]) == false)
                {
                    lblAUDBBill.Text = dtshow.Rows[0]["AUDBBills"].ToString();

                }
                else
                {
                    lblAUDBBill.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["AUDBChq"]) == false)
                {
                    lblAUDBChq.Text = dtshow.Rows[0]["AUDBChq"].ToString();

                }
                else
                {
                    lblAUDBChq.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["AUDSBills"]) == false)
                {
                    lblAUDSBill.Text = dtshow.Rows[0]["AUDSBills"].ToString();

                }
                else
                {
                    lblAUDSBill.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["AUDSTT"]) == false)
                {
                    lblAUDSTT.Text = dtshow.Rows[0]["AUDSTT"].ToString();

                }
                else
                {
                    lblAUDSTT.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["CADBTT"]) == false)
                {
                    lblCADBTT.Text = dtshow.Rows[0]["CADBTT"].ToString();

                }
                else
                {
                    lblCADBTT.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["CADBBills"]) == false)
                {
                    lblCADBBill.Text = dtshow.Rows[0]["CADBBills"].ToString();

                }
                else
                {
                    lblCADBBill.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["CADBChq"]) == false)
                {
                    lblCADBChq.Text = dtshow.Rows[0]["CADBChq"].ToString();

                }
                else
                {
                    lblCADBChq.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["CADSBills"]) == false)
                {
                    lblCADSBill.Text = dtshow.Rows[0]["CADSBills"].ToString();

                }
                else
                {
                    lblCADSBill.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["CADSTT"]) == false)
                {
                    lblCADSTT.Text = dtshow.Rows[0]["CADSTT"].ToString();

                }
                else
                {
                    lblCADSTT.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["CHFBTT"]) == false)
                {
                    lblCHFBTT.Text = dtshow.Rows[0]["CHFBTT"].ToString();

                }
                else
                {
                    lblCHFBTT.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["CHFBBills"]) == false)
                {
                    lblCHFBBill.Text = dtshow.Rows[0]["CHFBBills"].ToString();

                }
                else
                {
                    lblCHFBBill.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["CHFBChq"]) == false)
                {
                    lblCHFBChq.Text = dtshow.Rows[0]["CHFBChq"].ToString();

                }
                else
                {
                    lblCHFBChq.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["CHFSBills"]) == false)
                {
                    lblCHFSBill.Text = dtshow.Rows[0]["CHFSBills"].ToString();

                }
                else
                {
                    lblCHFSBill.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["CHFSTT"]) == false)
                {
                    lblCHFSTT.Text = dtshow.Rows[0]["CHFSTT"].ToString();

                }
                else
                {
                    lblCHFSTT.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["SGDBTT"]) == false)
                {
                    lblSGDBTT.Text = dtshow.Rows[0]["SGDBTT"].ToString();

                }
                else
                {
                    lblSGDBTT.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["SGDBBills"]) == false)
                {
                    lblSGDBBill.Text = dtshow.Rows[0]["SGDBBills"].ToString();

                }
                else
                {
                    lblSGDBBill.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["SGDBChq"]) == false)
                {
                    lblSGDBChq.Text = dtshow.Rows[0]["SGDBChq"].ToString();

                }
                else
                {
                    lblSGDBChq.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["SGDSBills"]) == false)
                {
                    lblSGDSBill.Text = dtshow.Rows[0]["SGDSBills"].ToString();

                }
                else
                {
                    lblSGDSBill.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["SGDSTT"]) == false)
                {
                    lblSGDSTT.Text = dtshow.Rows[0]["SGDSTT"].ToString();

                }
                else
                {
                    lblSGDSTT.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["AEDBTT"]) == false)
                {
                    lblAEDBTT.Text = dtshow.Rows[0]["AEDBTT"].ToString();

                }
                else
                {
                    lblAEDBTT.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["AEDBBills"]) == false)
                {
                    lblAEDBBill.Text = dtshow.Rows[0]["AEDBBills"].ToString();

                }
                else
                {
                    lblAEDBBill.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["AEDBChq"]) == false)
                {
                    lblAEDBChq.Text = dtshow.Rows[0]["AEDBChq"].ToString();

                }
                else
                {
                    lblAEDBChq.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["AEDSBills"]) == false)
                {
                    lblAEDSBill.Text = dtshow.Rows[0]["AEDSBills"].ToString();

                }
                else
                {
                    lblAEDSBill.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["AEDSTT"]) == false)
                {
                    lblAEDSTT.Text = dtshow.Rows[0]["AEDSTT"].ToString();

                }
                else
                {
                    lblAEDSTT.Text = "0.0000";
                }

                if (Information.IsDBNull(dtshow.Rows[0]["USDCCYBuying"]) == false)
                {
                    lblUSDCCYBuying.Text = dtshow.Rows[0]["USDCCYBuying"].ToString();

                }
                else
                {
                    lblUSDCCYBuying.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["USDCCYSelling"]) == false)
                {
                    lblUSDCCYSelling.Text = dtshow.Rows[0]["USDCCYSelling"].ToString();

                }
                else
                {
                    lblUSDCCYSelling.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["USDTCBuying"]) == false)
                {
                    lblUSDTCBuying.Text = dtshow.Rows[0]["USDTCBuying"].ToString();

                }
                else
                {
                    lblUSDTCBuying.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["USDTCSelling"]) == false)
                {
                    lblUSDTCSelling.Text = dtshow.Rows[0]["USDTCSelling"].ToString();

                }
                else
                {
                    lblUSDTCSelling.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["GBPCCYBuying"]) == false)
                {
                    lblGBPCCYBuying.Text = dtshow.Rows[0]["GBPCCYBuying"].ToString();

                }
                else
                {
                    lblGBPCCYBuying.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["GBPCCYSelling"]) == false)
                {
                    lblGBPCCYSelling.Text = dtshow.Rows[0]["GBPCCYSelling"].ToString();

                }
                else
                {
                    lblGBPCCYSelling.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["GBPTCBuying"]) == false)
                {
                    lblGBPTCBuying.Text = dtshow.Rows[0]["GBPTCBuying"].ToString();

                }
                else
                {
                    lblGBPTCBuying.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["GBPTCSelling"]) == false)
                {
                    lblGBPTCSelling.Text = dtshow.Rows[0]["GBPTCSelling"].ToString();

                }
                else
                {
                    lblGBPTCSelling.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["EURCCYBuying"]) == false)
                {
                    lblEURCCYBuying.Text = dtshow.Rows[0]["EURCCYBuying"].ToString();

                }
                else
                {
                    lblEURCCYBuying.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["EURCCYSelling"]) == false)
                {
                    lblEURCCYSelling.Text = dtshow.Rows[0]["EURCCYSelling"].ToString();

                }
                else
                {
                    lblEURCCYSelling.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["EURTCBuying"]) == false)
                {
                    lblEURTCBuying.Text = dtshow.Rows[0]["EURTCBuying"].ToString();

                }
                else
                {
                    lblEURTCBuying.Text = "0.0000";
                }
                if (Information.IsDBNull(dtshow.Rows[0]["EURTCSelling"]) == false)
                {
                    lblEURTCSelling.Text = dtshow.Rows[0]["EURTCSelling"].ToString();

                }
                else
                {
                    lblEURTCSelling.Text = "0.0000";
                }
            }
            
        }
        catch (Exception ex)
        {

            Response.Write(ex);
        }
        finally
        {

        }
    }
}