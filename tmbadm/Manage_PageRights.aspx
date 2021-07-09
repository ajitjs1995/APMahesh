<%@ Page Title="" Language="VB" MasterPageFile="~/tmbadm/AdmMaster.master" AutoEventWireup="false"
    CodeFile="Manage_PageRights.aspx.vb" Inherits="Admin_Manage_PageRights" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .whitefont
        {
            color: White;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table id="tbl_main" runat="server" style="width: 970px;" cellspacing="0" cellpadding="0"
        align="center" border="0">
        <tr>
            <td style="width: 970px; height: 20px;" valign="top" align="center" colspan="2">
                <table id="Table1" runat="server" style="width: 710px; border: Solid thin #cccccc"
                    cellspacing="1" cellpadding="0" border="0">
                    <tr>
                        <td style="width: 10px; height: 8px;" valign="top" align="left" bgcolor="#ffffff">
                        </td>
                        <td valign="middle" align="left" colspan="5" class="MenuHead" style="width: 700px;
                            height: 8px; font-weight: bold;" bgcolor="#ffffff">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 25px;" valign="top" align="left">
                        </td>
                        <td style="width: 90px; height: 25px;" valign="top" align="left" class="label2">
                            Name :
                        </td>
                        <td style="width: 250px; height: 25px;" valign="top" align="left">
                            <asp:Label ID="lblName" runat="server" CssClass="label2" Text=""></asp:Label>
                        </td>
                        <td style="width: 20px; height: 25px;" valign="top" align="left">
                        </td>
                        <td style="width: 90px; height: 25px;" valign="top" align="left" class="label2">
                            Email :&nbsp;
                        </td>
                        <td style="width: 250px; height: 25px;" valign="top" align="left">
                            <asp:Label ID="lblEmail" runat="server" CssClass="label2" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 25px;" valign="top" align="left">
                        </td>
                        <td style="width: 90px; height: 25px;" valign="top" align="left" class="label2">
                            User Type :
                        </td>
                        <td style="width: 250px; height: 25px;" valign="top" align="left">
                            <asp:Label ID="lblUserType" runat="server" CssClass="label2" Text=""></asp:Label>
                        </td>
                        <td style="width: 20px; height: 25px;" valign="top" align="left">
                        </td>
                        <td style="width: 90px; height: 25px;" valign="top" align="left" class="label2">
                            Username :&nbsp;
                        </td>
                        <td style="width: 250px; height: 25px;" valign="top" align="left">
                            <asp:Label ID="lblUsrNm" runat="server" CssClass="label2" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 25px;" valign="top" align="left">
                        </td>
                        <td style="width: 90px; height: 25px;" valign="top" align="left" class="label2">
                            Department :
                        </td>
                        <td style="width: 250px; height: 25px;" valign="top" align="left">
                            <asp:Label ID="lblMainDept" runat="server" CssClass="label2" Text=""></asp:Label>
                        </td>
                        <td style="width: 20px; height: 25px;" valign="top" align="left">
                        </td>
                        <td style="width: 90px; height: 25px;" valign="top" align="right" class="label2">
                            <%--  Sub Dept :&nbsp;--%>
                        </td>
                        <td style="width: 250px; height: 25px;" valign="top" align="left">
                            <asp:Label ID="lblSubDept" runat="server" CssClass="label2" Text="" Visible="false"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 970px; height: 3px;" valign="top" align="left" colspan="2">
            </td>
        </tr>
        <tr>
            <td style="width: 155px; height: 20px;" valign="top" align="left">
            </td>
            <td style="width: 815px; height: 20px;" valign="top" align="center">
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 970px; height: 25px;" valign="middle" align="center" colspan="2">
                <%--<asp:DataGrid ID="dg_Pg" Width="510px" runat="server" AllowPaging="false" AutoGenerateColumns="False" GridLines="None" CellSpacing="3" ShowFooter="false"  >
                    <HeaderStyle BackColor="#DA251C" Height="25px" HorizontalAlign="Center" CssClass="whitefont" Verticalalign="Middle"  />
                    <ItemStyle Height="20px" BackColor="#F3F3F3" HorizontalAlign="Left" VerticalAlign="Top" CssClass="label2"/>
                    <Columns>
                                  
                                <asp:TemplateColumn HeaderText="Sr.No.">
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    <HeaderStyle Width="50px" />
                                        <ItemTemplate>
                                            <%#(dg_Pg.PageSize * dg_Pg.CurrentPageIndex) + Container.ItemIndex + 1%>
                                        </ItemTemplate>
                                </asp:TemplateColumn>
                                
                                <asp:BoundColumn DataField="MainParentId" HeaderText="Main Parent ID" Visible="False">
                                </asp:BoundColumn>
                                  
                                <asp:BoundColumn DataField="MainParentName" HeaderText="Main Parent">
                                <ItemStyle Width="150px" />
                                    <HeaderStyle Width="150px" />
                                </asp:BoundColumn>
                                 
                                <asp:BoundColumn DataField="parentid" HeaderText="Parent ID" Visible="False">
                                </asp:BoundColumn>
                                   
                                <asp:BoundColumn DataField="MainPageName" HeaderText="Main Page">
                                    <ItemStyle Width="250px" />
                                    <HeaderStyle Width="250px" />
                                </asp:BoundColumn>
                                
                                <asp:TemplateColumn HeaderText="Allot">
                                    <HeaderStyle Width="60px" />
                                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                                        <ItemTemplate>
                                            <asp:CheckBox id="chkAllot" runat="server" CssClass="label2"></asp:CheckBox>
                                        </ItemTemplate>
                                </asp:TemplateColumn>
                                                      
                    </Columns>
                </asp:DataGrid>--%>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <fieldset>
                            <asp:CheckBox ID="chkall" runat="server" Text="All" CssClass="textbox" AutoPostBack="True" />
                            <asp:DataGrid ID="dg_fillPage" Width="950px" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                GridLines="None" CellSpacing="3" CellPadding="3">
                                <HeaderStyle BackColor="#1E3A8E" Height="25px" HorizontalAlign="Center" CssClass="whitefont"
                                    VerticalAlign="Middle" />
                                <ItemStyle Height="20px" BackColor="#F3F3F3" HorizontalAlign="Left" VerticalAlign="Top"
                                    CssClass="label2" />
                                <Columns>
                                    <%-- -------------------0-----------------------%>
                                    <asp:BoundColumn DataField="MainParentId" HeaderText="Main Dept ID" Visible="False">
                                    </asp:BoundColumn>
                                    <%-- -------------------1-----------------------%>
                                    <asp:TemplateColumn HeaderText="Sr.No.">
                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemTemplate>
                                            <%#(dg_fillPage.PageSize * dg_fillPage.CurrentPageIndex) + Container.ItemIndex + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <%-- -------------------2-----------------------%>
                                    <asp:BoundColumn DataField="MainParentName" HeaderText="Main Parent">
                                        <ItemStyle Width="150px" />
                                        <HeaderStyle Width="150px" />
                                    </asp:BoundColumn>
                                    <%-- -------------------3-----------------------%>
                                    <asp:BoundColumn DataField="parentid" HeaderText="Parent ID" Visible="False"></asp:BoundColumn>
                                    <%-- -------------------4-----------------------%>
                                    <asp:BoundColumn DataField="MainPageName" HeaderText="Main Page">
                                        <ItemStyle Width="250px" />
                                        <HeaderStyle Width="250px" />
                                    </asp:BoundColumn>
                                    <%-- -------------------5-----------------------%>
                                    <asp:TemplateColumn HeaderText="Allot">
                                        <HeaderStyle Width="60px" />
                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkAllot" runat="server" CssClass="label2"></asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                            </asp:DataGrid>
                        </fieldset>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <!--  -->
            </td>
        </tr>
        <tr id="Add1">
            <td style="width: 970px; height: 30px;" valign="middle" align="center" colspan="2">
                <asp:Button ID="btnEdit" runat="server" Text="Update" CssClass="btn1" Width="65px" />&nbsp;<asp:Button
                    ID="btnCheck" runat="server" Text="Check" CssClass="btn1" Width="65px" />&nbsp;<asp:Button
                        ID="btnCancel" runat="server" Text="Cancel" CssClass="btn1" Width="60px" />
            </td>
        </tr>
        <tr>
            <td style="width: 970px; height: 45px;" valign="middle" align="center" colspan="2">
            </td>
        </tr>
    </table>
</asp:Content>
