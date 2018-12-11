namespace KursCrypt
{
    partial class SettingsForm
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
            this.tb_host = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.num_port = new System.Windows.Forms.NumericUpDown();
            this.b_savesettings = new System.Windows.Forms.Button();
            this.b_cancelsettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_port)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_host
            // 
            this.tb_host.Location = new System.Drawing.Point(67, 12);
            this.tb_host.Name = "tb_host";
            this.tb_host.Size = new System.Drawing.Size(182, 20);
            this.tb_host.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Хост:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Порт:";
            // 
            // num_port
            // 
            this.num_port.Location = new System.Drawing.Point(69, 49);
            this.num_port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.num_port.Name = "num_port";
            this.num_port.Size = new System.Drawing.Size(97, 20);
            this.num_port.TabIndex = 5;
            // 
            // b_savesettings
            // 
            this.b_savesettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_savesettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.b_savesettings.Location = new System.Drawing.Point(12, 86);
            this.b_savesettings.Name = "b_savesettings";
            this.b_savesettings.Size = new System.Drawing.Size(119, 34);
            this.b_savesettings.TabIndex = 11;
            this.b_savesettings.Text = "Сохранить";
            this.b_savesettings.UseVisualStyleBackColor = true;
            this.b_savesettings.Click += new System.EventHandler(this.b_savesettings_Click);
            // 
            // b_cancelsettings
            // 
            this.b_cancelsettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_cancelsettings.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_cancelsettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.b_cancelsettings.Location = new System.Drawing.Point(137, 86);
            this.b_cancelsettings.Name = "b_cancelsettings";
            this.b_cancelsettings.Size = new System.Drawing.Size(119, 34);
            this.b_cancelsettings.TabIndex = 12;
            this.b_cancelsettings.Text = "Отмена";
            this.b_cancelsettings.UseVisualStyleBackColor = true;
            this.b_cancelsettings.Click += new System.EventHandler(this.b_cancelsettings_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.b_savesettings;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_cancelsettings;
            this.ClientSize = new System.Drawing.Size(268, 132);
            this.Controls.Add(this.b_cancelsettings);
            this.Controls.Add(this.b_savesettings);
            this.Controls.Add(this.num_port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_host);
            this.Name = "SettingsForm";
            this.Text = "Насторойки";
            ((System.ComponentModel.ISupportInitialize)(this.num_port)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tb_host;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown num_port;
        private System.Windows.Forms.Button b_savesettings;
        private System.Windows.Forms.Button b_cancelsettings;
    }
}