using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
//using System.Windows.Forms;
using BusinessLogicLayer;
using DataAccessLayer;

namespace Movies
{
    public partial class CinemaList : System.Web.UI.Page
    {
        //记录下拉列表1 的值 保存 地区 信息
        string _ddlArea = string.Empty;

        //记录下拉列表2 的值 记录 电影院
        string _ddlCinema = string.Empty;

        //记录输入的检索词
        string _searchText = string.Empty;

        //创建Cinema业务对象
        CinemaBLL _cinemaBll = new CinemaBLL();

        ////记录电影院列表中选中的电影院
        //int _selectCinema;

        //动态表存需要数据
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //MessageBox.Show("影院列表");
                //给下拉列表1 增加Items
                GetDdlAreaItems();

                //下拉列表默认选择第一个
                DropDownListArea.SelectedIndex = 0;
                DropDownListArea.Text = DropDownListArea.SelectedValue;

                //得到下拉列表 1  的值
                _ddlArea = DropDownListArea.SelectedValue;

                //给下拉列表2 增加Items
                //清理之前内容
                DropDownListCinema.Items.Clear();
                //根据地区 加入新内容
                //MessageBox.Show(_ddlArea);
                GetDdlCinemaItems(_ddlArea);
                //下拉列表 2 默认选择第一个 保存医院名
                DropDownListCinema.SelectedIndex = 0;
                DropDownListCinema.Text = DropDownListCinema.SelectedValue;
                //得到影院名
                _ddlCinema = DropDownListCinema.SelectedValue;

                //加载电影院信息
                //LoadCinema();
                //Display("武汉万达国际电影城");

                GridViewCinemas.DataSourceID = "ObjectDataSourceCinemaShow";
            }
        }

        protected void DropDownListArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ddlArea = DropDownListArea.SelectedValue;
            //清理影院下拉列表之前内容
            DropDownListCinema.Items.Clear();
            //根据地区 加入新内容
            GetDdlCinemaItems(_ddlArea);
            //默认选择第一个
            DropDownListCinema.SelectedIndex = 0;
            //Test
            //MessageBox.Show(_ddlArea);
        }

        protected void DropDownListCinema_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ddlCinema = DropDownListCinema.SelectedValue;
            //MessageBox.Show(_ddlCinema);
            
        }

        //protected void TextBoxSearch_TextChanged(object sender, EventArgs e)
        //{

        //}

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (TextBoxSearchText.Text != "")
            {
                List<CinemaShow> cinemaShows = new List<CinemaShow>();
                cinemaShows = _cinemaBll.GetCinemaShowByCinemaName(TextBoxSearchText.Text);
                if (cinemaShows.First().Name != null)
                {
                    Session["CinemaShowName"] = TextBoxSearchText.Text;
                    GridViewCinemas.DataSourceID = "CinemaDataSource";
                }
                else
                {
                    //MessageBox.Show("没有该影院的相关信息，请确认影院名是否输入正确！");  不可用

                    //另写提示信息 不能用 MessageBox
                    //Response.Write("<script language=javascript>alert('没有该影院的相关信息，请确认影院名是否输入正确！');</" + "script>");
                    //Page.RegisterStartupScript("1", "<script language=javascript >window.alert('没有该影院的相关信息，请确认影院名是否输入正确！');</" + "script>");
                    Response.Write("<div class='msgboxbg'>" + "<div class='mainmsgbox'>" + "<br/><br/><br/><br/><div class='msgcon'>您没有该影院的相关信息，请确认影院名名是否输入正确！</div>" + " <a href='CinemaList.aspx'> <div class='tip'>返回</div></a>" + " </div></div></div>");
                }
            }
            else
                GridViewCinemas.DataSourceID = "ObjectDataSourceCinemaShow";
        }

        protected void CinemaDetail_Click(object sender, EventArgs e)
        {
            string cinemaName = string.Empty;

            Button button = (Button)sender;
            cinemaName = button.Text;

            Session["CinemaNameToCinemaDetails"] = cinemaName;
            Response.Redirect("~/CinemaDetails.aspx");
        }

        protected void GetDdlAreaItems()
        {
            ListItem liAll1 = new ListItem("全部");
            ListItem liArea1 = new ListItem("汉阳区");
            ListItem liArea2 = new ListItem("洪山区");
            ListItem liArea3 = new ListItem("江岸区");
            ListItem liArea4 = new ListItem("江汉区");
            ListItem liArea5 = new ListItem("武昌区");
            ListItem liArea6 = new ListItem("硚口区");

            ListItem liArea7 = new ListItem("青山区");
            ListItem liArea8 = new ListItem("江夏区");
            ListItem liArea9 = new ListItem("黄陂区");
            ListItem liArea10 = new ListItem("新洲区");
            ListItem liArea11 = new ListItem("经济技术开发区");

            //清理已存在内容
            DropDownListArea.Items.Clear();
            //加入新内容
            DropDownListArea.Items.Add(liAll1);
            DropDownListArea.Items.Add(liArea1);
            DropDownListArea.Items.Add(liArea2);
            DropDownListArea.Items.Add(liArea3);
            DropDownListArea.Items.Add(liArea4);
            DropDownListArea.Items.Add(liArea5);
            DropDownListArea.Items.Add(liArea6);
            DropDownListArea.Items.Add(liArea7);
            DropDownListArea.Items.Add(liArea8);
            DropDownListArea.Items.Add(liArea9);
            DropDownListArea.Items.Add(liArea10);
            DropDownListArea.Items.Add(liArea11);
        }
        protected void GetDdlCinemaItems(String newArea)
        {
            //根据所选的地区 给下拉列表3 加载数据
            //汉阳区
            ListItem liCinemaAA = new ListItem("全部");
            ListItem liCinemaA1 = new ListItem("武汉金逸国际影城（王家湾店）");
            ListItem liCinemaA2 = new ListItem("汉阳天河国际影城");
            ListItem liCinemaA3 = new ListItem("武汉万达影城（汉商店）");
            //洪山区
            ListItem liCinemaBA = new ListItem("全部");
            ListItem liCinemaB1 = new ListItem("武汉正华影城");
            ListItem liCinemaB2 = new ListItem("武汉金逸国际影城（销品茂店）");
            ListItem liCinemaB3 = new ListItem("武汉中影天河国际影城");
            ListItem liCinemaB4 = new ListItem("洪山天河国际影城");
            ListItem liCinemaB5 = new ListItem("武汉金逸国际影城（南湖店）");
            ListItem liCinemaB6 = new ListItem("华谊兄弟影院武汉光谷店");
            //江岸区
            ListItem liCinemaCA = new ListItem("全部");
            ListItem liCinemaC1 = new ListItem("武汉CGV星星影城");
            ListItem liCinemaC2 = new ListItem("天汇影城");
            ListItem liCinemaC3 = new ListItem("中影国际影城武汉东购店");
            ListItem liCinemaC4 = new ListItem("武汉影城");
            ListItem liCinemaC5 = new ListItem("武汉天河国际影城后湖百步亭店");
            ListItem liCinemaC6 = new ListItem("湖北鑫乐银兴电影城");

            //江汉区
            ListItem liCinemaDA = new ListItem("全部");
            ListItem liCinemaD1 = new ListItem("武汉环银电影城");
            ListItem liCinemaD2 = new ListItem("武汉环艺新民众电影城");
            ListItem liCinemaD3 = new ListItem("武汉万达影城（江汉路店）");
            ListItem liCinemaD4 = new ListItem("武商摩尔国际电影城");
            ListItem liCinemaD5 = new ListItem("武汉万达影城（菱角湖店）");
            ListItem liCinemaD6 = new ListItem("湖北银兴乐天影城（西园旗舰店）");
            ListItem liCinemaD7 = new ListItem("武汉横店影视电影城");
            ListItem liCinemaD8 = new ListItem("大地数字影院-武汉汉口沿江一号");

            //武昌区
            ListItem liCinemaEA = new ListItem("全部");
            ListItem liCinemaE1 = new ListItem("洪山礼堂银兴影城");
            ListItem liCinemaE2 = new ListItem("江汉环球电影城");
            ListItem liCinemaE3 = new ListItem("亚贸兴汇");
            ListItem liCinemaE4 = new ListItem("武汉万达影城（春树里店）");
            ListItem liCinemaE5 = new ListItem("湖北剧院银兴电影城");
            ListItem liCinemaE6 = new ListItem("湖北银兴艺术影城");
            ListItem liCinemaE7 = new ListItem("大地数字影院--武汉五环峰商业广场");
            ListItem liCinemaE8 = new ListItem("武昌横店影城");

            //硚口区
            ListItem liCinemaFA = new ListItem("全部");
            ListItem liCinemaF1 = new ListItem("17.5武汉宝丰影城");

            //青山区
            ListItem liCinemaGA = new ListItem("全部");
            ListItem liCinemaG1 = new ListItem("青山天河国际电影城");

            //江夏区
            ListItem liCinemaHA = new ListItem("全部");
            ListItem liCinemaH1 = new ListItem("银兴乐天影城江夏店");

            //黄陂区
            ListItem liCinemaJA = new ListItem("全部");
            ListItem liCinemaJ1 = new ListItem("华谊兄弟武汉黄陂影城");

            //新洲区
            ListItem liCinemaKA = new ListItem("全部");
            ListItem liCinemaK1 = new ListItem("新洲横店影城");

            //经济技术开发区
            ListItem liCinemaLA = new ListItem("全部");
            ListItem liCinemaL1 = new ListItem("武汉万达影城（经开店）");
            ListItem liCinemaL2 = new ListItem("大地数字影院--武汉湘隆时代广场");
            switch (newArea)
            {
                case "汉阳区":
                    DropDownListCinema.Items.Add(liCinemaAA);
                    DropDownListCinema.Items.Add(liCinemaA1);
                    DropDownListCinema.Items.Add(liCinemaA2);
                    DropDownListCinema.Items.Add(liCinemaA3);
                    break;

                case "洪山区":
                    DropDownListCinema.Items.Add(liCinemaBA);
                    DropDownListCinema.Items.Add(liCinemaB1);
                    DropDownListCinema.Items.Add(liCinemaB2);
                    DropDownListCinema.Items.Add(liCinemaB3);
                    DropDownListCinema.Items.Add(liCinemaB4);
                    DropDownListCinema.Items.Add(liCinemaB5);
                    DropDownListCinema.Items.Add(liCinemaB6);
                    break;

                case "江岸区":
                    DropDownListCinema.Items.Add(liCinemaCA);
                    DropDownListCinema.Items.Add(liCinemaC1);
                    DropDownListCinema.Items.Add(liCinemaC2);
                    DropDownListCinema.Items.Add(liCinemaC3);
                    DropDownListCinema.Items.Add(liCinemaC4);
                    DropDownListCinema.Items.Add(liCinemaC5);
                    DropDownListCinema.Items.Add(liCinemaC6);
                    break;

                case "江汉区":
                    DropDownListCinema.Items.Add(liCinemaDA);
                    DropDownListCinema.Items.Add(liCinemaD1);
                    DropDownListCinema.Items.Add(liCinemaD2);
                    DropDownListCinema.Items.Add(liCinemaD3);
                    DropDownListCinema.Items.Add(liCinemaD4);
                    DropDownListCinema.Items.Add(liCinemaD5);
                    DropDownListCinema.Items.Add(liCinemaD6);
                    DropDownListCinema.Items.Add(liCinemaD7);
                    DropDownListCinema.Items.Add(liCinemaD8);
                    break;

                case "武昌区":
                    DropDownListCinema.Items.Add(liCinemaEA);
                    DropDownListCinema.Items.Add(liCinemaE1);
                    DropDownListCinema.Items.Add(liCinemaE2);
                    DropDownListCinema.Items.Add(liCinemaE3);
                    DropDownListCinema.Items.Add(liCinemaE4);
                    DropDownListCinema.Items.Add(liCinemaE5);
                    DropDownListCinema.Items.Add(liCinemaE6);
                    DropDownListCinema.Items.Add(liCinemaE7);
                    DropDownListCinema.Items.Add(liCinemaE8);
                    break;

                case "硚口区":
                    DropDownListCinema.Items.Add(liCinemaFA);
                    DropDownListCinema.Items.Add(liCinemaF1);
                    break;

                case "青山区":
                    DropDownListCinema.Items.Add(liCinemaGA);
                    DropDownListCinema.Items.Add(liCinemaG1);
                    break;

                case "江夏区":
                    DropDownListCinema.Items.Add(liCinemaHA);
                    DropDownListCinema.Items.Add(liCinemaH1);
                    break;

                case "黄陂区":
                    DropDownListCinema.Items.Add(liCinemaJA);
                    DropDownListCinema.Items.Add(liCinemaJ1);
                    break;

                case "新洲区":
                    DropDownListCinema.Items.Add(liCinemaKA);
                    DropDownListCinema.Items.Add(liCinemaK1);
                    break;

                case "经济技术开发区":
                    DropDownListCinema.Items.Add(liCinemaLA);
                    DropDownListCinema.Items.Add(liCinemaL1);
                    DropDownListCinema.Items.Add(liCinemaL2);
                    break;

                default:
                    {
                        //汉阳区
                    DropDownListCinema.Items.Add(liCinemaAA);
                    DropDownListCinema.Items.Add(liCinemaA1);
                    DropDownListCinema.Items.Add(liCinemaA2);
                    DropDownListCinema.Items.Add(liCinemaA3);
                    
                //洪山区":
                    //DropDownListCinema.Items.Add(liCinemaBA);
                    DropDownListCinema.Items.Add(liCinemaB1);
                    DropDownListCinema.Items.Add(liCinemaB2);
                    DropDownListCinema.Items.Add(liCinemaB3);
                    DropDownListCinema.Items.Add(liCinemaB4);
                    DropDownListCinema.Items.Add(liCinemaB5);
                    DropDownListCinema.Items.Add(liCinemaB6);
                    
                //江岸区":
                   // DropDownListCinema.Items.Add(liCinemaCA);
                    DropDownListCinema.Items.Add(liCinemaC1);
                    DropDownListCinema.Items.Add(liCinemaC2);
                    DropDownListCinema.Items.Add(liCinemaC3);
                    DropDownListCinema.Items.Add(liCinemaC4);
                    DropDownListCinema.Items.Add(liCinemaC5);
                    DropDownListCinema.Items.Add(liCinemaC6);
                    
                //江汉区":
                    //DropDownListCinema.Items.Add(liCinemaDA);
                    DropDownListCinema.Items.Add(liCinemaD1);
                    DropDownListCinema.Items.Add(liCinemaD2);
                    DropDownListCinema.Items.Add(liCinemaD3);
                    DropDownListCinema.Items.Add(liCinemaD4);
                    DropDownListCinema.Items.Add(liCinemaD5);
                    DropDownListCinema.Items.Add(liCinemaD6);
                    DropDownListCinema.Items.Add(liCinemaD7);
                    DropDownListCinema.Items.Add(liCinemaD8);
                   
                //武昌区":
                    //DropDownListCinema.Items.Add(liCinemaEA);
                    DropDownListCinema.Items.Add(liCinemaE1);
                    DropDownListCinema.Items.Add(liCinemaE2);
                    DropDownListCinema.Items.Add(liCinemaE3);
                    DropDownListCinema.Items.Add(liCinemaE4);
                    DropDownListCinema.Items.Add(liCinemaE5);
                    DropDownListCinema.Items.Add(liCinemaE6);
                    DropDownListCinema.Items.Add(liCinemaE7);
                    DropDownListCinema.Items.Add(liCinemaE8);
                   
                //硚口区":
                    //DropDownListCinema.Items.Add(liCinemaFA);
                    DropDownListCinema.Items.Add(liCinemaF1);
                    
                //青山区":
                    //DropDownListCinema.Items.Add(liCinemaGA);
                    DropDownListCinema.Items.Add(liCinemaG1);
                    
                //江夏区":
                    //DropDownListCinema.Items.Add(liCinemaHA);
                    DropDownListCinema.Items.Add(liCinemaH1);
                   
                //黄陂区":
                    //DropDownListCinema.Items.Add(liCinemaJA);
                    DropDownListCinema.Items.Add(liCinemaJ1);
                    
                //新洲区":
                    //DropDownListCinema.Items.Add(liCinemaKA);
                    DropDownListCinema.Items.Add(liCinemaK1);
                   
                //经济技术开发区":
                    //DropDownListCinema.Items.Add(liCinemaLA);
                    DropDownListCinema.Items.Add(liCinemaL1);
                    DropDownListCinema.Items.Add(liCinemaL2);
                    break;
                    }
            }

        }

        //过后删除！！！！！！！！！！！！！！！！！！
        protected void LoadCinema()
        {
            //加载电影院信息

            //MessageBox.Show(newCinemaName);
            //动态生成数据表
            //DataTable dt = new DataTable();
            //添加列
            DataColumn name = new DataColumn("name", typeof(string));

            DataColumn address = new DataColumn("address", typeof(string));
            DataColumn movieNum = new DataColumn("movieNum", typeof(int));

            dt.Columns.Add(name);
            dt.Columns.Add(address);
            dt.Columns.Add(movieNum);

            
            List<CINEMA> cinemas = new List<CINEMA>();
            cinemas = _cinemaBll.GetAllCinemas();

            //添加行数据      
            foreach (CINEMA ci in cinemas)
            {
                DataRow row = dt.NewRow();
                row[name] = ci.name;
                row[address] = ci.address;
                int num = _cinemaBll.GetMovieNumByCinemaName(ci.name, ci.address);
                row[movieNum] = num;

                //row[TitleLink] = SiteName + "/" + WebName + "/" + web.Lists[ListName].RootFolder +
                //    "/" + "DispForm.aspx?ID=" +
                //    item.GetFormattedValue("ID") +
                //    "&Source=" + SiteName + "/" + WebName + "/"; ;
                dt.Rows.Add(row);
            }
         
            //清楚原有数据
            GridViewCinemas.DataSource = null;
            GridViewCinemas.DataBind();
            //绑定新数据
            GridViewCinemas.DataSource = dt;
            GridViewCinemas.DataBind();
        }

        //过后删除！！！！！！！！！！！！！！！！！！
        protected void Display(string newCinemaName)
        {
            if(newCinemaName.Equals("全部"))
            {
                LoadCinema();
                return ;
            }
            //把搜索的数据绑定到界面
            //DataTable dt = new DataTable();
            //添加列
            DataColumn name = new DataColumn("name", typeof(string));

            DataColumn address = new DataColumn("address", typeof(string));
            DataColumn movieNum = new DataColumn("movieNum", typeof(int));

            dt.Columns.Add(name);
            dt.Columns.Add(address);
            dt.Columns.Add(movieNum);


            CINEMA cinema = new CINEMA();
            cinema = _cinemaBll.GetCinema(newCinemaName);

            //添加行数据      
            
            DataRow row = dt.NewRow();
            row[name] = cinema.name;
            row[address] = cinema.address;
            int num = _cinemaBll.GetMovieNumByCinemaName(cinema.name, cinema.address);
            row[movieNum] = num;

            dt.Rows.Add(row);

            //清除原有数据
            GridViewCinemas.DataSource = null;
            GridViewCinemas.DataBind();
            //绑定新数据
            GridViewCinemas.DataSource = dt;
            GridViewCinemas.DataBind();
            
            
        }

    }
}