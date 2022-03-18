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
    public partial class DailyReportForm : Form
    {
        private readonly DatabaseRetail _db;
        public DailyReportForm()
        {
            InitializeComponent();
            _db = new DatabaseRetail();
        }

        private void DailyReportForm_Load(object sender, EventArgs e)
        {
            var date = DateTime.Now.Date;
            var tCount = _db.Transactions.Where(t => t.Date == date).Count();
            var tProduct =
                (
                from tp in _db.TransactionProducts
                where (tp.Transaction.Date == date)
                select new
                {
                    tp.Quantity,
                    tp.Price
                }
                ).ToList();

            lbDate.Text = date.ToString("dd-MM-yyyy");
            lbTotalTransaction.Text = tCount.ToString();
            lbSold.Text = tProduct.Sum(tp => tp.Quantity).ToString();
            lbIncome.Text = tProduct.Sum(tp => tp.Price).ToString();
        }
    }
}
