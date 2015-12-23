$(function(){
    $("tr[class='alt']:even").css({ "color": "#000000", "background-color": "#FFFFCC" });
    $(".gridButton:even").css({ "color": "#000000", "background-color": "#FFFFCC" });
    $(".gridButton:odd").css({ "color": "#000000", "background-color": "#fff" });


    $("tr[class='alt']:odd").css({ "color": "#000000", "background-color": "#CCFFCC" });


	var length = 275 - ($(".customers").height());
	$(".customers").css({ "top": -length });

	backhover(".imgback");

	var hasclick = 0;
	$(".comimage").hover(
	  function () {
	      var thisloc = $(this).index();
	      var lgim = $(".comimage").length;
	      for (i = 0; i < lgim; i++) {
	          if (i % 2 == 1) {
	              $(".comimage").eq(i).attr("src", "image/com_half_right.png");
	          } else {
	              $(".comimage").eq(i).attr("src", "image/com_half_left.png");
	          }
	          if (i + 1 == thisloc) {
	              break;
	          }
	      }
	      for (i = thisloc; i < lgim; i++) {
	          if (i % 2 == 1) {
	              $(".comimage").eq(i).attr("src", "image/com_none_right.png");
	          } else {
	              $(".comimage").eq(i).attr("src", "image/com_none_left.png");
	          }
	      }
	  },
	  function () {
	      if (!hasclick) {
	          $(".comimage:even").attr("src", "image/com_none_left.png");
	          $(".comimage:odd").attr("src", "image/com_none_right.png");
	      }
	  });
});

function checkinput(classinput, defstr) {
    //失去焦点
    $(classinput).blur(function () {
        if (($(classinput).val() == defstr) || ($(classinput).val() == "")) {
            $(classinput).val(defstr);
            $(classinput).css('color', 'grey');
        }
    });
    //得到焦点
    $(classinput).focus(function () {
        if (($(classinput).val() == defstr) || ($(classinput).val() == "")) {
            $(classinput).val("");
        }
        $(classinput).css('color', 'black');
    });
}