using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.VisualBasic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
public partial class Admin_PreviewChangesDetails : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["TMBCON"]);
    SqlCommand cmd = new SqlCommand();
    //Audit_trail audtclass = new Audit_trail();
    SqlDataAdapter da = new SqlDataAdapter();
    System.Data.DataSet ds = new System.Data.DataSet();
    System.Data.DataSet ds1 = new System.Data.DataSet();
    string GetPgID = "";
    string Usrtype = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                fill_content();
            }
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    public void fill_content()
    {
        string content;
        //string contentt1;
        //string contentt2;
        GetPgID = Session["PgId1"].ToString();
        //string PgLang = Session["PgLanguage"].ToString();
        SqlDataAdapter da = new SqlDataAdapter();
        //string chk_cont = "";
        int cnt1 = 0;

        con.Open();
        cmd = new SqlCommand("proc_AuditTrail", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
        cmd.Parameters.AddWithValue("@id1", GetPgID);
        
        cmd.Parameters["@Mode"].Value = "cntContent";
        
        cnt1 = (int)cmd.ExecuteScalar();
        con.Close();

        if (cnt1 > 0)
        {
            con.Open();
            cmd = new SqlCommand("proc_AuditTrail", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@id1", GetPgID);
            
            cmd.Parameters["@Mode"].Value = "ShowContent";
         
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "tbl_PgContent");
            con.Close();
            if (!(ds.Tables["tbl_PgContent"].Rows.Count == 0))
            {
                //if (Convert.IsDBNull(ds.Tables["tbl_PgContent"].Rows[0]["UpdatedContent"]) == false)
                //{
                //    contentt2 = ds.Tables["tbl_PgContent"].Rows[0]["UpdatedContent"].ToString();
                //}
                //else
                //{
                //    contentt2 = "";
                //}

                //if (Convert.IsDBNull(ds.Tables["tbl_PgContent"].Rows[0]["ContDescription1"]) == false)
                //{
                //    contentt1 = ds.Tables["tbl_PgContent"].Rows[0]["ContDescription1"].ToString();
                //}
                //else
                //{
                //    contentt1 = "";
                //}

                if (Convert.IsDBNull(ds.Tables["tbl_PgContent"].Rows[0]["UpdatedContent"]) == false)
                {
                    content = ds.Tables["tbl_PgContent"].Rows[0]["UpdatedContent"].ToString();
                }
                else
                {
                    content = "";
                }

                //if (Convert.IsDBNull(ds.Tables["tbl_PgContent"].Rows[0]["ContID"]) == false)
                //{
                //    Session["ContId1"] = ds.Tables["tbl_PgContent"].Rows[0]["ContID"].ToString();
                //}
                //else
                //{
                //    Session["ContId1"] = "";
                //}
                if (!(content == ""))
                {
                    //if (!(contentt2 == ""))
                    //{
                    //    editor1.Value = contentt2;

                    //}
                    //else if (!(contentt1 == ""))
                    //{
                    //    editor1.Value = contentt1;
                    //}
                    //else if (!(contentt == ""))
                    //{
                    lnkDesign.Visible = true;
                    lnkback.Visible = false;
                    editor1.Text = content;
                    editor2.Visible = false;
                    lblmsg.Text = "The updated content of the page";
                    Session["CONTENT"] = content;
                    //}
                }
                else
                {
                    lblmsg.Text = "There is no Content Updated !!!";
                }
            }
        }
    }
    protected void lnkDesign_Click(object sender, EventArgs e)   
    {
        editor2.Value = Session["CONTENT"].ToString();
        editor1.Visible = false;
        editor2.Visible = true;
        lnkDesign.Visible = false;
        //lnkback.Visible = true;
       // Response.Redirect("PreviewChangesDesign.aspx");
      //this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
    }
    protected void lnkback_Click(object sender, EventArgs e)
    {
        editor1.Visible = true;
        editor2.Visible = false;
        lnkDesign.Visible = true;
    }
}