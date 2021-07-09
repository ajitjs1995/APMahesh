<%@ Control Language="C#" AutoEventWireup="true" CodeFile="pgnritamil.ascx.cs" Inherits="Tamil_pgnritamil" %>
<%@ Register Src="~/tamil/toptamilcntrl.ascx" TagPrefix="uc" TagName="Toptamilcntrl" %>
<%@ Register Src="~/innerpagebannercntrl.ascx" TagPrefix="uc" TagName="InnerPageBannercntrl" %>
<%@ Register Src="~/tamil/youareheretamilcntrl.ascx" TagPrefix="uc" TagName="YouAreHeretamilcntrl" %>
<%@ Register Src="~/menucntrl.ascx" TagPrefix="uc" TagName="Menucntrl" %>
<%@ Register Src="~/getcontent.ascx" TagPrefix="uc" TagName="Getcontent" %>
<%@ Register Src="~/tamil/bottomtamilcntrl.ascx" TagPrefix="uc" TagName="Bottomtamilcntrl" %>
<%--TOP CONTROLLER--%>
<uc:Toptamilcntrl runat="server" ID="ucToptamilcntrl" />
<%--TOP CONTROLLER--%>
<%--INNERPAGEBANNER CONTROLLER--%>
<uc:InnerPageBannercntrl runat="server" ID="ucInnerPageBannercntrl" />
<%--INNERPAGEBANNER CONTROLLER--%>
<%--YOUAREHERE CONTROLLER--%>
<uc:YouAreHeretamilcntrl runat="server" ID="ucYouAreHeretamilcntrl" />
<%--YOUAREHERE CONTROLLER--%>
<%--MENU CONTROLLER--%>
<uc:Menucntrl runat="server" ID="ucMenucntrl" />
<%--NENU CONTROLLER--%>
<%--CONTENT CONTROLLER--%>
<uc:Getcontent runat="server" ID="ucGetcontent" />
<%--CONTENT CONTROLLER--%>
<%--BOTTOM CONTROLLER--%>
<uc:Bottomtamilcntrl runat="server" ID="ucBottomtamilcntrl" />
<%--BOTTOM CONTROLLER--%>