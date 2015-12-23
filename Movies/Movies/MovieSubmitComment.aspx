<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MovieSubmitComment.aspx.cs"
    Inherits="Movies.MovieSubmitComment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   
    <script src="Js/jquery.js" type="text/javascript"></script>
    <script src="Js/back.js" type="text/javascript"></script>
    <script src="Js/cinema_list.js" type="text/javascript"></script>
    <link href="Css/promt.css" rel="stylesheet" type="text/css" />
    <title>电影详情</title>
    
    <link href="Css/detail.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 492px;
        }
    </style>
</head>
<body background="image/b7.jpg">
    <form id="form1" runat="server">
    <div class="main">
        <a href="javascript:history.back()">
            <img src="../image/back.png" height="50" width="50" class="imgback" /></a>
        <div class="name">
            <table>
                <caption>
                    <marquee>
    <asp:Label ID="LabelMovieName" runat="server" Text="MovieName"></asp:Label></marquee>
                </caption>
                <tr>
                    <td class="style1">
                        <asp:Label ID="LabelRank" runat="server" Text="Rank" Font-Size="Larger" 
                            ForeColor="Red"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="LabelRankNum" runat="server" Text="Label" Font-Size="Medium"></asp:Label>
                    </td>

                    <td class="buy">
                        <asp:HyperLink ID="HyperLinkBuy" runat="server" NavigateUrl="~/MovieOnShowList.aspx">查看票价</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
        <asp:Button ID="CollectButton" runat="server" CssClass="store" Text="收藏" OnClick="CollectButton_Click">
        </asp:Button>
        <div class="pic">
            <asp:Image ID="ImageMovieDetail" runat="server" Height="300px" Width="210px" />
        </div>
        <div class="intro">
            <div class="intro_text">
                <asp:Label ID="LabelMovieDetails" runat="server" Text="MovieDetails"></asp:Label>
            </div>
        </div>
        <div class="comment">
            <asp:Button ID="ButtonLatestComment" runat="server" 
                Text="最新评论" CssClass="swaphead" Width="100px"  Visible="False" />
            &nbsp;<asp:Button ID="ButtonHotComment" runat="server" 
                Style="margin-left: 34px" Text="热门评论" Width="100px" CssClass="swaphead" Visible="False"/>
            <asp:Button ID="ButtonMyComment" runat="server"  Text="我要评论" 
                CssClass="swaphead" Width="100px" />
            <div class="ccon">
                <div class="mycomment">
                    <div class="level">
                        <div style="float: left;">
                            打个分吧：</div>
                        
                            <%--  <asp:ImageButton  ID="ImageButtonBad" runat="server" ImageUrl="../image/bad.png" Width="30" CommandName="GetData" OnClick="ImageButtonBad_Click" CausesValidation="True" />--%>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            ImageUrl="image/com_none_left.png" width="25"  CssClass="comimage" 
                            onclick="ImageButton1_Click" />
                        <asp:ImageButton ID="ImageButton2" runat="server" 
                            ImageUrl="image/com_none_right.png" width="25" CssClass="comimage" 
                            onclick="ImageButton2_Click" />
                        <asp:ImageButton ID="ImageButton3" runat="server" 
                            ImageUrl="image/com_none_left.png" width="25" CssClass="comimage" 
                            onclick="ImageButton3_Click" />
                        <asp:ImageButton ID="ImageButton4" runat="server" 
                            ImageUrl="image/com_none_right.png" width="25" CssClass="comimage" 
                            onclick="ImageButton4_Click" />
                        <asp:ImageButton ID="ImageButton5" runat="server" 
                            ImageUrl="image/com_none_left.png" width="25" CssClass="comimage" 
                            onclick="ImageButton5_Click" />
                        <asp:ImageButton ID="ImageButton6" runat="server" 
                            ImageUrl="image/com_none_right.png" width="25" CssClass="comimage" 
                            onclick="ImageButton6_Click" />
                        <asp:ImageButton ID="ImageButton7" runat="server" 
                            ImageUrl="image/com_none_left.png" width="25" CssClass="comimage" 
                            onclick="ImageButton7_Click" />
                        <asp:ImageButton ID="ImageButton8" runat="server" 
                            ImageUrl="image/com_none_right.png" width="25" CssClass="comimage" 
                            onclick="ImageButton8_Click" />
                        <asp:ImageButton ID="ImageButton9" runat="server" 
                            ImageUrl="image/com_none_left.png" width="25" CssClass="comimage" 
                            onclick="ImageButton9_Click" />
                        <asp:ImageButton ID="ImageButton10" runat="server" 
                            ImageUrl="image/com_none_right.png" width="25" CssClass="comimage" 
                            onclick="ImageButton10_Click" />
                    </div>
                    <asp:TextBox ID="CommentTextBox" runat="server"  CssClass="inputclass" 
                        TextMode="MultiLine"/>
                    <asp:Button ID="SubmitButton" runat="server"  CssClass="inputbut" Text="提交" 
                        onclick="SubmitButton_Click" />
                        
                </div>
            </div>
            <!-- Baidu Button BEGIN -->
            <script type="text/javascript" id="bdshare_js" data="type=slide&img=0&pos=right&uid=782150"></script>
            <script type="text/javascript" id="bdshell_js"></script>
            <script type="text/javascript">
                var bds_config = { "bdTop": 166
                }
                document.getElementById("bdshell_js").src = "http://bdimg.share.baidu.com/static/js/shell_v2.js?cdnversion=" + new Date().getHours();

            </script>
            <!-- Baidu Button END -->
        </div>
    </div>
    </form>
</body>
</html>
