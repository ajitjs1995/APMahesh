<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mail-demo.aspx.cs" Inherits="mail_demo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div>    
         <asp:Label ID="errormsg" runat="server" ForeColor="Red" Font-Names="Calibri" Font-Size="12px"></asp:Label>    <br />
         
         <asp:TextBox ID="txtemail" runat="server" Width="242px"></asp:TextBox>&nbsp;&nbsp;
           
         <asp:Button ID="Button1" runat="server" Text="Click here to send mail" 
             BackColor="#009933" Font-Names="Calibri" Font-Size="12px" 
            ForeColor="White" onclick="Button1_Click1" />
           
    </div>
    </form>
</body>
</html>
