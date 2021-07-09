<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="Online-Feedback-Form.aspx.cs" Inherits="Online_Feedback_Form" %>

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
     <%--<img src="InnerBanner/Banner/Write-to-Us-Feedback.jpg" alt="Write-to-Us-Feedback.jpg" class="img-responsive">--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <section id="blog">
        <div class="blog container" style="width: 92%;">
            <div class="row">
                <div class="col-md-9">
                    <h1 style="color: #ce1c7b; font-size: 28px;">Submit your feedback</h1>


                    Thank you for choosing to send us your valuable feedback.

                    You are encouraged to use the online feedback form below to send us your valuable comments and suggestions as well as any queries about our products and services that you may have. You may also email your queries / feedback / suggestions. All feedback received are fully responded in a timely manner. Your patience in getting our reply is most appreciated. We look forward to your feedback today.

                    <div class="tabbs">
                        <p>
                            <asp:Label ID="lblerror" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </p>

                        <div class="form-group">
                            <label for="">Name:</label>
                            <asp:TextBox ID="Txtname" runat="server" onkeypress="return isalphaKey(event)" class="form-control" AutoComplete="off"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="">Address:</label>
                            <asp:TextBox ID="txtaddress" runat="server" class="form-control" AutoComplete="off" TextMode="MultiLine" Style="resize: none" Rows="2"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="">Mobile No:</label>
                            <asp:TextBox ID="Txtmob" runat="server" onkeypress="return isNumberKey(event)" class="form-control" AutoComplete="off" MaxLength="10"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="">Email:</label>
                            <asp:TextBox ID="Txtemail" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="">Subject:</label>
                            <asp:DropDownList ID="Ddlsub" runat="server" class="form-control">
                                <asp:ListItem Value="1">choose appropriate subject</asp:ListItem>
                                <asp:ListItem Value="2">Appericiations</asp:ListItem>
                                <asp:ListItem Value="3">comments and suggestions</asp:ListItem>
                                <asp:ListItem Value="4">errors and corrections</asp:ListItem>
                                <asp:ListItem Value="5">deposits schemes</asp:ListItem>
                                <asp:ListItem Value="6">domestic service</asp:ListItem>
                                <asp:ListItem Value="7">nri banking</asp:ListItem>
                                <asp:ListItem Value="8">loans</asp:ListItem>
                                <asp:ListItem Value="9">foreign exchange</asp:ListItem>
                                <asp:ListItem Value="10">enquiries</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="">Feedback:</label>
                            <asp:TextBox ID="Txtfeedback" runat="server" Rows="7" AutoComplete="off" TextMode="MultiLine" Style="resize: none" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="">
                                Select Branch & Give Full 15 Digit Acc. No.
(for existing customers):</label>
                            <asp:DropDownList ID="ddlBranch" runat="server" class="form-control"
                                OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtacc" runat="server" class="form-control" MaxLength="15" onkeypress="return isNumberKey(event)" Enabled="false"
                                AutoPostBack="true"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="">Send Copy of Email to Branch Manager?</label>
                            <asp:RadioButtonList ID="rdbcopy" runat="server" RepeatDirection="Horizontal" class="form-control" Style="margin-left: 4px;" Width="150px">
                                <asp:ListItem Selected="True" Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N">No</asp:ListItem>
                            </asp:RadioButtonList>
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
                                <asp:TextBox ID="Txtcaptch" AutoComplete="off" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Button ID="Btnsave" runat="server" Text="Send" class="btn btn-primary em-cta related-product-click-apply" OnClick="Btnsave_Click"></asp:Button>
                        <asp:Button ID="Button2" runat="server" Text="Reset" class="btn btn-primary em-cta related-product-click-apply" OnClick="Button2_Click"></asp:Button>


                    </div>


                </div>

             <div class="col-md-3 related-products em" data-type="product">
                        <div class="hp-main-box">
                            <div class="main-white-box box-1 clearfix" style="background: #ececed; height: auto; border: none;">
                                <img class="rel-img-right em-img lazyloaded" src="images/products1.jpg" style="width: 100%; height: auto; display: block; border-radius: 4px 4px 0 0;" />
                                <div class="details-box">
                                    <div class="hp-card-box">
                                        <h4 class="em-title share-comp-title" style="margin-top: 0px; min-height: 60px; background: transparent; border: none; color: #000; font-size: 24px;">Savings Account</h4>

                                       
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
                                        <a class="btn btn-primary em-cta related-product-click-apply" href="https://www.tmbnet.in/tmbankonline/" target="_blank">Apply Now</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
            </div>
        </div>
    </section>







</asp:Content>

