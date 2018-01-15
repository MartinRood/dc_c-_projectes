using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dc
{
    public partial class MainForm : Form
    {
        private Timer m_timer;
        private ePressureType m_pressure_type = ePressureType.None;
        private List<TabPage> m_tab_pages = new List<TabPage>();

        public MainForm()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.RegisterEvent();

            for (int i = 0; i < m_tabControl.TabCount; ++i)
            {
                TabPage tp = m_tabControl.TabPages[i];
                m_tab_pages.Add(tp);
            }

            this.m_tabUser_IP.Text = ServerConfig.db_info.address;
            this.m_tabUser_Port.Text = ServerConfig.db_info.port.ToString();
            this.m_tabUser_DB.Text = ServerConfig.db_info.name.ToString();

            m_timer = new Timer();
            m_timer.Interval = 1000;
            m_timer.Tick += Update;
            m_timer.Start();
        }
        protected override void OnClosed(EventArgs e)
        {
            this.UnRegisterEvent();
            base.OnClosed(e);
        }
        private void Update(object sender, EventArgs e)
        {
            lock (ThreadScheduler.Instance.LogicLock)
            {
                UpdateTabPage();
            }
        }
        private void UpdateTabPage()
        {
            switch (m_pressure_type)
            {
                case ePressureType.CreateUser: UpdateLoginTabPage(); break;
            }
        }
        /// <summary>
        /// 开启/关闭page
        /// </summary>
        private void EnableTabPage(bool b, TabPage page)
        {
            for (int i = 0; i < m_tab_pages.Count; ++i)
            {
                TabPage tp = m_tab_pages[i];
                if (!b)
                {
                    if (page == tp) continue;
                    m_tabControl.TabPages.Remove(tp);
                }
                else
                {
                    m_tabControl.TabPages.Remove(tp);
                    m_tabControl.TabPages.Insert(i, tp);
                    if(tp == page)
                    {
                        m_tabControl.SelectedTab = page;
                    }
                }
            }
        }
        private void SetCreateProgress(int cur, int total)
        {
            if (cur < 0 || total < 0) return;
            m_tabUser_Progress.Maximum = total;
            m_tabUser_Progress.Value = cur;
            m_tabUser_Protxt.Text = cur.ToString() + "/" + total.ToString();
        }
                
        /*～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～事件～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～*/
        private void RegisterEvent()
        {
            EventController.AddEventListener(ClientEventID.CREATE_COMPLETE, OnGameEvent);
            EventController.AddEventListener(ClientEventID.CREATE_PROGRESS, OnGameEvent);
        }
        private void UnRegisterEvent()
        {
            EventController.RemoveEventListener(ClientEventID.CREATE_COMPLETE, OnGameEvent);
            EventController.RemoveEventListener(ClientEventID.CREATE_PROGRESS, OnGameEvent);
        }
        private void OnGameEvent(GameEvent evt)
        {
            switch (evt.type)
            {
                case ClientEventID.CREATE_COMPLETE:
                    {
                        MessageBox.Show("创建完成", "提示", MessageBoxButtons.OK);
                        m_tabLogin_Start.Text = "开始";
                        m_tabLogin_Start.Enabled = true;
                        EnableTabPage(true, m_tabUser);
                        EnableLoginTabPage(true);
                        this.SetCreateProgress(0, 1);
                    }
                    break;
                case ClientEventID.CREATE_PROGRESS:
                    {
                        int cur = evt.Get<int>(0);
                        int total = evt.Get<int>(1);
                        this.SetCreateProgress(cur, total);
                    }
                    break;
            }
        }
        #region 创建角色
        /*～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～创建角色～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～*/
        /// <summary>
        /// 登陆测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoginPageClick(object sender, EventArgs e)
        {
            this.SetCreateProgress(0, 1);
            if (m_tabLogin_Start.Text == "停止")
            {
                m_tabLogin_Start.Text = "开始";
                m_tabLogin_Start.Enabled = true;
                EnableTabPage(true, m_tabUser);
                EnableLoginTabPage(true);

                EventController.TriggerEvent(ClientEventID.SWITCH_PRESSURE, ePressureType.CreateUser, false);
            }
            else
            {
                sCreateUserInfo info = new sCreateUserInfo();
                info.ip = this.m_tabUser_IP.Text;
                info.port = ushort.Parse(this.m_tabUser_Port.Text);
                info.db_name = this.m_tabUser_DB.Text;
                info.start_id = long.Parse(this.m_tabUser_StartId.Text);
                info.start_account = long.Parse(this.m_tabUser_StartAccount.Text);
                info.end_account = long.Parse(this.m_tabUser_EndAccount.Text);
                if (info.start_id < 0)
                {
                    MessageBox.Show("请设置有效的角色起始id", "错误", MessageBoxButtons.OK);
                    return;
                }
                if (info.end_account <= info.start_account || info.start_account < 0)
                {
                    MessageBox.Show("请设置有效的账号范围", "错误", MessageBoxButtons.OK);
                    return;
                }

                m_tabLogin_Start.Enabled = false;
                EnableTabPage(false, m_tabUser);
                EnableLoginTabPage(false);
                m_pressure_type = ePressureType.CreateUser;
                m_tabLogin_Start.Text = "停止";

                EventController.TriggerEvent(ClientEventID.SWITCH_PRESSURE, ePressureType.CreateUser, true, info);
                m_tabLogin_Start.Enabled = true;
            }
        }
        private void UpdateLoginTabPage()
        {
        }
        private void EnableLoginTabPage(bool b)
        {
            this.m_tabUser_IP.Enabled = b;
            this.m_tabUser_Port.Enabled = b;
            this.m_tabLogin_Start.Enabled = b;
            this.m_tabUser_EndAccount.Enabled = b;
            this.m_tabUser_StartAccount.Enabled = b;
        }
        #endregion
    }
}
