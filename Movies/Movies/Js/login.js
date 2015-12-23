$(document).ready(function () {
    checkinput(".memail", "请输入邮箱...");
    checkinput(".nname", "请输入您的昵称...");
    checkinput(".nemail", "请输入您的邮箱...");
    checkemail(".memail");
    checkemail(".nemail");
    checkpwd(".mpwd");
    checkpwd(".npwd");
    recheckpwd(".npwd", ".cknpwd");
    checkname(".nname");
    backhover(".imgback");
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
	  	$(classinput).css('color','black');
  });
}

function checkemail(classinput){
		//得到焦点
	  $(classinput).focus(function() {
			if (($(classinput).parent().parent().next().find("span").eq(0).val!="") ) {
			  $(classinput).parent().parent().next().find("span").eq(0).replaceWith("<span></span>");
			}
  		});
	 $(classinput).blur(function() {
		  if(!$(classinput).val().match(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/)){
    	//	error
		$(classinput).parent().parent().next().find("span").eq(0).replaceWith("<span>邮箱输入错误！</span>");
      }
	});
}

function checkpwd(classinput){
	 $(classinput).blur(function() {
		  if($(classinput).val() == "" || !$(classinput).val().match(/^[0-9a-zA-Z]{6,20}$/))
		  {
    		$(classinput).parent().parent().next().find("span").eq(0).replaceWith("<span>密码输入格式错误！</span>");
     	 }else{
			 $(classinput).parent().parent().next().find("span").eq(0).replaceWith("<span></span>");
		 }
	});
}

//cknpwd
function recheckpwd(classinput1,classinput2){
	 $(classinput2).blur(function() {
		  if($(classinput1).val() != $(classinput2).val())
		  {
    		$(classinput2).parent().parent().next().find("span").eq(0).replaceWith("<span>密码不相符，请确认！</span>");
     	 }else{
			 $(classinput2).parent().parent().next().find("span").eq(0).replaceWith("<span></span>");
		 }
	});
}

function checkname(classinput){
	$(classinput).blur(function() {
		  if(!$(classinput).val().match(/^[0-9a-zA-Z\u4e00-\u9fa5]{6,20}$/))
		  {
    		$(classinput).parent().parent().next().find("span").eq(0).replaceWith("<span>昵称不正确！</span>");
     	 }else{
			 $(classinput).parent().parent().next().find("span").eq(0).replaceWith("<span></span>");
		 }
	});
}