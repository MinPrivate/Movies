using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Windows.Forms;

namespace Movies
{
    public partial class ModifyPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text == string.Empty || NewPasswordTextBox.Text == string.Empty || CheckPasswordTextBox.Text == string.Empty)
            {

                Response.Write("<div class='msgboxbg'>" + "<div class='mainmsgbox'>" + "<div class='msgcon'>输入信息不完整!</div>" + " <a href='LogIn.aspx'> <div class='tip'>重新填写</div></a>" + " </div></div></div>");
            }
            else
            {
                if (Request.Cookies["UserEmail"] == null)//判断是否登录
                {

                    //  Response.Write("<div class='msgboxbg'>" + "<div class='mainmsgbox'>" + "<div class='msgcon'>您还没有登录，请先登录!</div>" + " <a href='LogIn.aspx'> <div class='tip'>返回</div></a>" + " </div></div></div>");
                }

                UersBLL newUserBll = new UersBLL();
                //获取登录状态 email标志
                string GetEmail = Request.Cookies["UserEmail"].Value;

                // MessageBox.Show(GetEmail);

                bool IsPassWordLegal = newUserBll.CheckPassword(GetEmail, PasswordTextBox.Text);
                //检查密码是否正确
                if (IsPassWordLegal)
                {

                    if (newUserBll.UpdatePassword(GetEmail, NewPasswordTextBox.Text))
                    {
                        //成功更新密码

                        //修改session中保存的老密码
                        // Response.Cookies["UserEmail"].Expires = DateTime.Now;
                        Response.Cookies["UserPassword"].Expires = DateTime.Now;
                        Response.Cookies["UserPassword"].Value = NewPasswordTextBox.Text.Trim();
                        Response.Cookies["UserPassword"].Expires = DateTime.Now.AddDays(7);
                        // Response.Write(Response.Cookies["UserPassword"].Value);
                        Response.Redirect("UserInfo.aspx");
                    }
                    else
                    {
                        //提示密码更新出错
                        //  Response.Write("<div class='msgboxbg'>" + "<div class='mainmsgbox'>" + "<div class='msgcon'>出错了，亲输入的用户名和密码不匹配!</div>" + " <a href='LogIn.aspx'> <div class='tip'>重新填写</div></a>" + " </div></div></div>");


                    }
                }
                else
                {
                    //提示密码有误
                    // Response.Write("<div class='msgboxbg'>" + "<div class='mainmsgbox'>" + "<div class='msgcon'>输入的密码有错</div>" + " <a href='LogIn.aspx'> <div class='tip'>重新填写</div></a>" + " </div></div></div>");

                }
            }
        }
    }
}