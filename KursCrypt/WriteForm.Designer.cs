namespace KursCrypt
{
    partial class WriteForm
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.cb_to = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_subject = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.b_send = new System.Windows.Forms.Button();
            this.list = new System.Windows.Forms.DataGridView();
            this.id_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.path_coll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ext_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.b_addattach = new System.Windows.Forms.Button();
            this.b_delattach = new System.Windows.Forms.Button();
            this.attach_fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.допАлгоритмыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CryptItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SignItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.list)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.AcceptsReturn = true;
            this.textBox.AcceptsTab = true;
            this.textBox.AllowDrop = true;
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox.Location = new System.Drawing.Point(12, 82);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(651, 292);
            this.textBox.TabIndex = 3;
            // 
            // cb_to
            // 
            this.cb_to.FormattingEnabled = true;
            this.cb_to.Location = new System.Drawing.Point(68, 29);
            this.cb_to.Name = "cb_to";
            this.cb_to.Size = new System.Drawing.Size(595, 21);
            this.cb_to.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Кому:";
            // 
            // tb_subject
            // 
            this.tb_subject.Location = new System.Drawing.Point(68, 56);
            this.tb_subject.Name = "tb_subject";
            this.tb_subject.Size = new System.Drawing.Size(595, 20);
            this.tb_subject.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Тема:";
            // 
            // b_send
            // 
            this.b_send.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_send.Location = new System.Drawing.Point(520, 463);
            this.b_send.Name = "b_send";
            this.b_send.Size = new System.Drawing.Size(141, 49);
            this.b_send.TabIndex = 5;
            this.b_send.Text = "Отправить";
            this.b_send.UseVisualStyleBackColor = true;
            this.b_send.Click += new System.EventHandler(this.b_send_Click);
            // 
            // list
            // 
            this.list.AllowUserToAddRows = false;
            this.list.AllowUserToDeleteRows = false;
            this.list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_col,
            this.path_coll,
            this.name_col,
            this.ext_col,
            this.size_col});
            this.list.Cursor = System.Windows.Forms.Cursors.Default;
            this.list.Location = new System.Drawing.Point(12, 362);
            this.list.MultiSelect = false;
            this.list.Name = "list";
            this.list.ReadOnly = true;
            this.list.RowHeadersVisible = false;
            this.list.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.list.Size = new System.Drawing.Size(504, 150);
            this.list.TabIndex = 7;
            this.list.TabStop = false;
            // 
            // id_col
            // 
            this.id_col.Frozen = true;
            this.id_col.HeaderText = "ID";
            this.id_col.Name = "id_col";
            this.id_col.ReadOnly = true;
            this.id_col.Visible = false;
            // 
            // path_coll
            // 
            this.path_coll.Frozen = true;
            this.path_coll.HeaderText = "Абсолютный путь";
            this.path_coll.Name = "path_coll";
            this.path_coll.ReadOnly = true;
            this.path_coll.Visible = false;
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
            // b_addattach
            // 
            this.b_addattach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_addattach.Location = new System.Drawing.Point(520, 362);
            this.b_addattach.Name = "b_addattach";
            this.b_addattach.Size = new System.Drawing.Size(141, 46);
            this.b_addattach.TabIndex = 4;
            this.b_addattach.Text = "Добавить файлы";
            this.b_addattach.UseVisualStyleBackColor = true;
            this.b_addattach.Click += new System.EventHandler(this.b_addattach_Click);
            // 
            // b_delattach
            // 
            this.b_delattach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_delattach.Location = new System.Drawing.Point(520, 408);
            this.b_delattach.Name = "b_delattach";
            this.b_delattach.Size = new System.Drawing.Size(141, 49);
            this.b_delattach.TabIndex = 9;
            this.b_delattach.TabStop = false;
            this.b_delattach.Text = "Удалить файл";
            this.b_delattach.UseVisualStyleBackColor = true;
            this.b_delattach.Click += new System.EventHandler(this.b_delattach_Click);
            // 
            // attach_fileDialog
            // 
            this.attach_fileDialog.Multiselect = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.допАлгоритмыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(673, 25);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // допАлгоритмыToolStripMenuItem
            // 
            this.допАлгоритмыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CryptItem,
            this.SignItem});
            this.допАлгоритмыToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.допАлгоритмыToolStripMenuItem.Name = "допАлгоритмыToolStripMenuItem";
            this.допАлгоритмыToolStripMenuItem.Size = new System.Drawing.Size(116, 21);
            this.допАлгоритмыToolStripMenuItem.Text = "Доп. алгоритмы";
            // 
            // CryptItem
            // 
            this.CryptItem.Name = "CryptItem";
            this.CryptItem.Size = new System.Drawing.Size(180, 22);
            this.CryptItem.Text = "Шифровать";
            this.CryptItem.Click += new System.EventHandler(this.CryptItem_Click);
            // 
            // SignItem
            // 
            this.SignItem.Name = "SignItem";
            this.SignItem.Size = new System.Drawing.Size(180, 22);
            this.SignItem.Text = "Подписать";
            this.SignItem.Click += new System.EventHandler(this.SignItem_Click);
            // 
            // WriteForm
            // 
            this.AcceptButton = this.b_send;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 525);
            this.Controls.Add(this.b_delattach);
            this.Controls.Add(this.b_addattach);
            this.Controls.Add(this.list);
            this.Controls.Add(this.b_send);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_subject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_to);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "WriteForm";
            this.ShowIcon = false;
            this.Text = "Новое письмо";
            ((System.ComponentModel.ISupportInitialize)(this.list)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ComboBox cb_to;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_subject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button b_send;
        private System.Windows.Forms.DataGridView list;
        private System.Windows.Forms.Button b_addattach;
        private System.Windows.Forms.Button b_delattach;
        private System.Windows.Forms.OpenFileDialog attach_fileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn path_coll;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn ext_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn size_col;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem допАлгоритмыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CryptItem;
        private System.Windows.Forms.ToolStripMenuItem SignItem;
    }
}