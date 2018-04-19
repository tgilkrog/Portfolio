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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDrinkzy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDrink(object sender, RoutedEventArgs e)
        {
            Main.Content = new DrinkPage();
        }

        private void Customer_click(object sender, RoutedEventArgs e)
        {
            Main.Content = new CustomerPage();
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new UserPage();
        }
        private void Ingredient_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new IngredientPage();
        }

        private void Storage_click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Storage();
        }
    }
}
