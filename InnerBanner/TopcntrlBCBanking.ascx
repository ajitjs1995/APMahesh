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
      <li class="selected"><a href="home-corporate.aspx">Corporate Banking</a></li>
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
</map></li>
</ul>
<div class="SearcContainer desktopsearch-container">
<input value="Personal" name="segment" type="hidden"><input id="Search" placeholder="Search" name="token" type="text" class="ui-autocomplete-input" autocomplete="off"><input value="" class="MagnifyingGlass" type="submit">
</div>

</div>
</header>



<div class="clear"> </div>
<!--Top bar End-->
<!--Top Header Start-->
<div class="headercontainer">
  <div class="midcontainer" style="position: relative;">
    
	<div class="logo">
                <a href="Home.aspx" title="">
                    <img src="images/tmb-logo.png" alt="" longdesc=""></a></div>	

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

          <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="" title="Products">
          <strong class="mob-icon fa fa-male"></strong>Products</a>

			<div class="megamenu clearfix" style="width: 266px;">
              <div class="dd-inner">
                <div class="column2 singledropdown">
				<!--<img src="images/menu3.jpg" alt="About Us" longdesc="" class="menucolimg">-->
                 
                    <div class="" id="tab1">
					<h3 class="spielbox">Current Account</h3>
					<a href="general-current-account.aspx" class="mega-menu-heading" data-tab="tab0" title="General Current Account">General Current Account</a>
					<a href="flexi-scheme.aspx" title="Super Flexi Current Account">Super Flexi Current Account</a>
    				<a href="general-faq-current-account.aspx" title="General FAQ - Current Accounts">General FAQ - Current Accounts</a>
					
					 <h3 class="spielbox">Loan Products</h3>
					<a href="commercial-vehicle-finance.aspx" class="mega-menu-heading" data-tab="tab0" title="TMB Commercial Vehicle">TMB Commercial Vehicle</a>
					<a href="educational-vehicle-finance.aspx" title="TMB Vehicle Finance - Educational Institution">TMB Vehicle Finance - Educational Institution</a>
    				<a href="tmb-sod.aspx" title="TMB SOD">TMB SOD</a>
					<a href="tmb-traders.aspx" title="TMB Traders & Services">TMB Traders & Services</a>
					<a href="tmb-msme.aspx" title="TMB MSME">TMB MSME</a>
					<a href="rice-mill.aspx" title="TMB Rice Mill">TMB Rice Mill</a>
					<a href="dhall-mill.aspx" title="TMB Dhall Mill">TMB Dhall Mill</a>
					<a href="Pmmy.aspx" title="TMB PMMY">TMB PMMY</a>
					<a href="pharma-finance.aspx" title="TMB Pharma Finance">TMB Pharma Finance</a>
					<a href="channel-finance.aspx" title="TMB Channel Finance">TMB Channel Finance</a>
					<a href="mahalir-loan.aspx" title="TMB Mahalir">TMB Mahalir</a>
					<a href="standup-india-finance.aspx" title="TMB Stand-up India Finance">TMB Stand-up India Finance</a>
					<a href="tmb-doctor-loan.aspx" title="TMB Doctor">TMB Doctor</a>
					<a href="genset.aspx" title="TMB Genset">TMB Genset</a>
					
				  </div>
                  </div>
                </div>
                  </div>
             
          </li>

           <%--SECOND LEVEL MENU 2--%>

          <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="" title="Online Services">
          <strong class="mob-icon fa fa-archive"></strong>Online Services</a>
            <div class="megamenu clearfix " style="width: 266px;">
              <div class="dropdown">
                <div class="dd-inner">
                  <div class="column2 singledropdown">
                 
                    <div class="" id="tab2"> <img src="images/menu1.jpg" alt="About Us" longdesc="" class="menucolimg">
					<a href="internet-banking.aspx" title="Internet Banking ">Internet Banking  </a>
                    <a href="Mobile-banking.aspx" title="Mobile Banking">Mobile Banking</a> 
                    <a href="sms-alert.aspx" title="SMS Alert">SMS Alert</a> 

					 </div>
                  </div>
                
                 
             
                </div>
              </div>
            </div>
          </li>

           <%--SECOND LEVEL MENU 3--%>


          <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="" title="Cards">
          <strong class="mob-icon fa fa-mouse-pointer"></strong>Cards</a>
             <div class="megamenu clearfix " style="width: 266px;  margin-right: 23%;">
              <div class="dropdown">
            <div class="dd-inner">
                  <div class="column2 singledropdown">
                   <div class="" id="tab3"> <img src="images/menu3.jpg" alt="About Us" longdesc="" class="menucolimg">
				<a href="business-card.aspx" title="Business Card" class="menuheadingg"><strong>Business Card</strong></a>
							
				<a href="#" title="Prepaid Cards" class="menuheadingg"><strong>Prepaid Cards</strong></a>
				<a href="fleet-card.aspx" title="TMB Fleet Cards">TMB Fleet Cards</a>
				<a href="general-prepaid-cards.aspx" title="TMB General Prepaid Cards">TMB General Prepaid Cards</a>
			
				
			
                  </div>
                  </div>
                 
                  </div>
                </div>
                  </div>
                              
                </li>



                <%--SECOND LEVEL MENU 4--%>

          
          <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="" title="Forex Services">
          <strong class="mob-icon fa fa-mouse-pointer"></strong>Forex Services</a>
             <div class="megamenu clearfix " style="width: 266px; margin-right: 23%;">
              <div class="dropdown">
            <div class="dd-inner">
                  <div class="column2 singledropdown">
                   <div class="" id="Div3"> <img src="images/menu3.jpg" alt="About Us" longdesc="" class="menucolimg">
				<a href="currency-rates.aspx" title="Currency Rates">Currency Rates</a>
				<a href="outward-remittances.aspx" title="Outward Remittances">Outward Remittances</a>
				<a href="inward-remittances.aspx" title="Inward Remittances">Inward Remittances</a>
                <a href="export-credit-services.aspx" title="Export Credit Services">Export Credit Services</a>
				<a href="import-credit-services.aspx" title="Import Credit Services">Import Credit Services</a>
                <a href="nastro-remittance-account.aspx" title="Nastro Remittance Account">Nastro Remittance Account</a>
				<a href="study-abroad-assistance.aspx" title="Study Abroad Assistance">Study Abroad Assistance</a>
                		
			
                  </div>
                  </div>
                 
                  </div>
                </div>
                  </div>
                              
                </li>


   <%--SECOND LEVEL MENU 5--%>

          
          <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="" title="Other Services">
          <strong class="mob-icon fa fa-mouse-pointer"></strong>Other Services</a>
             <div class="megamenu clearfix " style="width: 266px; margin-right: 23%;">
              <div class="dropdown">
            <div class="dd-inner">
                  <div class="column2 singledropdown">
                   <div class="" id="Div3"> <img src="images/menu3.jpg" alt="About Us" longdesc="" class="menucolimg">
				<a href="pos-terminals-corporate.aspx" title="PoS terminals">PoS terminals</a>
				<a href="e-tax-payment.aspx" title="E-tax Payment">E-tax Payment</a>
				<a href="e-collection-module.aspx" title="E- collection Module">E- collection Module</a>
                <a href="online-bill-payment.aspx" title="Online Bill Payment">Online Bill Payment</a>
				<a href="treasury-services.aspx" title="Treasury Services">Treasury Services</a>
                <a href="demat-services.aspx" title="Demat Services">Demat Services</a>
				<a href="e-stamping.aspx" title="E-Stamping">E-Stamping</a>
                <a href="bancassurance.aspx" title="Bancassurance">Bancassurance</a>		
			
                  </div>
                  </div>
                 
                  </div>
                </div>
                  </div>
                              
                </li>
				
                 
		<li>
              <button class="button">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="https://www.tmbnet.in/" target="_blank" style="color:#ffffff!important">Internet Banking</a></button>
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
      
	   <li class="mega" data-column="5"><a href="home-corporate.aspx">Corporate Banking</a>
      <ul>
        <li><a href="#">Products</a>
          <ul>
		  <li><a href="#" title="Current Account" class=""><strong>Current Account</strong></a></li>
					<li><a href="general-current-account.aspx" class="mega-menu-heading" data-tab="tab0" title="General Current Account">General Current Account</a></li>
					<li><a href="flexi-scheme.aspx" title="Flexi Scheme">Flexi Scheme</a></li>
    				<li><a href="general-faq-current-account.aspx" title="General FAQ - Current Accounts">General FAQ - Current Accounts</a></li>
					
				<li>	<a href="#" title="Loan Products" class="menuheadingg"><strong>Loan Products</strong></a></li>
				<li>	<a href="commercial-vehicle-finance.aspx" class="mega-menu-heading" data-tab="tab0" title="TMB Commercial Vehicle">TMB Commercial Vehicle</a></li>
				<li>	<a href="educational-vehicle-finance.aspx" title="Tmb Vehicle Finance - Educational Institution">Tmb Vehicle Finance - Educational Institution</a></li>
    			<li>	<a href="tmb-sod.aspx" title="General FAQ - Current Accounts">TMB SOD</a></li>
				<li>	<a href="#" title="TMB Traders & Services">TMB Traders & Services</a></li>
				<li>	<a href="tmb-msme.aspx" title="TMB MSME">TMB MSME</a></li>
				<li>	<a href="rice-mill.aspx" title="TMB Rice Mill">TMB Rice Mill</a></li>
				<li>	<a href="dhall-mill.aspx" title="TMB Dhall Mill">TMB Dhall Mill</a></li>
				<li>	<a href="Pmmy.aspx" title="TMB PMMY">TMB PMMY</a></li>
				<li>	<a href="pharma-finance.aspx" title="TMB Pharma Finance">TMB Pharma Finance</a></li>
				<li>	<a href="channel-finance.aspx" title="TMB Channel Finance">TMB Channel Finance</a></li>
				<li>	<a href="mahalir-loan.aspx" title="TMB Mahalir">TMB Mahalir</a></li>
				<li>	<a href="standup-india-finance.aspx" title="TMB Stand-up India Finance">TMB Stand-up India Finance</a></li>
				<li>	<a href="tmb-doctor-loan.aspx" title="TMB Doctor">Tmb Doctor</a></li>
				<li>	<a href="genset.aspx" title="TMB Genset">Tmb Genset</a></li>
		  

          </ul>
        </li>
		
        <li><a href="#">Online Services</a>
          <ul>
            <li><a href="internet-banking.aspx" title="Internet Banking ">Internet Banking  </a> </li>
              <li>      <a href="Mobile-banking.aspx" title="Mobile Banking">Mobile Banking</a>  </li>
               <li>     <a href="sms-alert.aspx" title="SMS Alert">SMS Alert</a> </li>

          </ul>
        </li>
        
        <li><a href="#">Cards</a>
		<ul>
			<li><a href="business-card.aspx" title="Business Card" class="menuheadingg"><strong>Business Card</strong></a></li>
				<li><a href="#" title="Partnership">Partnership</a></li>
				<li><a href="#" title="Company and LLP">Company and LLP</a></li>
				<li><a href="#" title="General FAQ">General FAQ</a></li>
				
				<li><a href="prepaid-cards.aspx" title="Prepaid Cards" class="menuheadingg">Prepaid Cards</a></li>
			<li>	<a href="#" title="TMB Fleet Cards">TMB Fleet Cards</a></li>
			<li>	<a href="#" title="TMB General Prepaid Cards">TMB General Prepaid Cards</a></li>

			
		
		</ul>
		</li>
        
        <li><a href="">Forex Services </a>
		<ul>
		<li><a href="currency-rates.aspx" title="Currency Rates">Currency Rates</a></li>
			<li>	<a href="outward-remittances.aspx" title="Outward Remittances">Outward Remittances</a></li>
			<li>	<a href="inward-remittances.aspx" title="Inward Remittances">Inward Remittances</a></li>
             <li>   <a href="export-credit-services.aspx" title="Export Credit Services">Export Credit Services</a></li>
			<li>	<a href="import-credit-services.aspx" title="Import Credit Services">Import Credit Services</a></li>
             <li>   <a href="nastro-remittance-account.aspx" title="Nastro Remittance Account">Nastro Remittance Account</a></li>
				<li><a href="study-abroad-assistance.aspx" title="Study Abroad Assistance">Study Abroad Assistance</a></li>

		</ul>
		
		
		</li>
		
        
		
		 
		
		 

      </ul>
    </li>
    <!-- main li-->
	
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
