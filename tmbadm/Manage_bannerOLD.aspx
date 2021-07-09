<%@ Page Title="" Language="C#" MasterPageFile="~/tmbadm/AdmMaster.master" AutoEventWireup="true"
    CodeFile="Manage_banner.aspx.cs" Inherits="Admin_Manage_banner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .btn7
        {
            border: thin solid Silver;
            font-size: 11px;
            font-weight: bold;
            font-family: Verdana, Helvetica, sans-serif;
            background-color: #DA251C;
            color: #FFFFFF;
            text-align: center;
            margin-left: 0px;
            padding-top: 3px;
            text-shadow: 1px 1px 1px rgba(255,255,255, .22);
            -webkit-box-shadow: 1px 1px 1px rgba(0,0,0, .29), inset 1px 1px 1px rgba(255,255,255, .44);
            -moz-box-shadow: 1px 1px 1px rgba(0,0,0, .29), inset 1px 1px 1px rgba(255,255,255, .44);
            box-shadow: 1px 1px 1px rgba(0,0,0, .29), inset 1px 1px 1px rgba(255,255,255, .44);
            -webkit-transition: all 0.15s ease;
            -moz-transition: all 0.15s ease;
            -o-transition: all 0.15s ease;
            -ms-transition: all 0.15s ease;
            transition: all 0.15s ease;
            padding-left: 5px;
            padding-right: 5px;
            padding-bottom: 5px;
            height: 29px;
        }
        .btn7:hover
        {
            background-color: #E6EAF7;
            color: #163384;
        }
        
        .style1
        {
            height: 22px;
            width: 92px;
        }
        .style4
        {
            width: 18px;
        }
        
        .style5
        {
            height: 22px;
            width: 86px;
        }
        .style6
        {
            width: 86px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="Table2" runat="server" style="width: 100%;" cellspacing="0" cellpadding="0"
        align="center" border="0">
        <tr id="trsearch" runat="server">
            <%--  <td style="width: 30px; height: 20px;" valign="middle" align="center">
            </td>--%>
            <td style="height: 20px;" valign="middle" align="center">
                <table id="Table3" runat="server" style="width: 60%; border: Solid thin #cccccc;
                    border-collapse: separate;" cellspacing="1" cellpadding="2" border="0">
                    <tr>
                        <td valign="middle" align="center" colspan="3" class="tdHeader">
                            <asp:Label ID="Label2" runat="server" Text="" ForeColor="#FFFFFF" Font-Size="Large">Search Banner</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" align="left" colspan="3" style="height: 18px; padding-left: 17px;"
                            bgcolor="#ffffff">
                            &nbsp;<asp:Label ID="Label3" runat="server" ForeColor="red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">
                        </td>
                        <td style="width: 90px; height: 22px;" valign="middle" align="left" class="label2">
                            Langauge :
                        </td>
                        <td valign="middle" align="left" class="style1">
                            <asp:RadioButtonList ID="rdblanguage" runat="server" RepeatDirection="Horizontal"
                                BackColor="White" Height="16px" Width="263px" OnSelectedIndexChanged="rdblanguage_SelectedIndexChanged"
                                AutoPostBack="true">
                                <asp:ListItem Text="English" Value="English"></asp:ListItem>
                                <asp:ListItem Text="Hindi" Value="Hindi"></asp:ListItem>
                                <asp:ListItem Text="Marathi" Value="Marathi"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td height="10px" class="style4">
                        </td>
                        <td style="width: 90px; height: 22px;" valign="middle" align="left" class="label2">
                            Page Name :
                        </td>
                        <td valign="middle" align="left" class="style1">
                            <%--  <asp:DropDownList ID="ddlsearchpage" runat="server" CssClass="form-control" 
                                Width="225px">
                            </asp:DropDownList>--%>
                            <asp:TextBox ID="txtpageName" runat="server" CssClass="form-control" Width="190px"
                                EnableViewState="False" MaxLength="50" AutoComplete="Off" ToolTip="Enter Department"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 26px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px;" valign="middle" align="center" colspan="3">
                            <asp:Button ID="btnsearch" runat="server" Text="Search" Width="90px" CssClass="btn7"
                                OnClick="btnsearch_Click" />
                            <asp:Button ID="btnsearchReset" runat="server" Text="Reset" Width="90px" CssClass="btn7"
                                OnClick="btnsearchReset_Click" />
                            <%--  <asp:Button ID="Button3" runat="server" Text="Cancel" width="90px"  CssClass="btn7" onclick="btn_Click"/> --%>
                        </td>
                    </tr>
                    <tr>
                        <td height="20px" colspan="3">
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 5px; height: 20px;" valign="middle" align="center">
            </td>
        </tr>
        <tr id="tradd" runat="server">
            <%--  <td style="width: 30px; height: 20px;" valign="middle" align="center">
            </td>--%>
            <td style="height: 20px;" valign="middle" align="center">
                <table id="tbl_AddPg" runat="server" style="width: 80%; border: Solid thin #cccccc;
                    border-collapse: separate;" cellspacing="1" cellpadding="2" border="0">
                    <tr>
                        <td valign="middle" align="center" colspan="6" class="tdHeader">
                            <asp:Label ID="lblAddEditHead" runat="server" Text="" ForeColor="#FFFFFF" Font-Size="Large">Add 
                        New Banner</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" align="left" colspan="6" bgcolor="#ffffff">
                            &nbsp;<asp:Label ID="lblAddMsg" runat="server" ForeColor="red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 2%; height: 22px;" valign="middle" align="left">
                        </td>
                        <td valign="middle" align="left" style="width: 12%;">
                            Language:
                        </td>
                        <td valign="middle" align="left" style="width: 37%;">
                            <asp:RadioButtonList ID="rdblanguageAdd" runat="server" RepeatDirection="Horizontal"
                                Height="16px" Width="50%" OnSelectedIndexChanged="rdblanguageAdd_SelectedIndexChanged"
                                AutoPostBack="true">
                                <asp:ListItem Text="English" Value="English"></asp:ListItem>
                                <asp:ListItem Text="Hindi" Value="Hindi"></asp:ListItem>
                                <asp:ListItem Text="Marathi" Value="Marathi"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td valign="middle" align="left" style="width: 2%;">
                        </td>
                        <td valign="middle" align="left" style="width: 12%;">
                            Select Page:
                        </td>
                        <td valign="middle" align="left" style="width: 37%;">
                            <asp:DropDownList ID="ddlpage" runat="server" CssClass="form-control" Width="80%">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="10px">
                        </td>
                        <td>
                        </td>
                        <td valign="top" align="left" class="style6">
                            &nbsp;&nbsp;
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td style="width: 210px; height: 25px;" valign="top" align="left">
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="" valign="middle" align="left">
                        </td>
                        <td valign="middle" align="left" class="label2">
                            Upload Banner:
                        </td>
                        <td valign="middle" align="left" class="style1">
                            <asp:FileUpload ID="FUBanner" runat="server" />
                            <asp:TextBox ID="txttempiconnm" runat="server" BorderColor="White" BorderStyle="Solid"
                                ReadOnly="true" BorderWidth="1px" Font-Size="0pt" Visible="true" Width="1px"
                                ForeColor="#000" Height="16px"></asp:TextBox>
                        </td>
                        <td valign="middle" align="left">
                        </td>
                        <td valign="middle" align="left" class="label2">
                            Active :
                        </td>
                        <td valign="middle" align="left" class="style5">
                            <asp:RadioButtonList ID="rdbAct" runat="server" RepeatDirection="Horizontal" EnableViewState="False"
                                BackColor="White">
                                <asp:ListItem Text="Yes" Value="Y" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td height="10px">
                        </td>
                        <td>
                        </td>
                        <td valign="top" align="left">
                            <asp:LinkButton ID="lnkbanner" runat="server" ForeColor="#DD5309" Font-Underline="true"
                                CssClass="label1"></asp:LinkButton>
                            &nbsp;&nbsp;
                            <asp:ImageButton runat="server" ID="icodel1" ImageUrl="../Images/close.png" Visible="false"
                                Width="20px" Height="20px" OnClick="icodel1_Click" />
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td valign="top" align="left">
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 2%; height: 22px;" valign="middle" align="left">
                        </td>
                        <td valign="middle" align="left" style="width: 12%;">
                            Alternate text for image:
                        </td>
                        <td valign="middle" align="left" style="width: 37%;">
                            <asp:TextBox ID="txtalttext" runat="server" CssClass="form-control" Width="70%"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td valign="top" align="left">
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" align="center" colspan="6">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" Width="90px" CssClass="btn7" OnClick="btnAdd_Click" />
                            <asp:Button ID="btnReset" runat="server" Text="Reset" Width="90px" CssClass="btn7"
                                OnClick="btnReset_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="90px" CssClass="btn7"
                                OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td height="20px" colspan="6">
                            <span style="margin-left: 31px; font-size: 13px; color: #e35219; font-weight: bold;">
                                Note: </span><span style="margin-left: 0px; font-size: 12px; color: #ea2e0f;">Banner
                                    Width Must 1366px and Height must 300px.</span>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 5px; height: 20px;" valign="middle" align="center">
            </td>
        </tr>
        <tr>
            <td style="height: 20px;" valign="middle" align="left" colspan="5">
                <div style="width: 200px; float: left; margin-left: 50px; text-align: left">
                    <asp:LinkButton ID="lnkAddNew" runat="server" Text="Add New Banner" Font-Names="Verdana"
                        Font-Size="8pt" Font-Bold="true" ForeColor="#1B4A77" OnClick="lnkAddNew_Click">
                    </asp:LinkButton>
                </div>
                <div style="float: right; margin-right: 20px; text-align: right">
                    &nbsp;&nbsp;</div>
            </td>
        </tr>
        <tr>
            <td style="height: 30px;" valign="middle" align="center" colspan="5">
                <asp:Label ID="lblmsg" runat="server" CssClass="ErrLbl"></asp:Label>
            </td>
        </tr>
        <tr id="trengdg" runat="server">
            <td>
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 95%; height: 25px;" valign="middle" align="center" colspan="5">
                            <asp:DataGrid ID="dg_PgEng" Width="95%" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                GridLines="None" CellSpacing="4" CellPadding="4" OnItemCommand="dg_PgEng_ItemCommand"
                                OnItemDataBound="dg_PgEng_ItemDataBound" OnPageIndexChanged="dg_PgEng_PageIndexChanged">
                                <HeaderStyle BackColor="#1E3A8E" ForeColor="White" Height="25px" HorizontalAlign="Center"
                                    CssClass="" VerticalAlign="Middle" />
                                <ItemStyle Height="20px" BackColor="#FFFFFF" HorizontalAlign="Left" VerticalAlign="Top"
                                    CssClass="" />
                                <AlternatingItemStyle Height="20px" CssClass="" BackColor="#F5F5F5" HorizontalAlign="Left"
                                    VerticalAlign="Top" />
                                <PagerStyle Mode="NumericPages" HorizontalAlign="center" VerticalAlign="middle" />
                                <Columns>
                                    <asp:BoundColumn DataField="Id" HeaderText="Page ID" Visible="False"></asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Sr.No.">
                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        <HeaderStyle Width="80px" />
                                        <ItemTemplate>
                                            <%#(dg_PgEng.PageSize * dg_PgEng.CurrentPageIndex) + Container.ItemIndex + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn DataField="AltText" HeaderText="Alternate Text">
                                        <ItemStyle Width="20%" />
                                        <HeaderStyle Width="20%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="BannerName" HeaderText="Banner Name">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="PageFileName" HeaderText="Page Name">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <%--   <asp:TemplateColumn HeaderText="Page File Name">
                            <HeaderStyle Width="20%" />
                            <ItemStyle Width="20%" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEngPgCont" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgEngCont"></asp:LinkButton><br />
                               
                            </ItemTemplate>
                        </asp:TemplateColumn>

                          <asp:TemplateColumn HeaderText="Banner Name" Visible="true">
                           <HeaderStyle Width="20%" />
                            <ItemStyle Width="20%" />
                              <ItemTemplate>
                                <asp:LinkButton ID="lnkengname" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="BannerEng"></asp:LinkButton>
                                    <br />
                                <asp:LinkButton ID="lnkhndname" runat="server" CssClass="label2" ForeColor="Blue" 
                                    CommandName="BannerHnd"></asp:LinkButton><br />
                                    <asp:LinkButton ID="lnkmarname" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="BannerMar"></asp:LinkButton>
                            </ItemTemplate>

                       </asp:TemplateColumn>
                                    --%>
                                    <asp:BoundColumn DataField="Lnguage" HeaderText="Lnguage" HeaderStyle-Width="12%">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Action">
                                        <HeaderStyle Width="18%" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="18%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnEditEng" runat="server" CssClass="label2" ForeColor="Blue"
                                                CommandName="PgEditEng">Edit |</asp:LinkButton>
                                            <asp:LinkButton ID="lnkDeleteEng" runat="server" CssClass="label2" ForeColor="Blue"
                                                CommandName="PgDeleteEng">Delete |</asp:LinkButton>
                                            <asp:LinkButton ID="lnkCheckEng" runat="server" CssClass="label2" ForeColor="Blue"
                                                CommandName="PgCheckEng">Check</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                            </asp:DataGrid>
                        </td>
                    </tr>
                    <tr id="tr_pg" runat="server" visible="true">
                        <td style="" valign="middle" align="center" colspan="5">
                            <table width="95%" align="center" cellpadding="0" cellspacing="0" border="0" bgcolor="#eeeeee"
                                style="border: Solid 1px #cccccc">
                                <tr>
                                    <td style="height: 4px;" valign="middle" align="center" colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle" height="20px">
                                        &nbsp;
                                        <asp:Label ID="Label7" runat="server" Text="Change Record(s) Per Page" CssClass="label2">
                                        </asp:Label>&nbsp;<asp:TextBox ID="txtPageSize" runat="server" CssClass="txt1" Width="30px"
                                            MaxLength="3" onKeyPress="return checkIt(event)">
                                        </asp:TextBox>&nbsp;<asp:Button ID="btnPageSize" runat="server" Text="Go" Width="35px"
                                            CssClass="btn7" OnClick="btnPageSize_Click" /><%--BackColor="	#024690" ForeColor="#FFFFFF" --%>
                                    </td>
                                    <td align="right" valign="middle" height="20px">
                                        <asp:Label ID="lblPageIndex" runat="server" Text="Skip to page" CssClass="label2">
                                        </asp:Label>&nbsp;<asp:TextBox ID="txtPageIndex" runat="server" CssClass="txt1" Width="30px"
                                            MaxLength="3" onKeyPress="return checkIt(event)">
                                        </asp:TextBox>&nbsp;<asp:Button ID="btnPageIndex" runat="server" Text="Go" Width="35px"
                                            CssClass="btn7" OnClick="btnPageIndex_Click" />&nbsp;<%-- BackColor="#024690" ForeColor="#FFFFFF"--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 4px;" valign="middle" align="center" colspan="2">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 8px;" valign="middle" align="center" colspan="5">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="trhnddg" runat="server">
            <td>
                <table>
                    <tr>
                        <td style="width: 91%; height: 25px;" valign="middle" align="center" colspan="5">
                            <asp:DataGrid ID="dg_PgHnd" Width="91%" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                GridLines="None" CellSpacing="4" CellPadding="4">
                                <HeaderStyle BackColor="#DA251C" ForeColor="White" Height="25px" HorizontalAlign="Center"
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
                                            <%#(dg_PgHnd.PageSize * dg_PgHnd.CurrentPageIndex) + Container.ItemIndex + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn DataField="" HeaderText="Page Name" Visible="false">
                                        <ItemStyle Width="20%" />
                                        <HeaderStyle Width="20%" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Page File Name">
                                        <HeaderStyle Width="20%" />
                                        <ItemStyle Width="20%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkHndPgCont" runat="server" CssClass="label2" ForeColor="Blue"
                                                CommandName="PgHndCont"></asp:LinkButton><br />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Banner Name" Visible="true">
                                        <HeaderStyle Width="20%" />
                                        <ItemStyle Width="20%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkhndname" runat="server" CssClass="label2" ForeColor="Blue"
                                                CommandName="BannerHnd"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Action">
                                        <HeaderStyle Width="8%" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnEditHnd" runat="server" CssClass="label2" ForeColor="Blue"
                                                CommandName="PgEditHnd">Edit |</asp:LinkButton>
                                            <asp:LinkButton ID="lnkDeleteHnd" runat="server" CssClass="label2" ForeColor="Blue"
                                                CommandName="PgDeleteHnd">Delete |</asp:LinkButton>
                                            <asp:LinkButton ID="lnkCheckHnd" runat="server" CssClass="label2" ForeColor="Blue"
                                                CommandName="PgCheckHnd">Check</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                            </asp:DataGrid>
                        </td>
                    </tr>
                    <tr id="tr2" runat="server" visible="false">
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
                                        <asp:Label ID="Label1" runat="server" Text="Change Record(s) Per Page" CssClass="label2">
                                        </asp:Label>&nbsp;<asp:TextBox ID="TextBox1" runat="server" CssClass="txt1" Width="30px"
                                            MaxLength="3" onKeyPress="return checkIt(event)">
                                        </asp:TextBox>&nbsp;<asp:Button ID="Button1" runat="server" Text="Go" Width="35px"
                                            CssClass="btn7" /><%--BackColor="	#024690" ForeColor="#FFFFFF" --%>
                                    </td>
                                    <td width="475px" align="right" valign="middle" height="20px">
                                        <asp:Label ID="Label4" runat="server" Text="Skip to page" CssClass="label2">
                                        </asp:Label>&nbsp;<asp:TextBox ID="TextBox2" runat="server" CssClass="txt1" Width="30px"
                                            MaxLength="3" onKeyPress="return checkIt(event)">
                                        </asp:TextBox>&nbsp;<asp:Button ID="Button2" runat="server" Text="Go" Width="35px"
                                            CssClass="btn7" />&nbsp;<%-- BackColor="#024690" ForeColor="#FFFFFF"--%>
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
            </td>
        </tr>
        <tr id="trmardg" runat="server">
            <td>
                <table>
                    <tr>
                        <td style="width: 91%; height: 25px;" valign="middle" align="center" colspan="5">
                            <asp:DataGrid ID="dg_PgMar" Width="91%" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                GridLines="None" CellSpacing="4" CellPadding="4">
                                <HeaderStyle BackColor="#DA251C" ForeColor="White" Height="25px" HorizontalAlign="Center"
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
                                            <%#(dg_PgMar.PageSize * dg_PgMar.CurrentPageIndex) + Container.ItemIndex + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn DataField="" HeaderText="Page Name" Visible="false">
                                        <ItemStyle Width="20%" />
                                        <HeaderStyle Width="20%" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Page File Name">
                                        <HeaderStyle Width="20%" />
                                        <ItemStyle Width="20%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkMarPgCont" runat="server" CssClass="label2" ForeColor="Blue"
                                                CommandName="PgMarCont"></asp:LinkButton><br />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Banner Name" Visible="true">
                                        <HeaderStyle Width="20%" />
                                        <ItemStyle Width="20%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkmarname" runat="server" CssClass="label2" ForeColor="Blue"
                                                CommandName="BannerMar"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Action">
                                        <HeaderStyle Width="8%" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnEditMar" runat="server" CssClass="label2" ForeColor="Blue"
                                                CommandName="PgEditMar">Edit |</asp:LinkButton>
                                            <asp:LinkButton ID="lnkDeleteMar" runat="server" CssClass="label2" ForeColor="Blue"
                                                CommandName="PgDeleteMar">Delete |</asp:LinkButton>
                                            <asp:LinkButton ID="lnkCheckMar" runat="server" CssClass="label2" ForeColor="Blue"
                                                CommandName="PgCheckMar">Check</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                            </asp:DataGrid>
                        </td>
                    </tr>
                    <tr id="tr3" runat="server" visible="false">
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
                                        <asp:Label ID="Label5" runat="server" Text="Change Record(s) Per Page" CssClass="label2">
                                        </asp:Label>&nbsp;<asp:TextBox ID="TextBox3" runat="server" CssClass="txt1" Width="30px"
                                            MaxLength="3" onKeyPress="return checkIt(event)">
                                        </asp:TextBox>&nbsp;<asp:Button ID="Button3" runat="server" Text="Go" Width="35px"
                                            CssClass="btn7" /><%--BackColor="	#024690" ForeColor="#FFFFFF" --%>
                                    </td>
                                    <td width="475px" align="right" valign="middle" height="20px">
                                        <asp:Label ID="Label6" runat="server" Text="Skip to page" CssClass="label2">
                                        </asp:Label>&nbsp;<asp:TextBox ID="TextBox4" runat="server" CssClass="txt1" Width="30px"
                                            MaxLength="3" onKeyPress="return checkIt(event)">
                                        </asp:TextBox>&nbsp;<asp:Button ID="Button4" runat="server" Text="Go" Width="35px"
                                            CssClass="btn7" />&nbsp;<%-- BackColor="#024690" ForeColor="#FFFFFF"--%>
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
            </td>
        </tr>
    </table>
</asp:Content>
