//(function ($) {
//    $.braviPopUp = function (src, width, height) {
//        //Destroy if exist
//        $('#dv_move').remove();
//        //create hte popup html
//        var html = '<div class="main" id="dv_move" style=" margin-top: -10px;width:' + width + 'px; height:' + height + 'px;">';
//        //        html += '  <div class="title">';
//        //        html += '    <span id="title_left">' + title + '</span> <span class="close">';
//        //        html += ' <img id="img_close" src="images/close.png" width="25" height="23" ></span></div>';

//        //        html += '<div style="border-bottom: solid #181818 2px;margin-top:5px;color:White; border-bottom-color: #666666;" class="tabs">';
//        //        html += '</div>';
//        html += ' <div id="dv_no_move">';
//        html += '<div id="dv_load"><img src="images/circular.gif"/></div>';

//        html += ' <iframe id="url" class="tabs" scrolling="auto"  src="' + src + '"  style="border:none;" width="100%" height="100%"></iframe>';

//        html += '<input type="button" class="button" style=" margin-left: 200px; margin-top: -50px;" id="butt" value="Cancel"/>';

//        //        html += '<input type="button" class="button" onClick="document.location.reload(true)" style=" margin-left: 200px; margin-top: -50px;" id="butt" value="Cancel"/>';
//        html += ' </div>';

//        html += ' </div>';

//        //add to body
//        $('<div></div>').prependTo('body').attr('id', 'overlay'); // add overlay div to disable the parent page
//        $('body').append(html);
//        //enable dragable
//        $('#dv_move').draggable();
//        //enable resizeable
//        $("#dv_move").resizable({
//            minWidth: 300,
//            minHeight: 100,
//            maxHeight: 768,
//            maxWidth: 1024
//        });


//        $("#img_close").click(function () {
//            $('#overlay').fadeOut('slow');
//            $('#dv_move').fadeOut('slow');
//            setTimeout("$('#dv_move').remove();", 1000);

//        });
//        $("#butt").click(function () {
//            $('#overlay').fadeOut('slow');
//            $('#dv_move').fadeOut('slow');
//            setTimeout("$('#dv_move').remove();", 1000);

//        });
//        $("#dv_no_move").mousedown(function () {
//            return false;
//        });
//        $("#title_left").mousedown(function () {
//            return false;
//        });
//        $("#img_close").mousedown(function () {
//            return false;
//        });
//        //change close icon image on hover
//        $("#img_close").mouseover(function () {
//            $(this).attr("src", 'images/close2.png');
//        });
//        $("#img_close").mouseout(function () {
//            $(this).attr("src", 'images/close.png');
//        });

//        setTimeout("$('#dv_load').hide();", 1500);
//    };
//})(jQuery);

(function ($) {
    $.braviPopUp = function (title, src, width, height) {
        //Destroy if exist
        $('#dv_move').remove();
        //create hte popup html
        var html = '<div class="main" id="dv_move" style="width:' + width + 'px; height:' + height + 'px;">';
        html += '  <div class="title1" ></div>';
        html += '  <div class="title">';
        html += '    <span id="title_left">' + title + '</span> <span class="close">';
        html += ' <img id="img_close" src="../Content/close1.png"  width="25" height="23" "></span></div>';
        html += ' <div id="dv_no_move">';
        html += '<div id="dv_load"></div>';
        html += ' <iframe id="url" scrolling="auto" src="' + src + '"  style="border: 0px  #FFFFFF ;" width="100%" height="100%"></iframe>';
        html += ' </div>';
        html += ' </div>';
        /// <reference path="../close1.png" />

        //add to body/// <reference path="../close.jpg" />

        $('<div></div>').prependTo('body').attr('id', 'overlay'); // add overlay div to disable the parent page
        $('body').append(html);
        //enable dragable
        $('#dv_move').draggable();
        //enable resizeable
        $("#dv_move").resizable({
            minWidth: 300,
            minHeight: 100,
            maxHeight: 768,
            maxWidth: 1024
        });

        $("#dv_no_move").mousedown(function () {
            return false;
        });
        $("#title_left").mousedown(function () {
            return false;
        });
        $("#img_close").mousedown(function () {
            return false;
        });
        //change close icon image on hover
        $("#img_close").mouseover(function () {
            $(this).attr("src", 'images/close2.png');
        });
        $("#img_close").mouseout(function () {
            $(this).attr("src", 'images/close.png');
        });
        $("#img_close").click(function () {  
             $('.overlay').fadeOut('slow');
            $('#dv_move').fadeOut('slow');
            setTimeout("$('#dv_move').remove();", 1000);

            //call Refresh(); if we need to reload the parent page on its closing
            // parent.Refresh();
        } );
        setTimeout("$('#dv_load').hide();", 1500);
    };
})(jQuery); 