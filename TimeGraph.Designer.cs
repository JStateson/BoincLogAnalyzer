
namespace BoincLogAnalyzer
{
    partial class cTimeGraph
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.tgraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_ShowData = new System.Windows.Forms.Button();
            this.cb_ylog = new System.Windows.Forms.CheckBox();
            this.btn_ScrollData = new System.Windows.Forms.Button();
            this.timer_ScrollData = new System.Windows.Forms.Timer(this.components);
            this.btn_Pause = new System.Windows.Forms.Button();
            this.gtv = new System.Windows.Forms.TreeView();
            this.cb_SelData = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_NotepadFile = new System.Windows.Forms.Button();
            this.nudScollCnt = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnAdvFilter = new System.Windows.Forms.Button();
            this.btn_invertFilter = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnPRJ = new System.Windows.Forms.Button();
            this.btnPrjCheck = new System.Windows.Forms.Button();
            this.btnPrjUnc = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_ItemsSelected = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbUseAdvFilter = new System.Windows.Forms.CheckBox();
            this.lblFilterString = new System.Windows.Forms.Label();
            this.pbarLoading = new System.Windows.Forms.ProgressBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnES = new System.Windows.Forms.Button();
            this.btnET = new System.Windows.Forms.Button();
            this.btnCPU = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tgraph)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScollCnt)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tgraph
            // 
            chartArea1.Name = "ChartArea1";
            this.tgraph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.tgraph.Legends.Add(legend1);
            this.tgraph.Location = new System.Drawing.Point(393, 40);
            this.tgraph.Name = "tgraph";
            this.tgraph.Size = new System.Drawing.Size(500, 400);
            this.tgraph.TabIndex = 0;
            this.tgraph.Text = "Time Graph";
            // 
            // btn_ShowData
            // 
            this.btn_ShowData.Location = new System.Drawing.Point(22, 24);
            this.btn_ShowData.Name = "btn_ShowData";
            this.btn_ShowData.Size = new System.Drawing.Size(108, 23);
            this.btn_ShowData.TabIndex = 8;
            this.btn_ShowData.Text = "Show Selected";
            this.toolTip1.SetToolTip(this.btn_ShowData, "You must click this once before the drop donw box is active");
            this.btn_ShowData.UseVisualStyleBackColor = true;
            this.btn_ShowData.Click += new System.EventHandler(this.btn_ShowData_Click);
            // 
            // cb_ylog
            // 
            this.cb_ylog.AutoSize = true;
            this.cb_ylog.Location = new System.Drawing.Point(253, 65);
            this.cb_ylog.Name = "cb_ylog";
            this.cb_ylog.Size = new System.Drawing.Size(99, 17);
            this.cb_ylog.TabIndex = 9;
            this.cb_ylog.Text = "Y axis log scale";
            this.cb_ylog.UseVisualStyleBackColor = true;
            // 
            // btn_ScrollData
            // 
            this.btn_ScrollData.Location = new System.Drawing.Point(48, 48);
            this.btn_ScrollData.Name = "btn_ScrollData";
            this.btn_ScrollData.Size = new System.Drawing.Size(108, 23);
            this.btn_ScrollData.TabIndex = 10;
            this.btn_ScrollData.Text = "Scroll Data";
            this.btn_ScrollData.UseVisualStyleBackColor = true;
            this.btn_ScrollData.Click += new System.EventHandler(this.btn_ScrollData_Click);
            // 
            // timer_ScrollData
            // 
            this.timer_ScrollData.Interval = 150;
            this.timer_ScrollData.Tick += new System.EventHandler(this.timer_ScrollData_Tick);
            // 
            // btn_Pause
            // 
            this.btn_Pause.Enabled = false;
            this.btn_Pause.Location = new System.Drawing.Point(48, 19);
            this.btn_Pause.Name = "btn_Pause";
            this.btn_Pause.Size = new System.Drawing.Size(77, 23);
            this.btn_Pause.TabIndex = 11;
            this.btn_Pause.Text = "Pause";
            this.btn_Pause.UseVisualStyleBackColor = true;
            this.btn_Pause.Click += new System.EventHandler(this.btn_Pause_Click);
            // 
            // gtv
            // 
            this.gtv.CheckBoxes = true;
            this.gtv.Location = new System.Drawing.Point(12, 144);
            this.gtv.Name = "gtv";
            this.gtv.Size = new System.Drawing.Size(340, 257);
            this.gtv.TabIndex = 12;
            this.toolTip1.SetToolTip(this.gtv, "Check or Uncheck desired data view");
            this.gtv.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.gtv_AfterCheck);
            // 
            // cb_SelData
            // 
            this.cb_SelData.FormattingEnabled = true;
            this.cb_SelData.Location = new System.Drawing.Point(22, 62);
            this.cb_SelData.Name = "cb_SelData";
            this.cb_SelData.Size = new System.Drawing.Size(219, 21);
            this.cb_SelData.TabIndex = 13;
            this.cb_SelData.Tag = "xxx";
            this.toolTip1.SetToolTip(this.cb_SelData, "Use up or donw cursor to view next or previous graph");
            this.cb_SelData.SelectedIndexChanged += new System.EventHandler(this.cb_SelData_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn_Pause);
            this.groupBox1.Controls.Add(this.btn_ScrollData);
            this.groupBox1.Location = new System.Drawing.Point(393, 446);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 148);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scroll Controls";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(17, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 26);
            this.label3.TabIndex = 12;
            this.label3.Text = "No filtering done here and\r\nbad points (if any) are shown";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_NotepadFile);
            this.groupBox2.Controls.Add(this.nudScollCnt);
            this.groupBox2.Controls.Add(this.btn_ShowData);
            this.groupBox2.Controls.Add(this.cb_SelData);
            this.groupBox2.Location = new System.Drawing.Point(625, 446);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 148);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Project Select";
            // 
            // btn_NotepadFile
            // 
            this.btn_NotepadFile.Location = new System.Drawing.Point(156, 103);
            this.btn_NotepadFile.Name = "btn_NotepadFile";
            this.btn_NotepadFile.Size = new System.Drawing.Size(75, 23);
            this.btn_NotepadFile.TabIndex = 18;
            this.btn_NotepadFile.Text = "View Data";
            this.toolTip1.SetToolTip(this.btn_NotepadFile, "Uses notepod to view raw data");
            this.btn_NotepadFile.UseVisualStyleBackColor = true;
            this.btn_NotepadFile.Click += new System.EventHandler(this.btn_NotepadFile_Click);
            // 
            // nudScollCnt
            // 
            this.nudScollCnt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudScollCnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudScollCnt.Location = new System.Drawing.Point(199, 19);
            this.nudScollCnt.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudScollCnt.Name = "nudScollCnt";
            this.nudScollCnt.ReadOnly = true;
            this.nudScollCnt.Size = new System.Drawing.Size(42, 27);
            this.nudScollCnt.TabIndex = 17;
            this.toolTip1.SetToolTip(this.nudScollCnt, "How far beyond screen data can plot");
            // 
            // btnAdvFilter
            // 
            this.btnAdvFilter.Location = new System.Drawing.Point(20, 19);
            this.btnAdvFilter.Name = "btnAdvFilter";
            this.btnAdvFilter.Size = new System.Drawing.Size(93, 23);
            this.btnAdvFilter.TabIndex = 0;
            this.btnAdvFilter.Text = "Create / Edit";
            this.toolTip1.SetToolTip(this.btnAdvFilter, "This is applied only when file is opened");
            this.btnAdvFilter.UseVisualStyleBackColor = true;
            this.btnAdvFilter.Click += new System.EventHandler(this.btnAdvFilter_Click);
            // 
            // btn_invertFilter
            // 
            this.btn_invertFilter.Location = new System.Drawing.Point(98, 47);
            this.btn_invertFilter.Name = "btn_invertFilter";
            this.btn_invertFilter.Size = new System.Drawing.Size(75, 23);
            this.btn_invertFilter.TabIndex = 35;
            this.btn_invertFilter.Text = "Invert";
            this.toolTip1.SetToolTip(this.btn_invertFilter, "Invertrs the filter");
            this.btn_invertFilter.UseVisualStyleBackColor = true;
            this.btn_invertFilter.Click += new System.EventHandler(this.btn_invertFilter_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox7.Controls.Add(this.btnAdvFilter);
            this.groupBox7.Location = new System.Drawing.Point(11, 92);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(194, 57);
            this.groupBox7.TabIndex = 32;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Advanced Filter";
            this.toolTip1.SetToolTip(this.groupBox7, "You may want to firest look at the raw data using notepad");
            // 
            // btnPRJ
            // 
            this.btnPRJ.Location = new System.Drawing.Point(6, 83);
            this.btnPRJ.Name = "btnPRJ";
            this.btnPRJ.Size = new System.Drawing.Size(95, 23);
            this.btnPRJ.TabIndex = 0;
            this.btnPRJ.Text = "Project Invert";
            this.toolTip1.SetToolTip(this.btnPRJ, "Invert Project checks");
            this.btnPRJ.UseVisualStyleBackColor = true;
            this.btnPRJ.Click += new System.EventHandler(this.btnPRJ_Click);
            // 
            // btnPrjCheck
            // 
            this.btnPrjCheck.Location = new System.Drawing.Point(6, 50);
            this.btnPrjCheck.Name = "btnPrjCheck";
            this.btnPrjCheck.Size = new System.Drawing.Size(95, 23);
            this.btnPrjCheck.TabIndex = 4;
            this.btnPrjCheck.Text = "Project Check";
            this.toolTip1.SetToolTip(this.btnPrjCheck, "Invert Project checks");
            this.btnPrjCheck.UseVisualStyleBackColor = true;
            this.btnPrjCheck.Click += new System.EventHandler(this.btnPrjCheck_Click);
            // 
            // btnPrjUnc
            // 
            this.btnPrjUnc.Location = new System.Drawing.Point(6, 18);
            this.btnPrjUnc.Name = "btnPrjUnc";
            this.btnPrjUnc.Size = new System.Drawing.Size(95, 23);
            this.btnPrjUnc.TabIndex = 5;
            this.btnPrjUnc.Text = "Project UnChk";
            this.toolTip1.SetToolTip(this.btnPrjUnc, "Invert Project checks");
            this.btnPrjUnc.UseVisualStyleBackColor = true;
            this.btnPrjUnc.Click += new System.EventHandler(this.btnPrjUnc_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tb_ItemsSelected);
            this.groupBox3.Controls.Add(this.btn_invertFilter);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cbUseAdvFilter);
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.lblFilterString);
            this.groupBox3.Location = new System.Drawing.Point(15, 433);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(337, 161);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filters";
            // 
            // tb_ItemsSelected
            // 
            this.tb_ItemsSelected.Location = new System.Drawing.Point(222, 102);
            this.tb_ItemsSelected.Multiline = true;
            this.tb_ItemsSelected.Name = "tb_ItemsSelected";
            this.tb_ItemsSelected.Size = new System.Drawing.Size(100, 38);
            this.tb_ItemsSelected.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(14, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Phrase";
            // 
            // cbUseAdvFilter
            // 
            this.cbUseAdvFilter.AutoSize = true;
            this.cbUseAdvFilter.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cbUseAdvFilter.Enabled = false;
            this.cbUseAdvFilter.Location = new System.Drawing.Point(11, 53);
            this.cbUseAdvFilter.Name = "cbUseAdvFilter";
            this.cbUseAdvFilter.Size = new System.Drawing.Size(70, 17);
            this.cbUseAdvFilter.TabIndex = 33;
            this.cbUseAdvFilter.Text = "Use Filter";
            this.cbUseAdvFilter.UseVisualStyleBackColor = false;
            this.cbUseAdvFilter.CheckedChanged += new System.EventHandler(this.cbUseAdvFilter_CheckedChanged);
            // 
            // lblFilterString
            // 
            this.lblFilterString.AutoSize = true;
            this.lblFilterString.BackColor = System.Drawing.SystemColors.Info;
            this.lblFilterString.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblFilterString.Location = new System.Drawing.Point(67, 16);
            this.lblFilterString.Name = "lblFilterString";
            this.lblFilterString.Size = new System.Drawing.Size(85, 13);
            this.lblFilterString.TabIndex = 1;
            this.lblFilterString.Text = "reserved for filter";
            // 
            // pbarLoading
            // 
            this.pbarLoading.Location = new System.Drawing.Point(12, 407);
            this.pbarLoading.Maximum = 10;
            this.pbarLoading.Name = "pbarLoading";
            this.pbarLoading.Size = new System.Drawing.Size(340, 12);
            this.pbarLoading.Step = 1;
            this.pbarLoading.TabIndex = 18;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnPrjUnc);
            this.groupBox4.Controls.Add(this.btnPrjCheck);
            this.groupBox4.Controls.Add(this.btnES);
            this.groupBox4.Controls.Add(this.btnET);
            this.groupBox4.Controls.Add(this.btnCPU);
            this.groupBox4.Controls.Add(this.btnPRJ);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(208, 118);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Check or Un-Check all";
            // 
            // btnES
            // 
            this.btnES.Location = new System.Drawing.Point(133, 83);
            this.btnES.Name = "btnES";
            this.btnES.Size = new System.Drawing.Size(47, 21);
            this.btnES.TabIndex = 3;
            this.btnES.Text = "ES";
            this.btnES.UseVisualStyleBackColor = true;
            this.btnES.Click += new System.EventHandler(this.btnES_Click);
            // 
            // btnET
            // 
            this.btnET.Location = new System.Drawing.Point(133, 51);
            this.btnET.Name = "btnET";
            this.btnET.Size = new System.Drawing.Size(47, 21);
            this.btnET.TabIndex = 2;
            this.btnET.Text = "ET";
            this.btnET.UseVisualStyleBackColor = true;
            this.btnET.Click += new System.EventHandler(this.btnET_Click);
            // 
            // btnCPU
            // 
            this.btnCPU.Location = new System.Drawing.Point(133, 20);
            this.btnCPU.Name = "btnCPU";
            this.btnCPU.Size = new System.Drawing.Size(47, 21);
            this.btnCPU.TabIndex = 1;
            this.btnCPU.Text = "CPU";
            this.btnCPU.UseVisualStyleBackColor = true;
            this.btnCPU.Click += new System.EventHandler(this.btnCPU_Click);
            // 
            // cTimeGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 617);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.pbarLoading);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gtv);
            this.Controls.Add(this.cb_ylog);
            this.Controls.Add(this.tgraph);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "cTimeGraph";
            this.Text = "TimeGraph";
            ((System.ComponentModel.ISupportInitialize)(this.tgraph)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudScollCnt)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart tgraph;
        private System.Windows.Forms.Button btn_ShowData;
        private System.Windows.Forms.CheckBox cb_ylog;
        private System.Windows.Forms.Button btn_ScrollData;
        private System.Windows.Forms.Timer timer_ScrollData;
        private System.Windows.Forms.Button btn_Pause;
        private System.Windows.Forms.TreeView gtv;
        private System.Windows.Forms.ComboBox cb_SelData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NumericUpDown nudScollCnt;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnAdvFilter;
        private System.Windows.Forms.Label lblFilterString;
        private System.Windows.Forms.CheckBox cbUseAdvFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_invertFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_NotepadFile;
        private System.Windows.Forms.ProgressBar pbarLoading;
        private System.Windows.Forms.TextBox tb_ItemsSelected;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnCPU;
        private System.Windows.Forms.Button btnPRJ;
        private System.Windows.Forms.Button btnET;
        private System.Windows.Forms.Button btnES;
        private System.Windows.Forms.Button btnPrjCheck;
        private System.Windows.Forms.Button btnPrjUnc;
    }
}