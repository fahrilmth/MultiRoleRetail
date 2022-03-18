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
    public partial class SupplierForm : Form
    {
        private readonly DatabaseRetail _db;
        private enum Mode {None, Add, Edit}
        private Mode _mode;
        public SupplierForm()
        {
            InitializeComponent();
            _db = new DatabaseRetail();
            _mode = Mode.None;
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            gbsuppliers.Enabled = false;
            LoadData();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var id = _db.Suppliers.OrderByDescending(s => s).FirstOrDefault()?.ColId[1..];
            tbID.Text = id == null ? "S001" : $"S{(int.Parse(id) + 1):D3}";

            gbsuppliers.Enabled = true;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = false;

            _mode = Mode.Add;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            gbsuppliers.Enabled = true;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = false;

            var id = dgvSupplier.SelectedRows[0].Cells[0].Value.ToString();
            var supplier = _db.Suppliers.Find(id);

            tbID.Text = supplier.ColId;
            tbName.Text = supplier.Name;

            _mode = Mode.Edit;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = dgvSupplier.SelectedRows[0].Cells[0].Value.ToString();
            var su = _db.Suppliers.Find(id);

            DeleteData(su);
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsValid())
                return;
            if (_mode == Mode.Add)
                AddData();
            if (_mode == Mode.Edit)
                EditData();
            if (_mode == Mode.None)
                return;

            gbsuppliers.Enabled = false;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = true;

            ClearData();
            LoadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();

            gbsuppliers.Enabled = false;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = true;
        }

        private void LoadData()
        {
            dgvSupplier.DataSource =
                (
                from ss in _db.Suppliers
                where ss.Name.Contains(tbSearch.Text)
                select new
                {
                    ss.ColId,
                    ss.Name
                }
                ).ToList();
        }

        private void AddData()
        {
            var sup = new Supplier
            {
                ColId = tbID.Text,
                Name = tbName.Text
            };

            _db.Suppliers.Add(sup);
            _db.SaveChanges();
        }

        private void EditData()
        {
            var suppli = _db.Suppliers.Find(tbID.Text);

            suppli.ColId = tbID.Text;
            suppli.Name = tbName.Text;

            _db.Suppliers.Update(suppli);
            _db.SaveChanges();
        }

        private void DeleteData(Supplier sss)
        {
            _db.Suppliers.Remove(sss);
            _db.SaveChanges();
        }

        private void ClearData()
        {
            tbID.Text = tbName.Text = String.Empty;
        }

        private bool IsValid()
        {
            var error = string.Empty;

            if (tbName.Text == string.Empty)
            {
                error += "Name can not be empty";
            }
            if (error != string.Empty)
            {
                MessageBox.Show(error, "Invalid supplier input", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }
    }
}
