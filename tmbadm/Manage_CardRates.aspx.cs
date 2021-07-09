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
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

public partial class tmbadm_Manage_CardRates : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["TMBCON"]);
    SqlCommand cmd = new SqlCommand();

    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    string strMessage = "";

    protected void Page_Load(object sender, EventArgs e)
    {        

        if (!Page.IsPostBack)
        {
            txtUSBTT.Attributes.Add("autocomplete", "off");
            txtUSBBill.Attributes.Add("autocomplete", "off");
            txtUSBChq.Attributes.Add("autocomplete", "off");
            txtUSSBill.Attributes.Add("autocomplete", "off");
            txtUSSTT.Attributes.Add("autocomplete", "off");


            txtGBPBTT.Attributes.Add("autocomplete", "off");
            txtGBPBBill.Attributes.Add("autocomplete", "off");
            txtGBPBChq.Attributes.Add("autocomplete", "off");
            txtGBPSBill.Attributes.Add("autocomplete", "off");
            txtGBPSTT.Attributes.Add("autocomplete", "off");


            txtEURBTT.Attributes.Add("autocomplete", "off");
            txtEURBBill.Attributes.Add("autocomplete", "off");
            txtEURBChq.Attributes.Add("autocomplete", "off");
            txtEURSBill.Attributes.Add("autocomplete", "off");
            txtEURSTT.Attributes.Add("autocomplete", "off");


            txtJPYBTT.Attributes.Add("autocomplete", "off");
            txtJPYBBill.Attributes.Add("autocomplete", "off");
            txtJPYBChq.Attributes.Add("autocomplete", "off");
            txtJPYSBill.Attributes.Add("autocomplete", "off");
            txtJPYSTT.Attributes.Add("autocomplete", "off");



            txtAUDBTT.Attributes.Add("autocomplete", "off");
            txtAUDBBill.Attributes.Add("autocomplete", "off");
            txtAUDBChq.Attributes.Add("autocomplete", "off");
            txtAUDSBill.Attributes.Add("autocomplete", "off");
            txtAUDSTT.Attributes.Add("autocomplete", "off");


            txtCADBTT.Attributes.Add("autocomplete", "off");
            txtCADBBill.Attributes.Add("autocomplete", "off");
            txtCADBChq.Attributes.Add("autocomplete", "off");
            txtCADSBill.Attributes.Add("autocomplete", "off");
            txtCADSTT.Attributes.Add("autocomplete", "off");


            txtCHFBTT.Attributes.Add("autocomplete", "off");
            txtCHFBBill.Attributes.Add("autocomplete", "off");
            txtCHFBChq.Attributes.Add("autocomplete", "off");
            txtCHFSBill.Attributes.Add("autocomplete", "off");
            txtCHFSTT.Attributes.Add("autocomplete", "off");


            txtSGDBTT.Attributes.Add("autocomplete", "off");
            txtSGDBBill.Attributes.Add("autocomplete", "off");
            txtSGDBChq.Attributes.Add("autocomplete", "off");
            txtSGDSBill.Attributes.Add("autocomplete", "off");
            txtSGDSTT.Attributes.Add("autocomplete", "off");


            txtAEDBTT.Attributes.Add("autocomplete", "off");
            txtAEDBBill.Attributes.Add("autocomplete", "off");
            txtAEDBChq.Attributes.Add("autocomplete", "off");
            txtAEDSBill.Attributes.Add("autocomplete", "off");
            txtAEDSTT.Attributes.Add("autocomplete", "off");


            txtUSDCCYBuying.Attributes.Add("autocomplete", "off");
            txtUSDCCYSelling.Attributes.Add("autocomplete", "off");
            txtUSDTCBuying.Attributes.Add("autocomplete", "off");
            txtUSDTCSelling.Attributes.Add("autocomplete", "off");


            txtGBPCCYBuying.Attributes.Add("autocomplete", "off");
            txtGBPCCYSelling.Attributes.Add("autocomplete", "off");
            txtGBPTCBuying.Attributes.Add("autocomplete", "off");
            txtGBPTCSelling.Attributes.Add("autocomplete", "off");


            txtEURCCYBuying.Attributes.Add("autocomplete", "off");
            txtEURCCYSelling.Attributes.Add("autocomplete", "off");
            txtEURTCBuying.Attributes.Add("autocomplete", "off");
            txtEURTCSelling.Attributes.Add("autocomplete", "off");

            BindGrid();          

        }
    }

    public void Update()
    {
        lblErr.Text = "";
        int cntNext = 0;
        int cntPrevious = 0;

        try
        {

            try
            {
                con.Open();
                lblErr.Text = "";
                cmd = new SqlCommand("USP_UpdateCardRates", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@QueryType", "MaxArchieveCnt");
                cntPrevious = Convert.ToInt32(cmd.ExecuteScalar());
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

            con.Open();
            lblErr.Text = "";
            SqlCommand cm = new SqlCommand();
            cm = new SqlCommand("USP_UpdateCardRates", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@QueryType", "Update");

            if (!string.IsNullOrEmpty(txtHeader.Text.Trim()))
            {
                cm.Parameters.AddWithValue("@strHeader", txtHeader.Text.ToString().Trim());
            }
            else
            {
                cm.Parameters.AddWithValue("@strHeader","");
            }




            if (!string.IsNullOrEmpty(txtUSBTT.Text))
            {
                cm.Parameters.AddWithValue("@strUSBTT", Convert.ToDouble(txtUSBTT.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strUSBTT", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtUSBBill.Text))
            {
                cm.Parameters.AddWithValue("@strUSBBills", Convert.ToDouble(txtUSBBill.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strUSBBills", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtUSBChq.Text))
            {
                cm.Parameters.AddWithValue("@strUSBChq", Convert.ToDouble(txtUSBChq.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strUSBChq", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtUSSBill.Text))
            {
                cm.Parameters.AddWithValue("@strUSSBills", Convert.ToDouble(txtUSSBill.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strUSSBills", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtUSSTT.Text))
            {
                cm.Parameters.AddWithValue("@strUSSTT", Convert.ToDouble(txtUSSTT.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strUSSTT", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtGBPBTT.Text))
            {
                cm.Parameters.AddWithValue("@strGBBTT", Convert.ToDouble(txtGBPBTT.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strGBBTT", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtGBPBBill.Text))
            {
                cm.Parameters.AddWithValue("@strGBBBills", Convert.ToDouble(txtGBPBBill.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strGBBBills", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtGBPBChq.Text))
            {
                cm.Parameters.AddWithValue("@strGBBChq", Convert.ToDouble(txtGBPBChq.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strGBBChq", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtGBPSBill.Text))
            {
                cm.Parameters.AddWithValue("@strGBSBills", Convert.ToDouble(txtGBPSBill.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strGBSBills", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtGBPSTT.Text))
            {
                cm.Parameters.AddWithValue("@strGBSTT", Convert.ToDouble(txtGBPSTT.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strGBSTT", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtEURBTT.Text))
            {
                cm.Parameters.AddWithValue("@strEURBTT", Convert.ToDouble(txtEURBTT.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strEURBTT", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtEURBBill.Text))
            {
                cm.Parameters.AddWithValue("@strEURBBills", Convert.ToDouble(txtEURBBill.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strEURBBills", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtEURBChq.Text))
            {
                cm.Parameters.AddWithValue("@strEURBChq", Convert.ToDouble(txtEURBChq.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strEURBChq", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtEURSBill.Text))
            {
                cm.Parameters.AddWithValue("@strEURSBills", Convert.ToDouble(txtEURSBill.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strEURSBills", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtEURSTT.Text))
            {
                cm.Parameters.AddWithValue("@strEURSTT", Convert.ToDouble(txtEURSTT.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strEURSTT", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtJPYBTT.Text))
            {
                cm.Parameters.AddWithValue("@strJPYBTT", Convert.ToDouble(txtJPYBTT.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strJPYBTT", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtJPYBBill.Text))
            {
                cm.Parameters.AddWithValue("@strJPYBBills", Convert.ToDouble(txtJPYBBill.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strJPYBBills", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtJPYBChq.Text))
            {
                cm.Parameters.AddWithValue("@strJPYBChq", Convert.ToDouble(txtJPYBChq.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strJPYBChq", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtJPYSBill.Text))
            {
                cm.Parameters.AddWithValue("@strJPYSBills", Convert.ToDouble(txtJPYSBill.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strJPYSBills", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtJPYSTT.Text))
            {
                cm.Parameters.AddWithValue("@strJPYSTT", Convert.ToDouble(txtJPYSTT.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strJPYSTT", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtAUDBTT.Text))
            {
                cm.Parameters.AddWithValue("@strAUDBTT", Convert.ToDouble(txtAUDBTT.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strAUDBTT", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtAUDBBill.Text))
            {
                cm.Parameters.AddWithValue("@strAUDBBills", Convert.ToDouble(txtAUDBBill.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strAUDBBills", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtAUDBChq.Text))
            {
                cm.Parameters.AddWithValue("@strAUDBChq", Convert.ToDouble(txtAUDBChq.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strAUDBChq", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtAUDSBill.Text))
            {
                cm.Parameters.AddWithValue("@strAUDSBills", Convert.ToDouble(txtAUDSBill.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strAUDSBills", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtAUDSTT.Text))
            {
                cm.Parameters.AddWithValue("@strAUDSTT", Convert.ToDouble(txtAUDSTT.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strAUDSTT", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtCADBTT.Text))
            {
                cm.Parameters.AddWithValue("@strCADBTT", Convert.ToDouble(txtCADBTT.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strCADBTT", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtCADBBill.Text))
            {
                cm.Parameters.AddWithValue("@strCADBBills", Convert.ToDouble(txtCADBBill.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strCADBBills", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtCADBChq.Text))
            {
                cm.Parameters.AddWithValue("@strCADBChq", Convert.ToDouble(txtCADBChq.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strCADBChq", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtCADSBill.Text))
            {
                cm.Parameters.AddWithValue("@strCADSBills", Convert.ToDouble(txtCADSBill.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strCADSBills", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtCADSTT.Text))
            {
                cm.Parameters.AddWithValue("@strCADSTT", Convert.ToDouble(txtCADSTT.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strCADSTT", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtCHFBTT.Text))
            {
                cm.Parameters.AddWithValue("@strCHFBTT", Convert.ToDouble(txtCHFBTT.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strCHFBTT", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtCHFBBill.Text))
            {
                cm.Parameters.AddWithValue("@strCHFBBills", Convert.ToDouble(txtCHFBBill.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strCHFBBills", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtCHFBChq.Text))
            {
                cm.Parameters.AddWithValue("@strCHFBChq", Convert.ToDouble(txtCHFBChq.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strCHFBChq", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtCHFSBill.Text))
            {
                cm.Parameters.AddWithValue("@strCHFSBills", Convert.ToDouble(txtCHFSBill.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strCHFSBills", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtCHFSTT.Text))
            {
                cm.Parameters.AddWithValue("@strCHFSTT", Convert.ToDouble(txtCHFSTT.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strCHFSTT", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtSGDBTT.Text))
            {
                cm.Parameters.AddWithValue("@strSGDBTT", Convert.ToDouble(txtSGDBTT.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strSGDBTT", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtSGDBBill.Text))
            {
                cm.Parameters.AddWithValue("@strSGDBBills", Convert.ToDouble(txtSGDBBill.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strSGDBBills", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtSGDBChq.Text))
            {
                cm.Parameters.AddWithValue("@strSGDBChq", Convert.ToDouble(txtSGDBChq.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strSGDBChq", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtSGDSBill.Text))
            {
                cm.Parameters.AddWithValue("@strSGDSBills", Convert.ToDouble(txtSGDSBill.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strSGDSBills", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtSGDSTT.Text))
            {
                cm.Parameters.AddWithValue("@strSGDSTT", Convert.ToDouble(txtSGDSTT.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strSGDSTT", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtAEDBTT.Text))
            {
                cm.Parameters.AddWithValue("@strAEDBTT", Convert.ToDouble(txtAEDBTT.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strAEDBTT", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtAEDBBill.Text))
            {
                cm.Parameters.AddWithValue("@strAEDBBills", Convert.ToDouble(txtAEDBBill.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strAEDBBills", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtAEDBChq.Text))
            {
                cm.Parameters.AddWithValue("@strAEDBChq", Convert.ToDouble(txtAEDBChq.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strAEDBChq", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtAEDSBill.Text))
            {
                cm.Parameters.AddWithValue("@strAEDSBills", Convert.ToDouble(txtAEDSBill.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strAEDSBills", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtAEDSTT.Text))
            {
                cm.Parameters.AddWithValue("@strAEDSTT", Convert.ToDouble(txtAEDSTT.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strAEDSTT", 0.0000);
            }


            
            if (!string.IsNullOrEmpty(txtUSDCCYBuying.Text))
            {
                cm.Parameters.AddWithValue("@strUSDCCYBuying", Convert.ToDouble(txtUSDCCYBuying.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strUSDCCYBuying", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtUSDCCYSelling.Text))
            {
                cm.Parameters.AddWithValue("@strUSDCCYSelling", Convert.ToDouble(txtUSDCCYSelling.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strUSDCCYSelling", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtUSDTCBuying.Text))
            {
                cm.Parameters.AddWithValue("@strUSDTCBuying", Convert.ToDouble(txtUSDTCBuying.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strUSDTCBuying", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtUSDTCSelling.Text))
            {
                cm.Parameters.AddWithValue("@strUSDTCSelling", Convert.ToDouble(txtUSDTCSelling.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strUSDTCSelling", 0.0000);
            }

            if (!string.IsNullOrEmpty(txtGBPCCYBuying.Text))
            {
                cm.Parameters.AddWithValue("@strGBPCCYBuying", Convert.ToDouble(txtGBPCCYBuying.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strGBPCCYBuying", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtGBPCCYSelling.Text))
            {
                cm.Parameters.AddWithValue("@strGBPCCYSelling", Convert.ToDouble(txtGBPCCYSelling.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strGBPCCYSelling", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtGBPTCBuying.Text))
            {
                cm.Parameters.AddWithValue("@strGBPTCBuying", Convert.ToDouble(txtGBPTCBuying.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strGBPTCBuying", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtGBPTCSelling.Text))
            {
                cm.Parameters.AddWithValue("@strGBPTCSelling", Convert.ToDouble(txtGBPTCSelling.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strGBPTCSelling", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtEURCCYBuying.Text))
            {
                cm.Parameters.AddWithValue("@strEURCCYBuying", Convert.ToDouble(txtEURCCYBuying.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strEURCCYBuying", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtEURCCYSelling.Text))
            {
                cm.Parameters.AddWithValue("@strEURCCYSelling", Convert.ToDouble(txtEURCCYSelling.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strEURCCYSelling", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtEURTCBuying.Text))
            {
                cm.Parameters.AddWithValue("@strEURTCBuying", Convert.ToDouble(txtEURTCBuying.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strEURTCBuying", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtEURTCSelling.Text))
            {
                cm.Parameters.AddWithValue("@strEURTCSelling", Convert.ToDouble(txtEURTCSelling.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strEURTCSelling", 0.0000);
            }

            cntNext = Convert.ToInt32(cm.ExecuteScalar());

            if (cntNext > cntPrevious)
            {
                lblErr.Text = "Card Rates Updated successfully";
                clear();
            }
            else
            {
                lblErr.Text = "Something went wrong while updating Rates";
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

    public bool Checkdata()
    {
        if (string.IsNullOrEmpty(txtHeader.Text))
        {
            strMessage += "Please Enter Header  <br />";
            txtHeader.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtHeader.Text) && txtHeader.Text.Trim().Length < 5)
        {
            strMessage += "Header Text lenght should be maximum  5 characters  <br />";
            txtHeader.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtHeader.Text) && !Regex.IsMatch(txtHeader.Text.Trim(), "^[a-zA-Z0-9-.:,& # /)(\r\n ]+$"))
        {
            strMessage += "Invalid Header Text <br />";
            txtHeader.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtUSBTT.Text.Trim()))
        {
            strMessage += "Please Enter USD Buying TT Value  <br />";
            txtUSBTT.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtUSBTT.Text.Trim()) && !Regex.IsMatch(txtUSBTT.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "USD Buying TT Value is In-Valid  <br />";
            txtUSBTT.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtUSBBill.Text.Trim()))
        {
            strMessage += "Please Enter USD Buying Billing Value  <br />";
            txtUSBBill.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtUSBBill.Text.Trim()) && !Regex.IsMatch(txtUSBBill.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "USD Buying Billing Value is In-Valid <br />";
            txtUSBBill.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtUSBChq.Text.Trim()))
        {
            strMessage += "Please Enter USD Buying Cheque Value  <br />";
            txtUSBChq.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtUSBChq.Text.Trim()) && !Regex.IsMatch(txtUSBChq.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "USD Buying Cheque Value is In-Valid <br />";
            txtUSBChq.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtUSSBill.Text.Trim()))
        {
            strMessage += "Please Enter USD Selling Bills Value  <br />";
            txtUSSBill.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtUSSBill.Text.Trim()) && !Regex.IsMatch(txtUSSBill.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "USD Selling Bills Value is In-Valid <br />";
            txtUSSBill.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtUSSTT.Text.Trim()))
        {
            strMessage += "Please Enter USD Selling TT Value  <br />";
            txtUSSTT.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtUSSTT.Text.Trim()) && !Regex.IsMatch(txtUSSTT.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "USD Selling TT Value is In-Valid <br />";
            txtUSSTT.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtGBPBTT.Text.Trim()))
        {
            strMessage += "Please Enter GBP Buying TT Value  <br />";
            txtGBPBTT.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtGBPBTT.Text.Trim()) && !Regex.IsMatch(txtGBPBTT.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "GBP Buying TT Value is In-Valid  <br />";
            txtGBPBTT.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtGBPBBill.Text.Trim()))
        {
            strMessage += "Please Enter GBP Buying Billing Value  <br />";
            txtGBPBBill.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtGBPBBill.Text.Trim()) && !Regex.IsMatch(txtGBPBBill.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "GBP Buying Billing Value is In-Valid <br />";
            txtGBPBBill.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtGBPBChq.Text.Trim()))
        {
            strMessage += "Please Enter GBP Buying Cheque Value  <br />";
            txtGBPBChq.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtGBPBChq.Text.Trim()) && !Regex.IsMatch(txtGBPBChq.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "GBP Buying Cheque Value is In-Valid <br />";
            txtGBPBChq.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtGBPSBill.Text.Trim()))
        {
            strMessage += "Please Enter GBP Selling Bills Value  <br />";
            txtGBPSBill.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtGBPSBill.Text.Trim()) && !Regex.IsMatch(txtGBPSBill.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "GBP Selling Bills Value is In-Valid <br />";
            txtGBPSBill.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtGBPSTT.Text.Trim()))
        {
            strMessage += "Please Enter GBP Selling TT Value  <br />";
            txtGBPSTT.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtGBPSTT.Text.Trim()) && !Regex.IsMatch(txtGBPSTT.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "GBP Selling TT Value is In-Valid <br />";
            txtGBPSTT.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtEURBTT.Text.Trim()))
        {
            strMessage += "Please Enter EURO Buying TT Value  <br />";
            txtEURBTT.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtEURBTT.Text.Trim()) && !Regex.IsMatch(txtEURBTT.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "EURO Buying TT Value is In-Valid  <br />";
            txtEURBTT.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtEURBBill.Text.Trim()))
        {
            strMessage += "Please Enter EURO Buying Billing Value  <br />";
            txtEURBBill.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtEURBBill.Text.Trim()) && !Regex.IsMatch(txtEURBBill.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "EURO Buying Billing Value is In-Valid <br />";
            txtEURBBill.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtEURBChq.Text.Trim()))
        {
            strMessage += "Please Enter EURO Buying Cheque Value  <br />";
            txtEURBChq.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtEURBChq.Text.Trim()) && !Regex.IsMatch(txtEURBChq.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "EURO Buying Cheque Value is In-Valid <br />";
            txtEURBChq.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtEURSBill.Text.Trim()))
        {
            strMessage += "Please Enter EURO Selling Bills Value  <br />";
            txtEURSBill.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtEURSBill.Text.Trim()) && !Regex.IsMatch(txtEURSBill.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "EURO Selling Bills Value is In-Valid <br />";
            txtEURSBill.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtEURSTT.Text.Trim()))
        {
            strMessage += "Please Enter EURO Selling TT Value  <br />";
            txtEURSTT.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtEURSTT.Text.Trim()) && !Regex.IsMatch(txtEURSTT.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "EURO Selling TT Value is In-Valid <br />";
            txtEURSTT.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtJPYBTT.Text.Trim()))
        {
            strMessage += "Please Enter JPY Buying TT Value  <br />";
            txtJPYBTT.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtJPYBTT.Text.Trim()) && !Regex.IsMatch(txtJPYBTT.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "JPY Buying TT Value is In-Valid  <br />";
            txtJPYBTT.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtJPYBBill.Text.Trim()))
        {
            strMessage += "Please Enter JPY Buying Billing Value  <br />";
            txtJPYBBill.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtJPYBBill.Text.Trim()) && !Regex.IsMatch(txtJPYBBill.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "JPY Buying Billing Value is In-Valid <br />";
            txtJPYBBill.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtJPYBChq.Text.Trim()))
        {
            strMessage += "Please Enter JPY Buying Cheque Value  <br />";
            txtJPYBChq.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtJPYBChq.Text.Trim()) && !Regex.IsMatch(txtJPYBChq.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "JPY Buying Cheque Value is In-Valid <br />";
            txtJPYBChq.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtJPYSBill.Text.Trim()))
        {
            strMessage += "Please Enter JPY Selling Bills Value  <br />";
            txtJPYSBill.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtJPYSBill.Text.Trim()) && !Regex.IsMatch(txtJPYSBill.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "JPY Selling Bills Value is In-Valid <br />";
            txtJPYSBill.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtJPYSTT.Text.Trim()))
        {
            strMessage += "Please Enter JPY Selling TT Value  <br />";
            txtJPYSTT.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtJPYSTT.Text.Trim()) && !Regex.IsMatch(txtJPYSTT.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "JPY Selling TT Value is In-Valid <br />";
            txtJPYSTT.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtAUDBTT.Text.Trim()))
        {
            strMessage += "Please Enter AUD Buying TT Value  <br />";
            txtAUDBTT.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtAUDBTT.Text.Trim()) && !Regex.IsMatch(txtAUDBTT.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "AUD Buying TT Value is In-Valid  <br />";
            txtAUDBTT.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtAUDBBill.Text.Trim()))
        {
            strMessage += "Please Enter AUD Buying Billing Value  <br />";
            txtAUDBBill.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtAUDBBill.Text.Trim()) && !Regex.IsMatch(txtAUDBBill.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "AUD Buying Billing Value is In-Valid <br />";
            txtAUDBBill.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtAUDBChq.Text.Trim()))
        {
            strMessage += "Please Enter AUD Buying Cheque Value  <br />";
            txtAUDBChq.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtAUDBChq.Text.Trim()) && !Regex.IsMatch(txtAUDBChq.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "AUD Buying Cheque Value is In-Valid <br />";
            txtAUDBChq.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtAUDSBill.Text.Trim()))
        {
            strMessage += "Please Enter AUD Selling Bills Value  <br />";
            txtAUDSBill.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtAUDSBill.Text.Trim()) && !Regex.IsMatch(txtAUDSBill.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "AUD Selling Bills Value is In-Valid <br />";
            txtAUDSBill.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtAUDSTT.Text.Trim()))
        {
            strMessage += "Please Enter AUD Selling TT Value  <br />";
            txtAUDSTT.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtAUDSTT.Text.Trim()) && !Regex.IsMatch(txtAUDSTT.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "AUD Selling TT Value is In-Valid <br />";
            txtAUDSTT.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtCADBTT.Text.Trim()))
        {
            strMessage += "Please Enter CAD Buying TT Value  <br />";
            txtCADBTT.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtCADBTT.Text.Trim()) && !Regex.IsMatch(txtCADBTT.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "CAD Buying TT Value is In-Valid  <br />";
            txtCADBTT.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtCADBBill.Text.Trim()))
        {
            strMessage += "Please Enter CAD Buying Billing Value  <br />";
            txtCADBBill.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtCADBBill.Text.Trim()) && !Regex.IsMatch(txtCADBBill.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "CAD Buying Billing Value is In-Valid <br />";
            txtCADBBill.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtCADBChq.Text.Trim()))
        {
            strMessage += "Please Enter CAD Buying Cheque Value  <br />";
            txtCADBChq.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtCADBChq.Text.Trim()) && !Regex.IsMatch(txtCADBChq.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "CAD Buying Cheque Value is In-Valid <br />";
            txtCADBChq.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtCADSBill.Text.Trim()))
        {
            strMessage += "Please Enter CAD Selling Bills Value  <br />";
            txtCADSBill.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtCADSBill.Text.Trim()) && !Regex.IsMatch(txtCADSBill.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "CAD Selling Bills Value is In-Valid <br />";
            txtCADSBill.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtCADSTT.Text.Trim()))
        {
            strMessage += "Please Enter CAD Selling TT Value  <br />";
            txtCADSTT.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtCADSTT.Text.Trim()) && !Regex.IsMatch(txtCADSTT.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "CAD Selling TT Value is In-Valid <br />";
            txtCADSTT.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtCHFBTT.Text.Trim()))
        {
            strMessage += "Please Enter CHF Buying TT Value  <br />";
            txtCHFBTT.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtCHFBTT.Text.Trim()) && !Regex.IsMatch(txtCHFBTT.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "CHF Buying TT Value is In-Valid  <br />";
            txtCHFBTT.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtCHFBBill.Text.Trim()))
        {
            strMessage += "Please Enter CHF Buying Billing Value  <br />";
            txtCHFBBill.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtCHFBBill.Text.Trim()) && !Regex.IsMatch(txtCHFBBill.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "CHF Buying Billing Value is In-Valid <br />";
            txtCHFBBill.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtCHFBChq.Text.Trim()))
        {
            strMessage += "Please Enter CHF Buying Cheque Value  <br />";
            txtCHFBChq.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtCHFBChq.Text.Trim()) && !Regex.IsMatch(txtCHFBChq.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "CHF Buying Cheque Value is In-Valid <br />";
            txtCHFBChq.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtCHFSBill.Text.Trim()))
        {
            strMessage += "Please Enter CHF Selling Bills Value  <br />";
            txtCHFSBill.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtCHFSBill.Text.Trim()) && !Regex.IsMatch(txtCHFSBill.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "CHF Selling Bills Value is In-Valid <br />";
            txtCHFSBill.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtCHFSTT.Text.Trim()))
        {
            strMessage += "Please Enter CHF Selling TT Value  <br />";
            txtCHFSTT.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtCHFSTT.Text.Trim()) && !Regex.IsMatch(txtCHFSTT.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "CHF Selling TT Value is In-Valid <br />";
            txtCHFSTT.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtSGDBTT.Text.Trim()))
        {
            strMessage += "Please Enter SGD Buying TT Value  <br />";
            txtSGDBTT.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtSGDBTT.Text.Trim()) && !Regex.IsMatch(txtSGDBTT.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "SGD Buying TT Value is In-Valid  <br />";
            txtSGDBTT.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtSGDBBill.Text.Trim()))
        {
            strMessage += "Please Enter SGD Buying Billing Value  <br />";
            txtSGDBBill.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtSGDBBill.Text.Trim()) && !Regex.IsMatch(txtSGDBBill.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "SGD Buying Billing Value is In-Valid <br />";
            txtSGDBBill.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtSGDBChq.Text.Trim()))
        {
            strMessage += "Please Enter SGD Buying Cheque Value  <br />";
            txtSGDBChq.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtSGDBChq.Text.Trim()) && !Regex.IsMatch(txtSGDBChq.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "SGD Buying Cheque Value is In-Valid <br />";
            txtSGDBChq.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtSGDSBill.Text.Trim()))
        {
            strMessage += "Please Enter SGD Selling Bills Value  <br />";
            txtSGDSBill.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtSGDSBill.Text.Trim()) && !Regex.IsMatch(txtSGDSBill.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "SGD Selling Bills Value is In-Valid <br />";
            txtSGDSBill.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtSGDSTT.Text.Trim()))
        {
            strMessage += "Please Enter SGD Selling TT Value  <br />";
            txtSGDSTT.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtSGDSTT.Text.Trim()) && !Regex.IsMatch(txtSGDSTT.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "SGD Selling TT Value is In-Valid <br />";
            txtSGDSTT.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtAEDBTT.Text.Trim()))
        {
            strMessage += "Please Enter AED Buying TT Value  <br />";
            txtAEDBTT.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtAEDBTT.Text.Trim()) && !Regex.IsMatch(txtAEDBTT.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "AED Buying TT Value is In-Valid  <br />";
            txtAEDBTT.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtAEDBBill.Text.Trim()))
        {
            strMessage += "Please Enter AED Buying Billing Value  <br />";
            txtAEDBBill.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtAEDBBill.Text.Trim()) && !Regex.IsMatch(txtAEDBBill.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "AED Buying Billing Value is In-Valid <br />";
            txtAEDBBill.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtAEDBChq.Text.Trim()))
        {
            strMessage += "Please Enter AED Buying Cheque Value  <br />";
            txtAEDBChq.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtAEDBChq.Text.Trim()) && !Regex.IsMatch(txtAEDBChq.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "AED Buying Cheque Value is In-Valid <br />";
            txtAEDBChq.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtAEDSBill.Text.Trim()))
        {
            strMessage += "Please Enter AED Selling Bills Value  <br />";
            txtAEDSBill.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtAEDSBill.Text.Trim()) && !Regex.IsMatch(txtAEDSBill.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "AED Selling Bills Value is In-Valid <br />";
            txtAEDSBill.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtAEDSTT.Text.Trim()))
        {
            strMessage += "Please Enter AED Selling TT Value  <br />";
            txtAEDSTT.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtAEDSTT.Text.Trim()) && !Regex.IsMatch(txtAEDSTT.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "AED Selling TT Value is In-Valid <br />";
            txtAEDSTT.Focus();
            return false;
        }

        if (string.IsNullOrEmpty(txtUSDCCYBuying.Text.Trim()))
        {
            strMessage += "Please Enter USD CCY Buying Value  <br />";
            txtUSDCCYBuying.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtUSDCCYBuying.Text.Trim()) && !Regex.IsMatch(txtUSDCCYBuying.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += " USD CCY Buying Value is In-Valid <br />";
            txtUSDCCYBuying.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtUSDCCYSelling.Text.Trim()))
        {
            strMessage += "Please Enter USD CCY Selling Value  <br />";
            txtUSDCCYSelling.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtUSDCCYSelling.Text.Trim()) && !Regex.IsMatch(txtUSDCCYSelling.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += " USD CCY Selling Value is In-Valid <br />";
            txtUSDCCYSelling.Focus();
            return false;
        }

        if (string.IsNullOrEmpty(txtUSDTCBuying.Text.Trim()))
        {
            strMessage += "Please Enter USD TC Buying Value  <br />";
            txtUSDTCBuying.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtUSDTCBuying.Text.Trim()) && !Regex.IsMatch(txtUSDTCBuying.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += " USD TC Buying Value is In-Valid <br />";
            txtUSDTCBuying.Focus();
            return false;
        }

        if (string.IsNullOrEmpty(txtUSDTCSelling.Text.Trim()))
        {
            strMessage += "Please Enter USD TC Selling Value  <br />";
            txtUSDTCSelling.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtUSDTCSelling.Text.Trim()) && !Regex.IsMatch(txtUSDTCSelling.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += " USD TC Selling Value is In-Valid <br />";
            txtUSDTCSelling.Focus();
            return false;
        }

        if (string.IsNullOrEmpty(txtGBPCCYBuying.Text.Trim()))
        {
            strMessage += "Please Enter GBP CCY Buying Value  <br />";
            txtGBPCCYBuying.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtGBPCCYBuying.Text.Trim()) && !Regex.IsMatch(txtGBPCCYBuying.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += " GBP CCY Buying Value is In-Valid <br />";
            txtGBPCCYBuying.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtGBPCCYSelling.Text.Trim()))
        {
            strMessage += "Please Enter GBP CCY Selling Value  <br />";
            txtGBPCCYSelling.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtGBPCCYSelling.Text.Trim()) && !Regex.IsMatch(txtGBPCCYSelling.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += " GBP CCY Selling Value is In-Valid <br />";
            txtGBPCCYSelling.Focus();
            return false;
        }

        if (string.IsNullOrEmpty(txtGBPTCBuying.Text.Trim()))
        {
            strMessage += "Please Enter GBP TC Buying Value  <br />";
            txtGBPTCBuying.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtGBPTCBuying.Text.Trim()) && !Regex.IsMatch(txtGBPTCBuying.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += " GBP TC Buying Value is In-Valid <br />";
            txtGBPTCBuying.Focus();
            return false;
        }

        if (string.IsNullOrEmpty(txtGBPTCSelling.Text.Trim()))
        {
            strMessage += "Please Enter GBP TC Selling Value  <br />";
            txtGBPTCSelling.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtGBPTCSelling.Text.Trim()) && !Regex.IsMatch(txtGBPTCSelling.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += " GBP TC Selling Value is In-Valid <br />";
            txtGBPTCSelling.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtEURCCYBuying.Text.Trim()))
        {
            strMessage += "Please Enter EUR CCY Buying Value  <br />";
            txtEURCCYBuying.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtEURCCYBuying.Text.Trim()) && !Regex.IsMatch(txtEURCCYBuying.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += " EUR CCY Buying Value is In-Valid <br />";
            txtEURCCYBuying.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtEURCCYSelling.Text.Trim()))
        {
            strMessage += "Please Enter EUR CCY Selling Value  <br />";
            txtEURCCYSelling.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtEURCCYSelling.Text.Trim()) && !Regex.IsMatch(txtEURCCYSelling.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += " EUR CCY Selling Value is In-Valid <br />";
            txtEURCCYSelling.Focus();
            return false;
        }

        if (string.IsNullOrEmpty(txtEURTCBuying.Text.Trim()))
        {
            strMessage += "Please Enter EUR TC Buying Value  <br />";
            txtEURTCBuying.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtEURTCBuying.Text.Trim()) && !Regex.IsMatch(txtEURTCBuying.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += " EUR TC Buying Value is In-Valid <br />";
            txtEURTCBuying.Focus();
            return false;
        }

        if (string.IsNullOrEmpty(txtEURTCSelling.Text.Trim()))
        {
            strMessage += "Please Enter EUR TC Selling Value  <br />";
            txtEURTCSelling.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtEURTCSelling.Text.Trim()) && !Regex.IsMatch(txtEURTCSelling.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += " EUR TC Selling Value is In-Valid <br />";
            txtEURTCSelling.Focus();
            return false;
        }
        else
        {
            return true;
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        lblErr.Text = "";
        if (Checkdata() == true)
        {
            Update();
            BindGrid();
        }
        else
        {
            lblErr.Text = strMessage;
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        clear();
    }

    public void clear()
    {
        txtHeader.Text = "";

        txtUSBTT.Text = "";
        txtUSBBill.Text = "";
        txtUSBChq.Text = "";
        txtUSSBill.Text = "";
        txtUSSTT.Text = "";

        txtGBPBTT.Text = "";
        txtGBPBBill.Text = "";
        txtGBPBChq.Text = "";
        txtGBPSBill.Text = "";
        txtGBPSTT.Text = "";

        txtEURBTT.Text = "";
        txtEURBBill.Text = "";
        txtEURBChq.Text = "";
        txtEURSBill.Text = "";
        txtEURSTT.Text = "";

        txtJPYBTT.Text = "";
        txtJPYBBill.Text = "";
        txtJPYBChq.Text = "";
        txtJPYSBill.Text = "";
        txtJPYSTT.Text = "";

        txtAUDBTT.Text = "";
        txtAUDBBill.Text = "";
        txtAUDBChq.Text = "";
        txtAUDSBill.Text = "";
        txtAUDSTT.Text = "";

        txtCADBTT.Text = "";
        txtCADBBill.Text = "";
        txtCADBChq.Text = "";
        txtCADSBill.Text = "";
        txtCADSTT.Text = "";

        txtCHFBTT.Text = "";
        txtCHFBBill.Text = "";
        txtCHFBChq.Text = "";
        txtCHFSBill.Text = "";
        txtCHFSTT.Text = "";

        txtSGDBTT.Text = "";
        txtSGDBBill.Text = "";
        txtSGDBChq.Text = "";
        txtSGDSBill.Text = "";
        txtSGDSTT.Text = "";

        txtAEDBTT.Text = "";
        txtAEDBBill.Text = "";
        txtAEDBChq.Text = "";
        txtAEDSBill.Text = "";
        txtAEDSTT.Text = "";

        txtUSDCCYBuying.Text = "";
        txtUSDCCYSelling.Text = "";
        txtUSDTCBuying.Text = "";
        txtUSDTCSelling.Text = "";

        txtGBPCCYBuying.Text = "";
        txtGBPCCYSelling.Text = "";
        txtGBPTCBuying.Text = "";
        txtGBPTCSelling.Text = "";

        txtEURCCYBuying.Text = "";
        txtEURCCYSelling.Text = "";
        txtEURTCBuying.Text = "";
        txtEURTCSelling.Text = "";

    }
    public void BindGrid()
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
                tblGrid.Visible = true;
                tblGrid1.Visible = true;
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
            else
            {
                tblGrid.Visible = false;
                tblGrid1.Visible = false;
            }
        }
        catch(Exception ex)
        {

            Response.Write(ex);
        }
        finally
        { 
        
        }
    }
}


