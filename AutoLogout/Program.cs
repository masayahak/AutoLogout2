using AutoLogout.Controls;

namespace AutoLogout
{
    internal static class Program
    {
        public static Controls.MyAppContext? AppContextInstance { get; private set; }

#if DEBUG
        public const int InactivityCheckIntervalSeconds = 1;    // 1�b�����Ɋm�F
        public static readonly TimeSpan InactivityTimeout = TimeSpan.FromSeconds(30);  // 30�b�Ń^�C���A�E�g
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

            // �N������1�񂾂��Ď����J�n
            InactivityMonitorManager.Start(InactivityCheckIntervalSeconds, InactivityTimeout);

            Application.Run(AppContextInstance);
        }
    }
}