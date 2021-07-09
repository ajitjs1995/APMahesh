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

public partial class Atm_Locator : System.Web.UI.Page
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
            //lblmsg.Text = "";
            //FillState();
            //ddldistrict.DataBind();
            //ddldistrict.Items.Insert(0, " Select District ");
            //ddldistrict.SelectedIndex = 0;
            //ddlsub.DataBind();
            //ddlsub.Items.Insert(0, " Select Type ");
            //ddlsub.SelectedIndex = 0;
            //lblmsg.Visible = false;
            dg_Atm.Visible = true;
            Fill_Grid();
        }

    }
    //public void FillState()
    //{
    //    try
    //    {
    //        SqlCommand cmd = new SqlCommand("USP_AtmMaster", con);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.Add("@Query", "FillState");
    //        con.Open();
    //        SqlDataAdapter ad = new SqlDataAdapter(cmd);
    //        DataSet ds = new DataSet();
    //        ad.Fill(ds, "TblStateMaster");
    //        if (ds.Tables["TblStateMaster"].Rows.Count == 0)
    //        {

    //            ddlstate.Items.Clear();

    //            ddlstate.Items.Insert(0, " Select State ");
    //            ddlstate.SelectedIndex = 0;
    //        }
    //        else
    //        {
    //            ddlstate.Items.Clear();
    //            ddlstate.DataSource = ds.Tables["TblStateMaster"].DefaultView;
    //            ddlstate.DataTextField = "State";
    //            //ddlstate.DataValueField = "ID";
    //            ddlstate.DataBind();
    //            ddlstate.Items.Insert(0, " Select State ");
    //            ddlstate.SelectedIndex = 0;

    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //    finally
    //    {
    //        con.Close();
    //    }

    //}
    //public void FillDistrict()
    //{
    //    try
    //    {
    //        con.Open();
    //        SqlCommand cmd = new SqlCommand("USP_AtmMaster", con);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.Add("@Query", "FillDistrict");
    //        if (ddlstate.SelectedItem.Text != " Select State ")
    //        {
    //            cmd.Parameters.AddWithValue("@state", ddlstate.SelectedValue);
    //        }
    //        SqlDataAdapter ad = new SqlDataAdapter(cmd);
    //        DataSet ds = new DataSet();
    //        ad.Fill(ds, "TblDistrictMaster");
    //        if (ds.Tables["TblDistrictMaster"].Rows.Count == 0)
    //        {
    //            ddldistrict.Items.Clear();
    //            ddldistrict.Items.Insert(0, " Select District ");
    //            ddldistrict.SelectedIndex = 0;
    //        }
    //        else
    //        {
    //            ddldistrict.Items.Clear();
    //            ddldistrict.DataSource = ds.Tables["TblDistrictMaster"].DefaultView;
    //            ddldistrict.DataTextField = "District";
    //           // ddldistrict.DataValueField = "ID";
    //            ddldistrict.DataBind();
    //            ddldistrict.Items.Insert(0, " Select District ");
    //            ddldistrict.SelectedIndex = 0;
    //        }
    //    }

    //    catch (Exception ex)
    //    {

    //    }
    //    finally
    //    {
    //        con.Close();
    //    }
    //}
    public void Fill_Grid()
    {
        //lblSrchErr.Text = "";
        try
        {

            int cnt1 = 0;
            con.Close();
            con.Open();
            cmd = new SqlCommand("USP_AtmMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Query", SqlDbType.VarChar, 20));
            //if (!(ddlstate.SelectedIndex == 0))
            //{
            //    cmd.Parameters.AddWithValue("@state", ddlstate.SelectedValue);
            //}
            //if (!(ddldistrict.SelectedIndex == 0))
            //{
            //    cmd.Parameters.AddWithValue("@district", ddldistrict.SelectedValue);
            //}
            //if (!(ddlsub.SelectedIndex == 0))
            //{
            //    cmd.Parameters.AddWithValue("@branchtype", ddlsub.SelectedValue);
            //}
            //if (!string.IsNullOrEmpty(txtlocation.Text))
            //{
            //    cmd.Parameters.AddWithValue("@location", txtlocation.Text.Trim());
            //}
            cmd.Parameters["@Query"].Value = "cntSrchAtmUsr";
            cnt1 = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();

            if (cnt1 > 0)
            {
                con.Open();
                cmd = new SqlCommand("USP_AtmMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Query", SqlDbType.VarChar, 20));
                //if (!(ddlstate.SelectedIndex == 0))
                //{
                //    cmd.Parameters.AddWithValue("@state", ddlstate.SelectedValue);
                //}
                //if (!(ddldistrict.SelectedIndex == 0))
                //{
                //    cmd.Parameters.AddWithValue("@district", ddldistrict.SelectedValue);
                //}
                //if (!(ddlsub.SelectedIndex == 0))
                //{
                //    cmd.Parameters.AddWithValue("@branchtype", ddlsub.SelectedValue);
                //}
                //if (!string.IsNullOrEmpty(txtlocation.Text))
                //{
                //    cmd.Parameters.AddWithValue("@location", txtlocation.Text.Trim());
                //}

                cmd.Parameters["@Query"].Value = "getSrchAtmUsr";
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds, "tbl_usr");
                con.Close();

                if (!(ds.Tables["tbl_usr"].Rows.Count == 0))
                {
                    //lblmsg.Text = ds.Tables["tbl_usr"].Rows.Count + " Records found !!";
                    //lblmsg.Visible = true;
                    dg_Atm.Visible = true;
                    //viewtbl.Visible = true;
                    try
                    {
                        dg_Atm.DataSource = ds.Tables["tbl_usr"].DefaultView;
                        dg_Atm.DataBind();
                    }
                    catch
                    {
                        try
                        {
                            this.dg_Atm.CurrentPageIndex = 0;
                            this.dg_Atm.DataBind();
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
                    dg_Atm.DataSource = null;
                    dg_Atm.DataBind();
                    dg_Atm.Visible = false;
                   // lblmsg.Text = "No Records found !!";
                    // viewtbl.Visible = false;
                }
            }

            else
            {
                dg_Atm.DataSource = null;
                dg_Atm.DataBind();
                dg_Atm.Visible = false;
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
    protected void dg_Atm_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        
            if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.SelectedItem | e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.EditItem)
            {
               

                string State = "";
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "State")) == false)
                {
                    State = (string)DataBinder.Eval(e.Item.DataItem, "State");
                }
                else
                {
                    State = "";
                }
                string District = "";
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "District")) == false)
                {
                    District = (String)DataBinder.Eval(e.Item.DataItem, "District");
                }
                else
                {
                    District = "";
                }

                Label lblStatedistrict = (Label)e.Item.Cells[1].FindControl("lblStatedistrict");
                lblStatedistrict.Text =  State + " - " + District;

                string Location = "";
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Location")) == false)
                {
                    Location = (string)DataBinder.Eval(e.Item.DataItem, "Location");
                    ((Label)e.Item.Cells[1].FindControl("lbllocation")).Text ="<strong> Location : </strong>"+ Location + "<br/>";
                }
                else
                {
                    Location = "";
                }

                string Address = "";
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Address")) == false)
                {
                    Address = (string)DataBinder.Eval(e.Item.DataItem, "Address");

                }
                else
                {
                    Address = "";
                }
                Label lblAdd = (Label)e.Item.Cells[1].FindControl("lblAdd");
                lblAdd.Text =  Address;

                string Site = "";
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Type")) == false)
                {
                    Site = (String)DataBinder.Eval(e.Item.DataItem, "Type");
                    ((Label)e.Item.Cells[1].FindControl("lblsite")).Text = " <strong> Branch Type : </strong> " + Site + "<br/>";
                }
                else
                {
                    Site = "";
                }
               
                string Active = "";
                if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Atm_Active")) == false)
                {
                    Active = DataBinder.Eval(e.Item.DataItem, "Atm_Active").ToString();
                }
                else
                {
                    Active = "N";
                }
                
            }
        
    }
    protected void dg_Atm_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        {
            dg_Atm.CurrentPageIndex = e.NewPageIndex;
            Fill_Grid();
            string x1 = dg_Atm.CurrentPageIndex.ToString();
            int currPage = Convert.ToInt32(x1) + 1;
            string x2 = dg_Atm.PageCount.ToString();
        }
    }
    //protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlstate.SelectedIndex != 0)
    //    {
    //        FillDistrict();
    //    }

    //    else
    //    {
    //        ddldistrict.Items.Clear();
    //        ddldistrict.Items.Insert(0, " Select District ");
    //        ddldistrict.SelectedIndex = 0;

    //    }
    //}
    //private bool chkdata()
    //{
    //    if (ddlstate.SelectedIndex == 0 && ddldistrict.SelectedIndex == 0 && string.IsNullOrEmpty(txtlocation.Text.Trim()))
    //    {
    //        LblError.Text = "Please select / enter atleast one field!!!";
    //        ddlstate.Focus();
    //        return false;
    //    }
        
    //    //else if (ddlstate.SelectedIndex != 0 && CheckState() == false)
    //    //{
    //    //    LblError.Text = "Please Select valid State !!";
    //    //    ddlstate.Focus();
    //    //    return false;
    //    //}

    //    //else if (ddldistrict.SelectedIndex != 0 && CheckDistrict() == false)
    //    //{
    //    //    LblError.Text = "Please Select valid district";
    //    //    ddldistrict.Focus();
    //    //    return false;
    //    //}
    //    //else if (ddldistrict.SelectedIndex != 0 && !Regex.IsMatch(ddldistrict.SelectedItem.Text, "^[a-zA-Z0-9-– ]+$"))
    //    //{
    //    //    LblError.Text = "please Select valid district !!";
    //    //    ddldistrict.Focus();
    //    //    return false;
    //    //}
    //    //else if (ddldistrict.SelectedIndex != 0 && !Regex.IsMatch(ddldistrict.SelectedValue, "^[0-9]+$"))
    //    //{
    //    //    LblError.Text = "please Select valid district !!";
    //    //    ddldistrict.Focus();
    //    //    return false;
    //    //}
    //    else if (!string.IsNullOrEmpty(txtlocation.Text.Trim()) && !Regex.IsMatch(txtlocation.Text, "^[a-z.A-Z-–(),/#&! ]+$"))
    //    {
    //        LblError.Text = "Please enter valid ATM location !!";
    //        txtlocation.Focus();
    //        return false;
    //    }
    //    else if (!string.IsNullOrEmpty(txtlocation.Text.Trim()) && txtlocation.Text.Length < 2)
    //    {
    //        LblError.Text = "ATM location should be greater than the 2 charactors !!";
    //        txtlocation.Focus();
    //        return false;
    //    }
    //    else if (!string.IsNullOrEmpty(txtlocation.Text.Trim()) && txtlocation.Text.Length > 100)
    //    {
    //        LblError.Text = "ATM location should be less than the 100 charactors !!";
    //        txtlocation.Focus();
    //        return false;
    //    }
    //    else
    //    {
    //        LblError.Text = "";
    //        return true;
    //    }
    //}

    //public bool CheckState()
    //{
    //    int cnt = 0;
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("USP_StateMaster", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.Add(new SqlParameter("@Query", SqlDbType.VarChar, 50));
    //    if (ddlstate.SelectedItem.Text != "Please select state" && ddlstate.SelectedIndex != 0)
    //    {
    //        cmd.Parameters.AddWithValue("@Name", ddlstate.SelectedItem.Text);
    //        cmd.Parameters.AddWithValue("@ID", ddlstate.SelectedValue);
    //    }

    //    cmd.Parameters["@Query"].Value = "CheckState";
    //    cnt = Convert.ToInt32(cmd.ExecuteScalar());
    //    con.Close();
    //    if (cnt > 0)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
    //public bool CheckDistrict()
    //{
    //    int cnt = 0;
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("USP_DistrictMaster", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.Add(new SqlParameter("@Query", SqlDbType.VarChar, 50));
    //    if (ddldistrict.SelectedItem.Text != "Please select district" && ddldistrict.SelectedIndex != 0)
    //    {
    //        cmd.Parameters.AddWithValue("@Name", ddldistrict.SelectedItem.Text);
    //        cmd.Parameters.AddWithValue("@ID", ddldistrict.SelectedValue);

    //    }
    //    cmd.Parameters["@Query"].Value = "CheckDistrict";
    //    cnt = Convert.ToInt32(cmd.ExecuteScalar());
    //    con.Close();
    //    if (cnt > 0)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
    ////protected void Btnsearch_Click(object sender, EventArgs e)
    ////{
    ////    try
    ////    {
    ////        if (chkdata() == true)
    ////        {

    ////            lblmsg.Visible = true;
    ////            Fill_Grid();
    ////        }
    ////        else
    ////        {

    ////            LblError.Text = LblError.Text;

    ////        }
    ////    }
    ////    catch (Exception exc)
    ////    {
    ////        Response.Write(exc);
    ////    }
    ////    finally
    ////    {
    ////        con.Close();
    ////    }
    ////}

    ////protected void Btnreset_Click(object sender, EventArgs e)
    ////{
    ////    lblmsg.Text = "";
    ////    ddlstate.SelectedIndex = 0;
    ////    ddldistrict.Items.Clear();
    ////    ddldistrict.Items.Insert(0, " Select District ");
    ////    ddldistrict.SelectedIndex = 0;
    ////    txtlocation.Text = "";
    ////    ddlsub.SelectedIndex = 0;
    ////    dg_Atm.Visible = false;
    ////    LblError.Text = "";
    ////}
}