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
            int userid;
            //validate
            if (Utils.ValidateEmpty(txtUsername.Text)&&Utils.ValidateEmpty(txtPassword.Text))
            {
                userid = Utils.login(txtUsername.Text, txtPassword.Text);
                if (userid != 0) 
                {
                    MessageBox.Show("Logged In!");
                    MessageBox.Show("Well done there's nothing else with logging in and yes this is completely useless XD");
                }
                else
                {
                    MessageBox.Show("Unsuccessful Log in.");
                }
            }
            else
            {
                MessageBox.Show("Test box was empty. Please try again.");
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            int tempsearchid;
            //validate
            if (Utils.ValidateEmpty(txtUsername.Text)&&Utils.ValidateEmpty(txtPassword.Text)) 
            {
                tempsearchid = Utils.ValidateActiveInRegistry(txtUsername.Text);
                //userid = Utils.register(txtUsername.Text,txtPassword.Text);
                if (tempsearchid != 0)
                {
                    MessageBox.Show("An account with this username has been already created.");
                }
                else
                {
                    MessageBox.Show("No account has been created with these credicentials yet. Creating an account now...");
                    Utils.registerAcc(txtUsername.Text, txtPassword.Text);
                }
            }
            else
            {
                MessageBox.Show("Text box was empty. Please try again.");
            }   
        }
        
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int tempsearchid;
            int userid;
            //validate
            if (Utils.ValidateEmpty(txtUsername.Text) && Utils.ValidateEmpty(txtPassword.Text))
            {
                tempsearchid = Utils.ValidateActiveInRegistry(txtPassword.Text);
                if (tempsearchid != 0)
                {
                    userid = Utils.login(txtUsername.Text, txtPassword.Text);
                    if (userid != 0)
                    {
                        MessageBox.Show("Username and Password successfully verified!");
                        if (MessageBox.Show("Are you sure you'd like to delete this account?", "Final Warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            Utils.deleteAcc(txtUsername.Text, txtPassword.Text);
                        }
                        else
                        {
                            MessageBox.Show("Process has been terminated.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unsuccessful Verification of Username and Password for this action.");
                    }
                }
                else
                {
                    MessageBox.Show("Account with this username couldnt be found, please try again.");
                }
            }
        }
    }
}
