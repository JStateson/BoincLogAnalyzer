
namespace BoincLogAnalyzer
{
    partial class PauseExit
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnOkExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(31, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "All data has been plotted\r\nClick OK to exit this popup\r\nand clear the graph";
            // 
            // btnOkExit
            // 
            this.btnOkExit.Location = new System.Drawing.Point(59, 82);
            this.btnOkExit.Name = "btnOkExit";
            this.btnOkExit.Size = new System.Drawing.Size(75, 23);
            this.btnOkExit.TabIndex = 2;
            this.btnOkExit.Text = "OK";
            this.btnOkExit.UseVisualStyleBackColor = true;
            this.btnOkExit.Click += new System.EventHandler(this.btnOkExit_Click);
            // 
            // PauseExit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 130);
            this.Controls.Add(this.btnOkExit);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PauseExit";
            this.Text = "PauseExit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOkExit;
    }
}