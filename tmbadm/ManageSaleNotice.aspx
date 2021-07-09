<%@ Page Title="" Language="C#" MasterPageFile="~/tmbadm/AdmMaster.master" AutoEventWireup="true"
    CodeFile="ManageSaleNotice.aspx.cs" Inherits="tmbadm_ManageSaleNotice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function allowOnlyNumber(evt) {

            alert('Please select date');
            return false;
            // var charCode = (evt.which) ? evt.which : event.keyCode
            // if (charCode > 31 && (charCode < 48 || charCode > 57))
            //  return false;
            // return true;
        }
    </script>
    <style type="text/css">
        .style2
        {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <table id="tbl_main" runat="server" style="width: 100%;" cellspacing="0" cellpadding="0"
        align="center" border="0">
        <tr id="TblSearch" runat="server">
            <td style="width: 100%; height: 20px;" valign="middle" align="center" colspan="3">
                <table id="Search" runat="server" style="width: 70%; border: Solid thin #cccccc;
                    border-collapse: separate; height: 200px;" cellspacing="1" cellpadding="0" border="0">
                    <tr>
                        <td valign="middle" align="center" colspan="7" class="tdHeader" style="width: 650px;
                            height: 30px; padding-left: 10px;">
                            <asp:Label ID="lblSearchHeading" runat="server" Text="" ForeColor="white">Search Sale Notice</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px;" valign="middle" align="left" bgcolor="#ffffff">
                        </td>
                        <td valign="middle" align="left" colspan="5" class="MenuHead" style="width: 580px;
                            height: 20px; font-weight: bold;" bgcolor="#ffffff">
                            <asp:Label ID="lblsearcherr" runat="server" CssClass="ErrLbl"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 2%; height: 25px;" valign="middle" align="right">
                        </td>
                        <td style="width: 15%; height: 25px;" valign="middle" align="left">
                            <asp:Label ID="lblsearchproperty" runat="server" CssClass="label2" Text="Property Name"></asp:Label>
                        </td>
                        <td style="height: 25px;" valign="middle" align="left" colspan="4">
                            <asp:TextBox ID="txtSearchProperty" runat="server" CssClass="form-control" Width="91.7%"
                                TextMode="MultiLine" Rows="2" Height="50px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="10px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 2%;" valign="middle" align="right">
                        </td>
                        <td style="width: 15%; height: 25px;" valign="middle" align="left">
                            <asp:Label ID="lblSearchBranch" runat="server" CssClass="label2" Text="Auction in Branch"></asp:Label>
                            &nbsp;
                        </td>
                        <td style="width: 32%; height: 25px;" valign="middle" align="left">
                            <asp:DropDownList ID="ddlSearchBranch" runat="server" CssClass="form-control" Width="275px"
                                Height="35px" AutoPostBack="True" 
                                onselectedindexchanged="ddlBranch_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 2%" valign="top" align="right">
                        </td>
                        <td valign="middle" align="left" class="style2">
                            Notice Date&nbsp;
                        </td>
                        <td valign="middle" align="left" class="style2">
                            <asp:TextBox ID="txtSearchNoticeDate" runat="server" placeholder="DD/MM/YYYY" MaxLength="10"
                                CssClass="form-control" ToolTip="Sale Notice Date" AutoComplete="off" onkeypress="return allowOnlyNumber(event)"
                                oncopy="return false" onpaste="return false" oncut="return false" Width="250px"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender2" PopupButtonID="imgPopup" runat="server"
                                TargetControlID="txtSearchNoticeDate" Format="yyyy-MM-dd">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td height="10px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center">
                            <asp:Button ID="btnSeach" runat="server" Text="Search" CssClass="btn7" Width="120px"
                                OnClick="btnSeach_Click"></asp:Button>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnSearchReset" runat="server" Text="Reset" CssClass="btn7" Width="120px"
                                OnClick="btnSearchReset_Click"></asp:Button>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnViewAll" runat="server" Text="View All" CssClass="btn7" Width="120px"
                                OnClick="btnViewAll_Click"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="TblAddNew" runat="server">
            <td style="width: 100%; height: 20px;" valign="middle" align="center" colspan="3">
                <table id="Table1" runat="server" style="width: 70%; border: Solid thin #cccccc;
                    border-collapse: separate; height: 200px;" cellspacing="1" cellpadding="0" border="0">
                    <tr>
                        <td valign="middle" align="center" colspan="7" class="tdHeader" style="width: 650px;
                            height: 30px; padding-left: 10px;">
                            <asp:Label ID="lblAddMainHead" runat="server" Text="" ForeColor="white">Add 
                        New Sale Notice</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px;" valign="middle" align="left" bgcolor="#ffffff">
                        </td>
                        <td valign="middle" align="left" colspan="5" class="MenuHead" style="width: 580px;
                            height: 20px; font-weight: bold;" bgcolor="#ffffff">
                            <asp:Label ID="lblMainMsg" runat="server" CssClass="ErrLbl"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 2%; height: 25px;" valign="middle" align="right">
                            <span class="ErrLbl">*</span>
                        </td>
                        <td style="width: 15%; height: 25px;" valign="middle" align="left">
                            <asp:Label ID="Label1" runat="server" CssClass="label2" Text="Asset Location :"></asp:Label>
                        </td>
                        <td style="height: 25px;" valign="middle" align="left" colspan="4">
                            <asp:TextBox ID="txtAssetLocation" runat="server" CssClass="form-control" Width="95%" TextMode="MultiLine" Rows="2" Height="70px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="10px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 2%; height: 25px;" valign="middle" align="right">
                            <span class="ErrLbl">*</span>
                        </td>
                        <td style="width: 15%; height: 25px;" valign="middle" align="left">
                            <asp:Label ID="Label2" runat="server" CssClass="label2" Text="Borrower Name :"></asp:Label>
                        </td>
                        <td style="height: 25px;" valign="middle" align="left">
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Width="250px" 
                                AutoPostBack="True" ontextchanged="txtTitle_TextChanged"></asp:TextBox>
                        </td>
                        <td style="width: 2%" valign="top" align="right">
                        </td>
                        <td valign="middle" align="left">
                            <asp:Label ID="Label3" runat="server" CssClass="label2">Asset Type : </asp:Label>
                        </td>
                        <td valign="middle" align="left">
                            <asp:TextBox ID="txtAssetType" runat="server" CssClass="form-control" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="10px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 2%;" valign="middle" align="right">
                            <span class="ErrLbl">*</span>
                        </td>
                        <td style="width: 15%; height: 25px;" valign="middle" align="left">
                            <asp:Label ID="Label4" runat="server" CssClass="label2" Text="Place of Auction :"></asp:Label>
                            &nbsp;
                        </td>
                        <td style="width: 32%; height: 25px;" valign="middle" align="left">
                            <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control" Width="275px"
                                Height="35px">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 2%" valign="top" align="right">
                        </td>
                        <td valign="middle" align="left">
                            <asp:Label ID="lblLanguage" runat="server" CssClass="label2">Select Language : </asp:Label>
                        </td>
                        <td valign="middle" align="left">
                            <asp:RadioButtonList ID="RblLanguage" runat="server" RepeatDirection="Horizontal"
                                Width="199px" OnSelectedIndexChanged="RblLanguage_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem>English</asp:ListItem>
                                <asp:ListItem>Tamil</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td height="10px">
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" align="right">
                            <span class="ErrLbl">*</span>
                        </td>
                        <td valign="middle" align="left" class="style2">
                            Auction Date :&nbsp;
                        </td>
                        <td valign="middle" align="left" class="style2">
                            <asp:TextBox ID="txtAuctionDate" runat="server" placeholder="DD/MM/YYYY" MaxLength="10"
                                CssClass="form-control" ToolTip="Sale Notice Date" AutoComplete="off" onkeypress="return allowOnlyNumber(event)"
                                oncopy="return false" onpaste="return false" oncut="return false" Width="250px"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender3" PopupButtonID="imgPopup" runat="server"
                                TargetControlID="txtAuctionDate" Format="yyyy-MM-dd">
                            </cc1:CalendarExtender>
                        </td>
                        <td valign="middle" align="right">
                            <span class="ErrLbl">*</span>
                        </td>
                        <td valign="middle" align="left" class="style2">
                            <asp:Label ID="Label5" runat="server" CssClass="label2">Auction Time : </asp:Label>
                        </td>
                        <td valign="middle" align="left" class="style2">
                            <asp:TextBox ID="txtAuctionTime" runat="server" placeholder="HH:mm AM/PM" MaxLength="8" Width="250px"
                                CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="10px">
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" align="right">
                            <span class="ErrLbl">*</span>
                        </td>
                        <td valign="middle" align="left" class="style2">
                            Notice Date :&nbsp;
                        </td>
                        <td valign="middle" align="left" class="style2">
                            <asp:TextBox ID="NoticeDate" runat="server" placeholder="DD/MM/YYYY" MaxLength="10"
                                CssClass="form-control" ToolTip="Sale Notice Date" AutoComplete="off" onkeypress="return allowOnlyNumber(event)"
                                oncopy="return false" onpaste="return false" oncut="return false" Width="250px"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgPopup" runat="server"
                                TargetControlID="NoticeDate" Format="yyyy-MM-dd">
                            </cc1:CalendarExtender>
                        </td>
                        <td valign="middle" align="right">
                            <span class="ErrLbl">*</span>
                        </td>
                        <td valign="middle" align="left" class="style2">
                            <asp:Label ID="Label9" runat="server" CssClass="label2">Upload File : </asp:Label>
                            <asp:TextBox ID="txtTempFilenm" runat="server" BorderColor="White" BorderStyle="Solid"
                                ReadOnly="true" BorderWidth="1px" Font-Size="0pt" Visible="false" Width="1px"
                                ForeColor="#ffffff">
                            </asp:TextBox>
                        </td>
                        <td valign="middle" align="left" class="style2">
                            <asp:FileUpload ID="FileDoc" runat="server" CssClass="" Width="205px" /><br />
                            <asp:LinkButton ID="lnkFile" runat="server" ForeColor="Blue" Font-Underline="true"
                                CssClass="label2" OnClick="lnkFile_Click"></asp:LinkButton>
                            &nbsp;&nbsp;
                            <asp:ImageButton runat="server" ID="lnkRemove" ImageUrl="~/images/close.png" Visible="false"
                                Width="20px" Height="20px" OnClick="icodel1_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td height="10px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px;" valign="middle" align="left" bgcolor="#ffffff">
                        </td>
                        <td>
                            Title Show on Page :
                        </td>
                        <td colspan="6">
                            <asp:Label ID="lblShowTitle" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="10px">
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" align="right">
                            <span class="ErrLbl">*</span>
                        </td>
                        <td valign="middle" align="left" class="style2">
                            Active :
                        </td>
                        <td valign="middle" align="left" class="style2">
                            <asp:RadioButtonList ID="RblActive" runat="server" RepeatDirection="Horizontal" Width="160px">
                                <asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
                                <asp:ListItem Value="N">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td valign="middle" align="right">
                            &nbsp;
                        </td>
                        <td valign="middle" align="left" class="style2">
                        </td>
                        <td valign="middle" align="left" class="style2">
                        </td>
                    </tr>
                    <tr>
                        <td height="10px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center">
                            <asp:Button ID="btnAdd" runat="server" Text="Add Sale Notice" CssClass="btn7" OnClick="btnAdd_Click"
                                Width="145px"></asp:Button>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn7" Width="120px"
                                OnClick="btnReset_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn7" Width="120px"
                                OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td height="15px">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 970px; height: 3px;" valign="middle" align="left" colspan="3">
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 30px;" valign="middle" align="center">
                <table width="100%">
                    <tr>
                        <td width="17%">
                        </td>
                        <td width="66%" valign="middle" align="center">
                            <asp:Label ID="lblmsg" runat="server" CssClass="ErrLbl"></asp:Label>
                        </td>
                        <td width="17%">
                            <asp:Button ID="btnAddnewSaleNotice" runat="server" Text="Add New Sale Notice" CssClass="btn7"
                                Width="165px" OnClick="btnAddnewSaleNotice_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 970px; height: 8px;" valign="middle" align="center" colspan="3">
                <asp:DataGrid ID="dg_salenotice" Width="95%" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    GridLines="None" CellSpacing="4" CellPadding="4" OnItemCommand="dg_salenotice_ItemCommand"
                    OnItemDataBound="dg_salenotice_ItemDataBound" OnPageIndexChanged="dg_salenotice_PageIndexChanged"
                    PageSize="25">
                    <HeaderStyle BackColor="#1E3A8E" ForeColor="White" Height="25px" HorizontalAlign="Center"
                        CssClass="" VerticalAlign="Middle" />
                    <ItemStyle Height="20px" BackColor="#FFFFFF" HorizontalAlign="Left" VerticalAlign="Top"
                        CssClass="" />
                    <AlternatingItemStyle Height="20px" CssClass="" BackColor="#F5F5F5" HorizontalAlign="Left"
                        VerticalAlign="Top" />
                    <PagerStyle Mode="NumericPages" HorizontalAlign="center" VerticalAlign="middle" />
                    <Columns>
                        <%--0--%>
                        <asp:BoundColumn DataField="Id" HeaderText="Page ID" Visible="False"></asp:BoundColumn>
                        <%--1--%>
                        <asp:TemplateColumn HeaderText="Sr.No.">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <HeaderStyle Width="5%" />
                            <ItemTemplate>
                                <%#(dg_salenotice.PageSize * dg_salenotice.CurrentPageIndex) + Container.ItemIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <%--2--%>
                        <asp:BoundColumn DataField="NoticeDate" HeaderText="Notice Date">
                            <ItemStyle Width="10%" VerticalAlign="Middle" HorizontalAlign="Center" />
                            <HeaderStyle Width="10%" />
                        </asp:BoundColumn>
                        <%--3--%>
                        <asp:BoundColumn DataField="Title" HeaderText="Title">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <%--4--%>
                        <asp:TemplateColumn HeaderText="File Name">
                            <HeaderStyle Width="20%" />
                            <ItemStyle Width="20%" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkFile" runat="server" CssClass="label2" ForeColor="Blue" CommandName="PgFile"></asp:LinkButton><br />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <%--5--%>
                        <asp:TemplateColumn HeaderText="Action">
                            <HeaderStyle Width="15%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15%" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" CssClass="label2" ForeColor="Blue" CommandName="PgEdit">Edit |</asp:LinkButton>
                                <asp:LinkButton ID="lnkDelete" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="PgDelete">Delete</asp:LinkButton><br />
                                <asp:LinkButton ID="lnkCheck" runat="server" CssClass="label2" ForeColor="Blue" CommandName="PgCheck">Check</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <%--6--%>
                        <asp:BoundColumn DataField="NoticeDate" HeaderText="Notice Date" Visible="false">
                        </asp:BoundColumn>
                        <%--7--%>
                        <asp:BoundColumn DataField="PropertyName" HeaderText="Property Name" Visible="false">
                        </asp:BoundColumn>
                        <%--8--%>
                        <asp:BoundColumn DataField="AuctionOn" HeaderText="Auction On" Visible="false"></asp:BoundColumn>
                        <%--9--%>
                        <asp:BoundColumn DataField="NoticeLanguage" HeaderText="Notice Language" Visible="false">
                        </asp:BoundColumn>
                        <%--10--%>
                        <asp:BoundColumn DataField="IsActive" HeaderText="Is Active" Visible="false"></asp:BoundColumn>
                        <%--11--%>
                        <asp:BoundColumn DataField="Checked" HeaderText="Checked" Visible="false"></asp:BoundColumn>
                        <%--12--%>
                        <asp:BoundColumn DataField="AuctionDate" HeaderText="AuctionDate" Visible="false"></asp:BoundColumn>
                        <%--13--%>
                        <asp:BoundColumn DataField="AuctionTime" HeaderText="AuctionTime" Visible="false"></asp:BoundColumn>
                        <%--14--%>
                        <asp:BoundColumn DataField="AssetLocation" HeaderText="AssetLocation" Visible="false"></asp:BoundColumn>
                        <%--15--%>
                        <asp:BoundColumn DataField="AssetType" HeaderText="AssetType" Visible="false"></asp:BoundColumn>
                    </Columns>
                </asp:DataGrid>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
</asp:Content>
