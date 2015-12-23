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
    public partial class CinemaSubmitComment : System.Web.UI.Page
    {
        CinemaBLL cinemaBll = new CinemaBLL();
        string cinemaName = null;
        int userID = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            cinemaName = (string )Session["CinemaName"];
            userID = (int)Session["UserID"];
            if (!IsPostBack)
            {
                LabelCinemaName.Text = cinemaName;
                //根据电影院名得到电影院对象，从而获取电影院详细信息
                CINEMA cinema = cinemaBll.GetCinema(cinemaName);
                LabelRank.Text = cinema.rank.ToString() + "分";
                LabelRankNum.Text = "已有" + cinema.rank_number.ToString() + "人打分";
                //绑定电影院图片到控件
                string cinemaPicture = string.Empty;
                cinemaPicture = cinemaBll.GetCinemaPicture(cinemaName);
                ImageCinemaDetail.ImageUrl = cinemaPicture;
                LabelCinemaDetails.Text = cinema.introduction;

               

            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {

            //获取电影d
            int cinemaId = new Cinema().GetCinemaId(cinemaName);

            if (cinemaId != -1)
            {
                string commentContext = CommentTextBox.Text.ToString();
                //获取评论内容
                DateTime commentTime = DateTime.Now.ToUniversalTime();
                //获取评论时间

                //生成评论对象
                CINAME_COMMENT cinemaComment = new CINAME_COMMENT();
                cinemaComment.body = commentContext;
                cinemaComment.time = commentTime;
                cinemaComment.user_id = userID;
                cinemaComment.cinema_id = cinemaId;
                cinemaComment.support = 0;
                cinemaComment.oppose = 0;


                //添加评论
                if (!new Comment().InsertCinemaComment(cinemaComment))
                {
                    //Response.Write("评论失败，请重新评论");
                    //ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('抱歉，评论失败，请重新评论!')</script>");
                    Response.Write("<div class='msgboxbg'>" + "<div class='mainmsgbox'>" + "<br/><br/><br/><br/><div class='msgcon'>抱歉，评论失败，请重新评论!</div>" + " <a href='CinemaDetails.aspx'> <div class='tip'>返回</div></a>" + " </div></div></div>");

                }
                else
                {
                    //跳转到显示评论信息页面，显示最新评论
                    //Response.Write("<script Language=JavaScript>alert('评论成功！')</script>");
                    //Response.Redirect("~/CinemaDetails.aspx");
                    Response.Write("<div class='msgboxbg'>" + "<div class='mainmsgbox'>" + "<br/><br/><br/><br/><div class='msgcon'>评论成功！</div>" + " <a href='CinemaDetails.aspx'> <div class='tip'>返回</div></a>" + " </div></div></div>");

                }

            }
            else
            {
                //Response.Write("电影院不存在");
                //ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('抱歉，评论失败，请稍后再试！')</script>");
                Response.Write("<div class='msgboxbg'>" + "<div class='mainmsgbox'>" + "<br/><br/><br/><br/><div class='msgcon'>抱歉，评论失败，请重新评论!</div>" + " <a href='CinemaDetails.aspx'> <div class='tip'>返回</div></a>" + " </div></div></div>");
            }
        }

        private bool RankMovie(string newCinemaName, int newRank)
        {
            return cinemaBll.RankCinema(newCinemaName, newRank);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (RankMovie(cinemaName, 1))
            {
                Response.Write("<script Language=JavaScript>alert('评分成功，您给出的评分是1分！');window.navigate('../CinemaDetails.aspx');</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('评分失败，请重试!')</script>");
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (RankMovie(cinemaName, 2))
            {
                Response.Write("<script Language=JavaScript>alert('评分成功，您给出的评分是2分！');window.navigate('../CinemaDetails.aspx');</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('评分失败，请重试!')</script>");
            }
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            if (RankMovie(cinemaName, 3))
            {
                Response.Write("<script Language=JavaScript>alert('评分成功，您给出的评分是3分！');window.navigate('../CinemaDetails.aspx');</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('评分失败，请重试!')</script>");
            }
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            if (RankMovie(cinemaName, 4))
            {
                Response.Write("<script Language=JavaScript>alert('评分成功，您给出的评分是4分！');window.navigate('../CinemaDetails.aspx');</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('评分失败，请重试!')</script>");
            }
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            if (RankMovie(cinemaName, 5))
            {
                Response.Write("<script Language=JavaScript>alert('评分成功，您给出的评分是5分！');window.navigate('../CinemaDetails.aspx');</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('评分失败，请重试!')</script>");
            }
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            if (RankMovie(cinemaName, 6))
            {
                Response.Write("<script Language=JavaScript>alert('评分成功，您给出的评分是6分！');window.navigate('../CinemaDetails.aspx');</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('评分失败，请重试!')</script>");
            }
        }

        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
        {
            if (RankMovie(cinemaName, 7))
            {
                Response.Write("<script Language=JavaScript>alert('评分成功，您给出的评分是7分！');window.navigate('../CinemaDetails.aspx');</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('评分失败，请重试!')</script>");
            }
        }

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
        {
            if (RankMovie(cinemaName, 8))
            {
                Response.Write("<script Language=JavaScript>alert('评分成功，您给出的评分是8分！');window.navigate('../CinemaDetails.aspx');</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('评分失败，请重试!')</script>");
            }
        }

        protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
        {
            if (RankMovie(cinemaName, 9))
            {
                Response.Write("<script Language=JavaScript>alert('评分成功，您给出的评分是9分！');window.navigate('../CinemaDetails.aspx');</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('评分失败，请重试!')</script>");
            }
        }

        protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
        {
            if (RankMovie(cinemaName, 10))
            {
                Response.Write("<script Language=JavaScript>alert('评分成功，您给出的评分是10分！');window.navigate('../CinemaDetails.aspx');</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('评分失败，请重试!')</script>");
            }
        }

     
    }
}