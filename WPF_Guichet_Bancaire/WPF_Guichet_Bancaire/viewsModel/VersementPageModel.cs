using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Guichet_Bancaire.@class;

namespace WPF_Guichet_Bancaire.viewsModel
{
    internal class VersementPageModel
    {
        public void createCompteEpargne(MySqlDataReader compteEpargne, out CompteBancaire[] comptes)
        {
           List<CompteBancaire> comptesEpargneList = new List<CompteBancaire>();
            if (compteEpargne.HasRows)
            {
                while (compteEpargne.Read())
                {
                    int idCompte = compteEpargne.GetInt32("compteEpargneId"); /// Problème de nom dans la db la je veux récup l'id d'un compteCourant
                    string numCompte = compteEpargne.GetString("numeroCompte");
                    string nomPropri = compteEpargne.GetString("nomPropri");
                    string prenomPropri = compteEpargne.GetString("prenomPropri");
                    double solde = compteEpargne.GetDouble("solde");
                    string typeCompte = compteEpargne.GetString("typeCompte");
                    double tauxInteret = compteEpargne.GetDouble("tauxInteret");

                    comptesEpargneList.Add(new CompteEpargne(idCompte, numCompte, nomPropri, prenomPropri, solde, typeCompte, tauxInteret));
                }
            }

            comptes = comptesEpargneList.ToArray();
        }
    }
}
