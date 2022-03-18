namespace MultiRoleRetail
{
    partial class DailyReportForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.lbTotalTransaction = new System.Windows.Forms.Label();
            this.lbSold = new System.Windows.Forms.Label();
            this.lbIncome = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Tarnsactions";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total Product Sold";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Gross Income";
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Location = new System.Drawing.Point(226, 18);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(106, 25);
            this.lbDate.TabIndex = 4;
            this.lbDate.Text = "22-01-2022";
            // 
            // lbTotalTransaction
            // 
            this.lbTotalTransaction.AutoSize = true;
            this.lbTotalTransaction.Location = new System.Drawing.Point(226, 72);
            this.lbTotalTransaction.Name = "lbTotalTransaction";
            this.lbTotalTransaction.Size = new System.Drawing.Size(32, 25);
            this.lbTotalTransaction.TabIndex = 5;
            this.lbTotalTransaction.Text = "10";
            // 
            // lbSold
            // 
            this.lbSold.AutoSize = true;
            this.lbSold.Location = new System.Drawing.Point(226, 123);
            this.lbSold.Name = "lbSold";
            this.lbSold.Size = new System.Drawing.Size(42, 25);
            this.lbSold.TabIndex = 6;
            this.lbSold.Text = "200";
            // 
            // lbIncome
            // 
            this.lbIncome.AutoSize = true;
            this.lbIncome.Location = new System.Drawing.Point(266, 178);
            this.lbIncome.Name = "lbIncome";
            this.lbIncome.Size = new System.Drawing.Size(66, 25);
            this.lbIncome.TabIndex = 7;
            this.lbIncome.Text = "10.000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(226, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Rp.";
            // 
            // DailyReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 235);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbIncome);
            this.Controls.Add(this.lbSold);
            this.Controls.Add(this.lbTotalTransaction);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DailyReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DailyReportForm";
            this.Load += new System.EventHandler(this.DailyReportForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lbDate;
        private Label lbTotalTransaction;
        private Label lbSold;
        private Label lbIncome;
        private Label label5;
    }
}