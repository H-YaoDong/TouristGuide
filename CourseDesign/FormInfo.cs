using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CourseDesign
{
    public partial class FormInfo : Form
    {
        private static FormInfo singleInfo = null;
        bool txtDepositHasText = false;

        DBHelper helper = new DBHelper("mysql");
        IDataReader reader;
        string phone;
        string sql;
        string name;
        float amount;
        string avatarName;
        string avatarPath;
        string chosedPath;
        string extension;

        
        //使用自定义的事件委托
        public delegate void MyEvent(string path);
        public event MyEvent ChangeAvatar;

        public FormInfo()
        {
            InitializeComponent();
        }
        public static FormInfo getSingle()
        {
            if (singleInfo == null || singleInfo.IsDisposed)
                singleInfo = new FormInfo();
            return singleInfo;
        }

        //给用户提供充值的提示文字
        private void txtDeposit_Leave(object sender, EventArgs e)
        {
            if (txtDeposit.Text == "")
            {
                txtDeposit.Text = "充值金额";
                txtDeposit.ForeColor = Color.LightGray;
                txtDepositHasText = false;
            }
            else
                txtDepositHasText = true;
        }

        private void txtDeposit_Enter(object sender, EventArgs e)
        {
            if (!txtDepositHasText)
            {
                txtDeposit.Text = "";
                txtDeposit.ForeColor = Color.Red;
            }
        }

        private void FormInfo_Load(object sender, EventArgs e)
        {

            //phone = ((FormMain)this.MdiParent).phone;  怎么没用啊？
            phone = FormLogin.userPhone;
            sql = "select name, avatarName, amount from user where phone='" + phone + "'";
            reader = helper.DataRead(sql);
            //获取保存头像的路径
            avatarPath = FormRegister.avatarPath;
            if(reader!=null && reader.Read()){
                name = reader.GetString(0);
                avatarName = reader.GetString(1);
                amount = reader.GetFloat(2);
                //好像在同一个类中用完一次heler就要将其关闭
                helper.DisConnection();

                pbAvatar.BackgroundImage = Image.FromFile(avatarPath+"\\"+avatarName);
                txtName.Text = name;
                txtPhone.Text = phone;
                txtAmount.Text = amount+"";
            }
            else
            {
                MessageBox.Show("无法读取用户信息？这是没有预料到的bug");
            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtName.ReadOnly = false;
            txtPhone.ReadOnly = false;
            btnChangeAvatar.Visible = true;
        }

        private void btnChangeAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择头像";
            ofd.InitialDirectory = avatarPath;
            ofd.ShowDialog();

            chosedPath = ofd.FileName;
            avatarName = System.IO.Path.GetFileName(chosedPath);
            extension = System.IO.Path.GetExtension(chosedPath);

            pbAvatar.BackgroundImage = Image.FromFile(chosedPath);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //如果保存头像的文件夹不存用户选定的头像，那么就将用户选中的头像添加到保存头像的文件夹中
            if (!File.Exists(avatarPath + "\\" + avatarName))
            {
                avatarName = DateTime.Now.ToFileTime().ToString() + extension;
                File.Copy(chosedPath, avatarPath + "\\" + avatarName);
            }
            sql = "update user set name='"+txtName.Text.Trim()+"', phone='" + txtPhone.Text.Trim() + "', avatarName='" + avatarName + "' where phone='" + phone + "'";
            long res = helper.Update(sql);

            if (res > 0)
            {
                MessageBox.Show("信息修改成功！");
                //pbAvatar.BackgroundImageChanged += new EventHandler(pbAvatar_BackgroundImageChanged);
                //点击保存后才能修改用户头像，妈的想了我好久
                btnSave.Click += new EventHandler(pbAvatarBackgroundImageChanged);
                ChangeAvatar.Invoke(avatarName);
            }
            else
            {
                MessageBox.Show("信息修改失败！");
            }
        }

        private void pbAvatarBackgroundImageChanged(object sender, EventArgs e)
        {
            //图片被修改后就抛出该事件
            ChangeAvatar.Invoke(avatarName);
        }
    }
}
