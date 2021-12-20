
namespace BoincLogAnalyzer
{
    partial class BoincLogAnalyzer
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_PlotEVA = new System.Windows.Forms.Button();
            this.btn_RunAnal = new System.Windows.Forms.Button();
            this.lb_DataDir = new System.Windows.Forms.Label();
            this.clb_lognames = new System.Windows.Forms.CheckedListBox();
            this.btn_FetchLogs = new System.Windows.Forms.Button();
            this.gb_Reveal = new System.Windows.Forms.GroupBox();
            this.rbShowStats = new System.Windows.Forms.RadioButton();
            this.rbExpandAll = new System.Windows.Forms.RadioButton();
            this.rbShowUnk = new System.Windows.Forms.RadioButton();
            this.rbShowHis = new System.Windows.Forms.RadioButton();
            this.rbShowAll = new System.Windows.Forms.RadioButton();
            this.tv = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gb_Reveal.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.btn_PlotEVA);
            this.groupBox1.Controls.Add(this.btn_RunAnal);
            this.groupBox1.Controls.Add(this.lb_DataDir);
            this.groupBox1.Controls.Add(this.clb_lognames);
            this.groupBox1.Controls.Add(this.btn_FetchLogs);
            this.groupBox1.Location = new System.Drawing.Point(21, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(598, 429);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log File Selections";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(17, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 52);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fetch the logs you are interested in.\r\nCheck the box for the data you want analyz" +
    "ed.\r\nThen click \"Analyze Selected\". May take a while\r\nSelect \"Show Graphics\" whe" +
    "n it becomes enabled.";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(270, 423);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(8, 4);
            this.listBox1.TabIndex = 5;
            // 
            // btn_PlotEVA
            // 
            this.btn_PlotEVA.Enabled = false;
            this.btn_PlotEVA.Location = new System.Drawing.Point(20, 323);
            this.btn_PlotEVA.Name = "btn_PlotEVA";
            this.btn_PlotEVA.Size = new System.Drawing.Size(147, 23);
            this.btn_PlotEVA.TabIndex = 4;
            this.btn_PlotEVA.Text = "Show Graphics";
            this.btn_PlotEVA.UseVisualStyleBackColor = true;
            this.btn_PlotEVA.Click += new System.EventHandler(this.btn_PlotEVA_Click);
            // 
            // btn_RunAnal
            // 
            this.btn_RunAnal.Enabled = false;
            this.btn_RunAnal.Location = new System.Drawing.Point(20, 282);
            this.btn_RunAnal.Name = "btn_RunAnal";
            this.btn_RunAnal.Size = new System.Drawing.Size(100, 23);
            this.btn_RunAnal.TabIndex = 3;
            this.btn_RunAnal.Text = "Analyze Selected";
            this.btn_RunAnal.UseVisualStyleBackColor = true;
            this.btn_RunAnal.Click += new System.EventHandler(this.btn_RunAnal_Click);
            // 
            // lb_DataDir
            // 
            this.lb_DataDir.AutoSize = true;
            this.lb_DataDir.Location = new System.Drawing.Point(141, 36);
            this.lb_DataDir.Name = "lb_DataDir";
            this.lb_DataDir.Size = new System.Drawing.Size(115, 13);
            this.lb_DataDir.TabIndex = 2;
            this.lb_DataDir.Text = "c:\\ProgramData\\Boinc";
            // 
            // clb_lognames
            // 
            this.clb_lognames.FormattingEnabled = true;
            this.clb_lognames.Location = new System.Drawing.Point(20, 138);
            this.clb_lognames.Name = "clb_lognames";
            this.clb_lognames.Size = new System.Drawing.Size(386, 94);
            this.clb_lognames.TabIndex = 1;
            this.clb_lognames.DoubleClick += new System.EventHandler(this.clb_lognames_DoubleClick);
            // 
            // btn_FetchLogs
            // 
            this.btn_FetchLogs.Location = new System.Drawing.Point(20, 31);
            this.btn_FetchLogs.Name = "btn_FetchLogs";
            this.btn_FetchLogs.Size = new System.Drawing.Size(100, 23);
            this.btn_FetchLogs.TabIndex = 0;
            this.btn_FetchLogs.Text = "Fetch Logs";
            this.btn_FetchLogs.UseVisualStyleBackColor = true;
            this.btn_FetchLogs.Click += new System.EventHandler(this.btn_FetchLogs_Click);
            // 
            // gb_Reveal
            // 
            this.gb_Reveal.Controls.Add(this.rbShowStats);
            this.gb_Reveal.Controls.Add(this.rbExpandAll);
            this.gb_Reveal.Controls.Add(this.rbShowUnk);
            this.gb_Reveal.Controls.Add(this.rbShowHis);
            this.gb_Reveal.Controls.Add(this.rbShowAll);
            this.gb_Reveal.Location = new System.Drawing.Point(13, 28);
            this.gb_Reveal.Name = "gb_Reveal";
            this.gb_Reveal.Size = new System.Drawing.Size(195, 151);
            this.gb_Reveal.TabIndex = 3;
            this.gb_Reveal.TabStop = false;
            this.gb_Reveal.Text = "Reveal Project / Apps";
            // 
            // rbShowStats
            // 
            this.rbShowStats.AutoSize = true;
            this.rbShowStats.Enabled = false;
            this.rbShowStats.Location = new System.Drawing.Point(18, 111);
            this.rbShowStats.Name = "rbShowStats";
            this.rbShowStats.Size = new System.Drawing.Size(163, 17);
            this.rbShowStats.TabIndex = 4;
            this.rbShowStats.TabStop = true;
            this.rbShowStats.Tag = "4";
            this.rbShowStats.Text = "Show elapsed [num-Avg(std)]";
            this.rbShowStats.UseVisualStyleBackColor = true;
            this.rbShowStats.Visible = false;
            this.rbShowStats.CheckedChanged += new System.EventHandler(this.rbShowStats_CheckedChanged);
            // 
            // rbExpandAll
            // 
            this.rbExpandAll.AutoSize = true;
            this.rbExpandAll.Location = new System.Drawing.Point(18, 42);
            this.rbExpandAll.Name = "rbExpandAll";
            this.rbExpandAll.Size = new System.Drawing.Size(61, 17);
            this.rbExpandAll.TabIndex = 3;
            this.rbExpandAll.Tag = "1";
            this.rbExpandAll.Text = "Expand";
            this.rbExpandAll.UseVisualStyleBackColor = true;
            this.rbExpandAll.CheckedChanged += new System.EventHandler(this.rbExpandAll_CheckedChanged);
            // 
            // rbShowUnk
            // 
            this.rbShowUnk.AutoSize = true;
            this.rbShowUnk.Location = new System.Drawing.Point(18, 88);
            this.rbShowUnk.Name = "rbShowUnk";
            this.rbShowUnk.Size = new System.Drawing.Size(139, 17);
            this.rbShowUnk.TabIndex = 2;
            this.rbShowUnk.Tag = "3";
            this.rbShowUnk.Text = "Show unknown projects";
            this.rbShowUnk.UseVisualStyleBackColor = true;
            this.rbShowUnk.CheckedChanged += new System.EventHandler(this.rbShowUnk_CheckedChanged);
            // 
            // rbShowHis
            // 
            this.rbShowHis.AutoSize = true;
            this.rbShowHis.Location = new System.Drawing.Point(18, 65);
            this.rbShowHis.Name = "rbShowHis";
            this.rbShowHis.Size = new System.Drawing.Size(66, 17);
            this.rbShowHis.TabIndex = 1;
            this.rbShowHis.Tag = "2";
            this.rbShowHis.Text = "Show All";
            this.rbShowHis.UseVisualStyleBackColor = true;
            this.rbShowHis.CheckedChanged += new System.EventHandler(this.rbShowHis_CheckedChanged);
            // 
            // rbShowAll
            // 
            this.rbShowAll.AutoSize = true;
            this.rbShowAll.Checked = true;
            this.rbShowAll.Location = new System.Drawing.Point(18, 19);
            this.rbShowAll.Name = "rbShowAll";
            this.rbShowAll.Size = new System.Drawing.Size(65, 17);
            this.rbShowAll.TabIndex = 0;
            this.rbShowAll.TabStop = true;
            this.rbShowAll.Tag = "0";
            this.rbShowAll.Text = "Collapse";
            this.rbShowAll.UseVisualStyleBackColor = true;
            this.rbShowAll.CheckedChanged += new System.EventHandler(this.rbShowAll_CheckedChanged);
            // 
            // tv
            // 
            this.tv.Location = new System.Drawing.Point(229, 19);
            this.tv.Name = "tv";
            this.tv.Size = new System.Drawing.Size(239, 421);
            this.tv.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gb_Reveal);
            this.groupBox2.Controls.Add(this.tv);
            this.groupBox2.Location = new System.Drawing.Point(641, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(474, 466);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "List of Projects";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(434, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "Double click an item\r\nto view in notepad";
            // 
            // BoincLogAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 589);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BoincLogAnalyzer";
            this.Text = "Boinc Log Analyzer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_Reveal.ResumeLayout(false);
            this.gb_Reveal.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox clb_lognames;
        private System.Windows.Forms.Button btn_FetchLogs;
        private System.Windows.Forms.Label lb_DataDir;
        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.GroupBox gb_Reveal;
        private System.Windows.Forms.RadioButton rbShowStats;
        private System.Windows.Forms.RadioButton rbExpandAll;
        private System.Windows.Forms.RadioButton rbShowUnk;
        private System.Windows.Forms.RadioButton rbShowHis;
        private System.Windows.Forms.RadioButton rbShowAll;
        private System.Windows.Forms.Button btn_RunAnal;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_PlotEVA;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

