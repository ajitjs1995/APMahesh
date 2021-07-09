<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Manage_UserModAuth.aspx.vb" Inherits="Admin_Manage_UserModAuth" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0" id="body1" runat="server" bgcolor="#ffffff" >
    <form id="form1" runat="server" autocomplete="off">
    
    <div style="vertical-align:top; height:550px; width:780px; overflow:auto " id="divprint">
        <table cellpadding="0" cellspacing="0" border="0" width="750px" style="border : solid thin #cccccc">
            <tr>
                <td align="center" style="width: 750px; height: 8px" valign="top">
                </td> 
            </tr> 
            <tr>
                <td align="left" style="width: 750px;" valign="middle">
                    &nbsp;&nbsp;<asp:label id="lblUsrNm" runat="server" CssClass="label2" Font-Bold="true" ></asp:label>
                </td> 
            </tr>
            <tr>
                <td align="center" style="width: 750px; height: 8px" valign="top">
                </td> 
            </tr> 
            <tr>
                <td align="center" style="width: 750px; height: 8px" valign="top">
                
                                    <asp:DataGrid ID="dg_UsrAuth" Width="720px" runat="server" AllowPaging="false" AutoGenerateColumns="False" GridLines="None" CellSpacing="2" CellPadding="3" >
                                        <HeaderStyle BackColor="#1E3A8E" Height="25px" HorizontalAlign="Center" CssClass="GridHead" Verticalalign="Middle"  />
                                        <ItemStyle Height="20px" BackColor="#F3F3F3" HorizontalAlign="Left" VerticalAlign="Top" CssClass="label2"/>
                                        <Columns>
                                           
                                            <asp:BoundColumn DataField="mod_id" HeaderText="Module ID" Visible="False">
                                            </asp:BoundColumn>
                                                                        
                                            <asp:TemplateColumn HeaderText="">
                                                <HeaderStyle Width="720px" />
                                                <ItemStyle HorizontalAlign="Center" Width="720px" />
                                                <ItemTemplate>
                                                   
                                                   <table id="Table4" runat="server"  style="WIDTH: 710px; " cellspacing="0" cellpadding="0" border="0">
                                                        <tr>
                                                            <td style="WIDTH: 50px; height: 25px; " valign="middle" align="center">
                                                                <%#(dg_UsrAuth.PageSize * dg_UsrAuth.CurrentPageIndex) + Container.ItemIndex + 1%>
                                                            </td>
                                                            <td style="WIDTH: 660px; height: 25px; " valign="middle" align="left" colspan="2">
                                                                <asp:label id="lblMainModuleNm" runat="server" Text="" CssClass="label2"></asp:label>
                                                            </td>
                                                         </tr>
                                                         
                                                         <tr>
                                                            <td style="WIDTH: 50px; height: 25px; " valign="middle" align="center" >
                                                            </td>
                                                            <td style="WIDTH: 660px; height: 25px; " valign="top" align="center">
                                                                <asp:DataGrid ID="dg_ModRights" runat="server" Width="650px" AllowPaging="false" AutoGenerateColumns="False" CellSpacing="2" CellPadding="3" GridLines="None" 
                                                                    BorderStyle="Solid" BorderWidth="1px" BorderColor="#588FC5" >
                                                                    <HeaderStyle Height="20px" HorizontalAlign="Center" CssClass="GridHead2" VerticalAlign="Middle" Font-Bold="false" ForeColor="#35699B" />
                                                                    <ItemStyle Height="20px" HorizontalAlign="Center" CssClass="label2" VerticalAlign="Top" BackColor="#ffffff"/>
                                                                    <Columns>
                                                                       
                                                                        <asp:BoundColumn DataField="" HeaderText="Auth ID" Visible="False">
                                                                        </asp:BoundColumn>
                                                                        
                                                                        <asp:TemplateColumn HeaderText="Sr.No.">
                                                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                            <HeaderStyle Width="50px" />
                                                                                <ItemTemplate>
                                                                                    <%#Container.ItemIndex + 1%>
                                                                                </ItemTemplate>
                                                                        </asp:TemplateColumn>   
                                             
                                                                        <asp:BoundColumn DataField="" HeaderText="Module Authority">
                                                                            <ItemStyle Width="250px" HorizontalAlign="Left" />
                                                                            <HeaderStyle Width="250px" />
                                                                        </asp:BoundColumn>
                                                                        
                                                                        <asp:TemplateColumn HeaderText="View">
                                                                            <HeaderStyle Width="50px" />
                                                                            <ItemStyle Width="50px" />
                                                                                <ItemTemplate >
                                                                                    <asp:CheckBox ID="chkView" runat="server" CssClass="label2"></asp:CheckBox>
                                                                                </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        
                                                                        <asp:TemplateColumn HeaderText="Add">
                                                                            <HeaderStyle Width="50px" />
                                                                            <ItemStyle Width="50px" />
                                                                                <ItemTemplate >
                                                                                    <asp:CheckBox ID="chkAdd" runat="server" CssClass="label2"></asp:CheckBox>
                                                                                </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        
                                                                        <asp:TemplateColumn HeaderText="Edit">
                                                                            <HeaderStyle Width="50px" />
                                                                            <ItemStyle Width="50px" />
                                                                                <ItemTemplate >
                                                                                    <asp:CheckBox ID="chkEdit" runat="server" CssClass="label2"></asp:CheckBox>
                                                                                </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        
                                                                        <asp:TemplateColumn HeaderText="Delete">
                                                                            <HeaderStyle Width="50px" />
                                                                            <ItemStyle Width="50px" />
                                                                                <ItemTemplate >
                                                                                    <asp:CheckBox ID="chkDelete" runat="server" CssClass="label2"></asp:CheckBox>
                                                                                </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        
                                                                        <asp:TemplateColumn HeaderText="Archive">
                                                                            <HeaderStyle Width="50px" />
                                                                            <ItemStyle Width="50px" />
                                                                                <ItemTemplate >
                                                                                    <asp:CheckBox ID="chkArchive" runat="server" CssClass="label2"></asp:CheckBox>
                                                                                </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        
                                                                        <asp:TemplateColumn HeaderText="Reply">
                                                                            <HeaderStyle Width="50px" />
                                                                            <ItemStyle Width="50px" />
                                                                                <ItemTemplate >
                                                                                    <asp:CheckBox ID="chkReply" runat="server" CssClass="label2"></asp:CheckBox>
                                                                                </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        
                                                                        <asp:TemplateColumn HeaderText="Check">
                                                                            <HeaderStyle Width="50px" />
                                                                            <ItemStyle Width="50px" />
                                                                                <ItemTemplate >
                                                                                    <asp:CheckBox ID="chkCheck" runat="server" CssClass="label2"></asp:CheckBox>
                                                                                </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        
                                                                    </Columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                         </tr>
                                                    </table>
                                                   
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                    
                                        </Columns>
                                    </asp:DataGrid>
                
                </td> 
            </tr>
            <tr>
                <td align="center" style="width: 750px;" valign="middle">
                    <asp:Button id="btnOk"  runat="server" Text="OK" CssClass="btn1" 
                    />&nbsp;<asp:Button id="btnChk"  runat="server" Text="Check" CssClass="btn1" />
                </td> 
            </tr>
            <tr>
                <td align="center" style="width: 750px; height: 8px" valign="top">
                </td> 
            </tr>
        </table>
    </div>
    
    
    </form>
</body>
</html>
