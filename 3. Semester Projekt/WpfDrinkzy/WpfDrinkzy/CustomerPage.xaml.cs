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
using WpfDrinkzy.CustomerServiceRef;
using WpfDrinkzy.MenuCardServiceRef;
using WpfDrinkzy.DrinkServiceRef;

namespace WpfDrinkzy
{
    /// <summary>
    /// Interaction logic for CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : Page
    {
        CustomerServiceClient CustomerClient = new CustomerServiceClient();
        MenuCardServiceClient MenuCardClient = new MenuCardServiceClient();
        DrinkServiceClient DrinkClient = new DrinkServiceClient();

        public CustomerPage()
        {
            InitializeComponent();
            fillViewList();
        }

        public void fillViewList()
        {
            CustomerList.ItemsSource = null;
            CustomerList.ItemsSource = CustomerClient.GetAllCustomers();
            DrinkList.ItemsSource = DrinkClient.getAllDrinks();
        }

        public void Changer(object sender, SelectionChangedEventArgs e)
        {
            WpfDrinkzy.CustomerServiceRef.Customer c = (WpfDrinkzy.CustomerServiceRef.Customer)CustomerList.SelectedItem;
            Details(c);
        }

        public void CreateCustomer()
        {
            WpfDrinkzy.CustomerServiceRef.Customer c = new WpfDrinkzy.CustomerServiceRef.Customer
            {
                CusName = txtName.Text,
                Region = txtRegion.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text,
                Img = txtImage.Text,
                CusPassword = txtPassword.Text
            };

            CustomerClient.CreateCustomer(c);
            clearTextboxes();

        }

        public void UpdateCustomer()
        {
            WpfDrinkzy.CustomerServiceRef.Customer c = (WpfDrinkzy.CustomerServiceRef.Customer)CustomerList.SelectedItem;

            c.CusName = txtName.Text;
            c.Region = txtRegion.Text;
            c.Address = txtAddress.Text;
            c.Phone = txtPhone.Text;
            c.Email = txtEmail.Text;
            c.Img = txtImage.Text;

            CustomerClient.UpdateCustomer(c);
            clearTextboxes();
        }

        public void DeleteCustomer()
        {
            WpfDrinkzy.CustomerServiceRef.Customer c = (WpfDrinkzy.CustomerServiceRef.Customer)CustomerList.SelectedItem;
            CustomerClient.DeleteCustomer(c.ID);
        }

        public void AddDrinkToMenu()
        {
            WpfDrinkzy.CustomerServiceRef.Customer c = (WpfDrinkzy.CustomerServiceRef.Customer)CustomerList.SelectedItem;

            if (MenuCardClient.GetMenuByCustomerID(c.ID) == null)
            {
                MenuCardClient.createMenuCard(c.ID);
            }
                WpfDrinkzy.DrinkServiceRef.Drink d = (WpfDrinkzy.DrinkServiceRef.Drink)DrinkList.SelectedItem;
                MenuCardClient.addDrink(MenuCardClient.GetMenuByCustomerID(c.ID), d.ID);
                MenuList.ItemsSource = MenuCardClient.GetMenuByCustomerID(c.ID).Drinks;
        }

        public void Details(WpfDrinkzy.CustomerServiceRef.Customer customer)
        {
            if (customer != null)
            {
                if (MenuCardClient.GetMenuByCustomerID(customer.ID) == null) { MenuList.ItemsSource = null; }
                else {MenuList.ItemsSource = MenuCardClient.GetMenuByCustomerID(customer.ID).Drinks; }
                
                txtName.Text = customer.CusName; ;
                txtRegion.Text = customer.Region;
                txtAddress.Text = customer.Address;
                txtPhone.Text = customer.Phone;
                txtEmail.Text = customer.Email;
                txtImage.Text = customer.Img;
            }
        }

        public void DeleteDrinkFromMenu()
        {
            WpfDrinkzy.MenuCardServiceRef.Drink d = (WpfDrinkzy.MenuCardServiceRef.Drink)MenuList.SelectedItem;
            WpfDrinkzy.CustomerServiceRef.Customer c = (WpfDrinkzy.CustomerServiceRef.Customer) CustomerList.SelectedItem;
            MenuCardClient.DeleteDrinkFromMenu( MenuCardClient.GetMenuByCustomerID(c.ID).ID, d.ID);

            MenuList.ItemsSource = MenuCardClient.GetMenuByCustomerID(c.ID).Drinks;
        }

        private void CreateCustomer_click(object sender, RoutedEventArgs e)
        {
            CreateCustomer();
            fillViewList();
        }

        private void UpdateCustomer_click(object sender, RoutedEventArgs e)
        {
            UpdateCustomer();
            fillViewList();
        }

        private void DeleteCustomer_click(object sender, RoutedEventArgs e)
        {
            DeleteCustomer();
            fillViewList();
        }

        private void btnAddDrink_click(object sender, RoutedEventArgs e)
        {
            AddDrinkToMenu();
            
        }

        private void deleteDrink_click(object sender, RoutedEventArgs e)
        {
            DeleteDrinkFromMenu();
            fillViewList();
        }

        public void clearTextboxes()
        {
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtImage.Text = "";
            txtName.Text = "";
            txtPassword.Text = "";
            txtPhone.Text = "";
            txtRegion.Text = "";
        }
    }
}
