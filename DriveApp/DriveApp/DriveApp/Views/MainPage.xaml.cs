using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriveApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DriveApp
{
    public partial class MainPage : ContentPage
    {
        UserFuck user { get; set; }

        public MainPage(UserFuck user)
        {
            InitializeComponent();
            Init();
            this.user = user;
        }

        public void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            lvs.ItemsSource = user.Ritten;
        } 




    }
}
