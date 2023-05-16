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
using WPF_Guichet_Bancaire.@class;
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

        public MySqlDataReader selectCompteCourant(int userId)
        {
           
            try
            {
                MySqlConnection connection = new MySqlConnection(DefinirChemin());
                string querySelectCompteCourant = "SELECT * FROM comptecourant WHERE usersId = @userId";
                MySqlCommand command = new MySqlCommand(querySelectCompteCourant, connection);
                command.Parameters.AddWithValue("@userId", userId);
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

        public MySqlDataReader selectCompteEpargne(int userId)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(DefinirChemin());
                string querySelectCompteEpargne = "SELECT * FROM compteepargne WHERE usersId = @userId";
                MySqlCommand command = new MySqlCommand(querySelectCompteEpargne, connection);
                command.Parameters.AddWithValue("@userId", userId);
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

        public bool ModifProfil()
        {
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
            Users user = mainWindow.monUser;
            try
            {
                MySqlConnection connection = new MySqlConnection(DefinirChemin());
                string queryModifProfil = "UPDATE users SET nom = @nom, prenom = @prenom, email = @email, password = @mdp WHERE usersId = @id";
                MySqlCommand command = new MySqlCommand(queryModifProfil, connection);
                command.Parameters.AddWithValue("@nom", user.Nom);
                command.Parameters.AddWithValue("@prenom", user.Prenom);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@mdp", user.Password);
                command.Parameters.AddWithValue("@id", user.Id);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int selectIdCompteCourant(string numeroCompte)
        {
            int compteCourantId = 0;
            try
            {
                MySqlConnection connection = new MySqlConnection(DefinirChemin());
                string querySelectIdCompteCourant = "SELECT compteEpargneId FROM comptecourant WHERE numeroCompte = @numeroCompte";
                MySqlCommand command = new MySqlCommand(querySelectIdCompteCourant,connection);
                command.Parameters.AddWithValue("@numeroCompte",numeroCompte);
                connection.Open();
                compteCourantId = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Une erreur s'est produite : " + ex.Message);
            }

            return compteCourantId;
        }

        public int selectIdCompteEpargne(string numeroCompte)
        {
            int compteEpargneId = 0;
            try
            {
                MySqlConnection connection = new MySqlConnection(DefinirChemin());
                string querySelectIdCompteEpargne = "SELECT compteEpargneId FROM compteepargne WHERE numeroCompte = @numeroCompte";
                MySqlCommand command = new MySqlCommand(querySelectIdCompteEpargne, connection);
                command.Parameters.AddWithValue("@numeroCompte", numeroCompte);
                connection.Open();
                compteEpargneId = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur s'est produite : " + ex.Message);
            }

            return compteEpargneId;
        }

        public void modifSoldeCompteCourant(int idCompteCourant,double solde)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(DefinirChemin());
                string queryModifSoldeCompteCourant = "UPDATE comptecourant SET solde = @solde WHERE compteEpargneId = @idCompteCourant";
                MySqlCommand command = new MySqlCommand(queryModifSoldeCompteCourant, connection);
                command.Parameters.AddWithValue("@solde", solde);
                command.Parameters.AddWithValue("@idCompteCourant", idCompteCourant);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur s'est produite : " + ex.Message);
            }
        }


        public void modifSoldeCompteEpargne(int idCompteEpargne, double solde)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(DefinirChemin());
                string queryModifSoldeCompteEpargne = "UPDATE compteEpargne SET solde = @solde WHERE compteEpargneId = @idCompteEpargne";
                MySqlCommand command = new MySqlCommand(queryModifSoldeCompteEpargne, connection);
                command.Parameters.AddWithValue("@solde", solde);
                command.Parameters.AddWithValue("@idCompteEpargne", idCompteEpargne);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur s'est produite : " + ex.Message);
            }
        }

    }
}
