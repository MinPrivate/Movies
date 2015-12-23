using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;


namespace BusinessLogicLayer
{
    public class UersBLL
    {
        public bool CheckPassword(string newPassword)
        {

            /*
             修改密码之前检查老密码是否正确
             */
            int id = 0;//获取用户登录ID
            Search s = new Search();
            return s.SearchUser(id, newPassword);//实现时修改

        }
        public bool CheckPassword(string newEmail, string newPassword)
        {

            /*
             登录时的检查
             */

            Search s = new Search();
            return s.SearchUserInfo(newEmail, newPassword);//实现时修改

            //返回值是false 时 提示相关信息

        }
        public bool UpdatePassword(string newEmail, string newPassWord)
        {
            //更新新密码

            User U = new User();
            return U.UpdatePassword(newEmail, newPassWord);//实现时修改

        }
        public bool PreferenceSave(string newEmail, string newType)
        {
            //保存用户偏好信息
            User newUser = new User();
            return newUser.PreferenceSave(newEmail, newType);


        }

        public List<MOVIE> GetcollectionByUserID(int newId)
        {
            //返回用户收藏电影信息
            Search s = new Search();
            return s.SearchPreferMovies(newId);//实现时修改

        }
        public void MadeCommentOnCinema(string newCinemaName, int newId, CINAME_COMMENT newComment)
        {
            //添加对电影院的评论 传入一个电影院名字和一个评论对象  
            int id = newId;//获取登录ID
            User U = new User(id);
            U.AddCinemaComment(newCinemaName,newId, newComment);

        }
        public void MadeCommentOnMovie(string newMovieName, MOVIE_COMMENT newComment)
        {
            //添加对电影的评论 传入一个电影名字和一个评论对象
            int id = 0;//获取登录ID
            User U = new User(id);
            U.AddMovieComment(newMovieName, newComment);
        }
        public bool CreateUser(string newName, string newEmail, string newePassword)
        {
            //创建一个新用户
            User U = new User();
            bool flag = U.AddUser(newName, newEmail, newePassword);
            //判断是否创建成功 未成功则提示 

            return flag;//实现时修改    ************已修改
        }
        //public bool CheckEmail(string newEmail)
        //{
        //    //注册时检查Email是否已经存在
        //    Search s = new Search();
        //    return false;//实现时修改
        //}

        public int GetUserId(string newEmail)
        {
            //获取用户ID
            User user = new User();
            return user.GetUserId(newEmail);
        }

        public List<MOVIE> GetPreferenceMoviesByUserId(int newUserId)
        {
            //根据用户id 得到用户的 偏好电影信息
            Search search = new Search();
            List<MOVIE> result = new List<MOVIE>();
            result = search.SearchPreferMovies(newUserId);

            return result;
        }

        public List<MOVIE> GetcollectionByUserId(int newId)
        {
            //返回用户收藏电影信息
            Search s = new Search();
            return s.SearchCollectedMovies(newId);//实现时修改

        }

        public string GetUserName(int userId)
        {

            string userName = new Search().SearchUserName(userId);

            return userName;

        }

        public bool SaveCollection(int newUserId, string newMovieName)
        {
            //保存用户收藏信息

            Collections c = new Collections();
            Movie m = new Movie();

            int movieId = m.GetMovieId(newMovieName);
            return c.InsertCollection(newUserId, movieId);
        }
    }
}
