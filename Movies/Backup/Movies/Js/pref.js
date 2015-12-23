
$(function(){
    $(".pref").click(function () {


		if($(this).children(".imgchoose").css("display") == "none"){
			$(this).children(".imgchoose").css("display","block");
		}else{
			$(this).children(".imgchoose").css("display","none");
		}
});
backhover(".imgback");
});