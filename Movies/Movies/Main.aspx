<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Movies.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   
   <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>�ÿ���Ӱ��</title>
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
              <div class="selectButton" id="hotPlay">��<br>��</div>
             <div class="selectButton" id="rankPlay">��<br>��</div>
            <div class="selectButton" id="recommandPlay">��<br>��</div>
</div>

<div class="mainDiv">
	<div class="header1">
        <div  class="hotPlay" id="playType">��ӳ����</div>
        <div  class="region">����</div>
        <div class="searchBox">
          <input class="search"  value="������ϲ���ĵ�Ӱ">
        </div>
        <div class="searchButton" id="searchMovie">����</div>
        <a href="CinemaList.aspx">
        <div id="tocinema">ӰԺ</div>
        </a>
        <a href="UserInfo.aspx">
        <div id="toUserCenter">��¼</div>
        </a>
	</div>

<div id="slides">	

</div>   
</div>
<div class="hotPlay-pop">
	<div class="hotPlay-pop-item">��ӳ��</div>
	<div class="hotPlay-pop-item">������ӳ</div>
</div>
<div class="region-pop">
    <div class="region-pop-item">����</div>
    <div class="region-pop-item">��ɽ</div>
    <div class="region-pop-item">����</div>
    <div class="region-pop-item">����</div>
    <div class="region-pop-item">���</div>
    <div class="region-pop-item">�~��</div>
    <div class="region-pop-item">��ɽ</div>
    <div class="region-pop-item">����</div>
    <div class="region-pop-item">����</div>
    <div class="region-pop-item">����</div>
    <div class="region-pop-item">���ü�������</div>
</div>

    </form>
</body>
</html>

