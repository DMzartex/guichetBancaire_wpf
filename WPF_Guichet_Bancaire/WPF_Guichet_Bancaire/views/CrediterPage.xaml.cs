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
using WPF_Guichet_Bancaire.model;

namespace WPF_Guichet_Bancaire.views
{
    /// <summary>
    /// Logique d'interaction pour CrediterPage.xaml
    /// </summary>
    public partial class CrediterPage : Page
    {
        Query mesRequetes = new Query();
        MySqlDataReader afficheCompte;
        public CrediterPage()
        {
            InitializeComponent();
            afficheCompte = mesRequetes.selectCompteCourant();
            setupInterface();
            
        }

        public void setupInterface()
        {
            while (afficheCompte.Read())
            {
                string numeroCompte = afficheCompte["numeroCompte"].ToString();
                RadioButton radioButton = new RadioButton();
                radioButton.Content = numeroCompte;
                radioButton.GroupName = "compte";
                stackComptes.Children.Add(radioButton);
            }
        }
    }
}
