using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class Collections
    {
        /// <summary>
        ///数据库实体类对象
        /// </summary>
        WATCHMOVIEEntities _entity;


        /// <summary>		
        /// 说明：<调用函数调用InsertCollection函数可以完成对收藏夹增加一条记录的功能>
        /// </summary>
        /// <param name="<newCollection>"><接受调用函数传入的一个COLLECTION对象></param>
        /// <returns><操作成功返回True，否则返回False> </returns>
        ///<exception>数据库增加操作异常</exception> 

        public bool InsertCollection(COLLECTION newCollection)
        {
            //创建数据库实体类对象
            _entity = new WATCHMOVIEEntities();

            bool isSucceed = false;

            //添加记录到内存
            _entity.AddToCOLLECTION(newCollection);

            //保存修改到数据库
            try
            {
                int i = _entity.SaveChanges();
                isSucceed = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
               //异常处理？
                return false;
            }

            //撤销entity对象
            _entity.Dispose();

            return isSucceed;
        }

        /// <summary>		
        /// 说明：<重载InsertCollection >
        /// </summary>
        /// <param name="<newUserId>" name="<newMovieId>">
        /// <接受调用函数传入COLLECTION的三个字段作为参数></param>
        /// <returns><操作成功返回True，否则返回False> </returns>
        ///<exception>数据库增加操作异常</exception> 

        //public bool InsertCollection(int newUserId, int newMovieId)
        //{
        //    //创建数据库实体类对象
        //    _entity = new WATCHMOVIEEntities();

        //    bool isSucceed = false;

        //    //创建一个临时COLLECTION对象
        //    COLLECTION collection = new COLLECTION();


        //    //collection.id = newId;
        //    collection.user_id = newUserId;
        //    collection.movie_id = newMovieId;

        //    //添加记录到内存
        //    _entity.AddToCOLLECTION(collection);

        //    //保存修改到数据库
        //    try
        //    {
        //        int i = _entity.SaveChanges();
        //        isSucceed = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        //异常处理？
        //        return false;
        //    }

        //    //撤销数据库实体
        //    _entity.Dispose();

        //    return isSucceed;
        //}
        public bool InsertCollection(int newUserId, int newMovieId)
        {
            //创建数据库实体类对象
            _entity = new WATCHMOVIEEntities();

            bool isSucceed = false;

            var result = from c in _entity.COLLECTION
                         where c.user_id == newUserId && c.movie_id == newMovieId
                         select c;

            if (result.Count() > 0)
            {
                return isSucceed;
            }
            //创建一个临时COLLECTION对象
            COLLECTION collection = new COLLECTION();


            //collection.id = newId;
            collection.user_id = newUserId;
            collection.movie_id = newMovieId;


            //添加记录到内存
            _entity.AddToCOLLECTION(collection);

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

            //撤销数据库实体
            _entity.Dispose();

            return isSucceed;
        }
        /// <summary>		
        /// 说明：<调用函数调用InsertCollections函数可以完成对收藏夹增加多条记录的功能>
        /// </summary>
        /// <param name="<newCollections>"><接受调用函数传入的一个COLLECTION对象集合></param>
        /// <returns><操作成功返回True，否则返回False> </returns>
        ///<exception>数据库增加操作异常</exception> 

        public bool InsertCollections(List<COLLECTION> newCollections)
        {
            //创建数据库实体类对象
            _entity = new WATCHMOVIEEntities();

            bool isSucceed = false;

            //添加新记录到内存 
            foreach (COLLECTION newCollection in newCollections)
            {
                _entity.AddToCOLLECTION(newCollection);
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
        /// 说明：<调用函数调用DeleteCollectionById函数可以完成对收藏夹删除一条记录的功能>
        /// </summary>
        /// <param name="<newId>"><接受调用函数传入的一个COLLECTION对象的Id></param>
        /// <returns><操作成功返回True，否则返回False> </returns>
        ///<exception>数据库删除操作异常</exception> 
        public bool DeleteCollectionById(int newId)
        {
            //创建数据库实体对象
            _entity = new WATCHMOVIEEntities();

            bool isSucceed = false;

            //查找到需要删除的数据——（根据收藏id查找 结果只可能是一个）
            var result = from c in _entity.COLLECTION
                         where c.id == newId
                         select c;

            //从数据库中删除查找到的记录 并保存
            if (result.Count() >= 1)
            {
                _entity.COLLECTION.DeleteObject(result.First());
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
        /// 说明：<调用函数调用DeleteCollectionsByUserId函数
        /// 可以完成对收藏夹删除于此用户相关的所以记录的功能>
        /// </summary>
        /// <param name="<newUserId>"><接受调用函数传入的一个用户对象的Id></param>
        /// <returns><操作成功返回True，否则返回False> </returns>
        ///<exception>数据库删除操作异常</exception> 
        public bool DeleteCollectionsByUserId(int newUserId)
        {
            //创建数据库实体对象
            _entity = new WATCHMOVIEEntities();

            bool isSucceed = false;

            //查找到需要删除的数据——（根据用户id查找 结果是该用户所有收藏记录）
            var result = from c in _entity.COLLECTION
                         where c.user_id == newUserId
                         select c;

            //从数据库中删除查找到的记录
            foreach (var a in result)
            {
                _entity.COLLECTION.DeleteObject(a);
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
        /// 说明：<调用函数调用DeleteCollectionsByMovieId函数
        /// 可以完成对收藏夹删除于此电影相关的所以记录的功能>
        /// </summary>
        /// <param name="<newMovieId>"><接受调用函数传入的一个电影对象的Id></param>
        /// <returns><操作成功返回True，否则返回False> </returns>
        ///<exception>数据库删除操作异常</exception> 
        public bool DeleteCollectionsByMovieId(int newMovieId)
        {
            //创建数据库实体对象
            _entity = new WATCHMOVIEEntities();

            bool isSucceed = false;

            //查找到需要删除的数据——（根据电影id查找 结果是有关该电影所有收藏记录）
            var result = from c in _entity.COLLECTION
                         where c.movie_id == newMovieId
                         select c;

            //从数据库中删除查找到的记录
            foreach (var a in result)
            {
                _entity.COLLECTION.DeleteObject(a);
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
