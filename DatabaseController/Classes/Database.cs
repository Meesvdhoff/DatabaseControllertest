using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace DatabaseController.Classes
{


    class Database
    {

        private MySqlConnection conn;





        public void Connect()
        {

            string connectionString = "SERVER=localhost;DATABASE=databasecontroller;UID=root;PASSWORD=;";

            conn = new MySqlConnection(connectionString);

            conn.Open();
        }


        public void CheckConn()
        {
            if (conn != null && conn.State == ConnectionState.Closed)
            {
                MessageBox.Show("Something went wrong with the connection!");
            }
        }


        public void Login(string User, string Pass)
        {
            string queryLogin = "SELECT `username`, `password` FROM `login` WHERE `Username` = '" + User + "' AND `Password` = '" + Pass + "'";

            MySqlCommand command = new MySqlCommand(queryLogin, conn);
            command.Parameters.AddWithValue("@user", User);
            command.Parameters.AddWithValue("@pass", Pass);

            command.ExecuteNonQuery();

            
        }

        public void Register ( string User, string Pass)
        {
            string passwordhashed = BCrypt.Net.BCrypt.HashPassword(Pass,BCrypt.Net.BCrypt.GenerateSalt());
            string queryRegister = "INSERT INTO `login`(`Username`, `Password`) VALUES (@user,@pass)";

            MySqlCommand command = new MySqlCommand(queryRegister, conn);
            command.Parameters.AddWithValue("@user", User);
            command.Parameters.AddWithValue("@pass", passwordhashed);
        }

        public void Showdatabases()
        {
            string queryShowdatabases = "Show databases";

            MySqlCommand command = new MySqlCommand(queryShowdatabases, conn);

            command.ExecuteNonQuery();

           
        }
    }
}

