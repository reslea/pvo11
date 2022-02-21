namespace MyBudget
{
    public partial class MyBudgetForm : Form
    {
        private readonly IBudgetRepository _repository;

        public MyBudgetForm(IBudgetRepository repository)
        {
            InitializeComponent();

            _repository = repository;
        }

        private void BudgetAddButton_Click(object sender, EventArgs e)
        {
            var amount = BudgetAmountNumeric.Value;
            var description = BudgetDescriptionTextbox.Text;
            var budgetItem = new BudgetItem(amount, description);
            try
            {
                _repository.Add(budgetItem);
                BudgetDatagrid.Rows.Add(amount, description);
            }
            catch
            {
                MessageBox.Show("Ooops, error");
            }
        }

        private void MyBudgetForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _repository.Dispose();
        }
    }
}