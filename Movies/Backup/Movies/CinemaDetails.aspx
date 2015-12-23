<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CinemaDetails.aspx.cs"
    Inherits="Movies.CinemaDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    
    <script src="Js/jquery.js" type="text/javascript"></script>
    <title>电影院详情</title>
    
    <link href="Css/detail.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 302px;
        }
    </style>
</head>
<body background="/image/b7.jpg">
    <form id="form1" runat="server">
    <div class="main">
        <%--<a href="javascript:history.back()">
            <img src="../image/back.png" height="50" width="50" class="img1" /></a>--%>
            <a href="../CinemaList.aspx">
            <img src="../image/back.png" height="50" width="50" class="imgback" /></a>
        <div class="name">
            <table>
                <caption>
                    <marquee>
    <asp:Label ID="LabelCinemaName" runat="server" Text="CinemaName"></asp:Label></marquee>
                </caption>
                <tr>
                    <td class="style1">
                        <asp:Label ID="LabelRank" runat="server" Text="Rank" Font-Size="Larger" ForeColor="Red"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="LabelRankNum" runat="server" Text="Label" Font-Size="Medium"></asp:Label>
                    </td>
                    <td class="buy">
                        <asp:HyperLink ID="HyperLinkBuy" runat="server" NavigateUrl="~/MovieList.aspx">播放影片列表</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
       <%-- <div class="pic">
            <div style="width: 210px; height: 300px; border: 1px solid gray" id="dituContent">
            </div>
        </div>--%>
         <div class="pic">
            <asp:Image ID="ImageCinemaDetail" runat="server" Height="300px" Width="210px" />
        </div>
        <div class="intro">
            <div class="intro_text">
                <asp:Label ID="LabelCinemaDetails" runat="server" Text="CinemaDetails"></asp:Label>
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
                <asp:Repeater ID="CommentRepeater" runat="server" OnItemCommand="CommentRepeater_ItemCommand">
                    <ItemTemplate>
                        <div class="ccon">
                            <div class="dtcom">
                                <div class="comhead">
                                    <div class="namediv">
                                        <asp:Label ID="LabelUserName" runat="server" Text='<%# (Eval("userName"))%>'></asp:Label></div>
                                    <div class="goodorbad">
                                        <asp:Label ID="LabelSupport" runat="server" Text='<%# Eval("support") %>' Font-Italic="False"></asp:Label>&nbsp;<asp:ImageButton
                                            ID="ImageButtonGood" runat="server" ImageUrl="../image/good.png" Width="30" CommandName="GetData"
                                            OnClick="ImageButtonGood_Click" CausesValidation="True" />&nbsp;
                                        <asp:Label ID="LabelOppose" runat="server" Text='<%# Eval("oppose") %>'></asp:Label><asp:ImageButton
                                            ID="ImageButtonBad" runat="server" ImageUrl="../image/bad.png" Width="30" CommandName="GetData"
                                            OnClick="ImageButtonBad_Click" CausesValidation="True" /></div>
                                </div>
                                <div style="clear: both">
                                </div><div>
                                <asp:Label ID="LabelComment1" runat="server" Height="114px" Text='<%# Eval("body") %>'
                                    Width="630px" EnableTheming="True" Font-Overline="True"></asp:Label>
                                <span class="dttime">
                                    <br />
                                    <asp:Label ID="LabelCommentTime" runat="server" Text='<%# Eval("time") %>'></asp:Label></span>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            
        </div>
        <!-- Baidu Button BEGIN -->

        <script type="text/javascript" id="bdshare_js" data="type=slide&img=0&pos=right&uid=782150" ></script>

        <script type="text/javascript" id="bdshell_js"></script>

        <script type="text/javascript">
            var bds_config = { "bdTop": 166 }
            document.getElementById("bdshell_js").src = "http://bdimg.share.baidu.com/static/js/shell_v2.js?cdnversion=" + new Date().getHours();

        </script>

        <!-- Baidu Button END -->
        
       <%-- <script type="text/javascript">
            var map = new BMap.Map("dituContent");            // 创建Map实例
            var point = new BMap.Point(116.404, 39.915);    // 创建点坐标
            map.centerAndZoom(point, 15); // 初始化地图，设置中心点坐标和地图级别。

            //创建和初始化地图函数：
            function initMap() {
                createMap(); //创建地图
                setMapEvent(); //设置地图事件
                addMapControl(); //向地图添加控件
            }

            //创建地图函数：
            function createMap() {
                var map = new BMap.Map("dituContent"); //在百度地图容器中创建一个地图
                var point = new BMap.Point(114.361123, 30.532285); //定义一个中心点坐标
                map.centerAndZoom(point, 17); //设定地图的中心点和坐标并将地图显示在地图容器中
                window.map = map; //将map变量存储在全局
            }

            //地图事件设置函数：
            function setMapEvent() {
                map.enableDragging(); //启用地图拖拽事件，默认启用(可不写)
                map.enableScrollWheelZoom(); //启用地图滚轮放大缩小
                map.enableDoubleClickZoom(); //启用鼠标双击放大，默认启用(可不写)
                map.enableKeyboard(); //启用键盘上下左右键移动地图
            }

            //地图控件添加函数：
            function addMapControl() {
                //向地图中添加缩放控件
                var ctrl_nav = new BMap.NavigationControl({ anchor: BMAP_ANCHOR_TOP_LEFT, type: BMAP_NAVIGATION_CONTROL_LARGE });
                map.addControl(ctrl_nav);
                //向地图中添加缩略图控件

                //向地图中添加比例尺控件
                var ctrl_sca = new BMap.ScaleControl({ anchor: BMAP_ANCHOR_BOTTOM_LEFT });
                map.addControl(ctrl_sca);
            }


            initMap(); //创建和初始化地图

	

</script>--%>


    </div>
    </form>
</body>
</html>
