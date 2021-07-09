<%@ Page Title="" Language="C#" MasterPageFile="~/tmbadm/AdmMaster.master" AutoEventWireup="true"
    CodeFile="ManageState.aspx.cs" Inherits="tmbadm_ManageState" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="tbl_main" runat="server" style="width: 95%;" cellspacing="0" cellpadding="0"
        align="center" border="0">
        <tr>
            <td style="width: 2%; height: 20px;" valign="middle" align="center">
            </td>
            <td style="width: 47%; height: 20px;" valign="middle" align="center">
                <table id="Table3" runat="server" class="admtbl" cellspacing="1" cellpadding="0" style="width:80%"
                    border="0">
                    <tr>
                        <td valign="middle" align="center" class="tdHeader" colspan="5">
                            <asp:Label ID="lblHeader" runat="server" Text="">Search State</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" align="left" style="width: 510px; height: 20px;" colspan="5">
                            &nbsp;<asp:Label ID="lblMainMsg" runat="server" CssClass="error"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%; height: 20px;" valign="middle" align="center">
                        </td>
                        <td>
                            State :
                        </td>
                        <td style="width: 5%; height: 20px;" valign="middle" align="center">
                        </td>
                        <td>
                            <asp:TextBox ID="txtnamesearch" runat="server" CssClass="form-control" Style="width:90%;"></asp:TextBox>
                        </td>
                        <td style="width: 5%; height: 20px;" valign="middle" align="center">
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 2%; height: 20px;" valign="middle" align="center">
            </td>
            <td style="width: 47%; height: 20px;" valign="middle" align="left">
                <table id="Table1" runat="server" class="admtbl" cellspacing="1" cellpadding="0"
                    border="0">
                    <tr>
                        <td valign="middle" align="center" class="tdHeader">
                            <asp:Label ID="lblAddHeader" runat="server" Text="">Add State</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" align="left" style="width: 510px; height: 20px;">
                            &nbsp;<asp:Label ID="lbladdMsg" runat="server" CssClass="error"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 2%; height: 20px;" valign="middle" align="center">
            </td>
        </tr>
        <tr>
            <td valign="middle" align="center" colspan="5" style="height: 35px;">
                <asp:Label ID="lblmsg" runat="server" ForeColor="red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 25px;" valign="middle" align="right" colspan="5">
            </td>
        </tr>
        <tr>
            <td style="width: 970px; height: 8px;" valign="middle" align="center" colspan="5">
            </td>
        </tr>
        <tr id="tr_pg">
            <td style="" valign="middle" align="center" colspan="5">
                <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0" bgcolor="#eeeeee"
                    style="border: Solid 1px #cccccc">
                    <tr>
                        <td style="height: 4px;" valign="middle" align="center" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td width="475px" align="left" valign="middle" height="20px">
                            &nbsp;
                            <asp:Label ID="Label7" runat="server" Text="Change Record(s) Per Page" CssClass="label2">
                            </asp:Label>&nbsp;<asp:TextBox ID="txtPageSize" runat="server" CssClass="txt1" Width="30px"
                                MaxLength="3" onKeyPress="return checkIt(event)">
                            </asp:TextBox>&nbsp;<asp:Button ID="btnPageSize" runat="server" Text="Go" Width="35px"
                                CssClass="btn7" />
                        </td>
                        <td width="475px" align="right" valign="middle" height="20px">
                            <asp:Label ID="lblPageIndex" runat="server" Text="Skip to page" CssClass="label2">
                            </asp:Label>&nbsp;<asp:TextBox ID="txtPageIndex" runat="server" CssClass="txt1" Width="30px"
                                MaxLength="3" onKeyPress="return checkIt(event)">
                            </asp:TextBox>&nbsp;<asp:Button ID="btnPageIndex" runat="server" Text="Go" Width="35px"
                                CssClass="btn7" />&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 950px; height: 4px;" valign="middle" align="center" colspan="2">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 970px; height: 8px;" valign="middle" align="center" colspan="5">
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
</asp:Content>
