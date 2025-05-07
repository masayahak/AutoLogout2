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
            var interval = 1; // 1�b�����Ɋm�F
            var timeout = TimeSpan.FromSeconds(30);  // 30�b�Ń^�C���A�E�g
#else
            var interval = 10; // 10�b�����Ɋm�F
            var timeout = TimeSpan.FromMinutes(30);  // 30���Ń^�C���A�E�g
#endif
            _ = new InactivityMonitor(interval, timeout);

            Application.Run(AppContextInstance);
        }
    }
}