using System;
using System.Collections.Generic;
using System.Text;
using WPF_Guichet_Bancaire.@class;
using WPF_Guichet_Bancaire.model;

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

        public CompteEpargne(int idCompte,string numeroCompte, string nomPropri, string prenomPropri, double solde, string typeCompte, double tauxInteret)
        {
            _idCompte = idCompte;
            _numeroCompte = numeroCompte;
            _nomPropri = nomPropri;
            _prenomPropri = prenomPropri;
            _solde = solde;
            _typeCompte = typeCompte;
            _tauxInteret = tauxInteret;
        }

        public override bool VerifSomme(double somme)
        {
            if(Solde > 0)
            {
                if ((Solde / 2) >= somme)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override string Versement(CompteBancaire compteCourant, double sommeVerse)
        {
            Query query = new Query();
            string result = "";

            if (VerifSomme(sommeVerse))
            {
                compteCourant.Solde += sommeVerse;
                Solde -= sommeVerse;
                query.modifSoldeCompteCourant(compteCourant.IdCompte, compteCourant.Solde);
                query.modifSoldeCompteEpargne(IdCompte, Solde);
                result = "Le versement de : " + sommeVerse + " à bien été effectué !";
            }
            else
            {
                result = "Le versement de : " + sommeVerse + " n'a pas pu être effectué !";
            }

            return result;
        }

        public override string AfficheCaractCompte()
        {
            string result = "Type de compte : " + TypeCompte + "\nNuméro de compte : " + NumeroCompte
                + "\nNom du titulaire : " + NomPropri + "\nPrénom du titulaire " + PrenomPropri
                + "\nVotre taux d'intéret : " + TauxInteret + " %" + "\nVotre solde : " + Solde;
            return result;
        }

    }
}
