<%@ Page Title="" Language="C#" MasterPageFile="~/tmbadm/AdmMaster.master" AutoEventWireup="true"
    CodeFile="adminTemplate.aspx.cs" Inherits="Admin_Manage_InnerPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="tbl_main" runat="server" style="width: 100%;" cellspacing="0" cellpadding="0"
        align="center" border="0">
        <tr>
            <td style="width: 5px; height: 20px;" valign="middle" align="center">
            </td>
            <td style="width: 550px; height: 20px;" valign="middle" align="center">
                <table id="Table1" runat="server" style="width: 95%; height: 246px; border: Solid thin #cccccc;
                    background-color: #F3F3F3; tamilgin-left: 65px;" cellspacing="1" cellpadding="0"
                    border="0">
                    <tr>
                        <td valign="middle" align="center" colspan="7" style="width: 510px; background-color: #585757;
                            height: 19px; padding-left: 10px;">
                            <asp:Label ID="lblAddMainHead" runat="server" Text="" ForeColor="#FFFFFF" Font-Size="15px">Search 
                        Page</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" align="left" colspan="6" style="width: 510px; height: 20px;">
                            &nbsp;<asp:Label ID="lblMainMsg" runat="server" CssClass="ErrLbl"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 25px;" valign="middle" align="left">
                        </td>
                        <td style="width: 90px; height: 25px;" valign="middle" align="left" class="label2">
                            Main Type :
                        </td>
                        <td style="width: 165px; height: 25px;" valign="middle" align="left">
                            <asp:DropDownList ID="cmbMainParentSrch" runat="server" CssClass="form-control" Width="225px"
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 10px; height: 25px;" valign="middle" align="left">
                        </td>
                        <td style="width: 90px; height: 25px;" valign="middle" align="right" class="label2">
                            Page Type :&nbsp;
                        </td>
                        <td style="width: 165px; height: 25px;" valign="middle" align="left">
                            <asp:DropDownList ID="cmbPgTypeSrch" runat="server" CssClass="form-control" Width="225px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 25px;" valign="middle" align="left">
                        </td>
                        <td style="width: 80px; height: 25px;" valign="middle" align="left" class="label2">
                            Page Name :
                        </td>
                        <td style="width: 165px; height: 25px;" valign="middle" align="left">
                            <asp:TextBox ID="txtSrchPg" runat="server" CssClass="form-control" Width="200px"
                                EnableViewState="False"></asp:TextBox>
                        </td>
                        <td style="width: 10px; height: 25px;" valign="middle" align="left">
                        </td>
                        <td style="width: 245px; height: 25px;" valign="middle" align="center" colspan="2">
                            <asp:Button ID="btnSrch" runat="server" Text="Search" CssClass="btn7" />
                            &nbsp;<asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn7" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 520px; height: 15px;" valign="middle" align="center" colspan="7">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 520px; height: 30px;" valign="middle" align="center" colspan="7">
                            <asp:Label ID="lblPage" runat="server" Text="" CssClass="label2"></asp:Label>&nbsp;<asp:LinkButton
                                ID="lnkAllPg" runat="server" Text="[All]" CssClass="label2" ForeColor="#196F30"></asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 30px; height: 20px;" valign="middle" align="center">
            </td>
            <td style="width: 400px; height: 20px;" valign="middle" align="left">
                <table id="tbl_AddPg" runat="server" style="width: 88%; border: Solid thin #cccccc;
                    background-color: #F3F3F3;" cellspacing="1" cellpadding="2" border="0">
                    <tr>
                        <td valign="middle" align="center" colspan="4" style="width: 360px; background-color: #585757;
                            height: 26px; padding-left: 20px;">
                            <asp:Label ID="lblAddEditHead" runat="server" Text="" ForeColor="#FFFFFF" Font-Size="15px">Add 
                        New Page</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" align="left" colspan="3" style="height: 18px; padding-left: 17px;">
                            &nbsp;<asp:Label ID="lblAddMsg" runat="server" CssClass="ErrLbl"></asp:Label>
                        </td>
                        <td style="width: 80px;" valign="middle" align="center" rowspan="6">
                            <table id="Table4" runat="server" style="width: 68px;" cellspacing="3" cellpadding="0"
                                border="0">
                                <tr>
                                    <td style="width: 68px; height: 30px; padding-bottom: 10px;" valign="middle" align="center">
                                        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn7" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 68px; height: 30px;" valign="middle" align="center">
                                        <asp:Button ID="btnCancel" runat="server" Text="Reset" CssClass="btn7" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 22px;" valign="middle" align="left">
                        </td>
                        <td style="width: 90px; height: 22px;" valign="middle" align="left" class="label2">
                            Main Type :
                        </td>
                        <td valign="middle" align="left" class="style1">
                            <asp:DropDownList ID="cmbMainType" runat="server" CssClass="form-control" Width="200px"
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 22px;" valign="middle" align="left">
                        </td>
                        <td style="width: 90px; height: 22px;" valign="middle" align="left" class="label2">
                            Page Type :
                        </td>
                        <td valign="middle" align="left" class="style1">
                            <asp:DropDownList ID="cmbPgType" runat="server" CssClass="form-control" Width="200px"
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr runat="server" id="PgSubType" visible="false">
                        <td style="width: 10px; height: 22px;" valign="middle" align="left">
                        </td>
                        <td style="width: 90px; height: 22px;" valign="middle" align="left" class="label2">
                            Page Sub-type :
                        </td>
                        <td valign="middle" align="left" class="style1">
                            <asp:DropDownList ID="cmbPgSubType" runat="server" CssClass="form-control" Width="200px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 22px;" valign="middle" align="left">
                        </td>
                        <td style="width: 90px; height: 22px;" valign="middle" align="left" class="label2">
                            Page Name :
                        </td>
                        <td valign="middle" align="left" class="style1">
                            <asp:TextBox ID="txtPgName" runat="server" CssClass="form-control" Width="174px"
                                EnableViewState="False" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 22px;" valign="middle" align="left">
                        </td>
                        <td style="width: 90px; height: 22px;" valign="middle" align="left" class="label2">
                            Page Title :
                        </td>
                        <td valign="middle" align="left" class="style1">
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Width="174px" EnableViewState="False"
                                MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 22px;" valign="middle" align="left">
                        </td>
                        <td style="width: 90px; height: 22px;" valign="middle" align="left" class="label2">
                            Active :
                        </td>
                        <td valign="middle" align="left" class="style1">
                            <asp:RadioButtonList ID="rdbMainAct" runat="server" RepeatDirection="Horizontal"
                                EnableViewState="False">
                                <asp:ListItem Text="Yes" Value="Y" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td height="5px" colspan="4">
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 5px; height: 20px;" valign="middle" align="center">
            </td>
        </tr>
        <tr>
            <td style="width: 970px; height: 30px;" valign="middle" align="center" colspan="5">
                <asp:Label ID="lblmsg" runat="server" CssClass="ErrLbl"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 25px;" valign="middle" align="center" colspan="5">
                <asp:DataGrid ID="dg_Pg" Width="90%" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    GridLines="None" CellSpacing="4" CellPadding="4">
                    <HeaderStyle BackColor="#1e3a8e" ForeColor="White" Height="25px" HorizontalAlign="Center"
                        CssClass="" VerticalAlign="Middle" />
                    <ItemStyle Height="20px" BackColor="#FFFFFF" HorizontalAlign="Left" VerticalAlign="Top"
                        CssClass="" />
                    <AlternatingItemStyle Height="20px" CssClass="" BackColor="#F5F5F5" HorizontalAlign="Left"
                        VerticalAlign="Top" />
                    <PagerStyle Mode="NumericPages" HorizontalAlign="center" VerticalAlign="middle" />
                    <Columns>
                        <asp:BoundColumn DataField="PageID" HeaderText="Page ID" Visible="False"></asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Sr.No.">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                            <HeaderStyle Width="5%" />
                            <ItemTemplate>
                                <%#(dg_Pg.PageSize * dg_Pg.CurrentPageIndex) + Container.ItemIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="" HeaderText="Main Page">
                            <ItemStyle Width="23%" />
                            <HeaderStyle Width="23%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="" HeaderText="Page Title">
                            <ItemStyle Width="23%" />
                            <HeaderStyle Width="23%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="" HeaderText="Page Name" Visible="false">
                            <ItemStyle Width="23%" />
                            <HeaderStyle Width="23%" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Page File Name">
                            <HeaderStyle Width="25%" />
                            <ItemStyle Width="25%" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEngPgCont" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgEngCont"></asp:LinkButton><br />
                                <asp:LinkButton ID="lnkHndPgCont" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgHndCont"></asp:LinkButton><br />
                                <asp:LinkButton ID="lnkTamilPgCont" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgTamilCont"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Action" Visible="false">
                            <HeaderStyle Width="0px" />
                            <ItemStyle HorizontalAlign="Center" Width="0px" />
                            <ItemTemplate>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Check Content" Visible="false">
                            <HeaderStyle Width="0px" />
                            <ItemStyle HorizontalAlign="Center" Width="0px" />
                            <ItemTemplate>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Menu" Visible="true">
                            <HeaderStyle Width="8%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkMenuEng" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgMenuEng">Eng.</asp:LinkButton>
                                &nbsp;|&nbsp;
                                <asp:LinkButton ID="lnkMenuHnd" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgMenuHnd">Hnd.</asp:LinkButton><br />
                                <asp:LinkButton ID="lnkMenuTamil" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgMenuTamil">Tamil.</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="ParentID" HeaderText="Parent ID" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="PageAct" HeaderText="Page Active" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="PageTitle" HeaderText="Page Title" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="" HeaderText="Hndathi Page Title" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="PageName" HeaderText="Page Name" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="" HeaderText="Hndathi Page Name" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="PageFileName" HeaderText="Page File" Visible="False">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="" HeaderText="Hndathi Page File" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="PageAct" HeaderText="Active" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="" HeaderText="Hndathi Active" Visible="False"></asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Edit">
                            <HeaderStyle Width="8%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEditEng" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgEditEng">Eng</asp:LinkButton>
                                &nbsp;|&nbsp;
                                <asp:LinkButton ID="lnkEditHnd" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgEditHnd">Hnd.</asp:LinkButton><br />
                                <asp:LinkButton ID="lnkEditTamil" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgEditTamil">Tamil.</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Delete">
                            <HeaderStyle Width="8%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDeleteEng" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgDeleteEng">Eng.</asp:LinkButton>
                                &nbsp;|&nbsp;
                                <asp:LinkButton ID="lnkDeleteHnd" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgDeleteHnd">Hnd.</asp:LinkButton><br />
                                <asp:LinkButton ID="lnkDeleteTamil" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgDeleteTamil">Tamil.</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
            </td>
        </tr>
        <tr>
            <td style="width: 970px; height: 8px;" valign="middle" align="center" colspan="5">
            </td>
        </tr>
        <tr id="tr_pg">
            <td style="width: 970px;" valign="middle" align="center" colspan="5">
                <table width="90%" align="center" cellpadding="0" cellspacing="0" border="0" bgcolor="#eeeeee"
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
                                CssClass="btn7" />
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
</asp:Content>
