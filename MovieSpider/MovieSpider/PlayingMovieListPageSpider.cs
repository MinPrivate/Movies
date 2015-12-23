using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace MovieSpider
{
    /// <summary>
    /// 代表对当前正在热映的电影页的爬虫分析类。
    /// </summary>
    public class PlayingMovieListPageSpider : MovieSpiderBase
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

        /* 公共方法 */

        /// <summary>
        /// 分析指定的 URI，进行爬虫递归。
        /// </summary>
        public override void DoWork()
        {
            if (this.TargetURI == null)
            {
                if (this.City == null || this.Province == null) // 参数错误
                {
                    throw new NullReferenceException("此 PlayingMovieListPageSpider 的 Provice 和 City 需要非 null 值。");
                }
                this.TargetURI = new Uri("http://theater.mtime.com/China_" + this.Province + "_Province_" + this.City + "/movie/"); // 默认 URI。
            }
            WebClient client = new WebClient();
            try
            {
                // 下载页面源代码
                this.FetchedDataSaver.WriteLog("PlayingMovieListPageSpider: 下载 " + this.TargetURI.ToString());
                string pageSource = Encoding.UTF8.GetString(client.DownloadData(this.TargetURI));

                // 根据正则表达式进行过滤
                this.FetchedDataSaver.WriteLog("PlayingMovieListPageSpider: 分析 " + this.TargetURI.ToString());
                Regex regex = new Regex ("(?<=" + this.TargetURI .ToString ()+")\\d+");
                List<string> movieIDs = new List<string>();
                foreach (Match m in regex.Matches(pageSource))
                {
                    movieIDs.Add(m.Value);
                }

                movieIDs = movieIDs.Distinct().ToList<string>(); // 去除重复元素
                foreach (string i in movieIDs)
                {
                    AsyncCreateSpider(i);
                    Thread t2 = new Thread(new ParameterizedThreadStart(AsyncCreateTSpider));
                    t2.Start(i);
                }
                
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

        private void AsyncCreateSpider(object i)
        {
            // 创建 MoviePageSpider 分析影片详情。
            MoviePageSpider spider = new MoviePageSpider();
            // 传递 Spider 参数信息。
            spider.Province = this.Province;
            spider.City = this.City;
            spider.MovieID = (string)i;
            spider.FetchedDataSaver = this.FetchedDataSaver;
            // 开始蜘蛛递归。
            spider.DoWork();
        }

        private void AsyncCreateTSpider(object i)
        {
            // 创建 TheaterListPageSpider 分析影片详情。
            TheaterListPageSpider tspider = new TheaterListPageSpider();
            // 传递 Spider 参数信息。
            tspider.Province = this.Province;
            tspider.City = this.City;
            tspider.MovieID = (string)i;
            tspider.FetchedDataSaver = this.FetchedDataSaver;
            // 开始蜘蛛递归。
            tspider.DoWork();
        }

        /// <summary>
        /// 分析指定的 URI，进行爬虫递归。
        /// </summary>
        public override void DoWorkAsync()
        {
            throw new NotImplementedException();
        }
    }
}
