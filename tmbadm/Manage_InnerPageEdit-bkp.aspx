<%@ Page Title="" Language="C#" MasterPageFile="~/tmbadm/AdmMaster.master" AutoEventWireup="true"
    ValidateRequest="false" CodeFile="Manage_InnerPageEdit.aspx.cs" Inherits="Admin_Manage_InnerPageEdit" %>

<%--<%@ Register TagPrefix="FckeditorV2" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>--%>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../ckeditor/ckeditor.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <center>
            <asp:ScriptManager ID="script1" runat="server">
            </asp:ScriptManager>
            <table id="tbl_main" runat="server" style="width: 970px;" cellspacing="0" cellpadding="0"
                align="center" border="0">
                <tr>
                    <td style="width: 90%; height: 35px;" valign="middle" align="center" colspan="4">
                        <table id="Table3" runat="server" style="width: 100%; height: 246px; border: Solid thin #cccccc;
                            background-color: #F3F3F3;" cellspacing="1" cellpadding="0"
                            border="0">
                            <tr>
                                <td valign="middle" align="center" colspan="7" style="background-color: #585757;
                                    height: 26px; padding-left: 10px;">
                                    <asp:Label ID="lblAddMainHead" runat="server" Text="" ForeColor="#FFFFFF" Font-Size="16px">Update Page Contents</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 10px; height: 30px;" valign="middle" align="left">
                                </td>
                                <td valign="middle" align="left" colspan="5">
                                    <asp:Label ID="lblMainMsg" runat="server" CssClass="ErrLbl"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%; height: 40px;" valign="middle" align="left">
                                </td>
                                <td style="width: 12%; height: 25px;" valign="middle" align="left">
                                    <asp:Label ID="Label2" runat="server" Text="Main Type :" CssClass="label2"></asp:Label>
                                </td>
                                <td style="width: 35%; height: 25px;" valign="middle" align="left">
                                    <asp:DropDownList ID="cmbMainType" runat="server" CssClass="form-control" Width="265px"
                                        AutoPostBack="false" OnSelectedIndexChanged="cmbMainType_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 2%; height: 25px;" valign="middle" align="left">
                                </td>
                                <td style="width: 12%; height: 25px;" valign="middle" align="left">
                                    <asp:Label ID="Label4" runat="server" Text="Page Type :" CssClass="label2"></asp:Label>&nbsp;
                                </td>
                                <td style="width: 35%; height: 25px; padding-left: 3px;" valign="middle" align="left">
                                    <asp:DropDownList ID="cmbPgType" runat="server" CssClass="form-control" Width="265px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 40px;" valign="middle" align="left">
                                </td>
                                <td valign="middle" align="left">
                                    <asp:Label ID="Label1" runat="server" Text="Page Name :" CssClass="label2"></asp:Label>
                                </td>
                                <td valign="middle" align="left">
                                    <asp:TextBox ID="txtPgName" runat="server" CssClass="form-control" Width="240px"
                                        ReadOnly="true" Enabled="false"></asp:TextBox>
                                </td>
                                <td valign="middle" align="left">
                                </td>
                                <td valign="middle" align="left">
                                    <asp:Label ID="Label3" runat="server" Text="Page Title :" CssClass="label2"></asp:Label>&nbsp;
                                </td>
                                <td valign="middle" align="left" style="padding-left: 3px;">
                                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Width="240px" EnableViewState="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 40px;" valign="middle" align="left">
                                    &nbsp;
                                </td>
                                <td valign="middle" align="left">
                                    <asp:Label ID="Label6" runat="server" Text="Page Active :" CssClass="label2"></asp:Label>
                                </td>
                                <td valign="middle" align="left">
                                    <asp:RadioButtonList ID="rdbMainAct" runat="server" BorderColor="White" Width="100px"
                                        RepeatDirection="Horizontal" EnableViewState="False">
                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td valign="middle" align="left">
                                    &nbsp;
                                </td>
                                <td valign="middle" align="left">
                                    <asp:Label ID="Label5" runat="server" Text=" Valid upto :" CssClass="label2"></asp:Label>
                                </td>
                                <td valign="middle" align="left">
                                    <table style="width:79%;">
                                        <tr>
                                            <td style="width: 29.41%">
                                                <asp:DropDownList ID="cmbDD1" runat="server" Width="100%" CssClass="form-control">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 32.35%">
                                                <asp:DropDownList ID="cmbMM1" runat="server" Width="100%" CssClass="form-control"
                                                    EnableViewState="False">
                                                    <asp:ListItem Value="MM" Selected="True">MM</asp:ListItem>
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
                                            <td style="width: 38.24%">
                                                <asp:DropDownList ID="cmbYY1" runat="server" Width="100%" CssClass="form-control">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 40px;" valign="middle" align="left">
                                    &nbsp;
                                </td>
                                <td valign="middle" align="left">
                                    <asp:Label ID="Label7" runat="server" Text="Content :" CssClass="label2" Width="70px"></asp:Label>
                                </td>
                                <td valign="middle" align="left" colspan="4">
                                    <asp:RadioButtonList ID="rdbcontent" runat="server" CssClass="txt1" BorderColor="White"
                                        Width="40%" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rdbcontent_SelectedIndexChanged">
                                        <asp:ListItem Text="Latest" Value="Latest"></asp:ListItem>
                                        <asp:ListItem Text="Previous1" Value="Previous1"></asp:ListItem>
                                        <asp:ListItem Text="Previous2" Value="Previous2"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" align="center" style="height: 40px;">
                                    <asp:Button ID="btnAdd1" runat="server" Text="Add" CssClass="btn7" Visible="false"
                                        OnClick="btnAdd1_Click" />&nbsp;<%-- Width="65px" Height="27px"--%>
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn7" OnClick="btnUpdate_Click">
                                    </asp:Button>&nbsp;<%--Width="65px"
                                    Height="27px" --%>
                                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn7" OnClick="btnBack_Click" /><%-- Width="50px"
                                    Height="27px"--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <%--  <td style="width: 550px; height: 20px;" valign="middle" align="left" colspan="3">
                    <asp:UpdatePanel ID="Update1" runat="server">
                        <ContentTemplate>
                            <table id="tbl_Email" runat="server" style="width: 350px; border: Solid thin #cccccc"
                                cellspacing="1" cellpadding="0" border="0">
                                <tr>
                                    <td style="width: 10px;" valign="middle" align="left" bgcolor="#EBF5FF">
                                    </td>
                                    <td valign="middle" align="left" colspan="3" class="MenuHead" style="width: 580px;
                                        height: 20px; font-weight: bold;" bgcolor="#EBF5FF">
                                        <asp:Label ID="Label8" runat="server" Text="" CssClass="GridHead" ForeColor="#1B4A77">Alert Emails</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 10px;" valign="middle" align="left">
                                    </td>
                                    <td valign="middle" align="left" colspan="3" class="MenuHead" style="width: 580px;
                                        height: 20px; font-weight: bold;" bgcolor="#ffffff">
                                        <asp:Label ID="lblmsg2" runat="server" CssClass="ErrLbl"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 10px;" valign="middle" align="left">
                                    </td>
                                    <td style="width: 100px; height: 25px;">
                                        <asp:Label ID="Label27" runat="server" CssClass="label2" Text="Email : "></asp:Label>
                                    </td>
                                    <td style="width: 5px;">
                                    </td>
                                    <td align="left" style="width: 100px;">
                                        <asp:TextBox ID="txtEmail" runat="server" Width="200px" CssClass="txt1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 10px;" valign="middle" align="left">
                                    </td>
                                    <td colspan="3" style="height: 25px;" align="center">
                                        <asp:Button ID="btnadd" runat="server" Text="Add" CssClass="btn7" Width="65px" Height="27px"
                                            OnClick="btnadd_Click"></asp:Button>&nbsp;
                                        <asp:Button ID="btncancel" runat="server" Text="Reset" CssClass="btn7" Width="50px"
                                            Height="27px" OnClick="btncancel_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 10px; height: 20px;" valign="middle" align="left">
                                    </td>
                                    <td colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 10px;" valign="middle" align="left">
                                    </td>
                                    <td colspan="3" align="center">
                                        <asp:DataGrid ID="dgemail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                            BorderColor="LightBlue" Width="300px" OnItemCommand="dgemail_ItemCommand">
                                            <SelectedItemStyle ForeColor="White" />
                                            <ItemStyle Font-Names="Verdana" Font-Size="11px" ForeColor="Black" Height="20px"
                                                BorderColor="lightBlue" />
                                            <HeaderStyle BackColor="#007dc5" Height="25px" HorizontalAlign="Center" CssClass="whitefont"
                                                VerticalAlign="Middle" />
                                            <Columns>
                                                <asp:BoundColumn DataField="id" HeaderText="" Visible="false"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="Sr.No.">
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                    <HeaderStyle Width="50px" />
                                                    <ItemTemplate>
                                                        <%#(dgemail.PageSize * dgemail.CurrentPageIndex) + Container.ItemIndex + 1%>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                    
                                                <asp:BoundColumn DataField="Email_id" HeaderText="Email"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="Remove">
                                                    <HeaderStyle Width="50px" />
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnimg1" runat="server" AlternateText="Remove File" ImageUrl="../images/remove icon.jpg"
                                                            Width="20px" Height="20px" CommandName="remove" />
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="id" Visible="false"></asp:BoundColumn>
                                            </Columns>
                                            <PagerStyle CssClass="vergridfooter" HorizontalAlign="Center" Mode="NumericPages" />
                                        </asp:DataGrid>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 10px; height: 40px;" valign="middle" align="left">
                                    </td>
                                    <td colspan="3">
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>--%>
                </tr>
                <tr>
                    <td style="width: 970px; height: 3px;" colspan="4" valign="middle" align="left">
                    </td>
                </tr>
                <tr>
                    <td style="width: 970px; height: 3px;" colspan="4" valign="middle" align="left">
                        <table>
                            <tr>
                                <td style="width: 635px; padding-left: 370px; height: 30px;" valign="middle" align="center">
                                    <asp:Label ID="lblmsg" runat="server" ForeColor="red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" valign="middle" align="center" class="style1">
                        <%--<fckeditorv2:fckeditor id="editor1" runat="server"></fckeditorv2:fckeditor>--%>
                        <%-- <asp:TextBox name="editor1" ID="editor1" runat="server"  TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
                        <script type="text/javascript">
                            CKEDITOR.replace('editor1');
                        </script>--%>
                        <CKEditor:CKEditorControl ID="editor1" runat="server">
                        </CKEditor:CKEditorControl>
                    </td>
                </tr>
                <tr>
                    <td style="width: 970px; height: 8px;" valign="middle" align="center">
                    </td>
                </tr>
            </table>
        </center>
    </div>
</asp:Content>
