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
    public partial class FormDelicious : Form
    {
        private static FormDelicious singleDelicious = null;
        public FormDelicious()
        {
            InitializeComponent();
        }
        public static FormDelicious getSingle()
        {
            if(singleDelicious==null || singleDelicious.IsDisposed)
            {
                singleDelicious = new FormDelicious();
            }
            return singleDelicious;
        }

        private void FormDelicious_Load(object sender, EventArgs e)
        {
            string time = "";
            time = System.DateTime.Now.ToString("yyyy-MM-dd-HH:mm");
            MessageBox.Show(time);
        }
    }
}
