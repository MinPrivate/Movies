using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace MovieSpider
{
    public class MoviePageSpider : MovieSpiderBase
    {
        /* 公共属性 继承 */

        /// <summary>
        /// 获取该蜘蛛是否支持递归地向下分析网页。
        /// </summary>
        public override bool Recursive
        {
            get
            {
                return true;
            }
        }

        /* 公共属性 */

        /// <summary>
        /// 指定或获取要获取正在热映电影列表的省份。
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 指定或获取要获取正在热映电影列表的城市。
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 指定或获取要显示的电影 ID。
        /// </summary>
        public string MovieID { get; set; }

        /* 公共方法 */

        /// <summary>
        /// 分析指定的 URI，进行爬虫递归。
        /// </summary>
        public override void DoWork()
        {
            if (this.TargetURI == null)
            {
                if (this.MovieID == null || this.City == null || this.Province == null) // 参数错误
                {
                    throw new NullReferenceException("此 MoviePageSpider 的 MovieID 需要非 null 值。");
                }
                this.TargetURI = new Uri("http://movie.mtime.com/" + this.MovieID + "/"); // 默认 URI。
            }
            WebClient client = new WebClient();
            try
            {
                // 下载页面源代码
                this.FetchedDataSaver.WriteLog("MoviePageSpider: 下载 " + this.TargetURI.ToString());
                string pageSource = Encoding.UTF8.GetString(client.DownloadData(this.TargetURI));

                // 根据正则表达式进行过滤
                this.FetchedDataSaver.WriteLog("MoviePageSpider: 分析 " + this.TargetURI.ToString());
                string movie_name = Regex.Match(pageSource, "(?<=<span class=\"px28 bold hei c_000\" property=\"v:itemreviewed\">).+?(?=</span>)").Value; // 匹配影片名
                this.FetchedDataSaver.WriteLog("MoviePageSpider: 获取影片 " + movie_name);
                string movie_director = ConcatRegexMatchWithTrim("(?<=<a target=\"_blank\" href=\"http://people.mtime.com/\\d+/\" class=\"mr6\" rel=\"v:directedBy\">).+?(?=<)", pageSource, " / "); // 导演
                string movie_actor = ConcatRegexMatchWithTrim("(?<=<a target=\"_blank\" href=\"http://people.mtime.com/\\d+/\" class=\"mr6\" rel=\"v:starring\">).+?(?=<)", pageSource, " / "); // 明星
                string movie_cateories = ConcatRegexMatchWithTrim("(?<=<a target=\"_blank\" href=\".*?\" property=\"v:genre\" >).+?(?=<)", pageSource, " / "); // 分类
                DateTime movie_dateFirstPlaying;
                try
                {
                    movie_dateFirstPlaying = DateTime.Parse(ConcatRegexMatchWithTrim("(?<=<span property=\"v:initialReleaseDate\" content=\").+?(?=\")", pageSource, " / ")); // 首映日期
                }
                catch
                {
                    movie_dateFirstPlaying = DateTime.MinValue;
                }
                string movie_region = Regex.Match(pageSource, "(?<=<a target=\"_blank\" href=\"http://movie.mtime.com/movie/search/section/\\?nation=.+?\">).+?(?=</a>)").Value.Replace("&nbsp;", "").Trim(); // 区域
                int movie_length;
                try
                {
                    movie_length = int.Parse(Regex.Match(pageSource, "(?<=<span property=\"v:runtime\" content=\")\\d+").Value); // 电影长度（分钟）
                }
                catch
                {
                    movie_length = -1;
                }
                string movie_summary = Regex.Match(pageSource, "(?<=<span property=\"v:summary\">).+?(?=</span>)").Value; // 影片概述

                string movie_pic_url = Regex.Match(pageSource, "(?<=<img src=\").+?(?=\" class=\"movie_film_img)").Value.Trim(); // 图片地址
                this.FetchedDataSaver.WriteLog("下载 " + movie_pic_url);
                byte[] movie_pic = client.DownloadData(movie_pic_url);
                
                // 保存信息
                this.FetchedDataSaver.SaveMovieInformation(movie_name, movie_director, movie_actor, movie_cateories, movie_dateFirstPlaying, movie_region, movie_length, movie_summary, movie_pic);
            }
            catch (WebException ex)
            {
                throw new WebException("因为下载页面失败，Spider 无法进行分析。", ex);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 分析指定的 URI，进行爬虫递归。
        /// </summary>
        public override void DoWorkAsync()
        {
            throw new NotImplementedException();
        }

        /* 私有方法 */

        /// <summary>
        /// 连接所有用正则表达式检索到的结果。
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="input"></param>
        /// <param name="connectionChars"></param>
        /// <returns></returns>
        private string ConcatRegexMatchWithTrim(string pattern, string input, string connectionChars)
        {
            Regex regex = new Regex(pattern);
            string ret = "";
            foreach (Match m in regex.Matches(input))
            {
                if (ret == "")
                    ret = m.Value.Trim();
                else
                    ret += connectionChars + m.Value.Trim(); 
            }

            return ret;
        }

    }
}
