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
            if (grdData.SelectedRows.Count > 0) grdData.Rows.Remove(grdData.CurrentRow);
        }

        private void mmuClear_Click(object sender, EventArgs e)
        {
            grdData.Rows.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mmuClear_Click(sender, e);
            txtName.Text = "";
            txtCount.Text = "1";
            
        }
    }
}
