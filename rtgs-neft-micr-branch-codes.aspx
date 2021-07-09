<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UserMasterPage.master" CodeFile="rtgs-neft-micr-branch-codes.aspx.cs" Inherits="rtgs_neft_micr_branch_codes" %>

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
         font-size : 15px;
         color:White !important;
         Height:40px;
         padding :12px;
     }
     </style>
     <script type="text/javascript">
         function fixform() {
             if (opener.document.getElementById("aspnetForm").target != "_blank") return;
             opener.document.getElementById("aspnetForm").target = "";
             opener.document.getElementById("aspnetForm").action = opener.location.href;
         }
</script>
      <%--<img src="InnerBanner/Banner/RTGS-NEFT-MICR-CODES.jpg" alt="RTGS-NEFT-MICR-CODES" class="img-responsive">--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="blog container" style="width: 92%;">
            <div class="row">
             <div class="col-md-9">
              <p>&nbsp;</p>
                    <h1>RTGS IFSC MICR Codes </h1>
<%--<div class="tabbs">
                      
                        <p>
                            <asp:Label ID="LblError" runat="server" ForeColor="Red" Text=""></asp:Label>
                        </p>

                        <div class="form-group">
                                <label for="">Name : </label>
                                <asp:TextBox ID="txtname"
                                runat="server"  class="form-control"  AutoComplete="off"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="">Area :</label>
                                 <asp:TextBox ID="txtarea"
                                runat="server"  class="form-control"  AutoComplete="off"></asp:TextBox>
                            </div>
                <asp:Button ID="Btnsearch" runat="server" Text="Search" OnClick="Btnsearch_Click" class="btn btn-primary em-cta related-product-click-apply" />
               <asp:Button ID="Btnreset" runat="server" Text="Reset"  OnClick="Btnreset_Click"  class="btn btn-primary em-cta related-product-click-apply" />
                    </div>--%>
                     <%--<div class="container" style="text-align: center">
                            <div class="row">
                                <br/><br/><asp:Label ID="lblmsg" runat="server" ForeColor="red" CssClass="btntop"></asp:Label>
                            </div>
                        </div>--%>
                       <div class="tabContainer">
<div aria-multiselectable="true" class="panel-group" id="accordion" role="tablist">
<div class="panel panel-default">
<div class="panel-heading" id="heading2" role="tab">
<h4 class="panel-title"><a aria-controls="collapse2" aria-expanded="false" class="collapsed" data-parent="#accordion" data-toggle="collapse" href="#collapse2" role="button">Overview</a></h4>
</div>

<div aria-labelledby="heading2" class="panel-collapse collapse" id="collapse2" role="tabpanel">
<div class="panel-body">
<p>
    Learn more about the RTGS (IFSC) / NEFT (IFSC) / MICR Codes of all our branches to enable quick and smooth same day inter bank fund transfers from any bank offering RTGS fund transfer to any branch network of Tamilnad Mercantile Bank anywhere in India.

</p>
</div>
</div>
</div>

<div class="panel panel-default">
<div class="panel-heading" id="heading3" role="tab">
<h4 class="panel-title"><a aria-controls="collapse3" aria-expanded="false" class="collapsed" data-parent="#accordion" data-toggle="collapse" href="#collapse3" role="button">List of Branches with RTGS & NEFT (IFSC) / MICR Codes</a></h4>
</div>

<div aria-labelledby="heading3" class="panel-collapse collapse in" id="collapse3" role="tabpanel">
<div class="panel-body">
                        <div class="tabbs" style="overflow-x: auto; overflow-y: scroll;
    height: 500px;">
                       
                    <asp:DataGrid ID="dg_AdmOff" runat="server" Width="100%"
                                AllowPaging="false" AutoGenerateColumns="False"
                    CellSpacing="4" CellPadding="4" 
                                onitemdatabound="dg_AdmOff_ItemDataBound" onitemcommand="dg_AdmOff_ItemCommand">
                            
                                 <HeaderStyle BackColor="#1e3a8e" ForeColor="White" Height="30px" HorizontalAlign="Center"/>
                    <ItemStyle Height="20px" BackColor="#FFFFFF" HorizontalAlign="Left" VerticalAlign="Top"
                        CssClass="" />
                    <AlternatingItemStyle Height="20px" CssClass="" BackColor="#F5F5F5" HorizontalAlign="Left"
                        VerticalAlign="Top" />
                    <PagerStyle Mode="NumericPages" HorizontalAlign="center" VerticalAlign="middle" />
                                <Columns>
                                    <asp:BoundColumn HeaderText="Sr No" DataField="Br_ID" Visible="True" > <HeaderStyle Width="100px" HorizontalAlign="Center" CssClass="h44" /><ItemStyle HorizontalAlign="Center" Width="120px" Font-Size="14px" CssClass="td1"/></asp:BoundColumn>
                                    
                         
                                     <%--1--%>
                        <asp:TemplateColumn HeaderText="Branch" >
                            <HeaderStyle Width="400px" HorizontalAlign="Center" CssClass="h44" />
                            <ItemStyle HorizontalAlign="left" Width="120px" Font-Size="14px" CssClass="td1"/>
                            <ItemTemplate>
                               
                                  <asp:LinkButton ID="lnkname" runat="server" style="font-size:14px;"  CommandName="CmdViewDetail" OnClientClick="aspnetForm.target ='_blank';"></asp:LinkButton></ItemTemplate>
                        </asp:TemplateColumn>
                                   
                          <%---------------------------------------2-------------------------------%>
                            <asp:BoundColumn DataField="RTGS_IFSC_Code" HeaderText="IFSC / RTGS Code" > <HeaderStyle Width="200px" HorizontalAlign="Center" CssClass="h44" /><ItemStyle HorizontalAlign="Center" Width="120px" Font-Size="14px" CssClass="td1"/></asp:BoundColumn>
                          <%---------------------------------------3-------------------------------%>
                         <asp:BoundColumn DataField="MICR_Code" HeaderText="M.I.C.R. Code "> <HeaderStyle Width="300px" HorizontalAlign="Center" CssClass="h44" /><ItemStyle HorizontalAlign="Center" Width="120px" Font-Size="14px" CssClass="td1"/></asp:BoundColumn>
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
                    
                  </div></div>
</div>
</div>
</div>
<div class="col-md-3 col-sm-12 related-products em" data-type="product">
<div class="hp-main-box">
<div class="main-white-box box-1 clearfix" style="background: #ececed; height: auto;   border: none;"><img class="rel-img-right em-img lazyloaded" srcset="images/products1.jpg" style="width: 100%; height: auto; display: block; border-radius: 4px 4px 0 0;" />
<div class="details-box">
<div class="hp-card-box">
<h4 class="em-title share-comp-title" style="margin-top: 0px; min-height: 60px; background: transparent; border: none; color: #000; font-size: 21px;">Savings Account</h4>
</div>

<div class="clearfix"><a href="https://www.tmbnet.in/tmbankonline/" target="_blank"><img src="images/morebtnapply.png" /></a></div>
</div>
</div>
</div>
</div>
</div>
</div>

</asp:Content>


