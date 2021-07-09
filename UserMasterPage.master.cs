using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] strPage = null;
        string sPageName = null;

        char[] splitchar = { '/' };
        string strPagename = Request.Path;
        //strPage = Strings.Split(strPagename, "/");
        strPage = strPagename.Split(splitchar);
        sPageName = strPage[strPage.Length - 1];

        if (sPageName.ToLower().Contains("rtgs-neft-micr-branch-codes"))
        {
            bannerimg.Text = "<img src='InnerBanner/Banner/RTGS-NEFT-MICR-CODES.jpg' alt='RTGS-NEFT-MICR-CODES' class='img-responsive' >";
        }
        else if (sPageName.ToLower().Contains("branch-code-details"))
        {
            bannerimg.Text = "<img src='InnerBanner/Banner/RTGS-NEFT-MICR-CODES.jpg' alt='branch-code-details' class='img-responsive' >";
        }

        else if (sPageName.ToLower().Contains("online-complaint-form"))
        {
            bannerimg.Text = "<img src='InnerBanner/Banner/Complaint-Grievance.jpg' alt='Complaint-Grievance' class='img-responsive' >";
        }

        else if (sPageName.ToLower().Contains("online-feedback-form"))
        {
            bannerimg.Text = "<img src='InnerBanner/Banner/Write-to-Us-Feedback.jpg' alt='Write-to-Us-Feedback' class='img-responsive' >";
        }
        else if (sPageName.ToLower().Contains("admin-offices"))
        {
            bannerimg.Text = "<img src='InnerBanner/Banner/AdminOffices.jpg' alt='AdminOffices' class='img-responsive' >";
        }
        else if (sPageName.ToLower().Contains("AdminOfficeDetails"))
        {
            bannerimg.Text = "<img src='InnerBanner/Banner/AdminOffices.jpg' alt='AdminOfficeDetails' class='img-responsive' >";
        }
        else if (sPageName.ToLower().Contains("atm-centres"))
        {
            bannerimg.Text = "<img src='InnerBanner/Banner/ATMCentres.jpg' alt='ATMCentres' class='img-responsive' >";
        }
        else if (sPageName.ToLower().Contains("sale-notice"))
        {
            bannerimg.Text = "<img src='InnerBanner/Banner/SaleNotice.jpg' alt='SalesNotice' class='img-responsive' >";
        }
        else if (sPageName.ToLower().Contains("sales-notice-details"))
        {
            bannerimg.Text = "<img src='InnerBanner/Banner/SaleNotice.jpg' alt='SaleNoticeDetails' class='img-responsive' >";
        }
        else if (sPageName.ToLower().Contains("unclaimed-deposits"))
        {
            bannerimg.Text = "<img src='InnerBanner/Banner/UnclaimedDeposits.jpg' alt='UnclaimedDeposits' class='img-responsive' >";
        }
        else if (sPageName.ToLower().Contains("press-release"))
        {
            bannerimg.Text = "<img src='InnerBanner/Banner/PressRelease.jpg' alt='PressRelease' class='img-responsive' >";
        }
        else if (sPageName.ToLower().Contains("branch-locator"))
        {
            bannerimg.Text = "<img src='InnerBanner/Banner/branch-locator.jpg' alt='BranchLoactor' class='img-responsive' >";
        }
        else if (sPageName.ToLower().Contains("Branch-Locator-Details"))
        {
            bannerimg.Text = "<img src='InnerBanner/Banner/branch-locator.jpg' alt='BranchLoactor' class='img-responsive' >";
        }
        else if (sPageName.ToLower().Contains("emi-calculator"))
        {
            bannerimg.Text = "<img src='InnerBanner/Banner/emi-calculator.jpg' alt='EMI Calculator' class='img-responsive' >";
        }
        else if (sPageName.ToLower().Contains("deposit-calculator"))
        {
            bannerimg.Text = "<img src='InnerBanner/Banner/deposit-calculator.jpg' alt='Deposit Calculator' class='img-responsive' >";
        }
        else
        {
            bannerimg.Text = "<img src='InnerBanner/Banner/Default.jpg' alt='Default.jpg' class='img-responsive' >";
        }
    }
}
