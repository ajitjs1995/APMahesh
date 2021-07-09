<%@ Page Language="C#" %>

<%@ Register Src="~/metadata.ascx" TagPrefix="uc" TagName="MetaData" %>
<%@ Register Src="~/tamil/pgcontactustamil.ascx" TagPrefix="uc" TagName="pgcontactustamil" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <uc:MetaData runat="server" ID="ucMetaData" />
    <title>Tamilad Mercantile Bank Ltd</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc:pgcontactustamil runat="server" ID="ucpgcontactustamil" />
    </div>
    </form>
</body>
</html>
