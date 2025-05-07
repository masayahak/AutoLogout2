using AutoLogout.Login;

namespace AutoLogout.Controls
{
    public class MyAppContext : ApplicationContext
    {
        public MyAppContext(FormLogin loginForm)
        {
            loginForm.Show();
        }

        // 新しいログインフォームを表示し、他のフォームを全て閉じる
        public void ShowLoginAndCloseOthers()
        {
            // ログアウト
            CurrentUser.Logout();

            // ログインフォームは常にNEWする
            var loginForm = new FormLogin();
            loginForm.Show();

            foreach (Form f in Application.OpenForms.Cast<Form>().ToList())
            {
                // 過去のログインフォームが残っていても、NEWしたインスタンス以外は閉じる
                if (f != loginForm)
                    f.Close();
            }

            // 最終操作時刻を現在時刻に更新（再スタート時の即タイムアウトを防ぐ）
            UserActivityTracker.Update();

            InactivityMonitorManager.Start(
                Program.InactivityCheckIntervalSeconds,
                Program.InactivityTimeout
            );
        }
    }

}