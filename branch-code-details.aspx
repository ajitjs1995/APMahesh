<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="branch-code-details.aspx.cs" Inherits="branch_code_detailed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<br />
<div class="main-contentz">
                                        <div class="table-container">
    <table id="Table2" style="width: 80%; border: solid thin #cccccc; border-color: #cccccc;"
            cellspacing="0" cellpadding="10" align="center" border="0" class="label2" >
       
              <tr height="50px">
               <td align="left" valign="middle" colspan="6" bgcolor="#1E3A8E"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                  <tr>
                    <td  width="151"><div align="left"><img  src="/images/logosmall.png"/></div></td>
                    <td width="681"><div align="center"><span style="color:White;">Address & Branch Info - </span><strong><asp:Label ID="Label2" runat="server" Font-Name="Open Sans,Sans-Serif;" Font-Size="14px" ForeColor="#FFFFFF"></asp:Label></strong> </div></td>
                  </tr>
                </table></td>
            </tr>
         <tr height="30px" style="background-color:#C90084; color:white;" >
                <td align="left" valign="middle" style=" width:40%;font-size:15px;font-family:Open Sans,Sans-Serif;">
                    <span style="color: Red;"></span><strong>Info</strong>
                </td>
                <td align="left" valign="middle" style=" width:40%;font-size:15px;font-family:Open Sans,Sans-Serif;">
                    <span style="color: Red;"></span><strong>Details</strong>
                </td>
            </tr>
            <tr height="30px">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    <span style="color: Red;"></span>Branch Code
                </td>
                <td align="left">
                    <asp:Label ID="lblBCode" runat="server" style="font-size:14px;font-family:Open Sans,Sans-Serif;" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
           
            <tr height="30px">
                <td align="left" valign="middle" style="width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    <span style="color: Red;"></span>Branch Type
                </td>
                <td align="left">
                    <asp:Label ID="lblBType" runat="server" style="font-size:14px;font-family:Open Sans,Sans-Serif;" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>

        <tr height="30px">
                <td align="left" valign="middle" style="width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    <span style="color: Red;"></span>Branch Name
                </td>
                <td align="left">
                    <asp:Label ID="lblBName" runat="server" style="font-size:14px;font-family:Open Sans,Sans-Serif;" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>

            <tr height="30px">
                <td align="left" valign="middle" style="width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    <span style="color: Red;"></span>Address
                </td>
                <td align="left">
                    <asp:Label ID="lblAdd" runat="server" Text="" style="font-size:14px;font-family:Open Sans,Sans-Serif;" CssClass="label2"></asp:Label>
                </td>
            </tr>
        <tr height="30px" runat="server" id="area">
                <td align="left" valign="middle" style="width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    <span style="color: Red;"></span>Area
                </td>
                <td align="left">
                    <asp:Label ID="lblArea" runat="server" Text="" style="font-size:14px;font-family:Open Sans,Sans-Serif;" CssClass="label2"></asp:Label>
                </td>
            </tr>
            <tr height="30px">
                <td align="left" valign="top" style="width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    <span style="color: Red;"></span>City
                </td>
                <td align="left">
                    <asp:Label ID="lblCity" runat="server" Text="" style="font-size:14px;font-family:Open Sans,Sans-Serif;" CssClass="label2"></asp:Label>
                </td>
            </tr>
             <tr height="30px">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    <span style="color: Red;"></span>Pin / Zip Code
                </td>
                <td align="left">
                    <asp:Label ID="lblpin" runat="server" Text="" style="font-size:14px;font-family:Open Sans,Sans-Serif;" CssClass="label2"></asp:Label>
                </td>
            </tr>
             <tr height="30px">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    <span style="color: Red;"></span>District / State
                </td>
                <td align="left">
                    <asp:Label ID="lblstate" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                    <asp:Label ID="lblDistrict" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
            <tr height="30px">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    <span style="color: Red;"></span>Country
                </td>
                <td align="left">
                    <asp:Label ID="lblcountry" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>


            <tr height="30px" style="background-color:#C90084; color:white;">
                <td align="left" valign="top" style="width:40%;font-size:15px;font-family:Open Sans,Sans-Serif;" colspan="2">
                    <strong>Services / Facilities / Products Offered</strong>   
                </td>
               
            </tr>
            <tr height="30px" runat="server" id="ForexService">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    Forex Services
                </td>
                <td align="left">
                    <asp:Label ID="lblForexService" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>

            <tr height="30px" runat="server" id="NRI">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    NRI Services
                </td>
                <td align="left">
                    <asp:Label ID="lblNRI" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>


            <tr height="30px" runat="server" id="micr">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                   MICR Code
                </td>
                <td align="left">
                    <asp:Label ID="lblMICR" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>

             <tr height="30px" runat="server" id="rtgs">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                   RTGS / IFSC Code
                </td>
                <td align="left">
                    <asp:Label ID="lblRTGS" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                &nbsp;<a href="rtgs-neft-micr-branch-codes.aspx" target="_blank">Click for RTGS / NEFT / MICR Codes</a> </td>
            </tr>





            <tr height="30px" style="background-color:#C90084; color:white;">
                <td align="left" valign="middle" style=" width:40%;font-size:15px;font-family:Open Sans,Sans-Serif;" colspan="2">
                 <strong> ATM / eLobby Center</strong>  
                </td>
               
            </tr>
             <tr height="30px" runat="server" id="ATMFac" >
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                  ATM Facility
                </td>
                <td align="left">
                    <asp:Label ID="lblatmfac" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                &nbsp; <a href="atm-centres.aspx" target="_blank">Click for ATM Details</a>  & <a href="eLobby-centres.aspx" target="_blank">Click for eLobby Details</a> </td>
            </tr>
        <tr height="30px" runat="server" id="asba">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                   ASBA Services
                </td>
                <td align="left">
                    <asp:Label ID="lblASBA" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
             <tr height="30px" runat="server" id="demat">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                   Demat Services
                </td>
                <td align="left">
                    <asp:Label ID="lblDemat" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
             <tr height="30px" runat="server" id="lckrfac">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                   Locker Facility
                </td>
                <td align="left">
                    <asp:Label ID="lblLocker" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
             
             <tr height="30px" runat="server" id="mutual">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                  Mutual Fund Services	
                </td>
                <td align="left">
                    <asp:Label ID="lblMutual" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
             <tr height="30px" runat="server" id="any">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                   Anywhere Banking
                </td>
                <td align="left">
                    <asp:Label ID="lblAny" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
             <tr height="30px" runat="server" id="ecs">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                   ECS Services
                </td>
                <td align="left">
                    <asp:Label ID="lblECS" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>



        <tr height="30px" id="CTFax" runat="server" style="background-color:#C90084; color:white;">
                <td align="left" valign="middle" style=" width:40%;font-size:15px;font-family:Open Sans,Sans-Serif;" colspan="2">
                 <strong> Contact Info (Country & Std Code)</strong>  
                </td>
               
            </tr>
        <tr height="30px" runat="server" id="Tr1">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                  Code
                </td>
                <td align="left">
                    <asp:Label ID="lblCode" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>

        <tr height="30px" id="Tr2" runat="server" style="background-color:#C90084; color:white;">
                <td align="left" valign="middle" style=" width:40%;font-size:15px;font-family:Open Sans,Sans-Serif;" colspan="2">
                 <strong>Contact Info (Phone)</strong>  
                </td>
               
            </tr>
        <tr height="30px" runat="server" id="bill">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                 Bill Section
                </td>
                <td align="left">
                    <asp:Label ID="lblBill" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>

         <tr height="30px" runat="server" id="Board">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                  Board
                </td>
                <td align="left">
                    <asp:Label ID="lblBoard" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
 <tr height="30px" runat="server" id="Board1">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                  Board
                </td>
                <td align="left">
                    <asp:Label ID="lblBoard1" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
 <tr height="30px" runat="server" id="Board2">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    Board
                </td>
                <td align="left">
                    <asp:Label ID="lblBoard2" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
 <tr height="30px" runat="server" id="cash">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                  Cash Section
                </td>
                <td align="left">
                    <asp:Label ID="lblCashSec" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
 <tr height="30px" runat="server" id="clear">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                  Clearing
                </td>
                <td align="left">
                    <asp:Label ID="lblClear" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
 <tr height="30px" runat="server" id="CTS">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                  CTS Clearing
                </td>
                <td align="left">
                    <asp:Label ID="lblCTS" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
 <tr height="30px" runat="server" id="crntAC">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                  Current A/C
                </td>
                <td align="left">
                    <asp:Label ID="lblcrntAC" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
 <tr height="30px" runat="server" id="Deposit">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                 Deposits
                </td>
                <td align="left">
                    <asp:Label ID="lblDeposit" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
 <tr height="30px" runat="server" id="Direct">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                 Direct
                </td>
                <td align="left">
                    <asp:Label ID="lblDirect" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
 <tr height="30px" runat="server" id="For">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                  Forex
                </td>
                <td align="left">
                    <asp:Label ID="lblFor" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
 <tr height="30px" runat="server" id="LL">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                  Landline
                </td>
                <td align="left">
                    <asp:Label ID="lblLL" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
 <tr height="30px" runat="server" id="Loan">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                  Loan Section
                </td>
                <td align="left">
                    <asp:Label ID="lblLoan" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
 <tr height="30px" runat="server" id="Manager">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                  Manager
                </td>
                <td align="left">
                    <asp:Label ID="lblManager" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
 <tr height="30px" runat="server" id="Mobile">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                  Mobile
                </td>
                <td align="left">
                    <asp:Label ID="lblMobile" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
 <tr height="30px" runat="server" id="res">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                 Residence
                </td>
                <td align="left">
                    <asp:Label ID="lblRes" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
 <tr height="30px" runat="server" id="Sav">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                  Savings A/C
                </td>
                <td align="left">
                    <asp:Label ID="lblSaving" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
 <tr height="30px" runat="server" id="Spic">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                  Spic Nagar
                </td>
                <td align="left">
                    <asp:Label ID="lblSpic" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>
 <tr height="30px" runat="server" id="SUbM">
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                  Sub Manager
                </td>
                <td align="left">
                    <asp:Label ID="lblSubM" style="font-size:14px;font-family:Open Sans,Sans-Serif;" runat="server" Text="" CssClass="label2"></asp:Label>
                </td>
            </tr>

        <tr height="30px" id="Tr3" runat="server" style="background-color:#C90084; color:white;">
                <td align="left" valign="middle" style=" width:40%;font-size:15px;font-family:Open Sans,Sans-Serif;" colspan="2">
                 <strong>Contact Info (Fax)</strong>  
                </td>
               
            </tr>
               <tr height="30px" id="CTFax1" runat="server">
               <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    <span style="color: Red;"></span>Fax No
                </td>
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                   <asp:Label ID="lblfaxno" runat="server" Text="" CssClass="label2"></asp:Label>	
                </td>
               
            </tr>
        <tr height="30px" id="ContactEid" runat="server" style="background-color:#C90084; color:white;">
                <td align="left" valign="middle" style=" width:40%;font-size:15px;font-family:Open Sans,Sans-Serif;" colspan="2">
                 <strong>Contact Info (Email)</strong>  
                </td>
               
            </tr>
               <tr height="30px" id="Eid" runat="server">
               <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    <span style="color: Red;"></span>Email ID
                </td>
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                   <asp:Label ID="lblEid" runat="server" Text="" CssClass="label2"></asp:Label>	
                </td>
               
            </tr>
         <tr height="30px" id="Tr5" runat="server">
               <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    <span style="color: Red;"></span>Send Feedback
                </td>
                <td align="left" valign="middle" style=" width:40%;font-size:14px;font-family:Open Sans,Sans-Serif;">
                    <a href="Online-Feedback-Form.aspx" target="_blank">Click Here to Write to the Branch Manager</a>
                </td>
               
            </tr>
         
      </table>
    </div>
   </div>
</asp:Content>

