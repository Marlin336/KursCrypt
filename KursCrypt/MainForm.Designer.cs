namespace KursCrypt
{
    partial class MainForm
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
            this.lb_mail = new System.Windows.Forms.ListBox();
            this.tb_opentext = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.написатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.почтовыеЯщикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_mail
            // 
            this.lb_mail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_mail.FormattingEnabled = true;
            this.lb_mail.ItemHeight = 16;
            this.lb_mail.Location = new System.Drawing.Point(12, 37);
            this.lb_mail.Name = "lb_mail";
            this.lb_mail.Size = new System.Drawing.Size(269, 468);
            this.lb_mail.TabIndex = 0;
            // 
            // tb_opentext
            // 
            this.tb_opentext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_opentext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_opentext.Location = new System.Drawing.Point(287, 37);
            this.tb_opentext.Multiline = true;
            this.tb_opentext.Name = "tb_opentext";
            this.tb_opentext.ReadOnly = true;
            this.tb_opentext.Size = new System.Drawing.Size(546, 468);
            this.tb_opentext.TabIndex = 1;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.написатьToolStripMenuItem,
            this.почтовыеЯщикиToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(845, 25);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // написатьToolStripMenuItem
            // 
            this.написатьToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.написатьToolStripMenuItem.Name = "написатьToolStripMenuItem";
            this.написатьToolStripMenuItem.Size = new System.Drawing.Size(75, 21);
            this.написатьToolStripMenuItem.Text = "Написать";
            this.написатьToolStripMenuItem.Click += new System.EventHandler(this.написатьToolStripMenuItem_Click);
            // 
            // почтовыеЯщикиToolStripMenuItem
            // 
            this.почтовыеЯщикиToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.почтовыеЯщикиToolStripMenuItem.Name = "почтовыеЯщикиToolStripMenuItem";
            this.почтовыеЯщикиToolStripMenuItem.Size = new System.Drawing.Size(122, 21);
            this.почтовыеЯщикиToolStripMenuItem.Text = "Почтовые ящики";
            this.почтовыеЯщикиToolStripMenuItem.Click += new System.EventHandler(this.почтовыеЯщикиToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 521);
            this.Controls.Add(this.tb_opentext);
            this.Controls.Add(this.lb_mail);
            this.Controls.Add(this.menuStrip);
            this.MinimumSize = new System.Drawing.Size(861, 560);
            this.Name = "MainForm";
            this.Text = "Почтовый клиент v0.1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox lb_mail;
        private System.Windows.Forms.TextBox tb_opentext;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem написатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem почтовыеЯщикиToolStripMenuItem;
    }
}