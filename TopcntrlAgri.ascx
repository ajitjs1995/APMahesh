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
	<li><a href="home.aspx"><img src="images/homeicon.png"/></a></li>
      <li class=""><a href="home.aspx">Personal Banking</a></li>
      <li><a href="home-nri.aspx">NRI</a></li>
      <li><a href="home-corporate.aspx">Corporate Banking</a></li>
      <li><a href="home-msme.aspx">MSME</a></li>
	  <li class="selected"><a href="home-agriculture.aspx">Agriculture</a></li>
      <li><a href="https://www.tmbnet.in/tmb_careers/" target="_blank">Careers</a></li>
      <li><a href="home-aboutus.aspx">About us</a></li>
      <li><a href="contact-us.aspx">Contact Us</a></li>
	  
      <li><img src="images/socialbottom.png" border="0" usemap="#Map" width="" style="margin-left: 134%;margin-top: -7px;">
        <map name="Map">
          <area shape="rect" coords="2,2,31,41" href="https://www.facebook.com/tmbltd" target="_blank">
          <area shape="rect" coords="35,3,65,35" href="https://twitter.com/tmbstepahead" target="_blank">
          <area shape="rect" coords="67,2,99,40" href="#">
        </map>
      </li>
    </ul>
    <div class="SearcContainer desktopsearch-container">
    
  
      <input value="Personal" name="segment" type="hidden">
     <%-- <input id="Search" placeholder="Search" name="token" type="text" class="ui-autocomplete-input" autocomplete="off">
      <input value="" class="MagnifyingGlass" type="submit">--%>

      <input title="Enter the terms you wish to search for."  type="text" class="ui-autocomplete-input" autocomplete="off"
  placeholder="Search here" onfocus="if(this.value == 'Search here') {this.value = '';}"  
 onkeydown="javascript: return myFunction(this.form.zoom_query.value)" 
 id="zoom_query" name="zoom_query"  size="15" maxlength="128"/>
<button id="btn" type="submit" onclick="javascript: return check(this.form.zoom_query.value)" class="MagnifyingGlass"></button>

    </div>
  </div>
</header>
<div class="clear"> </div>
<!--Top bar End-->
<!--Top Header Start-->
<div class="headercontainer">
  <div class="midcontainer" style="position: relative;">
    <div class="logo"> <a href="Home.aspx" title=""> <img src="images/tmb-logo.png" alt="" longdesc=""></a></div>
    <div class="iconss" style="float:right">
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
          <li style="float:left"><span class="wsmenu-click"><i class="wsmenu-arrow fa fa-angle-down"></i></span>
		  <a href="" title="Loan Products"><strong class="mob-icon fa fa-male"></strong>Loan Products</a>
            <div class="megamenu clearfix" style="width: 266px;">
              <div class="dd-inner">
                <div class="column2 singledropdown"> <img src="images/LoanProductsAgri-top.jpg" alt="About Us" longdesc="" class="menucolimg">
                 <div class="" id="tab1"> 
				 <a href="tmb-banana-cultivation.aspx" title="TMB Banana Cultivation" class="">TMB Banana Cultivation</a>
				 <a href="tmb-bhoomi-heen-kisan.aspx" title="TMB Bhoomi Heen Kisan">TMB Bhoomi Heen Kisan</a>
				 <a href="tmb-poultry-farm-broiler.aspx" title="TMB Poultry Farm – Broiler">TMB Poultry Farm – Broiler</a>
				 <a href="tmb-poultry-farm-layer.aspx" title="TMB Poultry Farm – Layer">TMB Poultry Farm – Layer</a>
				 <a href="tmb-diary-mini-commercial.aspx" title="TMB Dairy – Mini & Commercial">TMB Dairy – Mini & Commercial</a>
				 <a href="tmb-brackish-water.aspx" title="TMB Brackish Water">TMB Brackish Water</a> 
				 <a href="tmb-composite-fish-farm.aspx" title="TMB Composite Fish Farm">TMB Composite Fish Farm</a>
				 <a href="tractor.aspx" title="TMB Tractor">TMB Tractor</a>
				 <a href="tmb-agri-transport.aspx" title="TMB Agri Transport">TMB Agri Transport</a> 
				  </div>
                </div>
              </div>
            </div>
          </li>
         
  
          
		  
        
       
       <li style="float: right;"><ul style="margin-top: -10px;">
		<li>
              <button class="button" onclick="window.open('https://www.tmbnet.in/');">
            &nbsp;&nbsp;&nbsp;&nbsp;Internet Banking
            </button>
			</br>
             <button class="buttoncard" onclick="window.open('https://prepaid.tmbnet.in/tmbcreditcustomer/html/LoginFrame.jsp');">
            &nbsp;&nbsp;&nbsp;&nbsp;Credit Card Portal
            </button>
          </li></ul></li>
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
   
    <li><a href="home.aspx" style="background: #c6017e;">Personal Banking</a></li>
    <li class="mega" data-column="5"><a href="" style="background: #c6017e;">NRI</a></li>
    <!-- main li-->
	<li><a href="home-corporate.aspx" style="background: #c6017e;">Business & Corporate Banking</a></li>
    <li><a href="home-msme.aspx" style="background: #c6017e;">MSME</a></li>	
   <li><a href="home-agriculture.aspx" style="background: #c6017e;">Agriculture</a>
   <ul>
        <li><a href="#" style="background: #1c3a90;">Loan Products</a>
          <ul>
            <li><a href="tmb-banana-cultivation.aspx" title="TMB Banana Cultivation" class="">TMB Banana Cultivation</a></li>
			<li><a href="tmb-bhoomi-heen-kisan.aspx" title="TMB Bhoomi Heen Kisan">TMB Bhoomi Heen Kisan</a></li>
			<li><a href="tmb-poultry-farm-broiler.aspx" title="TMB Poultry Farm – Broiler">TMB Poultry Farm – Broiler</a></li>
			<li><a href="tmb-poultry-farm-layer.aspx" title="TMB Poultry Farm – Layer">TMB Poultry Farm – Layer</a></li>
			<li><a href="tmb-diary-mini-commercial.aspx" title="TMB Diary – Mini & Commercial">TMB Diary – Mini & Commercial</a></li>
			<li><a href="tmb-brackish-water.aspx" title="TMB Brackish Water">TMB Brackish Water</a></li>
			<li><a href="tmb-composite-fish-farm.aspx" title="TMB Composite Fish Farm">TMB Composite Fish Farm</a></li>
			<li><a href="tractor.aspx" title="TMB Tractor">TMB Tractor</a></li>
			<li><a href="tmb-agri-transport.aspx" title="TMB Agri Transport">TMB Agri Transport</a></li></li>
          </ul>
        </li>        
      </ul>
   </li>
    <li><a href="https://www.tmbnet.in/tmb_careers/" target="_blank" style="background: #c6017e;">Careers</a></li>
    <li><a href="home-aboutus.aspx" style="background: #c6017e;">About us</a></li>
    <li><a href="contact-us.aspx" style="background: #c6017e;">Contact Us</a></li>
  </ul>
</div>
<!-- .stellarnav -->
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
