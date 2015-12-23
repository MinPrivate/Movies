function getCon() {
		$.get("SpeechServlet", {
			input : input,
		},

		//此参数相当于回调函数
		function(json) {
			alert(json);
		});
}
var con = [
		"英雄本色","周杰伦", "俞斌强", "强哥", "强仔", "刘德华", "李连杰", 
		"Taobao", "Tom", "Yahoo", "JavaEye", "Csdn", "Alipay"
	];
$(document).ready(function(){
	//自动补全获取数据
	$(".search").click(function() {
		$.post("returnCon", {
			flag : "1",
		},
		function(json) {
			con = json;
		});
	});
	//自动补全
	$(".search").autocomplete(con,{
		minChars: 0,
		autoFill: true,
		matchContains: true,
		max: 5,
		highlightItem: false,
	});
	//滑动
	$('#slides').slides({
			preload: true,
			//generateNextPrev: true,
			generatePagination: false
	});
	//改变gif
	$(".pagination li img").click(function() {
		$(".pagination li img").attr("src","image/normal.png");
		this.src = 'image/current.png';
	});
	checkinput(".search","请输入电影名或人名...");
	
	$(".word_middle").click(function(){
		$(".word_middle").css("color","grey");	
		$(this).css("color","white");
	});

 
});

function checkinput(classinput,defstr){
	//失去焦点
  $(classinput).blur(function() {
	  if (($(classinput).val() == defstr) || ($(classinput).val() == "") ) {
		  $(classinput).val(defstr);
		  $(classinput).css('color','grey');
	  }
  });
	//得到焦点
  $(classinput).focus(function() {
		if (($(classinput).val() == defstr) || ($(classinput).val() == "") ) {
		  $(classinput).val("");
	  	}
	  	$(classinput).css('color','white');
  });
}