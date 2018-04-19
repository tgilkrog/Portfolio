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
using WpfDrinkzy.StorageServiceRef;

namespace WpfDrinkzy
{
    public partial class Storage : Page
    {
        CustomerServiceClient CusClient = new CustomerServiceClient();
        StorageServiceClient sClient = new StorageServiceClient();
        public Storage()
        {
            InitializeComponent();
            fillViewList();
        }

        public void fillViewList()
        {
            CustomerList.ItemsSource = null;
            CustomerList.ItemsSource = CusClient.GetAllCustomers();
        }

        public void Changer(object sender, SelectionChangedEventArgs e)
        {
            WpfDrinkzy.CustomerServiceRef.Customer c = (WpfDrinkzy.CustomerServiceRef.Customer)CustomerList.SelectedItem;
            StorageList.ItemsSource = null;

            List<WpfDrinkzy.StorageServiceRef.Storage> allProducts = new List<WpfDrinkzy.StorageServiceRef.Storage>();
            allProducts.AddRange(sClient.GetAllDrinkStorage(c.ID).ToList());
            allProducts.AddRange(sClient.GetAllAlchoholStorage(c.ID).ToList());
            allProducts.AddRange(sClient.GetAllHelflaskStorage(c.ID).ToList());

            StorageList.ItemsSource = allProducts;
        }

        public void Changer2(object sender, SelectionChangedEventArgs e)
        {
            WpfDrinkzy.StorageServiceRef.Storage storage = (WpfDrinkzy.StorageServiceRef.Storage)StorageList.SelectedItem;
            Details(storage);
        }

        public void UpdateStorage()
        {
            WpfDrinkzy.StorageServiceRef.Storage storage = (WpfDrinkzy.StorageServiceRef.Storage)StorageList.SelectedItem;

            storage.Amount = int.Parse(txtAmount.Text);
            storage.MinAmount = int.Parse(txtMinAMount.Text);
            storage.MaxAmount = int.Parse(txtMaxAmount.Text);

            sClient.UpdateStorages(storage);
        }

        public void Details(WpfDrinkzy.StorageServiceRef.Storage storage)
        {
            if(storage != null)
            {
                txtAmount.Text = Convert.ToString(storage.Amount);
                txtMinAMount.Text = Convert.ToString(storage.MinAmount);
                txtMaxAmount.Text = Convert.ToString(storage.MaxAmount);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateStorage();
        }
    }
}
