$(document).ready(function(){
	var hei = "-=" + $("li").height().toString();
	//alert(hei);
	$("#btnup").click(function() {
		$(".body_slide").animate({
			"top": hei
		}, 300 );
		//$("#0").slideToggle("slow");
		//$("#img1").show("slow");
		//$("#img0").slideUp();
		//$("#img1").slideDown("slow");
	});
	$("#btndown").click(function() {
		$(".body_slide").animate({
			top: '+=128px'
		}, 300 );
	});
	$("#btnauto").click(function() {
		slidePo(".body_slide","li","30px");
	});
	$("#btn0").click(function() {
		slidePo(".body_slide","li","30px");
	});
	$("#btn1").click(function() {
		slidePo(".body_slide","li","-150px");
	});
	$("#btn2").click(function() {
		slidePo(".body_slide","li","-300px");
	});
	$("#btn3").click(function() {
		slidePo(".body_slide","li","-450px");
	});
	$("#btn4").click(function() {
		slidePo(".body_slide","li","-500px");
	});
	$("#btn5").click(function() {
		slidePo(".body_slide","li","50px");
	});
	
	
});

function slidePo(vec,attribute,desPo) {
	//var curPo = $(attribute).height().toString();
	//var slidewidth = "-=" + $(attribute).height().toString();
	$(vec).animate({
		"left": desPo
	}, 300 );
	
}
