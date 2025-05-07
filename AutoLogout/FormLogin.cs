using AutoLogout.Controls;
using AutoLogout.Login;

namespace AutoLogout
{
    public partial class FormLogin : Form
    {
        private readonly LoginService _loginService = new(new MockUserRepository());

        public FormLogin()
        {
            InitializeComponent();
        }

        private void Button���O�C��_Click(object sender, EventArgs e)
        {
            // ���[�U�[ID�ƃp�X���[�h���擾
            string userId = TextBox���[�U�[ID.Text.Trim();
            string password = TextBox�p�X���[�h.Text.Trim();

            // ���O�C����񌟏�
            if (!_loginService.TryLogin(userId, password, out var �����R�[�h))
            {
                MessageBox.Show("���[�U�[ID�܂��̓p�X���[�h���Ԉ���Ă��܂�", "���O�C�����s", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ��ʑJ��
            var formMenu = new FormMenu();
            formMenu.FormClosed += (_, _) => this.Close();
            formMenu.Show();

            this.Hide();
        }

        private void Button�I��_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
