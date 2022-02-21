namespace MyBudget
{
    partial class MyBudgetForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BudgetAmountNumeric = new System.Windows.Forms.NumericUpDown();
            this.BudgetDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.BudgetAddButton = new System.Windows.Forms.Button();
            this.BudgetDatagrid = new System.Windows.Forms.DataGridView();
            this.BudgetItemAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BudgetItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.BudgetAmountNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BudgetDatagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // BudgetAmountNumeric
            // 
            this.BudgetAmountNumeric.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.BudgetAmountNumeric.Location = new System.Drawing.Point(12, 12);
            this.BudgetAmountNumeric.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.BudgetAmountNumeric.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.BudgetAmountNumeric.Name = "BudgetAmountNumeric";
            this.BudgetAmountNumeric.Size = new System.Drawing.Size(166, 27);
            this.BudgetAmountNumeric.TabIndex = 0;
            // 
            // BudgetDescriptionTextbox
            // 
            this.BudgetDescriptionTextbox.Location = new System.Drawing.Point(184, 12);
            this.BudgetDescriptionTextbox.Name = "BudgetDescriptionTextbox";
            this.BudgetDescriptionTextbox.Size = new System.Drawing.Size(163, 27);
            this.BudgetDescriptionTextbox.TabIndex = 1;
            // 
            // BudgetAddButton
            // 
            this.BudgetAddButton.Location = new System.Drawing.Point(353, 12);
            this.BudgetAddButton.Name = "BudgetAddButton";
            this.BudgetAddButton.Size = new System.Drawing.Size(104, 27);
            this.BudgetAddButton.TabIndex = 2;
            this.BudgetAddButton.Text = "Добавить";
            this.BudgetAddButton.UseVisualStyleBackColor = true;
            this.BudgetAddButton.Click += new System.EventHandler(this.BudgetAddButton_Click);
            // 
            // BudgetDatagrid
            // 
            this.BudgetDatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BudgetDatagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BudgetItemAmount,
            this.BudgetItemDescription});
            this.BudgetDatagrid.Location = new System.Drawing.Point(12, 45);
            this.BudgetDatagrid.Name = "BudgetDatagrid";
            this.BudgetDatagrid.RowHeadersWidth = 51;
            this.BudgetDatagrid.RowTemplate.Height = 29;
            this.BudgetDatagrid.Size = new System.Drawing.Size(445, 393);
            this.BudgetDatagrid.TabIndex = 3;
            // 
            // BudgetItemAmount
            // 
            this.BudgetItemAmount.HeaderText = "Amount";
            this.BudgetItemAmount.MinimumWidth = 6;
            this.BudgetItemAmount.Name = "BudgetItemAmount";
            this.BudgetItemAmount.ReadOnly = true;
            this.BudgetItemAmount.Width = 125;
            // 
            // BudgetItemDescription
            // 
            this.BudgetItemDescription.HeaderText = "Description";
            this.BudgetItemDescription.MinimumWidth = 6;
            this.BudgetItemDescription.Name = "BudgetItemDescription";
            this.BudgetItemDescription.ReadOnly = true;
            this.BudgetItemDescription.Width = 125;
            // 
            // MyBudgetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 450);
            this.Controls.Add(this.BudgetDatagrid);
            this.Controls.Add(this.BudgetAddButton);
            this.Controls.Add(this.BudgetDescriptionTextbox);
            this.Controls.Add(this.BudgetAmountNumeric);
            this.Name = "MyBudgetForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MyBudgetForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.BudgetAmountNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BudgetDatagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericUpDown BudgetAmountNumeric;
        private TextBox BudgetDescriptionTextbox;
        private Button BudgetAddButton;
        private DataGridView BudgetDatagrid;
        private DataGridViewTextBoxColumn BudgetItemAmount;
        private DataGridViewTextBoxColumn BudgetItemDescription;
    }
}