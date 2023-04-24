using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using WPF_Guichet_Bancaire.Form;

namespace WPF_Guichet_Bancaire.model
{
    public struct Query
    {
        public string DefinirChemin()
        {
            return "Server=localhost;User Id=root;password=;Database=guichetbancaire;Port=3306";
        }

        public bool Login(string email, string password, out MySqlDataReader reader)
        {
            bool isLoginSuccessful;

            MySqlConnection connection = new MySqlConnection(DefinirChemin());
            string queryLogin = "SELECT * FROM users WHERE email=@email AND password=@password";
            MySqlCommand command = new MySqlCommand(queryLogin, connection);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                isLoginSuccessful = true;
            }
            else
            {
                isLoginSuccessful = false;
                MessageBox.Show("Adresse e-mail ou mot de passe incorrect.");
            }
            return isLoginSuccessful;

        }

        public MySqlDataReader selectCompteCourant()
        {
           
            try
            {
                MySqlConnection connection = new MySqlConnection(DefinirChemin());
                string querySelectCompteCourant = "SELECT numeroCompte FROM comptecourant WHERE usersId = @userId";
                MySqlCommand command = new MySqlCommand(querySelectCompteCourant, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                return reader;
                connection.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        
    }
}
