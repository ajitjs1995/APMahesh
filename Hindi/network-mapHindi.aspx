<%@ Page Language="C#" %>
<%@ Register Src="~/metadata.ascx" TagPrefix="uc" TagName="MetaData" %>
<%@ Register Src="~/hindi/pggeneralhindi.ascx" TagPrefix="uc" TagName="pggeneralhindi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <uc:MetaData runat="server" ID="ucMetaData" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <uc:pggeneralhindi runat="server" ID="ucpggeneralhindi" />
    </div>
    </form>
</body>
</html>
