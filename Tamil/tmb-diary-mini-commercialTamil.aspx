<%@ Page Language="C#" %>

<%@ Register Src="~/metadata.ascx" TagPrefix="uc" TagName="MetaData" %>
<%@ Register Src="~/pgagriculture.ascx" TagPrefix="uc" TagName="pgagriculture" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <uc:MetaData runat="server" ID="ucMetaData" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="icon" type="image/ico" href="images/tmb.ico" />
    <title>Tamilad Mercantile Bank Ltd - About Us</title>
</head>
<body oncontextmenu="return false" onselectstart="return false" ondragstart="return false">
    <form id="form1" runat="server">
    <div>
        <uc:pgagriculture runat="server" ID="pgagriculture" />
    </div>
    </form>
</body>
</html>
