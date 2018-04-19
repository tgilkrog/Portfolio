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
using WpfDrinkzy.IngredientServiceRef;

namespace WpfDrinkzy
{
    /// <summary>
    /// Interaction logic for IngredientPage.xaml
    /// </summary>
    public partial class IngredientPage : Page
    {
        IngredientServiceClient ingredientServiceClient = new IngredientServiceClient();
        public IngredientPage()
        {
            InitializeComponent();
            fillViewList();
        }

        public void CreateIngredient()
        {
            WpfDrinkzy.IngredientServiceRef.Ingredient i = new WpfDrinkzy.IngredientServiceRef.Ingredient();

            i.Name = txtIngName.Text;
            i.Procent = decimal.Parse(txtProcent.Text);

            ingredientServiceClient.createIngredient(i);
        }
        public void UpdateIngredient()
        {
            WpfDrinkzy.IngredientServiceRef.Ingredient i = (WpfDrinkzy.IngredientServiceRef.Ingredient)IngList.SelectedItem;

            i.Name = txtIngName.Text;
            i.Procent = decimal.Parse(txtProcent.Text);

            ingredientServiceClient.UpdateIngredient(i);
        }
        public void DeleteIngredient()
        {
            WpfDrinkzy.IngredientServiceRef.Ingredient i = (WpfDrinkzy.IngredientServiceRef.Ingredient)IngList.SelectedItem;
            ingredientServiceClient.DeleteIngredient(i.ID);
        }

        public void fillViewList()
        {
            IngList.ItemsSource = null;
            IngList.ItemsSource = ingredientServiceClient.getAllIngredients();

        }
        public void Details(Ingredient ingredient)
        {
            if (ingredient != null)
            {

                txtIngName.Text = ingredient.Name;
                txtProcent.Text = ingredient.Procent.ToString();

            }
        }
        public void Changer(object sender, SelectionChangedEventArgs e)
        {
            Ingredient i = (Ingredient)IngList.SelectedItem;
            Details(i);


        }

        private void CreateIngredient_Click(object sender, RoutedEventArgs e)
        {
            CreateIngredient();
            fillViewList();
        }

        private void UpdateIngredient_Click(object sender, RoutedEventArgs e)
        {
            UpdateIngredient();
            fillViewList();

        }

        private void DeleteIngredient_Click(object sender, RoutedEventArgs e)
        {
            DeleteIngredient();
            fillViewList();
        }
    }

}

