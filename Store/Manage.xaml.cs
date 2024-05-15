using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Store
{
    /// <summary>
    /// Interaction logic for Manage.xaml
    /// </summary>
    public partial class Manage : Window
    {
        private DataContext context { get; set; }

        public Manage()
        {
            context = new DataContext();
            InitializeComponent();
            UpdateData();
        }

        public void UpdateData()
        {
            //List<Product> DatabaseProducts = context.Products.Include(product => product.Category).ToList();
            //ProductsItemList.ItemsSource = DatabaseProducts;

            //List<Category> DatabaseCategories = context.Categories.ToList();
            //CategoryItemList.ItemsSource = DatabaseCategories;

            //CategoryComboBox.ItemsSource = DatabaseCategories;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // додавання категорії до таблиці 
            context.Categories.Add(new Category
            {
                Name = NameTextBox.Text
            });
            //  синхронізація з базою даних
            context.SaveChanges();
            //метод оновлення інтерфейсу  
            UpdateData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //знаходимо виділений в таблиці рядок
            Category selectedCategory = CategoryItemList.SelectedItem as Category;

            selectedCategory.Name = NameTextBox.Text;
            //сихнхронізуємо дані з базою даних
            context.SaveChanges();
            //синхронізуємо дані з інтерфейсом
            UpdateData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (CategoryItemList.SelectedItem is Category selectedCategory)
            {
                //видаляємо його з контексту
                context.Categories.Remove(selectedCategory);
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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var quantity = QuantityTextBox.Text;
            var price = PriceTextBox.Text;

            int.TryParse(quantity, out int intQuantity);
            int.TryParse(price, out int intPrice);
            //додаємо продукт до списку
            _ = context.Products.Add(new Product
            {
                Name = ProductNameTextBox.Text,
                Quantity = intQuantity,
                Price = intPrice,
                Category = CategoryComboBox.SelectedItem as Category
            });
            //сихнхронізуємо дані з базою даних
            context.SaveChanges();
            //синхронізуємо дані з інтерфейсом
            UpdateData();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (ProductsItemList.SelectedItem is Product selectedProduct)
            {
                var quantity = QuantityTextBox.Text;
                var price = PriceTextBox.Text;

                int.TryParse(quantity, out int intQuantity);
                int.TryParse(price, out int intPrice);

                selectedProduct.Name = ProductNameTextBox.Text;
                selectedProduct.Price = intPrice;
                selectedProduct.Quantity = intQuantity;
                selectedProduct.Category = CategoryComboBox.SelectedItem as Category;
                //сихнхронізуємо дані з базою даних
                context.SaveChanges();
                //синхронізуємо дані з інтерфейсом
                UpdateData();
            }
            //якщо рядок не вибраний - повідомлення користувачу
            else
            {
                MessageBox.Show("Select some row", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (CategoryItemList.SelectedItem is Category selectedCategory)
            {
                //видаляємо його з контексту
                context.Categories.Remove(selectedCategory);
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
    }
}
