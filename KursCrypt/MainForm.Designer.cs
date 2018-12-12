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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.stateIndicator = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.почтовыеЯщикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.написатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.папкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.входящиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отправленныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.спамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.корзинаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grid_messlist = new System.Windows.Forms.DataGridView();
            this.uidCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromAddressCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttachCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_messlist)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stateIndicator,
            this.настройкиToolStripMenuItem,
            this.почтовыеЯщикиToolStripMenuItem,
            this.написатьToolStripMenuItem,
            this.папкиToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(649, 25);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // stateIndicator
            // 
            this.stateIndicator.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.stateIndicator.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stateIndicator.Name = "stateIndicator";
            this.stateIndicator.Size = new System.Drawing.Size(12, 21);
            this.stateIndicator.Click += new System.EventHandler(this.stateIndicator_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.настройкиToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(83, 21);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // почтовыеЯщикиToolStripMenuItem
            // 
            this.почтовыеЯщикиToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.почтовыеЯщикиToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.почтовыеЯщикиToolStripMenuItem.Name = "почтовыеЯщикиToolStripMenuItem";
            this.почтовыеЯщикиToolStripMenuItem.Size = new System.Drawing.Size(122, 21);
            this.почтовыеЯщикиToolStripMenuItem.Text = "Почтовые ящики";
            this.почтовыеЯщикиToolStripMenuItem.Click += new System.EventHandler(this.почтовыеЯщикиToolStripMenuItem_Click);
            // 
            // написатьToolStripMenuItem
            // 
            this.написатьToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.написатьToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.написатьToolStripMenuItem.Name = "написатьToolStripMenuItem";
            this.написатьToolStripMenuItem.Size = new System.Drawing.Size(75, 21);
            this.написатьToolStripMenuItem.Text = "Написать";
            this.написатьToolStripMenuItem.Click += new System.EventHandler(this.написатьToolStripMenuItem_Click);
            // 
            // папкиToolStripMenuItem
            // 
            this.папкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.входящиеToolStripMenuItem,
            this.отправленныеToolStripMenuItem,
            this.спамToolStripMenuItem,
            this.корзинаToolStripMenuItem});
            this.папкиToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.папкиToolStripMenuItem.Name = "папкиToolStripMenuItem";
            this.папкиToolStripMenuItem.Size = new System.Drawing.Size(65, 21);
            this.папкиToolStripMenuItem.Text = "Папки...";
            // 
            // входящиеToolStripMenuItem
            // 
            this.входящиеToolStripMenuItem.Checked = true;
            this.входящиеToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.входящиеToolStripMenuItem.Name = "входящиеToolStripMenuItem";
            this.входящиеToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.входящиеToolStripMenuItem.Text = "Входящие";
            this.входящиеToolStripMenuItem.Click += new System.EventHandler(this.входящиеToolStripMenuItem_Click);
            // 
            // отправленныеToolStripMenuItem
            // 
            this.отправленныеToolStripMenuItem.Name = "отправленныеToolStripMenuItem";
            this.отправленныеToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.отправленныеToolStripMenuItem.Text = "Отправленные";
            this.отправленныеToolStripMenuItem.Click += new System.EventHandler(this.отправленныеToolStripMenuItem_Click);
            // 
            // спамToolStripMenuItem
            // 
            this.спамToolStripMenuItem.Name = "спамToolStripMenuItem";
            this.спамToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.спамToolStripMenuItem.Text = "Спам";
            this.спамToolStripMenuItem.Click += new System.EventHandler(this.спамToolStripMenuItem_Click);
            // 
            // корзинаToolStripMenuItem
            // 
            this.корзинаToolStripMenuItem.Name = "корзинаToolStripMenuItem";
            this.корзинаToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.корзинаToolStripMenuItem.Text = "Корзина";
            this.корзинаToolStripMenuItem.Click += new System.EventHandler(this.корзинаToolStripMenuItem_Click);
            // 
            // grid_messlist
            // 
            this.grid_messlist.AllowUserToAddRows = false;
            this.grid_messlist.AllowUserToDeleteRows = false;
            this.grid_messlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_messlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_messlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uidCol,
            this.FromAddressCol,
            this.FromNameCol,
            this.SubjCol,
            this.DateCol,
            this.AttachCol});
            this.grid_messlist.Location = new System.Drawing.Point(12, 28);
            this.grid_messlist.MultiSelect = false;
            this.grid_messlist.Name = "grid_messlist";
            this.grid_messlist.ReadOnly = true;
            this.grid_messlist.RowHeadersVisible = false;
            this.grid_messlist.RowTemplate.ReadOnly = true;
            this.grid_messlist.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid_messlist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_messlist.Size = new System.Drawing.Size(625, 481);
            this.grid_messlist.TabIndex = 0;
            this.grid_messlist.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_messlist_CellDoubleClick);
            // 
            // uidCol
            // 
            this.uidCol.HeaderText = "UID";
            this.uidCol.Name = "uidCol";
            this.uidCol.ReadOnly = true;
            this.uidCol.Visible = false;
            // 
            // FromAddressCol
            // 
            this.FromAddressCol.HeaderText = "Адрес отправителя";
            this.FromAddressCol.Name = "FromAddressCol";
            this.FromAddressCol.ReadOnly = true;
            this.FromAddressCol.Width = 150;
            // 
            // FromNameCol
            // 
            this.FromNameCol.HeaderText = "Псевдоним отправителя";
            this.FromNameCol.Name = "FromNameCol";
            this.FromNameCol.ReadOnly = true;
            this.FromNameCol.Width = 110;
            // 
            // SubjCol
            // 
            this.SubjCol.HeaderText = "Тема сообщения";
            this.SubjCol.Name = "SubjCol";
            this.SubjCol.ReadOnly = true;
            this.SubjCol.Width = 150;
            // 
            // DateCol
            // 
            this.DateCol.HeaderText = "Дата/Время";
            this.DateCol.Name = "DateCol";
            this.DateCol.ReadOnly = true;
            this.DateCol.Width = 110;
            // 
            // AttachCol
            // 
            this.AttachCol.HeaderText = "Прикрепления";
            this.AttachCol.Name = "AttachCol";
            this.AttachCol.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 521);
            this.Controls.Add(this.grid_messlist);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(665, 560);
            this.Name = "MainForm";
            this.Text = "Почтовый клиент";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_messlist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem написатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem почтовыеЯщикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem папкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem входящиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отправленныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem спамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem корзинаToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem stateIndicator;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.DataGridView grid_messlist;
        private System.Windows.Forms.DataGridViewTextBoxColumn uidCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromAddressCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttachCol;
    }
}