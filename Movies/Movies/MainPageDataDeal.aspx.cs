using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DataAccessLayer;
using BusinessLogicLayer;

namespace Movies
{
    public partial class MainPageDataDeal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // selectHotPlayMovies();
            string message = Request.Form["selectType"];
            //MessageBox.Show(message);

            if (message == "playType")
            {
                message = Request.Form["message"];
                if (message == "热映中")
                    message = "onshow";
                else if(message=="即将上映")
                    message = "willshow";
                else message="";
                SearchOnshowMovie(message);
            }
            else if (message == "region") 
            {
                message = Request.Form["value"];
                SearchByRegion(message);

            }
            else if (message == "load")
            {
                if (Request.Cookies["UserEmail"] != null)
                {
                    //默认登录用户的初始化
                    selectRecommend();
                }
                else
                {
                    //未登录时的初始化
                    selectHotPlayMovies();
                }

            }
            else if (message == "hot")
            {
                selectHotPlayMovies();
            }
            else if (message == "rank")
            {
                selectRankHighMovies();
            }
            else if (message == "recommend")
            {
                selectRecommend();
            }
            else if (message == "playAddr") 
            {
                string region = Request.Form["addr"];
                SearchByRegion(region);
            }
            else if (message == "searchmovie") 
            {
                message = Request.Form["movieName"];
                //获取电影院
                MOVIE movie = new MOVIE();
                movie = new MoviesBLL().GetMovie(message);


                //List<List<MOVIE_SCHEDULE>> schedulelist = new List<List<MOVIE_SCHEDULE>>();
                List<MOVIE_SCHEDULE> allMovieSchedule = new List<MOVIE_SCHEDULE>();
                allMovieSchedule = new MoviesBLL().GetAllMovieSchedule(movie.id);
                //添加处理函数

                dealTheSearch(movie,allMovieSchedule);



            }
            else
            {
               // MessageBox.Show(message);
            }


        }



        public void dealTheSearch(MOVIE movie,List<MOVIE_SCHEDULE> newMovieSchedule)
        {
            List<Cinema> cinemas = new List<Cinema>();
            Cinema cinema = new Cinema();

            CinemaBLL cinemaBll = new CinemaBLL();
            int first = 0;
            int add = 0;

            //找出电影院
            foreach (MOVIE_SCHEDULE ms in newMovieSchedule)
            {
                CINEMA cia = cinemaBll.GetCinemaById(ms.cinema_id.Value);
                cinema.CinemaName = cia.name;
                cinema.CinemaId = ms.cinema_id.Value;
                //cinema._cinemaMovieSchedule.Add(ms);

                if (first == 0)
                {
                    first = -1;
                    cinemas.Add(cinema);
                }
                else
                {
                    foreach (Cinema ca in cinemas)
                    {
                        if (ca.CinemaId == ms.cinema_id)
                        {
                            add = 1;
                            break;
                        }
                    }

                    if (add != 1)
                    {
                        cinemas.Add(cinema);
                    }
                }
                add = 0;
            }

            //找出电影院中播放的电影时刻表
            foreach (Cinema cima in cinemas)
            {
                foreach (MOVIE_SCHEDULE mese in newMovieSchedule)
                {
                    if (cima.CinemaId == mese.cinema_id)
                    {
                        cima._cinemaMovieSchedule.Add(mese);
                    }
                }
            }
           //////////////////
            finshSearch(movie, cinemas);

        }

        public void finshSearch(MOVIE  movie,List<Cinema> cinemas) 
        {
            string innerHtml = "";







            Response.Write(innerHtml);
        }






        /// <summary>
        /// ///////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="newMovieName"></param>
        /// 
        //添加函数
        public void SearchOnshowMovie(string message)
        {

            dealSelect(new MoviesBLL().GetMoviesByPlayType(message));

        }

        public List<MOVIE> SearchByRegion(string newAddr) //根据地址查询电影 返回电影列表
        {
            List<MOVIE> movies = new List<MOVIE>();
            movies = new MoviesBLL().GetMoviesByAddr(newAddr);
            dealSelect(movies);
            return movies;
        }

        public void Search(bool isOnshow, string searchTest)
        {
            List<MOVIE> movies = new List<MOVIE>();
            List<List<MOVIE_SCHEDULE>> movieScheduleList = new List<List<MOVIE_SCHEDULE>>();

            //movies = new MoviesBLL().GetMoviesBySearchText(isOnshow, searchTest);//得到搜索的电影列表
            movies = new MoviesBLL().GetMoviesBySearchText(isOnshow, searchTest);

            foreach (MOVIE movie in movies)
            {
                //这里可以添加判断电影是否在指定的限制区域里面

                List<MOVIE_SCHEDULE> movieSchedule = new List<MOVIE_SCHEDULE>();//获取对应的电影列表
                movieSchedule = (new MoviesBLL()).GetMovieSchedule(movie.name);
                //获取对应的电影时刻表  按照票价升序排列
                movieScheduleList.Add(movieSchedule);
            }

            //展示电影信息和电影的时刻表 和票价
            //一页只展示一个电影信息


        }





        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="movies"></param>



        public void selectRecommend()
        {
            UersBLL usersBll = new UersBLL();
            //判断用户是否登录  ？？？
            if (Request.Cookies["UserEmail"] == null)
            {
                //MessageBox.Show("您还没有登录，请先登录");
                Response.Write("<div class='msgboxbg'>" + "<div class='mainmsgbox'>" + "<br/><br/><br/><br/><div class='msgcon'>您还没有登录，请先登录!</div>" + " <a href='LogIn.aspx'> <div class='tip'>返回</div></a>" + " </div></div></div>");
                //Response.Redirect("~/LogIn.aspx");
                return;
            }

            //获取登录状态 email标志
            //string getEmail = string.Empty;
            List<MOVIE> userLikeMovies = new List<MOVIE>();

            int _userId = Convert.ToInt32(Request.Cookies["UserId"].Value);
            userLikeMovies = usersBll.GetPreferenceMoviesByUserId(_userId);
            dealSelect(userLikeMovies);

        }
        public void selectRankHighMovies()
        {
            List<MOVIE> movies = new List<MOVIE>();
            movies = new MoviesBLL().GradeRank();
            dealSelect(movies);
        }
        public void selectHotPlayMovies()
        {
            List<MOVIE> movies = new List<MOVIE>();
            movies = new MoviesBLL().GetHotRank();
            dealSelect(movies);
        }

        public void dealSelect(List<MOVIE> movies)
        {
            //处理选择信息  传入一个电影列表
            int pageTotal = movies.Count();
            //MessageBox.Show(pageTotal.ToString());
            int pageNum = 0;
            int pageAdd = 0;
            int currentMovie = 0;


            if (movies.Count() > 9)
            {
                pageNum = (movies.Count() - 9) / 12;
                pageAdd = (movies.Count() - 9) % 12;
                if (pageAdd > 0)
                {
                    pageNum += 2;
                }
                else
                {
                    pageNum++;
                }
            }
            else
            {
                pageNum = 1;
            }

            // MessageBox.Show(pageNum.ToString());

            string innerHtml = "<div id='test'><div class='slides_container'>";
            //  DateTime time=DateTime.Now.Date;


            for (int i = 0; i < pageNum; i++)
            {
                if (i == 0)
                {
                    innerHtml += "<div class='boxb_2'> ";
                    MOVIE movie = movies.First();
                    innerHtml += formBigHtml(movie.name, movie.rank.Value, movie.director, movie.actor, movie.kind
                        , movie.region, movie.first_showtime.Value, movie.last_time.Value, movie.path);//第一张大图
                    pageTotal--;
                    currentMovie++;
                    if (pageTotal == 0) break;
                    // MessageBox.Show(innerHtml + "1");

                    for (int j = 0; j < 8; j++)
                    {
                        movie = movies.ElementAt(currentMovie);
                        innerHtml += formSmalHtml(movie.name, movie.rank.Value, movie.kind
                         , movie.region, movie.first_showtime.Value, movie.path);
                        pageTotal--;
                        currentMovie++;

                        //MessageBox.Show(innerHtml + "   "+pageTotal.ToString());
                        if (pageTotal == 0) break;
                    }
                    innerHtml += "</div>";

                    //MessageBox.Show(innerHtml);
                }

                else
                {
                    currentMovie = 9 + 12 * (i - 1);

                    innerHtml += "<div class='boxb_2'>";
                    for (int j = 0; j < 12; j++)
                    {
                        MOVIE movie = movies.ElementAt(currentMovie);
                        innerHtml += formSmalHtml(movie.name, movie.rank.Value, movie.kind
                        , movie.region, movie.first_showtime.Value, movie.path);
                        pageTotal--;
                        currentMovie++;
                        if (pageTotal == 0) break;
                    }
                    // <div class='mainPhoto'> 
                    //</div>

                    innerHtml += "</div>";
                }
                if (pageTotal == 0)
                { break; }
                else
                {
                    continue;
                }

            }


            innerHtml += "</div>" + formPagePoint(pageNum);
            Response.Write(innerHtml + "</div></div>");

        }


        public string formSmalHtml(string newMovieName, byte newRank, string newKind,
            string newRegion, DateTime newShowTime, string newPicturePath)
        {
            string smallMovieDetailHtml = " <div class='commonMovieDetail' data-movie-name=\"" + newMovieName + "\">"
                           + "<div  class='commonPhoto'>"
                           + "<img src='" + newPicturePath + "' class='photoChangeToSmaller'/> </div>"
                           + " <div  class='commonInfo'>"
                           + "<table id='smallTable'>"
                           + "<tr><td>" + newMovieName + "</td></tr>"
                           + "<tr><td>" + newRank + "</td></tr>"
                           + "<tr><td>" + newKind + "</td></tr>"
                           + "<tr><td>" + newRegion + "</td></tr>"
                           + "<tr><td>" + newShowTime + "</td></tr></table></div> </div>";

            return smallMovieDetailHtml;
        }

        public string formBigHtml(string newMovieName, byte newRank, string newDirector, string newActor,
            string newKind, string newRegion, DateTime newShowTime, int newLastTime, string newPicturePath)
        {
            string specialMovieDetailHtml = " <div class='specialMovieDetail' data-movie-name=\""+newMovieName+"\">"
                           + "<div  class='specialPhoto'>"
                           + "<img src='" + newPicturePath + "' class='photoChangeToLarger'/> </div>"
                           + " <div  class='specialInfo'>"
                           + "<table id='bigTable'>"
                           + "<tr><td>" + "影片名：" + newMovieName + "</td></tr>"
                           + "<tr><td>" + "评分：" + newRank + "分" + "</td></tr>"
                           + "<tr><td>" + "导演：" + newDirector + "</td></tr>"
                           + "<tr><td>" + "主演：" + newActor + "</td></tr>"
                           + "<tr><td>" + "类型：" + newKind + "</td></tr>"
                           + "<tr><td>" + "地区：" + newRegion + "</td></tr>"
                           + "<tr><td>" + "首映时间：" + newShowTime + "</td></tr>"
                           + "<tr><td>" + "片长：" + newLastTime + "分钟" + "</td></tr>"
                           + "</table></div> </div>";

            return specialMovieDetailHtml;
        }

        public string formPagePoint(int pageNum)
        {
            //动态生成页面导航点
           string  pagePointHtml = "";
            if (pageNum > 1)
            {

                 pagePointHtml = " <div class='footer'><ul class='pagination'>";
                pagePointHtml += "<li><a href='#'><img src='image/current.png' width='20' ></a></li>";
                for (int i = 0; i < pageNum - 1; i++)
                {
                    pagePointHtml += "<li><a href='#'><img src='image/normal.png' width='20' ></a></li>";
                }
                //<li><a href="#"><img src="image/current.png" width="20" ></a></li>
                pagePointHtml += " </ul></div>";
            }
            return pagePointHtml;
        }
    }
}