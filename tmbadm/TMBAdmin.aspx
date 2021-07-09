<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TMBAdmin.aspx.cs" Inherits="Admin_LvAdmin"
    ValidateRequest="false" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE HTML>
<html lang="zxx">
<head>
    <title>TMB Bank | AdminLogin</title>
    <!-- Meta tag Keywords -->
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta charset="UTF-8" />
    <script type="text/javascript">
        debugger;
        function checkForm() {
            document.getElementById('<%=txtpassword.ClientID%>').value = encrypt(document.getElementById('<%=txtpassword.ClientID%>').value);

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
    <script>
        addEventListener("load", function () {
            setTimeout(hideURLbar, 0);
        }, false);

        function hideURLbar() {
            window.scrollTo(0, 1);
        }
    </script>
    <!-- Meta tag Keywords -->
    <!-- css files -->
    <link rel="stylesheet" href="css/style.css" type="text/css" media="all" />
    <!-- Style-CSS -->
    <link rel="stylesheet" href="css/fontawesome-all.css">
    <!-- Font-Awesome-Icons-CSS -->
    <!-- //css files -->
    <!-- web-fonts -->
    <link href="//fonts.googleapis.com/css?family=Marck+Script&amp;subset=cyrillic,latin-ext"
        rel="stylesheet">
    <link href="//fonts.googleapis.com/css?family=Montserrat:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i&amp;subset=cyrillic,latin-ext"
        rel="stylesheet">
    <!-- //web-fonts -->
</head>
<body style="background-image: url(video/1.png);">
    <%--<div class="video-w3l" data-vide-bg="video/1">--%>
    <div class="video-w3l">
        <div style="padding: 15px;">
            <img src="../images/tmb-logo.png" />
        </div>
        <!-- title -->
        <!-- //title -->
        <!-- content -->
        <div class="sub-main-w3">
            <form runat="server">
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
            <asp:Panel ID="Panel1" runat="server" DefaultButton="Button1">
                <asp:Label ID="lblmsg" runat="server" Text="" ForeColor="white"></asp:Label>
                <div class="form-style-agile">
                    <label>
                        <i class="fas fa-user"></i>Username</label>
                    <%--	<input placeholder="Username" name="Name" type="text" required="">--%>
                    <asp:TextBox ID="txtlogin" runat="server" placeholder="Username" TabIndex="1" autocomplete="New-Password"></asp:TextBox>
                </div>
                <div class="form-style-agile">
                    <label>
                        <i class="fas fa-unlock-alt"></i>Password</label>
                    <%--<input placeholder="Password" name="Password" type="password" required="">--%>
                    <asp:TextBox ID="txtpassword" runat="server" placeholder="Password" TabIndex="2"
                        type="Password" TextMode="Password" OnBlur="javascript:return checkForm();" autocomplete="New-Password"></asp:TextBox>
                </div>
                <label>
                    Captcha</label>
                <br />
                <div class="form-style-agile" style="display: inline-flex;">
                    <%--	<input placeholder="Username" name="Name" type="text" required="">--%>
                    <asp:TextBox ID="txtcaptcha" runat="server" MaxLength="6" placeholder="Captcha" TabIndex="3"
                        Style="width: 60% !important" autocomplete="New-Password" />
                    <cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="6"
                        CaptchaHeight="44" CaptchaWidth="180" CaptchaLineNoise="None" CaptchaMinTimeout="1"
                        CaptchaMaxTimeout="240" Height="44px" Width="180px" BorderColor="#E7E4D3" BackColor="#E7E4D3"
                        BorderStyle="Solid" BorderWidth="1px" Font-Italic="true" ForeColor="#7A6802" />
                    <asp:ImageButton ID="lnkRefreshCode0" runat="server" ImageUrl="../Images/Refresh.png"
                        ToolTip="Refresh Captcha" Height="43px" Width="46px" TabIndex="23" />
                </div>
                <!-- switch -->
                <div class="checkout-w3l">
                </div>
                <!-- //switch -->
                <%--	<input type="submit" value="Log In">--%>
                <asp:Button ID="Button1" runat="server" Text="Login" TabIndex="4"
                    OnClick="Button1_Click" />
                <!-- social icons -->
                <!-- //social icons -->
            </asp:Panel>
            </form>
        </div>
        <!-- //content -->
       
    </div>
    <!-- Jquery -->
    <script src="js/jquery-2.2.3.min.js"></script>
    <!-- //Jquery -->
    <!-- Video js -->
    <script src="js/jquery.vide.min.js"></script>
    <!-- //Video js -->
</body>
</html>
