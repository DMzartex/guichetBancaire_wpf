using MySql.Data.MySqlClient;
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
using WPF_Guichet_Bancaire.@class;
using WPF_Guichet_Bancaire.model;
using WPF_Guichet_Bancaire.viewsModel;

namespace WPF_Guichet_Bancaire.Form
{
    /// <summary>
    /// Logique d'interaction pour loginForm.xaml
    /// </summary>
    public partial class loginForm : Page
    {
        Query loginQuery = new Query();
        public static MySqlDataReader readerInfoUsers;
        public bool isLoggedIn = false;
        public loginForm()
        {
            InitializeComponent();
            createEvent();
            
        }

        public void createEvent()
        {
            loginBtn.Click += LoginBtn_Click;
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            isLoggedIn = loginQuery.Login(emailTxtBox.Text, passwordBox.Password,out readerInfoUsers);
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
            mainWindow.isLoggedIn= isLoggedIn;
            ViewsModel.createObjetUser(readerInfoUsers);
            mainWindow.checkLogin();
        }

        public bool IsLoginSuccessful
        {
            get { return isLoggedIn; }
        }


    }
}
