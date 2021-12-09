using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace CourseDesign
{
    public partial class FormMain : Form
    {
        FormLogin frmLogin = FormLogin.GetSingle();
        FormIndex frmIndex;
        FormSearchRoute frmSR;
        FormDelicious frmDel;
        FormSystem frmSys;
        FormView frmView;

        FormInfo frmInfo;
        //保存当前用户的手机号码
        //保存用户id
        string id;
        DBHelper helper = new DBHelper("mysql");
        IDataReader reader;
        string sql;
        string name;
        //设置默认头像
        string avatar = "default.png";

        public static bool change = false;
        public FormMain()
        {
            InitializeComponent();
        }

        private void square2round(PictureBox pb)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(pb.ClientRectangle);
            Region region = new Region(gp);
            pb.Region = region;
            gp.Dispose();
            region.Dispose();
        }

        private void MyLoad()
        {
            id = FormLogin.userID;
            sql = "select name, avatarName from user where id='" + id + "'";
            reader = helper.DataRead(sql);
            if (reader != null && reader.Read())
            {
                name = reader.GetString(0);
                avatar = reader.GetString(1);
            }
            bool b = reader == null;
            pbAvatar.BackgroundImage = Image.FromFile(FormRegister.avatarPath + "\\" + avatar);
            lbUserName.Text = name;
            helper.DisConnection();

            //渐变+圆形头像
            pbAvatarBg.Invalidate();
            square2round(pbAvatarBg);
            square2round(pbAvatar);

            //不知道为啥不加这个也会有bug，缝缝补补，太难了
            this.IsMdiContainer = true;

            //加载首页
            frmIndex = FormIndex.getSingle();
            frmIndex.MdiParent = this;
            frmIndex.TopLevel = false;
            frmIndex.Dock = DockStyle.Fill;
            panel.Controls.Add(frmIndex);
            frmIndex.Show();

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            frmLogin.ShowDialog();
            MyLoad();

        }

        private void pbAvatarBg_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Color FColor = Color.Pink;
            Color TColor = Color.White; ;
            Brush b = new LinearGradientBrush(pbAvatarBg.ClientRectangle, FColor, TColor, LinearGradientMode.ForwardDiagonal);
            g.FillRectangle(b, pbAvatarBg.ClientRectangle);
        }

        private void mmuInfo_Click(object sender, EventArgs e)
        {
            frmInfo = new FormInfo();
            frmInfo.ChangeAvatar += new FormInfo.MyEvent(changeAvatar);
            frmInfo.MdiParent = this;
            frmInfo.TopLevel = false;
            frmInfo.Dock = DockStyle.Fill;
            frmInfo.Show();
            //有了Clear()就可以把panel之前的子窗口清空。每次就只会有一个Info窗体。
            panel.Controls.Clear();
            panel.Controls.Add(frmInfo);
        }

        private void changeAvatar(string name, string uname)
        {
            //当第一次进入个人信息页面时，用户的头像从无到有，就会抛出自定义的事件
            MessageBox.Show("为什么会执行这里啊？？");
            pbAvatar.BackgroundImage = Image.FromFile(FormRegister.avatarPath+"\\"+name);
            lbUserName.Text = uname;
        }

        private void mmuIndex_Click(object sender, EventArgs e)
        {
            frmIndex.Show();
            panel.Controls.Clear();
            panel.Controls.Add(frmIndex);
        }

        private void mmuSearchRoute_Click(object sender, EventArgs e)
        {
            frmSR = FormSearchRoute.getSingle();
            frmSR.MdiParent = this;
            frmSR.TopLevel = false;
            frmSR.Dock = DockStyle.Fill;
            frmSR.Show();
            panel.Controls.Clear();
            panel.Controls.Add(frmSR);
        }

        private void mmuDelicacies_Click(object sender, EventArgs e)
        {
            frmDel = FormDelicious.getSingle();
            frmDel.MdiParent = this;
            frmDel.TopLevel = false;
            frmDel.Dock = DockStyle.Fill;
            frmDel.Show();
            panel.Controls.Clear();
            panel.Controls.Add(frmDel);
        }

        private void mmuSystem_Click(object sender, EventArgs e)
        {
            frmSys = new FormSystem();
            frmSys.CHANGE += new EventHandler(change_User);
            frmSys.FORMCLOSED += new FormClosedEventHandler(close_Main);
            frmSys.MdiParent = this;
            frmSys.TopLevel = false;
            frmSys.Dock = DockStyle.Fill;
            frmSys.Show();
            panel.Controls.Clear();
            panel.Controls.Add(frmSys);
            
        }

        private void close_Main(object sender, EventArgs e)
        {
            Process process = Process.GetCurrentProcess();
            process.Close();
            Application.Restart();
        }

        private void change_User(object sender, EventArgs e)
        {
            MyLoad();
        }

        private void mmuView_Click(object sender, EventArgs e)
        {
            frmView = new FormView();
            frmView.MdiParent = this;
            frmView.TopLevel = false;
            frmView.Dock = DockStyle.Fill;
            frmView.Show();
            panel.Controls.Clear();
            panel.Controls.Add(frmView);
        }
    }
}
