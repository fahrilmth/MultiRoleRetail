using MultiRoleRetail.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiRoleRetail
{
    public partial class TransactionDetailForm : Form
    {
        private readonly DatabaseRetail _db;
        private readonly string _transactionId;
        public TransactionDetailForm(DatabaseRetail db, string trd)
        {
            InitializeComponent();
            _db = db;
            _transactionId = trd;
        }

        private void TransactionDetailForm_Load(object sender, EventArgs e)
        {
            var id = lbID.Text = _transactionId;
            var transact = _db.Transactions.Find(id);
            var user = _db.Users.Find(transact.UserId);

            Debug.WriteLine(user);

            var tran =
                (
                from t in _db.TransactionProducts
                where (t.TransactionId == transact.ColId)
                select new
                {
                    t.Product.ColId,
                    t.Product.Name,
                    t.Product.Price,
                    t.Quantity,
                    Subtotal = t.Price
                }
                ).ToList();

            this.Text = "Detail for" + id;

            lbUser.Text = user.Name;
            lbTotal.Text = tran.Sum(t => t.Subtotal).ToString();
            lbDate.Text = transact.Date.ToString();

            dataGridView1.DataSource = tran;
            dataGridView1.Columns[0].HeaderText = "Product id";
        }
    }
}
