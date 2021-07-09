<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="UserMasterPage.master" CodeFile="archieve-forex-rates-new.aspx.cs" Inherits="archieve_forex_rates_new" %>

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
                    <h1>Archive of Forex Rates</h1>

                    <div class="tabContainer">
                        <div aria-multiselectable="true" class="panel-group" id="accordion" role="tablist">
                            <div class="panel panel-default">
                                <div class="panel-heading" id="heading2" role="tab">
                                    <h4 class="panel-title"><a aria-controls="collapse2" aria-expanded="false" class="collapsed" data-parent="#accordion" data-toggle="collapse" href="#collapse2" role="button">Overview</a></h4>
                                </div>

                                <div aria-labelledby="heading2" class="panel-collapse collapse" id="collapse2" role="tabpanel">
                                    <div class="panel-body">
                                        <p>(get archived forex rates from past)</p>

                                        <p>This page provides you the archive of International Forex Inter Bank Rates for USD, Euro and GBP for any given past date starting from Jan 10, 2008.</p>
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading" id="heading3" role="tab">
                                    <h4 class="panel-title"><a aria-controls="collapse3" aria-expanded="false" class="collapsed" data-parent="#accordion" data-toggle="collapse" href="#collapse3" role="button">Archive Inter Bank Rates starting
                                        <asp:Label runat="server" ID="lblLinkText"></asp:Label></a></h4>
                                </div>
                                <div aria-labelledby="heading3" class="panel-collapse collapse in" id="collapse3" role="tabpanel">
                                    <div class="panel-body">
                                        <div>
                                            <div id="divForm" runat="server">
                                                <p>
                                                    <asp:Label ID="LblError" runat="server" ForeColor="Red" Text=""></asp:Label>
                                                </p>
                                                <div class="col-md-12">
                                                    <div class="col-md-3">
                                                        <label for="">Date & Period of Display</label>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:TextBox ID="txtDate" runat="server" AutoPostBack="true" TabIndex="3" onkeypress="return allowOnlyNumber(event);"
                                                            class="form-control" placeholder="DD-MM-YYYY" AutoComplete="off"
                                                            oncopy="return false" onpaste="return false"
                                                            oncut="return false"></asp:TextBox>
                                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                                            Format="dd-MM-yyyy" PopupButtonID="txtDate" PopupPosition="BottomLeft">
                                                        </asp:CalendarExtender>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:DropDownList ID="ddlPrd" runat="server" class="form-control">
                                                            <asp:ListItem Value="0" Enabled="true" Text="---Select---"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="1 Day"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="1 Week"></asp:ListItem>
                                                            <asp:ListItem Value="3" Text="1 Month"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btn_ShowClick" class="btn btn-primary em-cta related-product-click-apply" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="height: 15px"></div>
                                            <div>
                                                <asp:Label ID="lblmssg" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div style="height: 15px"></div>

                                        </div>
                                        <div class="main-contentz">
                                            <div class="table-container" id="DivRpt">

                                                <table  border ="1" cellpadding="0" cellspacing="0" width="670">
                                                    <tbody>
                                                        <tr>
                                                            <asp:Repeater ID="dgGB" runat="server">
                                                                <HeaderTemplate>
                                                                    <table class="admtbl" style="width: 60%; border: none">
                                                                        <tr style="text-align: center; background: #1E3A8E; color: White; height: 25px;">
                                                                            <th rowspan="2" valign="top">
                                                                                <p style="text-align: center;margin:0 7px 0;">Date / Time dd-mm-yy hh.mm.ss</p>
                                                                            </th>
                                                                            <th colspan="2" valign="top">
                                                                                <p style="text-align: center; ">US Dollar</p>
                                                                            </th>
                                                                            <th colspan="2" valign="top">
                                                                                <p style="text-align: center; ">Euro</p>
                                                                            </th>
                                                                            <th colspan="2" valign="top">
                                                                                <p style="text-align: center; ">GB Pounds</p>
                                                                            </th>
                                                                        </tr>
                                                                        <tr style="text-align: center; background: #1E3A8E; color: White; height: 25px;">

                                                                            <th valign="top">
                                                                                <p style="text-align: center; ">Buy</p>
                                                                            </th>
                                                                            <th valign="top">
                                                                                <p style="text-align: center; ">Sell</p>
                                                                            </th>
                                                                            <th valign="top">
                                                                                <p style="text-align: center; ">Buy</p>
                                                                            </th>
                                                                            <th valign="top">
                                                                                <p style="text-align: center; ">Sell</p>
                                                                            </th>
                                                                            <th valign="top">
                                                                                <p style="text-align: center; ">Buy</p>
                                                                            </th>
                                                                            <th valign="top">
                                                                                <p style="text-align: center; ">Sell</p>
                                                                        </tr>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td>
                                                                            <p style="text-align: center;  width:100px;"><%# Eval("SubDate") %></p>
                                                                        </td>
                                                                        <td>
                                                                            <p style="text-align: center;"><%# Eval("USBuy") %></p>
                                                                        </td>
                                                                        <td>
                                                                            <p style="text-align: center;" ><%# Eval("USSells") %></p>
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
                                                        </tr>
                                                        <%--   <tr>
                                                            <td valign="top">
                                                                <p>10-10-2019 11:00:00</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>71.0400</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>71.0500</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>77.9300</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>78.1800</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>86.7500</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>87.0000</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <p>10-10-2019 13:15:00</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>71.1300</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>71.1400</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>78.2500</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>78.5000</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>86.9000</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>87.1500</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <p>10-10-2019 15:00:00</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>71.0600</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>71.0700</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>78.1700</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>78.3200</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>86.8500</p>
                                                            </td>
                                                            <td valign="top">
                                                                <p>87.1000</p>
                                                            </td>
                                                        </tr>--%>
                                                    </tbody>
                                                </table>

                                            </div>
                                        </div>
                                        <div class="listing">
                                            <ul>
                                                <li>Rates updated only in forex trading hours on bank working days monday to friday</li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>

                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading" id="heading4" role="tab">
                                    <h4 class="panel-title"><a aria-controls="collapse4" aria-expanded="false" class="collapsed" data-parent="#accordion" data-toggle="collapse" href="#collapse4" role="button">Live Market Rates (Latest Inter Bank Rates)</a></h4>
                                </div>

                                <div aria-labelledby="heading4" class="panel-collapse collapse" id="collapse4" role="tabpanel">
                                    <div class="panel-body">
                                        <p><a href="live-rates.aspx">Click Here</a>&nbsp; this link to see the current inter bank rates table and charts.</p>
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
