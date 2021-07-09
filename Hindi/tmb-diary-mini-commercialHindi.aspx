<%@ Page Language="C#" %>

<%@ Register Src="~/Hindi/pgagriculturehindi.ascx" TagPrefix="uc" TagName="pgagriculturehindi" %>
<%@ Register Src="~/metadata.ascx" TagPrefix="uc" TagName="MetaData" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <uc:MetaData runat="server" ID="ucMetaData" />
    <title>Tamilad Mercantile Bank Ltd</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc:pgagriculturehindi runat="server" ID="pgagriculturehindi" />
    </div>
    </form>
</body>
</html>