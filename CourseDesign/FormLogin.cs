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
    public partial class FormLogin : Form
    {
        FormRegister register;
        private static FormLogin singleLogin=null;
        string sql;
        DBHelper helper = new DBHelper("mysql");
        string userName;
        IDataReader reader;
        bool success = false;
        public static string userPhone;
        public FormLogin()
        {
            InitializeComponent();
        }
        public static FormLogin GetSingle()
        {
            if(singleLogin==null || singleLogin.IsDisposed)
                singleLogin = new FormLogin();
            return singleLogin;
        }

        private void linkRegist_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            register = FormRegister.GetSingle();
            register.Show();
            register.Activate();
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            //success 作为标识符用来防止登陆成功后窗口关闭触发程序退出事件。
            if (!success)
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string phone = txtCode.Text.Trim();
            string pwd = txtPassword.Text.Trim();
            sql = "select name, phone, pwd from user where phone = '" + phone + "'";
            reader = helper.DataRead(sql);
            if(reader!=null && reader.Read())
            {
                if(phone==reader.GetString(1) && pwd == reader.GetString(2))
                {
                    success = true;
                    userName = reader.GetString(0);
                    userPhone = phone;
                    Close();
                }
            }
            else
            {
                MessageBox.Show("登录失败，请输入正确信息！");
                txtCode.Focus();
            }
            reader.Close();
            helper.DisConnection();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!success)
            {
                Application.Exit();
            }
        }
    }
}
