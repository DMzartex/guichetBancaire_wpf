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
using WPF_Guichet_Bancaire.Form;
using WPF_Guichet_Bancaire.model;
using WPF_Guichet_Bancaire.views;
using WPF_Guichet_Bancaire.viewsModel;

namespace WPF_Guichet_Bancaire
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public bool isLoggedIn = false;
        public Users monUser;
        public Query query = new Query();
        public CompteBancaire[] compteCourant;
        public CompteBancaire[] compteEpargne;
        public int compteCourantSelect;
        public int compteEpargneSelect;
        public MySqlDataReader compteEpargneDb;
        public MySqlDataReader compteCourantDb;
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
                Main.Content = new loginForm();
                stackMenu.Visibility = Visibility.Hidden;
                
            }
            else if(isLoggedIn)
            {
                CrediterPageModel crediterPageModel = new CrediterPageModel();
                compteCourantDb = query.selectCompteCourant(monUser.Id);
                crediterPageModel.createCompteCourant(compteCourantDb, out compteCourant);
                VersementPageModel versementPageModel = new VersementPageModel();
                compteEpargneDb =  query.selectCompteEpargne(monUser.Id);
                versementPageModel.createCompteEpargne(compteEpargneDb,out compteEpargne);
                Main.Content = new CrediterPage();
                stackMenu.Visibility = Visibility.Visible;
            }
        }

        public void CreateEvent()
        {
            btnCrediter.Click += BtnCrediter_Click;
            btnProfil.Click += BtnProfil_Click;
            btnDeconnexion.Click += BtnDeconnexion_Click;
            btnVersement.Click += BtnVersement_Click;
            btnInfoCompte.Click += BtnInfoCompte_Click;
        }

        private void BtnInfoCompte_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new InfosComptesPage();
        }

        private void BtnVersement_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new VersementPage();
        }

        private void BtnDeconnexion_Click(object sender, RoutedEventArgs e)
        {
            Deconnexion deco = new Deconnexion();
            deco.DeconnexionUser();
            checkLogin();
        }

        private void BtnProfil_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ProfilPage();
        }

        private void BtnCrediter_Click(object sender, RoutedEventArgs e)
        {
           Main.Content = new CrediterPage();
        }
    }
}
