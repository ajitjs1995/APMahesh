<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true"
    CodeFile="emi-calculator.aspx.cs" Inherits="emi_calculator" %>

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
	<link rel="stylesheet" href="css/blog-style.css" type="text/css">
    <script language="javascript">
        function freset() {
            debugger;
            document.getElementById('<%= nos.ClientID %>').value = null;
            document.getElementById('<%= rate.ClientID %>').value = null;
            document.getElementById('<%= lamt.ClientID %>').value = null;
            document.getElementById('<%= RsEMI.ClientID %>').value = null;

        }
        function fglobal3(num) {
            var numbers = "1234567890."
            var i = 0, j = 0, k = 0;
            for (i = 0; i <= num.length; i = i + 1) {
                j = num.substring(i, i + 1)
                k = numbers.indexOf(j)
                if (k < 0) {
                    alert("Please Enter Only numbers");
                    var nos = document.getElementById('<%= nos.ClientID %>');
                    nos.focus();
                    nos = "";
                    document.getElementById('<%= nos.ClientID %>').value = null;
                    return false
                }
            }
        }

        function fcalemi() {
            debugger;
            nos = document.getElementById('<%= nos.ClientID %>').value;
            rate = document.getElementById('<%= rate.ClientID %>').value;
            lamt = document.getElementById('<%= lamt.ClientID %>').value;
            flag = true

            if ((nos == "") || (isNaN(nos))) {
                alert("Please enter no of installments");
                nos.focus();
                flag = false;
            }
            else if ((parseFloat(nos) < 12) || (parseFloat(nos) > 240)) {
                alert("Please enter proper installments");
                nos.focus();
                flag = false
            }
            else if ((rate == "") || (isNaN(rate))) {
                alert("Please enter rate of interest");
                rate.focus();
                flag = false
            }
            else if ((parseFloat(rate) < 1.00) || (parseFloat(rate) > 99.99)) {
                alert("Please enter proper rate of interest");
                rate.focus();
                flag = false
            }
            else if ((lamt == "") || (isNaN(lamt))) {
                alert("Please enter loan amount");
                lamt.focus();
                flag = false
            }
            else if ((parseFloat(lamt) < 1000) || (parseFloat(lamt) > 5000000)) {
                alert("Please enter proper loan amount");
                lamt.focus();
                flag = false
            }
            if (flag == true) {
                var amt = lamt;
                x = nos;
                reset = 1;
                i = parseFloat(rate) / 100
                adv = 0
                var k = 1 / (1 + i * reset / 12)
                var gp = (Math.pow(k, x) - 1) / (k - 1) * k
                gp += adv / reset;
                var emi = amt / gp / reset;

                //	rate=parseFloat(rate)/100
                //calra=Math.pow(1+parseFloat(rate),parseInt(nos)/12)
                //	calra=Math.pow(1+parseFloat(rate),parseInt(nos)/12)
                //	EMI1=1/12*(calra/(calra-1))*parseFloat(lamt)*parseFloat(rate)
                //	RsEMI.value =EMI1;
                document.getElementById('<%= RsEMI.ClientID %>').value = emi;
                //RsEMI.value = emi;
                roundDec(document.getElementById('<%= RsEMI.ClientID %>'));
            }
        }
        //Set Decimal Places for loan Interest 
        function roundDec(val) {
            var s = "" + val.value;
            var k = s.indexOf('.');
            var t
            if (k < 0) {
                val.value = val.value + ".00";
            }
            else {
                t = s.substring(0, k + 1) + s.substring(k + 1, k + 3);
                if (k + 2 == s.length)
                    t = t + "0"
                val.value = t
            }
        }
    </script>
    <style type="text/css">
        .btnemi
        {
            display: inline-block;
            font-weight: 400;
            text-align: center;
            vertical-align: middle;
            -ms-touch-action: manipulation;
            touch-action: manipulation;
            cursor: pointer;
            border: 1px solid transparent;
            white-space: nowrap;
            padding: 6px 14px;
            font-size: 15px;
            border-radius: 5px;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
            text-transform: inherit;
            padding: 5px 15px 5px 15px;
        }
        .btn-primary
        {
            color: #fff;
            background-color: #18378b;
            background-image: linear-gradient(to bottom,#18378b 0,#18378b 100%) !important;
        }
        .btn-primary:hover
        {
            color: #fff;
            background-color: #286090;
            background-image: linear-gradient(to bottom,#286090 0,#286090 100%) !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="blog">
        <div class="blog container" style="width: 92%;">
            <div class="row">
                <div class="col-md-9">
                    <h1 style="color: #ce1c7b; font-size: 28px;">EMI Calculator</h1>
                    <strong>Note : </strong> That all figures are clearly indicative.<br />
Please contact our nearest TMB Bank branch for exact figures.
                    <div class="tabbs">                    
                        <div class="form-group">
                            <label for="">No. of Installments : (12 to 240 months)</label>
                            <asp:TextBox ID="nos" onKeyUp="return fglobal3(this.value)" runat="server" class="form-control" maxLength="3" size="15" AutoComplete="off"></asp:TextBox>
                            <%--<INPUT id="nos" onKeyUp="return fglobal3(nos)" class="form-control" maxLength="3" size="15" name="nos" AutoComplete="off">--%>
                        </div>
                                           
                        <div class="form-group">
                            <label for="">Interest Rate : (%)</label>
                            <asp:TextBox ID="rate" runat="server" onKeyUp="return fglobal3(this.value)" class="form-control" maxLength="5" size="15" ></asp:TextBox>
                            <%--<INPUTname="rate" id="rate"> --%>
                        </div>              
                        <div class="form-group">
                            <label for="">Loan Amount (Rs): (Rs.1000 to Rs.50,00,000)</label>
                            <asp:TextBox ID="lamt" runat="server" maxLength="8" size="15" class="form-control" ></asp:TextBox>
                           <%-- <INPUTname="lamt"id=""> --%>
                        </div>              
                        <div class="form-group">
                            <label for="">EMI (Rs): </label>
                            <asp:TextBox ID="RsEMI" runat="server" size="15" readonly class="form-control" ></asp:TextBox>
                            <%--<INPUT name=""id="RsEMI">--%>
                        </div>
                        <div style="text-align:center;">
                        <INPUT id="btnSubmit" onclick="javascript:fcalemi()" type="button" value="Calculate" class="btnemi btn-primary em-cta related-product-click-apply"> 
                  <INPUT id="Hidden1" type="hidden" maxLength="5" size="10" name="Rate"> 
                  &nbsp;  &nbsp;  &nbsp; 
                  <INPUT id="btnReset" onclick="javascript:freset()" type="button" value="Reset" class="btnemi btn-primary em-cta related-product-click-apply"> 
                        </div>
                        
                    </div>
                </div>
            <div class="col-md-3 col-sm-12 related-products em" data-type="product">
<div class="hp-main-box">
<div class="main-white-box box-1 clearfix" style="background: #ececed; height: auto;   border: none;"><img class="rel-img-right em-img lazyloaded" src="images/Car-Loan2.jpg" style="width: 100%; height: auto; display: block; border-radius: 4px 4px 0 0;">
<div class="details-box">
<div class="hp-card-box">
<h4 class="em-title share-comp-title" style="margin-top: 0px; min-height: 60px; background: transparent; border: none; color: #000; font-size: 21px;">Car Loan</h4>
</div>

<div class="clearfix"><a class="" href="/tmb-car-loan.aspx"><img src="images/morebtn.png"></a></div>
</div>
</div>
</div>
</div>
            </div>
        </div>
    </section>
</asp:Content>
