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
    public partial class BrowseProductForm : Form
    {
        private readonly DatabaseRetail _db;
        public BrowseProductForm()
        {
            InitializeComponent();
            _db = new DatabaseRetail();
        }

        private void BrowseProductForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            dgvTransaction.DataSource =
                (
                from t in _db.Transactions
                where t.User.Name.Contains(tbSearch.Text)
                select new
                {
                    t.ColId,
                    t.Date,
                    user = t.User.Name
                }
                ).ToList();
        }
    }
}
