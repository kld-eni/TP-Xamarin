using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin_Module4.Services;

namespace Xamarin_Module4
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly ITwitterService twitterService = new TwitterService();

        public MainPage()
        {
            InitializeComponent();
        }

        public async void Connection_Clicked(object sender, EventArgs e)
        {
            ErrorDisplay(false);

            if (login.Text == null || string.IsNullOrEmpty(login.Text.ToString()))
            {
                ErrorDisplay(true, "Identifiant obligatoire");
                return;
            }
            if (login.Text.Length < 3)
            {
                ErrorDisplay(true, "L'identifiant doit faire au moins 3 caractères");
                return;
            }
            if (password.Text == null || string.IsNullOrEmpty(password.Text.ToString()))
            {
                ErrorDisplay(true, "Mot de passe obligatoire");
                return;
            }
            if (password.Text.Length < 6)
            {
                ErrorDisplay(true, "Le mot de passe doit faire au moins 6 caractères");
                return;
            }

            NetworkAccess networkAccess = Connectivity.NetworkAccess;
            if (networkAccess != NetworkAccess.Internet)
            {
                ErrorDisplay(true, "Veuillez vous connecter à internet");
                return;
            }
            if (!twitterService.Authenticate(login.Text, password.Text))
            {
                ErrorDisplay(true, "L'identifiant et/ou le mot de passe sont incorrects");
                return;
            }
            await Navigation.PushAsync(new TweetsPage());
        }

        private void ErrorDisplay(bool visibility, string message = null)
        {
            if (message != null)
            {
                error.Text = message;
            }
            error.IsVisible = visibility;
        }
    }
}
