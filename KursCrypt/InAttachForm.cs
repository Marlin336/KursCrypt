using System;
using System.Windows.Forms;

namespace KursCrypt
{
    public partial class InAttachForm : Form
    {
        ImapX.Message handled_message;

        public InAttachForm(ImapX.Message message)
        {
            InitializeComponent();
            handled_message = message;
            foreach (var item in message.Attachments)
            {
                object[] row = { item.ContentId, item.FileName, item.FileName.Substring(item.FileName.LastIndexOf('.')), Math.Round((double)item.FileSize / 1024, 2) };
                list.Rows.Add(row);
            }   
        }
        private void list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                attach_fileDialog.FileName = list.SelectedRows[0].Cells[1].Value.ToString();
                attach_fileDialog.Filter = "|*" + list.SelectedRows[0].Cells[2].Value.ToString();
                if(attach_fileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (var item in handled_message.Attachments)
                    {
                        if (item.ContentId == list.SelectedRows[0].Cells[0].Value.ToString())
                        {
                            item.Download();
                            item.Save(attach_fileDialog.InitialDirectory, attach_fileDialog.FileName);
                        }
                    }
                }
            }
        }
    }
}
