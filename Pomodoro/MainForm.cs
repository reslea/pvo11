namespace Pomodoro
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimerMessageLabel.Text = "Timer has finished";
        }

        private void TimerStartButton_Click(object sender, EventArgs e)
        {
            Timer.Interval = (int)TimeIntervalNumeric.Value * 1000;

            Timer.Start();
        }
    }
}