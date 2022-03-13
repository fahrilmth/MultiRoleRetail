using MultiRoleRetail.Models;

namespace MultiRoleRetail
{
    public partial class LoginForm : Form
    {
        private readonly DatabaseRetail _db;
        public static string UserID { get; private set; }
        public static string UserName { get; private set; }
        public static string UserEmail { get; private set; }
        public static int UserPhone { get; private set; }
        public static int UserRole { get; private set; }
        public LoginForm()
        {
            InitializeComponent();
            _db = new DatabaseRetail();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var acccount = _db.Users.FirstOrDefault(user => user.Email == tbEmail.Text && user.Password == tbPassword.Text);

            if (tbEmail.Text != acccount?.Email)
            {
                MessageBox.Show("Invalid email, try again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (tbPassword.Text != acccount?.Password)
            {
                MessageBox.Show("Incorrect password!", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (acccount == null)
            {
                MessageBox.Show("Invalid account, make sure you have an account", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserID = acccount.ColId;
            UserName = acccount.Name;
            UserEmail = acccount.Email;
            UserPhone = acccount.Phone;
            UserRole = acccount.RoleId;

            Hide();
            MenuForm mf = new MenuForm();
            mf.Show();
        }
    }
}