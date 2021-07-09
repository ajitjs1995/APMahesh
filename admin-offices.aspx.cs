using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

public partial class AdminOffice : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            //lblmsg.Visible = false;
            dg_AdmOff.Visible = true;
            Fill_Grid();
        }
    }
    public void Fill_Grid()
    {
        //lblSrchErr.Text = "";
        try
        {

            int cnt1 = 0;
            con.Close();
            con.Open();
            cmd = new SqlCommand("USP_RegionalMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Query", SqlDbType.VarChar, 50));
           

            cmd.Parameters["@Query"].Value = "cntSrchRegUsr";
            cnt1 = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();

            if (cnt1 > 0)
            {
                con.Open();
                cmd = new SqlCommand("USP_RegionalMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Query", SqlDbType.VarChar, 50));

               

                cmd.Parameters["@Query"].Value = "getSrchRegUsr";
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds, "tbl_usr");
                con.Close();

                if (!(ds.Tables["tbl_usr"].Rows.Count == 0))
                {
                   // lblmsg.Text = ds.Tables["tbl_usr"].Rows.Count + " Records found !!";
                    //lblmsg.Visible = true;
                    dg_AdmOff.Visible = true;
                    //viewtbl.Visible = true;
                    try
                    {
                        dg_AdmOff.DataSource = ds.Tables["tbl_usr"].DefaultView;
                        dg_AdmOff.DataBind();
                    }
                    catch
                    {
                        try
                        {
                            this.dg_AdmOff.CurrentPageIndex = 0;
                            this.dg_AdmOff.DataBind();
                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex.ToString());
                        }
                        // viewtbl.Visible = true; ;
                    }
                }
                else
                {
                    dg_AdmOff.DataSource = null;
                    dg_AdmOff.DataBind();
                    dg_AdmOff.Visible = false;
                    //lblmsg.Text = "No Records found !!";
                    // viewtbl.Visible = false;
                }
            }

            else
            {
                dg_AdmOff.DataSource = null;
                dg_AdmOff.DataBind();
                dg_AdmOff.Visible = false;
                //lblmsg.Text = "No Records found !!";
                // viewtbl.Visible = false;
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
    
    protected void dg_AdmOff_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (!(e.CommandName == "Page"))
        {
            string QueryId = e.Item.Cells[0].Text;
            string Name = e.Item.Cells[2].Text;
            
            string district = e.Item.Cells[8].Text;
            if (e.CommandName == "CmdViewDetail")
            {
              
                Session["id"] = QueryId;
                LinkButton Readmore = (LinkButton)e.Item.FindControl("lnkname");
                Readmore.Attributes.Add("target", "_blank");
                //Response.Write("<script type='text/javascript'>detailedresults=window.open('AdminOfficeDetails.aspx?id=" + QueryId + "','frmMensajeBox','height=440px,width=840px,resizable=yes,scrollbars=yes,top=50,left=50');</script>");
                Response.Redirect("AdminOfficeDetails.aspx?id=" + QueryId + "");
            }
        }
    }
    protected void dg_AdmOff_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.SelectedItem | e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.EditItem)
        {
            string id = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "RO_ID")) == false)
            {
                id = DataBinder.Eval(e.Item.DataItem, "RO_ID").ToString();
            }
            else
            {
                id = "--";
            }

            string City = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "City")) == false)
            {
                City = DataBinder.Eval(e.Item.DataItem, "City").ToString();
            }
            else
            {
                City = "--";
            }

            string PinCode = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "PinZipCode")) == false)
            {
                PinCode = DataBinder.Eval(e.Item.DataItem, "PinZipCode").ToString();
            }
            else
            {
                PinCode = "--";
            }

            string Name = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Name")) == false)
            {
                Name = DataBinder.Eval(e.Item.DataItem, "Name").ToString();
            }
            else
            {
                Name = "--";
            }
            LinkButton lnkname = (LinkButton)e.Item.Cells[1].FindControl("lnkname");
            lnkname.Text = Name + "," + City + " " + PinCode;
            Session["id"] = id;
        }
    }
}