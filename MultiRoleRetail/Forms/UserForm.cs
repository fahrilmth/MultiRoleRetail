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
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace MultiRoleRetail
{
    public partial class UserForm : Form
    {
        private readonly DatabaseRetail _db;
        private enum Mode {None, Add, Edit}
        private Mode _mode;

        public UserForm()
        {
            InitializeComponent();
            _db = new DatabaseRetail();
            _mode = Mode.None;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var id = _db.Users.OrderByDescending(us => us).FirstOrDefault()?.ColId[1..];
            tbID.Text = id == null ? "U001" : $"U{(int.Parse(id) + 1):D3}";

            gbUser.Enabled = true;
            btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = false;

            _mode = Mode.Add;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            gbUser.Enabled = true;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = false;

            var id = dgvUser.SelectedRows[0].Cells[0].Value.ToString();
            var user = _db.Users.Find(id);
            user.Role = _db.Roles.Find(user.RoleId);

            tbID.Text = user.ColId;
            tbName.Text = user.Name;
            tbEmail.Text = user.Email;
            tbPhone.Text = user.Phone.ToString();
            tbPassword.Text = user.Password;
            cbRoleID.SelectedItem = user.Role.Name;

            _mode = Mode.Edit;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = dgvUser.SelectedRows[0].Cells[0].Value.ToString();
            var u = _db.Users.Find(id);

            var c = MessageBox.Show($"Are you sure want to delete {u.Name} from database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (c == DialogResult.No)
            {
                return;
            }

            DeleteData(u);
            LoadData();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Validate())
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
                return;

            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = true;
            gbUser.Enabled = false;

            Clear();
            LoadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = true;
            gbUser.Enabled = false;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            LoadData();
            gbUser.Enabled = false;

            cbRoleID.DataSource = (from role in _db.Roles select role.Name).ToList();
            cbRoleID.SelectedItem = null;
        }

        private void LoadData()
        {
            dgvUser.DataSource =
                (
                from user in _db.Users
                where user.Name.Contains(tbSearch.Text) || user.Role.Name.Contains(tbSearch.Text)
                select new
                {
                    user.ColId,
                    user.Name,
                    user.Email,
                    user.Phone,
                    user.Password,
                    role = user.Role.Name
                }
                ).ToList();
        }

        private void AddData()
        {
            var u = new User
            {
                ColId = tbID.Text,
                Name = tbName.Text,
                Email = tbEmail.Text,
                Phone = int.Parse(tbPhone.Text),
                Password = tbPassword.Text,
                Role = _db.Roles.First(r => r.Name == cbRoleID.Text)
            };

            _db.Users.Add(u);
            _db.SaveChanges();
        }

        private void EditData()
        {
            var uu = _db.Users.Find(tbID.Text);

            uu.Name = tbName.Text;
            uu.Email = tbEmail.Text;
            uu.Phone = int.Parse(tbPhone.Text);
            uu.Password = tbPassword.Text;
            uu.Role = _db.Roles.First(r => r.Name == cbRoleID.Text);

            _db.Users.Update(uu);
            _db.SaveChanges();
        }

        private void DeleteData(User user)
        {
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        private void Clear()
        {
            tbEmail.Text = tbName.Text = tbPhone.Text = tbPassword.Text = tbID.Text = String.Empty;
            cbRoleID.SelectedItem = null;
        }

        private bool Validate()
        {
            var cause = string.Empty;

            if (tbName.Text == string.Empty)
            {
                cause += "Enter a valid name ";
            }
            if (tbEmail.Text == string.Empty)
            {
                cause += "Enter a valid email ";
            }
            else if (!IsValidEmail(tbEmail.Text))
            {
                cause += "Enter a valid email format ";
            }
            if (tbPhone.Text == string.Empty)
            {
                cause += "Add your phone number ";
            }
            else if (!Regex.IsMatch(tbPhone.Text, @"[(+62) 0-9]"))
            {
                cause += "Phone number must contain +62";
            }
            if (tbPassword.Text == string.Empty)
            {
                cause += "Create your password";
            }
            else if (!Regex.IsMatch(tbPassword.Text, @"[a-zA-Z]") && !Regex.IsMatch(tbPassword.Text, @"[0-9]"))
            {
                cause += "Password must contain a letter and number";
            }
            if (cause != String.Empty)
            {
                MessageBox.Show(cause, "Inavlid User data, try again", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                MailAddress mailFormat = new MailAddress(email);
            }
            catch (Exception e)
            {

                return false;
            }
            return true;
        }
            
    }
}
