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
using WpfDrinkzy.DrinkServiceRef;
using WpfDrinkzy.IngredientServiceRef;

namespace WpfDrinkzy
{ 
    public partial class DrinkPage : Page
    {
        DrinkServiceClient DrinkClient = new DrinkServiceClient();
        IngredientServiceClient IngredientClient = new IngredientServiceClient();
        public DrinkPage()
        {
            InitializeComponent();
            fillViewList();
        }

        public void fillViewList()
        {
            DrinkList.ItemsSource = null;
            DrinkList.ItemsSource = DrinkClient.getAllDrinks();
            AllIngredientList.ItemsSource = IngredientClient.getAllIngredients();
        }

        public void CreateDrink()
        {
            Drink drink = new Drink
            {
                Name = txtName.Text,
                Description = txtDesc.Text,
                Price = Decimal.Parse(txtPrice.Text),
                Img = txtImg.Text
            };
            DrinkClient.CreateDrink(drink);
        }

        public void UpdateDrink()
        {
            Drink d;
            d = (Drink)DrinkList.SelectedItem;

            d.Name = txtName.Text;
            d.Description = txtDesc.Text;
            d.Price = Decimal.Parse(txtPrice.Text);
            d.Img = txtImg.Text;
   
            DrinkClient.UpdateDrink(d);
        }

        public void DeleteDrink()
        {
            Drink d = (Drink)DrinkList.SelectedItem;
            DrinkClient.DeleteDrinkById(d.ID);
        }

        public void Details(Drink drink)
        {
            if(drink != null)
            {
                IngredientList.ItemsSource = DrinkClient.GetDrink(drink.ID).Ingredients;
                txtName.Text = drink.Name; ;
                txtDesc.Text = drink.Description;
                txtPrice.Text = drink.Price.ToString();
                txtImg.Text = drink.Img;
            }
        }

        public void AddIngredient()
        {
            Drink d = (Drink)DrinkList.SelectedItem;
            WpfDrinkzy.IngredientServiceRef.Ingredient i = 
                (WpfDrinkzy.IngredientServiceRef.Ingredient)AllIngredientList.SelectedItem;

            DrinkClient.AddIngredientToDrink(i.ID, d);
            IngredientList.ItemsSource = DrinkClient.GetDrink(d.ID).Ingredients;
        }

        public void DeleteIngredient()
        {
            Drink d = (Drink)DrinkList.SelectedItem;
            WpfDrinkzy.DrinkServiceRef.Ingredient i =
                (WpfDrinkzy.DrinkServiceRef.Ingredient)IngredientList.SelectedItem;

            DrinkClient.DeleteIngredientFromDrink(i.ID, d);
            IngredientList.ItemsSource = DrinkClient.GetDrink(d.ID).Ingredients;
        }

        public void Changer(object sender, SelectionChangedEventArgs e)
        {
            Drink d = (Drink)DrinkList.SelectedItem;
            Details(d);
        }

        private void createDrink_Click(object sender, RoutedEventArgs e)
        {
            CreateDrink();

            CleanTextBox();
            fillViewList();
        }

        public void CleanTextBox()
        {
            IngredientList.ItemsSource = null;
            DrinkList.UnselectAll();
            txtName.Text = "";
            txtDesc.Text = "";
            txtPrice.Text = "";
            txtImg.Text = "";
        }

        private void drinkUpdate_click(object sender, RoutedEventArgs e)
        {
            UpdateDrink();
            fillViewList();
        }

        private void DeleteDrink_click(object sender, RoutedEventArgs e)
        {
            DeleteDrink();
            fillViewList();
        }

        private void cleanBoxes_click(object sender, RoutedEventArgs e)
        {
            CleanTextBox();
        }

        private void AddIngredient_click(object sender, RoutedEventArgs e)
        {
            AddIngredient();
        }

        private void DeleteIng_click(object sender, RoutedEventArgs e)
        {
            DeleteIngredient();
        }
    }
}
