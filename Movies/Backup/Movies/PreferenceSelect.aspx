<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreferenceSelect.aspx.cs" Inherits="Movies.PreferenceSelect" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>用户偏好选择</title>
    <link href="css/promt.css" rel="stylesheet" type="text/css" />
    <link href="css/pref.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/pref.js" type="text/javascript"></script>
</head>
<body background="image/b2.jpg">
    <form id="form1" runat="server">
   
<div class="main">
  <div class="img">
    <a href="UserInfo.aspx">
       <img src="image/back.png" width="50" height="50" />
    </a>
    
 </div>
 
  <div class="center">
    <div class="type"> 偏爱的电影类型: </div>

    <div class="mainchoose">

    
    <label for="Love"> <div class="pref" ><div class="back_text">爱情</div><img class="imgchoose" src="image/choose.png"  width="80"/> </div></label>
    <label for="Action"><div class="pref" > <div class="back_text"> 动作 </div><img class="imgchoose" src="image/choose.png"  width="80"/> </div></label>
    <label for="Terrifiy"><div class="pref" > <div class="back_text">惊悚 </div><img class="imgchoose" src="image/choose.png"  width="80"/> </div></label>
    <label for="Cartoon"><div class="pref" > <div class="back_text">动画 </div><img class="imgchoose" src="image/choose.png"  width="80"/> </div></label>
    <label for="Comedy"><div class="pref" > <div class="back_text">喜剧 </div><img class="imgchoose" src="image/choose.png"  width="80"/> </div></label>
    <label for="War"><div class="pref" > <div class="back_text">战争 </div><img class="imgchoose" src="image/choose.png"  width="80"/> </div></label>
    <label for="Horrify"><div class="pref">  <div class="back_text"> 恐怖 </div><img class="imgchoose" src="image/choose.png"  width="80"/> </div></label>
    <label for="Crime"><div class="pref" > <div class="back_text"> 犯罪 </div><img class="imgchoose" src="image/choose.png"  width="80"/> </div></label>
   
   <asp:CheckBox ID="Love" runat="server"  CssClass="display" />
   <asp:CheckBox ID="Action" runat="server" CssClass="display" />
   <asp:CheckBox ID="Terrifiy" runat="server" CssClass="display"/> 
   <asp:CheckBox ID="Cartoon" runat="server"   CssClass="display"/>
   <asp:CheckBox ID="Comedy" runat="server"    CssClass="display"/>
   <asp:CheckBox ID="War" runat="server"  CssClass="display" /> 
   <asp:CheckBox ID="Horrify" runat="server"    CssClass="display"/>
   <asp:CheckBox ID="Crime" runat="server"   CssClass="display"/>

    </div>
    
  </div>

 
  <div class="back">
  <asp:Button ID="ConfirmButton" runat="server" Cssclass="aspButton"  Text="确认" onclick="ConfirmButton_Click" BorderWidth="0"  />     
  </div>  
  

</div>


    
        
  
    </form>
</body>
</html>
