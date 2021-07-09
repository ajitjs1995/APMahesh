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
          <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="" title="Savings Bank"><strong class="mob-icon fa fa-male"></strong>Savings Bank</a>
            <div class="megamenu clearfix" style="width: 266px;">
              <div class="dd-inner">
                <div class="column2 singledropdown"> <img src="images/menu3.jpg" alt="About Us" longdesc="" class="menucolimg">
                  <div class="" id="tab1"> 
<!--				  <a href="#" title="Savings Bank Account" class="menuheadingg"><strong>Savings Bank Account</strong></a>
-->				  <a href="basic-services-savings-bank-account.aspx" class="mega-menu-heading" data-tab="tab0" title="Simple & Basic Services Savings Account">
				  Simple & Basic Services Savings Account</a>
					<a href="general-savings-bank-account.aspx" title="General Savings Bank Account">General Savings Bank Account</a>
					<a href="tmb-royal-account.aspx" title="TMB Royal Account">TMB Royal Account</a>
					<a href="sb-premium-account.aspx" title="SB Premium Account">SB Premium Account</a>
					<a href="tmb-little-super-star-savings-account.aspx" title=" TMB Little Super Star Savings Account" >TMB Little Super Star savings Account</a>
					<a href="tmb-dynamic-youth-account.aspx" title="TMB Dynamic Youth Account">TMB Dynamic Youth Account</a>
					<a href="tmb-mahila-subha-account.aspx" title="TMB Mahila Subha Account">TMB Mahila Subha Account</a>
					<a href="tmb-classic-salary-account.aspx" title="TMB Classic Salary Account">TMB Classic Salary Account</a>
					<a href="tmb-happy-family-banking-account.aspx" title="TMB Happy Family Banking Account">TMB Happy Family Banking Account</a>
					<a href="tmb-visa-savings-bank-account.aspx" title="TMB Visa Savings Bank Account">TMB Visa Savings Bank Account</a>
					<a href="santhosh-fixed-deposit.aspx" title="TMB Santhosh Savings Bank Account">TMB Santhosh Savings Bank Account</a> </div>
                </div>
              </div>
            </div>
          </li>
         <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="" title="Deopsits"><strong class="mob-icon fa fa-archive"></strong>Deposits</a>
            <div class="megamenu clearfix" style="width: 266px;">
              <div class="dropdown">
                <div class="dd-inner">
                  <div class="column2 singledropdown"> <img src="images/menu1.jpg" alt="About Us" longdesc="" class="menucolimg">				  
                    <div class="" id="tab1"> 
					    <h3 class="spielbox">Recurring Deposit Accounts</h2>
					    <a href="basic-recurring-deposit-account.aspx" title="Basic Recurring Deposit Account">Basic Recurring Deposit Account</a>
						<a href="Kids-recurring-deposit-account.aspx" title="Kids Recurring Deposit Account">Kids Recurring Deposit Account</a>
						<a href="navarathnamala-deposit-account.aspx" title="Navarathnamala Deposit Account">Navarathnamala Deposit Account</a>
						<a href="Siranjeevi-recurring-deposit-account.aspx" title="Siranjeevi Recurring Deposit Account">Siranjeevi Recurring Deposit Account</a> 
						
						<h3 class="spielbox">Term Deposit Accounts</h2>
						<a href="fixed-deposit-account.aspx" title="Fixed Deposit Account">Fixed Deposit Account </a>
						<a href="Muthukuvial-deposit-account.aspx" title="Muthukuvial Deposit Account">Muthukuvial Deposit Account </a>
						<a href="cash-certificates.aspx" title="Cash Certificates">Cash Certificates</a>
						<a href="tax-saving-deposit-account.aspx" title="TAX Saving Deposit Account">TAX Saving Deposit Account</a>
						<a href="pearl-deposit-account.aspx" title="Pearl Deposit Account">Pearl Deposit Account</a>
						<a href="20-20-deposit-account.aspx" title="20:20 Deposit Account">20:20 Deposit Account</a>
						<a href="bulk-deposits.aspx" title="Bulk Deposits" class="menuheadingg"><strong>Bulk Deposits</strong></a>
						
						</div>
					</div>
                </div>
              </div>
            </div>
          </li>
       
        <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="" title="Loans"><strong class="mob-icon fa fa-mouse-pointer"></strong>Loans </a>
            <div class="megamenu clearfix" style="width: 266px;">
              <div class="dropdown">
                <div class="dd-inner">
                  <div class="column2 singledropdown">
                    <div class="" id="tab3"> <!--<img src="images/menu3.jpg" alt="About Us" longdesc="" class="menucolimg"> -->
					 <h3 class="spielbox">Loan Products</h3>
					<a href="tmb-home-loan.aspx" title="TMB Home Loan">TMB Home Loan</a>
					<a href="tmb-affordable-home-loan.aspx" title="TMB Affordable Home Loan">TMB Affordable Home Loan</a>
					<a href="tmb-pmay-home-loan.aspx" title="TMB PMAY Home Loan">TMB PMAY Home Loan</a>							
						<a href="tmb-car-loan.aspx" title="TMB Car loan">TMB Car Loan</a>
						<a href="tmb-two-wheeler-loan.aspx" title="TMB Two Wheeler Loan">TMB Two Wheeler Loan</a>
						<a href="tmb-personal-loan.aspx" title="TMB Personal Loan">TMB Personal Loan</a>						
						<a href="tmb-lap.aspx" title="TMB LAP">TMB LAP</a>
						<a href="tmb-retirees.aspx" title="TMB Retirees">TMB Retirees</a>
						<a href="tmb-pensioner.aspx" title="TMB Pensioner">TMB Pensioner</a>
						<a href="tmb-rental.aspx" title="TMB Rental">TMB Rental</a>
						<a href="tmb-gold-overdraft.aspx" title="TMB Gold Overdraft">TMB Gold Overdraft</a>
						<a href="tmb-doctor-loan.aspx" title="TMB Doctor Loan">TMB Doctor Loan</a>
						<a href="tmb-education-loan.aspx" title="TMB Education Loan">TMB Education Loan</a>
						<a href="tmb-super-education-loan.aspx" title="TMB Super Education Loan">TMB Super Education Loan</a>		
						<a href="jewel-loan.aspx" title="Jewel Loan">Jewel Loan</a>
						<a href="loan-against-soverign-gold-bonds.aspx" title="Loan Against Soverign Gold Bonds">Loan Against Soverign Gold Bonds</a>
						<a href="general-loan-faq.aspx" title="General Loan FAQ">General Loan FAQ</a>
						
					
						 </div>
                  </div>
                </div>
              </div>
            </div>
          </li>
      
    <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span> <a href="" title="Value Added Services"> <strong class="mob-icon fa fa-line-chart"></strong>Value Added Services  </a>
            <div class="megamenu clearfix" style="width: 266px;">
              <div class="dd-inner">
                <div class="column2 singledropdown"> <!--<img src="images/menu2.jpg" alt="About Us" longdesc="" class="menucolimg"> -->
<!--				<a href="#" title="Cards" class="menuheadingg"><strong>Cards</strong></a> 
-->				<a href="debit-cards.aspx" title="Debit Cards">Debit Cards</a> 
				<a href="prepaid-debit-cards.aspx" title="Prepaid Debit Cards">Prepaid Debit Cards</a> 
				<a href="credit-cards.aspx" title="Credit Cards">Credit Cards</a>
				<a href="pos-terminals.aspx" title="PoS Terminals">PoS Terminals</a>
				<a href="internet-mobile-banking.aspx" title="Internet Banking / Mobile Banking">Internet Banking / Mobile Banking</a>
				<a href="mydelight-photo-debit-card.aspx" title="TMB My Delight Card">TMB My Delight Card</a>
				<a href="tab-banking.aspx" title="Tab Banking">Tab Banking</a>
				<a href="upi.aspx" title="UPI">UPI</a>
				<a href="epassbook.aspx" title="Epassbook">Epassbook</a>
				<a href="aeps.aspx" title="AEPS">AEPS</a>
				<a href="bbps.aspx" title="BBPS">BBPS</a>
				<a href="tmb-mobile-wallet.aspx" title="TMB Mobile Wallet">TMB Mobile Wallet</a>
				<a href="missec-call-facility.aspx" title="Missed Call Facility">Missed Call Facility</a>
				<a href="imps.aspx" title="IMPS">IMPS</a>
				<a href="education-fee-payment.aspx" title="Education Fee Payment">Education Fee Payment</a>				
				<a href="demat-account.aspx" title="Demat Account">Demat Account </a>				
				<a href="equity-trading-account.aspx" title="Equity Trading Account">Equity Trading Account </a>
				<a href="dynamic-3-in-1-account.aspx" title="Dynamic 3 in 1 Account">Dynamic 3 in 1 Account</a>
				<a href="faqs.aspx" title="FAQs">FAQs</a>
				</div>
              </div>
            </div>
          </li>
	  <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span> <a href="" title="Other Services"> <strong class="mob-icon fa fa-line-chart"></strong>Other Services </a>
            <div class="megamenu clearfix" style="width: 266px;">
              <div class="dd-inner">
                <div class="column2 singledropdown"> <img src="images/menu2.jpg" alt="About Us" longdesc="" class="menucolimg"> 				
				<a href="aadhar-card-enrolment.aspx" title="Aadhar Card Enrolment / Correction">Aadhar Card Enrolment / Correction</a> 
				<a href="e-stamping.aspx" title="E Stamping">E Stamping</a> 
				<a href="pan-card-service.aspx" title="PAN Card Service">PAN Card Service</a>
				<a href="national-pension-scheme.aspx" title="National Pension Scheme (NPS)">National Pension Scheme (NPS)</a>
				<a href="atal-pension-yojna.aspx" title="APY (Atal Pension Yojna)">APY (Atal Pension Yojna)</a>
				<a href="e-tax-payment.aspx" title="E-tax Payment">E-tax Payment</a>
				<a href="online-bill-payment.aspx" title="Online Bill Payment">Online Bill Payment </a>
				<a href="insurance-services.aspx" title="Insurance Services">Insurance Services</a>
				<a href="mutual-funds.aspx" title="Mutual Funds">Mutual Funds</a>
				<a href="sovereign-gold-bonds-scheme.aspx" title="Sovereign Gold Bonds Scheme">Sovereign Gold Bonds Scheme</a>
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
    <li class="mega" data-column="5"><a href="">Personal Banking</a>
      <ul>
        <li><a href="#">Savings Bank</a>
          <ul>
				<li>  <a href="basic-services-savings-bank-account.aspx" class="mega-menu-heading" data-tab="tab0" title="Simple & Basic Services Savings Account">
				  Simple & Basic Services Savings Account</a></li>
					<li><a href="general-savings-bank-account.aspx" title="General Savings Bank Account">General Savings Bank Account</a></li>
				<li>	<a href="tmb-royal-account.aspx" title="TMB Royal Account">TMB Royal Account</a></li>
					<li><a href="sb-premium-account.aspx" title="SB Premium Account">SB Premium Account</a></li>
				<li>	<a href="tmb-little-super-star-savings-account.aspx" title=" TMB Little Super Star Savings Account" >TMB Little Super Star savings Account</a></li>
					<li><a href="tmb-dynamic-youth-account.aspx" title="TMB Dynamic Youth Account">TMB Dynamic Youth Account</a></li>
				<li>	<a href="tmb-mahila-subha-account.aspx" title="TMB Mahila Subha Account">TMB Mahila Subha Account</a></li>
				<li>	<a href="tmb-classic-salary-account.aspx" title="TMB Classic Salary Account">TMB Classic Salary Account</a></li>
				<li>	<a href="tmb-happy-family-banking-account.aspx" title="TMB Happy Family Banking Account">TMB Happy Family Banking Account</a></li>
				<li>	<a href="tmb-visa-savings-bank-account.aspx" title="TMB Visa Savings Bank Account">TMB Visa Savings Bank Account</a></li>
				<li>	<a href="santhosh-fixed-deposit.aspx" title="TMB Santhosh Savings Bank Account">TMB Santhosh Savings Bank Account</a></li>
          </ul>
        </li>
        <li><a href="#">Deposits</a>
          <ul>
            <li><a href="basic-recurring-deposit-account.aspx">Basic Recurring Deposit Account</a></li>
            <li><a href="Kids-recurring-deposit-account.aspx">Kids Recurring Deposit Account</a></li>
            <li><a href="navarathnamala-deposit-account.aspx">Navarathnamala Deposit Account</a></li>
            <li><a href="Siranjeevi-recurring-deposit-account.aspx">Siranjeevi Recurring Deposit Account</a></li>
			<li><a href="#" title="Recurring Deposit Accounts" class="menuheadingg"><strong>Term Deposit Accounts</strong></a></li>
			<li><a href="fixed-deposit-account.aspx" title="Fixed Deposit Account">Fixed Deposit Account </a></li>
			<li><a href="Muthukuvial-deposit-account.aspx" title="Muthukuvial Deposit Account">Muthukuvial Deposit Account </a></li>
			<li><a href="cash-certificates.aspx" title="Cash Certificates">Cash Certificates</a></li>
			<li><a href="tax-saving-deposit-account.aspx" title="TAX Saving Deposit Account">TAX Saving Deposit Account</a></li>
			<li><a href="pearl-deposit-account.aspx" title="Pearl Deposit Account">Pearl Deposit Account</a></li>
			<li><a href="bulk-deposits.aspx" title="Bulk Deposits" class="menuheadingg"><strong>Bulk Deposits</strong></a></li>
          </ul>
        </li>
         <li><a href="#">Loans</a>
          <ul>
      <li><a href="#" title="Loan Products" class=""><strong>Loan Products</strong></a></li>
					<li><a href="tmb-home-loan.aspx" title="TMB Home Loan">TMB Home Loan</a></li>
					<li><a href="tmb-home-loan.aspx" title="TMB Affordable Home Loan">TMB Affordable Home Loan</a></li>
					<li><a href="tmb-home-loan.aspx" title="TMB PMAY Home Loan">TMB PMAY Home Loan</a></li>							
						<li><a href="tmb-car-loan.aspx" title="TMB Car loan">TMB Car Loan</a></li>
					<li>	<a href="tmb-two-wheeler-loan.aspx" title="TMB Two Wheeler Loan">TMB Two Wheeler Loan</a></li>
					<li>	<a href="tmb-personal-loan.aspx" title="TMB Personal Loan">TMB Personal Loan</a>				</li>		
					<li>	<a href="#" title="TMB LAP">TMB LAP</a></li>
					<li>	<a href="#" title="TMB Retirees">TMB Retirees</a></li>
					<li>	<a href="#" title="TMB Rental">TMB Rental</a></li>
					<li>	<a href="tmb-gold-overdraft.aspx" title="TMB Gold Overdraft">TMB Gold Overdraft</a></li>
					<li>	<a href="tmb-doctor-loan.aspx" title="TMB Doctor Loan">TMB Doctor Loan</a></li>
					<li>	<a href="tmb-education-loan.aspx" title="TMB Education Loan">TMB Education Loan</a></li>
					<li>	<a href="#" title="TMB Super Education Loan">TMB Super Education Loan</a>		</li>
					<li>	<a href="jewel-loan.aspx" title="Jewel Loan">Jewel Loan</a></li>
					<li>	<a href="loan-against-soverign-gold-bonds.aspx" title="Loan against Soverign Gold Bonds">Loan against Soverign Gold Bonds</a></li>
					<li>	<a href="general-loan-faq.aspx" title="General Loan FAQ">General Loan FAQ</a></li>
	  
	    </ul>
        </li>
		  <li><a href="#">Value Added Services</a>
          <ul>
				<li><a href="#" title="Cards" class="menuheadingg"><strong>Cards</strong></a> </li>
				<li><a href="debit-cards.aspx" title="Debit Cards">Debit Cards</a> </li>
				<li><a href="prepaid-debit-cards.aspx" title="Prepaid Debit Cards">Prepaid Debit Cards</a> </li>
				<li><a href="credit-cards.aspx" title="Credit Cards">Credit Cards</a></li>
				<li><a href="pos-terminals.aspx" title="PoS Terminals">PoS Terminals</a></li>
				<li><a href="internet-mobile-banking.aspx" title="Internet Banking / Mobile Banking">Internet Banking / Mobile Banking</a></li>
				<li><a href="demat-account.aspx" title="Demat Account">Demat Account </a></li>
				<li><a href="equity-trading-account.aspx" title="Equity Trading Account">Equity Trading Account </a></li>
				<li><a href="#" title="Dynamic 3 in 1 Account">Dynamic 3 in 1 Account</a></li>
		
		 </ul>
        </li>
		<li><a href="#">Other Services</a>
          <ul>
				<li><a href="aadhar-card-enrolment.aspx" title="Aadhar Card Enrolment / Correction">Aadhar Card Enrolment / Correction</a> </li>
				<li><a href="e-stamping.aspx" title="E Stamping">E Stamping</a> </li>
				<li><a href="pan-card-service.aspx" title="PAN Card Service">PAN Card Service</a></li>
				<li><a href="national-pension-scheme.aspx" title="National Pension Scheme (NPS)">National Pension Scheme (NPS)</a></li>
				<li><a href="atal-pension-yojna.aspx" title="APY (Atal Pension Yojna)">APY (Atal Pension Yojna)</a></li>
				<li><a href="e-tax-payment.aspx" title="E-tax Payment">E-tax Payment</a></li>
				<li><a href="online-bill-payment.aspx" title="Online Bill Payment">Online Bill Payment </a></li>
				<li><a href="insurance-services.aspx" title="Insurance Services">Insurance Services</a></li>
				<li><a href="mutual-funds.aspx" title="Mutual Funds">Mutual Funds</a></li>
		
      </ul>
    </li>
	</ul></li>
    <li><a href="home-nri.aspx">NRI</a></li>
    <li><a href="home-corporate.aspx">Corporate Banking</a></li>
    <li><a href="home-msme.aspx">MSME</a></li>
	<li><a href="home-agriculture.aspx">Agriculture</a></li>
    <li><a href="https://www.tmbnet.in/tmb_careers/" target="_blank">Careers</a></li>
    <li><a href="home-aboutus.aspx">About Us</a></li>
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