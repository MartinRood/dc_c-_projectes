using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace dc
{
    class ServerMain
    {
        public delegate bool ControlCtrlDelegate(int CtrlType);
        [DllImport("kernel32.dll")]
        private static extern bool SetConsoleCtrlHandler(ControlCtrlDelegate HandlerRoutine, bool Add);
        private static ControlCtrlDelegate cancelHandler = new ControlCtrlDelegate(HandlerRoutine);

        static void Main(string[] args)
        {
            if(!SetConsoleCtrlHandler(cancelHandler, true))
            {
                Console.WriteLine("截取关闭窗口API注入失败！");
            }
            Master.Instance.Setup();
            Master.Instance.Start();
        }

        public static bool HandlerRoutine(int CtrlType)
        {
            Log.Info("强制关闭进程");
            Master.Instance.Destroy();
            return false;
        }  
    }
}
