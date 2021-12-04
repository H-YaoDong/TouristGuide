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

namespace CourseDesign
{
    public partial class FormMain : Form
    {
        private static FormMain singleMain = null; 
        FormLogin frmLogin = FormLogin.GetSingle();
        FormInfo frmInfo;
        //保存当前用户的手机号码
        string phone;
        DBHelper helper = new DBHelper("mysql");
        IDataReader reader;
        string sql;
        string name;
        string avatar = "pic1.jpg";
        public FormMain()
        {
            InitializeComponent();
        }
        public static FormMain getSingle()
        {
            if(singleMain==null || singleMain.IsDisposed)
            {
                singleMain = new FormMain();
            }
            return singleMain;
        }

        //将方形图像转换成圆形图像
        private void square2round(PictureBox pb)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(pb.ClientRectangle);
            Region region = new Region(gp);
            pb.Region = region;
            gp.Dispose();
            region.Dispose();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            frmLogin.ShowDialog();

            //根据不同用户选择头像
            phone = FormLogin.userPhone;
            sql = "select name, avatarName from user where phone='" + phone + "'";
            reader = helper.DataRead(sql);
            if (reader != null && reader.Read())
            {
                name = reader.GetString(0);
                avatar = reader.GetString(1);
            }
            pbAvatar.BackgroundImage = Image.FromFile(FormRegister.avatarPath+"\\"+avatar);
            lbUserName.Text = name;
            //渐变+圆形头像
            pbAvatarBg.Invalidate();
            square2round(pbAvatarBg);
            square2round(pbAvatar);
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
            frmInfo = FormInfo.getSingle();
            frmInfo.ChangeAvatar += new FormInfo.MyEvent(changeAvatar);
            frmInfo.MdiParent = this;
            frmInfo.TopLevel = false;
            frmInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(frmInfo);
            frmInfo.Show();
        }

        private void changeAvatar(string name)
        {
            //当第一次进入个人信息页面时，用户的头像从无到有，就会抛出自定义的事件
            MessageBox.Show("为什么会执行这里啊？？");
            pbAvatar.BackgroundImage = Image.FromFile(FormRegister.avatarPath+"\\"+name);
        }
        
    }
}
