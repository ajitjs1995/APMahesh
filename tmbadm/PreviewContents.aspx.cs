using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


public partial class Admin_PreviewContents : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["TMBCON"]);
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    string GetPgID = "";
    string PgLang = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        if (!Page.IsPostBack)
        {
            lblContent.Text = "";
            if (Session["pgid22"] != null)
            {
                string x1 = Session["pgid22"].ToString();
            }
            if (!string.IsNullOrEmpty(Session["pgid22"].ToString()) & !string.IsNullOrEmpty(Session["PgLanguage"].ToString()))
            {
                int cnt1 = 0;
                GetPgID = Session["pgid22"].ToString();
                PgLang = Session["PgLanguage"].ToString();
                //cnt1 = ui.GetCntPreViewContect(cms);

                con.Open();
                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strPageId", GetPgID);
                if (PgLang == "English")
                {
                    cmd.Parameters["@Mode"].Value = "CntPageIDChkr1";
                }
                else if (PgLang == "Hindi")
                {
                    cmd.Parameters["@Mode"].Value = "CntPgHndIDChkr1";
                }
                else if (PgLang == "Marathi")
                {
                    cmd.Parameters["@Mode"].Value = "CntPgMarIDChkr1";
                }

                cnt1 = (int)cmd.ExecuteScalar();
                con.Close();

                if (cnt1 > 0)
                {
                    getData();
                }
                else
                {
                    lblContent.Text = "No content !!";
                }

            }
            else
            {
                lblContent.Text = "No content !!";
            }
        }
    }
    public void getData()
    {
        try
        {
            GetPgID = Session["PgId1"].ToString();
            PgLang = Session["PgLanguage"].ToString();
            //da= ui.GetPreviewContent(cms);
            con.Open();
            cmd = new SqlCommand("Proc_ManageMenus", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strPageId", GetPgID);
            if (PgLang == "English")
            {
                cmd.Parameters["@Mode"].Value = "GetPgContChkr";
            }
            else if (PgLang == "Hindi")
            {
                cmd.Parameters["@Mode"].Value = "GetHndPgContChkr";
            }
            else if (PgLang == "Marathi")
            {
                cmd.Parameters["@Mode"].Value = "GetMarPgContChkr";
            }

            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds, "tbl_PgConts");
            con.Close();
            if (!(ds.Tables["tbl_PgConts"].Rows.Count == 0))
            {
                if (Convert.IsDBNull(ds.Tables["tbl_PgConts"].Rows[0]["ContDescription1"]) == false)
                {
                    lblContent.Text = ds.Tables["tbl_PgConts"].Rows[0]["ContDescription1"].ToString();
                }
                else
                {
                    lblContent.Text = "No content !!";
                }

            }
            else
            {
                lblContent.Text = "No content !!";
            }

        }
        catch (Exception ex)
        {

        }
    }
}