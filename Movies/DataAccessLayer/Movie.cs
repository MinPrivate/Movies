using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public class Movie
    {
       /* public bool AddMovie(string name,string director,string actor,string kind,string region
            ,int lastingTime,DateTime firstShowTime,string introduction,Byte  rank,int rankNum,
            int clickNum,bool onShow)
        {//向数据库电影表MOVIEs中插入一个电影记录

            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();
            MOVIE newMovie = new MOVIE();
            newMovie.name = name;
            newMovie.director = director;
            newMovie.actor = actor;
            newMovie.kind = kind;
            newMovie.region = region;
            newMovie.last_time = lastingTime;
            newMovie.first_showtime = firstShowTime;
            newMovie.introduction = introduction;
            newMovie.rank = rank;
            newMovie.rank_number = rankNum;
            newMovie.click_number = clickNum;
            newMovie.is_on_show = onShow;//给新对象添加属性；

            entity.MOVIE.AddObject(newMovie);
            int i=0;
            try
            {
                i = entity.SaveChanges();
            }
            catch (Exception exp) 
            {
                MessageBox.Show (exp.ToString());
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
            //newMovie.last_time = lastingTime;  //7.22 cm
            newMovie.last_time = (short)lastingTime;
            newMovie.first_showtime = firstShowTime;
            newMovie.introduction = introduction;
            newMovie.rank = rank;
            //newMovie.rank_number = rankNum;   //7.22 cm
            newMovie.rank_number = (short)rankNum;
            //newMovie.click_number = clickNum;  //7.22 cm
            newMovie.click_number = (short)clickNum;


            entity.MOVIE.AddObject(newMovie);
            int i = 0;
            try
            {
                i = entity.SaveChanges();
            }
            catch (Exception exp)
            {
                //MessageBox.Show(exp.ToString());
                entity.Dispose();//销毁对象
                return false;
            }
            entity.Dispose();//销毁对象
            return true;

        }
        public bool DeleteMovie(string movieName,DateTime movieShowTime) 
        {
            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();
            var result = from movie in entity.MOVIE
                         where movie.name == movieName && movie .first_showtime ==movieShowTime 
                         select movie;//现在数据库根据影片名字 和首次放映时间 选择相关的影片记录
            foreach (var oldMovie in result) 
            {
                entity.MOVIE.DeleteObject(oldMovie);//是不是全部删除啊  根据什么删除？
            }
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

        public int GetMovieId(string newMovieName)
        {
            //根据电影名字和位置得到电影的ID
            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();
            var result = from movie in entity.MOVIE
                         where movie.name == newMovieName
                         select movie;
            if (result.Count() == 1)
            {
                return result.First().id;
            }
            else
            {
                return -1;//出错返回-1
            }
        }
        public int GetGradeByName(string newMovieName)
        {
            //根据电影名字得到该电影的评分
            int grade = 0;
            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();

            var result = from m in entity.MOVIE
                         where m.name.Equals(newMovieName)
                         select m;

            grade = (int)result.First().rank;

            return grade;
        }

        public string GetKindByName(string newMovieName)
        {
            //根据电影名字得到电影种类
            string kind = null;
            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();

            var result = from m in entity.MOVIE
                         where m.name.Equals(newMovieName)
                         select m;

            kind = result.First().kind;

            return kind;
        }

        public int GetCinemaNumByMovieName(string newMovieName)
        {
            //根据电影名字得到播放该电影的影院数目
            int count = 0;
            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();

            int movieId = new Movie().GetMovieId(newMovieName);
            if (movieId != -1)//-1代表出错
            {
                var result = (
                               from s in entity.MOVIE_SCHEDULE
                               where s.movie_id == movieId
                               select s.cinema_id
                          ).Distinct();

                count = result.Count();
            }

            return count;
        }

        public bool RankMovieByName(string newMovieName, int newRank)
        {
            //根据电影名字对电影进行评分
            bool isSucceed = false;
            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();

            int rank = 0;
            int rankNum = 0;
            int movieId = new Movie().GetMovieId(newMovieName);

            if (movieId != -1)//如果电影ID为-1，则代表没有这个影院，所以出错了
            {
                var result = from m in entity.MOVIE
                             where m.id == movieId
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
