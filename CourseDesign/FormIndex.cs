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
    public partial class FormIndex : Form
    {
        private static FormIndex FrmIndex = null;
        public FormIndex()
        {
            InitializeComponent();
            
        }
        public static FormIndex getSingle()
        {
            if(FrmIndex==null || FrmIndex.IsDisposed)
                FrmIndex = new FormIndex();
            return FrmIndex;
        }


    }
}
