namespace MultiRoleRetail
{
    partial class NewTransactionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvNewTransaction = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbProductID = new System.Windows.Forms.TextBox();
            this.numQty = new System.Windows.Forms.NumericUpDown();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbNominal = new System.Windows.Forms.Label();
            this.lbTotaaaal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNewTransaction
            // 
            this.dgvNewTransaction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNewTransaction.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvNewTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNewTransaction.Location = new System.Drawing.Point(12, 85);
            this.dgvNewTransaction.MultiSelect = false;
            this.dgvNewTransaction.Name = "dgvNewTransaction";
            this.dgvNewTransaction.RowHeadersWidth = 62;
            this.dgvNewTransaction.RowTemplate.Height = 33;
            this.dgvNewTransaction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNewTransaction.Size = new System.Drawing.Size(1151, 518);
            this.dgvNewTransaction.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "PRODUCT ID";
            // 
            // tbProductID
            // 
            this.tbProductID.Location = new System.Drawing.Point(129, 9);
            this.tbProductID.Name = "tbProductID";
            this.tbProductID.ReadOnly = true;
            this.tbProductID.Size = new System.Drawing.Size(883, 31);
            this.tbProductID.TabIndex = 2;
            // 
            // numQty
            // 
            this.numQty.Location = new System.Drawing.Point(129, 48);
            this.numQty.Name = "numQty";
            this.numQty.Size = new System.Drawing.Size(883, 31);
            this.numQty.TabIndex = 4;
            // 
            // btnCheckout
            // 
            this.btnCheckout.Location = new System.Drawing.Point(1051, 611);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(112, 34);
            this.btnCheckout.TabIndex = 5;
            this.btnCheckout.Text = "CHECKOUT";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "QUANTITY";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(1051, 9);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(112, 34);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "BROWSE";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(1051, 45);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 34);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 616);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "TOTAL PAYMENT :";
            // 
            // lbNominal
            // 
            this.lbNominal.AutoSize = true;
            this.lbNominal.Location = new System.Drawing.Point(170, 616);
            this.lbNominal.Name = "lbNominal";
            this.lbNominal.Size = new System.Drawing.Size(0, 25);
            this.lbNominal.TabIndex = 10;
            // 
            // lbTotaaaal
            // 
            this.lbTotaaaal.AutoSize = true;
            this.lbTotaaaal.Location = new System.Drawing.Point(170, 616);
            this.lbTotaaaal.Name = "lbTotaaaal";
            this.lbTotaaaal.Size = new System.Drawing.Size(52, 25);
            this.lbTotaaaal.TabIndex = 11;
            this.lbTotaaaal.Text = "1000";
            // 
            // NewTransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 657);
            this.Controls.Add(this.lbTotaaaal);
            this.Controls.Add(this.lbNominal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.numQty);
            this.Controls.Add(this.tbProductID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvNewTransaction);
            this.Name = "NewTransactionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewTransactionForm";
            this.Load += new System.EventHandler(this.NewTransactionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvNewTransaction;
        private Label label1;
        private TextBox tbProductID;
        private NumericUpDown numQty;
        private Button btnCheckout;
        private Label label2;
        private Button btnBrowse;
        private Button btnAdd;
        private Label label3;
        private Label lbNominal;
        private Label lbTotaaaal;
    }
}