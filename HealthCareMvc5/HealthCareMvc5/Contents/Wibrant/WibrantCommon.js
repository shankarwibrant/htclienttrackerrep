function Common()
{
    //Login Access

    $('body').removeClass('skin-blue sidebar-mini').addClass('skin-blue sidebar-mini sidebar-collapse');
    $.ajax({
        url: "../Home/LoginAccess",
        type: 'POST',
        success: function (result) {

            if (result == "Failed") {
                alert("Already Same User Login Another System ");
                window.location.href = "../Login/Login";
                //window.location.href = "http://www.octopus-intelligentsystem.com/Alpronew/login/loginpage";
            }
        }
    });

}