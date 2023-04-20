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
using WPF_Guichet_Bancaire.model;

namespace WPF_Guichet_Bancaire.Form
{
    /// <summary>
    /// Logique d'interaction pour loginForm.xaml
    /// </summary>
    public partial class loginForm : Page
    {
        Query loginQuery = new Query();
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
            
            isLoggedIn = loginQuery.Login(emailTxtBox.Text, passwordBox.Password);
            MainWindow mainWindow = new MainWindow();
            mainWindow.isLoggedIn= isLoggedIn;
            mainWindow.checkLogin();
            mainWindow.InitializeComponent();
        }

        public bool IsLoginSuccessful
        {
            get { return isLoggedIn; }
        }
    }
}
