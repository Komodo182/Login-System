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
        public static bool Validate(string input)
        {
                // return true if not empty
                return input != "";
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
    }
}
