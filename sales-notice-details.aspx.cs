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

public partial class sales_notice_details : System.Web.UI.Page
{
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    System.Data.DataSet ds = new System.Data.DataSet();
    System.Data.DataSet ds1 = new System.Data.DataSet();
    SqlDataReader dr;
    public SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["TMBCON"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                if (Session["NoticeDate"].ToString() != null || Session["NoticeDate"].ToString() != "" || Session["ActionOn"].ToString() != null || Session["ActionOn"].ToString() != "")
                {
                    bindgrid(Session["NoticeDate"].ToString(), Session["ActionOn"].ToString());
                    //string Month = string.Empty;
                    //string Day = string.Empty;
                    //string NoticeDatetitle = string.Empty;

                    //con.Open();
                    //cmd = new SqlCommand("Proc_SalesNotice", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 50));
                    //cmd.Parameters.AddWithValue("@NoticeDate", Session["NoticeDate"].ToString());
                    //cmd.Parameters["@mode"].Value = "GetNoticeDate";
                    //da = new SqlDataAdapter();
                    //da.SelectCommand = cmd;
                    //ds = new DataSet();
                    //da.Fill(ds, "NoticeDate");
                    //con.Close();
                    //if (Information.IsDBNull(ds.Tables["NoticeDate"].Rows[0]["NoticeDateTitle"].ToString()) == false)
                    //{
                    //    NoticeDatetitle = ds.Tables["NoticeDate"].Rows[0]["NoticeDateTitle"].ToString();
                    //}
                    //if (Information.IsDBNull(ds.Tables["NoticeDate"].Rows[0]["Month"].ToString()) == false)
                    //{
                    //    Month = ds.Tables["NoticeDate"].Rows[0]["Month"].ToString();
                    //}
                    //if (Information.IsDBNull(ds.Tables["NoticeDate"].Rows[0]["Day"].ToString()) == false)
                    //{
                    //    Day = ds.Tables["NoticeDate"].Rows[0]["Day"].ToString();
                    //}

                    //NoticeDate.Text = "<span class='calmonth' title='" + NoticeDatetitle + "'>" + Month + "<span class='day'>" + Day + "</span></span>";
                }
                else
                {
                    Response.Redirect("sale-notice.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("sale-notice.aspx");
            }
            finally
            {
                Session["NoticeDate"] = "";
                con.Close();
            }
        }
    }
    public void bindgrid(string AuctionDateTime, string AuctionOn)
    {
        try
        {
            con.Open();
            cmd = new SqlCommand("Proc_SalesNotice", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 50));
            cmd.Parameters.AddWithValue("@AuctionDateTime", AuctionDateTime);
            cmd.Parameters.AddWithValue("@AuctionOn", AuctionOn);
            cmd.Parameters["@mode"].Value = "ViewSalesNoticeInDetails";
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
            //string Noticedate = "";
            //string NoticeDatetitle = "";
            //if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "NoticeDateTitle")) == false)
            //{
            //    NoticeDatetitle = DataBinder.Eval(e.Item.DataItem, "NoticeDateTitle").ToString();
            //}
            //else
            //{
            //    NoticeDatetitle = "";
            //}

            //string Day = "";
            //if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Day")) == false)
            //{
            //    Day = DataBinder.Eval(e.Item.DataItem, "Day").ToString();
            //}
            //else
            //{
            //    Day = "";
            //}
            //string Month = "";
            //if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Month")) == false)
            //{
            //    Month = DataBinder.Eval(e.Item.DataItem, "Month").ToString();
            //}
            //else
            //{
            //    Month = "";
            //}
            //Noticedate = "<span class='calmonth' title=" + NoticeDatetitle + ">" + Month + "<span class='day'>" + Day + "</span></span>";
            //e.Item.Cells[1].Text = Noticedate;

            LinkButton Readmore = (LinkButton)e.Item.FindControl("lnkReadMore");
            Readmore.Attributes.Add("target", "_blank");
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Title")) == false)
            {
                Readmore.Attributes.Add("href", "press/" + DataBinder.Eval(e.Item.DataItem, "FileName").ToString());
            }
            else
            {
                Readmore.Text = "";
            }

        }
    }
    protected void DgSalesNotice_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (!(e.CommandName == "Page"))
        {
            string NoticeDate = e.Item.Cells[0].Text;
            string FileName = e.Item.Cells[0].Text;
            string FilePath = "";
            if (e.CommandName == "ReadMore")
            {
                FilePath = Server.MapPath("press/" + FileName);
                WebClient client = new WebClient();
                Byte[] buffer = client.DownloadData(FilePath);

                if (buffer != null)
                {
                    Response.ContentType = "application/pdf";

                    Response.AddHeader("content-length", buffer.Length.ToString());

                    Response.WriteFile(FilePath);
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                    Response.WriteFile(FilePath);
                }
            }
        }
    }
}