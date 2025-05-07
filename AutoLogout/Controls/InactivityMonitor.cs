using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace AutoLogout.Controls
{

    public class InactivityMonitor
    {
        private readonly Timer _timer;
        private readonly int _interval;
        private readonly TimeSpan _timeout;

        public InactivityMonitor(int interval, TimeSpan timeout)
        {
            _timeout = timeout;
            _interval = interval;

            _timer = new Timer();
            _timer.Interval = _interval * 1000;
            _timer.Tick += (s, e) => CheckTimeout();
            _timer.Start();

            Application.AddMessageFilter(new UserActivityMessageFilter());
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
