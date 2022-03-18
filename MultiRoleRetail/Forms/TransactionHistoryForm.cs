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
    public partial class TransactionHistoryForm : Form
    {
        private readonly DatabaseRetail _db;
        private readonly List<TransactionDetailForm> _history;

        public TransactionHistoryForm(DatabaseRetail db)
        {
            InitializeComponent();
            _db = db;
            _history = new List<TransactionDetailForm>();
        }

        private void TransactionHistoryForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource =
                (
                from transaction in _db.Transactions
                select new
                {
                    transaction.ColId,
                    transaction.Date,
                    User = transaction.User.Name,
                    Total = transaction.TransactionProducts.Where(t => t.TransactionId == transaction.ColId).Sum(tt => tt.Price)
                }
                ).ToList();

            dataGridView1.Columns.Add(new DataGridViewButtonColumn()
            {
                Text = "Detail",
                HeaderText = "Detail",
                UseColumnTextForButtonValue = true
            });
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 4)
            {
                return;
            }
            if (e.RowIndex < 0)
            {
                return;
            }

            var form = new TransactionDetailForm(_db, dataGridView1[0, e.RowIndex].Value.ToString());
            form.Show();

            _history.Add(form);
        }
    }
}
