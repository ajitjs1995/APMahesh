using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class VisitCounter : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        countMe();
        DataSet tmpDs = new DataSet();
        tmpDs.ReadXml(Server.MapPath("~/counter.xml"));
        int visitorNumm =Convert.ToInt32(tmpDs.Tables[0].Rows[0]["hits"].ToString());

        lblCounter.Text = "You are Visitor Number : " + visitorNumm;
    }

    private void countMe()
    {
        DataSet tmpDs = new DataSet();
        tmpDs.ReadXml(Server.MapPath("~/counter.xml"));

        int hits = Int32.Parse(tmpDs.Tables[0].Rows[0]["hits"].ToString());

        hits += 1;

        tmpDs.Tables[0].Rows[0]["hits"] = hits.ToString();

        tmpDs.WriteXml(Server.MapPath("~/counter.xml"));
    }

}