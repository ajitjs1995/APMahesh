<%@ Page Language="C#" %>
<%@ Register Src="~/menucntrl.ascx" TagPrefix="uc" TagName="Menucntrl" %>
<%@ Register Src="~/tamil/pggeneraltamil.ascx" TagPrefix="uc" TagName="pggeneraltamil" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <uc:Menucntrl runat="server" ID="ucMenucntrl" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <uc:pggeneraltamil runat="server" ID="ucpggeneraltamil" />
    </div>
    </form>
</body>
</html>
