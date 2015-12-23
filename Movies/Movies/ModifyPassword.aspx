<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyPassword.aspx.cs" Inherits="Movies.ModifyPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>密码修改</title>
<link href="css/promt.css" rel="stylesheet" type="text/css" />
<%--<link rel="stylesheet" type="text/css" href="Setting.css" />--%>
<link rel="stylesheet" type="text/css" href="css/Setting.css" />
<%--<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/setting.js"></script>--%>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/setting.js" type="text/javascript"></script>
    <script src="Js/back.js" type="text/javascript"></script>
</head>

<body>
<form id="form2" runat="server">
<div class="main">
  <div class="img">
  <a href="UserInfo.aspx">
      <img src="image/back.png" width="50" height="50"   class="imgback" />
  </a>
  
   </div>
  <div class="prompt1"> 修改下面的信息需要您输入密码验证。否则请返回 </div>
  
    <div class="prompt2"> 当前的密码 </div>
    <div class="oldpsw">
    <%--  <input name="oldpsw" type="password" value="" maxlength="12" />--%>
      <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <div class="prompt3"> 新密码 </div>
    <div class="newpsw">
<%--      <input class="newpswinp" type="password" value="" maxlength="12"/>--%>

       <asp:TextBox ID="NewPasswordTextBox" runat="server" class="newpswinp" TextMode="Password"></asp:TextBox>
    </div>
    <div class="prompt4"> 再次输入 </div>
    
    <div class="newpsw_re">
     <asp:TextBox ID="CheckPasswordTextBox" runat="server" class="newpsw_reinp" TextMode="Password"></asp:TextBox>
      <%--<input class="newpsw_reinp" id="" type="password" value="" maxlength="12"  />--%>
    </div>s
    <div class="error"></div>
    <div class="submit">
    <asp:Button ID="ConfirmButton" runat="server" Text="确认修改"  onclick="ConfirmButton_Click" CssClass="button" BorderWidth="0" />
    </div>
 </form>
</body>