using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dc
{
    /// <summary>
    /// 邮件
    /// @author hannibal
    /// @time 2016-9-11
    /// </summary>
    public partial class ItemListForm : Form
    {
        public ItemListForm()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            //List<MailTitleInfo> list = MailDataManager.Instance.mail_titles;
            //foreach(var obj in list)
            //{
            //    m_list_mail.Rows.Add(obj.mail_idx, obj.mail_type.ToString(), obj.sender_name, obj.flags, obj.subject);
            //}
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }
        /// <summary>
        /// 发邮件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnOK(object sender, EventArgs e)
        {

        }

        private void OnCellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int row = e.RowIndex;
            //int col = e.ColumnIndex; //获取当前列的索引
            //if (col == 4)
            //{
            //    string idx = m_list_mail.Rows[row].Cells["Idx"].Value.ToString();
            //    ServerMsgSend.SendReadMail(long.Parse(idx));
            //}
            //else if (col == 5)
            //{
            //    if(MessageBox.Show("确定要删除邮件吗?", "信息", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //    {
            //        string idx = m_list_mail.Rows[row].Cells["Idx"].Value.ToString();
            //        ServerMsgSend.SendDeleteMail(long.Parse(idx));

            //        m_list_mail.Rows.RemoveAt(row);
            //    }
            //}
        }
    }
}
