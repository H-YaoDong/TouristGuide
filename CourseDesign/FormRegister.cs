using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CourseDesign
{
    public partial class FormRegister : Form
    {
        //使用单例模式只创建出一个注册窗口
        private static FormRegister singleRegister = null;
        string sql;
        DBHelper helper = new DBHelper("mysql");

        //设置保存用户头像的路径
        public static string avatarPath = @"C:\Users\HYaoDong\Desktop\CourseDesign\CourseDesign\images\userAvatar";
        //保存用户选择的头像所在路径
        string chosedPath;
        //保存用户选择的头像的文件名
        string avatarName;
        //保存用户头像的后缀名
        string extension;

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

            //还要判断用户是否选择了头像
            if (avatar.BackgroundImage == null)
            {
                MessageBox.Show("请设置一个用户头像！");
            }
            else
            {
                if (pwd != repwd)
                {
                    MessageBox.Show("两次输入的密码不一致，请重新输入！");
                    txtPassword.Text = "";
                    txtRePassword.Text = "";
                    txtPassword.Focus();
                }
                else
                {
                    if (!File.Exists(avatarPath + "\\" + avatarName))
                    {
                        avatarName = DateTime.Now.ToFileTime().ToString()+extension;
                        File.Copy(chosedPath, avatarPath + "\\" + avatarName);
                    }

                    sql = "insert into user(name, phone, pwd, avatarName) values ('" + name + "', '" + phone + "',  '" + pwd + "', '"+ avatarName + "')";
                    long res = helper.Update(sql);
                    if (res > 0)
                    {
                        MessageBox.Show("注册成功！");
                        txtCode.Text = "";
                        txtName.Text = "";
                        txtPassword.Text = "";
                        txtRePassword.Text = "";
                        avatar.BackgroundImage = null;
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FormLogin.GetSingle().Activate();
            Close();
        }

        private void btnChoseAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择头像";
            ofd.InitialDirectory = avatarPath;
            ofd.ShowDialog();

            chosedPath = ofd.FileName;
            avatarName = System.IO.Path.GetFileName(chosedPath);
            extension = System.IO.Path.GetExtension(chosedPath);
            //在注册页面设置头像，只有当用户选择了头像才能把头像加载到头像的位置上
            if(chosedPath!="")
                avatar.BackgroundImage = Image.FromFile(chosedPath);

        }
    }
}
