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
      <li class="selected"><a href="home-nri.aspx">NRI</a></li>
      <li><a href="home-corporate.aspx">Corporate Banking</a></li>
      <li><a href="home-msme.aspx">MSME</a></li>
	  <li><a href="home-agriculture.aspx">Agriculture</a></li>
      <li><a href="https://www.tmbnet.in/tmb_careers/" target="_blank">Careers</a></li>
      <li><a href="home-aboutus.aspx">About us</a></li>
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
      <nav class="wsmenu clearfix other-nav">
        <ul id="ulmenu" class="mobile-wsmenu-list wsmenu-list" style="margin-top: -48px;">
          <%--SECOND LEVEL MENU 1--%>
          <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="" title="Products"><strong class="mob-icon fa fa-male"></strong>Products</a>
            <div class="megamenu clearfix" style="width: 266px;">
              <div class="dd-inner">
                <div class="column2 singledropdown"> <img src="images/menu3.jpg" alt="About Us" longdesc="" class="menucolimg">
                  <div class="" id="tab1"> 
				  <h3 class="spielbox">Savings Bank Account </h3>
				  <a href="nre-ordinary-accounts.aspx" class="mega-menu-heading" data-tab="tab0" title="NRE - Ordinary Accounts"> NRE - Ordinary Accounts</a> 
				  <a href="nre-premium-accounts.aspx" title="NRE - Premium Accounts"> NRE - Premium Accounts </a> 
				  <a href="nro-accounts.aspx" title="NRO Accounts"> <img src="images/dot.png" title="Apply online" class="">NRO Accounts</a> 
				  <a href="https://www.tmbnet.in/tmbankonline/" title="Apply Online"> Apply Online</a> 		
				  		  
				   <h3 class="spielbox">Recurring Deposit Accounts</h3>
				  <a href="nre-ordinary-accounts.aspx" class="mega-menu-heading" data-tab="tab0" title="NRE - Ordinary Accounts"> NRE - Ordinary Accounts</a> 
				  <a href="https://www.tmbnet.in/tmbankonline/" title="Apply Online"> Apply Online</a> 	
				  			  
				  <h3 class="spielbox">Term Deposit Account</h3>
				  <a href="nre-fixed-deposits.aspx" class="mega-menu-heading" data-tab="tab0" title="NRE - Fixed Deposits">NRE - Fixed Deposits</a> 				  
				  <a href="nre-muthukuvial-deposits.aspx" title="NRE - Muthukuvial Deposits">NRE - Muthukuvial Deposits</a> 		
				  <a href="fcnr-deposits.aspx" title="FCNR (B) Deposit Account">FCNR (B) Deposit Account </a> 	  
				  <a href="rfc-scheme-account.aspx" title="RFC Scheme Account">RFC Scheme Account </a> 
				  <a href="tax-savings-account.aspx" title="Tax Savings Account">Tax Savings Account </a> 	
				  			  
				  <h3 class="spielbox">Loan Accounts</h3>
				  <a href="all-loans-to-nri.aspx" class="mega-menu-heading" data-tab="tab0" title="ALL loans to NRIs">ALL loans to NRIs</a> 
				  <a href="loans-to-nri-faq.aspx" title="General FAQ - Loans to NRI">General FAQ - Loans to NRI</a> 
				  
				  </div>
                </div>
              </div>
            </div>
          </li>
         
          <%--SECOND LEVEL MENU 2--%>
          <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="" title="Money Transfer"> <strong class="mob-icon fa fa-mouse-pointer"></strong>Money Transfer</a>
            <div class="megamenu clearfix" style="width: 266px;
    margin-right: 23%;">
              <div class="dropdown">
                <div class="dd-inner ">
                  <div class="column2 singledropdown">
                    <div class="" id="tab3"> <img src="images/menu3.jpg" alt="About Us" longdesc="" class="menucolimg"> 
					<a href="western-union-money-transfer.aspx" title="Western Union Money Transfer">Western Union Money Transfer</a>
					<a href="xpress-money-service.aspx" title="Xpress Money Service">Xpress money service</a> 
					<a href="money-2-anywhere.aspx" title="Money 2 Anywhere">Money 2 Anywhere</a>
					<a href="gcc-exchange.aspx" title="GCC Exchange">GCC Exchange</a>
					<a href="remit-2-india.aspx" title="Remit2India">Remit2India</a>
					 </div>
                  </div>
                </div>
              </div>
            </div>
          </li>
		  
		   <%--SECOND LEVEL MENU 3--%>
          <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="" title="Online Services">
		  <strong class="mob-icon fa fa-mouse-pointer"></strong>Online Services</a>
            <div class="megamenu clearfix" style="width: 266px; margin-right: 23%;">
              <div class="dropdown">
                <div class="dd-inner ">
                  <div class="column2 singledropdown">
                    <div class="" id="tab3"> <img src="images/menu3.jpg" alt="About Us" longdesc="" class="menucolimg"> 
					<a href="internet-banking.aspx" title="Internet Banking">Internet Banking</a>
					<a href="sms-alert-to-international-number.aspx" title="Sms Alert To International Number">Sms Alert To International Number</a> 
					<a href="online-account-opening.aspx" title="Online Account Opening - Sb, Term Deposits">Online Account Opening - Sb, Term Deposits</a>					
					 </div>
                  </div>
                </div>
              </div>
            </div>
          </li>
		  
		  
		   <%--SECOND LEVEL MENU 4--%>
          <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="" title="TMB Cards">
		  <strong class="mob-icon fa fa-mouse-pointer"></strong>TMB Cards</a>
            <div class="megamenu clearfix" style="width: 266px; margin-right: 23%;">
              <div class="dropdown">
                <div class="dd-inner ">
                  <div class="column2 singledropdown">
                    <div class="" id="tab3"> <img src="images/menu3.jpg" alt="About Us" longdesc="" class="menucolimg"> 
					<a href="smart-shopper-visa-debit-card.aspx" title="TMB Smart Shopper Visa Debit Card">TMB Smart Shopper Visa Debit Card </a>								
					 </div>
                  </div>
                </div>
              </div>
            </div>
          </li>
		  
		  
          
		  
        
       
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
    <li class="mega" data-column="5"><a href="">NRI</a>
      <ul>
        <li><a href="#">Products</a>
          <ul>
            <li><a href="nre-ordinary-accounts.aspx">NRE  - Ordinary Accounts</a></li>
            <li><a href="nre-premium-accounts.aspx">NRE - Premium Accounts </a></li>
            <li><a href="nro-accounts.aspx">NRO Accounts</a></li>
            <li><a href="https://www.tmbnet.in/tmbankonline/">Apply Online </a></li>
          </ul>
        </li>
        <li><a href="#">Money Transfer</a>
          <ul>
            <li><a href="western-union-money-transfer.aspx" title="Western Union Money Transfer">Western Union Money Transfer</a></li>
			<li><a href="xpress-money-service.aspx" title="Xpress Money Service">Xpress money service</a> </li>
			<li><a href="money-2-anywhere.aspx" title="Money 2 Anywhere">Money 2 Anywhere</a></li>
			<li><a href="gcc-exchange.aspx" title="GCC Exchange">GCC Exchange</a></li>
			<li><a href="remit-2-india.aspx" title="Remit2India">Remit2India</a></li>
          </ul>
        </li>
        <li><a href="#">Online Services</a>
          <ul>
            <li><a href="internet-banking.aspx" title="Internet Banking">Internet Banking</a></li>
			<li><a href="sms-alert-to-international-number.aspx" title="Sms Alert To International Number">Sms Alert To International Number</a></li> 
			<li><a href="online-account-opening.aspx" title="Online Account Opening - Sb, Term Deposits">Online Account Opening - Sb, Term Deposits</a></li>
          </ul>
        </li>
        <li><a href="#">TMB Cards</a>
          <ul>
            <li> <a href="smar-shopper-visa-debit-card.aspx" title="TMB Smar Shopper Visa Debit Card">TMB Smar Shopper Visa Debit Card </a>	</li>
          </ul>
        </li>

      </ul>
    </li>
    <!-- main li-->
	<li><a href="home-corporate.aspx">Corporate Banking</a></li>
    <li><a href="home-msme.aspx">MSME</a></li>
	<li><a href="home-agriculture.aspx">Agriculture</a></li>
    <li><a href="https://www.tmbnet.in/tmb_careers/" target="_blank">Careers</a></li>
    <li><a href="home-aboutus.aspx">About us</a></li>
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
