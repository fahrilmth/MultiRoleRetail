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
    public partial class ProductForm : Form
    {
        private readonly DatabaseRetail _db;
        private enum Mode {None, Add, Edit}
        private Mode _mode;

        public ProductForm()
        {
            InitializeComponent();
            _db = new DatabaseRetail();
            _mode = Mode.None;
        }

        private void Product_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            RefreshData();

            cbSupplierID.DataSource = (from s in _db.Suppliers select s.Name).ToList();
            cbSupplierID.SelectedItem = null;
        }

        private void RefreshData()
        {
            dgProduct.DataSource =
                (
                from pp in _db.Products
                where pp.Name.Contains(tbSearch.Text) || pp.Supplier.Name.Contains(tbSearch.Text)
                select new
                {
                    pp.ColId,
                    pp.Name,
                    pp.Price,
                    pp.Stock,
                    supplier = pp.Supplier.Name
                }
                ).ToList();

        }

        private void AddData()
        {
            var product = new Product
            {
                ColId = tbID.Text,
                Name = tbName.Text,
                Price = int.Parse(tbPrice.Text),
                Stock = int.Parse(tbStock.Text),
                Supplier = _db.Suppliers.First(sup => sup.Name == cbSupplierID.Text)
            };

            _db.Products.Add(product);
            _db.SaveChanges();
        }

        private void EditData()
        {
            var prod = _db.Products.Find(tbID.Text);

            prod.Name = tbName.Text;
            prod.Price = int.Parse(tbPrice.Text);
            prod.Stock = int.Parse(tbStock.Text);
            prod.SupplierId = _db.Suppliers.First(s => s.Name == cbSupplierID.Text).ColId;

            _db.Products.Update(prod);
            _db.SaveChanges();
        }

        private void DeleteData(Product product)
        {
            _db.Remove(product);
            _db.SaveChanges();
        }

        private bool Validation()
        {
            var error = string.Empty;

            if (tbName.Text == string.Empty)
            {
                error += "Name can not be empty";
            }
            if (tbPrice.Text == string.Empty)
            {
                error += "Price can nt be empty";
            }
            if (tbStock.Text == string.Empty)
            {
                error += "At least there is 1 stock please";
            }
            if (cbSupplierID.SelectedItem == null)
            {
                error += "select a supplier";
            }
            if(error != String.Empty)
            {
                MessageBox.Show(error, "Failed to add product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void Clear()
        {
            tbID.Text = tbName.Text = tbPrice.Text = tbStock.Text = String.Empty;
            cbSupplierID.SelectedItem = null;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = false;

            var id = _db.Products.OrderByDescending(p => p).FirstOrDefault()?.ColId[1..];
            tbID.Text = id == null ? "P001" : $"P{(int.Parse(id) + 1):D3}";

            _mode = Mode.Add;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = false;

            var id = tbID.Text = dgProduct.SelectedRows[0].Cells[0].Value.ToString();
            var produh = _db.Products.Find(id);
            produh.Supplier = _db.Suppliers.Find(produh.SupplierId);

            tbName.Text = produh.Name;
            tbPrice.Text = produh.Price.ToString();
            tbStock.Text = produh.Stock.ToString();
            cbSupplierID.SelectedItem = produh.Supplier.Name;

            _mode = Mode.Edit;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = dgProduct.SelectedRows[0].Cells[0].Value.ToString();
            var pro = _db.Products.Find(id);

            var confirmation = MessageBox.Show($"Are you sure want to delete {pro.Name} from database?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation == DialogResult.No)
                return;

            DeleteData(pro);
            RefreshData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                return;
            }
            if (_mode == Mode.Add)
            {
                AddData();
            }
            if (_mode == Mode.Edit)
            {
                EditData();
            }
            if (_mode == Mode.None)
            {
                return;
            }

            groupBox1.Enabled = false;
            btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = true;

            Clear();
            RefreshData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            Clear();
        }
    }
}