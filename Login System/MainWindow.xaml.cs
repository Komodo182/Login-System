using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySqlConnector;


namespace Login_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string connStr = "Server=ND-COMPSCI;" +
            "User ID=tl_u6;" +
            "Password=uAoDj4xzQLatMMZmy0oPosKuowRBJlie;" +
            "Database=tl_u6_login";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //validate
            if (Utils.Validate(txtUsername.Text) && Utils.Validate(txtPassword.Text))
            {
                using var connection = new MySqlConnection(connStr);
                connection.Open();
                using var command = new MySqlCommand("SELECT userid FROM users WHERE username = @paramUsername AND password = @paramPassword", connection);
                command.Parameters.AddWithValue("@paramUsername", txtUsername.Text);
                command.Parameters.AddWithValue("@paramPassword", txtPassword.Text);
                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show($"User {txtUsername.Text} has ID {reader.GetInt32(0)}");
                }
                else
                {
                    MessageBox.Show($"User {txtUsername.Text} not found");
                }
            }
            else
            {
                MessageBox.Show("Textbox was blank!");
            }

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            using var connection = new MySqlConnection(connStr);
            connection.Open();
            using var command = new MySqlCommand("INSERT INTO users (username, password) VALUES (@paramUsername, @paramPassword)", connection);
            command.Parameters.AddWithValue("@paramUsername", txtUsername.Text);
            command.Parameters.AddWithValue("@paramPassword", txtPassword.Text);
            command.ExecuteNonQuery();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            using var connection = new MySqlConnection(connStr);
            connection.Open();
            using var command = new MySqlCommand("DELETE FROM users WHERE username = @paramUsername AND password = @paramPassword", connection);
            command.Parameters.AddWithValue("@paramUsername", txtUsername.Text);
            command.Parameters.AddWithValue("@paramPassword", txtPassword.Text);
            command.ExecuteNonQuery();
        }
    }
}
