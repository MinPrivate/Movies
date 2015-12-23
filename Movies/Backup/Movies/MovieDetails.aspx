<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MovieDetails.aspx.cs" Inherits="Movies.MovieDetails" EnableEventValidation="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    
    <script src="Js/jquery.js" type="text/javascript"></script>
    <script src="Js/back.js" type="text/javascript"></script>
     <script src="js/comment.js" type="text/javascript"></script>
    <title>电影详情</title>
 
    <link href="Css/detail.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 454px;
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
    <asp:Label ID="LabelMovieName" runat="server" Text="MovieName"></asp:Label></marquee></caption>
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
        <asp:button ID="CollectButton" runat="server"  CssClass="store" Text="收藏" 
            onclick="CollectButton_Click"></asp:button>
        <div class="pic">
            <asp:Image ID="ImageMovieDetail" runat="server" Height="300px" Width="210px" />
        </div>
        <div class="intro">
            <div class="intro_text">
                <asp:Label ID="LabelMovieDetails" runat="server" Text="MovieDetails"></asp:Label>
            </div>
        </div>
        <div class="comment">
            <asp:Button ID="ButtonLatestComment" runat="server" OnClick="ButtonLatestComment_Click"
                Text="最新评论" CssClass="swaphead" Width="100px" />
            &nbsp;<asp:Button ID="ButtonHotComment" runat="server" OnClick="ButtonHotComment_Click"
                Style="margin-left: 34px" Text="热门评论" Width="100px" CssClass="swaphead" />
            <asp:Button ID="ButtonMyComment" runat="server" OnClick="ButtonMyComment_Click" Text="我要评论"
                CssClass="swaphead" Width="100px" />
            <div class="combody">
                <asp:Repeater ID="CommentRepeater" runat="server" 
                    OnItemCommand="CommentRepeater_ItemCommand">
                    <ItemTemplate>
                        <div class="ccon">
                            <div class="dtcom">
                                <div >
                                    <div class="namediv">
                                        <asp:Label ID="LabelUserName" runat="server" Text='<%# (Eval("userName"))%>'></asp:Label></div>
                                    <div class="goodorbad">
                                        <asp:Label ID="LabelSupport" runat="server" Text='<%# Eval("support") %>' Font-Italic="False"></asp:Label>&nbsp;<asp:ImageButton
                                            ID="ImageButtonGood" runat="server" ImageUrl="../image/good.png" Width="30"  CommandName="GetData" OnClick="ImageButtonGood_Click" CausesValidation="True" />&nbsp;
                                        <asp:Label ID="LabelOppose" runat="server" Text='<%# Eval("oppose") %>'></asp:Label><asp:ImageButton
                                            ID="ImageButtonBad" runat="server" ImageUrl="../image/bad.png" Width="30" CommandName="GetData" OnClick="ImageButtonBad_Click" CausesValidation="True" /></div>
                                </div>
                                <div style="clear: both">
                                </div>
                                <asp:Label ID="LabelComment1" runat="server" Height="114px" Text='<%# Eval("body") %>'
                                    Width="613px" CssClass="comhead"></asp:Label>
                                <span class="dttime">
                                    <br />
                                    <asp:Label ID="LabelCommentTime" runat="server" Text='<%# Eval("time") %>'></asp:Label></span>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <%-- <div class="swapDiv">
                <a href="#">上一页</a>&nbsp;&nbsp;第 &nbsp;1&nbsp;&nbsp;页&nbsp;&nbsp;<a
                    href="#">下一页</a></div>--%>
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
    </form>
</body>
</html>
