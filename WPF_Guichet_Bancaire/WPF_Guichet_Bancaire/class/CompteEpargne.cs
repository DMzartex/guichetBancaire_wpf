using System;
using System.Collections.Generic;
using System.Text;
using WPF_Guichet_Bancaire.@class;

namespace WPF_Guichet_Bancaire.@class
{
    public class CompteEpargne : CompteBancaire
    {
        private double _tauxInteret;

        public double TauxInteret
        {
            get { return _tauxInteret; }
            set { _tauxInteret = value; }
        }

        public CompteEpargne(string numeroCompte, string nomPropri, string prenomPropri, double solde, string typeCompte, double tauxInteret)
        {
            _numeroCompte = numeroCompte;
            _nomPropri = nomPropri;
            _prenomPropri = prenomPropri;
            _solde = solde;
            _typeCompte = typeCompte;
            _tauxInteret = tauxInteret;
        }

        public override bool VerifSomme(double somme)
        {
            if (Solde >= somme)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string Versement(CompteBancaire compteBancaire, double sommeVerse)
        {
            string result;

            if (VerifSomme(sommeVerse))
            {
                if (compteBancaire.TypeCompte == "Courant")
                {
                    compteBancaire.Solde += sommeVerse;
                    Solde -= sommeVerse;
                    result = "Votre virement de " + sommeVerse + " euros vers votre compte épargne " + compteBancaire.NumeroCompte
                        + " à été effectué avec succès";
                }
                else
                {
                    result = "Vous ne pouvez envoyer de l'argent que vers votre ou vos comptes courant";
                }
            }
            else
            {
                result = "Votre solde est insufisant !";
            }

            return result;
        }

        public override string AfficheCaractCompte()
        {
            string result = "Type de compte : " + TypeCompte + " Numéro de compte : " + NumeroCompte
                + "Nom du titulaire : " + NomPropri + " Prénom du titulaire " + PrenomPropri
                + " Votre taux d'intéret : " + TauxInteret + " Votre solde : " + Solde;
            return result;
        }

    }
}
