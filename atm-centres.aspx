<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="atm-centres.aspx.cs" Inherits="Atm_Locator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

   <%-- <img src="InnerBanner/Banner/ATMCentres.jpg" alt="ATMCentres" class="img-responsive">--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="blog container" style="width: 92%;">
            <div class="row">
             <div class="col-md-9">
              <p>&nbsp;</p>
                    <h1>ATM Center </h1>
<%--<div class="tabbs">
                      
                        <p>
                            <asp:Label ID="LblError" runat="server" ForeColor="Red" Text=""></asp:Label>
                        </p>

                        <div class="form-group">
                                <label for="">State </label>
                                <asp:DropDownList
                                    ID="ddlstate" runat="server" class="form-control" 
                                    onselectedindexchanged="ddlstate_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <label for="">District </label>
                                <asp:DropDownList
                                    ID="ddldistrict" runat="server" class="form-control">
                                </asp:DropDownList>
                            </div>
                       

                        <div class="form-group">
                            <label for="">Location :</label>
                            <asp:TextBox ID="txtlocation"
                                runat="server"  class="form-control"  AutoComplete="off"></asp:TextBox>
                        </div>
                       
                        <div class="form-group">
                            <label for="">Type :</label>
                            <asp:DropDownList ID="ddlsub" runat="server" class="form-control" AutoPostBack="true">
                                <asp:ListItem>Select Type</asp:ListItem>
                                <asp:ListItem Value="OnSite">On Site</asp:ListItem>
                                <asp:ListItem Value="OffSite">Off Site</asp:ListItem>

                            </asp:DropDownList>
                        </div>


                        

                        <asp:Button ID="Btnsearch" runat="server" Text="Search" OnClick="Btnsearch_Click" class="btn btn-primary em-cta related-product-click-apply" />
               <asp:Button ID="Btnreset" runat="server" Text="Reset" OnClick="Btnreset_Click" class="btn btn-primary em-cta related-product-click-apply" />
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
<div align="center"><img src="/images/general-insurance.png" /></div>
&nbsp;

<p>Learn more about the extensive pan India network of automated teller machines of TMB Surabhi ATM Centres in India.</p>

<p>Tamilnad Mercantile Bank operates its own network of ATM Centres spread all over India. Apart from this, we have a tie up with <strong>National Financial Switch (NFS)</strong> through which our ATM Cards can be used at any of the 214,233 ATM&rsquo;s (as on Sep 2019) operated by 113 member banks (including TMB) as referred below.</p>
</div>
</div>
</div>



<div class="panel panel-default">
<div class="panel-heading" id="heading4" role="tab">
<h4 class="panel-title"><a aria-controls="collapse4" aria-expanded="false" class="collapsed" data-parent="#accordion" data-toggle="collapse" href="#collapse4" role="button">List of Services offered at ATMs</a></h4>
</div>

<div aria-labelledby="heading4" class="panel-collapse collapse" id="collapse4" role="tabpanel">
<div class="panel-body">
<div class="listing">
<ul>
	<li>Cash Withdrawal / Fast Cash</li>
	<li>PIN Change</li>
	<li>Cash Transfer - Self (Linked Acct.), Third Party (Any TMB Acct.), Card to Card (Any Card / Any Bank / Any Acct.)</li>
	<li>Donation</li>
	<li>Balance Inquiry</li>
	<li>Mini Statement</li>
	<li>Cheque Book Request</li>
	<li>Statement Request</li>
	<li>Product Request</li>
	<li>TNEB Bill Payment</li>
</ul>

<p>We are very glad to inform that TNEB Bill payment through our ATMs is enabled from 27.02.2016. We are the First Bank to enable this facility through ATMs.</p>
</div>
</div>
</div>
</div>

<div class="panel panel-default">
<div class="panel-heading" id="heading5" role="tab">
<h4 class="panel-title"><a aria-controls="collapse5" aria-expanded="false" class="collapsed" data-parent="#accordion" data-toggle="collapse" href="#collapse5" role="button">National Financial Switch (NFS) - 113 Member Banks</a></h4>
</div>

<div aria-labelledby="heading5" class="panel-collapse collapse" id="collapse5" role="tabpanel">
<div class="panel-body">
<div class="listing">
<ul>
	<li>Abhyudaya Co-operative Bank</li>
	<li>Allahabad Bank</li>
	<li>Almora Urban Co-operative Bank Ltd.</li>
	<li>Andhra bank</li>
	<li>ANZ Banking Group Ltd.</li>
	<li>APNA Sahakari Bank ltd.</li>
	<li>AU Small Finance Bank</li>
	<li>Axis Bank</li>
	<li>Bandhan Bank Limited</li>
	<li>Bank of Bahrain and Kuwait</li>
	<li>Bank of Baroda</li>
	<li>Bank Of India</li>
	<li>Bank of Maharashtra</li>
	<li>Bassein Catholic Co-operative Bank Ltd</li>
	<li>Canara Bank</li>
	<li>Capital Small Finance Bank Limited</li>
	<li>Catholic Syrian Bank</li>
	<li>Central Bank of India</li>
	<li>Citibank</li>
	<li>Citizen Credit Co-operative Bank</li>
	<li>City Union Bank</li>
	<li>Corporation Bank</li>
	<li>Cosmos Bank</li>
	<li>DCB Bank Ltd.</li>
	<li>Dena Bank</li>
	<li>Deutsche Bank</li>
	<li>Development Bank of Singapore</li>
	<li>Dhanlaxmi Bank</li>
	<li>Doha Bank</li>
	<li>Dombivli Nagarik Sahakari Bank</li>
	<li>Emirates NBD Bank</li>
	<li>Equitas Small Finance Bank Ltd.</li>
	<li>ESAF Small Finance Bank</li>
	<li>Federal Bank</li>
	<li>Fincare Small Finance Bank Limited</li>
	<li>Fino Payments Bank</li>
	<li>Gopinath Patil Parsik Janata Sahakari Bank Ltd.</li>
	<li>HDFC Bank</li>
	<li>HSBC Bank</li>
	<li>ICICI Bank</li>
	<li>IDBI Bank</li>
	<li>IDFC Bank</li>
	<li>Idukki District Co-operative Bank</li>
	<li>India Post Payments Bank Limited</li>
	<li>Indian Bank</li>
	<li>Indian Overseas Bank</li>
	<li>Indusind Bank</li>
	<li>Jammu and Kashmir Bank</li>
	<li>Jana Small Finance Bank</li>
	<li>JanaKalyan Sahakari Bank</li>
	<li>Janaseva Sahakari Bank Ltd.,Pune</li>
	<li>Janata Sahakari Bank</li>
	<li>Kallappanna Awade Ichalkaranji Janata Sahkari Bank</li>
	<li>Kalyan Janata Sahakari Bank</li>
	<li>Karnataka Bank</li>
	<li>Karur Vysya Bank</li>
	<li>KEB Hana Bank</li>
	<li>Kotak Mahindra Bank</li>
	<li>Lakshmi Vilas Bank</li>
	<li>Mahanagar Co-operative Bank</li>
	<li>Mehsana Urban Co-operative Bank</li>
	<li>Mumbai District Central Co-operative Bank Ltd.</li>
	<li>New India Co-operative Bank Ltd.</li>
	<li>NKGSB Co-Operative Bank</li>
	<li>North East Small Finance Bank Ltd.</li>
	<li>NSDL Payments Bank Limited</li>
	<li>Nutan Nagarik Sahakari Bank</li>
	<li>Odisha State Cooperative Bank</li>
	<li>Oriental Bank of Commerce</li>
	<li>Paytm Payments Bank Limited</li>
	<li>Punjab and Maharashtra Co-operative Bank</li>
	<li>Punjab and Sind Bank</li>
	<li>Punjab National Bank</li>
	<li>Qatar National Bank(Q.P.S.C)</li>
	<li>Rajkot Nagrik Sahakari Bank</li>
	<li>RBL Bank</li>
	<li>Saraswat Co-operative Bank</li>
	<li>SBM Bank (India) Ltd.</li>
	<li>Shamrao Vithal Bank</li>
	<li>Shivalik Mercantile Co-operative Bank Ltd</li>
	<li>Solapur Janata Sahakari Bank Ltd.</li>
	<li>Standard Chartered Bank</li>
	<li>State Bank of India</li>
	<li>Suryoday Small Finance Bank Limited</li>
	<li>Syndicate Bank</li>
	<li>Tamil Nadu State Apex Co-operative Bank Ltd.&nbsp;</li>
	<li>Tamilnad Mercantile Bank</li>
	<li>Telangana State Co-operative Apex Bank</li>
	<li>Thane Bharat Sahakari Bank Ltd.</li>
	<li>The A.P. Mahesh Co-operative Urban Bank Ltd.</li>
	<li>The Andhra Pradesh State Co-Operative Bank Ltd.</li>
	<li>The Bharat Co-Operative Bank Ltd.</li>
	<li>The Greater Bombay Co-operative Bank</li>
	<li>The Gujarat State Co-op Bank Ltd.</li>
	<li>The Kalupur Commercial Co-operative Bank Ltd.</li>
	<li>The Kangra Central Co-operative Bank Ltd.</li>
	<li>The Karad Urban Co-operative Bank Ltd.</li>
	<li>The Karnataka State Co-operative Apex Bank Ltd.</li>
	<li>The Maharashtra State Co-operative Bank Ltd.</li>
	<li>The Municipal Co-operative Bank Ltd.</li>
	<li>The South Indian Bank</li>
	<li>The Surat People&rsquo;s Co-operative Bank Ltd.</li>
	<li>The Thane Dist. Central Co-operative Bank Ltd.</li>
	<li>The West Bengal State Co-operative Bank Ltd.</li>
	<li>TJSB Sahakari Bank Ltd.</li>
	<li>UCO Bank</li>
	<li>Ujjivan Small Finance Bank Limited</li>
	<li>Union Bank Of India</li>
	<li>United Bank of India</li>
	<li>Utkarsh Small Finance Bank</li>
	<li>Vijaya Bank</li>
	<li>Woori Bank</li>
	<li>Yes Bank Ltd.</li>
	<li>more to follow soon...</li>
</ul>

<p>As of September 2019, the NFS Network now connects 214,233 ATM&rsquo;s and our Bank customers can access these ATMs for withdrawal / balance enquiry. This other bank ATM Access facility is available at a very nominal cost.</p>
</div>
</div>
</div>
</div>

<div class="panel panel-default">
<div class="panel-heading" id="heading6" role="tab">
<h4 class="panel-title"><a aria-controls="collapse6" aria-expanded="false" class="collapsed" data-parent="#accordion" data-toggle="collapse" href="#collapse6" role="button">For the Kind Attention of ATM Card Customers</a></h4>
</div>

<div aria-labelledby="heading6" class="panel-collapse collapse" id="collapse6" role="tabpanel">
<div class="panel-body">
<p>As per RBI advice, the following instructions are applicable to ATM transactions in India w.e.f. Jul 01, 2011</p>

<div class="listing">
<ul>
	<li>The time limit for resolution of customer complaints by the issuing banks shall stand reduced from 12 working days to 7 working days from the date of receipt of customer complaint. Accordingly, failure to re-credit the customer&rsquo;s account within 7 working days of receipt of the complaint shall entail payment of compensation to the customers @ Rs. 100.00 per day by the issuing bank.</li>
	<li>Any customer is entitled to receive such compensation for delay, only if a claim is lodged with the issuing bank within 30 days of the date of the transaction.</li>
	<li>The number of free transactions permitted per month at other bank ATMs to Savings Bank account holders shall be inclusive of all types of transactions, financial or non-financial.</li>
</ul>
</div>

<p>As per RBI advice, the following instructions are applicable to ATM transactions in India w.e.f. Oct 15, 2009</p>

<div class="listing">
<ul>
	<li>For the customers of other banks, maximum cash withdrawal would be Rs. 10,000.00 per transaction.</li>
	<li>Cash withdrawals from ATMs of banks other than TMB more than five times in a month, may attract levy of Rs. 20.00 [including Goods &amp; Service Tax (GST)] per transaction as service charges</li>
	<li>The facility of free cash withdrawal on other bank ATMs as stated above is extended only to the Savings Bank Account holders and not to the Other type of Account holders such as Current / Overdraft / Cash Credit Account holders.</li>
</ul>
</div>
</div>
</div>
</div>

<div class="panel panel-default">
<div class="panel-heading" id="heading7" role="tab">
<h4 class="panel-title"><a aria-controls="collapse7" aria-expanded="false" class="collapsed" data-parent="#accordion" data-toggle="collapse" href="#collapse7" role="button">Frequently Asked Questions about ATM&rsquo;s</a></h4>
</div>

<div aria-labelledby="heading7" class="panel-collapse collapse" id="collapse7" role="tabpanel">
<div class="panel-body">
<p>Know more and get answers to your <a href="doc/atm-faq-01.pdf" target="_blank">Frequently Asked Questions (FAQ).</a></p>
</div>
</div>
</div>

<div class="panel panel-default">
<div class="panel-heading" id="heading8" role="tab">
<h4 class="panel-title"><a aria-controls="collapse8" aria-expanded="false" class="collapsed" data-parent="#accordion" data-toggle="collapse" href="#collapse8" role="button">Contact Details of All NFS Member Banks</a></h4>
</div>

<div aria-labelledby="heading8" class="panel-collapse collapse" id="collapse8" role="tabpanel">
<div class="panel-body">
<p>Find linked, the list of <a href="doc/nfs-atm-member-banks-contact-01.pdf" target="_blank">NFS Member Banks Contact Details for ATM Queries.</a></p>
</div>
</div>
</div>

<div class="panel panel-default">
<div class="panel-heading" id="heading9" role="tab">
<h4 class="panel-title"><a aria-controls="collapse9" aria-expanded="false" class="collapsed" data-parent="#accordion" data-toggle="collapse" href="#collapse9" role="button">ATM Usage Related Complaints Template</a></h4>
</div>

<div aria-labelledby="heading9" class="panel-collapse collapse" id="collapse9" role="tabpanel">
<div class="panel-body">
<p>In case of any problem in accessing any of our ATM&rsquo;s, please download the <a href="doc/atm-complaint-01.pdf" target="_blank">ATM Complaint Registration Template Document (PDF)</a> and fill up the same to be handed over to the bank branch where the ATM card holder has his account.</p>
</div>
</div>
</div>
<div class="panel panel-default">
<div class="panel-heading" id="heading10" role="tab">
<h4 class="panel-title"><a aria-controls="collapse10" aria-expanded="false" class="collapsed" data-parent="#accordion" data-toggle="collapse" href="#collapse10" role="button">List of Our Own 1151 ATM Centres </a></h4>
</div>

<div aria-labelledby="heading10" class="panel-collapse collapse" id="collapse10" role="tabpanel">
<div class="panel-body">
<div class="tabbs" style="overflow-x: auto;">
                        
                    <asp:DataGrid ID="dg_Atm" runat="server" AutoGenerateColumns="False" 
                                    AllowPaging="false"  BorderColor="Black"
                                  onitemdatabound="dg_Atm_ItemDataBound" 
                     onpageindexchanged="dg_Atm_PageIndexChanged" Width="100%">
                                <SelectedItemStyle />
                                <PagerStyle CssClass="vergridfooter" HorizontalAlign="Center" Mode="NumericPages"
                                    VerticalAlign="Bottom" Font-Size="14px" />
                                <Columns>
                                    <asp:BoundColumn DataField="Atm_ID" Visible="False"></asp:BoundColumn>
                                    <asp:TemplateColumn>
                                        <ItemStyle HorizontalAlign="center" CssClass="tbltd" />
                                       <HeaderStyle />
                                        <ItemTemplate>
                                        <div class="main-contentz">
                                        <div class="table-container">
                                           <%-- <table class="tabcontent1">--%>
                                             <table>
                                                <tr>
                                                    <th colspan="2" style="text-align: center">
                                                        <asp:Label ID="lblStatedistrict" runat="server" Text="" Font-Size="15px" Style="padding: 5px;
                                                            font-weight: bold"></asp:Label>
                                                    </td>
                                                </tr>
                                               
                                                <tr style="background: #f2f2f2;">
                                                    <td Width="60%">
                                                     
                                                        <asp:Label ID="lblAdd" runat="server"></asp:Label>
                                                    </td>
                                                    <td Width="40%">
                                                     <asp:Label ID="lbllocation" runat="server"></asp:Label>
                                                       <asp:Label ID="lblsite" runat="server" CssClass="label2"></asp:Label>
                                                        
                                                        
                                                    </td>
                                                   
                                                </tr>
                                            </table>
                                            </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <%---------------------------------------2-------------------------------%>
                                               <asp:BoundColumn DataField="State" HeaderText="" Visible="False"></asp:BoundColumn>
                                                <%---------------------------------------3-------------------------------%>
                                               <asp:BoundColumn DataField="District" HeaderText="" Visible="False"></asp:BoundColumn>
                                                <%---------------------------------------4-------------------------------%>
                                                <asp:BoundColumn DataField="Location" HeaderText="" Visible="False"></asp:BoundColumn>
                                                <%---------------------------------------5-------------------------------%>
                                                <asp:BoundColumn DataField="Address" HeaderText="" Visible="False"></asp:BoundColumn>
                                                 <%---------------------------------------6-------------------------------%>
                                               <asp:BoundColumn DataField="Type" HeaderText="" Visible="False"></asp:BoundColumn>
                                               
                                               

                                </Columns>
                            </asp:DataGrid>
                            </div>
</div>
</div>
</div>

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
                  </div></div>  
                  
</asp:Content>

