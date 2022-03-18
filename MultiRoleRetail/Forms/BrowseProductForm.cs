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
        private readonly Dictionary<string, TransactionHelper> _transaction;
        public Action<string, int> selectProduct { private get; set; }
        
        public BrowseProductForm(DatabaseRetail db, Dictionary<string, TransactionHelper> t)
        {
            InitializeComponent();
            _db = db;
            _transaction = t;
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
            var id = dgvTransaction.SelectedRows[0].Cells[0].Value.ToString();
            var stock = (int)dgvTransaction.SelectedRows[0].Cells[3].Value;

            selectProduct(id, stock);
            Close();
        }

        private void LoadData()
        {
            dgvTransaction.DataSource =
                (
                from p in _db.Products
                where p.Name.Contains(tbSearch.Text)
                select new
                {
                    p.ColId,
                    p.Name,
                    p.Price,
                    stock = p.Stock - (_transaction.ContainsKey(p.ColId) ? _transaction[p.ColId].Qty : 0)
                }
                ).ToList();
        }
    }
}
