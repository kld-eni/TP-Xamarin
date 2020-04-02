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

        public void Connection_Clicked(object sender, EventArgs e)
        {
            this.ErrorDisplay(false);

            if (this.login.Text == null || string.IsNullOrEmpty(this.login.Text.ToString()))
            {
                this.ErrorDisplay(true, "Identifiant obligatoire");
                return;
            }
            if (this.login.Text.Length < 3)
            {
                this.ErrorDisplay(true, "L'identifiant doit faire au moins 3 caractères");
                return;
            }
            if (this.password.Text == null || string.IsNullOrEmpty(this.password.Text.ToString()))
            {
                this.ErrorDisplay(true, "Mot de passe obligatoire");
                return;
            }
            if (this.password.Text.Length < 6)
            {
                this.ErrorDisplay(true, "Le mot de passe doit faire au moins 6 caractères");
                return;
            }
            NetworkAccess networkAccess = Connectivity.NetworkAccess;

            if (networkAccess != NetworkAccess.Internet)
            {
                this.ErrorDisplay(true, "Veuillez vous connecter à internet");
                return;
            }
            if (!this.twitterService.Authenticate(this.login.Text, this.password.Text))
            {
                this.ErrorDisplay(true, "L'identifiant et/ou le mot de passe sont incorrects");
                return;
            }
            this.TweetsList.ItemsSource = twitterService.GetTweets();
            this.ShowContent();
        }

        private void ErrorDisplay(bool visibility, string message = null)
        {
            if (message != null)
            {
                this.error.Text = message;
            }
            this.error.IsVisible = visibility;
        }

        private void ShowContent()
        {
            this.loginForm.IsVisible = false;
            this.content.IsVisible = true;
        }
    }
}
