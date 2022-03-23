namespace BestOil
{
    public partial class MainForm : Form
    {
        private List<CafeMenuItemInfo> menuItemInfos = new()
        {
            new CafeMenuItemInfo("hot dog", 20, 0),
            new CafeMenuItemInfo("hamburger", 30, 0),
            new CafeMenuItemInfo("coca cola", 15, 0),
            new CafeMenuItemInfo("fries", 18, 0),
        };

        public MainForm()
        {
            InitializeComponent();
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            var controls = menuItemInfos
                .Select(i =>
                {
                    var item = new CafeMenuItem(i)
                    {
                        Dock = DockStyle.Top,
                    };
                    item.TotalPriceChanged += RecalculateTotalPrice;
                    return item;
                });

            CafeMenuItemsPanel.Controls.AddRange(controls.ToArray());
        }

        private void RecalculateTotalPrice(object sender, EventArgs e)
        {
            decimal sum = 0;
            foreach(Control control in CafeGroupbox.Controls)
            {
                if (control is CafeMenuItem menuItem)
                {
                    sum += menuItem.TotalPrice;
                }
            }
            CalculatedMenuPriceLabel.Text = sum.ToString();

            //CalculatedMenuPriceLabel.Text = CafeGroupbox.Controls
            //    .Cast<Control>()
            //    .Where(c => c is CafeMenuItem)
            //    .Sum(c => ((CafeMenuItem)c).TotalPrice)
            //    .ToString();
        }
    }

    public class CafeMenuItemInfo
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }

        public CafeMenuItemInfo(string title, decimal price, decimal quantity)
        {
            Title = title;
            Price = price;
            Quantity = quantity;
        }
    }
}