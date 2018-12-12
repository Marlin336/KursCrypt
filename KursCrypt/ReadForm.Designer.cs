namespace KursCrypt
{
    partial class ReadForm
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
            this.b_attach = new System.Windows.Forms.Button();
            this.b_reply = new System.Windows.Forms.Button();
            this.tb_from = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_subject = new System.Windows.Forms.TextBox();
            this.tb_opentext = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // b_attach
            // 
            this.b_attach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_attach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.b_attach.Location = new System.Drawing.Point(12, 429);
            this.b_attach.Name = "b_attach";
            this.b_attach.Size = new System.Drawing.Size(152, 34);
            this.b_attach.TabIndex = 17;
            this.b_attach.Text = "Прикрепления";
            this.b_attach.UseVisualStyleBackColor = true;
            // 
            // b_reply
            // 
            this.b_reply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_reply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.b_reply.Location = new System.Drawing.Point(514, 429);
            this.b_reply.Name = "b_reply";
            this.b_reply.Size = new System.Drawing.Size(152, 34);
            this.b_reply.TabIndex = 16;
            this.b_reply.Text = "Ответить";
            this.b_reply.UseVisualStyleBackColor = true;
            // 
            // tb_from
            // 
            this.tb_from.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_from.Location = new System.Drawing.Point(70, 6);
            this.tb_from.Name = "tb_from";
            this.tb_from.ReadOnly = true;
            this.tb_from.Size = new System.Drawing.Size(596, 20);
            this.tb_from.TabIndex = 15;
            this.tb_from.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "От:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Тема:";
            // 
            // tb_subject
            // 
            this.tb_subject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_subject.Location = new System.Drawing.Point(70, 32);
            this.tb_subject.Name = "tb_subject";
            this.tb_subject.ReadOnly = true;
            this.tb_subject.Size = new System.Drawing.Size(596, 20);
            this.tb_subject.TabIndex = 12;
            this.tb_subject.TabStop = false;
            // 
            // tb_opentext
            // 
            this.tb_opentext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_opentext.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_opentext.Location = new System.Drawing.Point(12, 58);
            this.tb_opentext.Multiline = true;
            this.tb_opentext.Name = "tb_opentext";
            this.tb_opentext.ReadOnly = true;
            this.tb_opentext.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_opentext.Size = new System.Drawing.Size(654, 365);
            this.tb_opentext.TabIndex = 11;
            // 
            // ReadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 475);
            this.Controls.Add(this.b_attach);
            this.Controls.Add(this.b_reply);
            this.Controls.Add(this.tb_from);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_subject);
            this.Controls.Add(this.tb_opentext);
            this.Name = "ReadForm";
            this.Text = "Чтение сообщения";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_attach;
        private System.Windows.Forms.Button b_reply;
        private System.Windows.Forms.TextBox tb_from;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_subject;
        private System.Windows.Forms.TextBox tb_opentext;
    }
}