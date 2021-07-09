using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class GetIP : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["TMBCON"].ToString());
    SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            con.Open();
            cmd = new SqlCommand("USP_GETIP", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
            cmd.Parameters.AddWithValue("@IP", GetIPAddress2());
            cmd.Parameters["@Mode"].Value = "INSERTIP";
            cmd.ExecuteNonQuery();
            con.Close();

            Response.Redirect("https://www.tmb.in/doc/CAPEX-RFP-MBank-001-2020-2021-V1.pdf");
        }
    }
    //protected string GetIPAddress()
    //{
    //    HttpRequest request = HttpContext.Current.Request;
    //    return request.UserHostAddress;
    //}
    protected string GetIPAddress2()
    {
        string IPAddress = string.Empty;
        IPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(IPAddress))
        {
            IPAddress = Request.ServerVariables["REMOTE_ADDR"];
        }
        return IPAddress;
    }
}