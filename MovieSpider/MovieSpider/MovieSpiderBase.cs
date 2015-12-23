using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieSpider
{
    /// <summary>
    /// 为电影蜘蛛程序提供共同基类。
    /// </summary>
    public abstract class MovieSpiderBase
    {
        /* 公共属性 */

        /// <summary>
        /// 指定或获取该蜘蛛程序的目标 URI。
        /// </summary>
        public Uri TargetURI { get; set; }

        /// <summary>
        /// 获取该蜘蛛是否支持递归地向下分析网页。
        /// </summary>
        public abstract bool Recursive { get; }

        /// <summary>
        /// 指定或获取该蜘蛛获取数据之后负责保存数据的类实例。
        /// </summary>
        public DataSaver FetchedDataSaver { get; set; }

        /* 公共方法 */

        /// <summary>
        /// 执行该蜘蛛的爬行任务。
        /// </summary>
        public abstract void DoWork();
        /// <summary>
        /// 开始执行该蜘蛛的爬行任务。
        /// </summary>
        public abstract void DoWorkAsync();
    }
}
