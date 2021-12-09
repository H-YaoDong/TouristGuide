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
    public partial class FormView : Form
    {
        int numPic;
        int cur = 0;
        string[] images;
        string[] articles;


        public FormView()
        {
            InitializeComponent();
        }

        private void FormView_Load(object sender, EventArgs e)
        {
            string path = @"C:\Users\HYaoDong\Desktop\CourseDesign\CourseDesign\images\vew1";
            images = Directory.GetFiles(path);
            pbPicture.BackgroundImage = Image.FromFile(images[cur]);
            numPic = images.Length;
            labelAll.Text = numPic + "";
            labelCur.Text = "1";

            path = @"C:\Users\HYaoDong\Desktop\CourseDesign\CourseDesign\images\article";
            articles = Directory.GetFiles(path);
            rtbArticle.Text = File.ReadAllText(articles[cur]);
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (cur == 0)
            {
                cur = numPic - 1;
            }
            else
            {
                cur -= 1;
            }
            pbPicture.BackgroundImage = Image.FromFile(images[cur]);
            rtbArticle.Text = File.ReadAllText(articles[cur]);
            labelCur.Text = (cur+1) + "";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (cur == numPic - 1)
            {
                cur = 0;
            }
            else
            {
                cur += 1;
            }
            pbPicture.BackgroundImage = Image.FromFile(images[cur]);
            rtbArticle.Text = File.ReadAllText(articles[cur]);
            labelCur.Text = (cur+1) + "";
        }
    }
}
