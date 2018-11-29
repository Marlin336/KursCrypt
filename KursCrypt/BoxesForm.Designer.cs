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
            this.b_add = new System.Windows.Forms.Button();
            this.b_del = new System.Windows.Forms.Button();
            this.grid_boxes = new System.Windows.Forms.DataGridView();
            this.id_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid_boxes)).BeginInit();
            this.SuspendLayout();
            // 
            // b_add
            // 
            this.b_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_add.ForeColor = System.Drawing.Color.ForestGreen;
            this.b_add.Location = new System.Drawing.Point(12, 240);
            this.b_add.Name = "b_add";
            this.b_add.Size = new System.Drawing.Size(107, 47);
            this.b_add.TabIndex = 2;
            this.b_add.Text = "+";
            this.b_add.UseVisualStyleBackColor = true;
            this.b_add.Click += new System.EventHandler(this.b_add_Click);
            // 
            // b_del
            // 
            this.b_del.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_del.ForeColor = System.Drawing.Color.Red;
            this.b_del.Location = new System.Drawing.Point(123, 240);
            this.b_del.Name = "b_del";
            this.b_del.Size = new System.Drawing.Size(107, 47);
            this.b_del.TabIndex = 3;
            this.b_del.TabStop = false;
            this.b_del.Text = "-";
            this.b_del.UseVisualStyleBackColor = true;
            this.b_del.Click += new System.EventHandler(this.b_del_Click);
            // 
            // grid_boxes
            // 
            this.grid_boxes.AllowUserToAddRows = false;
            this.grid_boxes.AllowUserToDeleteRows = false;
            this.grid_boxes.AllowUserToResizeColumns = false;
            this.grid_boxes.AllowUserToResizeRows = false;
            this.grid_boxes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_boxes.ColumnHeadersVisible = false;
            this.grid_boxes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_col,
            this.email_col});
            this.grid_boxes.Location = new System.Drawing.Point(13, 13);
            this.grid_boxes.MultiSelect = false;
            this.grid_boxes.Name = "grid_boxes";
            this.grid_boxes.ReadOnly = true;
            this.grid_boxes.RowHeadersVisible = false;
            this.grid_boxes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid_boxes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_boxes.Size = new System.Drawing.Size(217, 220);
            this.grid_boxes.TabIndex = 4;
            this.grid_boxes.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grid_boxes_RowsAdded);
            this.grid_boxes.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.grid_boxes_RowsRemoved);
            // 
            // id_col
            // 
            this.id_col.Frozen = true;
            this.id_col.HeaderText = "ID";
            this.id_col.Name = "id_col";
            this.id_col.ReadOnly = true;
            this.id_col.Visible = false;
            // 
            // email_col
            // 
            this.email_col.HeaderText = "Ящик";
            this.email_col.Name = "email_col";
            this.email_col.ReadOnly = true;
            this.email_col.Width = 215;
            // 
            // BoxesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 299);
            this.Controls.Add(this.grid_boxes);
            this.Controls.Add(this.b_del);
            this.Controls.Add(this.b_add);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BoxesForm";
            this.Text = "Ящики";
            ((System.ComponentModel.ISupportInitialize)(this.grid_boxes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button b_add;
        private System.Windows.Forms.Button b_del;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn email_col;
        public System.Windows.Forms.DataGridView grid_boxes;
    }
}