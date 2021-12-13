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
    public partial class FormDelicious : Form
    {
        DBHelper helper = new DBHelper("mysql");
        string sql;
        DataTable table;
        IDataReader reader;

        string[] cities = { "南昌市", "景德镇市", "萍乡市", "九江市", "新余市", "鹰潭市", "赣州市", "吉安市", "宜春市", "抚州市", "上饶市" };

        string[] country0 = { "南昌市", "新建县", "安义县", "进贤县"};
        string[] country1 = { "浮梁县", "乐平市"};
        string[] country2 = { "莲花", "上栗", "芦溪"};
        string[] country3 = { "武宁", "修水", "永修", "德安", "星子", "都昌", "湖口", "彭泽", "瑞昌" };
        string[] country4 = { "分宜县"};
        string[] country5 = { "余江", "贵溪" };
        string[] country6 = { "赣县", "南康", "信丰", "大余", "上犹", "崇义", "安远", "龙南", "定南", "全南", "宁都", "于都", "兴国", "会昌", "寻乌", "石城", "瑞金" };
        string[] country7 = { "丰城", "樟树", "高安", "奉新", "万载", "上高", "宜丰", "靖安", "铜鼓" };
        string[] country8 = { "德兴", "广丰", "玉山", "铅山", "横峰", "弋阳", "余干", "鄱阳", "万年", "婺源" };
        string[] country9 = { "井冈山", "吉水", "峡江", "新干", "永丰", "泰和", "遂川", "万安", "安福", "永新" };
        string[] country10 = { "南城", "黎川", "南丰", "崇仁", "乐安", "宜黄", "金溪", "资溪", "东乡", "广昌" };

        List<string[]> countries = new List<string[]>();


        public FormDelicious()
        {
            InitializeComponent();
        }

        private void FormDelicious_Load(object sender, EventArgs e)
        {
            sql = "select id, name from category";
            table = helper.FillTable(sql);
            if (table != null)
            {
                lvFood.Groups.Clear();
                for(int i=0; i<table.Rows.Count; i++)
                {
                    lvFood.Groups.Add(table.Rows[i][0].ToString(), table.Rows[i][1].ToString());
                }
            }
            sql = "select code, name, price, icon, category from foods";
            table = helper.FillTable(sql);
            ListViewItem itmData;
            if (table != null)
            {
                string[] items;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    //为item增加列，品名，单价，编号
                    items = new string[] { table.Rows[i][1].ToString(), table.Rows[i][2].ToString(), table.Rows[i][0].ToString() };
                    //为item增加ImageKey
                    itmData = lvFood.Items.Add(new ListViewItem(items, table.Rows[i][3].ToString()));
                    lvFood.Items[i].SubItems.Add("12");
                    //为item分配group
                    itmData.Group = lvFood.Groups[table.Rows[i][4].ToString()];
                }
            }


            countries.Add(country0); countries.Add(country1); countries.Add(country2); countries.Add(country3); countries.Add(country4); 
            countries.Add(country5); countries.Add(country6); countries.Add(country7); countries.Add(country8); countries.Add(country9);
            countries.Add(country10);

            cbCounty.DataSource = cities;
            cbCity.DataSource = country0;

        }

        private void lvFood_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvFood.SelectedItems.Count > 0)
            {
                txtName.Text = lvFood.SelectedItems[0].Text;
                txtID.Text = lvFood.SelectedItems[0].SubItems[2].Text;
                txtPrice.Text = lvFood.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            grdData.Rows.Add(txtID.Text.Trim(), txtName.Text.Trim(), txtPrice.Text.Trim(), txtCount.Value);
            float amount = float.Parse(txtAmount.Text.Trim());
            int price = int.Parse(txtPrice.Text.Trim());
            int count = (int)txtCount.Value;
            amount += price * count;
            txtAmount.Text = amount + "";
        }

        private void mmuDel_Click(object sender, EventArgs e)
        {
            int idx = grdData.CurrentRow.Index;
            float price = float.Parse(grdData.Rows[idx].Cells[3].Value.ToString());
            int count = int.Parse((string)grdData.Rows[idx].Cells[2].Value);
            float amount = float.Parse(txtAmount.Text.Trim());

            grdData.Rows.Remove(grdData.CurrentRow);
            amount -= price * count;
            txtAmount.Text = amount + "";
        }

        private void mmuClear_Click(object sender, EventArgs e)
        {
            grdData.Rows.Clear();
            txtAmount.Text = "0";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mmuClear_Click(sender, e);
            txtName.Text = "";
            txtCount.Text = "1";
            
        }

        private void btnPay_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("请确认支付", "提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                string id = FormLogin.userID;
                string sql;
                sql = "select amount from user where id ='" + id + "'";
                reader = helper.DataRead(sql);
                float amount = 0;
                if(reader!=null && reader.Read())
                    amount = reader.GetFloat(0);
                helper.DisConnection();
                float spend = float.Parse(txtAmount.Text.Trim());
                if (amount >= spend)
                {
                    int row = grdData.Rows.Count;
                    int column = grdData.Columns.Count;
                    string name = "";
                    float money = 0;
                    string date = "";

                    for (int i = 0; i < row; i++)
                    {
                        name = grdData.Rows[i].Cells[1].Value.ToString();
                        money = float.Parse(grdData.Rows[i].Cells[2].Value.ToString());
                        date = DateTime.Now.ToString("yyyy-MM-dd-HH:mm");
                        sql = "insert into consume_record values('"+id+"', '"+name+"', '"+money+"', '"+date+"', '"+txtCount.Value+"')";

                        helper.Update(sql);
                        helper.DisConnection();
                    }
                    MessageBox.Show("支付成功！");
                    sql = "update user set amount = '" + (amount - spend) + "' where id ='" +id+ "'";

                    helper.Update(sql);
                    helper.DisConnection();
                }
                else
                {
                    MessageBox.Show("余额不足，请充值！");
                }
            }
        }

        private void cbCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("country: "+cbCounty.SelectedIndex);
            MessageBox.Show("city: "+cbCity.SelectedIndex);
            
           cbCity.DataSource = countries[cbCounty.SelectedIndex];
        }
    }
}
