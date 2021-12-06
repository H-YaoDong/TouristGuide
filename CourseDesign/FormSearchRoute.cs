using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseDesign
{
    public partial class FormSearchRoute : Form
    {
        private static FormSearchRoute singlesr = null;

        private static string[] route1 = { "双港站", "孔目湖站", "长江路站", "珠江路站", "庐山南大道站", "绿茵路站", "卫东站", "地铁大厦站", "秋水广场站", "滕王阁站", "万寿宫站", "八一馆站", "八一广场站", "丁公路北站", "师大南路站", "彭家桥站", "谢家村站", "青山湖大道站", "高新大道站", "艾溪湖西站", "艾溪湖东站", "太子殿站", "奥体中心站", "瑶湖西站" };
        private static string[] route2 = { "南路站", "大岗站", "生米站", "九龙湖南站", "市民中心站", "鹰潭街站", "国博站", "西站南广场站", "南昌西站", "龙岗站", "国体中心站", "卧龙山站", "岭北站", "前湖大道站", "学府大道东站", "翠苑路站", "地铁大厦站", "雅苑路站", "红谷中大道站", "阳明公园站", "青山路口站", "福州路站", "八一广场站", "永叔路站", "丁公路南站", "南昌火车站", "顺外站", "辛家庵站" };
        private static string[] route3 = { "银三角北", "斗门", "柏岗", "沥山", "振兴大道", "邓埠", "八大山人", "施尧", "江铃", "京家山", "十字街", "绳金塔", "六眼井", "八一馆", "墩子塘", "青山路口", "上沙沟", "青山湖西", "火炬广场", "京东大道" };
        List<string> list1 = new List<string>(route1);
        List<string> list2 = new List<string>(route2);
        List<string> list3 = new List<string>(route3);

        private static double[] route1Dis = { 0.0, 1.2, 3.0, 1.2, 1.5, 0.8, 1.2, 1.0, 0.9, 2.0, 0.8, 0.6, 1.1, 1.0, 1.1, 0.9, 0.7, 0.8, 1.1, 1.3, 1.9, 1.7, 1.4, 1.3};
        private static double[] route2Dis = { 0.0,0.9,1.3, 0.9, 1.6, 0.7, 1.4, 1.6, 0.7, 1.1, 1.7, 1.2, 1.3, 1.3, 0.9, 1.6, 1.5, 0.9, 1.1, 2.6, 1.0, 0.7, 0.7, 0.9, 0.6, 1.0, 0.7, 1.4};
        private static double[] route3Dis = { 0,1,1.9,1.2,2.2,1.4,1.2,1.5,0.9,1.5,1.6,0.7,1.6,0.6,1.3,0.8,1.6,1.6,3.6,2.1};

        private static int len = route1Dis.Length + route2Dis.Length + route3Dis.Length;
        private double[,] allDis = new double[len, len];

        int startLine;
        int endLine;
        int startStation;
        int endStation;
        
        public FormSearchRoute()
        {
            InitializeComponent();
        }
        public static FormSearchRoute getSingle()
        {
            if (singlesr == null || singlesr.IsDisposed)
            {
                singlesr = new FormSearchRoute();
            }
            return singlesr;
        }

        private void cbStartRoute_SelectedIndexChanged(object sender, EventArgs e)
        { 
            int index = cbStartRoute.SelectedIndex;
            startLine = index;
            MessageBox.Show(index + "");
            if (index == 0)
            {
                cbStartStation.DataSource = list1;
            }
            else if (index == 1)
            {
                cbStartStation.DataSource = list2;
            }
            else
            {
                cbStartStation.DataSource = list3;
            }
        }

        private void cbEndRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbEndRoute.SelectedIndex;
            endLine = index;
            MessageBox.Show(index + "");
            if (index == 0)
            {
                cbEndStation.DataSource = list1;
            }
            else if (index == 1)
            {
                cbEndStation.DataSource = list2;
            }
            else
            {
                cbEndStation.DataSource = list3;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            double distacne = countDistance(startLine, startStation, endLine, endStation);
            int price = (int)distacne * 2;
            textBox1.Text = "总路程：" + distacne;
            labelPrice.Text = price+"";
        }

        private void countAllDistance()
        {
            for(int i=0; i<len; i++)
            {
                for(int j=0; j<len; j++)
                {
                    allDis[i,j] = 99999;
                }
            }

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (i == j) allDis[i, j] = 0;
                    if(i>0 && i < 24)
                    {
                        allDis[i, i - 1] = route1Dis[i];
                        allDis[i - 1, i] = route1Dis[i];
                    }else if (i>24&&i<52)
                    {
                        allDis[i, i - 1] = route2Dis[i - 24];
                        allDis[i - 1, i] = route2Dis[i - 24];
                    }
                    if (i > 52)
                    {
                        allDis[i, i - 1] = route3Dis[i - 52];
                        allDis[i - 1, i] = route3Dis[i - 52];
                    }
                }
            }
            //设置1，2号线交叉点
            //地铁大厦
            allDis[7, 40] = allDis[40, 7] = 0;
            //八一广场
            allDis[12, 46] = allDis[46, 12] = 0;
            //八一馆
            allDis[65, 11] = allDis[11, 65] = 0;

            for(int k=0; k<len; k++)
            {
                for(int i=0;i<len; i++)
                {
                    for(int j=0; j<len; j++)
                    {
                        allDis[i, j] = Math.Min(allDis[i, k] + allDis[k, j], allDis[i, j]);
                    }
                }
            }
        }

        private double countDistance(int startLine, int startStation, int endLine, int endStation)
        {
            double distance = 0;
            if (startLine == 1) startStation += 24;
            if (startLine == 2) startStation += 52;

            if (endLine == 1) endStation += 24;
            if (endLine == 2) endStation += 52;
            distance = allDis[startStation, endStation];
            return distance;    
        }

        private void FormSearchRoute_Load(object sender, EventArgs e)
        {
            countAllDistance();
        }

        private void cbStartStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            startStation = cbStartStation.SelectedIndex;
        }

        private void cbEndStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            endStation = cbEndStation.SelectedIndex;
        }
    }
}