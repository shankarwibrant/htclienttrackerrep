$(document).ready(function(){
$('#purple').hide();
$('#blue').hide();

$(document).on('click','#blue',function(){
$('#purple').hide();
$('#blue').show();
});


$(document).on('click','#purple',function(){
$('#purple').show();
$('#blue').hide();
});
});