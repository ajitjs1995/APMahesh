<%@ Page Title="" Language="C#" MasterPageFile="~/tmbadm/AdmMaster.master" AutoEventWireup="true"
    CodeFile="ManageMetaData.aspx.cs" Inherits="Admin_ManageMetaData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<style type="text/css">
        .tdpadding
        {
            padding-top: 10px !important;
            padding-bottom: 10px !important;
        }
        .tdpaddingitem
        {
            padding-top: 10px !important;
            padding-bottom: 10px !important;
            padding-left: 10px !important;
        }
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="tbl_main" runat="server" style="width: 80%;" cellspacing="0" cellpadding="0"
        align="center" border="0">
        <tr>
            <td style="width: 5px; height: 20px;" valign="middle" align="center">
            </td>
            <td style="width: 550px; height: 20px;" valign="middle" align="center">
                <table id="Table1" runat="server" style="width: 90%; border: Solid thin #cccccc;
                    border-radius: 10px; border-collapse: separate; height: 200px;" cellspacing="1"
                    cellpadding="0" border="0">
                    <tr>
                        <td valign="middle" align="center" colspan="4" style="width: 510px; background-color: #1E3A8E;
                            height: 18px; padding: 8px;">
                            <asp:Label ID="lblAddEditHead" runat="server" Text="" ForeColor="#FFFFFF" Font-Size="Large">Add Meta Data</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" align="left" colspan="4" class="MenuHead" style="width: 580px;
                            height: 20px;" bgcolor="#ffffff">
                            <asp:Label ID="lblerr" runat="server" CssClass="label2"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%;" valign="middle" align="left">
                        </td>
                        <td style="width: 25%;" valign="middle" align="left">
                            <asp:Label ID="Label2" runat="server" CssClass="label2" Text="Keyword Content :"></asp:Label>
                        </td>
                        <td style="width: 65%; height: 100px;" valign="middle" align="left">
                            <asp:TextBox ID="txtkeycont" Width="100%" Height="80px" runat="server" CssClass="form-control"
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td style="width: 5%; height: 25px;" valign="middle" align="left">
                        </td>
                    </tr>
                    <tr>    
                        <td style="height:100px;">
                        </td>
                        <td valign="middle" align="left">
                            <asp:Label ID="Label1" runat="server" CssClass="label2" Text="Description Content :"></asp:Label>
                            &nbsp;
                        </td>
                        <td valign="middle" align="left">
                            <asp:TextBox ID="txtdesccont" Width="100%" Height="80px" runat="server" CssClass="form-control"
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td valign="middle" align="left">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" align="left" style="height:45px;">
                        </td>
                        <td valign="middle" align="left">
                            <asp:Label ID="Label4" runat="server" CssClass="label2" Text="Active :"></asp:Label>
                            &nbsp;
                        </td>
                        <td valign="middle" align="left">
                            <asp:RadioButtonList ID="rdbMainAct" runat="server" CssClass="rbl" RepeatDirection="Horizontal" Width="120px"
                                EnableViewState="False">
                                <asp:ListItem Text="Yes" Value="Y" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td valign="middle" align="left">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="Button1" runat="server" Text="Add" CssClass="btn7" ForeColor="#ffffff"
                                Width="80px" Height="30px" OnClick="Button1_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Reset" CssClass="btn7" ForeColor="#ffffff"
                                Width="80px" Height="30px" OnClick="btnCancel_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="btn7" ForeColor="#ffffff"
                                Width="80px" Height="30px" OnClick="Button2_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="Button3" runat="server" Text="Check" CssClass="btn7" ForeColor="#ffffff"
                                Width="80px" Height="30px" OnClick="Button3_Click"/>
                        </td>
                    </tr>
                    <tr>
                        <td height="15px" colspan="4">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <asp:Label ID="lblParentPage" runat="server" Text="" ForeColor="Blue"></asp:Label>
    <asp:Label ID="lblmsg" runat="server" CssClass="label2"></asp:Label>
    <center>
        <asp:DataGrid ID="dg_Menu" Width="80%" runat="server" AllowPaging="false" AutoGenerateColumns="False"
            GridLines="None" CellSpacing="3" OnItemCommand="dg_Menu_ItemCommand" OnItemDataBound="dg_Menu_ItemDataBound">
            <HeaderStyle BackColor="#a3352a" ForeColor="White" Height="25px" HorizontalAlign="Center"
                CssClass="" VerticalAlign="Middle" />
            <ItemStyle Height="20px" BackColor="#FFFFFF" HorizontalAlign="Left" VerticalAlign="Top"
                CssClass="" />
            <AlternatingItemStyle Height="20px" CssClass="" BackColor="#dddddd" HorizontalAlign="Left"
                VerticalAlign="Top" />
            <Columns>
                <asp:BoundColumn DataField="ID" HeaderText="ID" Visible="False"></asp:BoundColumn>
                <asp:TemplateColumn HeaderText="Sr.No.">
                    <ItemStyle HorizontalAlign="Center" Width="6%" />
                    <HeaderStyle Width="6%" />
                    <ItemTemplate>
                        <%#(dg_Menu.PageSize * dg_Menu.CurrentPageIndex) + Container.ItemIndex + 1%>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="KeyCont" HeaderText="Keyword Content">
                    <ItemStyle Width="40%" HorizontalAlign="center" />
                    <HeaderStyle Width="40%" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="DescCont" HeaderText="Description Content">
                    <ItemStyle Width="40%" HorizontalAlign="center" />
                    <HeaderStyle Width="40%" />
                </asp:BoundColumn>
                <asp:TemplateColumn HeaderText="Action">
                    <HeaderStyle Width="50%" />
                    <ItemStyle HorizontalAlign="Center" Width="50%" />
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkMenuEdit" runat="server" CssClass="label2" ForeColor="#035193"
                            CommandName="metaEdit">Edit</asp:LinkButton>
                        |
                        <asp:LinkButton ID="lnkMenuDelete" runat="server" CssClass="label2" ForeColor="#035193"
                            Visible="false" CommandName="metaDelete">Delete</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="label2" ForeColor="#035193"
                            CommandName="metachk">Check</asp:LinkButton>
                        <br />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="Active" HeaderText="Active" Visible="false"></asp:BoundColumn>
                <asp:BoundColumn DataField="PageId" HeaderText="pageid" Visible="false"></asp:BoundColumn>
                <asp:BoundColumn DataField="Checked" HeaderText="check" Visible="false"></asp:BoundColumn>
            </Columns>
        </asp:DataGrid>
    </center>
</asp:Content>
