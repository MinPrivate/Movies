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
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Response.Cookies["UserPassword"].Expires = DateTime.Now;
            //Response.Cookies["UserEmail"].Expires = DateTime.Now;


            if (!IsPostBack)//判断是否已经登录
            {
                if (Request.Cookies["UserEmail"] == null)
                {
                    EmailTextBox.Text = "";
                    PasswordTextBox.Text = "";
                }
                else if ((new UersBLL()).CheckPassword(Request.Cookies["UserEmail"].Value, Request.Cookies["UserPassword"].Value))
                {

                    Response.Redirect("~/UserInfo.aspx");
                    //跳转到个人信息中心页面
                }
                else
                {

                    //Response.Write("<div class='msgboxbg'>" + "<div class='mainmsgbox'>" + "<div class='msgcon'>请重新登录</div>" + " <a href='LogIn.aspx'> <div class='tip'>确定</div></a>" + " </div></div></div>");
                    //Response.Redirect("~/LogIn.aspx");
                }
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

            if (EmailTextBox.Text != string.Empty && PasswordTextBox.Text != string.Empty)
            {
                UersBLL newUserBll = new UersBLL();
                bool IsLegal = newUserBll.CheckPassword(EmailTextBox.Text, PasswordTextBox.Text);
                if (IsLegal)
                {
                    //合法用户则允许登录
                    Session["UserEmail"] = EmailTextBox.Text.Trim();
                    if (Request.Cookies["UserEmail"] == null)
                    {
                        Response.Cookies["UserEmail"].Expires = DateTime.Now.AddDays(7);
                        Response.Cookies["UserPassword"].Expires = DateTime.Now.AddDays(7);
                        Response.Cookies["UserId"].Expires = DateTime.Now.AddDays(7);
                        Response.Cookies["UserId"].Value = Convert.ToString(new UersBLL().GetUserId(EmailTextBox.Text.ToString()));
                        Response.Cookies["UserEmail"].Value = EmailTextBox.Text.Trim();
                        Response.Cookies["UserPassword"].Value = PasswordTextBox.Text.Trim();
                    }
                    Response.Redirect("~/UserInfo.aspx");
                }
                else
                {
                    //不合法则不允许登录 并提示相关消息
                    Response.Write("<div class='msgboxbg'>" + "<div class='mainmsgbox'>" + "<div class='msgcon'>用户不存在，请检查密码和邮箱是否正确!</div>" + " <a href='LogIn.aspx'> <div class='tip'>确定</div></a>" + " </div></div></div>");

                }
            }
            else
            {
                Response.Write("<b>信息填写不完整</b>");
            }
        }
        protected void SignButton_Click(object sender, EventArgs e)
        {
            if ((EmailTextBox1.Text != string.Empty) && (PasswordTextBox1.Text != string.Empty) && (NameTextBox1.Text != string.Empty))
            {
                UersBLL newUserBll = new UersBLL();
                bool IsCreatedSuccess = newUserBll.CreateUser(NameTextBox1.Text, EmailTextBox1.Text, PasswordTextBox1.Text);
                if (IsCreatedSuccess)
                {
                    //创建成功
                    Session["UserEmail"] = EmailTextBox.Text.Trim();
                    if (Request.Cookies["UserEmail"] == null)
                    {
                        Response.Cookies["UserEmail"].Expires = DateTime.Now.AddDays(7);
                        Response.Cookies["UserPassword"].Expires = DateTime.Now.AddDays(7);
                        Response.Cookies["UserId"].Expires = DateTime.Now.AddDays(7);
                        Response.Cookies["UserId"].Value = Convert.ToString(new UersBLL().GetUserId(EmailTextBox1.Text.ToString()));
                        Response.Cookies["UserEmail"].Value = EmailTextBox1.Text.Trim();
                        Response.Cookies["UserPassword"].Value = PasswordTextBox1.Text.Trim();
                    }
                    Response.Redirect("~/UserInfo.aspx");

                }
                else
                {
                    //创建失败
                    Response.Write("此邮箱已经存在");
                }
            }
            else
            {
                Response.Write("信息填写不完整");
            }
        }

    }
}