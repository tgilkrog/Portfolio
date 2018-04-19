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
using WpfDrinkzy.UserServiceRef;
using WpfDrinkzy.DrinkServiceRef;
using WpfDrinkzy.FavoritesServiceRef;

namespace WpfDrinkzy
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        UserServiceClient UserClient = new UserServiceClient();
        DrinkServiceClient DrinkClient = new DrinkServiceClient();
        FavoritesServiceClient FavoriteClient = new FavoritesServiceClient();

        public UserPage()
        {
            InitializeComponent();
            fillViewList();
        }
        public void CreateUser()
        {
            WpfDrinkzy.UserServiceRef.User u = new WpfDrinkzy.UserServiceRef.User();
            DateTime btext = DateTime.Parse(birthText.Text);

            u.UserName = UserText.Text;
            u.Password = PassText.Text;
            u.FirstName = FirstnText.Text;
            u.LastName = LastnText.Text;
            u.Gender = GenderText.Text;
            u.Birthday = btext;
            u.Email = mailText.Text;
            u.Phone = phoneText.Text;

            UserClient.CreateUser(u);
        }

        public void UpdateUser()
        {
            WpfDrinkzy.UserServiceRef.User u = (WpfDrinkzy.UserServiceRef.User)UserList.SelectedItem;
            //DateTime btext = DateTime.Parse(birthText.Text);

            u.UserName = UserText.Text;
            u.Password = PassText.Text;
            u.FirstName = FirstnText.Text;
            u.LastName = LastnText.Text;
            u.Gender = GenderText.Text;
            u.Birthday = Convert.ToDateTime(birthText.Text);
            u.Email = mailText.Text;
            u.Phone = phoneText.Text;

            UserClient.UpdateUser(u);
        }

        public void DeleteUser()
        {
            WpfDrinkzy.UserServiceRef.User u = (WpfDrinkzy.UserServiceRef.User)UserList.SelectedItem;
            UserClient.DeleteUser(u.ID);
        }

        public void fillViewList()
        {
            UserList.ItemsSource = null;
            UserList.ItemsSource = UserClient.getAllUsers();

            DrinkList.ItemsSource = null;
            DrinkList.ItemsSource = DrinkClient.getAllDrinks();
        }

        private void CreateUser_Click(object sender, RoutedEventArgs e)
        {
            CreateUser();
            fillViewList();
        }

        private void UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            UpdateUser();
            fillViewList();
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            DeleteUser();
            fillViewList();
        }
        public void Details(WpfDrinkzy.UserServiceRef.User user)
        {
            if (user != null)
            {
                //UserList.ItemsSource = UserClient.GetUser(user.ID).UserName;
                //UserList.ItemsSource = UserClient.GetUser(user.ID).FirstName;
                //UserList.ItemsSource = UserClient.GetUser(user.ID).LastName;
                UserText.Text = user.UserName;
                PassText.Text = user.Password;
                FirstnText.Text = user.FirstName;
                LastnText.Text = user.LastName;
                GenderText.Text = user.Gender;
                birthText.Text = user.Birthday.ToString();
                mailText.Text = user.Email;
                phoneText.Text = user.Phone;

                WpfDrinkzy.UserServiceRef.User u = (WpfDrinkzy.UserServiceRef.User)UserList.SelectedItem;
                UserClient.createWalletAndFavorites(user.ID);

                FavoriteList.ItemsSource = null;
                FavoriteList.ItemsSource = FavoriteClient.GetAllDrinksByUser(FavoriteClient.GetFavoritesByUserID(u.ID).ID);
            }
        }

        public void Changer(object sender, SelectionChangedEventArgs e)
        {
            WpfDrinkzy.UserServiceRef.User u = (WpfDrinkzy.UserServiceRef.User)UserList.SelectedItem;
            Details(u);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WpfDrinkzy.UserServiceRef.User u = (WpfDrinkzy.UserServiceRef.User)UserList.SelectedItem;
            WpfDrinkzy.DrinkServiceRef.Drink d = (WpfDrinkzy.DrinkServiceRef.Drink)DrinkList.SelectedItem;

            FavoriteClient.addDrink(u.ID, d.ID);
        }
    }
}