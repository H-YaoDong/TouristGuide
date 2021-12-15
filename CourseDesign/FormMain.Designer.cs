
namespace CourseDesign
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lbUserName = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.pbAvatar = new System.Windows.Forms.PictureBox();
            this.pbAvatarBg = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mmuIndex = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mmuView = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mmuSearchRoute = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mmuDelicacies = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mmuInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mmuSystem = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatarBg)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.BackColor = System.Drawing.Color.Transparent;
            this.lbUserName.Font = new System.Drawing.Font("SimHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUserName.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbUserName.Location = new System.Drawing.Point(36, 184);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(79, 21);
            this.lbUserName.TabIndex = 7;
            this.lbUserName.Text = "用户名";
            // 
            // panel
            // 
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(150, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(828, 652);
            this.panel.TabIndex = 9;
            // 
            // pbAvatar
            // 
            this.pbAvatar.BackColor = System.Drawing.Color.Transparent;
            this.pbAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbAvatar.Location = new System.Drawing.Point(15, 30);
            this.pbAvatar.Name = "pbAvatar";
            this.pbAvatar.Size = new System.Drawing.Size(120, 120);
            this.pbAvatar.TabIndex = 4;
            this.pbAvatar.TabStop = false;
            // 
            // pbAvatarBg
            // 
            this.pbAvatarBg.BackColor = System.Drawing.Color.Transparent;
            this.pbAvatarBg.Location = new System.Drawing.Point(7, 21);
            this.pbAvatarBg.Name = "pbAvatarBg";
            this.pbAvatarBg.Size = new System.Drawing.Size(136, 138);
            this.pbAvatarBg.TabIndex = 5;
            this.pbAvatarBg.TabStop = false;
            this.pbAvatarBg.Paint += new System.Windows.Forms.PaintEventHandler(this.pbAvatarBg_Paint);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmuIndex,
            this.toolStripSeparator2,
            this.mmuView,
            this.toolStripSeparator5,
            this.mmuSearchRoute,
            this.toolStripSeparator3,
            this.mmuDelicacies,
            this.toolStripSeparator1,
            this.mmuInfo,
            this.toolStripSeparator4,
            this.mmuSystem});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(150, 652);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mmuIndex
            // 
            this.mmuIndex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mmuIndex.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mmuIndex.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mmuIndex.Image = ((System.Drawing.Image)(resources.GetObject("mmuIndex.Image")));
            this.mmuIndex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mmuIndex.Margin = new System.Windows.Forms.Padding(0, 250, 0, 2);
            this.mmuIndex.Name = "mmuIndex";
            this.mmuIndex.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.mmuIndex.Size = new System.Drawing.Size(149, 35);
            this.mmuIndex.Text = "    首页    >    ";
            this.mmuIndex.Click += new System.EventHandler(this.mmuIndex_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, -5, 0, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // mmuView
            // 
            this.mmuView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mmuView.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mmuView.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mmuView.Image = ((System.Drawing.Image)(resources.GetObject("mmuView.Image")));
            this.mmuView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mmuView.Name = "mmuView";
            this.mmuView.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.mmuView.Size = new System.Drawing.Size(149, 35);
            this.mmuView.Text = "    当地风景    >    ";
            this.mmuView.Click += new System.EventHandler(this.mmuView_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Margin = new System.Windows.Forms.Padding(0, -5, 0, 0);
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(149, 6);
            // 
            // mmuSearchRoute
            // 
            this.mmuSearchRoute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mmuSearchRoute.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mmuSearchRoute.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mmuSearchRoute.Image = ((System.Drawing.Image)(resources.GetObject("mmuSearchRoute.Image")));
            this.mmuSearchRoute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mmuSearchRoute.Name = "mmuSearchRoute";
            this.mmuSearchRoute.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.mmuSearchRoute.Size = new System.Drawing.Size(149, 35);
            this.mmuSearchRoute.Text = "    查询路线    >    ";
            this.mmuSearchRoute.ToolTipText = "    特色美食    >    ";
            this.mmuSearchRoute.Click += new System.EventHandler(this.mmuSearchRoute_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(0, -5, 0, 0);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // mmuDelicacies
            // 
            this.mmuDelicacies.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mmuDelicacies.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mmuDelicacies.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mmuDelicacies.Image = ((System.Drawing.Image)(resources.GetObject("mmuDelicacies.Image")));
            this.mmuDelicacies.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mmuDelicacies.Name = "mmuDelicacies";
            this.mmuDelicacies.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.mmuDelicacies.Size = new System.Drawing.Size(149, 35);
            this.mmuDelicacies.Text = "    特色小吃    >    ";
            this.mmuDelicacies.ToolTipText = "    特色美食    >    ";
            this.mmuDelicacies.Click += new System.EventHandler(this.mmuDelicacies_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, -5, 0, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // mmuInfo
            // 
            this.mmuInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mmuInfo.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mmuInfo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mmuInfo.Image = ((System.Drawing.Image)(resources.GetObject("mmuInfo.Image")));
            this.mmuInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mmuInfo.Name = "mmuInfo";
            this.mmuInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.mmuInfo.Size = new System.Drawing.Size(149, 35);
            this.mmuInfo.Text = "    个人信息    >    ";
            this.mmuInfo.Click += new System.EventHandler(this.mmuInfo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(0, -5, 0, 0);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // mmuSystem
            // 
            this.mmuSystem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mmuSystem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mmuSystem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mmuSystem.Image = ((System.Drawing.Image)(resources.GetObject("mmuSystem.Image")));
            this.mmuSystem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mmuSystem.Name = "mmuSystem";
            this.mmuSystem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.mmuSystem.Size = new System.Drawing.Size(149, 35);
            this.mmuSystem.Text = "    系统设置    >    ";
            this.mmuSystem.ToolTipText = "    系统设置    >    ";
            this.mmuSystem.Click += new System.EventHandler(this.mmuSystem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 652);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.pbAvatar);
            this.Controls.Add(this.pbAvatarBg);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatarBg)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mmuIndex;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton mmuSearchRoute;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton mmuDelicacies;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.PictureBox pbAvatar;
        private System.Windows.Forms.PictureBox pbAvatarBg;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.ToolStripButton mmuInfo;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolStripButton mmuSystem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton mmuView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}