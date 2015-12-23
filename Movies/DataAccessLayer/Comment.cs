using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
//using WATCHMOVIEModel;

namespace DataAccessLayer
{
    public class Comment
    {
        /*
        private int user_id;

        public int User_id
        {
            get
            {
                return user_id;
            }
            set
            {
                user_id = value;
            }
        }

        private string body;

        public string Body
        {
            get
            {
                return body;
            }
            set
            {
                body = value;
            }
        }

        private DateTime time;

        public DateTime Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }

        private int support;

        public int Support
        {
            get
            {
                return support;
            }
            set
            {
                support = value;
            }
        }

        private int oppose;

        public int Oppose
        {
            get
            {
                return oppose;
            }
            set
            {
                oppose = value;
            }
        }

        public Comment()
        {
            user_id = 0;
            body = null;
            time = DateTime.Now;
            support = 0;
            oppose = 0;
        }
        */
        private string userName;

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        private string body;

        public string Body
        {
            get
            {
                return body;
            }
            set
            {
                body = value;
            }
        }

        private DateTime time;

        public DateTime Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }

        private int support;

        public int Support
        {
            get
            {
                return support;
            }
            set
            {
                support = value;
            }
        }

        private int oppose;

        public int Oppose
        {
            get
            {
                return oppose;
            }
            set
            {
                oppose = value;
            }
        }

        public Comment()
        {
            userName = null;
            body = null;
            time = DateTime.Now;
            support = 0;
            oppose = 0;
        }
        /// <summary>
        ///数据库实体类对象
        /// </summary>
        WATCHMOVIEEntities _entity;

        /// <summary>
        /// 此函数用来增加一条电影评论
        /// </summary>
        /// <param name="newComment"></param>
        /// <returns></returns>
        /// <exception>数据库插入异常</exception>
        public bool InsertMovieComment(MOVIE_COMMENT newComment)
        {
            //创建数据库实体类对象
            _entity = new WATCHMOVIEEntities();

            bool isSucceed = false;

            //添加记录到内存
            _entity.AddToMOVIE_COMMENT(newComment);

            //保存修改到数据库
            try
            {
                int i = _entity.SaveChanges();
                isSucceed = true;
            }
            catch (Exception ex)
            {
                //异常处理？
                Console.WriteLine(ex);
                return false;
            }

            //撤销entity对象
            _entity.Dispose();

            return isSucceed;
        }

        /// <summary>
        /// 此函数用来增加一条电影院评论
        /// </summary>
        /// <param name="newComment"></param>
        /// <returns></returns>
        /// <exception>数据库插入异常</exception>
        public bool InsertCinemaComment(CINAME_COMMENT newComment)
        {
            //创建数据库实体类对象
            _entity = new WATCHMOVIEEntities();

            bool isSucceed = false;

            //添加记录到内存
            _entity.AddToCINAME_COMMENT(newComment);

            //保存修改到数据库
            try
            {
                int i = _entity.SaveChanges();
                isSucceed = true;
            }
            catch (Exception ex)
            {
                //异常处理？
                Console.WriteLine(ex);
                return false;
            }

            //撤销entity对象
            _entity.Dispose();

            return isSucceed;
        }

        /// <summary>		
        /// 此函数用来根据id删除电影院评论
        /// </summary>
        /// <param name="<newId>"></param>
        /// <returns><操作成功返回True，否则返回False> </returns>
        ///<exception>数据库删除操作异常</exception> 
        public bool DeleteCinemaCommentById(int newId)
        {
            //创建数据库实体对象
            _entity = new WATCHMOVIEEntities();

            bool isSucceed = false;

            //查找到需要删除的数据——（根据收藏id查找 结果只可能是一个）
            var result = from c in _entity.CINAME_COMMENT
                         where c.id == newId
                         select c;

            //从数据库中删除查找到的记录 并保存
            if (result.Count() >= 1)
            {
                _entity.CINAME_COMMENT.DeleteObject(result.First());
                try
                {
                    int i = _entity.SaveChanges();
                    isSucceed = true;
                }
                catch (Exception ex)
                {
                    //异常处理
                    Console.WriteLine(ex);
                    return false;
                }
            }

            //撤销entity对象
            _entity.Dispose();

            return isSucceed;
        }

        /// <summary>		
        /// 此函数用来根据id删除电影评论
        /// </summary>
        /// <param name="<newId>"></param>
        /// <returns><操作成功返回True，否则返回False> </returns>
        ///<exception>数据库删除操作异常</exception> 
        public bool DeleteMovieCommentById(int newId)
        {
            //创建数据库实体对象
            _entity = new WATCHMOVIEEntities();

            bool isSucceed = false;

            //查找到需要删除的数据——（根据收藏id查找 结果只可能是一个）
            var result = from c in _entity.MOVIE_COMMENT
                         where c.id == newId
                         select c;

            //从数据库中删除查找到的记录 并保存
            if (result.Count() >= 1)
            {
                _entity.MOVIE_COMMENT.DeleteObject(result.First());
                try
                {
                    int i = _entity.SaveChanges();
                    isSucceed = true;
                }
                catch (Exception ex)
                {
                    //异常处理
                    Console.WriteLine(ex);
                    return false;
                }
            }

            //撤销entity对象
            _entity.Dispose();

            return isSucceed;
        }

        /// <summary>
        /// 这个函数根据电影院名，电影院地址，发表时间对电影院评论反对数增加1
        /// </summary>
        /// <param name="newCinemaName"></param>
        /// <param name="newCinemaAddr"></param>
        /// <param name="newTime"></param>
        /// <returns></returns>
        //public bool IncreaseCinemaCommentOppose(string newCinemaName, string newCinemaAddr, DateTime newTime)
        //{
        //    bool isSucceed = false;
        //    _entity = new WATCHMOVIEEntities();
        //    int cinemaId = new Cinema().GetCinemaId(newCinemaName, newCinemaAddr);

        //    if (cinemaId != -1)//如果cinema_id为-1则代表没有这个电影院，所以出错了
        //    {
        //        var result = from c in _entity.CINAME_COMMENT
        //                     where c.cinema_id == cinemaId && c.time.Equals(newTime)
        //                     select c;

        //        if (result.Count() == 1)
        //        {
        //            result.First().oppose += 1;
        //            try
        //            {
        //                int i = _entity.SaveChanges();
        //                isSucceed = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                //异常处理
        //                Console.WriteLine(ex);
        //                return false;
        //            }
        //        }

        //        //撤销entity对象
        //        _entity.Dispose();
        //    }

        //    return isSucceed;
        //}


        /// <summary>
        /// 这个函数根据电影院名，电影院地址，发表时间对电影院评论反对数增加1
        /// </summary>
        /// <param name="newCinemaName"></param>
        /// <param name="newCinemaAddr"></param>
        /// <param name="newTime"></param>
        /// <returns></returns>
        //public bool IncreaseCinemaCommentOppose(string newCinemaName, string newCinemaAddr, DateTime newTime)
        //{
        //    bool isSucceed = false;
        //    _entity = new WATCHMOVIEEntities();
        //    int cinemaId = new Cinema().GetCinemaId(newCinemaName, newCinemaAddr);

        //    if (cinemaId != -1)//如果cinema_id为-1则代表没有这个电影院，所以出错了
        //    {
        //        var result = from c in _entity.CINAME_COMMENT
        //                     where c.cinema_id == cinemaId && c.time.Value.Equals(newTime)
        //                     select c;

        //        if (result.Count() == 1)
        //        {
        //            result.First().oppose += 1;
        //            try
        //            {
        //                int i = _entity.SaveChanges();
        //                isSucceed = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                //异常处理
        //                Console.WriteLine(ex);
        //                return false;
        //            }
        //        }

        //        //撤销entity对象
        //        _entity.Dispose();
        //    }

        //    return isSucceed;
        //}
        public bool IncreaseCinemaCommentOppose(string newCinemaName, DateTime newTime)
        {
            bool isSucceed = false;
            _entity = new WATCHMOVIEEntities();
            int cinemaId = new Cinema().GetCinemaId(newCinemaName);

            if (cinemaId != -1)//如果cinema_id为-1则代表没有这个电影院，所以出错了
            {
                var result = from c in _entity.CINAME_COMMENT
                             where c.cinema_id == cinemaId && c.time.Value.Equals(newTime)
                             select c;

                if (result.Count() == 1)
                {
                    result.First().oppose += 1;
                    try
                    {
                        int i = _entity.SaveChanges();
                        isSucceed = true;
                    }
                    catch (Exception ex)
                    {
                        //异常处理
                        Console.WriteLine(ex);
                        return false;
                    }
                }

                //撤销entity对象
                _entity.Dispose();
            }

            return isSucceed;
        }


        /// <summary>
        /// 这个函数根据电影院名，电影院地址，发表时间对电影院评论支持数增加1
        /// </summary>
        /// <param name="newCinemaName"></param>
        /// <param name="newCinemaAddr"></param>
        /// <param name="newTime"></param>
        /// <returns></returns>
        //public bool IncreaseCinemaCommentSupport(string newCinemaName, string newCinemaAddr, DateTime newTime)
        //{
        //    bool isSucceed = false;
        //    _entity = new WATCHMOVIEEntities();
        //    int cinemaId = new Cinema().GetCinemaId(newCinemaName, newCinemaAddr);

        //    if (cinemaId != -1)//如果cinema_id为-1则代表没有这个电影院，所以出错了
        //    {
        //        var result = from c in _entity.CINAME_COMMENT
        //                     where c.cinema_id == cinemaId && c.time.Equals(newTime)
        //                     select c;

        //        if (result.Count() == 1)
        //        {
        //            result.First().support += 1;
        //            try
        //            {
        //                int i = _entity.SaveChanges();
        //                isSucceed = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                //异常处理
        //                Console.WriteLine(ex);
        //                return false;
        //            }
        //        }

        //        //撤销entity对象
        //        _entity.Dispose();
        //    }

        //    return isSucceed;
        //}

        /// <summary>
        /// 这个函数根据电影院名，电影院地址，发表时间对电影院评论支持数增加1
        /// </summary>
        /// <param name="newCinemaName"></param>
        /// <param name="newCinemaAddr"></param>
        /// <param name="newTime"></param>
        /// <returns></returns>
        //public bool IncreaseCinemaCommentSupport(string newCinemaName, string newCinemaAddr, DateTime newTime)
        //{
        //    bool isSucceed = false;
        //    _entity = new WATCHMOVIEEntities();
        //    int cinemaId = new Cinema().GetCinemaId(newCinemaName, newCinemaAddr);

        //    if (cinemaId != -1)//如果cinema_id为-1则代表没有这个电影院，所以出错了
        //    {
        //        var result = from c in _entity.CINAME_COMMENT
        //                     where c.cinema_id == cinemaId && c.time.Value.Equals(newTime)
        //                     select c;

        //        if (result.Count() == 1)
        //        {
        //            result.First().support += 1;
        //            try
        //            {
        //                int i = _entity.SaveChanges();
        //                isSucceed = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                //异常处理
        //                Console.WriteLine(ex);
        //                return false;
        //            }
        //        }

        //        //撤销entity对象
        //        _entity.Dispose();
        //    }

        //    return isSucceed;
        //}
        public bool IncreaseCinemaCommentSupport(string newCinemaName, DateTime newTime)
        {
            bool isSucceed = false;
            _entity = new WATCHMOVIEEntities();
            int cinemaId = new Cinema().GetCinemaId(newCinemaName);

            if (cinemaId != -1)//如果cinema_id为-1则代表没有这个电影院，所以出错了
            {
                var result = from c in _entity.CINAME_COMMENT
                             where c.cinema_id == cinemaId && c.time.Value.Equals(newTime)
                             select c;

                if (result.Count() == 1)
                {
                    result.First().support += 1;
                    try
                    {
                        int i = _entity.SaveChanges();
                        isSucceed = true;
                    }
                    catch (Exception ex)
                    {
                        //异常处理
                        Console.WriteLine(ex);
                        return false;
                    }
                }

                //撤销entity对象
                _entity.Dispose();
            }

            return isSucceed;
        }

        /// <summary>
        /// 这个函数根据电影名，发表时间对电影院评论反对数增加1
        /// </summary>
        /// <param name="newMovieName"></param>
        /// <param name="newTime"></param>
        /// <returns></returns>
        //public bool IncreaseMovieCommentOppose(string newMovieName, DateTime newTime)
        //{
        //    bool isSucceed = false;
        //    _entity = new WATCHMOVIEEntities();
        //    int movieId = new Movie().GetMovieId(newMovieName);

        //    if (movieId != -1)//如果movie_id为-1则代表没有这个电影院，所以出错了
        //    {
        //        var result = from m in _entity.MOVIE_COMMENT
        //                     where m.movie_id == movieId && m.time.Equals(newTime)
        //                     select m;

        //        if (result.Count() == 1)
        //        {
        //            result.First().oppose += 1;
        //            try
        //            {
        //                int i = _entity.SaveChanges();
        //                isSucceed = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                //异常处理
        //                Console.WriteLine(ex);
        //                return false;
        //            }
        //        }

        //        //撤销entity对象
        //        _entity.Dispose();
        //    }

        //    return isSucceed;
        //}
        // <summary>

        /// <summary>
        /// 这个函数根据电影名，发表时间对电影院评论反对数增加1
        /// </summary>
        /// <param name="newMovieName"></param>
        /// <param name="newTime"></param>
        /// <returns></returns>
        public bool IncreaseMovieCommentOppose(string newMovieName, DateTime newTime)
        {
            bool isSucceed = false;
            _entity = new WATCHMOVIEEntities();
            int movieId = new Movie().GetMovieId(newMovieName);

            if (movieId != -1)//如果movie_id为-1则代表没有这个电影院，所以出错了
            {
                var result = from m in _entity.MOVIE_COMMENT
                             where m.movie_id == movieId && m.time.Value.Equals(newTime)
                             select m;

                if (result.Count() == 1)
                {
                    result.First().oppose += 1;
                    try
                    {
                        int i = _entity.SaveChanges();
                        isSucceed = true;
                    }
                    catch (Exception ex)
                    {
                        //异常处理
                        Console.WriteLine(ex);
                        return false;
                    }
                }


                //撤销entity对象
                _entity.Dispose();
            }

            return isSucceed;
        }
        /// 这个函数根据电影名，发表时间对电影院评论支持数增加1
        /// </summary>
        /// <param name="newMovieName"></param>
        /// <param name="newTime"></param>
        /// <returns></returns>
        //public bool IncreaseMovieCommentSupport(string newMovieName, DateTime newTime)
        //{
        //    bool isSucceed = false;
        //    _entity = new WATCHMOVIEEntities();
        //    int movieId = new Movie().GetMovieId(newMovieName);

        //    if (movieId != -1)//如果movie_id为-1则代表没有这个电影院，所以出错了
        //    {
        //        var result = from m in _entity.MOVIE_COMMENT
        //                     where m.movie_id == movieId && m.time.Equals(newTime)
        //                     select m;

        //        if (result.Count() == 1)
        //        {
        //            result.First().support += 1;
        //            try
        //            {
        //                int i = _entity.SaveChanges();
        //                isSucceed = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                //异常处理
        //                Console.WriteLine(ex);
        //                return false;
        //            }
        //        }

        //        //撤销entity对象
        //        _entity.Dispose();
        //    }

        //    return isSucceed;
        //}


        // <summary>
        /// 这个函数根据电影名，发表时间对电影院评论支持数增加1
        /// </summary>
        /// <param name="newMovieName"></param>
        /// <param name="newTime"></param>
        /// <returns></returns>
        public bool IncreaseMovieCommentSupport(string newMovieName, DateTime newTime)
        {
            bool isSucceed = false;
            _entity = new WATCHMOVIEEntities();
            int movieId = new Movie().GetMovieId(newMovieName);

            if (movieId != -1)//如果movie_id为-1则代表没有这个电影院，所以出错了
            {

                var result = from m in _entity.MOVIE_COMMENT
                             where m.movie_id == movieId && m.time.Value.Equals(newTime)
                             select m;


                if (result.Count() == 1)
                {
                    result.First().support += 1;
                    try
                    {
                        int i = _entity.SaveChanges();
                        isSucceed = true;
                    }
                    catch (Exception ex)
                    {
                        //异常处理
                        Console.WriteLine(ex);
                        return false;
                    }

                }
                //撤销entity对象
                _entity.Dispose();
            }

            return isSucceed;
        }

        public Comment(MOVIE_COMMENT newComment)
        {
            //根据MOVIE_COMMENT类型的newcomment生成Comment实例
            userName = new Search().SearchUserName((int)newComment.user_id);
            body = newComment.body;
            time = (DateTime)newComment.time;
            support = (int)newComment.support;
            oppose = (int)newComment.oppose;
        }

        public Comment(CINAME_COMMENT newComment)
        {
            //根据CINAME_COMMENT类型的newcomment生成Comment实例
            userName = new Search().SearchUserName((int)newComment.user_id);
            body = newComment.body;
            time = (DateTime)newComment.time;
            support = (int)newComment.support;
            oppose = (int)newComment.oppose;
        }

    }
}
