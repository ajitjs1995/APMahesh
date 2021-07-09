using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class live_Forex_Rates : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["TMBCON"]);
    SqlCommand cmd = new SqlCommand();

    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        BindGrid();
        string year = DateTime.Now.Year.ToString("yy");
        string month = DateTime.Now.ToString("MMMM");

        int day = DateTime.Now.Day;
        lblDt.Text = month + " " + day + " ~ 17:00";

    }

    public void BindGrid()
    {
        try
        {

            cmd = new SqlCommand("USP_UpdateForexRates", con);
            con.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@QueryType", "Show");
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgForexRates.DataSource = dt;
            dgForexRates.DataBind();
            con.Close();
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
}