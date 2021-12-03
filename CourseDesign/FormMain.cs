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
        FormLogin frmLogin = FormLogin.GetSingle();
        string phone = FormLogin.userPhone;
        DBHelper helper = new DBHelper("mysql");
        IDataReader reader;
        string sql;
        string name;
        string avatar;
        public FormMain()
        {
            InitializeComponent();
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
            MessageBox.Show(sql);
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
    }
}
