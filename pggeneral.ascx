<%@ Control Language="C#" AutoEventWireup="true" CodeFile="pgaboutus.ascx.cs" Inherits="pgaboutus" %>
<%@ Register Src="~/youarehere.ascx" TagPrefix="uc" TagName="YouAreHere" %>
<%@ Register Src="~/InnerPageBannercntrl.ascx" TagPrefix="uc" TagName="InnerPageBannercntrl" %>
<%@ Register Src="~/getcontent.ascx" TagPrefix="uc" TagName="Getcontent" %>
<%@ Register Src="~/menucntrl.ascx" TagPrefix="uc" TagName="Menucntrl" %>
<%@ Register Src="~/bottomcntrl.ascx" TagPrefix="uc" TagName="Bottomcntrl" %>
<%@ Register Src="~/topcntrl.ascx" TagPrefix="uc" TagName="Topcntrl" %>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<meta name="viewport" content="width=device-width, initial-scale=1">

<link rel="stylesheet" href="css/nli-index-custom.min.css" type="text/css">
<script type="text/javascript" async="" src="js/ga.js"></script>
<link rel="stylesheet" href="css/style.css" type="text/css" media="screen">
<link rel="stylesheet" href="css/vertical_menu.css" type="text/css" media="screen">
<link rel="stylesheet" type="text/css" media="all" href="css/webslidemenu.css">
<link rel="stylesheet" href="css/main.css" type="text/css">
<link rel="stylesheet" href="css/homepage.css" type="text/css">
<link rel="stylesheet" href="css/rates.css" type="text/css">
<link rel="stylesheet" href="css/accordian.css" type="text/css">
<link rel="stylesheet" href="css/homepage.min.css" type="text/css">
<script type="text/javascript" src="js/homepage.min.js"></script>
<link rel="stylesheet" href="css/bannerCarousel.min.css" type="text/css">
<link rel="stylesheet" href="css/blog-style.css" type="text/css">
<link href="css/fonts.css" rel='stylesheet' type='text/css' />
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
<%--TOP CONTROLLER--%>
<uc:Topcntrl runat="server" ID="ucTopcntrl" />
<%--TOP CONTROLLER--%>
<%--INNERPAGEBANNER CONTROLLER--%>
<uc:InnerPageBannercntrl runat="server" ID="ucInnerPageBannercntrl" />
<%--INNERPAGEBANNER CONTROLLER--%>
<%--YOUAREHERE CONTROLLER--%>
<uc:YouAreHere runat="server" ID="ucYouAreHere" />
<%--YOUAREHERE CONTROLLER--%>
<%--Menu CONTROLLER--%>
<uc:Menucntrl runat="server" ID="ucMenucntrl" />
<%--Menu CONTROLLER--%>
<%--CONTENT CONTROLLER--%>
<uc:Getcontent runat="server" ID="ucGetcontent" />
<%--CONTENT CONTROLLER--%>
<%--BOTTOM CONTROLLER--%>
<uc:Bottomcntrl runat="server" ID="ucBottomcntrl" />
<%--BOTTOM CONTROLLER--%>



<!-- jQuery and friends -->
<script type="text/javascript" src="lib/js/jquery-1.10.1.min.js"> </script>

<!-- Bootstrap -->
<script type="text/javascript" src="lib/js/bootstrap/bootstrap.js"></script>

<!-- Bootstrap TabCollapse-->
<script type="text/javascript" src="js/bootstrap-tabcollapse.js"></script>

<script type="text/javascript">
    $('button').on('click', function(){
        alert('preserve attached java script data!');
    });
    $('#myTab').tabCollapse();
</script>

<!-- required -->
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
	<!-- required -->
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