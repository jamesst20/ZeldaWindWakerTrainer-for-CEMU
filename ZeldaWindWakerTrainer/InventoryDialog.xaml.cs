using System.Windows;
using System.Linq;

namespace ZeldaWindWakerTrainer
{
    /// <summary>
    /// Interaction logic for InventoryDialog.xaml
    /// </summary>
    public partial class InventoryDialog : Window
    {
        public struct InventoryResult
        {
            public int ItemId { get; set; }
            public int ItemQuantity { get; set; }
        }

        public InventoryDialog(string currentItem, int currentQuantity = -1, bool quantity = false)
        {
            InitializeComponent();

            LabelCurrentItem.Content = currentItem;

            ComboNewItem.SelectedValuePath = "Id";
            ComboNewItem.DisplayMemberPath = "Name";
            ComboNewItem.ItemsSource = GameItems.GetAllItems();

            Item? matchingItem = GameItems.GetAllItems().FirstOrDefault(item => item.Name == currentItem);
            if (matchingItem.HasValue) ComboNewItem.SelectedValue = matchingItem.Value.Id;

            TxtQuantity.Text = currentQuantity.ToString();
            LabelQuantity.Content = currentQuantity.ToString();

            PanelQuantity.Visibility = quantity ? Visibility.Visible : Visibility.Hidden;
        }

        private void BtUpdate_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void BtCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        public InventoryResult GetResult()
        {
            return new InventoryResult
            {
                ItemId = (int)ComboNewItem.SelectedValue,
                ItemQuantity = int.Parse(TxtQuantity.Text != "" ? TxtQuantity.Text : "-1")
            };
        }
    }
}
