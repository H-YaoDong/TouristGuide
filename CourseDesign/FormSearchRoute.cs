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
        private static string[] route3 = { "银三角北站", "斗门站", "柏岗站", "沥山站", "振兴大道站", "邓埠站", "八大山人站", "施尧站", "江铃站", "京家山站", "十字街站", "绳金塔站", "六眼井站", "八一馆站", "墩子塘站", "青山路口站", "上沙沟站", "青山湖西站", "火炬广场站", "京东大道站" };
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

        int price;
        string id;

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
            double distacne = dijstra(startLine, startStation, endLine, endStation);
            if (distacne <= 6)
            {
                price = 2;
            }
            else if(distacne <= 12)
            {
                price = 3;
            }else
            {
                price = 3 + (int)(distacne - 12)/8;
            }
            txtDistance.Text =  distacne+" /km";
            labelPrice.Text = price+" 元";
        }

        //矩阵初始化
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


            /* Floyd算法
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
            */
        }


        private double dijstra(int startLine, int startStation, int endLine, int endStation)
        {
            double distance = 0;
            if (startLine == 1) startStation += 24;
            if (startLine == 2) startStation += 52;
            if (endLine == 1) endStation += 24;
            if (endLine == 2) endStation += 52;

            //dist[i]：起始站到 i 的最短距离
            bool[] visited = new bool[len];
            int[] path = new int[len];
            double[] dist = new double[len];
            
            for(int i=0; i<len; i++)
            {
                visited[i] = false;
                dist[i] = 99999;
                path[i] = -1;
            }

            //将距离始发站短的站加入到最短路径
            for(int i=0; i<len; i++)
            {
                if (dist[i] > allDis[startStation, i])
                {
                    dist[i] = allDis[startStation, i];
                    path[i] = startStation;
                }
            }
            dist[startStation] = 0;
            visited[startStation] = true;
            for(int i=0; i<len; i++)
            {
                double minDis = 99999;
                int minV = startStation;

                //找到当前路径中距离始发站最短的站
                for(int j=0; j<len; j++)
                {
                    if(!visited[j] && dist[j] < minDis)
                    {
                        minDis = dist[j];
                        minV = j;
                    }
                }
                for(int j = 0; j<len; j++)
                {
                    if (!visited[j])
                    {
                        //缩放，如果始发站到 j 站的距离大于站minV与minV，j两站之间的距离，那么就更新始发站到j的距离，和上一站
                        if (dist[j] > dist[minV] + allDis[minV, j])
                        {
                            dist[j] = dist[minV] + allDis[minV, j];
                            path[j] = minV;
                        }
                    }
                }
                visited[minV] = true;
            }
            distance = dist[endStation];
            string s = "";
            List<string> route = new List<string>();

            while (endStation != startStation)
            {
                if (endStation < 24) route.Add(route1[endStation]);
                else if (endStation < 52) route.Add(route2[endStation - 24]);
                else if (endStation < 72) route.Add(route3[endStation - 52]);

                endStation = path[endStation];
            }

            //最后再加上起始站
            if (endStation < 24) route.Add(route1[endStation]);
            else if (endStation < 52) route.Add(route2[endStation - 24]);
            else if (endStation < 72) route.Add(route3[endStation - 52]);
            route.Reverse();

            for(int i=0;i<route.Count; i++)
            {
                if(i!=route.Count-1 && route[i]!=route[i+1])
                s += route[i] + " -> ";
            }
            s += route[route.Count-1] ;
            rtbRoute.Text = s;
            gbRoute.Visible = true;
            return distance;
        }

        private void FormSearchRoute_Load(object sender, EventArgs e)
        {
            countAllDistance();
            string s = "";
            for(int i=0; i<len; i++)
            {
                for(int j=0; j<len; j++)
                {
                    s += allDis[i, j];
                }
                s += "\n";
            }

        }

        private void cbStartStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            startStation = cbStartStation.SelectedIndex;
        }

        private void cbEndStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            endStation = cbEndStation.SelectedIndex;
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            DialogResult dr =  MessageBox.Show("确认购买？", "提示", MessageBoxButtons.OKCancel);
            if(dr == DialogResult.OK)
            {
                id = FormLogin.userID;
                DBHelper helper = new DBHelper("mysql");
                string sql = "select amount from user where id='" + id + "'";
                IDataReader reader = helper.DataRead(sql);
                float amount = 0;
                if (reader != null && reader.Read())
                {
                    amount = reader.GetFloat(0);
                }
                helper.DisConnection();
                if (amount >= price)
                {
                    sql = "update user set amount='" + (amount - price) + "' where id='" + id + "'";
                    long res = helper.Update(sql);
                    helper.DisConnection();
                    if (res > 0)
                    {
                        MessageBox.Show("购票成功！欢迎下次光临");
                        string timeS = DateTime.Now.ToString("yyyy-MM-dd-HH:mm");
                        sql = "insert into consume_record values('"+id+"', '"+"地铁票"+"', '"+price+"', '"+timeS+ "', '" + 1 + "')";
                        helper.Update(sql);
                    }
                    else
                    {
                        MessageBox.Show("系统出错，这是个始料未及的bug");
                    }
                }
                else
                {
                    MessageBox.Show("余额不足请充值！");
                }
            }
        }
    }
}