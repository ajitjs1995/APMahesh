<%@ Page Title="" Language="C#" MasterPageFile="~/tmbadm/AdmMaster.master" AutoEventWireup="true"
    CodeFile="ManageUsers.aspx.cs" Inherits="tmbadm_ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function checkForm() {
            document.getElementById('<%=txtPwd.ClientID%>').value = encrypt(document.getElementById('<%=txtPwd.ClientID%>').value);

        }
        function encrypt(data) {
            var tempChar;
            var tempAsc;
            var tempLen;
            var newData;
            var i;

            newData = '';

            for (i = 0; i < data.length; i++) {
                tempChar = data.substr(i, 1);
                tempAsc = tempChar.charCodeAt(0);
                tempLen = tempAsc.toString().length;

                if (tempLen == 1) {
                    tempAsc = "00" + tempAsc.toString();
                } else if (tempLen == 2) {
                    tempAsc = "0" + tempAsc.toString();
                }

                newData = newData + tempAsc.toString();
            }

            return newData;
        }
    </script>
    <style type="text/css">
        .tdpadding12
        {
            text-align: center;
        }
        .rbl input[type="radio"]
        {
            margin-left: 5px;
            margin-right: 1px;
        }
        select
        {
            height: 35px;
            border-radius: 5px;
        }
        .headfont
        {
            color: White !important;
        }
        .overlay
        {
            position: fixed;
            top: 0;
            bottom: 0;
            left: 0;
            right: 0;
            background: rgba(0, 0, 0, 0.7);
            transition: opacity 500ms;
            visibility: hidden;
            opacity: 0;
        }
        .overlay:target
        {
            visibility: visible;
            opacity: 1;
        }
        
        .popup
        {
            margin: 70px auto;
            padding: 20px;
            background: #fff;
            border-radius: 5px;
            width: 30%;
            position: relative;
            transition: all 5s ease-in-out;
        }
        
        .popup h2
        {
            margin-top: 0;
            color: #0078C0;
            font-family: Tahoma, Arial, sans-serif;
        }
        .popup .close
        {
            position: absolute;
            top: 20px;
            right: 30px;
            transition: all 200ms;
            font-size: 30px;
            font-weight: bold;
            text-decoration: none;
            color: #333;
        }
        .popup .close:hover
        {
            color: #06D85F;
        }
        .popup .content
        {
            max-height: 30%;
            overflow: auto;
            text-align: justify;
        }
        
        @media screen and (max-width: 700px)
        {
            .box
            {
                width: 70%;
            }
            .popup
            {
                width: 70%;
            }
        }
        body
        {
            font-family: "Helvetica Neue" , Helvetica, Arial, sans-serif;
            font-size: 14px;
            line-height: 1.428571429;
            color: black;
            background-size: cover;
            height: 100vh;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="popup1" class="overlay">
        <div class="popup">
            <h2>
                Password Policy</h2>
            <a class="close" href="#">&times;</a>
            <div class="content">
                <ul>
                    <li>Password contain minium 8 characters. </li>
                    <li>Password contain maximum 20 characters. </li>
                    <li>Password should contain atleast 1 alphabet(A-Z or a-z), 1 number (0-9) and 1 special
                        character(!@#$%^&amp;*?). </li>
                    <li>Password should not contains username or blank space.</li>
                </ul>
            </div>
        </div>
    </div>
    <table id="tbl_main" runat="server" style="width: 970px;" cellspacing="0" cellpadding="0"
        align="center" border="0">
        <tr>
            <td valign="middle" align="center" colspan="5" class="MenuHead" style="width: 850px;
                height: 20px;" bgcolor="#ffffff">
                &nbsp;&nbsp;<asp:Label ID="lblchk" runat="server" CssClass="ErrLbl" ForeColor="red"></asp:Label>
            </td>
        </tr>
        <tr id="tr_first" runat="server">
            <td style="width: 970px; height: 20px;" valign="middle" align="center" colspan="2">
                <table id="Table1" runat="server" style="width: 880px; border: Solid thin #cccccc;
                    border-collapse: separate;" cellspacing="1" cellpadding="0" border="0">
                    <tr>
                        <td valign="middle" align="center" colspan="10" class="MenuHead" style="width: 850px;
                            height: 30px; font-weight: bold;" bgcolor="#1E3A8E">
                            &nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="" CssClass="GridHead" ForeColor="#FFFFFF">Search User</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <asp:Label ID="lblSrchErr" runat="server" Text="" CssClass="GridHead" ForeColor="#FFFFFF"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 45px;" valign="middle" align="left">
                        </td>
                        <td style="width: 90px; height: 45px;" valign="middle" align="left" class="label2">
                            Name :
                        </td>
                        <td style="width: 186px; height: 45px;" valign="middle" align="left">
                            <asp:TextBox ID="txtNameSrch" runat="server" CssClass="form-control" Width="175px"
                                EnableViewState="False" MaxLength="50"></asp:TextBox>
                        </td>
                        <td style="width: 15px; height: 45px;" valign="middle" align="left">
                        </td>
                        <td style="width: 90px; height: 45px;" valign="middle" align="left" class="label2">
                            Email :&nbsp;
                        </td>
                        <td style="width: 186px; height: 45px;" valign="middle" align="left">
                            <asp:TextBox ID="txtEmailSrch" runat="server" CssClass="form-control" Width="175px"
                                EnableViewState="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15px; height: 45px;" valign="middle" align="left">
                        </td>
                        <td style="width: 100px; height: 45px;" valign="middle" align="left" class="label2">
                            Username :
                        </td>
                        <td style="width: 186px; height: 45px;" valign="middle" align="left">
                            <asp:TextBox ID="txtUnmSrch" runat="server" CssClass="form-control" Width="175px"
                                EnableViewState="False"></asp:TextBox>
                        </td>
                        <td style="width: 15px; height: 45px;" valign="middle" align="left">
                        </td>
                        <td style="width: 90px; height: 45px;" valign="middle" align="left" class="label2">
                            &nbsp;Staff No. :
                        </td>
                        <td style="width: 186px; height: 45px;" valign="middle" align="left">
                            <asp:TextBox ID="txtStaffNum" runat="server" CssClass="form-control" Width="175px"
                                EnableViewState="False" MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 45px;" valign="middle" align="left">
                        </td>
                        <td runat="server" id="priviledge" style="width: 90px; height: 45px;" valign="middle"
                            align="left" class="label2">
                            Privilege :
                        </td>
                        <td runat="server" id="priviledge1" style="width: 186px; height: 45px;" valign="middle"
                            align="left">
                            <%--<asp:RadioButtonList ID="rdbPrivSrch" runat="server" CssClass="label2" AutoPostBack="false"
                                RepeatDirection="Horizontal" Width="115px" CellPadding="0" CellSpacing="0" EnableViewState="False">
                                <asp:ListItem Value="Admin" >Admin</asp:ListItem>
                                <asp:ListItem Value="Maker">Maker</asp:ListItem>
                                <asp:ListItem Value="Checker">Checker</asp:ListItem>
                            </asp:RadioButtonList>--%>
                            <asp:CheckBox ID="chksrch1" runat="server" Text="Maker" CssClass="textbox" AutoPostBack="True" />
                            &nbsp;
                            <asp:CheckBox ID="chksrch2" runat="server" Text="Checker" CssClass="textbox" AutoPostBack="True" />
                            &nbsp;
                            <asp:CheckBox ID="chksrch3" runat="server" Text="Both" CssClass="textbox" AutoPostBack="True" />
                        </td>
                        <td runat="server" id="priviledge2" style="width: 15px; height: 45px;" valign="middle"
                            align="left">
                        </td>
                        <td style="width: 90px; height: 45px;" valign="middle" align="left" class="label2">
                            Active :
                        </td>
                        <td style="width: 15px; height: 45px;" valign="middle" align="left">
                            <%--<asp:RadioButtonList ID="rdbActSrch" runat="server" CssClass="label2" AutoPostBack="false"
                                RepeatDirection="Horizontal" Width="199px" CellPadding="0" CellSpacing="0" EnableViewState="False">
                               
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N">No</asp:ListItem>
                            </asp:RadioButtonList>--%>
                            <asp:RadioButton ID="rbtsrch1" runat="server" GroupName="site" Text="Yes" CssClass="textbox"
                                AutoPostBack="True" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtsrch2" runat="server" GroupName="site" Text="No" CssClass="textbox"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 45px;" valign="middle" align="center" class="label2" colspan="6">
                            <asp:Button ID="btnSrch" runat="server" Text="Search" ForeColor="white" BackColor="#c6007f"
                                Width="80px" Height="35px" onclick="btnSrch_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnReset" runat="server" Text="Reset" ForeColor="white" BackColor="#c6007f"
                                Width="80px" Height="35px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 970px; height: 20px;" valign="middle" align="left">
                &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkAddNew" runat="server" Text="Add New User"
                    Font-Names="Verdana" Font-Size="8pt" Font-Bold="true" ForeColor="#1B4A77" OnClick="lnkAddNew_Click"></asp:LinkButton>
            </td>
        </tr>
        <tr id="Tr_AddNew" runat="server">
            <td style="width: 970px; height: 20px;" valign="middle" align="center" colspan="2">
                <table id="Table2" runat="server" style="width: 850px; border: Solid thin #cccccc"
                    cellspacing="1" cellpadding="0" border="0">
                    <tr>
                        <td valign="middle" align="center" colspan="5" class="MenuHead" style="width: 850px;
                            height: 30px; font-weight: bold;" bgcolor="#1E3A8E">
                            &nbsp;&nbsp;<asp:Label ID="lblAddMainHead" runat="server" Text="" CssClass="GridHead"
                                ForeColor="#FFFFFF">Add New User</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 850px; height: 45px;" valign="middle" align="center" colspan="5">
                            <table id="tbl_AddMain" runat="server" style="width: 100%;" cellspacing="0" cellpadding="0"
                                border="0">
                                <tr id="tr_PersDtls" runat="server">
                                    <td style="width: 100%; height: 45px;" valign="middle" align="left">
                                        <!--''''''''''''''''''''''''   Main Dtls'''''''''''''''''''''''''''''''-->
                                        <table id="Table3" runat="server" style="width: 790px;" cellspacing="0" cellpadding="0"
                                            border="0">
                                            <tr>
                                                <td style="width: 150px; height: 45px;" valign="middle" align="left">
                                                </td>
                                                <td style="width: 190px; height: 45px;" valign="middle" align="left">
                                                    <asp:Label ID="Label5" runat="server" CssClass="label2" Text="Name :"></asp:Label>
                                                </td>
                                                <td style="width: 250px; height: 45px;" valign="middle" align="left">
                                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Width="250px" EnableViewState="false"></asp:TextBox>
                                                </td>
                                                <td style="width: 25px; height: 45px;" valign="middle" align="left">
                                                </td>
                                                <td style="width: 190px; height: 45px;" valign="middle" align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="label2" Text="Staff No. :"></asp:Label>
                                                </td>
                                                <td style="width: 250px; height: 45px;" valign="middle" align="left">
                                                    <asp:TextBox ID="txtStaffNo" runat="server" CssClass="form-control" Width="250px"
                                                        MaxLength="20" EnableViewState="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 10px; height: 45px;" valign="middle" align="left">
                                                </td>
                                                <td style="width: 190px; height: 45px;" valign="middle" align="left">
                                                    <asp:Label ID="Label8" runat="server" CssClass="label2" Text="Mobile No. :"></asp:Label>
                                                </td>
                                                <td style="width: 250px; height: 45px;" valign="middle" align="left">
                                                    <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" Width="250px"
                                                        EnableViewState="false"></asp:TextBox>
                                                </td>
                                                <td style="width: 25px; height: 45px;" valign="middle" align="left">
                                                </td>
                                                <td style="width: 190px; height: 45px;" valign="middle" align="left">
                                                    <asp:Label ID="Label7" runat="server" CssClass="label2" Text="Email :"></asp:Label>
                                                </td>
                                                <td style="width: 250px; height: 45px;" valign="middle" align="left">
                                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Width="250px" EnableViewState="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 10px; height: 45px;" valign="middle" align="left">
                                                </td>
                                                <td style="width: 150px; height: 21px; text-align: left">
                                                    <asp:Label ID="Label17" runat="server" Text="Privilege :"></asp:Label>&nbsp;&nbsp;&nbsp;
                                                </td>
                                                <td style="width: 350px; height: 21px; text-align: left">
                                                    <asp:RadioButtonList ID="RblPrivilege" runat="server" RepeatDirection="Horizontal"
                                                        OnSelectedIndexChanged="RblPrivilege_SelectedIndexChanged">
                                                        <asp:ListItem>Maker</asp:ListItem>
                                                        <asp:ListItem>Checker</asp:ListItem>
                                                        <asp:ListItem>Both</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td style="width: 25px; height: 45px;" valign="middle" align="left">
                                                </td>
                                                <td style="width: 100px; height: 45px;" valign="middle" align="left">
                                                    <asp:Label ID="Label14" runat="server" CssClass="label2" Text="Active :"></asp:Label>
                                                </td>
                                                <td style="width: 220px; height: 45px;" valign="middle" align="left" class="label2">
                                                    <asp:RadioButton ID="RBYes" runat="server" GroupName="site" Text="Yes" CssClass="textbox"
                                                        AutoPostBack="True" />
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:RadioButton ID="RBNo" runat="server" GroupName="site" Text="No" CssClass="textbox"
                                                        AutoPostBack="True" />
                                                </td>
                                            </tr>
                                        </table>
                                        <!--'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''-->
                                    </td>
                                </tr>
                                <tr id="tr_LogDtls" runat="server">
                                    <td style="width: 100%; height: 45px;" valign="middle" align="left">
                                        <!--''''''''''''''''''''  log dtls '''''''''''''''''''''''''-->
                                        <table id="Table4" runat="server" style="width: 790px;" cellspacing="0" cellpadding="0"
                                            border="0">
                                            <tr id="tr_UnmAdd">
                                                <td style="width: 80px; height: 45px;" valign="middle" align="left">
                                                </td>
                                                <td style="width: 190px !important; height: 45px;" valign="middle" align="left">
                                                    <asp:Label ID="Label11" runat="server" CssClass="label2" Text="Username :"></asp:Label>
                                                </td>
                                                <td style="width: 250px; height: 45px;" valign="middle" align="left">
                                                    <asp:TextBox ID="txtUserID" runat="server" CssClass="form-control" Width="250px"
                                                        MaxLength="20" AutoComplete="new-password"></asp:TextBox>
                                                </td>
                                                <td style="width: 25px; height: 45px;" valign="middle" align="left">
                                                </td>
                                                <td style="width: 100px; height: 45px;" valign="middle" align="left">
                                                </td>
                                                <td style="width: 220px; height: 45px;" valign="middle" align="left" class="label2">
                                                </td>
                                            </tr>
                                            <tr id="tr_CnfPwdAdd">
                                                <td style="width: 10px; height: 45px;" valign="middle" align="left">
                                                </td>
                                                <td style="width: 190px; height: 45px;" valign="middle" align="left">
                                                    <asp:Label ID="Label12" runat="server" CssClass="label2" Text="Password :"></asp:Label>
                                                </td>
                                                <td style="width: 250px; height: 45px;" valign="middle" align="left">
                                                    <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" CssClass="form-control"
                                                        Width="250px" EnableViewState="false" MaxLength="20"></asp:TextBox>
                                                    <a class="" href="#popup1">Password Policy</a>
                                                </td>
                                                <td style="width: 25px; height: 45px;" valign="middle" align="left">
                                                </td>
                                                <td style="width: 190px; height: 45px;" valign="middle" align="left">
                                                    <asp:Label ID="Label13" runat="server" CssClass="label2" Text="Confirm Password:"></asp:Label>
                                                </td>
                                                <td style="width: 250px; height: 45px;" valign="middle" align="left">
                                                    <asp:TextBox ID="txtConfPwd" runat="server" TextMode="Password" CssClass="form-control"
                                                        Width="250px" EnableViewState="false" MaxLength="20"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        <!--''''''''''''''''''''''''''''''''''''''''''''''''''''''''-->
                                    </td>
                                </tr>
                                <tr id="tr_Moduledetls" runat="server">
                                    <td style="width: 675px; height: 45px;" valign="middle" align="left">
                                        <table id="Table5" runat="server" style="width: 845px;" cellspacing="0" cellpadding="0"
                                            border="0">
                                            <tr id="tr1">
                                                <td style="width: 10px; height: 45px;" valign="middle" align="left">
                                                </td>
                                                <td style="width: 80px; height: 45px; padding-left: 26px;" valign="middle" align="left">
                                                    <asp:Label ID="lblModHead" runat="server" CssClass="label2" Text="Module :"></asp:Label>
                                                </td>
                                                <td style="width: 760px; height: 45px; padding-left: 38px;" valign="middle" align="left">
                                                    <asp:CheckBox ID="chkall" runat="server" Text=" All Module" CssClass="textbox" AutoPostBack="True"
                                                        OnCheckedChanged="chkall_CheckedChanged" />
                                                    <asp:DataGrid ID="dg_modules" Width="500px" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                        GridLines="None" CellSpacing="2" CellPadding="3">
                                                        <HeaderStyle BackColor="#1E3A8E" Height="25px" HorizontalAlign="Center" CssClass=""
                                                            ForeColor="#FFFFFF" VerticalAlign="Middle" />
                                                        <ItemStyle Height="20px" BackColor="#F3F3F3" HorizontalAlign="Left" VerticalAlign="Top"
                                                            CssClass="label2" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="mod_id" HeaderText="Module ID" Visible="False"></asp:BoundColumn>
                                                            <asp:TemplateColumn HeaderText="Sr.No.">
                                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                <HeaderStyle Width="50px" />
                                                                <ItemTemplate>
                                                                    <%#(dg_modules.PageSize * dg_modules.CurrentPageIndex) + Container.ItemIndex + 1%>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Allot">
                                                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                                <HeaderStyle Width="100px" />
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkAllot" runat="server" CssClass="label2"></asp:CheckBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:BoundColumn DataField="mod_nm" HeaderText="Module Name">
                                                                <ItemStyle Width="350px" />
                                                                <HeaderStyle Width="350px" />
                                                            </asp:BoundColumn>
                                                        </Columns>
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="10px">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <%-- <tr>
                        <td style="width: 850px; height: 45px;" valign="middle" align="center" colspan="5">
                            
                        </td>
                    </tr>--%>
                    <tr>
                        <td style="width: 850px; height: 45px;" valign="middle" align="center" colspan="5">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" ForeColor="white" BackColor="#c6007f"
                                Width="80px" Height="35px" onclick="btnAdd_Click" />
                            <asp:Button ID="btnupdate" runat="server" Text="Update" ForeColor="white" BackColor="#c6007f"
                                Width="80px" Visible="false" Height="35px" onclick="btnupdate_Click" />
                            &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" ForeColor="white" BackColor="#c6007f"
                                Width="80px" Height="35px" onclick="btnCancel_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td height="10px">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 970px; height: 20px;" valign="middle" align="center">
                <asp:Label ID="lblmsg" runat="server" CssClass="ErrLbl" ForeColor="red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 970px; height: 45px;" valign="middle" align="center">
                <asp:DataGrid ID="dg_Usr" Width="950px" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CellSpacing="3" CellPadding="3" BorderColor="White" PageSize="10" BorderStyle="Solid"
                    BorderWidth="5px" OnItemCommand="dg_Usr_ItemCommand" OnItemDataBound="dg_Usr_ItemDataBound">
                    <HeaderStyle BackColor="#1E3A8E" Height="25px" HorizontalAlign="Center" CssClass="headfont"
                        VerticalAlign="Middle" />
                    <PagerStyle CssClass="GridHead2" HorizontalAlign="Center" Mode="NumericPages" VerticalAlign="Bottom"
                        Font-Names="Times New Roman" Font-Size="12pt" />
                    <ItemStyle Height="20px" BackColor="#F3F3F3" HorizontalAlign="Left" VerticalAlign="Top"
                        CssClass="label2" />
                    <AlternatingItemStyle BackColor="White" />
                    <Columns>
                        <%--      ------------------------------0-----------------------------%>
                        <asp:BoundColumn DataField="officer_id" HeaderText="Log ID" Visible="False"></asp:BoundColumn>
                        <%--     ------------------------------1-------------------------------%>
                        <asp:TemplateColumn HeaderText="Sr.No.">
                            <ItemStyle HorizontalAlign="Center" Width="50px" VerticalAlign="Middle" />
                            <HeaderStyle Width="50px" />
                            <ItemTemplate>
                                <%#(dg_Usr.PageSize * dg_Usr.CurrentPageIndex) + Container.ItemIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <%--     ------------------------------2-------------------------------%>
                        <asp:BoundColumn HeaderText="Name" DataField="officer_name">
                            <HeaderStyle Width="150px" HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="left" Width="150px" />
                        </asp:BoundColumn>
                        <%--     ------------------------------3-------------------------------%>
                        <asp:BoundColumn HeaderText="Staff No." DataField="officer_staffNo" Visible="false">
                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="center" Width="100px" VerticalAlign="Middle" />
                        </asp:BoundColumn>
                        <%--     ------------------------------4-------------------------------%>
                        <asp:BoundColumn HeaderText="Details" DataField="">
                            <HeaderStyle Width="200px" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                        </asp:BoundColumn>
                        <%--     ------------------------------5-------------------------------%>
                        <asp:BoundColumn HeaderText="Department" DataField="" Visible="false">
                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <%--     ------------------------------6-------------------------------%>
                        <asp:BoundColumn HeaderText="Privilege" DataField="officer_privilege" Visible="false">
                            <HeaderStyle Width="60px" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="center" Width="60px" />
                        </asp:BoundColumn>
                        <%--     ------------------------------7-------------------------------%>
                        <asp:BoundColumn HeaderText="User Id" DataField="officer_uid" Visible="false">
                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="center" Width="100px" />
                        </asp:BoundColumn>
                        <%--     ------------------------------8-------------------------------%>
                        <asp:TemplateColumn HeaderText="Log Details">
                            <HeaderStyle Width="200px" />
                            <ItemStyle HorizontalAlign="Center" Width="65px" />
                            <ItemTemplate>
                                <asp:Label ID="lblUsrLogDtls" runat="server" Text="" CssClass="label2"></asp:Label><br />
                                <asp:LinkButton ID="lnkUsrLogEdit" runat="server" CssClass="label2" CommandName="UsrLogEdit"
                                    ForeColor="Blue">Edit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <%--     ------------------------------9-------------------------------%>
                        <asp:TemplateColumn HeaderText="Modules">
                            <HeaderStyle Width="115px" />
                            <ItemStyle HorizontalAlign="Center" Width="115px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkAuth" runat="server" CssClass="label2" CommandName="UsrAuth"
                                    ForeColor="Blue">View Auth</asp:LinkButton><br />
                                <asp:LinkButton ID="lnkAuthChk" runat="server" CssClass="label2" CommandName="UsrAuthChk"
                                    Visible="false"></asp:LinkButton><br />
                                <asp:LinkButton ID="lnkPageRights" runat="server" CssClass="label2" CommandName="UsrPgRight"
                                    ForeColor="Blue">Page Rights</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <%--     ------------------------------10-------------------------------%>
                        <asp:TemplateColumn HeaderText="Action">
                            <HeaderStyle Width="130px" />
                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" CssClass="label2" CommandName="UsrEdit"
                                    ForeColor="Blue">Edit</asp:LinkButton>&nbsp;|&nbsp;<asp:LinkButton ID="lnkDelete"
                                        runat="server" CssClass="label2" CommandName="UsrDelete" ForeColor="Blue">Delete
                                    </asp:LinkButton>&nbsp;|&nbsp;<asp:LinkButton ID="lnkCheck" runat="server" CssClass="label2"
                                        CommandName="UsrCheck" ForeColor="Blue">Check</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <%--     ------------------------------11-------------------------------%>
                        <asp:BoundColumn DataField="officer_name" HeaderText="Name" Visible="False"></asp:BoundColumn>
                        <%--     ------------------------------12-------------------------------%>
                        <asp:BoundColumn DataField="officer_email" HeaderText="Email" Visible="False"></asp:BoundColumn>
                        <%--  <asp:BoundColumn DataField="usr_type" HeaderText="User Type" Visible="False"></asp:BoundColumn>--%>
                        <%--     ------------------------------13-------------------------------%>
                        <asp:BoundColumn DataField="" HeaderText="Sub Dept Id" Visible="False"></asp:BoundColumn>
                        <%--     ------------------------------14-------------------------------%>
                        <asp:BoundColumn DataField="officer_uid" HeaderText="Unm" Visible="False"></asp:BoundColumn>
                        <%--     ------------------------------15-------------------------------%>
                        <asp:BoundColumn DataField="officer_privilege" HeaderText="Previlege" Visible="False">
                        </asp:BoundColumn>
                        <%--     ------------------------------16-------------------------------%>
                        <asp:BoundColumn DataField="officer_active" HeaderText="Active" Visible="False">
                        </asp:BoundColumn>
                        <%--     ------------------------------17-------------------------------%>
                        <asp:BoundColumn DataField="checked1" HeaderText="Checked" Visible="False"></asp:BoundColumn>
                        <%--     ------------------------------18-------------------------------%>
                        <asp:BoundColumn DataField="" HeaderText="Module Auth Check" Visible="False"></asp:BoundColumn>
                        <%--     ------------------------------19-------------------------------%>
                        <asp:BoundColumn DataField="" HeaderText="Sub Dept Name" Visible="False"></asp:BoundColumn>
                        <%--     ------------------------------20-------------------------------%>
                        <asp:BoundColumn DataField="" HeaderText="Main Dept Id" Visible="False"></asp:BoundColumn>
                        <%--  <asp:BoundColumn DataField="staffnum" HeaderText="Staff Id" Visible="False"></asp:BoundColumn>--%>
                        <%--     ------------------------------21-------------------------------%>
                        <asp:BoundColumn DataField="" HeaderText="" Visible="False"></asp:BoundColumn>
                        <%--     ------------------------------22-------------------------------%>
                        <asp:BoundColumn DataField="" HeaderText="" Visible="False"></asp:BoundColumn>
                        <%--     ------------------------------23-------------------------------%>
                        <asp:BoundColumn DataField="" HeaderText="" Visible="False"></asp:BoundColumn>
                        <%--     ------------------------------24-------------------------------%>
                        <asp:BoundColumn DataField="" HeaderText="" Visible="False"></asp:BoundColumn>
                        <%--     ------------------------------25-------------------------------%>
                        <asp:BoundColumn DataField="" HeaderText="" Visible="False"></asp:BoundColumn>
                    </Columns>
                </asp:DataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
