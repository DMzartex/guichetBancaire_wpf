using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Guichet_Bancaire.viewsModel
{
    internal class Deconnexion
    {
        public void DeconnexionUser()
        {
            try
            {
                MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
                mainWindow.isLoggedIn = false;
                MessageBox.Show("Vous êtes déconnecté.");
            }
            catch
            {
                MessageBox.Show("La deconnexion à échoué.");
            }
        }
    }
}
