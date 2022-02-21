namespace BestOil
{
    partial class CafeMenuItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuItemQuantityNumeric = new System.Windows.Forms.NumericUpDown();
            this.MenuItemPriceNumeric = new System.Windows.Forms.NumericUpDown();
            this.MenuItemCheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.MenuItemQuantityNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuItemPriceNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuItemQuantityNumeric
            // 
            this.MenuItemQuantityNumeric.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.MenuItemQuantityNumeric.Location = new System.Drawing.Point(169, 3);
            this.MenuItemQuantityNumeric.Name = "MenuItemQuantityNumeric";
            this.MenuItemQuantityNumeric.Size = new System.Drawing.Size(72, 27);
            this.MenuItemQuantityNumeric.TabIndex = 5;
            this.MenuItemQuantityNumeric.ValueChanged += new System.EventHandler(this.NotifyTotalPriceChange);
            // 
            // MenuItemPriceNumeric
            // 
            this.MenuItemPriceNumeric.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.MenuItemPriceNumeric.DecimalPlaces = 2;
            this.MenuItemPriceNumeric.Location = new System.Drawing.Point(93, 3);
            this.MenuItemPriceNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.MenuItemPriceNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MenuItemPriceNumeric.Name = "MenuItemPriceNumeric";
            this.MenuItemPriceNumeric.ReadOnly = true;
            this.MenuItemPriceNumeric.Size = new System.Drawing.Size(70, 27);
            this.MenuItemPriceNumeric.TabIndex = 4;
            this.MenuItemPriceNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MenuItemPriceNumeric.ValueChanged += new System.EventHandler(this.NotifyTotalPriceChange);
            // 
            // MenuItemCheckbox
            // 
            this.MenuItemCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuItemCheckbox.AutoSize = true;
            this.MenuItemCheckbox.Location = new System.Drawing.Point(3, 3);
            this.MenuItemCheckbox.Name = "MenuItemCheckbox";
            this.MenuItemCheckbox.Size = new System.Drawing.Size(55, 24);
            this.MenuItemCheckbox.TabIndex = 3;
            this.MenuItemCheckbox.Text = "test";
            this.MenuItemCheckbox.UseVisualStyleBackColor = true;
            this.MenuItemCheckbox.CheckedChanged += new System.EventHandler(this.NotifyTotalPriceChange);
            // 
            // CafeMenuItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MenuItemQuantityNumeric);
            this.Controls.Add(this.MenuItemPriceNumeric);
            this.Controls.Add(this.MenuItemCheckbox);
            this.MaximumSize = new System.Drawing.Size(0, 33);
            this.MinimumSize = new System.Drawing.Size(245, 33);
            this.Name = "CafeMenuItem";
            this.Size = new System.Drawing.Size(245, 33);
            ((System.ComponentModel.ISupportInitialize)(this.MenuItemQuantityNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuItemPriceNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericUpDown MenuItemQuantityNumeric;
        private NumericUpDown MenuItemPriceNumeric;
        private CheckBox MenuItemCheckbox;
    }
}
