using System;
using System.Collections.Generic;
using System.Text;
using WPF_Guichet_Bancaire.@class;

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

        public CompteCourant(string numeroCompte, string nomPropri, string prenomPropri, double solde, string typeCompte, double decouvertAut)
        {
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

        public override string Versement(CompteBancaire compteBancaire, double sommeVerse)
        {
            string result;

            if (VerifSomme(sommeVerse))
            {
                compteBancaire.Solde += sommeVerse;
                Solde -= sommeVerse;
                result = "Votre virement de " + sommeVerse + " euros vers le compte " + compteBancaire.NumeroCompte + " à été effectué avec succès";
            }
            else
            {
                result = "Votre solde est inssufisant pour éffectuer le virement";
            }

            return result;
        }

        public override string AfficheCaractCompte()
        {
            string result = "Type de compte : " + TypeCompte + " Numéro de compte : " + NumeroCompte
                + "Nom du titulaire : " + NomPropri + " Prénom du titulaire " + PrenomPropri
                + " Votre découvert max autorisé : " + DecouvertAut + " Votre solde : " + Solde;
            return result;
        }
    }
}
