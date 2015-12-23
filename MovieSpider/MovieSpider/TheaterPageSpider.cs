using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace MovieSpider
{
    public class TheaterPageSpider : MovieSpiderBase
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

        /* 公共方法 */

        /// <summary>
        /// 分析指定的 URI，进行爬虫递归。
        /// </summary>
        public override void DoWork()
        {
            if (this.TargetURI == null)
            {
                if (this.TargetURI == null) // 参数错误
                {
                    throw new NullReferenceException("此 TheaterListPageSpider 的 TargetURI 需要非 null 值。");
                }
            }
            WebClient client = new WebClient();
            try
            {
                // 下载页面源代码
                this.FetchedDataSaver.WriteLog("下载 " + this.TargetURI.ToString());
                string pageSource = Encoding.UTF8.GetString(client.DownloadData(this.TargetURI));

                // 根据正则表达式进行过滤
                this.FetchedDataSaver.WriteLog("分析 " + this.TargetURI.ToString());
                string theater_name = Regex.Match(pageSource, "(?<=<h2.+?>).+?(?=</h2>)").Value.Trim();
                this.FetchedDataSaver.WriteLog("获取影院信息  " + theater_name);
                string theater_addr = Regex.Match(pageSource, "(?<=<dd.+?>地址：).+?(?=</dd>)").Value.Trim();
                string theater_phone = Regex.Match(pageSource, "(?<=<dd.+?>电话：).+?(?=</dd>)").Value.Trim();
                string theater_timeStart = Regex.Match(pageSource, "(?<=<dd.+?>营业时间：).+?(?=(-|－|<))").Value.Trim();
                string theater_timeEnd = Regex.Match(pageSource, "(?<=<dd.+?>营业时间：\\d{1,2}(:|：)\\d{1,2}(-|－)).+?(?=</dd>)").Value.Trim();
                string theater_summary = Regex.Match(pageSource, "(?<=<div class=\"c_666\">)(.|\\s)*?(?=</div>)").Value.Replace("<br>", Environment.NewLine).Replace("<br />", Environment.NewLine).Replace("&nbsp;", "").Trim();
                string theater_pic_url = Regex.Match(pageSource, "(?<=<img src=\").+?(?=\" alt=)").Value.Trim();
                this.FetchedDataSaver.WriteLog("下载 " + theater_pic_url);
                byte[] theater_pic = client.DownloadData(theater_pic_url);

                theater_summary = Regex.Replace(theater_summary, "<.+?>", "").Trim();

                this.FetchedDataSaver.SaveTheaterInformation(theater_name, theater_addr, theater_phone, theater_timeStart, theater_timeEnd, theater_summary, theater_pic);

            }
            catch (WebException ex)
            {
                this.FetchedDataSaver.WriteLog("因为下载页面失败，Spider 无法进行分析。");
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
