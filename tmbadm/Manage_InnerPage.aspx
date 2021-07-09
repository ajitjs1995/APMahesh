<%@ Page Title="" Language="C#" MasterPageFile="~/tmbadm/AdmMaster.master" AutoEventWireup="true"
    CodeFile="Manage_InnerPage.aspx.cs" Inherits="Admin_Manage_InnerPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="tbl_main" runat="server" style="width: 95%;" cellspacing="0" cellpadding="0"
        align="center" border="0">
        <tr>
            <td style="width: 5px; height: 20px;" valign="middle" align="center">
            </td>
            <td style="width: 550px; height: 20px;" valign="middle" align="center">
                <table id="Table3" runat="server" class="admtbl" style="height: 246px;" cellspacing="1"
                    cellpadding="0" border="0">
                    <tr>
                        <td valign="middle" align="center" colspan="7" style="height: 19px!Important;" class="tdHeader">
                            <asp:Label ID="Label1" runat="server" Text="" Font-Size="15px">Search 
                        Page</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" align="left" colspan="6" style="width: 510px; height: 20px;">
                            &nbsp;<asp:Label ID="lblMainMsg" runat="server" CssClass="error" ForeColor="red"></asp:Label>
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
                                AutoPostBack="true" OnSelectedIndexChanged="cmbMainParentSrch_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 10px; height: 25px;" valign="middle" align="left">
                        </td>
                        <td style="width: 90px; height: 25px;" valign="middle" align="right" class="label2">
                            Page Type :&nbsp;
                        </td>
                        <td style="width: 165px; height: 25px;" valign="middle" align="left">
                            <asp:DropDownList ID="cmbPgTypeSrch" runat="server" CssClass="form-control" AutoPostBack="true"
                                Width="225px" OnSelectedIndexChanged="cmbPgTypeSrch_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr runat="server" id="Tr1" visible="false">
                        <td style="width: 10px; height: 22px;" valign="middle" align="left">
                        </td>
                        <td style="width: 90px; height: 22px;" valign="middle" align="left" class="label2">
                            Page Sub-type :
                        </td>
                        <td valign="middle" align="left" class="style1">
                            <asp:DropDownList ID="ddlsrchsubtype" runat="server" CssClass="form-control" Width="224px">
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
                            <asp:Button ID="btnSrch" runat="server" Text="Search" Width="90px" CssClass="btn7"
                                OnClick="btnSrch_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnReset" runat="server" Text="Reset" Width="90px" CssClass="btn7"
                                OnClick="btnReset_Click" />
                            <asp:Button ID="lblallview" runat="server" Text="View All" CssClass="btn7" Width="90px"
                                Visible="false" OnClick="lblallview_Click" />
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 520px; height: 15px;" valign="middle" align="center" colspan="7">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 520px; height: 30px;" valign="middle" align="center" colspan="7">
                            <asp:Label ID="lblPage" runat="server" Text="" CssClass="label2"></asp:Label>&nbsp;<asp:LinkButton
                                ID="lnkAllPg" runat="server" Text="[All]" CssClass="label2" ForeColor="#196F30"
                                OnClick="lnkAllPg_Click"></asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 30px; height: 20px;" valign="middle" align="center">
            </td>
            <td style="width: 400px; height: 20px;" valign="middle" align="left">
                <table id="Table4" runat="server" class="admtbl" cellspacing="1" cellpadding="2"
                    border="0">
                    <tr>
                        <td valign="middle" align="center" colspan="4" style="width: 360px; height: 26px;
                            padding-left: 20px;" class="tdHeader">
                            <asp:Label ID="lblAddEditHead" runat="server" Text="" ForeColor="#FFFFFF">Add 
                        New Page</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" align="left" colspan="3" style="height: 18px; padding-left: 17px;">
                            &nbsp;<asp:Label ID="lblAddMsg" runat="server" CssClass="error"></asp:Label>
                        </td>
                        <td style="width: 80px;" valign="middle" align="center" rowspan="6">
                            <table id="Table5" runat="server" style="width: 68px;" cellspacing="3" cellpadding="0"
                                border="0">
                                <tr>
                                    <td style="width: 68px; height: 30px; padding-bottom: 10px;" valign="middle" align="center">
                                        <asp:Button ID="btnAdd" runat="server" Text="Add" Width="90px" CssClass="btn7" OnClick="btnAdd_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 68px; height: 30px;" valign="middle" align="center">
                                        <asp:Button ID="btnCancel" runat="server" Text="Reset" Width="90px" CssClass="btn7"
                                            OnClick="btnCancel_Click" />
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
                            <asp:DropDownList ID="cmbMainType" runat="server" CssClass="form-control" Width="225px"
                                AutoPostBack="true" OnSelectedIndexChanged="cmbMainType_SelectedIndexChanged">
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
                            <asp:DropDownList ID="cmbPgType" runat="server" CssClass="form-control" Width="225px"
                                AutoPostBack="True" OnSelectedIndexChanged="cmbPgType_SelectedIndexChanged">
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
                            <asp:DropDownList ID="cmbPgSubType" runat="server" CssClass="form-control" Width="225px">
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
                            <asp:TextBox ID="txtPgName" runat="server" CssClass="form-control" Width="200px"
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
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Width="200px" EnableViewState="False"
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
                                EnableViewState="False" BackColor="White">
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
            <td valign="middle" align="center" colspan="5" style="height: 35px;">
                <asp:Label ID="lblmsg" runat="server" ForeColor="red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 25px;" valign="middle" align="right" colspan="5">
                <asp:DataGrid ID="dg_Pg" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    GridLines="None" CellSpacing="4" CellPadding="4" PageSize="5" OnItemCommand="dg_Pg_ItemCommand"
                    OnItemDataBound="dg_Pg_ItemDataBound" OnPageIndexChanged="dg_Pg_PageIndexChanged">
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
                            <ItemStyle Width="50px" CssClass="tdpaddingitem" HorizontalAlign="Center" />
                            <HeaderStyle Width="5%" CssClass="tdpadding" />
                            <ItemTemplate>
                                <%#(dg_Pg.PageSize * dg_Pg.CurrentPageIndex) + Container.ItemIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="" HeaderText="Main Page">
                            <ItemStyle Width="18%" CssClass="tdpaddingitem" />
                            <HeaderStyle Width="18%" CssClass="tdpadding" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="" HeaderText="Page Title">
                            <ItemStyle Width="18%" CssClass="tdpaddingitem" />
                            <HeaderStyle Width="18%" CssClass="tdpadding" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="" HeaderText="Page Name" Visible="false">
                            <ItemStyle Width="18%" CssClass="tdpaddingitem" />
                            <HeaderStyle Width="18%" CssClass="tdpadding" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Page File Name">
                            <HeaderStyle Width="18%" CssClass="tdpadding" />
                            <ItemStyle Width="18%" CssClass="tdpaddingitem" />
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
                            <HeaderStyle Width="6.8%" CssClass="tdpadding" />
                            <ItemStyle Width="6.8%" CssClass="tdpaddingitem" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkMenuEng" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgMenuEng">Eng.</asp:LinkButton>
                                <br />
                                <asp:LinkButton ID="lnkMenuHnd" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgMenuHnd">Hnd.</asp:LinkButton><br />
                                <asp:LinkButton ID="lnkMenuTam" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgMenuTamil">tam.</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="ParentID" HeaderText="Parent ID" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="PageAct" HeaderText="Page Active" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="PageTitle" HeaderText="Page Title" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="TitleHnd" HeaderText="Hndathi Page Title" Visible="False">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="PageName" HeaderText="Page Name" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="PgNmHnd" HeaderText="Hndathi Page Name" Visible="False">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="PageFileName" HeaderText="Page File" Visible="False">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="PgFileHnd" HeaderText="Hndathi Page File" Visible="False">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="PageAct" HeaderText="Active" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="PageActHnd" HeaderText="Hndathi Active" Visible="False">
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Edit">
                            <HeaderStyle Width="6.8%" CssClass="tdpadding" />
                            <ItemStyle Width="6.8%" CssClass="tdpaddingitem" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEditEng" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgEditEng">Eng</asp:LinkButton>
                                <br />
                                <asp:LinkButton ID="lnkEditHnd" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgEditHnd">Hnd.</asp:LinkButton><br />
                                <asp:LinkButton ID="lnkEditTam" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgEditTam">Tam.</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Delete">
                            <HeaderStyle Width="6.8%" CssClass="tdpadding" />
                            <ItemStyle Width="6.8%" CssClass="tdpaddingitem" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDeleteEng" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgDeleteEng">Eng.</asp:LinkButton>
                                <br />
                                <asp:LinkButton ID="lnkDeleteHnd" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgDeleteHnd">Hnd.</asp:LinkButton><br />
                                <asp:LinkButton ID="lnkDeleteTam" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgDeleteTam">Tam.</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <%--      ---------------------------------for checker 21 --%>
                        <asp:TemplateColumn HeaderText="Check Menu">
                            <HeaderStyle Width="6.8%" CssClass="tdpadding" />
                            <ItemStyle Width="6.8%" CssClass="tdpaddingitem" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkcheckMenuEng" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgMenucheckEng">Eng.</asp:LinkButton>
                                <br />
                                <asp:LinkButton ID="lnkcheckMenuHnd" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgMenucheckHnd">Hnd.</asp:LinkButton><br />
                                <asp:LinkButton ID="lnkcheckMenuTam" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgMenucheckTam">Tam.</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Check Edit">
                            <HeaderStyle Width="6.8%" CssClass="tdpadding" />
                            <ItemStyle Width="6.8%" CssClass="tdpaddingitem" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkcheckEditEng" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgEditcheckEng">Eng</asp:LinkButton>
                                <br />
                                <asp:LinkButton ID="lnkcheckEditHnd" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgEditcheckHnd">Hnd.</asp:LinkButton><br />
                                <asp:LinkButton ID="lnkcheckEditTam" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgEditcheckTam">Tam.</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="PageActTam" HeaderText="Page Active" Visible="False">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="PgNmTam" HeaderText="Page Title" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="TitleTam" HeaderText="Tamil Page Title" Visible="False">
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Check Delete">
                            <HeaderStyle Width="6.8%" CssClass="tdpadding" />
                            <ItemStyle Width="6.8%" CssClass="tdpaddingitem" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkcheckDelEng" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgDelcheckEng">Eng</asp:LinkButton>
                                <br />
                                <asp:LinkButton ID="lnkcheckDeltHnd" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgDelcheckHnd">Hnd.</asp:LinkButton><br />
                                <asp:LinkButton ID="lnkcheckDelTam" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgDelcheckTam">Tam.</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Meta Data">
                            <HeaderStyle Width="6.8%" CssClass="tdpadding" />
                            <ItemStyle Width="6.8%" CssClass="tdpaddingitem" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkMetaData" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgmetadataEng">Eng</asp:LinkButton><br />
                                <asp:LinkButton ID="lnkMetaDataHnd" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="Pgmetadatahnd">Hnd.</asp:LinkButton><br />
                                <asp:LinkButton ID="lnkMetaDataKan" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgmetadataTam">Tam.</asp:LinkButton>
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
                                OnClick="btnPageSize_Click" CssClass="btn7" /><%--BackColor="	#024690" ForeColor="#FFFFFF" --%>
                        </td>
                        <td width="475px" align="right" valign="middle" height="20px">
                            <asp:Label ID="lblPageIndex" runat="server" Text="Skip to page" CssClass="label2">
                            </asp:Label>&nbsp;<asp:TextBox ID="txtPageIndex" runat="server" CssClass="txt1" Width="30px"
                                MaxLength="3" onKeyPress="return checkIt(event)">
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
            <td style="width: 970px; height: 8px;" valign="middle" align="center" colspan="5">
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
</asp:Content>
