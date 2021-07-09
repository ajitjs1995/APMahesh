
//function for show Message On Save and Update
function HideLabel() {
    var seconds = 5;
    setTimeout(function () {
        $('[id$=lblstatus]').hide();
        //document.getElementById("<%= lblstatus.ClientID %>").style.display = "none";
    }, seconds * 1000);
};
function HideLabelErr() {
    var seconds = 5;
    setTimeout(function () {
        $('[id$=lblerr]').hide();
        //document.getElementById("<%= lblstatus.ClientID %>").style.display = "none";
    }, seconds * 1000);
};
function HideDivForgotPassword() {
    var seconds = 5;
    setTimeout(function () {
        $('[id$=divresult]').hide();
        //document.getElementById("<%= lblstatus.ClientID %>").style.display = "none";
    }, seconds * 1000);
};
$(document).ready(function () {
    $("#name").keypress(function (event) {
        var charCode = (event.which) ? event.which : event.getAscii();
        if ((charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122) || (charCode == 46 || charCode == 8 || charCode == 44 || charCode == 0 || charCode == 47 || charCode == 45 || charCode == 9 || charCode == 32))
            return true;
        else
            return false;

    });
});
function isTextNum(evt) {
    var charCode = (evt.which) ? evt.which : evt.getAscii();
    if ((charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122) || (charCode >= 48 && charCode <= 57) || (charCode == 46 || charCode == 8 || charCode == 44 || charCode == 0 || charCode == 47 || charCode == 45 || charCode == 9 || charCode == 32))
        return true;
    else
        return false;
}
function isText(e) {
    var charCode = (e.which) ? e.which : e.getAscii();
    //var charCode = (e.which) ? e.which : e.keyCode;
    if ((charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122) || (charCode == 46 || charCode == 8 || charCode == 44 || charCode == 0 || charCode == 47 || charCode == 45 || charCode == 9 || charCode == 32))
        return true;
    else
        return false;
}
function isNumber(evt) {
    var iKeyCode = (evt.which) ? evt.which : evt.getAscii();
    if ((iKeyCode >= 48 && iKeyCode <= 57) || iKeyCode == 8)
        return true;
    else
        return false;
}
function isNumberFloat(evt) {
    var iKeyCode = (evt.which) ? evt.which : evt.getAscii();
    if ((iKeyCode >= 48 && iKeyCode <= 57) || (iKeyCode == 8 || iKeyCode == 46 || iKeyCode == 47))
        return true;
    else
        return false;
}
function isEmail(evt) {
    var charCode = (evt.which) ? evt.which : evt.getAscii();
    if ((charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122) || (charCode >= 48 && charCode <= 57) || (charCode == 64 || charCode == 46 || charCode == 8 || charCode == 0 || charCode == 95 || charCode == 45 || charCode == 9 || charCode == 32))
        return true;
    else
        return false;
}
function check(e) {
    var charCode = (e.which) ? e.which : e.keyCode;
    if ((charCode >= 48 && charCode <= 57) || (charCode == 8 || charCode == 0))
        return true;
    else
        return false;


    /*var charCode = (e.which) ? e.which : e.keyCode;
    if ((charCode >= 48 && charCode <= 57) || (charCode == 46 || charCode == 08 || charCode == 37 || charCode == 39))
    return true;
    else
    return false;*/

}
$(document).ready(function () {
    $('[id$=tagsinput]').keypress(function (event) {
        var charCode = (event.which) ? event.which : event.getAscii();
        if ((charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122) || (charCode == 46 || charCode == 8 || charCode == 44 || charCode == 0 || charCode == 47 || charCode == 45 || charCode == 9 || charCode == 32))
            return true;
        else
            return false;

    });

    $("[id*=imageClear]").click(function () {
        //Reference the FileUpload and get its Id and Name.
        var fileUpload = $("[id*=fuImage]");
        var id = fileUpload.attr("id");
        var name = fileUpload.attr("name");

        //Create a new FileUpload element.
        var newFileUpload = $("<input type = 'file' />");

        //Append it next to the original FileUpload.
        fileUpload.after(newFileUpload);

        //Remove the original FileUpload.
        fileUpload.remove();

        //Set the Id and Name to the new FileUpload.
        newFileUpload.attr("id", id);
        newFileUpload.attr("name", name);
        return false;

    });
    $("[id*=imgClearAS]").click(function () {
        //Reference the FileUpload and get its Id and Name.
        var fileUpload = $("[id*=fuImageAS]");
        var id = fileUpload.attr("id");
        var name = fileUpload.attr("name");

        //Create a new FileUpload element.
        var newFileUpload = $("<input type = 'file' />");

        //Append it next to the original FileUpload.
        fileUpload.after(newFileUpload);

        //Remove the original FileUpload.
        fileUpload.remove();

        //Set the Id and Name to the new FileUpload.
        newFileUpload.attr("id", id);
        newFileUpload.attr("name", name);
        return false;

    });
    $("[id*=imageClear]").click(function () {
        //Reference the FileUpload and get its Id and Name.
        var fileUpload = $("[id*=fuBanner]");
        var id = fileUpload.attr("id");
        var name = fileUpload.attr("name");

        //Create a new FileUpload element.
        var newFileUpload = $("<input type = 'file' />");

        //Append it next to the original FileUpload.
        fileUpload.after(newFileUpload);

        //Remove the original FileUpload.
        fileUpload.remove();

        //Set the Id and Name to the new FileUpload.
        newFileUpload.attr("id", id);
        newFileUpload.attr("name", name);
        return false;
    });
});

//Remove HTML tag from text box 
//$(document).ready(function () {
//    $('input[type=text]').blur(function () {
//        console.log(this.value);
//       // console.log($(this).text());
//        var regex = /(<([^>]+)>)/ig
//        var body = this.value;
//        var result = body.replace(regex, "");
//        this.value = result;
//        
//    });
//});


//$(document).ready(function () {
//    $("input").keypress(function (event) {
//        if (event.which == 13) {
//            event.preventDefault();
//            $("[id*=btnSave]").click();
//        }
//    });
//    $("input").keypress(function (event) {
//        if (event.which == 13) {
//            event.preventDefault();
//            $("[id*=btnUpdate]").click();
//        }
//    });
//    $("input").keypress(function (event) {
//        if (event.which == 13) {
//            event.preventDefault();
//            $("[id*=BtnLogin]").click(); 
//        }
//    });
//    $("input").keypress(function (event) {
//        if (event.which == 13) {
//            event.preventDefault();
//            $("[id*=BtnFP]").click();
//        }
//    });
//});


$(document).ready(function () {
    $(".close").click(function () {
        $(".alert").hide();

    });
    $(".srchbx1").keypress(function (event) {
        if (event.which == 13) {
            event.preventDefault();
            var text = $('.srchbx1').val();
            window.location = "search.aspx?SrStr=" + text + "";
        }
    });
    $(".srchbtn").click(function () {
        var text = $('.srchbx1').val();
        window.location = "search.aspx?SrStr=" + text + "";
    });
});

//-----------------Feedback Form CheckboxList validation-------------------------------//

$(document).on('change', '.requiredfeedback', function (e) {

    //var temp = '#' + $(this).attr('id');
    var checked_checkboxes = $("[id*=ckboccupation] input:checked");
    //var checked_chk2 = $("[id*=ckbaccounttype] input:checked");
    if (checked_checkboxes.length > 0) {
        console.log("up");
        $(this).removeClass("errborder");
        if ($(this).next().attr('class') == 'err') {
            $(this).next().remove();
        }
    }
    else {
        if (!$(this).next().hasClass('err')) {
            $(this).after("<div class='err'>*Required</div>");
        }
        $(this).addClass("errborder");
    }

});
$(document).on('change', '.requiredfeedback2', function (e) {

    //var temp = '#' + $(this).attr('id');

    var checked_chk2 = $("[id*=ckbaccounttype] input:checked");
    if (checked_chk2.length > 0) {
        console.log("down");
        $(this).removeClass("errborder");
        if ($(this).next().attr('class') == 'err') {
            $(this).next().remove();
        }
    }
    else {
        if (!$(this).next().hasClass('err')) {
            $(this).after("<div class='err'>*Required</div>");
        }
        $(this).addClass("errborder");
    }
});
//-----------------Feedback Form CheckboxList validation-------------------------------//





//------------------Function for change content and classes on Language change---------------------//
$(document).ready(function () {
	$('.orgbx h3 a').text('Internet Banking Login');
	if($('.orgbx h3 .fa-angle-right').length<1){$('.orgbx h3 a').after('<strong aria-hidden="true" class="fa fa-angle-right"></strong>')}
	
    var LanID = $("#HdnLangID").val();
    if (LanID == 2) {
        $('body').addClass('hindi-content');
        $('.logo a img').attr("src", "images/PNB-logo-hindi.jpg");
        $('.base-rate .midcontainer ul li h3').text('मार्केट फीड');
        $('.base-rate .midcontainer ul li h4').text('(प्रत्येक 15 मिनट में अद्यतन)');
        $('.base-rate .midcontainer ul .daily-update:eq(0)').text('पीएनबी');
		$('.base-rate .midcontainer ul .daily-update:eq(1)').text('एनएसई ');
		$('.base-rate .midcontainer ul .daily-update:eq(2)').text('बीएसई');
        $('.base-rate .midcontainer ul .daily-update:eq(3)').text('दैनिक फौरेक्स');
        $('.mob-homenewscontainer .midcontainer h3').text('समाचार बज्ज');
        $('.homenewscontainer .midcontainer h3').html('समाचार बज्ज <i class="fa fa-angle-right ticker-arrow"></i>');
        $('.bottom-content .catap .midcontainer').html('<div class="content-sec2-part"><ul class="content-sec2-nav"><li class="content-sec2-head"><a href="Calculator_.aspx" target="_blank"><img src="images/footer/calculator.png" alt="Calculators" />कैलकुलेट </a></li></ul></div><div class="content-sec2-part" style="border-right: none;"><ul class="content-sec2-nav"><li class="content-sec2-head"><a href="EAuction.aspx" target="_blank"><img src="images/auction.jpg" alt="#" />नीलामी</a> </li></ul></div><div class="content-sec2-part" style="border-right: none;"><ul class="content-sec2-nav"><li class="content-sec2-head"><a href="Tender.aspx" target="_blank"><img src="images/tender-icon.png" alt="#" />टेंडर / मनोनयन</a> </li></ul></div><div class="content-sec2-part" style="border-right: none;"><ul class="content-sec2-nav"><li class="content-sec2-head"><a href="Public-Notices.html"><img src="images/public-notice.png" alt="#" />पब्लिक नोटिस</a></li></ul></div><div class="content-sec2-part" style="border-right: none;"><ul class="content-sec2-nav"><li class="content-sec2-head"><a href="Recruitments.html"><img src="images/recruitment-circle.jpg" alt="भर्ती/कॅरियर" longdesc="PNB" />भर्ती/कॅरियर</a></li></ul></div><div class="content-sec2-part" style="border-right: none;"><ul class="content-sec2-nav"><li class="content-sec2-head"><a href="https://www.pnbindia.in/downloadprocess.aspx?fid=tIaxm4O0a0Y9BxNV43pdug==" target="_blank"><img src="images/holiday.jpg" alt="बैंक अवकाश" />बैंक अवकाश </a></li></ul></div>');
//       <div class="content-sec2-part" style="border-right: none;"><ul class="content-sec2-nav"><li class="content-sec2-head"><a href="advisories.html"><img src="images/advisory-icon.png" alt="#" />परामर्शदात्री </a></li></ul></div>
        
        $('.main .midcontainer .footerrgt .footerlink').html('<a href="Screen-Reader-Accessibilty.html" target="_blank">स्क्रीन रीडर एक्सेसबिलिटी  </a> | <a href="disclaimer.html">डिस्क्लेमर  </a> | <a href="privacypolicy.html">गोपनीयता नीति </a> | <a href="contact-us.html">हमसे संपर्क करें </a>| <a href="sitemap.html">साइट का मैप </a>| <a href="Terms-of-use.html">उपयोग की शर्तें </a>');
        $('.main .midcontainer .footbx .copyrgt').html('कॉपीराईट © पंजाब नैशनल बैंक / सभी अधिकार सुरक्षित हैं ');
        $('.main .midcontainer .footerrgt .fotvisitor .countspan').html('विजिट करने वालों में आपका नम्बर हैं ');
        $('.form-bg h3').text('पीएनबी के गौरवशाली कस्टमर बनें');
        $('.orgbx h3 a').text('इंटरनेट बैंकिंग लॉगिन');
        //$('.topheader ul li:eq(0) a').text('अपनी राय साझा करें');
       $('.topheader ul li:eq(0) a').text('मुख्य सामग्री पर जाएं');
        $('.topheader ul li:eq(3) a').text('मुख पृष्ठ');
        $('.topheader ul li:eq(4) a').text('हमसे संपर्क करें');
        $('.topheader ul li:eq(5) a').text('साइट का मैप');
        $('.footertoprgt a').text('सहायक, एसोसिएट्स व संयुक्त उद्यम');
        $('.boxbg2 .ratebox .btnpink').text('और अधि‍क जानें');
		$('.footbx div').html('<span style="color: #91203e;">कॉर्पोरेट ऑफिस :</span> प्लाट नंबर  4 सेक्टर - 10, द्धारका दिल्ली -110075 <a href="https://www.google.co.in/maps/@28.5805443,77.0553804,18z" target="_blank"><img src="images/reachus.jpg" alt="Reach Us" style="width:25px; height:25px;"/></a><br /><div class="copyrgt">कॉपीराईट © पंजाब नैशनल बैंक / सभी अधिकार सुरक्षित हैं </div><br /> ');
		$('.main .midcontainer .footerrgt p').text('साइट की सर्वश्रेष्ठता 1366x768 के रिजोल्यूशन में गूगल क्रोम 30+,आई.ई. 11+, मोज़िला 27+, एंड्रॉयड 5 + और दूसरों के नवीनतम संस्करण में दिखाई देती है');
		$('.main .midcontainer .footerrgt #designBy').html('डिजाइन एवं विकसित <a href="http://www.cyfuture.com" target="_blank" title="Cyfuture India Pvt. Ltd.">Cyfuture</a> द्वारा ');
        $('.main .midcontainer .footerrgt #lblUpdatedText').html('अंतिम अद्यतन:');
    }
    //console.log($("#HdnLangID").val());
});

//------------------End Function for change content and classes on Language change---------------------//