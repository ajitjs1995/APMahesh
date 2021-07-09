<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="admin-offices.aspx.cs" Inherits="AdminOffice" %>

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
              <p>&nbsp;</p>
                    <h1>Admin Office </h1>
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
<p>Learn more about the extensive non-branch network of offices of Tamilnad Mercantile Bank.</p>

<p>Apart from the extensive branch network of TMB, we also have the following offices / departments to cater to the needs of specific customer segments and serve our customers better. Click the specific office to get complete details of the choosen office.</p>
</div>
</div>
</div>

<div class="panel panel-default">
<div class="panel-heading" id="heading3" role="tab">
<h4 class="panel-title"><a aria-controls="collapse3" aria-expanded="false" class="collapsed" data-parent="#accordion" data-toggle="collapse" href="#collapse3" role="button">Other Administrative Offices of TMB</a></h4>
</div>

<div aria-labelledby="heading3" class="panel-collapse collapse" id="collapse3" role="tabpanel">
<div class="panel-body">
                        <div class="tabbs">
                       
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
                                    <asp:BoundColumn DataField="RO_ID" Visible="False"></asp:BoundColumn>
                                     <%--1--%>
                        <asp:TemplateColumn HeaderText="Other Administrative Offices of TMB" >
                            <HeaderStyle Width="300px" HorizontalAlign="Center" CssClass="h44" />
                            <ItemStyle HorizontalAlign="left" Width="120px" Font-Size="14px" CssClass="td1"/>
                            <ItemTemplate>
                               
                                  <asp:LinkButton ID="lnkname" runat="server" style="font-size:14px;"  CommandName="CmdViewDetail"  CssClass="td2" OnClientClick="aspnetForm.target ='_blank';"></asp:LinkButton></ItemTemplate>
                        </asp:TemplateColumn>
                          <%---------------------------------------2-------------------------------%>
                            <asp:BoundColumn DataField="Name" HeaderText="" Visible="False"></asp:BoundColumn>
                          <%---------------------------------------3-------------------------------%>
                         <asp:BoundColumn DataField="Address" HeaderText="" Visible="False"></asp:BoundColumn>
                                    <%---------------------------------------4-------------------------------%>
                                                <asp:BoundColumn DataField="Email" HeaderText="" Visible="False"></asp:BoundColumn>
                                                <%---------------------------------------5-------------------------------%>
                                                <asp:BoundColumn DataField="City" HeaderText="" Visible="False"></asp:BoundColumn>
                                                <%---------------------------------------6-------------------------------%>
                                              <asp:BoundColumn DataField="PinZipCode" HeaderText="" Visible="False"></asp:BoundColumn>
                                                <%---------------------------------------7-------------------------------%>
                                               <asp:BoundColumn DataField="District " HeaderText="" Visible="False"></asp:BoundColumn>
                                                 <%---------------------------------------8-------------------------------%>
                                                 <asp:BoundColumn DataField=" State" HeaderText="" Visible="False"></asp:BoundColumn>
                                                <%---------------------------------------9-------------------------------%>
                                                 <asp:BoundColumn DataField="Country" HeaderText="" Visible="False"></asp:BoundColumn>
                                                  <%---------------------------------------10-------------------------------%>
                                                <asp:BoundColumn DataField="CountryCode" HeaderText="" Visible="False"></asp:BoundColumn>
                                                  <%---------------------------------------11-------------------------------%>
                                               <asp:BoundColumn DataField="StdCode" HeaderText="" Visible="False"></asp:BoundColumn>
                                                  <%---------------------------------------12-------------------------------%>
                                                 <asp:BoundColumn DataField="Mobile" HeaderText="" Visible="False"></asp:BoundColumn>
                                                  <%---------------------------------------13-------------------------------%>
                                              <asp:BoundColumn DataField="RegionalManager" HeaderText="" Visible="False"></asp:BoundColumn>
                                                  <%---------------------------------------14-------------------------------%>
                                               <asp:BoundColumn DataField="ChiefManager" HeaderText="" Visible="False"></asp:BoundColumn>
                                                  <%---------------------------------------15-------------------------------%>
                                                  <asp:BoundColumn DataField="Board_Extn" HeaderText="" Visible="False"></asp:BoundColumn>
                                                  <%---------------------------------------16-------------------------------%>
                                                  <asp:BoundColumn DataField="Principal" HeaderText="" Visible="False"></asp:BoundColumn>
                                                  <%---------------------------------------17-------------------------------%>
                                               <asp:BoundColumn DataField="Board" HeaderText="" Visible="False"></asp:BoundColumn>
                                                  <%---------------------------------------18-------------------------------%>
                                                 <asp:BoundColumn DataField="Board_Mobile" HeaderText="" Visible="False"></asp:BoundColumn>
                                                  <%---------------------------------------19-------------------------------%>
                                               <asp:BoundColumn DataField="Board_01" HeaderText="" Visible="False"></asp:BoundColumn>
                                                  <%---------------------------------------20-------------------------------%>
                                                 <asp:BoundColumn DataField="Board_02" HeaderText="" Visible="False"></asp:BoundColumn>
                                                  <%---------------------------------------21-------------------------------%>
                                             <asp:BoundColumn DataField="Board_03" HeaderText="" Visible="False"></asp:BoundColumn>
                                                  <%---------------------------------------22-------------------------------%>
                                                 <asp:BoundColumn DataField="Board_04" HeaderText="" Visible="False"></asp:BoundColumn>
                                                  <%---------------------------------------23-------------------------------%>
                                                 <asp:BoundColumn DataField="Board_05" HeaderText="" Visible="False"></asp:BoundColumn>
                                                  <%---------------------------------------24-------------------------------%>
                                               <asp:BoundColumn DataField="AdministrativeOfficer" HeaderText="" Visible="False"></asp:BoundColumn>
                                                  <%---------------------------------------25-------------------------------%>
                                                 <asp:BoundColumn DataField="ChiefManager" HeaderText="" Visible="False"></asp:BoundColumn>
                                                  <%---------------------------------------26-------------------------------%>
                                                 <asp:BoundColumn DataField=" Manager" HeaderText="" Visible="False"></asp:BoundColumn>
                                                  <%---------------------------------------27-------------------------------%>
                                               <asp:BoundColumn DataField="Residence" HeaderText="" Visible="False"></asp:BoundColumn>
                                                  <%---------------------------------------28-------------------------------%>
                                                <asp:BoundColumn DataField="Residence1" HeaderText="" Visible="False"></asp:BoundColumn>
                                                  <%---------------------------------------29-------------------------------%>
                                              <asp:BoundColumn DataField="FaxNo" HeaderText="" Visible="False"></asp:BoundColumn>
                                                  <%---------------------------------------30-------------------------------%>
                                                   <asp:BoundColumn DataField="ETaxCustomDuty" HeaderText="" Visible="False"></asp:BoundColumn>
                                                  <%---------------------------------------31-------------------------------%>
                                                <asp:BoundColumn DataField="ATMCell" HeaderText="" Visible="False"></asp:BoundColumn>
                                                 <%---------------------------------------32-------------------------------%>
                                                <asp:BoundColumn DataField="AsstGeneralManager" HeaderText="" Visible="False"></asp:BoundColumn>
                                                 <%---------------------------------------33-------------------------------%>
                                               <asp:BoundColumn DataField="DGM" HeaderText="" Visible="False"></asp:BoundColumn>
                                                 <%---------------------------------------34-------------------------------%>
                                                <asp:BoundColumn DataField="DGM_2" HeaderText="" Visible="False"></asp:BoundColumn>
                                                 <%---------------------------------------35-------------------------------%>
                                                 <asp:BoundColumn DataField="AGM" HeaderText="" Visible="False"></asp:BoundColumn>
                                                 <%---------------------------------------36-------------------------------%>
                                                  <asp:BoundColumn DataField="BackOffice" HeaderText="" Visible="False"></asp:BoundColumn>
                                                 <%---------------------------------------37-------------------------------%>
                                             <asp:BoundColumn DataField="DealingRoom" HeaderText="" Visible="False"></asp:BoundColumn>
                                                 <%---------------------------------------38-------------------------------%>
                                                 <asp:BoundColumn DataField="DeputyGeneralManager" HeaderText="" Visible="False"></asp:BoundColumn>
                                                 <%---------------------------------------39-------------------------------%>
                                               <asp:BoundColumn DataField="Swift" HeaderText="" Visible="False"></asp:BoundColumn>
                                                 <%---------------------------------------40-------------------------------%>
                                              <asp:BoundColumn DataField="Credit" HeaderText="" Visible="False"></asp:BoundColumn>
                                                 <%---------------------------------------41-------------------------------%>
                                                    <asp:BoundColumn DataField="CM" HeaderText="" Visible="False"></asp:BoundColumn>
                                                 <%---------------------------------------42-------------------------------%>
                                               <asp:BoundColumn DataField="AO" HeaderText="" Visible="False"></asp:BoundColumn>
                                                 <%---------------------------------------43-------------------------------%>
                                                <asp:BoundColumn DataField="RM" HeaderText="" Visible="False"></asp:BoundColumn>
                                           
                                              
                                            
                                             
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
<div class="main-white-box box-1 clearfix" style="background: #ececed; height: auto;   border: none;"><img class="rel-img-right em-img lazyloaded" src="images/products1.jpg" style="width: 100%; height: auto; display: block; border-radius: 4px 4px 0 0;" />
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

