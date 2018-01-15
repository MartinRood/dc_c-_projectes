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
            SetConsoleCtrlHandler(cancelHandler, true);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Master.Instance.Setup();
            Master.Instance.Start();
        }

        public static bool HandlerRoutine(int CtrlType)
        {
            Log.Info("强制关闭进程");
            Master.Instance.Destroy();
            return false;
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            Log.Error(string.Format("捕获到未处理异常：{0}\r\n异常信息：{1}\r\n异常堆栈：{2}\r\nCLR即将退出：{3}", ex.GetType(), ex.Message, ex.StackTrace, e.IsTerminating));
        }
    }
}
