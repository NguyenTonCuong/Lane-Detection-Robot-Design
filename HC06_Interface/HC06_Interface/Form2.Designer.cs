namespace HC06_Interface
{
    partial class Form2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbKhoangCach = new System.Windows.Forms.Label();
            this.btnNgatKetNoi = new System.Windows.Forms.Button();
            this.btnKetNoi = new System.Windows.Forms.Button();
            this.cbxTenCongCom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbMotor = new System.Windows.Forms.Label();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.btnCheDo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbKhoangCach);
            this.groupBox1.Controls.Add(this.btnNgatKetNoi);
            this.groupBox1.Controls.Add(this.btnKetNoi);
            this.groupBox1.Controls.Add(this.cbxTenCongCom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 175);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // lbKhoangCach
            // 
            this.lbKhoangCach.BackColor = System.Drawing.Color.White;
            this.lbKhoangCach.Location = new System.Drawing.Point(18, 130);
            this.lbKhoangCach.Name = "lbKhoangCach";
            this.lbKhoangCach.Size = new System.Drawing.Size(233, 42);
            this.lbKhoangCach.TabIndex = 4;
            this.lbKhoangCach.Text = "Khoảng Cách ???";
            // 
            // btnNgatKetNoi
            // 
            this.btnNgatKetNoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNgatKetNoi.Enabled = false;
            this.btnNgatKetNoi.Location = new System.Drawing.Point(129, 69);
            this.btnNgatKetNoi.Name = "btnNgatKetNoi";
            this.btnNgatKetNoi.Size = new System.Drawing.Size(109, 31);
            this.btnNgatKetNoi.TabIndex = 3;
            this.btnNgatKetNoi.Text = "Ngắt Kết Nối";
            this.btnNgatKetNoi.UseVisualStyleBackColor = true;
            this.btnNgatKetNoi.Click += new System.EventHandler(this.btnNgatKetNoi_Click);
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKetNoi.Location = new System.Drawing.Point(6, 69);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(103, 31);
            this.btnKetNoi.TabIndex = 2;
            this.btnKetNoi.Text = "Kết Nối";
            this.btnKetNoi.UseVisualStyleBackColor = true;
            this.btnKetNoi.Click += new System.EventHandler(this.btnKetNoi_Click);
            // 
            // cbxTenCongCom
            // 
            this.cbxTenCongCom.FormattingEnabled = true;
            this.cbxTenCongCom.Location = new System.Drawing.Point(129, 25);
            this.cbxTenCongCom.Name = "cbxTenCongCom";
            this.cbxTenCongCom.Size = new System.Drawing.Size(109, 24);
            this.cbxTenCongCom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Cổng Com";
            // 
            // lbMotor
            // 
            this.lbMotor.AutoSize = true;
            this.lbMotor.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbMotor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMotor.Location = new System.Drawing.Point(81, 339);
            this.lbMotor.Name = "lbMotor";
            this.lbMotor.Size = new System.Drawing.Size(92, 24);
            this.lbMotor.TabIndex = 1;
            this.lbMotor.Text = "Stt Motor";
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(268, 4);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(960, 382);
            this.zedGraphControl1.TabIndex = 2;
            // 
            // btnCheDo
            // 
            this.btnCheDo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheDo.Location = new System.Drawing.Point(63, 197);
            this.btnCheDo.Name = "btnCheDo";
            this.btnCheDo.Size = new System.Drawing.Size(109, 31);
            this.btnCheDo.TabIndex = 4;
            this.btnCheDo.Text = "Scroll";
            this.btnCheDo.UseVisualStyleBackColor = true;
            this.btnCheDo.Click += new System.EventHandler(this.btnCheDo_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 399);
            this.Controls.Add(this.btnCheDo);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.lbMotor);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DỮ LIỆU KHOẢNG CÁCH SRF05";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Shown += new System.EventHandler(this.Form2_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbKhoangCach;
        private System.Windows.Forms.Button btnNgatKetNoi;
        private System.Windows.Forms.Button btnKetNoi;
        private System.Windows.Forms.ComboBox cbxTenCongCom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbMotor;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Button btnCheDo;
    }
}

