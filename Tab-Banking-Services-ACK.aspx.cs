using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tab_Banking_Services_ACK : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"].ToString() != null)
        {
            if (!IsPostBack)
            {
               
                lblName.Text = Session["Name"].ToString();
            }
            else
            {
               
                Session["Name"] = "";

                Session.Clear();
                Response.Redirect("Tab-Banking-Services.aspx");
            }
        }
        else
        {
            Session["RefNo"] = "";
            Session["Name"] = "";

            Session.Clear();
            Response.Redirect("Tab-Banking-Services.aspx");
        }

    }
}