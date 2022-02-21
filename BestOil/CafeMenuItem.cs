using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestOil
{

    public partial class CafeMenuItem : UserControl
    {
        public string Title
        {
            get => MenuItemCheckbox.Text;
            set => MenuItemCheckbox.Text = value;
        }

        public decimal Price 
        {
            get => MenuItemPriceNumeric.Value;
            set => MenuItemPriceNumeric.Value = value;
        }

        public decimal Quantity
        {
            get => MenuItemQuantityNumeric.Value;
            set => MenuItemQuantityNumeric.Value = value;
        }

        private bool IsChecked
        {
            get => MenuItemCheckbox.Checked;
            set => MenuItemCheckbox.Checked = value;
        }

        public decimal TotalPrice { get; private set; }

        public event Action<object, EventArgs> TotalPriceChanged;

        public CafeMenuItem()
        {
            InitializeComponent();
        }

        public CafeMenuItem(string title, decimal price, decimal quantity)
        {
            InitializeComponent();
            Title = title;
            Price = price;
            Quantity = quantity;

            MenuItemCheckbox.Text = title;
            MenuItemPriceNumeric.Value = price;
            MenuItemQuantityNumeric.Value = quantity;
        }

        public CafeMenuItem(CafeMenuItemInfo info)
        {
            InitializeComponent();
            Title = info.Title;
            Price = info.Price;
            Quantity = info.Quantity;

            MenuItemCheckbox.Text = info.Title;
            MenuItemPriceNumeric.Value = info.Price;
            MenuItemQuantityNumeric.Value = info.Quantity;
        }

        private void NotifyTotalPriceChange(object sender, EventArgs e)
        {
            TotalPrice = IsChecked 
                ? Price * Quantity 
                : 0;

            TotalPriceChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
