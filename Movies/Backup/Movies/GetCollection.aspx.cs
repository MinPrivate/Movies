using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using BusinessLogicLayer;

namespace Movies
{
    public partial class GetCollection : System.Web.UI.Page
    {
        //创建电影业务对象
        MoviesBLL _movieBll = new MoviesBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

            //判断是否登录
            if (Request.Cookies["UserEmail"] == null)
            {

                Response.Write("<div class='msgboxbg'>" + "<div class='mainmsgbox'>" + "<div class='msgcon'>您还没有登录，请先登录!</div>" + " <a href='LogIn.aspx'> <div class='tip'>返回</div></a>" + " </div></div></div>");
            }
            else
            {
                //获取登录状态 email标志
                string GetEmail = Request.Cookies["UserEmail"].Value;
                UersBLL newUserBll = new UersBLL();
                //获取ID值
                int userID = newUserBll.GetUserId(GetEmail);

                //MessageBox.Show(userID.ToString());
                if (userID >= 0)
                {
                    List<MOVIE> movies = new List<MOVIE>();
                    movies = newUserBll.GetcollectionByUserId(userID);


                    int pageNum = movies.Count() / 9;
                    int pageAdd = ((movies.Count()) % 9 != 0) ? 1 : 0;
                    pageNum += pageAdd;



                    string pageHtml = "<div class='slides_container'>";
                    //foreach (MOVIE movie in movies)
                    //{
                        //  Response.Write(movie.actor);
                        //根据数据计算具体的页数
                        //int pageNum = 45;
                    int index = 0;
                    MOVIE movie = new MOVIE();
                        for (int j = 0; j < pageNum; j++)
                        {
                            int pageMax = 9;
                            //if (j <= pageNum )
                            //{
                            //    pageMax = 9;
                            //}
                            //else
                            //{
                            //     pageMax = movies.Count() % 9;
                            //}
                            string singlePageHtml = "";
                            
                            
                            for (int i = 0; i < pageMax; i++)
                            {
                                if (index < movies.Count())
                                {
                                    movie = movies.ElementAt(index);
                                    index++;
                                }
                                else
                                    break;
                                string moviePicture = _movieBll.GetMoviePicture(movie.name);
                               
                                singlePageHtml += FormHtml(moviePicture,
                                                            movie.name, Convert.ToInt32(movie.rank_number),
                                                            movie.director, movie.actor);
                            }
                            pageHtml += FormPageFrame(singlePageHtml);

                        }

                        pageHtml += "</div>"
                            + FormPagePoint(pageNum) + "";
                        // Response.Write(pageHtml);
                        //MessageBox.Show(pageHtml);
                        Response.Write(pageHtml);

                        //  writeToHtml(pageHtml);
                    //}
                    //MessageBox.Show(movies.Count().ToString());
                }
                else
                {
                    Response.Write("<div class='msgboxbg'>" + "<div class='mainmsgbox'>" + "<div class='msgcon'>用户不存在!</div>" + " <a href='LogIn.aspx'> <div class='tip'>重新填写</div></a>" + " </div></div></div>");
                }

            }

        }

        public string FormHtml(string newImageAddr, string newMovieName, int newRankGrade, string newDirector, string newMainActor)
        {
            //动态生成一个单个电影信息展示模块
            string newhtml = "<div class='piece'>"
                           + "<div class='piece_picture'>"
                           + "<img src='" + newImageAddr + "'class='smallimg" + "'> </div>"
                           + "<div class='piece_word'>"
                           + "<div class='inFo'>"
                           + "<center>"
                           + "<table> <tr><td>" + newMovieName + "</td></tr><tr><td>评分：" + newRankGrade + "</td></tr>    <tr><td>导演：" + newDirector + "</td></tr>  <tr><td>主演：" + newMainActor + "</td></tr></table>"
                           + "</center>"
                           + "</div></div></div>";

            return newhtml;
        }

        public string FormPagePoint(int pageNum)
        {//动态生成页面导航点
            string pagePointHtml="";
            if (pageNum != 0)
            {

                pagePointHtml = "<ul class='pagination'>";
                pagePointHtml += "<li><a href='#'><img src='image/current.png' width='20' ></a></li>";
                for (int i = 0; i < pageNum - 1; i++)
                {
                    pagePointHtml += "<li><a href='#'><img src='image/normal.png' width='20' ></a></li>";
                }
                //<li><a href="#"><img src="image/current.png" width="20" ></a></li>
                pagePointHtml += "</ul>";
            }
        
            return pagePointHtml;
        }

        public string FormPageFrame(string singleMovieHtml)
        {
            //生成多个展示页面
            string pageFrame = "";
            pageFrame += "<div class='boxbody'>";
            pageFrame += singleMovieHtml + "</div>";


            return pageFrame;
        }

        //public bool writeToHtml(string message)
        //{//写入静态页面
        //    FileStream fs = new FileStream("C:/Users/wangxiaoyi/Desktop/Movies_v1.9errror/WebPage/test.htm", FileMode.Open);

        //    StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("UTF-8"));
        //    sw.Write(message);
        //    sw.Flush();
        //    sw.Close();
        //    fs.Close();
        //    return false;
        //}
    }
}