<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="UserMasterPage.master" CodeFile="live-Forex-Rates.aspx.cs" Inherits="live_Forex_Rates" %>

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

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="blog">
        <div class="blog container" style="width: 92%;">
            <div class="row">
                <div class="col-md-9 col-sm-12">
                    <h1>Live Forex Rates (Latest Inter Bank Rates)</h1>

                    <div class="tabContainer">
                        <div aria-multiselectable="true" class="panel-group" id="accordion" role="tablist">
                            <div class="panel panel-default">
                                <div class="panel-heading" id="heading2" role="tab">
                                    <h4 class="panel-title"><a aria-controls="collapse2" aria-expanded="false" class="collapsed" data-parent="#accordion" data-toggle="collapse" href="#collapse2" role="button">Overview</a></h4>
                                </div>

                                <div aria-labelledby="heading2" class="panel-collapse collapse" id="collapse2" role="tabpanel">
                                    <div class="panel-body">
                                        <p>(Get live forex rates during forex trading hours)</p>

                                        <p>On this page you can see the updated live market trend.</p>

                                        <p>International Forex Market Trends and Rates for USD, Euro and GBP provided below was last updated on Nov 01 ~ 17:00 - Indian Standard Time.</p>
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading" id="heading3" role="tab">
                                    <h4 class="panel-title"><a aria-controls="collapse3" aria-expanded="false" class="collapsed" data-parent="#accordion" data-toggle="collapse" href="#collapse3" role="button">Latest Inter Bank Rates (Updated Every 15-30 Minutes)</a></h4>
                                </div>

                                <div aria-labelledby="heading3" class="panel-collapse collapse in" id="collapse3" role="tabpanel">
                                    <div class="panel-body">
                                        <div class="main-contentz">
                                            <div class="table-container">

                                                <asp:Repeater ID="dgForexRates" runat="server">
                                                    <HeaderTemplate>
                                                        <table class="admtbl" style="width: 60%; border: none">
                                                            <tr style="text-align: center; background: #1E3A8E; color: White; height: 25px;">
                                                                <th rowspan="2" valign="top">
                                                                    <p style="text-align: center; margin: 0 7px 0;">Date / Time dd-mm-yy hh.mm.ss</p>
                                                                </th>
                                                                <th colspan="2" valign="top">
                                                                    <p style="text-align: center;">US Dollar</p>
                                                                </th>
                                                                <th colspan="2" valign="top">
                                                                    <p style="text-align: center;">Euro</p>
                                                                </th>
                                                                <th colspan="2" valign="top">
                                                                    <p style="text-align: center;">GB Pounds</p>
                                                                </th>
                                                            </tr>
                                                            <tr style="text-align: center; background: #1E3A8E; color: White; height: 25px;">

                                                                <th valign="top">
                                                                    <p style="text-align: center;">Buy</p>
                                                                </th>
                                                                <th valign="top">
                                                                    <p style="text-align: center;">Sell</p>
                                                                </th>
                                                                <th valign="top">
                                                                    <p style="text-align: center;">Buy</p>
                                                                </th>
                                                                <th valign="top">
                                                                    <p style="text-align: center;">Sell</p>
                                                                </th>
                                                                <th valign="top">
                                                                    <p style="text-align: center;">Buy</p>
                                                                </th>
                                                                <th valign="top">
                                                                    <p style="text-align: center;">Sell</p>
                                                            </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <p style="text-align: center; width: 100px;"><%# Eval("SubDate") %></p>
                                                            </td>
                                                            <td>
                                                                <p style="text-align: center;"><%# Eval("USBuy") %></p>
                                                            </td>
                                                            <td>
                                                                <p style="text-align: center;"><%# Eval("USSells") %></p>
                                                            </td>
                                                            <td>
                                                                <p style="text-align: center;"><%# Eval("EuroBuy") %></p>
                                                            </td>
                                                            <td>
                                                                <p style="text-align: center;"><%# Eval("EuroSells") %></p>
                                                            </td>
                                                            <td>
                                                                <p style="text-align: center;"><%# Eval("GBBuy") %></p>
                                                            </td>
                                                            <td>
                                                                <p style="text-align: center;"><%# Eval("GBSells") %></p>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </div>

                                        <div class="listing">
                                            <ul>
                                                <li>Rates Updated as on
                                                    <asp:Label runat="server" ID="lblDt"></asp:Label>
                                                    Indian Standard Time</li>
                                                <li>Rates updated only in forex trading hours on bank working days monday to friday.</li>
                                                <li><strong>Click the currency chart link at above right to view the currency trend chart below.</strong></li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading" id="heading4" role="tab">
                                    <h4 class="panel-title"><a aria-controls="collapse4" aria-expanded="false" class="collapsed" data-parent="#accordion" data-toggle="collapse" href="#collapse4" role="button">Quick Trend Analysis</a></h4>
                                </div>

                                <div aria-labelledby="heading4" class="panel-collapse collapse" id="collapse4" role="tabpanel">
                                    <div class="panel-body">
                                        <p>The Indian rupee opened at 70.98/99 and expected to trade in the range of 70.85 to 71.15.</p>
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading" id="heading5" role="tab">
                                    <h4 class="panel-title"><a aria-controls="collapse5" aria-expanded="false" class="collapsed" data-parent="#accordion" data-toggle="collapse" href="#collapse5" role="button">Market Rates Archive</a></h4>
                                </div>

                                <div aria-labelledby="heading5" class="panel-collapse collapse" id="collapse5" role="tabpanel">
                                    <div class="panel-body">
                                        <p><a href="archieve-forex-rates.aspx">Click here</a> to see the archived market rates table for any given past date / period starting from Jan 10, 2008 onwards.</p>
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading" id="heading6" role="tab">
                                    <h4 class="panel-title"><a aria-controls="collapse6" aria-expanded="false" class="collapsed" data-parent="#accordion" data-toggle="collapse" href="#collapse6" role="button">Exchange Rate Table</a></h4>
                                </div>

                                <div aria-labelledby="heading6" class="panel-collapse collapse" id="collapse6" role="tabpanel">
                                    <div class="panel-body">
                                        <p>This table is the easy reference to inter currency conversion among the 4 currencies viz. INR / USD / EURO / GBP.</p>

                                        <div class="main-contentz">
                                            <div class="table-container">
                                                <table>
                                                    <tbody>
                                                        <tr>
                                                            <th valign="top">
                                                                <p>Currency</p>
                                                            </th>
                                                            <th valign="top">
                                                                <p>Rupees</p>
                                                            </th>
                                                            <th valign="top">
                                                                <p>US Dollar</p>
                                                            </th>
                                                            <th valign="top">
                                                                <p>Euro</p>
                                                            </th>
                                                            <th valign="top">
                                                                <p>GB Pounds</p>
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <p>Rupees</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>---</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>0.01411</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>0.01267</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>0.0109</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <p>US Dollar</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>70.8900</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>---</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>0.89791</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>0.7729</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <p>Euro</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>78.9500</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>1.1137</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>---</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>0.86077</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <p>GB Pounds</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>91.7200</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>1.29384</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>1.16175</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>---</p>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>

                                        <div class="listing">
                                            <p>&nbsp;</p>

                                            <ul>
                                                <li>Rates Updated as on <strong>Nov 01 ~ 17:00</strong> Indian Standard Time (GMT+05:30).</li>
                                                <li><strong>Rates updated only during forex trading hours on bank working days Monday to Friday.</strong></li>
                                            </ul>

                                            <p>&nbsp;</p>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading" id="heading7" role="tab">
                                    <h4 class="panel-title"><a aria-controls="collapse7" aria-expanded="false" class="collapsed" data-parent="#accordion" data-toggle="collapse" href="#collapse7" role="button">Disclaimer</a></h4>
                                </div>

                                <div aria-labelledby="heading7" class="panel-collapse collapse" id="collapse7" role="tabpanel">
                                    <div class="panel-body">
                                        <p>The currency rates given herein are only for reference and convenience. The bank has taken due care and caution in compilation of data given herein. The bank however does not guarantee the accuracy, adequacy or completeness of the data and is not responsible for any errors or omissions or for the results obtained from use of such information / data. The bank has no financial liability whatsoever to any user on account of the use of information / data provided in this page.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-3 col-sm-12 related-products em" data-type="product">
                    <div class="hp-main-box">
                        <div class="main-white-box box-1 clearfix" style="background: #ececed; height: auto; border: none;">
                            <img class="rel-img-right em-img lazyloaded" srcset="images/Navarathnamala2.jpg" style="width: 100%; height: auto; display: block; border-radius: 4px 4px 0 0;" />
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
