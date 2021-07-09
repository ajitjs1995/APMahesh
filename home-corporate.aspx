<%@ Register Src="~/TopcntrlBCBanking.ascx" TagPrefix="uc" TagName="Topcntrl" %>
<%@ Register Src="~/bottomcntrl.ascx" TagPrefix="uc" TagName="Bottomcntrl" %>

<html>
 <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">

        <link href="css/fonts.css" rel='stylesheet' type='text/css' />
        <link rel="stylesheet" href="css/main.css" type="text/css">
        <link rel="stylesheet" href="css/homepage.css" type="text/css">
        <link rel="stylesheet" href="css/animate.css">
        <script src="js/wow.min.js"></script>
        <script>
            new WOW().init();
        </script>
        <link rel="stylesheet" href="css/nli-index-custom.min.css" type="text/css">
        <script type="text/javascript" async="" src="js/ga.js"></script>
        <link rel="stylesheet" href="css/style.css" type="text/css" media="screen">
        <link rel="stylesheet" href="css/vertical_menu.css" type="text/css" media="screen">
        <link rel="stylesheet" type="text/css" media="all" href="css/webslidemenu.css">
        <link rel="stylesheet" href="css/rates.css">
             <link href="css/magnific-popup.css" rel="stylesheet">
        <script src="js/script.js"></script>
        <script src="js/magnific-popup.js"></script> 
        <link rel="stylesheet" type="text/css" href="engine1/style.css" />
       
        <link rel="stylesheet" type="text/css" media="all" href="css/rates.css">

        <link rel="stylesheet" href="css/homepage.min.css" type="text/css">
       
        <link rel="stylesheet" href="css/bannerCarousel.min.css" type="text/css">
        <link rel="stylesheet" href="css/blog-style.css" type="text/css">
        <link rel="stylesheet" href="css/footer.css" type="text/css">
        <link rel="stylesheet" type="text/css" media="all" href="css/stellarnav.css">
        <title>Tamilnad Mercantile Bank Limited</title>
		<head>
<style>
.fixed-header {
    position: fixed;
	    height: 91px;
    top: 0;
    left: 0;
    width: 100%; 
}

</style>
<script type="text/javascript">

    var iChars = "!@#$%^&*()+=-[]\\\';,./{}|\":<>?";

    function stripCharsInBag(s, bag) {
        for (var i = 0; i < document.getElementById("zoom_query").value.length; i++) {
            if (iChars.indexOf(document.getElementById("zoom_query").value.charAt(i)) != -1) {

                return false;
            }
            else return true;
        }
    }

    function check() {

        debugger;
        if (document.getElementById("zoom_query").value == "Looking for Something") {
            alert("Please enter value for search");
            document.getElementById("zoom_query").focus();
            return false;
        }
        else if (document.getElementById("zoom_query").value == "") {
            alert("Please enter value for search");
            document.getElementById("zoom_query").focus();
            return false;
        }
        else if (stripCharsInBag(document.getElementById("zoom_query").value, iChars) == false) {
            alert("You have entered special characters");
            document.getElementById("zoom_query").focus();
            return false;
        }
        else {

            window.location = "SearchPage.aspx?zoom_query=" + document.getElementById('zoom_query').value;
            return false;
        }


    }

</script>
<script type="text/javascript">

    function myFunction() {

        if (event.which == 13 || event.keyCode == 13) {

            if (document.getElementById("zoom_query").value == "Looking for Something") {
                alert("Please enter value for search");
                document.getElementById("zoom_query").focus();
                return false;
            }
            else if (document.getElementById("zoom_query").value == "") {
                alert("Please enter value for search");
                document.getElementById("zoom_query").focus();
                return false;
            }

            else {
                $('#btn').click();
                return false;
            }
        }

    }
   
 

</script>
<!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-157825538-1"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());

  gtag('config', 'UA-157825538-1');
</script>
        </head>

        <body>
		  <form id="form1" runat="server">
            <%--TOP CONTROLLER--%>
                <uc:Topcntrl runat="server" ID="ucTopcntrl" />
                <%--TOP CONTROLLER--%>
                    <div>

                        <div class="herosliderRandomLogic section">

                            <div class="popup-desktop"></div>

                              <div class="fixed_apply animated slideInLeft" style="visibility: visible;">
                               <div class="row">
                                    <div class="fa_box one"> <img src="images/deposit.png" alt="">
                                        <div><a href="https://www.tmbnet.in/OnlDepOpnCls/" target="_blank" style="color:#ffffff!important"> Deposit </a></div>
                                    </div>
									
                                    <div class="fa_box two"> <img src="images/loan.png" alt="">
                                        <div> <a href="https://www.tmbho.in/laps" target="_blank" style="color:#ffffff!important">Loans</a> </div>
                                    </div>
									
                                    <div class="fa_box three"> <img src="images/accounting.png" alt="">
                                        <div> <a href="https://www.tmbnet.in/crcrdonline/" target="_blank" style="color:#ffffff!important">Credit Card </a></div>
                                    </div>
									
                                     <div class="fa_box four"> <img src="images/saving-icon.png" alt="">
                                        <div> <a href="https://www.tmbnet.in/tmbankonline/" target="_blank" style="color:#ffffff!important">Savings </a></div>
                                    </div>
									
                                    <a href="javascript:void(0);" class="fa_box link" id="applynowlink"> <img src="images/apply-now.png" alt="equitas login"> </a>
                                </div>
                            </div>

                            <div class="fl-sl">
                                <div class="sl-im"><img src="images/Interest-strip-1.png" class="img-fluid" alt=""></div>
                                <div class="box">
                                    <div class="bx-head">
                                      
                                        <h1>
										MCLR / Deposit<br>
										Interest Rate </h1>
                                    </div>
                                    
                                    <div class="in-box iblne">
                                        <div class="inb1">
										<span style="font-size:15px; color:#c6007c">1year MCLR</span>
										<h1>8.95%</h1>
				  
                                         
                                            <span><a href="rates-at-a-glance.aspx"><img src="images/knowmore.png"  style="display:block!important; margin: auto;" align="center"></a></span>
										</div>
                                    <div class="inb1">
									<span style="font-size:15px; color:#c6007c">1year Deposit</span>
									<h1>6.10%</h1>
                                 
                                        <span><a href="deposit-interest-rates.aspx"><img src="images/knowmore.png"  style="display:block!important; margin: auto;" align="center"></a></span>
								</div></div>
                                    
                                </div>
                            </div>

                            <!-- Start WOWSlider.com BODY section -->
                            <div id="wowslider-container1">
                                <div class="ws_images">
                                    <ul>
	<li><img src="images/corporate1.jpg" alt="8" title="" id="wows1_3" class="img-responsive" /></li>
	<li><img src="images/corporate2.jpg" alt="8" title="" id="wows1_3" class="img-responsive" /></li>
	<li><img src="images/corporate3.jpg" alt="8" title="" id="wows1_3" class="img-responsive" /></li>
	<li><img src="images/corporate4.jpg" alt="8" title="" id="wows1_3" class="img-responsive" /></li>
	<li><img src="images/corporate5.jpg" alt="8" title="" id="wows1_3" class="img-responsive" /></li>
	<li><img src="images/corporate6.jpg" alt="8" title="" id="wows1_3" class="img-responsive" /></li>
	<li><img src="images/corporate7.jpg" alt="8" title="" id="wows1_3" class="img-responsive" /></li>
	<li><img src="images/corporate8.jpg" alt="8" title="" id="wows1_3" class="img-responsive" /></li>
	<li><img src="images/corporate9.jpg" alt="8" title="" id="wows1_3" class="img-responsive" /></li>                                     
                                    </ul>
                                </div>
                             <!--    <div class="ws_bullets">
                                    <div> <a href="#" title=""><span>1</span></a> 
									<a href="#" title=""><span>2</span></a> 
									<a href="#" title=""><span>3</span></a> 
									<a href="#" title=""><span>4</span></a> 
									<a href="#" title=""><span>5</span></a> 
									<a href="#" title=""><span>6</span></a> 
									<a href="#" title=""><span>7</span></a> 
									<a href="#" title=""><span>8</span></a> 
									<a href="#" title=""><span>9</span></a> 
									</div>
                                </div> -->
                                <div class="ws_shadow"></div>
                            </div>

                            <!-- End WOWSlider.com BODY section -->
	<link rel="stylesheet" type="text/css" href="engine1/style.css" />
	<script type="text/javascript" src="engine1/jquery.js"></script>
	<script type="text/javascript" src="engine1/wowslider.js"></script>
	<script type="text/javascript" src="engine1/script.js"></script>
		
                             <div class="col-md-12" style="background-image: url(images/bg-line.jpg);
    background-repeat: repeat-x;
    height: 8px; margin-top: -13px;"></div>
                        </div>
                    </div>

                    <div class="customHomeComp section">

                        <div class="containerwrapper">
                            <div class="container">
                                <div class="universalbankwrapper">

                                    <div class="tabTitleContainer investorrelations">
                                        <div class="tab_content" id="personal">

                                            <div>
                                                <div class="gray-box">

                                                    <div class="gray-carosel owl-carousel">

                                                    
                                                        <div class="item">
                                                            <figure><img src="images/loan-icon.png" alt=""></figure>
                                                            <p>Loans </p>
                                                           
                                                            <p class="MT10"><a href="https://www.tmbho.in/laps" target="_blank" class="link">Apply Online </a></p>
                                                        </div>

															<div class="item">
													<figure><img src="images/bbps.png" alt=""></figure>
													<p>Bharath Bill Pay</p>
													<p class="MT10"><a href="https://pgi.billdesk.com/pgidsk/pgmerc/instpy/TMBBBPSIndex.jsp" target="_blank" class="link">Pay Now </a></p>
													</div>
													
													
                                                        <div class="item">
                                                            <figure><img src="images/etax-icon.png" alt=""></figure>
                                                            <p>E-tax Payment </p>
                                                           
                                                            <p class="MT10"><a href="https://www.billdesk.com/pgmerc/tmbtax/" class="link" target="_blank">Know More </a></p>
                                                        </div>

                                                        <div class="item">
                                                            <figure><img src="images/onlinebill-icon.png" alt=""></figure>
                                                            <p>Online Bill Payment </p>
                                                          
                                                            <p class="MT10"><a href="https://www.tmbnet.in/collapsible2.html" target="_blank" class="link">Pay Now</a></p>
                                                        </div>

                                                        <div class="item">
                                                            <figure><img src="images/pos-icon.png" alt=""></figure>
                                                            <p>POS Terminals </p>
                                                           
                                                            <p class="MT10"><a href="pos-terminals.aspx" target="_blank" class="link">Know More </a></p>
                                                        </div>
														
														
															<div class="item">
                                                            <figure><img src="images/card-icon.png" alt=""></figure>
                                                            <p>My Delight Card </p>
                                                           
                                                            <p class="MT10"><a href="https://www.tmbnet.in/onlinecarddesign/" class="link" target="_blank">Upload </a></p>
                                                        </div>

														
															<div class="item">
                                                            <figure><img src="images/deposit-icon.png" alt=""></figure>
                                                            <p>Fixed Deposit </p>
                                                           
                                                            <p class="MT10"><a href="https://www.tmbnet.in/OnlDepOpnCls/" class="link" target="_blank">Open Now  </a></p>
                                                        </div>
														
														
													<div class="item">
													<figure><img src="images/edu-icon.png" alt=""></figure>
													<p>Education Fee Payments </p>
													<p class="MT10"><a href="https://www.tmbnet.in/tmbfeepay/" target="_blank" class="link">Pay Now </a></p>
													</div>
	
													

													<div class="item">
													<figure><img src="images/mobbnk-icon.png" alt=""></figure>
													<p>TMB Mobile Banking </p>
													
													<p class="" style="display: flex;"><a href="https://play.google.com/store/apps/details?id=com.fss.tmb" target="_blank" class=""><img src="images/android-icon.png"/></a>
													
													<a href="https://www.microsoft.com/en-us/p/tmb-mconnect/9nblggh4rvmd" target="_blank" class=""><img src="images/windows-icon.png"/></a>
													
													<a href="https://itunes.apple.com/us/app/tmb-mconnect/id1074171088?mt=8" target="_blank" class=""><img src="images/apple-icon.png"/></a></p>
													</div>													
													
													<div class="item">
													<figure><img src="images/passbook-icon.png" alt=""></figure>
													<p>TMB Epassbook  </p>
													<p class="" style="display: flex;"><a href="https://play.google.com/store/apps/details?id=com.mobile.tmbepassbook" target="_blank" class=""><img src="images/android-icon.png"/></a>
													
													<a href=" https://www.windowsphone.com/en-in/store/app/tmb-epassbook/38f1c359-7e8e-4b4b-ab15-84e4c6353f9f" target="_blank" class=""><img src="images/windows-icon.png"/></a>
													
													<a href="https://apps.apple.com/us/app/tmb-epassbook/id901809079?ls=1" target="_blank" class=""><img src="images/apple-icon.png"/></a></p>
													</div>
													
															<div class="item">
													<figure><img src="images/card-icon.png" alt=""></figure>
													<p>TMB M Wallet </p>
														<p class="" style="display: flex;"><a href="https://play.google.com/store/apps/details?id=com.gi.tmb" target="_blank" class=""><img src="images/android-icon.png" align="center"/></a>
													
													</p>
													</div>	
														
														
                                                    </div>
                                                </div>

                                            </div>

                                        </div>

                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>
  <script type="text/javascript" src="js/homepage.min.js"></script>
                    <div class="customHomeComp section"  style="margin-top: 5%;">

                        <div class="containerwrapper">
                            <div class="container">
                                  <div class="universalbankwrapper">

                                    <div data-os-animation="fadeInUp" data-os-animation-delay="0s" style="animation-delay: 0s;">
                                        <div class="col-md-4 col-sm-4 col-xs-12">
										
                                            <div class="background">
											 <div style="margin-left: 2%;">
                                                <h2 style="color: #fff; font-weight: 700; font-size:20px!important"></br>
              
              Customer Testimonials</h2>

                                                <div class="content">
                                                    <div class="clearfix text-formatted field field--name-body field--type-text-with-summary field--label-hidden field__item">
                                                        <p style="color:#ffffff; margin: 0 5px 0 5px!important; font-size:15px"><em></br>We are banking with TMB since the last 20 years</br> and have been a profit making and growing</br> concern ever since. Many thanks to the continued </br>support and co-operation extended by the bank.</em></p>
                                                        <a class="choose-card" href="customer-testimonials.aspx" style="padding: 5px 10px;
    border: 2px solid #fff;
    color: #fff;
    border-radius: 5px;
    font-size: 12px;
    display: inline-block;
    margin-top: 21px;">VIEW DETAILS</a></div>
                                                </div>
												</div>
                                            </div>
                                        </div>
										
										  <div class="col-md-5 col-sm-4 col-xs-12">
										                                              
                                              
                                                  <a href="https://www.tmbnet.in/onlinecarddesign/" target="_blank"> <img src="images/tmb-delightcard.png" class="img-responsive1"/></a>
                                                
                                           </a>
                                        </div>
										
                                        <div class="col-md-3 col-sm-4 col-xs-12" style="margin-left: -1%;">
                                            <div class="copybox  hp-main-box111 stretch">
                                                <div class="guidance-container">
                                                    <h2 style="color:#ffffff; font-size: 22px; margin-top: 23px"> Latest News </h2>
                                                    </br>
   <marquee behavior="scroll" direction="up" height="130px" scrolldelay="10" scrollamount="2" onMouseOut="this.start();" onMouseOver="this.stop();">
                                                       <ul>
<!--<li><a href="" target="_blank" style="color:#ffffff"><img src="../images/new.gif"></a></li><br>-->
<li><a href="https://www.tmb.in/basel-disclosures.aspx" target="_blank" style="color:#ffffff">Basel III Disclosures<img src="../images/new.gif"></a></li><br>

<li><a href="https://www.tmb.in/doc/P2020062501.pdf" target="_blank" style="color:#ffffff">Financial results for the year ended 31.03.2020<img src="../images/new.gif"></a></li><br>
<li><a href="annual-general-meetings.aspx" style="color:#ffffff" target="_blank">Notice for Annual General Meeting 2020</a></li><br>													   
 <!--<li><a href="financial-performance-highlights.aspx" style="color:#ffffff">Financial results for quarter ended 31.12.2019</a></li>-->
 
                                                        </ul>
                                                    </marquee>
                                                </div>
                                            </div>
                                          
                                        </div>
                                    </div>
                                </div>
                                 <div class="universalbankwrapper">
                                    <div data-os-animation="fadeInUp" data-os-animation-delay="0s" style="animation-delay: 0s;">
                                        <div class="col-md-4 col-sm-4 newsbg">
                                                        <div class="col-md-12 newss" style="background-image: url(../images/noticebg.jpg);"><br>
                                                            <h3 style="color:#f5d657; font-size: 20px!important;">Sale Notice</h3>
                                                           
                                                            
                                                                <div class="hp-main-box11 offer-box-2 section wow flipInX col-md-12" data-wow-duration="2s" data-wow-delay="1s">
                                                                    </br>
                                                                  <!--   <p class="alignment" style="color:#ffffff; text-align: center;">Nov 08, 2019</p> -->
                                                                   
                                                                    <p class="alignment" style="color:#ffffff; text-align: center;">Sale of Property through Public Auction</p>
                                                                    </br>
                                                                    <p class="alignment" style="color:#f5d657;  text-align: center;"><a href="sale-notice.aspx"> Read more...<a></p>
                                                                </div>
                                                          
                                                        </div
                                        ></div>
                                       
                                    </div>
									   <div class="col-md-8 col-sm-7 col-xs-12 products" style="background: #ebecef;">
                                            <h2 class="spielbox" style="text-decoration:none"> Key Products </h2>
                                            <div class="brow">
                                                <div class="col-lg-4 col-sm-4">
                                                    <div class="single-blog">
                                                     
                                                            <div class="blog-content">
                                                                <div class="blog-img">
                                                                <img class="full-width zoom" alt="" src="images/MSME-Loan1.jpg"></div>
                                                                <div class="blog-text">
                                                                    <h4 class="char-65"><a href="tmb-msme.aspx" class="producttext" style="color:#c60180; text-decoration: none;">MSME Loan</a></h4>
                                                                </div>
                                                            </div>
                                                        

                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-sm-4">
                                                    <div class="single-blog">
                                                      
                                                            <div class="blog-content">
                                                                <div class="blog-img">
                                                                    <img class="full-width zoom" alt="" src="images/business-loan.jpg"></div>
                                                                <div class="blog-text">
                                                                    <h4 class="char-65"><a href="tmb-traders.aspx" style="color:#c60180; text-decoration: none;">TMB Traders & Services Loan</a></h4>
                                                                </div>
                                                            </div>
                                                      
                                                    </div>
                                                </div>
                                                <div class="col-lg-4 col-sm-4">
                                                    <div class="single-blog">
                                                       
                                                            <div class="blog-content"> 
                                                                <div class="blog-img zoom">
                                                                    <img class="full-width" alt="" src="images/TMB-Commercial-Vehicle.jpg"></div>
                                                                <div class="blog-text">
                                                                    <h4 class="char-65"><a href="commercial-vehicle-finance.aspx" style="color:#c60180; text-decoration: none;">TMB Commercial Vehicle</a></h4>
                                                                </div>
                                                            </div>
                                                       
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                </div>
                                </section>
                            </div>
                                </section>
                            </div>
                        </div>

                           <div class="middleContainer fourNavContainer clearfix">
                            <ul class="fourNav clearfix">
                                <li class="col-xs-6">
                                    <a class="hcplfix" href="https://www.tmbnet.in/" target="_blank">
                                        <div>
                                            <img src="images/DisplayImage_InternetBanking.png" class="" style="display: inline;"></div>
                                        <div>
                                            <h1>Internet Banking</h1>
                                            <br><p class="cont text-center">Your Time is precious. TMB Knows time value of your hard earned money management. Enjoy the way you Bank.</p></div>
                                    </a>
                                </li>
                                <li class="col-xs-6">
                                    <a class="hcplfix" href="mobile-banking.aspx">
                                        <div>
                                            <img src="images/DisplayImage_MobileBanking.png" class="" style="display: inline;"></div>
                                        <div>
                                            <h1>Mobile Banking</h1>
                                            <br><p class="cont text-center">Be delighted every moments of your life!. Just transact on your Mobile Phone wherever & whenever at your convenience.</p></div>
                                    </a>
                                </li>
                                <li class="col-xs-6">
                                    <a class="hcplfix" href="nearest-branch-atm.aspx">
                                        <div>
                                            <img src="images/DisplayImage_Facebook.png" class="" style="display: inline;"></div>
                                        <div>
                                            <h1>Branch & ATM Locations near you</h1>
                                            <br> <p class="cont text-center">Use Branch and ATM locator to connect to TMB's Banking Services.</p></div>
                                    </a>
                                </li>
                                <li class="col-xs-6">
                                    <a class="hcplfix" href="Tab-Banking-Services.aspx">
                                        <div>
                                            <img src="images/DisplayImage_AtmBanking.png" class="" style="display: inline;"></div>
                                        <div>
                                            <h1>Tab Banking</h1>
                                            <br><p class="cont text-center">New Bank Account opening at your doorstep. TMB TAB Banking transforms the way you bank never dreamed of!</p></div>
                                    </a>
                                </li>

                            </ul>
                        </div>
                        <div class="icon-bar">
                            <img src="images/ways.png" />
                        </div>

                        <%--BOTTOM CONTROLLER--%>
                            <uc:Bottomcntrl runat="server" ID="ucBottomcntrl" />
                            <%--BOTTOM CONTROLLER--%>

                                <script type="text/javascript" src="js/utils.min.js"></script>
                                <script type="text/javascript" src="js/main.js"></script>
                                

                                 <script>
                                    $(document).ready(function() {
                                        $(".close_social").mouseover(function() {
                                            $(".fixed_social").removeClass("on")
                                        });
                                        $("#go_fb").mouseover(function() {
                                            $("#li_social_two").removeClass("active");
                                            $("#li_social_three").removeClass("active");
                                            $("#li_social_one").addClass("active");
                                            $(".fixed_social").addClass("on")
                                        });
                                        $("#go_tw").mouseover(function() {
                                            $("#li_social_one").removeClass("active");
                                            $("#li_social_three").removeClass("active");
                                            $("#li_social_two").addClass("active");
                                            $(".fixed_social").addClass("on")
                                        });
                                        $("#go_yt").mouseover(function() {
                                            $("#li_social_two").removeClass("active");
                                            $("#li_social_one").removeClass("active");
                                            $("#li_social_three").addClass("active");
                                            $(".fixed_social").addClass("on")
                                        });

                                        $("#applynowlink").mouseover(function() {
                                            $(".fabox_content").slideUp();
                                            $(".fixed_apply").toggleClass("on")
                                        });
                                        $("#openloginleft").mouseover(function() {
                                            $(".fixed_login").toggleClass("on")
                                        });
                                    });

                                    $(document).ready(function() {
                                        setTimeout(function() {
                                            $(".fixed_login").css("visibility", "visible");
                                            $(".fixed_login").addClass("animated slideInLeft");
                                        }, 3000);
                                    });

                                    $(document).ready(function() {
                                        setTimeout(function() {
                                            $(".fixed_apply").css("visibility", "visible");
                                            $(".fixed_apply").addClass("animated slideInLeft");
                                        }, 3000);
                                        $(".fa_box.one").mouseover(function() {
                                            $(".fabox_content").slideUp(), $("#fa_box_one").slideToggle()
                                        }), $(".fa_box.two").mouseover(function() {
                                            $(".fabox_content").slideUp(), $("#fa_box_two").slideToggle()
                                        }), $(".fa_box.three").mouseover(function() {
                                            $(".fabox_content").slideUp(), $("#fa_box_three").slideToggle()
                                        }), $(".fa_box.four").mouseover(function() {
                                            $(".fabox_content").slideUp(), $("#fa_box_four").slideToggle()

                                        });
                                    });
                                </script>
                                <script>
                                    $(document).ready(function() {

                                        $(".fl-sl").hover(function() {

                                            $(".fl-sl").addClass("at");
                                        });
                                        $(".fl-sl").mouseleave(function() {
                                            $(".fl-sl").removeClass("at");
                                        });

                                        $(".msd-cl").hover(function() {

                                            $(".msd-cl").addClass("ach");
                                        });

                                        $(".msd-cl").mouseleave(function() {
                                            $(".msd-cl").removeClass("ach");
                                        });
                                    });
                                </script>
                                
                                <script type="text/javascript" src="js/stellarnav.js"></script>
                             
								<script>
	$(window).scroll(function(){
    if ($(window).scrollTop() >= 200) {
        $('.headercontainer').addClass('fixed-header');
    }
    else {
        $('.headercontainer').removeClass('fixed-header');
    }
});
	
</script>
</form>
        </body>

        </html>