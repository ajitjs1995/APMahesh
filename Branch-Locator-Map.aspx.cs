using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class Branch_Locator_Map : System.Web.UI.Page
{
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    System.Data.DataSet ds = new System.Data.DataSet();
    System.Data.DataSet ds1 = new System.Data.DataSet();
    DataTable dt;
    SqlDataReader dr;
    public SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["TMBCON"].ToString());
    int val = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            state();
            ctyy.Items.Add("Please Select District");
        }
    }
    public void state()
    {
        con.Open();
        cmd = new SqlCommand("USP_BranchMaster", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@Query", SqlDbType.VarChar, 50));

        cmd.Parameters["@Query"].Value = "FillState";

        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        dt = new DataTable();
        da.Fill(dt);

        stt.DataSource = dt;
        stt.Items.Add("Please Select State");
        stt.DataTextField = "State";
        stt.DataBind();
        con.Close();
    }

    public void city()
    {
        ctyy.Items.Clear();
        con.Open();
        cmd = new SqlCommand("USP_BranchMaster", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@Query", SqlDbType.VarChar, 50));

        cmd.Parameters["@Query"].Value = "FillDistrict";
        cmd.Parameters.AddWithValue("@State", stt.SelectedItem.Text);
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds, "Branch_Mastre");

        SqlDataReader dr = cmd.ExecuteReader();
        ctyy.DataSource = dr;
        ctyy.Items.Add("Please Select District");
        ctyy.DataTextField = "District";
        ctyy.DataBind();
        con.Close();
    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        cleardata();
    }
    public void cleardata()
    {
        LblError.Visible = false;
        stt.Items.Clear();
        state();
        ctyy.Items.Clear();
        ctyy.Items.Add("Please Select District");

    }
    protected void state_selection(object sender, EventArgs e)
    {
        city();
    }
    protected void Button1_Click(object sender, System.EventArgs e)
    {

        try
        {
            con.Open();
            cmd = new SqlCommand("Proc_map", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
            cmd.Parameters.AddWithValue("@state", stt.SelectedValue.Trim());
            cmd.Parameters.AddWithValue("@city", ctyy.SelectedValue.Trim());
            cmd.Parameters["@mode"].Value = "GetValue";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "map");

            rptMarkers.DataSource = ds;
            rptMarkers.DataBind();

        }
        catch (Exception ex)
        {
        }
        finally
        {
            con.Close();
        }
    }
}