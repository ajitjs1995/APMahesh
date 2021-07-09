<%@ Page Title="" Language="C#" MasterPageFile="~/tmbadm/AdmMaster.master" AutoEventWireup="true" CodeFile="Manage_PgMenuEnglish.aspx.cs" Inherits="Admin_Manage_PgMenuEnglish" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
  .rbl input[type="radio"]
{
   margin-left: 5px;
   margin-right: 5px;
}
.tdpadding12
{
   text-align:center;
}
    .btn7
{
	border: thin solid Silver;
	font-size: 11px;
	font-weight :bold;
	font-family: Verdana, Helvetica, sans-serif;
	background-color:#DA251C;
	color:#FFFFFF;
	text-align: center;
	margin-left: 0px;
	padding-top:3px;
	
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
    }
.btn7:hover{
	background-color: #E6EAF7; 
	color: #163384;
}

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="tbl_main" runat="server" style="width: 100%;" cellspacing="0" cellpadding="0"
        align="center" border="0">
        <tr id="tr_menu">
            <td style="width: 100%; height: 20px;" valign="middle" align="center" colspan="3">
                <table id="Table1" runat="server" style="width: 70%; border: Solid thin #cccccc; border-collapse:separate; height:200px;"
                    cellspacing="1" cellpadding="0" border="0">
                    <tr>
                        <td valign="middle" align="left" colspan="7" class="bgcolor" style="width: 650px;
                            height: 30px; padding-left:10px;" bgcolor="#DA251C">
                            <asp:Label ID="lblAddMainHead" runat="server" Text="" ForeColor="white">Add 
                        New Menu</asp:Label>
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
                        <td style="width: 2%; height: 25px;" valign="middle" align="left">
                        </td>
                        <td style="width: 15%; height: 25px;" valign="middle" align="left">
                            <asp:Label ID="Label2" runat="server" CssClass="label2" Text="Menu Text :"></asp:Label>
                        </td>
                        <td style="width: 32%; height: 25px;" valign="middle" align="left">
                            <asp:TextBox ID="txtManuName" runat="server" CssClass="form-control" Width="250px"></asp:TextBox>
                        </td>
                        <td style="width:2%;">
                        </td>
                        <td style="width: 15%; height: 25px;" valign="middle" align="left">
                            <asp:Label ID="Label4" runat="server" CssClass="label2" Text="Menu Page :"></asp:Label>
                            &nbsp;
                        </td>
                        <td style="width: 32%; height: 25px;" valign="middle" align="left">
                            <asp:DropDownList ID="cmbWebPage" runat="server" CssClass="form-control" Width="225px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                    <td height="10px"></td>
                    </tr>
                    <tr>
                        <td valign="middle" align="left">
                            &nbsp;
                        </td>
                        <td  valign="middle" align="left">
                            <asp:Label ID="Label9" runat="server" CssClass="label2">Upload File</asp:Label>
                            <asp:TextBox ID="txtTempFilenm" runat="server" BorderColor="White" BorderStyle="Solid"
                                ReadOnly="true" BorderWidth="1px" Font-Size="0pt" Visible="true" Width="1px"
                                ForeColor="#ffffff">
                            </asp:TextBox>
                        </td>
                        <td valign="middle" align="left">
                            <asp:FileUpload ID="FileMenuDoc" runat="server" CssClass="" Width="205px" />
                        </td>
                        <td style="width:2%"></td>
                        <td valign="middle" align="left" class="label2">
                            Active :&nbsp;
                        </td>
                        <td style="height: 25px;" valign="middle" align="left">                            
                        <asp:RadioButtonList ID="rdbAct" runat="server" RepeatDirection="Horizontal" CssClass="rbl">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px;" valign="middle" align="left" bgcolor="#ffffff">
                        </td>
                        <td valign="middle" align="left" colspan="5" class="MenuHead" style="width: 580px;
                            height: 20px; font-weight: bold;" bgcolor="#ffffff">
                            <asp:LinkButton ID="lnkMenuFile" runat="server" ForeColor="Blue" Font-Underline="true"
                                CssClass="label2"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 25px;" valign="middle" align="left">
                            &nbsp;
                        </td>
                        <td style="width: 90px; height: 25px;" valign="middle" align="left">
                            <asp:Label ID="Label3" runat="server" CssClass="label2">External URL </asp:Label>
                        </td>
                        <td style="height: 25px;" valign="top" align="left">
                            <asp:TextBox ID="txturl" runat="server" CssClass="form-control" Width="250px"></asp:TextBox>
                        </td> 
                         <td style="width:2%"></td>
                         <td valign="middle" align="left" class="label2">
                         <asp:Label ID="Label5" runat="server" CssClass="label2" Visible="false" Text="Menu Loaction : "></asp:Label>
                            &nbsp;
                        </td>
                        <td style="width: 100%;" valign="top" align="left" colspan="3">

                        <asp:RadioButtonList ID="rbtmenulocation" runat="server"  Visible="false"
                                RepeatDirection="Horizontal" CssClass="rbl" AutoPostBack="true"
                                onselectedindexchanged="rbtmenulocation_SelectedIndexChanged">
                                <asp:ListItem Value="Left">Left</asp:ListItem>
                                <asp:ListItem Value="Right">Right</asp:ListItem>
                                
                            </asp:RadioButtonList>

                            
                          </td>
                    </tr>
                     <tr>
                    <td height="15px"></td>
                    </tr>
                    <tr>
                    <td colspan="6" align="center">
                     <asp:Button ID="btnAdd" runat="server" Text="Update" CssClass="btn7" 
                                 onclick="btnAdd_Click" Width="84px" ></asp:Button><%-- Width="65px"
                                            Height="18px"--%>&nbsp;&nbsp;&nbsp;&nbsp;
                             <asp:Button ID="btnReset" runat="server" Text="Cancel" CssClass="btn7" Width="84px"
                                 onclick="btnReset_Click" /><%-- Width="65px"
                                            Height="18px" --%>
                    </td>
                    </tr>
                    <tr>
                    <td height="15px"></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 970px; height: 3px;" valign="middle" align="left" colspan="3">
            </td>
        </tr>
        <tr>
            <td style="width: 90%; height: 30px;" valign="middle" align="center">
                <table width="90%">
                    <tr>
                        <td>
                            <asp:Label ID="lblParentPage" runat="server" Text="" ForeColor="Blue"></asp:Label>
                        </td>
                    </tr>
                </table>               
            </td>
        </tr>
        <tr>
            <td style="width: 90%; height: 20px;" valign="middle" align="center">
                <table width="90%">
                    <tr>
                        <td align="left" valign="middle">
                            <asp:LinkButton ID="lnkAddNew" runat="server" Text="Add New Menu" Font-Names="Verdana"
                        Font-Size="10pt" Font-Bold="true" ForeColor="#1B4A77" OnClick="lnkAddNew_Click"></asp:LinkButton>
                        &nbsp;&nbsp;&nbsp;
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                RepeatDirection="Horizontal" CssClass="rbl" AutoPostBack="true"
                                onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                                <asp:ListItem Value="Left" Selected="true">Left</asp:ListItem>
                                <asp:ListItem Value="Right">Right</asp:ListItem>
                                
                            </asp:RadioButtonList>
                        </td>
                        <td align="right" valign="middle">
                            <asp:LinkButton ID="lnkHome" runat="server" Text="Home" Font-Names="Verdana" Font-Size="8pt"
                        Font-Bold="true" ForeColor="#1B4A77" OnClick="lnkHome_Click"></asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton
                            ID="lnkBack" runat="server" Text="Back" Font-Names="Verdana" Font-Size="8pt"
                            Font-Bold="true" ForeColor="#1B4A77" OnClick="lnkBack_Click"></asp:LinkButton>
                        </td>
                    </tr>
                </table>                
            </td>
        </tr>
          <tr>
        <td height="35px"></td>
        </tr>
        <tr>
            <td style="width: 100%; height: 30px;" valign="middle" align="center">
                <asp:Label ID="lblmsg" runat="server" CssClass="ErrLbl"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 25px;" valign="middle" align="center" colspan="3">
                <asp:DataGrid ID="dg_Menu" Width="90%" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                    GridLines="None" CellSpacing="3" OnItemCommand="dg_Menu_ItemCommand1" OnItemDataBound="dg_Menu_ItemDataBound">
                    <HeaderStyle BackColor="#DA251C" Height="30px" HorizontalAlign="Center" CssClass="GridHead"
                        VerticalAlign="Middle" ForeColor="White" />
                    <ItemStyle Height="20px" BackColor="#F3F3F3" HorizontalAlign="Left" VerticalAlign="Top"
                        CssClass="label2" />
                    <Columns>
  <%---------------------------------------------------0--------------------------------------%>
                        <asp:BoundColumn DataField="LnkID" HeaderText="Link ID" Visible="False"></asp:BoundColumn>
                 <%--      -------------------------------------------------1----------------------------------------%>
                        <asp:TemplateColumn HeaderText="Sr.No.">
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                            <HeaderStyle Width="7%" />
                            <ItemTemplate>
                                <%#(dg_Menu.PageSize * dg_Menu.CurrentPageIndex) + Container.ItemIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <%---------------------------------------------------2--------------------------------------%>
                        <asp:BoundColumn DataField="LnkName" HeaderText="Menu Text">
                            <ItemStyle Width="22%" CssClass="tdpadding12" />
                            <HeaderStyle Width="22%" />
                        </asp:BoundColumn>
                          <%---------------------------------------------------3--------------------------------------%>
                         <asp:BoundColumn DataField="menulocation" HeaderText="Menu Location">
                            <ItemStyle Width="10%" CssClass="tdpadding12" />
                            <HeaderStyle Width="10%" />
                        </asp:BoundColumn>
                          <%---------------------------------------------------3/4--------------------------------------%>
                        <asp:BoundColumn DataField="LnkHLink" HeaderText="Menu Link">
                            <ItemStyle Width="30%" CssClass="tdpadding12" />
                            <HeaderStyle Width="30%" />
                        </asp:BoundColumn>
                          <%---------------------------------------------------4/5--------------------------------------%>
                        <asp:TemplateColumn HeaderText="Menu Index">
                            <HeaderStyle Width="9%" />
                            <ItemStyle HorizontalAlign="Center" Width="9%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtMenuIndex" runat="server" CssClass="txt1" Width="50px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <%---------------------------------------------------5/6--------------------------------------%>
                        <asp:TemplateColumn HeaderText="Add Child">
                            <HeaderStyle Width="11%" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkAddChild" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="AddChild">Add 
                                    Child Page</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <%---------------------------------------------------6/7--------------------------------------%>
                        <asp:TemplateColumn HeaderText="Action">
                            <HeaderStyle Width="11%" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkMenuEdit" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="MenuEdit">Edit</asp:LinkButton>
                                |
                                <asp:LinkButton ID="lnkMenuDelete" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="MenuDelete">Delete</asp:LinkButton><br />
                                <asp:LinkButton id="lnkMenuCheck" runat="server" CssClass="label2" ForeColor="Blue" CommandName="MenuCheck">Check</asp:LinkButton>
                            
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <%---------------------------------------------------7/8--------------------------------------%>
                        <asp:BoundColumn DataField="PageID" HeaderText="Pg Id" Visible="false"></asp:BoundColumn>
                          <%---------------------------------------------------8/9--------------------------------------%>
                        <asp:BoundColumn DataField="Parentid" HeaderText="Parent Id" Visible="false"></asp:BoundColumn>
                          <%---------------------------------------------------9/10--------------------------------------%>
                        <asp:BoundColumn DataField="parentlinkid" HeaderText="Parent Id" Visible="false">
                        </asp:BoundColumn>
                          <%---------------------------------------------------10/11--------------------------------------%>
                        <asp:BoundColumn DataField="lnkAct" HeaderText="Active" Visible="false"></asp:BoundColumn>
                          <%---------------------------------------------------11/12--------------------------------------%>
                        <asp:BoundColumn DataField="LnkID" HeaderText="Active" Visible="false"></asp:BoundColumn>
                    </Columns>
                </asp:DataGrid>
            </td>
        </tr>

       
         <tr>
            <td style="width: 100%; height: 25px;" valign="middle" align="center" colspan="3">
                <asp:DataGrid ID="dgleft_menu" Width="90%" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                    GridLines="None" CellSpacing="3" onitemcommand="dgleft_menu_ItemCommand" 
                    onitemdatabound="dgleft_menu_ItemDataBound">
                    <HeaderStyle BackColor="#DA251C" Height="30px" HorizontalAlign="Center" CssClass="GridHead"
                        VerticalAlign="Middle" ForeColor="White" />
                    <ItemStyle Height="20px" BackColor="#F3F3F3" HorizontalAlign="Left" VerticalAlign="Top"
                        CssClass="label2" />
                    <Columns>
  <%---------------------------------------------------0--------------------------------------%>
                        <asp:BoundColumn DataField="LnkID" HeaderText="Link ID" Visible="False"></asp:BoundColumn>
                 <%--      -------------------------------------------------1----------------------------------------%>
                        <asp:TemplateColumn HeaderText="Sr.No.">
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                            <HeaderStyle Width="7%" />
                            <ItemTemplate>
                                <%#(dgleft_menu.PageSize * dgleft_menu.CurrentPageIndex) + Container.ItemIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <%---------------------------------------------------2--------------------------------------%>
                        <asp:BoundColumn DataField="LnkName" HeaderText="Menu Text">
                            <ItemStyle Width="22%" CssClass="tdpadding12" />
                            <HeaderStyle Width="22%" />
                        </asp:BoundColumn>
                          <%---------------------------------------------------3--------------------------------------%>
                         <asp:BoundColumn DataField="menulocation" HeaderText="Menu Location">
                            <ItemStyle Width="10%" CssClass="tdpadding12" />
                            <HeaderStyle Width="10%" />
                        </asp:BoundColumn>
                          <%---------------------------------------------------3/4--------------------------------------%>
                        <asp:BoundColumn DataField="LnkHLink" HeaderText="Menu Link">
                            <ItemStyle Width="30%" CssClass="tdpadding12" />
                            <HeaderStyle Width="30%" />
                        </asp:BoundColumn>
                          <%---------------------------------------------------4/5--------------------------------------%>
                        <asp:TemplateColumn HeaderText="Menu Index">
                            <HeaderStyle Width="9%" />
                            <ItemStyle HorizontalAlign="Center" Width="9%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtMenuIndexleft" runat="server" CssClass="txt1" Width="50px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <%---------------------------------------------------5/6--------------------------------------%>
                        <asp:TemplateColumn HeaderText="Add Child">
                            <HeaderStyle Width="11%" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkAddChildleft" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="AddChildleft">Add 
                                    Child Page</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <%---------------------------------------------------6/7--------------------------------------%>
                        <asp:TemplateColumn HeaderText="Action">
                            <HeaderStyle Width="11%" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkMenuEditleft" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="MenuEditleft">Edit</asp:LinkButton>
                                |
                                <asp:LinkButton ID="lnkMenuDeleteleft" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="MenuDeleteleft">Delete</asp:LinkButton><br />
                                <asp:LinkButton id="lnkMenuCheckleft" runat="server" CssClass="label2" ForeColor="Blue" CommandName="MenuCheckleft">Check</asp:LinkButton>
                            
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <%---------------------------------------------------7/8--------------------------------------%>
                        <asp:BoundColumn DataField="PageID" HeaderText="Pg Id" Visible="false"></asp:BoundColumn>
                          <%---------------------------------------------------8/9--------------------------------------%>
                        <asp:BoundColumn DataField="Parentid" HeaderText="Parent Id" Visible="false"></asp:BoundColumn>
                          <%---------------------------------------------------9/10--------------------------------------%>
                        <asp:BoundColumn DataField="parentlinkid" HeaderText="Parent Id" Visible="false">
                        </asp:BoundColumn>
                          <%---------------------------------------------------10/11--------------------------------------%>
                        <asp:BoundColumn DataField="lnkAct" HeaderText="Active" Visible="false"></asp:BoundColumn>
                          <%---------------------------------------------------11/12--------------------------------------%>
                        <asp:BoundColumn DataField="LnkID" HeaderText="Active" Visible="false"></asp:BoundColumn>
                    </Columns>
                </asp:DataGrid>
            </td>
        </tr>

      <%-- -------------------------child menu------------------------%>
      <tr>
            <td style="width: 100%; height: 25px;" valign="middle" align="center" colspan="3">
                <asp:DataGrid ID="dgchild" Width="90%" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                    GridLines="None" CellSpacing="3" onitemcommand="dgchild_ItemCommand" onitemdatabound="dgchild_ItemDataBound" 
               >
                    <HeaderStyle BackColor="#DA251C" Height="30px" HorizontalAlign="Center" CssClass="GridHead"
                        VerticalAlign="Middle" ForeColor="White" />
                    <ItemStyle Height="20px" BackColor="#F3F3F3" HorizontalAlign="Left" VerticalAlign="Top"
                        CssClass="label2" />
                    <Columns>
  <%---------------------------------------------------0--------------------------------------%>
                        <asp:BoundColumn DataField="LnkID" HeaderText="Link ID" Visible="False"></asp:BoundColumn>
                 <%--      -------------------------------------------------1----------------------------------------%>
                        <asp:TemplateColumn HeaderText="Sr.No.">
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                            <HeaderStyle Width="7%" />
                            <ItemTemplate>
                                <%#(dgchild.PageSize * dgchild.CurrentPageIndex) + Container.ItemIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <%---------------------------------------------------2--------------------------------------%>
                        <asp:BoundColumn DataField="LnkName" HeaderText="Menu Text">
                            <ItemStyle Width="22%" CssClass="tdpadding12" />
                            <HeaderStyle Width="22%" />
                        </asp:BoundColumn>
                          <%---------------------------------------------------3--------------------------------------%>
                         <asp:BoundColumn DataField="menulocation" HeaderText="Menu Location" Visible="false">
                            <ItemStyle Width="10%" CssClass="tdpadding12" />
                            <HeaderStyle Width="10%" />
                        </asp:BoundColumn>
                          <%---------------------------------------------------3/4--------------------------------------%>
                        <asp:BoundColumn DataField="LnkHLink" HeaderText="Menu Link">
                            <ItemStyle Width="30%" CssClass="tdpadding12" />
                            <HeaderStyle Width="30%" />
                        </asp:BoundColumn>
                          <%---------------------------------------------------4/5--------------------------------------%>
                        <asp:TemplateColumn HeaderText="Menu Index">
                            <HeaderStyle Width="9%" />
                            <ItemStyle HorizontalAlign="Center" Width="9%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtMenuIndex1" runat="server" CssClass="txt1" Width="50px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <%---------------------------------------------------6--------------------------------------%>
                        <asp:TemplateColumn HeaderText="Add Child" Visible="False">
                            <HeaderStyle Width="11%" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkAddChild1" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="AddChild1">Add 
                                    Child Page</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <%---------------------------------------------------7--------------------------------------%>
                        <asp:TemplateColumn HeaderText="Action">
                            <HeaderStyle Width="11%" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkMenuEdit1" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="MenuEdit1">Edit</asp:LinkButton>
                                |
                                <asp:LinkButton ID="lnkMenuDelete1" runat="server" CssClass="label2" ForeColor="Blue"
                                    CommandName="MenuDelete1">Delete</asp:LinkButton><br />
                                <asp:LinkButton id="lnkMenuCheck1" runat="server" CssClass="label2" ForeColor="Blue" CommandName="MenuCheck1">Check</asp:LinkButton>
                            
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <%---------------------------------------------------8--------------------------------------%>
                        <asp:BoundColumn DataField="PageID" HeaderText="Pg Id" Visible="false"></asp:BoundColumn>
                          <%---------------------------------------------------9--------------------------------------%>
                        <asp:BoundColumn DataField="Parentid" HeaderText="Parent Id" Visible="false"></asp:BoundColumn>
                          <%---------------------------------------------------10--------------------------------------%>
                        <asp:BoundColumn DataField="parentlinkid" HeaderText="Parent Id" Visible="false">
                        </asp:BoundColumn>
                          <%---------------------------------------------------11--------------------------------------%>
                        <asp:BoundColumn DataField="lnkAct" HeaderText="Active" Visible="false"></asp:BoundColumn>
                          <%---------------------------------------------------12--------------------------------------%>
                        <asp:BoundColumn DataField="LnkID" HeaderText="Active" Visible="false"></asp:BoundColumn>
                    </Columns>
                </asp:DataGrid>
            </td>
        </tr>
        <tr>
            <td style="width: 100%;" valign="middle" align="center">
            <table cellspacing="3" style="width:90%;">
  <tbody>
    <tr>
      <td style="width:7%;"><asp:Label ID="lblparentid" runat="server" Visible="False" ForeColor="White"></asp:Label></td>
      <td style="width:22%;"><asp:Label ID="Label1" runat="server" Visible="False" ForeColor="White"></asp:Label></td>
      <td style="width:40%;"><asp:Label ID="lbllnkid" runat="server" Visible="False" ForeColor="White"></asp:Label>
                    <asp:Label ID="tval" runat="server" Visible="False" ForeColor="White"></asp:Label></td>
      <td style="width:9%;" align="center">
	  <asp:Button ID="btnEditIndex" runat="server" Text="Update Right Menu Index" CssClass="btn1"
                        Width="169px" onclick="btnEditIndex_Click" />
                        &nbsp;
                         <asp:Button ID="btneditlftmenu" runat="server" 
              Text="Update Left Menu  Index" CssClass="btn1"  Width="169px"
                        onclick="btneditlftmenu_Click"  />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnchildIndex" runat="server" 
              Text="Update Child Menu Index" CssClass="btn1"
                        Width="169px" onclick="btnchildIndex_Click"  />
	  </td>
      <td style="width:11%;"></td>
      <td style="width:11%;"></td>
    </tr>
  </tbody>
</table>
               <%-- <div style="width: 878px; float: left; margin-left: 10px; text-align: left; color: #ffffff">
                    a
                    
                    
                    
                </div>
                <div style="width: 200px; float: left; text-align: left; color: #ffffff">
                    a
                    
                </div>--%>
            </td>
        </tr>
        <tr>
            <td style="width: 970px;" valign="middle" align="center">
                <asp:LinkButton ID="lnkBackMain" runat="server" Text="Back to Main Page" Font-Names="Verdana"
                    Font-Size="8pt" Font-Bold="true" ForeColor="#1B4A77" OnClick="lnkBackMain_Click"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="width: 970px; height: 8px;" valign="middle" align="center" colspan="3">
            </td>
        </tr>
    </table>
    <br /><br /><br />
</asp:Content>

