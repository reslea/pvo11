namespace Pomodoro
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
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.TimerMessageLabel = new System.Windows.Forms.Label();
            this.TimeIntervalNumeric = new System.Windows.Forms.NumericUpDown();
            this.TimeIntervalLabel = new System.Windows.Forms.Label();
            this.TimerStartButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TimeIntervalNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // Timer
            // 
            this.Timer.Interval = 2000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // TimerMessageLabel
            // 
            this.TimerMessageLabel.AutoSize = true;
            this.TimerMessageLabel.Location = new System.Drawing.Point(323, 237);
            this.TimerMessageLabel.Name = "TimerMessageLabel";
            this.TimerMessageLabel.Size = new System.Drawing.Size(0, 20);
            this.TimerMessageLabel.TabIndex = 0;
            // 
            // TimeIntervalNumeric
            // 
            this.TimeIntervalNumeric.Location = new System.Drawing.Point(365, 151);
            this.TimeIntervalNumeric.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.TimeIntervalNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TimeIntervalNumeric.Name = "TimeIntervalNumeric";
            this.TimeIntervalNumeric.Size = new System.Drawing.Size(58, 27);
            this.TimeIntervalNumeric.TabIndex = 1;
            this.TimeIntervalNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TimeIntervalLabel
            // 
            this.TimeIntervalLabel.AutoSize = true;
            this.TimeIntervalLabel.Location = new System.Drawing.Point(241, 153);
            this.TimeIntervalLabel.Name = "TimeIntervalLabel";
            this.TimeIntervalLabel.Size = new System.Drawing.Size(118, 20);
            this.TimeIntervalLabel.TabIndex = 2;
            this.TimeIntervalLabel.Text = "Time in seconds:";
            // 
            // TimerStartButton
            // 
            this.TimerStartButton.Location = new System.Drawing.Point(284, 193);
            this.TimerStartButton.Name = "TimerStartButton";
            this.TimerStartButton.Size = new System.Drawing.Size(94, 29);
            this.TimerStartButton.TabIndex = 3;
            this.TimerStartButton.Text = "Start";
            this.TimerStartButton.UseVisualStyleBackColor = true;
            this.TimerStartButton.Click += new System.EventHandler(this.TimerStartButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TimerStartButton);
            this.Controls.Add(this.TimeIntervalLabel);
            this.Controls.Add(this.TimeIntervalNumeric);
            this.Controls.Add(this.TimerMessageLabel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TimeIntervalNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Timer Timer;
        private Label TimerMessageLabel;
        private NumericUpDown TimeIntervalNumeric;
        private Label TimeIntervalLabel;
        private Button TimerStartButton;
    }
}