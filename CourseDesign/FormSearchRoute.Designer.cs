
namespace CourseDesign
{
    partial class FormSearchRoute
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
            this.cbEndStation = new System.Windows.Forms.ComboBox();
            this.cbStartStation = new System.Windows.Forms.ComboBox();
            this.cbEndRoute = new System.Windows.Forms.ComboBox();
            this.cbStartRoute = new System.Windows.Forms.ComboBox();
            this.pbRoute = new System.Windows.Forms.PictureBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.labelPrice = new System.Windows.Forms.Label();
            this.btnBuy = new System.Windows.Forms.Button();
            this.rtbRoute = new System.Windows.Forms.RichTextBox();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbRoute = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbRoute)).BeginInit();
            this.gbRoute.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbEndStation
            // 
            this.cbEndStation.FormattingEnabled = true;
            this.cbEndStation.Items.AddRange(new object[] {
            "双港站",
            "孔目湖站",
            "长江路站",
            "珠江路站",
            "庐山南大道站",
            "绿茵路站",
            "卫东站",
            "地铁大厦站",
            "秋水广场站",
            "滕王阁站",
            "万寿宫站",
            "八一馆站",
            "八一广场站",
            "丁公路北站",
            "师大南路站",
            "彭家桥站",
            "谢家村站",
            "青山湖大道站",
            "高新大道站",
            "艾溪湖西站",
            "艾溪湖东站",
            "太子殿站",
            "奥体中心站",
            "瑶湖西站"});
            this.cbEndStation.Location = new System.Drawing.Point(109, 39);
            this.cbEndStation.Name = "cbEndStation";
            this.cbEndStation.Size = new System.Drawing.Size(121, 24);
            this.cbEndStation.TabIndex = 13;
            this.cbEndStation.Text = "双港站";
            this.cbEndStation.SelectedIndexChanged += new System.EventHandler(this.cbEndStation_SelectedIndexChanged);
            // 
            // cbStartStation
            // 
            this.cbStartStation.FormattingEnabled = true;
            this.cbStartStation.ItemHeight = 16;
            this.cbStartStation.Items.AddRange(new object[] {
            "双港站",
            "孔目湖站",
            "长江路站",
            "珠江路站",
            "庐山南大道站",
            "绿茵路站",
            "卫东站",
            "地铁大厦站",
            "秋水广场站",
            "滕王阁站",
            "万寿宫站",
            "八一馆站",
            "八一广场站",
            "丁公路北站",
            "师大南路站",
            "彭家桥站",
            "谢家村站",
            "青山湖大道站",
            "高新大道站",
            "艾溪湖西站",
            "艾溪湖东站",
            "太子殿站",
            "奥体中心站",
            "瑶湖西站"});
            this.cbStartStation.Location = new System.Drawing.Point(109, 44);
            this.cbStartStation.Name = "cbStartStation";
            this.cbStartStation.Size = new System.Drawing.Size(121, 24);
            this.cbStartStation.TabIndex = 12;
            this.cbStartStation.Text = "双港站";
            this.cbStartStation.SelectedIndexChanged += new System.EventHandler(this.cbStartStation_SelectedIndexChanged);
            // 
            // cbEndRoute
            // 
            this.cbEndRoute.FormattingEnabled = true;
            this.cbEndRoute.Items.AddRange(new object[] {
            "一号线",
            "二号线",
            "三号线"});
            this.cbEndRoute.Location = new System.Drawing.Point(6, 39);
            this.cbEndRoute.Name = "cbEndRoute";
            this.cbEndRoute.Size = new System.Drawing.Size(83, 24);
            this.cbEndRoute.TabIndex = 11;
            this.cbEndRoute.Text = "一号线";
            this.cbEndRoute.SelectedIndexChanged += new System.EventHandler(this.cbEndRoute_SelectedIndexChanged);
            // 
            // cbStartRoute
            // 
            this.cbStartRoute.FormattingEnabled = true;
            this.cbStartRoute.Items.AddRange(new object[] {
            "一号线",
            "二号线",
            "三号线"});
            this.cbStartRoute.Location = new System.Drawing.Point(6, 44);
            this.cbStartRoute.Name = "cbStartRoute";
            this.cbStartRoute.Size = new System.Drawing.Size(83, 24);
            this.cbStartRoute.TabIndex = 8;
            this.cbStartRoute.Text = "一号线";
            this.cbStartRoute.SelectedIndexChanged += new System.EventHandler(this.cbStartRoute_SelectedIndexChanged);
            // 
            // pbRoute
            // 
            this.pbRoute.BackgroundImage = global::CourseDesign.Properties.Resources.route;
            this.pbRoute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbRoute.Location = new System.Drawing.Point(29, 115);
            this.pbRoute.Name = "pbRoute";
            this.pbRoute.Size = new System.Drawing.Size(650, 467);
            this.pbRoute.TabIndex = 7;
            this.pbRoute.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("YouYuan", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(748, 386);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 29);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "票价查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("YouYuan", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPrice.ForeColor = System.Drawing.Color.Red;
            this.labelPrice.Location = new System.Drawing.Point(879, 390);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(52, 19);
            this.labelPrice.TabIndex = 15;
            this.labelPrice.Text = "0 元";
            // 
            // btnBuy
            // 
            this.btnBuy.Font = new System.Drawing.Font("YouYuan", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBuy.Location = new System.Drawing.Point(748, 487);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(96, 29);
            this.btnBuy.TabIndex = 18;
            this.btnBuy.Text = "购买此票";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // rtbRoute
            // 
            this.rtbRoute.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbRoute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbRoute.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbRoute.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.rtbRoute.Location = new System.Drawing.Point(3, 25);
            this.rtbRoute.Name = "rtbRoute";
            this.rtbRoute.Size = new System.Drawing.Size(978, 72);
            this.rtbRoute.TabIndex = 22;
            this.rtbRoute.Text = "";
            // 
            // txtDistance
            // 
            this.txtDistance.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDistance.ForeColor = System.Drawing.SystemColors.Highlight;
            this.txtDistance.Location = new System.Drawing.Point(827, 439);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(113, 21);
            this.txtDistance.TabIndex = 23;
            this.txtDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("YouYuan", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(745, 441);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "旅途距离";
            // 
            // gbRoute
            // 
            this.gbRoute.Controls.Add(this.rtbRoute);
            this.gbRoute.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbRoute.Location = new System.Drawing.Point(29, 602);
            this.gbRoute.Name = "gbRoute";
            this.gbRoute.Size = new System.Drawing.Size(984, 100);
            this.gbRoute.TabIndex = 25;
            this.gbRoute.TabStop = false;
            this.gbRoute.Text = "路线";
            this.gbRoute.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Location = new System.Drawing.Point(28, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 5);
            this.panel1.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SimSun", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(24, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 48);
            this.label5.TabIndex = 26;
            this.label5.Text = "路线查询";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbStartStation);
            this.groupBox1.Controls.Add(this.cbStartRoute);
            this.groupBox1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(726, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 103);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "起始站";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbEndRoute);
            this.groupBox2.Controls.Add(this.cbEndStation);
            this.groupBox2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(726, 252);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 102);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "终点站";
            // 
            // FormSearchRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 730);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gbRoute);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDistance);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.pbRoute);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSearchRoute";
            this.Load += new System.EventHandler(this.FormSearchRoute_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbRoute)).EndInit();
            this.gbRoute.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbEndStation;
        private System.Windows.Forms.ComboBox cbStartStation;
        private System.Windows.Forms.ComboBox cbEndRoute;
        private System.Windows.Forms.ComboBox cbStartRoute;
        private System.Windows.Forms.PictureBox pbRoute;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.RichTextBox rtbRoute;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.GroupBox gbRoute;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}