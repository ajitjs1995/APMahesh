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

public partial class Admin_Manage_banner : System.Web.UI.Page
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
                    {

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }



            rdblanguage.SelectedValue = "English";
            rdblanguageAdd.SelectedValue = "English";
            tradd.Visible = false;
            filldropdownpages();
            filldropdownpagesSearch();
            bind_grid();
        }
    }

    private void bind_grid()
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

            con.Open();
            cmd = new SqlCommand("Proc_ManageBanner", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@Lnguage", rdblanguage.SelectedValue);
            cmd.Parameters.AddWithValue("@strLogNm", Session["log_name"].ToString());

            if (!string.IsNullOrEmpty(txtpageName.Text.Trim()))
            {
                cmd.Parameters.AddWithValue("@strPgFileNm", txtpageName.Text);
            }

            //cmd.Parameters.AddWithValue("@strPageId", Convert.ToString(Session["PgId1"]));
            if (rdblanguage.SelectedValue == "English")
            {
                if (Usrtype == "admin")
                {
                    cmd.Parameters["@Mode"].Value = "cntbn1adm";
                }
                else
                {
                    cmd.Parameters["@Mode"].Value = "cntbn1";
                }
            }
            else if (rdblanguage.SelectedValue == "Hindi")
            {
                if (Usrtype == "admin")
                {
                    cmd.Parameters["@Mode"].Value = "cntbn1Hindiadm";
                }
                else
                {
                    cmd.Parameters["@Mode"].Value = "cntbn1Hindi";
                }
            }
            else
            {
                if (Usrtype == "admin")
                {
                    cmd.Parameters["@Mode"].Value = "cntbn1MarathiAdm";
                }
                else
                {
                    cmd.Parameters["@Mode"].Value = "cntbn1Marathi";
                }
            }
            cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();


            if (cnt1 != 0)
            {
                con.Open();
                cmd = new SqlCommand("Proc_ManageBanner", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@Lnguage", rdblanguage.SelectedValue);
                cmd.Parameters.AddWithValue("@strLogNm", Session["log_name"].ToString());
                if (!string.IsNullOrEmpty(txtpageName.Text.Trim()))
                {

                    cmd.Parameters.AddWithValue("@strPgFileNm", txtpageName.Text);
                }
                //cmd.Parameters.AddWithValue("@strPageId", Convert.ToString(Session["PgId1"]));
                if (rdblanguage.SelectedValue == "English")
                {
                    if (Usrtype == "admin")
                    {
                        cmd.Parameters["@Mode"].Value = "dispbannerAdm";
                    }
                    else
                    {
                        cmd.Parameters["@Mode"].Value = "dispbanner";
                    }

                }
                else if (rdblanguage.SelectedValue == "Hindi")
                {
                    if (Usrtype == "admin")
                    {
                        cmd.Parameters["@Mode"].Value = "dispbannerHindiadm";
                    }
                    else
                    {
                        cmd.Parameters["@Mode"].Value = "dispbannerHindi";
                    }
                }
                else
                {
                    if (Usrtype == "admin")
                    {
                        cmd.Parameters["@Mode"].Value = "dispbannerMarathiAdm";
                    }
                    else
                    {
                        cmd.Parameters["@Mode"].Value = "dispbannerMarathi";
                    }
                }

                ds = new DataSet();
                da = new SqlDataAdapter(cmd);

                da.Fill(ds);

                dg_PgEng.DataSource = ds.Tables[0];
                dg_PgEng.DataBind();
                dg_PgEng.Visible = true;

                lblmsg.Text = Convert.ToString(ds.Tables[0].Rows.Count) + " " + "Record's Found";

            }
            else
            {
                //dg_PgEng.DataSource = null;
                //dg_Menu.DataBind();
                //dg_Menu.Visible = false;
                lblmsg.Text = "No Record Found !!";
                dg_PgEng.Visible = false;

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

    private void filldropdownpagesSearch()
    {
        cmd = new SqlCommand("Proc_ManageBanner", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 50);
        if (rdblanguage.SelectedValue == "English")
        {
            cmd.Parameters["@Mode"].Value = "GetDataEng";
        }
        else if (rdblanguage.SelectedValue == "Hindi")
        {
            cmd.Parameters["@Mode"].Value = "GetDataHnd";
        }
        else
        {
            cmd.Parameters["@Mode"].Value = "GetDataMar";
        }
        da = new SqlDataAdapter(cmd);
        dt = new DataTable();
        da.Fill(dt);

        //ddlsearchpage.DataSource = dt;
        //ddlsearchpage.DataValueField = "PageID";
        //ddlsearchpage.DataTextField = "PageName";
        //ddlsearchpage.DataBind();

        //ddlsearchpage.Items.Insert(0, "--Select--");
    }

    private void filldropdownpages()
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

        cmd = new SqlCommand("Proc_ManageBanner", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 50);
        cmd.Parameters.AddWithValue("@strLogNm", Session["log_name"].ToString());
        if (rdblanguageAdd.SelectedValue == "English")
        {
            if (Usrtype == "admin")
            {
                cmd.Parameters["@Mode"].Value = "GetDataEngAdm";
            }
            else
            {
                cmd.Parameters["@Mode"].Value = "GetDataEng";
            }
        }
        else if (rdblanguageAdd.SelectedValue == "Hindi")
        {
            if (Usrtype == "admin")
            {
                cmd.Parameters["@Mode"].Value = "GetDataHndAdm";
            }
            else
            {
                cmd.Parameters["@Mode"].Value = "GetDataHnd";
            }
        }
        else
        {
            if (Usrtype == "admin")
            {
                cmd.Parameters["@Mode"].Value = "GetDataMarAdm";
            }
            else
            {
                cmd.Parameters["@Mode"].Value = "GetDataMar";
            }
        }
        da = new SqlDataAdapter(cmd);
        dt = new DataTable();
        da.Fill(dt);

        ddlpage.DataSource = dt;
        ddlpage.DataValueField = "PageID";
        ddlpage.DataTextField = "PageName";
        ddlpage.DataBind();

        ddlpage.Items.Insert(0, "--Select--");
        ddlpage.SelectedIndex = 0;
    }
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        tradd.Visible = true;
        lnkAddNew.Visible = false;
        trsearch.Visible = false;
        filldropdownpages();
        bind_gridAdd();
        //if (rdblanguage.SelectedValue == "English")
        //{
        //  rdblanguageAdd.SelectedValue = "English";
        //  filldropdownpages();

        //}
        //else if (rdblanguage.SelectedValue == "Hindi")
        //{
        //  rdblanguageAdd.SelectedValue = "Hindi";
        //}
        //else 
        //{
        //  rdblanguageAdd.SelectedValue = "Marathi";
        //}
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        tradd.Visible = false;
        lnkAddNew.Visible = true;
        trsearch.Visible = true;

        cleardata();
        bind_grid();
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string bnname = "";
            byte[] bytes;
            BinaryReader br;
            br = new BinaryReader(FUBanner.PostedFile.InputStream);
            bytes = br.ReadBytes(FUBanner.PostedFile.ContentLength);
            if (chk_data() == true)
            {
                if (!string.IsNullOrEmpty(Path.GetFileName(FUBanner.PostedFile.FileName)) || lnkbanner.Text != "")
                {
                    if (FUBanner.HasFile)
                    {
                        string extension = System.IO.Path.GetExtension(FUBanner.FileName);
                        
                        if (extension == ".jpg" || extension == ".png" || extension == ".ico")
                        {
                            // FUicon.SaveAs("yourpath" + FUicon.FileName);
                           // FUBanner.PostedFile.SaveAs(Server.MapPath("..\\InnerBanner") + "\\" + FUBanner.FileName);

                            if (!string.IsNullOrEmpty(txttempiconnm.Text) || lnkbanner.Text != "" || !string.IsNullOrEmpty(FUBanner.FileName))
                            {
                                bnname = txttempiconnm.Text;
                            }
                        }
                        else
                        {
                            lblAddMsg.Text = "Only .jpg, .png and .ico are allowed to upload in banner !!";
                            FUBanner.Focus();
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(Path.GetFileName(FUBanner.PostedFile.FileName)) || lnkbanner.Text != "")
                    {
                        
                        if (string.IsNullOrEmpty(Path.GetFileName(FUBanner.PostedFile.FileName)) == false)
                        {
                            txttempiconnm.Text = Path.GetFileName(FUBanner.PostedFile.FileName);
                        }
                        else if (lnkbanner.Text != "")
                        {
                            txttempiconnm.Text = lnkbanner.Text;
                        }
                        else
                        {
                            txttempiconnm.Text = "";
                        }
                    }

                    if (btnAdd.Text == "Add")
                    {
                       
                        int cnt1 = 0;
                        cmd = new SqlCommand("Proc_ManageBanner", con);
                        con.Open();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                        cmd.Parameters.AddWithValue("@BannerName", txttempiconnm.Text);
                        // cmd.Parameters.AddWithValue("@strParentLnkId", Label1.Text);
                        if (rdblanguageAdd.SelectedValue == "English")
                        {
                            cmd.Parameters["@Mode"].Value = "chkdupbname";
                        }
                        else if (rdblanguageAdd.SelectedValue == "Hindi")
                        {
                            cmd.Parameters["@Mode"].Value = "chkdupbnameHnd";
                        }
                        else
                        {
                            cmd.Parameters["@Mode"].Value = "chkdupbnameMar";
                        }
                        cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                        if (cnt1 == 0)
                        {
                            int cnt2 = 0;
                            cmd = new SqlCommand("Proc_ManageBanner", con);
                            con.Open();
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                            cmd.Parameters.AddWithValue("@strPageId", ddlpage.SelectedValue);
                            if (rdblanguageAdd.SelectedValue == "English")
                            {
                                cmd.Parameters["@Mode"].Value = "chkduppgup";
                            }
                            else if (rdblanguageAdd.SelectedValue == "Hindi")
                            {
                                cmd.Parameters["@Mode"].Value = "chkduppgupHnd";
                            }
                            else
                            {
                                cmd.Parameters["@Mode"].Value = "chkduppgupMar";
                            }

                            cnt2 = Convert.ToInt32(cmd.ExecuteScalar());
                            con.Close();

                            if (cnt2 == 0)
                            {
                                cmd = new SqlCommand("Proc_ManageBanner", con);
                                con.Open();
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 50);
                                cmd.Parameters.AddWithValue("@Lnguage", rdblanguageAdd.SelectedValue);
                                cmd.Parameters.AddWithValue("@PageId", ddlpage.SelectedValue);
                                cmd.Parameters.AddWithValue("@BannerName", txttempiconnm.Text);
                                cmd.Parameters.AddWithValue("@ContentType", FUBanner.PostedFile.ContentType);
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                cmd.Parameters.AddWithValue("@Active", rdbAct.SelectedValue);
                                cmd.Parameters.AddWithValue("@stralttext", txtalttext.Text.Trim());
                                if (rdblanguageAdd.SelectedValue == "English")
                                {
                                    cmd.Parameters["@Mode"].Value = "AddBn";
                                }
                                else if (rdblanguageAdd.SelectedValue == "Hindi")
                                {
                                    cmd.Parameters["@Mode"].Value = "AddBnHindi";
                                }
                                else
                                {
                                    cmd.Parameters["@Mode"].Value = "AddBnMarathi";
                                }
                                cmd.ExecuteNonQuery();
                                audit_trail_Mode();
                                con.Close();
                                cleardata();
                                lblAddMsg.Text = "Banner uploaded successfully !!";
                                bind_gridAdd();
                            }

                            else
                            {
                                lblAddMsg.Text = "Already uploaded banner for this page !!";
                            }
                        }
                        else
                        {
                            lblAddMsg.Text = "Banner file name already exist !!";
                        }
                    }

                    else if (btnAdd.Text == "Update")
                    {
                     
                        int cnt2 = 0;
                        con.Open();
                        cmd = new SqlCommand("Proc_ManageBanner", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                        cmd.Parameters.AddWithValue("@strId", (Session["LnkId"]));
                        cmd.Parameters.AddWithValue("@BannerName", Strings.Trim(txttempiconnm.Text));
                        cmd.Parameters.AddWithValue("@ContentType", FUBanner.PostedFile.ContentType);
                        cmd.Parameters.AddWithValue("@Data", bytes);
                        // cmd.Parameters.AddWithValue("@strParentLnkId", Label1.Text);
                        cmd.Parameters["@Mode"].Value = "chkdupbnr";
                        cnt2 = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();

                        if (cnt2 == 0)
                        {
                            con.Open();
                            cmd = new SqlCommand("Proc_ManageBanner", con);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                            cmd.Parameters.AddWithValue("@Lnguage", rdblanguageAdd.SelectedValue);
                            cmd.Parameters.AddWithValue("@strPageId", ddlpage.SelectedValue);
                            cmd.Parameters.AddWithValue("@BannerName", txttempiconnm.Text);
                            cmd.Parameters.AddWithValue("@ContentType", FUBanner.PostedFile.ContentType);
                            cmd.Parameters.AddWithValue("@Data", bytes);
                            cmd.Parameters.AddWithValue("@strId", (Session["LnkId"]));
                            cmd.Parameters.AddWithValue("@Active", rdbAct.SelectedValue);
                            cmd.Parameters.AddWithValue("@stralttext", txtalttext.Text.Trim());
                            if (rdblanguageAdd.SelectedValue == "English")
                            {
                                cmd.Parameters["@Mode"].Value = "Editbn";
                            }
                            else if (rdblanguageAdd.SelectedValue == "Hindi")
                            {
                                cmd.Parameters["@Mode"].Value = "EditbnHindi";
                            }
                            else
                            {
                                cmd.Parameters["@Mode"].Value = "EditbnMarathi";
                            }
                            cmd.ExecuteNonQuery();
                            con.Close();
                            audit_trail_Mode();
                            cleardata();
                            lblAddMsg.Text = "Banner updated successfully !!";
                            bind_gridAdd();
                        }
                        else
                        {
                            lblAddMsg.Text = "Banner name already exists !!";
                        }
                    }
                }
                else
                {
                    lblAddMsg.Text = "Please upload banner !!";
                }

            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }

    private void cleardata()
    {
        // filldropdownpages();
        ddlpage.SelectedIndex = 0;
        lnkbanner.Text = "";
        txtalttext.Text = "";
        icodel1.Visible = false;
        btnAdd.Text = "Add";
        rdblanguageAdd.SelectedIndex = 0;
        lblAddMsg.Text = "";
        rdbAct.SelectedIndex = 0;
        lblAddEditHead.Text = "Add New Banner";
        btnReset.Visible = true;
    }

    public void audit_trail_Mode()
    {
        try
        {
            string Remark = "";
            string fields1 = "";
            //if (!string.IsNullOrEmpty(txtaddmenutext.Text))
            //{
            //  if (string.IsNullOrEmpty(fields1))
            //  {
            //    fields1 = "Menu Text: " + txtaddmenutext.Text;
            //  }
            //  else
            //  {
            //    fields1 = fields1 + "Menu Text: " + txtaddmenutext.Text;
            //  }
            //}

            if (!string.IsNullOrEmpty(ddlpage.SelectedItem.Text))
            {
                if (string.IsNullOrEmpty(fields1))
                {
                    fields1 = ", Banner Page: " + ddlpage.SelectedItem.Text;
                }
                else
                {
                    fields1 = fields1 + ", Banner Page: " + ddlpage.SelectedItem.Text;
                }
            }
            if (!string.IsNullOrEmpty(FUBanner.FileName))
            {
                if (string.IsNullOrEmpty(fields1))
                {
                    fields1 = ", Banner Name: " + FUBanner.FileName;
                }
                else
                {
                    fields1 = fields1 + ", Banner Name: " + FUBanner.FileName;
                }
            }

            //if (!string.IsNullOrEmpty(txtTempFilenm.Text))
            //{
            //  if (string.IsNullOrEmpty(fields1))
            //  {
            //    fields1 = ", File Name: " + txtTempFilenm.Text;
            //  }
            //  else
            //  {
            //    fields1 = fields1 + ", File Name: " + txtTempFilenm.Text;
            //  }
            //}

            if (string.IsNullOrEmpty(fields1))
            {
                fields1 = ", Active: " + rdbAct.SelectedItem.Text;
            }
            else
            {
                fields1 = fields1 + ", Active: " + rdbAct.SelectedItem.Text;
            }


            string LogNm = Session["log_name"].ToString();
            string LogId = Convert.ToString(Session["usr_id"]);
            string FieldNm = fields1;
            string TblNm = "";
            if (rdblanguageAdd.SelectedValue == "English")
            {
                TblNm = "Tbl_Banner";
            }
            else if (rdblanguageAdd.SelectedValue == "Hindi")
            {
                TblNm = "Tbl_BannerHindi";
            }
            else
            {
                TblNm = "Tbl_BannerMarathi";
            }
            string PageNm = "Manage_banner.aspx";
            string ModuleNm = "Manage Inner Banner";


            Remark = "Inner banner is Added";
            //audtclass.AditOnAdd(adm, "Add");
            con.Close();
            con.Open();
            cmd = new SqlCommand("proc_AuditTrail", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strLogNm", LogNm);
            cmd.Parameters.AddWithValue("@strLogId", LogId);
            cmd.Parameters.AddWithValue("@strTblNm", TblNm);
            cmd.Parameters.AddWithValue("@strFildNm", FieldNm);
            cmd.Parameters.AddWithValue("@strPgNm", PageNm);
            cmd.Parameters.AddWithValue("@strModuleNm", ModuleNm);
            cmd.Parameters.AddWithValue("@strAuditDt", DateAndTime.Now);




            if (btnAdd.Text == "Add")
            {
                cmd.Parameters.AddWithValue("@strAddOn", DateAndTime.Now);
                cmd.Parameters.AddWithValue("@strRemark", Remark);
                cmd.Parameters["@mode"].Value = "AuditOnAdd";
            }
            else if (btnAdd.Text == "Update")
            {
                cmd.Parameters.AddWithValue("@strEditOn", DateAndTime.Now);
                cmd.Parameters.AddWithValue("@strRemark", "Inner banner is Updated");
                cmd.Parameters["@mode"].Value = "AuditOnEdit";
            }
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    private bool chk_data()
    {

        if (ddlpage.SelectedIndex == 0)
        {
            lblAddMsg.Text = "Please select page !!";
            ddlpage.Focus();
            return false;
        }
        //else if (string.IsNullOrEmpty(Path.GetFileName(FUBanner.PostedFile.FileName)) || lnkbanner.Text=="")
        //{
        //  lblAddMsg.Text = "Please upload banner !!";
        //  FUBanner.Focus();
        //  return false;
        //}
        //else if (!FUBanner.HasFile)
        //{
        //  lblAddMsg.Text = "Please upload banner !!";
        //  FUBanner.Focus();
        //  return false;     
        //}

        else if (!string.IsNullOrEmpty(Path.GetFileName(FUBanner.PostedFile.FileName)) && FUBanner.PostedFile.ContentLength > 153600)
        {
            lblAddMsg.Text = "Banner size should be less than 150 kb !!";
            FUBanner.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(Path.GetFileName(FUBanner.PostedFile.FileName)) && checkwidth() == false)
        {
            lblAddMsg.Text = "Width must not exceed 1366px or not less than 1366px !!";
            FUBanner.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(Path.GetFileName(FUBanner.PostedFile.FileName)) && checkheight() == false)
        {
            lblAddMsg.Text = "Height must not exceed 300px or not less than 300px !!";
            FUBanner.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(Path.GetFileName(FUBanner.PostedFile.FileName)) & checkRealFile(FUBanner) == false)
        {
            lblAddMsg.Text = "Only .jpg, .png and .ico are allowed to upload in banner";
            FUBanner.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtalttext.Text.Trim()))
        {
            lblAddMsg.Text = "Please enter the alternate text for image";
            txtalttext.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtalttext.Text.Trim()) && !Regex.IsMatch(txtalttext.Text.Trim(),"^[a-zA-Z0-9| ]+$"))
        {
            lblAddMsg.Text = "Please enter the alternate text for image";
            txtalttext.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtalttext.Text.Trim()) && txtalttext.Text.Trim().Length < 2)
        {
            lblAddMsg.Text = "Image alternate text contains minimum 2 characters !!";
            txtalttext.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtalttext.Text.Trim()) && txtalttext.Text.Trim().Length > 100)
        {
            lblAddMsg.Text = "Image alternate text contains maximum 100 characters !!";
            txtalttext.Focus();
            return false;
        }
        else
        {
            lblAddMsg.Text = "";
            return true;
        }
    }

    private bool checkheight()
    {
        System.Drawing.Image img = System.Drawing.Image.FromStream(FUBanner.PostedFile.InputStream);
        int height = img.Height;
        int width = img.Width;

        if (height > 300)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private bool checkwidth()
    {
        System.Drawing.Image img = System.Drawing.Image.FromStream(FUBanner.PostedFile.InputStream);
        int height = img.Height;
        int width = img.Width;

        if (width > 1366)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private bool checkRealFile(FileUpload FUBanner)
    {
        if (FUBanner.HasFile)
        {
            FUBanner.PostedFile.SaveAs(Server.MapPath("..\\InnerBanner") + "\\" + FUBanner.FileName);
            if (HasMzSignature(Server.MapPath("..\\InnerBanner") + "\\" + FUBanner.FileName))
            {
                FileInfo fd = new FileInfo(Server.MapPath("..\\InnerBanner") + "\\" + FUBanner.FileName);
                fd.Delete();
                return false;
            }
            else
            {
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
    protected void dg_PgEng_ItemCommand(object source, DataGridCommandEventArgs e)
    {


        if (e.CommandName == "PgEditEng")
        {
            string linkid = e.Item.Cells[0].Text;
            string lang = e.Item.Cells[5].Text;

            Session["LnkId"] = e.Item.Cells[0].Text;
            // clear_AddData();
            // tr_menu.Visible = true;
            // tbl_AddPg.Visible = true;
            lnkAddNew.Visible = false;
            //  lblAddMainHead.Text = "Update Menu";
            trsearch.Visible = false;
            tradd.Visible = true;
            btnAdd.Text = "Update";
            lblAddEditHead.Text = "Edit Banner";
            btnReset.Visible = false;

            //tval.Text = e.Item.Cells[0].Text;
            string lnkid = Session["LnkId"].ToString();

            if (lang == "English")
            {

                fill_MenuDtls(lnkid);
            }
            else if (lang == "Hindi")
            {

                fill_MenuDtlsHindi(lnkid);
            }

            else
            {
                fill_MenuDtlsMarathi(lnkid);
            }
        }


        else if (e.CommandName == "PgDeleteEng")
        {
            string linkid = e.Item.Cells[0].Text;
            string lang = e.Item.Cells[5].Text;
            Session["LnkId"] = e.Item.Cells[0].Text;


            con.Open();
            cmd = new SqlCommand("Proc_ManageBanner", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strId", (Session["LnkId"]).ToString());
            if (lang == "English")
            {

                cmd.Parameters["@Mode"].Value = "delinban";
            }
            else if (lang == "Hindi")
            {

                cmd.Parameters["@Mode"].Value = "delinbanHindi";
            }
            else
            {
                cmd.Parameters["@Mode"].Value = "delinbanMarathi";
            }
            cmd.ExecuteNonQuery();
            con.Close();


            ///////////////////////////////Delete sitemap/////////////////////////////

            //int cntSlnkid;

            //con.Open();
            //cmd = new SqlCommand("Proc_Sitemap", con);
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            //cmd.Parameters.AddWithValue("@strMenucntrlID", linkid1);
            //cmd.Parameters.AddWithValue("@strMenuTyp", "M");
            //cmd.Parameters["@Mode"].Value = "GetLnkidForDelete";
            //cntSlnkid = Convert.ToInt32(cmd.ExecuteScalar());
            //con.Close();


            //con.Open();
            //cmd = new SqlCommand("Proc_Sitemap", con);
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            //cmd.Parameters.AddWithValue("@strLnkId", cntSlnkid);
            //cmd.Parameters["@Mode"].Value = "DelLnkFooter";
            //cmd.ExecuteNonQuery();
            //con.Close();


            ///////////////////////////////End of Delete sitemap/////////////////////////////






            string mnm1 = e.Item.Cells[3].Text;

            string fields1 = "";
            if (!string.IsNullOrEmpty(mnm1))
            {
                if (string.IsNullOrEmpty(fields1))
                {
                    fields1 = "Inner Banner : " + mnm1;
                }
                else
                {
                    fields1 = fields1 + ", Inner Banner : ";
                }
            }
            ///''''''''''''''''''''''''''''''''''''''''''''''''''''''''call Audit Trail Function
            ///

            string LogNm = Session["log_name"].ToString();
            string LogId = Convert.ToString(Session["usr_id"]);
            string FieldNm = fields1;
            string TblNm = "";

            if (lang == "English")
            {
                TblNm = "Tbl_Banner";
            }
            else if (lang == "Hindi")
            {
                TblNm = "Tbl_BannerHindi";
            }
            else
            {
                TblNm = "Tbl_BannerMarathi";
            }
            string PageNm = "Manage_banner.aspx";
            string ModuleNm = "Manage Inner Banner";


            string Remark = "Inner Banner is Deleted";
            //audtclass.AditOnAdd(adm, "Add");

            con.Open();
            cmd = new SqlCommand("proc_AuditTrail", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strLogNm", LogNm);
            cmd.Parameters.AddWithValue("@strLogId", LogId);
            cmd.Parameters.AddWithValue("@strTblNm", TblNm);
            cmd.Parameters.AddWithValue("@strFildNm", FieldNm);
            cmd.Parameters.AddWithValue("@strPgNm", PageNm);
            cmd.Parameters.AddWithValue("@strModuleNm", ModuleNm);
            cmd.Parameters.AddWithValue("@strAuditDt", DateAndTime.Now);
            cmd.Parameters.AddWithValue("@strRemark", Remark);
            cmd.Parameters.AddWithValue("@strDelOn", DateAndTime.Now);
            cmd.Parameters["@mode"].Value = "AuditOnDelete";
            cmd.ExecuteNonQuery();
            con.Close();

            lblmsg.Text = "Inner Banner Deleted successfully";

            if (lnkAddNew.Visible == true)
            {
                bind_grid();
            }
            else
            {
                bind_gridAdd();
            }
        }

        else if (e.CommandName == "PgCheckEng")
        {
            string linkid = e.Item.Cells[0].Text;
            string lang = e.Item.Cells[5].Text;
            Session["LnkId"] = e.Item.Cells[0].Text;


            con.Open();
            cmd = new SqlCommand("Proc_ManageBanner", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strId", (Session["LnkId"]).ToString());
            if (lang == "English")
            {
                cmd.Parameters["@Mode"].Value = "chkdupchecker";
            }
            else if (lang == "Hindi")
            {
                cmd.Parameters["@Mode"].Value = "chkdupcheckerHnd";
            }
            else
            {
                cmd.Parameters["@Mode"].Value = "chkdupcheckerMar";
            }
            int cntdup = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            if (cntdup > 0)
            {
                con.Open();
                cmd = new SqlCommand("Proc_ManageBanner", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strId", (Session["LnkId"]).ToString());
                if (lang == "English")
                {
                    cmd.Parameters["@Mode"].Value = "deldupchk";
                }
                else if (lang == "Hindi")
                {
                    cmd.Parameters["@Mode"].Value = "deldupchkHnd";
                }
                else
                {
                    cmd.Parameters["@Mode"].Value = "deldupchkMar";
                }
                cmd.ExecuteNonQuery();
                con.Close();
            }

            con.Open();
            cmd = new SqlCommand("Proc_ManageBanner", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strId", (Session["LnkId"]).ToString());
            if (lang == "English")
            {
                cmd.Parameters["@Mode"].Value = "inschecker";
            }
            else if (lang == "Hindi")
            {
                cmd.Parameters["@Mode"].Value = "inscheckerHnd";
            }
            else
            {
                cmd.Parameters["@Mode"].Value = "inscheckerMar";
            }
            cmd.ExecuteNonQuery();
            con.Close();

            if (lnkAddNew.Visible == true)
            {
                bind_grid();
            }
            else
            {
                bind_gridAdd();
            }

        }
    }

    private void fill_MenuDtlsMarathi(string lnkid)
    {
        try
        {

            con.Open();
            cmd = new SqlCommand("Proc_ManageBanner", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strId", lnkid);


            cmd.Parameters["@Mode"].Value = "chkdtbtMarathi";


            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds, "tbl_LnkDtls");
            con.Close();


            if (!(ds.Tables["tbl_LnkDtls"].Rows.Count == 0))
            {

                if (Information.IsDBNull(ds.Tables["tbl_LnkDtls"].Rows[0]["Lnguage"]) == false)
                {
                    rdblanguageAdd.SelectedValue = ds.Tables["tbl_LnkDtls"].Rows[0]["Lnguage"].ToString();
                    filldropdownpages();
                }


                if (Information.IsDBNull(ds.Tables["tbl_LnkDtls"].Rows[0]["Lnguage"]) == false)
                {
                    rdblanguageAdd.SelectedValue = ds.Tables["tbl_LnkDtls"].Rows[0]["Lnguage"].ToString();
                }
                else
                {
                    rdblanguageAdd.SelectedValue = "0";
                }



                string lnkact = null;
                if (Information.IsDBNull(ds.Tables["tbl_LnkDtls"].Rows[0]["Active"]) == false)
                {
                    lnkact = ds.Tables["tbl_LnkDtls"].Rows[0]["Active"].ToString();
                }
                else
                {
                    lnkact = "";
                }
                if (lnkact == "N")
                {
                    rdbAct.SelectedIndex = 1;
                }
                else
                {
                    rdbAct.SelectedIndex = 0;
                }


                if (Information.IsDBNull(ds.Tables["tbl_LnkDtls"].Rows[0]["BannerName"]) == false)
                {
                    txttempiconnm.Text = "";
                    lnkbanner.Text = ds.Tables["tbl_LnkDtls"].Rows[0]["BannerName"].ToString();
                    icodel1.Visible = true;
                }
                else
                {
                    txttempiconnm.Text = "";
                    lnkbanner.Text = "";
                }

                if (Information.IsDBNull(ds.Tables["tbl_LnkDtls"].Rows[0]["PageId"]) == false)
                {
                    ddlpage.SelectedValue = ds.Tables["tbl_LnkDtls"].Rows[0]["PageId"].ToString();
                }
                else
                {
                    ddlpage.SelectedIndex = 0;
                }


            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }

    private void fill_MenuDtlsHindi(string lnkid)
    {
        try
        {

            con.Open();
            cmd = new SqlCommand("Proc_ManageBanner", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strId", lnkid);


            cmd.Parameters["@Mode"].Value = "chkdtbtHindi";


            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds, "tbl_LnkDtls");
            con.Close();

            if (!(ds.Tables["tbl_LnkDtls"].Rows.Count == 0))
            {

                if (Information.IsDBNull(ds.Tables["tbl_LnkDtls"].Rows[0]["Lnguage"]) == false)
                {
                    rdblanguageAdd.SelectedValue = ds.Tables["tbl_LnkDtls"].Rows[0]["Lnguage"].ToString();
                    filldropdownpages();
                }

                if (Information.IsDBNull(ds.Tables["tbl_LnkDtls"].Rows[0]["Lnguage"]) == false)
                {
                    rdblanguageAdd.SelectedValue = ds.Tables["tbl_LnkDtls"].Rows[0]["Lnguage"].ToString();
                }
                else
                {
                    rdblanguageAdd.SelectedValue = "0";
                }



                string lnkact = null;
                if (Information.IsDBNull(ds.Tables["tbl_LnkDtls"].Rows[0]["Active"]) == false)
                {
                    lnkact = ds.Tables["tbl_LnkDtls"].Rows[0]["Active"].ToString();
                }
                else
                {
                    lnkact = "";
                }
                if (lnkact == "N")
                {
                    rdbAct.SelectedIndex = 1;
                }
                else
                {
                    rdbAct.SelectedIndex = 0;
                }


                if (Information.IsDBNull(ds.Tables["tbl_LnkDtls"].Rows[0]["BannerName"]) == false)
                {
                    txttempiconnm.Text = "";
                    lnkbanner.Text = ds.Tables["tbl_LnkDtls"].Rows[0]["BannerName"].ToString();
                    icodel1.Visible = true;
                }
                else
                {
                    txttempiconnm.Text = "";
                    lnkbanner.Text = "";
                }

                if (Information.IsDBNull(ds.Tables["tbl_LnkDtls"].Rows[0]["PageId"]) == false)
                {
                    ddlpage.SelectedValue = ds.Tables["tbl_LnkDtls"].Rows[0]["PageId"].ToString();
                }
                else
                {
                    ddlpage.SelectedIndex = 0;
                }


            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }

    private void fill_MenuDtls(string lnkid)
    {
        try
        {

            con.Open();
            cmd = new SqlCommand("Proc_ManageBanner", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strId", lnkid);


            cmd.Parameters["@Mode"].Value = "chkdtbt";


            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds, "tbl_LnkDtls");
            con.Close();

            if (!(ds.Tables["tbl_LnkDtls"].Rows.Count == 0))
            {

                if (Information.IsDBNull(ds.Tables["tbl_LnkDtls"].Rows[0]["Lnguage"]) == false)
                {
                    rdblanguageAdd.SelectedValue = ds.Tables["tbl_LnkDtls"].Rows[0]["Lnguage"].ToString();
                }
                else
                {
                    rdblanguageAdd.SelectedValue = "0";
                }



                string lnkact = null;
                if (Information.IsDBNull(ds.Tables["tbl_LnkDtls"].Rows[0]["Active"]) == false)
                {
                    lnkact = ds.Tables["tbl_LnkDtls"].Rows[0]["Active"].ToString();
                }
                else
                {
                    lnkact = "";
                }
                if (lnkact == "N")
                {
                    rdbAct.SelectedIndex = 1;
                }
                else
                {
                    rdbAct.SelectedIndex = 0;
                }


                if (Information.IsDBNull(ds.Tables["tbl_LnkDtls"].Rows[0]["BannerName"]) == false)
                {
                    txttempiconnm.Text = "";
                    lnkbanner.Text = ds.Tables["tbl_LnkDtls"].Rows[0]["BannerName"].ToString();
                    icodel1.Visible = true;
                }
                else
                {
                    txttempiconnm.Text = "";
                    lnkbanner.Text = "";
                }

                if (Information.IsDBNull(ds.Tables["tbl_LnkDtls"].Rows[0]["AltText"]) == false)
                {
                    txtalttext.Text = ds.Tables["tbl_LnkDtls"].Rows[0]["AltText"].ToString();
                   
                }
                else
                {
                    txtalttext.Text = "";
                }

                if (Information.IsDBNull(ds.Tables["tbl_LnkDtls"].Rows[0]["PageId"]) == false)
                {
                    ddlpage.SelectedValue = ds.Tables["tbl_LnkDtls"].Rows[0]["PageId"].ToString();
                }
                else
                {
                    ddlpage.SelectedIndex = 0;
                }


            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }
    protected void rdblanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldropdownpagesSearch();
        bind_grid();
    }
    protected void rdblanguageAdd_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldropdownpages();
        bind_gridAdd();
    }

    private void bind_gridAdd()
    {
        try
        {
            int cnt1 = 0;
            string Usrtype = Session["usr_type"].ToString();
            con.Close();
            con.Open();
            cmd = new SqlCommand("Proc_ManageBanner", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@Lnguage", rdblanguageAdd.SelectedValue);
            cmd.Parameters.AddWithValue("@strLogNm", Session["log_name"].ToString());
            //cmd.Parameters.AddWithValue("@strPageId", Convert.ToString(Session["PgId1"]));
            if (rdblanguageAdd.SelectedValue == "English")
            {
                if (Usrtype == "admin")
                {
                    cmd.Parameters["@Mode"].Value = "cntbn1adm";
                }
                else
                {

                    cmd.Parameters["@Mode"].Value = "cntbn1";
                }
            }
            else if (rdblanguageAdd.SelectedValue == "Hindi")
            {
                if (Usrtype == "admin")
                {
                    cmd.Parameters["@Mode"].Value = "cntbn1Hindiadm";
                }
                else
                {

                    cmd.Parameters["@Mode"].Value = "cntbn1Hindi";
                }
            }
            else
            {
                if (Usrtype == "admin")
                {
                    cmd.Parameters["@Mode"].Value = "cntbn1MarathiAdm";
                }
                else
                {

                    cmd.Parameters["@Mode"].Value = "cntbn1Marathi";
                }
            }
            cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();


            if (cnt1 != 0)
            {
                con.Open();
                cmd = new SqlCommand("Proc_ManageBanner", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@Lnguage", rdblanguageAdd.SelectedValue);
                cmd.Parameters.AddWithValue("@strLogNm", Session["log_name"].ToString());
                //cmd.Parameters.AddWithValue("@strPageId", Convert.ToString(Session["PgId1"]));
                if (rdblanguageAdd.SelectedValue == "English")
                {
                    if (Usrtype == "admin")
                    {
                        cmd.Parameters["@Mode"].Value = "dispbannerAdm";
                    }
                    else
                    {

                        cmd.Parameters["@Mode"].Value = "dispbanner";
                    }
                }
                else if (rdblanguageAdd.SelectedValue == "Hindi")
                {
                    if (Usrtype == "admin")
                    {
                        cmd.Parameters["@Mode"].Value = "dispbannerHindiadm";
                    }
                    else
                    {

                        cmd.Parameters["@Mode"].Value = "dispbannerHindi";
                    }
                }
                else
                {
                    if (Usrtype == "admin")
                    {
                        cmd.Parameters["@Mode"].Value = "dispbannerMarathiAdm";
                    }
                    else
                    {

                        cmd.Parameters["@Mode"].Value = "dispbannerMarathi";
                    }
                }

                ds = new DataSet();
                da = new SqlDataAdapter(cmd);

                da.Fill(ds);
                dg_PgEng.DataSource = ds.Tables[0];
                dg_PgEng.DataBind();
                dg_PgEng.Visible = true;
                lblmsg.Text = Convert.ToString(ds.Tables[0].Rows.Count) + " " + "Record's Found";

            }
            else
            {
                //dg_PgEng.DataSource = null;
                //dg_Menu.DataBind();
                //dg_Menu.Visible = false;
                lblmsg.Text = "No Record Found !!";
                dg_PgEng.Visible = false;
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
    protected void dg_PgEng_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.SelectedItem | e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.EditItem)
        {
            String checkeddata = "";

            string lnkAct = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Active")) == false)
            {
                lnkAct = DataBinder.Eval(e.Item.DataItem, "Active").ToString();
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
                ((LinkButton)e.Item.Cells[5].FindControl("lnkCheckEng")).Enabled = false;
                ((LinkButton)e.Item.Cells[5].FindControl("lnkCheckEng")).ForeColor = System.Drawing.Color.Gray;
            }
            else
            {
                ((LinkButton)e.Item.Cells[5].FindControl("lnkCheckEng")).Enabled = true;
                // ((LinkButton)e.Item.Cells[6].FindControl("lnkcheck")).ForeColor = System.Drawing.Color.Gray;
            }

            if (userPriv == "Checker" || userPriv == "admin" && checkeddata == "N")
            {
                ((LinkButton)e.Item.Cells[5].FindControl("lnkCheckEng")).ForeColor = System.Drawing.Color.Red;
            }

            if (checkeddata == "Y")
            {
                ((LinkButton)e.Item.Cells[5].FindControl("lnkCheckEng")).Enabled = false;
                ((LinkButton)e.Item.Cells[5].FindControl("lnkCheckEng")).ForeColor = System.Drawing.Color.Green;
                ((LinkButton)e.Item.Cells[5].FindControl("lnkCheckEng")).Text = "Checked";

            }

            if (lnkAct == "Y")
            {
                ((LinkButton)e.Item.Cells[5].FindControl("lnkDeleteEng")).Enabled = true;
            }
            else if (lnkAct == "N")
            {

                ((LinkButton)e.Item.Cells[5].FindControl("lnkDeleteEng")).Enabled = false;

                ((LinkButton)e.Item.Cells[5].FindControl("lnkDeleteEng")).ForeColor = System.Drawing.Color.Gray;

                e.Item.Cells[2].ForeColor = System.Drawing.Color.Gray;
                e.Item.Cells[3].ForeColor = System.Drawing.Color.Gray;
                e.Item.Cells[4].ForeColor = System.Drawing.Color.Gray;
                e.Item.Cells[5].ForeColor = System.Drawing.Color.Gray;

            }


            if (userPriv == "Checker")
            {
                ((LinkButton)e.Item.Cells[5].FindControl("lnEditEng")).Enabled = false;
                ((LinkButton)e.Item.Cells[5].FindControl("lnEditEng")).ForeColor = System.Drawing.Color.Gray;
                ((LinkButton)e.Item.Cells[5].FindControl("lnkDeleteEng")).Enabled = false;
                ((LinkButton)e.Item.Cells[5].FindControl("lnkDeleteEng")).ForeColor = System.Drawing.Color.Gray;

                lnkAddNew.Enabled = false;
                lnkAddNew.ForeColor = System.Drawing.Color.Gray;
            }

            if (lnkAct == "Y")
            {
                ///''''''''''''confirmation before deletion
                ((LinkButton)e.Item.Cells[5].FindControl("lnkDeleteEng")).Attributes.Add("onclick", "javascript: return confirm('Are you sure you want to delete this link?')");
            }

        }
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        bind_grid();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        cleardata();
        txtPageSize.Text = "10";
        txtPageIndex.Text = "1";
        dg_Griev_indexSizeAdd();
        bind_gridAdd();

        filldropdownpages();
    }
    protected void btnsearchReset_Click(object sender, EventArgs e)
    {
        rdblanguage.SelectedIndex = 0;
        filldropdownpagesSearch();
        txtpageName.Text = "";
        txtPageSize.Text = "10";
        txtPageIndex.Text = "1";
        dg_Griev_indexSize();
        bind_grid();
    }
    protected void icodel1_Click(object sender, ImageClickEventArgs e)
    {
        string filename = lnkbanner.Text;
        string path = Server.MapPath("../InnerBanner/" + filename);
        //  File.Delete(path);
        lnkbanner.Text = "";
        icodel1.Visible = false;
        // lblMainMsg.Text = "Deleted successfully";
        FUBanner.Focus();
    }
    protected void dg_PgEng_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        dg_PgEng.CurrentPageIndex = e.NewPageIndex;
        bind_grid();

        string x1 = dg_PgEng.CurrentPageIndex.ToString();
        int currPage = Convert.ToInt32(x1) + 1;
        string x2 = dg_PgEng.PageCount.ToString();
    }

    protected void btnPageSize_Click(object sender, EventArgs e)
    {
        if (txtPageSize.Text != "" && !Regex.IsMatch(txtPageSize.Text, "^[0-9]+$"))
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Enter only digits";
            txtPageSize.Focus();
        }


        else if (txtPageSize.Text != "" && (!(Convert.ToInt32(txtPageSize.Text) < 0) & Convert.ToInt32(txtPageSize.Text) > 0))
        {
            dg_Griev_indexSize();
        }
        else
        {
            txtPageSize.Text = "";
        }
    }

    public void dg_Griev_indexSize()
    {
        try
        {
            if (!string.IsNullOrEmpty(txtPageSize.Text))
            {
                if (!string.IsNullOrEmpty(txtPageSize.Text) & Information.IsNumeric(txtPageSize.Text) == true)
                {
                    dg_PgEng.PageSize = Convert.ToInt32(txtPageSize.Text);
                }
            }

            int pg_index = 0;
            if (!string.IsNullOrEmpty(txtPageIndex.Text))
            {
                if (!string.IsNullOrEmpty(txtPageIndex.Text) & Information.IsNumeric(txtPageIndex.Text) == true)
                {
                    if (Convert.ToInt32(txtPageIndex.Text) != 0)
                    {
                        pg_index = Convert.ToInt32(txtPageIndex.Text) - 1;

                        dg_PgEng.CurrentPageIndex = pg_index;
                    }
                }
            }

            bind_grid();

            string x1 = Convert.ToString(dg_PgEng.CurrentPageIndex);
            int currPage = Convert.ToInt32(x1) + 1;
            string x2 = Convert.ToString(dg_PgEng.PageCount);
            txtPageIndex.Text = Convert.ToString(currPage);
            lblPageIndex.Text = "Page" + " " + currPage + " " + "of" + " " + x2 + " " + ". Skip to page";

            if (string.IsNullOrEmpty(txtPageSize.Text))
            {
                int n = dg_PgEng.Items.Count;
                txtPageSize.Text = Convert.ToString(n);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);

        }

    }
    protected void btnPageIndex_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtPageIndex.Text != "" && !Regex.IsMatch(txtPageIndex.Text, "^[0-9]+$"))
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Enter only digits";
                txtPageIndex.Focus();
            }
            else if (txtPageIndex.Text != "" && !(Convert.ToInt32(txtPageIndex.Text) < 0))
            {

                dg_Griev_indexSize();
            }
            else
            {
                txtPageIndex.Text = "";
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }


    public void dg_Griev_indexSizeAdd()
    {
        try
        {
            if (!string.IsNullOrEmpty(txtPageSize.Text))
            {
                if (!string.IsNullOrEmpty(txtPageSize.Text) & Information.IsNumeric(txtPageSize.Text) == true)
                {
                    dg_PgEng.PageSize = Convert.ToInt32(txtPageSize.Text);
                }
            }

            int pg_index = 0;
            if (!string.IsNullOrEmpty(txtPageIndex.Text))
            {
                if (!string.IsNullOrEmpty(txtPageIndex.Text) & Information.IsNumeric(txtPageIndex.Text) == true)
                {
                    if (Convert.ToInt32(txtPageIndex.Text) != 0)
                    {
                        pg_index = Convert.ToInt32(txtPageIndex.Text) - 1;

                        dg_PgEng.CurrentPageIndex = pg_index;
                    }
                }
            }

            bind_gridAdd();

            string x1 = Convert.ToString(dg_PgEng.CurrentPageIndex);
            int currPage = Convert.ToInt32(x1) + 1;
            string x2 = Convert.ToString(dg_PgEng.PageCount);
            txtPageIndex.Text = Convert.ToString(currPage);
            lblPageIndex.Text = "Page" + " " + currPage + " " + "of" + " " + x2 + " " + ". Skip to page";

            if (string.IsNullOrEmpty(txtPageSize.Text))
            {
                int n = dg_PgEng.Items.Count;
                txtPageSize.Text = Convert.ToString(n);
            }


        }
        catch (Exception ex)
        {
            Response.Write(ex);

        }


    }
}