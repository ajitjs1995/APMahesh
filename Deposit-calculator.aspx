<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" %>

<script runat="server">

</script>
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
    <script type="text/javascript" language="javascript">

        function reccur_checked() {
            document.getElementById('<%= shortDep.ClientID %>').checked = false

            document.getElementById('<%= monthly.ClientID %>').checked = false

            document.getElementById('<%= quaterly.ClientID %>').checked = false
            document.getElementById('<%= quaterly.ClientID %>').checked = false

            document.getElementById('<%= doubleDep.ClientID %>').checked = false
            document.getElementById('<%= principal.ClientID %>').value = "0"
            document.getElementById('<%= rate.ClientID %>').value = "0"
            document.getElementById('<%= months.ClientID %>').value = "0"
            document.getElementById('<%= days.ClientID %>').value = "0"
            document.getElementById('<%= totalint.ClientID %>').value = "0"
            document.getElementById('<%= maturity.ClientID %>').value = "0"
            document.getElementById('<%= message.ClientID %>').value = "0"

            //calculate();
        }

        function short_checked() {
            document.getElementById('<%= Recurring.ClientID %>').checked = false

            document.getElementById('<%= monthly.ClientID %>').checked = false
            document.getElementById('<%= quaterly.ClientID %>').checked = false
            document.getElementById('<%= doubleDep.ClientID %>').checked = false
            document.getElementById('<%= principal.ClientID %>').value = "0"
            document.getElementById('<%= rate.ClientID %>').value = "0"
            document.getElementById('<%= months.ClientID %>').value = "0"
            document.getElementById('<%= days.ClientID %>').value = "0"
            document.getElementById('<%= totalint.ClientID %>').value = "0"
            document.getElementById('<%= maturity.ClientID %>').value = "0"
            document.getElementById('<%= message.ClientID %>').value = ""
            //calculate();
        }

        function fixed_checked() {
            document.getElementById('<%= shortDep.ClientID %>').checked = false
            document.getElementById('<%= Recurring.ClientID %>').checked = false
            document.getElementById('<%= monthly.ClientID %>').checked = false
            document.getElementById('<%= quaterly.ClientID %>').checked = false
            document.getElementById('<%= doubleDep.ClientID %>').checked = false
            document.getElementById('<%= principal.ClientID %>').value = "0"
            document.getElementById('<%= rate.ClientID %>').value = "0"
            document.getElementById('<%= months.ClientID %>').value = "0"
            document.getElementById('<%= days.ClientID %>').value = "0"
            document.getElementById('<%= totalint.ClientID %>').value = "0"
            document.getElementById('<%= maturity.ClientID %>').value = "0"
            document.getElementById('<%= message.ClientID %>').value = ""
            //calculate();
        }

        function monthly_checked() {
            document.getElementById('<%= shortDep.ClientID %>').checked = false
            document.getElementById('<%= Recurring.ClientID %>').checked = false
            document.getElementById('<%= quaterly.ClientID %>').checked = false
            document.getElementById('<%= doubleDep.ClientID %>').checked = false
            document.getElementById('<%= principal.ClientID %>').value = "0"
            document.getElementById('<%= rate.ClientID %>').value = "0"
            document.getElementById('<%= months.ClientID %>').value = "0"
            document.getElementById('<%= days.ClientID %>').value = "0"
            document.getElementById('<%= totalint.ClientID %>').value = "0"
            document.getElementById('<%= maturity.ClientID %>').value = "0"
            document.getElementById('<%= message.ClientID %>').value = ""
            //calculate();
        }

        function quarterly_checked() {
            document.getElementById('<%= shortDep.ClientID %>').checked = false
            document.getElementById('<%= monthly.ClientID %>').checked = false
            document.getElementById('<%= Recurring.ClientID %>').checked = false
            document.getElementById('<%= doubleDep.ClientID %>').checked = false
            document.getElementById('<%= principal.ClientID %>').value = "0"
            document.getElementById('<%= rate.ClientID %>').value = "0"
            document.getElementById('<%= months.ClientID %>').value = "0"
            document.getElementById('<%= days.ClientID %>').value = "0"
            document.getElementById('<%= totalint.ClientID %>').value = "0"
            document.getElementById('<%= maturity.ClientID %>').value = "0"
            document.getElementById('<%= message.ClientID %>').value = ""

            //calculate();
        }

        function double_checked() {
            document.getElementById('<%= shortDep.ClientID %>').checked = false
            document.getElementById('<%= shortDep.ClientID %>').checked = false
            document.getElementById('<%= monthly.ClientID %>').checked = false
            document.getElementById('<%= quaterly.ClientID %>').checked = false
            document.getElementById('<%= Recurring.ClientID %>').checked = false
            document.getElementById('<%= principal.ClientID %>').value = "0"
            document.getElementById('<%= rate.ClientID %>').value = "0"
            document.getElementById('<%= months.ClientID %>').value = "0"
            document.getElementById('<%= days.ClientID %>').value = "0"
            document.getElementById('<%= totalint.ClientID %>').value = "0"
            document.getElementById('<%= maturity.ClientID %>').value = "0"
            document.getElementById('<%= message.ClientID %>').value = ""

            //calculate();
        }

        function month_daycheck() {
            if (document.getElementById('<%= months.ClientID %>').value <= 0 || document.getElementById('<%= days.ClientID %>').value <= 0) {
                alert("Enter the numeric value in months and days field")
                return false;
            }
            //         if (document.getElementById('<%= months.ClientID %>').value == 0) {
            //             document.form1.months.focus
            //             return false;
            //         }
            //         else if (document.forms1.days.value == 0) {
            //             document.form1.days.focus
            //             return false;
            //         }

        }


        function calculate() {
            if (document.getElementById('<%= principal.ClientID %>').value == "" || isNaN(document.getElementById('<%= principal.ClientID %>').value)) {
                alert("Enter the numeric value in principal feild")
                document.getElementById('<%= principal.ClientID %>').value = 0
                document.form1.principal.focus
                return false;
            }


            if (document.getElementById('<%= rate.ClientID %>').value == "" || isNaN(document.getElementById('<%= rate.ClientID %>').value)) {
                alert("Enter the numeric value in rate feild")
                document.getElementById('<%= rate.ClientID %>').value = 0
                document.form1.rate.focus
                return false;
            }


            if (document.getElementById('<%= days.ClientID %>').value == "" || isNaN(document.getElementById('<%= days.ClientID %>').value)) {
                alert("Enter the numeric value in days feild")
                document.getElementById('<%= days.ClientID %>').value = 0
                document.form1.days.focus
                return false;
            }


            if (document.getElementById('<%= months.ClientID %>').value == "" || isNaN(document.getElementById('<%= months.ClientID %>').value)) {
                alert("Enter the numeric value in months feild")
                document.getElementById('<%= months.ClientID %>').value = 0
                document.form1.months.focus
                return false;
            }


            // setting validation of the radio Buttons


            if (document.getElementById('<%= Recurring.ClientID %>').checked == true) {
                //recurring

                principal = document.getElementById('<%= principal.ClientID %>').value
                rate = document.getElementById('<%= rate.ClientID %>').value
                months = document.getElementById('<%= months.ClientID %>').value
                days = document.getElementById('<%= days.ClientID %>').value
                totalbalance = 0
                product = 0
                j = 0

                for (var i = 1; i <= months; i++) {

                    totalbalance = totalbalance + parseFloat(principal);
                    product = product + totalbalance;
                    j = j + 1;
                    if (j == 3 || i == months) {
                        PerodicInt = parseFloat(product * rate / 1200)
                        totalbalance = totalbalance + PerodicInt
                        product = 0
                        j = 0;
                    }
                }

                if (parseInt(days) > 0) {
                    Interest = ((principal * rate * days) / 36500)

                    if (months > 0) {
                        totalbalance = totalbalance + parseFloat(Interest)
                    }
                    else {
                        totalbalance = parseFloat(principal) + parseFloat(Interest)
                    }
                }

                document.getElementById('<%= maturity.ClientID %>').value = parseInt(totalbalance)
                if (months == 0) {
                    totprincipal = parseInt(principal)
                    Int = 0
                }

                else {
                    totprincipal = parseInt(principal * months)
                    Int = parseInt(totalbalance - parseFloat(totprincipal))
                }


                document.getElementById('<%= totalint.ClientID %>').value = Int
                document.getElementById('<%= message.ClientID %>').value = "Entire amount of deposit & interest payable on maturity"
            }


            if (document.getElementById('<%= shortDep.ClientID %>').checked == true) {
                //short term deposit
                months = document.getElementById('<%= months.ClientID %>').value
                if (months > 0) {
                    alert("In short term calculators-insert period in days only")
                    document.getElementById('<%= months.ClientID %>').value = 0
                }
                days = document.getElementById('<%= days.ClientID %>').value
                principal = document.getElementById('<%= principal.ClientID %>').value
                rate = document.getElementById('<%= rate.ClientID %>').value
                Interest = ((principal * rate * days) / 36500)
                maturity = Math.round(parseFloat(principal) + parseFloat(Interest))
                document.getElementById('<%= maturity.ClientID %>').value = maturity
                document.getElementById('<%= totalint.ClientID %>').value = parseInt(maturity - principal)
                document.getElementById('<%= message.ClientID %>').value = "Entire amount of deposit & interest payable on maturity"
            }

            //		
            //		if (document.form1.fixed.checked==true)
            //		{	
            //			
            //			//fiexed
            //			days=document.getElementById('<%= days.ClientID %>').value
            //			principal=document.getElementById('<%= principal.ClientID %>').value
            //			rate=document.getElementById('<%= rate.ClientID %>').value
            //			months=document.getElementById('<%= months.ClientID %>').value
            //			Interest=((parseFloat(principal*rate*months)/1200)+ (parseFloat(principal*rate*days)/36500))
            //			maturity=Math.round(parseFloat(principal)  + parseFloat(Interest))
            //			document.getElementById('<%= maturity.ClientID %>').value=maturity
            //			document.getElementById('<%= totalint.ClientID %>').value= parseInt(maturity - principal)
            //			perodic =parseInt(principal * rate / 200)
            //			 document.getElementById('<%= message.ClientID %>').value="Perodic Interest :" + perodic + "  payable every half-year"	   
            //			
            //		}

            if (document.getElementById('<%= monthly.ClientID %>').checked == true) {  //MONTHLY DEPOSIT

                months = document.getElementById('<%= months.ClientID %>').value
                days = document.getElementById('<%= days.ClientID %>').value

                if (months == 0 && days == 0) {


                    document.getElementById('<%= maturity.ClientID %>').value = 0
                    document.getElementById('<%= totalint.ClientID %>').value = 0
                    document.getElementById('<%= message.ClientID %>').value = ""
                    //alert("enter month / days")
                    //return false;
                }

                else {

                    principal = document.getElementById('<%= principal.ClientID %>').value
                    rate = document.getElementById('<%= rate.ClientID %>').value
                    document.getElementById('<%= message.ClientID %>').value = ""

                    temp = (principal * rate) / 1200
                    diff = (temp * rate) / 1200
                    var intofonemonth = parseFloat(temp) - parseFloat(diff)

                    totalinterest = (intofonemonth * months) + ((principal * rate * days) / 36500)
                    maturity = Math.round(parseFloat(totalinterest) + parseFloat(principal))
                    document.getElementById('<%= maturity.ClientID %>').value = maturity
                    document.getElementById('<%= totalint.ClientID %>').value = parseInt(maturity - principal)
                    var intomonRound = Math.round(intofonemonth * Math.pow(10, 2)) / Math.pow(10, 2);
                    document.getElementById('<%= message.ClientID %>').value = "Perodic Interest :" + intomonRound + "  payable every month"
                }


            }


            if (document.getElementById('<%= quaterly.ClientID %>').checked == true) {
                months = document.getElementById('<%= months.ClientID %>').value
                days = document.getElementById('<%= days.ClientID %>').value

                if (months == 0 && days == 0) {

                    document.getElementById('<%= maturity.ClientID %>').value = 0
                    document.getElementById('<%= totalint.ClientID %>').value = 0
                    document.getElementById('<%= message.ClientID %>').value = ""
                }

                else {

                    principal = document.getElementById('<%= principal.ClientID %>').value
                    rate = document.getElementById('<%= rate.ClientID %>').value
                    months = document.getElementById('<%= months.ClientID %>').value
                    quaterint = (principal * rate) / 400
                    totalinterest = ((principal * months * rate) / 1200) + ((principal * rate * days) / 36500)
                    maturity = Math.round(parseFloat(totalinterest) + parseFloat(principal))
                    document.getElementById('<%= maturity.ClientID %>').value = maturity
                    document.getElementById('<%= totalint.ClientID %>').value = parseInt(maturity - principal)
                    var perodic = parseFloat(principal * rate / 400)
                    //var xx1=toRound(perodic);
                    var periodRound = Math.round(perodic * Math.pow(10, 2)) / Math.pow(10, 2);
                    document.getElementById('<%= message.ClientID %>').value = "Perodic Interest :" + periodRound + "  payable every quarter "
                }


            }


            if (document.getElementById('<%= doubleDep.ClientID %>').checked == true) {

                days = document.getElementById('<%= days.ClientID %>').value
                principal = document.getElementById('<%= principal.ClientID %>').value
                rate = document.getElementById('<%= rate.ClientID %>').value
                months = document.getElementById('<%= months.ClientID %>').value
                quaters = parseInt(months / 3)
                remain = parseFloat(months) - (quaters * 3)
                //alert(principal * Math.pow((1 + rate/400), quaters))
                maturity = (principal * Math.pow((1 + rate / 400), quaters)) + (parseFloat(principal * remain * rate) / 1200) + parseFloat((principal * rate * days) / 36500)
                maturity = parseInt(maturity)
                document.getElementById('<%= maturity.ClientID %>').value = maturity
                document.getElementById('<%= totalint.ClientID %>').value = parseInt(maturity - principal)
                document.getElementById('<%= message.ClientID %>').value = "Entire amount of deposit & interest payable on maturity"

            }
        }


    
    </script>
    <style type="text/css">
        @media only screen and (min-width:120px) and (max-width:768px)
        {
            .emitbl
            {
                width: 98% !important;
            }
            .tddisplay
            {
                display: block;
                width: 100% !important;
            }
            .tddisplayN
            {
                display: none !important;
            }
            .tddisplayABN
            {
                display: block;
                width: 100% !important;
                line-height: 31px;
            }
        }
        tbody tr:nth-child(even)
        {
            background-color: transparent;
        }
        .col-lg-1, .col-lg-10, .col-lg-11, .col-lg-12, .col-lg-2, .col-lg-3, .col-lg-4, .col-lg-5, .col-lg-6, .col-lg-7, .col-lg-8, .col-lg-9, .col-md-1, .col-md-10, .col-md-11, .col-md-12, .col-md-2, .col-md-3, .col-md-4, .col-md-5, .col-md-6, .col-md-7, .col-md-8, .col-md-9, .col-sm-1, .col-sm-10, .col-sm-11, .col-sm-12, .col-sm-2, .col-sm-3, .col-sm-4, .col-sm-5, .col-sm-6, .col-sm-7, .col-sm-8, .col-sm-9, .col-xs-1, .col-xs-10, .col-xs-11, .col-xs-12, .col-xs-2, .col-xs-3, .col-xs-4, .col-xs-5, .col-xs-6, .col-xs-7, .col-xs-8, .col-xs-9
        {
            padding: 10px 15px 10px 15px;
        }
        .toppadding
        {
            margin-top: 8px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="blog">
        <div class="blog container" style="width: 92%;">
            <div class="row">
                <div class="col-md-9">
                    <h1 style="color: #ce1c7b; font-size: 28px;">Deposit Calculator</h1>
                    <strong>Note : </strong> That all figures are clearly indicative.<br />
Please contact your nearest TMB Bank branch for exact figures.
                    <div class="tabbs"> 
<div class="row">
                    <div class="col-md-4  col-xs-12 col-lg-4 pull-right">
                    <div class="col-md-12  col-xs-12 col-lg-12">                    
                                <%--<input type="radio" name="r1"  id="Recurring" value="Recurring" onclick="calculate()" />--%>
                                <asp:RadioButton ID="Recurring" runat="server" onclick="reccur_checked()" />Recurring Deposit
                    </div>
                    <div class="col-md-12  col-xs-12 col-lg-12">
                    <%--<input type="radio" name="r1" id="short" value="short" onclick="calculate()" />--%>
                                <asp:RadioButton ID="shortDep" runat="server" onclick="short_checked()" />Short Deposit
                    </div>   
                    <div class="col-md-12  col-xs-12 col-lg-12">
                    <%--<input type="radio" name="r1" id="monthly" value="monthly" onclick="calculate()"/>--%>
                                <asp:RadioButton ID="monthly" runat="server" onkeydown="month_daycheck()" onclick="monthly_checked()" />Fixed Deposit-Monthly Interest
                    </div>   
                    <div class="col-md-12  col-xs-12 col-lg-12">     
                    <%--<input type="radio" name="r1" id="quaterly" value="quaterly" onclick="calculate()"/>--%>
                                <asp:RadioButton ID="quaterly" runat="server" onclick="quarterly_checked()" />Fixed Deposit-Quarterly &nbsp;Interest
                    </div>   
                    <div class="col-md-12  col-xs-12 col-lg-12">
                    <%--<input type="radio" name="r1" id="double" value="double" onclick="calculate()"/>--%>
                                <asp:RadioButton ID="doubleDep" runat="server" onclick="double_checked()" />Reinvestment Deposit
                    </div>       
                    
                    </div>
                    <div class="col-md-8  col-xs-12 col-lg-8 pull-left">
                    <div class="row">
                    <div class="col-md-5  col-xs-12 col-lg-5">Principal Amount</div>
                    <div class="col-md-7  col-xs-12 col-lg-7">
                    <%--<input type="text" id="principal" onblur="calculate()" dir="rtl" value="0" style="width: 140px" />--%>
                    <asp:TextBox ID="principal" runat="server" onblur="calculate()" CssClass="form-control" Height="35px">0</asp:TextBox></div>
                    </div>
                    <div class="row">
                    <div class="col-md-5  col-xs-12 col-lg-5 toppadding">
                    Interest Rate
                    </div>
                    <div class="col-md-7  col-xs-12 col-lg-7">
                    <%--<input type="text" id="rate" onblur="calculate()" dir="rtl" value="0" style="width: 140px" />--%>
                                    <asp:TextBox ID="rate" runat="server" onblur="calculate()" CssClass="form-control" Width=""
                                        Height="35px">0</asp:TextBox>
                    </div>
                    </div>
                    <div class="row">
                    <div class="col-md-5  col-xs-12 col-lg-5 toppadding">
                    Months
                    </div>
                    <div class="col-md-7  col-xs-12 col-lg-7">
                    <%--<input type="text"  id="months" dir="rtl" onblur="calculate()"  maxlength="3" value="0" style="width: 140px" />--%>
                                    <asp:TextBox ID="months" runat="server" onblur="calculate()" CssClass="form-control" Width=""
                                        Height="35px">0</asp:TextBox>
                    </div>
                    </div>
                    <div class="row">
                    <div class="col-md-5  col-xs-12 col-lg-5 toppadding">
                    Days
                    </div>
                    <div class="col-md-7  col-xs-12 col-lg-7">
                    <%--<input type="text"  id="days" dir="rtl" onblur="calculate()"  maxlength="4" value="0" style="width: 140px" />--%>
                                    <asp:TextBox ID="days" runat="server" onblur="calculate()" CssClass="form-control" Width=""
                                        Height="35px">0</asp:TextBox>
                    </div>
                    </div>
                    <div class="row">
                    <div class="col-md-5  col-xs-12 col-lg-5 toppadding">
                    Total Interest
                    </div>
                    <div class="col-md-7  col-xs-12 col-lg-7">
                    <%--<input type="text" readonly="readonly" dir="rtl"   id="totalint" style="width: 140px" />--%>
                                    <asp:TextBox ID="totalint" runat="server" onblur="calculate()" CssClass="form-control" Width=""
                                        Height="35px" ReadOnly="true">0</asp:TextBox>
                    </div>
                    </div>
                    <div class="row">
                    <div class="col-md-5 col-xs-12 col-lg-5 toppadding">
                    Maturity Value
                    </div>
                    <div class="col-md-7  col-xs-12 col-lg-7">
                    <%--<input type="text" readonly="readonly" id="maturity" dir="rtl" style="width: 140px" />--%>
                                    <asp:TextBox ID="maturity" runat="server" onblur="calculate()" CssClass="form-control" Width=""
                                        Height="35px" ReadOnly="true">0</asp:TextBox>
                    </div>
                </div>
            </div>                    
        </div>
        <hr />
        <div class="row">
                    <div class="col-md-8  col-xs-12 col-lg-8">
                    <div class="row">
                    <div class="col-md-5  col-xs-12 col-lg-5 toppadding"><asp:Label ID="Label14" runat="server" Font-Names="Verdana" Font-Size="14px"
                                    Text="Periodic Interest">
                                </asp:Label></div>
                    <div class="col-md-7  col-xs-12 col-lg-7">
<asp:TextBox ID="message" runat="server" Rows="2" CssClass="form-control"
                                TextMode="MultiLine" ReadOnly="true"></asp:TextBox>

                                </div>
                </div>
            </div>
                    <div class="col-md-4  col-xs-12 col-lg-4">
                    </div>                    
        </div>
                
          
                </div>
                </div>
            <div class="col-md-3 col-sm-12 related-products em" data-type="product">
<div class="hp-main-box">
<div class="main-white-box box-1 clearfix" style="background: #ececed; height: auto;   border: none;">
<img class="rel-img-right em-img lazyloaded" src="images/Car-Loan2.jpg" style="width: 100%; height: auto; display: block; border-radius: 4px 4px 0 0;">
<div class="details-box">
<div class="hp-card-box">
<h4 class="em-title share-comp-title" style="margin-top: 0px; min-height: 60px; background: transparent; border: none; color: #000; font-size: 21px;">Car Loan</h4>
</div>

<div class="clearfix">
<a class="" href="/tmb-car-loan.aspx">
<img src="images/morebtn.png">
</a>
</div>
</div>
</div>
</div>
</div>
            </div>
        </div>
    </section>
</asp:Content>
