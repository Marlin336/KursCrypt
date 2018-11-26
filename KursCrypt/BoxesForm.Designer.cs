namespace KursCrypt
{
    partial class BoxesForm
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
            this.lb_boxes = new System.Windows.Forms.ListBox();
            this.b_add = new System.Windows.Forms.Button();
            this.b_del = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_boxes
            // 
            this.lb_boxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_boxes.FormattingEnabled = true;
            this.lb_boxes.ItemHeight = 16;
            this.lb_boxes.Location = new System.Drawing.Point(12, 12);
            this.lb_boxes.Name = "lb_boxes";
            this.lb_boxes.Size = new System.Drawing.Size(216, 212);
            this.lb_boxes.TabIndex = 1;
            this.lb_boxes.TabStop = false;
            this.lb_boxes.SelectedIndexChanged += new System.EventHandler(this.lb_boxes_SelectedIndexChanged);
            // 
            // b_add
            // 
            this.b_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_add.ForeColor = System.Drawing.Color.ForestGreen;
            this.b_add.Location = new System.Drawing.Point(12, 240);
            this.b_add.Name = "b_add";
            this.b_add.Size = new System.Drawing.Size(105, 45);
            this.b_add.TabIndex = 2;
            this.b_add.Text = "+";
            this.b_add.UseVisualStyleBackColor = true;
            this.b_add.Click += new System.EventHandler(this.b_add_Click);
            // 
            // b_del
            // 
            this.b_del.Enabled = false;
            this.b_del.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_del.ForeColor = System.Drawing.Color.Red;
            this.b_del.Location = new System.Drawing.Point(123, 240);
            this.b_del.Name = "b_del";
            this.b_del.Size = new System.Drawing.Size(105, 47);
            this.b_del.TabIndex = 3;
            this.b_del.Text = "-";
            this.b_del.UseVisualStyleBackColor = true;
            // 
            // BoxesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 299);
            this.Controls.Add(this.b_del);
            this.Controls.Add(this.b_add);
            this.Controls.Add(this.lb_boxes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BoxesForm";
            this.Text = "Ящики";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button b_add;
        private System.Windows.Forms.Button b_del;
        public System.Windows.Forms.ListBox lb_boxes;
    }
}