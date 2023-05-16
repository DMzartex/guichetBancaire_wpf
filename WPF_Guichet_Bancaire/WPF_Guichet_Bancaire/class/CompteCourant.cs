using System;
using System.Collections.Generic;
using System.Text;
using WPF_Guichet_Bancaire.@class;
using WPF_Guichet_Bancaire.model;

namespace WPF_Guichet_Bancaire.@class
{
    public class CompteCourant : CompteBancaire
    {
       
        private double _decouvertAut;

        public double DecouvertAut
        {
            get { return _decouvertAut; }
            set { _decouvertAut = value; }
        }

        public CompteCourant(int idCompte,string numeroCompte, string nomPropri, string prenomPropri, double solde, string typeCompte, double decouvertAut)
        {
            _idCompte = idCompte;
            _numeroCompte = numeroCompte;
            _nomPropri = nomPropri;
            _prenomPropri = prenomPropri;
            _solde = solde;
            _typeCompte = typeCompte;
            _decouvertAut = decouvertAut;
        }

        public override bool VerifSomme(double somme)
        {
            if (Solde - somme >= DecouvertAut)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string Versement(CompteBancaire compteBancaire,double sommeVerse)
        {
            string result;
            Query query = new Query();
            if (VerifSomme(sommeVerse))
            {
                compteBancaire.Solde += sommeVerse;
                Solde -=sommeVerse;
                query.modifSoldeCompteCourant(IdCompte,Solde);
                query.modifSoldeCompteEpargne(compteBancaire.IdCompte, compteBancaire.Solde);
                result = "Le versement de : " + sommeVerse + " à bien été effectué !";
            }
            else
            {
                result = "Votre solde est inssufisant pour éffectuer le virement";
            }

            return result;
        }

        public override string AfficheCaractCompte()
        {
            string result = "Type de compte : " + TypeCompte + "\nNuméro de compte : " + NumeroCompte
                + " \nNom du titulaire : " + NomPropri + "\nPrénom du titulaire " + PrenomPropri
                + "\nVotre découvert max autorisé : " + DecouvertAut + "\nVotre solde : " + Solde;
            return result;
        }
    }
}
