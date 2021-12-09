namespace Mine_sweeper
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Appearance = new System.Windows.Forms.ToolStripDropDownButton();
            this.boxColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.resetButton = new System.Windows.Forms.Button();
            this.Bamount = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Appearance});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1172, 40);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Appearance
            // 
            this.Appearance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Appearance.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boxColorToolStripMenuItem});
            this.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("Appearance.Image")));
            this.Appearance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Appearance.Name = "Appearance";
            this.Appearance.Size = new System.Drawing.Size(145, 34);
            this.Appearance.Text = "Appearance";
            // 
            // boxColorToolStripMenuItem
            // 
            this.boxColorToolStripMenuItem.Name = "boxColorToolStripMenuItem";
            this.boxColorToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.boxColorToolStripMenuItem.Text = "Box Color";
            this.boxColorToolStripMenuItem.Click += new System.EventHandler(this.boxColorToolStripMenuItem_Click);
            // 
            // resetButton
            // 
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.resetButton.Location = new System.Drawing.Point(513, 150);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(100, 100);
            this.resetButton.TabIndex = 1;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // Bamount
            // 
            this.Bamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.14286F);
            this.Bamount.Location = new System.Drawing.Point(93, 150);
            this.Bamount.Name = "Bamount";
            this.Bamount.Size = new System.Drawing.Size(100, 100);
            this.Bamount.TabIndex = 2;
            this.Bamount.Text = "70";
            this.Bamount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer
            // 
            this.timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.1429F);
            this.timer.Location = new System.Drawing.Point(944, 150);
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(149, 100);
            this.timer.TabIndex = 3;
            this.timer.Text = "000";
            this.timer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 1449);
            this.Controls.Add(this.timer);
            this.Controls.Add(this.Bamount);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minesweeper";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton Appearance;
        private System.Windows.Forms.ToolStripMenuItem boxColorToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label Bamount;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label timer;
    }
}

