namespace AutoLogout.Controls
{
    public static class InactivityMonitorManager
    {
        private static InactivityMonitor? _instance;

        public static void Start(int interval, TimeSpan timeout)
        {
            if (_instance != null)
            {
                _instance.Stop(); // 旧インスタンスが動いていたら止める
            }

            // _instanceをstaticにしアプリ全体で１つだけ持ちたい。複数起動させない。
            _instance = new InactivityMonitor(interval, timeout);
        }
    }
}
