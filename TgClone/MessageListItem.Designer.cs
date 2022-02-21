
namespace tgClone
{
    partial class MessageListItem
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
            this.MessageLabel = new System.Windows.Forms.Label();
            this.NicknameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.MessageLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MessageLabel.Location = new System.Drawing.Point(270, 0);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(170, 37);
            this.MessageLabel.TabIndex = 1;
            this.MessageLabel.Text = "test message";
            // 
            // NicknameLabel
            // 
            this.NicknameLabel.AutoSize = true;
            this.NicknameLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.NicknameLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NicknameLabel.Location = new System.Drawing.Point(102, 0);
            this.NicknameLabel.Name = "NicknameLabel";
            this.NicknameLabel.Size = new System.Drawing.Size(168, 32);
            this.NicknameLabel.TabIndex = 2;
            this.NicknameLabel.Text = "test nickname:";
            // 
            // MessageListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NicknameLabel);
            this.Controls.Add(this.MessageLabel);
            this.Name = "MessageListItem";
            this.Size = new System.Drawing.Size(440, 67);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Label NicknameLabel;
    }
}
