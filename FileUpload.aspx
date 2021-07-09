<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileUpload.aspx.cs" Inherits="FileUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
 <fieldset>
  <legend>TMB bank File Upload</legend>
     <asp:Label ID="lblMessage" runat="server" Text="Please select folder for uploading file" ForeColor="Red"></asp:Label>
        <br />
        <br />
     <asp:DropDownList ID="ddlfolders" runat="server">
         <asp:ListItem>-- Please select folder --</asp:ListItem>
         <asp:ListItem>doc</asp:ListItem>
         <asp:ListItem>forms</asp:ListItem>
         <asp:ListItem>images</asp:ListItem>
         <asp:ListItem>press</asp:ListItem>
     </asp:DropDownList>
        <br />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Upload File" OnClick="Button1_Click" />
 </fieldset>
    </div>
    </form>
</body>
</html>
