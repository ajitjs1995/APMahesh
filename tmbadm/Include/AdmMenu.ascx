<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdmMenu.ascx.cs" Inherits="tmbadm_Include_AdmMenu" %>
<link href="../Css/Page.css" type="text/css" rel="Stylesheet" />
<link href="../css/Style-admin.css" type="text/css" rel="Stylesheet" />
<style type="text/css">
    .AdmMenutab2
    {
        color: White;
    }
    .pinkfont
    {
        color: Black !important;
    }
</style>
<div class="div_1234">
    <table width="100%" cellpadding="0" cellspacing="0" border="0" align="left">
        <tr>
            <td style="width: 100%; height: 24px; background-color: #1E3A8E; font-size: 15px;"
                valign="middle" align="left">
                <table width="90%" cellpadding="0" cellspacing="0" border="0" align="center">
                    <tr>
                        <td style="width: 11%; height: 24px;" valign="middle" align="center" class="AdmMenutab2"
                            rowspan="3">
                            <asp:LinkButton ID="lnkManageadministration" runat="server" CssClass="AdmMenutab2"
                                OnClick="lnkManageadministration_Click">Administration</asp:LinkButton>
                        </td>
                        <td style="width: 1px; height: 7px;" valign="middle" align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 6%; height: 45px;" valign="middle" align="center" class="AdmMenutab2"
                            rowspan="3">
                            <asp:LinkButton ID="lnkManageCMS" runat="server" CssClass="AdmMenutab2" OnClick="lnkManageCMS_Click">CMS</asp:LinkButton>
                        </td>
                        <td style="width: 1px; height: 7px;" valign="middle" align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 7.5%; height: 45px;" valign="middle" align="center" class="AdmMenutab2"
                            rowspan="3">
                            <asp:LinkButton ID="lnkManageMasters" runat="server" CssClass="AdmMenutab2" 
                                onclick="lnkManageMasters_Click">Masters</asp:LinkButton>
                        </td>
                        <td style="width: 1px; height: 7px;" valign="middle" align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 16%; height: 24px;" valign="middle" align="center" class="AdmMenutab2"
                            rowspan="3">
                            <asp:LinkButton ID="lnkManageForexRates" runat="server" CssClass="AdmMenutab2" OnClick="lnkManageForexRates_Click">Manage Forex Rates</asp:LinkButton>
                        </td>
                        <td style="width: 1px; height: 7px;" valign="middle" align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 6.5%; height: 24px;" valign="middle" align="center" class="AdmMenutab2"
                            rowspan="3">
                            <%--<asp:LinkButton ID="lnkleads" runat="server" CssClass="AdmMenutab2">Leads</asp:LinkButton>--%>
                        </td>
                        <td style="width: 1px; height: 7px;" valign="middle" align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 100px; height: 24px;" valign="middle" align="center" class="AdmMenutab2"
                            rowspan="3">
                            <%--<asp:LinkButton ID="lnkgrievance" runat="server" CssClass="AdmMenutab2">Grievance</asp:LinkButton>--%>
                        </td>
                        <td style="width: 1px; height: 7px;" valign="middle" align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 90px; height: 24px;" valign="middle" align="center" class="AdmMenutab2"
                            rowspan="3">
                            <%--<asp:LinkButton ID="lnktender" runat="server" CssClass="AdmMenutab2">Tender</asp:LinkButton>--%>
                        </td>
                        <td style="width: 1px; height: 7px;" valign="middle" align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 100px; height: 24px;" valign="middle" align="center" class="AdmMenutab2"
                            rowspan="3">
                            <%--<asp:LinkButton ID="lnkauction" runat="server" CssClass="AdmMenutab2">Auction Property</asp:LinkButton>--%>
                        </td>
                        <td style="width: 1px; height: 7px;" valign="middle" align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 100px; height: 24px;" valign="middle" align="center" class="AdmMenutab2"
                            rowspan="3">
                            <%--<asp:LinkButton ID="lnkpressrelease" runat="server" CssClass="AdmMenutab2">Press Release</asp:LinkButton>--%>
                        </td>
                        <td style="width: 1px; height: 7px;" valign="middle" align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 86px; height: 24px;" valign="middle" align="center" class="AdmMenutab2"
                            rowspan="3">
                            <asp:LinkButton ID="lnkManageAudit" runat="server" CssClass="AdmMenutab2" OnClick="lnkManageAudit_Click">Audit Trial</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 1px; height: 10px; background-color: transparent" valign="middle"
                            align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 1px; height: 10px; background-color: transparent" valign="middle"
                            align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 1px; height: 10px; background-color: transparent" valign="middle"
                            align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 1px; height: 10px; background-color: transparent" valign="middle"
                            align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 1px; height: 10px; background-color: transparent" valign="middle"
                            align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 1px; height: 10px; background-color: transparent" valign="middle"
                            align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 1px; height: 10px; background-color: transparent" valign="middle"
                            align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 1px; height: 10px; background-color: transparent" valign="middle"
                            align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 1px; height: 10px; background-color: transparent" valign="middle"
                            align="center" class="AdmMenutab2">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 1px; height: 7px;" valign="middle" align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 1px; height: 7px;" valign="middle" align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 1px; height: 7px;" valign="middle" align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 1px; height: 7px;" valign="middle" align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 1px; height: 7px;" valign="middle" align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 1px; height: 7px;" valign="middle" align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 1px; height: 7px;" valign="middle" align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 1px; height: 7px;" valign="middle" align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 1px; height: 7px;" valign="middle" align="center" class="AdmMenutab2">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="middle" align="center" class="AdmMenutab2">

             <%--''''''''''''''''''''''''''''''  cms menu  ''''''''''''''''''''''''''--%>
                <table id="tbl_administration" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 400px;"
                    align="left">
                    <tr>
                        <td style="width: 130px; height: 22px;" valign="middle" align="center" class="AdmMenutab4"
                            rowspan="3">
                            <asp:LinkButton ID="Lnkmangeruser" runat="server" CssClass="pinkfont" 
                                onclick="Lnkmangeruser_Click">Manage User</asp:LinkButton>
                        </td>
                        <td style="width: 1px; height: 5px;" valign="middle" align="center">
                        </td>
                        <td style="width: 124px; height: 22px;" valign="middle" align="center" class="AdmMenutab4"
                            rowspan="3">
                          
                        </td>
                        <%-- <td style="width: 1px; height: 5px;" valign="middle" align="center">
                        </td>
                        <td style="width: 124px; height: 22px;" valign="middle" align="center" class="AdmMenutab4"
                            rowspan="3">
                            <asp:LinkButton ID="lnkfooter" runat="server" CssClass="pinkfont">Manage Footer</asp:LinkButton>
                        </td>--%>
                    </tr>
                    <%--<tr>
                        <td style="width: 1px; height: 12px; background-color:#000;" valign="middle" align="center">
                        </td>
                        <td style="width: 1px; height: 12px; background-color:#000;" valign="middle" align="center">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 1px; height: 5px;" valign="middle" align="center">
                        </td>
                    </tr>--%>
                </table>
                <%--''''''''''''''''''''''''''''''  cms menu  ''''''''''''''''''''''''''--%>
                <table id="tblCMS" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 400px;"
                    align="left">
                    <tr>
                        <td style="width: 130px; height: 22px;" valign="middle" align="center" class="AdmMenutab4"
                            rowspan="3">
                            <asp:LinkButton ID="lnkManageInnerPg" runat="server" CssClass="pinkfont" OnClick="lnkManageInnerPg_Click">Manage Inner Pages</asp:LinkButton>
                        </td>
                        <td style="width: 1px; height: 5px;" valign="middle" align="center">
                        </td>
                        <td style="width: 124px; height: 22px;" valign="middle" align="center" class="AdmMenutab4"
                            rowspan="3">
                            <asp:LinkButton ID="lnkinnerpagebanner" runat="server" CssClass="pinkfont" OnClick="lnkinnerpagebanner_Click">Manage InnerPage Banner</asp:LinkButton>
                        </td>
                        <%-- <td style="width: 1px; height: 5px;" valign="middle" align="center">
                        </td>
                        <td style="width: 124px; height: 22px;" valign="middle" align="center" class="AdmMenutab4"
                            rowspan="3">
                            <asp:LinkButton ID="lnkfooter" runat="server" CssClass="pinkfont">Manage Footer</asp:LinkButton>
                        </td>--%>
                    </tr>
                    <%--<tr>
                        <td style="width: 1px; height: 12px; background-color:#000;" valign="middle" align="center">
                        </td>
                        <td style="width: 1px; height: 12px; background-color:#000;" valign="middle" align="center">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 1px; height: 5px;" valign="middle" align="center">
                        </td>
                    </tr>--%>
                </table>
                <%--''''''''''''''''''''''''''''''  Master menu  ''''''''''''''''''''''''''--%>
                <table id="TblMaster" runat="server" width="500px" cellpadding="0" cellspacing="0"
                    border="0" align="left">
                    <tr>
                        <td style="width: 130px; height: 22px;" valign="middle" align="center" class="AdmMenutab4"
                            rowspan="3">
                            <asp:LinkButton ID="lnkpress" runat="server" CssClass="pinkfont" 
                                onclick="lnkpress_Click">Manage Press Relase</asp:LinkButton>
                        </td>
                        <td style="width: 1px; height: 5px;" valign="middle" align="center">
                        </td>
                        <td style="width: 124px; height: 22px;" valign="middle" align="center" class="AdmMenutab4"
                            rowspan="3">
                            <asp:LinkButton ID="lnksale" runat="server" CssClass="pinkfont" 
                                onclick="lnksale_Click">Manage Sale Notice</asp:LinkButton>
                        </td>
                       <%-- <td style="width: 1px; height: 5px;" valign="middle" align="center">
                        </td>
                        <td style="width: 124px; height: 22px;" valign="middle" align="center" class="AdmMenutab4"
                            rowspan="3">
                            <asp:LinkButton ID="lnkcity" runat="server" CssClass="pinkfont">Manage City</asp:LinkButton>
                        </td>--%>
                    </tr>
                   <%-- <tr>
                        <td style="width: 1px; height: 12px; background-color: #000;" valign="middle" align="center">
                        </td>
                        <td style="width: 1px; height: 12px; background-color: #000;" valign="middle" align="center">
                        </td>
                    </tr>--%>
                    <tr>
                        <td style="width: 1px; height: 5px;" valign="middle" align="center">
                        </td>
                    </tr>
                </table>

                   <%--''''''''''''''''''''''''''''''  Forex menu  ''''''''''''''''''''''''''--%>
                <table id="tblForex" runat="server" width="100%" cellpadding="0" cellspacing="0"
                    border="0" align="left">
                    <tr>
                        <td style="width: 20%; height: 22px;" valign="middle" align="center" class="AdmMenutab4"
                            rowspan="3">
                            <asp:LinkButton ID="lnkMngLiveRates" runat="server" CssClass="pinkfont" OnClick="lnkMngLiveRates_Click" >Manage Live Forex Rates</asp:LinkButton>
                        </td>
                       
                        <td style="width: 20%; height: 22px;" valign="middle" align="center" class="AdmMenutab4"
                            rowspan="3">
                            <asp:LinkButton ID="lnkMngTrendIndicators" runat="server" CssClass="pinkfont" OnClick="lnkMngTrendIndicators_Click" >Manage Trend Indicators</asp:LinkButton>
                        </td>
                        
                        <td style="width: 25%; height: 22px;" valign="middle" align="center" class="AdmMenutab4"
                            rowspan="3">
                            <asp:LinkButton ID="lnkMngIFCR" runat="server" CssClass="pinkfont" OnClick="lnkMngIFCR_Click">Manage Indicative / Forward / Cross Rates</asp:LinkButton>
                        </td>
                         <td style="width: 20%; height: 22px;" valign="middle" align="center" class="AdmMenutab4"
                            rowspan="3">
                            <asp:LinkButton ID="lnkMngCardRates" runat="server" CssClass="pinkfont" OnClick="lnkMngCardRates_Click">Manage Cards Rates</asp:LinkButton>
                        </td>
                    </tr>
                  
                    <tr>
                        <td style="width: 1px; height: 5px;" valign="middle" align="center">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
