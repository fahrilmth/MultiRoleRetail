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
    public partial class NewTransactionForm : Form
    {
        private readonly DatabaseRetail _db;
        private BrowseProductForm _bp;
        private readonly Dictionary<string, TransactionHelper> _helper;

        public NewTransactionForm(BrowseProductForm b)
        {
            InitializeComponent();
            _db = new DatabaseRetail();
            _bp = b;
            _helper = new Dictionary<string, TransactionHelper>();

        }

        private void NewTransactionForm_Load(object sender, EventArgs e)
        {
            LoadData();

            dgvNewTransaction.Columns[0].HeaderText = "Product ID";
            dgvNewTransaction.Columns[1].HeaderText = "Name";
            dgvNewTransaction.Columns[2].HeaderText = "Price";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            _bp = (BrowseProductForm)
                MenuForm.LoadForm(_bp, new BrowseProductForm(_db, _helper)
                {
                    selectProduct = (id, stock) =>
                    {
                        tbProductID.Text = id;
                        numQty.Value = stock;
                        Focus();
                    }
                });
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var ppp = _db.Products.Find(tbProductID.Text);

            AddData(ppp);
            LoadData();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (!ValidateTransaction())
            {
                return;
            }

            Checkout();
            Close();
        }

        private void LoadData()
        {
            dgvNewTransaction.DataSource =
                (
                from t in _helper
                select new
                {
                    t.Key,
                    t.Value.ProductName,
                    t.Value.ProductPrice,
                    t.Value.Qty,
                    subtotal = t.Value.ProductPrice * t.Value.Qty
                }
                ).ToList();
        }

        private void CountTotal(int price)
        {
            var currentPrice = lbTotaaaal.Text;
            lbTotaaaal.Text = (currentPrice + price).ToString();
        }

        private void AddData(Product pr)
        {
            var qty = (int)numQty.Value;

            if (qty == 0)
                return;

            if (_helper.ContainsKey(pr.ColId))
            {
                var addedProduct = _helper[pr.ColId];
                var currentStock = pr.Stock - addedProduct.Qty;

                if (qty > currentStock)
                {
                    qty = currentStock;
                }

                addedProduct.Qty += qty;
                CountTotal(qty * pr.Price);
                return;
            }
            if (qty > pr.Stock)
            {
                qty = pr.Stock;
            }

            _helper.Add(pr.ColId, new TransactionHelper()
            {
                ProductName = pr.Name,
                ProductPrice = pr.Price,
                Qty = qty
            });
        }

        private bool ValidateTransaction()
        {
            if (_helper.Count == 0)
            {
                MessageBox.Show("At least add 1 product");
                return false;
            }
            return true;
        }

        private void Checkout()
        {
            var id = _db.Transactions.OrderByDescending(t => t).FirstOrDefault()?.ColId[1..];
            id = id == null ? "T001" : $"T{(int.Parse(id) + 1):D3}";

            _db.Transactions.Add(new Transaction
            {
                ColId = id,
                Date = DateTime.Now,
                UserId = LoginForm.UserID
            });

            foreach (var trns in _helper)
            {
                _db.TransactionProducts.Add(new TransactionProduct
                {
                    TransactionId = id,
                    ProductId = trns.Key,
                    Quantity = trns.Value.Qty,
                    Price = trns.Value.ProductPrice
                });

                _db.Products.Find(trns.Key).Stock -= trns.Value.Qty;
            }

            _db.SaveChanges();
        }
    }
}
