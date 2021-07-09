<%@ Page Title="" Language="C#" MasterPageFile="~/tmbadm/AdmMaster.master" AutoEventWireup="true" CodeFile="ManageAuditTrail.aspx.cs" Inherits="Admin_ManageAuditTrail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="tbl_main" runat="server" style="width: 95%;" cellspacing="0" cellpadding="0"
        align="center" border="0">
        <tr>
                       <%-- <td style="width: 10px;" valign="top" align="left">
                        </td>--%>
                        <td  align="center" colspan="5" style="width:970px ; height: 20px;">
                            <asp:Label ID="lblMainMsg" runat="server" Class="ErrLbl"></asp:Label>
                        </td>
                    </tr>
        <tr>
            <td style="width: 90%; height: 25px;" valign="middle" align="center" colspan="2">
                <table id="tbl_NewsLtrRegist" runat="server" style="width: 70%; border:1px solid  #0d1e4a ; height:210px;" 
                    cellspacing="1" cellpadding="0" border="0">
                    <tr>
                        
                        <td valign="middle" height="30px" align="left" colspan="6" class="bgcolor"
                            style="padding-left:10px;">
                            <asp:Label ID="Label4" runat="server" Text="Audit Trail" CssClass="header"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px;" colspan="6" valign="top" align="left">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 2%; height: 40px;" valign="top" align="left">
                        </td>
                        <td valign="middle" align="left" style="width:12%;">
                            <asp:Label ID="Label2" runat="server" Text="View :"></asp:Label>
                        </td>
                        <td style="width: 35%; padding-left:3px;" valign="top" align="left" >
                            <asp:DropDownList ID="cmbView" runat="server" CssClass="form-control" Width="239px"
                                AutoPostBack="True" onselectedindexchanged="cmbView_SelectedIndexChanged">
                                <asp:ListItem Selected="True">All</asp:ListItem>
                                <asp:ListItem>Added</asp:ListItem>
                                <asp:ListItem>Updated</asp:ListItem>
                                <asp:ListItem>Deleted</asp:ListItem>
                                <asp:ListItem>Replied</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 2%;" valign="top" align="left">
                        </td>
                        <td style="width: 12%;" valign="middle" align="left">
                            <asp:Label ID="Label8" runat="server" Text="Duration :" ></asp:Label>&nbsp;
                        </td>
                        <td style="width: 35%; padding-left:3px;" valign="top" align="left">
                            <asp:DropDownList ID="cmbTimeProd" runat="server" CssClass="form-control" Width="239px"
                                AutoPostBack="True" OnSelectedIndexChanged="cmbTimeProd_SelectedIndexChanged">
                               <%-- <asp:ListItem>Today</asp:ListItem>--%>
                                <asp:ListItem Selected="True">All</asp:ListItem>
                                <asp:ListItem>Today</asp:ListItem>
                                <asp:ListItem>Date Wise</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:40px;" valign="top" align="left">
                        </td>
                        <td valign="middle" align="left">
                            <asp:Label ID="Label5" runat="server" Text="From :"></asp:Label>
                        </td>
                        <td valign="top" align="left">
                            <table>
                                <tr>
                                    <td style="width:29.41%"> 
                                <asp:DropDownList ID="cmbDD1" runat="server" Width="100%" CssClass="form-control">
                            </asp:DropDownList>
                                </td>
                                <td style="width:32.35%">
                                <asp:DropDownList ID="cmbMM1" runat="server" Width="100%" CssClass="form-control">
                                <asp:ListItem>MM</asp:ListItem>
                                <asp:ListItem Value="1">Jan</asp:ListItem>
                                <asp:ListItem Value="2">Feb</asp:ListItem>
                                <asp:ListItem Value="3">Mar</asp:ListItem>
                                <asp:ListItem Value="4">Apr</asp:ListItem>
                                <asp:ListItem Value="5">May</asp:ListItem>
                                <asp:ListItem Value="6">June</asp:ListItem>
                                <asp:ListItem Value="7">July</asp:ListItem>
                                <asp:ListItem Value="8">Aug</asp:ListItem>
                                <asp:ListItem Value="9">Sept</asp:ListItem>
                                <asp:ListItem Value="10">Oct</asp:ListItem>
                                <asp:ListItem Value="11">Nov</asp:ListItem>
                                <asp:ListItem Value="12">Dec</asp:ListItem>
                            </asp:DropDownList>
                                </td>
                                <td style="width:38.24%">
                                <asp:DropDownList ID="cmbYY1" runat="server" Width="100%" CssClass="form-control">
                            </asp:DropDownList>
                                </td>
                                </tr>
                            </table>  
                        </td>
                        <td valign="top" align="left">
                        </td>
                        <td align="left" valign="middle">
                            <asp:Label ID="Label3" runat="server" Text="To :"></asp:Label>&nbsp;
                        </td>
                        <td valign="top" align="left">
                            <table>
                                <tr>
                                    <td style="width:29.41%"> 
                                <asp:DropDownList ID="cmbDD2" runat="server" Width="100%" CssClass="form-control">
                            </asp:DropDownList>
                                </td>
                                <td style="width:32.35%">
                                <asp:DropDownList ID="cmbMM2" runat="server" Width="100%" CssClass="form-control">
                                <asp:ListItem>MM</asp:ListItem>
                                <asp:ListItem Value="1">Jan</asp:ListItem>
                                <asp:ListItem Value="2">Feb</asp:ListItem>
                                <asp:ListItem Value="3">Mar</asp:ListItem>
                                <asp:ListItem Value="4">Apr</asp:ListItem>
                                <asp:ListItem Value="5">May</asp:ListItem>
                                <asp:ListItem Value="6">June</asp:ListItem>
                                <asp:ListItem Value="7">July</asp:ListItem>
                                <asp:ListItem Value="8">Aug</asp:ListItem>
                                <asp:ListItem Value="9">Sept</asp:ListItem>
                                <asp:ListItem Value="10">Oct</asp:ListItem>
                                <asp:ListItem Value="11">Nov</asp:ListItem>
                                <asp:ListItem Value="12">Dec</asp:ListItem>
                            </asp:DropDownList>
                                </td>
                                <td style="width:38.24%">
                                <asp:DropDownList ID="cmbYY2" runat="server" Width="100%" CssClass="form-control">
                            </asp:DropDownList>
                                </td>
                                </tr>
                            </table>                            
                        </td>
                    </tr>
                    <tr>
                        <td style="height:40px;">
                        </td>
                        <td align="left">
                            User :
                        </td>
                        <td align="left" style="padding-left:3px;">
                            <asp:DropDownList ID="ddluser" runat="server" CssClass="form-control" Width="239px"
                                AutoPostBack="False" onselectedindexchanged="ddluser_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                        <td align="left">
                           <%-- Type :--%>
                            Page :</td>
                        <td align="left" style="padding-left:3PX;">
                            <asp:DropDownList ID="ddlpage" runat="server" Width="239px" CssClass="form-control">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" align="center" colspan="6">
                            <asp:Button ID="btnSrch" runat="server" Text="Search" CssClass="btn7"
                                OnClick="btnSrch_Click"  />&nbsp;&nbsp;
                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn7"
                                OnClick="btnReset_Click"  />
                        </td>
                    </tr>
                     <tr>
                        <td style="height: 5px;" colspan="6" valign="top" align="left">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 970px; height: 20px;" valign="top" align="center" colspan="2">
            <br />
                <asp:Label ID="lblmsg" runat="server" CssClass="ErrLbl" 
                    ></asp:Label>               
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 25px;" valign="middle" align="center" colspan="2">
             <br />
                <div style="vertical-align: top; width: 100%;  overflow: auto" id="divprint">
                    <asp:DataGrid ID="dg_audit" Width="100%" runat="server" AllowPaging="true" 
                        AutoGenerateColumns="False" CellSpacing="5" CellPadding="5" PageSize="10" OnItemDataBound="dg_audit_ItemDataBound"
                        OnPageIndexChanged="dg_audit_PageIndexChanged" 
                        Font-Names="Times New Roman" GridLines="None" 
                        onitemcommand="dg_audit_ItemCommand" 
                        onselectedindexchanged="dg_audit_SelectedIndexChanged">
                        <HeaderStyle BackColor="#1E3A8E" ForeColor="#FFFFFF" Height="25px" HorizontalAlign="Center"
                            CssClass="" VerticalAlign="Middle"  
                            Font-Size="16px" />
                        <ItemStyle Height="20px" BackColor="#FFFFFF" HorizontalAlign="Left" VerticalAlign="Top"
                            CssClass="padding" Font-Size="15px" Font-Names="Times New Roman" />
                        <PagerStyle Mode="NumericPages" HorizontalAlign="center" VerticalAlign="middle" 
                            Font-Names="Times New Roman" Font-Size="16px"/>
                        <AlternatingItemStyle Height="20px" CssClass="padding" BackColor="WhiteSmoke" HorizontalAlign="Left" Font-Names="Times New Roman"
                            VerticalAlign="Top" Font-Size="15px" />
                        <Columns>
                            <asp:BoundColumn DataField="id1" HeaderText="Audit ID" Visible="False"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Sr.No.">
                                <ItemStyle HorizontalAlign="Center" Width="3%" />
                                <HeaderStyle Width="3%" />
                                <ItemTemplate>
                                    <%#(dg_audit.PageSize * dg_audit.CurrentPageIndex) + Container.ItemIndex + 1%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="" HeaderText="Action Details">
                                <ItemStyle Width="11%" CssClass="padding"/>
                                <HeaderStyle Width="11%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="" HeaderText="Module Details">
                                <ItemStyle Width="16%" CssClass="padding"/>
                                <HeaderStyle Width="16%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="" HeaderText="Page Details">
                                <ItemStyle Width="19%" CssClass="padding"/>
                                <HeaderStyle Width="19%" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Content Changes">
                                <ItemStyle Width="11%" VerticalAlign="Middle" HorizontalAlign="Center"/>
                                <HeaderStyle Width="11%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkChangesMade" runat="server" Text="Show content changes" CommandName="PgChanges">
                                    </asp:LinkButton>
                                    <asp:Label ID="lblChangesDetails" runat="server" Text="" Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="" HeaderText="Added On">
                                <ItemStyle Width="8%" HorizontalAlign="Center" CssClass="padding"/>
                                <HeaderStyle Width="8%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="" HeaderText="Updated On">
                                <ItemStyle Width="8%" HorizontalAlign="Center" CssClass="padding"/>
                                <HeaderStyle Width="8%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="" HeaderText="Checked On">
                                <ItemStyle Width="8%" HorizontalAlign="Center" CssClass="padding"/>
                                <HeaderStyle Width="8%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="" HeaderText="Deleted On">
                                <ItemStyle Width="8%" HorizontalAlign="Center" CssClass="padding"/>
                                <HeaderStyle Width="8%" />
                            </asp:BoundColumn>
                             <asp:BoundColumn DataField="" HeaderText="Replied On">
                                <ItemStyle Width="8%" HorizontalAlign="Center" CssClass="padding"/>
                                <HeaderStyle Width="8%" />
                            </asp:BoundColumn>
                           
                        </Columns>
                    </asp:DataGrid>
                </div>
            </td>
        </tr>
        <tr>
                                    <td style="width: 970px; height: 1px;" valign="middle" align="center" colspan="2">
                                    &nbsp;
                                    </td>
                                </tr>
        <tr id="tr_pg">
            <td style="width: 100%;" valign="middle" align="center" colspan="5">
                <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0" bgcolor="#eeeeee"
                    style="border: Solid 1px #cccccc">
                    <tr>
                        <td style="height: 4px;" valign="middle" align="center" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td width="50%" align="left" valign="middle" height="20px">
                            &nbsp;
                            <asp:Label ID="Label7" runat="server" Text="Change Record(s) Per Page" CssClass="label2">
                            </asp:Label>&nbsp;<asp:TextBox ID="txtPageSize" runat="server" CssClass="txt1" Width="30px"
                                MaxLength="3" onKeyPress="return checkIt(event)" >
                            </asp:TextBox>&nbsp;<asp:Button ID="btnPageSize" runat="server" Text="Go" Width="35px"
                                OnClick="btnPageSize_Click" CssClass="btn7" /><%--BackColor="	#024690" ForeColor="#FFFFFF" --%>
                        </td>
                        <td width="50%" align="right" valign="middle" height="20px">
                            <asp:Label ID="lblPageIndex" runat="server" Text="Skip to page" CssClass="label2">
                            </asp:Label>&nbsp;<asp:TextBox ID="txtPageIndex" runat="server" CssClass="txt1" Width="30px"
                                MaxLength="3" onKeyPress="return checkIt(event)" >
                            </asp:TextBox>&nbsp;<asp:Button ID="btnPageIndex" runat="server" Text="Go" Width="35px"
                               OnClick="btnPageIndex_Click" CssClass="btn7" />&nbsp;<%-- BackColor="#024690" ForeColor="#FFFFFF"--%>
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
            <td style="width: 970px; height: 8px;" valign="middle" align="center" colspan="2">
            </td>
        </tr>
    </table>
</asp:Content>

