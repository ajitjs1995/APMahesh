using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.VisualBasic;
using System.Data;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

public partial class tmbadm_ManagePressRelease : System.Web.UI.Page
{
    public Label lblpath1 = new Label();
    private AdmChkClass chkclass = new AdmChkClass();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    System.Data.DataSet ds = new System.Data.DataSet();
    System.Data.DataSet ds1 = new System.Data.DataSet();
    SqlDataReader dr;
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["TMBCON"].ToString());
    string strAlpha;
    string fields1 = "";
    string msg = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtSrchFileNm.Attributes.Add("autocomplete", "off");
            txtDescsrch.Attributes.Add("autocomplete", "off");
            txtFromDate.Attributes.Add("autocomplete", "off");

            txtitle.Attributes.Add("autocomplete", "off");
            txtdesc.Attributes.Add("autocomplete", "off");
            txtheading.Attributes.Add("autocomplete", "off");
            txtnoticedate.Attributes.Add("autocomplete", "off");
             fill_WebPg("Add");
           // clear_AddData();
            dg_press.Visible = true;
            tr_AddNew.Visible = false;
            trdatagrid.Visible = true;
            lblmsg.Visible = true;
            fill_grid();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            
            
            string filepath = string.Empty;
            if (!string.IsNullOrEmpty(FileNews.FileName))
            {
                filepath = "../press/" + FileNews.FileName;
            }
            bool exists = File.Exists(Server.MapPath(filepath));

            if (string.IsNullOrEmpty(txtitle.Text.Trim()))
            {
                lblMainMsg.Text = "Please enter  title !!";
                txtitle.Focus();
                
            }
           else if (string.IsNullOrEmpty(txtitle.Text.Trim()) && Regex.IsMatch(txtitle.Text, "^[  ]+$"))
            {
                lblMainMsg.Text = "Please enter  title !!";
                txtitle.Focus();

            }
            else if (!string.IsNullOrEmpty(txtitle.Text.Trim()) && chkNwsDesc(txtitle.Text.Trim()) == false)
            {
                lblMainMsg.Text = "Please Enter valid  title !!";
                txtitle.Focus();
            }
            else if (chkNwsDesc(txtitle.Text.Trim()) == false)
            {
                lblMainMsg.Text = "Please Enter valid  title !!";
                txtitle.Focus();
            }
            else if (!string.IsNullOrEmpty(txtitle.Text.Trim()) & txtitle.Text.Length < 10)
            {
                lblMainMsg.Text = "Title should contain minimum 10 characters !!";
                txtitle.Focus();
            }
            else if (!string.IsNullOrEmpty(txtitle.Text.Trim()) && txtitle.Text.Length > 100)
            {
                lblMainMsg.Text = "Title should contain maximum 100 characters !!";
                txtitle.Focus();
            }
            else if (string.IsNullOrEmpty(txtnoticedate.Text.Trim()))
            {
                lblMainMsg.Text = "Please select notice date !!";
                txtnoticedate.Focus();
            }
            else if (string.IsNullOrEmpty(txtheading.Text.Trim()))
            {
                lblMainMsg.Text = "Please enter  file heading !!";
                txtheading.Focus();

            }
            else if (!string.IsNullOrEmpty(txtheading.Text.Trim()) && chkNwsDesc(txtheading.Text.Trim()) == false)
            {
                lblMainMsg.Text = "Please Enter valid  file heading !!";
                txtheading.Focus();
            }
            else if (!string.IsNullOrEmpty(txtheading.Text) && Regex.IsMatch(txtheading.Text, "^[  ]+$"))
            {
                lblMainMsg.Text = "Please Enter valid  file heading !!";
                txtheading.Focus();
            }
            else if (!string.IsNullOrEmpty(txtheading.Text.Trim()) & txtheading.Text.Length < 10)
            {
                lblMainMsg.Text = "File heading should contain minimum 10 characters!!";
                txtheading.Focus();
            }
            else if (!string.IsNullOrEmpty(txtheading.Text.Trim()) & txtheading.Text.Length > 300)
            {
                lblMainMsg.Text = "File heading should contain maximum 300 characters!!";
                txtheading.Focus();
            }
            else if (string.IsNullOrEmpty(txtdesc.Text.Trim()))
            {
                lblMainMsg.Text = "Please enter description !!";
                txtdesc.Focus();

            }
            else if (!string.IsNullOrEmpty(txtdesc.Text.Trim()) && chkNwsDesc(txtdesc.Text.Trim()) == false)
            {
                lblMainMsg.Text = "Please Enter valid  description !!";
                txtdesc.Focus();
            }
            else if (!string.IsNullOrEmpty(txtdesc.Text) && Regex.IsMatch(txtdesc.Text, "^[  ]+$"))
            {
                lblMainMsg.Text = "Please Enter valid  description !!";
                txtdesc.Focus();
            }
            else if (!string.IsNullOrEmpty(txtdesc.Text.Trim()) & txtdesc.Text.Length < 10)
            {
                lblMainMsg.Text = "Description should contain minimum 10 characters !!";
                txtdesc.Focus();
            }
            else if (!string.IsNullOrEmpty(txtdesc.Text.Trim()) & txtdesc.Text.Length > 500)
            {
                lblMainMsg.Text = "Description should contain maximum 500 characters !!";
                txtdesc.Focus();
            }



            else if (!(btnAdd.Text == "Update") && string.IsNullOrEmpty(Path.GetFileName(FileNews.PostedFile.FileName)) && string.IsNullOrEmpty(txturl.Text.Trim()))
            {
                lblMainMsg.Text = "Select press file to upload  !!";
                FileNews.Focus();
            }
         
            else if (chk_NewsLink() == false)
            {
                lblMainMsg.Text = lblMainMsg.Text;
            }
            else if (exists)
            {
                lblMainMsg.Text = "This file name is already exist !!";
                FileNews.Focus();
            }
            else if (!string.IsNullOrEmpty(FileNews.PostedFile.FileName) && checkRealFile(FileNews) == false)
            {
                lblMainMsg.Text = "Please select file !!";
                FileNews.Focus();
            }
            //else if (!(btnAdd.Text == "Update") && string.IsNullOrEmpty(Path.GetFileName(FileNews.PostedFile.FileName)) && string.IsNullOrEmpty(txturl.Text.Trim()))
            //{
            //    lblMainMsg.Text = "Select press file to upload !!";
            //    FileNews.Focus();
            //}

            else if (!string.IsNullOrEmpty(Path.GetFileName(FileNews.PostedFile.FileName)) & Path.GetFileName(FileNews.PostedFile.FileName).Contains(".exe"))
            {
                lblMainMsg.Text = "Only word, pdf, excel, zip , jpg and png documents are allowed to upload !!";
                FileNews.Focus();
            }
            else if (!string.IsNullOrEmpty(Path.GetFileName(FileNews.PostedFile.FileName)) & Path.GetFileName(FileNews.PostedFile.FileName).Contains(".htm"))
            {
                lblMainMsg.Text = "Only word, pdf, excel, zip , jpg and png documents are allowed to upload !!";
                FileNews.Focus();
            }
            else if (!string.IsNullOrEmpty(Path.GetFileName(FileNews.PostedFile.FileName)) & Path.GetFileName(FileNews.PostedFile.FileName).Contains(".asp"))
            {
                lblMainMsg.Text = "Only word, pdf, excel, zip , jpg and png documents are allowed to upload !!";
                FileNews.Focus();
            }
            else if (!string.IsNullOrEmpty(Path.GetFileName(FileNews.PostedFile.FileName)) & !Path.GetFileName(FileNews.PostedFile.FileName).Contains(".doc") & !Path.GetFileName(FileNews.PostedFile.FileName).Contains(".pdf") & !Path.GetFileName(FileNews.PostedFile.FileName).Contains(".xls") & !Path.GetFileName(FileNews.PostedFile.FileName).Contains(".zip") & !Path.GetFileName(FileNews.PostedFile.FileName).Contains(".rar") & !Path.GetFileName(FileNews.PostedFile.FileName).Contains(".jpg") & !Path.GetFileName(FileNews.PostedFile.FileName).Contains(".jpeg") & !Path.GetFileName(FileNews.PostedFile.FileName).Contains(".docx") & !Path.GetFileName(FileNews.PostedFile.FileName).Contains(".png"))
            {
                lblMainMsg.Text = "Only word, pdf, excel, zip , jpg and png documents are allowed to upload !!";
                FileNews.Focus();
            }
            else if (!string.IsNullOrEmpty(Path.GetFileName(FileNews.PostedFile.FileName)) & FileNews.PostedFile.ContentLength >= 4194304)
            {
                lblMainMsg.Text = "Your file size should be less than 4MB !!";
                FileNews.Focus();
            }
            else if (!string.IsNullOrEmpty(Path.GetFileName(FileNews.PostedFile.FileName)) & Path.GetFileName(FileNews.PostedFile.FileName).Length > 100)
            {
                lblMainMsg.Text = "Your file name can contain max 100 characters !!";
                FileNews.Focus();
            }
            else if (btnAdd.Text == "Update" && string.IsNullOrEmpty(Path.GetFileName(FileNews.PostedFile.FileName)) && string.IsNullOrEmpty(txtTempFilenm.Text.Trim()) && string.IsNullOrEmpty(txturl.Text.Trim()) && cmbWebPage.SelectedIndex !=0)
            {
                lblMainMsg.Text = "Select Press file to upload !!";
                FileNews.Focus();
            }
            else if (!(rdbMainAct.SelectedValue == "Y") & !(rdbMainAct.SelectedValue == "N"))
            {
                lblMainMsg.Text = "Select whether press release is active !!";
            }
            
            else
            {
                lblMainMsg.Text = "";

                int flag1 = 0;
                if (!string.IsNullOrEmpty(Path.GetFileName(FileNews.PostedFile.FileName)))
                {
                    txtTempFilenm.Text = Path.GetFileName(FileNews.PostedFile.FileName);
                    flag1 = 1;
                }
                else if (cmbWebPage.SelectedIndex != 0)
                {
                    txtTempFilenm.Text = "";
                    lblMainMsg.Text = "";
                    flag1 = flag1 + 1;
                }
                else if (!string.IsNullOrEmpty(txturl.Text.Trim()))
                {
                    txtTempFilenm.Text = txturl.Text.Trim();
                    lblMainMsg.Text = "";
                    flag1 = flag1 + 1;
                }
                else
                {
                    txturl.Text = "";
                    txtTempFilenm.Text = "";
                    lblMainMsg.Text = "";
                    flag1 = 0;
                }
                //If flag1 > 0 Then

                int cnt1 = 0;
                con.Open();
                cmd = new SqlCommand("USP_PressRelease", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@Title", txtitle.Text);
                if (btnAdd.Text == "Add")
                {
                    cmd.Parameters["@mode"].Value = "PressDuptitle1";
                }
                else if (btnAdd.Text == "Update")
                {
                    string x1 = Session["PressEdit"].ToString();
                    if (!string.IsNullOrEmpty(Session["PressEdit"].ToString()))
                    {
                        cmd.Parameters.AddWithValue("@Id", Convert.ToString(Session["PressEdit"]));
                    }
                    cmd.Parameters["@mode"].Value = "EditPressMaker2";
                }
                cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

               
                if (cnt1 == 0)
                {
                    lblMainMsg.Text = "";

                    int cnt2 = 0;
                    if (cnt2 > 0)
                    {
                        lblMainMsg.Text = "Press Release with this file name already exists !!";

                    }
                    else if (cnt2 == 0)
                    {
                        ///''''''''''''''''''''''''''  add data

                        lblMainMsg.Text = "";

                        con.Open();
                        cmd = new SqlCommand("USP_PressRelease", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
                        if (!string.IsNullOrEmpty(txtitle.Text))
                        {
                            cmd.Parameters.AddWithValue("@Title", txtitle.Text);
                        }
                        if (!string.IsNullOrEmpty(txtdesc.Text))
                        {
                            cmd.Parameters.AddWithValue("@Description", txtdesc.Text);
                        }

                        if (!string.IsNullOrEmpty(txtheading.Text))
                        {
                            cmd.Parameters.AddWithValue("@FileHeading", txtheading.Text);
                        }
                        if (!string.IsNullOrEmpty(txtnoticedate.Text))
                        {
                            cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(txtnoticedate.Text).ToString("yyyy-MM-dd"));
                        }

                        cmd.Parameters.AddWithValue("@Active", rdbMainAct.SelectedValue);
                       

                        if (btnAdd.Text == "Add")
                        {
                            if (flag1 == 1)
                            {
                                if (!string.IsNullOrEmpty(txtTempFilenm.Text))
                                {
                                    cmd.Parameters.AddWithValue("@FilePath", txtTempFilenm.Text);
                                }
                                else if (cmbWebPage.SelectedIndex != 0)
                                {
                                    cmd.Parameters.AddWithValue("@FilePath", cmbWebPage.SelectedValue);
                                }
                                else if (!string.IsNullOrEmpty(txturl.Text))
                                {
                                    cmd.Parameters.AddWithValue("@FilePath", txturl.Text);
                                }
                            }

                            cmd.Parameters.AddWithValue("@Chkr", "N");
                            cmd.Parameters["@mode"].Value = "AddPressChkr1";
                        }
                        else if (btnAdd.Text == "Update")
                        {
                            if (flag1 == 1)
                            {
                                if (!string.IsNullOrEmpty(txtTempFilenm.Text))
                                {
                                    cmd.Parameters.AddWithValue("@FilePath", txtTempFilenm.Text);
                                }
                                else if (!(cmbWebPage.SelectedIndex == 0))
                                {
                                    cmd.Parameters.AddWithValue("@FilePath", cmbWebPage.SelectedValue);
                                }
                                else if (!string.IsNullOrEmpty(txturl.Text))
                                {
                                    cmd.Parameters.AddWithValue("@FilePath", txturl.Text);
                                }
                            }
                            else if (!string.IsNullOrEmpty(lblNwsFileNm.Text))
                            {
                                cmd.Parameters.AddWithValue("@FilePath", lblNwsFileNm.Text);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@FilePath", "");
                            }

                            if (!string.IsNullOrEmpty(Session["PressEdit"].ToString()))
                            {
                                cmd.Parameters.AddWithValue("@Id", Session["PressEdit"]);
                            }
                            cmd.Parameters["@mode"].Value = "EditPressMaker1";
                        }
                        cmd.ExecuteNonQuery();
                        con.Close();

                        if (!string.IsNullOrEmpty(Path.GetFileName(FileNews.PostedFile.FileName)))
                        {
                            FileNews.PostedFile.SaveAs(Server.MapPath("..\\press") + "\\" + txtTempFilenm.Text);
                        }
                        if (btnAdd.Text == "Add")
                        {
                            clear_AddData();
                            Session["btnMainAdd"] = "Add";
                            lblMainMsg.Text = "Press added successfully !!";
                        }
                        else if (btnAdd.Text == "Update")
                        {
                            clear_AddData();
                            Session["btnMainAdd"] = "Update";
                            lblMainMsg.Text = "Press updated successfully !!";
                            btnAdd.Text = "Add";
                            lblAddMainHead.Text = "Add New Press";
                            lblmsg.Visible = false;
                        }

                        string fields1 = "";

                        if (string.IsNullOrEmpty(fields1))
                        {
                            fields1 = "Admin : Manage Press Release";
                        }

                        con.Open();
                        cmd = new SqlCommand("Proc_AuditTrail", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
                        cmd.Parameters.AddWithValue("@strLogNm", Session["log_name"]);
                        cmd.Parameters.AddWithValue("@strTblNm", "TblPressRelease");
                        cmd.Parameters.AddWithValue("@strFildNm", fields1);
                        cmd.Parameters.AddWithValue("@strPgNm", "ManagePressRelease.aspx");
                        cmd.Parameters.AddWithValue("@strModuleNm", "Manage Press Release");
                        cmd.Parameters.AddWithValue("@strAuditDt", DateTime.Now.Date);


                        if (Session["btnMainAdd"].Equals("Add"))
                        {
                            cmd.Parameters.AddWithValue("@strAddOn", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@strRemark", "Press Release is Added");
                            cmd.Parameters["@mode"].Value = "AuditOnAdd";
                            Session["btnMainAdd"] = "";
                        }
                        else if (Session["btnMainAdd"].Equals("Update"))
                        {
                            cmd.Parameters.AddWithValue("@strEditOn", DateTime.Now.Date);
                            cmd.Parameters.AddWithValue("@strRemark", "Press Releasev is Updated");
                            cmd.Parameters["@mode"].Value = "AuditOnEdit";
                            Session["btnMainAdd"] = "";
                        }
                        cmd.ExecuteNonQuery();
                        con.Close();


                        fill_grid();
                        //trsrch.Visible = true;
                        //traddnewlink.Visible = true;
                        //tr_AddNew.Visible = false;
                        //trdatagrid.Visible = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        clear_AddData();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManagePressRelease.aspx");
    }

    public void fill_grid()
    {
        try
        {
            lblerr.Text = "";
            


            int cnt1 = 0;
            con.Open();
            cmd = new SqlCommand("USP_PressRelease", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 20));
            if (!string.IsNullOrEmpty(txtSrchFileNm.Text))
            {
                cmd.Parameters.AddWithValue("@Title", txtSrchFileNm.Text.Trim());
            }

            if (!string.IsNullOrEmpty(txtDescsrch.Text))
            {
                cmd.Parameters.AddWithValue("@Description", txtDescsrch.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtFromDate.Text))
            {
                cmd.Parameters.AddWithValue("@date", txtFromDate.Text);
            }
            cmd.Parameters["@mode"].Value = "CntSrchPressadm";
            cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            if (cnt1 > 0)
            {
                con.Open();
                cmd = new SqlCommand("USP_PressRelease", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 20));

                if (!string.IsNullOrEmpty(txtSrchFileNm.Text))
                {
                    cmd.Parameters.AddWithValue("@Title", txtSrchFileNm.Text.Trim());
                }

                if (!string.IsNullOrEmpty(txtDescsrch.Text))
                {
                    cmd.Parameters.AddWithValue("@Description", txtDescsrch.Text.Trim());
                }
                if (!string.IsNullOrEmpty(txtFromDate.Text))
                {
                    cmd.Parameters.AddWithValue("@date", txtFromDate.Text);
                }
                cmd.Parameters["@mode"].Value = "GetSrchPressadm";
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds, "tbl_NewsDtls1");
                con.Close();

                if (!(ds.Tables["tbl_NewsDtls1"].Rows.Count == 0))
                {
                    lblmsg.Text = ds.Tables["tbl_NewsDtls1"].Rows.Count + " Records found !!";
                    dg_press.Visible = true;
                    try
                    {
                        dg_press.DataSource = ds.Tables["tbl_NewsDtls1"].DefaultView;
                        dg_press.DataBind();
                    }
                    catch
                    {
                        try
                        {
                            this.dg_press.CurrentPageIndex = 0;
                            this.dg_press.DataBind();
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else
                {
                    dg_press.DataSource = null;
                    dg_press.DataBind();
                    dg_press.Visible = false;
                    lblmsg.Text = "No records found";
                }
            }

            else
            {
                dg_press.DataSource = null;
                dg_press.DataBind();
                dg_press.Visible = false;
                lblmsg.Text = "No records found";
            }
        }
        catch (Exception ex)
        {
            //Response.Write(ex.Message.ToString();())
        }
        //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
     }
    public void fill_WebPg(string main_for)
    {

        try
        {
            int cnt1 = 0;
            con.Open();
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
            if (main_for == "Add")
            {
                cmd.Parameters["@mode"].Value = "cntPgChkr1";
            }
            else
            {
                cmd.Parameters["@mode"].Value = "cntPgChkr2";
            }
            cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();


            if (cnt1 > 0)
            {
                con.Open();
                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
                if (main_for == "Add")
                {
                    cmd.Parameters["@mode"].Value = "shPgChkr1";
                }
                else
                {
                    cmd.Parameters["@mode"].Value = "shPgChkr2";
                }

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds, "tbl_WbPg2");
                con.Close();


                if (!(ds.Tables["tbl_WbPg2"].Rows.Count == 0))
                {
                    cmbWebPage.Items.Clear();
                    cmbWebPage.DataSource = ds.Tables["tbl_WbPg2"];
                    cmbWebPage.DataTextField = "PageName";
                    cmbWebPage.DataValueField = "PageFileName";
                    cmbWebPage.DataBind();
                    cmbWebPage.Items.Insert(0, "Select Page");
                    cmbWebPage.SelectedIndex = 0;

                }
                else
                {
                    cmbWebPage.Items.Clear();
                    cmbWebPage.Items.Insert(0, "Select Page");
                    cmbWebPage.SelectedIndex = 0;

                }
            }
            else
            {
                cmbWebPage.Items.Clear();
                cmbWebPage.Items.Insert(0, "Select Page");
                cmbWebPage.SelectedIndex = 0;

            }

        }
        catch (Exception ex)
        {

        }
    }

    public bool chkNwsDesc(string data1)
    {

        string allowed1 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-/.(),%&!#@%: ";
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
    private void fill_WebPg()
    {
        throw new NotImplementedException();
    }
    public bool chk_NewsLink()
    {

        if (string.IsNullOrEmpty(Path.GetFileName(FileNews.PostedFile.FileName)))//& cmbWebPage.SelectedIndex == 0)
        {
            lblMainMsg.Text = "";
            return true;
        }
        else
        {
            if (!string.IsNullOrEmpty(Path.GetFileName(FileNews.PostedFile.FileName)))
            {
                        
             if (!Path.GetFileName(FileNews.PostedFile.FileName).Contains(".doc") & !Path.GetFileName(FileNews.PostedFile.FileName).Contains(".pdf") & !Path.GetFileName(FileNews.PostedFile.FileName).Contains(".png") & !Path.GetFileName(FileNews.PostedFile.FileName).Contains(".xls") & !Path.GetFileName(FileNews.PostedFile.FileName).Contains(".zip") & !Path.GetFileName(FileNews.PostedFile.FileName).Contains(".ZIP") & !Path.GetFileName(FileNews.PostedFile.FileName).Contains(".rar") & !Path.GetFileName(FileNews.PostedFile.FileName).Contains(".jpg") & !Path.GetFileName(FileNews.PostedFile.FileName).Contains(".jpeg") & !Path.GetFileName(FileNews.PostedFile.FileName).Contains(".docx"))
                {
                    lblMainMsg.Text = "Only word, pdf, excel, zip , jpg and png documents are allowed to upload";
                    return false;
                }
               
                else
                {
                    lblMainMsg.Text = "";
                    return true;
                }
            }
           
            else
            {
                return true;
            }
        }
    }
    public bool checkRealFile(FileUpload passfile)
    {
        if (passfile.HasFile)
        {
            if (passfile.PostedFile.ContentType == "application/pdf" || passfile.PostedFile.ContentType == "application/msword" || passfile.PostedFile.ContentType == "image/jpeg" || passfile.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document" || passfile.PostedFile.ContentType == "application/zip" || passfile.PostedFile.ContentType == "image/png" || passfile.PostedFile.ContentType == "application/vnd.ms-excel" || passfile.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" || passfile.PostedFile.ContentType == "application/x-zip-compressed")
            {
                bool exists = System.IO.Directory.Exists(Server.MapPath("..\\press"));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("..\\press"));
                }

                passfile.PostedFile.SaveAs(Server.MapPath("..\\press") + "\\" + passfile.FileName);
                if (HasMzSignature(Server.MapPath("..\\press\\" + passfile.FileName)))
                {
                    FileInfo fd = new FileInfo(Server.MapPath("..\\press\\" + passfile.FileName));
                    fd.Delete();
                    return false;
                }
                else
                {
                    FileInfo fd = new FileInfo(Server.MapPath("..\\press\\" + passfile.FileName));
                    fd.Delete();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
        System.GC.Collect();
    }
    public static bool HasMzSignature(string fileName)
    {
        try
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
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

    public void clear_AddData()
    {
        Session["PressEdit"] = "";
        txtitle.Text = "";
        txtdesc.Text = "";
        txtheading.Text = "";
        txtnoticedate.Text = "";
        txtTempFilenm.Text = "";

        //rdbMainAct.SelectedIndex = 0;
        lblMainMsg.Text = "";
        tr_NwsLnk.Visible = false;
        lblNwsFileNm.Text = "";
        lnkRemove.Text = "";
        lnkRemove.Enabled = false;
        txturl.Text = "";
        cmbWebPage.SelectedIndex = 0;
        btnAdd.Text = "Add";
        btnReset.Text = "Reset";
        //lblAddMainHead.Text = "Add Press Release";
        lblmsg.Visible = false;
        lblerr.Text = "";

    }
    protected void lnkRemove_Click1(object sender, EventArgs e)
    {
        txtTempFilenm.Text = "";
        lblNwsFileNm.Text = "";
        lnkRemove.Text = "";
        lnkRemove.Enabled = false;
        tr_NwsLnk.Visible = false;
        
    }
    protected void dg_press_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.SelectedItem | e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.EditItem)
        {
            string title = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Title")) == false)
            {
                title = DataBinder.Eval(e.Item.DataItem, "Title").ToString();
            }
            else
            {
                title = "";
            }

            string description = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Description")) == false)
            {
                description = DataBinder.Eval(e.Item.DataItem, "Description").ToString();
                e.Item.Cells[8].Text = description;
            }
            else
            {
                description = "";
                e.Item.Cells[8].Text = description;
            }

            if (!string.IsNullOrEmpty(description))
            {
                e.Item.Cells[2].Text = title + "<br>" + "[ " + description + " ]";
            }
            else
            {
                e.Item.Cells[2].Text = title;
            }
            string FileHeading = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "FileHeading")) == false)
            {
                FileHeading = DataBinder.Eval(e.Item.DataItem, "FileHeading").ToString();
                e.Item.Cells[3].Text = FileHeading;
            }
            else
            {
                FileHeading = "";
                e.Item.Cells[3].Text = FileHeading;
            }
            string FilePath = "";
            LinkButton Newsbtn = (LinkButton)e.Item.FindControl("lnkPressFile");
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "FileName")) == false)
            {
                FilePath = DataBinder.Eval(e.Item.DataItem, "FileName").ToString();
                e.Item.Cells[10].Text = FilePath;
                ((LinkButton)e.Item.Cells[4].FindControl("lnkPressFile")).Text = FilePath;
                if (FilePath.Contains(".doc") | FilePath.Contains(".pdf") | FilePath.Contains(".zip") | FilePath.Contains(".xlsx") | FilePath.Contains(".docx") | FilePath.Contains(".rar") | FilePath.Contains(".xls") | FilePath.Contains(".jpg") | FilePath.Contains(".png"))
                {
                    ((LinkButton)e.Item.Cells[4].FindControl("lnkPressFile")).Enabled = true;
                    ((LinkButton)e.Item.Cells[4].FindControl("lnkPressFile")).ForeColor = System.Drawing.Color.Blue;
                }
                else if (FilePath.Contains(".aspx"))
                {
                    string filepath = "../" + FilePath;
                    Newsbtn.Attributes.Add("href", filepath);
                    Newsbtn.Attributes.Add("target", "_blank");
                }


                else
                {
                    ((LinkButton)e.Item.Cells[4].FindControl("lnkPressFile")).Enabled = true;
                    ((LinkButton)e.Item.Cells[4].FindControl("lnkPressFile")).ForeColor = System.Drawing.Color.Blue;
                }
            }
            else
            {
                FilePath = "";
                e.Item.Cells[12].Text = FilePath;
                ((LinkButton)e.Item.Cells[4].FindControl("lnkPressFile")).Text = FilePath;
                ((LinkButton)e.Item.Cells[4].FindControl("lnkPressFile")).Enabled = false;
                ((LinkButton)e.Item.Cells[4].FindControl("lnkPressFile")).ForeColor = System.Drawing.Color.Black;
            }

            string date_news = "";
            System.DateTime date_news1 = default(System.DateTime);
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "NoticeDate")) == false)
            {
                date_news1 = (DateTime)DataBinder.Eval(e.Item.DataItem, "NoticeDate");
                date_news = date_news1.ToString("yyyy-MM-dd");
                e.Item.Cells[5].Text = date_news;
            }
            else
            {
                date_news = "";
                e.Item.Cells[5].Text = date_news;
            }

            string active1 = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Active")) == false)
            {
                active1 = DataBinder.Eval(e.Item.DataItem, "Active").ToString();
                active1 = active1.Trim();
            }
            else
            {
                active1 = "N";
            }

            if (active1 == "Y")
            {
                e.Item.ForeColor = System.Drawing.Color.Black;
                ((LinkButton)e.Item.Cells[6].FindControl("lnkPressEdit")).Enabled = true;
                ((LinkButton)e.Item.Cells[6].FindControl("lnkPressEdit")).ForeColor = System.Drawing.Color.Blue;
                ((LinkButton)e.Item.Cells[6].FindControl("lnkPressDelete")).Enabled = true;
                ((LinkButton)e.Item.Cells[6].FindControl("lnkPressDelete")).ForeColor = System.Drawing.Color.Blue;
                ((LinkButton)e.Item.Cells[6].FindControl("lnkPressDelete")).Attributes.Add("onclick", "javascript: return confirm('Are you sure you want to delete this Press Release ?')");
            }
            else
            {
                e.Item.ForeColor = System.Drawing.Color.Gray;
                ((LinkButton)e.Item.Cells[6].FindControl("lnkPressEdit")).Enabled = true;
                ((LinkButton)e.Item.Cells[6].FindControl("lnkPressEdit")).ForeColor = System.Drawing.Color.Blue;
                ((LinkButton)e.Item.Cells[6].FindControl("lnkPressDelete")).Enabled = false;
            }

            string nws_Chkr = "";
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Checked")) == false)
            {
                nws_Chkr = DataBinder.Eval(e.Item.DataItem, "Checked").ToString();
            }
            else
            {
                nws_Chkr = "N";
            }
            if (nws_Chkr == "N")
            {
                if (Session["usr_privilege"] != "Maker" || Session["usr_privilege"] == "admin")
                {
                    ((LinkButton)e.Item.Cells[6].FindControl("lnkPressCheck")).Enabled = true;
                    ((LinkButton)e.Item.Cells[6].FindControl("lnkPressCheck")).ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    ((LinkButton)e.Item.Cells[6].FindControl("lnkPressCheck")).Enabled = false;
                    ((LinkButton)e.Item.Cells[6].FindControl("lnkPressCheck")).ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                ((LinkButton)e.Item.Cells[6].FindControl("lnkPressCheck")).Enabled = false;
                ((LinkButton)e.Item.Cells[6].FindControl("lnkPressCheck")).ForeColor = System.Drawing.Color.Green;
                ((LinkButton)e.Item.Cells[6].FindControl("lnkPressCheck")).Text = "Checked";
            }
        }
    }
    protected void dg_press_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (!(e.CommandName == "Page"))
        {
            string Press_id = e.Item.Cells[0].Text;
            string Press_title = e.Item.Cells[7].Text;
            string Press_desc = e.Item.Cells[8].Text;
            string FileHeading = e.Item.Cells[9].Text;
            string Press_File = e.Item.Cells[10].Text;
            string Press_date = Convert.ToDateTime(e.Item.Cells[11].Text).ToString("yyyy-MM-dd");
            string Active1 = e.Item.Cells[12].Text;
           

            LinkButton Newsbtn = (LinkButton)e.Item.FindControl("lnkPressFile");

            Session["PressEdit"] = "";
           // clear_AddData();

            if (e.CommandName == "PressFile")
            {
               
                string Nws_path;

                Nws_path = Server.MapPath("../press/" + Press_File);
               
                
                WebClient client = new WebClient();
               

                Byte[] buffer = client.DownloadData(Nws_path);

                string mimetype = null;
                string extension = Path.GetExtension(Press_File);
                switch (extension)
                {
                    case ".doc":
                    case ".docx":
                        mimetype = "application/msword";
                        break; // TODO: might not be correct. Was : Exit Select

                    case ".txt":
                        mimetype = "text/plain";
                        break; // TODO: might not be correct. Was : Exit Select

                    case ".pdf":
                        mimetype = "application/pdf";
                        break; // TODO: might not be correct. Was : Exit Select

                    default:
                        mimetype = "application/octet-stream";
                        break; // TODO: might not be correct. Was : Exit Select
                }

                if (buffer != null)
                {
                    Response.ContentType = mimetype;

                    Response.AddHeader("content-length", buffer.Length.ToString());

                    Response.WriteFile(Nws_path);
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + Press_File);
                    Response.WriteFile(Nws_path);
                }

            }
            else if (e.CommandName == "PressReleaseEdit")
            {
                clear_AddData();
                //fill_WebPg("Edit");
                tr_AddNew.Visible = true;
               lblAddMainHead.Text = "Edit Press Release";
                btnAdd.Text = "Update";

                Session["PressEdit"] = Press_id;
                txtitle.Text = Press_title;
                txtdesc.Text = Press_desc;
                txtheading.Text = FileHeading;
                txtnoticedate.Text = Press_date;
               
                //lblmsg.Text = "";
                traddnewlink.Visible = false;
                
                trdatagrid.Visible = false;
                tbl_NewsLtrRegist.Visible = false;

                if (string.IsNullOrEmpty(Press_File))
                {

                    tr_NwsLnk.Visible = false;
                    lblNwsFileNm.Text = "";
                    lnkRemove.Text = "";
                    lnkRemove.Enabled = false;
                }
                else if (Press_File.Contains(".aspx"))
                {
                    con.Open();
                    cmd = new SqlCommand("USP_PressRelease", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
                    cmd.Parameters.AddWithValue("@FilePath", Press_File);
                    cmd.Parameters["@mode"].Value = "testcntpg";
                    int cnt = Convert.ToInt32(cmd.ExecuteScalar());

                    con.Close();

                    txtTempFilenm.Text = "";
                    if (cnt > 0)
                    {
                        cmbWebPage.SelectedValue = Press_File;
                        //txturl.Text = Press_File;
                    }
                    else
                    {
                        cmbWebPage.SelectedIndex = 0;
                        //txturl.Text = "";
                    }
                }
                else
                {
                    txtTempFilenm.Text = Press_File;

                    tr_AddNew.Visible = true;
                    tr_NwsLnk.Visible = true;
                    lblNwsFileNm.Text = Press_File;
                    lnkRemove.Text = "Remove";
                    lnkRemove.Enabled = true;
                    txturl.Text = "";
                }
                rdbMainAct.SelectedValue = Active1;
            }
            else if (e.CommandName == "PressDelete")
            {
                con.Open();
                cmd = new SqlCommand("USP_PressRelease", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@Id", Press_id);
                cmd.Parameters["@mode"].Value = "DelPressChkrById2";
                cmd.ExecuteNonQuery();
                con.Close();
               

                string fields1 = "";

                if (string.IsNullOrEmpty(fields1))
                {
                    fields1 = "Admin : Manage Press Release";
                }

                con.Open();
                cmd = new SqlCommand("Proc_AuditTrail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strLogNm", Session["log_name"]);
                cmd.Parameters.AddWithValue("@strTblNm", "TblPressRelease");
                cmd.Parameters.AddWithValue("@strFildNm", fields1);
                cmd.Parameters.AddWithValue("@strPgNm", "ManagePressRelease.aspx");
                cmd.Parameters.AddWithValue("@strModuleNm", "Manage Press Release");
                cmd.Parameters.AddWithValue("@strAuditDt", DateTime.Now.Date);

                cmd.Parameters.AddWithValue("@strDelOn", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@strRemark", "Press Release is Deleted");
                cmd.Parameters["@mode"].Value = "AuditOnDelete";

                cmd.ExecuteNonQuery();
                con.Close();

                fill_grid();
                lnkAddNew.Visible = true;
            }

            else if (e.CommandName == "PressChecked")
            {
                con.Open();

                cmd = new SqlCommand("USP_PressRelease", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@Id", Press_id);
                cmd.Parameters["@mode"].Value = "UpdateChkrPress";
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("USP_PressRelease", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@Id", Press_id);
                cmd.Parameters["@mode"].Value = "delChkrPress";
                cmd.ExecuteNonQuery();



                cmd = new SqlCommand("USP_PressRelease", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@Id", Press_id);
                cmd.Parameters["@mode"].Value = "InsertChkrPress";
                cmd.ExecuteNonQuery();
                con.Close();

                string fields1 = "";

                if (string.IsNullOrEmpty(fields1))
                {
                    fields1 = "Admin : Manage Press Release";
                }

                con.Open();
                cmd = new SqlCommand("Proc_AuditTrail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strLogNm", Session["log_name"]);
                cmd.Parameters.AddWithValue("@strTblNm", "tbl_News");
                cmd.Parameters.AddWithValue("@strFildNm", fields1);
                cmd.Parameters.AddWithValue("@strPgNm", "ManagePressRelease.aspx");
                cmd.Parameters.AddWithValue("@strModuleNm", "Manage Press Release");
                cmd.Parameters.AddWithValue("@strAuditDt", DateTime.Now.Date);

                cmd.Parameters.AddWithValue("@strEditOn", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@strRemark", "Press Release is Checked");
                cmd.Parameters["@mode"].Value = "AuditOnEdit";

                cmd.ExecuteNonQuery();
                con.Close();

                Session["PressEdit"] = "";
                fill_grid();
            }
        }
    }
    protected void dg_press_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        dg_press.CurrentPageIndex = e.NewPageIndex;
        fill_grid();
    }
    protected void btnSrch_Click(object sender, EventArgs e)
    {
        try
        {
            if (chkdata() == true)
            {

                lblmsg.Visible = true;
                fill_grid();
                traddnewlink.Visible = false;
            }
            else
            {

                lblSrchErr.Text = lblSrchErr.Text;
            }
        }
        catch (Exception exc)
        {
            Response.Write(exc);
        }
        finally
        {
            con.Close();
        }
    }
    

    public bool chkdata()
    {
        if (string.IsNullOrEmpty(txtSrchFileNm.Text.Trim()) && string.IsNullOrEmpty(txtDescsrch.Text.Trim()) && txtFromDate.Text.Trim() == "")
        {
            lblSrchErr.Text = "Please enter any one field !!";
            txtSrchFileNm.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtSrchFileNm.Text.Trim()) && !Regex.IsMatch(txtSrchFileNm.Text, "^[a-z.A-Z 0-9-(),/#&! ]+$"))
        {
            lblSrchErr.Text = "Please enter valid title !!";
            txtSrchFileNm.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtSrchFileNm.Text.Trim()) && txtSrchFileNm.Text.Length < 2)
        {
            lblSrchErr.Text = "Title , should be greater than the 2 charactors !!";
            txtSrchFileNm.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtSrchFileNm.Text.Trim()) && txtSrchFileNm.Text.Length > 100)
        {
            lblSrchErr.Text = "Title , should be lesser than the 100 charactors !!";
            txtSrchFileNm.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtDescsrch.Text.Trim()) && chkrateDesc(txtDescsrch.Text.Trim()) == false)
        
        {
            lblSrchErr.Text = "Please enter valid Description !!";
            txtDescsrch.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtDescsrch.Text.Trim()) && txtDescsrch.Text.Length < 2)
        {
            lblSrchErr.Text = "Description , should be greater than the 2 charactors !!";
            txtDescsrch.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtDescsrch.Text.Trim()) && txtDescsrch.Text.Length > 500)
        {
            lblSrchErr.Text = "Description , should be lesser than the 500 charactors !!";
            txtDescsrch.Focus();
            return false;
        }
       
        

        
        else
        {
            lblSrchErr.Text = "";
            return true;
        }
    }
   
    protected void reset_Click(object sender, EventArgs e)
    {
        txtSrchFileNm.Text = "";
        txtDescsrch.Text = "";
        fill_grid();
        dg_press.Visible = true;
        txtFromDate.Text = "";
        traddnewlink.Visible = true;
        lblSrchErr.Text = "";

    }

    protected void lnkAddNew_Click1(object sender, EventArgs e)
    {
        tr_AddNew.Visible = true;
        traddnewlink.Visible = false;
        trsrch.Visible = false;
        trdatagrid.Visible = false;
        lblmsg.Text = "";
        tr_NwsLnk.Visible = false;
       
    }

    public bool chkrateDesc(string data1)
    {

        string allowed1 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-/.(),%&!#@%:$’“”' ";
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

    public bool checkWbPgs1(string MainId1, string MainNm1)
    {
        try
        {
            int cnt1 = 0;
            con.Open();
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@strPgFileNm", MainId1);
            cmd.Parameters.AddWithValue("@strPageNm", MainNm1);
            cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
            cmd.Parameters["@mode"].Value = "ChkEngPgMkr2";
            cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            if (cnt1 > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        catch (Exception ex)
        {
            return false;
        }
    }
    public bool chkURL(string data1)
    {

        string allowed1 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-_*#/.:%& ";
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
}