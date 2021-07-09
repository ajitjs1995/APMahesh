<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PreviewChangesDetails.aspx.cs" Inherits="Admin_PreviewChangesDetails" ValidateRequest = "false" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register TagPrefix="FckeditorV2" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="../ckeditor/ckeditor.js" type="text/javascript"></script>
     <style type="text/css">
    .cke_top
    {
        display: none !important;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center>
        <table style="height:40px; width:100%">
            <tr>
                <td style="width:20%;">
                    <asp:LinkButton ID="lnkDesign" runat="server" onclick="lnkDesign_Click">Code</asp:LinkButton>
                    <asp:LinkButton ID="lnkback" runat="server" onclick="lnkback_Click" >Back</asp:LinkButton>
                </td>
                <td style="width:60%;" align="center">
                    <asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Size="Large" 
                        ForeColor="Red"></asp:Label>
                </td>  
                <td style="width:20%;">
                </td> 
            </tr>
        </table>        
    </center>
    <center>
        <fckeditorv2:fckeditor id="editor2" runat="server" Height="400px" Width="90%"></fckeditorv2:fckeditor>

         <CKEditor:CKEditorControl ID="editor1" runat="server" Height="400px" Width="90%"></CKEditor:CKEditorControl>
    </center>
    </div>
    </form>
</body>
</html>
