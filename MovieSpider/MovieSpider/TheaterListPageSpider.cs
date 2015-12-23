using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace MovieSpider
{
    public class TheaterListPageSpider : MovieSpiderBase
    {
        /* 公共属性 继承 */

        /// <summary>
        /// 获取该蜘蛛是否支持递归地向下分析网页。
        /// </summary>
        public override bool Recursive
        {
            get
            {
                return false;
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
                    throw new NullReferenceException("此 TheaterListPageSpider 的 MovieID 需要非 null 值。");
                }
                this.TargetURI = new Uri(string.Format("http://theater.mtime.com/China_{0}_Province_{1}/movie/{2}/", this.Province, this.City, this.MovieID)); // 默认 URI。
            }
            WebClient client = new WebClient();
            try
            {
                // 下载页面源代码
                this.FetchedDataSaver.WriteLog("TheaterListPageSpider: 下载 " + this.TargetURI.ToString());
                string pageSource = Encoding.UTF8.GetString(client.DownloadData(this.TargetURI));

                // 根据正则表达式进行过滤
                this.FetchedDataSaver.WriteLog("TheaterListPageSpider: 分析 " + this.TargetURI.ToString());
                string movie_name = Regex.Match(pageSource, "(?<=<title>).+?(?= 武汉)").Value;

                List<string> link_theater = new List<string>();
                foreach (Match m in Regex.Matches(pageSource, "http://theater.mtime.com/China_Hubei_Province_Wuhan\\w+?/\\d+?/"))
                {
                    link_theater.Add(m.Value);
                }
                link_theater = link_theater.Distinct().ToList<string>();

                // 获取影院信息，并存储在数据库中
                foreach (string i in link_theater)
                {
                    AsyncCreateSpider(i);
                    /*Thread t = new Thread(new ParameterizedThreadStart(AsyncCreateSpider));
                    t.Start(i);*/
                }

                /* 获取场次信息 */
                this.FetchedDataSaver.WriteLog("TheaterListPageSpider: 获取场次 " + movie_name);
                MatchCollection theaters = Regex.Matches(pageSource, "(?<=,\"Name\":\").+?(?=\",\"District\":)");

                string[] splitedPlaytimeSources = pageSource.Split(new string[] { "<!--time list end -->" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < splitedPlaytimeSources.Length; ++i)
                {
                    if (Regex.Matches(splitedPlaytimeSources[i], "http://theater.mtime.com/China_Hubei_Province_Wuhan\\w+?/\\d+?/").Count == 0)
                        continue;
                    string theater_name = theaters[i].Value.Replace("&nbsp;", "").Trim();
                    MatchCollection times = Regex.Matches(splitedPlaytimeSources[i], "\\d{4}/\\d{2}/\\d{2} \\d{1,2}:\\d{1,2}");
                    MatchCollection prices = Regex.Matches(splitedPlaytimeSources[i], "(?<=<em>￥)\\d+(?=</em>)");
                    MatchCollection showtimeids = Regex.Matches(splitedPlaytimeSources[i], "(?<=showtimeId=\\\\\")\\d+?(?=\\\\)");

                    for (int j = 0; j < times.Count; ++j)
                    {
                        if (prices.Count > j)
                            this.FetchedDataSaver.SavePlaytimeInformation(movie_name, theater_name, DateTime.Parse(times[j].Value), int.Parse(prices[j].Value), "http://piao.mtime.com/onlineticket/showtime/" + showtimeids[j].Value + "/");
                        else
                            this.FetchedDataSaver.SavePlaytimeInformation(movie_name, theater_name, DateTime.Parse(times[j].Value), -1, "http://piao.mtime.com/onlineticket/showtime/" + showtimeids[j].Value + "/");
                    }
                }
            }
            catch (WebException)
            {
                this.FetchedDataSaver.WriteLog("因为下载页面失败，Spider 无法进行分析: " + this.TargetURI);
                // throw new WebException("因为下载页面失败，Spider 无法进行分析。", ex);
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

        private void AsyncCreateSpider(object i)
        {
            TheaterPageSpider spider = new TheaterPageSpider();
            spider.TargetURI = new Uri((string)i + "info.html");
            spider.FetchedDataSaver = this.FetchedDataSaver;
            spider.DoWork();
        }
    }
}
