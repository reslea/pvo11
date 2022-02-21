
namespace tgClone
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
            this.components = new System.ComponentModel.Container();
            this.UsersPanel = new System.Windows.Forms.Panel();
            this.MessagesPanel = new System.Windows.Forms.Panel();
            this.UserAddTimer = new System.Windows.Forms.Timer(this.components);
            this.MessageAddTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // UsersPanel
            // 
            this.UsersPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.UsersPanel.Location = new System.Drawing.Point(0, 0);
            this.UsersPanel.Name = "UsersPanel";
            this.UsersPanel.Size = new System.Drawing.Size(203, 450);
            this.UsersPanel.TabIndex = 0;
            // 
            // MessagesPanel
            // 
            this.MessagesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessagesPanel.Location = new System.Drawing.Point(203, 0);
            this.MessagesPanel.Name = "MessagesPanel";
            this.MessagesPanel.Size = new System.Drawing.Size(597, 450);
            this.MessagesPanel.TabIndex = 1;
            // 
            // UserAddTimer
            // 
            this.UserAddTimer.Interval = 3000;
            this.UserAddTimer.Tick += new System.EventHandler(this.UserAddTimer_Tick);
            // 
            // MessageAddTimer
            // 
            this.MessageAddTimer.Enabled = true;
            this.MessageAddTimer.Interval = 2000;
            this.MessageAddTimer.Tick += new System.EventHandler(this.MessageAddTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MessagesPanel);
            this.Controls.Add(this.UsersPanel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel UsersPanel;
        private System.Windows.Forms.Panel MessagesPanel;
        private System.Windows.Forms.Timer UserAddTimer;
        private System.Windows.Forms.Timer MessageAddTimer;
    }
}

