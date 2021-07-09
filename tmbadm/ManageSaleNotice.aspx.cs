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
public partial class tmbadm_ManageSaleNotice : System.Web.UI.Page
{
    SqlDataReader dr;
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["TMBCON"].ToString());
    SqlCommand cmd = new SqlCommand();
    string pid = "";
    string pidlbl = "";
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
                        cmd.Parameters.AddWithValue("@strStaffNum", Session["usr_id"].ToString());
                        cmd.Parameters.AddWithValue("@strAuthName", "CMS");
                        cmd.Parameters["@Mode"].Value = "countmoduleusr";
                        cnt = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                        if (cnt == 0)
                        {
                            Response.Redirect("TMBAdmin.aspx");
                        }
                    }
                    catch
                    { }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            TblAddNew.Visible = false;
            TblSearch.Visible = true;
            FillBranch();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string FullTitle = string.Empty;
        string extension = string.Empty;
        try
        {
            lblMainMsg.Text = "";
            string getFileName = "";
            string uploadFolder = Request.PhysicalApplicationPath + "press\\";
            if (FileDoc.HasFile)
            {
                extension = System.IO.Path.GetExtension(FileDoc.FileName);

                if (extension != ".pdf")
                {
                    lblmsg.Text = "Only .pdf are allowed to upload in Sale notice !!";
                    FileDoc.Focus();
                }
            }
            if (chk_data() == true)
            {
                DateTime AuctionDateTime = new DateTime();
                string AuctionTime = string.Empty;
                if (txtAuctionDate.Text.Trim() != "" && txtAuctionTime.Text.Trim() != "")
                {
                    DateTime d = DateTime.Parse(txtAuctionTime.Text.Trim());
                    AuctionTime = d.ToString("HH:mm:ss");
                    AuctionDateTime = Convert.ToDateTime(txtAuctionDate.Text.Trim() + " " + AuctionTime);
                }
                if (btnAdd.Text.ToLower() == "add sale notice")
                {
                    con.Open();
                    cmd = new SqlCommand("Proc_SalesNotice", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                    cmd.Parameters.AddWithValue("@NoticeDate", NoticeDate.Text.Trim());
                    cmd.Parameters["@Mode"].Value = "GetFilenewName";
                    getFileName = Convert.ToString(cmd.ExecuteScalar());
                    con.Close();

                    lblmsg.Text = "";
                    int cnt1 = 0;
                    if (FileDoc.HasFile)
                    {
                        extension = Path.GetExtension(FileDoc.PostedFile.FileName);
                        //FileDoc.SaveAs(uploadFolder + getFileName + extension);
                        FileDoc.SaveAs(uploadFolder + getFileName + ".pdf");

                    }
                    con.Open();
                    cmd = new SqlCommand("Proc_SalesNotice", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                    cmd.Parameters.AddWithValue("@NoticeDate", NoticeDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@Title", lblShowTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@PropertyName", txtTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@AuctionOn", ddlBranch.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@AuctionDateTime", AuctionDateTime);
                    cmd.Parameters.AddWithValue("@AuctionDate", txtAuctionDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@AuctionTime", txtAuctionTime.Text.Trim());
                    cmd.Parameters.AddWithValue("@AssetLocation", txtAssetLocation.Text.Trim());
                    cmd.Parameters.AddWithValue("@AssetType", txtAssetType.Text.Trim());
                    if (RblLanguage.SelectedIndex == 0 || RblLanguage.SelectedIndex == 1)
                    {
                        cmd.Parameters.AddWithValue("@NoticeLanguage", RblLanguage.SelectedItem.Text.Trim());
                    }
                    //cmd.Parameters.AddWithValue("@FileName", getFileName + extension);
                    cmd.Parameters.AddWithValue("@FileName", getFileName + ".pdf");
                    cmd.Parameters.AddWithValue("@AddedBy", Session["log_name"].ToString());
                    cmd.Parameters["@Mode"].Value = "AddNewSalesNoticeMaker";
                    cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    if (cnt1 > 0)
                    {
                        lblmsg.Text = "Sale notice successfully added !!!";
                        resetall();
                    }
                }
                else if (btnAdd.Text.ToLower() == "update sale notice")
                {
                    con.Open();
                    cmd = new SqlCommand("Proc_SalesNotice", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd.Parameters.AddWithValue("@NoticeDate", NoticeDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@Title", lblShowTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@PropertyName", txtTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@AuctionOn", ddlBranch.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@AuctionDateTime", AuctionDateTime);
                    cmd.Parameters.AddWithValue("@AuctionDate", txtAuctionDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@AuctionTime", txtAuctionTime.Text.Trim());
                    cmd.Parameters.AddWithValue("@AssetLocation", txtAssetLocation.Text.Trim());
                    cmd.Parameters.AddWithValue("@AssetType", txtAssetType.Text.Trim());
                    if (RblLanguage.SelectedIndex == 0 || RblLanguage.SelectedIndex == 1)
                    {
                        cmd.Parameters.AddWithValue("@NoticeLanguage", RblLanguage.SelectedItem.Text.Trim());
                    }
                    if (RblActive.SelectedIndex == 0 || RblActive.SelectedIndex == 1)
                    {
                        cmd.Parameters.AddWithValue("@IsActive", RblActive.SelectedValue.Trim());
                    }
                    if (FileDoc.PostedFile.FileName != "")
                    {
                        cmd.Parameters.AddWithValue("@FileName", Session["FileName"].ToString());
                        if (FileDoc.HasFile)
                        {
                            FileDoc.SaveAs(uploadFolder + Session["FileName"].ToString());
                        }
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@FileName", Session["FileName"].ToString());
                    }
                    cmd.Parameters.AddWithValue("@AddedBy", Session["log_name"].ToString());
                    cmd.Parameters.AddWithValue("@ID", Session["NoticeID"].ToString());

                    cmd.Parameters["@Mode"].Value = "UpdateSalesNotice";

                    cmd.ExecuteNonQuery();
                    con.Close();

                    lblmsg.Text = "Sale notice updated successfully !!";
                    resetall();

                }
            }
        }
        catch (Exception ext)
        { }
        finally
        {
            con.Close();
        }
    }

    private bool chk_data()
    {

        if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
        {
            lblMainMsg.Text = "Please enter Property name !!!";
            txtTitle.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtTitle.Text.Trim()) && txtTitle.Text.Trim().Length < 5)
        {
            lblMainMsg.Text = "Property name contains minimum 5 characters !!";
            txtTitle.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtTitle.Text.Trim()) && chkSaleDesc(txtTitle.Text.Trim()) == false)
        {
            lblMainMsg.Text = "Please enter the valid property name !!";
            txtTitle.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtTitle.Text.Trim()) && txtTitle.Text.Trim().Length > 500)
        {
            lblMainMsg.Text = "Property name contains maximum 500 characters !!";
            txtTitle.Focus();
            return false;
        }
        else if (ddlBranch.SelectedIndex == 0)
        {
            lblMainMsg.Text = "Please Select auction on branch !!";
            ddlBranch.Focus();
            return false;
        }
        //else if (ddlBranch.SelectedIndex != 0 && !Regex.IsMatch(ddlBranch.SelectedItem.Text.Trim(), "^[a-z.A-Z0-9-/_()[] ]+$"))
        else if (ddlBranch.SelectedIndex != 0 && chkSaleBranch(ddlBranch.SelectedValue) == false)
        {
            lblMainMsg.Text = "Please Select Valid auction on branch !!";
            ddlBranch.Focus();
            return false;
        }
        else if (RblLanguage.SelectedIndex != -1 && RblLanguage.SelectedIndex != 0 && RblLanguage.SelectedIndex != 1)
        {
            lblMainMsg.Text = "Please Select either English or Tamil !!";
            RblLanguage.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(NoticeDate.Text))
        {
            lblMainMsg.Text = "Please Select Notice Date !!";
            NoticeDate.Focus();
            return false;
        }

        else if (!(RblActive.SelectedValue == "Y") & !(RblActive.SelectedValue == "N"))
        {
            lblMainMsg.Text = "Select whether sale notice is active !!";
            RblActive.Focus();
            return false;
        }


        else
        {
            lblMainMsg.Text = "";
            return true;
        }
    }
    public bool chkSaleDesc(string data1)
    {

        string allowed1 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-/.(),|[]& ";
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
    public bool chkSaleBranch(string data1)
    {

        string allowed1 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-_/.()[] ";
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
    private bool checkRealFile(FileUpload Document)
    {
        if (Document.HasFile)
        {
            Document.PostedFile.SaveAs(Server.MapPath("..\\press") + "\\" + Document.FileName);
            if (HasMzSignature(Server.MapPath("..\\press") + "\\" + Document.FileName))
            {
                FileInfo fd = new FileInfo(Server.MapPath("..\\press") + "\\" + Document.FileName);
                fd.Delete();
                return false;
            }
            else
            {
                FileInfo fd = new FileInfo(Server.MapPath("..\\press") + "\\" + Document.FileName);
                fd.Delete();
                return true;
            }
        }
        else
        {
            return false;
        }
        System.GC.Collect();
    }

    private bool HasMzSignature(string p)
    {
        try
        {
            using (FileStream fs = new FileStream(p, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    double mzSignature = reader.ReadInt16();
                    if (mzSignature == 0x5a4d)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        catch
        {
        }
        return false;
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        resetall();
        lblmsg.Text = "";
    }
    public void resetall()
    {
        ddlBranch.SelectedIndex = 0;
        txtTitle.Text = "";
        NoticeDate.Text = "";
        lblShowTitle.Text = "";
        RblLanguage.SelectedIndex = -1;
        lnkFile.Text = "";
        lnkFile.Visible = false;
        lnkRemove.Visible = false;
        btnAdd.Text = "Add Sale notice";
        RblActive.SelectedIndex = 0;
        Session["FileName"] = "";
        Session["NoticeID"] = "";
        lblMainMsg.Text = "";
        txtAuctionDate.Text = "";
        txtAuctionTime.Text = "";
        txtAssetType.Text = "";
        txtAssetLocation.Text = "";

    }

    public void FillBranch()
    {
        try
        {
            int cnt1 = 0;
            con.Open();
            cmd = new SqlCommand("Proc_SalesNotice", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));

            cmd.Parameters["@Mode"].Value = "CountBranches";
            cnt1 = (int)cmd.ExecuteScalar();
            con.Close();

            if (cnt1 > 0)
            {
                con.Open();
                cmd = new SqlCommand("Proc_SalesNotice", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                cmd.Parameters["@Mode"].Value = "GetBranches";

            }
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "tbl_Main2");
            con.Close();
            if (!(ds.Tables["tbl_Main2"].Rows.Count == 0))
            {
                ddlBranch.Items.Clear();
                ddlBranch.DataSource = ds.Tables["tbl_Main2"];
                ddlBranch.DataTextField = "Branch";
                ddlBranch.DataValueField = "Branch";
                ddlBranch.DataBind();
                ddlBranch.Items.Insert(0, "Select Branch");
                ddlBranch.SelectedIndex = 0;

                ddlSearchBranch.Items.Clear();
                ddlSearchBranch.DataSource = ds.Tables["tbl_Main2"];
                ddlSearchBranch.DataTextField = "Branch";
                ddlSearchBranch.DataValueField = "Branch";
                ddlSearchBranch.DataBind();
                ddlSearchBranch.Items.Insert(0, "Select Branch");
                ddlSearchBranch.SelectedIndex = 0;
            }
            else
            {
                ddlBranch.Items.Clear();
                ddlBranch.Items.Insert(0, "Select Branch");
                ddlBranch.SelectedIndex = 0;

                ddlSearchBranch.Items.Clear();
                ddlSearchBranch.Items.Insert(0, "Select Branch");
                ddlSearchBranch.SelectedIndex = 0;
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
    }
    protected void txtTitle_TextChanged(object sender, EventArgs e)
    {
        lblShowTitle.Text = (!string.IsNullOrEmpty(txtTitle.Text.Trim()) ? "Sale of Property for Loan Recovery from " + txtTitle.Text.Trim() + ((ddlBranch.SelectedIndex != 0) ? ", " + ddlBranch.SelectedItem.Text.Trim() : "") + " " + (RblLanguage.SelectedIndex != -1 ? "[" + RblLanguage.SelectedItem.Text.Trim() + "]" : "") : "");
        ddlBranch.Focus();
    }
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtTitle.Text.Trim()))
        {
            lblShowTitle.Text = (!string.IsNullOrEmpty(txtTitle.Text.Trim()) ? "Sale of Property for Loan Recovery from " + txtTitle.Text.Trim() + ((ddlBranch.SelectedIndex != 0) ? ", " + ddlBranch.SelectedItem.Text.Trim() : "") + " " + (RblLanguage.SelectedIndex != -1 ? "[" + RblLanguage.SelectedItem.Text.Trim() + "]" : "") : "");
            RblLanguage.Focus();
        }
        if (string.IsNullOrEmpty(txtTitle.Text.Trim()) && ddlBranch.SelectedIndex > 0)
        {
            lblMainMsg.Text = "Please enter the property name !!";
            ddlBranch.SelectedIndex = 0;
            txtTitle.Focus();
        }
    }
    protected void RblLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtTitle.Text.Trim()))
        {
            if (ddlBranch.SelectedIndex != 0)
            {
                lblShowTitle.Text = (!string.IsNullOrEmpty(txtTitle.Text.Trim()) ? "Sale of Property for Loan Recovery from " + txtTitle.Text.Trim() + ((ddlBranch.SelectedIndex != 0) ? ", " + ddlBranch.SelectedItem.Text.Trim() : "") + " " + (RblLanguage.SelectedIndex != -1 ? "[" + RblLanguage.SelectedItem.Text.Trim() + "]" : "") : "");
                NoticeDate.Focus();
            }
            else
            {
                lblMainMsg.Text = "Please select Branch,In which property has sale !!";
                ddlBranch.Focus();
                RblLanguage.SelectedIndex = -1;
            }
        }
        else
        {
            lblMainMsg.Text = "Please enter the property name !!";
            txtTitle.Focus();
            ddlBranch.SelectedIndex = 0;
        }
    }
    private void BindGrid()
    {
        try
        {
            string Usrtype = "";
            if (Session["usr_type"] != null)
            {
                Usrtype = Session["usr_type"].ToString();
            }
            else
            {
                Response.Redirect("TMBAdmin.aspx");
            }
            int cnt1 = 0;

            con.Close();

            cmd = new SqlCommand("Proc_SalesNotice", con);
            con.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
            if (!string.IsNullOrEmpty(txtSearchNoticeDate.Text.Trim()))
            {
                cmd.Parameters.AddWithValue("@NoticeDate", txtSearchNoticeDate.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtSearchProperty.Text.Trim()))
            {
                cmd.Parameters.AddWithValue("@Title", txtSearchProperty.Text.Trim());
            }
            if (ddlSearchBranch.SelectedIndex != 0)
            {
                cmd.Parameters.AddWithValue("@AuctionOn", ddlSearchBranch.SelectedValue.ToString());
            }
            cmd.Parameters["@Mode"].Value = "CountSalesNoticeMaker";

            cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();


            if (cnt1 != 0)
            {

                cmd = new SqlCommand("Proc_SalesNotice", con);
                con.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                if (!string.IsNullOrEmpty(txtSearchNoticeDate.Text.Trim()))
                {
                    cmd.Parameters.AddWithValue("@NoticeDate", txtSearchNoticeDate.Text.Trim());
                }
                if (!string.IsNullOrEmpty(txtSearchProperty.Text.Trim()))
                {
                    cmd.Parameters.AddWithValue("@Title", txtSearchProperty.Text.Trim());
                }
                if (ddlSearchBranch.SelectedIndex != 0)
                {
                    cmd.Parameters.AddWithValue("@AuctionOn", ddlSearchBranch.SelectedValue.ToString());
                }
                cmd.Parameters["@Mode"].Value = "GetSalesNoticeMaker";

                ds = new DataSet();
                da = new SqlDataAdapter(cmd);

                da.Fill(ds);

                dg_salenotice.DataSource = ds.Tables[0];
                dg_salenotice.DataBind();
                dg_salenotice.Visible = true;

                lblmsg.Text = Convert.ToString(ds.Tables[0].Rows.Count) + " " + "Record's Found";

            }
            else
            {
                lblmsg.Text = "No Record Found !!";
                dg_salenotice.Visible = false;

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
    protected void dg_salenotice_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.SelectedItem | e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.EditItem)
        {
            string FileName = "";
            LinkButton lnkFile = (LinkButton)e.Item.Cells[4].FindControl("lnkFile");
            LinkButton lnkEdit = (LinkButton)e.Item.Cells[5].FindControl("lnkEdit");
            LinkButton lnkDelete = (LinkButton)e.Item.Cells[5].FindControl("lnkDelete");
            LinkButton lnkChecked = (LinkButton)e.Item.Cells[5].FindControl("lnkCheck");
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "FileName")) == false)
            {
                lnkFile.Text = DataBinder.Eval(e.Item.DataItem, "FileName").ToString();
            }
            else
            {
                lnkFile.Text = "";
            }
            string checkeddata = "";

            string lnkAct = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "IsActive")) == false)
            {
                lnkAct = DataBinder.Eval(e.Item.DataItem, "IsActive").ToString();
            }
            else
            {
                lnkAct = "";
            }

            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Checked")) == false)
            {
                checkeddata = DataBinder.Eval(e.Item.DataItem, "Checked").ToString();

            }


            string userPriv = Session["usr_privilege"].ToString();

            if (userPriv == "Maker")
            {
                lnkChecked.Enabled = false;
                lnkChecked.ForeColor = System.Drawing.Color.Gray;
            }
            else
            {
                lnkChecked.Enabled = true;
            }

            if (userPriv == "Checker" || userPriv == "admin" && checkeddata == "N")
            {
                lnkChecked.ForeColor = System.Drawing.Color.Red;
            }

            if (checkeddata == "Y")
            {
                lnkChecked.Enabled = false;
                lnkChecked.ForeColor = System.Drawing.Color.Green;
                lnkChecked.Text = "Checked";

            }

            if (lnkAct == "Y")
            {
                lnkDelete.Enabled = true;
            }
            else if (lnkAct == "N")
            {

                lnkDelete.Enabled = false;

                lnkDelete.ForeColor = System.Drawing.Color.Gray;

                e.Item.Cells[2].ForeColor = System.Drawing.Color.Gray;
                e.Item.Cells[3].ForeColor = System.Drawing.Color.Gray;
                e.Item.Cells[4].ForeColor = System.Drawing.Color.Gray;
                e.Item.Cells[5].ForeColor = System.Drawing.Color.Gray;

            }


            if (userPriv == "Checker")
            {
                lnkEdit.Enabled = false;
                lnkEdit.ForeColor = System.Drawing.Color.Gray;
                lnkDelete.Enabled = false;
                lnkDelete.ForeColor = System.Drawing.Color.Gray;

            }

            if (lnkAct == "Y")
            {
                ///''''''''''''confirmation before deletion
                lnkDelete.Attributes.Add("onclick", "javascript: return confirm('Are you sure you want to delete this sale notice?')");
            }
        }
    }
    protected void dg_salenotice_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        LinkButton lnkFileName = (LinkButton)e.Item.Cells[4].FindControl("lnkFile");
        string ID = e.Item.Cells[0].Text;
        string SalesNoticeDate = e.Item.Cells[6].Text;
        string Title = e.Item.Cells[3].Text;
        string PropertyName = e.Item.Cells[7].Text;
        string AuctionOn = e.Item.Cells[8].Text;
        string NoticeLanguage = e.Item.Cells[9].Text;
        string FileName = lnkFileName.Text;
        string IsActive = e.Item.Cells[10].Text;
        string Checked = e.Item.Cells[11].Text;
        string AuctionDate = e.Item.Cells[12].Text;
        string AuctionTime = e.Item.Cells[13].Text;
        string AssetLocation = e.Item.Cells[14].Text;
        string AssetType = e.Item.Cells[15].Text;

        if (e.CommandName == "PgFile")
        {

            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            if (FileName.Contains(".pdf"))
            {
                Response.AddHeader("Content-Type", "application/pdf");
            }
            else if (FileName.Contains(".doc"))
            {
                Response.AddHeader("Content-Type", "application/doc");
            }
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            Response.WriteFile("../press/" + FileName);
            Response.End();
        }
        else if (e.CommandName == "PgEdit")
        {
            if (!string.IsNullOrEmpty(PropertyName) && PropertyName != "&nbsp;")
            {
                txtTitle.Text = PropertyName;
            }
            if (!string.IsNullOrEmpty(AuctionOn) && AuctionOn != "&nbsp;")
            {
                ddlBranch.SelectedValue = AuctionOn;
            }
            if (!string.IsNullOrEmpty(NoticeLanguage) && NoticeLanguage != "&nbsp;")
            {
                RblLanguage.SelectedValue = NoticeLanguage;
            }
            if (!string.IsNullOrEmpty(SalesNoticeDate) && SalesNoticeDate != "&nbsp;")
            {
                NoticeDate.Text = SalesNoticeDate;
            }
            if (!string.IsNullOrEmpty(Title) && Title != "&nbsp;")
            {
                lblShowTitle.Text = Title;
            }
            if (!string.IsNullOrEmpty(IsActive) && IsActive != "&nbsp;")
            {
                RblActive.SelectedValue = IsActive;
            }
            if (!string.IsNullOrEmpty(AuctionDate) && AuctionDate != "&nbsp;")
            {
                txtAuctionDate.Text = AuctionDate;
            }
            if (!string.IsNullOrEmpty(AuctionTime) && AuctionTime != "&nbsp;")
            {
                txtAuctionTime.Text = AuctionTime;
            }
            if (!string.IsNullOrEmpty(AssetLocation) && AssetLocation != "&nbsp;")
            {
                txtAssetLocation.Text = AssetLocation;
            }
            if (!string.IsNullOrEmpty(AssetType) && AssetType != "&nbsp;")
            {
                txtAssetType.Text = AssetType;
            }

            if (string.IsNullOrEmpty(FileName))
            {
                lnkFile.Visible = false;
                lnkFile.Text = "";
                lnkRemove.Visible = false;
            }
            else
            {
                lnkFile.Text = FileName;
                lnkFile.Visible = true;
                lnkFile.Text = FileName;
                lnkRemove.Enabled = true;
                lnkRemove.Visible = true;
            }
            Session["FileName"] = FileName;
            TblAddNew.Visible = true;
            TblSearch.Visible = false;
            btnAddnewSaleNotice.Visible = false;
            dg_salenotice.Visible = false;
            lblmsg.Text = "";
            lblMainMsg.Text = "";
            btnAdd.Text = "Update Sale Notice";
            lnkFile.Visible = true;
            Session["NoticeID"] = ID;
        }
        else if (e.CommandName == "PgDelete")
        {
            con.Open();
            cmd = new SqlCommand("Proc_SalesNotice", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters["@Mode"].Value = "InActiveNotice";
            cmd.ExecuteNonQuery();
            con.Close();

            lblmsg.Text = "Sale notice is deleted successfully";
            BindGrid();

        }
        else if (e.CommandName == "PgCheck")
        {
            con.Open();
            cmd = new SqlCommand("Proc_SalesNotice", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters["@Mode"].Value = "CheckPreviousNotice";
            int cntdup = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            if (cntdup > 0)
            {
                con.Open();
                cmd = new SqlCommand("Proc_SalesNotice", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters["@Mode"].Value = "DeletePreviousNotice";
                cmd.ExecuteNonQuery();
                con.Close();
            }

            con.Open();
            cmd = new SqlCommand("Proc_SalesNotice", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters["@Mode"].Value = "InsertCheckedNotice";
            cmd.ExecuteNonQuery();
            con.Close();
            BindGrid();
        }
    }
    protected void dg_salenotice_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        dg_salenotice.CurrentPageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void icodel1_Click(object sender, ImageClickEventArgs e)
    {
        string filename = lnkFile.Text;
        string path = Server.MapPath("../press/" + filename);
        lnkFile.Text = "";
        lnkRemove.Visible = false;
        FileDoc.Focus();
    }
    protected void lnkFile_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ClearContent();
        Response.ClearHeaders();
        if (lnkFile.Text.Contains(".pdf"))
        {
            Response.AddHeader("Content-Type", "application/pdf");
        }
        else if (lnkFile.Text.Contains(".doc"))
        {
            Response.AddHeader("Content-Type", "application/doc");
        }
        Response.AddHeader("Content-Disposition", "attachment;filename=" + lnkFile.Text);
        Response.WriteFile("../press/" + lnkFile.Text);
        Response.End();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        resetall();
        lblmsg.Text = "";
        TblAddNew.Visible = false;
        TblSearch.Visible = true;
        btnAddnewSaleNotice.Visible = true;
        dg_salenotice.Visible = false;
    }
    public void ResetSearch()
    {
        txtSearchProperty.Text = "";
        ddlSearchBranch.SelectedIndex = 0;
        txtSearchNoticeDate.Text = "";
        TblSearch.Visible = true;
        TblAddNew.Visible = false;
        lblsearcherr.Text = "";
        lblMainMsg.Text = "";
        dg_salenotice.Visible = false;
    }
    protected void btnSeach_Click(object sender, EventArgs e)
    {
        if (ChkSrch_Data() == true)
        {
            BindGrid();
        }
        else
        {
            lblsearcherr.Text = lblsearcherr.Text;
        }
    }
    protected void btnSearchReset_Click(object sender, EventArgs e)
    {
        ResetSearch();
        lblmsg.Text = "";
    }
    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void btnAddnewSaleNotice_Click(object sender, EventArgs e)
    {
        TblAddNew.Visible = true;
        TblSearch.Visible = false;
        btnAddnewSaleNotice.Visible = false;
        dg_salenotice.Visible = false;
        lblmsg.Text = "";
    }

    public bool ChkSrch_Data()
    {
        if (string.IsNullOrEmpty(txtSearchProperty.Text.Trim()) && string.IsNullOrEmpty(txtSearchNoticeDate.Text.Trim()) && ddlSearchBranch.SelectedIndex == 0)
        {
            lblsearcherr.Text = "Please select atleast one field !!";
            txtSearchProperty.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtSearchProperty.Text.Trim()) && chkSaleDesc(txtTitle.Text.Trim()) == false)
        {
            lblsearcherr.Text = "Please enter the valid property name !!";
            txtSearchProperty.Focus();
            return false;
        }
        else if (ddlSearchBranch.SelectedIndex != 0 && !Regex.IsMatch(ddlSearchBranch.SelectedItem.Text.Trim(), "^[a-zA-Z0-9 ]+$"))
        {
            lblsearcherr.Text = "Please Select Valid auction on branch !!";
            ddlSearchBranch.Focus();
            return false;
        }
        else
        {
            lblsearcherr.Text = "";
            return true;
        }
    }
}