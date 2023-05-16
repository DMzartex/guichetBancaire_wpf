using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Guichet_Bancaire.@class;

namespace WPF_Guichet_Bancaire.viewsModel
{
    internal class CrediterPageModel
    {
        public void createCompteCourant(MySqlDataReader compteCourant, out CompteBancaire[] comptes)
        {
            List<CompteBancaire> compteCourantList = new List<CompteBancaire>();
            if (compteCourant.HasRows)
            {

                while (compteCourant.Read())
                {
                    int idCompte = compteCourant.GetInt32("compteEpargneId"); /// Problème de nom dans la db la je veux récup l'id d'un compteCourant
                    string numCompte = compteCourant.GetString("numeroCompte");
                    string nomPropri = compteCourant.GetString("nomPropri");
                    string prenomPropri = compteCourant.GetString("prenomPropri");
                    double solde = compteCourant.GetDouble("solde");
                    string typeCompte = compteCourant.GetString("typeCompte");
                    double decouvertAut = compteCourant.GetDouble("decouvertAut");

                    compteCourantList.Add(new CompteCourant(idCompte, numCompte, nomPropri, prenomPropri, solde, typeCompte, decouvertAut));
                }
            }
            comptes = compteCourantList.ToArray();
        }

    }
}
