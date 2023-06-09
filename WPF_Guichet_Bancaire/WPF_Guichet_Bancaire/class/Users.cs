﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_Guichet_Bancaire.@class
{
    public class Users
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _nom;

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        private string _prenom;

        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        private DateTime _dateNaissance;

        public DateTime DateNaissance
        {
            get { return _dateNaissance; }
            set { _dateNaissance = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }


        public Users(string nom, string prenom, DateTime dateNaissance, string email,int id, string password)
        {
            _nom = nom;
            _prenom = prenom;
            _dateNaissance = dateNaissance;
            _email = email;
            _id = id;
            _password = password;
        }

        public string AfficheCaractUsers()
        {
            string result = "Nom : " + Nom + " Prenom : " + Prenom + " Date de Naissance : " + DateNaissance
                + " Email " + Email;
            return result;
        }


    }
}
