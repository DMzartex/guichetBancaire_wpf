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
using WPF_Guichet_Bancaire.model;
using WPF_Guichet_Bancaire.viewsModel;

namespace WPF_Guichet_Bancaire.views
{
    /// <summary>
    /// Logique d'interaction pour ProfilPage.xaml
    /// </summary>
    public partial class ProfilPage : Page
    {
        MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
        public ProfilPage()
        {
            InitializeComponent();
            setupPage();
            createEvent();
        }

        public void setupPage()
        {
            txtNom.Text = mainWindow.monUser.Nom;
            txtPrenom.Text = mainWindow.monUser.Prenom;
            txtEmail.Text = mainWindow.monUser.Email;
            txtMdp.Text = mainWindow.monUser.Password;
            txtId.Text = mainWindow.monUser.Id.ToString();
            txtDate.IsReadOnly = true;
            txtId.IsReadOnly = true;
        }

        public void createEvent()
        {
            btnModif.Click += BtnModif_Click;
        }

        private void BtnModif_Click(object sender, RoutedEventArgs e)
        {
            if(txtNom.Text != "")
            {
                string nom = txtNom.Text;

                if(txtPrenom.Text != "")
                {
                    string prenom = txtPrenom.Text;
                    if(txtEmail.Text != "")
                    {
                        string email = txtEmail.Text;
                        if(txtMdp.Text != "")
                        {
                            string mdp = txtMdp.Text;
                            ModifUserModel modifUser = new ModifUserModel();
                            Query modifDbUser = new Query();
                            bool verifModifObjet = modifUser.ModifUser(nom, prenom, email, mdp);
                            bool verifModifDB = modifDbUser.ModifProfil();
                            if (verifModifObjet)
                            {
                                if (verifModifDB)
                                {
                                    MessageBox.Show("Votre profil à bien été modifier");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vous devez entrez un mdp");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vous devez entrez une email valide");
                    }
                }
                else
                {
                    MessageBox.Show("Vous devez entrez un prenom");
                }
            }
            else
            {
                MessageBox.Show("Vous devez entrez un nom");
            }
        }
    }
}
