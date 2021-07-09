<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="Online-Aadhar-Enrolment-Ack.aspx.cs" Inherits="Online_Aadhar_Enrolment_ACK" %>

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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <section id="blog">
        <div class="blog container" style="width: 92%;">
            <div class="row">
                <div class="col-md-9">
                    <h1 style="color: #ce1c7b; font-size: 28px;">Online Aadhar Enrolment Acknowledgement</h1>
                    <div class="tabbs">

                        <div class="applynow-outer">
                            <div class="col-md-12">
                                Dear 
                                        <asp:Label ID="lblName" runat="server">lblName</asp:Label>,
                            </div>
                        </div>
                        <div style="height: 30px"></div>
                        <div class="applynow-outer">
                            <div class="col-md-12">Greetings from Tamilnad Mercantile Bank Ltd ! </div>
                        </div>
                        <div style="height: 30px"></div>
                        <div class="applynow-outer">
                            <div class="col-md-12">
                                Your Aadhar Enrolment Online Request was well recveived. The tracking number for this request is :<strong>
                                    <asp:Label ID="lblId" runat="server">lblId</asp:Label></strong>.
                                <br />
                                Additionally, an email copy of this Aadhar Enrolment Online Request was also sent to yot email account. we will revert back to you regarding this request as soon as possible.<br />
                                Your Patience till then is appreciated.  

                            </div>
                        </div>
                        <div style="height: 30px"></div>                     
                        <div style="height: 30px"></div>  
                        <div class="applynow-outer">
                            <div class="col-md-12">Thanking You,</div>
                        </div>

                        <div style="height: 30px"></div>
                        <div class="applynow-outer">
                            <div class="col-md-12">Webmaster</div>
                        </div>
                        <div style="height: 30px"></div>
                        <div class="applynow-outer">
                            <div class="col-md-12">Tamilnad Mercantile Bank Ltd.</div>
                        </div>
                        <div style="height: 30px"></div>

                    </div>

                </div>
               
            </div>
        </div>

    </section>


</asp:Content>

