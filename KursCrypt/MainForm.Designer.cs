﻿namespace KursCrypt
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
            this.label2 = new System.Windows.Forms.Label();
            this.tb_subject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_from = new System.Windows.Forms.TextBox();
            this.b_reply = new System.Windows.Forms.Button();
            this.b_attach = new System.Windows.Forms.Button();
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
            this.tb_opentext.Location = new System.Drawing.Point(287, 89);
            this.tb_opentext.Multiline = true;
            this.tb_opentext.Name = "tb_opentext";
            this.tb_opentext.ReadOnly = true;
            this.tb_opentext.Size = new System.Drawing.Size(546, 380);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(288, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Тема:";
            // 
            // tb_subject
            // 
            this.tb_subject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_subject.Location = new System.Drawing.Point(345, 63);
            this.tb_subject.Name = "tb_subject";
            this.tb_subject.ReadOnly = true;
            this.tb_subject.Size = new System.Drawing.Size(488, 20);
            this.tb_subject.TabIndex = 5;
            this.tb_subject.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(288, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "От:";
            // 
            // tb_from
            // 
            this.tb_from.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_from.Location = new System.Drawing.Point(345, 37);
            this.tb_from.Name = "tb_from";
            this.tb_from.ReadOnly = true;
            this.tb_from.Size = new System.Drawing.Size(488, 20);
            this.tb_from.TabIndex = 8;
            this.tb_from.TabStop = false;
            // 
            // b_reply
            // 
            this.b_reply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_reply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.b_reply.Location = new System.Drawing.Point(733, 475);
            this.b_reply.Name = "b_reply";
            this.b_reply.Size = new System.Drawing.Size(100, 34);
            this.b_reply.TabIndex = 9;
            this.b_reply.Text = "Ответить";
            this.b_reply.UseVisualStyleBackColor = true;
            this.b_reply.Click += new System.EventHandler(this.b_reply_Click);
            // 
            // b_attach
            // 
            this.b_attach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_attach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.b_attach.Location = new System.Drawing.Point(287, 475);
            this.b_attach.Name = "b_attach";
            this.b_attach.Size = new System.Drawing.Size(119, 34);
            this.b_attach.TabIndex = 10;
            this.b_attach.Text = "Прикрепления";
            this.b_attach.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 521);
            this.Controls.Add(this.b_attach);
            this.Controls.Add(this.b_reply);
            this.Controls.Add(this.tb_from);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_subject);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_subject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_from;
        private System.Windows.Forms.Button b_reply;
        private System.Windows.Forms.Button b_attach;
    }
}