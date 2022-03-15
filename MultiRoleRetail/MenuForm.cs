using MultiRoleRetail.Models;
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
        private readonly DatabaseRetail _db;
        private BrowseProductForm _brp;
        public MenuForm()
        {
            InitializeComponent();
            _db = new DatabaseRetail();
        }

        private void pROFILEToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            ExportDataForm exp = new ExportDataForm();
            exp.Show();
        }

        private void pRODUCTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProductForm pf = new ProductForm();
            pf.Show();
        }

        private void eMPLOYEEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm us = new UserForm();
            us.Show();
        }

        private void sUPPLIERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierForm s = new SupplierForm();
            s.Show();
        }

        public static Form LoadForm(Form form, Form formNext)
        {
            if (form == null || form.IsDisposed)
            {
                form = formNext;
                form.Show();
            }
            if (!form.Focused)
            {
                form.Focus();
            }
            if (form.WindowState == FormWindowState.Minimized)
            {
                form.WindowState = FormWindowState.Normal;
            }
            return form;
        }

        private void nEWTRANSACTIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTransactionForm n = new NewTransactionForm(_brp);
            n.Show();
        }

        private void tRANSACTIONHISTORYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransactionHistoryForm thf = new TransactionHistoryForm();
            thf.Show();
        }
    }
}