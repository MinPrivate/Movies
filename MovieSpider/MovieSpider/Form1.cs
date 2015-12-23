using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace MovieSpider
{
    public partial class Form1 : Form
    {
        private int selectedPanel = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            initPanel();
        }

        private void initPanel()
        {
            selectedPanel = 0;
            this.tableLayoutPanel1.ColumnStyles[0].Width = 100;
            this.tableLayoutPanel1.ColumnStyles[1].Width = 0;
            this.tableLayoutPanel1.ColumnStyles[2].Width = 0;
        }

        private void BeginSpider()
        {
            PlayingMovieListPageSpider spider = new PlayingMovieListPageSpider();
            spider.Province = "Hubei";
            spider.City = "Wuhan";
            spider.FetchedDataSaver = new DataSaver(this.listBox1);
            spider.FetchedDataSaver.ClearAll();
            spider.DoWork();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(BeginSpider));
            thread.Start();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.label3.ForeColor = this.label5.ForeColor = Color.White;
            this.label4.ForeColor = Color.Aqua;
            ChangeSelectedPanel(1);
        }

        private void ChangeSelectedPanel(int id)
        {
            if (id == selectedPanel)
                return;
            for (int i = 0; i < 3; ++i)
                if (i != selectedPanel && i != id)
                    this.tableLayoutPanel1.ColumnStyles[i].Width = 0;


            for (int i = 0; i < 8; ++i)
            {
                System.Threading.Thread.Sleep(10);
                this.tableLayoutPanel1.ColumnStyles[selectedPanel].Width -= 12.5F;
                this.tableLayoutPanel1.ColumnStyles[id].Width += 12.5F;
                this.tableLayoutPanel1.Refresh();
            }

            this.selectedPanel = id;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.label4.ForeColor = this.label5.ForeColor = Color.White;
            this.label3.ForeColor = Color.Aqua;
            ChangeSelectedPanel(0);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.label3.ForeColor = this.label4.ForeColor = Color.White;
            this.label5.ForeColor = Color.Aqua;
            ChangeSelectedPanel(2);
        }
    }
}
