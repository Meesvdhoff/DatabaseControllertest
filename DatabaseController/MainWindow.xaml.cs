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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db = new Database();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btCreatedb_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow dbCreate = new MainWindow();
            dbCreate.ShowDialog();
        }

        private void btViewdb_Click(object sender, RoutedEventArgs e)
        {

            db.Showdatabases();
        }
    }
}
