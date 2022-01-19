namespace WinFormsBase
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
            this.ClickMeBtn = new System.Windows.Forms.Button();
            this.UsersGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.UsersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ClickMeBtn
            // 
            this.ClickMeBtn.Location = new System.Drawing.Point(336, 409);
            this.ClickMeBtn.Name = "ClickMeBtn";
            this.ClickMeBtn.Size = new System.Drawing.Size(94, 29);
            this.ClickMeBtn.TabIndex = 0;
            this.ClickMeBtn.Text = "Click Me";
            this.ClickMeBtn.UseVisualStyleBackColor = true;
            // 
            // UsersGridView
            // 
            this.UsersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersGridView.Location = new System.Drawing.Point(12, 12);
            this.UsersGridView.Name = "UsersGridView";
            this.UsersGridView.RowHeadersWidth = 51;
            this.UsersGridView.RowTemplate.Height = 29;
            this.UsersGridView.Size = new System.Drawing.Size(776, 391);
            this.UsersGridView.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UsersGridView);
            this.Controls.Add(this.ClickMeBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.UsersGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button ClickMeBtn;
        private DataGridView UsersGridView;
    }
}