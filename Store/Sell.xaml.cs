using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;

namespace Store
{
    public partial class Sell : Window
    {
        private DataContext context { get; set; }

        public Sell()
        {
            context = new DataContext();
            InitializeComponent();
            UpdateData();
        }

        public void UpdateData()
        {
            List<Receipt> DatabaseReceipts = context.Receipts.Include(receipt => receipt.Products).Include(receipt => receipt.ReceiptProduct).ToList();
            ReceiptsItemList.ItemsSource = DatabaseReceipts;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ReceiptsItemList.SelectedItem is Receipt selectedReceipt)
            {
                //видаляємо його з контексту
                context.Receipts.Remove(selectedReceipt);
                //синхронізуємо з базою даних
                context.SaveChanges();
                //синхронізуємо з інтерфейсом
                UpdateData();
            }
            //якщо рядок не вибраний - повідомлення користувачу
            else
            {
                MessageBox.Show("Select some row", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ReceiptsItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Receipt receipt = (Receipt)e.AddedItems[0];
                ReceiptProductsItemList.ItemsSource = receipt.ReceiptProduct;
            }
        }


        public void Window_Closed(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Purchase purchase = new Purchase();
            purchase.Closed += Window_Closed;
            purchase.ShowDialog();
        }
    }
}
