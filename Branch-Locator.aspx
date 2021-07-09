<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UserMasterPage.master" CodeFile="Branch-Locator.aspx.cs" Inherits="Branch_Locator" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

     <style>
     .td1 
     {
        
         padding :12px;
     }
     .td2
     {
          color:Black !important;
     }
     .h44
     {
         font-size : 18px;
         color:White !important;
         Height:40px;
         padding :12px;
     }
     .address
     {
         font-size:14px;
         padding-left:0.8em;
     }
     #Btnsrch
     {
         padding-left:1em;
         padding-right:1em;
     }
     .form-control {
   
    display: inline-block;
    margin-left:-193px;
        padding: 8px 11px;
		height: 40px;
}
   .btn {
      border: 0;
    cursor: pointer;
    color: #fff !important;
    text-decoration: none;
    text-decoration: none;
    background: #18378b;
    line-height: 20px;
    height: 20px;
    margin-left: 3%;
    margin-bottom: 6px;
    width: auto;
    height: 36px!important;
}
      


   input[placeholder]
   {
       font-size:18px;
	   height: 42px;
   }

   .mydropdownlist
{
color: #333333 ;
font-size: 14px;
padding: 5px 10px;
border-radius: 17px;
background-color:#fff;
/*font-weight: bold;*/
}
     </style>
     <script type="text/javascript">
         function fixform() {
             if (opener.document.getElementById("aspnetForm").target != "_blank") return;
             opener.document.getElementById("aspnetForm").target = "";
             opener.document.getElementById("aspnetForm").action = opener.location.href;
         }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="blog container" style="width: 92%;">
            <div class="row">
             <div class="col-md-9">
             <h1>Branch Locator</h1>
                 <p>
                            <asp:Label ID="msg" runat="server" Text=""></asp:Label>
                        </p>
                   
                       <div class="tabContainer">

<p style="text-align:center;">
                            <asp:Label ID="LblError" runat="server" Text=""></asp:Label>
                        </p>
                           <div class="panel">
      <div class="panel-body" style="box-shadow: 1px 3px 8px 2px rgba(125, 123, 123, 0.75);
    background: #e6e5e6; padding: 20px;">
          <form id="Form1" method="post" onsubmit="return false;" enctype="multipart/form-data"  autocomplete="off">
                        <div class="col-l-5" style="left:20%;">
<div class="col-md-12">

                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <div class="col-md-4">    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <strong style="vertical-align: baseline; color: #c6007e;">Select State</strong>
        <asp:DropDownList ID="stt" runat="server" 
            onselectedindexchanged="state_selection" AutoPostBack="true" AppendDataBoundItems="true" CssClass="mydropdownlist" >
           
        </asp:DropDownList>

        
        </ContentTemplate>
        <Triggers>
        
        <asp:AsyncPostBackTrigger ControlID="stt" />
        </Triggers>
        
        </asp:UpdatePanel>
          </div>

      
     <div class="col-md-5">  
         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
        <strong style="vertical-align: baseline; color: #c6007e;">Select District</strong>

        <asp:DropDownList ID="ctyy" runat="server" 
            onselectedindexchanged="city_selection" AutoPostBack="true" AppendDataBoundItems="true" CssClass="mydropdownlist" >
           
        </asp:DropDownList>

        </ContentTemplate>
        <Triggers>
        
        <asp:AsyncPostBackTrigger ControlID="ctyy" />
        </Triggers>
        </asp:UpdatePanel>

     </div>
      
                       <div class="col-md-3">
                           
                           <asp:Button ID="Btnsrch" runat="server" Text="Search" CssClass="btn"  OnClick="btnsrch_Click" />
                                     
                                         
                                          <asp:Button ID="btnreset" runat="server" Text="Reset"  CssClass="btn" OnClick="btnreset_Click" /></div>

    </div>

                        </div>
                                                
                                 
                                           <%--  <asp:Button ID="Button3" runat="server" Text="View All" class="buttons-submits" OnClick="BtnView_Click" /><br/><br/>--%>
                                   
                       
                       </form>

                           </div>
    </div>
                      <br />
                         
                       
                    <asp:DataGrid ID="dg_AdmOff" runat="server" Width="100%"
                                AllowPaging="false" AutoGenerateColumns="False"
                    CellSpacing="4" CellPadding="4" 
                                onitemdatabound="dg_AdmOff_ItemDataBound" onitemcommand="dg_AdmOff_ItemCommand" style="box-shadow: 1px 3px 8px 2px rgba(125, 123, 123, 0.75);
    background: #e6e5e6;">
                            
                                 <HeaderStyle BackColor="#1e3a8e" ForeColor="White" Height="30px" HorizontalAlign="Center"/>
                    <ItemStyle Height="20px" BackColor="#FFFFFF" HorizontalAlign="Left" VerticalAlign="Top"
                        CssClass="" />
                    <AlternatingItemStyle Height="20px" CssClass="" BackColor="#F5F5F5" HorizontalAlign="Left"
                        VerticalAlign="Top" />
                    <PagerStyle Mode="NumericPages" HorizontalAlign="center" VerticalAlign="middle" />
                                <Columns>
                                    <asp:BoundColumn HeaderText="Sr No" DataField="Br_ID" Visible="false" > <HeaderStyle Width="300px" HorizontalAlign="Center" CssClass="h44" /><ItemStyle HorizontalAlign="Center" Width="120px" Font-Size="12px" CssClass="td1"/></asp:BoundColumn>
                                    
                         
                                     <%--1--%>
                        <asp:TemplateColumn HeaderText="Branch" >
                            <HeaderStyle Width="300px" HorizontalAlign="Center" CssClass="h44" />
                            <ItemStyle HorizontalAlign="left" Width="120px" Font-Size="12px" CssClass="td1"/>
                            <ItemTemplate>
                               
                                <p> <strong> <asp:LinkButton ID="lnkname" runat="server" style="font-size:14px;"  CommandName="CmdViewDetail" OnClientClick="aspnetForm.target ='_blank';"></asp:LinkButton></strong></p>
                                    <asp:Label runat="server" ID="addlbl" CssClass="address"></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateColumn>
                                   
                          <%---------------------------------------2-------------------------------%>
                            <asp:BoundColumn DataField="RTGS_IFSC_Code" HeaderText="IFSC / RTGS Code" Visible="false"> <%--<HeaderStyle Width="300px" HorizontalAlign="Center" CssClass="h44" /><ItemStyle HorizontalAlign="Center" Width="120px" Font-Size="12px" CssClass="td1"/>--%></asp:BoundColumn>
                          <%---------------------------------------3-------------------------------%>
                         <asp:BoundColumn DataField="MICR_Code" HeaderText="" Visible="false"><%-- <HeaderStyle Width="300px" HorizontalAlign="Center" CssClass="h44" /><ItemStyle HorizontalAlign="Center" Width="120px" Font-Size="12px" CssClass="td1"/>--%></asp:BoundColumn>
                          <%---------------------------------------4-------------------------------%>
                          <asp:BoundColumn DataField="Br_Name" HeaderText="Brach Name " Visible="false"></asp:BoundColumn>
                          <%---------------------------------------5-------------------------------%>
                         <asp:BoundColumn DataField="District" HeaderText="" Visible="false"></asp:BoundColumn>
                                          
                            <%---------------------------------------6-------------------------------%>
                         <asp:BoundColumn DataField="State" HeaderText="State " Visible="false"></asp:BoundColumn> 
                            <%---------------------------------------7-------------------------------%>
                         <asp:BoundColumn DataField="Br_Code" HeaderText="State " Visible="false"></asp:BoundColumn> 
                            <%---------------------------------------8-------------------------------%>
                         <asp:BoundColumn DataField="Br_Type" HeaderText="State " Visible="false"></asp:BoundColumn> 
                            <%---------------------------------------9-------------------------------%>
                         <asp:BoundColumn DataField="Address" HeaderText="State " Visible="false"></asp:BoundColumn> 
                            <%---------------------------------------10-------------------------------%>
                         <asp:BoundColumn DataField="Area" HeaderText="State " Visible="false"></asp:BoundColumn> 
                            <%---------------------------------------11-------------------------------%>
                         <asp:BoundColumn DataField="Pin_Code" HeaderText="State " Visible="false"></asp:BoundColumn> 
                            <%---------------------------------------12-------------------------------%>
                         <asp:BoundColumn DataField="Country" HeaderText="State " Visible="false"></asp:BoundColumn> 
                            <%---------------------------------------13------------------------------%>
                         <asp:BoundColumn DataField="Forex_Services" HeaderText="State " Visible="false"></asp:BoundColumn> 
                            <%---------------------------------------14-------------------------------%>
                         <asp:BoundColumn DataField="NRI_Services" HeaderText="State " Visible="false"></asp:BoundColumn> 
                            <%---------------------------------------15-------------------------------%>
                         <asp:BoundColumn DataField="ATM_Facility" HeaderText="State " Visible="false"></asp:BoundColumn> 
                            <%---------------------------------------16-------------------------------%>
                         <asp:BoundColumn DataField="Locker_Facility" HeaderText="State " Visible="false"></asp:BoundColumn> 
                            <%---------------------------------------17-------------------------------%>
                         <asp:BoundColumn DataField="ASBA_Services" HeaderText="State " Visible="false"></asp:BoundColumn> 
                            <%---------------------------------------18-------------------------------%>
                         <asp:BoundColumn DataField="Demat_Services" HeaderText="State " Visible="false"></asp:BoundColumn> 
                            <%---------------------------------------19-------------------------------%>
                         <asp:BoundColumn DataField="Mutual_Fund_Services" HeaderText="State " Visible="false"></asp:BoundColumn> 
                            <%---------------------------------------20-------------------------------%>
                         <asp:BoundColumn DataField="Anywhere_Banking" HeaderText="State " Visible="false"></asp:BoundColumn> 
                            <%---------------------------------------21-------------------------------%>
                         <asp:BoundColumn DataField="ECS_Services" HeaderText="State " Visible="false"></asp:BoundColumn> 
                            <%---------------------------------------22-------------------------------%>
                         <asp:BoundColumn DataField="Country_Code" HeaderText="State " Visible="false"></asp:BoundColumn> 
                            <%---------------------------------------23-------------------------------%>
                         <asp:BoundColumn DataField="Std_Code" HeaderText="State " Visible="false"></asp:BoundColumn> 
<%---------------------------------------24-------------------------------%>
                         <asp:BoundColumn DataField="Mobile" HeaderText="State " Visible="false"></asp:BoundColumn> 
<%---------------------------------------25-------------------------------%>
                         <asp:BoundColumn DataField="Manager" HeaderText="State " Visible="false"></asp:BoundColumn> 
<%---------------------------------------26-------------------------------%>
                         <asp:BoundColumn DataField="Spic_Nagar" HeaderText="State " Visible="false"></asp:BoundColumn> 
<%---------------------------------------27-------------------------------%>
                         <asp:BoundColumn DataField="Sub_Manager" HeaderText="State " Visible="false"></asp:BoundColumn> 
<%---------------------------------------28-------------------------------%>
                         <asp:BoundColumn DataField="Landline" HeaderText="State " Visible="false"></asp:BoundColumn> 
<%---------------------------------------29-------------------------------%>
                         <asp:BoundColumn DataField="Savings_AC" HeaderText="State " Visible="false"></asp:BoundColumn> 
<%---------------------------------------30-------------------------------%>
                         <asp:BoundColumn DataField="Current_AC" HeaderText="State " Visible="false"></asp:BoundColumn> 
<%---------------------------------------31-------------------------------%>
                         <asp:BoundColumn DataField="Deposits" HeaderText="State " Visible="false"></asp:BoundColumn> 
<%---------------------------------------32-------------------------------%>
                         <asp:BoundColumn DataField="Clearing" HeaderText="State " Visible="false"></asp:BoundColumn> 
<%---------------------------------------33-------------------------------%>
                         <asp:BoundColumn DataField="CTS_Clearing" HeaderText="State " Visible="false"></asp:BoundColumn> 
<%---------------------------------------34-------------------------------%>
                         <asp:BoundColumn DataField="Forex" HeaderText="State " Visible="false"></asp:BoundColumn> 
<%---------------------------------------35-------------------------------%>
                         <asp:BoundColumn DataField="Board" HeaderText="State " Visible="false"></asp:BoundColumn> 
<%---------------------------------------36-------------------------------%>
                         <asp:BoundColumn DataField="Board1" HeaderText="State " Visible="false"></asp:BoundColumn> 
<%---------------------------------------37-------------------------------%>
                         <asp:BoundColumn DataField="Board2" HeaderText="State " Visible="false"></asp:BoundColumn> 
<%---------------------------------------38-------------------------------%>
                         <asp:BoundColumn DataField="Direct" HeaderText="State " Visible="false"></asp:BoundColumn> 
<%---------------------------------------39-------------------------------%>
                         <asp:BoundColumn DataField="Residence" HeaderText="State " Visible="false"></asp:BoundColumn> 
<%---------------------------------------40-------------------------------%>
                         <asp:BoundColumn DataField="Loan_Section" HeaderText="State " Visible="false"></asp:BoundColumn> 
<%---------------------------------------41-------------------------------%>
                         <asp:BoundColumn DataField="Bill_Section" HeaderText="State " Visible="false"></asp:BoundColumn> 
<%---------------------------------------42-------------------------------%>
                         <asp:BoundColumn DataField="Cash_Section" HeaderText="State " Visible="false"></asp:BoundColumn> 

<%---------------------------------------43-------------------------------%>
                         <asp:BoundColumn DataField="Fax_No" HeaderText="State " Visible="false"></asp:BoundColumn> 

<%---------------------------------------44-------------------------------%>
                         <asp:BoundColumn DataField="Email_ID" HeaderText="State " Visible="false"></asp:BoundColumn> 

                                                     
                                             
                                </Columns>
                            </asp:DataGrid>
                            </div>
                    </div>
					<div class="col-md-3 related-products em" data-type="product">
<div class="hp-main-box">
<div class="main-white-box box-1 clearfix" style="background: #ececed; height: auto;   border: none;"><img class="rel-img-right em-img lazyloaded" src="images/TractorLoan.jpg" style="width: 100%; height: auto; display: block; border-radius: 4px 4px 0 0;">
<div class="details-box">
<div class="hp-card-box">
<h4 class="em-title share-comp-title" style="margin-top: 0px; min-height: 60px; background: transparent; border: none; color: #000; font-size: 21px;">TMB Tractor Loan</h4>
</div>

<div class="clearfix"><a class="" href="/tractor.aspx"><img src="images/morebtn.png"></a></div>
</div>
</div>
</div>
</div>
    </div>
                    
                  </div>



</asp:Content>


