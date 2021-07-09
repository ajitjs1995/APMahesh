using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class InnerPageBannercntrl : System.Web.UI.UserControl
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["TMBCON"]);
    SqlCommand cmd = new SqlCommand();

    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        //  innerbanner.Text = "<img src='../InnerBanner/Default.jpg' alt='banner' title='lv bank' class='img-responsive'>";
        string x1 = "";
        x1 = Request.Path;
        int pgid = GetPageID(Request.Path);

        fillbanner(pgid);
    }

    private void fillbanner(int nPageID)
    {
        string[] strPage = null;
        string sPageName = null;
string imageUrl ="";
		string alternateText = "";
        char[] splitchar = { '/' };
        string strPagename = Request.Path;
        //strPage = Strings.Split(strPagename, "/");
        strPage = strPagename.Split(splitchar);
        sPageName = strPage[strPage.Length - 1];
        string lang = null;
        if (sPageName.Contains("Hindi") | sPageName.Contains("hindi"))
        {
            lang = "Hindi";
        }
        else if (sPageName.Contains("Tamil") | sPageName.Contains("tamil"))
        {
            lang = "Tamil";
        }
        else
        {
            lang = "English";
        }



        cmd = new SqlCommand("Proc_ManageBanner", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
        cmd.Parameters.AddWithValue("@strPageId", nPageID);
        if (lang == "Hindi")
        {
            cmd.Parameters["@Mode"].Value = "GetMenuDataHnd";
        }
        else if (lang == "Tamil")
        {
            cmd.Parameters["@Mode"].Value = "GetMenuDataMar";
        }
        else
        {
            cmd.Parameters["@Mode"].Value = "GetMenuData";
        }
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0] != null)
        {
            if (!(ds.Tables[0].Rows.Count == 0))
            {
                string bnname = ds.Tables[0].Rows[0]["BannerName"].ToString();
                alternateText = ds.Tables[0].Rows[0]["AltText"].ToString();
                 imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])ds.Tables[0].Rows[0]["Data"]);
                innerbanner.Text = "<img src='"+imageUrl+"' alt='" + alternateText + "' class='img-responsive' >";
                //innerbanner.ImageUrl = imageUrl;
            }
            else
            {
                //innerbanner.ImageUrl = imageUrl;
				innerbanner.Text = "<img src='"+imageUrl+"' alt='" + alternateText + "' class='img-responsive' >";
            }
        }
        else
        {
            //innerbanner.ImageUrl = imageUrl;
			innerbanner.Text = "<img src='"+imageUrl+"' alt='" + alternateText + "' class='img-responsive' >";
        }


    }
    public int GetPageID(string strPagename)
    {
        int nPageID = 0;
        try
        {
            string[] strPage = null;
            string sPageName = null;

            strPage = strPagename.Split('/');
            sPageName = strPage[strPage.Length - 1];
            Session["spagemenu"] = sPageName;
            ///''''''''''''''''''''''''''''''' check whether page in page master 
            int cnt1 = 0;
            string pgnm = sPageName;
            string PgLang = "English";
            //cnt1 = ui.CntPageIDChkr(cms);
            con.Open();
            cmd = new SqlCommand("Proc_ManageBanner", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters.AddWithValue("@strPgFileNm", pgnm);
            if (pgnm.Contains("Hindi") | pgnm.Contains("hindi"))
            {
                cmd.Parameters["@Mode"].Value = "CntPgHndIDChkr";
            }
            else if (pgnm.Contains("Tamil") | pgnm.Contains("tamil"))
            {
                cmd.Parameters["@Mode"].Value = "CntPgMarIDChkr";
            }
            else
            {
                cmd.Parameters["@Mode"].Value = "CntPageIDChkr";
            }
            cnt1 = (int)cmd.ExecuteScalar();
            con.Close();

            if (cnt1 > 0)
            {
                // nPageID = ui.GetPageIDChkr(cms);

                con.Open();
                cmd = new SqlCommand("Proc_ManageBanner", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@strPgFileNm", pgnm);
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                if (pgnm.Contains("Hindi") | pgnm.Contains("hindi"))
                {
                    cmd.Parameters["@Mode"].Value = "GetHndPgIDChkr";
                }
                else if (pgnm.Contains("Tamil") | pgnm.Contains("tamil"))
                {
                    cmd.Parameters["@Mode"].Value = "GetMarPgIDChkr";
                }
                else
                {
                    cmd.Parameters["@Mode"].Value = "GetPageIDChkr";
                }

                if (Convert.IsDBNull(cmd.ExecuteScalar()) == false)
                {
                    nPageID = (int)cmd.ExecuteScalar();
                }
                else
                {
                    nPageID = 0;
                }

                con.Close();
            }
            else
            {
                nPageID = 0;
            }

            return nPageID;


        }
        catch (Exception ex)
        {
            string ma1 = "";
            ma1 = ex.ToString();
        }
        return nPageID;
    }
}