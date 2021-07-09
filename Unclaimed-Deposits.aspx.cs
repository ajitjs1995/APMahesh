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

public partial class Unclaimed_Deposits : System.Web.UI.Page
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
            FillState();
            // cleardata();
        }
    }

    public void FillGrid()
    {
        try
        {
            con.Close();

            int cnt1 = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand("USP_UnclaimedProcedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@Name", txtname.Text.Trim());
            if (ddlstate.SelectedIndex != 0)
            {
                cmd.Parameters.AddWithValue("@State", Convert.ToInt32(ddlstate.SelectedValue.ToString()));
            }
            cmd.Parameters["@mode"].Value = "CntDetails";
            cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();


            if (cnt1 > 0)
            {
                con.Close();
                con.Open();
                cmd = new SqlCommand("USP_UnclaimedProcedure", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@Name", txtname.Text.Trim());
                if (ddlstate.SelectedIndex != 0)
                {
                    cmd.Parameters.AddWithValue("@State", Convert.ToInt32(ddlstate.SelectedValue.ToString()));
                }
                cmd.Parameters["@Mode"].Value = "GetDetails";

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds, "UnlaimDeposit");
                con.Close();

                if (ds.Tables["UnlaimDeposit"].Rows.Count != 0)
                {
                    
                    divForm.Visible = false;
                    tr_details.Visible = true;
                    dg_Applications.Visible = true;
                    try
                    {
                        lblmssg.Visible = true;
                        lblmssg.Text = ds.Tables["UnlaimDeposit"].Rows.Count + " Records ";
                        dg_Applications.DataSource = ds.Tables["UnlaimDeposit"].DefaultView;
                        dg_Applications.DataBind();

                        LblError.Text = "";

                        LblError.Visible = false;


                    }
                    catch
                    {
                        try
                        {
                            this.dg_Applications.CurrentPageIndex = 0;
                            this.dg_Applications.DataBind();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open)
                            con.Close();
                    }
                }
                else
                {

                    dg_Applications.DataSource = null;
                    dg_Applications.DataBind();
                    dg_Applications.Visible = false;
                    LblError.Visible = true;
                    LblError.Text = "No Record Found";
                    tr_details.Visible = false;
                    divForm.Visible = true;


                }
            }
            else
            {

                lblmssg.Visible = true;
                lblmssg.Text = "No Record Found";
                tr_details.Visible = false;
                divForm.Visible = true;
            }
        }

        catch(Exception ex)
        {
            Response.Write(ex);
        }
        finally
        {
            con.Close();
        }
    }
    protected void dg_Applications_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {

        dg_Applications.CurrentPageIndex = e.NewPageIndex;
        FillGrid();
        string x1 = dg_Applications.CurrentPageIndex.ToString();
        int currPage = Convert.ToInt32(x1) + 1;
        string x2 = dg_Applications.PageCount.ToString();

    }
    protected void BtnSerch_Click(object sender, EventArgs e)
    {
        if (checkdata() == true)
        {
            string capcha = txtCaptcha.Text;
            ccJoin.ValidateCaptcha(capcha);

            if (ccJoin.UserValidated == false)
            {
                LblError.Text = "The text you typed as shown in image is incorrect !!";
            }
            else
            {
                FillGrid();
            }
        }
    }

    public bool checkdata()
    {
        if (string.IsNullOrEmpty(txtname.Text.Trim()) )
        {
            LblError.Text = "Please enter account name !!";
            txtname.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtname.Text.Trim()) && !Regex.IsMatch(txtname.Text.Trim(), "^[a-zA-Z ]+$"))
        {
            LblError.Text = "Name should contain only aplhabates !!";
            txtname.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtname.Text.Trim()) && txtname.Text.Trim().Length < 2)
        {
            LblError.Text = "account Name should be greater then 2 character !!";
            txtname.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtname.Text.Trim()) && txtname.Text.Trim().Length > 100)
        {
            LblError.Text = "account Name should be less than 100 character !!";
            txtname.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtadd.Text.Trim()) && !Regex.IsMatch(txtadd.Text.Trim(), "^[a-zA-Z0-9.\n-/,()#@ ]+$"))
        {
            LblError.Text = "Invalid Address, Should contain alpha numeric and ( ) # @ - , / Character !!";
            txtadd.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtadd.Text.Trim()) && txtadd.Text.Length < 8)
        {
            LblError.Text = "Address , should be geater than 8 characters !!";
            txtadd.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtadd.Text.Trim()) && txtadd.Text.Trim().Length > 350)
        {
            LblError.Text = "Address, should be  lesser than 350 characters !!";
            txtadd.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtcity.Text.Trim()) && !Regex.IsMatch(txtcity.Text.Trim(), "^[a-zA-Z() ]+$"))
        {
            LblError.Text = "Invalid city, should contains the alphabets and space !!";
            txtcity.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtadd.Text.Trim()) && txtadd.Text.Trim().Length < 2)
        {
            LblError.Text = "City , should be geater than 2 characters !!";
            txtcity.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtadd.Text.Trim()) && txtadd.Text.Trim().Length > 100)
        {
            LblError.Text = "City, should be  lesser than 100 characters !!";
            txtcity.Focus();
            return false;
        }
        else if (ddlstate.SelectedIndex == 0)
        {
            LblError.Text = "Please select state !!";
            ddlstate.Focus();
            return false;
        }
        else if (String.IsNullOrEmpty(txtCaptcha.Text.Trim()))
        {
            LblError.Text = "Verification Code , should not be blank !!";
            txtCaptcha.Focus();
            return false;
        }
        else if (String.IsNullOrEmpty(txtCaptcha.Text.Trim()) && !Regex.IsMatch(txtCaptcha.Text, "@^[0-9]+$"))
        {
            LblError.Text = "Verification Code , should not be blank !!";
            txtCaptcha.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtCaptcha.Text.Trim()) && txtCaptcha.Text.Length != 6)
        {
            LblError.Text = "The text you typed as shown in image is incorrect !!";
            txtCaptcha.Focus();
            return false;
        }
        else
        {
            LblError.Text = "";
            return true;
        }
    }
    protected void Btnreset_Click(object sender, EventArgs e)
    {
        cleardata();
    }
    public void FillState()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand("USP_StateMaster", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@QueryType", "S");
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds, "tblState");
            con.Close();
            if (!(ds.Tables["tblState"].Rows.Count == 0))
            {
                ddlstate.Items.Clear();
                ddlstate.DataSource = ds.Tables["tblState"];
                ddlstate.DataTextField = ds.Tables[0].Columns["Name"].ToString();
                ddlstate.DataValueField = ds.Tables[0].Columns["ID"].ToString();
                ddlstate.DataBind();
                ddlstate.Items.Insert(0, "Select State");
                ddlstate.SelectedIndex = 0;
            }
            else
            {
                ddlstate.Items.Clear();
                ddlstate.Items.Insert(0, "Select State");
                ddlstate.SelectedIndex = 0;

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
    public void cleardata()
    {
        txtname.Text = "";
        txtadd.Text = "";
        txtcity.Text = "";
        txtCaptcha.Text = "";
        ddlstate.SelectedIndex = 0;
        tr_details.Visible = false;
        lblmssg.Text = "";
        LblError.Text = "";
    }
}