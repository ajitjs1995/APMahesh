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
    <li><a href="home-aboutus.aspx">About us</a></li>
    <li class="selected"><a href="home-contactus.aspx">Contact Us</a></li>
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
      <nav class="wsmenu clearfix other-nav">
        <ul id="ulmenu" class="mobile-wsmenu-list wsmenu-list">
          <%--SECOND LEVEL MENU 1--%>
      <li style="float:left"><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span> <a href="" title="Contact Us"><strong class="mob-icon fa fa-male"></strong>Contact Us</a>
            <div class="megamenu clearfix" style="width: 266px;">
              <div class="dd-inner">
                <div class="column2 singledropdown"> <img src="images/menu3.jpg" alt="About Us" longdesc="" class="menucolimg">
                  <div class="" id="tab1"> 
				  <a href="contact-us.aspx" title="Contact Us">Contact Us</a>
				  <a href="online-feedback-form.aspx" title="Write to Us / Feedback">Write to Us / Feedback</a>
				  <a href="online-complaint-form.aspx" title="Complaint / Grievance">Complaint / Grievance</a>
				  <a href="whats-new.aspx" title="Whats New @ TMB">Whats New @ TMB</a>
				  <a href="customer-care-support.aspx" title="Customer Care / Support">Customer Care / Support</a>
				  <a href="customer-testimonials.aspx" title="Customer Care / Support">Customer Testimonials</a>
				  </div>
                </div>
              </div>
            </div>
          </li>
		    <li style="float:right">
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
    <li><a href="home-aboutus.aspx">About us</a></li>
    <li class="mega" data-column="5"><a href="home-contactus.aspx">Contact Us</a>
      <ul>
        <li><a href="#">Contact Us</a>
          <ul>
            <li><a href="contact-us.aspx">Contact Us</a></li>
          </ul>
        </li>
        <li><a href="#">Customer Care / Support</a>
          <ul>
            <li><a href="contact-us.aspx" title="Contact Us">Contact Us</a></li>
			<li><a href="online-feedback-form.aspx" title="Write to Us / Feedback">Write to Us / Feedback</a></li>
			<li><a href="online-complaint-form.aspx" title="Complaint / Grievance">Complaint / Grievance</a></li>
			<li><a href="how-to.aspx" title="Whats New @ TMB">Whats New @ TMB</a></li>
			<li><a href="" title="Customer Care / Support">Customer Care / Support</a></li>
          </ul>
        </li>
        
      </ul>
    </li>
    <!-- main li-->
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
