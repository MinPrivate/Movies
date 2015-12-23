using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace DataAccessLayer
{
    public class Cinema
    {
        string _cinemaName;

        int _cinemaId;

        public List<MOVIE_SCHEDULE> _cinemaMovieSchedule;

        public string CinemaName
        {
            get
            {
                return _cinemaName;
            }
            set
            {
                _cinemaName = value;
            }

        }

        public int CinemaId
        {
            get
            {
                return _cinemaId;
            }
            set
            {
                _cinemaId = value;
            }

        }


        /*public bool AddCinema(string name, string addr, string phoneNum, TimeSpan openTime, TimeSpan closeTime,
             string introduction, string webSite, Byte rank, int rankNum)
        {//插入一条电影院信息
            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();
            CINEMA newCinema = new CINEMA();

            //为新对象的属性赋值

            newCinema.name = name;
            newCinema.address = addr;
            newCinema.phone = phoneNum;
            newCinema.start_work_time = openTime.ToString();//类型有没有问题
            newCinema.end_work_time = closeTime.ToString();//TimeSpan 
            newCinema.introduction = introduction;
            newCinema.website = webSite;
            newCinema.rank = rank;
            newCinema.rank_number = rankNum;

            entity.CINEMA.AddObject(newCinema);
            try
            {
                int i = entity.SaveChanges();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
                entity.Dispose();//销毁对象
                return false;
            }
            entity.Dispose();//销毁对象
            return true;
        }
        */
        public bool AddMovie(string name, string director, string actor, string kind, string region
            , int lastingTime, DateTime firstShowTime, string introduction, Byte rank, int rankNum,
            int clickNum)
        {//向数据库电影表MOVIEs中插入一个电影记录

            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();
            MOVIE newMovie = new MOVIE();
            //给新对象添加属性；
            newMovie.name = name;
            newMovie.director = director;
            newMovie.actor = actor;
            newMovie.kind = kind;
            newMovie.region = region;
            newMovie.last_time = (short)lastingTime;
            newMovie.first_showtime = firstShowTime;
            newMovie.introduction = introduction;
            newMovie.rank = rank;
            newMovie.rank_number = (short)rankNum;
            newMovie.click_number = (short)clickNum;


            entity.MOVIE.AddObject(newMovie);
            int i = 0;
            try
            {
                i = entity.SaveChanges();
            }
            catch (Exception exp)
            {//
                //MessageBox.Show(exp.ToString());
                entity.Dispose();//销毁对象
                return false;
            }
            entity.Dispose();//销毁对象
            return true;

        }

        public bool DeleteCinema(string name, string addr) 
        {
            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();

            //根据电影院名字遍历数据库表CINEMA 
            var result = from cinema in entity.CINEMA
                         where cinema.name ==name && cinema.address == addr
                         select cinema;

            //删除满足条件的电影院
            foreach (var deleteCinema in result) 
            {
                entity.CINEMA.DeleteObject(deleteCinema);
            }
            try
            {
                int i = entity.SaveChanges();
            }
            catch(Exception exp) 
            {
               // MessageBox.Show(exp.ToString());
                entity.Dispose();//销毁对象
                return false;
            }
            entity.Dispose();//销毁对象
            return true;
        }

        //public int GetCinemaId(string newCinemaName, string newCinemaAdddr)
        //{
        //    //根据电影名字和位置得到电影的ID
        //    WATCHMOVIEEntities entity = new WATCHMOVIEEntities();
        //    var result = from cinema in entity.CINEMA
        //                 where cinema.address == newCinemaAdddr && cinema.name == newCinemaName
        //                 select cinema;
        //    if (result.Count() == 1)
        //    {
        //        return result.First().id;
        //    }
        //    else
        //    {
        //        return -1;//出错返回-1
        //    }
        //}

        public int GetCinemaId(string newCinemaName)
        {
            //所有相关函数用到GetCinemaId都得修改，有点小麻烦
            //根据电影名字和位置得到电影的ID
            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();
            var result = from cinema in entity.CINEMA
                         where cinema.name.Equals(newCinemaName)
                         select cinema;
            if (result.Count() == 1)
            {
                return result.First().id;
            }
            else
            {
                return -1;//出错返回-1
            }
        }


        public int GetMovieNumByCinemaName(string newCinemaName, string newCinemaAddr)
        {
            //根据电影院名字得到该影院播放的电影数目
            int count = 0;
            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();

            int cinemaId = new Cinema().GetCinemaId(newCinemaName);
            if (cinemaId != -1)//-1代表出错
            {
                var result = (
                               from s in entity.MOVIE_SCHEDULE
                               where s.cinema_id == cinemaId
                               select s.movie_id
                          ).Distinct();

                count = result.Count();
            }

            return count;
        }

        //与上面重复
        //public int GetMovieNumByCinemaName(string newCinemaName, string newCinemaAddr)
        //{
        //    //根据电影院名字得到该影院播放的电影数目
        //    int count = 0;
        //    WATCHMOVIEEntities entity = new WATCHMOVIEEntities();

        //    int cinemaId = new Cinema().GetCinemaId(newCinemaName, newCinemaAddr);
        //    if (cinemaId != -1)//-1代表出错
        //    {
        //        var result = (
        //                       from s in entity.MOVIE_SCHEDULE
        //                       where s.cinema_id == cinemaId
        //                       select s.movie_id
        //                  ).Distinct();

        //        count = result.Count();
        //    }

        //    return count;
        //}

        //public bool RankCinemaByNameAddr(string newCinemaName, string newCinemaAddr, int newRank)
        //{
        //    //根据电影院名字，地址对电影院进行评分
        //    bool isSucceed = false;
        //    WATCHMOVIEEntities entity = new WATCHMOVIEEntities();

        //    int rank = 0;
        //    int rankNum = 0;
        //    int cinemaId = new Cinema().GetCinemaId(newCinemaName, newCinemaAddr);

        //    if (cinemaId != -1)//如果电影院ID为-1，则代表没有这个影院，所以出错了
        //    {
        //        var result = from m in entity.CINEMA
        //                     where m.id == cinemaId
        //                     select m;

        //        if (result.Count() == 1)
        //        {
        //            rank = (int)result.First().rank;
        //            rankNum = (int)result.First().rank_number;
        //            rank = (rank * rankNum + newRank) / (rankNum + 1);

        //            result.First().rank = (byte)rank;
        //            result.First().rank_number += 1;

        //            try
        //            {
        //                int i = entity.SaveChanges();
        //                isSucceed = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                //异常处理
        //                Console.WriteLine(ex);
        //                return false;
        //            }

        //        }

        //    }

        //    return isSucceed;
        //}
        //RankCinemaByNameAddr改名RankCinemaByName
        public bool RankCinemaByName(string newCinemaName, int newRank)
        {
            //根据电影院名字，地址对电影院进行评分
            bool isSucceed = false;
            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();

            int rank = 0;
            int rankNum = 0;
            int cinemaId = new Cinema().GetCinemaId(newCinemaName);

            if (cinemaId != -1)//如果电影院ID为-1，则代表没有这个影院，所以出错了
            {
                var result = from m in entity.CINEMA
                             where m.id == cinemaId
                             select m;

                if (result.Count() == 1)
                {
                    rank = (int)result.First().rank;
                    rankNum = (int)result.First().rank_number;
                    rank = (rank * rankNum + newRank) / (rankNum + 1);

                    result.First().rank = (byte)rank;
                    result.First().rank_number += 1;

                    try
                    {
                        int i = entity.SaveChanges();
                        isSucceed = true;
                    }
                    catch (Exception ex)
                    {
                        //异常处理
                        Console.WriteLine(ex);
                        return false;
                    }

                }

            }

            return isSucceed;
        }

    }
}
