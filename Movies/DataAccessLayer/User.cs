using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;

namespace DataAccessLayer
{
    public class User
    {

        
        private int _id;
        public int Id { get; set; }

        public bool UpdatePassword(string newEmail, string newPassword)
        {
            //更新密码
            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();
            var result = from user in entity.RUSER
                         where user.email == newEmail
                         select user;
            if (result.Count() == 1)
            {
                //修改密码
                result.First().password = newPassword;
                try
                {
                    int i = entity.SaveChanges();//保存修改
                    entity.Dispose();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.ToString());
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool PreferenceSave(string newEmail, string newType)
        {
            //保存用户偏好
            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();
            var result = from user in entity.RUSER
                         where user.email == newEmail
                         select user;//找到用户
            if (result.Count() == 1)
            {
                result.First().like_kind = newType;//保存用户偏好
                //result.First().address = newAddr;
                try
                {
                    int i = entity.SaveChanges();//同步到数据库
                    entity.Dispose();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.ToString());
                    return false;
                }
                return true;

            }
            else
            {
                return false;
            }
        }

        public bool AddCinemaComment(string newCinemaName,int  newCinemaId, CINAME_COMMENT  newComment) 
        {
            //添加用户对电影院的评论
            //修改 增加一个电影院的ID 唯一定位电影院
            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();
            var result = from cinema in entity.CINEMA
                         where cinema.name == newCinemaName && cinema.id  == newCinemaId 
                         select cinema;//检索出对应的电影院
            if (result.Count() == 1)
            {
                entity.CINAME_COMMENT.AddObject(newComment);//向电影评论列表中添加一条新评论
                try 
                {
                    int i = entity.SaveChanges();
                    entity.Dispose();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.ToString());
                    return false;
                }
                return true;
            }
            else 
            {
                return false;
            }
            
        }
        public bool AddMovieComment(string newMovieName,MOVIE_COMMENT  newComment)
        {
            //添加用户对电影的评论
            //？？？？？？？？？？？？？？？？？？？？？？？？？？

            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();
            var result = from movie in entity.MOVIE
                         where movie.name == newMovieName
                         select movie;//定位到对应的电影
            if (result.Count () == 1)
            {
                entity.MOVIE_COMMENT.AddObject(newComment);
                try
                {
                    int i = entity.SaveChanges();
                    entity.Dispose();
                }
                catch (Exception exp) 
                {
                    MessageBox.Show(exp.ToString());
                    return false;
                }
                return true;
            }
            else 
            {
                return false;
            }
        }

        public bool AddUser(string newName,string newEmail,string newePassword) 
        {
            Search searchEmail=new Search ();//用来检查newEmai是不是已经注册过
            if(!(searchEmail.SearchEmail (newEmail )))
            {
                //创建新用户

                WATCHMOVIEEntities entity = new WATCHMOVIEEntities();
                RUSER newUser = new RUSER();

                //为新用户添加基本信息
                newUser.name = newName;
                newUser.password = newePassword;
                newUser.email = newEmail;

                entity.RUSER.AddObject(newUser);
                try
                {
                    int i = entity.SaveChanges();
                }
                catch (Exception exp) 
                {
                    MessageBox.Show(exp.ToString());
                    entity.Dispose();
                    return false;
                }
                entity.Dispose();

                return true;
            }
            else 
            {
                return false;
            }    
        }


        public bool DeleteUser() //删除用户
        {
            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();
            var result = from user in entity.RUSER
                         where user.id == _id
                         select user;
            if (result.Count() == 1)
            {
                entity.RUSER.DeleteObject(result.First());
                try
                {
                    int i = entity.SaveChanges();
                    entity.Dispose();
                }
                catch (Exception exp) 
                {
                    MessageBox.Show(exp.ToString());
                    return false;
                }
                return true;
            }
            else 
            {
                return false;
            }
        }

        public int GetUserId(string newEmail) //获取用户ID
        {
            WATCHMOVIEEntities entity = new WATCHMOVIEEntities();
            var result = from user in entity.RUSER
                         where user.email == newEmail
                         select user;
            if (result.Count() == 1)
            {
                return result.First().id;
            }
            else
            {
                return -1;
            }
        }


        public User(int id) //构造函数
        {
            _id = id;
        }
        public User() { }//没有参数的构造函数
    }
}
