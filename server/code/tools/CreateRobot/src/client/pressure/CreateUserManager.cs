using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace dc
{
    /// <summary>
    /// 创建用户
    /// @author hannibal
    /// @time 2016-9-3
    /// </summary>
    public class CreateUserManager : Singleton<CreateUserManager>
    {
        private bool m_active = false;
        private sCreateUserInfo m_pressure_info = null;

        public CreateUserManager()
        {
        }

        public void Setup()
        {
            m_active = false;
            this.RegisterEvent();
        }
        public void Destroy()
        {
            this.UnRegisterEvent();
            m_active = false;
        }
        public void Tick()
        {
        }
        private void Update(object sender, EventArgs e)
        {
            if (m_active)
            {

            }
        }
        private void Start()
        {
            Stop();
            m_active = true;
            this.CreateOneUser(m_pressure_info.start_account, m_pressure_info.start_id);
        }
        private void Stop()
        {
            m_active = false;
        }

        private void CreateOneUser(long account_idx, long char_idx)
        {
            if (!m_active || account_idx > m_pressure_info.end_account) return;

            CreateCharacterInfo create_info = new CreateCharacterInfo();
            create_info.spid = 0;
            create_info.ws_id = 0;
            create_info.ss_id = 0;
            create_info.fs_id = 0;
            create_info.char_idx = char_idx;
            create_info.char_name = "test" + account_idx;
            create_info.char_type = (byte)(MathUtils.Rand_Sign() == 1 ? eSexType.BOY : eSexType.GIRL);

            SQLCharHandle.CreateCharacter(account_idx, create_info, (res) =>
            {
                if (create_info.char_idx != res)
                {
                    Log.Error("创建角色失败，账号:" + account_idx + ", error:" + res.ToString());
                }
                EventController.TriggerEvent(ClientEventID.CREATE_PROGRESS, (int)(account_idx - m_pressure_info.start_account), (int)(m_pressure_info.end_account - m_pressure_info.start_account));
                if (account_idx + 1 > m_pressure_info.end_account)
                {
                    EventController.TriggerEvent(ClientEventID.CREATE_COMPLETE);
                    this.Stop();
                }
                else
                {
                    this.CreateOneUser(account_idx + 1, char_idx + 1);
                }
            }
            );
        }
        /*～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～事件～～～～～～～～～～～～～～～～～～～～～～～～～～～～～～*/
        private void RegisterEvent()
        {
            EventController.AddEventListener(ClientEventID.SWITCH_PRESSURE, OnGameEvent);
        }
        private void UnRegisterEvent()
        {
            EventController.RemoveEventListener(ClientEventID.SWITCH_PRESSURE, OnGameEvent);
        }
        private void OnGameEvent(GameEvent evt)
        {
            switch (evt.type)
            {
                case ClientEventID.SWITCH_PRESSURE:
                    {
                        ePressureType type = evt.Get<ePressureType>(0);
                        bool is_start = evt.Get<bool>(1);
                        if (type == ePressureType.CreateUser && is_start)
                        {
                            m_pressure_info = evt.Get<sCreateUserInfo>(2);
                            this.Start();
                        }
                        else
                        {
                            this.Stop();
                        }
                    }
                    break;
            }
        }
    }
}
