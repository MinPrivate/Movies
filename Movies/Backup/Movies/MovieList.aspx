<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MovieList.aspx.cs" Inherits="Movies.MovieList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>电影列表</title>
    <link href="Css/list.css" rel="stylesheet" type="text/css" />
    <script src="Js/jquery.js" type="text/javascript"></script>
    <script src="Js/cinema_list.js" type="text/javascript"></script>
    <script src="Js/back.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="Css/promt.css" />
    <script type="text/javascript">
        $(function () { checkinput(".searchinput", "找电影?"); });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="name">
        <%--<span class="img">
        <asp:HyperLink ID="HyperLinkGetBack" runat="server" Height="10px" 
            ImageUrl="~/image/back.png" Width="10px" >返回</asp:HyperLink>
        </span>--%>
        <%--<span class="img"><a href="javascript:history.back()">
            <img src="../image/back.png" height="50" width="50" /></a></span>--%>
            <span class="img"><a href="../CinemaDetails.aspx">
            <img src="../image/back.png" height="50" width="50" class="imgback" /></a></span>
       <%-- <span class="area">

        <asp:DropDownList ID="DropDownListArea" runat="server"  CssClass="area_de"
            onselectedindexchanged="DropDownListArea_SelectedIndexChanged" 
            AutoPostBack="True">
        </asp:DropDownList>
        </span>
        <span class="cinema">

        <asp:DropDownList ID="DropDownListCinema" runat="server"  CssClass="cinema_de"
            onselectedindexchanged="DropDownListCinema_SelectedIndexChanged" 
            AutoPostBack="True">
        </asp:DropDownList>
        </span>--%>
        <span class="searchtext">
        <asp:TextBox ID="TextBoxSearchText" runat="server"  CssClass="searchinput"
            >找电影?</asp:TextBox>
        </span>

        <asp:Button ID="ButtonSearch" runat="server" CssClass="button" Text="Search" 
            onclick="ButtonSearch_Click" />
    </div>

    <div class="table">
        <div class="textCenter">
            <br />
            <br />
            <br />
        <asp:Label ID="LabelCinemaName" runat="server" Text="Label"></asp:Label>正在播放电影列表
        </div>

    <asp:GridView ID="GridViewMovies" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
            GridLines="Vertical" BackColor="#990099"   
            HorizontalAlign="Center">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="电影名" SortExpression="Name">
                <ItemTemplate>
                    <asp:Button ID="ButtonMovieName" CssClass="gridButton" runat="server" Text='<%# Bind("Name") %>' 
                     OnClick="MovieDetail_Click" Font-Underline="True"></asp:Button>
                </ItemTemplate>
                <%--<EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                </EditItemTemplate>--%>
            </asp:TemplateField>
            <asp:BoundField DataField="ShowTime" HeaderText="播放时间" NullDisplayText="暂无数据" 
                SortExpression="ShowTime" />
            <asp:BoundField DataField="Price" HeaderText="价格" 
                SortExpression="Price" NullDisplayText="暂无数据" />
            <asp:BoundField DataField="BuyWebsite" HeaderText="购买" 
                SortExpression="BuyWebsite" Visible="False" />
            <asp:HyperLinkField DataNavigateUrlFields="BuyWebsite" HeaderText="购买" 
                SortExpression="BuyWebsite" Text="点击购买" />
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
       <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="Gray" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>

        <asp:ObjectDataSource ID="ObjectDataSourceSearchMovieShow" runat="server" 
            SelectMethod="GetMovieShow" TypeName="BusinessLogicLayer.MoviesBLL">
            <SelectParameters>
                <asp:SessionParameter Name="newMovieName" SessionField="MovieShowName" 
                    Type="String" />
                <asp:SessionParameter Name="newCinemaId" SessionField="CinemaShowId" 
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceMovieShow" runat="server" 
            SelectMethod="GetMovieShow" TypeName="BusinessLogicLayer.MoviesBLL">
            <SelectParameters>
                <asp:SessionParameter Name="newCinemaName" SessionField="CinemaNameToMovieList" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
      </div>


    </form>
</body>
</html>
