  $(function(){
	  var swaplength = $(".swap").length;
	  
	  $(".swap:eq(0):eq(swaplength)").after("<div class='swap'><div class='boxb_2a'><div class='boxb_2a1'></div><div class='boxb_2a2'></div><div class='boxb_2a3'></div></div><div class='boxb_2b'><div class='boxb_2b1'>333333</div><div class='boxb_2b2'>33333</div></div><div class='boxb_2c'><div class='boxb_2c1'>33333</div></div></div>");
	  
  });
  
  $(document).ready(function(){
	  $("#bt").click(function() {
		  slidePo(".mainswap","-891px");
	  });
	  $("input:eq(3)").focusout(function() {
		  if($("input:eq(3)").val()!=$("input:eq(3)").val())
		  {
			  
		  }
		  else document.forms[0].submit();
	  });
  });
  
  function slidePo(vec,desPo) {
	  //var curPo = $(attribute).height().toString();
	  //var slidewidth = "-=" + $(attribute).height().toString();
	  $(vec).animate({
		  "left": desPo
	  }, 300 );
	  
  }
  
  
  function checkValidPasswd(str){
		var reg = /^[x00-x7f]+$/;
		if (! reg.test(str)){
		 return false;
		}
		if (str.length < 6 || str.length > 16){
		 return false;
		}
		return true;
  }