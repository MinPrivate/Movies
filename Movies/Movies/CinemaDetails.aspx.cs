using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;
using DataAccessLayer;


namespace Movies
{
    public partial class CinemaDetails : System.Web.UI.Page
    {
        CinemaBLL cinemaBll = new CinemaBLL();
        //根据前面页面传来的参数得到电影院名字
        string cinemaName = "暂无影院信息";
        ////根据前面页面传来的参数得到电影院地址，根据电影院的这两个参数确定一个电影院
        //string cinemaAddr = "武汉市江汉区交通路1号万达商业广场C座二层";
        int userID = 1;//用户ID整个会话都要保存，默认没有登录，即为-1
       
        protected void Page_Load(object sender, EventArgs e)
        {
            cinemaName = Convert.ToString(Session["CinemaNameToCinemaDetails"]);
            Session["CinemaNameToMovieList"] = cinemaName;
           
            //*******************************************************************************
            //注意，一定要将这两个量写在if判断的外面，否则每次点击按钮后变16-17行设置的默认值
            //cinemaName=Session["CinemaName"];
            //userID=Session["UserID"];
            //*******************************************************************************
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

                //根据电影院名得到电影院最新评论列表,默认显示最新列表                
                List<Comment> comment = cinemaBll.GetLatestComment(cinemaName);
                DisplayCinemaComment(comment);
  
            }
        }

        protected void DisplayCinemaComment(List<Comment> newComment)
        {
            CommentRepeater.DataSource = newComment;
            CommentRepeater.DataBind();

        }

        protected void ButtonLatestComment_Click(object sender, EventArgs e)
        {
            //得到最新评论
            List<Comment> comment = cinemaBll.GetLatestComment(cinemaName);

            //显示最新评论到页面
            DisplayCinemaComment(comment);
        }

        protected void ButtonHotComment_Click(object sender, EventArgs e)
        {
            //得到最新评论
            List<Comment> comment = cinemaBll.GetHotComment(cinemaName);

            //显示最新评论到页面
            DisplayCinemaComment(comment);
        }

        protected void ButtonMyComment_Click(object sender, EventArgs e)
        {
            //我的评论，调转到影院评论页面
            Session["UserID"] = userID;
            Session["CinemaName"] = cinemaName;
            Response.Redirect("~/CinemaSubmitComment.aspx");
        }




        protected void ImageButtonGood_Click(object sender, EventArgs e)
        {

            ImageButton button = (ImageButton)sender;
            RepeaterItem recomment = (RepeaterItem)button.Parent;
            string time = ((Label)recomment.FindControl("LabelCommentTime")).Text;
            DateTime t = Convert.ToDateTime(time);
            cinemaBll.IncreaseCommentSupport(cinemaName, t);
            ((Label)recomment.FindControl("LabelSupport")).Text = (Convert.ToInt32(((Label)recomment.FindControl("LabelSupport")).Text) + 1).ToString();
        }

        protected void ImageButtonBad_Click(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            RepeaterItem recomment = (RepeaterItem)button.Parent;
            string time = ((Label)recomment.FindControl("LabelCommentTime")).Text;
            DateTime t = Convert.ToDateTime(time);
            cinemaBll.IncreaseCommentOppose(cinemaName, t);
            ((Label)recomment.FindControl("LabelOppose")).Text = (Convert.ToInt32(((Label)recomment.FindControl("LabelOppose")).Text) + 1).ToString();
           
        }

        protected void CommentRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "GetData")
            {                
                Label lb = e.Item.FindControl("LabelCommentTime") as Label;
                
            }
        }
    }
}