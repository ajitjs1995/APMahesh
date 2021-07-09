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

public partial class Admin_ManageTrendIndicatorsINR : System.Web.UI.Page
{
    SqlDataReader dr;
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["TMBCON"].ToString());
    SqlCommand cmd = new SqlCommand();
    string pid = "";
    string pidlbl = "";
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    string strMessage = "";
    int cnt = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtPreUS.Attributes.Add("autocomplete", "off");
            txtPreEURO.Attributes.Add("autocomplete", "off");
            txtPreGB.Attributes.Add("autocomplete", "off");

            txtTodUs.Attributes.Add("autocomplete", "off");
            txtTodEuro.Attributes.Add("autocomplete", "off");
            txtTodGB.Attributes.Add("autocomplete", "off");

            txtRanUS.Attributes.Add("autocomplete", "off");
            txtRanEuro.Attributes.Add("autocomplete", "off");
            txtRanGB.Attributes.Add("autocomplete", "off");

            txtCurrUS.Attributes.Add("autocomplete", "off");
            txtCurrEuro.Attributes.Add("autocomplete", "off");
            txtCurrGB.Attributes.Add("autocomplete", "off");



            BindGrid();
            fill_data();
            if (Convert.ToInt32(Session["id"]) == 0)
            {
                Btn.Text = "Add";
                lblAddMainHead.Text = "Add Content";
            }
            else
            {
                Btn.Text = "Update";
                lblAddMainHead.Text = "Update Content";
            }
            if (Session["usr_privilege"] != null)
            {
                if (Session["usr_privilege"].ToString() != "admin")
                {
                    try
                    {
                        con.Open();
                        int cnt;
                        //cmd = new SqlCommand("select count(*) from USerModAuthMaker a , tbl_AdmModules b where a .off_staff_no='" + Session["officer_staffNo"].ToString() + "' and a.mod_id=b.mod_id and b.mod_nm='CMS'", con);
                        cmd = new SqlCommand("Proc_User_Master", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 50));
                        cmd.Parameters.AddWithValue("@strStaffNum", Session["officer_staffNo"].ToString());
                        cmd.Parameters.AddWithValue("@strAuthCurrency", "CMS");
                        cmd.Parameters["@Mode"].Value = "countmoduleusr";
                        cnt = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                        if (cnt == 0)
                        {
                            Response.Redirect("TMBAdmin.aspx");
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
                else
                {
                     //this.BindGrid();
                     //BindArchieveRates();

                }
            }

            
        }

    }
    protected void Btn_Click(object sender, EventArgs e)
    {
        try
        {
            if (checkdata() == true)
            {
                SqlCommand cmd = new SqlCommand("Proc_TrendIndicator", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@Heading", txtheading.Text);
                cmd.Parameters.AddWithValue("@Spot", txtspot.Text);
                cmd.Parameters.AddWithValue("@Forword", Textforword.Text);
                cmd.Parameters.AddWithValue("@Global", Textglobal.Text);
                cmd.Parameters.AddWithValue("@Positive", Textpositive.Text);
                cmd.Parameters.AddWithValue("@Factor", Textfactor.Text);
                if (Btn.Text == "Add")
                {
                    cmd.Parameters["@mode"].Value = "InsertTrendCont";
                }
                else if (Btn.Text == "Update")
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(Session["id"])))
                    {
                        cmd.Parameters.AddWithValue("@id", Session["id"]);
                    }
                    cmd.Parameters["@Mode"].Value = "EditTrendCont";
                }
                cmd.ExecuteNonQuery();
                con.Close();
                if (Btn.Text == "Add")
                {
                    lblerror.Text = "Content added successfully !!";
                }
                else if (Btn.Text == "Update")
                {
                    
                    lblerror.Text = "Content updated successfully !!";
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
    }
    public bool checkdata()
    {
       
        if (!string.IsNullOrEmpty(txtheading.Text.Trim()) && chkrateDesc(txtheading.Text.Trim()) == false)
        {
            lblerror.Text = "Heading, should contains the alphabets and space !!";
            txtheading.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtheading.Text.Trim()) && txtheading.Text.Length < 2)
        {
            lblerror.Text = "Heading should be greater than the 2 charactors !!";
            txtheading.Focus();
            return false;
        }


        else if (!string.IsNullOrEmpty(txtspot.Text.Trim()) && chkrateDesc(txtspot.Text.Trim()) == false)
        {
            lblerror.Text = "Invalid Spot/INR, should contains the alphabets and space !!";
            txtspot.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtspot.Text.Trim()) && txtspot.Text.Length < 2)
        {
            lblerror.Text = "Spot/INR should be greater than the 2 charactors !!";
            txtspot.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(Textforword.Text.Trim()) && chkrateDesc(Textforword.Text.Trim()) == false)
        {
            lblerror.Text = "Invalid forword premium, should contains the alphabets and space !!";
            Textforword.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(Textforword.Text.Trim()) && Textforword.Text.Length < 2)
        {
            lblerror.Text = "Forword premium  should be greater than the 2 charactors !!";
            Textforword.Focus();
            return false;
        }

        //else if (!string.IsNullOrEmpty(Textglobal.Text.Trim()) && !Regex.IsMatch(Textglobal.Text, "^[A-Za-z0-9 ,.?!%&()@$-_:;\"\\]+$"))
        else if (!string.IsNullOrEmpty(Textglobal.Text.Trim()) && chkTrendDesc(Textglobal.Text.Trim()) == false)
        {
            lblerror.Text = "Invalid global development, should contains the alphabets and space !!";
            Textglobal.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(Textglobal.Text.Trim()) && Textglobal.Text.Length < 2)
        {
            lblerror.Text = "Global development should be greater than the 2 charactors !!";
            Textglobal.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(Textpositive.Text.Trim()) && chkrateDesc(Textpositive.Text.Trim()) == false)
        {
            lblerror.Text = "Invalid positive factor for rupee, should contains the alphabets and space !!";
            Textpositive.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(Textpositive.Text.Trim()) && Textpositive.Text.Length < 2)
        {
            lblerror.Text = "Positive factor for rupee should be greater than the 2 charactors !!";
            Textpositive.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(Textfactor.Text.Trim()) && chkFactDesc(Textfactor.Text.Trim()) == false)
        {
            lblerror.Text = "Invalid factors against rupee, should contains the alphabets and space !!";
            Textfactor.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(Textfactor.Text.Trim()) && Textfactor.Text.Length < 2)
        {
            lblerror.Text = "Factors against rupee should be greater than the 2 charactors !!";
            Textfactor.Focus();
            return false;
        }

        else
        {
            return true;
        }
    }
    public bool chkrateDesc(string data1)
    {

        string allowed1 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-/.(),%&!#@::$’“”' ";
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
                            //flag1 = 0
                            charfound = 0;
                        }
                    }

                    if (flag2 == allowed1.Length & charfound == 0)
                    {
                        if (txtchar.CompareTo(Environment.NewLine) == -1)
                        {
                            flag1 = flag1 + 1;
                            charfound = 1;
                        }
                        else
                        {
                            flag1 = 0;
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
    public bool chkTrendDesc(string data1)
    {

        string allowed1 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-().'&$;,%\n\r\"  ";
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
                            //flag1 = 0
                            charfound = 0;
                        }
                    }

                    if (flag2 == allowed1.Length & charfound == 0)
                    {
                        if (txtchar.CompareTo(Environment.NewLine) == -1)
                        {
                            flag1 = flag1 + 1;
                            charfound = 1;
                        }
                        else
                        {
                            flag1 = 0;
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
    public bool chkFactDesc(string data1)
    {

        string allowed1 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-_()&;,.  ";
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
                            //flag1 = 0
                            charfound = 0;
                        }
                    }

                    if (flag2 == allowed1.Length & charfound == 0)
                    {
                        if (txtchar.CompareTo(Environment.NewLine) == -1)
                        {
                            flag1 = flag1 + 1;
                            charfound = 1;
                        }
                        else
                        {
                            flag1 = 0;
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
    protected void Btn1_Click(object sender, EventArgs e)
    {
        fill_data();
        lblerror.Text = "";
    }
    public void fill_data()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand("Proc_TrendIndicator", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 50));

            cmd.Parameters["@Mode"].Value = "GetTrendCont";
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds1 = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds1, "tbl_data");
            if (ds1.Tables["tbl_data"].Rows.Count > 0)
            {

                if (Information.IsDBNull(ds1.Tables["tbl_data"].Rows[0]["id"]) == false)
                {
                    Session["id"] = Convert.ToInt32(ds1.Tables["tbl_data"].Rows[0]["id"]);
                }


                if (Information.IsDBNull(ds1.Tables["tbl_data"].Rows[0]["Heading"]) == false)
                {
                    txtheading.Text = ds1.Tables["tbl_data"].Rows[0]["Heading"].ToString();
                }
                else
                {
                    txtheading.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data"].Rows[0]["Spot"]) == false)
                {
                    txtspot.Text = ds1.Tables["tbl_data"].Rows[0]["Spot"].ToString();
                }
                else
                {
                    txtspot.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data"].Rows[0]["Forword"]) == false)
                {
                    Textforword.Text = ds1.Tables["tbl_data"].Rows[0]["Forword"].ToString();
                }
                else
                {
                    Textforword.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data"].Rows[0]["Global"]) == false)
                {
                    Textglobal.Text = ds1.Tables["tbl_data"].Rows[0]["Global"].ToString();
                }
                else
                {
                    Textglobal.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data"].Rows[0]["Positive"]) == false)
                {
                    Textpositive.Text = ds1.Tables["tbl_data"].Rows[0]["Positive"].ToString();
                }
                else
                {
                    Textpositive.Text = "";
                }
                if (Information.IsDBNull(ds1.Tables["tbl_data"].Rows[0]["Factor"]) == false)
                {
                    Textfactor.Text = ds1.Tables["tbl_data"].Rows[0]["Factor"].ToString();
                }
                else
                {
                    Textfactor.Text = "";
                }
            }
        }
        catch
        { }
        finally
        {
            con.Close();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Checkdata() == true)
        {
            Update();
            BindGrid();
           Clear();

        }
        else
        {
            lblErr.Text = strMessage;
        }
    }
    public void BindGrid()
    {
        try
        {

            con.Open();
            cmd = new SqlCommand("USP_UpdateTrendRates", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@QueryType", "Show");
            DataTable dtShow = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dtShow);
            if (dtShow.Rows.Count > 0)
            {
                tblGrid.Visible = true;
                if (Information.IsDBNull(dtShow.Rows[0]["PrevDayUS"]) == false)
                {
                    lblPreUS.Text = dtShow.Rows[0]["PrevDayUS"].ToString();
                }
                else
                {
                    lblPreUS.Text = " ---- ";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["PrevDayEuro"]) == false)
                {
                    lblPreEURO.Text = dtShow.Rows[0]["PrevDayEuro"].ToString();
                }
                else
                {
                    lblPreEURO.Text = " ---- ";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["PrevDayGB"]) == false)
                {
                    lblPreGB.Text = dtShow.Rows[0]["PrevDayGB"].ToString();
                }
                else
                {
                    lblPreGB.Text = " ---- ";
                }

                if (Information.IsDBNull(dtShow.Rows[0]["TodayUS"]) == false)
                {
                    lblTodUS.Text = dtShow.Rows[0]["TodayUS"].ToString();
                }
                else
                {
                    lblTodUS.Text = " ---- ";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["TodayEuro"]) == false)
                {
                    lblTodEURO.Text = dtShow.Rows[0]["TodayEuro"].ToString();
                }
                else
                {
                    lblTodEURO.Text = " ---- ";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["TodayGB"]) == false)
                {
                    lblTodGB.Text = dtShow.Rows[0]["TodayGB"].ToString();
                }
                else
                {
                    lblTodGB.Text = " ---- ";
                }


                if (Information.IsDBNull(dtShow.Rows[0]["TRUS"]) == false)
                {
                    lblRanUS.Text = dtShow.Rows[0]["TRUS"].ToString();
                }
                else
                {
                    lblRanUS.Text = " ---- ";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["TREuro"]) == false)
                {
                    lblRanEURO.Text = dtShow.Rows[0]["TREuro"].ToString();
                }
                else
                {
                    lblRanEURO.Text = " ---- ";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["TRGB"]) == false)
                {
                    lblRanGB.Text = dtShow.Rows[0]["TRGB"].ToString();
                }
                else
                {
                    lblRanGB.Text = " ---- ";
                }


                if (Information.IsDBNull(dtShow.Rows[0]["CMUS"]) == false)
                {
                    lblCurrUS.Text = dtShow.Rows[0]["CMUS"].ToString();
                }
                else
                {
                    lblCurrUS.Text = " ---- ";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["CMEuro"]) == false)
                {
                    lblCurrEURO.Text = dtShow.Rows[0]["CMEuro"].ToString();
                }
                else
                {
                    lblCurrEURO.Text = " ---- ";
                }
                if (Information.IsDBNull(dtShow.Rows[0]["CMGB"]) == false)
                {
                    lblCurrGB.Text = dtShow.Rows[0]["CMGB"].ToString();
                }
                else
                {
                    lblCurrGB.Text = " ---- ";
                }
            }
            else
            {
                tblGrid.Visible = false;
            }
            con.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
        finally
        {
            con.Close();
        }
    }
    public void Update()
    {
        lblErr.Text = "";
        int cntNext = 0;
        int cntPrevious = 0;

        try
        {

            try
            {
                con.Open();
                lblErr.Text = "";
                cmd = new SqlCommand("USP_UpdateTrendRates", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@QueryType", "MaxArchieveCnt");
                cntPrevious = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            finally
            {
                con.Close();
            }

            con.Open();
            lblErr.Text = "";
            SqlCommand cm = new SqlCommand();
            cm = new SqlCommand("USP_UpdateTrendRates", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@QueryType", "Update");
            if (!string.IsNullOrEmpty(txtPreUS.Text))
            {
                cm.Parameters.AddWithValue("@strPDUS",(txtPreUS.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strPDUS", " ---- ");
            }

            if (!string.IsNullOrEmpty(txtPreEURO.Text))
            {
                cm.Parameters.AddWithValue("@strPDEuro", (txtPreEURO.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strPDEuro", " ---- ");
            }

            if (!string.IsNullOrEmpty(txtPreGB.Text))
            {
                cm.Parameters.AddWithValue("@strPDGB", (txtPreGB.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strPDGB", " ---- ");
            }

            if (!string.IsNullOrEmpty(txtTodUs.Text))
            {
                cm.Parameters.AddWithValue("@strTDUS", (txtTodUs.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strTDUS", " ---- ");
            }

            if (!string.IsNullOrEmpty(txtTodEuro.Text))
            {
                cm.Parameters.AddWithValue("@strTDEuro", (txtTodEuro.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strTDEuro", " ---- ");
            }

            if (!string.IsNullOrEmpty(txtTodGB.Text))
            {
                cm.Parameters.AddWithValue("@strTDGB", (txtTodGB.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strTDGB", " ---- ");
            }

            if (!string.IsNullOrEmpty(txtRanUS.Text))
            {
                cm.Parameters.AddWithValue("@strTRUS", (txtRanUS.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strTRUS", " ---- ");
            }

            if (!string.IsNullOrEmpty(txtRanEuro.Text))
            {
                cm.Parameters.AddWithValue("@strTREuro", (txtRanEuro.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strTREuro", " ---- ");
            }
            if (!string.IsNullOrEmpty(txtRanGB.Text))
            {
                cm.Parameters.AddWithValue("@strTRGB", (txtRanGB.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strTRGB", " ---- ");
            }

            if (!string.IsNullOrEmpty(txtCurrUS.Text))
            {
                cm.Parameters.AddWithValue("@strCMUS", (txtCurrUS.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strCMUS", " ---- ");
            }

            if (!string.IsNullOrEmpty(txtCurrEuro.Text))
            {
                cm.Parameters.AddWithValue("@strCMEuro", (txtCurrEuro.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strCMEuro", " ---- ");
            }
            if (!string.IsNullOrEmpty(txtCurrGB.Text))
            {
                cm.Parameters.AddWithValue("@strCMGB", (txtCurrGB.Text));
            }
            else
            {
                cm.Parameters.AddWithValue("@strCMGB", " ---- ");
            }
            cntNext = Convert.ToInt32(cm.ExecuteScalar());
            con.Close();
            if (cntNext > cntPrevious)
            {
                lblErr.Text = "Rates Updated Successfully";
            }

        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
        finally
        {
            con.Close();
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Clear();
    }
    public void Clear()
    {
        txtPreUS.Text = "";
        txtPreEURO.Text = "";
        txtPreGB.Text = "";

        txtTodUs.Text = "";
        txtTodEuro.Text = "";
        txtTodGB.Text = "";

        txtRanUS.Text = "";
        txtRanEuro.Text = "";
        txtRanGB.Text = "";

        txtCurrUS.Text = "";
        txtCurrEuro.Text = "";
        txtCurrGB.Text = "";
        lblErr.Text = "";

    }
    public bool Checkdata()
    {

        if (string.IsNullOrEmpty(txtPreUS.Text.Trim()))
        {
            strMessage += "Please Enter Previous Day USD  Value  <br />";
            txtPreUS.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtPreUS.Text.Trim()) && !Regex.IsMatch(txtPreUS.Text.Trim(), "^(([0-9]+(\\.[0-9]{1,2}))([/]{1})([0-9]+(\\.[0-9]{1,2})))?$"))
        {
            strMessage += "Previous Day USD Value is In-Valid  <br />";
            txtPreUS.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtPreEURO.Text.Trim()))
        {
            strMessage += "Please Enter Previous Day EURO Value  <br />";
            txtPreEURO.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtPreEURO.Text.Trim()) && !Regex.IsMatch(txtPreEURO.Text.Trim(), "^(([0-9]+(\\.[0-9]{1,2}))([/]{1})([0-9]+(\\.[0-9]{1,2})))?$"))
        {
            strMessage += "Previous Day EURO Value is In-Valid <br />";
            txtPreEURO.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtPreGB.Text.Trim()))
        {
            strMessage += "Please Enter Previous Day GBP Value  <br />";
            txtPreGB.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtPreGB.Text.Trim()) && !Regex.IsMatch(txtPreGB.Text.Trim(), "^(([0-9]+(\\.[0-9]{1,2}))([/]{1})([0-9]+(\\.[0-9]{1,2})))?$"))
        {
            strMessage += "Previous Day GBP Value is In-Valid <br />";
            txtPreGB.Focus();
            return false;
        }


        if (txtTodUs.Text.Trim() == "")
        {
            strMessage += "Please Enter Today's Opening USD Value  <br />";
            txtTodUs.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtTodUs.Text.Trim()) && !Regex.IsMatch(txtTodUs.Text.Trim(), "^(([0-9]+(\\.[0-9]{1,2}))([/]{1})([0-9]+(\\.[0-9]{1,2})))?$"))
        {
            strMessage += "Today's Opening USD Value is In-Valid  <br />";
            txtTodUs.Focus();
            return false;
        }

        if (txtTodEuro.Text.Trim() == "")
        {
            strMessage += "Please Enter Today's Opening EURO Value  <br />";
            txtTodEuro.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtTodEuro.Text.Trim()) && !Regex.IsMatch(txtTodEuro.Text.Trim(), "^(([0-9]+(\\.[0-9]{1,2}))([/]{1})([0-9]+(\\.[0-9]{1,2})))?$"))
        {
            strMessage += "Today's Opening EURO Value is In-Valid  <br />";
            txtTodEuro.Focus();
            return false;
        }

        if (txtTodGB.Text.Trim() == "")
        {
            strMessage += "Please Enter Today's Opening GBP Value  <br />";
            txtTodGB.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtTodGB.Text.Trim()) && !Regex.IsMatch(txtTodGB.Text.Trim(), "^(([0-9]+(\\.[0-9]{1,2}))([/]{1})([0-9]+(\\.[0-9]{1,2})))?$"))
        {
            strMessage += "Today's Opening GBP Value is In-Valid  <br />";
            txtTodGB.Focus();
            return false;
        }
        if (txtRanUS.Text.Trim() == "")
        {
            strMessage += "Please Enter Today Range USD Value  <br />";
            txtRanUS.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtRanUS.Text.Trim()) && !Regex.IsMatch(txtRanUS.Text.Trim(), "^(([0-9]+(\\.[0-9]{1,2})) to ([0-9]+(\\.[0-9]{1,2})))?$"))
        {
            strMessage += "Today Range USD Value is In-Valid  <br />";
            txtRanUS.Focus();
            return false;
        }
        if (txtCurrUS.Text.Trim() == "")
        {
            strMessage += "Please Enter Current Month USD Value  <br />";
            txtCurrUS.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtCurrUS.Text.Trim()) && !Regex.IsMatch(txtCurrUS.Text.Trim(), "^(([0-9]+(\\.[0-9]{1,2})) to ([0-9]+(\\.[0-9]{1,2})))?$"))
        {
            strMessage += "Current Month USD Value is In-Valid  <br />";
            txtCurrUS.Focus();
            return false;
        }
        
        else
        {
            return true;
        }
    }
}
