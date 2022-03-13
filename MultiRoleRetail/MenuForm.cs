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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void pROFILEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            ProfileForm p = new ProfileForm();
            p.Show();
        }

        private void sIGNOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void eXPORTDAYAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            ExportDataForm exp = new ExportDataForm();
            exp.Show();
        }
    }
}
