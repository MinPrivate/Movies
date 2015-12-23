using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using BusinessLogicLayer;

namespace Movies
{
    public partial class MovieOnShowList : System.Web.UI.Page
    {
        //记录从前页面传入的电影名参数
        string _movieName = string.Empty;

        //记录搜索框内容
        string _SearchText = string.Empty;

        //创建电影业务对象
        MoviesBLL _movieBll = new MoviesBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["MovieOnShow"] = "马达加斯加3";
            _movieName = Convert.ToString(Session["MovieOnShow"]);    //此Session 从前页面传入
            GridViewMovies.DataSourceID = "ObjectDataSourceMovieOnShow";

            LabelMovieName.Text = _movieName;
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            _SearchText = TextBoxSearchText.Text;


            if (_SearchText != "")
            {
                List<MovieOnShow> movieOnShows = new List<MovieOnShow>();
                movieOnShows = _movieBll.GetMovieOnShow(_movieName, _SearchText);
                if (movieOnShows.Count() > 0 && movieOnShows.First().Name != null)
                {
                    Session["MovieOnShowSearch"] = _SearchText;
                    GridViewMovies.DataSourceID = "ObjectDataSourceMovieOnShowSearch";
                }
                else
                {
                    //MessageBox.Show("没有该影院的相关信息，请确认影院名是否输入正确！");  不可用

                    //另写提示信息 不能用 MessageBox
                    //Response.Write("<script language=javascript>alert('没有该电影的相关信息，请确认电影名是否输入正确！');</" + "script>");
                   // Page.RegisterStartupScript("1", "<script language=javascript >window.alert('没有该影院的相关信息，请确认影院名名是否输入正确！');</" + "script>");
                    Response.Write("<div class='msgboxbg'>" + "<div class='mainmsgbox'>" + "<br/><br/><br/><br/><div class='msgcon'>您没有该影院的相关信息，请确认影院名名是否输入正确！</div>" + " <a href='MovieOnShowList.aspx'> <div class='tip'>返回</div></a>" + " </div></div></div>");
                }
            }
            else
                GridViewMovies.DataSourceID = "ObjectDataSourceMovieOnShow";
        }

        protected void CinemaDetail_Click(object sender, EventArgs e)
        {
            string cinemaName = string.Empty;

            Button button = (Button)sender;
            cinemaName = button.Text;

            Session["CinemaNameToCinemaDetails"] = cinemaName;
            Response.Redirect("~/CinemaDetails.aspx");
        }
    }
}