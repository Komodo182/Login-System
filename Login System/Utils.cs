using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Login_System
{
    public static class Utils
    {
        static string connStr = "Server=ND-COMPSCI;" +
            "User ID=tl_u6;" +
            "Password=uAoDj4xzQLatMMZmy0oPosKuowRBJlie;" +
            "Database=tl_u6_login";
        public static bool ValidateEmpty(string input)
        {
                // return true if not empty
                return input != "";
        }
        public static int ValidateActiveInRegistry(string username) 
        {
            using var connection = new MySqlConnection(connStr);
            connection.Open();
            using var command = new MySqlCommand("SELECT userid FROM users WHERE username = @paramUsername", connection);
            command.Parameters.AddWithValue("@paramUsername", username);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return reader.GetInt32(0);
            }
            else
            {
                return -1;
            }
        }
        public static int login(String username, String password)
        {   
            using var connection = new MySqlConnection(connStr);
            connection.Open();
            using var command = new MySqlCommand("SELECT userid FROM users WHERE username = @paramUsername AND password = @paramPassword", connection);
            command.Parameters.AddWithValue("@paramUsername", username);
            command.Parameters.AddWithValue("@paramPassword", password);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return reader.GetInt32(0);
            }
            else
            {
                return -1;
            }
        }
        public static int registerAcc(String username, String password)
        {
            using var connection = new MySqlConnection(connStr);
            connection.Open();
            using var command = new MySqlCommand("INSERT INTO users (username, password) VALUES (@paramUsername, @paramPassword)", connection);
            command.Parameters.AddWithValue("@paramUsername", username);
            command.Parameters.AddWithValue("@paramPassword", password);
            command.ExecuteNonQuery();
            MessageBox.Show("Account has been registered with these credentials.");
            return -1;
        }
        public static int deleteAcc(String username, String password)
        {
            using var connection = new MySqlConnection(connStr);
            connection.Open();
            using var command = new MySqlCommand("DELETE FROM users WHERE username = @paramUsername AND password = @paramPassword", connection);
            command.Parameters.AddWithValue("@paramUsername", username);
            command.Parameters.AddWithValue("@paramPassword", password);
            command.ExecuteNonQuery();
            MessageBox.Show("Account has been succefully deleted.");
            return -1;
        }
}
