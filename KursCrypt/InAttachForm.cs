using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursCrypt
{
    public partial class InAttachForm : Form
    {
        MimeMessage handled_message;
        public InAttachForm(MimeMessage message)
        {
            InitializeComponent();
            handled_message = message;
            foreach (var item in message.Attachments)
            {
                object[] row = { item.ContentId, ((MimePart)item).FileName, ((MimePart)item).FileName.Substring(((MimePart)item).FileName.IndexOf('.')) };
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
                    SaveAttachment(handled_message.Attachments.First(msg => ((MimePart)msg).FileName == list.SelectedRows[0].Cells[1].Value.ToString()), attach_fileDialog.FileName);
                }
            }
        }
        private void SaveAttachment(MimeEntity attachment, string filepath)
        {
            using (var stream = File.Create(filepath))
            {
                if (attachment is MessagePart)
                {
                    var rfc822 = (MessagePart)attachment;
                    rfc822.Message.WriteTo(stream);
                }
                else
                {
                    var part = (MimePart)attachment;
                    part.Content.DecodeTo(stream);
                }
            }
        }
    }
}
