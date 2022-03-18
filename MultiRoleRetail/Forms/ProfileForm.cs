using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiRoleRetail
{
    public partial class ProfileForm : Form
    {
        public ProfileForm()
        {
            InitializeComponent();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            lbName.Text = LoginForm.UserName;
            lbEmail.Text = LoginForm.UserEmail;
            lbPhone.Text = LoginForm.UserPhone.ToString();

            if (LoginForm.UserRole == int.Parse("1"))
            {
                lbRole.Text = "Admin";
            }
            if (LoginForm.UserRole == int.Parse("2"))
            {
                lbRole.Text = "Executive";
            }
            if (LoginForm.UserRole == int.Parse("3"))
            {
                lbRole.Text = "User";
            }
        }
    }
}
