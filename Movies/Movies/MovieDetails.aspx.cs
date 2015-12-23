using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;
using DataAccessLayer;
//using System.Windows.Forms;


namespace Movies
{
    public partial class MovieDetails : System.Web.UI.Page
    {
        MoviesBLL movieBll = new MoviesBLL();

        //根据前面页面传来的参数得到电影名字
        string movieName = "暂无影片信息";

        int userID = 1;//用户ID整个会话都要保存，默认没有登录，即为-1
        //public  bool isLatest;//是否显示最新评论   


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.Form["movieName"] != null)
                {
                    string message = Request.Form["movieName"];

                    //Response.Write(message);
                   
                    Session["MovieNameToMovieDetails"] = message;
                }

            }


            movieName = Convert.ToString(Session["MovieNameToMovieDetails"]);
                


            
            Session["MovieOnShow"] = movieName;
            //*******************************************************************************
            //注意，一定要将这两个量写在if判断的外面，否则每次点击按钮后变16-17行设置的默认值
            //movieName=Session["MovieName"];
            //userID=Session["UserID"];
            //*******************************************************************************
            if (!IsPostBack)
            {
                //HyperLinkBack.NavigateUrl = "~/Main.aspx";
                //得到前页面的电影名
                //movieName = Convert.ToString(Session["MovieNameToDetail"]);
                //将电影名绑定到控件
                LabelMovieName.Text = movieName;

                //根据电影名得到电影对象，从而获取电影详细信息

                MOVIE movie = movieBll.GetMovie(movieName);
                LabelRank.Text = movie.rank.ToString() + "分";
                LabelRankNum.Text = "已有" + movie.rank_number.ToString() + "人打分";
                //跳转到buy_list
                //HyperLinkBuy.NavigateUrl = "~/";
                //根据电影名得到电影海报的路径
                // ImageMapMovie.ImageUrl = movieBll.GetPicture(movieName);
                string moviePicture = string.Empty;
                moviePicture = movieBll.GetMoviePicture(movieName);
                //绑定电影图片到控件
                ImageMovieDetail.ImageUrl = moviePicture;              

                //根据电影名 得到电影的详细信息
                LabelMovieDetails.Text = movie.introduction;

                //根据电影院名得到电影院最新评论列表,默认显示最新列表
                //isLatest = true;
                List<Comment> comment = movieBll.GetLatestComments(movieName);
                //CommentGridView.DataSource = comment;
                //CommentGridView.DataBind();
                DisplayMovieComment(comment);
                //设置返回前页链接

            }
        }

        protected void ButtonLatestComment_Click(object sender, EventArgs e)
        {
            //得到最新评论
            
            List<Comment> comment = movieBll.GetLatestComments(movieName);

            //显示最新评论到页面
            DisplayMovieComment(comment);
        }

        protected void ButtonHotComment_Click(object sender, EventArgs e)
        {
            //得到最热评论
            
            List<Comment> comment = movieBll.GetHotComments(movieName);

            //显示最热评论到页面
            DisplayMovieComment(comment);
        }

        protected void ButtonMyComment_Click(object sender, EventArgs e)
        {
            //我的评论
            //跳转到电影评论页面
            
            //MOVIE_COMMENT comment = new MOVIE_COMMENT();
            
            //comment.user_id = userID;
            //comment.body = LabelComment1.Text;
            ////还要传过去电影名字，根据电影名字获得对应movie_id
            //comment.time = DateTime.Now;
            //comment.support = 0;
            //comment.oppose = 0;
            Session["UserID"] = userID;
            Session["MovieNameToMovieComment"] = movieName;
            Response.Redirect("~/MovieSubmitComment.aspx");

        }

        //protected void ButtonShare_Click(object sender, EventArgs e)
        //{
            
        //}

        //显示电影评论  此类中着重要写的函数 
        protected void DisplayMovieComment(List<Comment> newComment)
        {
            CommentRepeater.DataSource = newComment;
            CommentRepeater.DataBind();
            
            //CommentGridView.DataSource = newComment;
            //CommentGridView.DataBind();
            
        }

        protected void ImageButtonGood_Click(object sender, EventArgs e)
        {
           
            ImageButton button = (ImageButton)sender;
            RepeaterItem recomment = (RepeaterItem)button.Parent;
            string time = ((Label)recomment.FindControl("LabelCommentTime")).Text;
            DateTime t = Convert.ToDateTime(time);
            movieBll.IncreaseCommentSupport(movieName, t);
            ((Label)recomment.FindControl("LabelSupport")).Text = (Convert.ToInt32(((Label)recomment.FindControl("LabelSupport")).Text) + 1).ToString();
            //List<Comment> comment = new List<Comment>();
            //if (isLatest)
            //    comment = movieBll.GetLatestComments(movieName);
            //else
            //    comment = movieBll.GetHotComments(movieName);
            //DisplayMovieComment(comment);
        }

        protected void ImageButtonBad_Click(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            RepeaterItem recomment = (RepeaterItem)button.Parent;
            string time = ((Label)recomment.FindControl("LabelCommentTime")).Text;
            DateTime t = Convert.ToDateTime(time);
            movieBll.IncreaseCommentOppose(movieName, Convert.ToDateTime(time));
            ((Label)recomment.FindControl("LabelOppose")).Text = (Convert.ToInt32(((Label)recomment.FindControl("LabelOppose")).Text) + 1).ToString();
            //List<Comment> comment = new List<Comment>();
            //if (isLatest)
            //    comment = movieBll.GetLatestComments(movieName);
            //else
            //    comment = movieBll.GetHotComments(movieName);
            //DisplayMovieComment(comment);
        }

        //protected void SubmitButton_Click(object sender, EventArgs e)
        //{
        //    string movieName = LabelMovieName.ToString();//获取电影名

        //    int movieId = new Movie().GetMovieId(movieName);
        //    //获取电影d

        //    if (movieId != -1)
        //    {
        //        int userId = -1;
        //        if (Request.Cookies["UserEmail"] != null)
        //        {
        //            userId = Convert.ToInt32(Request.Cookies["UserId"].Value);
        //            //获取登录者的用户ID
        //        }
        //        //?????????????????????????????
        //        //是否提示未登录用户先登录在执行评论


        //        //string commentContext = MovieCommentTextBox.Text.ToString();
        //        //获取评论内容
        //        DateTime commentTime = DateTime.Now.ToUniversalTime();
        //        //获取评论时间

        //        //生成评论对象
        //        MOVIE_COMMENT movieComment = new MOVIE_COMMENT();
        //        //movieComment.body = commentContext;
        //        movieComment.time = commentTime;
        //        movieComment.user_id = userId;
        //        movieComment.time = commentTime;
        //        movieComment.support = 0;
        //        movieComment.oppose = 0;


        //        //添加评论
        //        if (!new Comment().InsertMovieComment(movieComment))
        //        {
        //            Response.Write("评论失败，请重新评论");
        //        }
        //        //??????????????????????????????????????
        //        //??????????????????????????????????????
        //        //调用显示最新评论的函数及时显示当前评论信息

        //    }
        //    else
        //    {
        //        Response.Write("电影院不存在");
        //    }
        //}

        protected void CommentRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "GetData")
            {
                //e.Item.ItemIndex
                Label lb = e.Item.FindControl("LabelCommentTime") as Label;
                //Response.Write(lb.Text);

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
                UersBLL userBll = new UersBLL();
                if (userBll.SaveCollection(userID, movieName))
                    //Response.Write("<script Language=JavaScript>alert('收藏成功，谢谢！')</script>");
                    ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('收藏成功，谢谢！')</script>");
                else
                    ClientScript.RegisterClientScriptBlock(GetType(), "", "<script Language=JavaScript>alert('收藏失败，您已经收藏过此部影片')</script>");
                    //Response.Write("<script Language=JavaScript>alert('您已经收藏过此部影片!')</script>");

                        
            }
        }

        

        //protected void CommentRepeater_ItemCreated(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        //    {
        //        ImageButton ImageButtonGood = e.Item.FindControl("ImageButtonGood") as ImageButton; //Label标签的标签名
        //        ImageButtonGood.OnClientClick += new EventHandler(ImageButtonGood_Click); //关联单击事件
        //        ImageButton ImageButtonBad = e.Item.FindControl("ImageButtonBad") as ImageButton; //Label标签的标签名
        //        ImageButtonBad.OnClientClick += new EventHandler(ImageButtonBad_Click); //关联单击事件

        //    }
        //}

    }
}