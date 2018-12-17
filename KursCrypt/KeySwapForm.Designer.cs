namespace KursCrypt
{
    partial class KeySwapForm
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
            this.tb_email = new System.Windows.Forms.TextBox();
            this.b_sentreq = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "E-mail:";
            // 
            // tb_email
            // 
            this.tb_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_email.Location = new System.Drawing.Point(75, 9);
            this.tb_email.Name = "tb_email";
            this.tb_email.Size = new System.Drawing.Size(267, 20);
            this.tb_email.TabIndex = 16;
            this.tb_email.TabStop = false;
            // 
            // b_sentreq
            // 
            this.b_sentreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.b_sentreq.Location = new System.Drawing.Point(91, 40);
            this.b_sentreq.Name = "b_sentreq";
            this.b_sentreq.Size = new System.Drawing.Size(170, 34);
            this.b_sentreq.TabIndex = 17;
            this.b_sentreq.Text = "Отправить запрос";
            this.b_sentreq.UseVisualStyleBackColor = true;
            this.b_sentreq.Click += new System.EventHandler(this.b_sentreq_Click);
            // 
            // KeySwapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 81);
            this.Controls.Add(this.b_sentreq);
            this.Controls.Add(this.tb_email);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "KeySwapForm";
            this.Text = "Запрос на обмен ключами шифрования";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_email;
        private System.Windows.Forms.Button b_sentreq;
    }
}