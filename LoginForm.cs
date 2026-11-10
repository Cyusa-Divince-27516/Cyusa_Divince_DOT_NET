using System;
using System.Windows.Forms;

namespace MushroomBicycleApp
{
    public partial class LoginForm : Form
    {
        public static LoginForm? Instance;

        public LoginForm()
        {
            InitializeComponent();
            Instance = this;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Demo credentials: admin / 1234
            if (txtUser.Text.Trim() == "admin" && txtPass.Text == "1234")
            {
                Hide();
                new ChooseForm().Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.\n(Hint: admin / 1234)", "Login failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Clear();
                txtPass.Focus();
            }
        }

        // Called by other forms when the user logs out
        public void ShowAgain()
        {
            txtUser.Clear();
            txtPass.Clear();
            Show();
            txtUser.Focus();
        }
    }
}