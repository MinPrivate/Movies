$(function () {
    popleft(".hotPlay", ".hotPlay-pop");

    popleft(".region", ".region-pop");

    $(window).resize(function () {
        popleft(".hotPlay", ".hotPlay-pop");

        popleft(".region", ".region-pop");

    });

    pop(".hotPlay", ".hotPlay-pop");

    pop(".region", ".region-pop");


    itemclick(".hotPlay-pop-item", ".hotPlay");
    itemclick(".region-pop-item",".region");
    //itemclick(".cinema-pop-item", ".cinema");

    $('.cinema-pop-item').live('click', function () {
        $(".cinema").text($(this).text());
    });
});


	
function popleft(classpos,classloc){
	var left =  $(classpos).offset().left;
	$(classloc).css("left",left);
}

function pop(classclick,classpop){
	$(classclick).hover(function(){
	    $(classpop).css("display", "block");
	},
	function(){
		$(classpop).css("display","none");
	});
	
	$(classpop).hover(function(){
		$(classpop).css("display","block");
	},
	function(){
		$(classpop).slideUp(100);
	});
}

function itemclick(classclick,classswap){
	$(classclick).click(function(){
		$(classswap).text($(this).text());
	});
}