namespace BestOil
{
    partial class MainForm
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
            this.CafeGroupbox = new System.Windows.Forms.GroupBox();
            this.CafeMenuItemsPanel = new System.Windows.Forms.Panel();
            this.CalculateMenuPriceButton = new System.Windows.Forms.Button();
            this.CalculatedMenuPriceLabel = new System.Windows.Forms.Label();
            this.CafeGroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CafeGroupbox
            // 
            this.CafeGroupbox.Controls.Add(this.CafeMenuItemsPanel);
            this.CafeGroupbox.Location = new System.Drawing.Point(513, 12);
            this.CafeGroupbox.MinimumSize = new System.Drawing.Size(275, 0);
            this.CafeGroupbox.Name = "CafeGroupbox";
            this.CafeGroupbox.Size = new System.Drawing.Size(275, 254);
            this.CafeGroupbox.TabIndex = 0;
            this.CafeGroupbox.TabStop = false;
            this.CafeGroupbox.Text = "MiniCafe";
            // 
            // CafeMenuItemsPanel
            // 
            this.CafeMenuItemsPanel.AutoScroll = true;
            this.CafeMenuItemsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CafeMenuItemsPanel.Location = new System.Drawing.Point(3, 23);
            this.CafeMenuItemsPanel.Name = "CafeMenuItemsPanel";
            this.CafeMenuItemsPanel.Size = new System.Drawing.Size(269, 228);
            this.CafeMenuItemsPanel.TabIndex = 3;
            // 
            // CalculateMenuPriceButton
            // 
            this.CalculateMenuPriceButton.Location = new System.Drawing.Point(416, 320);
            this.CalculateMenuPriceButton.Name = "CalculateMenuPriceButton";
            this.CalculateMenuPriceButton.Size = new System.Drawing.Size(154, 93);
            this.CalculateMenuPriceButton.TabIndex = 1;
            this.CalculateMenuPriceButton.Text = "Calculate";
            this.CalculateMenuPriceButton.UseVisualStyleBackColor = true;
            this.CalculateMenuPriceButton.Click += new System.EventHandler(this.RecalculateTotalPrice);
            // 
            // CalculatedMenuPriceLabel
            // 
            this.CalculatedMenuPriceLabel.AutoSize = true;
            this.CalculatedMenuPriceLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CalculatedMenuPriceLabel.Location = new System.Drawing.Point(669, 339);
            this.CalculatedMenuPriceLabel.Name = "CalculatedMenuPriceLabel";
            this.CalculatedMenuPriceLabel.Size = new System.Drawing.Size(39, 41);
            this.CalculatedMenuPriceLabel.TabIndex = 2;
            this.CalculatedMenuPriceLabel.Text = "...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CalculatedMenuPriceLabel);
            this.Controls.Add(this.CalculateMenuPriceButton);
            this.Controls.Add(this.CafeGroupbox);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.CafeGroupbox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox CafeGroupbox;
        private Button CalculateMenuPriceButton;
        private Label CalculatedMenuPriceLabel;
        private Panel CafeMenuItemsPanel;
    }
}