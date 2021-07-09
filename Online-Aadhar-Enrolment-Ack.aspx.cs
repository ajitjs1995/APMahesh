using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Online_Aadhar_Enrolment_ACK : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACK"].ToString() != "" && Session["ACK"].ToString() != null)
        {
            if (!IsPostBack)
            {
                if (Session["ACK"].ToString() != "" && Session["Name"].ToString() != null)
                {
                    if (!IsPostBack)
                    {
                        lblId.Text = Session["ACK"].ToString();
                        lblName.Text = Session["Name"].ToString();
                    }
                    else
                    {
                        Session["ACK"] = "";
                        Session["Name"] = "";

                        Session.Clear();
                        Response.Redirect("Online-Aadhaar-Enrolment.aspx");
                    }
                }
                else
                {
                    Session["ACK"] = "";
                    Session["Name"] = "";

                    Session.Clear();
                    Response.Redirect("Online-Aadhaar-Enrolment.aspx");
                }
            }
        }
            
        
    }
}


