using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public  class Search
    {

        public List<MOVIE_SCHEDULE> SearchCinemasSchedule(string newMovieName) 
        {
            //返回电影院电影放映时刻表,按票价升序排序
            List < MOVIE_SCHEDULE > cinemas=new List<MOVIE_SCHEDULE>();
            WATCHMOVIEEntities w = new WATCHMOVIEEntities();
           
            var result = from c in w.MOVIE_SCHEDULE
                         where c.movie_id == (
                                                 from m in w.MOVIE
                                                 //where m.name.Equals ( newMovieName)   //7.22 cm
                                                 where m.name.Contains(newMovieName)
                                                 select m
                                               ).FirstOrDefault().id
                        orderby c.price ascending
                         select c;
                         
            foreach (var r in result)
            {
                cinemas.Add(r);
            }
            return cinemas;

        }

        //重写此函数 cm_7.22
        /*public string SearchMoviePicture(string newMovieName)
        {
            //根据电影名子搜索相关海报并且返回 海报所在位置 
            //只返回了搜索到的对应电影的第一张图片
            string picturePath = string.Empty;
            WATCHMOVIEEntities w = new WATCHMOVIEEntities();

            var result = from p in w.MOVIE_PICTURE
                         where p.movie_id == (
                                                          from m in w.MOVIE
                                                          where m.name.Equals(newMovieName)
                                                          select m
                                                          ).FirstOrDefault().id
                         select p;
            if (result.Count() > 0)
            {
                picturePath = result.First().path;
            }
            return picturePath;
        }
        */

        public string SearchMoviePicture(string newMovieName)
        {
            //根据电影名子搜索相关海报并且返回 海报所在位置 
            //只返回了搜索到的对应电影的第一张图片
            string picturePath = string.Empty;
            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();

            var result = from p in entity.MOVIE
                         where p.name.Equals(newMovieName)
                         select p;

            if (result.Count() > 0)
            {
                picturePath = result.FirstOrDefault().path;
            }

            return picturePath;
        }

        public List<MOVIE_COMMENT> SearchLatestMovieComment(string newMovieName) 
        {
            //根据电影名 搜索 电影的最新评论 并且返回评论列表
           
            List<MOVIE_COMMENT> comment = new List<MOVIE_COMMENT>();
            WATCHMOVIEEntities w = new WATCHMOVIEEntities();

            var result = from c in w.MOVIE_COMMENT
                         where c.movie_id == (
                                                        from m in w.MOVIE
                                                        where m.name.Equals( newMovieName)
                                                        select m
                                                        ).FirstOrDefault().id
                        orderby c.time descending
                         select c;
            foreach (var r in result)
            {
                comment.Add(r);
            }

            return comment;
        }

        public List<MOVIE_COMMENT> SearchHotMovieComment(string newMovieName)
        {
            //根据电影名 搜索 电影的最热评论 并且返回评论列表
           
            List<MOVIE_COMMENT> comment = new List<MOVIE_COMMENT>();
            WATCHMOVIEEntities w = new WATCHMOVIEEntities();

            var result = from c in w.MOVIE_COMMENT
                         where c.movie_id == (
                                                        from m in w.MOVIE
                                                        where m.name.Equals( newMovieName)
                                                        select m
                                                        ).FirstOrDefault().id
                         orderby c.support descending
                         select c;
            foreach (var r in result)
            {
                comment.Add(r);
            }

            return comment;
        }

        public List<MOVIE> SearchRankMovies() 
        {
            //根据评分排行检索电影 并且以列表的形式返回
            WATCHMOVIEEntities w = new WATCHMOVIEEntities();
            List<MOVIE> movie = new List<MOVIE>();

            var result = from m in w.MOVIE
                         orderby m.rank descending
                         select m;

            foreach (var r in result)
            {
                movie.Add(r);
            }

            return movie;
        }

        public List<MOVIE> SearchHotMovies()
        {
            //根据点击数排行显示电影，以列表形式返回
            WATCHMOVIEEntities w = new WATCHMOVIEEntities();
            List<MOVIE> movie = new List<MOVIE>();

            var result = from m in w.MOVIE
                         orderby m.click_number descending
                         select m;
            foreach (var r in result)
            {
                movie.Add(r);
            }

            return movie;
         
        }

        public List<MOVIE> SearchPreferMovies(int newUserID) 
        {

            //根据用户偏好 选择相关影片推荐按点击数排列 以列表的形式返回
            //select *
            //from schedule
            //where movie_id in (select id from movie where kind like @kind ) and cinema_id in (select id from cinema where addr like @addr)
            WATCHMOVIEEntities w = new WATCHMOVIEEntities();
            List<MOVIE> movie = new List<MOVIE>();
            string kind=null;   


            var result1 = from u in w.RUSER
                          where u.id == newUserID
                          select u;

            RUSER user = new RUSER();
            if (result1.Count() > 0)
            {
                user = result1.First();
                kind = user.like_kind;
            }
            if (kind != null)
            {
                string[] singleKinds = kind.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string singleKind in singleKinds)
                {
                    var result2 = from m in w.MOVIE
                                  //where kind.Equals(m.kind)
                                  where m.kind.Contains(singleKind)
                                  orderby m.click_number descending
                                  select m;

                    foreach (var r in result2)
                    {
                        movie.Add(r);
                    }
                }
            }

            return movie;
        }

        public List<MOVIE> SearchCollectedMovies(int newUserID) 
        {
            //返回用户收藏列表
            WATCHMOVIEEntities w = new WATCHMOVIEEntities();
            List<MOVIE> movie = new List<MOVIE>();

            //sql语句
            //select *
           // from movie
            //where id in(select movie_id from Collection where user_id=newUserId)
            
            //方法一
            //var result = from m in w.MOVIE
            //             from c in w.COLLECTION
            //             where m.id == c.movie_id && c.user_id == newUserID
            //             select m;

            //方法二连接两张表
            var result = from m in w.MOVIE
                         join c in w.COLLECTION on m.id equals c.movie_id
                         where c.user_id == newUserID
                         select m;

            foreach (var r in result)
            {
                movie.Add(r);
            }

            return movie;
        }

        public bool SearchEmail(string newEmail)
        {
            //返回是否已经存在e-mail
            WATCHMOVIEEntities w = new WATCHMOVIEEntities();

            //还可以可以思考如何用自己定义的函数funcCheckEmailByEmail
            var result = from u in w.RUSER
                         where u.email.Equals(newEmail)
                         select u;

            if (result.Count() > 0)
                return true;
            else 
                 return false;
        }

        public bool SearchUser(int newUserID, string newPassword) 
        {
            // 根据ID及密码检查用户是否存在是否合法；
            WATCHMOVIEEntities w = new WATCHMOVIEEntities();

            var result = from u in w.RUSER
                         where u.id == newUserID && u.password.Equals(newPassword)
                         select u;

            if (result.Count() > 0)
                return true;
            else
                return false;
        }

        public bool SearchUserInfo(string newEmail, string newPassword)
        {
            //根据邮箱及密码检查用户是否存在
            WATCHMOVIEEntities w = new WATCHMOVIEEntities();

            var result = from u in w.RUSER
                         where u.email .Equals(newEmail) && u.password.Equals(newPassword)
                         select u;

            if (result.Count() > 0)
                return true;
            else
                return false;
        } 

        public List<MOVIE_SCHEDULE> SearchMoviesSchedule(string newCinemaName) 
        {
            //根据电影院名返回电影时刻列表，按时间升序排列
            List<MOVIE_SCHEDULE> schedule = new List<MOVIE_SCHEDULE>();
            WATCHMOVIEEntities w = new WATCHMOVIEEntities();

            var result = from c in w.MOVIE_SCHEDULE
                         where c.cinema_id == (
                                                 from m in w.CINEMA
                                                 where m.name.Equals( newCinemaName)
                                                 select m
                                               ).FirstOrDefault().id
                         orderby c.showtime ascending
                         select c;

            foreach (var r in result)
            {
                schedule.Add(r);
            }
            return schedule;

            
        }

        public MOVIE SearchMovie(string newMovieName)
        {
            //根据电影名返回电影对象
            WATCHMOVIEEntities w = new WATCHMOVIEEntities();
            MOVIE movie = new MOVIE();

            var result = from m in w.MOVIE
                         where m.name.Equals(newMovieName)
                         select m;
            if (result.Count() > 0)
            {
                movie = result.First();
            }

            return movie;
        }

        public CINEMA SearchCinema(string newCinemaName) 
        {
            //根据电影院名 返回一个电影院对象
            WATCHMOVIEEntities w = new WATCHMOVIEEntities();
            CINEMA cinema = new CINEMA();

            var result = from c in w.CINEMA
                         where c.name.Equals(newCinemaName)
                         select c;
            if (result.Count() > 0)
            {
                cinema = result.First();
            }
            return cinema;
        }

        
        public CINEMA SearchCinema(int newCinemaId)
        {
            //根据电影院名 返回一个电影院对象
            WATCHMOVIEEntities w = new WATCHMOVIEEntities();
            CINEMA cinema = new CINEMA();

            var result = from c in w.CINEMA
                         where c.id == newCinemaId
                         select c;
            if (result.Count() > 0)
            {
                cinema = result.First();
            }
            return cinema;
        }

        public List<CINAME_COMMENT> SearchLatestCinemaComment(string newCinemaName) 
        {
            //根据电影院名字 返回电影院的最新评价列表
            List<CINAME_COMMENT> comment = new List<CINAME_COMMENT>();
            WATCHMOVIEEntities w = new WATCHMOVIEEntities();

            var result = from c in w.CINAME_COMMENT
                         where c.cinema_id == (
                                                        from m in w.CINEMA
                                                        where m.name.Equals( newCinemaName)
                                                        select m
                                                        ).FirstOrDefault().id
                         orderby c.time descending
                         select c;
            foreach (var r in result)
            {
                comment.Add(r);
            }

            return comment;
            
        }
        public List<CINAME_COMMENT> SearchHotCinemaComment(string newCinemaName)
        {
            //根据电影院名 检索最热评论 返回评论列表
            List<CINAME_COMMENT> comment = new List<CINAME_COMMENT>();
            WATCHMOVIEEntities w = new WATCHMOVIEEntities();

            var result = from c in w.CINAME_COMMENT
                         where c.cinema_id == (
                                                        from m in w.CINEMA
                                                        where m.name.Equals( newCinemaName)
                                                        select m
                                                        ).FirstOrDefault().id
                         orderby c.support descending
                         select c;
            foreach (var r in result)
            {
                comment.Add(r);
            }

            return comment;
        }
        public List<CINEMA> SearchAddrCinemas(string newAddr) 
        {
            /*addr=null 时 返回所有的电影院列表 
             * addr!=null 时 返回对应地区的电影院列表
             */
            WATCHMOVIEEntities w = new WATCHMOVIEEntities();
            List<CINEMA> cinemas = new List<CINEMA>();

            if (newAddr != null)
            {
                var result = from c in w.CINEMA
                             where c.address.Equals(newAddr)
                             select c;

                foreach (var r in result)
                {
                    cinemas.Add(r);
                }

            }
            else
            {
                var result = from c in w.CINEMA
                             select c;

                foreach (var r in result)
                {
                    cinemas.Add(r);
                }
            }
            return cinemas;

        }

        //isOnShow字段已删除 此函数无用
        public List<MOVIE> SearchMain(bool newIsOnShow, string newText)
        {
             DateTime dtNow = DateTime.Now;

            //主页搜索函数，根据是否上映，影片名或导演名或演员名搜索
            WATCHMOVIEEntities w = new WATCHMOVIEEntities();
            List<MOVIE> movie = new List<MOVIE>();

            var result = from m in w.MOVIE
                         //where m.is_on_show == newIsOnShow && (m.name.Equals(newText) || m.director.Equals(newText) || m.actor.Equals(newText))

                         //此处可能出错((m.first_showtime < dtNow) == newIsOnShow)
                         where ((m.first_showtime < dtNow) == newIsOnShow) && (m.name.Equals(newText) || m.director.Equals(newText) || m.actor.Equals(newText))
                         select m;

            foreach (var r in result)
            {
                movie.Add(r);
            }

            return movie;
        }

        public string SearchCinemaNameById(int newCinemaId)
        {
            //根据电影院id 得到电影院名
            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();
            var result = from c in entity.CINEMA
                         where c.id == newCinemaId
                         select c;
            return result.First().name;
        }

        public List<CINEMA> SearchAllCinemas()
        {
            //搜索得到所有的电影院信息
            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();
            List<CINEMA> cinemas = new List<CINEMA>();

            var result = from c in entity.CINEMA
                         //where c.id > 0
                         select c;
            foreach (CINEMA ci in result)
            {
                cinemas.Add(ci);
            }

            return cinemas ;
        }

        public string SearchMovieNameById(int newMovieId)
        {
            //根据电影id搜索得到电影名
            
            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();
            string movieName = string.Empty;

            var result = from m in entity.MOVIE
                         where m.id == newMovieId
                         select m;
            if (result.Count() > 0)
            {
                movieName = result.First().name;
            }

            return movieName;
        }

        public string SearchUserName(int userID)
        {
            //根据用户ID得到用户名
            string userName = "游客";

            if (userID != -1)
            {
                WATCHMOVIEEntities entity = new WATCHMOVIEEntities();


                var result = from u in entity.RUSER
                             where u.id == userID
                             select u;

                userName = result.First().name;
            }
            return userName;
        }

        //重写此函数  cm_7.22
       /*public string SearchCinemaPicture(string newCinemaName)
        {
            //根据电影院名子搜索相关海报并且返回 海报所在位置 
            //只返回了搜索到的对应电影院的第一张图片
            string picturePath = null;
            WATCHMOVIEEntities w = new WATCHMOVIEEntities();

            var result = from p in w.CINEMA_PICTURE
                         where p.cinema_id == (
                                                          from m in w.MOVIE
                                                          where m.name.Equals(newCinemaName)
                                                          select m
                                                          ).FirstOrDefault().id
                         select p;
            if (result.Count() > 0)
            {
                picturePath = result.FirstOrDefault().path;
            }
            return picturePath;
        }*/
        public string SearchCinemaPicture(string newCinemaName)
        {
            //根据电影院名子搜索相关海报并且返回 海报所在位置 
            //只返回了搜索到的对应电影院的第一张图片
            string picturePath = string.Empty;
            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();

            var result = from p in entity.CINEMA
                         where p.name.Equals(newCinemaName)
                         select p;

            if (result.Count() > 0)
            {
                picturePath = result.FirstOrDefault().path;
            }

            return picturePath;
        }


        public List<MOVIE> GetMoviesByAddr(string newAddr)
        {//查询有点小麻烦  根据地址查询 电影
            List<MOVIE> movies = new List<MOVIE>();
            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();
            int recod = 0; //控制第一次加入
            int add = 0;  //控制不重复加入

            var cinemas = from c in entity.CINEMA
                          where c.address.Contains(newAddr)
                          select c;
            //Test
            //MessageBox.Show(cinemas.Count().ToString());

            foreach (var cinema in cinemas)
            {
                var movieschedules = from m in entity.MOVIE_SCHEDULE
                                     where m.cinema_id == cinema.id
                                     select m;
                //Test
                //MessageBox.Show(movieschedules.Count().ToString());

                foreach (var movieschedule in movieschedules)
                {
                    var result = from movie in entity.MOVIE
                                 where movie.id == movieschedule.movie_id
                                 select movie;

                    //Test
                    //MessageBox.Show(result.Count().ToString());

                    foreach (MOVIE m in result)
                    {
                        if (recod == 0)
                        {
                            movies.Add(m);
                            recod = -1;
                        }
                        else
                        {
                            foreach (MOVIE rm in movies)
                            {
                                if (rm.id == m.id)
                                {
                                    add = 1;
                                    break;
                                }
                            }
                            if (add != 1)
                            {
                                movies.Add(m);
                            }
                        }
                        add = 0;
                    }

                }
            }


            return movies;
        }
        public List<MOVIE> GetMoviesByPlayType(string message)
        {
            DateTime dtNow = DateTime.Now;
            //bool is_on_show;


            //根据传经来的数据判断取出相应的类型的电影列表
            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();
            List<MOVIE> movies = new List<MOVIE>();

            if (message == "onshow")
            {
                var result = from m in entity.MOVIE
                             //where m.is_on_show == true
                             where m.first_showtime < dtNow
                             select m;
                foreach (var m in result)
                {
                    movies.Add(m);
                }
            }
            else if (message == "willshow")
            {
                var result = from m in entity.MOVIE
                             //where m.is_on_show == false
                             where m.first_showtime > dtNow
                             select m;
                foreach (var m in result)
                {
                    movies.Add(m);
                }
            }
            else
            {
                var result = from m in entity.MOVIE
                             //where m.is_on_show == false || m.is_on_show == true || m.is_on_show == null
                             where m.first_showtime > dtNow || m.first_showtime <dtNow || m.first_showtime ==dtNow
                             select m;
                foreach (var m in result)
                {
                    movies.Add(m);
                }
            }
            return movies;

        }








        public List<MOVIE_SCHEDULE> GetAllMovieSchedule(int newMovieId)
        {
            //根据电影名字选择对应的电影时刻表
            List<MOVIE_SCHEDULE> movieSchedule = new List<MOVIE_SCHEDULE>();
            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();
            var result = from m in entity.MOVIE_SCHEDULE
                         where m.movie_id == newMovieId
                         select m;
            if (result.Count() > 0) 
            {
                foreach (var m in result) 
                {
                    movieSchedule.Add(m);
                }
            }
            entity.Dispose();
            return movieSchedule;
        }
      
    }
}
