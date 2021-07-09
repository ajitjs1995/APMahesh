<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true"
    CodeFile="sale-notice.aspx.cs" Inherits="sales_notice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .calmonth
        {
            color: #fff;
            font-size: 11px;
            font-weight: bold;
            display: block;
            background: #c6027f; /* position: absolute; */
            text-align: center;
            text-transform: uppercase;
            line-height: 1;
            margin-top: 0; /* width: 45px; */ /* padding-top: 5px; */
            top: 3px;
            border-radius: 4px;
            -moz-border-radius: 4px; /* height: 50px; */
            padding: 10px 10px 10px 10px;
        }
        .calmonth .day
        {
            display: block; /* font-weight: bold; */
            font-size: 20px;
            text-indent: -3px;
            letter-spacing: -2px;
            color: #ffffff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="blog">
  <div class="blog container" style="width: 92%;">
    <div class="row">
      <div class="col-md-9">
        <h1>Sale Notice</h1>
       
        <div class="tabbs">
       
        Find the latest news worthy happenings at TMB. Get the latest upto date
        sale notice about sale of assets and other related information from us. Keep yourself
        updated about TMB with the detailed sale notice below.
        <br /><br />
        <div class="main-contentz">
          <div class="table-container">
            <asp:DataGrid ID="DgSalesNotice" runat="server"  AutoGenerateColumns="False" 
            CellPadding="3" CellSpacing="2" Font-Names="Century gothic" 
                  onitemdatabound="DgSalesNotice_ItemDataBound" 
                  onitemcommand="DgSalesNotice_ItemCommand" AllowPaging="True" 
                  onpageindexchanged="DgSalesNotice_PageIndexChanged">
            <SelectedItemStyle ForeColor="White"  />
            <ItemStyle Font-Size="14px" ForeColor="Black" HorizontalAlign="left" />
            <HeaderStyle BackColor="#18388C" Height="25px" HorizontalAlign="Center" CssClass="whitefont"
                VerticalAlign="Middle" Font-Size="14px" ForeColor="#FFFFFF" Font-Bold="False" />
            <PagerStyle CssClass="vergridfooter" HorizontalAlign="Center" Mode="NumericPages"
                VerticalAlign="Bottom" Font-Size="14px" />
            <Columns>
                <asp:BoundColumn DataField="AuctionDate" HeaderText="Auction Date" Visible="False"></asp:BoundColumn>
                <asp:TemplateColumn HeaderText=" Sr. No." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" Visible="false">
                    <HeaderStyle CssClass="tdpadding"  HorizontalAlign="Center" VerticalAlign="Middle"/>
                    <ItemStyle HorizontalAlign="Center" Width="50px"  VerticalAlign="Middle" />
                    <ItemTemplate>
                        <%#(DgSalesNotice.PageSize * DgSalesNotice.CurrentPageIndex) + Container.ItemIndex + 1%>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="AuctionDateTime1" HeaderText="Auction Date & Time"></asp:BoundColumn>
                <asp:BoundColumn DataField="AuctionOn" HeaderText="Place of Auction"></asp:BoundColumn>
                <asp:BoundColumn DataField="AssetLocation" HeaderText="Asset Location"></asp:BoundColumn>
                <asp:BoundColumn DataField="AssetType" HeaderText="Asset Type"></asp:BoundColumn>
                <asp:BoundColumn DataField="PropertyName" HeaderText="Borrower Name"></asp:BoundColumn>
                <asp:TemplateColumn HeaderText="File">
                    <ItemStyle HorizontalAlign="Center" Width="161px" VerticalAlign="Middle" />
                    <ItemTemplate>
            <%--<asp:ImageButton runat="server" ID="lnkNwsFile" CommandName="NwsFile" ImageUrl="~/images/view-button.png" CssClass="img-responsive"/>--%>
                        <asp:LinkButton ID="lnkReadMore" runat="server" CommandName="ReadMore" CssClass="">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/readmore-btn.png" CssClass="img-responsive"/>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="AuctionDateTime" HeaderText="Auction Date & Time" Visible="false"></asp:BoundColumn>
                                               
            </Columns>
        </asp:DataGrid>
          </div>
        </div>
        </div>
      </div>
      <div class="col-md-3 related-productsem" data-type="product">
        <div class="hp-main-box">
          <div class="main-white-box box-1 clearfix" style="background: #ececed; height: auto; border: none;"> 
          <img class="rel-img-right em-img lazyloaded" src="images/products1.jpg" style="width: 100%; height: auto;display: block; border-radius: 4px 4px 0 0;">
            <div class="details-box">
              <div class="hp-card-box">
                <h4 class="em-title share-comp-title" style="margin-top: 0px; min-height: 60px; background: transparent; border: none; color: #000; font-size: 21px;">Savings Account</h4>
              </div>
              <p class="link-box" style="display: none;"><a class="em-cta related-product-click-know-more" href="/en/personal-banking/accounts/savings-account/silk-woman-savings-account.html">Know More...</a></p>
              <div class="clearfix">
                <div class="FR MT15">
                  <div class="share-box">
                    <div class="share-positon-box clearfix">
                      <div class="share-bubble white">&nbsp;</div>
                    </div>
                  </div>
                </div>
                <a class="btn btn-primary em-cta related-product-click-apply" href="https://www.tmbnet.in/tmbankonline/" target="_blank">Apply Now</a> </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>
</asp:Content>
