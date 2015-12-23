using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//using System.Windows.Forms;
using DataAccessLayer;
using BusinessLogicLayer;

namespace Movies
{
    public partial class MovieList : System.Web.UI.Page
    {

        //得到传入的电影院名
        string _cinemaName = string.Empty;

        //得到传入电影院的Id
        int _cinemaId;

        //得到传入的电影院的地址
        //string _cineamAddr = string.Empty;

        //创建电影业务对象
        MoviesBLL _moviesBll = new MoviesBLL();

        //创建电影院业务对象
        CinemaBLL _cinemaBll = new CinemaBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Test
            //Session["CinemaNameToMovieList"] = "武汉环银电影城";
            _cinemaName = Convert.ToString(Session["CinemaNameToMovieList"]);
            //_cineamAddr = Convert.ToString(Session["CinemaAddrToMovieList"]);
            //MessageBox.Show(_cinemaName);
            LabelCinemaName.Text = _cinemaName;
            //得到电影院Id
            CINEMA cinema = _cinemaBll.GetCinema(_cinemaName);
            _cinemaId = cinema.id;
            

            //显示数据
            //LoadMovies(_cinemaName);
            if (!IsPostBack)
            {
                //LoadMovies("武汉环银电影城");
                GridViewMovies.DataSourceID = "ObjectDataSourceMovieShow";
            }
        }

        //protected void DropDownListArea_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //protected void DropDownListCinema_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            
            if (TextBoxSearchText.Text != "")
            {
                List<MovieShow> movieShows = new List<MovieShow>();
                movieShows = _moviesBll.GetMovieShow(TextBoxSearchText.Text,_cinemaId);
                if (movieShows.Count() > 0 && movieShows.First().Name != null)
                {
                    Session["MovieShowName"] = TextBoxSearchText.Text;
                    Session["CinemaShowId"] = _cinemaId;
                    GridViewMovies.DataSourceID = "ObjectDataSourceSearchMovieShow";
                }
                else
                {
                    //MessageBox.Show("没有该影院的相关信息，请确认影院名是否输入正确！");  不可用

                    //另写提示信息 不能用 MessageBox
                    //Response.Write("<script language=javascript>alert('没有该电影的相关信息，请确认电影名是否输入正确！');</" + "script>");
                   // Page.RegisterStartupScript("1", "<script language=javascript >window.alert('没有该电影的相关信息，请确认电影名是否输入正确！');</" + "script>");
                    Response.Write("<div class='msgboxbg'>" + "<div class='mainmsgbox'>" + "<br/><br/><br/><br/><div class='msgcon'>没有该电影的相关信息，请确认电影名是否输入正确！</div>" + " <a href='MovieList.aspx'> <div class='tip'>返回</div></a>" + " </div></div></div>");

                }
            }
            else
                GridViewMovies.DataSourceID = "ObjectDataSourceMovieShow";
        }

        protected void MovieDetail_Click(object sender, EventArgs e)
        {
            string movieName = string.Empty;

            Button button = (Button)sender;
            movieName = button.Text;

            Session["MovieNameToMovieDetails"] = movieName;
            Response.Redirect("~/MovieDetails.aspx");
        }
       
        

        //过后删除！！！！！！！！！
        public void LoadMovies(string newCinemaName)
        {
            //使前页面传入的电影院所播放的所有电影显示到页面
            List<MOVIE_SCHEDULE> movieSchedules = new List<MOVIE_SCHEDULE>();
            //movies = _cinemaBll.GetAllMoviesByCinemaName(newCinemaName);

            movieSchedules = _cinemaBll.GetMovies(newCinemaName);
            //int cinemaId = _cinemaBll.GetCinemaId(newCinemaName, newCinemaAddr);

            //MessageBox.Show(newCinemaName);
            //动态生成数据表
            DataTable dt = new DataTable();
            //添加列
            DataColumn name = new DataColumn("name", typeof(string));

            DataColumn price = new DataColumn("price", typeof(string));
            DataColumn buyWebsite = new DataColumn("buyWebsite", typeof(string));

            dt.Columns.Add(name);
            dt.Columns.Add(price);
            dt.Columns.Add(buyWebsite);

            foreach (MOVIE_SCHEDULE ms in movieSchedules)
            {
                DataRow row = dt.NewRow();
                string movieName = _moviesBll.GetMovieNameById((int)ms.movie_id);
                row[name] = movieName;
                row[price] = ms.price;
                row[buyWebsite] = ms.book_website;

                dt.Rows.Add(row);
            }

            //清除已有数据
            GridViewMovies.DataSource = null;
            GridViewMovies.DataBind();
            //绑定新数据
            GridViewMovies.DataSource = dt;
            GridViewMovies.DataBind();
        }
       
    }
}