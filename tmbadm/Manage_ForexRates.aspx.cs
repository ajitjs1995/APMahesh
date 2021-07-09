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

public partial class tmbadm_Manage_ForexRates : System.Web.UI.Page
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
            txtUSBuy.Attributes.Add("autocomplete", "off");
            txtUSSells.Attributes.Add("autocomplete", "off");


            txtEurobuy.Attributes.Add("autocomplete", "off");
            txtEuroSells.Attributes.Add("autocomplete", "off");

            txtGBBuy.Attributes.Add("autocomplete", "off");
            txtGBSells.Attributes.Add("autocomplete", "off");

            BindGrid();

        }





    }
    public bool Checkdata()
    {

        if (string.IsNullOrEmpty(txtUSBuy.Text.Trim()))
        {
            strMessage += "Please Enter US Buy Value  <br />";
            txtUSBuy.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtUSBuy.Text.Trim()) && !Regex.IsMatch(txtUSBuy.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "US Buy Value is In-Valid  <br />";
            txtUSBuy.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtUSSells.Text.Trim()))
        {
            strMessage += "Please Enter US Sells Value  <br />";
            txtUSSells.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtUSSells.Text.Trim()) && !Regex.IsMatch(txtUSSells.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "US Sells Value is In-Valid <br />";
            txtUSSells.Focus();
            return false;
        }

        if (txtEurobuy.Text.Trim() == "")
        {
            strMessage = "Please Enter Euro Buy Value  <br />";
            txtEurobuy.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtEurobuy.Text.Trim()) && !Regex.IsMatch(txtEurobuy.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "Euro Buy Value is In-Valid  <br />";
            txtEurobuy.Focus();
            return false;
        }

        if (txtEuroSells.Text.Trim() == "")
        {
            strMessage = "Please Enter Euro Sells Value  <br />";
            txtEuroSells.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtEuroSells.Text.Trim()) && !Regex.IsMatch(txtEuroSells.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "Euro Sells Value is In-Valid  <br />";
            txtEuroSells.Focus();
            return false;
        }

        if (txtGBBuy.Text.Trim() == "")
        {
            strMessage = "Please Enter GB Pounds Buy Value  <br />";
            txtGBBuy.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtGBBuy.Text.Trim()) && !Regex.IsMatch(txtGBBuy.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "GB Pounds Buy Value is In-Valid  <br />";
            txtGBBuy.Focus();
            return false;
        }
        if (txtGBSells.Text.Trim() == "")
        {
            strMessage = "Please Enter GB Pounds Sells Value  <br />";
            txtGBSells.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtGBSells.Text.Trim()) && !Regex.IsMatch(txtGBSells.Text.Trim(), "((?!(0)) ([1-9]{1}[0-9]{1})[.][0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4})$"))
        {
            strMessage += "GB Pounds Sells Value is In-Valid  <br />";
            txtGBSells.Focus();
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Update()
    {
        lblErr.Text = "";
        int cntNext=0;
        int cntPrevious = 0;
        
        try
        {

            try
            {
                con.Open();
                lblErr.Text = "";
                cmd = new SqlCommand("USP_UpdateForexRates", con);
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
            cm = new SqlCommand("USP_UpdateForexRates", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@QueryType", "Update");
            if (!string.IsNullOrEmpty(txtUSBuy.Text))
            {
                cm.Parameters.AddWithValue("@strUSBuy", Convert.ToDouble(txtUSBuy.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strUSBuy", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtUSSells.Text))
            {
                cm.Parameters.AddWithValue("@strUSSells", Convert.ToDouble(txtUSSells.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strUSSells", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtEurobuy.Text))
            {
                cm.Parameters.AddWithValue("@strEuroBuy", Convert.ToDouble(txtEurobuy.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strEuroBuy", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtEuroSells.Text))
            {
                cm.Parameters.AddWithValue("@strEuroSells", Convert.ToDouble(txtEuroSells.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strEuroSells", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtGBBuy.Text))
            {
                cm.Parameters.AddWithValue("@strGBBuy", Convert.ToDouble(txtGBBuy.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strGBBuy", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtGBSells.Text))
            {
                cm.Parameters.AddWithValue("@strGBSells", Convert.ToDouble(txtGBSells.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strGBSells", 0.0000);
            }
            cntNext =Convert.ToInt32(cm.ExecuteScalar());
            con.Close();
            if (cntNext > cntPrevious)
            {
                lblErr.Text = "Rates Updated Successfully";
            }
            
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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
       
        if (Checkdata() == true)
        {
            Update();
            BindGrid();
            Clear();
            
        }
        else
        {
            lblErr.Text = strMessage;
        }
    }
    public void BindGrid()
    {
        try
        {

            con.Open();
            cmd = new SqlCommand("USP_UpdateForexRates", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@QueryType", "Show");
            DataTable dtShow = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dtShow);
            if (dtShow.Rows.Count > 0)
            {
                tblGrid.Visible = true;
                if (Information.IsDBNull(dtShow.Rows[0]["USBuy"]) == false)
                {
                    lblUSBuy.Text = dtShow.Rows[0]["USBuy"].ToString();
                }
                else
                {
                    lblUSBuy.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["USSells"]) == false)
                {
                    lblUSSell.Text = dtShow.Rows[0]["USSells"].ToString();
                }
                else
                {
                    lblUSSell.Text = "0.0000";
                }

                if (Information.IsDBNull(dtShow.Rows[0]["EuroBuy"]) == false)
                {
                    lblEuroBuy.Text = dtShow.Rows[0]["EuroBuy"].ToString();
                }
                else
                {
                    lblEuroBuy.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["EuroSells"]) == false)
                {
                    lblEuroSells.Text = dtShow.Rows[0]["EuroSells"].ToString();
                }
                else
                {
                    lblEuroSells.Text = "0.0000";
                }

                if (Information.IsDBNull(dtShow.Rows[0]["GBBuy"]) == false)
                {
                    lblGBBuy.Text = dtShow.Rows[0]["GBBuy"].ToString();
                }
                else
                {
                    lblGBBuy.Text = "0.0000";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["GBSells"]) == false)
                {
                    lblGBSells.Text = dtShow.Rows[0]["GBSells"].ToString();
                }
                else
                {
                    lblGBSells.Text = "0.0000";
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
    public void Clear()
    {
        txtUSBuy.Text = "";
        txtUSSells.Text = "";
        txtEurobuy.Text = "";
        txtEuroSells.Text = "";
        txtGBBuy.Text = "";
        txtGBSells.Text = "";
        
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Clear();
    }
}
