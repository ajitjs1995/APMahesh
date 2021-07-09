<%@ Page Title="" Language="C#" MasterPageFile="~/tmbadm/AdmMaster.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="tmbadm_ChangePassword" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="797px" align="center" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td width="797px" height="250px" valign="middle" align="center" class="label3">
                <table id="Table2" style="width: 57%; border: solid thin #cccccc;" cellspacing="0"
                    cellpadding="2" align="center" border="0">
                    <tr>
                        <td colspan="5" class="bgcolor" align="center" style="padding-left: 10px; height: 25px;">
                            <asp:Label ID="Label1" runat="server" Text="Change Password" CssClass="header"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="left" style="padding-left: 10px;">
                            <asp:Label ID="lblmsg" runat="server" CssClass="ErrLbl"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" style="width: 2%; height: 40px;">
                        </td>
                        <td style="width: 44%;font-size:14px; height: 26px;" align="left" class="label2">
                            Username :
                        </td>
                        <td style="width: 54%; height: 26px" align="left">
                            <span style="font-weight: bold">
                            <asp:Label ID="txtlogin" runat="server" CssClass="label2"></asp:Label></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle" style="height: 40px;" class="ErrLbl">
                          
                        </td>
                        <td style="width: 110px; font-size:14px;height: 30px;" align="left">
                            Old Password :
                        </td>
                        <td align="left" style="height: 29px">
                            <asp:TextBox ID="txtOldpassword" runat="server" TextMode="Password" Width="200px" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle" style="height: 40px;" class="ErrLbl">
                        
                        </td>
                        <td align="left" style="font-size:14px;">
                            New Password :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtNewpassword" runat="server" TextMode="Password" Width="200px" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle" style="height: 40px;">
                           
                        </td>
                        <td align="left" style="font-size:14px;">
                            Confirm Password :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtConfpassword" runat="server" TextMode="Password" Width="200px" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle" style="height: 40px;">
                            
                        </td>
                        <td align="left" valign="middle" style="font-size:14px;">
                            Enter the code shown below :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtcaptcha" runat="server" CssClass="form-control" Width="200px" MaxLength="6"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top" style="height: 40px;">
                           
                        </td>
                        <td align="left" valign="top">
                         
                        </td>
                        <td align="left">
                            <cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="6"
                                CaptchaHeight="31" CaptchaWidth="150" CaptchaLineNoise="None" CaptchaMinTimeout="5"
                                CaptchaMaxTimeout="240" Height="31px" Width="150px" BorderColor="#E7E4D3" BackColor="#E7E4D3"
                                BorderStyle="Solid" BorderWidth="1px" Font-Italic="true" ForeColor="#7A6802" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3" height="40px" valign="middle">
                            <asp:Button ID="btnChngPwd" runat="server" Text="Change Password" CssClass="btn7"
                                Width="140px" OnClick="btnChngPwd_Click" />&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Reset" CssClass="btn7" 
                                Width="60px" onclick="btnCancel_Click"
                              />
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <table align="center" cellpadding="6" cellspacing="1" border="1px" style="border-color: black">
                    <tbody>
                        <tr>
                            <td align="center" class="bgcolor" style="color:White; font-size:16px;">
                                Password Policy
                            </td>
                        </tr>
                        <tr align="center">
                            <td align="left" style="color: Navy; font-size:14px;">
                                <ol style="margin-left:27px;">
                                    <li>Password contain minium 8 charachters.</li>
                                    <br>
                                    <li>Password contain maximum 20 charachters.</li>
                                    <br>
                                    <li>Password should contain atleast 1 alphabet (A-Z or a-z), 1 number (0-9) and 1 special
                                        character (!@#$%^&amp;*?).</li>
                                    <br>
                                    <li>Password should not contains username or blank space.</li>
                                </ol>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

