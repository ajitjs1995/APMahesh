<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="Unclaimed-Deposits.aspx.cs" Inherits="Unclaimed_Deposits" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


<link href='https://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css'/>


    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <link rel="stylesheet" href="css/style.css" type="text/css" media="screen">
    <link rel="stylesheet" href="css/vertical_menu.css" type="text/css" media="screen">
    <link rel="stylesheet" type="text/css" media="all" href="css/webslidemenu.css">
    <link rel="stylesheet" href="css/main.css" type="text/css">
    <link rel="stylesheet" href="css/homepage.css" type="text/css">
    <link rel="stylesheet" href="css/rates.css" type="text/css">
	<link rel="stylesheet" href="css/blog-style.css" type="text/css">
    <script type="text/javascript">     



        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        function isalphaKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode < 33 || charCode > 47 && charCode < 48 || charCode > 57) {
                return true;
            }
            return false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <section id="blog">
        <div class="blog container" style="width: 92%;">
            <div class="row">
                <div class="col-md-9">
                    <h1 style="color: #ce1c7b; font-size: 28px;">Un-Claimed Deposits</h1>
                    Account holders can search the details of unclaimed deposits / inoperative accounts for more than 10 years held in their name using the "Find" option. This database search is based on the list of un-claimed / in-operative deposit accounts for more than 10 years in our Bank (updated as on Jul 31, 2019).
                    <p></p>
                    <h4>TMB Unclaimed Deposits Account Search:</h4>
                    <div class="tabbs">
                        <div id="divForm" runat="server">
                            <p>Enter the A/c Name, choose the State and enter the Security Code in the form below to search. Fields marked [*] are mandatory.</p>
                            <p>
                                <asp:Label ID="LblError" runat="server" ForeColor="Red" Text=""></asp:Label>
                            </p>


                            <div class="form-group">
                                <label for="">A/c Name *</label>
                                <asp:TextBox ID="txtname" runat="server" onkeypress="return isalphaKey(event)" class="form-control" AutoComplete="off"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="">Address:</label>
                                <asp:TextBox ID="txtadd" runat="server" class="form-control" Style="resize: none" TextMode="MultiLine" Rows="2" AutoComplete="off"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="">City:</label>
                                <asp:TextBox ID="txtcity" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="">State *</label>
                                <asp:DropDownList
                                    ID="ddlstate" runat="server" class="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-12" style="margin-bottom: 30px; margin-left: -25px">
                                <div class="col-lg-4">
                                    <cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="6"
                                        CaptchaHeight="40" CaptchaWidth="200" CaptchaMinTimeout="5" CaptchaMaxTimeout="240"
                                        FontColor="#000000" NoiseColor="#B1B1B1" />
                                </div>
                                <div class="col-lg-4" style="width: 100px">
                                    <asp:ImageButton ID="ImageButton1" ImageUrl="images/refresh.png" runat="server" CausesValidation="false" Width="40px" />
                                </div>
                                <div class="col-lg-4" style="width: 300px">
                                    <label for="email">Enter the code from the image here:</label>
                                    <asp:TextBox ID="txtCaptcha" AutoComplete="off" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            
                            <asp:Button ID="Button1" runat="server" Text="Search" 
                                OnClick="BtnSerch_Click" class="btn btn-primary em-cta related-product-click-apply" />
                            <asp:Button ID="Button2" runat="server" Text="Reset"
                                OnClick="Btnreset_Click" class="btn btn-primary em-cta related-product-click-apply"  />


                        </div>
                        <div style="height: 15px"></div>
                        <div>
                            <asp:Label ID="lblmssg" runat="server" Text=""></asp:Label>
                        </div>
                        <div style="height: 15px"></div>
                        <div id="tr_details" runat="server" visible="false" class="table-responsive">
                            <asp:DataGrid ID="dg_Applications" Width="800px" runat="server" Style="color: black; font-size: 14px; height: 25px; border: Solid thin #cccccc"
                                AllowPaging="true" AutoGenerateColumns="False" Font-Names=" Open Sans" OnPageIndexChanged="dg_Applications_PageIndexChanged"
                                GridLines="both" CellSpacing="4" CellPadding="10" PageSize="10">
                                <HeaderStyle BackColor="#18388c" ForeColor="White" Height="25px" HorizontalAlign="Center"
                                    CssClass="" VerticalAlign="Middle" Font-Size="16px" />
                                <ItemStyle Height="10px" Width="50px" BackColor="White" Font-Size="13px" ForeColor="Black"
                                    HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                <AlternatingItemStyle Height="10px" CssClass="" BackColor="#f3f3f3" ForeColor="Black"
                                    HorizontalAlign="Left" VerticalAlign="Top" />
                                <PagerStyle Mode="NumericPages" HorizontalAlign="center" ForeColor="Blue" BackColor="White"
                                    VerticalAlign="middle" />
                                <Columns>
                                    <asp:BoundColumn DataField="ID" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                    <%-- ------------------------1--------------------%>
                                    <asp:TemplateColumn HeaderText="Sr.No.">
                                        <ItemStyle HorizontalAlign="Center" Width="5px" />
                                        <HeaderStyle Width="5px" />
                                        <ItemTemplate>
                                            <%#(dg_Applications.PageSize * dg_Applications.CurrentPageIndex) + Container.ItemIndex + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <%-- ------------------------3--------------------%>
                                    <asp:BoundColumn DataField="Name" HeaderText="Account Name" Visible="true">
                                        <ItemStyle Width="50px" HorizontalAlign="left" VerticalAlign="Middle" />
                                        <HeaderStyle Width="50px" />
                                    </asp:BoundColumn>
                                    <%-- ------------------------4--------------------%>
                                    <asp:BoundColumn DataField="Address" HeaderText="Address Details" Visible="True">
                                        <ItemStyle Width="300px" HorizontalAlign="left" VerticalAlign="Middle" />
                                        <HeaderStyle Width="300px" />
                                    </asp:BoundColumn>
                                </Columns>
                            </asp:DataGrid>
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
    </section>

</asp:Content>

