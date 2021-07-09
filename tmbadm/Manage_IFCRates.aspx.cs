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

public partial class tmbadm_Manage_IFCRates : System.Web.UI.Page
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
            txtUSIREx.Attributes.Add("autocomplete", "off");
            txtUSIRIm.Attributes.Add("autocomplete", "off");
            txtUSIFRIm.Attributes.Add("autocomplete", "off");
            txtUSICREx.Attributes.Add("autocomplete", "off");
            txtUSICRIm.Attributes.Add("autocomplete", "off");


            txtGBIREx.Attributes.Add("autocomplete", "off");
            txtGBIRIm.Attributes.Add("autocomplete", "off");
            txtGBIFRIm.Attributes.Add("autocomplete", "off");
            txtGBICREx.Attributes.Add("autocomplete", "off");
            txtGBICRIm.Attributes.Add("autocomplete", "off");

            txtEuroIREx.Attributes.Add("autocomplete", "off");
            txtEuroIRIm.Attributes.Add("autocomplete", "off");
            txtEuroIFRIm.Attributes.Add("autocomplete", "off");
            txtEuroICREx.Attributes.Add("autocomplete", "off");
            txtEuroICRIm.Attributes.Add("autocomplete", "off");

            txtJPYIREx.Attributes.Add("autocomplete", "off");
            txtJPYIRIm.Attributes.Add("autocomplete", "off");
            txtJPYIFRIm.Attributes.Add("autocomplete", "off");
            txtJPYICREx.Attributes.Add("autocomplete", "off");
            txtJPYICRIm.Attributes.Add("autocomplete", "off");

            txtCHFIREx.Attributes.Add("autocomplete", "off");
            txtCHFIRIM.Attributes.Add("autocomplete", "off");
            txtCHFIFRIm.Attributes.Add("autocomplete", "off");
            txtCHFICREx.Attributes.Add("autocomplete", "off");
            txtCHFICRIm.Attributes.Add("autocomplete", "off");




            BindMonth();
            BindGrid();
           

        }
    }
    public void BindMonth()
    {
        int m = DateTime.Now.Month;
        int n = m + 5;
        int year = 0;
        if (m <= 6)
        {
            year = DateTime.Now.Year;

        }
        if (m > 6)
        {
            year = DateTime.Now.Year + 1;

        }
        DateTimeFormatInfo info = new DateTimeFormatInfo();

        for (int i = m; i < n; i++)
        {
            ddlMonthUS.Items.Add(new ListItem(info.GetMonthName(i).Substring(0, 3) + " " + year, i.ToString()));

            ddlGBMonth.Items.Add(new ListItem(info.GetMonthName(i).Substring(0, 3) + " " + year, i.ToString()));
            ddlEuroMonth.Items.Add(new ListItem(info.GetMonthName(i).Substring(0, 3) + " " + year, i.ToString()));
            ddlJPYMonth.Items.Add(new ListItem(info.GetMonthName(i).Substring(0, 3) + " " + year, i.ToString()));
            ddlCHFMonth.Items.Add(new ListItem(info.GetMonthName(i).Substring(0, 3) + " " + year, i.ToString()));

        }
    }
    
    public bool Checkdata()
    {
        int m = DateTime.Now.Month;
        int n = m + 6;
        int year = 0;
        if (m <= 6)
        {
            year = DateTime.Now.Year;

        }
        if (m > 6)
        {
            year = DateTime.Now.Year + 1;

        }

        int ddlusmonth = Convert.ToInt32(ddlMonthUS.SelectedValue);
        int ddlGBPmonth = Convert.ToInt32(ddlGBMonth.SelectedValue);
        int ddlEuromonth = Convert.ToInt32(ddlEuroMonth.SelectedValue);
        int ddlJPYmonth = Convert.ToInt32(ddlJPYMonth.SelectedValue);
        int ddlCHFmonth = Convert.ToInt32(ddlCHFMonth.SelectedValue);

        if (string.IsNullOrEmpty(txtUSIREx.Text.Trim()))
        {
            strMessage += "Please Enter USD Indicative Export Rate Value  <br />";
            txtUSIREx.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtUSIREx.Text.Trim()) && !Regex.IsMatch(txtUSIREx.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "USD Indicative Export Rate Value is In-Valid  <br />";
            txtUSIREx.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtUSIRIm.Text.Trim()))
        {
            strMessage += "Please Enter USD Indicative Import Rate Value  <br />";
            txtUSIRIm.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtUSIRIm.Text.Trim()) && !Regex.IsMatch(txtUSIRIm.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "USD Indicative Import Rate Value is In-Valid <br />";
            txtUSIRIm.Focus();
            return false;
        }

        if (txtUSIFREx.Text.Trim() == "")
        {
            strMessage = "Please Enter USD Indicative Forward Export Rate Value  <br />";
            txtUSIFREx.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtUSIFREx.Text.Trim()) && !Regex.IsMatch(txtUSIFREx.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += " USD Indicative Forward Export Rate Value is In-Valid  <br />";
            txtUSIFREx.Focus();
            return false;
        }

        if (txtUSIFRIm.Text.Trim() == "")
        {
            strMessage = "Please Enter USD Indicative Forward Import Rate Value  <br />";
            txtUSIFRIm.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtUSIFRIm.Text.Trim()) && !Regex.IsMatch(txtUSIFRIm.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "USD Indicative Forward Import Rate Value is In-Valid  <br />";
            txtUSIFRIm.Focus();
            return false;
        }

        if (txtUSICREx.Text.Trim() == "")
        {
            strMessage = "Please Enter USD Indicative Cross Export Rate Value  <br />";
            txtUSICREx.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtUSICREx.Text.Trim()) && !Regex.IsMatch(txtUSICREx.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "USD Indicative Cross Export Rate Value is In-Valid  <br />";
            txtUSICREx.Focus();
            return false;
        }
        if (txtUSICRIm.Text.Trim() == "")
        {
            strMessage = "Please Enter USD Indicative Cross Import Rate Value  <br />";
            txtUSICRIm.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtUSICRIm.Text.Trim()) && !Regex.IsMatch(txtUSICRIm.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "USD Indicative Cross Import Rate Value is In-Valid  <br />";
            txtUSICRIm.Focus();
            return false;
        }
        if (ddlMonthUS.SelectedIndex == 0)
        {
            strMessage += "Select Month for USD Currency <br />";
            ddlMonthUS.Focus();
            return false;

        }
        if (Convert.ToInt32(ddlMonthUS.SelectedValue) < m && Convert.ToInt32(ddlMonthUS.SelectedValue) > n)
        {
            strMessage += "Select Month for USD Currency <br />";
            ddlMonthUS.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtGBIREx.Text.Trim()))
        {
            strMessage += "Please Enter GB Pounds Indicative Export Rate Value  <br />";
            txtGBIREx.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtGBIREx.Text.Trim()) && !Regex.IsMatch(txtGBIREx.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "GB Pounds Indicative Export Rate Value is In-Valid  <br />";
            txtGBIREx.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtGBIRIm.Text.Trim()))
        {
            strMessage += "Please Enter GB Pounds Indicative Import Rate Value  <br />";
            txtGBIRIm.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtGBIRIm.Text.Trim()) && !Regex.IsMatch(txtGBIRIm.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "GB Pounds Indicative Import Rate Value is In-Valid <br />";
            txtGBIRIm.Focus();
            return false;
        }

        if (txtGBIFREx.Text.Trim() == "")
        {
            strMessage = "Please Enter GB Pounds Indicative Forward Export Rate Value  <br />";
            txtGBIFREx.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtGBIFREx.Text.Trim()) && !Regex.IsMatch(txtGBIFREx.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "GB Pounds Indicative Forward Export Rate Value is In-Valid  <br />";
            txtGBIFREx.Focus();
            return false;
        }

        if (txtGBIFRIm.Text.Trim() == "")
        {
            strMessage = "Please Enter GB Pounds Indicative Forward Import Rate Value  <br />";
            txtGBIFRIm.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtGBIFRIm.Text.Trim()) && !Regex.IsMatch(txtGBIFRIm.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "GB Pounds Indicative Forward Import Rate Value is In-Valid  <br />";
            txtGBIFRIm.Focus();
            return false;
        }
        
        if (txtGBICREx.Text.Trim() == "")
        {
            strMessage = "Please Enter GB Pounds Indicative Cross Export Rate Value  <br />";
            txtGBICREx.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtGBICREx.Text.Trim()) && !Regex.IsMatch(txtGBICREx.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "GB Pounds Indicative Cross Export Rate Value is In-Valid  <br />";
            txtGBICREx.Focus();
            return false;
        }
        if (txtGBICRIm.Text.Trim() == "")
        {
            strMessage = "Please Enter GB Pounds Indicative Cross Import Rate Value  <br />";
            txtGBICRIm.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtGBICRIm.Text.Trim()) && !Regex.IsMatch(txtGBICRIm.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "GB Pounds Indicative Cross Import Rate Value is In-Valid  <br />";
            txtGBICRIm.Focus();
            return false;
        }
        if (ddlGBMonth.SelectedIndex == 0)
        {
            strMessage += "Select Month for GB Pound Currency <br />";
            ddlGBMonth.Focus();
            return false;

        }
        if (Convert.ToInt32(ddlGBMonth.SelectedValue) < m && Convert.ToInt32(ddlGBMonth.SelectedValue) > n)
        {
            strMessage += "Select Month for GB Pound Currency <br />";
            ddlGBMonth.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtEuroIREx.Text.Trim()))
        {
            strMessage += "Please Enter Euro Indicative Export Rate Value  <br />";
            txtEuroIREx.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtEuroIREx.Text.Trim()) && !Regex.IsMatch(txtEuroIREx.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "Euro Indicative Export Rate Value is In-Valid  <br />";
            txtEuroIREx.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtEuroIRIm.Text.Trim()))
        {
            strMessage += "Please Enter Euro Indicative Import Rate Value  <br />";
            txtEuroIRIm.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtEuroIRIm.Text.Trim()) && !Regex.IsMatch(txtEuroIRIm.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "Euro Indicative Import Rate Value is In-Valid <br />";
            txtEuroIRIm.Focus();
            return false;
        }

        if (txtEuroIFREx.Text.Trim() == "")
        {
            strMessage = "Please Enter Euro Indicative Forward Export Rate Value  <br />";
            txtEuroIFREx.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtEuroIFREx.Text.Trim()) && !Regex.IsMatch(txtEuroIFREx.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "Euro Indicative Forward Export Rate Value is In-Valid  <br />";
            txtEuroIFREx.Focus();
            return false;
        }

        if (txtEuroIFRIm.Text.Trim() == "")
        {
            strMessage = "Please Enter Euro Indicative Forward Import Rate Value  <br />";
            txtEuroIFRIm.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtEuroIFRIm.Text.Trim()) && !Regex.IsMatch(txtEuroIFRIm.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "Euro Indicative Forward Import Rate Value is In-Valid  <br />";
            txtEuroIFRIm.Focus();
            return false;
        }

        if (txtEuroICREx.Text.Trim() == "")
        {
            strMessage = "Please Enter Euro Indicative Cross Export Rate Value  <br />";
            txtEuroICREx.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtEuroICREx.Text.Trim()) && !Regex.IsMatch(txtEuroICREx.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "Euro Indicative Export Cross Rate Value is In-Valid  <br />";
            txtEuroICREx.Focus();
            return false;
        }
        if (txtEuroICRIm.Text.Trim() == "")
        {
            strMessage = "Please Enter Euro Indicative Cross Import Rate Value  <br />";
            txtEuroICRIm.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtEuroICRIm.Text.Trim()) && !Regex.IsMatch(txtEuroICRIm.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "Euro  Indicative Cross Import Rate Value is In-Valid  <br />";
            txtEuroICRIm.Focus();
            return false;
        }
        if (ddlEuroMonth.SelectedIndex == 0)
        {
            strMessage += "Select Month for Euro Currency <br />";
            ddlEuroMonth.Focus();
            return false;

        }
        if (Convert.ToInt32(ddlEuroMonth.SelectedValue) < m && Convert.ToInt32(ddlEuroMonth.SelectedValue) > n)
        {
            strMessage += "Select Month for Euro Currency <br />";
            ddlEuroMonth.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtJPYIREx.Text.Trim()))
        {
            strMessage += "Please Enter JPY Indicative Export Rate Value  <br />";
            txtJPYIREx.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtJPYIREx.Text.Trim()) && !Regex.IsMatch(txtJPYIREx.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "JPY Indicative Export Rate Value is In-Valid  <br />";
            txtJPYIREx.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtJPYIRIm.Text.Trim()))
        {
            strMessage += "Please Enter JPY Indicative Import Rate Value  <br />";
            txtJPYIRIm.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtJPYIRIm.Text.Trim()) && !Regex.IsMatch(txtJPYIRIm.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "JPY Indicative Import Rate Value is In-Valid <br />";
            txtJPYIRIm.Focus();
            return false;
        }

        if (txtJPYIFREx.Text.Trim() == "")
        {
            strMessage = "Please Enter JPY Indicative Forward Export Rate Value  <br />";
            txtJPYIFREx.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtJPYIFREx.Text.Trim()) && !Regex.IsMatch(txtJPYIFREx.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "JPY Indicative Forward Export Rate Value is In-Valid  <br />";
            txtJPYIFREx.Focus();
            return false;
        }

        if (txtJPYIFRIm.Text.Trim() == "")
        {
            strMessage = "Please Enter JPY Indicative Forward Import Rate Value  <br />";
            txtJPYIFRIm.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtJPYIFRIm.Text.Trim()) && !Regex.IsMatch(txtJPYIFRIm.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "JPY Indicative Forward Import Rate Value is In-Valid  <br />";
            txtJPYIFRIm.Focus();
            return false;
        }

        if (txtJPYICREx.Text.Trim() == "")
        {
            strMessage = "Please Enter JPY  Indicative Cross Export Rate Value  <br />";
            txtJPYICREx.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtJPYICREx.Text.Trim()) && !Regex.IsMatch(txtJPYICREx.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "JPY Indicative Cross Export Rate Value is In-Valid  <br />";
            txtJPYICREx.Focus();
            return false;
        }
        if (txtJPYICRIm.Text.Trim() == "")
        {
            strMessage = "Please Enter JPY Indicative Cross Import Rate Value  <br />";
            txtJPYICRIm.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtJPYICRIm.Text.Trim()) && !Regex.IsMatch(txtJPYICRIm.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "JPY Indicative Cross Import Rate Value is In-Valid  <br />";
            txtJPYICRIm.Focus();
            return false;
        }
        if (ddlJPYMonth.SelectedIndex == 0)
        {
            strMessage += "Select Month for JPY Currency <br />";
            ddlJPYMonth.Focus();
            return false;

        }
        if (Convert.ToInt32(ddlJPYMonth.SelectedValue) < m && Convert.ToInt32(ddlJPYMonth.SelectedValue) > n)
        {
            strMessage += "Select Month for JPY Currency <br />";
            ddlJPYMonth.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtCHFIREx.Text.Trim()))
        {
            strMessage += "Please Enter CHF Indicative  Export Rate Value  <br />";
            txtCHFIREx.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtCHFIREx.Text.Trim()) && !Regex.IsMatch(txtCHFIREx.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "CHF Indicative  Export Rate Value is In-Valid  <br />";
            txtCHFIREx.Focus();
            return false;
        }

        if (string.IsNullOrEmpty(txtCHFIRIM.Text.Trim()))
        {
            strMessage += "Please Enter CHF Indicative Import Rate Value  <br />";
            txtCHFIRIM.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtCHFICREx.Text.Trim()) && !Regex.IsMatch(txtCHFICREx.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "CHF Indicative Import Rate Value is In-Valid <br />";
            txtCHFICREx.Focus();
            return false;
        }

        if (txtCHFIFREx.Text.Trim() == "")
        {
            strMessage = "Please Enter CHF Indicative Forward Export Rate Value  <br />";
            txtCHFIFREx.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtCHFIFREx.Text.Trim()) && !Regex.IsMatch(txtCHFIFREx.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "CHF Indicative Forward Export Rate Value is In-Valid  <br />";
            txtCHFIFREx.Focus();
            return false;
        }

        if (txtCHFIFRIm.Text.Trim() == "")
        {
            strMessage = "Please Enter CHF Indicative Forward Import Rate Value  <br />";
            txtCHFIFRIm.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtCHFIFRIm.Text.Trim()) && !Regex.IsMatch(txtCHFIFRIm.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "CHF Indicative Forward Import Rate Value is In-Valid  <br />";
            txtCHFIFRIm.Focus();
            return false;
        }

        if (txtCHFICREx.Text.Trim() == "")
        {
            strMessage = "Please Enter CHF Indicative Cross Export Rate Value  <br />";
            txtCHFICREx.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtCHFICREx.Text.Trim()) && !Regex.IsMatch(txtCHFICREx.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "CHF Indicative Cross Export Rate Value is In-Valid  <br />";
            txtCHFICREx.Focus();
            return false;
        }
        if (txtCHFICRIm.Text.Trim() == "")
        {
            strMessage = "Please Enter CHF Indicative Cross Import Rate Value  <br />";
            txtCHFICRIm.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtCHFICRIm.Text.Trim()) && !Regex.IsMatch(txtCHFICRIm.Text.Trim(), "(([0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5})|([0-9]{1}|[0-9]{2}|[0-9]{3})[.]([0-9]{1}|[0-9]{2}|[0-9]{3}|[0-9]{4}|[0-9]{5}))$"))
        {
            strMessage += "CHF Indicative Cross Import Rate Value is In-Valid  <br />";
            txtCHFICRIm.Focus();
            return false;
        }
        if (ddlCHFMonth.SelectedIndex == 0)
        {
            strMessage += "Select Month for CHF Currency <br />";
            ddlCHFMonth.Focus();
            return false;

        }
        if (Convert.ToInt32(ddlCHFMonth.SelectedValue) < m && Convert.ToInt32(ddlCHFMonth.SelectedValue) > n)
        {
            strMessage += "Select Month for CHF Currency <br />";
            ddlCHFMonth.Focus();
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
        int cntNext = 0;
        int cntPrevious = 0;

        try
        {

            try
            {
                con.Open();
                lblErr.Text = "";
                cmd = new SqlCommand("USP_UpdateIndFwdCrossRates", con);
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
            cm = new SqlCommand("USP_UpdateIndFwdCrossRates", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@QueryType", "Update");
            if (!string.IsNullOrEmpty(txtUSIREx.Text))
            {
                cm.Parameters.AddWithValue("@strUSIREx", Convert.ToDouble(txtUSIREx.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strUSIREx", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtUSIRIm.Text))
            {
                cm.Parameters.AddWithValue("@strUSIRIm", Convert.ToDouble(txtUSIRIm.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strUSIRIm", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtUSIFREx.Text))
            {
                cm.Parameters.AddWithValue("@strUSIFREx", Convert.ToDouble(txtUSIFREx.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strUSIFREx", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtUSIFRIm.Text))
            {
                cm.Parameters.AddWithValue("@strUSIFRIm", Convert.ToDouble(txtUSIFRIm.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strUSIFRIm", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtUSICREx.Text))
            {
                cm.Parameters.AddWithValue("@strUSICREx", Convert.ToDouble(txtUSICREx.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strUSICREx", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtUSICRIm.Text))
            {
                cm.Parameters.AddWithValue("@strUSICRIm", Convert.ToDouble(txtUSICRIm.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strUSICRIm", 0.0000);
            }

            cm.Parameters.AddWithValue("@strMonthUS", ddlMonthUS.SelectedItem.Text);
            if (!string.IsNullOrEmpty(txtGBIREx.Text))
            {
                cm.Parameters.AddWithValue("@strGBIREx", Convert.ToDouble(txtGBIREx.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strGBIREx", 0.0000);
            }

            
            if (!string.IsNullOrEmpty(txtGBIRIm.Text))
            {
                cm.Parameters.AddWithValue("@strGBIRIm", Convert.ToDouble(txtGBIRIm.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strGBIRIm", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtGBIFREx.Text))
            {
                cm.Parameters.AddWithValue("@strGBIFREx", Convert.ToDouble(txtGBIFREx.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strGBIFREx", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtGBIFRIm.Text))
            {
                cm.Parameters.AddWithValue("@strGBIFRIm", Convert.ToDouble(txtGBIFRIm.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strGBIFRIm", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtGBICREx.Text))
            {
                cm.Parameters.AddWithValue("@strGBIFCREx", Convert.ToDouble(txtGBICREx.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strGBIFCREx", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtGBICRIm.Text))
            {
                cm.Parameters.AddWithValue("@strGBICRIm", Convert.ToDouble(txtGBICRIm.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strGBICRIm", 0.0000);
            }
            cm.Parameters.AddWithValue("@strGBMonth", ddlGBMonth.SelectedItem.Text);

            if (!string.IsNullOrEmpty(txtEuroIREx.Text))
            {
                cm.Parameters.AddWithValue("@strEuroIREx", Convert.ToDouble(txtEuroIREx.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strEuroIREx", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtEuroIRIm.Text))
            {
                cm.Parameters.AddWithValue("@strEuroIRIm", Convert.ToDouble(txtEuroIRIm.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strEuroIRIm", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtEuroIFREx.Text))
            {
                cm.Parameters.AddWithValue("@strEuroIFREx", Convert.ToDouble(txtEuroIFREx.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strEuroIFREx", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtEuroIFRIm.Text))
            {
                cm.Parameters.AddWithValue("@strEuroIFRIm", Convert.ToDouble(txtEuroIFRIm.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strEuroIFRIm", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtEuroICREx.Text))
            {
                cm.Parameters.AddWithValue("@strEuroICREx", Convert.ToDouble(txtEuroICREx.Text));
            }
            if (!string.IsNullOrEmpty(txtEuroICRIm.Text))
            {
                cm.Parameters.AddWithValue("@strEuroICRIm", Convert.ToDouble(txtEuroICRIm.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strEuroICRIm", 0.0000);
            }
            cm.Parameters.AddWithValue("@strEuroMonth", ddlEuroMonth.SelectedItem.Text);

            if (!string.IsNullOrEmpty(txtJPYIREx.Text))
            {
                cm.Parameters.AddWithValue("@strJPYIREx", Convert.ToDouble(txtJPYIREx.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strJPYIREx", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtJPYIRIm.Text))
            {
                cm.Parameters.AddWithValue("@strJPYIRIm", Convert.ToDouble(txtJPYIRIm.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strJPYIRIm", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtJPYIFREx.Text))
            {
                cm.Parameters.AddWithValue("@strJPYIFREx", Convert.ToDouble(txtJPYIFREx.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strJPYIFREx", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtJPYIFRIm.Text))
            {
                cm.Parameters.AddWithValue("@strJPYIFRIm", Convert.ToDouble(txtJPYIFRIm.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strJPYIFRIm", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtJPYICREx.Text))
            {
                cm.Parameters.AddWithValue("@strJPYICREx", Convert.ToDouble(txtJPYICREx.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strJPYICREx", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtJPYICRIm.Text))
            {
                cm.Parameters.AddWithValue("@strJPYICRImJ", Convert.ToDouble(txtJPYICRIm.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strJPYICRImJ", 0.0000);
            }
            cm.Parameters.AddWithValue("@strJPYMonth", ddlJPYMonth.SelectedItem.Text);

            if (!string.IsNullOrEmpty(txtCHFIREx.Text))
            {
                cm.Parameters.AddWithValue("@strCHFIREx", Convert.ToDouble(txtCHFIREx.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strCHFIREx", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtCHFIRIM.Text))
            {
                cm.Parameters.AddWithValue("@strCHFIRIM", Convert.ToDouble(txtCHFIRIM.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strCHFIRIM", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtCHFIFREx.Text))
            {
                cm.Parameters.AddWithValue("@strCHFIFREx", Convert.ToDouble(txtCHFIFREx.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strCHFIFREx", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtCHFIFRIm.Text))
            {
                cm.Parameters.AddWithValue("@strCHFIFRIm", Convert.ToDouble(txtCHFIFRIm.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strCHFIFRIm", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtCHFICREx.Text))
            {
                cm.Parameters.AddWithValue("@strCHCIREx", Convert.ToDouble(txtCHFICREx.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strCHCIREx", 0.0000);
            }
            if (!string.IsNullOrEmpty(txtCHFICRIm.Text))
            {
                cm.Parameters.AddWithValue("@strCHFICRIm", Convert.ToDouble(txtCHFICRIm.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strCHFICRIm", 0.0000);
            }

            cm.Parameters.AddWithValue("@strCHFMonth", ddlCHFMonth.SelectedItem.Text);


            cntNext = Convert.ToInt32(cm.ExecuteScalar());

            if (cntNext > cntPrevious)
            {
                lblErr.Text = "Indicative/Forward/Cross Rates Updated successfully";
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
        txtUSIREx.Text = "";
        txtUSIRIm.Text = "";
        txtUSIFRIm.Text = "";
        txtUSIFREx.Text = "";
        txtUSICRIm.Text = "";
        txtUSICREx.Text = "";
        

        txtGBIREx.Text = "";
        txtGBIRIm.Text = "";
        txtGBIFREx.Text = "";
        txtGBIFRIm.Text = "";
        txtGBICREx.Text = "";
        txtGBICRIm.Text = "";
       
        txtEuroIREx.Text = "";
        txtEuroIRIm.Text = "";
        txtEuroIFREx.Text = "";
        txtEuroIFRIm.Text = "";
        txtEuroICREx.Text = "";
        txtEuroICRIm.Text = "";
     
        txtJPYIREx.Text = "";
        txtJPYIRIm.Text = "";
        txtJPYIFREx.Text = "";
        txtJPYIFRIm.Text = "";
        txtJPYICREx.Text = "";
        txtJPYICRIm.Text = "";
       
        txtCHFIREx.Text = "";
        txtCHFIRIM.Text = "";
        txtCHFIFREx.Text = "";
        txtCHFIFRIm.Text = "";
        txtCHFICREx.Text = "";
        txtCHFICRIm.Text = "";
        ddlCHFMonth.SelectedIndex = 0;
        ddlEuroMonth.SelectedIndex = 0;
        ddlGBMonth.SelectedIndex = 0;
        ddlJPYMonth.SelectedIndex = 0;
        ddlMonthUS.SelectedIndex = 0;
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
}


