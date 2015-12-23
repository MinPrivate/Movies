$(function(){
	var hasclick= 0;
	$(".comimage").hover(
	  function () {
		  var thisloc = $(this).index();
		  var lgim =  $(".comimage").length;
		 for(i = 0;i < lgim;i++){
			 if(i%2 == 1){
				 $(".comimage").eq(i).attr("src","image/com_half_right.png");
			 }else{
				 $(".comimage").eq(i).attr("src","image/com_half_left.png");
			 }
			 if(i + 1 == thisloc){
			 	break;
			}
		 }
		 for(i = thisloc;i < lgim;i++){
			 if(i%2 == 1){
				 $(".comimage").eq(i).attr("src","image/com_none_right.png");
			 }else{
				 $(".comimage").eq(i).attr("src","image/com_none_left.png");
			 }
			}
	  },
	  function () {
		  if(!hasclick){
		 $(".comimage:even").attr("src","image/com_none_left.png");
		 $(".comimage:odd").attr("src","image/com_none_right.png");
		  }
	  });
	  
	  $(".comimage").click(function(){
		  	hasclick=1;
	   });
		var tmpstring =  $("marquee").text();
		if(tmpstring.length>15){
			$("marquee").replaceWith("<marquee>"+tmpstring+"</marquee>");
		}else{
			$("marquee").replaceWith(tmpstring);
		}
    backhover(".imgback");
});