<%@ Control Language="C#" AutoEventWireup="true" CodeFile="pgmsmehindi.ascx.cs" Inherits="Hindi_pgmsmehindi" %>
<%@ Register Src="~/hindi/tophindicntrl.ascx" TagPrefix="uc" TagName="Tophindicntrl" %>
<%@ Register Src="~/innerpagebannercntrl.ascx" TagPrefix="uc" TagName="InnerPageBannercntrl" %>
<%@ Register Src="~/hindi/youareherehindicntrl.ascx" TagPrefix="uc" TagName="YouAreHerehindicntrl" %>
<%@ Register Src="~/hindi/menuhindicntrl.ascx" TagPrefix="uc" TagName="Menuhindicntrl" %>
<%@ Register Src="~/getcontent.ascx" TagPrefix="uc" TagName="Getcontent" %>
<%@ Register Src="~/hindi/bottomhindicntrl.ascx" TagPrefix="uc" TagName="Bottomhindicntrl" %>
<%--TOP CONTROLLER--%>
<uc:Tophindicntrl runat="server" ID="ucTophindicntrl" />
<%--TOP CONTROLLER--%>
<%--INNERPAGEBANNER CONTROLLER--%>
<uc:InnerPageBannercntrl runat="server" ID="ucInnerPageBannercntrl" />
<%--INNERPAGEBANNER CONTROLLER--%>
<%--YOUAREHERE CONTROLLER--%>
<uc:YouAreHerehindicntrl runat="server" ID="ucYouAreHerehindicntrl" />
<%--YOUAREHERE CONTROLLER--%>
<%--MENU CONTROLLER--%>
<uc:Menuhindicntrl runat="server" ID="ucMenuhindicntrl" />
<%--MENU CONTROLLER--%>
<%--CONTENT CONTROLLER--%>
<uc:Getcontent runat="server" ID="ucGetcontent" />
<%--CONTENT CONTROLLER--%>
<%--BOTTOM CONTROLLER--%>
<uc:Bottomhindicntrl runat="server" ID="ucBottomhindicntrl" />
<%--BOTTOM CONTROLLER--%>