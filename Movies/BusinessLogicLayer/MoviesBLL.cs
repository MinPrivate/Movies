using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;


namespace BusinessLogicLayer
{
    public class MoviesBLL
    {
        public MOVIE GetMovie(string newName)
        {
            //返回一个电影对象
            Search s = new Search();

            return s.SearchMovie(newName);//实现时修改
        }
        public List<MOVIE_SCHEDULE> GetMovieScheduleByMovieName(string newMovieName)
        {
            //根据电影的名字获取电影时刻列表
            Search s = new Search();
            
            return s.SearchCinemasSchedule(newMovieName);//实现时修改
        }
        public string GetPicture(string newMovieName)
        {
            //根据电影的名称获得电影的海报路径
            string path = "";
            Search s = new Search();
            path = s.SearchMoviePicture(newMovieName);
            return path;//实现时修改
        }

        //public List<MOVIE_COMMENT> GetHotComments(string newMovieName)
        //{
        //    //返回电影的热度评价列表。
        //    Search s = new Search();
        //    return s.SearchHotMovieComment(newMovieName);//实现时修改
        //}

        public List<Comment> GetHotComments(string newMovieName)
        {
            //返回电影的热度评价列表。
            Search s = new Search();
            List<MOVIE_COMMENT> comment = s.SearchHotMovieComment(newMovieName);
            List<Comment> result = new List<Comment>();

            foreach (var c in comment)
            {
                result.Add(new Comment(c));
            }

            return result;
        }
        //public List<MOVIE_COMMENT> GetLatestComments(string newMovieName)
        //{
        //    //根据新传入来的电影名字返回最新的评价列表。

        //    Search s = new Search();
        //    return s.SearchLatestMovieComment(newMovieName);//实现时修改
        //}

        public List<Comment> GetLatestComments(string newMovieName)
        {
            //根据新传入来的电影名字返回最新的评价列表。

            Search s = new Search();
            List<MOVIE_COMMENT> comment = s.SearchLatestMovieComment(newMovieName);
            List<Comment> result = new List<Comment>();

            foreach (var c in comment)
            {
                result.Add(new Comment(c));
            }

            return result;

        }


        /// <summary>		
        /// 说明：<调用函数调用GetRank函数可以完成热度排行的电影列表>
        /// </summary>
        /// <param ><无></param>
        /// <returns><操作成功返回热度排行电影列表> </returns>
        ///<exception>无</exception> 
        public List<MOVIE> GetHotRank()
        {
            //返回热度排行列表。
            Search s = new Search();
            return s.SearchHotMovies();//实现时修改
        }
        public List<MOVIE> GradeRank()
        {
            //返回评分电影排行
            Search s = new Search();
            return s.SearchRankMovies();//实现时修改
        }

        //isOnShow字段已删除 此函数无用
        public List<MOVIE> GetMoviesBySearchText(bool isOnShow, string newSearchText)
        {
            //根据是否上映和电影名或导演名搜索
            Search search = new Search();
            List<MOVIE> result = new List<MOVIE>();
            result = search.SearchMain(isOnShow, newSearchText);
            return result;
        }

        public string GetMoviePicture(string newMovieName)
        {
            //根据电影名得到电影图片的地址
            Search search = new Search();
            string moviePicture = search.SearchMoviePicture(newMovieName);
            return moviePicture;
        }

        public List<MOVIE_SCHEDULE> GetMovieSchedule(string newMovieName)
        {
            //根据电影名 得到电影时刻表
            Search search = new Search();
            List<MOVIE_SCHEDULE> movieSchedule = new List<MOVIE_SCHEDULE>();
            movieSchedule = search.SearchCinemasSchedule(newMovieName);
            return movieSchedule;
        }

        public string GetCinemaNameById(int newCinemaId)
        {
            //根据电影院id 得到电影院名
            string cinemaName = string.Empty;
            Search search = new Search();
            cinemaName = search.SearchCinemaNameById(newCinemaId);
            return cinemaName;
        }

        public int GetMovieId(string newMovieName)
        {
            //获取电影院ID
            return new Movie().GetMovieId(newMovieName);
        }

        public bool IncreaseCommentSupport(string newMovieName, DateTime newTime)
        {
            //增加电影评论的支持数
            return new Comment().IncreaseMovieCommentSupport(newMovieName, newTime);
        }

        public bool IncreaseCommentOppose(string newMovieName, DateTime newTime)
        {
            //增加电影评论的反对数
            return new Comment().IncreaseMovieCommentOppose(newMovieName, newTime);
        }

        public string GetMovieNameById(int newMovieId)
        {
            //根据电影id得到电影名
            string movieName = string.Empty;
            Search search = new Search();
            movieName = search.SearchMovieNameById(newMovieId);

            return movieName;
        }

        public List<MovieShow> GetMovieShow(string newCinemaName)
        {
            //根据影院名得到该影院 播放的电影  为电影院 显示该影院所有电影列表提供数据源
            List<MovieShow> movieShows = new List<MovieShow>();
            List<MOVIE_SCHEDULE> movieSchedules = new List<MOVIE_SCHEDULE>();

            CinemaBLL cienmaBll = new CinemaBLL();

            movieSchedules = cienmaBll.GetMovies(newCinemaName);

            foreach (MOVIE_SCHEDULE ms in movieSchedules)
            {
                MovieShow movieShow = new MovieShow();
                string movieName = GetMovieNameById((int)ms.movie_id);

                movieShow.Name = movieName;
                movieShow.ShowTime = ms.showtime.ToString();
                movieShow.Price = Convert.ToInt32(ms.price);
                movieShow.BuyWebsite = ms.book_website;

                movieShows.Add(movieShow);
            }
            return movieShows;
        }

        public List<MovieShow> GetMovieShow(string newMovieName ,int newCinemaId)
        {
            //根据电影名得到该影院 的 所有该电影的信息  为电影院 显示该影院所有电影列表提供数据源
            List<MovieShow> movieShows = new List<MovieShow>();
            
            List<MOVIE_SCHEDULE> movieSchedules = new List<MOVIE_SCHEDULE>();

            CinemaBLL cienmaBll = new CinemaBLL();

            movieSchedules = GetMovieSchedule(newMovieName);

            foreach (MOVIE_SCHEDULE ms in movieSchedules)
            {
                if (ms.price < 0 || ms.cinema_id != newCinemaId) //排除错误数据
                    continue;

                MovieShow movieShow = new MovieShow();
                string movieName = GetMovieNameById((int)ms.movie_id);

                movieShow.Name = movieName;
                movieShow.ShowTime = ms.showtime.ToString();
                movieShow.Price = Convert.ToInt32(ms.price);
                movieShow.BuyWebsite = ms.book_website;
                
                movieShows.Add(movieShow);
            }

            /*/for (int i = 0; i < movieShows.Count(); i++)
            //{
            //    MovieShow m = movieShows.ElementAt(i);
            //    for (int j = i + 1; j < movieShows.Count(); j++)
            //    {
            //        MovieShow m1 = movieShows.ElementAt(j);
            //        if (m.Price == m1.Price)
            //        {
            //            movieShows.RemoveAt(j);
            //        }
            //    }
            //}*/

            return movieShows;
        }

        public List<MovieOnShow> GetMovieOnShow(string newMovieName)
        {
            //根据电影名得到播放该电影的所有影院  为电影播放列表 显示播放该电影的所有影院信息提供数据源
            List<MovieOnShow> movieOnShows = new List<MovieOnShow>();
            List<MOVIE_SCHEDULE> movieSchedules = new List<MOVIE_SCHEDULE>();

            CinemaBLL cienmaBll = new CinemaBLL();

            movieSchedules = GetMovieScheduleByMovieName(newMovieName);

            foreach (MOVIE_SCHEDULE ms in movieSchedules)
            {
                if (ms.price < 0)
                {
                    continue;
                }
                MovieOnShow movieOnShow = new MovieOnShow();
                string cinemaName = GetCinemaNameById(ms.cinema_id.Value);

                movieOnShow.Name = cinemaName;
                movieOnShow.ShowTime = ms.showtime.ToString();
                movieOnShow.Price = Convert.ToInt32(ms.price);
                movieOnShow.BuyWebsite = ms.book_website;

                movieOnShows.Add(movieOnShow);
            }
            return movieOnShows;
        }

        public List<MovieOnShow> GetMovieOnShow(string newMovieName, string newCinemaName)
        {
            //根据电影名得到播放该电影的所有影院  为电影播放列表 显示播放该电影的所有影院信息提供数据源
            List<MovieOnShow> movieOnShows = new List<MovieOnShow>();

            List<MOVIE_SCHEDULE> movieSchedules = new List<MOVIE_SCHEDULE>();

            CinemaBLL cienmaBll = new CinemaBLL();

            movieSchedules = GetMovieSchedule(newMovieName);

            CINEMA cinema = cienmaBll.GetCinema(newCinemaName);

            foreach (MOVIE_SCHEDULE ms in movieSchedules)
            {
                if (ms.price < 0) //排除错误数据
                    continue;
                if (ms.cinema_id == cinema.id)
                {
                    MovieOnShow movieOnShow = new MovieOnShow();
                    string cinemaeName = GetCinemaNameById(ms.cinema_id.Value);

                    movieOnShow.Name = cinemaeName;
                    movieOnShow.ShowTime = ms.showtime.ToString();
                    movieOnShow.Price = Convert.ToInt32(ms.price);
                    movieOnShow.BuyWebsite = ms.book_website;

                    movieOnShows.Add(movieOnShow);
                }
            }

            return movieOnShows;
        }

        public int GetGradeByName(string newMovieName)
        {
            //根据电影名字得到该电影的评分
            return new Movie().GetGradeByName(newMovieName);
        }

        public bool RankMovie(string newMovieName, int newRank)
        {
            //对电影进行打分
            return new Movie().RankMovieByName(newMovieName, newRank);
        }

        public List<MOVIE> GetMoviesByAddr(string newAddr)
        {
            return new Search().GetMoviesByAddr(newAddr);
        }//添加函数查询地址对应的电影 

        public List<MOVIE> GetMoviesByPlayType(string message)
        {
            return new Search().GetMoviesByPlayType(message);
        }

        public List<MOVIE_SCHEDULE> GetAllMovieSchedule(int newMovieId)
        {
            List<MOVIE_SCHEDULE> movieSchdule = new List<MOVIE_SCHEDULE>();
            Search s = new Search();
            movieSchdule = s.GetAllMovieSchedule(newMovieId);

            return movieSchdule;
        }
    }
}
