using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using WPF_Guichet_Bancaire.model;

namespace WPF_Guichet_Bancaire.@class
{

    public abstract class CompteBancaire
    {

        protected int _idCompte;

        public int IdCompte
        {
            get { return _idCompte; }
            set { _idCompte = value; }
        }

        protected string _numeroCompte;

        public string NumeroCompte
        {
            get { return _numeroCompte; }
            set { _numeroCompte = value; }
        }

        protected string _nomPropri;

        public string NomPropri
        {
            get { return _nomPropri; }
            set { _nomPropri = value; }
        }

        protected string _prenomPropri;

        public string PrenomPropri
        {
            get { return _prenomPropri; }
            set { _prenomPropri = value; }
        }

        protected double _solde;

        public double Solde
        {
            get { return _solde; }
            set { _solde = value; }
        }

        protected string _typeCompte;

        public string TypeCompte
        {
            get { return _typeCompte; }
            set { _typeCompte = value; }
        }

        public abstract bool VerifSomme(double somme);

        public string Crediter(double sommeAjoute)
        {
            string result;
            try
            {
                MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
                Query query = new Query();
                Solde = Solde + sommeAjoute;
                query.modifSoldeCompteCourant(mainWindow.compteCourantSelect, Solde);
                result = "Votre compte à été créditer de " + sommeAjoute + " euro.";
            }
            catch(Exception ex)
            {
                result = "Votre compte n'a pas pu être créditer !";
                Console.WriteLine("Un problème est survenu : " + ex.Message);
            }

            return result;

        }

        public string Debiter(double sommeRetire)
        {
            string result;
            if (VerifSomme(sommeRetire))
            {
                Solde = Solde - sommeRetire;
                result = "Votre compte : " + NumeroCompte + " à été débité de " + sommeRetire + " euro.";
            }
            else
            {
                result = "Votre compte : " + NumeroCompte + " n'a pas pu être débité de " + sommeRetire + " euro car le solde est insufisant";
            }

            return result;
        }

        public abstract string Versement(CompteBancaire compteBancaire, double somme);

        public abstract string AfficheCaractCompte();
        
    }
}
