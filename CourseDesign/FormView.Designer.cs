
namespace CourseDesign
{
    partial class FormView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pbPicture = new System.Windows.Forms.PictureBox();
            this.gbContent = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelCur = new System.Windows.Forms.Label();
            this.labelAll = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.rtbArticle = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).BeginInit();
            this.gbContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Location = new System.Drawing.Point(46, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 5);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(35, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 48);
            this.label1.TabIndex = 2;
            this.label1.Text = "当地风景";
            // 
            // pbPicture
            // 
            this.pbPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPicture.Location = new System.Drawing.Point(104, 20);
            this.pbPicture.Name = "pbPicture";
            this.pbPicture.Size = new System.Drawing.Size(600, 330);
            this.pbPicture.TabIndex = 0;
            this.pbPicture.TabStop = false;
            // 
            // gbContent
            // 
            this.gbContent.Controls.Add(this.label4);
            this.gbContent.Controls.Add(this.labelCur);
            this.gbContent.Controls.Add(this.labelAll);
            this.gbContent.Controls.Add(this.btnNext);
            this.gbContent.Controls.Add(this.btnPre);
            this.gbContent.Controls.Add(this.rtbArticle);
            this.gbContent.Controls.Add(this.pbPicture);
            this.gbContent.Location = new System.Drawing.Point(134, 122);
            this.gbContent.Name = "gbContent";
            this.gbContent.Size = new System.Drawing.Size(785, 541);
            this.gbContent.TabIndex = 4;
            this.gbContent.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(427, 502);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "/";
            // 
            // labelCur
            // 
            this.labelCur.AutoSize = true;
            this.labelCur.Location = new System.Drawing.Point(392, 504);
            this.labelCur.Name = "labelCur";
            this.labelCur.Size = new System.Drawing.Size(41, 12);
            this.labelCur.TabIndex = 5;
            this.labelCur.Text = "label3";
            // 
            // labelAll
            // 
            this.labelAll.AutoSize = true;
            this.labelAll.Location = new System.Drawing.Point(442, 504);
            this.labelAll.Name = "labelAll";
            this.labelAll.Size = new System.Drawing.Size(41, 12);
            this.labelAll.TabIndex = 4;
            this.labelAll.Text = "label2";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(514, 496);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 28);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "下一张";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPre
            // 
            this.btnPre.Location = new System.Drawing.Point(259, 496);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(77, 28);
            this.btnPre.TabIndex = 2;
            this.btnPre.Text = "上一张";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // rtbArticle
            // 
            this.rtbArticle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbArticle.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbArticle.Location = new System.Drawing.Point(104, 376);
            this.rtbArticle.Name = "rtbArticle";
            this.rtbArticle.Size = new System.Drawing.Size(600, 94);
            this.rtbArticle.TabIndex = 1;
            this.rtbArticle.Text = "";
            // 
            // FormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 724);
            this.Controls.Add(this.gbContent);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormView";
            this.Text = "FormView";
            this.Load += new System.EventHandler(this.FormView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).EndInit();
            this.gbContent.ResumeLayout(false);
            this.gbContent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbPicture;
        private System.Windows.Forms.GroupBox gbContent;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.RichTextBox rtbArticle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelCur;
        private System.Windows.Forms.Label labelAll;
    }
}