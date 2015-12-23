using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data.Entity;

namespace BusinessLogicLayer
{
    public class CinemaBLL
    {
        public List<MOVIE_SCHEDULE> GetMovies(string newCinemaName)
        {
            //根据电影院名字 返回该电影院的放映电影时刻列表；
            Search s = new Search();

            return s.SearchMoviesSchedule(newCinemaName);
        }

        public CINEMA GetCinema(string newCinemaName)
        {
            //根据电影院名字 返回一个电影院对象；
            Search s = new Search();
            return s.SearchCinema(newCinemaName);
        }

        
        public CINEMA GetCinemaById(int newCinemaId)
        {
            //根据电影院名字 返回一个电影院对象；
            Search s = new Search();
            return s.SearchCinema(newCinemaId);
        }


        //电影院的地图的位置怎么解决暂缓
        //public List<CINAME_COMMENT> GetLatestComment(string newCinemaName)
        //{
        //    //根据电影院的名字 检索最近的评论 并且展示

        //    Search s = new Search();
        //    return s.SearchLatestCinemaComment(newCinemaName);//使用时修改
        //}
        public List<Comment> GetLatestComment(string newCinemaName)
        {
            //根据新传入来的电影院名字返回最新的评价列表。

            Search s = new Search();
            List<CINAME_COMMENT> comment = s.SearchHotCinemaComment(newCinemaName);
            List<Comment> result = new List<Comment>();

            foreach (var c in comment)
            {
                result.Add(new Comment(c));
            }

            return result;

        }

        //public List<CINAME_COMMENT> GetHotComment(string newCinemaName)
        //{
        //    //调用检索函数  返回最热评论列表
        //    Search s = new Search();
        //    return s.SearchHotCinemaComment(newCinemaName);//使用时修改
        //}
        public List<Comment> GetHotComment(string newCinemaName)
        {
            //根据新传入来的电影院名字返回最新的评价列表。

            Search s = new Search();
            List<CINAME_COMMENT> comment = s.SearchHotCinemaComment(newCinemaName);
            List<Comment> result = new List<Comment>();

            foreach (var c in comment)
            {
                result.Add(new Comment(c));
            }

            return result;

        }
        public List<CINEMA> GetCinemas(string newAddr)
        {
            //调用检索函数  返回电影院列表
            Search s = new Search();
            return s.SearchAddrCinemas(newAddr);//使显示修改
        }

        //public int GetCinemaId(string newCinemaName, string newCinemaAddr)
        //{
        //    //返回电影ID
        //    return new Cinema().GetCinemaId(newCinemaName, newCinemaAddr);
        //}

        public int GetCinemaId(string newCinemaName)
        {
            //返回电影院ID
            return new Cinema().GetCinemaId(newCinemaName);
        }

        public List<CINEMA> GetAllCinemas()
        {
            //得到所有的电影院信息
            List<CINEMA> cinemas = new List<CINEMA>();
            Search search = new Search();
            cinemas = search.SearchAllCinemas();

            return cinemas;
        }

        //public bool IncreaseCommentSupport(string newCinemaName, string newAddr, DateTime newTime)
        //{
        //    //增加影院评论的支持数
        //    return new Comment().IncreaseCinemaCommentSupport(newCinemaName, newAddr, newTime);
        //}

        public bool IncreaseCommentSupport(string newCinemaName, DateTime newTime)
        {
            //增加影院评论的支持数
            return new Comment().IncreaseCinemaCommentSupport(newCinemaName, newTime);
        }

        //public bool IncreaseCommentOppose(string newCinemaName, string newAddr, DateTime newTime)
        //{
        //    //增加影院评论的反对数
        //    return new Comment().IncreaseCinemaCommentOppose(newCinemaName, newAddr, newTime);
        //}

        public bool IncreaseCommentOppose(string newCinemaName, DateTime newTime)
        {
            //增加影院评论的反对数
            return new Comment().IncreaseCinemaCommentOppose(newCinemaName, newTime);
        }

        public int GetMovieNumByCinemaName(string newCinemaName, string newCinemaAddr)
        {
            int num = 0;
            Cinema cinema = new Cinema();
            num = cinema.GetMovieNumByCinemaName(newCinemaName, newCinemaAddr);

            return num;
        }

        //public List<MOVIE> GetAllMoviesByCinemaName(string newCinemaName)
        //{
        //    //根据电影院名 得到这个电影院所播放的所有电影
        //    List<MOVIE> movies = new List<MOVIE>();
        //    Search search = new Search();
        //    movies = search.searchAllMoviesByCinemaName(newCinemaName);

        //    return movies;
        //}

        public List<CinemaShow> GetCinemaShow()
        {
            //得到电影院页面中的影院列表项
            List<CinemaShow> cinemaShows = new List<CinemaShow>();
            List<CINEMA> cinemas = new List<CINEMA>();
            cinemas = GetAllCinemas();

            foreach (CINEMA ci in cinemas)
            {
                CinemaShow cinemaShow = new CinemaShow();

                cinemaShow.Name = ci.name;
                cinemaShow.Address = ci.address;
             
                int num = GetMovieNumByCinemaName(ci.name, ci.address);
                cinemaShow.MovieNum = num;

                cinemaShows.Add(cinemaShow);
            }
            return cinemaShows;
        }

        public List<CinemaShow> GetCinemaShowByCinemaName(string newCinemaName)
        {
            //根据影院名得到相关影院列表项
            //得到电影院页面中的影院列表项
          
            List<CinemaShow> cinemaShows = new List<CinemaShow>();
            CINEMA cinema = new CINEMA();
            cinema = GetCinema(newCinemaName);

            CinemaShow cinemaShow = new CinemaShow();

            cinemaShow.Name = cinema.name;
            cinemaShow.Address = cinema.address;

            int num = GetMovieNumByCinemaName(cinema.name, cinema.address);
            cinemaShow.MovieNum = num;

            cinemaShows.Add(cinemaShow);

            return cinemaShows;
            
        }


        public string GetCinemaPicture(string newCinemaName)
        {
            //根据电影院名得到电影图片的地址
            Search search = new Search();
            string cinemaPicture = search.SearchCinemaPicture(newCinemaName);
            return cinemaPicture;
        }

        public bool RankCinema(string newCinemaName, int newRank)
        {
            //对电影院进行打分
            return new Cinema().RankCinemaByName(newCinemaName, newRank);
        }
    }
}
