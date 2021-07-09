<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="AdminOfficeDetails.aspx.cs" Inherits="Admin_Office_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title></title>
	
	<!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-157825538-1"></script>
<script>
    window.dataLayer = window.dataLayer || [];
    function gtag() { dataLayer.push(arguments); }
    gtag('js', new Date());

    gtag('config', 'UA-157825538-1');
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<br />
<div class="main-contentz">
                                        <div class="table-container">
<table id="Table2" style="width: 80%; border: solid thin #cccccc; border-color: #cccccc;"
            cellspacing="0" cellpadding="10" align="center" border="1px" class="label2">
       
              <tr height="50px">
               <td align="left" valign="middle" colspan="6" bgcolor="#1E3A8E"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                  <tr>
                    <td width="151"><div align="left"><img  src="/images/logosmall.png"/></div></td>
                    <td width="681"><div align="center"><asp:Label ID="Label2" runat="server" Font-Name="Open Sans,Sans-Serif;" Font-Size="16px" ForeColor="#FFFFFF" Text="Regional Office Address & Info"></asp:Label></div></td>
                  </tr>
                </table></td>
            </tr>
            <tr height="30px">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    <span style="color: Red;"></span>No :
                </td>
                <td align="left">
                    <asp:Label ID="lblNo" runat="server" style="font-size:14px;font-family:Open Sans,Sans-Serif;" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
           
            <tr height="30px">
                <td align="left" valign="middle" style="width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    <span style="color: Red;"></span>Name :
                </td>
                <td align="left">
                    <asp:Label ID="lblName" runat="server" style="font-size:14px;font-family:Open Sans,Sans-Serif;" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
            <tr height="30px">
                <td align="left" valign="middle" style="width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    <span style="color: Red;"></span>Address :
                </td>
                <td align="left">
                    <asp:Label ID="lblAdd" runat="server" Text="" style="font-size:14px;font-family:Open Sans,Sans-Serif;" CssClass="label2"></asp:Label>
                </td>
            </tr>
            <tr height="30px">
                <td align="left" valign="top" style="width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    <span style="color: Red;"></span>City :
                </td>
                <td align="left">
                    <asp:Label ID="lblCity" runat="server" Text="" style="font-size:14px;font-family:Open Sans,Sans-Serif;" CssClass="label2"></asp:Label>
                </td>
            </tr>
             <tr height="30px">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    <span style="color: Red;"></span>Pin / Zip Code :
                </td>
                <td align="left">
                    <asp:Label ID="lblpin" runat="server" Text="" style="font-size:14px;font-family:Open Sans,Sans-Serif;" CssClass="label2"></asp:Label>
                </td>
            </tr>
             <tr height="30px">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    <span style="color: Red;"></span>District / State :
                </td>
                <td align="left">
                    <asp:Label ID="lblstate" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
            <tr height="30px">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    <span style="color: Red;"></span>Country :
                </td>
                <td align="left">
                    <asp:Label ID="lblcountry" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>


            <tr height="30px">
                <td align="left" valign="top" style="width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;" colspan="2">
                    <strong>Contact Info (Country & Std Code)</strong>   
                </td>
               
            </tr>
            <tr height="30px">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    Code :
                </td>
                <td align="left">
                    <asp:Label ID="lblCode" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
            <tr height="30px">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;" colspan="2">
                 <strong> Contact Info (Phone)</strong>  
                </td>
               
            </tr>
              <tr height="30px">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;" colspan="2">
                   <asp:Label ID="lblContact" runat="server" Text="" CssClass="label2"></asp:Label>	
                </td>
               
            </tr>
             <tr height="30px" id="CTFax" runat="server">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;" colspan="2">
                 <strong> Contact Info (Fax)</strong>  
                </td>
               
            </tr>
              <tr height="30px" id="CTFax1" runat="server">
               <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    <span style="color: Red;"></span>Fax No :
                </td>
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                   <asp:Label ID="lblfaxno" runat="server" Text="" CssClass="label2"></asp:Label>	
                </td>
               
            </tr>
          
      </table>
      </div></div>
</asp:Content>

