<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="UserMasterPage.master" CodeFile="forex-analysis-report-New.aspx.cs" Inherits="archieve_forex_rates_new" %>

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
    <link rel="stylesheet" href="css/accordian.css" type="text/css">
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
        function allowOnlyNumber(evt) {

            alert('Please select date');
            return false;
            // var charCode = (evt.which) ? evt.which : event.keyCode
            // if (charCode > 31 && (charCode < 48 || charCode > 57))
            //  return false;
            // return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <section id="blog">
        <div class="blog container" style="width: 92%;">
            <div class="row">
                <div class="col-md-9 col-sm-12">
                    <h1>Forex Analysis Report</h1>

                    <div class="tabContainer col-md-12">
                        <div aria-multiselectable="true" class="panel-group" id="accordion" role="tablist">
                            <div class="panel panel-default">
                                <div class="panel-heading" id="heading2" role="tab">
                                    <h4 class="panel-title"><a aria-controls="collapse2" aria-expanded="false" class="collapsed" data-parent="#accordion" data-toggle="collapse" href="#collapse2" role="button">Overview</a></h4>
                                </div>

                                <div aria-labelledby="heading2" class="panel-collapse collapse" id="collapse2" role="tabpanel">
                                    <div class="panel-body">
                                        <p>(get daily professional forex analysis report here)</p>

                                        <p>You can see the latest forex market movement trends updated frequently during forex trading hours. International Forex Market Trends and Market Analysis Report are provided by our professional forex trade dealing professionals and research team for the benefit of all our forex customers.</p>

                                        <p>International Forex Market Rates for USD, Euro and GBP provided below was last updated on Nov 01 ~ 17:00 - Indian Standard Time</p>
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading" id="heading3" role="tab">
                                    <h4 class="panel-title"><a aria-controls="collapse3" aria-expanded="false" class="collapsed" data-parent="#accordion" data-toggle="collapse" href="#collapse3" role="button">Latest Inter Bank Rates (Updated Every 15-30 Minutes)</a></h4>
                                </div>

                                <div aria-labelledby="heading3" class="panel-collapse collapse" id="collapse3" role="tabpanel">
                                    <div class="panel-body">
                                        <div class="main-contentz">
                                            <div class="table-container">
                                                <table>
                                                    <tbody>
                                                        <tr>
                                                            <th valign="top">
                                                                <p>Currency</p>
                                                            </th>
                                                            <th valign="top">
                                                                <p>Buy</p>
                                                            </th>
                                                            <th valign="top">
                                                                <p>Sell</p>
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <p>US Dollar</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p><strong>70.8100</strong></p>
                                                            </td>
                                                            <td valign="top">
                                                                <p><strong>70.8200</strong></p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <p>Euro</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p><strong>78.9500</strong></p>
                                                            </td>
                                                            <td valign="top">
                                                                <p><strong>79.2000</strong></p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <p>GB Pounds</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p><strong>91.7200</strong></p>
                                                            </td>
                                                            <td valign="top">
                                                                <p><strong>91.9700</strong></p>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>

                                        <p>&nbsp;</p>

                                        <div class="listing">
                                            <ul>
                                                <li>Rates Updated as on <strong>Nov 01 ~ 17:00</strong> Indian Standard Time.</li>
                                                <li>Rates updated during forex trading hours on bank working days Monday to Friday.</li>
                                                <li><a href="live-rates.aspx">Click Here</a> to See the Foreign Exchange Live Rates and Trend Charts.</li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="tabContainer col-md-12">
                                <div aria-multiselectable="true" class="panel-group" id="accordion" role="tablist">
                                    <div class="panel panel-default">
                                        <div class="panel-heading" id="heading42" role="tab">
                                            <h4 class="panel-title"><a aria-controls="collapse42" aria-expanded="false" class="collapsed" data-parent="#accordion42" data-toggle="collapse" href="#collapse42" role="button">Market Trend Analysis - INR / USD / EURO / GBP </a></h4>
                                        </div>

                                        <div class="panel panel-default">
                                            <div class="panel-heading" id="heading7" role="tab">
                                                <h4 class="panel-title"><a aria-controls="collapse7" aria-expanded="false" class="collapsed" data-parent="#accordion" data-toggle="collapse" href="#collapse7" role="button">1.Trend Indicators against INR</a></h4>
                                            </div>

                                            <div aria-labelledby="heading7" class="panel-collapse collapse" id="collapse7" role="tabpanel">
                                                <div class="panel-body">
                                                    <div class="main-contentz">
                                                        <div class="table-container">
                                                            <table runat="server">
                                                                <tr>
                                                                    <th valign="top">----
                                                                    </th>
                                                                    <th valign="top">USD
                                                                    </th>
                                                                    <th valign="top">EURO
                                                                    </th>
                                                                    <th valign="top">GBP
                                                                    </th>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">Previous Day
                                                                    </td>
                                                                    <td valign="top">
                                                                        <p style="text-align: center">
                                                                            <asp:Label runat="server" ID="lblPreUS"></asp:Label>
                                                                        </p>
                                                                    </td>
                                                                    <td valign="top">
                                                                        <p style="text-align: center">
                                                                            <asp:Label runat="server" ID="lblPreEURO"></asp:Label>
                                                                        </p>
                                                                    </td>
                                                                    <td valign="top">
                                                                        <p style="text-align: center">
                                                                            <asp:Label runat="server" ID="lblPreGB"></asp:Label>
                                                                        </p>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">Today's Opening
                                                                    </td>
                                                                    <td valign="top">
                                                                        <p style="text-align: center">
                                                                            <asp:Label runat="server" ID="lblTodUS"></asp:Label>
                                                                        </p>
                                                                    </td>
                                                                    <td valign="top">
                                                                        <p style="text-align: center">
                                                                            <asp:Label runat="server" ID="lblTodEURO"></asp:Label>
                                                                        </p>
                                                                    </td>
                                                                    <td valign="top">
                                                                        <p style="text-align: center">
                                                                            <asp:Label runat="server" ID="lblTodGB"></asp:Label>
                                                                        </p>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">Today Range
                                                                    </td>
                                                                    <td valign="top">
                                                                        <p style="text-align: center">
                                                                            <asp:Label runat="server" ID="lblRanUS"></asp:Label>
                                                                        </p>
                                                                    </td>
                                                                    <td valign="top">
                                                                        <p style="text-align: center">
                                                                            <asp:Label runat="server" ID="lblRanEURO"></asp:Label>
                                                                        </p>
                                                                    </td>
                                                                    <td valign="top">
                                                                        <p style="text-align: center">
                                                                            <asp:Label runat="server" ID="lblRanGB"></asp:Label>
                                                                        </p>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">Current Month
                                                                    </td>
                                                                    <td valign="top">
                                                                        <p style="text-align: center">
                                                                            <asp:Label runat="server" ID="lblCurrUS"></asp:Label>
                                                                        </p>
                                                                    </td>
                                                                    <td valign="top">
                                                                        <p style="text-align: center">
                                                                            <asp:Label runat="server" ID="lblCurrEURO"></asp:Label>
                                                                        </p>
                                                                    </td>
                                                                    <td valign="top">
                                                                        <p style="text-align: center">
                                                                            <asp:Label runat="server" ID="lblCurrGB"></asp:Label>
                                                                        </p>
                                                                    </td>
                                                                </tr>


                                                            </table>
                                                        </div>
                                                    </div>

                                                    <p>&nbsp;</p>

                                                    <p>
                                                        <strong>
                                                            <asp:Label ID="lblheading" runat="server"></asp:Label></strong>
                                                    </p>

                                                    <p>
                                                        <strong>SPOT/INR&nbsp;</strong>:
                                                        <asp:Label ID="lblspot" runat="server"></asp:Label>
                                                    </p>

                                                    <p>
                                                        <strong>FORWARD PREMIUM&nbsp;</strong>:
                                                        <asp:Label ID="lblforpre" runat="server"></asp:Label>
                                                    </p>

                                                    <p>
                                                        <strong>GLOBAL DEVELOPMENTS :</strong><br />
                                                        <asp:Label ID="lblglobal" runat="server"></asp:Label>
                                                    </p>

                                                    <p><strong>POSITIVE FACTORS FOR RUPEE :</strong></p>

                                                    <div class="listing">
                                                        <ul>
                                                            <li>
                                                                <asp:Label ID="lblpostive" runat="server"></asp:Label></li>
                                                        </ul>
                                                    </div>

                                                    <p><strong>FACTORS AGAINST RUPEE :</strong></p>

                                                    <div class="listing">
                                                        <ul>
                                                            <li>
                                                                <asp:Label ID="lblfactor" runat="server"></asp:Label></li>
                                                            <%-- <li>Due to Geopolitical Tensions and Trade war between US and China</li>--%>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="panel panel-default">
                                            <div class="panel-heading" id="heading8" role="tab">
                                                <h4 class="panel-title"><a aria-controls="collapse8" aria-expanded="false" class="collapsed" data-parent="#accordion" data-toggle="collapse" href="#collapse8" role="button">2.Indicative / Forward / Cross Rates</a></h4>
                                            </div>

                                            <div aria-labelledby="heading8" class="panel-collapse collapse" id="collapse8" role="tabpanel">
                                                <div class="panel-body">
                                                    <div class="main-contentz">
                                                        <div class="table-container">
                                                            <table runat="server" id="tblGrid" visible="false" class="tblGrid" style="height: 246px; width: 100%" cellspacing="1"
                                                                cellpadding="10" border="0">
                                                                <tbody>

                                                                    <tr>
                                                                        <th valign="top">
                                                                            <p>Currency</p>
                                                                        </th>
                                                                        <th valign="top">
                                                                            <p>For Export</p>
                                                                        </th>
                                                                        <th valign="top">
                                                                            <p>For Import</p>
                                                                        </th>
                                                                        <th valign="top">
                                                                            <p>For Export</p>
                                                                        </th>
                                                                        <th valign="top">
                                                                            <p>For Import</p>
                                                                        </th>
                                                                        <th valign="top">
                                                                            <p>For Export</p>
                                                                        </th>
                                                                        <th valign="top">
                                                                            <p>For Import</p>
                                                                        </th>
                                                                        <th valign="top">
                                                                            <p>Month</p>
                                                                        </th>

                                                                    </tr>
                                                                    <tr>
                                                                        <th></th>
                                                                        <th align="center" colspan="2" valign="top">Indicative Rates</th>
                                                                        <th align="center" colspan="2" valign="top">Indicative Forward Rates</th>
                                                                        <th align="center" colspan="2" valign="top">Indicative Cross Rates</th>
                                                                        <th></th>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <p>USD</p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblUSIREx" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblUSIRIm" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblUSIFREx" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblUSIFRIm" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblUSICREx" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblUSICRIm" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblUSMonth" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <p>GBP</p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblGBIREx" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblGBIRIm" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblGBIFREx" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblGBIFRIm" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblGBICREx" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblGBICRIm" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblGBMonth" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <p>Euro</p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblEuroIREx" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblEuroIRIm" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblEuroIFREx" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblEuroIFRIm" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblEuroICREx" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblEuroICRIm" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblEuroMonth" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <p>JPY</p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblJPYIREx" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblJPYIRIm" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblJPYIFREx" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblJPYIFRIm" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblJPYICREx" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblJPYICRIm" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblJPYMonth" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <p>CHF</p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblCHFIREx" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblCHFIRIM" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblCHFIFREx" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblCHFIFRIm" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblCHFICREx" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblCHFICRIm" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblCHFMonth" MaxLength="7" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                    </tr>

                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>

                                                    <p>&nbsp;</p>

                                                    <p><strong>Note&nbsp;</strong>: This information is given only for guidance purpose without any obligation on the part of TMB or any of its officials. Any person dealing on the basis of the said information does so at his / her own risks and no obligation arises to TMB or any of its officials. All such trading involves risks.</p>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="panel panel-default">
                                            <div class="panel-heading" id="heading9" role="tab">
                                                <h4 class="panel-title"><a aria-controls="collapse9" aria-expanded="false" class="collapsed" data-parent="#accordion" data-toggle="collapse" href="#collapse9" role="button">3.Card Rates</a></h4>
                                            </div>

                                            <div aria-labelledby="heading9" class="panel-collapse collapse" id="collapse9" role="tabpanel">
                                                <div class="panel-body">
                                                   <p> <%--Exchange Rates Information last updated in part or full on Friday, November 01, 2019 - 11:03 am (IST) for ready transactions. All quotations are per unit of Foreign Currency except Japanese Yen, which is quoted for 100 Units</p>--%>
                                                    <asp:Label ID="lblHeader" runat="server"></asp:Label></p>
                                                    <div class="main-contentz">
                                                        <div class="table-container">
                                                            <table>
                                                                <tbody>
                                                                    <tr>
                                                                        <th valign="top">
                                                                            <p>Currency</p>
                                                                        </th>
                                                                        <th valign="top">
                                                                            <p>TT</p>
                                                                        </th>
                                                                        <th valign="top">
                                                                            <p>Bills</p>
                                                                        </th>
                                                                        <th valign="top">
                                                                            <p>Cheqs</p>
                                                                        </th>
                                                                        <th valign="top">
                                                                            <p>Bills</p>
                                                                        </th>
                                                                        <th valign="top">
                                                                            <p>TT</p>
                                                                        </th>

                                                                    </tr>
                                                                    <tr>

                                                                        <th align="center" valign="top">Foreign Currency</th>
                                                                        <th align="center" colspan="3" valign="top">Buying</th>
                                                                        <th align="center" colspan="2" valign="top">Selling</th>

                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <p>USD</p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblUSBTT"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblUSBBill"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblUSBChq"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblUSSBill"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblUSSTT"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <p>GBP</p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblGBPBTT"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblGBPBBill"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblGBPBChq"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblGBPSBill"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblGBPSTT"></asp:Label>
                                                                            </p>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <p>Euro</p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblEURBTT"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblEURBBill"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblEURBChq"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblEURSBill"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblEURSTT"></asp:Label>
                                                                            </p>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <p>JPY</p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblJPYBTT"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblJPYBBill"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblJPYBChq"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblJPYSBill"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblJPYSTT"></asp:Label>
                                                                            </p>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <p>AUD</p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblAUDBTT"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblAUDBBill"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblAUDBChq"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblAUDSBill"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblAUDSTT"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <p>CAD</p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblCADBTT"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblCADBBill"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblCADBChq"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblCADSBill"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblCADSTT"></asp:Label>
                                                                            </p>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <p>CHF</p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblCHFBTT"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblCHFBBill"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblCHFBChq"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblCHFSBill"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblCHFSTT"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td valign="top">
                                                                            <p>SGD</p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblSGDBTT"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblSGDBBill"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblSGDBChq"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblSGDSBill"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblSGDSTT"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <p>AED</p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblAEDBTT"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblAEDBBill"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblAEDBChq"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblAEDSBill"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p>
                                                                                <asp:Label runat="server" ID="lblAEDSTT"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            &nbsp;

                                                            <table>
                                                                <tbody>
                                                                    <tr>
                                                                        <th valign="top">
                                                                            <p style="text-align: center">Currency</p>
                                                                        </th>
                                                                        <th valign="top">
                                                                            <p style="text-align: center">CCY Buying</p>
                                                                        </th>
                                                                        <th valign="top">
                                                                            <p style="text-align: center">CCY Selling</p>
                                                                        </th>
                                                                        <th valign="top">
                                                                            <p style="text-align: center">TC Buying</p>
                                                                        </th>
                                                                        <th valign="top">
                                                                            <p style="text-align: center">TC Selling</p>
                                                                        </th>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <p>USD</p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p style="text-align: center">
                                                                                <asp:Label runat="server" ID="lblUSDCCYBuying" TabIndex="1" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p style="text-align: center">
                                                                                <asp:Label runat="server" ID="lblUSDCCYSelling" TabIndex="1" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p style="text-align: center">
                                                                                <asp:Label runat="server" ID="lblUSDTCBuying" TabIndex="1" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p style="text-align: center">
                                                                                <asp:Label runat="server" ID="lblUSDTCSelling" TabIndex="1" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <p>GBP</p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p style="text-align: center">
                                                                                <asp:Label runat="server" ID="lblGBPCCYBuying" TabIndex="1" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p style="text-align: center">
                                                                                <asp:Label runat="server" ID="lblGBPCCYSelling" TabIndex="1" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p style="text-align: center">
                                                                                <asp:Label runat="server" ID="lblGBPTCBuying" TabIndex="1" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p style="text-align: center">
                                                                                <asp:Label runat="server" ID="lblGBPTCSelling" TabIndex="1" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <p>EUR</p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p style="text-align: center">
                                                                                <asp:Label runat="server" ID="lblEURCCYBuying" TabIndex="1" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p style="text-align: center">
                                                                                <asp:Label runat="server" ID="lblEURCCYSelling" TabIndex="1" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p style="text-align: center">
                                                                                <asp:Label runat="server" ID="lblEURTCBuying" TabIndex="1" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <p style="text-align: center">
                                                                                <asp:Label runat="server" ID="lblEURTCSelling" TabIndex="1" Width="50px"></asp:Label>
                                                                            </p>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-3 col-sm-12 related-products em" data-type="product">
                    <div class="hp-main-box">
                        <div class="main-white-box box-1 clearfix" style="background: #ececed; height: auto; border: none;">
                            <img class="rel-img-right em-img lazyloaded" src="images/Navarathnamala2.jpg" style="width: 100%; height: auto; display: block; border-radius: 4px 4px 0 0;" />
                            <div class="details-box">
                                <div class="hp-card-box">
                                    <h4 class="em-title share-comp-title" style="margin-top: 0px; min-height: 60px; background: transparent; border: none; color: #000; font-size: 21px;">Savings Account</h4>
                                </div>

                                <div class="clearfix">
                                    <a href="https://www.tmbnet.in/tmbankonline/" target="_blank">
                                        <img src="images/morebtnapply.png" /></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>


</asp:Content>
