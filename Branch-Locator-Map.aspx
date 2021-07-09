<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true"
    CodeFile="Branch-Locator-Map.aspx.cs" Inherits="Branch_Locator_Map" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<style>
        .td1
        {
            padding: 12px;
        }
        .td2
        {
            color: Black !important;
        }
        .h44
        {
            font-size: 18px;
            color: White !important;
            height: 40px;
            padding: 12px;
        }
        .address
        {
            font-size: 14px;
            padding-left: 0.8em;
        }
        #Btnsrch
        {
            padding-left: 1em;
            padding-right: 1em;
        }
        .form-control
        {
            display: inline-block;
            margin-left: -193px;
            padding: 8px 11px;
            height: 40px;
        }
        .btn
        {
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
            height: 36px !important;
        }
        
        
        
        input[placeholder]
        {
            font-size: 18px;
            height: 42px;
        }
        
        .mydropdownlist
        {
            color: #333333;
            font-size: 14px;
            padding: 5px 10px;
            border-radius: 17px;
            background-color: #fff; /*font-weight: bold;*/
        }
    </style>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBKvQDDRBNPS-T3cuJL8t4-nIh2EkQprvg"></script>
    <script type="text/javascript">
    var markers = [
    <asp:Repeater ID="rptMarkers" runat="server">
    <ItemTemplate>
             {
                "title": '<%# Eval("Name") %>',
                "lat": '<%# Eval("Latitude") %>',
                "lng": '<%# Eval("Longitude") %>',
                "description": '<%# Eval("Description") %>'
            }
           
    </ItemTemplate>
    <SeparatorTemplate>
        ,
    </SeparatorTemplate>
    </asp:Repeater>
    ];
    </script>
    <script type="text/javascript">

        window.onload = function () {
            var mapOptions = {
                center: new google.maps.LatLng(-34, 151),
                zoom: 8,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var infoWindow = new google.maps.InfoWindow();
            var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);
            for (i = 0; i < markers.length; i++) {
                var data = markers[i]
                var myLatlng = new google.maps.LatLng(data.lat, data.lng);
                var marker = new google.maps.Marker({
                    position: myLatlng,
                    map: map,
                    title: data.title
                });
                (function (marker, data) {
                    google.maps.event.addListener(marker, "click", function (e) {
                        infoWindow.setContent(data.description);
                        infoWindow.open(map, marker);
                    });
                })(marker, data);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="blog container" style="width: 92%;">
        <div class="row">
            <div class="col-md-9">
                <h1>
                    Branch Locator</h1>
                <p>
                    <asp:Label ID="msg" runat="server" Text=""></asp:Label>
                </p>
                <div class="tabContainer">
                    <p style="text-align: center;">
                        <asp:Label ID="LblError" runat="server" Text=""></asp:Label>
                    </p>
                    <div class="panel">
                        <div class="panel-body" style="box-shadow: 1px 3px 8px 2px rgba(125, 123, 123, 0.75);
                            background: #e6e5e6; padding: 20px;">
                            <form id="Form1" method="post" onsubmit="return false;" enctype="multipart/form-data"
                            autocomplete="off">
                            <div class="col-l-5" style="left: 20%;">
                                <div class="col-md-12">
                                   
                                                <strong style="vertical-align: baseline; color: #c6007e;">Select State</strong>
                                                <asp:DropDownList ID="stt" runat="server" OnSelectedIndexChanged="state_selection"
                                                    AutoPostBack="true" AppendDataBoundItems="true" CssClass="mydropdownlist">
                                                </asp:DropDownList>
                                          
                                    </div>
                                    <div class="col-md-5">
                                       
                                                <strong style="vertical-align: baseline; color: #c6007e;">Select District</strong>
                                                <asp:DropDownList ID="ctyy" runat="server" AutoPostBack="false" AppendDataBoundItems="true" CssClass="mydropdownlist">
                                                </asp:DropDownList>
                                            
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Button ID="Btnsrch" runat="server" Text="Search" CssClass="btn" 
                                            onclick="Button1_Click" />
                                        <asp:Button ID="btnreset" runat="server" Text="Reset" CssClass="btn" OnClick="btnreset_Click" /></div>
                                </div>
                            
                            <%--  <asp:Button ID="Button3" runat="server" Text="View All" class="buttons-submits" OnClick="BtnView_Click" /><br/><br/>--%>
                            <div id="dvMap" style="width: 500px; height: 500px"></div>
                            </form>
                        </div>
                    </div>
                    <br />
                   
                </div>
            </div>
            <div class="col-md-3 related-products em" data-type="product">
                <div class="hp-main-box">
                    <div class="main-white-box box-1 clearfix" style="background: #ececed; height: auto;
                        border: none;">
                        <img class="rel-img-right em-img lazyloaded" srcset="images/TractorLoan.jpg" style="width: 100%;
                            height: auto; display: block; border-radius: 4px 4px 0 0;">
                        <div class="details-box">
                            <div class="hp-card-box">
                                <h4 class="em-title share-comp-title" style="margin-top: 0px; min-height: 60px; background: transparent;
                                    border: none; color: #000; font-size: 21px;">
                                    TMB Tractor Loan</h4>
                            </div>
                            <div class="clearfix">
                                <a class="" href="/tractor.aspx">
                                    <img src="images/morebtn.png"></a></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>    
</asp:Content>
