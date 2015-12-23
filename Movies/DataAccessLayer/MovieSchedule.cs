using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class MovieSchedule
    {
        /// <summary>
        ///数据库实体类对象
        /// </summary>
        WATCHMOVIEEntities _entity;


        /// <summary>		
        /// 说明：<调用函数调用InsertMovieSchedule函数可以完成对电影时刻表增加一条记录的功能>
        /// </summary>
        /// <param name="<newMovieSchedule>"><接受调用函数传入的一个MOVIE_SCHEDULE对象></param>
        /// <returns><操作成功返回True，否则返回False> </returns>
        ///<exception>数据库增加操作异常</exception> 
        public bool InsertMovieSchedule(MOVIE_SCHEDULE newMovieSchedule)
        {
            //创建数据库实体类对象
            _entity = new WATCHMOVIEEntities();

            bool isSucceed = false;

            //添加记录到内存
            _entity.AddToMOVIE_SCHEDULE(newMovieSchedule);

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
        /// 说明：<调用函数调用InsertMovieSchedules函数可以完成对电影时刻表增加多条记录的功能>
        /// </summary>
        /// <param name="<newMovieSchedules>"><接受调用函数传入的一个COLLECTION对象集合></param>
        /// <returns><操作成功返回True，否则返回False> </returns>
        ///<exception>数据库增加操作异常</exception> 

        public bool InsertMovieSchedules(List<MOVIE_SCHEDULE> newMovieSchedules)
        {
            //创建数据库实体类对象
            _entity = new WATCHMOVIEEntities();

            bool isSucceed = false;

            //添加新记录到内存
            foreach (MOVIE_SCHEDULE newMovieSchedule in newMovieSchedules)
            {
                _entity.AddToMOVIE_SCHEDULE(newMovieSchedule);
            }

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
        /// 说明：<调用函数调用DeleteMovieScheduleById函数可以完成对电影时刻表删除一条记录的功能>
        /// </summary>
        /// <param name="<newId>"><接受调用函数传入的一个MOVIE_SCHEDULE对象的Id></param>
        /// <returns><操作成功返回True，否则返回False> </returns>
        ///<exception>数据库删除操作异常</exception> 
        public bool DeleteMovieScheduleById(int newId)
        {
            //创建数据库实体对象
            _entity = new WATCHMOVIEEntities();

            bool isSucceed = false;

            //查找到需要删除的数据——（根据电影时刻表id查找 结果只可能是一个）
            var result = from c in _entity.MOVIE_SCHEDULE
                         where c.id == newId
                         select c;

            //从数据库中删除查找到的记录 并保存
            if (result.Count() >= 1)
            {
                _entity.MOVIE_SCHEDULE.DeleteObject(result.First());

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
            }

            //撤销entity对象
            _entity.Dispose();

            return isSucceed;
        }


        /// <summary>		
        /// 说明：<调用函数调用DeleteCollectionsByCinemaId函数
        /// 可以完成对收藏夹删除于此影院相关的所以记录的功能>
        /// </summary>
        /// <param name="<newCinemaId>"><接受调用函数传入的一个影院对象的Id></param>
        /// <returns><操作成功返回True，否则返回False> </returns>
        ///<exception>数据库删除操作异常</exception> 
        public bool DeleteMovieSchedulesByCinemaId(int newCinemaId)
        {
            //创建数据库实体对象
            _entity = new WATCHMOVIEEntities();

            bool isSucceed = false;

            //查找到需要删除的数据——（根据影院id查找 结果是与该影院相关所有电影时刻表记录）
            var result = from c in _entity.MOVIE_SCHEDULE
                         where c.cinema_id == newCinemaId
                         select c;

            //从数据库中删除查找到的记录
            foreach (var a in result)
            {
                _entity.MOVIE_SCHEDULE.DeleteObject(a);
            }

            //保存更改到数据库
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
        /// 说明：<调用函数调用DeleteMovieSchedulesByMovieId函数
        /// 可以完成对收藏夹删除于此电影相关的所以记录的功能>
        /// </summary>
        /// <param name="<newMovieId>"><接受调用函数传入的一个电影对象的Id></param>
        /// <returns><操作成功返回True，否则返回False> </returns>
        ///<exception>数据库删除操作异常</exception> 
        public bool DeleteMovieSchedulesByMovieId(int newMovieId)
        {
            //创建数据库实体对象
            _entity = new WATCHMOVIEEntities();

            bool isSucceed = false;

            //查找到需要删除的数据——（根据电影id查找 结果是有关该电影所有电影时刻表记录）
            var result = from c in _entity.MOVIE_SCHEDULE
                         where c.movie_id == newMovieId
                         select c;

            //从数据库中删除查找到的记录
            foreach (var a in result)
            {
                _entity.MOVIE_SCHEDULE.DeleteObject(a);
            }

            //保存更改到数据库
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
    }
}
