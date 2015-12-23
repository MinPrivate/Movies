using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using DataAccessLayer;

namespace Movies
{
    public partial class MovieSubmitComment : System.Web.UI.Page
    {
        MoviesBLL movieBll = new MoviesBLL();
        string movieName = null;
        int userID = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            movieName = (string)Session["MovieNameToMovieComment"];
            userID = (int)Session["UserID"];
            if (!IsPostBack)
            {
                
                LabelMovieName.Text = movieName;
                MOVIE movie = movieBll.GetMovie(movieName);
                LabelRank.Text = movie.rank.ToString() + "分";
                LabelRankNum.Text = "已有" + movie.rank_number.ToString() + "人打分";
                string moviePicture = string.Empty;
                moviePicture = movieBll.GetMoviePicture(movieName);
                //绑定电影图片到控件
                ImageMovieDetail.ImageUrl = moviePicture;
                LabelMovieDetails.Text = movie.introduction;
            }
        }

        protected void CollectButton_Click(object sender, EventArgs e)
        {
            if (userID == -1)
            {
                Response.Write("<script Language=JavaScript>alert('登陆用户才能使用收藏功能，请您登陆！');window.navigate('../LogIn.aspx');</script>");
            }
            else
            {
                if (new UersBLL().SaveCollection(userID, movieName))
                    
                    ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('收藏成功，谢谢！')</script>");
                else
                    ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('收藏失败，您已经收藏过此部影片')</script>");
                
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {

            //获取电影d
            int movieId = new Movie().GetMovieId(movieName);
            
            if (movieId != -1)
            {
                //userID在整个会话过程都报存在session中
                //int userId = -1;
                //if (Request.Cookies["UserEmail"] != null)
                //{
                //    userId = Convert.ToInt32(Request.Cookies["UserId"].Value);
                //    //获取登录者的用户ID
                //}
                //?????????????????????????????
                //是否提示未登录用户先登录在执行评论


                string commentContext = CommentTextBox.Text.ToString();
                //获取评论内容

                //评论内容为空 则提示用户
                
                DateTime commentTime = DateTime.Now.ToUniversalTime();
                //获取评论时间

                //生成评论对象
                MOVIE_COMMENT movieComment = new MOVIE_COMMENT();
                movieComment.body = commentContext;
                movieComment.time = commentTime;
                movieComment.user_id = userID;
                movieComment.movie_id = movieId;
                movieComment.support = 0;
                movieComment.oppose = 0;


                //添加评论
                if (!new Comment().InsertMovieComment(movieComment))
                {
                    //Response.Write("评论失败，请重新评论");
                   // ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('抱歉，评论失败，请重新评论!')</script>");
                    Response.Write("<div class='msgboxbg'>" + "<div class='mainmsgbox'>" + "<br/><br/><br/><br/><div class='msgcon'>抱歉，评论失败，请重新评论!</div>" + " <a href='MovieDetails.aspx'> <div class='tip'>返回</div></a>" + " </div></div></div>");

                }
                else
                {
                    //跳转到显示评论信息页面，显示最新评论
                    //Response.Write("<script Language=JavaScript>alert('评论成功！')</script>");
                    //Response.Redirect("~/MovieDetails.aspx");
                    Response.Write("<div class='msgboxbg'>" + "<div class='mainmsgbox'>" + "<br/><br/><br/><br/><div class='msgcon'>评论成功！</div>" + " <a href='MovieDetails.aspx'> <div class='tip'>返回</div></a>" + " </div></div></div>");
                }

            }
            else
            {
                //Response.Write("电影院不存在");
                //ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('抱歉，评论失败，请稍后再试！')</script>");
                Response.Write("<div class='msgboxbg'>" + "<div class='mainmsgbox'>" + "<br/><br/><br/><br/><div class='msgcon'>抱歉，评论失败，请重新评论!</div>" + " <a href='MovieDetails.aspx'> <div class='tip'>返回</div></a>" + " </div></div></div>");
            }
        }
        private bool RankMovie(string newMovieName, int newRank)
        {
            return movieBll.RankMovie(newMovieName, newRank);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (RankMovie(movieName, 1))
            {
                Response.Write("<script Language=JavaScript>alert('评分成功，您给出的评分是1分！');window.navigate('../MovieDetails.aspx');</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('评分失败，请重试!')</script>");
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (RankMovie(movieName, 2))
            {
                Response.Write("<script Language=JavaScript>alert('评分成功，您给出的评分是2分！');window.navigate('../MovieDetails.aspx');</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('评分失败，请重试!')</script>");
            }
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            if (RankMovie(movieName, 3))
            {
                Response.Write("<script Language=JavaScript>alert('评分成功，您给出的评分是3分！');window.navigate('../MovieDetails.aspx');</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('评分失败，请重试!')</script>");
            }
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            if (RankMovie(movieName, 4))
            {
                Response.Write("<script Language=JavaScript>alert('评分成功，您给出的评分是4分！');window.navigate('../MovieDetails.aspx');</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('评分失败，请重试!')</script>");
            }
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            if (RankMovie(movieName, 5))
            {
                Response.Write("<script Language=JavaScript>alert('评分成功，您给出的评分是5分！');window.navigate('../MovieDetails.aspx');</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('评分失败，请重试!')</script>");
            }
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            if (RankMovie(movieName, 6))
            {
                Response.Write("<script Language=JavaScript>alert('评分成功，您给出的评分是6分！');window.navigate('../MovieDetails.aspx');</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('评分失败，请重试!')</script>");
            }
        }

        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
        {
            if (RankMovie(movieName, 7))
            {
                Response.Write("<script Language=JavaScript>alert('评分成功，您给出的评分是7分！');window.navigate('../MovieDetails.aspx');</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('评分失败，请重试!')</script>");
            }
        }

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
        {
            if (RankMovie(movieName, 8))
            {
                Response.Write("<script Language=JavaScript>alert('评分成功，您给出的评分是8分！');window.navigate('../MovieDetails.aspx');</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('评分失败，请重试!')</script>");
            }
        }

        protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
        {
            if (RankMovie(movieName, 9))
            {
                Response.Write("<script Language=JavaScript>alert('评分成功，您给出的评分是9分！');window.navigate('../MovieDetails.aspx');</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('评分失败，请重试!')</script>");
            }
        }

        protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
        {
            if (RankMovie(movieName, 10))
            {
                Response.Write("<script Language=JavaScript>alert('评分成功，您给出的评分是10分！');window.navigate('../MovieDetails.aspx');</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('评分失败，请重试!')</script>");
            }
        }
    }
}