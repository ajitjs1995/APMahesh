using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;

public partial class rtgs_neft_micr_branch_codes : System.Web.UI.Page
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
           // con.Close();
            con.Open();
            cmd = new SqlCommand("USP_BranchMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Query", SqlDbType.VarChar, 50));
            

            cmd.Parameters["@Query"].Value = "CntBranchDtls";
            cnt1 = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();

            if (cnt1 > 0)
            {
                con.Open();
                cmd = new SqlCommand("USP_BranchMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Query", SqlDbType.VarChar, 50));

               

                cmd.Parameters["@Query"].Value = "GetBranchDtls";
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds, "Branch_Mastre");
                con.Close();

                if (!(ds.Tables["Branch_Mastre"].Rows.Count == 0))
                {
                    // lblmsg.Text = ds.Tables["Branch_Mastre"].Rows.Count + " Records found !!";
                    //lblmsg.Visible = true;
                    dg_AdmOff.Visible = true;
                    //viewtbl.Visible = true;
                    try
                    {
                        dg_AdmOff.DataSource = ds.Tables["Branch_Mastre"].DefaultView;
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
            string ID = e.Item.Cells[0].Text;
            LinkButton Readmore = (LinkButton)e.Item.FindControl("lnkname");
            if (e.CommandName == "CmdViewDetail")
            {
                Session["id"] = ID;
                Readmore.Attributes.Add("target", "_blank");
                //Response.Write("<script type='text/javascript'>detailedresults=window.open('branch-code-details.aspx?id=" + ID + " ','frmMensajeBox','height=440px,width=840px,resizable=yes,scrollbars=yes,top=50,left=50');</script>");
                Response.Redirect("branch-code-details.aspx?id=" + ID + "");

            }
        }
    }
    protected void dg_AdmOff_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.SelectedItem | e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.EditItem)
        {
            LinkButton Readmore = (LinkButton)e.Item.FindControl("lnkname");
            string id = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Br_ID")) == false)
            {
                id = DataBinder.Eval(e.Item.DataItem, "Br_ID").ToString();
            }
            else
            {
                id = "--";
            }

            string District = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "District")) == false)
            {
                District = DataBinder.Eval(e.Item.DataItem, "District").ToString();
            }
            else
            {
                District = "";
            }

            string State = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "State")) == false)
            {
                State = DataBinder.Eval(e.Item.DataItem, "State").ToString();
            }
            else
            {
                State = "";
            }

            string Name = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Br_Name")) == false)
            {
                Name = DataBinder.Eval(e.Item.DataItem, "Br_Name").ToString();
            }
            else
            {
                Name = "--";
            }
            LinkButton lnkname = (LinkButton)e.Item.Cells[1].FindControl("lnkname");
            lnkname.Text = Name + "," + District + " " + State;
            Session["id"] = id;
        }
    }
}