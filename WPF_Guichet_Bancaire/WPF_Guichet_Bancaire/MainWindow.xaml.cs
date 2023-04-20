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
using WPF_Guichet_Bancaire.Form;
using WPF_Guichet_Bancaire.views;


namespace WPF_Guichet_Bancaire
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        loginForm loginForm = new loginForm();
        
        public bool isLoggedIn = false;
        public MainWindow()
        {
            InitializeComponent();
            checkLogin();
            CreateEvent();
        }
        public void checkLogin()
        {
            if (!isLoggedIn)
            {
                Main.NavigationUIVisibility = NavigationUIVisibility.Hidden; // Cacher la barre de navigation
                Main.NavigationService.Navigate(new loginForm());
                stackMenu.Visibility = Visibility.Hidden;
                Main.Margin = new Thickness(0,0,0,0);
            }
            else if(isLoggedIn)
            {
                MessageBox.Show("Vous êtes connecté !!!!!!!!!!!!!!!");
                Main.NavigationUIVisibility = NavigationUIVisibility.Visible;
                Main.NavigationService.Navigate(new CrediterPage());
                stackMenu.Visibility = Visibility.Visible;
                Main.Margin = new Thickness(80, 80, 80, 80);
                
            }
        }

        public void CreateEvent()
        {
            btnCrediter.Click += BtnCrediter_Click;
        }

        private void BtnCrediter_Click(object sender, RoutedEventArgs e)
        {
           Main.Content = new CrediterPage();
        }
    }
}
