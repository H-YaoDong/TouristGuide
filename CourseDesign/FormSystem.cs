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
    public partial class FormSystem : Form
    {
        string userPhoe;
        string userPwd;
        string id = FormLogin.userID;

        public event EventHandler CHANGE;
        public event FormClosedEventHandler FORMCLOSED;

        public FormSystem()
        {
            InitializeComponent();
            btnChange.Click += new EventHandler(changeuser);
        }

        private void changeuser(object sender, EventArgs e)
        {
            CHANGE.Invoke(sender, e);
        }

        private void formclose(object sender, FormClosedEventArgs e)
        {
            FORMCLOSED.Invoke(sender, e);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string phone = txtCode.Text.Trim();
            string pwd = txtPassword.Text.Trim();
            string changeID = "";
            DBHelper helper = new DBHelper("mysql");
            string sql = "select phone, pwd, id from user where phone='"+phone+"'";
            IDataReader reader = helper.DataRead(sql);
            if(reader!=null && reader.Read())
            {
                userPhoe = reader.GetString(0);
                userPwd = reader.GetString(1);
                changeID = reader.GetString(2);
            }
            helper.DisConnection();
            if (pwd==userPwd && phone==userPhoe)
            {
                FormLogin.userID = changeID;
                MessageBox.Show("切换成功！");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtPassword.Text = "";
            txtCode.Focus();
        }

        private void btnDestory_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认删除？", "警告", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                gbTip.Visible = true;
                gbChange.Visible = false;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string content = txtCopy.Text.Trim();
            if (content == "我已知悉注销后果，继续执行注销操作。")
            {
                DBHelper helper = new DBHelper("mysql");
                string sql = "delete from user where id='" + FormLogin.userID + "'";
                long res = helper.Update(sql);
                helper.DisConnection();
                sql = "delete from deposit_record where id ='" + FormLogin.userID + "'";
                long res1 = helper.Update(sql);
                MessageBox.Show("res: "+res+"\nres1: "+res1);
                if (res >= 0 && res1 >= 0)
                {
                    MessageBox.Show("你的账号已从该星球消失，请使用另一个账号登陆！");
                    this.FormClosed += new FormClosedEventHandler(formclose);
                    this.Close();

                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            gbTip.Visible = false;
            txtCopy.Text = "";
            gbChange.Visible = true;
        }
    }
}
