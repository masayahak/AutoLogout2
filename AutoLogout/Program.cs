using AutoLogout.Controls;

namespace AutoLogout
{
    internal static class Program
    {
        public static Controls.MyAppContext? AppContextInstance { get; private set; }

#if DEBUG
        public const int InactivityCheckIntervalSeconds = 1;    // 1秒おきに確認
        public static readonly TimeSpan InactivityTimeout = TimeSpan.FromSeconds(30);  // 30秒でタイムアウト
#else
        public const int InactivityCheckIntervalSeconds = 10;
        public static readonly TimeSpan InactivityTimeout = TimeSpan.FromMinutes(30);
#endif
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loginForm = new FormLogin();
            AppContextInstance = new MyAppContext(loginForm);

            // 起動時に1回だけ監視を開始
            InactivityMonitorManager.Start(InactivityCheckIntervalSeconds, InactivityTimeout);

            Application.Run(AppContextInstance);
        }
    }
}