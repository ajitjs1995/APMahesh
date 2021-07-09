using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Drawing;


public partial class Customer_Survey : System.Web.UI.Page
{
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    System.Data.DataSet ds = new System.Data.DataSet();
    System.Data.DataSet ds1 = new System.Data.DataSet();
    SqlDataReader dr;


    string CDTime;
    string CDSatisfaction;

    string CWTime;
    string CWSatisfaction;

    string PUTime;
    string PUSatisfaction;

    string RDTime;
    string RDSatisfaction;

    string RTGSTime;
    string RTGSSatisfaction;

    string DDTime;
    string DDSatisfaction;

    string ClrTranDay;
    string ClrTranSatisfaction;

    string BillDay;
    string BillSatisfaction;

    string ChqDay;
    string ChqSatisfaction;

    string ATMUse;
    string ATMSatisfaction;

    string BSUse;
    string BSSatisfaction;


    string IBUse;
    string IBSatisfaction;

    string MBUse;
    string MBSatisfaction;


    string SppedTrnSat;
    string CorrectSat;
    string BehaviourSat;
    string KnoBankstaffSat;
    string PunctualitySat;
    string AvailabilitySat;
    string FacilitySat;


    public SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["TMBCON"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            BindBranch();
        }
    }
    public bool chkQue345()
    {
        if (rdoQues3.SelectedIndex == -1)
        {
            lblErrQues3.Visible = true;
            lblErrQues3.Text = "Please select account type";
            rdoQues3.Focus();

            return false;
        }
        else if (rdoQues3.SelectedValue == "3" && string.IsNullOrEmpty(txtOtherAccount.Text))
        {
            lblErrQues3.Visible = true;
            lblErrQues3.Text = "Please enter other account type";
            rdoQues3.Focus();

            return false;
        }
        else if (!string.IsNullOrEmpty(txtOtherAccount.Text.Trim()) && !Regex.IsMatch(txtOtherAccount.Text, "^[a-zA-Z ]+$"))
        {
            lblerror.Text = "Please  Account type should contain only alphabates !!";
            txtOtherAccount.Focus();
            return false;
        }
        else if (rdoQues4.SelectedIndex == -1)
        {
            lblErrQues4.Visible = true;
            lblErrQues4.Text = "Please select occupation";
            rdoQues4.Focus();

            return false;
        }
        else if (rdoQues3.SelectedValue == "6" && string.IsNullOrEmpty(txtOtherOccupation.Text))
        {
            lblErrQues4.Visible = true;
            lblErrQues4.Text = "Please enter other occupation";
            rdoQues4.Focus();

            return false;
        }
        else if (!string.IsNullOrEmpty(txtOtherOccupation.Text.Trim()) && !Regex.IsMatch(txtOtherOccupation.Text, "^[a-zA-Z ]+$"))
        {
            lblerror.Text = "Please  Account type should contain only alphabates !!";
            txtOtherOccupation.Focus();
            return false;
        }
        else if (rdoQues5.SelectedIndex == -1)
        {
            lblErrQues5.Visible = true;
            lblErrQues5.Text = "Please select annual income";
            rdoQues5.Focus();

            return false;
        }
        else
        {
            return true;
        }
    }
    public bool chQue67()
    {
        if (rdbCashD1.Checked == false && rdbCashD2.Checked == false && rdbCashD3.Checked == false && rdbCashD4.Checked == false)
        {
            rdbCashD1.Focus();
            lblErr6.Visible = true;
            rdbCashD1.BorderStyle = BorderStyle.Solid;
            rdbCashD1.BorderColor = System.Drawing.Color.LightGray;
            lblErr6.Text = "Please select atleast one Option for time taken for Cash Deposits.";
            return false;
        }
        if (rdbCashD5.Checked == false && rdbCashD6.Checked == false && rdbCashD7.Checked == false && rdbCashD8.Checked == false && rdbCashD9.Checked == false)
        {
            rdbCashD1.Focus();
            lblErr6.Visible = true;
            rdbCashD5.BorderStyle = BorderStyle.Solid;
            rdbCashD5.BorderColor = System.Drawing.Color.LightGray;
            lblErr6.Text = "Please select atleast one Option for satisfaction level of Cash Deposits.";
            return false;

        }
        if (rdbCashW1.Checked == false && rdbCashW2.Checked == false && rdbCashW3.Checked == false && rdbCashW4.Checked == false)
        {
            rdbCashW1.Focus();
            lblErr6.Visible = true;
            rdbCashW1.BorderStyle = BorderStyle.Solid;
            rdbCashW1.BorderColor = System.Drawing.Color.LightGray;
            lblErr6.Text = "Please select atleast one Option for time taken for Cash Withdrawl.";
            return false;
        }
        if (rdbCashW5.Checked == false && rdbCashW6.Checked == false && rdbCashW7.Checked == false && rdbCashW8.Checked == false && rdbCashW9.Checked == false)
        {
            rdbCashW5.Focus();
            lblErr6.Visible = true;
            rdbCashW5.BorderStyle = BorderStyle.Solid;
            rdbCashW5.BorderColor = System.Drawing.Color.LightGray;
            lblErr6.Text = "Please select atleast one Option for satisfaction level of Cash Withdrawl.";
            return false;
        }
        if (rdbPassUpd1.Checked == false && rdbPassUpd2.Checked == false && rdbPassUpd3.Checked == false && rdbPassUpd4.Checked == false)
        {
            rdbPassUpd1.Focus();
            lblErr6.Visible = true;
            rdbPassUpd1.BorderStyle = BorderStyle.Solid;
            rdbPassUpd1.BorderColor = System.Drawing.Color.LightGray;
            lblErr6.Text = "Please select atleast one Option for time taken for Pasbook Updation.";
            return false;
        }
        if (rdbPassUpd5.Checked == false && rdbPassUpd6.Checked == false && rdbPassUpd7.Checked == false && rdbPassUpd8.Checked == false && rdbPassUpd9.Checked == false)
        {
            rdbPassUpd5.Focus();
            lblErr6.Visible = true;
            rdbPassUpd5.BorderStyle = BorderStyle.Solid;
            rdbPassUpd5.BorderColor = System.Drawing.Color.LightGray;
            lblErr6.Text = "Please select atleast one Option for satisfaction level of Pasbook Updation.";
            return false;
        }
        if (rdoRD1.Checked == false && rdoRD2.Checked == false && rdoRD3.Checked == false && rdoRD4.Checked == false)
        {
            rdoRD1.Focus();
            lblErr6.Visible = true;
            rdoRD1.BorderStyle = BorderStyle.Solid;
            rdoRD1.BorderColor = System.Drawing.Color.LightGray;
            lblErr6.Text = "Please select atleast one Option for time taken for Issue / Renew Term Deposit.";
            return false;
        }
        if (rdoRD5.Checked == false && rdoRD6.Checked == false && rdoRD7.Checked == false && rdoRD8.Checked == false && rdoRD9.Checked == false)
        {
            rdoRD5.Focus();
            lblErr6.Visible = true;
            rdoRD5.BorderStyle = BorderStyle.Solid;
            rdoRD5.BorderColor = System.Drawing.Color.LightGray;
            lblErr6.Text = "Please select atleast one Option for satisfaction level of Issue / Renew Term Deposit.";
            return false;
        }
        if (rdoRTGS1.Checked == false && rdoRTGS2.Checked == false && rdoRTGS3.Checked == false && rdoRTGS4.Checked == false)
        {
            rdoRTGS1.Focus();
            lblErr7.Visible = true;
            rdoRTGS1.BorderStyle = BorderStyle.Solid;
            rdoRTGS1.BorderColor = System.Drawing.Color.LightGray;
            lblErr7.Text = "Please select atleast one Option for time taken for RTGS / NEFT Transfer.";
            return false;
        }
        if (rdoRTGS5.Checked == false && rdoRTGS6.Checked == false && rdoRTGS7.Checked == false && rdoRTGS8.Checked == false && rdoRTGS9.Checked == false)
        {
            rdoRTGS5.Focus();
            lblErr7.Visible = true;
            rdoRTGS5.BorderStyle = BorderStyle.Solid;
            rdoRTGS5.BorderColor = System.Drawing.Color.LightGray;
            lblErr7.Text = "Please select atleast one Option for satisfaction level of RTGS / NEFT Transfer.";
            return false;
        }
        if (rdoDD1.Checked == false && rdoDD2.Checked == false && rdoDD3.Checked == false && rdoDD4.Checked == false)
        {
            rdoDD1.Focus();
            lblErr6.Visible = true;
            rdoDD1.BorderStyle = BorderStyle.Solid;
            rdoDD1.BorderColor = System.Drawing.Color.LightGray;
            lblErr7.Text = "Please select atleast one Option for time taken for Issue DD / PO.";
            return false;
        }
        if (rdoDD5.Checked == false && rdoDD6.Checked == false && rdoDD7.Checked == false && rdoDD8.Checked == false && rdoDD9.Checked == false)
        {
            rdoDD5.Focus();
            lblErr7.Visible = true;
            rdoDD5.BorderStyle = BorderStyle.Solid;
            rdoDD5.BorderColor = System.Drawing.Color.LightGray;
            lblErr7.Text = "Please select atleast one Option for satisfaction level of Issue DD / PO.";
            return false;
        }
        else
        {
            return true;
        }
    }
    public bool chQue89()
    {
        if (rdoBills1.Checked == false && rdoBills2.Checked == false && rdoBills3.Checked == false && rdoBills4.Checked == false)
        {

            rdoBills1.Focus();
            lblErr8.Visible = true;
            rdoBills1.BorderStyle = BorderStyle.Solid;
            rdoBills1.BorderColor = System.Drawing.Color.LightGray;
            lblErr8.Text = "Please select atleast one Option for time taken for Bills Collection.";
            return false;
        }
        if (rdoBills5.Checked == false && rdoBills6.Checked == false && rdoBills7.Checked == false && rdoBills8.Checked == false && rdoBills9.Checked == false)
        {
            rdoBills5.Focus();
            lblErr8.Visible = true;
            rdoBills5.BorderStyle = BorderStyle.Solid;
            rdoBills5.BorderColor = System.Drawing.Color.LightGray;
            lblErr8.Text = "Please select atleast one Option for satisfaction level of Bills Collection.";
            return false;
        }

        if (rdoCh1.Checked == false && rdoCh2.Checked == false && rdoCh3.Checked == false && rdoCh4.Checked == false)
        {
            rdoCh1.Focus();
            lblErr8.Visible = true;
            rdoCh1.BorderStyle = BorderStyle.Solid;
            rdoCh1.BorderColor = System.Drawing.Color.LightGray;
            lblErr8.Text = "Please select atleast one Option for time taken for Cheque Collection.";
            return false;
        }
        if (rdoCh5.Checked == false && rdoCh6.Checked == false && rdoCh7.Checked == false && rdoCh8.Checked == false && rdoCh9.Checked == false)
        {
            rdoCh5.Focus();
            lblErr8.Visible = true;
            rdoCh5.BorderStyle = BorderStyle.Solid;
            rdoCh5.BorderColor = System.Drawing.Color.LightGray;
            lblErr8.Text = "Please select atleast one Option for satisfaction level of Cheque Collection.";
            return false;
        }
        if (rdoClrTran1.Checked == false && rdoClrTran2.Checked == false && rdoClrTran3.Checked == false && rdoClrTran4.Checked == false)
        {
            rdoClrTran1.Focus();
            lblErr8.Visible = true;
            rdoClrTran1.BorderStyle = BorderStyle.Solid;
            rdoClrTran1.BorderColor = System.Drawing.Color.LightGray;
            lblErr8.Text = "Please select atleast one Option for time taken for Clearing Transaction.";
            return false;
        }
        if (rdoClrTran5.Checked == false && rdoClrTran6.Checked == false && rdoClrTran7.Checked == false && rdoClrTran8.Checked == false && rdoClrTran9.Checked == false)
        {
            rdoClrTran5.Focus();
            lblErr8.Visible = true;
            rdoClrTran5.BorderStyle = BorderStyle.Solid;
            rdoClrTran5.BorderColor = System.Drawing.Color.LightGray;
            lblErr8.Text = "Please select atleast one Option for satisfaction level of Clearing Transaction.";
            return false;
        }

        if (rdoATM1.Checked == false && rdoATM2.Checked == false)
        {
            rdoATM1.Focus();
            lblErr9.Visible = true;
            rdoATM1.BorderStyle = BorderStyle.Solid;
            rdoATM1.BorderColor = System.Drawing.Color.LightGray;
            lblErr9.Text = "Are you using ATM Service ?";
            return false;
        }
        if (rdoATM1.Checked == true && rdoATM3.Checked == false && rdoATM4.Checked == false && rdoATM5.Checked == false && rdoATM6.Checked == false && rdoATM7.Checked == false)
        {
            rdoATM3.Focus();
            lblErr9.Visible = true;
            rdoATM3.BorderStyle = BorderStyle.Solid;
            rdoATM3.BorderColor = System.Drawing.Color.LightGray;
            lblErr9.Text = "Please select atleast one Option for satisfaction level of ATM Uses.";
            return false;
        }
        if (rdoBS1.Checked == false && rdoBS2.Checked == false)
        {
            rdoBS1.Focus();
            lblErr9.Visible = true;
            rdoBS1.BorderStyle = BorderStyle.Solid;
            rdoBS1.BorderColor = System.Drawing.Color.LightGray;
            lblErr9.Text = "Are you using Anywhere Banking Services	?";
            return false;
        }
        if (rdoBS1.Checked == true && rdoBS3.Checked == false && rdoBS4.Checked == false && rdoBS5.Checked == false && rdoBS6.Checked == false && rdoBS7.Checked == false)
        {
            rdoBS3.Focus();
            lblErr9.Visible = true;
            rdoBS3.BorderStyle = BorderStyle.Solid;
            rdoBS3.BorderColor = System.Drawing.Color.LightGray;
            lblErr9.Text = "Please select atleast one Option for satisfaction level of Banking Services.";
            return false;
        }
        if (rdoIB1.Checked == false && rdoIB2.Checked == false)
        {
            rdoIB1.Focus();
            lblErr9.Visible = true;
            rdoIB1.BorderStyle = BorderStyle.Solid;
            rdoIB1.BorderColor = System.Drawing.Color.LightGray;
            lblErr9.Text = "Are you using Internet Banking Services	?";
            return false;
        }
        if (rdoIB1.Checked == true && rdoIB3.Checked == false && rdoIB7.Checked == false && rdoIB4.Checked == false && rdoIB5.Checked == false && rdoIB6.Checked == false)
        {
            rdoIB3.Focus();
            lblErr9.Visible = true;
            rdoIB3.BorderStyle = BorderStyle.Solid;
            rdoIB3.BorderColor = System.Drawing.Color.LightGray;
            lblErr9.Text = "Please select atleast one Option for satisfaction level of Internet Banking Services.";
            return false;
        }
        if (rdoMB1.Checked == false && rdoMB2.Checked == false)
        {
            rdoMB1.Focus();
            lblErr9.Visible = true;
            rdoMB1.BorderStyle = BorderStyle.Solid;
            rdoMB1.BorderColor = System.Drawing.Color.LightGray;
            lblErr9.Text = "Are you using Mobile Banking Services	?";
            return false;
        }
        if (MBUse == "Yes" && rdoMB3.Checked == true && rdoMB4.Checked == false && rdoMB5.Checked == false && rdoMB6.Checked == false && rdoMB7.Checked == false)
        {
            rdoMB3.Focus();
            lblErr9.Visible = true;
            rdoMB3.BorderStyle = BorderStyle.Solid;
            rdoMB3.BorderColor = System.Drawing.Color.LightGray;
            lblErr9.Text = "Please select atleast one Option for satisfaction level of Mobile Banking Services.";
            return false;
        }
        else
        {
            return true;
        }
    }
    public bool chklast()
    {
        if (rdoSTC1.Checked == false && rdoSTC2.Checked == false && rdoSTC3.Checked == false && rdoSTC4.Checked == false && rdoSTC5.Checked == false)
        {
            rdoSTC1.Focus();
            lblErr11.Visible = true;
            rdoSTC1.BorderStyle = BorderStyle.Solid;
            rdoSTC1.BorderColor = System.Drawing.Color.LightGray;
            lblErr11.Text = "Please select atleast one Option for satisfaction level  for Speed of Transactions at Counters";
            return false;
        }
        if (RadioButton1.Checked == false && RadioButton2.Checked == false && RadioButton3.Checked == false && RadioButton4.Checked == false && RadioButton5.Checked == false)
        {
            RadioButton1.Focus();
            lblErr11.Visible = true;
            RadioButton1.BorderStyle = BorderStyle.Solid;
            RadioButton1.BorderColor = System.Drawing.Color.LightGray;
            lblErr11.Text = "Please select atleast one Option for satisfaction level  for Correctness / Accuracy of Transactions";
            return false;
        }
        if (RadioButton6.Checked == false && RadioButton7.Checked == false && RadioButton8.Checked == false && RadioButton9.Checked == false && RadioButton10.Checked == false)

        {
            RadioButton6.Focus();
            lblErr11.Visible = true;
            RadioButton6.BorderStyle = BorderStyle.Solid;
            RadioButton6.BorderColor = System.Drawing.Color.LightGray;
            lblErr11.Text = "Please select atleast one Option for satisfaction level  for Behaviour / Attitude of Bank Staff";
            return false;
        }
        if (RadioButton11.Checked == false && RadioButton12.Checked == false && RadioButton13.Checked == false && RadioButton14.Checked == false && RadioButton15.Checked == false)
        {

            RadioButton11.Focus();
            lblErr11.Visible = true;
            RadioButton11.BorderStyle = BorderStyle.Solid;
            RadioButton11.BorderColor = System.Drawing.Color.LightGray;
            lblErr11.Text = "Please select atleast one Option for satisfaction level for Knowledge Level of Bank Staff";
            return false;
        }
        if (RadioButton16.Checked == false && RadioButton17.Checked == false && RadioButton18.Checked == false && RadioButton19.Checked == false && RadioButton20.Checked == false)
        {
            RadioButton16.Focus();
            lblErr11.Visible = true;
            RadioButton16.BorderStyle = BorderStyle.Solid;
            RadioButton16.BorderColor = System.Drawing.Color.LightGray;
            lblErr11.Text = "Please select atleast one Option for satisfaction level  for Punctuality of Commencing Business in the branch";
            return false;
        }
        if (RadioButton21.Checked == false && RadioButton22.Checked == false && RadioButton23.Checked == false && RadioButton24.Checked == false && RadioButton25.Checked == false)
        {
            RadioButton21.Focus();
            lblErr11.Visible = true;
            RadioButton21.BorderStyle = BorderStyle.Solid;
            RadioButton21.BorderColor = System.Drawing.Color.LightGray;
            lblErr11.Text = "Please select atleast one Option for satisfaction level  for Availability / Display of Information at Branches";
            return false;
        }
        if (RadioButton26.Checked == false && RadioButton12.Checked == false && RadioButton28.Checked == false && RadioButton29.Checked == false && RadioButton30.Checked == false)
        {
            RadioButton26.Focus();
            lblErr11.Visible = true;
            RadioButton26.BorderStyle = BorderStyle.Solid;
            RadioButton26.BorderColor = System.Drawing.Color.LightGray;
            lblErr11.Text = "Please select atleast one Option for satisfaction level  for Basic Facilities (seating arrangement, drinking water, stationary, etc.)";
            return false;
        }
        if (rdoSocil.SelectedIndex == -1)
        {
            lblerror.Text = "Are you following us on social mdeia (facebbok/ twitter)?";
            rdoSocil.Focus();
            return false;
        }
        if (txtComments.Text != "" && !Regex.IsMatch(txtComments.Text, "^[a-zA-Z, & \n\r ]+$"))
        {
            lblerror.Text = "Please enter valid comments";
            txtComments.Focus();
            return false;
        }

        if (String.IsNullOrEmpty(Txtcaptch.Text))
        {
            lblerror.Text = "Verification Code , should not be blank !!";
            Txtcaptch.Focus();
            return false;
        }
       
        if (!string.IsNullOrEmpty(Txtcaptch.Text.Trim()) && Txtcaptch.Text.Trim().Length != 6)
        {
            lblerror.Text = "The text you typed as shown in image is incorrect !!";
            Txtcaptch.Focus();
            return false;
        }
        else
        {
            return true;
        }
    }
    public bool checkdata()
    {


        if (Txtname.Text == "")
        {
            lblerror.Text = "Please Enter Name";
            Txtname.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(Txtname.Text.Trim()) && !Regex.IsMatch(Txtname.Text, "^[a-zA-Z ]+$"))
        {
            lblerror.Text = "Name should contain only aplhabates !!";
            Txtname.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(Txtname.Text.Trim()) && Txtname.Text.Trim().Length < 2)
        {
            lblerror.Text = "Name should be greater then 2 character !!";
            lblerror.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(Txtname.Text.Trim()) && Txtname.Text.Trim().Length > 100)
        {
            lblerror.Text = "Name should be less than 100 character !!";
            Txtname.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
        {
            lblerror.Text = "Email-Id should not be blank !!";
            txtEmail.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtEmail.Text.Trim()) && !Regex.IsMatch(txtEmail.Text.Trim(), "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$"))
        {
            lblerror.Text = "Your email-Id is not in correct format !!";
            txtEmail.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtEmail.Text.Trim()) && txtEmail.Text.Trim().Length < 8)
        {
            lblerror.Text = "Please enter email Id is above 8 characters !!";
            txtEmail.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtEmail.Text.Trim()) && txtEmail.Text.Trim().Length > 75)
        {
            lblerror.Text = "Please enter email Id is below 75 characters !!";
            txtEmail.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtAge.Text.Trim()) && txtAge.Text.Trim().Length < 2)
        {
            lblerror.Text = "Age  should contain 2 or 3 digits !!";
            txtAge.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtAge.Text.Trim()) && txtAge.Text.Trim().Length > 3)
        {
            lblerror.Text = "Age  should contain  digits !!";
            txtAge.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtAge.Text.Trim()) && !Regex.IsMatch(txtAge.Text.Trim(), "^[1-9]{1}[0-9}{1}$"))
        {
            lblerror.Text = "Invalid Age !!";
            txtAge.Focus();
            return false;
        }
        
        else if (!string.IsNullOrEmpty(txtMonths.Text.Trim()) && !Regex.IsMatch(txtMonths.Text.Trim(), "^[1-9]{1}[0-9]{1}$"))
        {
            lblerror.Text = "Invalid Months !!";
            txtMonths.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtYears.Text.Trim()) && !Regex.IsMatch(txtYears.Text.Trim(), "^[1-9]{1}[0-9]{1}$"))
        {
            lblerror.Text = "Invalid Years !!";
            txtYears.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtMobile.Text.Trim()) && txtMobile.Text.Trim().Length < 10)
        {
            lblerror.Text = "Mobile number should contain 2 or 3 digits !!";
            txtMobile.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtMobile.Text.Trim()) && txtMobile.Text.Trim().Length > 10)
        {
            lblerror.Text = "Mobile number should contain 10 digits !!";
            txtMobile.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtMobile.Text.Trim()) && !Regex.IsMatch(txtMobile.Text.Trim(), "^[7-9]{1}[0-9]{9}$"))
        {
            lblerror.Text = "Invalid Mobile no, should start with 7, 8 or 9 !! !!";
            txtMobile.Focus();
            return false;
        }



        else if (rdoGender.SelectedIndex == -1)
        {
            lblerror.Text = "Please select  Gender";

            return false;
        }



        else
        {
            lblerror.Text = "";
            return true;
        }
    }
    public bool ChQue11()
    {
        if (txtLoanType.Text != "" && !Regex.IsMatch(txtLoanType.Text, "^[a-zA-Z   ]+$"))
        {
            lblerror.Text = "Loan type should contain only alphabates";
            txtLoanType.Focus();
            return false;
        }

        else
        {
            return true;
        }
    }


    public void BindBranch()
    {

        try
        {
            con.Open();
            cmd = new SqlCommand("USP_ManageBranch", con);
            cmd.Parameters.AddWithValue("@QueryType", "AllBranch");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                ddlBranch.Items.Clear();
                ddlBranch.DataSource = dt.DefaultView;
                ddlBranch.DataTextField = "BR_Name";
                ddlBranch.DataValueField = "BR_ID";
                ddlBranch.DataBind();
                ddlBranch.Items.Insert(0, " Select Branch Where You Have An Account");
                ddlBranch.SelectedIndex = 0;
            }
            else
            {
                ddlBranch.Items.Clear();
                ddlBranch.Items.Insert(0, " Select Branch Where You Have An Account ");
                ddlBranch.SelectedIndex = 0;
            }


        }
        catch { }
        finally
        {
            con.Close();
        }
    }
    public void Clear()
    {
        BindBranch();
        Txtname.Text = "";
        txtMobile.Text = "";
        txtEmail.Text = "";
        Txtcaptch.Text = "";
        txtLoanType.Text = "";
        txtMonths.Text = "";
        txtYears.Text = "";
        txtOtherAccount.Text = "";
        txtOtherOccupation.Text = "";
        txtAge.Text = "";
        txtComments.Text = "";
        ddlCrFacYr.SelectedValue = "0";
        ddlCrRate.SelectedValue = "0";
        ddlKnowProducts.SelectedValue = "0";
        ddlLoanType.SelectedValue = "0";
        ddlRateLoanSaction.SelectedValue = "0";
        rdoSocil.SelectedIndex = -1;
        rdoQues3.SelectedIndex = -1;
        rdoQues4.SelectedIndex = -1;
        rdoGender.SelectedIndex = -1;
        rdoQues5.SelectedIndex = -1;
        rdbCashD1.Checked = false;
        rdbCashD2.Checked = false;
        rdbCashD3.Checked = false;
        rdbCashD4.Checked = false;
        rdbCashD5.Checked = false;
        rdbCashD6.Checked = false;
        rdbCashD7.Checked = false;
        rdbCashD8.Checked = false;
        rdbCashD9.Checked = false;
        rdbCashW1.Checked = false;
        rdbCashW2.Checked = false;
        rdbCashW3.Checked = false;
        rdbCashW4.Checked = false;
        rdbCashW5.Checked = false;
        rdbCashW6.Checked = false;
        rdbCashW7.Checked = false;
        rdbCashW8.Checked = false;
        rdbCashW9.Checked = false;
        rdbPassUpd1.Checked = false;
        rdbPassUpd2.Checked = false;
        rdbPassUpd3.Checked = false;
        rdbPassUpd4.Checked = false;
        rdbPassUpd5.Checked = false;
        rdbPassUpd6.Checked = false;
        rdbPassUpd7.Checked = false;
        rdbPassUpd8.Checked = false;
        rdbPassUpd9.Checked = false;
        rdoRD1.Checked = false;
        rdoRD2.Checked = false;
        rdoRD3.Checked = false;
        rdoRD4.Checked = false;
        rdoRD5.Checked = false;
        rdoRD6.Checked = false;
        rdoRD7.Checked = false;
        rdoRD8.Checked = false;
        rdoRD9.Checked = false;
        rdoRTGS1.Checked = false;
        rdoRTGS2.Checked = false;
        rdoRTGS3.Checked = false;
        rdoRTGS4.Checked = false;
        rdoRTGS5.Checked = false;
        rdoRTGS6.Checked = false;
        rdoRTGS7.Checked = false;
        rdoRTGS8.Checked = false;
        rdoRTGS9.Checked = false;
        rdoDD1.Checked = false;
        rdoDD2.Checked = false;
        rdoDD3.Checked = false;
        rdoDD4.Checked = false;
        rdoDD5.Checked = false;
        rdoDD6.Checked = false;
        rdoDD7.Checked = false;
        rdoDD8.Checked = false;
        rdoDD9.Checked = false;
        rdoBills1.Checked = false;
        rdoBills2.Checked = false;
        rdoBills3.Checked = false;
        rdoBills4.Checked = false;
        rdoBills5.Checked = false;
        rdoBills6.Checked = false;
        rdoBills7.Checked = false;
        rdoBills8.Checked = false;
        rdoBills9.Checked = false;
        rdoCh1.Checked = false;
        rdoCh2.Checked = false;
        rdoCh2.Checked = false;
        rdoCh3.Checked = false;
        rdoCh4.Checked = false;
        rdoCh5.Checked = false;
        rdoCh6.Checked = false;
        rdoCh7.Checked = false;
        rdoCh8.Checked = false;
        rdoCh9.Checked = false;
        rdoClrTran1.Checked = false;
        rdoClrTran2.Checked = false;
        rdoClrTran3.Checked = false;
        rdoClrTran4.Checked = false;
        rdoClrTran5.Checked = false;
        rdoClrTran6.Checked = false;
        rdoClrTran7.Checked = false;
        rdoClrTran8.Checked = false;
        rdoClrTran9.Checked = false;
        rdoATM1.Checked = false;
        rdoATM2.Checked = false;
        rdoATM3.Checked = false;
        rdoATM4.Checked = false;
        rdoATM5.Checked = false;
        rdoATM6.Checked = false;
        rdoATM7.Checked = false;
        rdoBS1.Checked = false;
        rdoBS2.Checked = false;
        rdoBS3.Checked = false;
        rdoBS4.Checked = false;
        rdoBS5.Checked = false;
        rdoBS6.Checked = false;
        rdoBS7.Checked = false;
        rdoIB1.Checked = false;
        rdoIB2.Checked = false;
        rdoIB3.Checked = false;
        rdoIB4.Checked = false;
        rdoIB5.Checked = false;
        rdoIB6.Checked = false;
        rdoIB7.Checked = false;
        rdoMB1.Checked = false;
        rdoMB2.Checked = false;
        rdoMB3.Checked = false;
        rdoMB4.Checked = false;
        rdoMB5.Checked = false;
        rdoMB6.Checked = false;
        rdoMB7.Checked = false;
        rdoSTC1.Checked = false;
        rdoSTC2.Checked = false;
        rdoSTC3.Checked = false;
        rdoSTC4.Checked = false;
        rdoSTC5.Checked = false;

        RadioButton1.Checked = false;
        RadioButton2.Checked = false;
        RadioButton3.Checked = false;
        RadioButton4.Checked = false;
        RadioButton5.Checked = false;
        RadioButton6.Checked = false;
        RadioButton7.Checked = false;
        RadioButton8.Checked = false;
        RadioButton9.Checked = false;
        RadioButton10.Checked = false;
        RadioButton11.Checked = false;
        RadioButton12.Checked = false;
        RadioButton13.Checked = false;
        RadioButton14.Checked = false;
        RadioButton15.Checked = false;
        RadioButton16.Checked = false;
        RadioButton17.Checked = false;
        RadioButton18.Checked = false;
        RadioButton19.Checked = false;
        RadioButton20.Checked = false;
        RadioButton21.Checked = false;
        RadioButton22.Checked = false;
        RadioButton23.Checked = false;
        RadioButton24.Checked = false;
        RadioButton25.Checked = false;
        RadioButton26.Checked = false;
        RadioButton27.Checked = false;
        RadioButton28.Checked = false;
        RadioButton29.Checked = false;
        RadioButton30.Checked = false;
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        Clear();
    }

    protected void ddlLoanType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLoanType.SelectedValue == "5")
        {
            divOtherLoan.Visible = true;
        }
        if (ddlLoanType.SelectedValue != "5")
        {
            divOtherLoan.Visible = false;
            txtLoanType.Text = "";
        }
    }

    protected void rdoQues3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoQues3.SelectedIndex != -1)
        {
            lblErrQues3.Text = "";
            lblErrQues3.Visible = false;
            rdoQues3.Focus();
        }
        else
        {
            lblErrQues3.Focus();
        }
        if (rdoQues3.SelectedValue == "3")
        {
            
            txtOtherAccount.Enabled = true;

        }
        else
        {
            txtOtherAccount.Enabled = false;
            txtOtherAccount.Text = "";
        }
    }

    protected void rdoQues4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoQues4.SelectedIndex != -1)
        {
            lblErrQues4.Text = "";
            lblErrQues4.Visible = false;
            rdoQues4.Focus();
        }
        else
        {
            lblErrQues4.Focus();
        }
        if (rdoQues4.SelectedValue == "6")
        {
            txtOtherOccupation.Enabled = true;
        }
        else
        {
            txtOtherOccupation.Enabled = false;
            txtOtherOccupation.Text = "";
        }
    }
    protected void rdoQues5_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoQues5.SelectedIndex != -1)
        {
            lblErrQues5.Text = "";
            lblErrQues5.Visible = false;
            rdoQues5.Focus();
        }
        else
        {
            lblErrQues5.Focus();
        }

    }
    protected void Btnsave_Click(object sender, EventArgs e)
    {
        lblerror.Text = "";
        if (chklast() == true)
        {

            //mail_appl();
            //mail_PlanningTMB();

            Response.Redirect("Home.aspx");
        }

    }

    protected void rdbCashD1_CheckedChanged(object sender, EventArgs e)
    {
        CDTime = "03~05 m";
        if (CDTime != "")
        {
            rdbCashD1.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdbCashD2_CheckedChanged(object sender, EventArgs e)
    {
        CDTime = "05~10 m";
        if (CDTime != "")
        {
            rdbCashD2.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdbCashD3_CheckedChanged(object sender, EventArgs e)
    {
        CDTime = "10~15 m";
        if (CDTime != "")
        {
            rdbCashD3.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdbCashD4_CheckedChanged(object sender, EventArgs e)
    {
        CDTime = "> 15 m";
        if (CDTime != "")
        {
            rdbCashD4.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdbCashD5_CheckedChanged(object sender, EventArgs e)
    {
        CDSatisfaction = "Extremely Satisfied";
        if (CDSatisfaction != "")
        {
            rdbCashD5.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdbCashD6_CheckedChanged(object sender, EventArgs e)
    {
        CDSatisfaction = "Satisfied";
        if (CDSatisfaction != "")
        {
            rdbCashD6.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdbCashD7_CheckedChanged(object sender, EventArgs e)
    {
        CDSatisfaction = "Somewhat Satisfied";
        if (CDSatisfaction != "")
        {
            rdbCashD7.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdbCashD8_CheckedChanged(object sender, EventArgs e)
    {
        CDSatisfaction = "Dis Satisfied";
        if (CDSatisfaction != "")
        {
            rdbCashD8.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdbCashD9_CheckedChanged(object sender, EventArgs e)
    {
        CDSatisfaction = "Extremely Satisfied";
        if (CDSatisfaction != "")
        {
            rdbCashD9.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }

    protected void rdbCashW1_CheckedChanged(object sender, EventArgs e)
    {
        CWTime = "03~05 m";
        if (CWTime != "")
        {
            rdbCashW1.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdbCashW2_CheckedChanged(object sender, EventArgs e)
    {
        CWTime = "05~10 m";
        if (CWTime != "")
        {
            rdbCashW2.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdbCashW3_CheckedChanged(object sender, EventArgs e)
    {
        CWTime = "10~15 m";
        if (CWTime != "")
        {
            rdbCashW3.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdbCashW4_CheckedChanged(object sender, EventArgs e)
    {
        CWTime = "> 15 m";
        if (CWTime != "")
        {
            rdbCashW4.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdbCashW5_CheckedChanged(object sender, EventArgs e)
    {
        CWSatisfaction = "Extremely Satisfied";
        if (CWSatisfaction != "")
        {
            rdbCashW5.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdbCashW6_CheckedChanged(object sender, EventArgs e)
    {
        CWSatisfaction = "Satisfied";
        if (CWSatisfaction != "")
        {
            rdbCashW6.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdbCashW7_CheckedChanged(object sender, EventArgs e)
    {
        CWSatisfaction = "Somewhat Satisfied";
        if (CWSatisfaction != "")
        {
            rdbCashW7.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdbCashW8_CheckedChanged(object sender, EventArgs e)
    {
        CWSatisfaction = "Dis Satisfied";
        if (CWSatisfaction != "")
        {
            rdbCashW8.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdoRD1_CheckedChanged(object sender, EventArgs e)
    {
        RDTime = "03~05 m";
        if (RDTime != "")
        {
            rdoRD1.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdoRD2_CheckedChanged(object sender, EventArgs e)
    {
        RDTime = "05~10 m";
        if (RDTime != "")
        {
            rdoRD2.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdoRD3_CheckedChanged(object sender, EventArgs e)
    {
        RDTime = "10~15 m";
        if (RDTime != "")
        {
            rdoRD3.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdoRD4_CheckedChanged(object sender, EventArgs e)
    {
        RDTime = "> 15 m";
        if (RDTime != "")
        {
            rdoRD4.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdoRD5_CheckedChanged(object sender, EventArgs e)
    {
        RDSatisfaction = "Extremely Satisfied";
        if (RDSatisfaction != "")
        {
            rdoRD5.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdoRD6_CheckedChanged(object sender, EventArgs e)
    {
        RDSatisfaction = "Satisfied";
        if (RDSatisfaction != "")
        {
            rdoRD6.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdoRD7_CheckedChanged(object sender, EventArgs e)
    {
        RDSatisfaction = "Somewhat Satisfied";
        if (RDSatisfaction != "")
        {
            rdoRD7.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdoRD8_CheckedChanged(object sender, EventArgs e)
    {
        RDSatisfaction = "Dis Satisfied";
        if (RDSatisfaction != "")
        {
            rdoRD8.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdoRD9_CheckedChanged(object sender, EventArgs e)
    {
        RDSatisfaction = "Extremely Satisfied";
        if (RDSatisfaction != "")
        {
            rdoRD9.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }

    protected void rdbCashW9_CheckedChanged(object sender, EventArgs e)
    {
        CWSatisfaction = "Extremely Satisfied";
        if (CWSatisfaction != "")
        {
            rdbCashW9.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdbPassUpd1_CheckedChanged(object sender, EventArgs e)
    {
        PUTime = "03~05 m";
        if (PUTime != "")
        {
            rdbPassUpd1.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdbPassUpd2_CheckedChanged(object sender, EventArgs e)
    {
        PUTime = "05~10 m";
        if (PUTime != "")
        {
            rdbPassUpd2.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdbPassUpd3_CheckedChanged(object sender, EventArgs e)
    {
        PUTime = "10~15 m";
        if (PUTime != "")
        {
            rdbPassUpd3.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdbPassUpd4_CheckedChanged(object sender, EventArgs e)
    {
        PUTime = ">15 m";
        if (PUTime != "")
        {
            rdbPassUpd4.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdbPassUpd5_CheckedChanged(object sender, EventArgs e)
    {
        PUSatisfaction = "Extremely Satisfied";
        if (PUSatisfaction != "")
        {
            rdbPassUpd5.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdbPassUpd6_CheckedChanged(object sender, EventArgs e)
    {
        PUSatisfaction = "Satisfied";
        if (PUSatisfaction != "")
        {
            rdbPassUpd6.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdbPassUpd7_CheckedChanged(object sender, EventArgs e)
    {
        PUSatisfaction = "Somewhat Satisfied";
        if (PUSatisfaction != "")
        {
            rdbPassUpd7.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdbPassUpd8_CheckedChanged(object sender, EventArgs e)
    {
        PUSatisfaction = "Dis Satisfied";
        if (PUSatisfaction != "")
        {
            rdbPassUpd8.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdbPassUpd9_CheckedChanged(object sender, EventArgs e)
    {
        PUSatisfaction = "Extremely Satisfied";
        if (PUSatisfaction != "")
        {
            rdbPassUpd9.BorderStyle = BorderStyle.None;
            lblErr6.Text = "";
        }


    }
    protected void rdoRTGS1_CheckedChanged(object sender, EventArgs e)
    {
        RTGSTime = "10~15 m";
        if (RTGSTime != "")
        {
            rdoRTGS1.BorderStyle = BorderStyle.None;
            lblErr7.Text = "";
        }


    }
    protected void rdoRTGS2_CheckedChanged(object sender, EventArgs e)
    {
        RTGSTime = "15~30 m";
        if (RTGSTime != "")
        {
            lblErr7.Text = "";
        }


    }
    protected void rdoRTGS3_CheckedChanged(object sender, EventArgs e)
    {
        RTGSTime = "30~45 m";
        if (RTGSTime != "")
        {
            rdoRTGS3.BorderStyle = BorderStyle.None;
            lblErr7.Text = "";
        }


    }
    protected void rdoRTGS4_CheckedChanged(object sender, EventArgs e)
    {
        RTGSTime = "> 45 m";
        if (RTGSTime != "")
        {
            rdoRTGS4.BorderStyle = BorderStyle.None;
            lblErr7.Text = "";
        }


    }
    protected void rdoRTGS5_CheckedChanged(object sender, EventArgs e)
    {
        RTGSSatisfaction = "Extremely Satisfied";
        if (RTGSSatisfaction != "")
        {
            rdoRTGS5.BorderStyle = BorderStyle.None;
            lblErr7.Text = "";
        }


    }
    protected void rdoRTGS6_CheckedChanged(object sender, EventArgs e)
    {
        RTGSSatisfaction = "Satisfied";
        if (RTGSSatisfaction != "")
        {
            rdoRTGS6.BorderStyle = BorderStyle.None;
            lblErr7.Text = "";
        }


    }
    protected void rdoRTGS7_CheckedChanged(object sender, EventArgs e)
    {
        RTGSSatisfaction = "Somewhat Satisfied";
        if (RTGSSatisfaction != "")
        {
            rdoRTGS7.BorderStyle = BorderStyle.None;
            lblErr7.Text = "";
        }


    }
    protected void rdoRTGS8_CheckedChanged(object sender, EventArgs e)
    {
        RTGSSatisfaction = "Dis Satisfied";
        if (RTGSSatisfaction != "")
        {
            rdoRTGS8.BorderStyle = BorderStyle.None;
            lblErr7.Text = "";
        }


    }
    protected void rdoRTGS9_CheckedChanged(object sender, EventArgs e)
    {
        RTGSSatisfaction = "Extremely Satisfied";
        if (RTGSSatisfaction != "")
        {
            rdoRTGS9.BorderStyle = BorderStyle.None;
            lblErr7.Text = "";
        }


    }
    protected void rdoDD1_CheckedChanged(object sender, EventArgs e)
    {
        DDTime = "10~15 m";
        if (DDTime != "")
        {
            rdoDD1.BorderStyle = BorderStyle.None;
            lblErr7.Text = "";
        }


    }
    protected void rdoDD2_CheckedChanged(object sender, EventArgs e)
    {
        DDTime = "15~30 m";
        if (DDTime != "")
        {
            rdoDD2.BorderStyle = BorderStyle.None;
            lblErr7.Text = "";
        }


    }
    protected void rdoDD3_CheckedChanged(object sender, EventArgs e)
    {
        DDTime = "30~45 m";
        if (DDTime != "")
        {
            rdoDD3.BorderStyle = BorderStyle.None;
            lblErr7.Text = "";
        }


    }
    protected void rdoDD4_CheckedChanged(object sender, EventArgs e)
    {
        DDTime = "> 45 m";
        if (DDTime != "")
        {
            rdoDD4.BorderStyle = BorderStyle.None;
            lblErr7.Text = "";
        }


    }
    protected void rdoDD5_CheckedChanged(object sender, EventArgs e)
    {
        DDSatisfaction = "Extremely Satisfied";
        if (DDSatisfaction != "")
        {
            rdoDD5.BorderStyle = BorderStyle.None;
            lblErr7.Text = "";
        }


    }
    protected void rdoDD6_CheckedChanged(object sender, EventArgs e)
    {
        DDSatisfaction = "Satisfied";
        if (DDSatisfaction != "")
        {
            rdoDD6.BorderStyle = BorderStyle.None;
            lblErr7.Text = "";
        }


    }
    protected void rdoDD7_CheckedChanged(object sender, EventArgs e)
    {
        DDSatisfaction = "Somewhat Satisfied";
        if (DDSatisfaction != "")
        {
            rdoDD7.BorderStyle = BorderStyle.None;
            lblErr7.Text = "";
        }


    }
    protected void rdoDD8_CheckedChanged(object sender, EventArgs e)
    {
        DDSatisfaction = "Dis Satisfied";
        if (DDSatisfaction != "")
        {
            rdoDD8.BorderStyle = BorderStyle.None;
            lblErr7.Text = "";
        }


    }
    protected void rdoDD9_CheckedChanged(object sender, EventArgs e)
    {
        DDSatisfaction = "Extremely Satisfied";
        if (DDSatisfaction != "")
        {
            rdoDD9.BorderStyle = BorderStyle.None;
            lblErr7.Text = "";
        }


    }
    protected void rdoBills1_CheckedChanged(object sender, EventArgs e)
    {
        BillDay = "1 d";
        if (BillDay != "")
        {
            rdoBills1.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoBills2_CheckedChanged(object sender, EventArgs e)
    {
        BillDay = "2 d";
        if (BillDay != "")
        {
            rdoBills2.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoBills3_CheckedChanged(object sender, EventArgs e)
    {
        BillDay = "3 d";
        if (BillDay != "")
        {
            rdoBills3.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoBills4_CheckedChanged(object sender, EventArgs e)
    {
        BillDay = "> 3 d";
        if (BillDay != "")
        {
            rdoBills4.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoBills5_CheckedChanged(object sender, EventArgs e)
    {
        BillSatisfaction = "Extremely Satisfied";
        if (BillSatisfaction != "")
        {
            rdoBills5.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoBills6_CheckedChanged(object sender, EventArgs e)
    {
        BillSatisfaction = "Satisfied";
        if (BillSatisfaction != "")
        {
            rdoBills6.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoBills7_CheckedChanged(object sender, EventArgs e)
    {
        BillSatisfaction = "Somewhat Satisfied";
        if (BillSatisfaction != "")
        {
            rdoBills7.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoBills8_CheckedChanged(object sender, EventArgs e)
    {
        BillSatisfaction = "Dis Satisfied";
        if (BillSatisfaction != "")
        {
            rdoBills8.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoBills9_CheckedChanged(object sender, EventArgs e)
    {
        BillSatisfaction = "Extremely Satisfied";
        if (BillSatisfaction != "")
        {
            rdoBills9.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }

    protected void rdoCh1_CheckedChanged(object sender, EventArgs e)
    {
        ChqDay = "1 d";
        if (ChqDay != "")
        {
            rdoCh1.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoCh2_CheckedChanged(object sender, EventArgs e)
    {
        ChqDay = "2 d";
        if (ChqDay != "")
        {
            rdoCh2.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoCh3_CheckedChanged(object sender, EventArgs e)
    {
        ChqDay = "3 d";
        if (ChqDay != "")
        {
            rdoCh3.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoCh4_CheckedChanged(object sender, EventArgs e)
    {
        ChqDay = "> 3 d";
        if (ChqDay != "")
        {
            rdoCh4.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoCh5_CheckedChanged(object sender, EventArgs e)
    {
        ChqSatisfaction = "Extremely Satisfied";
        if (ChqSatisfaction != "")
        {
            rdoCh5.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoCh6_CheckedChanged(object sender, EventArgs e)
    {
        ChqSatisfaction = "Satisfied";
        if (ChqSatisfaction != "")
        {
            rdoCh6.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoCh7_CheckedChanged(object sender, EventArgs e)
    {
        ChqSatisfaction = "Somewhat Satisfied";
        if (ChqSatisfaction != "")
        {
            rdoCh7.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoCh8_CheckedChanged(object sender, EventArgs e)
    {
        ChqSatisfaction = "Dis Satisfied";
        if (ChqSatisfaction != "")
        {
            rdoCh8.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoCh9_CheckedChanged(object sender, EventArgs e)
    {
        ChqSatisfaction = "Extremely Satisfied";
        if (ChqSatisfaction != "")
        {
            rdoCh9.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoClrTran1_CheckedChanged(object sender, EventArgs e)
    {
        ClrTranDay = "1 d";
        if (ClrTranDay != "")
        {
            rdoClrTran1.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoClrTran2_CheckedChanged(object sender, EventArgs e)
    {
        ClrTranDay = "2 d";
        if (ClrTranDay != "")
        {
            rdoClrTran2.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoClrTran3_CheckedChanged(object sender, EventArgs e)
    {
        ClrTranDay = "3 d";
        if (ClrTranDay != "")
        {
            rdoClrTran3.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoClrTran4_CheckedChanged(object sender, EventArgs e)
    {
        ClrTranDay = "> 3 d";
        if (ClrTranDay != "")
        {
            rdoClrTran4.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoClrTran5_CheckedChanged(object sender, EventArgs e)
    {
        ClrTranSatisfaction = "Extremely Satisfied";
        if (ClrTranSatisfaction != "")
        {
            rdoClrTran5.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoClrTran6_CheckedChanged(object sender, EventArgs e)
    {
        ClrTranSatisfaction = "Satisfied";
        if (ClrTranSatisfaction != "")
        {
            rdoClrTran6.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoClrTran7_CheckedChanged(object sender, EventArgs e)
    {
        ClrTranSatisfaction = "Somewhat Satisfied";
        if (ClrTranSatisfaction != "")
        {
            rdoClrTran7.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoClrTran8_CheckedChanged(object sender, EventArgs e)
    {
        ClrTranSatisfaction = "Dis Satisfied";
        if (ClrTranSatisfaction != "")
        {
            rdoClrTran8.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }
    protected void rdoClrTran9_CheckedChanged(object sender, EventArgs e)
    {
        ClrTranSatisfaction = "Extremely Satisfied";
        if (ClrTranSatisfaction != "")
        {
            rdoClrTran9.BorderStyle = BorderStyle.None;
            lblErr8.Text = "";
        }


    }

    protected void rdoATM1_CheckedChanged(object sender, EventArgs e)
    {
        ATMUse = "Yes";
        if (ATMUse != "")
        {
            rdoATM3.Enabled = true;
            rdoATM4.Enabled = true;
            rdoATM5.Enabled = true;
            rdoATM6.Enabled = true;
            rdoATM7.Enabled = true;
            rdoATM1.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }
    protected void rdoATM2_CheckedChanged(object sender, EventArgs e)
    {
        ATMUse = "No";
        if (ATMUse != "")
        {

            rdoATM3.Checked = false;
            rdoATM4.Checked = false;
            rdoATM5.Checked = false;
            rdoATM5.Checked = false;
            rdoATM6.Checked = false;

            rdoATM3.Enabled = false;
            rdoATM4.Enabled = false;
            rdoATM5.Enabled = false;
            rdoATM5.Enabled = false;
            rdoATM6.Enabled = false;
            
            rdoATM7.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }

    protected void rdoATM3_CheckedChanged(object sender, EventArgs e)
    {
        ATMSatisfaction = "Extremely Satisfied";
        if (ATMSatisfaction != "")
        {
            rdoATM3.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }
    protected void rdoATM4_CheckedChanged(object sender, EventArgs e)
    {
        ATMSatisfaction = "Satisfied";
        if (ATMSatisfaction != "")
        {
            rdoATM4.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }
    protected void rdoATM5_CheckedChanged(object sender, EventArgs e)
    {
        ATMSatisfaction = "Somewhat Satisfied";
        if (ATMSatisfaction != "")
        {
            rdoATM5.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }
    protected void rdoATM6_CheckedChanged(object sender, EventArgs e)
    {
        ATMSatisfaction = "Dis Satisfied";
        if (ATMSatisfaction != "")
        {
            rdoATM6.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }
    protected void rdoATM7_CheckedChanged(object sender, EventArgs e)
    {
        ATMSatisfaction = "Extremely Satisfied";
        if (ATMSatisfaction != "")
        {
            rdoATM7.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }
    protected void rdoBS1_CheckedChanged(object sender, EventArgs e)
    {
        BSUse = "Yes";
        if (BSUse != "")
        {
            rdoBS3.Enabled = true;
            rdoBS4.Enabled = true;
            rdoBS5.Enabled = true;
            rdoBS6.Enabled = true;
            rdoBS7.Enabled = true;
            rdoBS1.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }
    protected void rdoBS2_CheckedChanged(object sender, EventArgs e)
    {
        BSUse = "No";
        if (BSUse != "")
        {
           

            rdoBS3.Checked = false;
            rdoBS4.Checked = false;
            rdoBS5.Checked = false;
            rdoBS6.Checked = false;
            rdoBS7.Checked = false;

            rdoBS3.Enabled = false;
            rdoBS4.Enabled = false;
            rdoBS5.Enabled = false;
            rdoBS6.Enabled = false;
            rdoBS7.Enabled = false;
            rdoBS2.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }

    protected void rdoBS3_CheckedChanged(object sender, EventArgs e)
    {
        BSSatisfaction = "Extremely Satisfied";
        if (BSSatisfaction != "")
        {
            rdoBS3.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }
    protected void rdoBS4_CheckedChanged(object sender, EventArgs e)
    {
        BSSatisfaction = "Satisfied";
        if (BSSatisfaction != "")
        {
            rdoBS4.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }
    protected void rdoBS5_CheckedChanged(object sender, EventArgs e)
    {
        BSSatisfaction = "Somewhat Satisfied";
        if (BSSatisfaction != "")
        {
            rdoBS5.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }
    protected void rdoBS6_CheckedChanged(object sender, EventArgs e)
    {
        BSSatisfaction = "Dis Satisfied";
        if (BSSatisfaction != "")
        {
            rdoBS6.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }
    protected void rdoBS7_CheckedChanged(object sender, EventArgs e)
    {
        BSSatisfaction = "Extremely Satisfied";
        if (BSSatisfaction != "")
        {
            rdoBS7.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }
    protected void rdoIB1_CheckedChanged(object sender, EventArgs e)
    {
        IBUse = "Yes";
        if (IBUse != "")
        {
            rdoIB3.Enabled = true;
            rdoIB4.Enabled = true;
            rdoIB5.Enabled = true;
            rdoIB6.Enabled = true;
            rdoIB7.Enabled = true;
            rdoIB1.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }
    protected void rdoIB2_CheckedChanged(object sender, EventArgs e)
    {
        IBUse = "No";
        if (IBUse != "")
        {

            rdoIB3.Checked = false;
            rdoIB4.Checked = false;
            rdoIB5.Checked = false;
            rdoIB6.Checked = false;
            rdoIB7.Checked = false;

            rdoIB3.Enabled = false;
            rdoIB4.Enabled = false;
            rdoIB5.Enabled = false;
            rdoIB6.Enabled = false;
            rdoIB7.Enabled = false;

            rdoIB2.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }

    protected void rdoIB3_CheckedChanged(object sender, EventArgs e)
    {
        IBSatisfaction = "Extremely Satisfied";
        if (IBSatisfaction != "")
        {
            rdoIB3.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }
    protected void rdoIB4_CheckedChanged(object sender, EventArgs e)
    {
        IBSatisfaction = "Satisfied";
        if (IBSatisfaction != "")
        {
            rdoIB4.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }
    protected void rdoIB5_CheckedChanged(object sender, EventArgs e)
    {
        IBSatisfaction = "Somewhat Satisfied";
        if (IBSatisfaction != "")
        {
            rdoIB5.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }
    protected void rdoIB6_CheckedChanged(object sender, EventArgs e)
    {
        IBSatisfaction = "Dis Satisfied";
        if (IBSatisfaction != "")
        {
            rdoIB6.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }
    protected void rdoIB7_CheckedChanged(object sender, EventArgs e)
    {
        IBSatisfaction = "Extremely Satisfied";
        if (IBSatisfaction != "")
        {
            
            rdoIB7.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }
    protected void rdoMB1_CheckedChanged(object sender, EventArgs e)
    {
        MBUse = "Yes";
        if (MBUse != "")
        {
            rdoMB3.Enabled = true;
            rdoMB4.Enabled = true;
            rdoMB5.Enabled = true;
            rdoMB6.Enabled = true;
            rdoMB7.Enabled = true;
            rdoMB1.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }
    protected void rdoMB2_CheckedChanged(object sender, EventArgs e)
    {
        MBUse = "No";
        if (MBUse != "")
        {
            
            rdoMB3.Checked = false;
            rdoMB4.Checked = false;
            rdoMB5.Checked = false;
            rdoMB6.Checked = false;
            rdoMB7.Checked = false;

            rdoMB3.Enabled = false;
            rdoMB4.Enabled = false;
            rdoMB5.Enabled = false;
            rdoMB6.Enabled = false;
            rdoMB7.Enabled = false;

            rdoMB2.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }

    protected void rdoMB3_CheckedChanged(object sender, EventArgs e)
    {
        MBSatisfaction = "Extremely Satisfied";
        if (MBSatisfaction != "")
        {
            rdoMB3.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }
    protected void rdoMB4_CheckedChanged(object sender, EventArgs e)
    {
        MBSatisfaction = "Satisfied";
        if (MBSatisfaction != "")
        {
            rdoMB4.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }
    protected void rdoMB5_CheckedChanged(object sender, EventArgs e)
    {
        MBSatisfaction = "Somewhat Satisfied";
        if (MBSatisfaction != "")
        {
            rdoMB5.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }
    protected void rdoMB6_CheckedChanged(object sender, EventArgs e)
    {
        MBSatisfaction = "Dis Satisfied";
        if (MBSatisfaction != "")
        {
            rdoMB6.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }
    protected void rdoMB7_CheckedChanged(object sender, EventArgs e)
    {
        MBSatisfaction = "Extremely Satisfied";
        if (MBSatisfaction != "")
        {
            rdoMB7.BorderStyle = BorderStyle.None;
            lblErr9.Text = "";
        }


    }

    protected void rdoSTC1_CheckedChanged(object sender, EventArgs e)
    {
        SppedTrnSat = "Extremely Satisfied";
        if (SppedTrnSat != "")
        {
            rdoSTC1.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void rdoSTC2_CheckedChanged(object sender, EventArgs e)
    {
        SppedTrnSat = "Satisfied";
        if (SppedTrnSat != "")
        {
            rdoSTC2.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void rdoSTC3_CheckedChanged(object sender, EventArgs e)
    {
        SppedTrnSat = "Somewhat Satisfied";
        if (SppedTrnSat != "")
        {
            rdoSTC3.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void rdoSTC4_CheckedChanged(object sender, EventArgs e)
    {
        SppedTrnSat = "Dis Satisfied";
        if (SppedTrnSat != "")
        {
            rdoSTC4.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void rdoSTC5_CheckedChanged(object sender, EventArgs e)
    {
        SppedTrnSat = "Extremely Satisfied";
        if (SppedTrnSat != "")
        {
            rdoSTC5.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }

    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        CorrectSat = "Extremely Satisfied";
        if (CorrectSat != "")
        {
            RadioButton1.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        CorrectSat = "Satisfied";
        if (CorrectSat != "")
        {
            RadioButton2.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        CorrectSat = "Somewhat Satisfied";
        if (CorrectSat != "")
        {
            RadioButton3.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
    {
        CorrectSat = "Dis Satisfied";
        if (CorrectSat != "")
        {
            RadioButton4.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton5_CheckedChanged(object sender, EventArgs e)
    {
        CorrectSat = "Extremely Satisfied";
        if (CorrectSat != "")
        {
            RadioButton5.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }

    protected void RadioButton6_CheckedChanged(object sender, EventArgs e)
    {
        BehaviourSat = "Extremely Satisfied";
        if (BehaviourSat != "")
        {
            RadioButton6.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }



    }
    protected void RadioButton7_CheckedChanged(object sender, EventArgs e)
    {
        BehaviourSat = "Satisfied";
        if (BehaviourSat != "")
        {
            RadioButton7.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton8_CheckedChanged(object sender, EventArgs e)
    {
        BehaviourSat = "Somewhat Satisfied";
        if (BehaviourSat != "")
        {
            RadioButton8.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton9_CheckedChanged(object sender, EventArgs e)
    {
        BehaviourSat = "Dis Satisfied";
        if (BehaviourSat != "")
        {
            RadioButton9.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton10_CheckedChanged(object sender, EventArgs e)
    {
        BehaviourSat = "Extremely Satisfied";
        if (BehaviourSat != "")
        {
            RadioButton10.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton11_CheckedChanged(object sender, EventArgs e)
    {
        KnoBankstaffSat = "Extremely Satisfied";
        if (KnoBankstaffSat != "")
        {
            RadioButton11.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton12_CheckedChanged(object sender, EventArgs e)
    {
        KnoBankstaffSat = "Satisfied";
        if (KnoBankstaffSat != "")
        {
            RadioButton12.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton13_CheckedChanged(object sender, EventArgs e)
    {
        KnoBankstaffSat = "Somewhat Satisfied";
        if (KnoBankstaffSat != "")
        {
            RadioButton13.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton14_CheckedChanged(object sender, EventArgs e)
    {
        KnoBankstaffSat = "Dis Satisfied";
        if (KnoBankstaffSat != "")
        {
            RadioButton14.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton15_CheckedChanged(object sender, EventArgs e)
    {
        KnoBankstaffSat = "Extremely Satisfied";
        if (KnoBankstaffSat != "")
        {
            RadioButton15.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }

    protected void RadioButton16_CheckedChanged(object sender, EventArgs e)
    {
        PunctualitySat = "Extremely Satisfied";
        if (PunctualitySat != "")
        {
            RadioButton16.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton17_CheckedChanged(object sender, EventArgs e)
    {
        PunctualitySat = "Satisfied";
        if (PunctualitySat != "")
        {
            RadioButton12.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton18_CheckedChanged(object sender, EventArgs e)
    {
        PunctualitySat = "Somewhat Satisfied";
        if (PunctualitySat != "")
        {
            RadioButton18.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton19_CheckedChanged(object sender, EventArgs e)
    {
        PunctualitySat = "Dis Satisfied";
        if (PunctualitySat != "")
        {
            RadioButton19.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton20_CheckedChanged(object sender, EventArgs e)
    {
        PunctualitySat = "Extremely Satisfied";
        if (PunctualitySat != "")
        {
            RadioButton20.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton21_CheckedChanged(object sender, EventArgs e)
    {
        AvailabilitySat = "Extremely Satisfied";
        if (AvailabilitySat != "")
        {
            RadioButton21.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton22_CheckedChanged(object sender, EventArgs e)
    {
        AvailabilitySat = "Satisfied";
        if (AvailabilitySat != "")
        {
            RadioButton22.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton23_CheckedChanged(object sender, EventArgs e)
    {
        AvailabilitySat = "Somewhat Satisfied";
        if (AvailabilitySat != "")
        {
            RadioButton23.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton24_CheckedChanged(object sender, EventArgs e)
    {
        AvailabilitySat = "Dis Satisfied";
        if (AvailabilitySat != "")
        {
            RadioButton24.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton25_CheckedChanged(object sender, EventArgs e)
    {
        AvailabilitySat = "Extremely Satisfied";
        if (AvailabilitySat != "")
        {
            RadioButton25.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }

    protected void RadioButton26_CheckedChanged(object sender, EventArgs e)
    {
        FacilitySat = "Extremely Satisfied";
        if (FacilitySat != "")
        {
            RadioButton26.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton27_CheckedChanged(object sender, EventArgs e)
    {
        FacilitySat = "Satisfied";
        if (FacilitySat != "")
        {
            RadioButton27.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton28_CheckedChanged(object sender, EventArgs e)
    {
        FacilitySat = "Somewhat Satisfied";
        if (FacilitySat != "")
        {
            RadioButton28.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton29_CheckedChanged(object sender, EventArgs e)
    {
        FacilitySat = "Dis Satisfied";
        if (FacilitySat != "")
        {
            RadioButton29.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }
    protected void RadioButton30_CheckedChanged(object sender, EventArgs e)
    {
        FacilitySat = "Extremely Satisfied";
        if (FacilitySat != "")
        {
            RadioButton30.BorderStyle = BorderStyle.None;
            lblErr11.Text = "";
        }


    }

    public void mail_appl()
    {
        ///''''''''''----------------Mail Code To Customer Service-----------------------''''''''''''''

        try
        {
            con.Close();
            con.Open();

            ///'''''''''''''''''''''''''''''' mail to Customer service

            MailAddress ma = new MailAddress(ConfigurationSettings.AppSettings["fromaddress"], "Webmaster");



            string strbody3 = "";
            //string imgurl = ConfigurationManager.AppSettings.Get("imgurl");

            strbody3 = "<html><head></head><body><table align=center border=0 cellpadding=0 cellspacing=0 style='width:68%; border:solid 1px; #18388c;' >";
            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
            strbody3 = strbody3 + "<tr><td colspan='3' align=left valign=top><img src='http://tmb2.cdn18.com/i/tmb_head_04.png'>";
            strbody3 = strbody3 + "</td></tr><br/>";



            strbody3 = strbody3 + "<tr><td colspan='3' align=center valign=middle style='width:68%; height:30px; font-family:Verdana; font-size:10pt; font-weight:bold; color:#ffffff;' bgcolor=#18388c> Customer Survey Acknowledgement</td></tr>";

            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";




            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Customer Name :  " + " " + Txtname.Text + ",";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Greetings from Tamilnad Mercantile Bank Ltd!";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

            if (ddlBranch.SelectedIndex > 0)
            {
                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Branch : " + ddlBranch.SelectedItem.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
            }
            else
            {
                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Branch : NA" + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
            }

            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Mobile No. is:<strong> " + txtMobile.Text + "<strong>";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";


            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Email : " + txtEmail.Text + ",";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";


            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Age : " + txtAge.Text + ",";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";


            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Gender : " + rdoGender.SelectedItem.Text + ",";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";



            if (rdoQues3.SelectedValue != "3")
            {
                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Account Type : " + rdoQues3.SelectedItem.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
            }

            if (rdoQues3.SelectedValue == "3")
            {
                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Account Type : " + txtOtherAccount.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
            }

            if (rdoQues4.SelectedValue != "6")
            {
                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Occupation : " + rdoQues4.SelectedItem.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
            }

            if (rdoQues4.SelectedValue == "6")
            {
                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Occupation : " + txtOtherOccupation.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
            }

            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Annual Income : " + rdoQues5.SelectedItem.Text + ",";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";




            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Social Network : " + rdoSocil.SelectedItem.Text + ",";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Comments/Suggestions : " + txtComments.Text + ",";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";





            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Thanking You,";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Webmaster";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Tamilnad Mercantile Bank Ltd.";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

            strbody3 = strbody3 + "</table></body></html>";






            MailMessage Mail_br1 = new MailMessage();
            Mail_br1.From = ma;
            Mail_br1.To.Add("vijayabhosale16@gmail.com");
            Mail_br1.Subject = "A new Customer Survey";
            Mail_br1.IsBodyHtml = true;
            Mail_br1.Body = strbody3;

            SmtpClient smtpMailObj2 = new SmtpClient();
            smtpMailObj2.EnableSsl = true;
            smtpMailObj2.Host = ConfigurationSettings.AppSettings["smtphost"];
            smtpMailObj2.Port = Convert.ToInt32(ConfigurationSettings.AppSettings["smtpport"]);
            smtpMailObj2.Credentials = new System.Net.NetworkCredential(ConfigurationSettings.AppSettings["smtpuser"], ConfigurationSettings.AppSettings["smtppassword"]);
            smtpMailObj2.Send(Mail_br1);


            //SmtpClient smtpMailObj2 = new SmtpClient();
            //smtpMailObj2.Host = "127.0.0.1";
            //smtpMailObj2.Port = 25;
            //smtpMailObj2.Send(Mail_br1);









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


    public void mail_PlanningTMB()
    {
        ///''''''''''----------------Mail Code To Customer Service-----------------------''''''''''''''

        try
        {
            con.Close();
            con.Open();

            ///'''''''''''''''''''''''''''''' mail to Customer service

            MailAddress ma = new MailAddress(ConfigurationSettings.AppSettings["fromaddress"], "Webmaster");



            string strbody3 = "";
            //string imgurl = ConfigurationManager.AppSettings.Get("imgurl");

            strbody3 = "<html><head></head><body><table align=center border=0 cellpadding=0 cellspacing=0 style='width:68%; border:solid 1px; #18388c;' >";
            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
            strbody3 = strbody3 + "<tr><td colspan='3' align=left valign=top><img src='http://tmb2.cdn18.com/i/tmb_head_04.png'>";
            strbody3 = strbody3 + "</td></tr><br/>";



            strbody3 = strbody3 + "<tr><td colspan='3' align=center valign=middle style='width:68%; height:30px; font-family:Verdana; font-size:10pt; font-weight:bold; color:#ffffff;' bgcolor=#18388c>Customer Survey Acknowledgement</td></tr>";

            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";


            if (ddlBranch.SelectedIndex > 0)
            {
                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Branch : " + ddlBranch.SelectedItem.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
            }
            else
            {
                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Branch : NA" + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
            }

            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Customer Name : " + " " + Txtname.Text.Trim() + ",";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Greetings from Tamilnad Mercantile Bank Ltd!";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Mobile No. is:<strong> " + txtMobile.Text.Trim() + "<strong>";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";


            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Email : " + txtEmail.Text.Trim() + ",";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";


            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Age : " + txtAge.Text.Trim() + ",";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Banking With TMB Since  : " + txtYears.Text.Trim() + " years" + txtMobile.Text.Trim() + " months" + ",";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            if (rdoQues3.SelectedValue != "3")
            {
                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Account Type : " + rdoQues3.SelectedItem.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
            }

            if (rdoQues3.SelectedValue == "3")
            {
                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Account Type : " + txtOtherAccount.Text.Trim() + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
            }

            if (rdoQues4.SelectedValue != "6")
            {
                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Occupation : " + rdoQues4.SelectedItem.Text + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
            }

            if (rdoQues4.SelectedValue == "6")
            {
                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Occupation : " + txtOtherOccupation.Text.Trim() + ",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";
            }

            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Annual Income : " + rdoQues5.SelectedItem.Text.Trim() + ",";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";


            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Social Network : " + rdoSocil.SelectedItem.Text + ",";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Comments/Suggestions : " + txtComments.Text.Trim() + ",";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";





            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Thanking You,";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Webmaster";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:48px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Tamilnad Mercantile Bank Ltd.";
            strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

            strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

            strbody3 = strbody3 + "</table></body></html>";






            MailMessage Mail_br1 = new MailMessage();
            Mail_br1.From = ma;
            Mail_br1.To.Add("vijayabhosale16@gmail.com");
            Mail_br1.Subject = "A new Customer Survey";
            Mail_br1.IsBodyHtml = true;
            Mail_br1.Body = strbody3;

            SmtpClient smtpMailObj2 = new SmtpClient();
            smtpMailObj2.EnableSsl = true;
            smtpMailObj2.Host = ConfigurationSettings.AppSettings["smtphost"];
            smtpMailObj2.Port = Convert.ToInt32(ConfigurationSettings.AppSettings["smtpport"]);
            smtpMailObj2.Credentials = new System.Net.NetworkCredential(ConfigurationSettings.AppSettings["smtpuser"], ConfigurationSettings.AppSettings["smtppassword"]);
            smtpMailObj2.Send(Mail_br1);


            //SmtpClient smtpMailObj2 = new SmtpClient();
            //smtpMailObj2.Host = "127.0.0.1";
            //smtpMailObj2.Port = 25;
            //smtpMailObj2.Send(Mail_br1);









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


    protected void btnnext1_Click(object sender, EventArgs e)
    {
        lblerror.Text = "";
        if (checkdata() == true)
        {

            divp1.Visible = false;
            divp2.Visible = false;
            div3.Visible = false;
            divp4.Visible = false;
            divp5.Visible = false;
            divp6.Visible = false;
            divp7.Visible = false;
            divp8.Visible = false;
            hr1.Visible = false;
            hr2.Visible = false;
            hr3.Visible = false;
            divnext1.Visible = false;
            divp9.Visible = true;
            hr4.Visible = true;
            divq3.Visible = true;
            divp10.Visible = true;
            hr5.Visible = true;
            divp11.Visible = true;
            hr6.Visible = true;
            divq4.Visible = false;
            hr7.Visible = true;
            divp12.Visible = true;
            hr8.Visible = true;
            divq5.Visible = true;
            divq4.Visible = true;
            divbtn2.Visible = true;
            btnnext1.Visible = false;
        }
    }

    protected void btnnext2_Click(object sender, EventArgs e)
    {
        if (chkQue345() == true)
        {
            divp9.Visible = false;
            hr4.Visible = false;
            divq3.Visible = false;
            divp10.Visible = false;
            hr5.Visible = false;
            divp11.Visible = false;
            hr6.Visible = false;
            divnext1.Visible = false;
            divq4.Visible = false;
            hr7.Visible = false;
            divp12.Visible = false;
            hr8.Visible = false;
            divq5.Visible = false;
            btnnext1.Visible = false;
            divbtn2.Visible = false;

            divp13.Visible = false;
            divp14.Visible = true;
            divp15.Visible = true;
            divp16.Visible = true;
            divq6.Visible = true;
            divq7.Visible = true;
            hr9.Visible = false;
            hr10.Visible = true;
            hr11.Visible = true;
            hr12.Visible = true;
            divbtn3.Visible = true;
        }

    }

    protected void btnext3_Click(object sender, EventArgs e)
    {
        if (chQue67() == true)
        {
            divp9.Visible = false;
            hr4.Visible = false;
            divq3.Visible = false;
            divp10.Visible = false;
            hr5.Visible = false;
            divp11.Visible = false;
            hr6.Visible = false;
            divq4.Visible = false;
            hr7.Visible = false;
            divp12.Visible = false;
            hr8.Visible = false;
            divnext1.Visible = false;
            divq5.Visible = false;
            btnnext1.Visible = false;
            divbtn2.Visible = false;

            divp13.Visible = false;
            divp14.Visible = false;
            divp15.Visible = false;
            divp16.Visible = false;
            divq6.Visible = false;
            divq7.Visible = false;
            hr9.Visible = false;
            hr10.Visible = false;
            hr11.Visible = false;
            hr12.Visible = false;
            divbtn3.Visible = false;

            divbtn4.Visible = true;
            divp16.Visible = false;
            divp17.Visible = false;
            divp18.Visible = true;
            divp19.Visible = true;
            divp20.Visible = true;


            divq8.Visible = true;
            divq9.Visible = true;
            hr13.Visible = false;
            hr14.Visible = true;
            hr15.Visible = true;
            hr16.Visible = true;
            divbtn4.Visible = true;

            Session["CDTime"] = CDTime;
            Session["CWTime"] = CWTime;
            Session["PUTime"] = PUTime;
            Session["RDTime"] = RDTime;

            Session["CDTime"] = CDSatisfaction;
            Session["CWTime"] = CWSatisfaction;
            Session["PUTime"] = PUSatisfaction;
            Session["RDTime"] = RDSatisfaction;

            Session["RTGSTime"] = RTGSTime;
            Session["DDTime"] = DDTime;

            Session["RTGSSatisfaction"] = RTGSSatisfaction;
            Session["DDSatisfaction"] = DDSatisfaction;
        }


    }

    protected void btnnex4_Click(object sender, EventArgs e)
    {
        if (chQue89() == true)
        {
            divp9.Visible = false;
            hr4.Visible = false;
            divq3.Visible = false;
            divp10.Visible = false;
            hr5.Visible = false;
            divp11.Visible = false;
            hr6.Visible = false;
            divq4.Visible = false;
            hr7.Visible = false;
            divp12.Visible = false;
            divnext1.Visible = false;
            hr8.Visible = false;
            divq5.Visible = false;
            btnnext1.Visible = false;
            divbtn2.Visible = false;

            divp13.Visible = false;
            divp14.Visible = false;
            divp15.Visible = false;
            divp16.Visible = false;
            divq6.Visible = false;
            divq7.Visible = false;
            hr9.Visible = false;
            hr10.Visible = false;
            hr11.Visible = false;
            hr12.Visible = false;
            divbtn3.Visible = false;

            divbtn4.Visible = false;
            divp16.Visible = false;
            divp17.Visible = false;
            divp18.Visible = false;
            divp19.Visible = false;
            divp20.Visible = false;


            divq8.Visible = false;
            divq9.Visible = false;
            hr13.Visible = false;
            hr14.Visible = false;
            hr15.Visible = false;
            hr16.Visible = false;
            divbtn4.Visible = false;

            divp21.Visible = false;
            divp22.Visible = true;
            divp23.Visible = true;
            divq101.Visible = true;
            divq102.Visible = true;
            divq103.Visible = true;
            divq104.Visible = true;
            divOtherLoan.Visible = true;
            hr17.Visible = false;
            hr18.Visible = true;
            hr19.Visible = true;
            hr19.Visible = true;
            divbtn5.Visible = true;
        }
    }

    protected void next5_Click(object sender, EventArgs e)
    {
        if (ChQue11() == true)
        {
            divp9.Visible = false;
            hr4.Visible = false;
            divq3.Visible = false;
            divp10.Visible = false;
            hr5.Visible = false;
            divp11.Visible = false;
            hr6.Visible = false;
            divq4.Visible = false;
            divnext1.Visible = false;
            hr7.Visible = false;
            divp12.Visible = false;
            hr8.Visible = false;
            divq5.Visible = false;
            btnnext1.Visible = false;
            divbtn2.Visible = false;

            divp13.Visible = false;
            divp14.Visible = false;
            divp15.Visible = false;
            divp16.Visible = false;
            divq6.Visible = false;
            divq7.Visible = false;
            hr9.Visible = false;
            hr10.Visible = false;
            hr11.Visible = false;
            hr12.Visible = false;
            divbtn3.Visible = false;

            divbtn4.Visible = false;
            divp16.Visible = false;
            divp17.Visible = false;
            divp18.Visible = false;
            divp19.Visible = false;
            divp20.Visible = false;


            divq8.Visible = false;
            divq9.Visible = false;
            hr13.Visible = false;
            hr14.Visible = false;
            hr15.Visible = false;
            hr16.Visible = false;
            divbtn4.Visible = false;

            divp21.Visible = false;
            divp22.Visible = false;
            divp23.Visible = false;
            divq101.Visible = false;
            divq102.Visible = false;
            divq103.Visible = false;
            divq104.Visible = false;
            divOtherLoan.Visible = false;
            hr17.Visible = false;
            hr18.Visible = false;
            hr19.Visible = false;
            hr19.Visible = false;
            divbtn5.Visible = false;

            divq11.Visible = true;
            div11.Visible = true;
            divp24.Visible = false;
            divp25.Visible = true;
            divp26.Visible = true;
            divp27.Visible = true;
            divp28.Visible = true;
            divp29.Visible = true;
            divp30.Visible = true;
            hr19.Visible = false;
            hr20.Visible = true;
            hr21.Visible = true;
            hr22.Visible = true;
            hr23.Visible = true;
            Btnsave.Visible = true;
            btnReset.Visible = true;
        }
    }

    protected void rdoGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoGender.SelectedIndex != -1)
        {
            lblerror.Text = "";
        }
    }
}