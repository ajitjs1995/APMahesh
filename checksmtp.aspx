<%@ Page ViewStateEncryptionMode="Always" Language="VB" AutoEventWireup="false" CodeFile="checksmtp.aspx.vb" Inherits="checksmtp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
	
	<!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-157825538-1"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());

  gtag('config', 'UA-157825538-1');
</script>
	
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" ForeColor="Red" runat="server" Font-Names="Calibri" 
            Font-Size="12px"></asp:Label></br>
        <asp:TextBox ID="txtemail" runat="server" Width="372px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Clich here to Send mail" 
            BackColor="#009933" Font-Names="Calibri" Font-Size="12px" 
            ForeColor="White" />       
    </div>
    </form>
</body>
</html>

