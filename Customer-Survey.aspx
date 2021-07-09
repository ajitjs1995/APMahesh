<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="Customer-Survey.aspx.cs" Inherits="Customer_Survey" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <link rel="stylesheet" href="css/style.css" type="text/css" media="screen">
    <link rel="stylesheet" href="css/vertical_menu.css" type="text/css" media="screen">
    <link rel="stylesheet" type="text/css" media="all" href="css/webslidemenu.css">
    <link rel="stylesheet" href="css/main.css" type="text/css">
    <link rel="stylesheet" href="css/homepage.css" type="text/css">
    <link rel="stylesheet" href="css/rates.css" type="text/css">
    <link rel="stylesheet" href="css/survey.css" type="text/css" media="screen">
    <script type="text/javascript">        
       

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        function isalphaKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode < 33 || charCode > 47 && charCode < 48 || charCode > 57) {
                return true;
            }
            return false;
        }
        function chk1Client() {
            debugger;
            var FullName = "^[a-zA-Z ]+$";

            var strErrorMessage = "";
            if (document.getElementById("<%=Txtname.ClientID %>").value.trim() == "") {
                strErrorMessage = "Enter full name.\n";
                alert(strErrorMessage);
                document.getElementById("<%=Txtname.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=Txtname.ClientID%>").style.borderColor = '#ff0000';
                return false;
            }
            else {

                document.getElementById("<%=Txtname.ClientID%>").style.background = '##fff';
                document.getElementById("<%=Txtname.ClientID%>").style.borderColor = '#a5a5a5';
            }
            if (document.getElementById("<%=Txtname.ClientID %>").value != "" && !document.getElementById("<%=Txtname.ClientID %>").value.match(FullName)) {
                strErrorMessage = "Full name should contain only alphabates.\n";
                alert(strErrorMessage);
                document.getElementById("<%=Txtname.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=Txtname.ClientID%>").style.borderColor = '#ff0000';
                return false;
            }
            else {

                document.getElementById("<%=Txtname.ClientID%>").style.background = '##fff';
                document.getElementById("<%=Txtname.ClientID%>").style.borderColor = '#a5a5a5';
            }

            if (document.getElementById("<%=txtMobile.ClientID %>").value != "" && !document.getElementById("<%=txtMobile.ClientID%>").value.match("^([7-9]{1})([0-9]{9})$")) {

                strErrorMessage = "Enter valid 10 digits mobile number\n";
                alert(strErrorMessage);
                document.getElementById("<%=txtMobile.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=txtMobile.ClientID%>").style.borderColor = '#ff0000';
                return false;
            }
            else {
                document.getElementById("<%=txtMobile.ClientID%>").style.background = '##fff';
                document.getElementById("<%=txtMobile.ClientID%>").style.borderColor = '#a5a5a5';
            }

            if (document.getElementById("<%=txtEmail.ClientID %>").value.trim() == "") {
                strErrorMessage = "Enter email-id.\n";
                alert(strErrorMessage);
                document.getElementById("<%=txtEmail.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = '#ff0000';
                return false;
            }
            else {
                document.getElementById("<%=txtEmail.ClientID%>").style.background = '##fff';
                document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = '#a5a5a5';
            }


            if (document.getElementById("<%=txtEmail.ClientID %>").value != "" && !document.getElementById("<%=txtEmail.ClientID%>").value.match("^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$")) {
                strErrorMessage = "Enter valid email-id.\n";
                alert(strErrorMessage);
                document.getElementById("<%=txtEmail.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = '#ff0000';
                return false;
            }
            else {

                document.getElementById("<%=txtEmail.ClientID%>").style.background = '##fff';
                document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = '#a5a5a5';
            }
            if (document.getElementById("<%=txtMonths.ClientID %>").value != "" && !document.getElementById("<%=txtMonths.ClientID%>").value.match("^[1-9]{1}[0-9]{1}$")) {
                strErrorMessage = "Enter valid months.\n";
                alert(strErrorMessage);
                document.getElementById("<%=txtMonths.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=txtMonths.ClientID%>").style.borderColor = '#ff0000';
                return false;
            }
            else {

                document.getElementById("<%=txtMonths.ClientID%>").style.background = '##fff';
                document.getElementById("<%=txtMonths.ClientID%>").style.borderColor = '#a5a5a5';
            }
            if (document.getElementById("<%=txtYears.ClientID %>").value != "" && !document.getElementById("<%=txtYears.ClientID%>").value.match("^[1-9]{1}[0-9]{1}$")) {
                strErrorMessage = "Enter valid years.\n";
                alert(strErrorMessage);
                document.getElementById("<%=txtYears.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=txtYears.ClientID%>").style.borderColor = '#ff0000';
                return false;
            }
            else {

                document.getElementById("<%=txtYears.ClientID%>").style.background = '##fff';
                document.getElementById("<%=txtYears.ClientID%>").style.borderColor = '#a5a5a5';
            }
            var rbg = document.getElementById("<%=rdoGender.ClientID %>");
            var rbGen = rbg.getElementsByTagName("input");
            var Gender = "";
            for (var i = 0; i < rbGen.length; i++) {
                if (rbGen[i].checked) {
                    Gender = rbGen[i].value;
                }
            }

            if (Gender == "") {
                strErrorMessage += "Please Select Gender";
                alert(strErrorMessage);
                document.getElementById("<%=rdoGender.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=rdoGender.ClientID%>").style.borderColor = '#ff0000'

                return false;
            }
            else {

                document.getElementById("<%=rdoGender.ClientID%>").style.background = '##fff';
                document.getElementById("<%=rdoGender.ClientID%>").style.borderColor = '#a5a5a5';
            }
            return confirm("Want to Submit Details?\n\nClick 'OK' to Submit Details. Click 'CANCEL' to recheck.");

            return true;
        }


        function chk345Client() {
            debugger;
            var strErrorMessage = "";

            var rbAccType = document.getElementById("<%=rdoQues3.ClientID %>");
            var AT = rbAccType.getElementsByTagName("input");
            var AccType = "";
            for (var i = 0; i < AT.length; i++) {
                if (AT[i].checked) {
                    AccType = AT[i].value;
                }
            }

            if (AccType == "") {
                strErrorMessage += "Please Select Account Type";
                alert(strErrorMessage);
                document.getElementById("<%=rdoQues3.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=rdoQues3.ClientID%>").style.borderColor = '#ff0000'

                return false;
            }
            else {

                document.getElementById("<%=rdoQues3.ClientID%>").style.background = '##fff';
                document.getElementById("<%=rdoQues3.ClientID%>").style.borderColor = '#a5a5a5';
            }
            if (AccType == "3" && document.getElementById("<%=txtOtherAccount.ClientID %>").value.trim() == "") {
                strErrorMessage += "Please Enter Account Type";
                alert(strErrorMessage);
                document.getElementById("<%=txtOtherAccount.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=txtOtherAccount.ClientID%>").style.borderColor = '#ff0000'

                return false;
            }
            else {

                document.getElementById("<%=txtOtherAccount.ClientID%>").style.background = '##fff';
                document.getElementById("<%=txtOtherAccount.ClientID%>").style.borderColor = '#a5a5a5';
            }
            if (AccType == "3" && document.getElementById("<%=txtOtherAccount.ClientID %>").value.trim() != "" && !document.getElementById("<%=Txtname.ClientID %>").value.match(FullName)) {
                strErrorMessage += "Please  Account type should contain only alphabates !!";
                alert(strErrorMessage);
                document.getElementById("<%=txtOtherAccount.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=txtOtherAccount.ClientID%>").style.borderColor = '#ff0000'

                return false;
            }
            else {

                document.getElementById("<%=txtOtherAccount.ClientID%>").style.background = '##fff';
                document.getElementById("<%=txtOtherAccount.ClientID%>").style.borderColor = '#a5a5a5';
            }
            var rbAccuptn = document.getElementById("<%=rdoQues4.ClientID %>");
            var OCP = rbAccuptn.getElementsByTagName("input");
            var Occupation = "";
            for (var i = 0; i < OCP.length; i++) {
                if (OCP[i].checked) {
                    Occupation = OCP[i].value;
                }
            }


            if (Occupation == "") {
                strErrorMessage += "Please Select Occupation";
                alert(strErrorMessage);
                document.getElementById("<%=rdoQues4.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=rdoQues4.ClientID%>").style.borderColor = '#ff0000'

                return false;
            }
            else {

                document.getElementById("<%=rdoQues4.ClientID%>").style.background = '##fff';
                document.getElementById("<%=rdoQues4.ClientID%>").style.borderColor = '#a5a5a5';
            }
            if (Occupation == "6" && document.getElementById("<%=txtOtherOccupation.ClientID %>").value.trim() == "") {
                strErrorMessage += "Please Enter Occupation";
                alert(strErrorMessage);
                document.getElementById("<%=txtOtherOccupation.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=txtOtherOccupation.ClientID%>").style.borderColor = '#ff0000'

                return false;
            }
            else {

                document.getElementById("<%=txtOtherOccupation.ClientID%>").style.background = '##fff';
                document.getElementById("<%=txtOtherOccupation.ClientID%>").style.borderColor = '#a5a5a5';
            }

            var rbAIncome = document.getElementById("<%=rdoQues5.ClientID %>");
            var AnnIncome = rbAIncome.getElementsByTagName("input");
            var AnnualIncomne = "";
            for (var i = 0; i < AnnIncome.length; i++) {
                if (AnnIncome[i].checked) {
                    AnnualIncomne = AnnIncome[i].value;
                }
            }

            if (AnnualIncomne == "") {
                strErrorMessage += "Please Select Annual Income";
                alert(strErrorMessage);
                document.getElementById("<%=rdoQues5.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=rdoQues5.ClientID%>").style.borderColor = '#ff0000'

                return false;
            }
            else {

                document.getElementById("<%=rdoQues5.ClientID%>").style.background = '##fff';
                document.getElementById("<%=rdoQues5.ClientID%>").style.borderColor = '#a5a5a5';
            }
            return confirm("Want to Submit Details?\n\nClick 'OK' to Submit Details. Click 'CANCEL' to recheck.");

            return true;

        }

        function chk67Client()
        {
            debugger;
            var strErrorMessage = "";

            var rbCDT1 = document.getElementById("<%=rdbCashD1.ClientID %>");
            var rbCDT2 = document.getElementById("<%=rdbCashD2.ClientID %>");
            var rbCDT3 = document.getElementById("<%=rdbCashD3.ClientID %>");
            var rbCDT4 = document.getElementById("<%=rdbCashD4.ClientID %>");


            if (rbCDT1.checked == false && rbCDT2.checked == false && rbCDT3.checked == false && rbCDT4.checked == false)
            {
                strErrorMessage += "Please select atleast one Option for time taken for Cash Deposits";
                alert(strErrorMessage);
                document.getElementById("<%=rdbCashD1.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=rdbCashD1.ClientID%>").style.borderColor = '#ff0000'

                return false;
            }

            else
            {

                document.getElementById("<%=rdbCashD1.ClientID%>").style.background = '##fff';
                document.getElementById("<%=rdbCashD1.ClientID%>").style.borderColor = '#a5a5a5';
            }
            var rbCDSat1 = document.getElementById("<%=rdbCashD5.ClientID %>");
            var rbCDSat2 = document.getElementById("<%=rdbCashD6.ClientID %>");
            var rbCDSat3 = document.getElementById("<%=rdbCashD7.ClientID %>");
            var rbCDSat4 = document.getElementById("<%=rdbCashD8.ClientID %>");
            var rbCDSat5 = document.getElementById("<%=rdbCashD9.ClientID %>");

            if (rbCDSat1.checked == false && rbCDSat2.checked == false && rbCDSat3.checked == false && rbCDSat4.checked == false && rbCDSat5.checked == false)
            {
                strErrorMessage += "Please select atleast one Option for satisfaction level of Cash Deposits";
                alert(strErrorMessage);
                document.getElementById("<%=rdbCashD5.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=rdbCashD5.ClientID%>").style.borderColor = '#ff0000'

                return false;
            }


            var rbCWT1 = document.getElementById("<%=rdbCashW1.ClientID %>");
            var rbCWT2 = document.getElementById("<%=rdbCashW2.ClientID %>");
            var rbCWT3 = document.getElementById("<%=rdbCashW3.ClientID %>");
            var rbCWT4 = document.getElementById("<%=rdbCashW4.ClientID %>");


            if (rbCWT1.checked == false && rbCWT2.checked == false && rbCWT3.checked == false && rbCWT4.checked == false)
            {
                strErrorMessage += "Please select atleast one Option for time taken for Cash Withdrwal";
                alert(strErrorMessage);
                document.getElementById("<%=rdbCashW1.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=rdbCashW1.ClientID%>").style.borderColor = '#ff0000'

                return false;
            }

            else
            {

                document.getElementById("<%=rdbCashW1.ClientID%>").style.background = '##fff';
                document.getElementById("<%=rdbCashW1.ClientID%>").style.borderColor = '#a5a5a5';
            }
            var rbCWSat1 = document.getElementById("<%=rdbCashW5.ClientID %>");
            var rbCWSat2 = document.getElementById("<%=rdbCashW6.ClientID %>");
            var rbCWSat3 = document.getElementById("<%=rdbCashW7.ClientID %>");
            var rbCWSat4 = document.getElementById("<%=rdbCashW8.ClientID %>");
            var rbCWSat5 = document.getElementById("<%=rdbCashW9.ClientID %>");

            if (rbCWSat1.checked == false && rbCWSat2.checked == false && rbCWSat3.checked == false && rbCWSat4.checked == false && rbCWSat5.checked == false)
            {
                strErrorMessage += "Please select atleast one Option for satisfaction level of Cash Withdrwal";
                alert(strErrorMessage);
                document.getElementById("<%=rdbCashW5.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=rdbCashW5.ClientID%>").style.borderColor = '#ff0000'

                return false;
            }


            var rbPU1 = document.getElementById("<%=rdbPassUpd1.ClientID %>");
            var rbPU2 = document.getElementById("<%=rdbPassUpd2.ClientID %>");
            var rbPU3 = document.getElementById("<%=rdbPassUpd3.ClientID %>");
            var rbPU4 = document.getElementById("<%=rdbPassUpd4.ClientID %>");


            if (rbPU1.checked == false && rbPU2.checked == false && rbPU3.checked == false && rbPU4.checked == false)
            {
                strErrorMessage += "Please select atleast one Option for time taken for Passbook Updation";
                alert(strErrorMessage);
                document.getElementById("<%=rdbPassUpd1.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=rdbPassUpd1.ClientID%>").style.borderColor = '#ff0000'

                return false;
            }

            else
            {

                document.getElementById("<%=rdbPassUpd1.ClientID%>").style.background = '##fff';
                document.getElementById("<%=rdbPassUpd1.ClientID%>").style.borderColor = '#a5a5a5';
            }
            var rbPUSat1 = document.getElementById("<%=rdbPassUpd5.ClientID %>");
            var rbPUSat2 = document.getElementById("<%=rdbPassUpd6.ClientID %>");
            var rbPUSat3 = document.getElementById("<%=rdbPassUpd7.ClientID %>");
            var rbPUSat4 = document.getElementById("<%=rdbPassUpd8.ClientID %>");
            var rbPUSat5 = document.getElementById("<%=rdbPassUpd9.ClientID %>");

            if (rbPUSat1.checked == false && rbPUSat2.checked == false && rbPUSat3.checked == false && rbPUSat4.checked == false && rbPUSat5.checked == false)
            {
                strErrorMessage += "Please select atleast one Option for satisfaction level of Passbook Updation";
                alert(strErrorMessage);
                document.getElementById("<%=rdbPassUpd5.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=rdbPassUpd5.ClientID%>").style.borderColor = '#ff0000'

                return false;
            }


            var rbRD1 = document.getElementById("<%=rdoRD1.ClientID %>");
            var rbRD2 = document.getElementById("<%=rdoRD2.ClientID %>");
            var rbRD3 = document.getElementById("<%=rdoRD3.ClientID %>");
            var rbRD4 = document.getElementById("<%=rdoRD4.ClientID %>");


            if (rbRD1.checked == false && rbRD2.checked == false && rbRD3.checked == false && rbRD4.checked == false)
            {
                strErrorMessage += "Please select atleast one Option for time taken for Issue / Renew Term Deposit";
                alert(strErrorMessage);
                document.getElementById("<%=rdoRD1.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=rdoRD1.ClientID%>").style.borderColor = '#ff0000'

                return false;
            }

            else
            {

                document.getElementById("<%=rdoRD1.ClientID%>").style.background = '##fff';
                document.getElementById("<%=rdoRD1.ClientID%>").style.borderColor = '#a5a5a5';
            }
            var rbRDSat1 = document.getElementById("<%=rdoRD5.ClientID %>");
            var rbRDSat2 = document.getElementById("<%=rdoRD6.ClientID %>");
            var rbRDSat3 = document.getElementById("<%=rdoRD7.ClientID %>");
            var rbRDSat4 = document.getElementById("<%=rdoRD8.ClientID %>");
            var rbRDSat5 = document.getElementById("<%=rdoRD9.ClientID %>");

            if (rbRDSat1.checked == false && rbRDSat2.checked == false && rbRDSat3.checked == false && rbRDSat4.checked == false && rbRDSat5.checked == false)
            {
                strErrorMessage += "Please select atleast one Option for satisfaction level of Issue / Renew Term Deposit";
                alert(strErrorMessage);
                document.getElementById("<%=rdoRD5.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=rdoRD5.ClientID%>").style.borderColor = '#ff0000'

                return false;
            }

            var RTGS1 = document.getElementById("<%=rdoRTGS1.ClientID %>");
            var RTGS2 = document.getElementById("<%=rdoRTGS2.ClientID %>");
            var RTGS3 = document.getElementById("<%=rdoRTGS3.ClientID %>");
            var RTGS4 = document.getElementById("<%=rdoRTGS4.ClientID %>");


            if (RTGS1.checked == false && RTGS2.checked == false && RTGS3.checked == false && RTGS4.checked == false)
            {
                strErrorMessage += "Please select atleast one Option for time taken for RTGS / NEFT Transfer";
                alert(strErrorMessage);
                document.getElementById("<%=rdoRTGS1.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=rdoRTGS1.ClientID%>").style.borderColor = '#ff0000'

                return false;
            }

            else
            {

                document.getElementById("<%=rdoRTGS1.ClientID%>").style.background = '##fff';
                document.getElementById("<%=rdoRTGS1.ClientID%>").style.borderColor = '#a5a5a5';
            }
            var RTGSSat1 = document.getElementById("<%=rdoRTGS5.ClientID %>");
            var RTGSSat2 = document.getElementById("<%=rdoRTGS6.ClientID %>");
            var RTGSSat3 = document.getElementById("<%=rdoRTGS7.ClientID %>");
            var RTGSSat4 = document.getElementById("<%=rdoRTGS8.ClientID %>");
            var RTGSSat5 = document.getElementById("<%=rdoRTGS9.ClientID %>");

            if (RTGSSat1.checked == false && RTGSSat2.checked == false && RTGSSat3.checked == false && RTGSSat4.checked == false && RTGSSat5.checked == false)
            {
                strErrorMessage += "Please select atleast one Option for satisfaction level of RTGS / NEFT Transfer";
                alert(strErrorMessage);
                document.getElementById("<%=rdoRTGS5.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=rdoRTGS5.ClientID%>").style.borderColor = '#ff0000'

                return false;
            }

            var DD1 = document.getElementById("<%=rdoDD1.ClientID %>");
            var DD2 = document.getElementById("<%=rdoDD2.ClientID %>");
            var DD3 = document.getElementById("<%=rdoDD3.ClientID %>");
            var DD4 = document.getElementById("<%=rdoDD4.ClientID %>");


            if (DD1.checked == false && DD2.checked == false && DD3.checked == false && DD4.checked == false)
            {
                strErrorMessage += "Please select atleast one Option for time taken for  Issue DD / PO";
                alert(strErrorMessage);
                document.getElementById("<%=rdoDD1.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=rdoDD1.ClientID%>").style.borderColor = '#ff0000'

                return false;
            }
            else
            {

                document.getElementById("<%=rdoDD1.ClientID%>").style.background = '##fff';
                document.getElementById("<%=rdoDD1.ClientID%>").style.borderColor = '#a5a5a5';
            }
            var DDSat1 = document.getElementById("<%=rdoDD5.ClientID %>");
            var DDSat2 = document.getElementById("<%=rdoDD6.ClientID %>");
            var DDSat3 = document.getElementById("<%=rdoDD7.ClientID %>");
            var DDSat4 = document.getElementById("<%=rdoDD8.ClientID %>");
            var DDSat5 = document.getElementById("<%=rdoDD9.ClientID %>");

            if (DDSat1.checked == false && DDSat2.checked == false && DDSat3.checked == false && DDSat4.checked == false && DDSat5.checked == false)
            {
                strErrorMessage += "Please select atleast one Option for satisfaction level for  Issue DD / PO";
                alert(strErrorMessage);
                document.getElementById("<%=rdoDD5.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=rdoDD5.ClientID%>").style.borderColor = '#ff0000'

                return false;
            }
            else
            {

                document.getElementById("<%=rdoDD5.ClientID%>").style.background = '##fff';
                document.getElementById("<%=rdoDD5.ClientID%>").style.borderColor = '#a5a5a5';
            }

            return confirm("Want to Submit Details?\n\nClick 'OK' to Submit Details. Click 'CANCEL' to recheck.");

            return true;
        }
     function chk89Client() {
            debugger;

            var Bills1 = document.getElementById("<%=rdoBills1.ClientID %>");
            var Bills2 = document.getElementById("<%=rdoBills2.ClientID %>");
            var Bills3 = document.getElementById("<%=rdoBills3.ClientID %>");
            var Bills4 = document.getElementById("<%=rdoBills4.ClientID %>");


         if (Bills1.checked == false && Bills2.checked == false && Bills3.checked == false && Bills4.checked == false)
         {
                strErrorMessage = "Please select atleast one Option for time taken for Bills Collection";
                alert(strErrorMessage);
                document.getElementById("<%=rdoBills1.ClientID%>").style.background = '#FFFF99';
             document.getElementById("<%=rdoBills1.ClientID%>").style.borderColor = '#ff0000';

                return false;
            }

         else
         {

                document.getElementById("<%=rdoBills1.ClientID%>").style.background = '##fff';
                document.getElementById("<%=rdoBills1.ClientID%>").style.borderColor = '#a5a5a5';
            }
            var BillsSat1 = document.getElementById("<%=rdoBills5.ClientID %>");
            var BillsSat2 = document.getElementById("<%=rdoBills6.ClientID %>");
            var BillsSat3 = document.getElementById("<%=rdoBills7.ClientID %>");
            var BillsSat4 = document.getElementById("<%=rdoBills8.ClientID %>");
            var BillsSat5 = document.getElementById("<%=rdoBills9.ClientID %>");

         if (BillsSat1.checked == false && BillsSat2.checked == false && BillsSat3.checked == false && BillsSat4.checked == false && BillsSat5.checked == false)
         {
                strErrorMessage = "Please select atleast one Option for satisfaction level of Bills Collection";
                alert(strErrorMessage);
                document.getElementById("<%=rdoBills5.ClientID%>").style.background = '#FFFF99';
             document.getElementById("<%=rdoBills5.ClientID%>").style.borderColor = '#ff0000';

                return false;
         }
         else {

             document.getElementById("<%=rdoBills5.ClientID%>").style.background = '##fff';
             document.getElementById("<%=rdoBills5.ClientID%>").style.borderColor = '#a5a5a5';
         }
            var Cheque1 = document.getElementById("<%=rdoCh1.ClientID %>");
            var Cheque2 = document.getElementById("<%=rdoCh2.ClientID %>");
            var Cheque3 = document.getElementById("<%=rdoCh3.ClientID %>");
            var Cheque4 = document.getElementById("<%=rdoCh4.ClientID %>");


         if (Cheque1.checked == false && Cheque2.checked == false && Cheque3.checked == false && Cheque4.checked == false)
         {
                strErrorMessage = "Please select atleast one Option for time taken for Cheque Collection";
                alert(strErrorMessage);
                document.getElementById("<%=rdoCh1.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=rdoCh1.ClientID%>").style.borderColor = '#ff0000';

                return false;
            }

            else {

                document.getElementById("<%=rdoCh1.ClientID%>").style.background = '##fff';
                document.getElementById("<%=rdoCh1.ClientID%>").style.borderColor = '#a5a5a5';
            }
            var ChequeSat1 = document.getElementById("<%=rdoCh5.ClientID %>");
            var ChequeSat2 = document.getElementById("<%=rdoCh6.ClientID %>");
            var ChequeSat3 = document.getElementById("<%=rdoCh7.ClientID %>");
            var ChequeSat4 = document.getElementById("<%=rdoCh8.ClientID %>");
            var ChequeSat5 = document.getElementById("<%=rdoCh9.ClientID %>");

         if (ChequeSat1.checked == false && ChequeSat2.checked == false && ChequeSat3.checked == false && ChequeSat4.checked == false && ChequeSat5.checked == false)
         {
                strErrorMessage = "Please select atleast one Option for satisfaction level of Cheque Collection";
                alert(strErrorMessage);
                document.getElementById("<%=rdoCh5.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=rdoCh5.ClientID%>").style.borderColor = '#ff0000';

                return false;
            }

            var ClrTran1 = document.getElementById("<%=rdoClrTran1.ClientID %>");
            var ClrTran2 = document.getElementById("<%=rdoClrTran2.ClientID %>");
            var ClrTran3 = document.getElementById("<%=rdoClrTran3.ClientID %>");
            var ClrTran4 = document.getElementById("<%=rdoClrTran4.ClientID %>");


         if (ClrTran1.checked == false && ClrTran2.checked == false && ClrTran3.checked == false && ClrTran4.checked == false)
         {
                strErrorMessage = "Please select atleast one Option for time taken for Clear Transaction";
                alert(strErrorMessage);
                document.getElementById("<%=rdoClrTran1.ClientID%>").style.background = '#FFFF99';
             document.getElementById("<%=rdoClrTran1.ClientID%>").style.borderColor = '#ff0000';

                return false;
            }

            else {

                document.getElementById("<%=rdoClrTran1.ClientID%>").style.background = '##fff';
                document.getElementById("<%=rdoClrTran1.ClientID%>").style.borderColor = '#a5a5a5';
            }
            var ClrTranSat1 = document.getElementById("<%=rdoClrTran5.ClientID %>");
            var ClrTranSat2 = document.getElementById("<%=rdoClrTran6.ClientID %>");
            var ClrTranSat3 = document.getElementById("<%=rdoClrTran7.ClientID %>");
            var ClrTranSat4 = document.getElementById("<%=rdoClrTran8.ClientID %>");
            var ClrTranSat5 = document.getElementById("<%=rdoClrTran9.ClientID %>");

         if (ClrTranSat1.checked == false && ClrTranSat2.checked == false && ClrTranSat3.checked == false && ClrTranSat4.checked == false && ClrTranSat5.checked == false)
         {
                strErrorMessage = "Please select atleast one Option for satisfaction level of ClrTran";
                alert(strErrorMessage);
                document.getElementById("<%=rdoClrTran5.ClientID%>").style.background = '#FFFF99';
             document.getElementById("<%=rdoClrTran5.ClientID%>").style.borderColor = '#ff0000';

                return false;
         }
         else {

             document.getElementById("<%=rdoClrTran5.ClientID%>").style.background = '##fff';
             document.getElementById("<%=rdoClrTran5.ClientID%>").style.borderColor = '#a5a5a5';
         }

            var ATMUse1 = document.getElementById("<%=rdoATM1.ClientID %>");
            var ATMUse2 = document.getElementById("<%=rdoATM2.ClientID %>");


         if (ATMUse1.checked == false && ATMUse2.checked == false)
         {
                strErrorMessage = "Are you using ATM Service";
                alert(strErrorMessage);
                document.getElementById("<%=rdoATM1.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=rdoATM1.ClientID%>").style.borderColor = '#ff0000';

                return false;
            }

            else {

                document.getElementById("<%=rdoATM1.ClientID%>").style.background = '##fff';
                document.getElementById("<%=rdoATM1.ClientID%>").style.borderColor = '#a5a5a5';
            }
          
            var ATMUseSat3 = document.getElementById("<%=rdoATM3.ClientID %>");
            var ATMUseSat4 = document.getElementById("<%=rdoATM4.ClientID %>");
            var ATMUseSat5 = document.getElementById("<%=rdoATM5.ClientID %>");
            var ATMUseSat6 = document.getElementById("<%=rdoATM6.ClientID %>");
            var ATMUseSat7 = document.getElementById("<%=rdoATM7.ClientID %>");
            

         if (ATMUse1.checked == true && ATMUseSat3.checked == false && ATMUseSat4.checked == false && ATMUseSat5.checked == false && ATMUseSat6.checked == false && ATMUseSat7.checked == false)
         {
                strErrorMessage = "Please select atleast one Option for satisfaction level of ATM Uses";
                alert(strErrorMessage);
                document.getElementById("<%=rdoATM5.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=rdoATM5.ClientID%>").style.borderColor = '#ff0000'

                return false;
         }
         else {

             document.getElementById("<%=rdoATM5.ClientID%>").style.background = '##fff';
             document.getElementById("<%=rdoATM5.ClientID%>").style.borderColor = '#a5a5a5';
         }


            var BSUse1 = document.getElementById("<%=rdoBS1.ClientID %>");
            var BSUse2 = document.getElementById("<%=rdoBS2.ClientID %>");


         if (BSUse1.checked == false && BSUse2.checked == false)
         {
                strErrorMessage = "Are you using Banking Services";
                alert(strErrorMessage);
                document.getElementById("<%=rdoBS1.ClientID%>").style.background = '#FFFF99';
             document.getElementById("<%=rdoBS1.ClientID%>").style.borderColor = '#ff0000';

                return false;
            }

         else
         {
                  document.getElementById("<%=rdoBS1.ClientID%>").style.background = '##fff';
                document.getElementById("<%=rdoBS1.ClientID%>").style.borderColor = '#a5a5a5';
          }
            var BSUseSat3= document.getElementById("<%=rdoBS3.ClientID %>");
            var BSUseSat4 = document.getElementById("<%=rdoBS4.ClientID %>");
            var BSUseSat5 = document.getElementById("<%=rdoBS5.ClientID %>");
            var BSUseSat6 = document.getElementById("<%=rdoBS6.ClientID %>");
            var BSUseSat7 = document.getElementById("<%=rdoBS7.ClientID %>");
           

         if (BSUse1.checked == true && BSUseSat3.checked == false && BSUseSat4.checked == false && BSUseSat5.checked == false && BSUseSat6.checked == false && BSUseSat7.checked == false)
         {
                strErrorMessage = "Please select atleast one Option for satisfaction level of Banking Services";
                alert(strErrorMessage);
                document.getElementById("<%=rdoBS5.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=rdoBS5.ClientID%>").style.borderColor = '#ff0000';
                return false;
          }
          else {

             document.getElementById("<%=rdoBS5.ClientID%>").style.background = '##fff';
             document.getElementById("<%=rdoBS5.ClientID%>").style.borderColor = '#a5a5a5';
         }

            var IBUse1 = document.getElementById("<%=rdoIB1.ClientID %>");
            var IBUse2 = document.getElementById("<%=rdoIB2.ClientID %>");


         if (IBUse1.checked == false && IBUse2.checked == false)
         {
                strErrorMessage = "Are you using Internet Banking Services";
                alert(strErrorMessage);
                document.getElementById("<%=rdoIB1.ClientID%>").style.background = '#FFFF99';
             document.getElementById("<%=rdoIB1.ClientID%>").style.borderColor = '#ff0000';

                return false;
          }
         else
         {

                document.getElementById("<%=rdoIB1.ClientID%>").style.background = '##fff';
                document.getElementById("<%=rdoIB1.ClientID%>").style.borderColor = '#a5a5a5';
          }


            var IBUseSat3 = document.getElementById("<%=rdoIB3.ClientID %>");
            var IBUseSat4 = document.getElementById("<%=rdoIB4.ClientID %>");
            var IBUseSat5 = document.getElementById("<%=rdoIB5.ClientID %>");
            var IBUseSat6 = document.getElementById("<%=rdoIB6.ClientID %>");
            var IBUseSat7 = document.getElementById("<%=rdoIB7.ClientID %>");


         if (IBUse1.checked == true && IBUseSat3.checked == false && IBUseSat4.checked == false && IBUseSat5.checked == false && IBUseSat6.checked == false && IBUseSat7.checked == false)
         {
                strErrorMessage = "Please select atleast one Option for satisfaction level of  Internet Banking Services";
                alert(strErrorMessage);
                document.getElementById("<%=rdoIB5.ClientID%>").style.background = '#FFFF99';
             document.getElementById("<%=rdoIB5.ClientID%>").style.borderColor = '#ff0000';

                return false;
         }
         else {

             document.getElementById("<%=rdoIB5.ClientID%>").style.background = '##fff';
             document.getElementById("<%=rdoIB5.ClientID%>").style.borderColor = '#a5a5a5';
         }

            var MBUse1 = document.getElementById("<%=rdoMB1.ClientID %>");
            var MBUse2 = document.getElementById("<%=rdoMB2.ClientID %>");


         if (MBUse1.checked == false && MBUse2.checked == false)
         {
                strErrorMessage = "Are you using Mobile Banking Services";
                alert(strErrorMessage);
                document.getElementById("<%=rdoMB1.ClientID%>").style.background = '#FFFF99';
             document.getElementById("<%=rdoMB1.ClientID%>").style.borderColor = '#ff0000';

                return false;
         }
           
            else {

                document.getElementById("<%=rdoMB1.ClientID%>").style.background = '##fff';
                document.getElementById("<%=rdoMB1.ClientID%>").style.borderColor = '#a5a5a5';
            }
            var MBUseSat3 = document.getElementById("<%=rdoMB3.ClientID %>");
            var MBUseSat4 = document.getElementById("<%=rdoMB4.ClientID %>");
            var MBUseSat5 = document.getElementById("<%=rdoMB5.ClientID %>");
            var MBUseSat6 = document.getElementById("<%=rdoMB6.ClientID %>");
            var MBUseSat7 = document.getElementById("<%=rdoMB7.ClientID %>");


         if (MBUse1.checked == true && MBUseSat3.checked == false && MBUseSat4.checked == false && MBUseSat5.checked == false && MBUseSat6.checked == false && MBUseSat7.checked == false)
         {
                strErrorMessage = "Please select atleast one Option for satisfaction level of  Mobile Banking Services";
                alert(strErrorMessage);
                document.getElementById("<%=rdoMB5.ClientID%>").style.background = '#FFFF99';
             document.getElementById("<%=rdoMB5.ClientID%>").style.borderColor = '#ff0000';

                return false;
            }
            else {

                document.getElementById("<%=rdoMB5.ClientID%>").style.background = '##fff';
                document.getElementById("<%=rdoMB5.ClientID%>").style.borderColor = '#a5a5a5';
            }
            return confirm("Want to Submit Details?\n\nClick 'OK' to Submit Details. Click 'CANCEL' to recheck.");

            return true;
        }

        function chklastClient()
        {
            var strErrorMessage;
            var STCSat1 = document.getElementById("<%=rdoSTC1.ClientID %>");
            var STCSat2 = document.getElementById("<%=rdoSTC2.ClientID %>");
            var STCSat3 = document.getElementById("<%=rdoSTC3.ClientID %>");
            var STCSat4 = document.getElementById("<%=rdoSTC4.ClientID %>");
            var STCSat5 = document.getElementById("<%=rdoSTC5.ClientID %>");


            if (STCSat1.checked == false && STCSat2.checked == false && STCSat3.checked == false && STCSat4.checked == false && STCSat5.checked == false)
            {
                strErrorMessage = "Please select atleast one Option for satisfaction level of  Speed of Transactions at Counters";
                alert(strErrorMessage);
                document.getElementById("<%=rdoSTC5.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=rdoSTC5.ClientID%>").style.borderColor = '#ff0000';

                return false;
            }
            else {

                document.getElementById("<%=rdoSTC5.ClientID%>").style.background = '##fff';
                document.getElementById("<%=rdoSTC5.ClientID%>").style.borderColor = '#a5a5a5';
            }


            var AccuracySat1 = document.getElementById("<%=RadioButton1.ClientID %>");
            var AccuracySat2 = document.getElementById("<%=RadioButton2.ClientID %>");
            var AccuracySat3 = document.getElementById("<%=RadioButton3.ClientID %>");
            var AccuracySat4 = document.getElementById("<%=RadioButton4.ClientID %>");
            var AccuracySat5 = document.getElementById("<%=RadioButton5.ClientID %>");


            if (AccuracySat1.checked == false && AccuracySat2.checked == false && AccuracySat3.checked == false && AccuracySat4.checked == false && AccuracySat5.checked == false)
            {
                strErrorMessage = "Please select atleast one Option for satisfaction level of  Correctness / Accuracy of Transactions";
                alert(strErrorMessage);
                document.getElementById("<%=RadioButton1.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=RadioButton1.ClientID%>").style.borderColor = '#ff0000';

                return false;
            }
            else {

                document.getElementById("<%=RadioButton1.ClientID%>").style.background = '##fff';
                document.getElementById("<%=RadioButton1.ClientID%>").style.borderColor = '#a5a5a5';
            }


            var BAStaffSat1 = document.getElementById("<%=RadioButton6.ClientID %>");
            var BAStaffSat2 = document.getElementById("<%=RadioButton7.ClientID %>");
            var BAStaffSat3 = document.getElementById("<%=RadioButton8.ClientID %>");
            var BAStaffSat4 = document.getElementById("<%=RadioButton9.ClientID %>");
            var BAStaffSat5 = document.getElementById("<%=RadioButton10.ClientID %>");


            if (BAStaffSat1.checked == false && BAStaffSat2.checked == false && BAStaffSat3.checked == false && BAStaffSat4.checked == false && BAStaffSat5.checked == false)
            {
                strErrorMessage = "Please select atleast one Option for satisfaction level of   Behaviour / Attitude of Bank Staff";
                alert(strErrorMessage);
                document.getElementById("<%=RadioButton6.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=RadioButton6.ClientID%>").style.borderColor = '#ff0000';

                return false;
            }
            else {

                document.getElementById("<%=RadioButton6.ClientID%>").style.background = '##fff';
                document.getElementById("<%=RadioButton6.ClientID%>").style.borderColor = '#a5a5a5';
            }


            var KOBstafffSat1 = document.getElementById("<%=RadioButton11.ClientID %>");
            var KOBstafffSat2 = document.getElementById("<%=RadioButton12.ClientID %>");
            var KOBstafffSat3 = document.getElementById("<%=RadioButton13.ClientID %>");
            var KOBstafffSat4 = document.getElementById("<%=RadioButton14.ClientID %>");
            var KOBstafffSat5 = document.getElementById("<%=RadioButton15.ClientID %>");


            if (KOBstafffSat1.checked == false && KOBstafffSat2.checked == false && KOBstafffSat3.checked == false && KOBstafffSat4.checked == false && KOBstafffSat5.checked == false)
            {
                strErrorMessage = "Please select atleast one Option for satisfaction level for Knowledge Level of Bank Staff";
                alert(strErrorMessage);
                document.getElementById("<%=RadioButton11.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=RadioButton11.ClientID%>").style.borderColor = '#ff0000';

                return false;
            }
            else {

                document.getElementById("<%=RadioButton11.ClientID%>").style.background = '##fff';
                document.getElementById("<%=RadioButton11.ClientID%>").style.borderColor = '#a5a5a5';
            }


            var PunctualitySat1 = document.getElementById("<%=RadioButton16.ClientID %>");
            var PunctualitySat2 = document.getElementById("<%=RadioButton17.ClientID %>");
            var PunctualitySat3 = document.getElementById("<%=RadioButton18.ClientID %>");
            var PunctualitySat4 = document.getElementById("<%=RadioButton19.ClientID %>");
            var PunctualitySat5 = document.getElementById("<%=RadioButton20.ClientID %>");


            if (PunctualitySat1.checked == false && PunctualitySat2.checked == false && PunctualitySat3.checked == false && PunctualitySat4.checked == false && PunctualitySat5.checked == false)
            {
                strErrorMessage = "Please select atleast one Option for satisfaction level Punctuality of Commencing Business in the branch";
                alert(strErrorMessage);
                document.getElementById("<%=RadioButton16.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=RadioButton16.ClientID%>").style.borderColor = '#ff0000';

                return false;
            }
            else {

                document.getElementById("<%=RadioButton16.ClientID%>").style.background = '##fff';
                document.getElementById("<%=RadioButton16.ClientID%>").style.borderColor = '#a5a5a5';
            }

            var AvailSat1 = document.getElementById("<%=RadioButton21.ClientID %>");
            var AvailSat2 = document.getElementById("<%=RadioButton22.ClientID %>");
            var AvailSat3 = document.getElementById("<%=RadioButton23.ClientID %>");
            var AvailSat4 = document.getElementById("<%=RadioButton24.ClientID %>");
            var AvailSat5 = document.getElementById("<%=RadioButton25.ClientID %>");


            if (AvailSat1.checked == false && AvailSat2.checked == false && AvailSat3.checked == false && AvailSat4.checked == false && AvailSat5.checked == false)
            {
                strErrorMessage = "Please select atleast one Option for satisfaction level Availability / Display of Information at Branches";
                alert(strErrorMessage);
                document.getElementById("<%=RadioButton21.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=RadioButton21.ClientID%>").style.borderColor = '#ff0000';

                return false;
            }
            else {

                document.getElementById("<%=RadioButton21.ClientID%>").style.background = '##fff';
                document.getElementById("<%=RadioButton21.ClientID%>").style.borderColor = '#a5a5a5';
            }


            var BasicFacSat1 = document.getElementById("<%=RadioButton26.ClientID %>");
            var BasicFacSat2 = document.getElementById("<%=RadioButton27.ClientID %>");
            var BasicFacSat3 = document.getElementById("<%=RadioButton28.ClientID %>");
            var BasicFacSat4 = document.getElementById("<%=RadioButton29.ClientID %>");
            var BasicFacSat5 = document.getElementById("<%=RadioButton30.ClientID %>");


            if (BasicFacSat1.checked == false && BasicFacSat2.checked == false && BasicFacSat3.checked == false && BasicFacSat4.checked == false && BasicFacSat5.checked == false)
            {
                strErrorMessage = "Please select atleast one Option for satisfaction level Basic Facilities";
                alert(strErrorMessage);
                document.getElementById("<%=RadioButton26.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=RadioButton26.ClientID%>").style.borderColor = '#ff0000';

                return false;
            }
            else {

                document.getElementById("<%=RadioButton26.ClientID%>").style.background = '##fff';
                document.getElementById("<%=RadioButton26.ClientID%>").style.borderColor = '#a5a5a5';
            }

            var rbSocil = document.getElementById("<%=rdoSocil.ClientID %>");
            var SocNW = rbSocil.getElementsByTagName("input");
            var SocialNetwork = "";
            for (var i = 0; i < SocNW.length; i++) {
                if (SocNW[i].checked) {
                    SocialNetwork = SocNW[i].value;
                }
            }

            if (SocialNetwork == "")
            {
                strErrorMessage = "Are you following us on social media";
                alert(strErrorMessage);
                document.getElementById("<%=rdoSocil.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=rdoSocil.ClientID%>").style.borderColor = '#ff0000';
                return false;
            }
            else {

                document.getElementById("<%=rdoSocil.ClientID%>").style.background = '##fff';
                document.getElementById("<%=rdoSocil.ClientID%>").style.borderColor = '#a5a5a5';
            }
            if (document.getElementById("<%=txtComments.ClientID%>").value != "" && !(document.getElementById("<%=txtComments.ClientID%>").value.match("^[a-zA-Z, & \n\r ]+$"))) {
                strErrorMessage = "Please enter valid comments";
                alert(strErrorMessage);
                document.getElementById("<%=txtComments.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=txtComments.ClientID%>").style.borderColor = '#ff0000';
                return false;
            }
            else {

                document.getElementById("<%=txtComments.ClientID%>").style.background = '##fff';
                document.getElementById("<%=txtComments.ClientID%>").style.borderColor = '#a5a5a5';
            }
            if (document.getElementById("<%=Txtcaptch.ClientID%>").value == "")
            {
                strErrorMessage = "Verification Code , should not be blank";
                alert(strErrorMessage);
                document.getElementById("<%=Txtcaptch.ClientID%>").style.background = '#FFFF99';
                document.getElementById("<%=Txtcaptch.ClientID%>").style.borderColor = '#ff0000';
                return false;
            }
            else {

                document.getElementById("<%=Txtcaptch.ClientID%>").style.background = '##fff';
                document.getElementById("<%=Txtcaptch.ClientID%>").style.borderColor = '#a5a5a5';
            }
            

            return confirm("Want to Submit Details?\n\nClick 'OK' to Submit Details. Click 'CANCEL' to recheck.");

            return true;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="blog">
        <div class="blog container" style="width: 92%;">
            <div class="row">
                <div class="col-md-9">
                    <h1 style="color: #ce1c7b; font-size: 28px;">Customer Survey</h1>
                    <h4>Dear Customer,</h4>

                    Thank you for banking with TMB. It is our endeavour to provide our customers the best possible services. In order to improve the customer satisfaction level, we request your valuable response on our services. Please spare a few seconds to answer this simple questionnaire. You may like to read our Survey Disclaimer noted below this form.
                        Thank you.
                   


                    <div class="tabbs">
                        <div class="applynow" id="fullcontact">
                            <p>
                                <asp:Label ID="lblerror" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </p>

                            <div class="form-group" id="divp1" runat="server">
                                <label for="" style="font-weight: 700">1. Branch:</label>
                                <asp:DropDownList ID="ddlBranch" runat="server" class="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="row" id="divp2" runat="server">
                                <div class="col-lg-12" style="padding-top: 15px;">
                                </div>
                            </div>
                            <hr style="margin: 10px -15px;" id="hr1" runat="server" />
                            <div class="row" id="div3" runat="server">
                                <div class="col-lg-12" style="padding-top: 15px;">
                                    <asp:Label ID="Label2" runat="server" CssClass="label2" Text="2. Let us know more about you and how we can connect with you. "
                                        Font-Bold="True"></asp:Label>
                                </div>
                            </div>

                            <hr style="margin: 10px -15px;" id="hr2" runat="server" />
                            <div class="applynow-outer" id="divp4" runat="server">
                                <div class="apply-fild-3of2">
                                    <label for="" style="font-weight: 700;">Name:</label>
                                    <asp:TextBox ID="Txtname" onkeypress="return isalphaKey(event)" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>
                                </div>
                                <div class="apply-fild-3of2">
                                    <label for="" style="font-weight: 700;">Mobile No:</label>
                                    <asp:TextBox ID="txtMobile" onkeypress="return isNumberKey(event)" MaxLength="10" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>
                                </div>

                            </div>
                            <div class="applynow-outer" id="divp5" runat="server">
                                <div class="apply-fild-3of2">
                                    <label for="" style="font-weight: 700;">Email:</label>
                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>
                                </div>
                                <div class="apply-fild-3of2">
                                    <label for="" style="font-weight: 700;">Age:</label>
                                    <asp:TextBox ID="txtAge" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumberKey(event)" MaxLength="3" runat="server" class="form-control" AutoComplete="off" Width="100px"></asp:TextBox>
                                </div>

                            </div>


                            <div class="applynow-outer" id="divp6" runat="server">
                                <div class="apply-fild-3of2">
                                    <label for="" style="font-weight: 700; width: 100%">with TMB since Years:</label>
                                    <asp:TextBox ID="txtYears"  oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumberKey(event)" MaxLength="2" runat="server" class="form-control" AutoComplete="off" Width="50px"></asp:TextBox><div style="width: 10px"></div>
                                    year(s)
                                </div>
                                <div class="apply-fild-3of2">
                                    <label for="" style="font-weight: 700;">And Months:</label>
                                    <asp:TextBox ID="txtMonths"   oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumberKey(event)" MaxLength="2" runat="server" class="form-control" AutoComplete="off" Width="50px"></asp:TextBox><div style="width: 10px"></div>
                                    months(s)
                                </div>
                            </div>
                            <div class="applynow-outer" id="divp7" runat="server">
                                <div class="apply-fild-3of3">
                                    <label for="" style="font-weight: 700;">Gender:</label>
                                    <asp:RadioButtonList runat="server" ID="rdoGender" class="lablerdo" RepeatLayout="Table" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoGender_SelectedIndexChanged">
                                        <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>

                            </div>
                            <div class="applynow-outer" id="divnext1" runat="server">
                                <div class="apply-fild-3of3">
                                    <asp:Button ID="btnnext1" runat="server" Text="Next" class="btn btn-primary em-cta related-product-click-apply" OnClick="btnnext1_Click" OnClientClick="return chk1Client();" />&nbsp;
                                </div>
                            </div>
                            <div class="row" id="divp8" runat="server">
                                <div class="col-lg-12" style="padding-top: 15px;">
                                </div>
                            </div>
                            <hr style="margin: 10px -15px;" id="hr3" runat="server" />

                            <div class="row" id="divp9" runat="server" visible="false">
                                <div class="col-lg-12" style="padding-top: 15px;">
                                    <asp:Label ID="Label1" runat="server" CssClass="label2" Text="3. Type of Account " Font-Bold="True"></asp:Label>
                                </div>
                            </div>
                            <hr style="margin: 10px -15px;" id="hr4" runat="server" visible="false" />
                            <div class="row" id="divq3" visible="false" runat="server">
                                <div class="col-lg-12">
                                    <asp:RadioButtonList ID="rdoQues3" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" RepeatLayout="Table" RepeatColumns="2" OnSelectedIndexChanged="rdoQues3_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Savings Account</asp:ListItem>
                                        <asp:ListItem Value="1">Current Account</asp:ListItem>
                                        <asp:ListItem Value="2">Term Deposit Account</asp:ListItem>
                                        <asp:ListItem Value="3">Other Please Specify</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <div style="height: 15px"></div>
                                    <asp:TextBox ID="txtOtherAccount" Enabled="false" runat="server" onkeypress="return isalphaKey(event)" class="form-control" AutoComplete="off" Width="200px"></asp:TextBox>
                                </div>
                                <br />
                                <asp:Label ID="lblErrQues3" runat="server" CssClass="label2" ForeColor="Red" Font-Bold="false"
                                    Visible="False"></asp:Label>
                            </div>
                            <div class="row" id="divp10" runat="server" visible="false">
                                <div class="col-lg-12" style="padding-top: 15px;">
                                </div>
                            </div>
                            <hr style="margin: 10px -15px;" id="hr5" runat="server" visible="false" />
                            <div class="row" id="divp11" runat="server" visible="false">
                                <div class="col-lg-12" style="padding-top: 15px;">
                                    <asp:Label ID="Label3" runat="server" CssClass="label2" Text="4. Occupation" Font-Bold="True"></asp:Label>
                                </div>
                            </div>
                            <hr style="margin: 10px -15px;" id="hr6" runat="server" visible="false" />
                            <div class="row" id="divq4" runat="server" visible="false">
                                <div class="col-lg-12">
                                    <asp:RadioButtonList ID="rdoQues4" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" RepeatLayout="Table" RepeatColumns="2" OnSelectedIndexChanged="rdoQues4_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Service</asp:ListItem>
                                        <asp:ListItem Value="1">Professional </asp:ListItem>
                                        <asp:ListItem Value="2">Business</asp:ListItem>
                                        <asp:ListItem Value="3">Self Employed </asp:ListItem>
                                        <asp:ListItem Value="4">Housewife</asp:ListItem>
                                        <asp:ListItem Value="5">Student</asp:ListItem>
                                        <asp:ListItem Value="6">Other Please Specify</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <div style="height: 15px"></div>
                                    <asp:TextBox ID="txtOtherOccupation" runat="server" class="form-control" Enabled="false" AutoComplete="off" Width="200px"></asp:TextBox>
                                </div>
                                <br />
                                <asp:Label ID="lblErrQues4" runat="server" CssClass="label2" ForeColor="Red" Font-Bold="false"
                                    Visible="False"></asp:Label>
                            </div>
                            <hr style="margin: 10px -15px;" id="hr7" runat="server" visible="false" />
                            <div class="row" id="divp12" runat="server" visible="false">
                                <div class="col-lg-12" style="padding-top: 15px;">
                                    <asp:Label ID="Label4" runat="server" CssClass="label2" Text="5. Annual Income "
                                        Font-Bold="True"></asp:Label>
                                </div>
                            </div>
                            <hr style="margin: 10px -15px;" id="hr8" runat="server" visible="false" />
                            <div class="row" id="divq5" runat="server" visible="false">
                                <div class="col-lg-12">
                                    <asp:RadioButtonList ID="rdoQues5" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rdoQues5_SelectedIndexChanged" RepeatLayout="Table" RepeatColumns="2">
                                        <asp:ListItem>Below 1 Lakh</asp:ListItem>
                                        <asp:ListItem>1~3 Lakhs </asp:ListItem>
                                        <asp:ListItem>3~6 Lakhs </asp:ListItem>
                                        <asp:ListItem>6~10 Lakhs  </asp:ListItem>
                                        <asp:ListItem>Ablove 10 Lakhs</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <asp:Label ID="lblErrQues5" runat="server" CssClass="label2" ForeColor="Red" Font-Bold="false"
                                        Visible="False"></asp:Label>
                                </div>
                            </div>
                            <div class="row" id="divbtn2" runat="server" visible="false">
                                <div class="col-lg-12">
                                    <asp:Button ID="btnnext2" runat="server" Text="Next" class="btn btn-primary em-cta related-product-click-apply" OnClick="btnnext2_Click" OnClientClick="return chk345Client();" />&nbsp;
                                </div>
                            </div>
                            <div class="row" id="divp13" runat="server" visible="false">
                                <div class="col-lg-12" style="padding-top: 15px;">
                                </div>
                            </div>
                            <hr style="margin: 10px -15px;" id="hr9" runat="server" visible="false" />
                            <div class="row" id="divp14" runat="server" visible="false">
                                <div class="col-lg-12" style="padding-top: 15px;">
                                    <asp:Label ID="Label5" runat="server" CssClass="label2" Text="6. What is the normal time taken completing the following transactions in the bank branch? Also please rate your satisfaction levels with the amount of time taken. "
                                        Font-Bold="True"></asp:Label>
                                </div>
                            </div>
                            <hr style="margin: 10px -15px;" id="hr10" runat="server" visible="false" />
                            <div class="row" id="divq6" runat="server" visible="false">
                                <div class="col-lg-12 tblscroll">
                                    <table class="tblrdo">

                                        <tr>
                                            <td colspan="2" rowspan="2">Transaction</td>
                                            <td colspan="4" style="text-align: center">Time Taken (min.)</td>
                                            <td colspan="5" style="text-align: center">Satisfaction Level</td>
                                        </tr>

                                        <tr>
                                            <td style="width: 95px">03~05 m</td>
                                            <td style="width: 95px">05~10 m</td>
                                            <td style="width: 95px">10~15 m</td>
                                            <td style="width: 95px">> 15 m</td>
                                            <td style="width: 65px">Extremely<br>
                                                Satisfied</td>
                                            <td style="width: 65px">Satisfied</td>
                                            <td style="width: 65px">Somewhat<br>
                                                Satisfied</td>
                                            <td style="width: 65px">Dis<br>
                                                Satisfied</td>
                                            <td style="width: 65px">Extremely<br>
                                                Dissatisfied</td>
                                        </tr>
                                        <tr class="field">
                                            <td colspan="2">Cash Deposits</td>
                                            <td>
                                                <asp:RadioButton ID="rdbCashD1" runat="server" GroupName="CDTinme" OnCheckedChanged="rdbCashD1_CheckedChanged" AutoPostBack="true" />
                                            </td>

                                            <td>
                                                <asp:RadioButton ID="rdbCashD2" runat="server" GroupName="CDTinme" OnCheckedChanged="rdbCashD2_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbCashD3" runat="server" GroupName="CDTinme" OnCheckedChanged="rdbCashD3_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbCashD4" runat="server" GroupName="CDTinme" OnCheckedChanged="rdbCashD4_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbCashD5" runat="server" GroupName="CDSatisfaction" OnCheckedChanged="rdbCashD5_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbCashD6" runat="server" GroupName="CDSatisfaction" OnCheckedChanged="rdbCashD6_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbCashD7" runat="server" GroupName="CDSatisfaction" OnCheckedChanged="rdbCashD7_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbCashD8" runat="server" GroupName="CDSatisfaction" OnCheckedChanged="rdbCashD8_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbCashD9" runat="server" GroupName="CDSatisfaction" OnCheckedChanged="rdbCashD9_CheckedChanged" AutoPostBack="true" />

                                            </td>
                                        </tr>
                                        <tr class="field">
                                            <td colspan="2">Cash Withdrawl</td>
                                            <td>
                                                <asp:RadioButton ID="rdbCashW1" runat="server" GroupName="CWTime" OnCheckedChanged="rdbCashW1_CheckedChanged" AutoPostBack="true" />
                                            </td>

                                            <td>
                                                <asp:RadioButton ID="rdbCashW2" runat="server" GroupName="CWTime" OnCheckedChanged="rdbCashW2_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbCashW3" runat="server" GroupName="CWTime" OnCheckedChanged="rdbCashW3_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbCashW4" runat="server" GroupName="CWTime" OnCheckedChanged="rdbCashW4_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbCashW5" runat="server" GroupName="CWSatisfaction" OnCheckedChanged="rdbCashW5_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbCashW6" runat="server" GroupName="CWSatisfaction" OnCheckedChanged="rdbCashW6_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbCashW7" runat="server" GroupName="CWSatisfaction" OnCheckedChanged="rdbCashW7_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbCashW8" runat="server" GroupName="CWSatisfaction" OnCheckedChanged="rdbCashW8_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbCashW9" runat="server" GroupName="CWSatisfaction" OnCheckedChanged="rdbCashW9_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                        </tr>
                                        <tr class="field">
                                            <td colspan="2">Passbook Updation</td>
                                            <td>
                                                <asp:RadioButton ID="rdbPassUpd1" runat="server" GroupName="PUTime" OnCheckedChanged="rdbPassUpd1_CheckedChanged" AutoPostBack="true" />
                                            </td>

                                            <td>
                                                <asp:RadioButton ID="rdbPassUpd2" runat="server" GroupName="PUTime" OnCheckedChanged="rdbPassUpd2_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbPassUpd3" runat="server" GroupName="PUTime" OnCheckedChanged="rdbPassUpd3_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbPassUpd4" runat="server" GroupName="PUTime" OnCheckedChanged="rdbPassUpd4_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbPassUpd5" runat="server" GroupName="PUSatisfaction" OnCheckedChanged="rdbPassUpd5_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbPassUpd6" runat="server" GroupName="PUSatisfaction" OnCheckedChanged="rdbPassUpd6_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbPassUpd7" runat="server" GroupName="PUSatisfaction" OnCheckedChanged="rdbPassUpd7_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbPassUpd8" runat="server" GroupName="PUSatisfaction" OnCheckedChanged="rdbPassUpd8_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdbPassUpd9" runat="server" GroupName="PUSatisfaction" OnCheckedChanged="rdbPassUpd9_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                        </tr>
                                        <tr class="field">
                                            <td colspan="2">Issue / Renew Term Deposit</td>
                                            <td>
                                                <asp:RadioButton ID="rdoRD1" runat="server" GroupName="RDTime" OnCheckedChanged="rdoRD1_CheckedChanged" AutoPostBack="true" />
                                            </td>

                                            <td>
                                                <asp:RadioButton ID="rdoRD2" runat="server" GroupName="RDTime" OnCheckedChanged="rdoRD2_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoRD3" runat="server" GroupName="RDTime" OnCheckedChanged="rdoRD3_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoRD4" runat="server" GroupName="RDTime" OnCheckedChanged="rdoRD4_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoRD5" runat="server" GroupName="RDSatisfaction" OnCheckedChanged="rdoRD5_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoRD6" runat="server" GroupName="RDSatisfaction" OnCheckedChanged="rdoRD6_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoRD7" runat="server" GroupName="RDSatisfaction" OnCheckedChanged="rdoRD7_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoRD8" runat="server" GroupName="RDSatisfaction" OnCheckedChanged="rdoRD8_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoRD9" runat="server" GroupName="RDSatisfaction" OnCheckedChanged="rdoRD9_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                        </tr>
                                    </table>

                                </div>
                                <div style="height: 15px">
                                </div>
                                <div id="div6" runat="server">
                                    <asp:Label ID="lblErr6" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                </div>
                            </div>
                            <div class="row" id="divp15" runat="server" visible="false">
                                <div class="col-lg-12" style="padding-top: 15px;">
                                </div>
                            </div>
                            <hr style="margin: 10px -15px;" id="hr11" runat="server" visible="false" />
                            <div class="row" id="divp16" runat="server" visible="false">
                                <div class="col-lg-12" style="padding-top: 15px;">
                                    <asp:Label ID="Label6" runat="server" CssClass="label2" Text="7. What is the normal time taken completing the following remittance transactions in the bank branch? Also please rate your satisfaction levels with the amount of time taken. "
                                        Font-Bold="True"></asp:Label>
                                </div>
                            </div>
                            <hr style="margin: 10px -15px;" id="hr12" runat="server" visible="false" />
                            <div class="row" id="divq7" runat="server" visible="false">
                                <div class="col-lg-12 tblscroll">

                                    <table class="tblrdo">

                                        <tr>
                                            <td colspan="2" rowspan="2">Transaction</td>
                                            <td colspan="4" style="text-align: center">Time Taken (min.)</td>
                                            <td colspan="5" style="text-align: center">Satisfaction Level</td>
                                        </tr>

                                        <tr>
                                            <td style="width: 95px">10~15 m m</td>
                                            <td style="width: 95px">15~30 m</td>
                                            <td style="width: 95px">30~45 m</td>
                                            <td style="width: 95px">> 45 m</td>
                                            <td style="width: 65px">Extremely<br>
                                                Satisfied</td>
                                            <td style="width: 65px">Satisfied</td>
                                            <td style="width: 65px">Somewhat<br>
                                                Satisfied</td>
                                            <td style="width: 65px">Dis<br>
                                                Satisfied</td>
                                            <td style="width: 65px">Extremely<br>
                                                Dissatisfied</td>
                                        </tr>
                                        <tr class="field">
                                            <td colspan="2">RTGS / NEFT Transfer</td>
                                            <td>
                                                <asp:RadioButton ID="rdoRTGS1" runat="server" GroupName="RTGSTime" OnCheckedChanged="rdoRTGS1_CheckedChanged" AutoPostBack="true" />
                                            </td>

                                            <td>
                                                <asp:RadioButton ID="rdoRTGS2" runat="server" GroupName="RTGSTime" OnCheckedChanged="rdoRTGS2_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoRTGS3" runat="server" GroupName="RTGSTime" OnCheckedChanged="rdoRTGS3_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoRTGS4" runat="server" GroupName="RTGSTime" OnCheckedChanged="rdoRTGS4_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoRTGS5" runat="server" GroupName="RTGSSatisfaction" OnCheckedChanged="rdoRTGS5_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoRTGS6" runat="server" GroupName="RTGSSatisfaction" OnCheckedChanged="rdoRTGS6_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoRTGS7" runat="server" GroupName="RTGSSatisfaction" OnCheckedChanged="rdoRTGS7_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoRTGS8" runat="server" GroupName="RTGSSatisfaction" OnCheckedChanged="rdoRTGS8_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoRTGS9" runat="server" GroupName="RTGSSatisfaction" OnCheckedChanged="rdoRTGS9_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                        </tr>
                                        <tr class="field">
                                            <td colspan="2">Issue DD / PO</td>
                                            <td>
                                                <asp:RadioButton ID="rdoDD1" runat="server" GroupName="DDTime" OnCheckedChanged="rdoDD1_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoDD2" runat="server" GroupName="DDTime" OnCheckedChanged="rdoDD2_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoDD3" runat="server" GroupName="DDTime" OnCheckedChanged="rdoDD3_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoDD4" runat="server" GroupName="DDTime" OnCheckedChanged="rdoDD4_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoDD5" runat="server" GroupName="DDSatisfaction" OnCheckedChanged="rdoDD5_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoDD6" runat="server" GroupName="DDSatisfaction" OnCheckedChanged="rdoDD6_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoDD7" runat="server" GroupName="DDSatisfaction" OnCheckedChanged="rdoDD7_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoDD8" runat="server" GroupName="DDSatisfaction" OnCheckedChanged="rdoDD8_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoDD9" runat="server" GroupName="DDSatisfaction" OnCheckedChanged="rdoDD9_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div style="height: 15px"></div>
                                <div id="div7" runat="server">
                                    <asp:Label ID="lblErr7" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                </div>

                            </div>
                            <div class="row" id="divbtn3" runat="server" visible="false">
                                <div class="col-lg-12">
                                    <asp:Button ID="btnext3" runat="server" Text="Next" class="btn btn-primary em-cta related-product-click-apply" OnClick="btnext3_Click" OnClientClick="return chk67Client();" />
                                </div>
                            </div>


                            <div class="row" id="divp17" runat="server" visible="false">
                                <div class="col-lg-12" style="padding-top: 15px;">
                                </div>
                            </div>
                            <hr style="margin: 10px -15px;" id="hr13" runat="server" visible="false" />
                            <div class="row" id="divp18" runat="server" visible="false">
                                <div class="col-lg-12" style="padding-top: 15px;">
                                    <asp:Label ID="Label7" runat="server" CssClass="label2" Text="8. What is the normal time taken completing the bills collection / cheque collections / clearing transaction in the bank branch? Also please rate your satisfaction levels with the amount of time taken. "
                                        Font-Bold="True"></asp:Label>
                                </div>
                            </div>
                            <hr style="margin: 10px -15px;" id="hr14" runat="server" visible="false" />
                            <div class="row" id="divq8" runat="server" visible="false">
                                <div class="col-lg-12 tblscroll">
                                    <table class="tblrdo">

                                        <tr>
                                            <td colspan="2" rowspan="2">Transaction</td>
                                            <td colspan="4" style="text-align: center">Time Taken (days)</td>
                                            <td colspan="5" style="text-align: center">Satisfaction Level</td>
                                        </tr>

                                        <tr>
                                            <td style="width: 95px">1d</td>
                                            <td style="width: 95px">2 d</td>
                                            <td style="width: 95px">3 d</td>
                                            <td style="width: 95px">> 3</td>
                                            <td style="width: 65px">Extremely<br>
                                                Satisfied</td>
                                            <td style="width: 65px">Satisfied</td>
                                            <td style="width: 65px">Somewhat<br>
                                                Satisfied</td>
                                            <td style="width: 65px">Dis<br>
                                                Satisfied</td>
                                            <td style="width: 65px">Extremely<br>
                                                Dissatisfied</td>
                                        </tr>
                                        <tr class="field">
                                            <td colspan="2">Bills Collection</td>
                                            <td>
                                                <asp:RadioButton ID="rdoBills1" runat="server" GroupName="BillsTime" OnCheckedChanged="rdoBills1_CheckedChanged" AutoPostBack="true" /></td>

                                            <td>
                                                <asp:RadioButton ID="rdoBills2" runat="server" GroupName="BillsTime" OnCheckedChanged="rdoBills2_CheckedChanged" AutoPostBack="true" /></td>
                                            <td>
                                                <asp:RadioButton ID="rdoBills3" runat="server" GroupName="BillsTime" OnCheckedChanged="rdoBills3_CheckedChanged" AutoPostBack="true" /></td>
                                            <td>
                                                <asp:RadioButton ID="rdoBills4" runat="server" GroupName="BillsTime" OnCheckedChanged="rdoBills4_CheckedChanged" AutoPostBack="true" /></td>
                                            <td>
                                                <asp:RadioButton ID="rdoBills5" runat="server" GroupName="BillsSatisfaction" OnCheckedChanged="rdoBills5_CheckedChanged" AutoPostBack="true" /></td>
                                            <td>
                                                <asp:RadioButton ID="rdoBills6" runat="server" GroupName="BillsSatisfaction" OnCheckedChanged="rdoBills6_CheckedChanged" AutoPostBack="true" /></td>
                                            <td>
                                                <asp:RadioButton ID="rdoBills7" runat="server" GroupName="BillsSatisfaction" OnCheckedChanged="rdoBills7_CheckedChanged" AutoPostBack="true" /></td>
                                            <td>
                                                <asp:RadioButton ID="rdoBills8" runat="server" GroupName="BillsSatisfaction" OnCheckedChanged="rdoBills8_CheckedChanged" AutoPostBack="true" /></td>
                                            <td>
                                                <asp:RadioButton ID="rdoBills9" runat="server" GroupName="BillsSatisfaction" OnCheckedChanged="rdoBills9_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                        </tr>
                                        <tr class="field">
                                            <td colspan="2">Cheque Collection</td>
                                            <td>
                                                <asp:RadioButton ID="rdoCh1" runat="server" GroupName="CHTime" OnCheckedChanged="rdoCh1_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoCh2" runat="server" GroupName="CHTime" OnCheckedChanged="rdoCh2_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoCh3" runat="server" GroupName="CHTime" OnCheckedChanged="rdoCh3_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoCh4" runat="server" GroupName="CHTime" OnCheckedChanged="rdoCh4_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoCh5" runat="server" GroupName="CHSatisfaction" OnCheckedChanged="rdoCh5_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoCh6" runat="server" GroupName="CHSatisfaction" OnCheckedChanged="rdoCh6_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoCh7" runat="server" GroupName="CHSatisfaction" OnCheckedChanged="rdoCh7_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoCh8" runat="server" GroupName="CHSatisfaction" OnCheckedChanged="rdoCh8_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoCh9" runat="server" GroupName="CHSatisfaction" OnCheckedChanged="rdoCh9_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                        </tr>
                                        <tr class="field">
                                            <td colspan="2">Clearing Transactions</td>
                                            <td>
                                                <asp:RadioButton ID="rdoClrTran1" runat="server" GroupName="ClrTime" OnCheckedChanged="rdoClrTran1_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoClrTran2" runat="server" GroupName="ClrTime" OnCheckedChanged="rdoClrTran2_CheckedChanged" AutoPostBack="true" /></td>
                                            <td>
                                                <asp:RadioButton ID="rdoClrTran3" runat="server" GroupName="ClrTime" OnCheckedChanged="rdoClrTran3_CheckedChanged" AutoPostBack="true" /></td>
                                            <td>
                                                <asp:RadioButton ID="rdoClrTran4" runat="server" GroupName="ClrTime" OnCheckedChanged="rdoClrTran4_CheckedChanged" AutoPostBack="true" /></td>
                                            <td>
                                                <asp:RadioButton ID="rdoClrTran5" runat="server" GroupName="ClrSatisfaction" OnCheckedChanged="rdoClrTran5_CheckedChanged" AutoPostBack="true" /></td>
                                            <td>
                                                <asp:RadioButton ID="rdoClrTran6" runat="server" GroupName="ClrSatisfaction" OnCheckedChanged="rdoClrTran6_CheckedChanged" AutoPostBack="true" /></td>
                                            <td>
                                                <asp:RadioButton ID="rdoClrTran7" runat="server" GroupName="ClrSatisfaction" OnCheckedChanged="rdoClrTran7_CheckedChanged" AutoPostBack="true" /></td>
                                            <td>
                                                <asp:RadioButton ID="rdoClrTran8" runat="server" GroupName="ClrSatisfaction" OnCheckedChanged="rdoClrTran8_CheckedChanged" AutoPostBack="true" /></td>
                                            <td>
                                                <asp:RadioButton ID="rdoClrTran9" runat="server" GroupName="ClrSatisfaction" OnCheckedChanged="rdoClrTran9_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div style="height: 15px"></div>
                                <div id="div8" runat="server">
                                    <asp:Label ID="lblErr8" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                </div>

                            </div>

                            <div class="row">
                                <div id="btn5" runat="server" visible="false">
                                    <asp:Button ID="btnnext5" runat="server" Text="Next" class="btn btn-primary em-cta related-product-click-apply" />&nbsp;

                                </div>
                            </div>
                            <div class="row" id="divp19" runat="server" visible="false">
                                <div class="col-lg-12" style="padding-top: 15px;">
                                </div>
                            </div>
                            <hr style="margin: 10px -15px;" id="hr15" runat="server" visible="false" />
                            <div class="row" id="divp20" runat="server" visible="false">
                                <div class="col-lg-12" style="padding-top: 15px;">
                                    <asp:Label ID="Label8" runat="server" CssClass="label2" Text="9. Are you using any of the following services? If Yes, please rate your satisfaction level. "
                                        Font-Bold="True"></asp:Label>
                                </div>
                            </div>
                            <hr style="margin: 10px -15px;" id="hr16" runat="server" visible="false" />
                            <div class="row" id="divq9" runat="server" visible="false">
                                <div class="col-lg-12 tblscroll">
                                    <table class="tblrdo">

                                        <tr>
                                            <td colspan="2" rowspan="2">Type</td>
                                            <td colspan="4" style="text-align: center">Whether Using ?</td>
                                            <td colspan="5" style="text-align: center">Satisfaction Level</td>
                                        </tr>

                                        <tr>
                                            <td style="width: 95px">Yes</td>
                                            <td style="width: 95px">No</td>
                                            <td style="width: 65px">Extremely<br>
                                                Satisfied</td>
                                            <td style="width: 65px">Satisfied</td>
                                            <td style="width: 65px">Somewhat<br>
                                                Satisfied</td>
                                            <td style="width: 65px">Dis<br>
                                                Satisfied</td>
                                            <td style="width: 65px">Extremely<br>
                                                Dissatisfied</td>
                                        </tr>
                                        <tr class="field">
                                            <td colspan="2">ATM Services</td>
                                            <td>
                                                <asp:RadioButton ID="rdoATM1" runat="server" GroupName="ATMUse" OnCheckedChanged="rdoATM1_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoATM2" runat="server" GroupName="ATMUse" OnCheckedChanged="rdoATM2_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoATM3" runat="server" GroupName="ATMSatisfaction" OnCheckedChanged="rdoATM3_CheckedChanged" AutoPostBack="true" Enabled="false" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoATM4" runat="server" GroupName="ATMSatisfaction" OnCheckedChanged="rdoATM4_CheckedChanged" AutoPostBack="true"  Enabled="false" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoATM5" runat="server" GroupName="ATMSatisfaction" OnCheckedChanged="rdoATM5_CheckedChanged" AutoPostBack="true" Enabled="false" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoATM6" runat="server" GroupName="ATMSatisfaction" OnCheckedChanged="rdoATM6_CheckedChanged" AutoPostBack="true" Enabled="false" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoATM7" runat="server" GroupName="ATMSatisfaction" OnCheckedChanged="rdoATM7_CheckedChanged" AutoPostBack="true" Enabled="false" />
                                            </td>
                                        </tr>
                                        <tr class="field">
                                            <td colspan="2">Anywhere Banking Services </td>
                                            <td>
                                                <asp:RadioButton ID="rdoBS1" runat="server" GroupName="BSUse" OnCheckedChanged="rdoBS1_CheckedChanged" AutoPostBack="true"  />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoBS2" runat="server" GroupName="BSUse" OnCheckedChanged="rdoBS2_CheckedChanged" AutoPostBack="true"   />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoBS3" runat="server" GroupName="BSSatisfaction" OnCheckedChanged="rdoBS3_CheckedChanged" AutoPostBack="true" Enabled="false" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoBS4" runat="server" GroupName="BSSatisfaction" OnCheckedChanged="rdoBS4_CheckedChanged" AutoPostBack="true" Enabled="false" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoBS5" runat="server" GroupName="BSSatisfaction" OnCheckedChanged="rdoBS5_CheckedChanged" AutoPostBack="true" Enabled="false" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoBS6" runat="server" GroupName="BSSatisfaction" OnCheckedChanged="rdoBS6_CheckedChanged" AutoPostBack="true"  Enabled="false" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoBS7" runat="server" GroupName="BSSatisfaction" OnCheckedChanged="rdoBS7_CheckedChanged" AutoPostBack="true" Enabled="false" />
                                            </td>
                                        </tr>
                                        <tr class="field">
                                            <td colspan="2">Internet Banking Services </td>
                                            <td>
                                                <asp:RadioButton ID="rdoIB1" runat="server" GroupName="IBUse" OnCheckedChanged="rdoIB1_CheckedChanged" AutoPostBack="true"  />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoIB2" runat="server" GroupName="IBUse" OnCheckedChanged="rdoIB2_CheckedChanged" AutoPostBack="true"  />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoIB3" runat="server" GroupName="IBSatisfaction" OnCheckedChanged="rdoIB3_CheckedChanged" AutoPostBack="true" Enabled="false" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoIB4" runat="server" GroupName="IBSatisfaction" OnCheckedChanged="rdoIB4_CheckedChanged" AutoPostBack="true" Enabled="false" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoIB5" runat="server" GroupName="IBSatisfaction" OnCheckedChanged="rdoIB5_CheckedChanged" AutoPostBack="true" Enabled="false" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoIB6" runat="server" GroupName="IBSatisfaction" OnCheckedChanged="rdoIB6_CheckedChanged" AutoPostBack="true" Enabled="false" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoIB7" runat="server" GroupName="IBSatisfaction" OnCheckedChanged="rdoIB7_CheckedChanged"  AutoPostBack="true" Enabled="false" />
                                            </td>
                                        </tr>
                                        <tr class="field">
                                            <td colspan="2">Mobile Banking Services </td>
                                            <td>
                                                <asp:RadioButton ID="rdoMB1" runat="server" GroupName="MBUse" OnCheckedChanged="rdoMB1_CheckedChanged" AutoPostBack="true"   />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoMB2" runat="server" GroupName="MBUse" OnCheckedChanged="rdoMB2_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoMB3" runat="server" GroupName="MBSatisfaction" OnCheckedChanged="rdoMB3_CheckedChanged" AutoPostBack="true" Enabled="false" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoMB4" runat="server" GroupName="MBSatisfaction" OnCheckedChanged="rdoMB4_CheckedChanged" AutoPostBack="true" Enabled="false" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoMB5" runat="server" GroupName="MBSatisfaction" OnCheckedChanged="rdoMB5_CheckedChanged" AutoPostBack="true" Enabled="false" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoMB6" runat="server" GroupName="MBSatisfaction" OnCheckedChanged="rdoMB6_CheckedChanged" AutoPostBack="true" Enabled="false" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoMB7" runat="server" GroupName="MBSatisfaction" OnCheckedChanged="rdoMB7_CheckedChanged" AutoPostBack="true" Enabled="false" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div style="height: 15px"></div>
                                <div id="div9" runat="server">
                                    <asp:Label ID="lblErr9" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                </div>
                                <div style="height: 15px"></div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12" id="divbtn4" runat="server" visible="false">
                                    <asp:Button ID="btnnex4" runat="server" Text="Next" class="btn btn-primary em-cta related-product-click-apply" OnClick="btnnex4_Click" OnClientClick="return chk89Client();" />
                                </div>
                            </div>

                            <div class="row" id="divp21" runat="server" visible="false">
                                <div class="col-lg-12" style="padding-top: 15px;">
                                </div>
                            </div>
                            <hr style="margin: 10px -15px;" id="hr17" runat="server" visible="false" />
                            <div class="row" id="divp22" runat="server" visible="false">
                                <div class="col-lg-12" style="padding-top: 15px;">
                                    <asp:Label ID="Label9" runat="server" CssClass="label2" Text="10. Feedback from the Borrower (If you are not a borrower / loan or cc limit customer skip this). "
                                        Font-Bold="True"></asp:Label>
                                </div>
                            </div>
                            <hr style="margin: 10px -15px;" id="hr18" runat="server" visible="false" />
                            <div class="row" id="divq101" runat="server" visible="false">
                                <div class="col-lg-6">
                                    <label for="">Since How Long are you enjoying credit facilities from the bank?</label>
                                    <asp:DropDownList runat="server" ID="ddlCrFacYr" CssClass="form-control">
                                        <asp:ListItem Value="0" Selected="True">---select---</asp:ListItem>
                                        <asp:ListItem Value="1">Less than 6 months</asp:ListItem>
                                        <asp:ListItem Value="2">6 months to 1 year</asp:ListItem>
                                        <asp:ListItem Value="3">1 year to 3 years</asp:ListItem>
                                        <asp:ListItem Value="4">3 year to 5 years</asp:ListItem>
                                        <asp:ListItem Value="5">Above 5 years</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-6">
                                    <label for="">Which of the loan products / services did you avail with us?</label>
                                    <asp:DropDownList runat="server" ID="ddlLoanType" CssClass="form-control" OnSelectedIndexChanged="ddlLoanType_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="0" Selected="True">---Loan Type----</asp:ListItem>
                                        <asp:ListItem Value="1">Business Loan</asp:ListItem>
                                        <asp:ListItem Value="2">Housing Loan</asp:ListItem>
                                        <asp:ListItem Value="3">Car Loan</asp:ListItem>
                                        <asp:ListItem Value="4">Export Credit</asp:ListItem>
                                        <asp:ListItem Value="5">Any Other Loan</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                            </div>
                            <div style="height: 15px" id="divp23" runat="server" visible="false"></div>
                            <div class="row" id="divOtherLoan" runat="server" visible="false">
                                <div class="col-lg-6">
                                    <asp:TextBox runat="server" ID="txtLoanType" CssClass="form-control" AutoComplete="off"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row" id="divq102" runat="server" visible="false">
                                <div class="col-lg-6">
                                    <label for="">How did you know the availability of these products / services?</label>
                                    <asp:DropDownList runat="server" ID="ddlKnowProducts" CssClass="form-control">
                                        <asp:ListItem Value="0" Selected="True">---Select Referrer----</asp:ListItem>
                                        <asp:ListItem Value="1">Advertisement</asp:ListItem>
                                        <asp:ListItem Value="2">Display Info at Branch</asp:ListItem>
                                        <asp:ListItem Value="3">Friends</asp:ListItem>
                                        <asp:ListItem Value="4">Social Network</asp:ListItem>
                                        <asp:ListItem Value="5">TMB Staff</asp:ListItem>
                                        <asp:ListItem Value="6">Other</asp:ListItem>

                                    </asp:DropDownList>
                                </div>

                            </div>
                            <div class="row" id="divq103" runat="server" visible="false">
                                <div class="col-lg-12">
                                    <label for="">Rate your experience on new sanction / renewal / ad-hoc sanction?</label>
                                    <asp:DropDownList runat="server" ID="ddlRateLoanSaction" CssClass="form-control">
                                        <asp:ListItem Value="0" Selected="True">---Select----</asp:ListItem>
                                        <asp:ListItem Value="1">Extremely Satisfied</asp:ListItem>
                                        <asp:ListItem Value="2">Satisfied</asp:ListItem>
                                        <asp:ListItem Value="3">Somewhat Satisfied</asp:ListItem>
                                        <asp:ListItem Value="4">Dis-satisfied</asp:ListItem>
                                        <asp:ListItem Value="6">Extremely Dissatisfied</asp:ListItem>


                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row" id="divq104" runat="server" visible="false">
                                <div class="col-lg-12">
                                    <label for="">How will you rate your overall credit sanction satisfaction?</label>
                                    <asp:DropDownList runat="server" ID="ddlCrRate" CssClass="form-control">
                                        <asp:ListItem Value="0" Selected="True">---Select----</asp:ListItem>
                                        <asp:ListItem Value="1">Extremely Satisfied</asp:ListItem>
                                        <asp:ListItem Value="2">Satisfied</asp:ListItem>
                                        <asp:ListItem Value="3">Somewhat Satisfied</asp:ListItem>
                                        <asp:ListItem Value="4">Dis-satisfied</asp:ListItem>
                                        <asp:ListItem Value="6">Extremely Dissatisfied</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12" style="padding-top: 15px;">
                                </div>
                            </div>
                            <div class="row" id="divbtn5" runat="server" visible="false">
                                <div class="col-lg-12">
                                    <asp:Button ID="next5" runat="server" Text="Next" class="btn btn-primary em-cta related-product-click-apply" OnClick="next5_Click" />
                                </div>
                            </div>
                            <div class="row" id="divp24" runat="server" visible="false">
                                <div class="col-lg-12" style="padding-top: 15px;">
                                </div>
                            </div>
                            <hr style="margin: 10px -15px;" id="hr19" runat="server" visible="false" />
                            <div class="row" id="divp25" runat="server" visible="false">
                                <div class="col-lg-12" style="padding-top: 15px;">
                                    <asp:Label ID="Label10" runat="server" CssClass="label2" Text="11.  Rate your satisfaction on the following. "
                                        Font-Bold="True"></asp:Label>
                                </div>
                            </div>
                            <hr style="margin: 10px -15px;" id="hr20" runat="server" visible="false" />
                            <div class="row" id="divq11" runat="server" visible="false">
                                <div class="col-lg-12 ">
                                    <table class="tblrdo tblscroll">

                                        <tr>
                                            <td colspan="2" rowspan="2"></td>

                                        </tr>

                                        <tr>

                                            <td style="width: 65px">Extremely<br>
                                                Satisfied</td>
                                            <td style="width: 65px">Satisfied</td>
                                            <td style="width: 65px">Somewhat<br>
                                                Satisfied</td>
                                            <td style="width: 65px">Dis<br>
                                                Satisfied</td>
                                            <td style="width: 65px">Extremely<br>
                                                Dissatisfied</td>
                                        </tr>
                                        <tr class="field">
                                            <td colspan="2">Speed of Transactions at Counters </td>
                                            <td>
                                                <asp:RadioButton ID="rdoSTC1" runat="server" GroupName="STC" OnCheckedChanged="rdoSTC1_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoSTC2" runat="server" GroupName="STC" OnCheckedChanged="rdoSTC2_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoSTC3" runat="server" GroupName="STC" OnCheckedChanged="rdoSTC3_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoSTC4" runat="server" GroupName="STC" OnCheckedChanged="rdoSTC4_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rdoSTC5" runat="server" GroupName="STC" OnCheckedChanged="rdoSTC5_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                        </tr>
                                        <tr class="field">
                                            <td colspan="2">Correctness / Accuracy of Transactions </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="CAT" OnCheckedChanged="RadioButton1_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="CAT" OnCheckedChanged="RadioButton2_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton3" runat="server" GroupName="CAT" OnCheckedChanged="RadioButton3_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton4" runat="server" GroupName="CAT" OnCheckedChanged="RadioButton4_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton5" runat="server" GroupName="CAT" OnCheckedChanged="RadioButton5_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                        </tr>
                                        <tr class="field">
                                            <td colspan="2">Behaviour / Attitude of Bank Staff</td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton6" runat="server" GroupName="BAS" OnCheckedChanged="RadioButton6_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton7" runat="server" GroupName="BAS" OnCheckedChanged="RadioButton7_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton8" runat="server" GroupName="BAS" OnCheckedChanged="RadioButton8_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton9" runat="server" GroupName="BAS" OnCheckedChanged="RadioButton9_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton10" runat="server" GroupName="BAS" OnCheckedChanged="RadioButton10_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                        </tr>
                                        <tr class="field">
                                            <td colspan="2">Knowledge Level of Bank Staff</td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton11" runat="server" GroupName="KLB" OnCheckedChanged="RadioButton11_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton12" runat="server" GroupName="KLB" OnCheckedChanged="RadioButton12_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton13" runat="server" GroupName="KLB" OnCheckedChanged="RadioButton13_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton14" runat="server" GroupName="KLB" OnCheckedChanged="RadioButton14_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton15" runat="server" GroupName="KLB" OnCheckedChanged="RadioButton15_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                        </tr>
                                        <tr class="field">
                                            <td colspan="2">Punctuality of Commencing Business in the branch</td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton16" runat="server" GroupName="Punctuality" OnCheckedChanged="RadioButton16_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton17" runat="server" GroupName="Punctuality" OnCheckedChanged="RadioButton17_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton18" runat="server" GroupName="Punctuality" OnCheckedChanged="RadioButton18_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton19" runat="server" GroupName="Punctuality" OnCheckedChanged="RadioButton19_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton20" runat="server" GroupName="Punctuality" OnCheckedChanged="RadioButton20_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                        </tr>
                                        <tr class="field">
                                            <td colspan="2">Availability / Display of Information at Branches</td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton21" runat="server" GroupName="ADBI" OnCheckedChanged="RadioButton21_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton22" runat="server" GroupName="ADBI" OnCheckedChanged="RadioButton22_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton23" runat="server" GroupName="ADBI" OnCheckedChanged="RadioButton23_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton24" runat="server" GroupName="ADBI" OnCheckedChanged="RadioButton24_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton25" runat="server" GroupName="ADBI" OnCheckedChanged="RadioButton25_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                        </tr>
                                        <tr class="field">
                                            <td colspan="2">Basic Facilities (seating arrangement, drinking water, stationary, etc.)</td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton26" runat="server" GroupName="BF" OnCheckedChanged="RadioButton26_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton27" runat="server" GroupName="BF" OnCheckedChanged="RadioButton27_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton28" runat="server" GroupName="BF" OnCheckedChanged="RadioButton28_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton29" runat="server" GroupName="BF" OnCheckedChanged="RadioButton29_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton30" runat="server" GroupName="BF" OnCheckedChanged="RadioButton30_CheckedChanged" AutoPostBack="true" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div style="height: 15px"></div>
                                <div id="div11" runat="server">
                                    <asp:Label ID="lblErr11" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                </div>
                            </div>
                            <div class="row" id="divp26" runat="server" visible="false">
                                <div class="col-lg-12" style="padding-top: 15px;">
                                </div>
                            </div>
                            <hr style="margin: 10px -15px;" id="hr21" runat="server" visible="false" />
                            <div class="row" id="divp27" runat="server" visible="false">
                                <div class="col-lg-12" style="padding-top: 15px;">
                                    <asp:Label ID="Label11" runat="server" CssClass="label2" Text="12.  Social Network (Following us on Facebook / Twitter…?) "
                                        Font-Bold="True"></asp:Label>
                                    <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rdoSocil">
                                        <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                        <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="row" id="divp28" runat="server" visible="false">
                                <div class="col-lg-12" style="padding-top: 15px;">
                                </div>
                            </div>
                            <hr style="margin: 10px -15px;" id="hr22" runat="server" visible="false" />
                            <div class="row" id="divp29" runat="server" visible="false">
                                <div class="col-lg-12" style="padding-top: 15px;">
                                    <label for="">13.  Do you have any comments / suggestions?</label>

                                    <asp:TextBox runat="server" ID="txtComments" MaxLength="6000" TextMode="MultiLine" Width="500px" Rows="7" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <hr style="margin: 10px -15px;" id="hr23" runat="server" visible="false" />
                            <div class="col-lg-12" id="divp30" runat="server" visible="false" style="margin-bottom: 30px; margin-left: -25px">
                                <div class="col-lg-4">
                                    <cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="6"
                                        CaptchaHeight="40" CaptchaWidth="200" CaptchaMinTimeout="5" CaptchaMaxTimeout="240"
                                        FontColor="#000000" NoiseColor="#B1B1B1" />
                                </div>
                                <div class="col-lg-4" style="width: 100px">
                                    <asp:ImageButton ID="ImageButton1" ImageUrl="images/refresh.png" runat="server" CausesValidation="false" Width="40px" />
                                </div>
                                <div class="col-lg-4" style="width: 300px">
                                    <label for="email">Enter the code from the image here:</label>
                                    <asp:TextBox ID="Txtcaptch" AutoComplete="off" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <asp:Button ID="Btnsave" runat="server" Visible="false" Text="Send" class="btn btn-primary em-cta related-product-click-apply" OnClick="Btnsave_Click" OnClientClick="return chklastClient();"></asp:Button>

                            <asp:Button ID="btnReset" runat="server" Text="Reset" Visible="false" class="btn btn-primary em-cta related-product-click-apply" OnClick="Button2_Click"></asp:Button>
                        </div>




                    </div>
                </div>

              <div class="col-md-3 related-products em" data-type="product">
                        <div class="hp-main-box">
                            <div class="main-white-box box-1 clearfix" style="background: #ececed; height: auto; border: none;">
                                <img class="rel-img-right em-img lazyloaded" src="images/products1.jpg" style="width: 100%; height: auto; display: block; border-radius: 4px 4px 0 0;" />
                                <div class="details-box">
                                    <div class="hp-card-box">
                                        <h4 class="em-title share-comp-title" style="margin-top: 0px; min-height: 60px; background: transparent; border: none; color: #000; font-size: 24px;">Savings Account</h4>

                                        
                                    </div>



                                    <p class="link-box" style="display: none;"><a class="em-cta related-product-click-know-more" href="/en/personal-banking/accounts/savings-account/silk-woman-savings-account.html">Know More...</a></p>

                                    <div class="clearfix">
                                        <div class="FR MT15">
                                            <div class="share-box">
                                                <div class="share-positon-box clearfix">
                                                    <div class="share-bubble white">&nbsp;</div>
                                                </div>
                                            </div>
                                        </div>
                                        <a class="btn btn-primary em-cta related-product-click-apply" href="https://www.tmbnet.in/laps/?PAGE_TYPE=R" target="_blank">Apply Now</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
            </div>
        </div>
    </section>


</asp:Content>

