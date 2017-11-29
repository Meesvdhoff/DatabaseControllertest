using DatabaseController.Classes;
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
using System.Windows.Shapes;

namespace DatabaseController
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Database db = new Database();


        public Login()
        {
            InitializeComponent();
            db.Connect();
            db.CheckConn();

        }



        private void CheckAccount()
        {
   
        }

        private void btRegister_Click(object sender, RoutedEventArgs e)
        {
            string User = tbLogin.Text;
            string Pass = pbPass.Password;
            db.Register(User,Pass);
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            string User = tbLogin.Text;
            string Pass = pbPass.Password;
            db.Login(User,Pass);

            this.Hide();
            MainWindow controller = new MainWindow();
            controller.ShowDialog();
        }
    }
}
