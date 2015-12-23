<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="Movies.UserInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Css/promt.css" rel="stylesheet" type="text/css" />
    <link href="Css/user_collecting.css" rel="stylesheet" type="text/css" />
    <script src="Js/jquery.js" type="text/javascript"></script>
    <script src="Js/slides.min.jquery.js" type="text/javascript"></script>
    <script src="Js/user_slide.js" type="text/javascript"></script>
    <script src="Js/back.js" type="text/javascript"></script>
    <script src="Js/datatransfer.js" type="text/javascript"></script>

    <%--<link href="css/promt.css" rel="stylesheet" type="text/css" />
    <link href="css/user_collecting.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/slides.min.jquery.js" type="text/javascript"></script>
    <script src="js/user_slide.js" type="text/javascript"></script>
    <script src="js/datatransfer.js" type="text/javascript"></script>--%>
   
    
</head>
<body background="image/b2.jpg">
    <form id="form1" runat="server">
 
    <div ID="mainbox" class="mainbox_user" runat="server">

		<div class="boxhead">
			  <div class="boxhead1">
                <a href="Main.aspx">
                <img src="image/back.png" width="50" height="50" class="imgback" />
                </a>
              
         </div>
         
             <input id="CollectButton" type="button" value="收藏" class="boxhead2"/>
             <asp:Button ID="PasswordAdmButton" runat="server" Text="密码管理" class="boxhead2" 
                  onclick="PasswordAdmButton_Click"  />
             <asp:Button ID="PreferenceAdmButton" runat="server" Text="偏好订阅管理"   
                  class="boxhead2" onclick="PreferenceAdmButton_Click"  />
             <asp:Button ID="ChangeUserButton" runat="server" Text="退出登录"  class="boxhead2" 
                  onclick="ChangeUserButton_Click"  />

		</div>
        <div id="slides">          
		</div>
    </div>

    </form>
</body>
</html>
