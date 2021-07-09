<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileUploadOnSite.aspx.cs" Inherits="Admin_FileUpload_Large_Size" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        <asp:DropDownList ID="FileType" runat="server" AutoPostBack="True" 
            onselectedindexchanged="FileType_SelectedIndexChanged">
            <asp:ListItem>Select File Folder</asp:ListItem>
            <asp:ListItem>css</asp:ListItem>
            <asp:ListItem>doc</asp:ListItem>
            <asp:ListItem>forms</asp:ListItem>
            <asp:ListItem>images</asp:ListItem>
            <asp:ListItem>InnerBanner</asp:ListItem>
            <asp:ListItem>press</asp:ListItem>
            <asp:ListItem>js</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="Location" runat="server" Text=""></asp:Label>
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <br />
        <asp:Button ID="btnupload" runat="server" Text="Upload" 
            onclick="btnupload_Click" />
        <br />
        <asp:Label ID="Result" runat="server" Text=""></asp:Label>
        <br />
    </div>
    </form>
</body>
</html>
