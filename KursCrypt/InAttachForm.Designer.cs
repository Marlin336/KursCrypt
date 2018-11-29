namespace KursCrypt
{
    partial class InAttachForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.list = new System.Windows.Forms.DataGridView();
            this.attach_fileDialog = new System.Windows.Forms.SaveFileDialog();
            this.id_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ext_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.download_coll = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.list)).BeginInit();
            this.SuspendLayout();
            // 
            // list
            // 
            this.list.AllowUserToAddRows = false;
            this.list.AllowUserToDeleteRows = false;
            this.list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_col,
            this.name_col,
            this.ext_col,
            this.size_col,
            this.download_coll});
            this.list.Cursor = System.Windows.Forms.Cursors.Default;
            this.list.Location = new System.Drawing.Point(12, 12);
            this.list.MultiSelect = false;
            this.list.Name = "list";
            this.list.ReadOnly = true;
            this.list.RowHeadersVisible = false;
            this.list.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.list.Size = new System.Drawing.Size(577, 150);
            this.list.TabIndex = 8;
            this.list.TabStop = false;
            this.list.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.list_CellContentClick);
            // 
            // id_col
            // 
            this.id_col.Frozen = true;
            this.id_col.HeaderText = "ID";
            this.id_col.Name = "id_col";
            this.id_col.ReadOnly = true;
            this.id_col.Visible = false;
            // 
            // name_col
            // 
            this.name_col.Frozen = true;
            this.name_col.HeaderText = "Имя файла";
            this.name_col.Name = "name_col";
            this.name_col.ReadOnly = true;
            this.name_col.Width = 300;
            // 
            // ext_col
            // 
            this.ext_col.Frozen = true;
            this.ext_col.HeaderText = "Тип файла";
            this.ext_col.Name = "ext_col";
            this.ext_col.ReadOnly = true;
            // 
            // size_col
            // 
            this.size_col.Frozen = true;
            this.size_col.HeaderText = "Размер (КБ)";
            this.size_col.Name = "size_col";
            this.size_col.ReadOnly = true;
            // 
            // download_coll
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.download_coll.DefaultCellStyle = dataGridViewCellStyle1;
            this.download_coll.Frozen = true;
            this.download_coll.HeaderText = "Загрузить";
            this.download_coll.Name = "download_coll";
            this.download_coll.ReadOnly = true;
            this.download_coll.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.download_coll.Text = "↓";
            this.download_coll.UseColumnTextForButtonValue = true;
            this.download_coll.Width = 75;
            // 
            // InAttachForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 173);
            this.Controls.Add(this.list);
            this.Name = "InAttachForm";
            this.Text = "Прикрепления";
            ((System.ComponentModel.ISupportInitialize)(this.list)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView list;
        private System.Windows.Forms.SaveFileDialog attach_fileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn ext_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn size_col;
        private System.Windows.Forms.DataGridViewButtonColumn download_coll;
    }
}