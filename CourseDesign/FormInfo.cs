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
        bool txtDepositHasText = false;

        DBHelper helper = new DBHelper("mysql");
        IDataReader reader;
        string phone;
        string id;
        string sql;
        string name;
        float amount;
        string avatarName;
        string avatarPath;
        string chosedPath;
        string extension;
        DataTable table;
        DateTime dt;
        string curTime;

        //使用自定义的事件委托
        public delegate void MyEvent(string path, string name);
        public event MyEvent ChangeAvatar;

        public FormInfo()
        {
            InitializeComponent();
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
            //phone = ((FormMain)this.MdiParent).id;  怎么没用啊？
            id = FormLogin.userID;
            sql = "select name, phone, avatarName, amount from user where id='" + id + "'";
            reader = helper.DataRead(sql);
            //获取保存头像的路径
            avatarPath = FormRegister.avatarPath;
            if (reader != null && reader.Read())
            {
                name = reader.GetString(0);
                phone = reader.GetString(1);
                avatarName = reader.GetString(2);
                amount = reader.GetFloat(3);
                //在同一个类中用完一次helpgrdRecorder就要将其关闭
                helper.DisConnection();

                pbAvatar.BackgroundImage = Image.FromFile(avatarPath + "\\" + avatarName);
                txtName.Text = name;
                txtPhone.Text = phone;
                txtAmount.Text = amount + "";

                sql = "select d.name, d.phone, d.date, d.addMoney from user u, deposit_record d where u.id = d.id and u.id='" + id + "'";

                table = helper.FillTable(sql);
                grdRecord.DefaultCellStyle.Font = new Font("SimSun", 12.5F, GraphicsUnit.Pixel);
                grdRecord.DataSource = table;

                sql = "select name, money, date, num from consume_record where id = '" + id + "'";
                table = helper.FillTable(sql);
                grVConsume.DefaultCellStyle.Font = new Font("SimSun", 12.5F, GraphicsUnit.Pixel);
                grVConsume.DataSource = table;
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
            if (chosedPath != "")
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
            name = txtName.Text.Trim();
            sql = "update user set name='" + name + "', phone='" + txtPhone.Text.Trim() + "', avatarName='" + avatarName + "' where id='" + id + "'";
            long res = helper.Update(sql);

            if (res > 0)
            {
                MessageBox.Show("信息修改成功！");
                //phone存储更新后的手机号
                phone = txtPhone.Text.Trim();
                //pbAvatar.BackgroundImageChanged += new EventHandler(pbAvatar_BackgroundImageChanged);
                //点击保存后才能修改用户头像，妈的想了我好久
                btnSave.Click += new EventHandler(pbAvatarBackgroundImageChanged);
                ChangeAvatar.Invoke(avatarName, name);
            }
            else
            {
                MessageBox.Show("信息修改失败！");
            }
            txtName.ReadOnly = true;
            txtPhone.ReadOnly = true;
        }


        private void pbAvatarBackgroundImageChanged(object sender, EventArgs e)
        {
            //图片被修改后就抛出该事件
            ChangeAvatar.Invoke(avatarName, name);
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            float addMoney = float.Parse(txtDeposit.Text.Trim());
            sql = "update user set amount = " + (amount + addMoney) + " where id='" + id + "'";
            long res = helper.Update(sql);
            helper.DisConnection();
            if (res > 0)
            {
                amount += addMoney;
                MessageBox.Show("充值成功！当前余额为：" + amount);
                txtAmount.Text = amount + "";
                txtDeposit.Text = "充值金额";
                txtDeposit.ForeColor = Color.LightGray;

                dt = System.DateTime.Now;
                curTime = dt.ToString("yyyy-MM-dd-HH:mm");

                sql = "insert into deposit_record values('" + id + "', '" + name + "', '" + phone + "', '" + curTime + "', '" + addMoney + "')";
                res = helper.Update(sql);
                if (res > 0)
                {
                    //加入行的值的顺序必须和一开始的一样，这个千万别改了。
                    ((DataTable)grdRecord.DataSource).Rows.Add(name, phone, curTime, addMoney);
                }
            }
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            grpData.Visible = true;
            grbConsume.Visible = false;
            btnD.Enabled = false;
            btnC.Enabled = true;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            grbConsume.Visible = true;
            grpData.Visible = false;
            btnD.Enabled = true;
            btnC.Enabled = false;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
       