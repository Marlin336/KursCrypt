﻿namespace KursCrypt
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.b_send = new System.Windows.Forms.Button();
            this.list = new System.Windows.Forms.DataGridView();
            this.b_addattach = new System.Windows.Forms.Button();
            this.b_delattach = new System.Windows.Forms.Button();
            this.attach_fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.id_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.path_coll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ext_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.list)).BeginInit();
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
            this.textBox.Location = new System.Drawing.Point(12, 78);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(651, 259);
            this.textBox.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "abc",
            "bcd",
            "cde",
            "efg"});
            this.comboBox1.Location = new System.Drawing.Point(68, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(595, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Кому:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(68, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(595, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Тема:";
            // 
            // b_send
            // 
            this.b_send.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_send.Location = new System.Drawing.Point(12, 501);
            this.b_send.Name = "b_send";
            this.b_send.Size = new System.Drawing.Size(123, 34);
            this.b_send.TabIndex = 5;
            this.b_send.Text = "Отправить";
            this.b_send.UseVisualStyleBackColor = true;
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
            this.list.Location = new System.Drawing.Point(12, 345);
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
            // b_addattach
            // 
            this.b_addattach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_addattach.Location = new System.Drawing.Point(522, 421);
            this.b_addattach.Name = "b_addattach";
            this.b_addattach.Size = new System.Drawing.Size(141, 34);
            this.b_addattach.TabIndex = 8;
            this.b_addattach.Text = "Добавить файл...";
            this.b_addattach.UseVisualStyleBackColor = true;
            this.b_addattach.Click += new System.EventHandler(this.b_addattach_Click);
            // 
            // b_delattach
            // 
            this.b_delattach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_delattach.Location = new System.Drawing.Point(522, 461);
            this.b_delattach.Name = "b_delattach";
            this.b_delattach.Size = new System.Drawing.Size(141, 34);
            this.b_delattach.TabIndex = 9;
            this.b_delattach.Text = "Удалить файл";
            this.b_delattach.UseVisualStyleBackColor = true;
            this.b_delattach.Click += new System.EventHandler(this.b_delattach_Click);
            // 
            // attach_fileDialog
            // 
            this.attach_fileDialog.Multiselect = true;
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
            // WriteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 539);
            this.Controls.Add(this.b_delattach);
            this.Controls.Add(this.b_addattach);
            this.Controls.Add(this.list);
            this.Controls.Add(this.b_send);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox);
            this.Name = "WriteForm";
            this.Text = "Новое письмо";
            ((System.ComponentModel.ISupportInitialize)(this.list)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
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
    }
}