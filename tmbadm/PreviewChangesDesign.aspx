<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PreviewChangesDesign.aspx.cs" Inherits="Admin_PreviewChangesDesign" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/AdmLogin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <table width="620px" cellpadding="0" cellspacing="0" border="0" align="center" style="background-color:#FFFFFF;" >
            
            <tr>
                <td style="width :620px; height:7px" valign="top" align="left" colspan="3"></td>
            </tr> 
            <tr>
                <td style="width :10px;" valign="top" align="left"></td> 
                <td style="width :600px;" valign="top" align="left">
                    <asp:label id="lblContentDesign" runat="server" CssClass="CmsContentData"></asp:label>
                </td>
                <td style="width :10px;" valign="top" align="left"></td> 
            </tr> 
            <tr>
                <td>
                    <div style="">

                        <asp:Button ID="btnback" runat="server" CssClass="bouton-contact" Text="Source" 
                        width="65px" style="height:25px; position:fixed; float:right; 
                        border-radius: 30px;left:90%; top:90%;padding:0;"
                        PostBackUrl="~/Admin/PreviewChangesDetails.aspx"/>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
