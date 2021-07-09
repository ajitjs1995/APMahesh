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
    string strMessage = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
                BindRates();            
        }
    }



    public void BindRates()
    {
        string frmdate = "";
        string FromDate = "";
        string fdd = "";
        string fmm = "";
        string fyy = "";


        if (!string.IsNullOrEmpty(txtDate.Text.Trim()) && !string.IsNullOrEmpty(txtDate.Text.Trim()))
        {

            FromDate = txtDate.Text.Trim();
            string[] aa = FromDate.Split('-');
            fdd = aa[0];
            fmm = aa[1];
            fyy = aa[2];

        }
        try
        {

            cmd = new SqlCommand("USP_UpdateForexRates", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            if (ddlPrd.SelectedIndex != 0 && !string.IsNullOrEmpty(txtDate.Text))
            {
                cmd.Parameters.AddWithValue("@QueryType", "PeriodWise");
                cmd.Parameters.AddWithValue("@Period", Convert.ToInt32(ddlPrd.SelectedValue));
                cmd.Parameters.AddWithValue("@SubDate", fdd.ToString() + "-" + fmm.ToString() + "-" + fyy.ToString());

            }
            else
            {
                cmd.Parameters.AddWithValue("@QueryType", "Show");

            }

            con.Open();
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                frmdate = dt.Rows[0]["Subdate"].ToString();
                if (string.IsNullOrEmpty(txtDate.Text) && ddlPrd.SelectedIndex == 0)
                {
                    lblLinkText.Text = "from " + frmdate.Substring(0, 10);
                }
                if (!string.IsNullOrEmpty(txtDate.Text) && ddlPrd.SelectedIndex != 0)
                {
                    lblLinkText.Text = "from " + txtDate.Text + " for upto " + ddlPrd.SelectedItem.Text;
                }

                dgGB.DataSource = dt;
                    dgGB.DataBind();
                   
                
               
                con.Close();
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
        finally
        {
            con.Close();
        }
    }

    protected void btn_ShowClick(object sender, EventArgs e)
    {
        LblError.Text = "";
        if (Checkdata() == true)
        {
            BindRates();
        }
        
    }

    public bool Checkdata()
    {

        DateTime dt5 = DateTime.MinValue;
        DateTime dt3 = DateTime.MinValue;
        DateTime dt4 = DateTime.MinValue;
        string today = DateTime.Now.ToString("dd-MM-yyyy");
        DateTimeFormatInfo dateFormat = new DateTimeFormatInfo();
        dateFormat.DateSeparator = "/";

        if (txtDate.Text != "")
        {
            DateTime.TryParseExact(txtDate.Text, "dd-MM-yyyy", dateFormat, DateTimeStyles.AllowWhiteSpaces, out dt5);
         }
        
        if (today != "")
        {
            DateTime.TryParseExact(today, "dd-MM-yyyy", dateFormat, DateTimeStyles.AllowWhiteSpaces, out dt4);
        }    
        
         if (dt5 > dt4)
        {
            LblError.Text = "From date should not be greater than today's date";

            txtDate.Focus();
            return false;
        }
         if((ddlPrd.SelectedItem.Text != "---Select---" && ddlPrd.SelectedItem.Text != "1 Day" && ddlPrd.SelectedItem.Text != "1 Week" && ddlPrd.SelectedItem.Text != "1 Month") || (ddlPrd.SelectedValue != "0" && ddlPrd.SelectedValue != "1" && ddlPrd.SelectedValue != "2" && ddlPrd.SelectedValue != "3"))
        {
            LblError.Text = "Select Period";

            txtDate.Focus();
            return false;
        }
       
        else
        {
            LblError.Text = "";

            return true;
        }
    }
 }