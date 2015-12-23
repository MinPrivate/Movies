<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Movies.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   
   <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>好看电影网</title>
    <link href="Css/main.css" rel="stylesheet" type="text/css" />
    <link href="Css/slide.css" rel="stylesheet" type="text/css" />
    <script src="Js/jquery.js" type="text/javascript"></script>
    <script src="Js/slides.min.jquery.js" type="text/javascript"></script>
    <script src="Js/user_slide.js" type="text/javascript"></script>
    <script src="Js/main_pop.js" type="text/javascript"></script>
    <script src="Js/mainpagedatadeal.js" type="text/javascript"></script>
     
    <link href="Css/promt.css" rel="stylesheet" type="text/css" />
</head>
<body id="bodystyle" background="image/b1.jpg">
    <form id="Form1" runat="server">
		

<div class="leftColum">
              <div class="selectButton" id="hotPlay">热<br>门</div>
             <div class="selectButton" id="rankPlay">评<br>价</div>
            <div class="selectButton" id="recommandPlay">推<br>荐</div>
</div>

<div class="mainDiv">
	<div class="header1">
        <div  class="hotPlay" id="playType">上映类型</div>
        <div  class="region">地区</div>
        <div class="searchBox">
          <input class="search"  value="搜索您喜欢的电影">
        </div>
        <div class="searchButton" id="searchMovie">搜索</div>
        <a href="CinemaList.aspx">
        <div id="tocinema">影院</div>
        </a>
        <a href="UserInfo.aspx">
        <div id="toUserCenter">登录</div>
        </a>
	</div>

<div id="slides">	

</div>   
</div>
<div class="hotPlay-pop">
	<div class="hotPlay-pop-item">热映中</div>
	<div class="hotPlay-pop-item">即将上映</div>
</div>
<div class="region-pop">
    <div class="region-pop-item">汉阳</div>
    <div class="region-pop-item">洪山</div>
    <div class="region-pop-item">江岸</div>
    <div class="region-pop-item">江汉</div>
    <div class="region-pop-item">武昌</div>
    <div class="region-pop-item">硚口</div>
    <div class="region-pop-item">青山</div>
    <div class="region-pop-item">江夏</div>
    <div class="region-pop-item">黄陂</div>
    <div class="region-pop-item">新洲</div>
    <div class="region-pop-item">经济技术开发</div>
</div>

    </form>
</body>
</html>

