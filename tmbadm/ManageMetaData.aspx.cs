using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

public partial class Admin_ManageMetaData : System.Web.UI.Page
{
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    SqlDataReader dr;
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["TMBCON"].ToString());
    string strAlpha;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["log_name"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
        {
            if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
            {
                Response.Redirect("admlogin.aspx");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    bind_grid();
                }
            }

            if (Session["usr_privilege"].ToString() == "Checker")
            {
                Button1.Enabled = false;
            }

            if (Session["usr_privilege"].ToString() != "Maker")
            {
                Button3.Visible = true;
                Button1.Visible = false;
            }
            if (Session["usr_privilege"].ToString() == "admin")
            {
                Button1.Visible = true;
                Button2.Visible = true;
                Button3.Visible = true;
                btnCancel.Visible = true;
            }
            try
            {
                con.Open();
                int pgid = int.Parse(Session["PgId1"].ToString());

                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strPageId", pgid);
                cmd.Parameters["@Mode"].Value = "chkval";
                string val = Convert.ToString(cmd.ExecuteScalar());

                if (Session["usr_privilege"].ToString() != "Maker")
                {
                    if (val == "Y")
                    {
                        Button3.Visible = false;
                    }
                    else
                    {
                        Button3.Visible = true;
                    }
                }
                else
                {
                    Button3.Visible = false;
                }
            }
            catch
            {
            }
            finally
            {
                con.Close();
            }
        }
    }
    public bool chkNm(string data1)
    {

        string allowed1 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ,. ";
        int ALLOW_FLAG = 0;

        string txtchar = "";
        string allchar = "";

        int i = 0;
        int j = 0;
        int next1 = 0;

        int flag1 = 0;
        int flag2 = 0;
        int charfound = 0;

        for (i = 0; i <= data1.Length - 1; i++)
        {
            txtchar = Convert.ToString(data1[i]);
            charfound = 0;


            if (flag1 == i)
            {

                for (j = 0; j <= allowed1.Length - 1; j++)
                {
                    allchar = Convert.ToString(allowed1[j]);
                    flag2 = j + 1;
                    if (charfound == 0)
                    {
                        if (txtchar == allchar)
                        {
                            flag1 = flag1 + 1;
                            charfound = 1;
                        }
                        else
                        {

                            charfound = 0;
                        }
                    }
                }
            }
        }

        if (flag1 == data1.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool chk()
    {
        if (txtkeycont.Text == "")
        {
            lblerr.Text = "Please enter keyword content !!";
            txtkeycont.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtkeycont.Text) & chkNm(txtkeycont.Text) == false)
        {
            lblerr.Text = "Please enter valid keyword content !!";
            txtkeycont.Focus();
            return false;
        }
        else if (txtdesccont.Text == "")
        {
            lblerr.Text = "Please enter Description content !!";
            txtdesccont.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtdesccont.Text) & chkNm(txtdesccont.Text) == false)
        {
            lblerr.Text = "Please enter valid Description content !!";
            txtdesccont.Focus();
            return false;
        }
        else
        {
            return true;
        }
    }
    public void bind_grid()
    {
        try
        {


            int cnt1 = 0;
            int cnt2 = 0;
            int pgid = int.Parse(Session["PgId1"].ToString());
            string GetPgID = pgid.ToString();

            con.Close();
            con.Open();
            cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strPageId", GetPgID);
            cmd.Parameters["@Mode"].Value = "CntMenuItemMkr1";

            cnt1 = (int)cmd.ExecuteScalar();
            // con.Close();

            // con.Open();
            cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strPageId", GetPgID);
            cmd.Parameters["@Mode"].Value = "Cntpageid";

            cnt2 = (int)cmd.ExecuteScalar();
            //  con.Close();
            int cnt3 = cnt1 + cnt2;
            if (cnt2 > 0)
            {
                GetPgID = pgid.ToString();
                //  con.Open();
                cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strPageId", GetPgID);
                cmd.Parameters["@Mode"].Value = "Shitemeta";

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "tbl_MenuDtls1");
            }
            if (cnt2 > 0)
            {
                txtkeycont.Text = ds.Tables["tbl_MenuDtls1"].Rows[0]["KeyCont"].ToString();
                txtdesccont.Text = ds.Tables["tbl_MenuDtls1"].Rows[0]["DescCont"].ToString();
                lblAddEditHead.Text = "Update Meta Data";
                Button1.Text = "Update";
                btnCancel.Visible = false;
            }
        }
        catch (Exception ex)
        {
            string ma1 = "";
            ma1 = ex.ToString();

            if (!ma1.Contains("Thread was being aborted"))
            {
                try
                {
                    Response.Write(ex.Message);
                }
                catch
                {
                }
            }
        }
        finally
        {
            con.Close();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            if (chk() == true)
            {
                if (lblAddEditHead.Text == "Add Meta Data")
                {
                    cmd = new SqlCommand("Proc_ManageCmsPages", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 50));
                    cmd.Parameters.AddWithValue("@strPageId", Session["PgId1"]);
                    cmd.Parameters.AddWithValue("@strkeycont", txtkeycont.Text);
                    cmd.Parameters.AddWithValue("@strdesccont", txtdesccont.Text);
                    cmd.Parameters.AddWithValue("@strAction", rdbMainAct.SelectedValue);
                    cmd.Parameters["@Mode"].Value = "addmeta";
                    cmd.ExecuteNonQuery();
                    lblerr.Text = "Meta data added successfully ";
                    txtdesccont.Text = "";
                    txtkeycont.Text = "";
                    rdbMainAct.SelectedValue = "Y";
                    bind_grid();
                }
                else
                {
                    cmd = new SqlCommand("Proc_ManageCmsPages", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 50));
                    cmd.Parameters.AddWithValue("@strPageId", Session["PgId1"]);
                    cmd.Parameters.AddWithValue("@strkeycont", txtkeycont.Text);
                    cmd.Parameters.AddWithValue("@strdesccont", txtdesccont.Text);
                    cmd.Parameters.AddWithValue("@strAction", rdbMainAct.SelectedValue);
                    cmd.Parameters["@Mode"].Value = "editmeta";
                    cmd.ExecuteNonQuery();
                    lblerr.Text = "Meta data update successfully ";
                    txtdesccont.Text = "";
                    txtkeycont.Text = "";
                    rdbMainAct.SelectedValue = "Y";
                    //  bind_grid();

                    cmd = new SqlCommand("Proc_ManagePageMenuLinks", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd.Parameters.AddWithValue("@strPageId", Session["PgId1"]);
                    cmd.Parameters["@Mode"].Value = "Shitemeta";

                    da = new SqlDataAdapter();
                    da.SelectCommand = cmd;

                    da.Fill(ds, "tbl_MenuDtls1");
                    // con.Close();
                    txtkeycont.Text = ds.Tables["tbl_MenuDtls1"].Rows[0]["KeyCont"].ToString();
                    txtdesccont.Text = ds.Tables["tbl_MenuDtls1"].Rows[0]["DescCont"].ToString();
                    lblAddEditHead.Text = "Update Meta Data";
                    Button1.Text = "Update";
                    btnCancel.Visible = false;
                }
            }
        }
        catch
        {
        }
        finally
        {
            con.Close();
        }
        lblerr.Text = lblerr.Text;
        bind_grid();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtdesccont.Text = "";
        txtkeycont.Text = "";
        rdbMainAct.SelectedValue = "Y";
    }
    protected void dg_Menu_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (!(e.CommandName == "Page"))
        {
            string id = e.Item.Cells[0].Text;
            string keycont = e.Item.Cells[2].Text;
            string desccont = e.Item.Cells[3].Text;
            string act = e.Item.Cells[5].Text;
            string pgid = e.Item.Cells[6].Text;

            if (e.CommandName == "metaEdit")
            {
                Session["id"] = id;
                txtdesccont.Text = desccont;
                txtkeycont.Text = keycont;
                rdbMainAct.SelectedValue = act;
                lblAddEditHead.Text = "Update Meta Data";
                Button1.Text = "Update";
            }
            else if (e.CommandName == "metachk")
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("Proc_ManageCmsPages", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 50));

                    cmd.Parameters.AddWithValue("@strPageId", id);
                    cmd.Parameters["@Mode"].Value = "deletemeta";
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("Proc_ManageCmsPages", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 50));
                    cmd.Parameters.AddWithValue("@strid", id);
                    cmd.Parameters.AddWithValue("@strPageId", pgid);
                    cmd.Parameters.AddWithValue("@strkeycont", keycont);
                    cmd.Parameters.AddWithValue("@strdesccont", desccont);
                    cmd.Parameters.AddWithValue("@strAction", rdbMainAct.SelectedValue);
                    cmd.Parameters["@Mode"].Value = "addmetacheck";
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("Proc_ManageCmsPages", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 50));
                    cmd.Parameters.AddWithValue("@strPageId", id);
                    cmd.Parameters["@Mode"].Value = "updatechk";
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                }
                finally
                {
                    con.Close();
                }
                bind_grid();
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage_InnerPage.aspx");
    }
    protected void dg_Menu_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem || e.Item.ItemType == ListItemType.EditItem)
        {
            string Checked = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Checked")) == false)
            {
                Checked = DataBinder.Eval(e.Item.DataItem, "Checked").ToString();
            }
            else
            {
                Checked = "";
            }
            if (Checked == "Y")
            {
                ((LinkButton)e.Item.Cells[4].FindControl("LinkButton1")).Enabled = false;
                ((LinkButton)e.Item.Cells[4].FindControl("LinkButton1")).ForeColor = System.Drawing.Color.Gray;
            }
            else
            {
                if (Session["usr_privilege"].ToString() != "Maker")
                {
                    ((LinkButton)e.Item.Cells[4].FindControl("LinkButton1")).Enabled = true;
                    ((LinkButton)e.Item.Cells[4].FindControl("LinkButton1")).ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    ((LinkButton)e.Item.Cells[4].FindControl("LinkButton1")).Enabled = false;
                    ((LinkButton)e.Item.Cells[4].FindControl("LinkButton1")).ForeColor = System.Drawing.Color.Blue;
                }
            }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            int id = int.Parse(Session["PgId1"].ToString());
            con.Open();
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 50));

            cmd.Parameters.AddWithValue("@strPageId", id);
            cmd.Parameters["@Mode"].Value = "deletemeta";
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 50));
            // cmd.Parameters.AddWithValue("@strid", id);
            cmd.Parameters.AddWithValue("@strPageId", id);
            cmd.Parameters.AddWithValue("@strkeycont", txtkeycont.Text);
            cmd.Parameters.AddWithValue("@strdesccont", txtdesccont.Text);
            cmd.Parameters.AddWithValue("@strAction", rdbMainAct.SelectedValue);
            cmd.Parameters["@Mode"].Value = "addmetacheck";
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 50));
            cmd.Parameters.AddWithValue("@strPageId", id);
            cmd.Parameters["@Mode"].Value = "updatechk";
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strPageId", id);
            cmd.Parameters["@Mode"].Value = "chkval";
            string val = cmd.ExecuteScalar().ToString();

            if (Session["usr_privilege"].ToString() != "Maker")
            {
                if (val == "Y")
                {
                    Button3.Visible = false;
                }
                else
                {
                    Button3.Visible = true;
                }
            }
        }
        catch
        {
        }
        finally
        {
            con.Close();
        }
        bind_grid();

    }
}