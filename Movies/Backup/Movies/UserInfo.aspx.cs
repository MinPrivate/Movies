using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using DataAccessLayer;
using System.Windows.Forms;

namespace Movies
{
    public partial class UserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserEmail"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }
        }


        //protected void CollectButton_Click(object sender, EventArgs e)
        //{
        //    //判断是否登录
        //    if (Request.Cookies["UserEmail"] == null)
        //    {

        //        Response.Write("<div class='msgboxbg'>" + "<div class='mainmsgbox'>" + "<div class='msgcon'>您还没有登录，请先登录!</div>" + " <a href='LogIn.aspx'> <div class='tip'>返回</div></a>" + " </div></div></div>");
        //    }
        //    else
        //    {
        //        //获取登录状态 email标志
        //        string GetEmail = Request.Cookies["UserEmail"].Value;
        //        UersBLL newUserBll = new UersBLL();
        //        //获取ID值
        //        int userID = newUserBll.GetUserId(GetEmail);

        //        //MessageBox.Show(userID.ToString());
        //        if (userID >= 0)
        //        {
        //            List<DataAccessLayer.MOVIE> movies = new List<DataAccessLayer.MOVIE>();
        //            movies = newUserBll.GetcollectionByUserId(userID);
        //            foreach (MOVIE movie in movies)
        //            {
        //                Response.Write(movie.actor);
        //                MessageBox.Show(movie.actor);
        //                //打印出一条信息
        //                ////////////////////////////////
        //                //////////////////////////////////
        //                /////////////////////////////////
        //            }
        //            //MessageBox.Show(movies.Count().ToString());
        //        }
        //        else
        //        {
        //            Response.Write("<div class='msgboxbg'>" + "<div class='mainmsgbox'>" + "<div class='msgcon'>用户不存在!</div>" + " <a href='LogIn.aspx'> <div class='tip'>重新填写</div></a>" + " </div></div></div>");
        //        }

        //    }
        //}

        protected void PasswordAdmButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModifyPassword.aspx");
        }

        protected void ChangeUserButton_Click(object sender, EventArgs e)
        {

            //首先销毁cookie中的值再 转到登录界面
            Response.Cookies["UserEmail"].Expires = DateTime.Now;
            Response.Cookies["UserPassword"].Expires = DateTime.Now;
            Response.Cookies["UserId"].Expires = DateTime.Now;
            Response.Redirect("~/Main.aspx");
        }
        protected void PreferenceAdmButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PreferenceSelect.aspx");
        }

    }
}