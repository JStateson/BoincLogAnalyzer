
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.tgraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_ShowData = new System.Windows.Forms.Button();
            this.cb_ylog = new System.Windows.Forms.CheckBox();
            this.btn_ScrollData = new System.Windows.Forms.Button();
            this.timer_ScrollData = new System.Windows.Forms.Timer(this.components);
            this.btn_Pause = new System.Windows.Forms.Button();
            this.gtv = new System.Windows.Forms.TreeView();
            this.cb_SelData = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.nudScollCnt = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.tgraph)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScollCnt)).BeginInit();
            this.SuspendLayout();
            // 
            // tgraph
            // 
            chartArea3.Name = "ChartArea1";
            this.tgraph.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.tgraph.Legends.Add(legend3);
            this.tgraph.Location = new System.Drawing.Point(289, 12);
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
            this.cb_ylog.Location = new System.Drawing.Point(26, 30);
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
            this.gtv.Location = new System.Drawing.Point(12, 65);
            this.gtv.Name = "gtv";
            this.gtv.Size = new System.Drawing.Size(198, 257);
            this.gtv.TabIndex = 12;
            this.toolTip1.SetToolTip(this.gtv, "Check or Uncheck desired data view");
            this.gtv.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.gtv_AfterCheck);
            this.gtv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.gtv_AfterSelect);
            // 
            // cb_SelData
            // 
            this.cb_SelData.FormattingEnabled = true;
            this.cb_SelData.Location = new System.Drawing.Point(22, 72);
            this.cb_SelData.Name = "cb_SelData";
            this.cb_SelData.Size = new System.Drawing.Size(219, 21);
            this.cb_SelData.TabIndex = 13;
            this.toolTip1.SetToolTip(this.cb_SelData, "Use up or donw cursor to view next or previous graph");
            this.cb_SelData.SelectedIndexChanged += new System.EventHandler(this.cb_SelData_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 347);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Use checkbox to select graphs";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Pause);
            this.groupBox1.Controls.Add(this.btn_ScrollData);
            this.groupBox1.Location = new System.Drawing.Point(289, 418);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 124);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scroll Controls";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudScollCnt);
            this.groupBox2.Controls.Add(this.btn_ShowData);
            this.groupBox2.Controls.Add(this.cb_SelData);
            this.groupBox2.Location = new System.Drawing.Point(521, 418);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 124);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Project Select";
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
            this.nudScollCnt.ValueChanged += new System.EventHandler(this.nudScollCnt_ValueChanged);
            // 
            // cTimeGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 554);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gtv);
            this.Controls.Add(this.cb_ylog);
            this.Controls.Add(this.tgraph);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "cTimeGraph";
            this.Text = "TimeGraph";
            ((System.ComponentModel.ISupportInitialize)(this.tgraph)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudScollCnt)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NumericUpDown nudScollCnt;
    }
}