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
                
        /*～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～事件～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～*/
        private void RegisterEvent()
        {
            EventController.AddEventListener(ClientEventID.CREATE_COMPLETE, OnGameEvent);
        }
        private void UnRegisterEvent()
        {
            EventController.RemoveEventListener(ClientEventID.CREATE_COMPLETE, OnGameEvent);
        }
        private void OnGameEvent(GameEvent evt)
        {
            switch (evt.type)
            {
                case ClientEventID.CREATE_COMPLETE:
                    {
                        m_tabLogin_Start.Text = "开始";
                        m_tabLogin_Start.Enabled = true;
                        EnableTabPage(true, m_tabUser);
                        EnableLoginTabPage(true);
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
            this.m_tabUser_EndAccount.Enabled = b;
            this.m_tabUser_StartAccount.Enabled = b;
        }
        #endregion
    }
}
