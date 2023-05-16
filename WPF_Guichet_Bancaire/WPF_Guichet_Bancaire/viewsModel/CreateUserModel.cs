using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Guichet_Bancaire.@class;

namespace WPF_Guichet_Bancaire.viewsModel
{
    public struct CreateUserModel
    {
        public Users createObjetUser(MySqlDataReader reader)
        {
            reader.Read();
            int id = reader.GetInt32("usersId");
            string nom = reader.GetString("nom");
            string prenom = reader.GetString("prenom");
            DateTime date = DateTime.Parse(reader.GetString("dateNaissance"));
            string email = reader.GetString("email");
            string password = reader.GetString("password");
            Users user = new Users(nom, prenom, date, email, id,password);
            return user;
        }
    }
}
