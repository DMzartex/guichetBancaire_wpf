using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WPF_Guichet_Bancaire.views
{
    /// <summary>
    /// Logique d'interaction pour InfosComptesPage.xaml
    /// </summary>
    public partial class InfosComptesPage : Page
    {
        MainWindow mainWindow = (MainWindow) App.Current.MainWindow;
        string typeCompteSelect;
       
        public InfosComptesPage()
        {
            InitializeComponent();
            createEvent();
        }

        public void createEvent()
        {
            btnEpargne.Checked += BtnEpargne_Checked;
            btnCourant.Checked += BtnCourant_Checked;
        }

        public void setupInterface()
        {
            if(typeCompteSelect == "Courant")
            {
                btnCourant.IsEnabled = false;
                btnEpargne.IsEnabled = true;
                stackSelectCompte.Children.Clear();

                ComboBox comboxCourant = new ComboBox();
                comboxCourant.SelectionChanged += ComboxCourant_SelectionChanged;
                comboxCourant.Margin = new Thickness(0, 10, 0, 0);
                comboxCourant.Width = 250;
                comboxCourant.HorizontalAlignment = HorizontalAlignment.Left;
                comboxCourant.SelectedIndex = 0;
                for(int i = 0; i < mainWindow.compteCourant.Length; i++)
                {
                    ComboBoxItem itemCompte = new ComboBoxItem();
                    itemCompte.Content = mainWindow.compteCourant[i].NumeroCompte;
                    itemCompte.Tag = i.ToString();
                    comboxCourant.Items.Add(itemCompte);
                }
                stackSelectCompte.Children.Add(comboxCourant);
            }else if(typeCompteSelect == "Epargne")
            {
                btnCourant.IsEnabled = true;
                btnEpargne.IsEnabled = false;
                stackSelectCompte.Children.Clear();

                ComboBox comboxEpargne = new ComboBox();
                comboxEpargne.SelectionChanged += ComboxEpargne_SelectionChanged;
                comboxEpargne.Margin = new Thickness(0, 10, 0, 0);
                comboxEpargne.Width = 250;
                comboxEpargne.HorizontalAlignment = HorizontalAlignment.Left;
                comboxEpargne.SelectedIndex = 0;
                for (int i = 0; i < mainWindow.compteEpargne.Length; i++)
                {
                    ComboBoxItem itemCompte = new ComboBoxItem();
                    itemCompte.Content = mainWindow.compteEpargne[i].NumeroCompte;
                    itemCompte.Tag = i.ToString();
                    comboxEpargne.Items.Add(itemCompte);
                }
                stackSelectCompte.Children.Add(comboxEpargne);
            }
        }

        private void ComboxEpargne_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboxEpargne = (ComboBox)sender;
            ComboBoxItem SelectedItem = (ComboBoxItem)comboxEpargne.SelectedItem;
            int tagSelect = int.Parse(SelectedItem.Tag.ToString());
            string result = mainWindow.compteEpargne[tagSelect].AfficheCaractCompte();
            txtInfoCompte.Text = result;
        }

        private void ComboxCourant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboxCourant = (ComboBox)sender;
            ComboBoxItem SelectedItem = (ComboBoxItem)comboxCourant.SelectedItem;
            int tagSelect = int.Parse(SelectedItem.Tag.ToString());
            string result = mainWindow.compteCourant[tagSelect].AfficheCaractCompte();
            txtInfoCompte.Text = result;
        }

        private void BtnCourant_Checked(object sender, RoutedEventArgs e)
        {
            typeCompteSelect = "Courant";
            setupInterface();
        }

        private void BtnEpargne_Checked(object sender, RoutedEventArgs e)
        {
            typeCompteSelect = "Epargne";
            setupInterface();
        }
    }
}
