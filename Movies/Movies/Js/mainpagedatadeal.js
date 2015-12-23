/// <reference path="jquery.js" />


$(function () {
    $("#hotPlay").click(function () {
        $.ajax(
        {
            type: "POST",
            url: "MainPageDataDeal.aspx",
            data: "selectType=" + "hot",
            error: function (XMLHttpRequest, testStatus, errorThrown) {
                //alert("error");
            },
            success: function (html) {
                $("#slides").empty();
                $("#slides").append(html);
            }
        }
        )
    });
    $("#rankPlay").click(function () {
        $.ajax(
        {
            type: "POST",
            url: "MainPageDataDeal.aspx",
            data: "selectType=" + "rank",
            error: function (XMLHttpRequest, testStatus, errorThrown) {
                //alert("error");
            },
            success: function (html) {
                // alert("success");
                $("#slides").empty();
                $("#slides").append(html);
            }
        }
        )
    });
    $("#recommandPlay").click(function () {
        $.ajax(
        {
            type: "POST",
            url: "MainPageDataDeal.aspx",
            data: "selectType=" + "recommend",
            error: function (XMLHttpRequest, testStatus, errorThrown) {
                // alert("error");
            },
            success: function (html) {
                $("#slides").empty();
                $("#slides").append(html);
                //$("#slides").load("MainPageDataDeal.aspx")
            }
        }
        )
    });
    $(".playType").click(function () {

        $.ajax(
        {
            type: "POST",
            url: "MainPageDataDeal.aspx",
            data: { selectType: "recommend", value: message },
            // data:"hello"+"nihao",
            error: function (XMLHttpRequest, testStatus, errorThrown) {
                //alert("error");
            },
            success: function (html) {
                $("#slides").empty();
                $("#slides").append(html);
                //$("#slides").load("MainPageDataDeal.aspx")
            }
        }
        )
    });
    $.ajax(
        {
            type: "POST",
            url: "MainPageDataDeal.aspx",
            data: "selectType=" + "load",
            error: function (XMLHttpRequest, testStatus, errorThrown) {
                //alert("error");
            },
            success: function (html) {

                $("#slides").empty();
                $("#slides").append(html);

            }
        })


    $('.hotPlay-pop').click(function () {    //是否热映
        var playtype = $("#playType").text();


        $.ajax(
        {
            type: "POST",
            url: "MainPageDataDeal.aspx",
            data: { selectType: "playType", message: playtype },
            error: function (XMLHttpRequest, testStatus, errorThrown) {
                //alert("error");
            },
            success: function (html) {

                $("#slides").empty();
                $("#slides").append(html);

            }
        })


    });









    $('.region-pop').click(function () {//根据地区检索相关电影
        var playAddr = $(".region").text();


        $.ajax(
        {
            type: "POST",
            url: "MainPageDataDeal.aspx",
            data: { selectType: "playAddr", addr: playAddr },
            error: function (XMLHttpRequest, testStatus, errorThrown) {
                //alert("error");
            },
            success: function (html) {

                $("#slides").empty();
                $("#slides").append(html);

            }
        })


    });





});



    



    //传递大图片的电影名字
    $(".specialMovieDetail").live("click",function () {
        var moviename = $(this).attr("data-movie-name");
        //alert(moviename);
        $.ajax({
            type: "POST",
            url: "MovieDetails.aspx",

            data: { movieName: moviename },
            // data:"hello"+"nihao",
            error: function (XMLHttpRequest, testStatus, errorThrown) {
               // alert("error");
            },
            success: function (html) {
               // alert("scuess");
                location.href = "MovieDetails.aspx";
                // $("#slides").empty();
                // $("#slides").append(html);
                //$("#slides").load("MainPageDataDeal.aspx")
            }
        });
    });





    //传递大图片的电影名字
    $(".commonMovieDetail").live("click", function () {
        var moviename = $(this).attr("data-movie-name");
       // alert(moviename);
        $.ajax({
            type: "POST",
            url: "MovieDetails.aspx",

            data: { movieName: moviename },
            // data:"hello"+"nihao",
            error: function (XMLHttpRequest, testStatus, errorThrown) {
                //alert("error");
            },
            success: function (html) {
                //alert("scuess");
                location.href = "MovieDetails.aspx";
                // $("#slides").empty();
                // $("#slides").append(html);
                //$("#slides").load("MainPageDataDeal.aspx")
            }
        });
    });


    $(function(){
        $('#searchMovie').click(function () {//根据输入信息检索相关电影

            $("#slides").empty();
                //$("#slides").append(main.html);

                $.get("main.html", function (data) { //初始將a.html include div#iframe
                    $("#slides").html(data);
                });
                
            });


        });

