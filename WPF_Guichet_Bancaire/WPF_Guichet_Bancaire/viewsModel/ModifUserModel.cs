using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Guichet_Bancaire.@class;
using WPF_Guichet_Bancaire.Form;

namespace WPF_Guichet_Bancaire.viewsModel
{
    public struct ModifUserModel
    {
        public bool ModifUser(string nom,string prenom,string email,string mdp)
        {
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
            try
            {
                Users user = mainWindow.monUser;
                user.Nom = nom;
                user.Prenom = prenom;
                user.Email = email;
                user.Password = mdp;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
