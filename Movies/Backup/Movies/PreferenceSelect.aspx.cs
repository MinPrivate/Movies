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
    public partial class PreferenceSelect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          

        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            //接受选择信息

            string Preference = "";
            if (Love.Checked)
            {
                Preference += "爱情";
            }
            if (this.Action.Checked)
            {
                Preference += "/动作";
            } if (this.Terrifiy.Checked)
            {
                Preference += "/惊悚";
            }
            if (this.Cartoon.Checked)
            {
                Preference += "/卡通";
            } if (this.Comedy.Checked)
            {
                Preference += "/喜剧";
            } if (this.War.Checked)
            {
                Preference += "/战争";
            } if (this.Horrify.Checked)
            {
                Preference += "/恐怖";
            } if (this.Crime.Checked)
            {
                Preference += "/犯罪";
            }
            // MessageBox.Show(Preference);
            //判断是否登录
            if (Request.Cookies["UserEmail"] == null)
            {
                Response.Write("<div class='msgboxbg'>" + "<div class='mainmsgbox'>" + "<br/><br/><br/><br/><div class='msgcon'>您还没有登录，请先登录!</div>" + " <a href='LogIn.aspx'> <div class='tip'>返回</div></a>" + " </div></div></div>");
            }
            else
            {
                //获取登录状态 email标志
                string GetEmail = Request.Cookies["UserEmail"].Value;
                UersBLL newUserBll = new UersBLL();
                if (!newUserBll.PreferenceSave(GetEmail, Preference))
                {
                    Response.Write(" <div class='msgboxbg'>" + "<div class='mainmsgbox'>" + "<br/><br/><br/><br/><div class='msgcon'>提交失败，请重试!</div>" + " <a href='PreferenceSelect.aspx'> <div class='tip'>返回</div></a>" + " </div></div></div>");
                }
                else
                {
                    Response.Write("<div class='msgboxbg'>" + "<div class='mainmsgbox'>" + "<br/><br/><br/><br/><div class='msgcon'>您的偏好选择成功!</div>" + " <a href='UserInfo.aspx'> <div class='tip'>返回</div></a>" + " </div></div></div>");
                    //提示成功
                }
                //

            }


        }
    }
}