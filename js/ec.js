function integerInRange(a, b, c) {
    return jvalue = a.value, isNaN(jvalue) ? (a.focus(), !1) : parseInt(jvalue) >= b && parseInt(jvalue) <= c ? (document.rl_mat_calc.isubmit.disabled = !1, !0) : (a.focus(), !1)
}

function loadXMLDoc(a) {
    window.XMLHttpRequest ? (req = new XMLHttpRequest, req.onreadystatechange = processReqChange, req.open("GET", a, !0), req.send()) : window.ActiveXObject && (req = new ActiveXObject("Microsoft.XMLHTTP"), req && (req.onreadystatechange = processReqChange, req.open("GET", a, !0), req.send()))
}

function processReqChange() {
    req.readyState == 4 && (req.status == 200 ? (oResult = document.getElementById("dep_mat_value"), oResult.innerHTML = req.responseText) : alert("Problem Status: " + req.status))
}

function calcclick() {
    return val0 = document.getElementById("itype").value,
    val1 = document.getElementById("ivalue").value,
    val2 = document.getElementById("irate").value,
    val3 = document.getElementById("iperiod").value,
    val4 = document.getElementById("itype_name").value,
    oResult = document.getElementById("dep_mat_value"),
    oResult.innerHTML = '<div class="preload_calc">&nbsp;</div>',
    loadXMLDoc("emi_calc/itype-" + val0 + "/ivalue-" + val1 + "/irate-" + val2 + "/iperiod-" + val3),
    typeof ga.q != "undefined" && ga.q !== null && ga("send", "pageview", "loan_emi_calc/" + val4 + "/irate-" + val2 + "/iperiod-" + val3 + "/ivalue-" + val1), 
    !1
}
var req