$(document).ready(function () {
    //滑动
    $('#slides').slides({
        preload: true,
        //generateNextPrev: true,
        generatePagination: false
    });
    //改变gif
    $(".pagination li img").click(function () {
        $(".pagination li img").attr("src", "image/normal.png");
        this.src = 'image/current.png';
    });
    $(".boxhead2").click(function () {
        $(".boxhead2").css("color", "grey");
        $(this).css("color", "white");
    });

    checkinput(".search", "搜索您喜欢的电影");
});



function checkinput(classinput, defstr) {
    //失去焦点
    $(classinput).blur(function () {
        if (($(classinput).val() == defstr) || ($(classinput).val() == "")) {
            $(classinput).val(defstr);
            $(classinput).css('color', 'white');
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