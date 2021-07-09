<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Topcntrl.ascx.cs" Inherits="Topcntrl" %>
<style>
.fixed-header {
    position: fixed;
	    height: 91px;
    top: 0;
    left: 0;
    width: 100%; 
}

</style>
<header class="nav-header" style="background-color: #18388c;">
<div class="middleContainer updated-header clearfix">
  <ul class="menu">
      <li class=""><a href="home.aspx">Personal Banking</a></li>
      <li><a href="home-nri.aspx">NRI</a></li>
      <li><a href="home-corporate.aspx">Corporate Banking</a></li>
      <li><a href="home-msme.aspx">MSME</a></li>
	  <li><a href="home-agriculture.aspx">Agriculture</a></li>
      <li><a href="https://www.tmbnet.in/tmb_careers/" target="_blank">Careers</a></li>
      <li class="selected"><a href="home-aboutus.aspx">About us</a></li>
      <li><a href="home-contactus.aspx">Contact Us</a></li>
    <li><img src="images/social.png" border="0" usemap="#Map"  width="123" height="37" style="margin-left: 150%; margin-top: -7px;">
      <map name="Map">
        <area shape="rect" coords="2,2,31,41" href="https://www.facebook.com/tmbltd" target="_blank">
        <area shape="rect" coords="35,3,65,35" href="https://twitter.com/tmbstepahead" target="_blank">
        <area shape="rect" coords="67,2,99,40" href="http://www.tmb.in/feed.rss" target="_blank">
      </map>
    </li>
  </ul>
  <div class="SearcContainer desktopsearch-container">
    <input value="Personal" name="segment" type="hidden">
    <input id="Search" placeholder="Search" name="token" type="text" class="ui-autocomplete-input" autocomplete="off">
    <input value="" class="MagnifyingGlass" type="submit">
  </div>
</div>
</header>
<div class="clear"> </div>
<!--Top bar End-->
<!--Top Header Start-->
<div class="headercontainer">
  <div class="midcontainer" style="position: relative;">
    <div class="logo"> <a href="Home.aspx" title=""> <img src="images/tmb-logo.png" alt="" longdesc=""></a></div>
    <div class="iconss">
      <ul>
        <li style="margin-bottom: 5px;"><img src="images/search-icon.jpg"/></li>
        <li><img src="images/netbanking-icon.jpg"/></li>
      </ul>
    </div>
    <div class="">
      <!--Main Menu HTML Code-->
      <nav class="wsmenu clearfix other-nav" style="margin-top: 1%;">
        <ul id="ulmenu" class="mobile-wsmenu-list wsmenu-list">
          <%--SECOND LEVEL MENU 1--%>
          <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span>
		  <a href="" title="Knowing TMB "><strong class="mob-icon fa fa-male"></strong>Knowing TMB </a>
            <div class="megamenu clearfix" style="width: 266px;">
              <div class="dd-inner">
                <div class="column2 singledropdown"> <img src="images/menu3.jpg" alt="About Us" longdesc="" class="menucolimg">
                  <div class="" id="tab1"> 
				  <a href="knowing-tmb.aspx" title="About TMB">About TMB</a>
				  <a href="message-ceo-desk.aspx" title="Message from the CEO Desk ">Message from the CEO Desk </a> 
				  <a href="management.aspx" title="Management @ TMB">Management @ TMB</a>				  
				  <a href="iso-27001-certification.aspx" title=" ISO 27001 Certification ">ISO 27001 Certification </a> 				 
				  <a href="awards-and-achievements.aspx" title="Awards & Achievements"> Awards & Achievements </a> 
				  <a href="future-vision.aspx" title="Future Vision"> Future Vision </a>
				   <a href="events-gallary.aspx" title="Events & Gallary">Events & Gallary</a>
				   </div>
                </div>
              </div>
            </div>
          </li>
          <%--SECOND LEVEL MENU 2--%>
          <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="financial-highlights.aspx" title="Financial Highlights"> <strong class="mob-icon fa fa-archive"></strong>Financial Highlights</a>
             <div class="megamenu clearfix" style="width:266px;">
              <div class="dd-inner">
                  <div class="column2 singledropdown">
                 
                    <div class="" id="tab2"> <img src="images/menu1.jpg" alt="About Us" longdesc="" class="menucolimg">
				<a href="financial-performance-highlights.aspx" title="Financial Performance Highlights">Financial Performance Highlights</a> 
				<a href="audited-balance-sheet.aspx" title="Audited Balance Sheet">Audited Balance Sheet</a> 
                    

					 </div>
                  </div>
                
                 
             
              </div>
            </div>
          </li>
          <%--SECOND LEVEL MENU 3--%>
          <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="" title="Shareholders Corner"><strong class="mob-icon fa fa-male"></strong>Shareholders Corner</a>
            <div class="megamenu clearfix" style="width: 266px;">
              <div class="dd-inner">
                <div class="column2 singledropdown"> <img src="images/menu3.jpg" alt="About Us" longdesc="" class="menucolimg">
                  <div class="" id="tab1"> 
			
				  <a href="appointment-of-Ind-Directors.aspx" title="Appointment of Ind. Directors">Appointment of Ind. Directors</a> 
				  <a href="share-transfer-procedure.aspx " title="Share Transfer Procedure">Share Transfer Procedure </a> 
				  <a href="forms-for-share-transfer-and-nomination.aspx " title="Forms for Share Transfer & Nomination ">Forms for Share Transfer & Nomination </a> 
				  <a href="shareholders-grievance-redressal.aspx" title="Shareholders Grievance Redressal">Shareholders Grievance Redressal</a> 
				  <a href="shareholders-notices.aspx" title="Shareholders Notices">Shareholders Notices</a> 
				  <a href="annual-general-meetings.aspx" title="Annual General Meetings">Annual General Meetings</a> 
				  <a href="investor-education-and-protection-fund.aspx" title="Investor Education and Protection Fund">Investor Education and Protection Fund</a> 
				  <a href="kyc-updation.aspx" title="Know Your Customer (KYC) Updation">Know Your Customer (KYC) Updation</a>
				  <a href="green-initiative.aspx" title="Green Initiative">Green Initiative </a> </div>
                </div>
              </div>
            </div>
          </li>
          <%--SECOND LEVEL MENU 4--%>
          <li>
            <button class="button">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="https://www.tmbnet.in/" target="_blank" style="color:#ffffff!important">Internet Banking</a>
            </button>
            <style>
			 
</style>
          </li>
        </ul>
      </nav>
      <!--Menu HTML Code-->
    </div>
  </div>
</div>
<!-- required -->
<link rel="stylesheet" type="text/css" media="all" href="css/stellarnav.css">
<!-- required -->
<div class="stellarnav responsivelogin">
  <ul>
    <!--  <li><a href="">Item 2</a></li>
		    <li><a href="">Item 3</a></li>
		    <li><a href="">Item 4</a></li>
		    <li><a href="">Item 5</a></li>
		    <li><a href="">Item 6</a></li> -->
    <li><a href="home.aspx">Personal Banking</a></li>
    <li><a href="home-nri.aspx">NRI</a></li>
    <li><a href="home-corporate.aspx">Corporate Banking</a></li>
    <li><a href="home.msme.aspx">MSME</a></li>
    <li><a href="https://www.tmbnet.in/tmb_careers/" target="_blank">Careers</a></li>
    <li class="mega" data-column="5"><a href="home-aboutus.aspx">About us</a>
      <ul>
        <li><a href="#">Knowing TMB </a>
          <ul>
            <li><a href="	management.aspx	"> Management @ TMB</a></li>
            <li><a href="	iso-27001-certification.aspx	"> ISO 27001 Certification</a></li>
            <li><a href="	awards-and-achievements.aspx	"> Awards & Achievements</a></li>
            <li><a href="	future-vision.aspx	"> Future Vision</a></li>
          </ul>
        </li>
        <li><a href="financial-highlights.aspx">Financial Highlights</a> </li>
        <li><a href="#">Shareholders Corner</a>
          <ul>
            <li><a href="	financial-performance-highlights.aspx	"> Financial Performance Highlights </a></li>
            <li><a href="	audited-balance-sheet.aspx	"> Audited Balance Sheet </a></li>
            <li><a href="	appointment-of-Ind-Directors.aspx	"> Appointment of Ind. Directors </a></li>
            <li><a href="	share-transfer-procedure.aspx	"> Share Transfer Procedure </a></li>
            <li><a href="	forms-for-share-transfer-and-nomination.aspx	"> Forms for Share Transfer & Nomination </a></li>
            <li><a href="	shareholders-grievance-redressal.aspx	"> Shareholders Grievance Redressal </a></li>
            <li><a href="	shareholders-notices.aspx	"> Shareholders Notices </a></li>
            <li><a href="	annual-general-meetings.aspx	"> Annual General Meetings </a></li>
            <li><a href="	investor-education-and-protection-fund.aspx	"> Investor Education and Protection Fund </a></li>
            <li><a href="	kyc-updation.aspx	"> Know Your Customer (KYC) Updation </a></li>
            <li><a href="	green-initiative.aspx	"> Green Initiative </a></li>
          </ul>
        </li>
      </ul>
    </li>
    <!-- main li-->
    <li><a href="home-contactus.aspx">Contact Us</a></li>
  </ul>
</div>
<!-- .stellarnav -->
<script type="text/javascript" src="js/stellarnav.js"></script>
<script type="text/javascript">
		jQuery(document).ready(function($) {
			jQuery('.stellarnav').stellarNav({
				theme: 'dark',
				breakpoint: 960,
				position: 'right',
				phoneBtn: '18009997788',
				locationBtn: 'https://www.google.com/maps'
			});
		});
	</script>
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
