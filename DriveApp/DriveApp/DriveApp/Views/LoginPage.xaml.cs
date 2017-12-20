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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        UserFuck user = new UserFuck();

        public LoginPage()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Entry_Username.TextColor = Constants.MainTextColor;
            Entry_Password.TextColor = Constants.MainTextColor;
            Entry_Username.Text = "mees.database";
            Entry_Password.Text = "Bezorger1";

            //Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            //Entry_Password.Completed += async (s, e) => await SignInProcedure(s, e);
        }


        private async void SignInProcedure(object sender, EventArgs e)
        {
            
            bool b = user.CheckLogin(Entry_Username.Text, Entry_Password.Text).GetAwaiter().GetResult();
            
            if (b == true)
            {
                await DisplayAlert("Login", "Login Succes", "Oke");
                await Navigation.PushModalAsync(new MainPage(user));
            }
            else
            {
               await  DisplayAlert("Login", "Login Not Correct", "Oke");
            }
        }
    }
}