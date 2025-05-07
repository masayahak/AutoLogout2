using AutoLogout.Controls;

namespace AutoLogout
{
    internal static class Program
    {
        public static Controls.MyAppContext? AppContextInstance { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loginForm = new FormLogin();
            AppContextInstance = new MyAppContext(loginForm);

#if DEBUG
            var interval = 1; // 1秒おきに確認
            var timeout = TimeSpan.FromSeconds(30);  // 30秒でタイムアウト
#else
            var interval = 10; // 10秒おきに確認
            var timeout = TimeSpan.FromMinutes(30);  // 30分でタイムアウト
#endif
            _ = new InactivityMonitor(interval, timeout);

            Application.Run(AppContextInstance);
        }
    }
}