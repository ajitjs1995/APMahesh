using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.IO;
using System.Net;

public partial class press_release_details : System.Web.UI.Page
{
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    System.Data.DataSet ds = new System.Data.DataSet();
    System.Data.DataSet ds1 = new System.Data.DataSet();
    SqlDataReader dr;
    public SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["TMBCON"].ToString());
    string PressReleaseDate = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                if (Session["NoticeDate"].ToString() != null || Session["NoticeDate"].ToString() != "" || PressReleaseDate != "")
                {
                    if (PressReleaseDate != "" && PressReleaseDate != null)
                    {
                        string dd = string.Empty;
                        string mm = string.Empty;
                        string yy = string.Empty;
                        yy = PressReleaseDate.Substring(0, 4);
                        mm = PressReleaseDate.Substring(4, 2);
                        dd = PressReleaseDate.Substring(6, 2);
                        PressReleaseDate = yy + "-" + mm + "-" + dd;
                        bindgrid(PressReleaseDate);
                    }
                    else
                    {
                        bindgrid(Session["NoticeDate"].ToString());
                    }
                    string Month = string.Empty;
                    string Day = string.Empty;
                    string NoticeDatetitle = string.Empty;
                    string Title = string.Empty;
                    string Description = string.Empty;

                    con.Open();
                    cmd = new SqlCommand("USP_PressRelease", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add("@Date", Session["NoticeDate"].ToString());
                    cmd.Parameters["@mode"].Value = "GetReleaseDate";
                    da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    ds = new DataSet();
                    da.Fill(ds, "NoticeDate");
                    con.Close();
                    if (Information.IsDBNull(ds.Tables["NoticeDate"].Rows[0]["NoticeDateTitle"].ToString()) == false)
                    {
                        NoticeDatetitle = ds.Tables["NoticeDate"].Rows[0]["NoticeDateTitle"].ToString();
                    }
                    if (Information.IsDBNull(ds.Tables["NoticeDate"].Rows[0]["Month"].ToString()) == false)
                    {
                        Month = ds.Tables["NoticeDate"].Rows[0]["Month"].ToString();
                    }
                    if (Information.IsDBNull(ds.Tables["NoticeDate"].Rows[0]["Day"].ToString()) == false)
                    {
                        Day = ds.Tables["NoticeDate"].Rows[0]["Day"].ToString();
                    }
                    if (Information.IsDBNull(ds.Tables["NoticeDate"].Rows[0]["Title"].ToString()) == false)
                    {
                        Title = ds.Tables["NoticeDate"].Rows[0]["Title"].ToString();
                    }
                    if (Information.IsDBNull(ds.Tables["NoticeDate"].Rows[0]["Description"].ToString()) == false)
                    {
                        Description = ds.Tables["NoticeDate"].Rows[0]["Description"].ToString();
                    }

                    NoticeDate.Text = "<span class='calmonth' title='" + NoticeDatetitle + "'>" + Month + "<span class='day'>" + Day + "</span></span>";
                    TitleDescription.Text = "<h3>" + Title + "</H3>" + Description;
                }
                else
                {
                    Response.Redirect("press-release.aspx");
                }
            }
            catch (Exception exc)
            {
                Response.Redirect("press-release.aspx");
            }
            finally
            {
                con.Close();
            }
        }
    }
    public void bindgrid(string NoticeDate)
    {
        try
        {
            con.Open();
            cmd = new SqlCommand("USP_PressRelease", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 50));
            cmd.Parameters.Add("@Date", NoticeDate);
            cmd.Parameters["@mode"].Value = "ViewPressReleaseInDetails";
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds, "Table");
            con.Close();

            if (!(ds.Tables["Table"].Rows.Count == 0))
            {
                //lblmsg.Text = ds.Tables["tbl_NewsDtls2"].Rows.Count + " Records found !!";
                //NoticeDate = "<span class='calmonth' title=" + NoticeDatetitle + ">" + Month + "<span class='day'>" + Day + "</span></span>";
                DgSalesNotice.Visible = true;
                try
                {
                    DgSalesNotice.DataSource = ds.Tables["Table"].DefaultView;
                    DgSalesNotice.DataBind();
                }
                catch
                {
                    try
                    {
                        this.DgSalesNotice.CurrentPageIndex = 0;
                        this.DgSalesNotice.DataBind();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            else
            {
                DgSalesNotice.DataSource = null;
                DgSalesNotice.DataBind();
                DgSalesNotice.Visible = false;
                //lblmsg.Text = "No records found";
            }

        }
        catch (Exception ex)
        {
        }
        finally
        {
            con.Close();
        }
    }
    protected void DgSalesNotice_ItemDataBound(object sender, DataGridItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.SelectedItem | e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.EditItem)
        {
            string Noticedate = "";
            string NoticeDatetitle = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "NoticeDateTitle")) == false)
            {
                NoticeDatetitle = DataBinder.Eval(e.Item.DataItem, "NoticeDateTitle").ToString();
            }
            else
            {
                NoticeDatetitle = "";
            }

            string Day = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Day")) == false)
            {
                Day = DataBinder.Eval(e.Item.DataItem, "Day").ToString();
            }
            else
            {
                Day = "";
            }
            string Month = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Month")) == false)
            {
                Month = DataBinder.Eval(e.Item.DataItem, "Month").ToString();
            }
            else
            {
                Month = "";
            }
            Noticedate = "<span class='calmonth' title=" + NoticeDatetitle + ">" + Month + "<span class='day'>" + Day + "</span></span>";

            //LinkButton Readmore = (LinkButton)e.Item.FindControl("lnkReadMore");
            //Readmore.Attributes.Add("target", "_blank");
            //if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "FileHeading")) == false)
            //{
            //    Readmore.Attributes.Add("href", DataBinder.Eval(e.Item.DataItem, "FileName").ToString());
            //}
            //else
            //{
            //    Readmore.Text = "";
            //}

            string FileHeading = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "FileHeading")) == false)
            {

                FileHeading = DataBinder.Eval(e.Item.DataItem, "FileHeading").ToString();
            }
            else
            {

                FileHeading = "";
            }

            string file = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "FileName")) == false)
            {
                file = DataBinder.Eval(e.Item.DataItem, "FileName").ToString();
                if (!string.IsNullOrEmpty(file.Trim()))
                {
                    ((LinkButton)e.Item.Cells[3].FindControl("lnkReadMore")).Visible = true;
                    if (file.Contains(".aspx"))
                    {
                        ((LinkButton)e.Item.Cells[3].FindControl("lnkReadMore")).Attributes.Add("href", file);
                        ((LinkButton)e.Item.Cells[3].FindControl("lnkReadMore")).Attributes.Add("target", "_blank");
                    }
                }
                else
                {
                    ((LinkButton)e.Item.Cells[3].FindControl("lnkReadMore")).Visible = false;
                }
            }
            else
            {
                file = "";
                ((LinkButton)e.Item.Cells[3].FindControl("lnkReadMore")).Visible = false;

            }

        }
    }
    protected void DgSalesNotice_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (!(e.CommandName == "Page"))
        {
            string NoticeDate = e.Item.Cells[0].Text;
            string FileName = e.Item.Cells[4].Text;

            string FilePath = "";
            if (e.CommandName == "ReadMore")
            {
                string Nws_path;

                Nws_path = Server.MapPath("press/" + FileName);

                WebClient client = new WebClient();

                Byte[] buffer = client.DownloadData(Nws_path);

                string mimetype = null;
                string extension = Path.GetExtension(FileName);
                switch (extension)
                {
                    case ".doc":
                    case ".docx":
                        mimetype = "application/msword";
                        break; // TODO: might not be correct. Was : Exit Select

                    case ".txt":
                        mimetype = "text/plain";
                        break; // TODO: might not be correct. Was : Exit Select

                    case ".pdf":
                        mimetype = "application/pdf";
                        break; // TODO: might not be correct. Was : Exit Select

                    default:
                        mimetype = "application/octet-stream";
                        break; // TODO: might not be correct. Was : Exit Select
                }
                if (buffer != null)
                {
                    Response.ContentType = mimetype;

                    Response.AddHeader("content-length", buffer.Length.ToString());

                    Response.WriteFile(Nws_path);
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                    Response.WriteFile(Nws_path);
                }

            }
        }

    }
}