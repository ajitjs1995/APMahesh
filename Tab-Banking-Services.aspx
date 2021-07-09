<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="Tab-Banking-Services.aspx.cs" Inherits="Tab_Banking_Services" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
    <script type="text/javascript">
        javascript: window.history.forward(1);
        function isNumberKey(evt) {

            javascript: window.history.forward(1);
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
                    <h1 style="color: #ce1c7b; font-size: 28px;">Tab Banking Services</h1>
                    <h4>Dear Customer,</h4>

                    Thank you for your interest in having a relationship with TMB. It is our endeavour to provide our customers the best possible services using the latest in technology. Please input the following details and we will connect you with one of our branch / field executives to interact and attend to your request.
Thank you once again.

                    <div class="tabbs">

                        <p>
                            <asp:Label ID="LblError" runat="server" ForeColor="Red" Text=""></asp:Label>
                        </p>


                        <div class="form-group">
                            <label for="">Name:</label>
                            <asp:TextBox ID="txtname" TabIndex="1" runat="server" onkeypress="return isalphaKey(event)" class="form-control" AutoComplete="off"></asp:TextBox>
                        </div>



                        <div class="form-group">
                            <label for="">Mobile No :</label>
                            <asp:TextBox ID="txtphone" runat="server" MaxLength="10" TabIndex="2" class="form-control" onkeypress="return isNumberKey(event)" AutoComplete="off"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="">Email Address :</label>
                            <asp:TextBox ID="txtemail"
                                runat="server" class="form-control" TabIndex="3" AutoComplete="off"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="">Location:</label>
                            <asp:TextBox ID="txtLocation" runat="server" TabIndex="4" class="form-control" AutoComplete="off"></asp:TextBox>
                        </div>

                        <div class="col-lg-12" style="margin-bottom: 30px; margin-left: -25px">
                            <div class="col-lg-4">
                                <cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="6"
                                    CaptchaHeight="40" CaptchaWidth="200" CaptchaMinTimeout="5" CaptchaMaxTimeout="240"
                                    FontColor="#000000" NoiseColor="#B1B1B1" />
                            </div>
                            <div class="col-lg-4" style="width: 100px">
                                <asp:ImageButton ID="ImageButton1" TabIndex="5" ImageUrl="images/refresh.png" runat="server" CausesValidation="false" Width="40px" />
                            </div>
                            <div class="col-lg-4" style="width: 300px">
                                <label for="email">Enter the code from the image here:</label>
                                <asp:TextBox ID="txtCaptcha" AutoComplete="off" runat="server" TabIndex="6" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Button ID="Btnsave" runat="server" Text="Submit" OnClick="Btnsave_Click" TabIndex="7" class="btn btn-primary em-cta related-product-click-apply" />&nbsp;
               <asp:Button ID="BtnReset" runat="server" Text="Reset" OnClick="BtnReset_Click" TabIndex="8" class="btn btn-primary em-cta related-product-click-apply" />
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

