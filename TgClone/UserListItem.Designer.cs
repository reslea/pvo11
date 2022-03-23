
namespace tgClone
{
    partial class UserListItem
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.NicknameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NicknameLabel
            // 
            this.NicknameLabel.AutoSize = true;
            this.NicknameLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NicknameLabel.Location = new System.Drawing.Point(0, 19);
            this.NicknameLabel.Name = "NicknameLabel";
            this.NicknameLabel.Size = new System.Drawing.Size(127, 32);
            this.NicknameLabel.TabIndex = 0;
            this.NicknameLabel.Text = "Test Name";
            // 
            // UserListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NicknameLabel);
            this.Name = "UserListItem";
            this.Size = new System.Drawing.Size(150, 74);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NicknameLabel;
    }
}
