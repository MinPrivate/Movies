<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Movies.LogIn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>登陆界面</title>
    <link href="css/promt.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/login.js" type="text/javascript"></script>
    <link href="css/login.css" rel="stylesheet" type="text/css" />
    <script src="Js/back.js" type="text/javascript"></script>
</head>
<body background="image/b6.jpg">

<form id="form2" runat="server">
<div class="main">
<div class="backhome">
<a href="Main.aspx">
<%--<img src="../image/back.png" width="50" height="50"/>--%>
<img src="image/back.png" width="50" height="50" class="imgback" />
</a>
</div>
  <div class="memeber">
    <div class="header">已有账户：</div>
    <div class="headerspace">
        <table>
          <tr>
            <td>邮箱：</td>
            <td>
            <%--<input type="email"  class="memail" value="请输入邮箱..."/>--%>
            <asp:TextBox ID="EmailTextBox" runat="server" class="memail" Text="请输入邮箱..."></asp:TextBox>
            </td>
          </tr>
          <tr>
          <td>&nbsp;</td>
          <td><span>&nbsp;</span></td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td><span>&nbsp;</span></td>
          </tr>
            <td>密码：</td>
                 <td>
               <%-- <input type="password" class="mpwd"/>--%>
                <asp:TextBox ID="PasswordTextBox" runat="server" class="mpwd" TextMode="Password"></asp:TextBox>
                </td>
          </tr>
          <td>&nbsp;</td>
            <td><span>&nbsp;</span></td>
          <tr>
            <td>&nbsp;</td>
            <td><span>&nbsp;</span></td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td><span>&nbsp;</span></td>
          </tr>
          <tr>
        
            <td align="center" colspan="2">
            
       <%--     <input type="submit"value="登录" class="button" >--%>
             <asp:Button ID="LoginButton" runat="server" onclick="LoginButton_Click"  Text="登录" class="button" />							            &nbsp;&nbsp;&nbsp; <input type="reset"value="重置"class="button" ></td>
          </tr>
        </table>
    
    </div>
  </div>
  <div class="costomer">
    <div class="header">还未注册：</div>
    <div>
    
 
      <table>
     	 <tr>
         <td>&nbsp;</td>
            <td><span>&nbsp;</span></td>
          </tr>
        <tr>
          <td>昵称：</td>
            <td>
            <%--<input type="text"  class="nname" value="请输入您的昵称..."/>--%>
             <asp:TextBox ID="NameTextBox1" runat="server" class="nname"  Text="请输入您的昵称..."></asp:TextBox>
            </td>
        </tr>
        <tr>
           <td>&nbsp;</td>
            <td><span>&nbsp;</span></td>
          </tr>
        <tr>
          <td>邮箱：</td>
            <td>
<%--          <input type="email"  class="nemail" value="请输入您的邮箱..."/>--%>
          <asp:TextBox ID="EmailTextBox1" runat="server" class="nemail"  Text="请输入您的邮箱..."></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><span>&nbsp;</span></td>
          </tr>
        <tr>
          <td>密码：</td>
          <td><input type="password" class="npwd"/></td>
        </tr>
        <tr>
           <td>&nbsp;</td>
            <td><span>&nbsp;</span></td>
          </tr>
        <tr>
          <td>确认密码：</td>
          <td>
          <%--<input type="password" class="cknpwd"/>--%>
           <asp:TextBox ID="PasswordTextBox1" class="cknpwd"  runat="server" 
                  TextMode="Password"></asp:TextBox>
          </td>
        </tr>
        <tr>
        	<td>&nbsp;</td>
            <td><span>&nbsp;</span></td>
          </tr>
        <tr>
       
          <td align="center" colspan="2">
        
        <%--  <input type="submit"value="创建并登入" class="button" >--%>

          <asp:Button ID="SignButton" runat="server"  class="button" onclick="SignButton_Click" Text="创建并登入" />

            &nbsp;&nbsp;&nbsp;
            <input type="reset"value="重置"class="button" ></td>
        </tr>
      </table>
      </div>
  </div>
</div>
</form>
</body>
</html>