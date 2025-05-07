using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace AutoLogout.Controls
{

    public class InactivityMonitor
    {
        private readonly Timer _timer;
        private readonly int _interval;
        private readonly TimeSpan _timeout;

        private static bool _filterAdded = false;

        public InactivityMonitor(int interval, TimeSpan timeout)
        {
            _timeout = timeout;
            _interval = interval;

            _timer = new Timer();
            _timer.Interval = _interval * 1000;
            _timer.Tick += (s, e) => CheckTimeout();
            _timer.Start();

            // フィルターは一度だけ登録する
            if (!_filterAdded)
            {
                Application.AddMessageFilter(new UserActivityMessageFilter());
                _filterAdded = true;
            }
        }

        public void Stop ()
        {
            _timer.Stop();
        }

        private void CheckTimeout()
        {
            if (UserActivityTracker.IsInactive(_timeout))
            {
                _timer.Stop();
                Program.AppContextInstance?.ShowLoginAndCloseOthers();
            }
        }
    }
}
