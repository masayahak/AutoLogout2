namespace AutoLogout.Controls
{
    public static class InactivityMonitorManager
    {
        private static InactivityMonitor? _instance;

        public static void Start(int interval, TimeSpan timeout)
        {
            // _instanceをstaticにしアプリ全体で１つだけ持ちたい。複数起動させない。
            _instance = new InactivityMonitor(interval, timeout);
        }
    }
}
