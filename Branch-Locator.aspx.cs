using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Branch_Locator : System.Web.UI.Page
{
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    System.Data.DataSet ds = new System.Data.DataSet();
    System.Data.DataSet ds1 = new System.Data.DataSet();
    DataTable dt;
    SqlDataReader dr;
    public SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["TMBCON"].ToString());
  
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
        //stt.DataValueField = "Br_ID";
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
       //ctyy.DataValueField = "Br_ID";
       ctyy.DataBind();
     con.Close();

       
        
     }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //lblmsg.Visible = false;
            dg_AdmOff.Visible = false;
            //  txtbranch.Attributes.Add("autocomplete", "off");
              msg.Text = "Enter the keyword in the search box below to search.";
              state();
              ctyy.Items.Add("Please Select District");
           
        }


    }
    protected void btnsrch_Click(object sender, EventArgs e)
    {
        
        //if(chkdata()==true)
        //{
            Fill_Grid();
        //}
       
    }

    public void Fill_Grid()
    {

        //lblSrchErr.Text = "";
        try
        {

            int cnt1 = 0;
            string text;
            
            
            // con.Close();
            con.Open();
            cmd = new SqlCommand("USP_BranchMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Query", SqlDbType.VarChar, 50));
            //if (!string.IsNullOrEmpty(txtbranch.Text))
            //{
            //    cmd.Parameters.AddWithValue("@Name", txtbranch.Text.Trim());
            //}
            //if (!string.IsNullOrEmpty(txtarea.Text))
            //{
            //    cmd.Parameters.AddWithValue("@Area", txtarea.Text.Trim());
            //}

            cmd.Parameters["@Query"].Value = "CntBranchDtls";
            cnt1 = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();

            if (cnt1 > 0)
            {
                 if (ctyy.SelectedItem.Text == null || ctyy.SelectedItem.Text == "Please Select District")
            {
                text = stt.SelectedItem.Text;
                con.Open();
                cmd = new SqlCommand("USP_BranchMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Query", SqlDbType.VarChar, 50));


               
                cmd.Parameters["@Query"].Value = "SearchBranchState";
                cmd.Parameters.AddWithValue("@Name", text.Trim());
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds, "Branch_Mastre");
                con.Close();

                if (!(ds.Tables["Branch_Mastre"].Rows.Count == 0))
                    {
                    if (ds.Tables["Branch_Mastre"].Rows.Count == 1)
                        {
                        LblError.ForeColor = Color.Green;
                        LblError.Text = ds.Tables["Branch_Mastre"].Rows.Count + " Record found !!";
                        }
                    else
                        {
                        LblError.ForeColor = Color.Green;
                        LblError.Text = ds.Tables["Branch_Mastre"].Rows.Count + " Records found !!";
                        }
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

                    LblError.ForeColor = Color.Red;
                    LblError.Text = "No Records found !!";
                    // viewtbl.Visible = false;


                    }
                
             }

                 else
                     {

                     text = ctyy.SelectedItem.Text;
                     con.Open();
                     cmd = new SqlCommand("USP_BranchMaster", con);
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.Add(new SqlParameter("@Query", SqlDbType.VarChar, 50));


                    
                     cmd.Parameters["@Query"].Value = "SearchBranchDistrict";
                     cmd.Parameters.AddWithValue("@Name", text.Trim());
                     da = new SqlDataAdapter();
                     da.SelectCommand = cmd;
                     ds = new DataSet();
                     da.Fill(ds, "Branch_Mastre");
                     con.Close();

                     if (!(ds.Tables["Branch_Mastre"].Rows.Count == 0))
                         {
                         if (ds.Tables["Branch_Mastre"].Rows.Count == 1)
                             {
                             LblError.ForeColor = Color.Green;
                             LblError.Text = ds.Tables["Branch_Mastre"].Rows.Count + " Record found !!";
                             }
                         else
                             {
                             LblError.ForeColor = Color.Green;
                             LblError.Text = ds.Tables["Branch_Mastre"].Rows.Count + " Records found !!";
                             }
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

                         LblError.ForeColor = Color.Red;
                         LblError.Text = "No Records found !!";
                         // viewtbl.Visible = false;


                         }

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
   
    protected void btnreset_Click(object sender, EventArgs e)
    {
        cleardata();
    }
    public void cleardata()
    {
        LblError.Visible = false;
        dg_AdmOff.Visible = false;

        stt.Items.Clear();
        state();
       ctyy.Items.Clear();
       ctyy.Items.Add("Please Select District");

    }
    protected void state_selection(object sender, EventArgs e)
        {

      city();
       
      
        }
   
    //private bool chkdata()
    //{
    //    if (string.IsNullOrEmpty(txtbranch.Text.Trim()))
    //    {
    //        LblError.ForeColor = Color.Red;
    //        LblError.Text = "State or District name cannot be left blank !!!";

    //        txtbranch.Focus();
    //        return false;
    //    }


    //    else if (!string.IsNullOrEmpty(txtbranch.Text.Trim()) && !Regex.IsMatch(txtbranch.Text, "^[a-z.A-Z0-9-–(),/#&! ]+$"))
    //    {
    //        LblError.ForeColor = Color.Red;
    //        LblError.Text = "Please enter valid keyword !!";
    //        txtbranch.Focus();
    //        return false;
    //    }
    //    else if (!string.IsNullOrEmpty(txtbranch.Text.Trim()) && txtbranch.Text.Length <= 2)
    //    {
    //        LblError.ForeColor = Color.Red;
    //        LblError.Text = "Minimum two characters are required !!";
    //        txtbranch.Focus();
    //        return false;
    //    }
    //    else if (!string.IsNullOrEmpty(txtbranch.Text.Trim()) && txtbranch.Text.Length > 100)
    //    {
    //        LblError.ForeColor = Color.Red;
    //        LblError.Text = "Keyword to be searched should be less than the 100 characters !!";
    //        txtbranch.Focus();
    //        return false;
    //    }
       
    //    else
    //    {
    //        LblError.Text = "";
    //        return true;
    //    }
    //}
    //protected void Btnsearch_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (chkdata() == true)
    //        {

    //            lblmsg.Visible = true;
    //            Fill_Grid();
    //        }
    //        else
    //        {
    //            //fillgrid();
    //            LblError.Text = LblError.Text;
    //        }
    //    }
    //    catch (Exception exc)
    //    {
    //        Response.Write(exc);
    //    }
    //    finally
    //    {
    //        con.Close();
    //    }
    //}
    //protected void Btnreset_Click(object sender, EventArgs e)
    //{
    //    txtbranch.Text = "";
    //    txtarea.Text = "";
    //}
    protected void dg_AdmOff_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (!(e.CommandName == "Page"))
        {
            string queryid = e.Item.Cells[0].Text;
            string IFSC=e.Item.Cells[2].Text;
            //string Name = e.Item.Cells[4].Text;

            //string district = e.Item.Cells[5].Text;
            if (e.CommandName == "CmdViewDetail")
            {
                Session["id"] = IFSC.Trim();
                //Response.Write("<script type='text/javascript'>detailedresults=window.open('Branch-Locator-Details.aspx?ifsc="+IFSC+" ','frmMensajeBox','height=440px,width=840px,resizable=yes,scrollbars=yes,top=50,left=50');</script>");
                Response.Redirect("Branch-Locator-Details.aspx?ifsc=" + IFSC + "");
            }
        }
    }
    protected void dg_AdmOff_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.SelectedItem | e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.EditItem)
        {
            string id = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Br_ID")) == false)
            {
                id = DataBinder.Eval(e.Item.DataItem, "Br_ID").ToString();
            }
            else
            {
                id = "--";
            }

            string Area = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Area")) == false)
            {
                Area = " , " + DataBinder.Eval(e.Item.DataItem, "Area").ToString();
            }
            else
            {
                Area = null;
            }

            string City = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "City")) == false)
            {
                City = " , " + DataBinder.Eval(e.Item.DataItem, "City").ToString();
            }
            else
            {
                City = null;
            }

            string Pin = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Pin_Code")) == false)
            {
                Pin =" , "+ DataBinder.Eval(e.Item.DataItem, "Pin_Code").ToString();
            }
            else
            {
                Pin = null;
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
            string Address = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Address")) == false)
            {
                Address = DataBinder.Eval(e.Item.DataItem, "Address").ToString();
            }
            else
            {
                Address = "";
            }
            LinkButton lnkname = (LinkButton)e.Item.Cells[1].FindControl("lnkname");
            Label addlbl = (Label)e.Item.Cells[1].FindControl("addlbl");

            lnkname.Text = "Branch - "+Name ;
            addlbl.Text = Address + Area + Pin;        
            Session["id"] = id;
        }
    }

    protected void city_selection(object sender, EventArgs e)
        {

        }
}