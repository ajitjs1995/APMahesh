<%@ Page Title="" Language="C#" MasterPageFile="~/tmbadm/AdmMaster.master" AutoEventWireup="true" CodeFile="ManagePressRelease.aspx.cs" Inherits="tmbadm_ManagePressRelease" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    $(function () {
        $('#txtDatePicker').datepicker(
                {
                    //                    dateFormat: 'dd/mm/yy',
                    dateFormat: 'dd/mm/yy',
                    changeMonth: true,
                    changeYear: true,
                    yearRange: '1950:2100'
                });
    })
    function checkGreaterDate(sender, args) {
        if (sender._selectedDate > new Date()) {
            alert("You can only select a day earlier than today!");
            sender._selectedDate = new Date();
            // set the date back to the current date
            sender._textbox.set_Value(sender._selectedDate.format(sender._format))
        }
    }
    function checkToDate(sender, args) {
        if (sender._selectedDate < new Date()) {
            //                  alert("You can only select a day  than today!");
            sender._selectedDate = new Date();
            // set the date back to the current date
            sender._textbox.set_Value(sender._selectedDate.format(sender._format))
        }
    }
    function allowOnlyNumber(evt) {

        alert('Please select date');
        return false;
        // var charCode = (evt.which) ? evt.which : event.keyCode
        // if (charCode > 31 && (charCode < 48 || charCode > 57))
        //  return false;
        // return true;
    }
    $(document).ready(function () {
        $('#MyTextBox').bind('copy paste cut', function (e) {
            e.preventDefault(); //disable cut,copy,paste
        });
    });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

     <table id="Table2" runat="server" style="width: 90%;" cellspacing="0" cellpadding="0"
        align="center" border="0">
        <tr runat="server" id="trsrch">
            <td style="width: 95%; height: 25px;" valign="middle" align="center" colspan="2">
                <table id="tbl_NewsLtrRegist" runat="server" style="width: 70%; border: 1px solid  #0d1e4a;
                    height: 210px;" cellspacing="1" cellpadding="0" border="0">
                    <tr>
                        <td valign="middle" height="30px" align="center" colspan="6" class="tdHeader" style="padding-left: 10px;">
                            <asp:Label ID="Label3" runat="server" Text="Search Press Release"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px;" valign="top" align="left">
                        </td>
                        <td valign="middle" align="left" colspan="6" style="height: 20px;">
                            &nbsp;<asp:Label ID="lblSrchErr" runat="server" CssClass="ErrLbl" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 2%; height: 40px;" valign="top" align="left">
                        </td>
                        <td valign="middle" style="width: 18%;">
                            <asp:Label ID="Label6" runat="server" Text="Title :"></asp:Label>
                        </td>
                        <td style="padding-left: 3px;" valign="top" align="left">
                            <asp:TextBox ID="txtSrchFileNm" runat="server" CssClass="form-control" 
                                Width="200px"></asp:TextBox>
                        </td>
                        <td style="width: 2%; height: 40px;" valign="top" align="left">
                        </td>
                        <td valign="middle" style="width: 17%;">
                            <asp:Label ID="Label7" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td style="padding-left: 3px;" valign="top" align="left">
                            <asp:TextBox ID="txtDescsrch" runat="server" CssClass="form-control" Width="200px"  AutoComplete="new-password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 2%; height: 40px;" valign="top" align="left">
                        </td>
                        <td valign="middle" style="width: 15%;">
                            <asp:Label ID="Label9" runat="server" Text="Notice Date:"></asp:Label>
                        </td>
                        <td style="padding-left: 3px;" valign="top" align="left">
                            <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" Width="200px"
                                  onkeypress="return allowOnlyNumber(event);" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                                PopupButtonID="txtFromDate" Format="yyyy-MM-dd" PopupPosition="BottomLeft">
                            </asp:CalendarExtender>
                        </td>
                        <td style="width: 2%; height: 40px;" valign="top" align="left">
                        </td>
                       
                    </tr>
                    <tr>
                        <td valign="middle" align="center" colspan="6">
                            <asp:Button ID="btnSrch" runat="server" Text="Search" CssClass="btn7" OnClick="btnSrch_Click" />&nbsp;&nbsp;
                            <asp:Button ID="reset" runat="server" Text="Reset" CssClass="btn7" onclick="reset_Click"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
       
        <tr>
            <td style="width: 970px; height: 8px;" valign="top" align="center" colspan="2">
                <asp:Label ID="lblmessage" runat="server" CssClass="ErrLbl" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="5" style="width: 970px; height: 20px;">
                
            </td>
        </tr>
         
         </table>
        <table id="trmain" runat="server" style="width: 90%;" cellspacing="0" cellpadding="0"
        align="center" border="0">
        <tr>
            <%-- <td style="width: 10px;" valign="top" align="left">
                        </td>--%>
            <td align="center" colspan="5" style="width: 970px; height: 20px;">
                <asp:Label ID="lblAddMainHead1" runat="server" Class="ErrLbl"></asp:Label>
            </td>
        </tr>
        <tr id="tr_AddNew" runat="server">
            <td style="width: 95%; height: 25px;" valign="middle" align="center" colspan="2">
                <table style="width: 70%; border: 1px solid #0d1e4a; height: 210px;" cellspacing="1"
                    cellpadding="0" border="0">
                    <tr>
                        <td valign="middle" height="30px" align="center" colspan="6" class="tdHeader" style="padding-left: 10px;">
                            <asp:Label ID="lblAddMainHead" runat="server" Text="Add Press Release"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px;" colspan="6" valign="top" align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="7" style="height: 20px;">
                            <asp:Label ID="lblMainMsg" runat="server" Class="ErrLbl"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px;" colspan="6" valign="top" align="left">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 2%; height: 40px;" valign="top" align="left">
                        </td>
                        <td valign="middle" align="left" style="width: 12%; padding-right: 3px;">
                           <span class="ErrLbl"> * </span> <asp:Label ID="Label2" runat="server" Text="Title :"></asp:Label>
                        </td>
                        <td style="width: 35%; padding-left: 3px;" valign="top" align="left">
                            <asp:TextBox ID="txtitle" Width="200px" CssClass="form-control" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 2%;" valign="top" align="left">
                        </td>
                        <td valign="middle" align="left" style="width: 12%;">
                          <span class="ErrLbl"> * </span>  <asp:Label ID="Label5" runat="server" Text="Notice Date :"></asp:Label>
                        </td>
                        <td style="width: 35%; padding-left: 3px;" valign="top" align="left">
                            <asp:TextBox ID="txtnoticedate" Width="200px" CssClass="form-control" runat="server" oncopy="return false" onpaste="return false" oncut="return false"
                                onkeypress="return allowOnlyNumber(event);"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtnoticedate"
                                PopupButtonID="txtnoticedate" Format="yyyy-MM-dd" PopupPosition="BottomLeft">
                            </asp:CalendarExtender>
                        </td>
                       
                    </tr>
                    <tr>
                        <td style="width: 2%; height: 40px;" valign="top" align="left">
                        </td>
                        <td valign="middle" align="left" style="width: 12%;">
                           <span class="ErrLbl"> * </span>  <asp:Label ID="Label1" runat="server" Text="File Heading :"></asp:Label>
                        </td>
                        <td style="width: 35%; padding-left: 3px;" valign="top" align="left">
                           <asp:TextBox ID="txtheading" TextMode="MultiLine" Width="200px" CssClass="form-control"
                                runat="server" Height="70px"></asp:TextBox>
                        </td>
                        <td style="width: 2%;" valign="top" align="left">
                        </td>
                        <td style="width: 12%;" valign="middle" align="left">
                          <span class="ErrLbl"> * </span>  <asp:Label ID="Label8" runat="server" Text="Description :"></asp:Label>&nbsp;
                        </td>
                        <td style="width: 35%; padding-left: 3px;" valign="top" align="left">
                            <asp:TextBox ID="txtdesc" Width="200px" TextMode="MultiLine" CssClass="form-control" runat="server" Height="70px"></asp:TextBox>
                        </td>
                    </tr>
                    
                    
                    <tr>
                        <td style="width: 2%; height: 40px;" valign="top" align="left">
                        </td>
                        <td valign="middle" align="left" style="width: 12%;">
                             <asp:Label ID="Label10" runat="server" Text="Upload file :"></asp:Label>
                        </td>
                        <td style="width: 35%; padding-left: 3px;" valign="top" align="left">
                           <asp:TextBox ID="txtTempFilenm" Width="200px" CssClass="form-control" Visible="false" runat="server"></asp:TextBox>
                              <asp:FileUpload ID="FileNews" Width="200px" runat="server" />
                        </td>
                        <td style="width: 2%;" valign="top" align="left">
                        </td>
                        
                         <td style="padding-left: 3px;" valign="middle" align="left">
                            Page :
                        </td>
                        <td style="padding-left: 3px;" valign="middle" align="left">
                            <asp:DropDownList ID="cmbWebPage" runat="server" CssClass="form-control" Width="230px"
                                AutoPostBack="False"> 
                            </asp:DropDownList>
                        </td>
                       
                    </tr>
                    
                     <tr id="tr_NwsLnk" runat="server">
                        <td style="width: 2%; height: 40px;" valign="top" align="left">
                        </td>
                        <td valign="middle" style="width: 12%;">
                            <asp:Label ID="Label14" runat="server" Text="Linked file"> </asp:Label>
                        </td>
                        <td style="padding-left: 3px;" valign="top" align="left" colspan="3">
                            <asp:Label ID="lblNwsFileNm" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;<asp:LinkButton
                                ID="lnkRemove" runat="server" OnClick="lnkRemove_Click1" ForeColor="Red">Remove</asp:LinkButton>
                        </td>
                       
                        
                    </tr>

                     <tr>
                    <td style="width: 2%; height: 40px;" valign="top" align="left">
                        </td>
                        <td valign="middle" style="width: 12%;">
                            <asp:Label ID="Label4" runat="server" Text="External Url:"></asp:Label>
                        </td>
                        <td style="padding-left: 3px;" valign="middle" align="left">
                          <asp:TextBox ID="txturl" runat="server" CssClass="form-control" Width="200px" EnableViewState="False" AutoComplete="Off"></asp:TextBox>  
                        </td>
                        <td style="width: 2%; height: 40px;" valign="top" align="left">
                        </td>
                         <td valign="middle" style="width: 12%;">
                            <asp:Label ID="Label12" runat="server" Text="Active :"></asp:Label>
                        </td>
                        <td  style="width:10%;" valign="top" align="left" >
                        <asp:RadioButtonList ID="rdbMainAct" runat="server" RepeatDirection="Horizontal" Width="160px">
                                <asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
                                <asp:ListItem Value="N">No</asp:ListItem>
                            </asp:RadioButtonList>
                        
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px;" colspan="6" valign="top" align="right">
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" align="center" colspan="6">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn7" 
                                onclick="btnAdd_Click"  />&nbsp;&nbsp;
                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn7" onclick="btnReset_Click" 
                                 />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn7" 
                                onclick="btnCancel_Click"  />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px;" colspan="6" valign="top" align="left">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px;" colspan="6" valign="top" align="left">
                        </td>
                    </tr>
                </table>
                  <tr>
                        <td style="height: 5px;" colspan="6" valign="top" align="left">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px;" colspan="6" valign="top" align="left">
                        </td>
                    </tr>
            </td>
        </tr>
        
         <tr>
            <td style="width: 970px; height: 20px;" valign="top" align="center">
               
            </td>
        </tr>
        <tr>
            <td style="width: 970px; height: 20px;" valign="top" align="center">
                         <asp:Label ID="lblmsg" runat="server" CssClass="ErrLbl"></asp:Label>
                <asp:Label ID="lblerr" runat="server" CssClass="ErrLbl"></asp:Label>
            </td>
        </tr>
        <tr runat="server" id="traddnewlink">
        
            <td style="width: 410px; height: 60px;"  align="right">
            
                &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkAddNew" runat="server" Text="Add New Press Release"
                  OnClick="lnkAddNew_Click1" style="border:1px solid white; width:600px; padding:9px; border-radius:5px; background-color:#c5017e; color:White; text-decoration:none" ></asp:LinkButton> 
                  
            </td>
        </tr>
        <tr align="center" runat="server" id="trdatagrid">
            <td style="width: 970px; height: 25px;" valign="middle" align="center">
                <div id="container">
                    <asp:DataGrid ID="dg_press" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                        CellPadding="5" CellSpacing="3" PageSize="10" Width="100%" 
                        GridLines="None" onitemcommand="dg_press_ItemCommand" 
                        onitemdatabound="dg_press_ItemDataBound" 
                        onpageindexchanged="dg_press_PageIndexChanged">
                        <HeaderStyle BackColor="#1E3A8E" ForeColor="#FFFFFF" Height="25px" HorizontalAlign="Center"
                            CssClass="" VerticalAlign="Middle" Font-Size="16px" />
                        <ItemStyle Height="20px" BackColor="#FFFFFF" HorizontalAlign="Left" VerticalAlign="Top"
                            CssClass="padding" Font-Size="14px" />
                        <AlternatingItemStyle Height="20px" CssClass="padding" BackColor="WhiteSmoke" HorizontalAlign="Left"
                            VerticalAlign="Top" Font-Size="14px" />
                        <PagerStyle Mode="NumericPages" HorizontalAlign="center" VerticalAlign="middle" Font-Size="16px" />
                        <Columns>
                         <%--0--%>
                            <asp:BoundColumn DataField="Id" HeaderText="ID" Visible="False"></asp:BoundColumn>
                             <%--1--%>
                            <asp:TemplateColumn HeaderText="Sr.No.">
                                <ItemStyle HorizontalAlign="Center" Width="3%" />
                                <HeaderStyle Width="3%" />
                                <ItemTemplate>
                                    <%#(dg_press.PageSize * dg_press.CurrentPageIndex) + Container.ItemIndex + 1%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                             <%--2--%>
                            <asp:BoundColumn DataField="" HeaderText="Press Release">
                                <ItemStyle Width="33%" CssClass="padding" />
                                <HeaderStyle Width="33%" />
                            </asp:BoundColumn>
                            <%--3--%>
                            <asp:BoundColumn DataField="" HeaderText="File Heading">
                                <ItemStyle Width="33%" CssClass="padding" />
                                <HeaderStyle Width="33%" />
                            </asp:BoundColumn>
                             <%--4--%>
                            <asp:TemplateColumn HeaderText="File">
                                <HeaderStyle Width="20%" />
                                <ItemStyle HorizontalAlign="center" Width="20%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkPressFile" runat="server" CommandName="PressFile" CssClass="label2 padding"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                             <%--5--%>
                            <asp:BoundColumn DataField="" HeaderText="Notice Date">
                                <ItemStyle HorizontalAlign="center" Width="15%" CssClass="padding" />
                                <HeaderStyle Width="15%" />
                            </asp:BoundColumn>
                            
                            <%--6--%>
                            <asp:TemplateColumn HeaderText="Action">
                                <HeaderStyle Width="9%" />
                                <ItemStyle HorizontalAlign="Center" Width="9%" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkPressEdit" runat="server" CommandName="PressReleaseEdit" CssClass="label2">Edit</asp:LinkButton>&nbsp;|&nbsp;<asp:LinkButton
                                        ID="lnkPressDelete" runat="server" CommandName="PressDelete" CssClass="label2">Delete</asp:LinkButton>&nbsp;|&nbsp;<asp:LinkButton
                                        ID="lnkPressCheck" runat="server" CommandName="PressChecked" CssClass="label2">Check</asp:LinkButton>

                                </ItemTemplate>
                            </asp:TemplateColumn>
                             <%--7--%>
                            <asp:BoundColumn DataField="Title" HeaderText="Title" Visible="False"></asp:BoundColumn>
                           <%--8--%>
                            <asp:BoundColumn DataField="Description" HeaderText="" Visible="False"></asp:BoundColumn>
                             <%--9--%>
                            <asp:BoundColumn DataField="FileHeading" HeaderText="" Visible="False"></asp:BoundColumn>
                            <%--10--%>
                            <asp:BoundColumn DataField="FileName" HeaderText="" Visible="False"></asp:BoundColumn>
                             <%--11--%>
                            <asp:BoundColumn DataField="NoticeDate" HeaderText="" Visible="False"></asp:BoundColumn>
                            <%--12--%>
                             <asp:BoundColumn DataField="Active" HeaderText="" Visible="False"></asp:BoundColumn>
                        </Columns>
                    </asp:DataGrid>
                </div>
                <br />
            </td>
        </tr>
    </table>
    
   
    
</asp:Content>

