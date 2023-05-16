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
using WPF_Guichet_Bancaire.model;

namespace WPF_Guichet_Bancaire.views
{
    /// <summary>
    /// Logique d'interaction pour VersementPage.xaml
    /// </summary>
    public partial class VersementPage : Page
    {
        string typeCompteVersement = "";
        MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
        Query query = new Query();
        public MySqlDataReader afficheCompteEpargne;
        public MySqlDataReader afficheCompteCourant;
        List<string> compteCourantList = new List<string>();
        List<string> compteEpargneList = new List<string>();
        public VersementPage()
        {
            InitializeComponent();
            if (mainWindow.monUser != null)
            {
                int userId = mainWindow.monUser.Id;
                afficheCompteEpargne = mainWindow.query.selectCompteEpargne(userId);
                afficheCompteCourant = mainWindow.query.selectCompteCourant(userId);
            }
            createEvent();
            setupInterface();
        }

        public void createEvent()
        {
            btnEpargne.Checked += BtnEpargne_Checked;
            btnCourant.Checked += BtnCourant_Checked;
            validerVersement.Click += ValiderVersement_Click;
        }

        public void setupInterface()
        {
            if(typeCompteVersement != "")
            {
                if(typeCompteVersement == "Epargne")
                {
                    btnEpargne.IsEnabled = false;
                    btnCourant.IsEnabled = true;
                    stackEpargne.Children.Clear();
                    stackCourant.Children.Clear();
                    mainWindow.compteCourantSelect = 0;
                    mainWindow.compteEpargneSelect = 0;

                    TextBlock titleCompteEpargne = new TextBlock();
                    titleCompteEpargne.Text = "Selectionné un compte epargne pour effectué le virement";
                    titleCompteEpargne.FontSize = 18;
                    titleCompteEpargne.Foreground = Brushes.White;
                    titleCompteEpargne.Margin = new Thickness(20, 5, 0, 5);
                    stackEpargne.Children.Add(titleCompteEpargne);
                    
                    
                    while (afficheCompteEpargne.Read())
                    {
                        string numeroCompteEpargne = afficheCompteEpargne["numeroCompte"].ToString();
                        compteEpargneList.Add(numeroCompteEpargne);
                    }

                    foreach (string numeroCompteEpargne in compteEpargneList)
                    {
                        RadioButton radioButtonEpargne = new RadioButton();
                        radioButtonEpargne.Content = numeroCompteEpargne;
                        radioButtonEpargne.GroupName = "compteEpargne";
                        radioButtonEpargne.Foreground = new SolidColorBrush(Colors.White);
                        radioButtonEpargne.Margin = new Thickness(20, 10, 0, 0);
                        radioButtonEpargne.Checked += RadioButtonEpargne_Checked;
                        stackEpargne.Children.Add(radioButtonEpargne);
                    }

                    
                    while (afficheCompteCourant.Read())
                    {
                        string numeroCompteCourant = afficheCompteCourant["numeroCompte"].ToString();
                        compteCourantList.Add(numeroCompteCourant);
                    }

                    foreach(string numeroCompteCourant in compteCourantList)
                    {
                        RadioButton radioButtonCourant = new RadioButton();
                        radioButtonCourant.Content = numeroCompteCourant;
                        radioButtonCourant.GroupName = "compteCourant";
                        radioButtonCourant.Foreground = new SolidColorBrush(Colors.White);
                        radioButtonCourant.Margin = new Thickness(20, 10, 0, 0);
                        radioButtonCourant.Checked += RadioButtonCourant_Checked;
                        stackCourant.Children.Add(radioButtonCourant);
                    }

                }

                if(typeCompteVersement == "Courant")
                {
                    btnEpargne.IsEnabled = true;
                    btnCourant.IsEnabled = false;
                    mainWindow.compteCourantSelect = 0;
                    mainWindow.compteEpargneSelect = 0;

                    stackEpargne.Children.Clear();
                    stackCourant.Children.Clear();

                    while (afficheCompteEpargne.Read())
                    {
                        string numeroCompteEpargne = afficheCompteEpargne["numeroCompte"].ToString();
                        compteEpargneList.Add(numeroCompteEpargne);
                    }

                    foreach (string numeroCompteEpargne in compteEpargneList)
                    {
                        RadioButton radioButtonEpargne = new RadioButton();
                        radioButtonEpargne.Content = numeroCompteEpargne;
                        radioButtonEpargne.GroupName = "compteEpargne";
                        radioButtonEpargne.Foreground = new SolidColorBrush(Colors.White);
                        radioButtonEpargne.Margin = new Thickness(20, 10, 0, 0);
                        radioButtonEpargne.Checked += RadioButtonEpargne_Checked;
                        stackCourant.Children.Add(radioButtonEpargne);
                    }

                   
                    while (afficheCompteCourant.Read())
                    {
                        string numeroCompteCourant = afficheCompteCourant["numeroCompte"].ToString();
                        compteCourantList.Add(numeroCompteCourant);
                    }

                    foreach (string numeroCompteCourant in compteCourantList)
                    {
                        RadioButton radioButtonCourant = new RadioButton();
                        radioButtonCourant.Content = numeroCompteCourant;
                        radioButtonCourant.GroupName = "compteCourant";
                        radioButtonCourant.Foreground = new SolidColorBrush(Colors.White);
                        radioButtonCourant.Margin = new Thickness(20, 10, 0, 0);
                        radioButtonCourant.Checked += RadioButtonCourant_Checked;
                        stackEpargne.Children.Add(radioButtonCourant);
                    }
                }
            }
        }

        public int indexObjetCompteCourant()
        {
            int idObjet = 0;
            for (int i = 0; i < mainWindow.compteCourant.Length; i++)
            {
                if (mainWindow.compteCourant[i].IdCompte == mainWindow.compteCourantSelect)
                {
                    idObjet = i;
                }
            }

            return idObjet;
        }

        public int indexObjetCompteEpargne()
        {
            int idObjet = 0;
            for (int i = 0; i < mainWindow.compteEpargne.Length; i++)
            {
                if (mainWindow.compteEpargne[i].IdCompte == mainWindow.compteEpargneSelect)
                {
                    idObjet = i;
                }
            }

            return idObjet;
        }

        private void RadioButtonCourant_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton checkedButton = sender as RadioButton;
            mainWindow.compteCourantSelect = query.selectIdCompteCourant(checkedButton.Content.ToString());
        }

        private void RadioButtonEpargne_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton checkedButton = sender as RadioButton;
            mainWindow.compteEpargneSelect = query.selectIdCompteEpargne(checkedButton.Content.ToString());
        }

        private void BtnEpargne_Checked(object sender, RoutedEventArgs e)
        {
            typeCompteVersement = "Epargne";
            setupInterface();
        }

        private void BtnCourant_Checked(object sender, RoutedEventArgs e)
        {
            typeCompteVersement = "Courant";
            setupInterface();
        }

        private void ValiderVersement_Click(object sender, RoutedEventArgs e)
        {
           
            double sommeVerse;
            if (double.TryParse(txbSommeVerse.Text, out sommeVerse))
            {
                if(mainWindow.compteCourantSelect != 0)
                {
                    if(mainWindow.compteEpargneSelect != 0)
                    {
                        if (typeCompteVersement == "Epargne")
                        {

                            string result = mainWindow.compteEpargne[indexObjetCompteEpargne()].Versement(mainWindow.compteCourant[indexObjetCompteCourant()], sommeVerse);
                            MessageBox.Show(result);

                        }
                        else if (typeCompteVersement == "Courant")
                        {

                            string result = mainWindow.compteCourant[indexObjetCompteCourant()].Versement(mainWindow.compteEpargne[indexObjetCompteEpargne()], sommeVerse);
                            MessageBox.Show(result);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Selectionner un compte Epargne !");
                    }
                }
                else
                {
                    MessageBox.Show("Selectionner un compte courant !");
                }
            }
            else
            {
                MessageBox.Show("Entrez un montant valide svp.");
            }
            
        }

    }
}
