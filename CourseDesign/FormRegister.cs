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
    public partial class FormRegister : Form
    {
        private static FormRegister singleRegister = null;
        string sql;
        DBHelper helper = new DBHelper("mysql");
        public FormRegister()
        {
            InitializeComponent();
        }
        public static FormRegister GetSingle()
        {
            if(singleRegister==null || singleRegister.IsDisposed)
                singleRegister = new FormRegister();
            return singleRegister;
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLogin.GetSingle().Activate();
            Close();
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string phone = txtCode.Text.Trim();
            string pwd = txtPassword.Text.Trim();
            string repwd = txtRePassword.Text.Trim();
            if (pwd != repwd)
            {
                MessageBox.Show("两次输入的密码不一致，请重新输入！");
                txtPassword.Text = "";
                txtRePassword.Text = "";
                txtPassword.Focus();
            }
            else
            {
                sql = "insert into user values ('"+name+"', '"+phone+"',  '"+pwd+"')";
                long res = helper.Update(sql);
                if (res > 0)
                {
                    MessageBox.Show("注册成功！");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FormLogin.GetSingle().Activate();
            Close();
        }
    }
}
