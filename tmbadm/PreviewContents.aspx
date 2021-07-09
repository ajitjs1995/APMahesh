<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PreviewContents.aspx.cs" Inherits="Admin_PreviewContents" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onunload="opener.location=('Manage_InnerPage.aspx')">
    <form id="form1" runat="server">
    <div>
         <table width="620px" cellpadding="0" cellspacing="0" border="0" align="center" style="background-color:#FFFFFF;" >
            
            <tr>
                <td style="width :620px; height:7px" valign="top" align="left" colspan="3"></td>
            </tr> 
            <tr>
                <td style="width :10px;" valign="top" align="left"></td> 
                <td style="width :600px;" valign="top" align="left">
                    <asp:label id="lblContent" runat="server" CssClass="CmsContentData"></asp:label>
                </td>
                <td style="width :10px;" valign="top" align="left"></td> 
            </tr> 
        </table>
    </div>
    </form>
</body>
</html>
