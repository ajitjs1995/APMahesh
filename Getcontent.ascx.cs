using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Microsoft.VisualBasic;

public partial class Getcontent : System.Web.UI.UserControl
{
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["TMBCON"]);
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    string Pagename = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        GetPageID(Request.Path);
        string strPagename = Request.Path;
        Session["Site_name"] = "Tamilnad Mercantile Bank";
        string[] strPage = null;
        string sPageName = null;
        int nPageID = 0;
        char[] splitchar = { '/' };

        strPage = strPagename.Split(splitchar);
        sPageName = strPage[strPage.Length - 1];
        string language = strPage[strPage.Length - 2];
        char[] splitchar1 = { '.' };
        string[] strPage1 = null;
        strPage1 = sPageName.Split(splitchar1);
        Page.Title = strPage1[strPage1.Length - 2] + " | " + Session["Site_name"];
        string pgname1 = strPage1[strPage1.Length - 2];

        cmd = new SqlCommand("Proc_ManageCmsPages", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 50);
        cmd.Parameters.AddWithValue("@strPageNm", pgname1);
        if (language.Contains("Hindi") || pgname1.Contains("hindi"))
        {
            cmd.Parameters["@Mode"].Value = "gettitle1";
        }
        else if (language.Contains("tamil") || pgname1.Contains("tamil"))
        {
            cmd.Parameters["@Mode"].Value = "gettitle2";
        }
        else
        {
            cmd.Parameters["@Mode"].Value = "gettitle";
        }
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (pgname1.Contains("msme-loan"))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                Page.Title = ds.Tables[0].Rows[0]["PageTitle"].ToString();
            }
            else
            {
                Page.Title = strPage1[strPage1.Length - 2] + " | " + Session["Site_name"];
            }
        }
        else
        {
            if (ds.Tables["Table"] != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Page.Title = ds.Tables[0].Rows[0]["PageTitle"].ToString() + " | " + Session["Site_name"];
                }
                else
                {
                    Page.Title = strPage1[strPage1.Length - 2] + " | " + Session["Site_name"];
                }
            }
            else
            {
                Page.Title = strPage1[strPage1.Length - 2] + " | " + Session["Site_name"];
            }
        }
    }
    public void GetPageID(string strPagename)
    {
        try
        {
            string st = "";
            string[] strPage = null;
            string sPageName = null;
            int nPageID = 0;
            char[] splitchar = { '/' };

            strPage = strPagename.Split(splitchar);
            sPageName = strPage[strPage.Length - 1];

            ///''''''''''''''''''''''''''''''' check whether page in page master

            int cnt1 = 0;

            string pglang = "";
            if (sPageName.Contains("Hindi") | sPageName.Contains("hindi"))
            {
                pglang = "Hindi";
            }
            else if (sPageName.Contains("tamil") | sPageName.Contains("tamil"))
            {
                pglang = "tamil";
            }
            else
            {
                pglang = "English";
            }
            Pagename = sPageName;

            string pgnm = Pagename;
            con.Open();
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strPgFileNm", pgnm);
            if (pgnm.Contains("Hindi") | pgnm.Contains("hindi"))
            {
                cmd.Parameters["@Mode"].Value = "CntPgHndIDChkr";
            }
            else if (pgnm.Contains("tamil") | pgnm.Contains("tamil"))
            {
                cmd.Parameters["@Mode"].Value = "CntPgTamIDChkr";
            }
            else
            {
                cmd.Parameters["@Mode"].Value = "CntPageIDChkr";
            }
            cnt1 = (int)cmd.ExecuteScalar();
            con.Close();

            if (cnt1 > 0)
            {
                ///'''''''''''''''''''''''''''''  get the content of the CMS page
                string MkrPgAct1 = "";
                Pagename = sPageName;

                con.Open();
                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                cmd.Parameters.AddWithValue("@strPgFileNm", pgnm);
                if (pgnm.Contains("Hindi") | pgnm.Contains("hindi"))
                {
                    cmd.Parameters["@Mode"].Value = "GetHndPgActChkr1";
                }
                else if (pgnm.Contains("tamil") | pgnm.Contains("Tamil"))
                {
                    cmd.Parameters["@Mode"].Value = "GetTamPgActChkr1";
                    st = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    cmd.Parameters["@Mode"].Value = "GetPgActChkr1";
                }
                if (Convert.IsDBNull(cmd.ExecuteScalar()) == false)
                {
                    MkrPgAct1 = cmd.ExecuteScalar().ToString();
                    //  MkrPgAct1 = st;
                }
                else
                {
                    MkrPgAct1 = "N";
                }
                con.Close();


                if (MkrPgAct1 == "N")
                {
                    Response.Redirect("InvalidPage.htm");
                }
                else
                {
                    Pagename = sPageName;

                    con.Open();
                    cmd = new SqlCommand("Proc_ManageCmsPages", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@strPgFileNm", pgnm);
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 50));
                    if (pgnm.Contains("Hindi") | pgnm.Contains("hindi"))
                    {
                        cmd.Parameters["@Mode"].Value = "GetHndPgIDChkr";
                    }
                    else if (pgnm.Contains("tamil") | pgnm.Contains("tamil"))
                    {
                        cmd.Parameters["@Mode"].Value = "GetTamPgIDChkr";
                    }
                    else
                    {
                        cmd.Parameters["@Mode"].Value = "GetPageIDChkr";
                    }

                    if (Convert.IsDBNull(cmd.ExecuteScalar()) == false)
                    {
                        nPageID = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    else
                    {
                        nPageID = 0;
                    }

                    con.Close();

                    if (nPageID == 0)
                    {
                        Response.Redirect("InvalidPage.htm");
                    }
                    else
                    {
                        if (sPageName.Contains("Hindi") | sPageName.Contains("hindi"))
                        {
                            FillMainContents(nPageID, "Hindi");
                        }
                        else if (pgnm.Contains("tamil") | pgnm.Contains("tamil"))
                        {
                            FillMainContents(nPageID, "tamil");
                        }
                        else
                        {
                            FillMainContents(nPageID, "English");
                        }
                    }
                }
            }
            else if (cnt1 == 0)
            {
                ///''''''''''''''''''''''''''''''' check whether page in main parent master
                int cnt2 = 0;

                con.Open();

                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@strPgFileNm", pgnm);
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                if (pgnm.Contains("Hindi") | pgnm.Contains("hindi"))
                {
                    cmd.Parameters["@Mode"].Value = "cntMainParentIdHnd";
                }
                else if (pgnm.Contains("tamil") | pgnm.Contains("tamil"))
                {
                    cmd.Parameters["@Mode"].Value = "cntMainParentIdTam";
                }
                else
                {
                    cmd.Parameters["@Mode"].Value = "cntMainParentId";
                }
                cnt2 = (int)cmd.ExecuteScalar();
                con.Close();

                if (cnt2 > 0)
                {
                    Response.Redirect(sPageName);
                }
                else if (cnt2 == 0)
                {
                    ///''''''''''''''''''''''''''''''' check whether page in main page master
                    int cnt3 = 0;
                    Pagename = strPagename;

                    con.Open();

                    cmd = new SqlCommand("Proc_ManageCmsPages", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@strPgFileNm", Pagename);
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd.Parameters["@Mode"].Value = "cntMainPgId";
                    cnt3 = (int)cmd.ExecuteScalar();
                    con.Close();

                    if (cnt3 > 0)
                    {
                        Response.Redirect(sPageName);
                    }
                    else if (cnt3 == 0)
                    {
                        Response.Redirect("InvalidPage.htm");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
        finally
        {
            con.Close();
        }
    }
    public void FillMainContents(int nPageID, string PgLanguage)
    {
        try
        {
            int cnt1 = 0;
            string GetPgID = nPageID.ToString();
            string PgLang = PgLanguage;

            con.Open();
            string pglang = PgLang;
            cmd = new SqlCommand("Proc_ManageCmsPages", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strPageId", GetPgID);
            if (pglang == "Hindi")
            {
                cmd.Parameters["@Mode"].Value = "CntPgHndContChkr";
            }
            else if (pglang == "tamil")
            {
                cmd.Parameters["@Mode"].Value = "CntPgTamContChkr";
            }
            else
            {
                cmd.Parameters["@Mode"].Value = "CntPgContChkr";
            }
            cnt1 = (int)cmd.ExecuteScalar();
            con.Close();

            if (cnt1 > 0)
            {
                string MkrPgAct1 = "";

                GetPgID = nPageID.ToString();

                string pgnm = Pagename;

                con.Open();
                cmd = new SqlCommand("Proc_ManageCmsPages", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strPgFileNm", pgnm);
                if (pgnm.Contains("Hindi") | pgnm.Contains("hindi"))
                {
                    cmd.Parameters["@Mode"].Value = "GetHndPgActChkr1";
                }
                else if (pglang == "tamil")
                {
                    cmd.Parameters["@Mode"].Value = "GetTamPgActChkr1";
                }
                else
                {
                    cmd.Parameters["@Mode"].Value = "GetPgActChkr1";
                }
                if (Convert.IsDBNull(cmd.ExecuteScalar()) == false)
                {
                    MkrPgAct1 = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    MkrPgAct1 = "N";
                }
                con.Close();

                if (MkrPgAct1 == "N")
                {
                    Response.Redirect("InvalidPage.htm");
                }
                else
                {
                    ds = new DataSet();
                    GetPgID = nPageID.ToString();
                    PgLang = PgLanguage;
                    con.Open();
                    cmd = new SqlCommand("Proc_ManageCmsPages", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd.Parameters.AddWithValue("@strPageId", GetPgID);
                    if (pglang == "English")
                    {
                        cmd.Parameters["@Mode"].Value = "GetPgContChkr";
                    }
                    else if (pglang == "tamil")
                    {
                        cmd.Parameters["@Mode"].Value = "GetTamPgContChkr";
                    }
                    else if (pglang == "Hindi")
                    {
                        cmd.Parameters["@Mode"].Value = "GetHndPgContChkr";
                    }
                    da = new SqlDataAdapter();
                    da.SelectCommand = cmd;

                    da.Fill(ds, "tbl_PgContent");
                    string contentt;
                    string contentt1;
                    string contentt2;
                    if (!(ds.Tables["tbl_PgContent"].Rows.Count == 0))
                    {
                        if (!(ds.Tables["tbl_PgContent"].Rows.Count == 0))
                        {
                            if (Convert.IsDBNull(ds.Tables["tbl_PgContent"].Rows[0]["ContDescription2"]) == false)
                            {
                                contentt2 = ds.Tables["tbl_PgContent"].Rows[0]["ContDescription2"].ToString();
                            }
                            else
                            {
                                contentt2 = "";
                            }

                            if (Convert.IsDBNull(ds.Tables["tbl_PgContent"].Rows[0]["ContDescription1"]) == false)
                            {
                                contentt1 = ds.Tables["tbl_PgContent"].Rows[0]["ContDescription1"].ToString();
                            }
                            else
                            {
                                contentt1 = "";
                            }
                            if (Convert.IsDBNull(ds.Tables["tbl_PgContent"].Rows[0]["ContDescription"]) == false)
                            {
                                contentt = ds.Tables["tbl_PgContent"].Rows[0]["ContDescription"].ToString();
                            }
                            else
                            {
                                contentt = "";
                            }

                            if (Convert.IsDBNull(ds.Tables["tbl_PgContent"].Rows[0]["ContID"]) == false)
                            {
                                Session["ContId1"] = ds.Tables["tbl_PgContent"].Rows[0]["ContID"].ToString();
                            }
                            else
                            {
                                Session["ContId1"] = "";
                            }
                            if (!(contentt == ""))
                            {
                                if (!(contentt == ""))
                                {
                                    lblContent.Text = contentt;
                                }
                                else if (!(contentt2 == ""))
                                {
                                    lblContent.Text = contentt2;
                                }
                                else if (!(contentt1 == ""))
                                {
                                    lblContent.Text = contentt1;
                                }
                            }
                        }
                    }
                    else
                    {
                        da = new SqlDataAdapter();
                        GetPgID = nPageID.ToString();
                        con.Open();
                        cmd = new SqlCommand("Proc_ManageCmsPages", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                        cmd.Parameters.AddWithValue("@strPageId", GetPgID);
                        cmd.Parameters["@Mode"].Value = "GetDefaultCont1";
                        da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        con.Close();

                        ds = new DataSet();
                        da.Fill(ds, "tbl_PgConts1");

                        if (!(ds.Tables["tbl_PgConts1"].Rows.Count == 0))
                        {
                            if (Information.IsDBNull(ds.Tables["tbl_PgConts1"].Rows[0]["ContDescription"]) == false)
                            {
                                lblContent.Text = ds.Tables["tbl_PgConts1"].Rows[0]["ContDescription"].ToString();
                            }
                            else
                            {
                                lblContent.Text = "";
                            }
                        }
                        else
                        {
                            lblContent.Text = "";
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("InvalidPage.htm");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
}