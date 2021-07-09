<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SaleNOtice.aspx.cs" Inherits="tmbadm_SaleNOtice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="row">
            <div>
                Sale Notice Title
            </div>
            <div>
                <asp:TextBox ID="Title" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div>
                Branch Name
            </div>
            <div>
                <asp:TextBox ID="Branch" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div>
                File Name
            </div>
            <div>
                <asp:TextBox ID="FileName" runat="server" PlaceHolder="p+yyyymmdd+.pdf"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div>
                Notice Date
            </div>
            <div>
                <asp:TextBox ID="NoticeDate" runat="server" PlaceHolder="YYYY-MM-DD"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div>
                <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />
                <asp:Button ID="Reset" runat="server" Text="Reset" OnClick="Reset_Click" />
            </div>
        </div>
        <asp:Label ID="Message" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
