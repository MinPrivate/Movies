
$(function(){
	checkpwd(".newpswinp",".error");
	recheckpwd(".newpswinp", ".newpsw_reinp", ".error");

	backhover(".imgback");
});


//cknpwd
function recheckpwd(classinput1,classinput2,error){
	 $(classinput2).blur(function() {
		  if($(classinput1).val() != $(classinput2).val())
		  {
    		$(error).text("密码不相符，请确认！");
     	 }else{
			 $(error).text(" ");
		 }
	});
}

function checkpwd(classinput,error){
	 $(classinput).blur(function() {
		  if($(classinput).val() == "" || !$(classinput).val().match(/^[0-9a-zA-Z]{6,20}$/))
		  {
    		$(error).text("密码输入格式错误!");
     	 }else{
			 $(error).text(" ");
		 }
	});
}