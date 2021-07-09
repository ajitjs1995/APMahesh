using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

public partial class tmbadm_SaleNOtice : System.Web.UI.Page
{
    SqlDataReader dr;
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["TMBCON"].ToString());
    SqlCommand cmd = new SqlCommand();
    string pid = "";
    string pidlbl = "";
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        string FullTitle = string.Empty;
        try
        {
            Message.Text = "";
            FullTitle = "Sale of Property for Loan Recovery from " + Title.Text + ", " + Branch.Text;
            int cnt1 = 0;
            cmd = new SqlCommand("Proc_SalesNotice", con);
            con.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
            cmd.Parameters.AddWithValue("@NoticeDate", NoticeDate.Text.Trim());
            cmd.Parameters.AddWithValue("@Title", FullTitle.Trim());
            cmd.Parameters.AddWithValue("@FileName", FileName.Text.Trim());
            cmd.Parameters["@Mode"].Value = "AddNewSalesNotice";
            cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            if (cnt1 > 0)
            {
                Message.Text = "Sale notice successfully added !!!";
                Message.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                Message.Text = "Please Check Database table !!!";
                Message.ForeColor = System.Drawing.Color.Red;
            }
            resetall();
        }
        catch (Exception ext)
        { }
        finally
        {
            con.Close();
        }


    }
    protected void Reset_Click(object sender, EventArgs e)
    {
        resetall();
    }
    public void resetall()
    {
        Branch.Text = "";
        Title.Text = "";
        NoticeDate.Text = "";
        FileName.Text = "";
    }
}