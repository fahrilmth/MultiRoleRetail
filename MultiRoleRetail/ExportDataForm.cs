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
    public partial class ExportDataForm : Form
    {
        public ExportDataForm()
        {
            InitializeComponent();
        }

        private void ExportDataForm_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var id = LoginForm.UserID;

            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                string extension = Path.GetExtension(openFileDialog1.FileName);
                string fNmae = $"{id}avatar{extension}";
                string pathImage = $"{Application.StartupPath}/ExportedData";
                Directory.CreateDirectory(pathImage);
                string fileName = Path.Combine(pathImage, fNmae);
                File.Copy(openFileDialog1.FileName, fileName, true);
                textBox1.Text = openFileDialog1.FileName;
            }

        }

        private void btnSeave_Click(object sender, EventArgs e)
        {

        }
    }
}
