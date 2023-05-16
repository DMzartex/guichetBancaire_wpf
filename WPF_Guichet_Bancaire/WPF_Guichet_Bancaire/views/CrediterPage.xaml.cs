using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
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
using MySql.Data.MySqlClient;
using WPF_Guichet_Bancaire.Form;
using WPF_Guichet_Bancaire.model;

namespace WPF_Guichet_Bancaire.views
{
    /// <summary>
    /// Logique d'interaction pour CrediterPage.xaml
    /// </summary>
    public partial class CrediterPage : Page
    {
        double sommeAjoute;
        MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
        public MySqlDataReader afficheCompte;
        Query query = new Query();
        public CrediterPage()
        {
            InitializeComponent();
            if (mainWindow.monUser != null)
            {
                int userId = mainWindow.monUser.Id;
                afficheCompte = mainWindow.query.selectCompteCourant(userId);
            }
            setupInterface();
            createEvent();
            
        }

        public void setupInterface()
        {
            while (afficheCompte.Read())
            {
                string numeroCompte = afficheCompte["numeroCompte"].ToString();
                RadioButton radioButton = new RadioButton();
                radioButton.Content = numeroCompte;
                radioButton.GroupName = "compte";
                radioButton.Foreground = new SolidColorBrush(Colors.White);
                radioButton.Margin = new Thickness(20,10,0,0);
                radioButton.Checked += RadioButton_Checked;
                stackComptes.Children.Add(radioButton); 
            }
        }

        public void createEvent()
        {
            
            btnCrediter.Click += BtnCrediter_Click;
        }

        public int indexObjetCompteCourant()
        {
           int idObjet = 0;
           for(int i = 0; i < mainWindow.compteCourant.Length; i++)
           {
                if (mainWindow.compteCourant[i].IdCompte == mainWindow.compteCourantSelect)
                {
                    idObjet = i;
                }
           }

            return idObjet;
        }

       
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton checkedButton = sender as RadioButton;
            mainWindow.compteCourantSelect = query.selectIdCompteCourant(checkedButton.Content.ToString());
        }

        private void BtnCrediter_Click(object sender, RoutedEventArgs e)
        {
            double soldeModif;

            if(mainWindow.compteCourantSelect != 0)
            {
                if (txtMontantAjt.Text != "")
                {
                    if(double.TryParse(txtMontantAjt.Text, out soldeModif))
                    {
                       string resultTransaction = mainWindow.compteCourant[indexObjetCompteCourant()].Crediter(soldeModif);
                       MessageBox.Show(resultTransaction);
                    }
                }
                else
                {
                    MessageBox.Show("Vous n'avez pas choisi un montant valide pour effectuer la transaction.");
                }
            }
            else
            {
                MessageBox.Show("Vous n'avez pas séléctionné de compte pour effectuer l'opération.");
            }
        }
    }
}


// Creer un événement pour chaque radioButton et une variables 
// Au click sur le button modif le solde dans l'objet et dans la db 