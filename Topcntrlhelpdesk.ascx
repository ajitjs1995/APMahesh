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

   <li><img src="images/social.png" border="0" usemap="#Map"  width="123" height="37" style="margin-left: 170%; margin-top: -7px;">
<map name="Map">
  <area shape="rect" coords="2,2,31,41" href="https://www.facebook.com/tmbltd" target="_blank">
<area shape="rect" coords="35,3,65,35" href="https://twitter.com/tmbstepahead" target="_blank">
<area shape="rect" coords="67,2,99,40" href="#">
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
			   <li style="margin-bottom: 5px;"><a href="https://www.tmbnet.in/" target="_blank"><img src="images/netbanking-icon.jpg"/></a></li>
		<li><a href="https://prepaid.tmbnet.in/tmbcreditcustomer/html/LoginFrame.jsp" target="_blank"><img src="images/credit-icon.jpg"/></a></li>
			   </ul>			   
			   </div>
					
    <div class="">	
           <!--Main Menu HTML Code-->
      <nav class="wsmenu clearfix other-nav">
        <ul id="ulmenu" class="mobile-wsmenu-list wsmenu-list">

         <%--SECOND LEVEL MENU 1--%>

          <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="" title="Contact Us"><strong class="mob-icon fa fa-male"></strong>Contact Us</a>

							  <div class="megamenu clearfix" style="width: 266px;">
              <div class="dd-inner">
                <div class="column2 singledropdown">
				<img src="images/menu3.jpg" alt="About Us" longdesc="" class="menucolimg">
                 
                    <div class="" id="tab1">
					<a href="contact-us.aspx" class="mega-menu-heading" data-tab="tab0" title="Contact Us">
                    	Contact Us</a>
            
					

		    		

				 
				  </div>
                  </div>
                </div>
                  </div>
             
          </li>

           <%--SECOND LEVEL MENU 2--%>
 <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="" title="Customer Care / Support"><strong class="mob-icon fa fa-male"></strong>Customer Care / Support</a>

							  <div class="megamenu clearfix" style="width: 266px;">
              <div class="dd-inner">
                <div class="column2 singledropdown">
				<img src="images/menu3.jpg" alt="About Us" longdesc="" class="menucolimg">
                 
                    <div class="" id="tab1">
					<a href="online-feedback-form.aspx" title="Write to Us / Feedback">Write to Us / Feedback</a>
                    <a href="online-complaint-form.aspx" title="Complaint / Grievance">Complaint / Grievance</a> 
					<a href="rates-at-a-glance.aspx" title="Rates at a Glance">Rates at a Glance</a> 
					<a href="how-to.aspx" title="How To / FAQ">How To / FAQ</a> 
					<a href="whats-new.aspx" title="Whats New @ TMB">Whats New @ TMB</a> 

		    		

				 
				  </div>
                  </div>
                </div>
                  </div>
             
          </li>
     

           <%--SECOND LEVEL MENU 3--%>

  <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="" title="Public Notice"><strong class="mob-icon fa fa-male"></strong>Public Notice</a>

							  <div class="megamenu clearfix" style="width: 266px;">
              <div class="dd-inner">
                <div class="column2 singledropdown">
				<img src="images/menu3.jpg" alt="About Us" longdesc="" class="menucolimg">
                 
                    <div class="" id="tab1">
					<a href="press-release.aspx" title="Press Release">Press Release</a>
                    <a href="sale-notice.aspx" title="Sale Notice">Sale Notice</a>
                    

		    		

				 
				  </div>
                  </div>
                </div>
                  </div>
             
          </li>



      


           <%--SECOND LEVEL MENU 4--%>

          <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="" title="Calculators">
          <strong class="mob-icon fa fa-mouse-pointer"></strong>Calculators</a>
             <div class="megamenu clearfix" style="width: 266px;
    margin-right: 23%;">
              <div class="dropdown">
            <div class="dd-inner ">
                  <div class="column2 singledropdown">
                   <div class="" id="tab3"> <img src="images/menu3.jpg" alt="About Us" longdesc="" class="menucolimg">
				<a href="deposit-calculator.aspx">Maturity Interest Calculator</a>
				
				<a href="emi-calculator.aspx">Loan EMI Calculator</a>
				
				
			
                  </div></div>
                 
                  </div>
                </div>
                  </div>
                              
                </li>



                <%--SECOND LEVEL MENU 5--%>

          <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="unclaimed-deposits.aspx" title="Un-Claimed Deposits">
          <strong class="mob-icon fa fa-mouse-pointer"></strong>Un-Claimed Deposits</a>
           
                              
                </li>

                 <%--SECOND LEVEL MENU 6--%>

          <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="download-forms.aspx" title="Downloads & Forms">
          <strong class="mob-icon fa fa-mouse-pointer"></strong>Downloads & Forms</a>
       
                              
                </li>



                     <%--SECOND LEVEL MENU 7--%>

          <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="external-links.aspx" title="External Links">
          <strong class="mob-icon fa fa-mouse-pointer"></strong>External Links</a>
           
                              
                </li>

                         <%--SECOND LEVEL MENU 8--%>

          <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="" title="Search our Site">
          <strong class="mob-icon fa fa-mouse-pointer"></strong>Search our Site</a>
         
                              
                </li>


                               <%--SECOND LEVEL MENU 9--%>

          <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="bank-holidays.aspx" title="Bank Holidays">
          <strong class="mob-icon fa fa-mouse-pointer"></strong>Bank Holidays</a>
           
                              
                </li>


  <%--SECOND LEVEL MENU 10--%>

          <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="" title="Points of Presence">
          <strong class="mob-icon fa fa-mouse-pointer"></strong>Points of Presence</a>
             <div class="megamenu clearfix" style="width: 266px;
    margin-right: 23%;">
              <div class="dropdown">
            <div class="dd-inner ">
                  <div class="column2 singledropdown">
                   <div class="" id="tab2"> <img src="images/menu3.jpg" alt="About Us" longdesc="" class="menucolimg">
				<a href="http://www.tmb.in/network_map/access_our_pan_India_branch_atm_network.html" title="Network Map"> Network Map</a>
				<a href="eLobby-centres.aspx" title="eLobby Centres">eLobby Centres </a>
				<a href="atm-centres.aspx" title="ATM Centres"> ATM Centres </a>
				<a href="tie-up-branches.aspx" title=" Tie Up Branches"> Tie Up Branches</a>
				<a href="admin-offices.aspx" title="Admin Offices">Admin Offices</a>
				<a href="nearest-branch-atm.aspx" title="Nearest Branch /ATM"> Nearest Branch /ATM</a>
				<a href="smart-Phone-navigation-assistance.aspx" title="Smart Phone Navigation Assistance"> Smart Phone Navigation Assistance</a>
				    </div>
                  </div>
            </div>
                </div>
                  </div>
                              
                </li>
				
				 <%--SECOND LEVEL MENU 11--%>

          <li><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span><a href="" title="Policies & Disclosures">
          <strong class="mob-icon fa fa-mouse-pointer"></strong>Policies & Disclosures</a>
             <div class="megamenu clearfix" style="width: 266px;
    margin-right: 23%;">
              <div class="dropdown">
            <div class="dd-inner ">
                  <div class="column2 singledropdown">
                   <div class="" id="Div6"> <img src="images/menu3.jpg" alt="About Us" longdesc="" class="menucolimg">
				<a href="bankings-codes.aspx" title="Bankings Codes & Standards Board of India Commitment">Bankings Codes & Standards Board of India Commitment </a>
				<a href="banking-ombudsman.aspx" title="Banking Ombudsman">Banking Ombudsman </a>
				<a href="basel-disclosures.aspx" title="Basel Disclosures"> Basel Disclosures</a>
				<a href="policies.aspx" title="Policies">Policies</a>
				
				    </div>
                  </div>
            </div>
                </div>
                  </div>
                              
                </li>
 
       
       <%--SECOND LEVEL MENU 12--%>
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
<a href="searchpage.aspx?zoom_query="><img src="images/search1.png" style="float: right; margin-top: 13px;"></a>

		<ul>
		
			<!--  <li><a href="">Item 2</a></li>
		    <li><a href="">Item 3</a></li>
		    <li><a href="">Item 4</a></li>
		    <li><a href="">Item 5</a></li>
		    <li><a href="">Item 6</a></li> -->
			 <li><a href="home.aspx">Personal Banking</a></li>
			  <li><a href="home-nri.aspx">NRI</a></li>
			  <li><a href="home-corporate.aspx">Business & Corporate Banking</a></li>
			 <li><a href="home.msme.aspx">MSME</a></li>
			<li><a href="https://www.tmbnet.in/tmb_careers/" target="_blank">Careers</a></li>
			<li><a href="home-aboutus.aspx">About us</a></li>
			
			<li class="mega" data-column="5"><a href="home-helpdesk.aspx">Helpdesk</a>
		    	<ul>				
		    		<li><a href="#">Contact Us</a>
		    			<ul>
				    	<li><a href="contact-us.aspx">Contact Us</a></li>
		    			</ul>
		    		</li>
					
					
		    		<li><a href="#">Customer Care / Support</a>
		    			<ul>
				    		
<li><a href="	feedback.aspx	">	Write to Us / Feedback	</a></li>
<li><a href="	grievance.aspx	">	Complaint / Grievance	</a></li>
<li><a href="	rates-at-a-glance.aspx	">	Rates at a Glance	</a></li>
<li><a href="	how-to.aspx	">	How To / FAQ	</a></li>
<li><a href="	whats-new.aspx	">	Whats New @ TMB	</a></li>


		    			</ul>
		    		</li>
		    		<li><a href="#">Term deposit Account</a>
		    			<ul>
		    				<li><a href="nre-fixed-deposits .aspx">NRE - Fixed Deposits </a></li>
<li><a href="nre-muthukuvial-deposits .aspx">NRE - Muthukuvial Deposits</a></li>
<li><a href="fcnr-deposits.aspx">FCNR (B) Deposits</a></li>
<li><a href="rfc-scheme-account.aspx ">RFC Scheme Account </a></li>
<li><a href="tax-savings-account.aspx ">Tax Savings Account </a></li>

						
		    			</ul>
		    		</li>
		    		
		    		<li><a href="#">Public Notice</a>
		    			<ul>
				    		<li><a href="	press-release.aspx	">	Press Release	</a></li>
<li><a href="	sale-notice.aspx	">	Sale Notice	</a></li>

						
		    			</ul>
		    		</li>
		    		<li><a href="#">Calculators </a>
					<ul>
				    		<li><a href="		">	Maturity Interest Calculator
	</a></li>
<li><a href="		">	Loan EMI Calculator
	</a></li>

						
		    			</ul>
					
					</li>
					
					<li><a href="un-claimed-deposits.aspx">Un-Claimed Deposits</a></li>
					<li><a href="download-forms.aspx">Downloads & Forms</a></li>
					<li><a href="external-links.aspx">External Links</a></li>
					<li><a href="">Search our Site</a></li>
					<li><a href="bank-holidays.aspx">Bank Holidays</a></li>
					
		    		<li><a href="#">Points of Presence</a>
		    			<ul>		    			
		    				<a href="http://www.tmb.in/network_map/access_our_pan_India_branch_atm_network.html" title="Network Map"> Network Map</a>
				<a href="eLobby-centres.aspx" title="eLobby Centres">eLobby Centres </a>
				<a href="atm-centres.aspx" title="ATM Centres"> ATM Centres </a>
				<a href="tie-up-branches.aspx" title=" Tie Up Branches"> Tie Up Branches</a>
				<a href="admin-offices.aspx" title="Admin Offices">Admin Offices</a>
				<a href="nearest-branch-atm.aspx" title="Nearest Branch /ATM"> Nearest Branch /ATM</a>
				<a href="smart-Phone-navigation-assistance.aspx" title="Smart Phone Navigation Assistance"> Smart Phone Navigation Assistance</a>


		    			</ul>
		    		</li>
					<li><a href="home-corporate.aspx">Policies & Disclosures </a>
			<ul>
			<li><a href="	bankings-codes.aspx	">	Bankings Codes & Standards Board of India Commitment	</a></li>
<li><a href="	banking-ombudsman.aspx	">	Banking Ombudsman	</a></li>
<li><a href="	basel-disclosures.aspx	">	Basel Disclosures	</a></li>
<li><a href="	policies.aspx	">	Policies	</a></li>

			</ul>
			</li>
			
		
				
				
				
						    		
		    	</ul>
		    </li>		  <!-- main li-->
		   
			
			
			
			

		</ul>
	</div><!-- .stellarnav -->

	<script type="text/javascript" src="js/stellarnav.js"></script>
	<script type="text/javascript">
		jQuery(document).ready(function($) {
			jQuery('.stellarnav').stellarNav({
				theme: 'dark',
				breakpoint: 1200,
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