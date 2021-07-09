using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Online_Complaint_Form_Ack : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["RefNo"].ToString() != "" && Session["Name"].ToString() != null)
        {
            if (!IsPostBack)
            {
                lblId.Text = Session["RefNo"].ToString();
                lblName.Text = Session["Name"].ToString();
            }
            else
            {
                Session["RefNo"] = "";
                Session["Name"] = "";
               
                Session.Clear();
                Response.Redirect("Online-Complaint-Form.aspx");
            }
        }
        else
        {
            Session["RefNo"] = "";
            Session["Name"] = "";
            
            Session.Clear();
            Response.Redirect("Online-Complaint-Form.aspx");
        }
    }
}