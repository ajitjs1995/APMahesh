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

public partial class press_release : System.Web.UI.Page
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
        bindgrid();
    }
    public void bindgrid()
    {
        try
        {
            int cnt = 0;
            con.Open();
            cmd = new SqlCommand("USP_PressRelease", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 50));

            cmd.Parameters["@mode"].Value = "CountPressRelease";
            cnt = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();


            if (cnt > 0)
            {
                con.Open();
                cmd = new SqlCommand("USP_PressRelease", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 50));

                cmd.Parameters["@mode"].Value = "ViewPressRelease";
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds, "Table");
                con.Close();

                if (!(ds.Tables["Table"].Rows.Count == 0))
                {
                    //lblmsg.Text = ds.Tables["tbl_NewsDtls2"].Rows.Count + " Records found !!";
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
            LinkButton Readmore = (LinkButton)e.Item.FindControl("lnkReadMore");
            //Readmore.Attributes.Add("target", "_blank");
            //Readmore.Attributes.Add("href", "sales-notice-details.aspx");

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
            Noticedate = "<span class='calmonth' title='" + NoticeDatetitle + "'>" + Month + "<span class='day'>" + Day + "</span></span>";
            e.Item.Cells[1].Text = Noticedate;

            DateTime DateOfNotie = new DateTime();
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "NoticeDate")) == false)
            {
                DateOfNotie = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "NoticeDate").ToString());
                e.Item.Cells[0].Text = DateOfNotie.ToString("yyyy-MM-dd");
            }
            string Title = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Title")) == false)
            {
                Title = DataBinder.Eval(e.Item.DataItem, "Title").ToString();
            }
            else
            {
                Title = "";
            }
            string Description = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Description")) == false)
            {
                Description = DataBinder.Eval(e.Item.DataItem, "Description").ToString();
            }
            else
            {
                Description = "";
            }
            e.Item.Cells[2].Text = "<H3>" + Title + "</H3>" + Description;
        }
    }
    protected void DgSalesNotice_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (!(e.CommandName == "Page"))
        {
            string NoticeDate = e.Item.Cells[0].Text;
            string filename = e.Item.Cells[4].Text;
            LinkButton Readmore = (LinkButton)e.Item.FindControl("lnkReadMore");
            if (e.CommandName == "ReadMore")
            {
                if (filename.Contains(".pdf") || filename.Contains(".jpg") || filename.Contains(".png") || filename.Contains(".doc") || filename.Contains(".zip") || filename.Contains(".xls"))
                {



                    Session["NoticeDate"] = NoticeDate;
                    Readmore.Attributes.Add("target", "_blank");
                    //NoticeDate = Convert.ToDateTime(NoticeDate).ToString("yyyyMMdd");
                    //Response.Redirect("press-release-details.aspx?Date=" + NoticeDate);
                    Response.Redirect("press-release-details.aspx");
                }
                else
                {
                    Response.Redirect(filename);
                    Readmore.Attributes.Add("target", "_blank");
                }
               
            }
            
        }
    }
    protected void DgSalesNotice_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        DgSalesNotice.CurrentPageIndex = e.NewPageIndex;
        bindgrid();

        string x1 = DgSalesNotice.CurrentPageIndex.ToString();
        int currPage = Convert.ToInt32(x1) + 1;
        string x2 = DgSalesNotice.PageCount.ToString();
    }
}