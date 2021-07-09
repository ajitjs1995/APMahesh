<%@ Page Language="VB" AutoEventWireup="false" CodeFile="searchpage.aspx.vb" Inherits="searchpage" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	
	<!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-157825538-1"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());

  gtag('config', 'UA-157825538-1');
</script>
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

        //debugger;
        if (document.getElementById("zoom_query").value == "") {
            alert("Please enter value for search");
            document.getElementById("zoom_query").focus();
            return false;
        }
//        else if (document.getElementById("zoom_query").value == "") {
//            alert("Please enter value for search");
//            document.getElementById("zoom_query").focus();
//            return false;
//        }
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

            if (document.getElementById("zoom_query").value == "") {
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
	
</head>
<body>
  <!--   <form id="form1" runat="server">
    <div>
    
    </div>
    </form> -->
</body>
</html>
--%>