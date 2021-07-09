using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tmbadm_dmMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblDate.Text = DateTime.Now.Date.ToString("dddd") + ", " + DateTime.Now.Date.ToString("dd MMM yyyy") + " " + DateTime.Now.ToString("hh:mm:ss") + " " + DateTime.Now.ToString("tt");
        lblUsr.Text = "Current Administrator : " + Session["log_name"];
    }
    protected void lnkChngPwd_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChangePassword.aspx");
    }
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("TMBAdmin.aspx");
    }
}
