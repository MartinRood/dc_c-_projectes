using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace dc
{
    /// <summary>
    /// 管理器
    /// @author hannibal
    /// @time 2016-7-28
    /// </summary>
    public class Master : Singleton<Master>
    {
        private Timer m_timer;
        public void Setup()
        {
            ServerConfig.Read();
            Framework.Instance.Setup(Tick);

            ClientNetManager.Instance.Setup();
            LoginPressureManager.Instance.Setup();
            MovePressureManager.Instance.Setup();
        }
        public void Destroy()
        {
            ClientNetManager.Instance.Destroy();
            LoginPressureManager.Instance.Destroy();
            MovePressureManager.Instance.Destroy();
        }
        public void Tick()
        {
            ClientNetManager.Instance.Tick();
            LoginPressureManager.Instance.Tick();
            MovePressureManager.Instance.Tick();
        }

        public void Start()
        {
            m_timer = new Timer();
            m_timer.Interval = 10;
            m_timer.Tick += Update;
            m_timer.Start();
        }        
        private long tmpLastTime = Time.time;
        private void Update(object sender, EventArgs e)
        {
            Framework.Instance.Update(Time.time - tmpLastTime);
            tmpLastTime = Time.time;
        }
    }
}
