<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="Online-Aadhaar-Enrolment.aspx.cs" Inherits="Online_Aadhaar_Enrolment" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <section id="blog">
        <div class="blog container" style="width: 92%;">
            <div class="row">
                <div class="col-md-9">
                    <h1>Aadhar Enrolment</h1>

                    <div class="tabbs">
                        <h4>Online Request for an Appointment for Aadhaar Enrolment / Updation</h4>
                        Customers can use the form below to ask us your queries / request an appointment for Aadhaar Enrolment.
                        <p>&nbsp;</p>
                        <p>
                            <asp:Label ID="lblerror" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </p>
                        <div class="form-group">
                            <label for="">
                                Select Branch :</label>
                            <asp:DropDownList ID="ddlBranch" runat="server" class="form-control">
                            </asp:DropDownList>

                        </div>
                        <div class="form-group">
                            <label for="">Name:</label>
                            <asp:TextBox ID="txtName" runat="server" onkeypress="return isalphaKey(event)" class="form-control" AutoComplete="off"></asp:TextBox>
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
                                <asp:ListItem Value="0">choose appropriate subject</asp:ListItem>
                                <asp:ListItem Value="1">Online Request for an Appointment</asp:ListItem>
                                <asp:ListItem Value="2">Ask Questions for Aadhar Enrolment</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="">Message:</label>
                            <asp:TextBox ID="txtMessage" runat="server" Rows="7" AutoComplete="off" TextMode="MultiLine" Style="resize: none" class="form-control"></asp:TextBox>
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
                    <p>&nbsp;</p>
                    <h4 style="color: #ce1c7b; font-size: 28px;">Aadhaar Enrolment / Updation Process</h4>

                    Tamilnad Mercantile Bank has started the Aadhaar Enrolment / Updation activity through it's designated branches across India.
                    Please check below to know the list of branches. Residents can visit these branches for Aadhaar Enrolment / Updation. 
                    Customers may also use the Online Request for Appointment Form referred above to complete the Aadhaar Enrolment quickly.
                     

                    <h4>Download the List of Aadhaar Enrolment / Updation Centres</h4>

                    <div class="listing">
                        <ul>
                            <li><a href="/doc/aadhaar_enrolment_branches_01.pdf" target="_blank" rel="noopener" title="Click Here to Download">Region wise List of Aadhaar Enrolment / Updation Centres (Branches)</a></li>
                        </ul>
                    </div>

                    <h4>Accepted List of Aadhaar Enrolment / Updation Documents</h4>

                    <div class="listing">
                        <ul>
                            <li><a href="/doc/aadhaar_enrolment_documents_01.pdf" target="_blank" rel="noopener" title="Click Here to Download">Accepted List of Aadhaar Enrolment / Updation Documents - Carry Originals to Branch / Centr</a></li>
                        </ul>
                    </div>

                    <h4>Aadhaar Enrolment Form</h4>

                    <div class="listing">
                        <ul>
                            <li><a href="/doc/aadhaar_enrolment_form_01.pdf" target="_blank" rel="noopener" title="Click Here to Download">Click Here to Download the Aadhaar Enrolment Form</a></li>
                        </ul>
                    </div>

                    <h4>Aadhaar Updation Form</h4>

                    <div class="listing">
                        <ul>
                            <li><a href="/doc/aadhaar_enrolment_form_02.pdf" target="_blank" rel="noopener" title="Click Here to Download">Click Here to Download the Aadhaar Updation Form</a></li>
                        </ul>
                    </div>

                    <h4>Charges</h4>
                    <h3>Aadhaar Enrolment: Aadhaar Enrolment is FREE for residents</h3>
                    <div class="main-contentz">
                        <div class="table-container tblscroll">
                            <table border="0">
                                <thead>
                                    <tr>
                                        <th><strong>Description</strong></th>
                                        <th><strong>Charges</strong></th>
                                    </tr>
                                    <tr>
                                        <td>Demographic Update (Any Type / Any Channel)</td>
                                        <td>Rs. 29.00</td>
                                    </tr>
                                    <tr>
                                        <td>Other Biometric Update</td>
                                        <td>Rs. 29.00</td>
                                    </tr>
                                    <tr>
                                        <td>Aadhaar Search using eKYC / Find Aadhaar using Any Other Tool</td>
                                        <td>Rs. 11.00</td>
                                    </tr>
                                    <tr>
                                        <td>B/W print out on A4 sheet</td>
                                        <td>Rs. 11.00</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">* Inclusive of GST Charges at 18%.</td>
                                    </tr>

                                </thead>
                            </table>
                        </div>
                    </div>
                    <h4>How to check Aadhaar Enrolment / Updation status</h4>
                    <div class="listing">
                        <ul>
                            <li>UIDAI has provided following channels for residents to check their Aadhaar Enrolment / Updation status.
                                <ul>
                                    <li>UIDAI Help Line Number: <a href="tel:+1947" title="Click to Call (Mobile Browsers Only)">1947</a></li>
                                    <li>UIDAI Email Address: <a href="mailto:help@uidai.gov.in">help@uidai.gov.in</a></li>
                                    <li>UIDAI Website: <a href="resident.uidai.gov.in" target="_blank">resident.uidai.gov.in</a></li>
                                </ul>
                            </li>

                        </ul>

                    </div>
                </div>

                <div class="col-md-3 related-products em" data-type="product">
                    <div class="hp-main-box">
                        <div class="main-white-box box-1 clearfix" style="background: #ececed; height: auto; border: none;">
                            <img class="rel-img-right em-img lazyloaded" src="images/products1.jpg" style="width: 100%; height: auto; display: block; border-radius: 4px 4px 0 0;" />
                            <div class="details-box">
                                <div class="hp-card-box">
                                    <h4 class="em-title share-comp-title" style="margin-top: 0px; min-height: 60px; background: transparent; border: none; color: #000; font-size: 24px;">Savings Account</h4>

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

