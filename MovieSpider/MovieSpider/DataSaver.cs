using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;


namespace MovieSpider
{
    /// <summary>
    /// 该类用于为蜘蛛捕获的程序提供写入数据库的支持。
    /// </summary>
    public class DataSaver
    {
        SqlConnection objConnection;
        System.Windows.Forms.ListBox LogBox;

        public DataSaver(System.Windows.Forms.ListBox LogBox)
        {
            //string str = "Server=(local)\\SQLExpress;user id=sa;password=sg2359756;initial catalog=WATCHMOVIE;Connect Timeout=30";
            string str = "Data Source=CHENGMIN-PC;Initial Catalog=WATCHMOVIE;Integrated Security=True;Connect Timeout=30";
            objConnection = new SqlConnection(str);
            objConnection.Open();
            this.LogBox = LogBox;
        }

        public void ClearAll()
        {
            WriteLog("DataSaver: 清空数据库");
            lock (objConnection)
            {
                SqlCommand sqlCmd = new SqlCommand("DELETE FROM MOVIE_SCHEDULE;", objConnection);
                sqlCmd.ExecuteNonQuery();
                sqlCmd = new SqlCommand("DELETE FROM CINAME_COMMENT;", objConnection);
                sqlCmd.ExecuteNonQuery();
                sqlCmd = new SqlCommand("DELETE FROM MOVIE_COMMENT;", objConnection);
                sqlCmd.ExecuteNonQuery();
                sqlCmd = new SqlCommand("DELETE FROM COLLECTION;", objConnection);
                sqlCmd.ExecuteNonQuery();
                sqlCmd = new SqlCommand("DELETE FROM MOVIE;", objConnection);
                sqlCmd.ExecuteNonQuery();
                sqlCmd = new SqlCommand("DELETE FROM CINEMA;", objConnection);
                sqlCmd.ExecuteNonQuery();
                
            }
        }

        public void SaveMovieInformation(string movie_name, string movie_director, string movie_actor, string movie_cateories, DateTime movie_dateFirstPlaying, string movie_region, int movie_length, string movie_summary, byte[] movie_pic)
        {
            WriteLog("DataSaver: 保存电影信息 " + movie_name);
            lock (objConnection)
            {
                SqlCommand sqlCmd = new SqlCommand("INSERT INTO MOVIE(name, director, actor, kind, region, last_time, first_showtime, introduction, path) VALUES(@movie_name, @movie_dir, @movie_actor, @movie_kind, @movie_region, @movie_last_time, @movie_first_show_time, @movie_summary, @movie_pic);", objConnection);
                sqlCmd.Parameters.AddWithValue("movie_name", movie_name);
                sqlCmd.Parameters.AddWithValue("movie_dir", movie_director);
                sqlCmd.Parameters.AddWithValue("movie_actor", movie_actor);
                sqlCmd.Parameters.AddWithValue("movie_kind", movie_cateories);
                sqlCmd.Parameters.AddWithValue("movie_region", movie_region);
                sqlCmd.Parameters.AddWithValue("movie_last_time", movie_length);
                if (movie_dateFirstPlaying == DateTime.MinValue)
                    movie_dateFirstPlaying = DateTime.Parse("2099-9-9 9:9:9");
                sqlCmd.Parameters.AddWithValue("movie_first_show_time", movie_dateFirstPlaying);
                sqlCmd.Parameters.AddWithValue("movie_summary", movie_summary);

                // 保存图片
                string picfile = "imgs\\" + (Guid.NewGuid()).ToString() + ".jpg";
                File.WriteAllBytes(picfile, movie_pic);
                sqlCmd.Parameters.AddWithValue("movie_pic", picfile);

                sqlCmd.ExecuteNonQuery();
            }
        }

        public void SaveTheaterInformation(string name, string address, string phone, string stime, string etime, string summary, byte[] pic)
        {
            WriteLog("DataSaver: 保存影院信息 " + name);
            if (GetTheaterID(name) != -1)
                return;
            lock (objConnection)
            {
                SqlCommand sqlCmd = new SqlCommand("INSERT INTO CINEMA(name, address, phone, start_work_time, end_work_time, introduction, path) VALUES (@name, @address, @phone, @start_work_time, @end_work_time, @introduction, @path);", objConnection);
                sqlCmd.Parameters.AddWithValue("name", name);
                sqlCmd.Parameters.AddWithValue("address", address);
                sqlCmd.Parameters.AddWithValue("phone", phone);
                sqlCmd.Parameters.AddWithValue("start_work_time", stime);
                sqlCmd.Parameters.AddWithValue("end_work_time", etime);
                sqlCmd.Parameters.AddWithValue("introduction", summary);

                // 保存图片
                string picfile = "imgs\\" + (Guid.NewGuid()).ToString() + ".jpg";
                File.WriteAllBytes(picfile, pic);
                sqlCmd.Parameters.AddWithValue("path", picfile);

                sqlCmd.ExecuteNonQuery();
            }
        }

        public void SavePlaytimeInformation(string movie_name, string theater_name, DateTime time, int price, string order_website)
        {
            WriteLog("DataSaver: 保存电影场次信息 " + movie_name);
            lock (objConnection)
            {
                SqlCommand sqlCmd = new SqlCommand("INSERT INTO MOVIE_SCHEDULE(movie_id, cinema_id, showtime, price, book_website) VALUES (@movie_id, @cinema_id, @showtime, @price, @order_website);", objConnection);
                sqlCmd.Parameters.AddWithValue("movie_id", GetMovieID(movie_name));
                sqlCmd.Parameters.AddWithValue("cinema_id", GetTheaterID(theater_name));
                sqlCmd.Parameters.AddWithValue("showtime", time);
                sqlCmd.Parameters.AddWithValue("price", price);
                sqlCmd.Parameters.AddWithValue("order_website", order_website);
                sqlCmd.ExecuteNonQuery();
            }
        }

        public int GetMovieID(string movie_name)
        {
            lock (objConnection)
            {
                SqlCommand sqlCmd = new SqlCommand("SELECT id FROM MOVIE WHERE name = '" + movie_name + "'", objConnection);
                return int.Parse(sqlCmd.ExecuteScalar().ToString());
            }
        }

        public int GetTheaterID(string theater_name)
        {
            lock (objConnection)
            {
                SqlCommand sqlCmd = new SqlCommand("SELECT id FROM CINEMA WHERE name = '" + theater_name + "'", objConnection);
                try
                {
                    return int.Parse(sqlCmd.ExecuteScalar().ToString());
                }
                catch
                {
                    return -1;
                }
            }
        }

        public void WriteLog(string log)
        {
            try
            {
                lock (LogBox)
                    LogBox.SetSelected(LogBox.Items.Add(DateTime.Now.ToShortTimeString() + " " + log), true);
            }
            catch (NullReferenceException)
            {

            }
        }

    }
}
