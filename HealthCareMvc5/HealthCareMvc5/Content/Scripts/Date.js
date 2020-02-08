function dates(fromdat, todate) {
    var birthdate = fromdat; // in   "mm/dd/yyyy" format    
    var senddate = todate; // in   "mm/dd/yyyy" format    
    var x = birthdate.split("/");
    var y = senddate.split("/");
    var bdays = x[1];
    var bmonths = x[0];
    var byear = x[2];     //alert(bdays);     
    var sdays = y[1];
    var smonths = y[0];
    var syear = y[2];     //alert(sdays);     
    if (sdays < bdays) {
        sdays = parseInt(sdays) + 30;
        smonths = parseInt(smonths) - 1;         //alert(sdays);         
        var fdays = sdays - bdays;         //alert(fdays);     
    }
    else {
        var fdays = sdays - bdays;
    }
    if (smonths < bmonths) {
        smonths = parseInt(smonths) + 12; 
        syear = syear - 1;
        var fmonths = (smonths - bmonths)+1;
    }
    else {
        var fmonths = (smonths - bmonths)+1;
    }
    var fyear = syear - byear;
    return fmonths;
    document.getElementById('patientAge').value = fyear + ' years ' + fmonths + ' months ' + fdays + ' days';

}

function datevalid() {
    try {
        var d1 = Frmon.value.substr(0, 2);
        var m1 = Frmon.value.substr(3, 2);
        var y1 = Frmon.value.substr(6, 4);
        var StrDate = m1 + "/" + d1 + "/" + y1;

        var d2 = Tomon.value.substr(0, 2);
        var m2 = Tomon.value.substr(3, 2);
        var y2 = Tomon.value.substr(6, 4);
        var EndDate = m2 + "/" + d2 + "/" + y2;

        var cd = d2 - d1;
        var yr = y2 - y1;
        var mn=m1
        var Aug = 1, Sep = 2, Oct = 3, Nov = 4, Dec = 5;

        var startDate = new Date(StrDate); 
        var endDate = new Date(EndDate);
        var corrdat = new Date(corrdat);

        if (startDate > endDate) {
            alert('To date should be greater than From date.');

            Tomon.value = '';
            Tomon.focus();
            return false;
        }
//        else {
//            if (cd < 5) {
//                
//                    alert("Enter from Dec " + "" + mn);
//                    return false;
//                }

//        }
    } catch (e) {  }
    return true;

}